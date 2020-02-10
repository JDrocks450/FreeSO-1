using FSO.Client.UI.Controls;
using FSO.Client.UI.Framework;
using FSO.Common.Rendering.Emoji;
using FSO.Files.Formats.IFF.Chunks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Client.UI.Panels
{
    public class UILotLanguageDialog : UIDialog
    {        
        public const int MAX_LANGS = 3; // max of 3 languages per lot
        /// <summary>
        /// Emoji to display for each language
        /// </summary>
        private static Dictionary<STRLangCode, string> langEmojiTable = new Dictionary<STRLangCode, string>()
        {
            { STRLangCode.EnglishUS, "us" },
            { STRLangCode.Italian, "it" },
            { STRLangCode.Danish, "denmark" },
            { STRLangCode.Dutch, "netherlands" },
            { STRLangCode.Finish, "finland" },
            { STRLangCode.French, "fr" },
            { STRLangCode.German, "de" },
            { STRLangCode.Japanese, "jp" },
            { STRLangCode.Korean, "kr" },
            { STRLangCode.Spanish, "es" },
        };
        private Dictionary<Vector2, Rectangle> emojiPositions; // The positions to draw each emoji at, with the second specifying which emoji to draw

        private UIButton ButtonOK;
        private UIButton ButtonCancel;
        private List<STRLangCode> selectedLanguages; // the currently selected languages for the lot

        public int SelectedLanguages => selectedLanguages.Count;

        public UILotLanguageDialog() : base(UIDialogStyle.Tall, true)
        {
            Caption = "Primary Language";
            selectedLanguages = new List<STRLangCode>();
            SetupUI();
        }

        private void SetupUI()
        {
            emojiPositions = new Dictionary<Vector2, Rectangle>();
            int margin_left = 30, margin_top = 50, 
                height = 20, i = 0, w = 250;
            var pickLabel = new UILabel()
            {
                Caption = $"Pick up to {MAX_LANGS} languages",
                Wrapped = true,
                Size = new Vector2(w, 30),
                Position = new Vector2(0, margin_top - 7)
            };
            Add(pickLabel);
            i++;
            foreach(var lang in langEmojiTable)
            {
                var langString = lang.Key == STRLangCode.EnglishUS ? "English" : Enum.GetName(typeof(STRLangCode), lang.Key);
                var checkBox = new FSO.Client.UI.Controls.UIRadioButton()
                {
                    Position = new Microsoft.Xna.Framework.Vector2(margin_left, margin_top + height * i),
                    RadioGroup = null,  
                    RadioData = lang.Key //marks which Language this radio button represents
                };
                checkBox.OnButtonClick += LanguageSelected;
                Add(checkBox);
                Add(new UILabel()
                {
                    Position = new Microsoft.Xna.Framework.Vector2(margin_left + 25, margin_top + height * i),
                    Caption = langString,                    
                });
                var emoji = GetEmojiRectByLang(lang.Key);
                emojiPositions.Add(new Microsoft.Xna.Framework.Vector2(margin_left + 170, margin_top + height * i), emoji);
                i++;
            }
            int h = i * height + 2 * margin_top + 10;            
            ButtonCancel = new UIButton()
            {
                Position = new Vector2(30, h - 50),
                Caption = "Cancel",
            };
            ButtonCancel.OnButtonClick += ButtonCancel_OnButtonClick;
            Add(ButtonCancel);
            ButtonOK = new UIButton()
            {
                Size = ButtonCancel.Size, // looks nicer if they're both the same size
                Position = new Vector2(w - 118, h - 50),
                Caption = "OK",
            };
            ButtonOK.OnButtonClick += ButtonOK_OnButtonClick;
            Add(ButtonOK);
            SetSize(w,h);
        }

        private void ButtonOK_OnButtonClick(UIElement button)
        {
            UIScreen.RemoveDialog(this);
        }

        private void LanguageSelected(UIElement button)
        {
            var radio = button as UIRadioButton;
            radio.Selected = (SelectedLanguages < MAX_LANGS) ? !radio.Selected : false; // make sure only MAX_LANGS are selected
            if (radio.Selected)
                selectedLanguages.Add((STRLangCode)radio.RadioData);
            else
                selectedLanguages.Remove((STRLangCode)radio.RadioData);
        }

        private void ButtonCancel_OnButtonClick(UIElement button)
        {
            UIScreen.RemoveDialog(this);
        }

        /// <summary>
        /// Gets a flag emoji by language, if there is one defined - "X" emoji is returned by default
        /// </summary>
        /// <param name="Lang">The language to find a flag for</param>
        /// <returns></returns>
        public static Rectangle GetEmojiRectByLang(STRLangCode Lang)
        {
            var provider = GameFacade.Emojis;
            var emojiName = "x";
            if (!langEmojiTable.TryGetValue(Lang, out emojiName))
                emojiName = "x";
            try
            {
                var emojiBB = GameFacade.Emojis.EmojiFromName(emojiName);
                return provider.GetEmoji(emojiBB).Item2;
            }
            catch (Exception)
            {
                var emojiBB = GameFacade.Emojis.EmojiFromName("x");
                return provider.GetEmoji(emojiBB).Item2;
            }
            
        }

        public override void Draw(UISpriteBatch batch)
        {  
            base.Draw(batch);          
            var emojis = GameFacade.Emojis.Cache.EmojiTex;
            foreach(var Emoji in emojiPositions) // where the magic happens (emoji rendering)
                DrawLocalTexture(batch, emojis, Emoji.Value, Emoji.Key, new Vector2(16/24f));            
        }
    }
}

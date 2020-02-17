using FSO.Client.UI.Controls;
using FSO.Client.UI.Framework.Parser;
using FSO.SimAntics.NetPlay.EODs.Handlers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Client.UI.Panels.EODs
{
    public class UIPartyEOD : UIEOD
    {
        private UIScript Script;
        private UIImage background;
        private VMEODPartyState State;
        public UIPartyEOD(UIEODController controller) : base(controller)
        {
            var script = this.RenderScript("pizzamakereod.uis");
            Script = script;

            background = script.Create<UIImage>("background");
            AddAt(0, background);

            //make sure our plugin handlers are setup
            PlaintextHandlers["party_show"] = P_Show;
            PlaintextHandlers["party_state"] = P_State;
            PlaintextHandlers["party_time"] = P_Time;
            //PlaintextHandlers["pizza_result"] = P_Result;
            //PlaintextHandlers["pizza_contrib"] = P_Contrib;
            //PlaintextHandlers["pizza_hand"] = P_Hand;
            PlaintextHandlers["party_players"] = P_Players;
        }

        private void P_Show(string evt, string body)
        {
            EODController.ShowEODMode(new EODLiveModeOpt
            {
                Buttons = 0,
                Expandable = false,
                Height = EODHeight.Tall,
                Length = EODLength.Full,
                Timer = EODTimer.Normal,
                Tips = EODTextTips.Short
            });
        }

        private void P_State(string evt, string body)
        {
            var state = (VMEODPartyState)byte.Parse(body);
            EnterState(state);
        }

        private void P_Time(string evt, string body)
        {
            int time = 0;
            int.TryParse(body, out time);
            SetTime(time);
        }

        private void P_Players(string evt, string body)
        {
            SetTip("A host has volenteered to help out!");
            //throw new NotImplementedException();
        }

        private void EnterState(VMEODPartyState state)
        {
            State = state;
            switch (State)
            {
                case VMEODPartyState.Lobby:
                    SetTip("Waiting for the guests to arrive...");
                    break;
            }
        }
    }
}

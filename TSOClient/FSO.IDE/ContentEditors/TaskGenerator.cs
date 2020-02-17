using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSO.IDE.ContentEditors
{
    public struct FSOAbstractTaskData
    {
        public string Title, Description, Role;
        public int TotalActions;
    }
    public partial class TaskGenerator : Form
    {
        private List<FSOAbstractTaskData> data = new List<FSOAbstractTaskData>();
        public TaskGenerator()
        {
            InitializeComponent();
            RoleSwitcher.Items.AddRange(new object[] {
                "Host", "Guest", "Saboteur" });
        }

        private void AddTask_Click(object sender, EventArgs e)
        {
            data.Add(new FSOAbstractTaskData()
            {
                Title = TitleBox.Text,
                Description = DescBox.Text,
                Role = RoleBox.Text,
                TotalActions = (int)TotalActions.Value
            });
            TaskSetDisplay.Items.Add(new ListViewItem()
            {
                Text = data.Last().Title
            });
        }

        private void ExportTaskSet_Click(object sender, EventArgs e)
        {

        }
    }
}

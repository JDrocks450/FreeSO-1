namespace FSO.IDE.ContentEditors
{
    partial class TaskGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskGenerator));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RoleSwitcher = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RoleBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TotalActions = new System.Windows.Forms.NumericUpDown();
            this.AddTask = new System.Windows.Forms.Button();
            this.TaskSetDisplay = new System.Windows.Forms.ListView();
            this.ExportTaskSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TotalActions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Task Title";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(15, 75);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(476, 20);
            this.TitleBox.TabIndex = 2;
            // 
            // DescBox
            // 
            this.DescBox.Location = new System.Drawing.Point(15, 129);
            this.DescBox.Multiline = true;
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(476, 41);
            this.DescBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Target Player - PartyEOD";
            // 
            // RoleSwitcher
            // 
            this.RoleSwitcher.FormattingEnabled = true;
            this.RoleSwitcher.Location = new System.Drawing.Point(13, 206);
            this.RoleSwitcher.Name = "RoleSwitcher";
            this.RoleSwitcher.Size = new System.Drawing.Size(219, 21);
            this.RoleSwitcher.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "OR";
            // 
            // RoleBox
            // 
            this.RoleBox.Location = new System.Drawing.Point(267, 207);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(224, 20);
            this.RoleBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Target Custom Player Role";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Number Of Actions Needed:";
            // 
            // TotalActions
            // 
            this.TotalActions.Location = new System.Drawing.Point(159, 245);
            this.TotalActions.Name = "TotalActions";
            this.TotalActions.Size = new System.Drawing.Size(332, 20);
            this.TotalActions.TabIndex = 11;
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(12, 282);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(479, 23);
            this.AddTask.TabIndex = 12;
            this.AddTask.Text = "Add Task";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // TaskSetDisplay
            // 
            this.TaskSetDisplay.HideSelection = false;
            this.TaskSetDisplay.Location = new System.Drawing.Point(12, 311);
            this.TaskSetDisplay.Name = "TaskSetDisplay";
            this.TaskSetDisplay.Size = new System.Drawing.Size(479, 134);
            this.TaskSetDisplay.TabIndex = 13;
            this.TaskSetDisplay.UseCompatibleStateImageBehavior = false;
            // 
            // ExportTaskSet
            // 
            this.ExportTaskSet.Location = new System.Drawing.Point(12, 451);
            this.ExportTaskSet.Name = "ExportTaskSet";
            this.ExportTaskSet.Size = new System.Drawing.Size(479, 23);
            this.ExportTaskSet.TabIndex = 14;
            this.ExportTaskSet.Text = "Export Task Set";
            this.ExportTaskSet.UseVisualStyleBackColor = true;
            this.ExportTaskSet.Click += new System.EventHandler(this.ExportTaskSet_Click);
            // 
            // TaskGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 484);
            this.Controls.Add(this.ExportTaskSet);
            this.Controls.Add(this.TaskSetDisplay);
            this.Controls.Add(this.AddTask);
            this.Controls.Add(this.TotalActions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RoleSwitcher);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DescBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TaskGenerator";
            this.Text = "Task Generator";
            ((System.ComponentModel.ISupportInitialize)(this.TotalActions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RoleSwitcher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RoleBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown TotalActions;
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.ListView TaskSetDisplay;
        private System.Windows.Forms.Button ExportTaskSet;
    }
}
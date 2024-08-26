namespace CodeGenerator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panel1 = new Panel();
            button1 = new Button();
            splitContainer1 = new SplitContainer();
            treeView_tableList = new TreeView();
            panel3 = new Panel();
            dataGridView_tableInfo = new DataGridView();
            panel2 = new Panel();
            button2 = new Button();
            labelLoading = new Label();
            button4 = new Button();
            textBox_ConnectionName = new TextBox();
            label6 = new Label();
            textBox_pre = new TextBox();
            label5 = new Label();
            textBox_BuildPath = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox_Project = new TextBox();
            button3 = new Button();
            checkedListBox_template = new CheckedListBox();
            textBox_Company = new TextBox();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_tableInfo).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1234, 52);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(4, 5);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(112, 38);
            button1.TabIndex = 0;
            button1.Text = "切换数据库";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 52);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView_tableList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1234, 800);
            splitContainer1.SplitterDistance = 275;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 1;
            // 
            // treeView_tableList
            // 
            treeView_tableList.CheckBoxes = true;
            treeView_tableList.Dock = DockStyle.Fill;
            treeView_tableList.Location = new Point(0, 0);
            treeView_tableList.Margin = new Padding(4, 5, 4, 5);
            treeView_tableList.Name = "treeView_tableList";
            treeView_tableList.Size = new Size(275, 800);
            treeView_tableList.TabIndex = 0;
            treeView_tableList.AfterCheck += treeView_tableList_AfterCheck;
            treeView_tableList.AfterSelect += treeView_tableList_AfterSelect;
            treeView_tableList.NodeMouseDoubleClick += treeView_tableList_DoubleClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView_tableInfo);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(953, 418);
            panel3.TabIndex = 1;
            // 
            // dataGridView_tableInfo
            // 
            dataGridView_tableInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_tableInfo.Dock = DockStyle.Fill;
            dataGridView_tableInfo.Location = new Point(0, 0);
            dataGridView_tableInfo.Margin = new Padding(4, 5, 4, 5);
            dataGridView_tableInfo.Name = "dataGridView_tableInfo";
            dataGridView_tableInfo.RowHeadersWidth = 51;
            dataGridView_tableInfo.RowTemplate.Height = 23;
            dataGridView_tableInfo.Size = new Size(953, 418);
            dataGridView_tableInfo.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(labelLoading);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(textBox_ConnectionName);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox_pre);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox_BuildPath);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox_Project);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(checkedListBox_template);
            panel2.Controls.Add(textBox_Company);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 428);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(953, 372);
            panel2.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(771, 240);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(112, 38);
            button2.TabIndex = 19;
            button2.Text = "仅EDB";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelLoading
            // 
            labelLoading.AutoSize = true;
            labelLoading.Location = new Point(550, 310);
            labelLoading.Margin = new Padding(4, 0, 4, 0);
            labelLoading.Name = "labelLoading";
            labelLoading.Size = new Size(0, 20);
            labelLoading.TabIndex = 18;
            // 
            // button4
            // 
            button4.Location = new Point(650, 240);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(112, 38);
            button4.TabIndex = 17;
            button4.Text = "模板全选";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox_ConnectionName
            // 
            textBox_ConnectionName.Location = new Point(648, 35);
            textBox_ConnectionName.Margin = new Padding(4, 5, 4, 5);
            textBox_ConnectionName.Name = "textBox_ConnectionName";
            textBox_ConnectionName.Size = new Size(190, 27);
            textBox_ConnectionName.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(645, 10);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 15;
            label6.Text = "数据库连接名称";
            // 
            // textBox_pre
            // 
            textBox_pre.Location = new Point(411, 35);
            textBox_pre.Margin = new Padding(4, 5, 4, 5);
            textBox_pre.Name = "textBox_pre";
            textBox_pre.Size = new Size(190, 27);
            textBox_pre.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(408, 10);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 13;
            label5.Text = "隐藏表前缀";
            // 
            // textBox_BuildPath
            // 
            textBox_BuildPath.Location = new Point(411, 243);
            textBox_BuildPath.Margin = new Padding(4, 5, 4, 5);
            textBox_BuildPath.Name = "textBox_BuildPath";
            textBox_BuildPath.Size = new Size(190, 27);
            textBox_BuildPath.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(408, 218);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 11;
            label4.Text = "生成位置:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(658, 135);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 10;
            label3.Text = "项目名称:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(408, 135);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 9;
            label2.Text = "组织名称:";
            // 
            // textBox_Project
            // 
            textBox_Project.Location = new Point(648, 160);
            textBox_Project.Margin = new Padding(4, 5, 4, 5);
            textBox_Project.Name = "textBox_Project";
            textBox_Project.Size = new Size(190, 27);
            textBox_Project.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(411, 288);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(112, 63);
            button3.TabIndex = 7;
            button3.Text = "生成";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkedListBox_template
            // 
            checkedListBox_template.FormattingEnabled = true;
            checkedListBox_template.Location = new Point(9, 10);
            checkedListBox_template.Margin = new Padding(4, 5, 4, 5);
            checkedListBox_template.Name = "checkedListBox_template";
            checkedListBox_template.Size = new Size(373, 334);
            checkedListBox_template.TabIndex = 6;
            // 
            // textBox_Company
            // 
            textBox_Company.Location = new Point(411, 160);
            textBox_Company.Margin = new Padding(4, 5, 4, 5);
            textBox_Company.Name = "textBox_Company";
            textBox_Company.Size = new Size(190, 27);
            textBox_Company.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(408, 93);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 4;
            label1.Text = "命名空间:";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 852);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMain";
            Text = "知数能快速开发框架系统-v1.0-代码生成器";
            Load += FormMain_Load;
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_tableInfo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_tableList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_tableInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_Company;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox_template;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_Project;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_BuildPath;
        private System.Windows.Forms.Label label4;
        private TextBox textBox_pre;
        private Label label5;
        private TextBox textBox_ConnectionName;
        private Label label6;
        private Button button4;
        private Label labelLoading;
        private Button button2;
    }
}
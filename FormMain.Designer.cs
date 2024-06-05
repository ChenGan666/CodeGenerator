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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_tableList = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_tableInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.labelLoading = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_ConnectionName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_pre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_BuildPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Project = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkedListBox_template = new System.Windows.Forms.CheckedListBox();
            this.textBox_Company = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tableInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 31);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "切换数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_tableList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(823, 480);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView_tableList
            // 
            this.treeView_tableList.CheckBoxes = true;
            this.treeView_tableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_tableList.Location = new System.Drawing.Point(0, 0);
            this.treeView_tableList.Name = "treeView_tableList";
            this.treeView_tableList.Size = new System.Drawing.Size(184, 480);
            this.treeView_tableList.TabIndex = 0;
            this.treeView_tableList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_tableList_AfterCheck);
            this.treeView_tableList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_tableList_AfterSelect);
            this.treeView_tableList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_tableList_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_tableInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(635, 251);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView_tableInfo
            // 
            this.dataGridView_tableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_tableInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_tableInfo.Name = "dataGridView_tableInfo";
            this.dataGridView_tableInfo.RowTemplate.Height = 23;
            this.dataGridView_tableInfo.Size = new System.Drawing.Size(635, 251);
            this.dataGridView_tableInfo.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.labelLoading);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.textBox_ConnectionName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox_pre);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox_BuildPath);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_Project);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.checkedListBox_template);
            this.panel2.Controls.Add(this.textBox_Company);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 223);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(514, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "仅EDB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(367, 186);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(0, 12);
            this.labelLoading.TabIndex = 18;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(433, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "模板全选";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox_ConnectionName
            // 
            this.textBox_ConnectionName.Location = new System.Drawing.Point(432, 21);
            this.textBox_ConnectionName.Name = "textBox_ConnectionName";
            this.textBox_ConnectionName.Size = new System.Drawing.Size(128, 21);
            this.textBox_ConnectionName.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "数据库连接名称";
            // 
            // textBox_pre
            // 
            this.textBox_pre.Location = new System.Drawing.Point(274, 21);
            this.textBox_pre.Name = "textBox_pre";
            this.textBox_pre.Size = new System.Drawing.Size(128, 21);
            this.textBox_pre.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "隐藏表前缀";
            // 
            // textBox_BuildPath
            // 
            this.textBox_BuildPath.Location = new System.Drawing.Point(274, 146);
            this.textBox_BuildPath.Name = "textBox_BuildPath";
            this.textBox_BuildPath.Size = new System.Drawing.Size(128, 21);
            this.textBox_BuildPath.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "生成位置:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "项目名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "组织名称:";
            // 
            // textBox_Project
            // 
            this.textBox_Project.Location = new System.Drawing.Point(432, 96);
            this.textBox_Project.Name = "textBox_Project";
            this.textBox_Project.Size = new System.Drawing.Size(128, 21);
            this.textBox_Project.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 7;
            this.button3.Text = "生成";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkedListBox_template
            // 
            this.checkedListBox_template.FormattingEnabled = true;
            this.checkedListBox_template.Location = new System.Drawing.Point(6, 6);
            this.checkedListBox_template.Name = "checkedListBox_template";
            this.checkedListBox_template.Size = new System.Drawing.Size(250, 212);
            this.checkedListBox_template.TabIndex = 6;
            // 
            // textBox_Company
            // 
            this.textBox_Company.Location = new System.Drawing.Point(274, 96);
            this.textBox_Company.Name = "textBox_Company";
            this.textBox_Company.Size = new System.Drawing.Size(128, 21);
            this.textBox_Company.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "命名空间:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 511);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "代码生成器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tableInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
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
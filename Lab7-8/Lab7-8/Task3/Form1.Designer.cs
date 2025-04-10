namespace Task3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TreeView treeView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxPath = new TextBox();
            buttonBack = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            textBoxName = new TextBox();
            buttonCreate = new Button();
            buttonDelete = new Button();
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(270, 12);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.ReadOnly = true;
            textBoxPath.Size = new Size(460, 23);
            textBoxPath.TabIndex = 1;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(736, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(60, 23);
            buttonBack.TabIndex = 2;
            buttonBack.Text = "Back";
            buttonBack.Click += buttonBack_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(270, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(526, 370);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Size";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Extension";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Created";
            columnHeader4.Width = 150;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(270, 420);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 23);
            textBoxName.TabIndex = 4;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(476, 420);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(100, 23);
            buttonCreate.TabIndex = 5;
            buttonCreate.Text = "Create";
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(582, 420);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 23);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(250, 400);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // Form1
            // 
            ClientSize = new Size(808, 460);
            Controls.Add(treeView1);
            Controls.Add(textBoxPath);
            Controls.Add(buttonBack);
            Controls.Add(listView1);
            Controls.Add(textBoxName);
            Controls.Add(buttonCreate);
            Controls.Add(buttonDelete);
            Name = "Form1";
            Text = "FileManagerApp";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

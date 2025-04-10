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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(270, 12);
            this.textBoxPath.Size = new System.Drawing.Size(460, 22);
            this.textBoxPath.ReadOnly = true;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(736, 12);
            this.buttonBack.Size = new System.Drawing.Size(60, 23);
            this.buttonBack.Text = "Back";
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Size = new System.Drawing.Size(250, 400);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(270, 40);
            this.listView1.Size = new System.Drawing.Size(526, 370);
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Extension";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Created";
            this.columnHeader4.Width = 150;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(270, 420);
            this.textBoxName.Size = new System.Drawing.Size(200, 22);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(476, 420);
            this.buttonCreate.Size = new System.Drawing.Size(100, 23);
            this.buttonCreate.Text = "Create";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(582, 420);
            this.buttonDelete.Size = new System.Drawing.Size(100, 23);
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(808, 460);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonDelete);
            this.Name = "Form1";
            this.Text = "FileManagerApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

namespace Lab5_6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer code

        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            SuspendLayout();

            treeView1.Location = new Point(10, 9);
            treeView1.Margin = new Padding(3, 2, 3, 2);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(507, 432);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 452);
            Controls.Add(treeView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Lab 5-6: Reflection and TreeView";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}

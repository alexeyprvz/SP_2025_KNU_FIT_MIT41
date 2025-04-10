using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task3
{
    public partial class Form1 : Form
    {
        private string currentPath;

        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            TreeNode rootNode;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    rootNode = new TreeNode(drive.Name)
                    {
                        Tag = drive.RootDirectory
                    };
                    rootNode.Nodes.Add("...");
                    treeView1.Nodes.Add(rootNode);
                }
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "...")
            {
                e.Node.Nodes.Clear();
                DirectoryInfo dir = (DirectoryInfo)e.Node.Tag;
                try
                {
                    foreach (DirectoryInfo subDir in dir.GetDirectories())
                    {
                        TreeNode node = new TreeNode(subDir.Name) { Tag = subDir };
                        node.Nodes.Add("...");
                        e.Node.Nodes.Add(node);
                    }
                }
                catch { }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is DirectoryInfo dir)
            {
                LoadDirectory(dir.FullName);
            }
        }

        private void LoadDirectory(string path)
        {
            try
            {
                listView1.Items.Clear();
                currentPath = path;
                textBoxPath.Text = path;

                DirectoryInfo dirInfo = new DirectoryInfo(path);

                foreach (var dir in dirInfo.GetDirectories())
                {
                    var item = new ListViewItem(dir.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add("Directory");
                    item.SubItems.Add(dir.CreationTime.ToString());
                    item.Tag = dir.FullName;
                    listView1.Items.Add(item);
                }

                foreach (var file in dirInfo.GetFiles())
                {
                    var item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.Extension);
                    item.SubItems.Add(file.CreationTime.ToString());
                    item.Tag = file.FullName;
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedPath = listView1.SelectedItems[0].Tag.ToString();
                if (Directory.Exists(selectedPath))
                {
                    LoadDirectory(selectedPath);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string parent = Directory.GetParent(currentPath)?.FullName;
            if (parent != null)
            {
                LoadDirectory(parent);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            string fullPath = Path.Combine(currentPath, name);

            try
            {
                if (name.Contains("."))
                    File.Create(fullPath).Close();
                else
                    Directory.CreateDirectory(fullPath);
                LoadDirectory(currentPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            string path = listView1.SelectedItems[0].Tag.ToString();

            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
                else if (File.Exists(path))
                    File.Delete(path);

                LoadDirectory(currentPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення: " + ex.Message);
            }
        }
    }
}

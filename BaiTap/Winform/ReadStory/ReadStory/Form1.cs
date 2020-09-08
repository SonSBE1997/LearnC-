using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ReadStory
{
    public partial class Form1 : Form
    {
        //string path = @"D:\";


        public Form1()
        {
            TreeNode root1 = new TreeNode(@"D:\");
            TreeNode root2 = new TreeNode(@"E:\");
            InitializeComponent();
            treeView1.Nodes.Add(root1);
            treeView1.Nodes.Add(root2);
            LoadExplorer(root1);
            LoadExplorer(root2);
        }

        void LoadExplorer(TreeNode root)
        {
            if (root == null) return;
            try
            {
                FileInfo[] listFile = new DirectoryInfo(root.Text).GetFiles();
                if (listFile.Length != 0)
                {
                    foreach (FileInfo item in listFile)
                    {
                        TreeNode node = new TreeNode(item.FullName);
                        root.Nodes.Add(node);
                    }
                }

                DirectoryInfo[] listDirectory = new DirectoryInfo(root.Text).GetDirectories();
                if (listDirectory.Length != 0)
                {
                    foreach (DirectoryInfo item in listDirectory)
                    {
                        TreeNode node = new TreeNode(item.FullName);
                        root.Nodes.Add(node);
                        LoadExplorer(node);
                    }
                }
            }
            catch { }
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            textBox1.Text = e.Node.Text;
            if (e.Node.Text.Contains(".pdf") || e.Node.Text.Contains(".txt") || e.Node.Text.Contains(".doc"))
            {
                FileInfo file = new FileInfo(e.Node.Text);
                ReadFile read = new ReadFile(file);
                read.ShowDialog();
            }
        }

    }
}

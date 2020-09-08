using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DemoTreeView
{
    public partial class Form1 : Form
    {
        string path = @"D:\";
        public Form1()
        {
            InitializeComponent();
            if (Directory.Exists(path))
            {
                TreeNode root = new TreeNode(path);
                trvFolder.Nodes.Add(root);
                LoadExplorer(root);
            }
        }

        void LoadExplorer(TreeNode root)
        {
            if (root == null) return;

            try
            {
                FileInfo[] listFile = new DirectoryInfo(root.Text).GetFiles();
                if (listFile.Length != 0)
                {
                    foreach (FileInfo file in listFile)
                    {
                        TreeNode node = new TreeNode(file.FullName);
                        root.Nodes.Add(node);
                    }
                }
                DirectoryInfo[] listFolder = new DirectoryInfo(root.Text).GetDirectories();
                if (listFolder.Length != 0)
                    foreach (DirectoryInfo dir in listFolder)
                    {
                        TreeNode node = new TreeNode(dir.FullName);
                        root.Nodes.Add(node);
                        LoadExplorer(node);
                    }
            }
            catch
            {
                return;
            }
        }
    }
}

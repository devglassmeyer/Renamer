﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renamer
{
    public partial class frmRenamerMain : Form
    {
        bool _loading_data = false;

        public frmRenamerMain()
        {
            InitializeComponent();
        }

        private void btnChooseDir1_Click(object sender, EventArgs e)
        {
            // display choose directory dialog
            // Not Till We Are Lost
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the parent folder folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    txtMainFolder.Text = selectedPath;
                    get_directories_in_folder(selectedPath);
                }
            }
        }


        private void get_directories_in_folder(string path)
        {
            lstSubDirs.Items.Clear();
            lstFiles.Items.Clear();
            string[] dir_names = Directory.GetDirectories(path);
            _loading_data = true;

            if (dir_names.Length > 0)
            {
                foreach (string dir in dir_names)
                {
                    lstSubDirs.Items.Add(dir);
                }
            }
            _loading_data = false;
            if (lstSubDirs.Items.Count > 0)
            {
                lstSubDirs.SelectedIndex = 0;
            }
        }

        private void get_files_in_folder(string path)
        {
            var save_loading = _loading_data;
            _loading_data = true;
            lstFiles.Items.Clear();
            string[] files_in_dir = Directory.GetFiles(path);

            if (files_in_dir.Length > 0)
            {
                foreach (string a_file in files_in_dir)
                {
                    lstFiles.Items.Add((string)a_file);
                }
            }
            _loading_data = save_loading;
        }

        private void lstSubDirs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubDirs.Items.Count > 0 && lstSubDirs.SelectedItems.Count > 0 && lstSubDirs.SelectedItem != null)
            {
                string full_path = System.IO.Path.Combine(txtMainFolder.Text, lstSubDirs.SelectedItem.ToString());
                get_files_in_folder(full_path);
            }
        }

        private void paint_renamed_file(string parent_folder, string file_name)
        {
            string new_file_name = file_name;
            if (!string.IsNullOrEmpty(parent_folder))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(parent_folder);
                string directoryName = directoryInfo.Name;
                var start_index = file_name.IndexOf(" " + directoryName + " -");
                if (start_index != -1)
                {
                    new_file_name = file_name.Remove(start_index, directoryName.Length + 3);
                }
            }
            txtNewName.Text = new_file_name;
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading_data)
            {
                paint_renamed_file(txtMainFolder.Text, lstFiles.SelectedItem.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Renamer
{
    public partial class frmRenamerMain : Form
    {
        bool _loading_data = false;
        List<artistdata> _artistdata;

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
            lblNumOfAlbums.Text = "Number of Albums With Songs to be Renamed: 0";
            lstSubDirs.Items.Clear();
            lstFiles.Items.Clear();
            string[] dir_names = Directory.GetDirectories(path);
            _loading_data = true;

            if (dir_names.Length > 0)
            {
                foreach (string dir in dir_names)
                {
                    has_files_to_be_renamed(dir);
                }
            }
            _loading_data = false;
            if (lstSubDirs.Items.Count > 0)
            {
                lblNumOfAlbums.Text = "Number of Albums With Songs to be Renamed: " + lstSubDirs.Items.Count.ToString();
                lstSubDirs.SelectedIndex = 0;
            }
        }

        private bool has_files_to_be_renamed(string path)
        {
            DirectoryInfo artist_dir = new DirectoryInfo(path);
            string artist_dir_name = artist_dir.Name;
            string[] album_dir_names = Directory.GetDirectories(path);

            if (album_dir_names.Length > 0)
            {
                foreach (string album in album_dir_names)
                {
                    string[] files_in_dir = Directory.GetFiles(album);
                    foreach (string a_file in files_in_dir)
                    {
                        if (a_file.ToLower().EndsWith(".flac"))
                        {
                            var start_index = a_file.IndexOf(" " + artist_dir_name + " -");
                            if (start_index != -1)
                            {
                                lstSubDirs.Items.Add(album);
                                break;
                            }
                        }
                    }

                }
            }
            return true;
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
                    if (a_file.ToLower().EndsWith(".flac"))
                    {
                        lstFiles.Items.Add((string)a_file);
                    }
                }
            }
            _loading_data = save_loading;
        }

        private void rename_all_files()
        {
            List<string> artists_no_albums = new List<string>();
            _artistdata = new List<artistdata>();
            if (lstSubDirs.Items.Count > 0)
            {
                string[] artist_directories = Directory.GetDirectories(txtMainFolder.Text);
                if (artist_directories.Length > 0)
                {
                    foreach (string artist_directory in artist_directories)
                    {
                        DirectoryInfo artist_dir = new DirectoryInfo(artist_directory);
                        string artist_name = artist_dir.Name;
                        string[] album_dir_names = Directory.GetDirectories(artist_directory);
                        artistdata ad = new artistdata(artist_name, artist_directory);
                        
                        if (album_dir_names.Length > 0)
                        {
                            foreach (string album in album_dir_names)
                            {
                                albumdata al = new albumdata(album, artist_name);
                                string[] files_in_dir = Directory.GetFiles(album);
                                foreach (string a_file in files_in_dir)
                                {
                                    if (a_file.ToLower().EndsWith(".flac"))
                                    {
                                        var start_index = a_file.IndexOf(" " + artist_name + " -");
                                        if (start_index != -1)
                                        {
                                            string new_file_name = a_file.Remove(start_index, artist_name.Length + 3);
                                            songdata sd = new songdata(a_file, new_file_name);
                                            sd.IsRenamed = true;
                                            al.add_song(sd);
                                            File.Move(a_file, new_file_name);
                                        }
                                        else
                                        {
                                            songdata sd = new songdata(a_file, a_file);
                                            sd.IsRenamed = false;
                                            al.add_song(sd);                                        }
                                    }
                                }
                                ad.AddAlbum(al);
                            }
                        }
                        else
                        {
                            artists_no_albums.Add(artist_name);
                        }
                        _artistdata.Add(ad);
                    }
                }
                else
                {
                    MessageBox.Show("Hey, buddy. No artist directories found. So, nothing to rename!", "Nothing to Do", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hey, buddy. There are no directories to look through. So, nothing to rename!", "Nothing to Do", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string artist_directory = directoryInfo.Parent.Name;
                var start_index = file_name.IndexOf(" " + artist_directory + " -");
                if (start_index != -1)
                {
                    new_file_name = file_name.Remove(start_index, artist_directory.Length + 3);
                }
            }
            txtNewName.Text = new_file_name;
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading_data)
            {
                paint_renamed_file(lstSubDirs.SelectedItem.ToString(), lstFiles.SelectedItem.ToString());
            }
        }

        private void btnRenameAll_Click(object sender, EventArgs e)
        {
            rename_all_files();
        }
    }
}

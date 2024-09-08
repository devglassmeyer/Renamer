using System;
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
            string[] _dir_names = Directory.GetDirectories(path);

            if (_dir_names.Length > 0)
            {
                lstSubDirs.Items.Clear();
                foreach (string dir in _dir_names)
                {
                    lstSubDirs.Items.Add(dir);
                }
            }
        }
    }
}

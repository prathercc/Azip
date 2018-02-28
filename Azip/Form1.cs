using Ionic.Zip;
using System;
using System.IO;
using System.Windows.Forms;

namespace Azip
{
    public partial class Form1 : Form
    {
        /****** STATIC VARIABLES BEGIN ********/
        static string prevDirectory = string.Empty;
        static int duplicateHit = 0;
        /****** STATIC VARIABLES END ********/









        /****************************** BEGIN FORM OBJECTS ********************************/

        private void Form1_Load(object sender, EventArgs e)  //defaults
        {
            finalLocationLabel.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ArchiveButton.Enabled = false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)  //add item button
        {
            foreach (ListViewItem s in listView1.SelectedItems)
            {
                foreach (ListViewItem ss in listView2.Items)
                {
                    if (s.Text.Replace(" (directory)", "") == ss.Text.Replace(currentDirectoryLabel.Text, "").Replace("\\", ""))
                    {
                        duplicateHit++;
                    }
                }
                if (duplicateHit == 0)
                {
                    addItemToListView(s.Text);
                }
                else
                {
                    duplicateHit = 0;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)  //remove item button
        {
            foreach (ListViewItem s in listView2.SelectedItems)
            {
                listView2.Items.Remove(s);
            }
        }

        private void folderSelectButton_Click(object sender, EventArgs e)  //button to select document(s) path to zip
        {
            // Set starting folder, show folder selection dialog and set newly selected folder path 
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            prevDirectory = currentDirectoryLabel.Text;
            folderBrowserDialog.ShowDialog();
            currentDirectoryLabel.Text = folderBrowserDialog.SelectedPath;
            //************************************************************************************
            if (prevDirectory != currentDirectoryLabel.Text)
            {
                try
                {
                    listView1.Clear();
                    DirectoryInfo dir = new DirectoryInfo(currentDirectoryLabel.Text);
                    foreach (var folder in dir.GetDirectories())
                    {
                        listView1.Items.Add(Convert.ToString(folder) + " (directory)");
                    }
                    foreach (var file in dir.GetFiles())
                    {
                        listView1.Items.Add(Convert.ToString(file));
                    }
                }
                catch
                {
                    currentDirectoryLabel.Text = "...";
                }
            }
        }

        private void finalLocButton_Click(object sender, EventArgs e)  //button to select save location
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog2.ShowDialog();
            if (folderBrowserDialog2.SelectedPath != string.Empty)
            {
                string toAdd1 = folderBrowserDialog2.SelectedPath + "\\" + archiveNameTextBox.Text + ".zip";
                toAdd1 = toAdd1.Replace("\\\\", "\\");
                finalLocationLabel.Text = toAdd1;
            }
        }

        private void archiveNameTextBox_TextChanged(object sender, EventArgs e)  //archive name textbox when text is modified
        {
            if (archiveNameTextBox.Text.Length > 0)
            {
                ArchiveButton.Enabled = true;
            }
            else
            {
                ArchiveButton.Enabled = false;
            }
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog2.SelectedPath != string.Empty)
            {
                string toAdd1 = folderBrowserDialog2.SelectedPath + "\\" + archiveNameTextBox.Text + ".zip";
                toAdd1 = toAdd1.Replace("\\\\", "\\");
                finalLocationLabel.Text = toAdd1;
            }
            else
            {
                string toAdd1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archiveNameTextBox.Text + ".zip";
                toAdd1 = toAdd1.Replace("\\\\", "\\");
                finalLocationLabel.Text = toAdd1;
            }
        }

        private void ArchiveButton_Click(object sender, EventArgs e)  //archive button
        {
            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("No file/folder to archive!", "Error!");
            }
            else if (File.Exists(finalLocationLabel.Text))
            {
                DialogResult r = MessageBox.Show("Archive located at '" + finalLocationLabel.Text + "' already exists, overwrite this archive?", "Warning!", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes) //overwrite old archive
                {
                    archiveFiles();
                }
            }
            else
            {
                DialogResult r = MessageBox.Show("Create archive at location '" + finalLocationLabel.Text + "' ?", "Warning!", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    archiveFiles();
                }
            }
        }

        private void zip_Progress(object sender, SaveProgressEventArgs e)  //borrowed progress bar code, thanks stackoverflow
        {
            if (e.TotalBytesToTransfer > 0)
            {
                progressBar.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
            }
        }

        private void removeAllButton_Click(object sender, EventArgs e)  //button to clear listview2.Items
        {
            removeAllFiles();
        }

        /****************************** END FORM OBJECTS ********************************/




















        /************* BEGIN METHODS SECTION **************************************************************/



        private void removeAllFiles()
        {
            if (listView2.Items.Count != 0)
            {
                DialogResult r = MessageBox.Show("Are you sure you want to clear out the list of files to be archived?", "Warning!", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    foreach (ListViewItem s in listView2.Items)
                    {
                        listView2.Items.Remove(s);
                    }
                }
            }
            else
            {
                //MessageBox.Show("No file/folder to remove!", "Error!");
            }
        }

        private void archiveFiles()
        {
            Enabled = false;
            Text = "Gathering files.";
            for (int i = 0; i < 3; i++)
            {
                Text = Text + ".";
                System.Threading.Thread.Sleep(250);
            }
            Text = "Archiving files please wait...";

            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {

                zip.SaveProgress += new EventHandler<SaveProgressEventArgs>(zip_Progress);
                foreach (ListViewItem s in listView2.Items)
                {
                    char test = s.Text[s.Text.Length - 1];
                    if (Convert.ToString(test) == "\\")  //do if the item is a folder
                    {
                        string[] t = s.Text.Split('\\'); /* We have to separate the string from each '\' and store into a string in order to get the parent folders name*/
                        if (archivePwTextBox.Text != string.Empty)
                        {
                            zip.Password = archivePwTextBox.Text;
                            zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
                        }
                        zip.AddDirectory(s.Text); /* t[t.Length - 2] is where the parent folder name is, it is the 2nd to last string in the array*/
                    }
                    else   //do if the item is a file
                    {
                        if (archivePwTextBox.Text != string.Empty)
                        {
                            zip.Password = archivePwTextBox.Text;
                            zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
                        }
                        zip.AddFile(s.Text, "");
                    }
                }
                zip.Save(finalLocationLabel.Text);  //saves final zip file

            }
            Text = "Aarons Zipper 2.0";
            Enabled = true;
            MessageBox.Show("Archive created at location '" + finalLocationLabel.Text + "'", "Success!");
            archiveNameTextBox.Text = string.Empty; //reset name box after archiving
            archivePwTextBox.Text = string.Empty; //reset password box after archiving
            progressBar.Value = 0;
        }




        private void addItemToListView(string s)
        {
            if (s.Contains(" (directory)"))
            {
                string toAdd1 = currentDirectoryLabel.Text + "\\" + s.Replace(" (directory)", "");
                toAdd1 = toAdd1.Replace("\\\\", "\\");
                listView2.Items.Add(toAdd1 + "\\");
            }
            else
            {
                string toAdd1 = currentDirectoryLabel.Text + "\\" + s;
                toAdd1 = toAdd1.Replace("\\\\", "\\");
                listView2.Items.Add(toAdd1);
            }

        }


        private void switchMode(int selection)
        {
            folderSelectButton.Visible = false;
            currentDirectoryLabel.Visible = false;

        }

        /************* END METHODS SECTION **************************************************************/






    }
}

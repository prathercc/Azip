namespace Azip
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.rightButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.currentDirectoryLabel = new System.Windows.Forms.Label();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.finalLocationLabel = new System.Windows.Forms.Label();
            this.finalLocButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.archivePwTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.archiveNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightBlue;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // rightButton
            // 
            resources.ApplyResources(this.rightButton, "rightButton");
            this.rightButton.Name = "rightButton";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // currentDirectoryLabel
            // 
            resources.ApplyResources(this.currentDirectoryLabel, "currentDirectoryLabel");
            this.currentDirectoryLabel.Name = "currentDirectoryLabel";
            // 
            // folderSelectButton
            // 
            resources.ApplyResources(this.folderSelectButton, "folderSelectButton");
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.LightBlue;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            resources.ApplyResources(this.listView2, "listView2");
            this.listView2.Name = "listView2";
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // ArchiveButton
            // 
            resources.ApplyResources(this.ArchiveButton, "ArchiveButton");
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.UseVisualStyleBackColor = true;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // finalLocationLabel
            // 
            resources.ApplyResources(this.finalLocationLabel, "finalLocationLabel");
            this.finalLocationLabel.Name = "finalLocationLabel";
            // 
            // finalLocButton
            // 
            resources.ApplyResources(this.finalLocButton, "finalLocButton");
            this.finalLocButton.Name = "finalLocButton";
            this.finalLocButton.UseVisualStyleBackColor = true;
            this.finalLocButton.Click += new System.EventHandler(this.finalLocButton_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // archivePwTextBox
            // 
            resources.ApplyResources(this.archivePwTextBox, "archivePwTextBox");
            this.archivePwTextBox.Name = "archivePwTextBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // archiveNameTextBox
            // 
            resources.ApplyResources(this.archiveNameTextBox, "archiveNameTextBox");
            this.archiveNameTextBox.Name = "archiveNameTextBox";
            this.archiveNameTextBox.TextChanged += new System.EventHandler(this.archiveNameTextBox_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // removeAllButton
            // 
            resources.ApplyResources(this.removeAllButton, "removeAllButton");
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.UseVisualStyleBackColor = true;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.archiveNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.archivePwTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.finalLocButton);
            this.Controls.Add(this.finalLocationLabel);
            this.Controls.Add(this.ArchiveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.folderSelectButton);
            this.Controls.Add(this.currentDirectoryLabel);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label currentDirectoryLabel;
        private System.Windows.Forms.Button folderSelectButton;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label finalLocationLabel;
        private System.Windows.Forms.Button finalLocButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox archivePwTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox archiveNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeAllButton;
    }
}


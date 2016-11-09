namespace MCSSH
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
            this.terminalControl1 = new WalburySoftware.TerminalControl();
            this.SuspendLayout();

            System.Windows.Forms.ContextMenuStrip mnu = new System.Windows.Forms.ContextMenuStrip();
            System.Windows.Forms.ToolStripMenuItem mnuCopy = new System.Windows.Forms.ToolStripMenuItem("Copy");
            System.Windows.Forms.ToolStripMenuItem mnuPaste = new System.Windows.Forms.ToolStripMenuItem("Pase");
            System.Windows.Forms.ToolStripMenuItem mnuAbout = new System.Windows.Forms.ToolStripMenuItem("About");
            System.Windows.Forms.ToolStripMenuItem mnuSettings = new System.Windows.Forms.ToolStripMenuItem("Settings");

            mnuCopy.Click += new System.EventHandler(mnuCopy_Click);
            mnuPaste.Click += new System.EventHandler(mnuPaste_Click);
            mnuAbout.Click += new System.EventHandler(mnuAbout_Click);
            mnuSettings.Click += new System.EventHandler(mnuSettings_Click);
            
            mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuCopy,mnuPaste,mnuAbout,mnuSettings });

            this.terminalControl1.ContextMenuStrip = mnu;

            // 
            // terminalControl1
            // 
            this.terminalControl1.AuthType = Poderosa.ConnectionParam.AuthType.Password;
            this.terminalControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalControl1.Host = "";
            this.terminalControl1.IdentifyFile = "";
            this.terminalControl1.Location = new System.Drawing.Point(0, 0);
            this.terminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;
            this.terminalControl1.Name = "terminalControl1";
            this.terminalControl1.Password = "";
            this.terminalControl1.Size = new System.Drawing.Size(910, 455);
            this.terminalControl1.TabIndex = 13;
            this.terminalControl1.Text = "terminalControl1";
            this.terminalControl1.UserName = "";
            this.terminalControl1.DoubleClick += new System.EventHandler(this.terminalControl1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 455);
            this.Controls.Add(this.terminalControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NighterSSH";
            this.ResumeLayout(false);

        }

        #endregion

        private WalburySoftware.TerminalControl terminalControl1;
    }
}


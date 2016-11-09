using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Poderosa.Terminal;
using System.Threading;
using Poderosa.Config;
using Poderosa.ConnectionParam;
using Poderosa.Forms;
using System.Globalization;

namespace MCSSH
{
    public partial class Form1 : Form
    {
        public Form1(string address,string username,string password)
        {
            InitializeComponent();
            base.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
            Init_Connection(address,username,password);
        }

        /// <summary>
        /// Handles a close 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.terminalControl1.Close();
        

            Application.Exit(); 
            this.Close();
            return;
        }

        private void Init_Connection(string address,string username,string password)
        {
            this.terminalControl1.UserName = username.Trim();
            this.terminalControl1.Password = password.Trim();
            this.terminalControl1.Host = address.Trim();

            if (this.terminalControl1.UserName.Length<2 || this.terminalControl1.Password.Length<2 || this.terminalControl1.Host.Length<2)
            {
                this.Close();
                return;
            }

            this.terminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;

            if (this.terminalControl1.Connect() == false)
            {
                NighterSSH.PopupBox PopupBox = new NighterSSH.PopupBox();
                PopupBox.pText = "Unable to connect: "+this.terminalControl1.Host;
                PopupBox.Show();
                Application.Exit();
                this.Close();
                return;
            }

            try
            {
                TextReader textReader = new StreamReader("nighterssh.settings");
                ConfigNode configNode = new ConfigNode("nighterssh-settings");
                configNode.ReadFrom(textReader);
                if (configNode.Children != null)
                {
                    configNode = configNode.FindChildConfigNode("nighterssh-settings");
                    if (configNode != null)
                    {
                        this.terminalControl1.TerminalPane.ConnectionTag.RenderProfile.Import(configNode);
                        Color textColor = default(Color);
                        textColor = Color.FromArgb(int.Parse(configNode["force-color"], NumberStyles.HexNumber));
                        Color backColor = default(Color);
                        backColor = Color.FromArgb(int.Parse(configNode["back-color"], NumberStyles.HexNumber));
                        this.terminalControl1.SetPaneColors(textColor, backColor);
                        this.terminalControl1.Focus();
                    }
                    textReader.Close();
                }
                else
                {
                    //this.terminalControl1.SetPaneColors(Color.LawnGreen, Color.Black);
                    //this.terminalControl1.Focus();
                }
            }
            catch
            {
                try
                {
                    //this.terminalControl1.SetPaneColors(Color.LawnGreen, Color.Black);
                    //this.terminalControl1.Focus();
                }
                catch { }

            }
        }

        private void servertextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Menu copy click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            this.terminalControl1.CopySelectedTextToClipboard();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            this.terminalControl1.PasteTextFromClipboard();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            NighterSSH.PopupBox PopupBox = new NighterSSH.PopupBox();
            PopupBox.pText = "NighterSSH\n  Author: Mikael Kall \n kall.micke@gmail.com";
            PopupBox.Show();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            if (this.terminalControl1.TerminalPane.ConnectionTag == null)
            {
                return;
            }

            Poderosa.Forms.EditRenderProfile dlg = new Poderosa.Forms.EditRenderProfile(this.terminalControl1.TerminalPane.ConnectionTag.RenderProfile);

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.terminalControl1.TerminalPane.ConnectionTag.RenderProfile = dlg.Result;
            this.terminalControl1.TerminalPane.ApplyRenderProfile(dlg.Result);
            try
            {
                ConfigNode configNode = new ConfigNode("nighterssh-settings");
                this.terminalControl1.TerminalPane.ConnectionTag.RenderProfile.Export(configNode);
                TextWriter textWriter = new StreamWriter("nighterssh.settings");
                configNode.WriteTo(textWriter);
                textWriter.Flush();
                textWriter.Close();
            }
            catch { }
        }

        private void terminalControl1_DoubleClick(object sender, EventArgs e)
        {
            this.terminalControl1.CopySelectedTextToClipboard();
        }
        
    }

}
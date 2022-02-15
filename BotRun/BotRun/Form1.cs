using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace BotRun
{
    public partial class Form1 : Form
    {
        string[] args = new string[2];
        string settingsFile = "settings";

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(settingsFile))
            {
                args = File.ReadAllLines(settingsFile);

                this.TokenBox.Text = args[0];
                this.DataPathBox.Text = args[1];
            }
            else
            {
                File.WriteAllLines(settingsFile, args);
            }
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            bool tokenCheck, dataPathCheck = false;

            if (!this.TokenBox.Text.Equals(""))
            {
                args[0] = this.TokenBox.Text;
                tokenCheck = true;
            }
            else
            {
                MessageBox.Show("Please, insert a token", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tokenCheck = false;
            }

            if (!this.DataPathBox.Text.Equals(""))
            {
                args[1] = this.DataPathBox.Text;
                dataPathCheck = true;
            }
            else
            {
                MessageBox.Show("Please, insert a Data Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataPathCheck = false;
            }

            if (tokenCheck && dataPathCheck)
            {
                File.WriteAllLines(settingsFile, args);

                ProcessStartInfo psi = new ProcessStartInfo("cmd", $"/k EgeBot.exe -t {args[0]} -fp {args[1]}");
                Process.Start(psi);
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.DataPathBox.Text = dialog.SelectedPath;
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace DVR
{
    public partial class IPCam_Select : Form
    {
        public string GetUrl{ get => cboIPCams.Text; }
        public string GetUser{ get => txtUsername.Text; }
        public string GetPass{ get => txtPassword.Text; }

        public IPCam_Select()
        {
            InitializeComponent();
            Height = 125;
            SetDefaultCameraURLs();
        }

        private void SetDefaultCameraURLs()
        {
            cboIPCams.Items.Add("http://192.168.0.102/snapshot.cgi?");
            cboIPCams.Items.Add("http://192.168.0.143/snapshot.cgi?");
            cboIPCams.SelectedIndex = 0;
        }

        private void chkAutentication_CheckedChanged(object sender, EventArgs e)
        {
            Height = chkAutentication.Checked ? Height = 215 : Height = 125;
        }

        private void BtnIPConnect_Click(object sender, EventArgs e)
        {
            if (chkAutentication.Checked)
            {
                if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please enter a valid Username and Password");
                    return;
                }
            }

            Close();
        }
    }
}

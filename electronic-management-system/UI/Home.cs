using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using itcrafts.DL;
using itcrafts.Util;
using itcrafts.Utils;

namespace itcrafts.UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(LogInBtn);
            Style.DangerButton(CloseBtn);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartClick(object sender, EventArgs e)
        {
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            var userDL = ObjectHandler.GetUserDL();
            var authenticatedUser = userDL.Authenticate(username, password);
            if (authenticatedUser == null)
            {
                MessageBox.Show("Invalid Credentials !", "Error");
                Logger.Log(BL.ActionType.Read, BL.AuditStatus.Failed, $"Log In | Username: <{UsernameInput.Text}> Password: <{PasswordInput.Text}>");
                UsernameInput.Text = "";
                PasswordInput.Text = "";
                return;
            }
            Hide();
            State.SetCurrentUser(authenticatedUser);
            Logger.Log(BL.ActionType.Read, BL.AuditStatus.Success, "Log In", State.GetCurrentUser()!.GetId());
            State.SetCurrentForm(new Dashboard());
        }
    }
}

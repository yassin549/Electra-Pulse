using itcrafts.BL;
using itcrafts.DL;
using itcrafts.Util;
using itcrafts.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itcrafts.UI
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.PrimaryButton(CheckAccessLogBtn);
            Style.PrimaryButton(CheckAuditLogBtn);
            Style.DangerButton(GoBackBtn);
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Dashboard());
        }

        private void CheckAccessLog(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new AccessLogPanel());
        }

        private void CheckAuditLog(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new AuditLogPanel());
        }
    }
}

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
    public partial class QualityAssurancePanel : Form
    {
        public QualityAssurancePanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.PrimaryButton(DTBtn);
            Style.PrimaryButton(MDDBtn);
            Style.DangerButton(GoBackBtn);
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Dashboard());
        }

        private void MDDClick(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new DeviceDefects());
        }

        private void DTClick(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new DeviceTesting());
        }
    }
}

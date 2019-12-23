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
    public partial class SupplyChainPanel : Form
    {
        public SupplyChainPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.PrimaryButton(MPLBtn);
            Style.PrimaryButton(MWBtn);
            Style.PrimaryButton(MMBtn);
            Style.DangerButton(GoBackBtn);
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Dashboard());
        }

        private void MDClick(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new DevicesPanel());
        }

        private void MCCLick(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new ComponentPanel());
        }

        private void MMCLick(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new MaterialPanel());
        }
    }
}

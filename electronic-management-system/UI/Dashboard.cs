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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.DangerButton(CloseBtn);
            Style.PrimaryButton(LogOutBtn);
            Title.Text = $"Welcome {State.GetCurrentUser()!.GetFullname()}";
            List<Button> buttons = GetRoleButtons(State.GetCurrentUser()!.GetId());
            foreach (Button btn in buttons)
            {
                RoleButtonsPanel.Controls.Add(btn);
            }
        }

        private List<Button> GetRoleButtons(int userId)
        {
            List<Button> buttons = new List<Button>();
            var userDL = ObjectHandler.GetUserDL();
            var roles = userDL.GetUserRoles(userId);
            foreach (var role in roles)
            {
                Button btn = new Button();
                btn.Width = 210;
                btn.Height = 70;
                btn.Text = Role.GetLabel(role);
                btn.Tag = role;
                Style.SecondaryButton(btn);
                btn.Click += new EventHandler(SwitchToRoleTab!);
                buttons.Add(btn);
            }
            return buttons;
        }

        private void SwitchToRoleTab(object sender, EventArgs e)
        {
            Hide();
            var role = ((Button)sender).Tag;
            switch (role)
            {
                case RoleType.Admin:
                    State.SetCurrentForm(new AdminPanel());
                    break;
                case RoleType.HumanResourceManager:
                    State.SetCurrentForm(new HumanResourcePanel());
                    break;
                case RoleType.InventoryManager:
                    State.SetCurrentForm(new InventoryPanel());
                    break;
                case RoleType.SupplyChainManager:
                    State.SetCurrentForm(new SupplyChainPanel());
                    break;
                case RoleType.QualityAssuranceEngineer:
                    State.SetCurrentForm(new QualityAssurancePanel());
                    break;
                case RoleType.ManufacturingEngineer:
                    State.SetCurrentForm(new ManufacturingEngineerPanel());
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogOut(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Home());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoleButtonsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

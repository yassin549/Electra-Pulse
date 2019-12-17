using itcrafts.BL;
using itcrafts.DL;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using itcrafts.Util;
using itcrafts.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itcrafts.UI
{
    public partial class HumanResourcePanel : Form
    {
        int? SelectedId;
        IUserDL UserDL = ObjectHandler.GetUserDL();
        public HumanResourcePanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            UsersTable.DataSource = GetDataTable();
            Style.StylizeTable(UsersTable);
            var allRoles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().Select(r => Role.GetLabel(r)).ToArray();
            for (int i = 0; i < allRoles.Length; i++)
            {
                var checkbox = new CheckBox();
                checkbox.Text = allRoles[i];
                checkbox.Tag = i;
                checkbox.ForeColor = Color.White;
                checkbox.Checked = false;
                checkbox.AutoSize = true;
                checkbox.Dock = DockStyle.Fill;
                RolesPanel.Controls.Add(checkbox);
            }
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Fullname", typeof(string));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Columns.Add("DateCreated", typeof(DateTime));

            var users = UserDL.GetUsers();
            foreach (var user in users)
            {
                var row = table.NewRow();
                row["Id"] = user.GetId();
                row["Fullname"] = user.GetFullname();
                row["Username"] = user.GetUsername();
                row["Password"] = user.GetPassword();
                row["DateCreated"] = user.GetDateCreated();
                table.Rows.Add(row);
            }
            return table;
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!User.IsValidFullname(FullnameInput.Text) || !User.IsValidUsername(UsernameInput.Text) || !User.IsValidPassword(PasswordInput.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var newUser = new User(
                0, FullnameInput.Text, UsernameInput.Text, PasswordInput.Text, DateTime.Now
            );
            bool userAdded = UserDL.AddUser(newUser), rolesAssigned = false;
            if (userAdded)
            {
                var userId = UserDL.GetUsers().Find(u => u.GetUsername() == UsernameInput.Text)!.GetId();
                var selectedRolesForUser = RolesPanel.Controls
                    .Cast<CheckBox>()
                    .ToList()
                    .FindAll(c => c.Checked)
                    .Select(c => (RoleType)c.Tag!)
                    .ToList();
                rolesAssigned = UserDL.SetRoles(userId, selectedRolesForUser);
            }
            if (rolesAssigned)
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "User", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New User Added Successfully !");
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "User", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = UsersTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            FullnameInput.Text = (string)row.Cells[1].Value;
            UsernameInput.Text = (string)(row.Cells[2].Value);
            PasswordInput.Text = (string)(row.Cells[3].Value);
            var roles = UserDL.GetUserRoles((int)SelectedId);
            foreach (var item in RolesPanel.Controls)
            {
                var checkbox = (CheckBox)item;
                checkbox.Checked = roles.Select(r => (int)r).Contains((int)checkbox.Tag!);
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            bool deleted = UserDL.DeleteUser((int)SelectedId);
            if (deleted)
            {
                MessageBox.Show("User Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "User", State.GetCurrentUser()!.GetId());
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("User has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "User", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (!User.IsValidFullname(FullnameInput.Text) || !User.IsValidUsername(UsernameInput.Text) || !User.IsValidPassword(PasswordInput.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedUser = new User(
                (int)SelectedId, FullnameInput.Text, UsernameInput.Text, PasswordInput.Text, DateTime.Now
            );
            bool userUpdated = UserDL.UpdateUser((int)SelectedId, FullnameInput.Text, UsernameInput.Text, PasswordInput.Text), rolesAssigned = false;
            if (userUpdated)
            {
                var selectedRolesForUser = RolesPanel.Controls
                    .Cast<CheckBox>()
                    .ToList()
                    .FindAll(c => c.Checked)
                    .Select(c => (RoleType)c.Tag!)
                    .ToList();
                rolesAssigned = UserDL.SetRoles((int)SelectedId, selectedRolesForUser);
            }
            if (rolesAssigned)
            {
                MessageBox.Show("User Updated Successfully !");
                Logger.Log(ActionType.Update, AuditStatus.Success, "User", State.GetCurrentUser()!.GetId());
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "User", State.GetCurrentUser()!.GetId());
            }
        }
    }
}

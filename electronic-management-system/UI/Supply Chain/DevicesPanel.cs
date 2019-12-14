using itcrafts.BL;
using itcrafts.DL;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using itcrafts.Util;
using itcrafts.Utils;
using itcrafts_lib.DL.General;
using itcrafts_lib.DL.Interfaces;
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
    public partial class DevicesPanel : Form
    {
        int? SelectedId;
        public DevicesPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            DevicesTable.DataSource = GetDataTable();
            Style.StylizeTable(DevicesTable);
            foreach (var category in CategoryDL.GetDeviceCategories())
            {
                CategoryBox.Items.Add(category);
            }
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Description", typeof(string));
            var devices = DevicesDL.GetCRUD().GetAll();
            foreach (var device in devices)
            {
                var row = table.NewRow();
                row["Id"] = device["Id"];
                row["Name"] = device["Name"];
                row["Category"] = CategoryDL.GetDeviceCategories()[(int)device["Category"]!];
                row["Description"] = device["Description"];
                table.Rows.Add(row);
            }
            return table;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new SupplyChainPanel());
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
            if (!ProductionLine.IsValidName(NameBox.Text) || !ProductionLine.IsValidDescription(DescriptionBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var newDevice = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text,
                ["Category"] = Array.IndexOf(CategoryDL.GetDeviceCategories(), CategoryBox.SelectedItem)
            };
            if (DevicesDL.GetCRUD().Add(newDevice))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Device", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Device Added Successfully !");
                DevicesTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Device", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = DevicesTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            NameBox.Text = (string)row.Cells[1].Value;
            DescriptionBox.Text = (string)(row.Cells[3].Value);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (DevicesDL.GetCRUD().Delete((int)SelectedId!))
            {
                MessageBox.Show("Device Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Device", State.GetCurrentUser()!.GetId());
                DevicesTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Device has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Device", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (!ProductionLine.IsValidName(NameBox.Text) || !ProductionLine.IsValidDescription(DescriptionBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedDevice = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text,
                ["Category"] = Array.IndexOf(CategoryDL.GetDeviceCategories(), CategoryBox.SelectedItem)
            };
            if (DevicesDL.GetCRUD().Update((int)SelectedId!, updatedDevice))
            {
                Logger.Log(ActionType.Update, AuditStatus.Success, "Device", State.GetCurrentUser()!.GetId());
                MessageBox.Show("Device Updated Successfully !");
                DevicesTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Device", State.GetCurrentUser()!.GetId());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

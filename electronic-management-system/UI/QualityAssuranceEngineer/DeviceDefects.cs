using itcrafts.BL;
using itcrafts.DL;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using itcrafts.Util;
using itcrafts.Utils;
using itcrafts_lib.DL.General;
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
    public partial class DeviceDefects : Form
    {
        int? SelectedId;
        public DeviceDefects()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            DeviceDefectsTable.DataSource = GetDataTable();
            Style.StylizeTable(DeviceDefectsTable);
            var devices = DevicesDL.GetCRUD().GetAll();
            foreach (var d in devices)
            {
                DeviceBox.Items.Add(new ComboBoxItem { Id = (int)d["Id"]!, Display = (string)d["Name"]! });
            }
            foreach (var category in CategoryDL.GetDefectCategories())
            {
                DefectBox.Items.Add(category);
            }
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("DeviceId", typeof(int));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Timestamp", typeof(DateTime));

            var devicedefects = DeviceDefectDL.GetCRUD().GetAll();
            foreach (var dt in devicedefects)
            {
                var row = table.NewRow();
                row["Id"] = dt["Id"];
                row["DeviceId"] = dt["DeviceId"];
                row["Category"] = dt["Category"];
                row["Description"] = dt["Description"];
                row["Timestamp"] = dt["Timestamp"];
                table.Rows.Add(row);
            }
            return table;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Dashboard());
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var newDeviceDefect = new Dictionary<string, object?>
            {
                ["DeviceId"] = ((ComboBoxItem)DeviceBox.SelectedItem!).Id,
                ["Category"] = Array.IndexOf(CategoryDL.GetDefectCategories(), (string) DefectBox.SelectedItem!),
                ["Description"] = DescriptionBox.Text,
                ["Timestamp"] = DateTime.Now
            };
            if (DeviceDefectDL.GetCRUD().Add(newDeviceDefect))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Device Defect", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Device Defect Added Successfully !");
                DeviceDefectsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Device Defect ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Device Defect", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = DeviceDefectsTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            DescriptionBox.Text = (string)row.Cells[3].Value;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (DeviceDefectDL.GetCRUD().Delete((int)SelectedId))
            {
                MessageBox.Show("Device Defect Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Device Defect", State.GetCurrentUser()!.GetId());
                DeviceDefectsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Device Defect has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Device Defect", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            var updatedDeviceDefect = new Dictionary<string, object?>
            {
                ["DeviceId"] = ((ComboBoxItem)DeviceBox.SelectedItem!).Id,
                ["Category"] = Array.IndexOf(CategoryDL.GetDefectCategories(), (string)DefectBox.SelectedItem!),
                ["Description"] = DescriptionBox.Text,
                ["Timestamp"] = (DateTime) DeviceDefectDL
                .GetCRUD()
                .GetAll()
                .Find(x => (int)x["Id"]! == (int)SelectedId!)!["Timestamp"]!
            };
            if (DeviceDefectDL.GetCRUD().Update((int) SelectedId!, updatedDeviceDefect))
            {
                MessageBox.Show("Device Defect Updated Successfully !");
                Logger.Log(ActionType.Update, AuditStatus.Success, "Device Defect", State.GetCurrentUser()!.GetId());
                DeviceDefectsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Device Defect", State.GetCurrentUser()!.GetId());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeviceDefects_Load(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }
    }
}

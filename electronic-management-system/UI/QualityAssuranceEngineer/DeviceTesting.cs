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
    public partial class DeviceTesting : Form
    {
        int? SelectedId;
        public DeviceTesting()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            DeviceTestsTable.DataSource = GetDataTable();
            Style.StylizeTable(DeviceTestsTable);
            var devices = DevicesDL.GetCRUD().GetAll();
            foreach (var d in devices)
            {
                DeviceBox.Items.Add(new ComboBoxItem { Id = (int)d["Id"]!, Display = (string)d["Name"]! });
            }
            foreach (var rating in RatingDL.GetRatings())
            {
                PerformanceBox.Items.Add(rating);
            }
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("DeviceId", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Performance", typeof(string));
            table.Columns.Add("Body", typeof(string));
            table.Columns.Add("Timestamp", typeof(DateTime));

            var deviceTests = DeviceTestDL.GetCRUD().GetAll();
            foreach (var dt in deviceTests)
            {
                var row = table.NewRow();
                row["Id"] = dt["Id"];
                row["DeviceId"] = dt["DeviceId"];
                row["Title"] = dt["Title"];
                row["Performance"] = RatingDL.GetRatings()[(int)dt["Performance"]!];
                row["Body"] = dt["Body"];
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
            if (!User.IsValidFullname(TitleBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            Debug.WriteLine("Rating: " + Array.IndexOf(RatingDL.GetRatings(), (string)PerformanceBox.SelectedItem!));
            var newDeviceTest = new Dictionary<string, object?>
            {
                ["DeviceId"] = ((ComboBoxItem)DeviceBox.SelectedItem!).Id,
                ["Title"] = TitleBox.Text,
                ["Performance"] = Array.IndexOf(RatingDL.GetRatings(), (string) PerformanceBox.SelectedItem!),
                ["Body"] = BodyBox.Text,
                ["Timestamp"] = DateTime.Now
            };
            if (DeviceTestDL.GetCRUD().Add(newDeviceTest))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Device Test", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Device Test Added Successfully !");
                DeviceTestsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Device Test ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Device Test", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = DeviceTestsTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            TitleBox.Text = (string)row.Cells[2].Value;
            BodyBox.Text = (string)row.Cells[4].Value;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (DeviceTestDL.GetCRUD().Delete((int)SelectedId))
            {
                MessageBox.Show("Device Test Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Device Test", State.GetCurrentUser()!.GetId());
                DeviceTestsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Device Test has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Device Test", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (!User.IsValidFullname(TitleBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedDeviceTest = new Dictionary<string, object?>
            {
                ["DeviceId"] = ((ComboBoxItem)DeviceBox.SelectedItem!).Id,
                ["Title"] = TitleBox.Text,
                ["Performance"] = Array.IndexOf(RatingDL.GetRatings(), (string)PerformanceBox.SelectedItem!),
                ["Body"] = BodyBox.Text,
                ["Timestamp"] = DateTime.Now
            };
            if (DeviceTestDL.GetCRUD().Update((int) SelectedId!, updatedDeviceTest))
            {
                MessageBox.Show("Device Test Updated Successfully !");
                Logger.Log(ActionType.Update, AuditStatus.Success, "Device Test", State.GetCurrentUser()!.GetId());
                DeviceTestsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Device Test", State.GetCurrentUser()!.GetId());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeviceTesting_Load(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class MaterialPanel : Form
    {
        int? SelectedId;
        public MaterialPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            MaterialTable.DataSource = GetDataTable();
            Style.StylizeTable(MaterialTable);
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            var data = MaterialDL.GetCRUD().GetAll();
            foreach (var d in data)
            {
                var row = table.NewRow();
                row["Id"] = d["Id"];
                row["Name"] = d["Name"];
                row["Description"] = d["Description"];
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
            var newMaterial = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text
            };
            if (MaterialDL.GetCRUD().Add(newMaterial))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Material", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Material Added Successfully !");
                MaterialTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Material", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = MaterialTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            NameBox.Text = (string)row.Cells[1].Value;
            DescriptionBox.Text = (string)(row.Cells[2].Value);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (MaterialDL.GetCRUD().Delete((int)SelectedId!))
            {
                MessageBox.Show("Material Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Material", State.GetCurrentUser()!.GetId());
                MaterialTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Material has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Material", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (!ProductionLine.IsValidName(NameBox.Text) || !ProductionLine.IsValidDescription(DescriptionBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedMaterial = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text
            };
            if (MaterialDL.GetCRUD().Update((int)SelectedId!, updatedMaterial))
            {
                Logger.Log(ActionType.Update, AuditStatus.Success, "Material", State.GetCurrentUser()!.GetId());
                MessageBox.Show("Material Updated Successfully !");
                MaterialTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Material", State.GetCurrentUser()!.GetId());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

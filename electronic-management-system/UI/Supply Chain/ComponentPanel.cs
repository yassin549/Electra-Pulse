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
    public partial class ComponentPanel : Form
    {
        int? SelectedId;
        public ComponentPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            ComponentsTable.DataSource = GetDataTable();
            Style.StylizeTable(ComponentsTable);
            foreach (var category in CategoryDL.GetComponentCategories())
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
            var components = ComponentDL.GetCRUD().GetAll();
            foreach (var component in components)
            {
                var row = table.NewRow();
                row["Id"] = component["Id"];
                row["Name"] = component["Name"];
                row["Category"] = CategoryDL.GetComponentCategories()[(int)component["Category"]!];
                row["Description"] = component["Description"];
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
            var newComponent = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text,
                ["Category"] = Array.IndexOf(CategoryDL.GetComponentCategories(), CategoryBox.SelectedItem)
            };
            if (ComponentDL.GetCRUD().Add(newComponent))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Component", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Component Added Successfully !");
                ComponentsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Component", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = ComponentsTable.SelectedRows;
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
            if (ComponentDL.GetCRUD().Delete((int)SelectedId!))
            {
                MessageBox.Show("Component Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Component", State.GetCurrentUser()!.GetId());
                ComponentsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Component has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Component", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (!ProductionLine.IsValidName(NameBox.Text) || !ProductionLine.IsValidDescription(DescriptionBox.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedDevice = new Dictionary<string, object?>
            {
                ["Name"] = NameBox.Text,
                ["Description"] = DescriptionBox.Text,
                ["Category"] = Array.IndexOf(CategoryDL.GetComponentCategories(), CategoryBox.SelectedItem)
            };
            if (ComponentDL.GetCRUD().Update((int)SelectedId!, updatedDevice))
            {
                Logger.Log(ActionType.Update, AuditStatus.Success, "Component", State.GetCurrentUser()!.GetId());
                MessageBox.Show("Component Updated Successfully !");
                ComponentsTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Component", State.GetCurrentUser()!.GetId());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

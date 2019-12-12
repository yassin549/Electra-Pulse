using itcrafts.BL;
using itcrafts.DL;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using itcrafts.Util;
using itcrafts.Utils;
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
    public partial class ProductionLinesPanel : Form
    {
        int? SelectedId;
        IProductionLineDL PLDL = ObjectHandler.GetProductionLineDL();
        public ProductionLinesPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            UsersTable.DataSource = GetDataTable();
            Style.StylizeTable(UsersTable);
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));

            var productionLines = PLDL.GetProductionLines();
            foreach (var pl in productionLines)
            {
                var row = table.NewRow();
                row["Id"] = pl.GetId();
                row["Name"] = pl.GetName();
                row["Description"] = pl.GetDescription();
                table.Rows.Add(row);
            }
            return table;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new InventoryPanel());
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
            if (!ProductionLine.IsValidName(Name.Text) || !ProductionLine.IsValidDescription(Description.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var newProductionLine = new ProductionLine(0, Name.Text, Description.Text);
            if (PLDL.AddProductionLine(newProductionLine))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Production Line", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Production Line Added Successfully !");
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Production Line", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = UsersTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            Name.Text = (string)row.Cells[1].Value;
            Description.Text = (string)(row.Cells[2].Value);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            bool deleted = PLDL.RemoveProductionLine((int)SelectedId);
            if (deleted)
            {
                MessageBox.Show("Production Line Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Production Line", State.GetCurrentUser()!.GetId());
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Production Line has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Production Line", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (!ProductionLine.IsValidName(Name.Text) || !ProductionLine.IsValidDescription(Description.Text))
            {
                MessageBox.Show("Invalid Inputs !");
                return;
            }
            var updatedProductionLine = new ProductionLine((int)SelectedId, Name.Text, Description.Text);
            if (PLDL.UpdateProductionLine((int)SelectedId, updatedProductionLine))
            {
                Logger.Log(ActionType.Update, AuditStatus.Success, "Production Line", State.GetCurrentUser()!.GetId());
                MessageBox.Show("Production Line Updated Successfully !");
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Production Line", State.GetCurrentUser()!.GetId());
            }
        }
    }
}

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
    public partial class WorkstationsPanel : Form
    {
        int? SelectedId;
        IWorkstationDL WDL = ObjectHandler.GetWorkstationDL();
        IProductionLineDL PLDL = ObjectHandler.GetProductionLineDL();
        public WorkstationsPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(CreateButton);
            Style.PrimaryButton(UpdateButton);
            Style.DangerButton(DeleteButton);
            Style.DangerButton(GoBackBtn);
            UsersTable.DataSource = GetDataTable();
            foreach (var pl in PLDL.GetProductionLines())
            {
                ProductionLineBox.Items.Add(new ComboBoxItem { Id = pl.GetId(), Display = pl.GetName() });
            }
            Style.StylizeTable(UsersTable);
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Production Line Id", typeof(int));
            table.Columns.Add("Workstation", typeof(string));

            var workstations = WDL.GetWorkstations();
            foreach (var w in workstations)
            {
                var row = table.NewRow();
                row["Id"] = w.GetId();
                row["Production Line Id"] = w.GetProductionLineId();
                row["Workstation"] = w.GetName();
                table.Rows.Add(row);
            }
            return table;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new InventoryPanel());
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!Workstation.IsNameValid(WorkstationNameBox.Text) || ProductionLineBox.SelectedItem == null)
            {
                MessageBox.Show("Invalid Input !");
                return;
            }
            int selectedPLId = ((ComboBoxItem)ProductionLineBox.SelectedItem!).Id;
            var newWorkstation = new Workstation(0, selectedPLId, WorkstationNameBox.Text);
            if (WDL.AddWorkstation(newWorkstation))
            {
                Logger.Log(ActionType.Create, AuditStatus.Success, "Workstation", State.GetCurrentUser()!.GetId());
                MessageBox.Show("New Workstation Added Successfully !");
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Add ! There was an error");
                Logger.Log(ActionType.Create, AuditStatus.Failed, "Workstation", State.GetCurrentUser()!.GetId());
            }
        }

        private void HandleRowClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var SelectedRows = UsersTable.SelectedRows;
            if (SelectedRows.Count != 1) return;
            if (SelectedRows[0].IsNewRow) return;
            DataGridViewRow row = SelectedRows[0];

            SelectedId = (int)row.Cells[0].Value;
            WorkstationNameBox.Text = (string)row.Cells[2].Value;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            bool deleted = WDL.RemoveWorkstation((int)SelectedId);
            if (deleted)
            {
                MessageBox.Show("Workstation Deleted Successfully !");
                Logger.Log(ActionType.Delete, AuditStatus.Success, "Workstation", State.GetCurrentUser()!.GetId());
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Workstation has dependencies, can't delete !");
                Logger.Log(ActionType.Delete, AuditStatus.Failed, "Workstation", State.GetCurrentUser()!.GetId());
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (SelectedId == null) return;
            if (!Workstation.IsNameValid(WorkstationNameBox.Text) || ProductionLineBox.SelectedItem == null)
            {
                MessageBox.Show("Invalid Input !");
                return;
            }
            int selectedPLId = ((ComboBoxItem)ProductionLineBox.SelectedItem!).Id;
            var updatedWorkstation = new Workstation((int) SelectedId!, selectedPLId, WorkstationNameBox.Text);
            if (WDL.UpdateWorkstation((int)SelectedId, updatedWorkstation))
            {
                Logger.Log(ActionType.Update, AuditStatus.Success, "Workstation", State.GetCurrentUser()!.GetId());
                MessageBox.Show("Workstation Updated Successfully !");
                UsersTable.DataSource = GetDataTable();
            }
            else
            {
                MessageBox.Show("Couldn't Update ! There was an error");
                Logger.Log(ActionType.Update, AuditStatus.Failed, "Workstation", State.GetCurrentUser()!.GetId());
            }
        }
    }
}

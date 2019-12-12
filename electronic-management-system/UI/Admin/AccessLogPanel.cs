﻿using itcrafts.BL;
using itcrafts.DL;
using itcrafts.DL.DB;
using itcrafts.DL.General;
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
    public partial class AccessLogPanel : Form
    {
        public AccessLogPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.DangerButton(GoBackBtn);
            AccessLogTable.DataSource = GetDataTable();
            Style.StylizeTable(AccessLogTable);
        }

        private DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Timestamp", typeof(DateTime));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Description", typeof(string));

            var accessLogs = AuditLogDL.GetAccessLogs();
            foreach (var log in accessLogs)
            {
                var row = table.NewRow();
                row["Timestamp"] = log.GetTimestamp();
                row["Status"] = log.GetAuditStatus().ToString();
                row["Description"] = log.GetDescription();
                table.Rows.Add(row);
            }
            return table;
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new AdminPanel());
        }

        private void AccessLogPanel_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

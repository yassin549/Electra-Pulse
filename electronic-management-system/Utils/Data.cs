using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itcrafts.Utils
{
    internal class Data
    {
        public static int DeleteRows(DataGridView table, string tableName)
        {
            var SelectedRows = table.SelectedRows;
            if (SelectedRows.Count == 0) return 0;
            List<string> IdsList = new List<string>();
            foreach (DataGridViewRow row in SelectedRows)
            {
                string Id = Convert.ToString(row.Cells[0].Value);
                IdsList.Add(Id);
            }
            string Ids = string.Join(", ", IdsList);
            try
            {
                Utils.DB.Execute($"DELETE FROM [{tableName}] WHERE Id IN ({Ids})");
            }
            catch
            {
                MessageBox.Show("Can't delete one of the selected item !");
                return 0;
            }
            return IdsList.Count;
        }

        public static void HandleRowClickForUpdation(DataGridView table, List<TextBox> textBoxes, List<int> columnValues, List<ComboBox> comboBoxes = null, List<int> comboBoxColumnValues = null)
        {
            var SelectedRows = table.SelectedRows;
            if (SelectedRows.Count != 1) return;
            DataGridViewRow row = SelectedRows[0];
            for (int i = 0; i < textBoxes.Count; i++)
            {
                textBoxes[i].Text = Convert.ToString(row.Cells[columnValues[i]].Value);
            }
            // If comboboxes have been passed, then their handling
            if (comboBoxes != null && comboBoxColumnValues != null)
            {
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    int cellData = Convert.ToInt32(row.Cells[comboBoxColumnValues[i]].Value);
                    // Above is the id of that selected row's cell, which has to be put in ComboBox
                    ComboBox comboBox = comboBoxes[i];
                    for (int j = 0; j < comboBox.Items.Count; j++)
                    {
                        if (((ComboBoxItem)comboBox.Items[j]).Id == cellData)
                        {
                            comboBox.SelectedItem = comboBox.Items[j];
                        }
                    }
                }
            }
        }

        public static int GetId(DataGridView table)
        {
            var SelectedRow = table.SelectedRows;
            if (SelectedRow.Count != 1) return -1;
            DataGridViewRow row = SelectedRow[0];
            int Id = Convert.ToInt32(row.Cells[0].Value);
            return Id;
        }

        public static List<ComboBoxItem> GetSelectionItems(string tableName, string displayColumnName, string valueColumnName = "Id", string condition = "")
        {
            List<ComboBoxItem> selectorItems = new List<ComboBoxItem>();
            string query = $"SELECT {valueColumnName}, {displayColumnName} AS DISPLAY FROM {tableName} {condition}";
            var data = DB.ExecuteAndGetDataSet(query);
            foreach (var row in data)
            {
                selectorItems.Add(new ComboBoxItem { Id = (int)row[valueColumnName]!, Display = (string)row[displayColumnName]! });
            }
            
            return selectorItems;
        }

        public static DataTable DataTablePopulate(string query)
        {
            DataTable dataTable = new DataTable();
            var dbClient = new SqlConnection(DB.ConnectionString);
            dbClient.Open();
            SqlCommand command = new SqlCommand(query, dbClient);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            dbClient.Close();
            return dataTable;

        }
    }
}

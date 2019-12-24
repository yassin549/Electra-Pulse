using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itcrafts.Util
{
    public class Style
    {
        public static readonly Color Primary = Color.FromArgb(27, 26, 85);
        public static readonly Color PrimaryDarker = Color.FromArgb(7, 15, 43);
        public static readonly Color PrimaryLight = Color.FromArgb(83, 92, 145);
        public static readonly Color PrimaryLighter = Color.FromArgb(146, 144, 195);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color Success = Color.FromArgb(34, 197, 94);

        public static void DecorateButton(Button btn)
        {
            btn.ForeColor = Color.White;
            btn.Font = new Font("Yu Gothic", 11.25f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        public static void PrimaryButton(Button btn)
        {
            DecorateButton(btn);
            btn.BackColor = Style.PrimaryLight;
        }

        public static void DangerButton(Button btn)
        {
            DecorateButton(btn);
            btn.BackColor = Style.Danger;
        }

        public static void SuccessButton(Button btn)
        {
            DecorateButton(btn);
            btn.BackColor = Style.Success;
        }

        public static void SecondaryButton(Button btn)
        {
            DecorateButton(btn);
            btn.BackColor = Style.PrimaryLighter;
        }

        public static void StylizeTable(DataGridView table)
        {
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            table.BackgroundColor = Color.LightGray;

            // Set background color of header cells
            table.ColumnHeadersDefaultCellStyle.BackColor = PrimaryLighter;
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set background color of content cells
            table.DefaultCellStyle.BackColor = Color.White;
            table.DefaultCellStyle.ForeColor = PrimaryDarker;

            // Optionally, set background color of selected cells
            table.DefaultCellStyle.SelectionBackColor = Primary;
            table.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}

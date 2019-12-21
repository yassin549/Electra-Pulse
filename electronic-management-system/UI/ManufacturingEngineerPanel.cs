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
    public partial class ManufacturingEngineerPanel : Form
    {
        List<int> SelectedRawMaterials = [];
        List<int> SelectedComponents = [];
        List<int> SelectedProcessSteps = [];

        public ManufacturingEngineerPanel()
        {
            InitializeComponent();
            BackColor = Style.PrimaryDarker;
            Style.SuccessButton(ManufactureBtn);
            Style.DangerButton(GoBackBtn);
            Style.PrimaryButton(ProcessStepBtn);
            Style.SecondaryButton(RawMaterialsBtn);
            Style.SecondaryButton(ComponentsBtn);

            var steps = ProcessStepDL.GetProcessSteps();
            for (int i = 0; i < steps.Length; i++)
            {
                var checkbox = new CheckBox();
                checkbox.Text = steps[i];
                checkbox.Tag = i;
                checkbox.ForeColor = Color.White;
                checkbox.Checked = false;
                checkbox.AutoSize = true;
                checkbox.Dock = DockStyle.Fill;
                checkbox.CheckedChanged += (sender, e) =>
                {
                    int id = (int)((CheckBox)sender!).Tag!;
                    if (((CheckBox)sender).Checked)
                        SelectedProcessSteps.Add(id);
                    else
                        SelectedProcessSteps.Remove(id);
                };
                MainPanel.Controls.Add(checkbox);
            }
            var workstations = ObjectHandler.GetWorkstationDL().GetWorkstations();
            foreach (var workstation in workstations)
            {
                WorkstationBox.Items.Add(new ComboBoxItem { Id = workstation.GetId(), Display = workstation.GetName() });
            }
            var devices = DevicesDL.GetCRUD().GetAll();
            foreach (var device in devices)
            {
                DeviceBox.Items.Add(new ComboBoxItem { Id = (int)device["Id"]!, Display = (string)device["Name"]! });
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ProcessStepsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManufactureClick(object sender, EventArgs e)
        {
            MessageBox.Show("Device has been placed in workstation for manufacturing !");
        }

        private void ManufacturingEngineerPanel_Load(object sender, EventArgs e)
        {

        }

        private void ProcessStepBtn_Click(object sender, EventArgs e)
        {
            Style.PrimaryButton(ProcessStepBtn);
            Style.SecondaryButton(RawMaterialsBtn);
            Style.SecondaryButton(ComponentsBtn);

            MainPanel.Controls.Clear();
            var steps = ProcessStepDL.GetProcessSteps();
            for (int i = 0; i < steps.Length; i++)
            {
                var checkbox = new CheckBox();
                checkbox.Text = steps[i];
                checkbox.Tag = i;
                checkbox.ForeColor = Color.White;
                checkbox.Checked = SelectedProcessSteps.Contains(i);
                checkbox.AutoSize = true;
                checkbox.Dock = DockStyle.Fill;
                checkbox.CheckedChanged += (sender, e) =>
                {
                    int id = (int)((CheckBox)sender!).Tag!;
                    if (((CheckBox)sender).Checked)
                        SelectedProcessSteps.Add(id);
                    else
                        SelectedProcessSteps.Remove(id);
                };
                MainPanel.Controls.Add(checkbox);
            }
        }

        private void RawMaterialsBtnClick(object sender, EventArgs e)
        {
            Style.SecondaryButton(ProcessStepBtn);
            Style.PrimaryButton(RawMaterialsBtn);
            Style.SecondaryButton(ComponentsBtn);

            MainPanel.Controls.Clear();
            var materials = MaterialDL.GetCRUD().GetAll();
            for (int i = 0; i < materials.Count; i++)
            {
                var checkbox = new CheckBox();
                int materialId = (int)materials[i]["Id"]!;
                checkbox.Text = (string)materials[i]["Name"]!;
                checkbox.Tag = materialId;
                checkbox.ForeColor = Color.White;
                checkbox.Checked = SelectedRawMaterials.Contains(materialId);
                checkbox.AutoSize = true;
                checkbox.Dock = DockStyle.Fill;
                checkbox.CheckedChanged += (sender, e) =>
                {
                    int id = (int)((CheckBox)sender!).Tag!;
                    if (((CheckBox)sender).Checked)
                        SelectedRawMaterials.Add(id);
                    else
                        SelectedRawMaterials.Remove(id);
                };
                MainPanel.Controls.Add(checkbox);
            }
        }

        private void ComponentsBtnClick(object sender, EventArgs e)
        {
            Style.SecondaryButton(ProcessStepBtn);
            Style.SecondaryButton(RawMaterialsBtn);
            Style.PrimaryButton(ComponentsBtn);

            MainPanel.Controls.Clear();
            var components = ComponentDL.GetCRUD().GetAll();
            for (int i = 0; i < components.Count; i++)
            {
                var checkbox = new CheckBox();
                int componentId = (int)components[i]["Id"]!;
                checkbox.Text = (string)components[i]["Name"]!;
                checkbox.Tag = componentId;
                checkbox.ForeColor = Color.White;
                checkbox.Checked = SelectedComponents.Contains(componentId);
                checkbox.AutoSize = false;
                checkbox.CheckedChanged += (sender, e) =>
                {
                    int id = (int)((CheckBox)sender!).Tag!;
                    if (((CheckBox)sender).Checked)
                        SelectedComponents.Add(id);
                    else
                        SelectedComponents.Remove(id);
                };
                MainPanel.Controls.Add(checkbox);
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            Hide();
            State.SetCurrentForm(new Dashboard());
        }
    }
}

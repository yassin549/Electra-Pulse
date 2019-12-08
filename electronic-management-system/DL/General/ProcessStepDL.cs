using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class ProcessStepDL
    {
        static string[] ProcessSteps = [
            "Preparation",
            "Assembly",
            "Testing",
            "Calibration",
            "Integration",
            "Inspection",
            "Packaging",
            "Labeling",
            "Quality Control",
            "Maintenance",
            "Troubleshooting",
            "Documentation",
            "Cleaning",
            "Soldering",
            "Welding",
            "Cutting",
            "Drilling",
            "Grinding",
            "Polishing",
            "Painting",
            "Injection Molding",
            "Extrusion",
            "Machining",
            "Laminating",
            "Embossing",
            "Etching",
            "Annealing",
            "Tempering",
            "Coating",
            "Engraving",
            "Assembling Circuit Boards",
            "Testing Electrical Connections",
            "Coding",
            "Debugging",
            "Firmware Installation",
            "System Integration",
            "Network Configuration",
            "Sensor Calibration",
            "Signal Processing",
            "Data Logging",
            "Remote Monitoring",
            "Alarm Triggering",
            "Emergency Shutdown",
            "Material Handling",
            "Inventory Management",
            "Supply Chain Coordination",
            "Logistics Planning",
            "Customer Support",
            "Documentation Management",
            "Training and Development"
        ];

        public static string[] GetProcessSteps()
        {
            return ProcessSteps;
        }
    }
}

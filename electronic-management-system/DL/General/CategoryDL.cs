using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class CategoryDL
    {
        static string[] DeviceCategories = [
            "Healthcare",
            "Agriculture",
            "Smart Home",
            "Industrial Automation",
            "Transportation",
            "Retail",
            "Energy Management",
            "Environmental Monitoring",
            "Wearable Technology",
            "Smart Cities",
            "Logistics and Supply Chain",
            "Building Automation",
            "Safety and Security",
            "Fitness and Wellness",
            "Education",
            "Entertainment",
            "Financial Technology (Fintech)",
            "Remote Monitoring",
            "Communication and Networking",
            "Automotive",
            "Smart Grid",
            "Water Management",
            "Oil and Gas",
            "Mining",
            "Aviation",
            "Maritime",
            "Defense",
            "Construction",
            "Manufacturing",
            "Food and Beverage",
            "Pharmaceuticals",
            "Telecommunications",
            "Internet of Things Platforms",
            "Robotics",
            "3D Printing",
            "Augmented Reality",
            "Virtual Reality",
            "Drones",
            "Biotechnology",
            "Chemical Industry",
            "Textile Industry",
            "Hospitality",
            "Insurance",
            "Cybersecurity",
            "Data Analytics",
            "Artificial Intelligence",
            "Machine Learning",
            "Blockchain",
            "Quantum Computing"
        ];

        static string[] ComponentCategories = [
            "Microcontrollers",
            "Sensors",
            "Actuators",
            "Power Supplies",
            "Communication Modules",
            "Displays",
            "Memory Devices",
            "Storage Devices",
            "Analog Circuits",
            "Digital Circuits",
            "Wireless Modules",
            "Connectors",
            "Antennas",
            "Enclosures",
            "Microphones",
            "Speakers",
            "Cameras",
            "LEDs",
            "Motors",
            "Transistors",
            "Capacitors",
            "Resistors",
            "Inductors",
            "Diodes",
            "Integrated Circuits",
            "Printed Circuit Boards (PCBs)",
            "Relays",
            "Switches",
            "Potentiometers",
            "Transformers",
            "Optoelectronic Components",
            "Amplifiers",
            "Filters",
            "Oscillators",
            "Voltage Regulators",
            "Signal Converters",
            "Voltage Dividers",
            "Current Sensors"
        ];

        static string[] DefectCategories = [
            "Hardware Failure",
            "Software Bug",
            "Connection Issues",
            "Battery Drain",
            "Sensor Calibration",
            "Component Compatibility",
            "Physical Damage",
            "User Interface",
            "Power Supply Issues",
            "Data Corruption",
            "Network Congestion",
            "Security Vulnerability",
            "Environmental Factors",
            "Manufacturing Defect",
            "Firmware Update Issues",
            "Miscellaneous/Other"
        ];

        public static string[] GetDeviceCategories()
        {
            return DeviceCategories;
        }

        public static string[] GetComponentCategories()
        {
            return ComponentCategories;
        }

        public static string[] GetDefectCategories()
        {
            return DefectCategories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    internal class Device: Abstract.Entity
    {
        public Category Category;
        public string SerialNumber;
        public Manufacturer Manufacturer;
        public DateTime? ManufacturingDate;
        public List<Component> Components;

        public Device(int id, string name, string description, Category category, string serialNumber, Manufacturer manufacturer, DateTime? manufacturingDate): base(id, name, description)
        {
            Category = category;
            SerialNumber = serialNumber;
            Manufacturer = manufacturer;
            ManufacturingDate = manufacturingDate;
            Components = new List<Component>();
        }

        public Device(int id, string name, string description, Category category, string serialNumber, Manufacturer manufacturer, DateTime? manufacturingDate, List<Component> components): this(id, name, description, category, serialNumber, manufacturer, manufacturingDate)
        {
            Components = components;
        }
    }
}

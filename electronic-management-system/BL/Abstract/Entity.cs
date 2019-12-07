using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL.Abstract
{
    public abstract class Entity
    {
        protected int Id;
        protected string Name;
        protected string Description;
        protected static (string[], Type[]) Schema = (
            ["Id", "Name", "Description"],
            [typeof(int), typeof(string), typeof(string)]
        );

        public Entity(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Entity(Dictionary<string, object?> entity)
        {
            Id = (int)entity["Id"]!;
            Name = (string)entity["Name"]!;
            Description = (string)entity["Description"]!;
        }

        public int GetId() { return Id; }
        public string GetName() { return Name; }
        public static bool IsValidName(string name)
        {
            if (name.Length > 3 && name.Length < 25) return true;
            return false;
        }
        public string GetDescription() {  return Description; }
        public static bool IsValidDescription(string desc)
        {
            if (desc.Length > 5 && desc.Length < 1000) return true;
            return false;
        }
        public static (string[], Type[]) GetSchema()
        {
            return Schema;
        }
    }
}

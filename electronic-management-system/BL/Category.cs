using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public enum CategoryType
    {
        Device,
        Component,
        Defect
    }

    public class Category: Abstract.Entity
    {
        CategoryType CategoryType;
        new static (string[], Type[]) Schema = (
            ["Id", "Name", "Description", "Category"],
            [typeof(int), typeof(string), typeof(string), typeof(int)]
        );

        public Category(int id, string name, string description, CategoryType categoryType): base(id, name, description)
        {
            CategoryType = categoryType;
        }

        public Category(Dictionary<string, object?> category): base(category)
        {
            CategoryType = (CategoryType)category["CategoryType"]!;
        }

        public CategoryType GetCategoryType() { return CategoryType; }
        public Dictionary<string, object?> GetDictionary()
        {
            return new Dictionary<string, object?>
            {
                ["Id"] = Id,
                ["Name"] = Name,
                ["Description"] = Description,
                ["Category"] = CategoryType
            };
        }
        public void SetCategoryType(CategoryType categoryType) {  CategoryType = categoryType; }
    }
}

using System;

namespace CaseStudy
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public override string ToString()
        {
            return "Id: " + CategoryId + " Category Name: " + CategoryName;
        }
    }
}

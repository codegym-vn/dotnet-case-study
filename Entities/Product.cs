using System;

namespace CaseStudy
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public override string ToString()
        {
            return "|" + "Id: " + Id + "Product Name: " + ProductName + "Price: " + Price + "|";
        }
    }
}

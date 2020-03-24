using CaseStudy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DotNetCaseStudy.DAL
{
    public class Service
    {
        List<Product> products = new List<Product>();
        List<Category> categories = new List<Category>();
        string productFile = "productList.txt";
        string categoryFile = "categoryList.txt";
        public List<Category> GetAllCategory()
        {
            categories = new List<Category>();
            using (StreamReader sr = new StreamReader(categoryFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Category c = new Category();
                    c.CategoryId = Int32.Parse(line.Split("-")[0].Split("=")[1]);
                    c.CategoryName = line.Split("-")[1].Split("=")[1];

                    categories.Add(c);
                }
                return categories;
            }
        }
        public void RemoveCategory(int calId)
        {
            categories = GetAllCategory();
            Category cal = new Category();
            foreach (var item in categories)
            {
                if (item.CategoryId == calId)
                {
                    cal = item;
                }
            }
            categories.Remove(cal);
            WriteCategoryFile(categories);

        }
        public void AddCategory(Category c)
        {
            categories = GetAllCategory();
            categories.Add(c);
            WriteCategoryFile(categories);
        }
        public string GetCategoryName(List<Category> categories, int cId)
        {
            string cName = "";
            foreach (var item in categories)
            {
                if (item.CategoryId == cId)
                {
                    cName = item.CategoryName;
                }
            }
            return cName;
        }
        public void UpdateCategory(Category cat)
        {
            categories = GetAllCategory();
            foreach (var item in categories)
            {
                if (item.CategoryId == cat.CategoryId)
                {
                    item.CategoryName = cat.CategoryName;
                }
            }
            WriteCategoryFile(categories);
        }
        public List<Product> GetAllProduct()
        {
            products = new List<Product>();
            using (StreamReader sr = new StreamReader(productFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product p = new Product();
                    var data = line.Split("-");
                    p.Id = Int32.Parse(data[0].Split(":")[1]);
                    p.ProductName = data[1].Split(":")[1];
                    p.Price = float.Parse(data[2].Split(":")[1]);
                    products.Add(p);
                }
                return products;
            }
        }
        public void AddProduct(Product product)
        {
            products = GetAllProduct();
            products.Add(product);
            WriteProductFile(products);
        }
        public void UpdateProduct(Product prod)
        {
            products = GetAllProduct();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == prod.Id)
                {
                    products[i].ProductName = prod.ProductName;
                    products[i].Price = prod.Price;
                }
            }
            WriteProductFile(products);
        }
        public bool CheckCategoryId(List<Category> categories, int id)
        {
            bool isExist = false;
            foreach (var item in categories)
            {
                if (item.CategoryId == id)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        public bool CheckProductId(List<Product> products, int id)
        {
            bool isExist = false;
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        public void RemoveProduct(int productId)
        {
            products = GetAllProduct();
            Product p = new Product();
            foreach (var item in products)
            {
                if (item.Id == productId)
                {
                    p = item;
                }
            }
            products.Remove(p);
            WriteProductFile(products);
        }
        public void WriteCategoryFile(List<Category> categories)
        {
            using (TextWriter tw = new StreamWriter(categoryFile))
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    tw.WriteLine(string.Format("{0}: Id= {0} - Category Name= {1}", categories[i].CategoryId, categories[i].CategoryName));
                }
            }
        }
        public void WriteProductFile(List<Product> products)
        {
            using (TextWriter tw = new StreamWriter(productFile))
            {
                foreach (var product in products)
                {
                    string categoryName = GetCategoryName(categories, product.CategoryId);
                    tw.WriteLine(string.Format("Id: {0} - Product Name: {1} - Price: {2} - Category Id: {3} - Category Name: {4}", product.Id, product.ProductName, product.Price, product.CategoryId, categoryName));
                }
            }
        }
        public void ShowAllProduct()
        {
            products = GetAllProduct();
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void ShowAllCategory()
        {
            categories = GetAllCategory();
            foreach (var item in categories)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

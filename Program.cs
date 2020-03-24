using DotNetCaseStudy.DAL;
using System;
using System.Collections.Generic;

namespace CaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
        Main:
            var categories = service.GetAllCategory();
            do
            {
                if (categories.Count > 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("________________________________");
                    Console.WriteLine("|1: Product Management         |");
                    Console.WriteLine("|2: Category Management        |");
                    Console.WriteLine("|0: Exit                       |");
                    Console.WriteLine("|______________________________|");
                    Console.Write("Your choice:");
                    int choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("\n---------------------------------------");
                                Console.WriteLine("1: Add new product");
                                Console.WriteLine("2: Remove a product");
                                Console.WriteLine("3: Update a product");
                                Console.WriteLine("4: Get all product");
                                Console.WriteLine("0: Back");
                                int choice2 = Int32.Parse(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 1:
                                        Product p = new Product();
                                        Console.WriteLine("Select a category:");
                                        for (int i = 0; i < categories.Count; i++)
                                        {
                                            Console.WriteLine("{0}: Category {1}", i + 1, categories[i].CategoryName);
                                        }
                                        Console.Write("Your Choice : ");
                                        int choiceCategory = Int32.Parse(Console.ReadLine());
                                        p.CategoryId = categories[choiceCategory - 1].CategoryId;
                                        Console.Write("Enter product id:");
                                        p.Id = Int32.Parse(Console.ReadLine());
                                        Console.Write("Enter product name: ");
                                        p.ProductName = Console.ReadLine();
                                        Console.Write("Enter price: ");
                                        p.Price = float.Parse(Console.ReadLine());

                                        service.AddProduct(p);
                                        Console.WriteLine("Add new product success");
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter product id you want to remove:");
                                        int idRemove = Int32.Parse(Console.ReadLine());
                                        service.RemoveProduct(idRemove);
                                        Console.WriteLine("Remove a product success");
                                        break;
                                    case 3:
                                        Product product = new Product();
                                        Console.Write("Enter product id:");
                                        product.Id = Int32.Parse(Console.ReadLine());
                                        Console.Write("Enter product name: ");
                                        product.ProductName = Console.ReadLine();
                                        Console.Write("Enter price: ");
                                        product.Price = float.Parse(Console.ReadLine());
                                        service.UpdateProduct(product);
                                        Console.WriteLine("product updated");
                                        break;
                                    case 4:
                                        service.ShowAllProduct();
                                        break;
                                    case 0:
                                        goto Main;
                                    default:
                                        Environment.Exit(0);
                                        break;
                                }
                            } while (true);
                        case 2:
                            do
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine("1: Add new category");
                                Console.WriteLine("2: Remove a category");
                                Console.WriteLine("3: Update a category");
                                Console.WriteLine("4: Get all category");
                                Console.WriteLine("0: Back");
                                int choice2 = Int32.Parse(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 1:
                                        Category cal = new Category();
                                        Console.WriteLine("Enter category id:");
                                        cal.CategoryId = Int32.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter categoty name:");
                                        cal.CategoryName = Console.ReadLine();
                                        service.AddCategory(cal);
                                        Console.WriteLine("--------Add Category Success !--------");
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter category id:");
                                        int calId = Int32.Parse(Console.ReadLine());
                                        service.RemoveCategory(calId);
                                        Console.WriteLine("--------Category Deleted !--------");
                                        break;
                                    case 3:
                                        Category calUpdate = new Category();
                                        Console.WriteLine("Enter category id:");
                                        calUpdate.CategoryId = Int32.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter category name:");
                                        calUpdate.CategoryName = Console.ReadLine();
                                        service.UpdateCategory(calUpdate);
                                        Console.WriteLine("--------Category Updated !--------");
                                        break;
                                    case 4:
                                        service.ShowAllCategory();
                                        break;
                                    case 0:
                                        goto Main;
                                    default:
                                        Environment.Exit(0);
                                        break;
                                }
                            } while (true);
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Category c = new Category();
                    bool idCorrect = true;
                AddNewCategory:
                    do
                    {
                        Console.WriteLine("Enter category id: ");
                        string idStr = Console.ReadLine();
                        if (idStr != "")
                        {
                            int categoryId = Int32.Parse(idStr);
                            bool isExist = service.CheckCategoryId(categories, categoryId);
                            if (!isExist)
                            {
                                c.CategoryId = categoryId;
                                idCorrect = false;
                            }
                        }
                    } while (idCorrect);
                    Console.Write("Enter category name: ");
                    c.CategoryName = Console.ReadLine();

                    service.AddCategory(c);
                    Console.WriteLine("--------Add Category Success !--------");
                    Console.WriteLine("Do you want to create new category ?");
                    Console.Write("Y/N: ");
                    string choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        goto AddNewCategory;
                    }
                    else
                    {
                        goto Main;
                    }
                }
            } while (true);
        }
    }
}

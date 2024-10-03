//სავარჯიშო 3: პროდუქციის გაყიდვების მართვა
//შენი კომპანია ყიდის პროდუქტებს. გვჭირდება პროგრამა რომელიც დაიანგარიშებს გაყიდვების სტატისტიკას.
//პროგრამა უნდა ითვლიდეს გაყიდვების ჯამურ ღირებულებას კვირის დღეების მიხედვით
//პროგრამა უნდა ითვლიდეს გაყიდვების საერთო მოცულობას კვირის ბოლოს.

namespace Week4_3;
using System;
using System.Collections.Generic;

public class Product
{
    public string NameOfProduct { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

    public Product(string nameOfProduct, decimal price, int amount)
    {
        NameOfProduct = nameOfProduct;
        Price = price;
        Amount = amount;
    }

    public decimal CalculateTotalValue(int quantitySold)
    {
        return Price * quantitySold;
    }
}

public class Program
{
    public static void Main()
    {
        Dictionary<string, List<Product>> ByDayOfSales = new Dictionary<string, List<Product>>()
        {
            { "Monday", new List<Product>
                {
                    new Product("vashli", 3m, 50),
                    new Product("atami", 5m, 30)
                }
            },
            { "Tuesday", new List<Product>
                {
                    new Product("mandarini", 4m, 40),
                    new Product("kivi", 7m, 20)
                }
            },
            { "Wednesday", new List<Product>
                {
                    new Product("banani", 2m, 60),
                    new Product("xurma", 6m, 25)
                }
            },
            { "Thursday", new List<Product>
                {
                    new Product("msxali", 3.5m, 35),
                    new Product("yurdzeni", 8m, 20)
                }
            },
            { "Friday", new List<Product>
                {
                    new Product("marwyvi", 9m, 15),
                    new Product("alubali", 7.5m, 25)
                }
            },
            { "Saturday", new List<Product>
                {
                    new Product("ananasi", 12m, 10),
                    new Product("gogra", 4.5m, 40)
                }
            },
            { "Sunday", new List<Product>
                {
                    new Product("limonati", 2.5m, 50),
                    new Product("tarxuniswveni", 6m, 35)
                }
            }
        };

        decimal totalSales = 0m; 
        foreach (var day in ByDayOfSales)
        {
            Console.WriteLine($"\n{day.Key} gayidvebi:");
            List<Product> dayProducts = day.Value;
            decimal dailySales = 0m;

            foreach (var product in dayProducts)
            {
                int quantity = product.Amount; 
                decimal productTotalValue = product.CalculateTotalValue(quantity);
                dailySales += productTotalValue;

                Console.WriteLine($"{product.NameOfProduct} - {quantity} erteuli gaiyida, jamuri fasi: {productTotalValue} larshi");
            }

            Console.WriteLine($"{day.Key} dRis saerTo gayidvebi: {dailySales} lari");
            totalSales += dailySales;
        }
        Console.WriteLine($"\nsaerto gayidvebis raodenoba kviris bolos: {totalSales} lari");
    }
}

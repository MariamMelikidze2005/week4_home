//შენი კომპანია ყიდის პროდუქტებს და გჭირდება პროგრამა, რომელიც მართავს პროდუქციის ჩამონათვალს. 
//    პროდუქტს აქვს დასახელება, ფასი და რაოდენობა.
//პროგრამამ უნდა დაიანგარიშოს თითოეული პროდუქტის ჯამური ღირებულება, და ასევე პროდუქტების საერთო ღირებულება.

namespace Week4_2;
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

    public decimal CalculateTotalValue(int quantity)
    {
        return Price * quantity;
    }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("vashli", 15m, 5),
            new Product("msxali", 10m, 4),
            new Product("atami", 5m, 6)
        };

        decimal totalValue = 0m;
        string continueShopping;

        do
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].NameOfProduct} - {products[i].Price} per item (misawvdomeli raodenoba: {products[i].Amount})");
            }

            Console.WriteLine("airchie produqti misi nomris mixedviT:");
            string inputname = Console.ReadLine();
            int productIndex;

            if (int.TryParse(inputname, out productIndex) && productIndex > 0 && productIndex <= products.Count)
            {
                Product selectedProduct = products[productIndex - 1];
                Console.WriteLine($"Sen airCie: {selectedProduct.NameOfProduct}.  ramdens iyidit?");

                string amountInput = Console.ReadLine();
                int quantity;
                if (int.TryParse(amountInput, out quantity) && quantity > 0 && quantity <= selectedProduct.Amount)
                {
                    selectedProduct.Amount -= quantity;
                    decimal productTotalValue = selectedProduct.CalculateTotalValue(quantity);
                    totalValue += productTotalValue;
                    Console.WriteLine($"jami {quantity} {selectedProduct.NameOfProduct}(s): {productTotalValue}");
                }
                else
                {
                    Console.WriteLine("amdeni produqcia ar gvaqvs!");
                }
            }

            Console.WriteLine("ginda gaagrdzeelo yidva? (yes/no)");
            continueShopping = Console.ReadLine().ToLower();

        } while (continueShopping == "yes" || continueShopping == "y");

        Console.WriteLine($"Produqtebis jami girebuleba: {totalValue}");
    }
}

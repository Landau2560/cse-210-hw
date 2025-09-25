using System;


class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 Orange St", "Phoenix", "AZ", "USA");
        var customer1 = new Customer("John Doe", address1);
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Board Game", "BG100", 29.99m, 1));
        order1.AddProduct(new Product("Dice Set", "DICE42", 4.5m, 2));


        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.TotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));


        var address2 = new Address("456 Oak Lane", "Toronto", "ON", "Canada");
        var customer2 = new Customer("Jane Smith", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("T-shirt", "TS200", 19.99m, 3));
        order2.AddProduct(new Product("Sticker Pack", "STK09", 2.99m, 5));

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.TotalPrice():0.00}");

    }
}
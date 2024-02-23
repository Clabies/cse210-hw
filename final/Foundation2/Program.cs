using System;

class Program
{
    static void Main(string[] args)
    {
        // Create address
        var address1 = new Address
        {
            Street = "123 Main St",
            City = "Anytown",
            StateProvince = "CA",
            Country = "USA"
        };

        // Create customer
        var customer1 = new Customer
        {
            Name = "John Doe",
            Address = address1
        };

        // Create products
        var product1 = new Product
        {
            Name = "Product 1",
            ProductId = 1,
            Price_Per_Unit = 10,
            Quantity = 2
        };

        var product2 = new Product
        {
            Name = "Product 2",
            ProductId = 2,
            Price_Per_Unit = 20,
            Quantity = 1
        };

        // Create order
        var order1 = new Order(customer1);
        order1.Add_Product(product1);
        order1.Add_Product(product2);

        // Display order details
        Console.WriteLine(order1.Get_Packing_Label());
        Console.WriteLine(order1.Get_Shipping_Label());
        Console.WriteLine($"Total Price: ${order1.Calculate_Total_Cost()}");

        // Create another order for demonstration
        var address2 = new Address
        {
            Street = "456 Elm St",
            City = "Othertown",
            StateProvince = "NY",
            Country = "Canada"
        };

        var customer2 = new Customer
        {
            Name = "Jane Smith",
            Address = address2
        };

        var product3 = new Product
        {
            Name = "Product 3",
            ProductId = 3,
            Price_Per_Unit = 15,
            Quantity = 3
        };

        var order2 = new Order(customer2);
        order2.Add_Product(product3);

        Console.WriteLine("\n=== Second Order ===");
        Console.WriteLine(order2.Get_Packing_Label());
        Console.WriteLine(order2.Get_Shipping_Label());
        Console.WriteLine($"Total Price: ${order2.Calculate_Total_Cost()}");
    }
}
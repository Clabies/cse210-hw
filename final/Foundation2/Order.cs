using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void Add_Product(Product product)
    {
        _products.Add(product);
    }

    public decimal Calculate_Total_Cost()
    {
        decimal total_cost = _products.Sum(product => product.Total_Cost);
        total_cost += _customer.Is_In_USA() ? 5 : 35; // Shipping cost
        return total_cost;
    }

    public string Get_Packing_Label()
    {
        string packing_label = "Packing Label:\n";
        foreach (var product in _products)
        {
            packing_label += $"{product.Name} - {product.ProductId}\n";
        }
        return packing_label;
    }

    public string Get_Shipping_Label()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address}";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price_Per_Unit { get; set; }
    public int Quantity { get; set; }

    public decimal Total_Cost => Price_Per_Unit * Quantity;
}
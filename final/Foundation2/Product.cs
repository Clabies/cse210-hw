using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal PricePerUnit { get; set; }
    public int Quantity { get; set; }

    public decimal TotalCost => PricePerUnit * Quantity;
}
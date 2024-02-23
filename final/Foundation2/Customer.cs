using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool Is_In_USA()
    {
        return Address.Is_In_USA();
    }
}
﻿namespace Hold.Models;

public class Country
{
    public int Id { get; set; }
    public string CountryName { get; set; }

    public override string ToString()
    {
        return $"{CountryName}";
    }
}

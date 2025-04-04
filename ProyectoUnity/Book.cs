using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Book 
{
    public string Name { get; }
    public string Author { get; }
    public string Category { get; }
    public int Year { get; }

    public Book(string name, string author, string category, int year)
    {
        Name = name;
        Author = author;
        Category = category;
        Year = year;
    }
}

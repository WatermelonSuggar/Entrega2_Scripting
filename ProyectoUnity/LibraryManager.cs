using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchByName : ISearchStrategy
{
    private string name;
    public SearchByName(string name) { this.name = name; }
    public List<Book> Search(List<Book> books)
    {
        return books.Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

public class LibraryManager 
{
    private static LibraryManager _instance;
    public static LibraryManager Instance => _instance ??= new LibraryManager();

    private List<Book> books = new List<Book>();
    public event Action OnBooksUpdated;

    private LibraryManager() { }

    public void AddBook(Book book)
    {
        books.Add(book);
        OnBooksUpdated?.Invoke();
    }

    public List<Book> SearchBooks(ISearchStrategy strategy)
    {
        return strategy.Search(books);
    }
}

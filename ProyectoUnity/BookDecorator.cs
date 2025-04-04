using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BookDecorator : Book
{
    protected Book baseBook;
    public BookDecorator(Book book) : base(book.Name, book.Author, book.Category, book.Year)
    {
        baseBook = book;
    }
}

public class BookWithSummary : BookDecorator
{
    public string Summary { get; }
    public BookWithSummary(Book book, string summary) : base(book)
    {
        Summary = summary;
    }
}

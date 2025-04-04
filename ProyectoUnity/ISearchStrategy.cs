using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ISearchStrategy 
{
    List<Book> Search(List<Book> books);
}

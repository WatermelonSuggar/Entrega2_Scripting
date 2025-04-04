using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryUI : MonoBehaviour
{
    void Start()
    {
        LibraryManager.Instance.OnBooksUpdated += UpdateUI;
        LibraryManager.Instance.AddBook(new Book("El Gran Libro", "Autor Desconocido", "Ficción", 2021));
        LibraryManager.Instance.AddBook(new Book("El viejo y el mar", "HErmes hemingway", "Ficcion nautica", 1952));
        LibraryManager.Instance.AddBook(new Book("El arte de la guerra", "Zung Zung", "Guerra", 200));
        LibraryManager.Instance.AddBook(new Book("El libro troll del rubius", "El rubius", "Bromas", 2012));
        LibraryManager.Instance.AddBook(new Book("Nacidos de la bruma", "Brandon sanderson", "Literatura fantastica ", 2006));

    }

    void UpdateUI()
    {
        Debug.Log("Lista de libros actualizada");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class AddBookButton : MonoBehaviour
{
    public void AddBook()
    {
        LibraryManager.Instance.AddBook(new Book("Nuevo Libro", "Autor", "Categor�a", 2022));
    }
}

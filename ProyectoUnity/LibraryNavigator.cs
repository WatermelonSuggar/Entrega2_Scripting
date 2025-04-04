using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LibraryNavigator : MonoBehaviour
{
    public TMP_Text bookText;
    public Button prevButton;
    public Button nextButton;

    private List<Book> books;
    private int currentIndex = 0;

    void Start()
    {
        books = LibraryManager.Instance.SearchBooks(new SearchByName("")); // Obtiene todos los libros
        UpdateUI();
        if (bookText == null)
        {
            Debug.LogError("BookText no está asignado en el Inspector.");
        }
        prevButton.onClick.AddListener(ShowPreviousBook);
        nextButton.onClick.AddListener(ShowNextBook);
    }

    void UpdateUI()
    {
        if (books.Count > 0 && currentIndex >= 0 && currentIndex < books.Count)
        {
            bookText.text = $"{books[currentIndex].Name}\nAutor: {books[currentIndex].Author}\nCategoría: {books[currentIndex].Category}\nAño: {books[currentIndex].Year}";
        }
        else
        {
            bookText.text = "No hay libros en la biblioteca.";
        }
    }

    void ShowPreviousBook()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    void ShowNextBook()
    {
        if (currentIndex < books.Count - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }
}

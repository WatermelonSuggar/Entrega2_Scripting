using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchBookUI : MonoBehaviour
{
    public TMP_InputField searchInput;
    public Button searchButton;
    public TMP_Text resultText;


    void Start()
    {
        searchButton.onClick.AddListener(SearchBook);
    }

    void SearchBook()
    {
        string query = searchInput.text;
        List<Book> results = LibraryManager.Instance.SearchBooks(new SearchByName(query));

        if (results.Count > 0)
        {
            resultText.text = "";
            foreach (Book book in results)
            {
                resultText.text += $"{book.Name} - {book.Author} ({book.Year})\n";
            }
        }
        else
        {
            resultText.text = "No se encontraron libros.";
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddBookUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField authorInput;
    public TMP_InputField categoryInput;
    public TMP_InputField yearInput;
    public Button addBookButton;

    void Start()
    {
        addBookButton.onClick.AddListener(AddBook);
    }

    void AddBook()
    {
        string name = nameInput.text;
        string author = authorInput.text;
        string category = categoryInput.text;
        int year;

        if (int.TryParse(yearInput.text, out year))
        {
            LibraryManager.Instance.AddBook(new Book(name, author, category, year));
            Debug.Log($"Libro agregado: {name}");
        }
        else
        {
            Debug.LogError("El año debe ser un número válido.");
        }
    }
}

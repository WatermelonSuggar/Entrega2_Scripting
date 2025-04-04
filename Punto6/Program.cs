using System;
using System.Collections.Generic;

// INTERFAZ DEL OBSERVER
public interface IObserver
{
    void Update(string message);
}

// INTERFAZ DEL SUBJECT
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}

// CLASE SUBJECT (EMISOR)
public class NewsPublisher : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine("📢 Se ha registrado un nuevo observador.");
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine("🗑️ Se ha removido un observador.");
    }

    public void NotifyObservers(string message)
    {
        Console.WriteLine($"📨 Notificando a {observers.Count} observadores...");
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    // Método para cambiar el estado
    public void PublishNews(string news)
    {
        Console.WriteLine($"\n📰 Nueva noticia: {news}");
        NotifyObservers(news);
    }
}

// OBSERVADORES CONCRETOS
public class EmailSubscriber : IObserver
{
    private string name;

    public EmailSubscriber(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"📧 {name} ha recibido la noticia por correo: {message}");
    }
}

public class SmsSubscriber : IObserver
{
    private string phone;

    public SmsSubscriber(string phone)
    {
        this.phone = phone;
    }

    public void Update(string message)
    {
        Console.WriteLine($"📱 SMS a {phone}: {message}");
    }
}

// PROGRAMA PRINCIPAL
class Program
{
    static void Main(string[] args)
    {
        NewsPublisher publisher = new NewsPublisher();

        // Crear observadores
        IObserver observer1 = new EmailSubscriber("Carlos");
        IObserver observer2 = new SmsSubscriber("300-123-4567");

        // Registrar observadores
        publisher.RegisterObserver(observer1);
        publisher.RegisterObserver(observer2);

        // Publicar noticias
        publisher.PublishNews("¡El patrón Observer es genial!");
        publisher.PublishNews("Se lanzó .NET 8 🚀");

        // Remover un observador
        publisher.RemoveObserver(observer2);

        // Nueva noticia
        publisher.PublishNews("Noticia solo para suscriptores de correo.");
    }
}

using System;
using System.Collections.Generic;

// Definimos un delegado para notificar cambios
public delegate void NotificacionEvento(string mensaje);

// Clase que actúa como sujeto (Publisher)
public class TiendaLibros
{
    public event NotificacionEvento OnLibroAgregado;

    public void AgregarLibro(string titulo, double precio)
    {
        Console.WriteLine($"Se ha agregado el libro '{titulo}' (${precio}).");
        OnLibroAgregado?.Invoke($"Nuevo libro disponible: '{titulo}' por ${precio}");
    }
}

// Clase que actúa como observador (Subscriber)
public class Usuario
{
    private string nombre;

    public Usuario(string nombre)
    {
        this.nombre = nombre;
    }

    public void RecibirNotificacion(string mensaje)
    {
        Console.WriteLine($"{nombre} ha recibido una notificación: {mensaje}");
    }
}

class Program
{
    static void Main()
    {
        TiendaLibros tienda = new TiendaLibros();

        Usuario usuario1 = new Usuario("Carlos");
        Usuario usuario2 = new Usuario("Ana");

        // Suscribimos los usuarios a las notificaciones de la tienda
        tienda.OnLibroAgregado += usuario1.RecibirNotificacion;
        tienda.OnLibroAgregado += usuario2.RecibirNotificacion;

        // Se agregan libros y se notifica a los usuarios
        tienda.AgregarLibro("C# Avanzado", 29.99);
        tienda.AgregarLibro("Diseño de Videojuegos", 39.99);
    }
}

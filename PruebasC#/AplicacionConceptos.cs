using System;
using System.Collections.Generic;
using System.Text;

// SINGLETON: SISTEMA DE GUARDADO
public class GameSave
{
    private static GameSave instance;
    private static readonly object lockObj = new object();
    
    private GameSave() { } // Constructor privado

    public static GameSave Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new GameSave();
                }
                return instance;
            }
        }
    }

    public void GuardarProgreso(string progreso)
    {
        Console.WriteLine($"Progreso guardado: {progreso}");
    }
}

// OBSERVER: ACTUALIZAR HUD AUTOMÁTICAMENTE
public class HUD
{
    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine($"HUD: {mensaje}");
    }
}

public class Jugador
{
    public event Action<string> OnEventoHUD; // Delegado para notificaciones
    
    public void RecibirDanio(int puntos)
    {
        Console.WriteLine($"Jugador recibe {puntos} de daño.");
        OnEventoHUD?.Invoke($"Vida reducida en {puntos} puntos.");
    }

    public void RecogerMoneda(int cantidad)
    {
        Console.WriteLine($"Jugador recoge {cantidad} monedas.");
        OnEventoHUD?.Invoke($"Monedas: +{cantidad}");
    }
}

// ANTIPATRÓN: CLASE DIOS (GOD OBJECT)
public class GameManager
{
    public int VidaJugador = 100;
    public int Puntuacion = 0;
    public string NivelActual = "Bosque Encantado";
    
    public void MoverJugador() => Console.WriteLine("Jugador se mueve.");
    public void AtacarEnemigo() => Console.WriteLine("Ataque realizado.");
    public void CalcularFísica() => Console.WriteLine("Física del juego calculada.");
    public void IAEnemigos() => Console.WriteLine("IA enemiga procesada.");
    public void GuardarPartida() => Console.WriteLine("Partida guardada.");
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\nSelecciona un ejemplo para ejecutar:");
            Console.WriteLine("1. Singleton (Sistema de Guardado)");
            Console.WriteLine("2. Observer (HUD y Notificaciones)");
            Console.WriteLine("3. Antipatrón (Clase Dios)");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");
            
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    GameSave.Instance.GuardarProgreso("Nivel 3 - Jefe Final");
                    break;
                
                case "2":
                    HUD hud = new HUD();
                    Jugador jugador = new Jugador();
                    jugador.OnEventoHUD += hud.MostrarMensaje;
                    
                    jugador.RecibirDanio(20);
                    jugador.RecogerMoneda(5);
                    break;
                
                case "3":
                    GameManager gameManager = new GameManager();
                    gameManager.MoverJugador();
                    gameManager.AtacarEnemigo();
                    gameManager.CalcularFísica();
                    gameManager.IAEnemigos();
                    gameManager.GuardarPartida();
                    break;
                
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}

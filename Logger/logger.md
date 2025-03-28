**Código anterior**

```cs
namespace Prueba1;

//Clase Logger opc1

public class Logger
{
    // Instancia privada y estática de la clase
    private static Logger instance;
    
    // Bloqueo estático para asegurar que es thread-safe
    private static readonly object lockObj = new object();

    // Ruta del archivo de log
    private readonly string logFilePath = "log.txt";

    // Constructor privado para evitar instanciación externa
    private Logger() { }

    // Propiedad para acceder a la instancia única
    public static Logger Instance
    {
        get
        {
            // Si la instancia no existe, la crea
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }
            return instance;
        }
    }

    // Método para registrar mensajes en el archivo
    public void Log(string message)
    {
        try
        {
            // Escribir en el archivo de log
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir en el archivo de log: " + ex.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo de uso del Logger Singleton
        Logger.Instance.Log("Este es un mensaje de log.");
        Logger.Instance.Log("Otro mensaje de log.");
        
        Console.WriteLine("Mensajes registrados en log.txt.");
    }
}

```
![image](https://github.com/user-attachments/assets/5288731f-d931-4213-be1a-aaf4f1c911c6)

**Nuevo código**

```cs
using System;
using System.IO;

namespace Prueba1
{
    // Clase Logger implementando el patrón Singleton
    public class Logger
    {
        // Instancia única usando Lazy<T> para una inicialización segura
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        // Ruta del archivo de log
        private readonly string logFilePath;

        // Constructor privado para evitar instanciación externa
        private Logger()
        {
            // Define la ruta en la misma carpeta del ejecutable
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        }

        // Propiedad pública para acceder a la instancia única
        public static Logger Instance => instance.Value;

        // Método para registrar mensajes en el archivo
        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    string logMessage = $"{DateTime.Now}: {message}";
                    writer.WriteLine(logMessage);
                    Console.WriteLine(logMessage); // Muestra el mensaje en consola
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] No se pudo escribir en el log: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Ejemplo de uso del Logger Singleton
            Logger.Instance.Log("Este es un mensaje de log.");
            Logger.Instance.Log("Otro mensaje de log.");

            Console.WriteLine("Mensajes registrados en log.txt.");
        }
    }
}
```
**Código nuevo ejecutado**

![image](https://github.com/user-attachments/assets/94a576d6-f528-488c-9861-531a8c7e06a1)

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

**Compilación**
![image](https://github.com/user-attachments/assets/83492f14-e899-4664-b992-8e723ee3ffa3)

> El propósito del Logger es que cualquier parte del programa pueda registrar eventos sin depender de la consola.

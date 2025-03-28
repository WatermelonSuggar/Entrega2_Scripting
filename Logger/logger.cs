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

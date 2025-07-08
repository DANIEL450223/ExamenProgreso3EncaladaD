using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3EncaladaD.Services
{
    public static class LogService
    {
        private static string logFilePath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Encalada.txt");

        public static async Task EscribirLogAsync(string nombre)
        {
            string log = $"Se incluyó el registro [{nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            await File.AppendAllTextAsync(logFilePath, log + Environment.NewLine);
        }

        public static async Task<List<string>> LeerLogsAsync()
        {
            if (!File.Exists(logFilePath)) return new List<string>();
            return (await File.ReadAllLinesAsync(logFilePath)).ToList();
        }
    }
}

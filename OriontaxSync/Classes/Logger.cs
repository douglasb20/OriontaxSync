using System;
using System.IO;

namespace OriontaxSync.Classes
{
    public static class Logger
    {
        private static readonly string LogDirectory = "Logs";
        private static readonly string LogFile = $"{LogDirectory}/log_{DateTime.Now:yyyyMMdd}.txt";

        static Logger()
        {
            // Cria o diretório de logs se não existir
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void Log(string message, string logLevel = "INFO")
        {
            try
            {
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logLevel}] {message}";
                File.AppendAllText(LogFile, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar log: {ex.Message}");
            }
        }

        private static void DeleteOldLogs(int daysToKeep)
        {
            try
            {
                // Obtém todos os arquivos no diretório de logs
                var logFiles = Directory.GetFiles(LogDirectory, "Log_*.txt");

                foreach (var file in logFiles)
                {
                    // Extrai a data do nome do arquivo
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.StartsWith("Log_") && DateTime.TryParse(fileName.Substring(4), out DateTime logDate))
                    {
                        // Exclui arquivos mais antigos que o período especificado
                        if (logDate < DateTime.Now.AddDays(-daysToKeep))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir logs antigos: {ex.Message}");
            }
        }
    }
}

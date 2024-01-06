
namespace ExerciseListOOP.Logger
{
    public class LogWriter
    {
        private string logFilePath = string.Empty;

        public LogWriter()
        {
            InitializeLogFilePath();
        }

        private void InitializeLogFilePath()
        {
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        }
        public void WriteLog(string logMessage, string level = "Info")
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    FormatAndWriteLog(logMessage, writer, level);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro escrevendo o log: {ex.Message}");
            }
        }
        private void FormatAndWriteLog(string logMessage, TextWriter textWriter, string level)
        {
            try
            {
                textWriter.Write("\r\nLog Entry: ");
                textWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                textWriter.WriteLine("Level: {level}");
                textWriter.WriteLine($"Message: {logMessage}");
                textWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro formatando e escrevendo log: {ex.Message}");
            }
        }
    }
}

using ExerciseListOOP.Logger;

namespace ExerciseListOOP.ConsoleInteraction.Components
{
    public class Message
    {
        static LogWriter _logWriter = new LogWriter();

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar.");
            ConsoleKeyInfo key = Console.ReadKey();
            LogWrite($"Tecla pressionada: {key}", "ConsoleKeyInfo");
        }
        public static void Error(string prompt)
        {
            string titleError = Title.Error();
            WriteTitle(titleError, "Red");

            LogAndConsoleWrite(prompt);
            PressAnyKeyToContinue();
        }

        public static void WriteTitle(string titleError, string color = "White")
        {
            if (Enum.TryParse(color, true, out ConsoleColor consoleColor))
            {
                Console.ForegroundColor = consoleColor;
                Console.WriteLine(titleError);
                Console.ResetColor();
            }
            else
            {
                LogAndConsoleWrite($"Cor inválida especificada ({color})");
                PressAnyKeyToContinue();
            }
        }

        public static void CatchException(Exception ex)
        {
            Error(ex.Message);
        }
        public static void LogAndConsoleWrite(string prompt, string level = "Info")
        {
            LogWrite(prompt, level);
            Console.WriteLine($"\n{prompt}");
        }

        public static void LogWrite(string prompt, string level = "Info")
        {
            _logWriter.WriteLog(prompt, level);
        }
    }
}

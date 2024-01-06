using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using ExerciseListOOP.Domain.TemperatureConverter;
using System.Text.RegularExpressions;

namespace ExerciseListOOP.Domain.Service
{
    internal class TemperatureConverter : IMenuConvertible
    {
        private readonly string MenuTitle = Title.TemperatureConverter();
        private readonly string TitleColor = "Magenta";

        private readonly Menu _mainMenu;
        private ITemperatureConverter _temperatureConverter;

        private readonly string[] _mainMenuOptions =
        {
            "Celsius para Fahrenheit",
            "Fahrenheit para Celsius",
            "Sair"
        };

        public TemperatureConverter()
        {
            _mainMenu = new Menu(_mainMenuOptions);
        }

        public int Display(string title, string color)
        {
            return _mainMenu.DisplayMenu(title, color);
        }

        public void Analyze(int selectedOption)
        {
            switch (selectedOption)
            {
                case 0:
                    _temperatureConverter = new CelsiusToFahrenheitConverter();
                    ConvertAndDisplayResult();
                    break;
                case 1:
                    _temperatureConverter = new FahrenheitToCelsiusConverter();
                    ConvertAndDisplayResult();
                    break;
                case 2:
                    HandleExitOption();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.");
                    Message.PressAnyKeyToContinue();
                    break;
            }
        }

        private void ConvertAndDisplayResult()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                string typeName = Regex.Replace(_temperatureConverter.GetType().Name, "Converter$", "");
                Console.Write($"\nDigite a temperatura para converter ({typeName}): ");

                double temperature = Convert.ToDouble(Console.ReadLine());
                double result = _temperatureConverter.Convert(temperature);

                string displayType = _temperatureConverter is CelsiusToFahrenheitConverter ? "Fahrenheit" : "Celsius";

                Console.WriteLine($"\nA temperatura convertida é: {result:F1} Grau {displayType}");

                Message.PressAnyKeyToContinue();
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um valor numérico.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private void HandleExitOption()
        {
            string environmentExit = Title.InnerProgramExit();
            Message.WriteTitle(environmentExit);
        }

        public int GetMainMenuLength()
        {
            return _mainMenuOptions.Length;
        }

        public string GetTitle()
        {
            return MenuTitle;
        }

        public string GetTitleColor()
        {
            return TitleColor;
        }
    }
}

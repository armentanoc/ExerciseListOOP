using ExerciseListOOP.ConsoleInteraction;
using ExerciseListOOP.ConsoleInteraction.Components;

namespace ExerciseListOOP.Domain.Service
{
    internal class CurrencyConverter : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.CurrencyConverter();
        private readonly string TitleColor = "Green";
        private readonly string[] _mainMenuOptions = { "Converter Real para Dólar", "Converter Dólar para Real", "Sair" };

        private readonly ExchangeRateApiClient _exchangeRateApiClient;

        public CurrencyConverter()
        {
            _mainMenu = new Menu(_mainMenuOptions);
            _exchangeRateApiClient = new ExchangeRateApiClient();
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
                    ConvertCurrency(true); 
                    break;
                case 1:
                    ConvertCurrency(false);
                    break;
                case 2:
                    HandleExitOption();
                    break;
                default:
                    Message.Error("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                    Message.PressAnyKeyToContinue();
                    break;
            }
        }

        private void ConvertCurrency(bool reverseConversion)
        {
            string fromCurrency = reverseConversion ? "BRL" : "USD";
            string toCurrency = reverseConversion ? "USD" : "BRL";

            try
            {
                double exchangeRate = _exchangeRateApiClient.GetExchangeRate().Result;

                if (exchangeRate > 0)
                {
                    Console.Write($"\nDigite o valor a ser convertido ({fromCurrency}): ");
                    double.TryParse(Console.ReadLine(), out double amountToConvert);

                    double convertedAmount = reverseConversion ? amountToConvert / exchangeRate : amountToConvert * exchangeRate;

                    Message.LogAndConsoleWrite($"Resultado da conversão de {amountToConvert}{fromCurrency} para {toCurrency}: \n{convertedAmount:F2} {toCurrency}");
                }
                else
                {
                    Message.Error("Não foi possível obter a taxa de câmbio. Verifique sua conexão com a internet e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Message.Error($"Erro durante a conversão de moeda: {ex.Message}");
            }

            Message.PressAnyKeyToContinue();
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

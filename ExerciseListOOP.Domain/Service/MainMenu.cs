using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using ExerciseListOOP.Domain.Model.TemperatureConverter;

namespace ExerciseListOOP.Domain.Service
{
    internal class MainMenu
    {
        private readonly Menu _mainMenu;

        string[] mainMenuOptions =
        {
            "Conversor de Temperatura",
            "Número Primo",
            "Fatorial",
            "Ordenando Array",
            "Palíndromo",
            "Raiz Quadrada",
            "Conversor de Moeda",
            "Validador de Senha",
            "Validador de CPF",
            "Frequência de Palavras",
            "Sair"
        };

        public MainMenu()
        {
            _mainMenu = new Menu(mainMenuOptions);
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
                    DisplayOption(new TemperatureConverter());
                    break;
                case 1:
                    DisplayOption(new PrimeNumberChecker());
                    break;
                case 2:
                    DisplayOption(new FactorialCalculator());
                    break;
                case 3:
                    DisplayOption(new NumberSorter());
                    break;
                case 4:
                    DisplayOption(new PalindromeChecker());
                    break;
                case 5:
                    DisplayOption(new SquareRootCalculator());
                    break;
                case 6:
                    DisplayOption(new CurrencyConverter());
                    break;
                case 7:
                    DisplayOption(new PasswordValidator());
                    break;
                case 8:
                    DisplayOption(new CpfValidator());
                    break;
                case 9:
                    DisplayOption(new WordFrequencyAnalyzer());
                    break;
                case 10:
                    HandleExitOption();
                    break;
                default:
                    Message.Error("Opção inválida selecionada.");
                    break;
            }
        }

        private void DisplayOption(object menuInstance)
        {
            if (menuInstance is IMenuConvertible)
            {
                IMenuConvertible menu = (IMenuConvertible)menuInstance;

                int userSelection;
                do
                {
                    userSelection = menu.Display(menu.GetTitle(), menu.GetTitleColor());
                    menu.Analyze(userSelection);
                } while (userSelection != menu.GetMainMenuLength() - 1);

                Message.PressAnyKeyToContinue();
            }
            else
            {
                Message.Error($"A instância de menu {menuInstance} não implementa a interface IMenuConvertible.");
            }
        }

        private void ChoosenOption(int selectedOption)
        {
            string notImplementedTitle = Title.NotYetImplemented();
            Message.WriteTitle(notImplementedTitle, "Yellow");
            Console.WriteLine($"Escolheu uma opção ainda não implementada: {mainMenuOptions[selectedOption]}");
        }

        private void HandleExitOption()
        {
            string environmentExit = Title.EnvironmentExit();
            Message.WriteTitle(environmentExit);
            Environment.Exit(0);
        }
    }
}

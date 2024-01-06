using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using ExerciseListOOP.Domain.TemperatureConverter;

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
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 2:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 3:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 4:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 5:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 6:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 7:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 8:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 9:
                    ChoosenOption(selectedOption);
                    Message.PressAnyKeyToContinue();
                    break;
                case 10:
                    string environmentExit = Title.EnvironmentExit();
                    Message.WriteTitle(environmentExit);
                    Environment.Exit(0);
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

using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using System;

namespace ExerciseListOOP.Domain.Service
{
    internal class NumberSorter : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.NumberSorter();
        private readonly string TitleColor = "Cyan";
        private readonly string[] _mainMenuOptions =
        {
            "Ordenar números em ordem crescente", "Sair"
        };

        public NumberSorter()
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
                    SortNumbers();
                    break;
                case 1:
                    HandleExitOption();
                    break;
                default:
                    Message.Error("Opção inválida. Por favor, escolha 1 ou 2.");
                    Message.PressAnyKeyToContinue();
                    break;
            }
        }

        private void SortNumbers()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite os números separados por espaços (ex: 3.1 1.5 5.2): ");

                string[] inputNumbers = Console.ReadLine().Split(' ');
                double[] numbers = new double[inputNumbers.Length];

                for (int i = 0; i < inputNumbers.Length; i++)
                {
                    numbers[i] = Convert.ToDouble(inputNumbers[i]);
                }

                Array.Sort(numbers);

                Message.LogAndConsoleWrite("Números ordenados em ordem crescente:");
                foreach (double number in numbers)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
                Message.PressAnyKeyToContinue();
            }
            catch (FormatException)
            {
                Message.Error("Entrada inválida. Certifique-se de digitar números separados por espaços.");
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
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

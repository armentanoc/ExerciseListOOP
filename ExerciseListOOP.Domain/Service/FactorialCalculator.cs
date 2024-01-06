using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using System;

namespace ExerciseListOOP.Domain.Service
{
    internal class FactorialCalculator : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.FactorialChecker();
        private readonly string TitleColor = "Green";
        private readonly string[] _mainMenuOptions =
        {
            "Verificar o fatorial de um número", "Sair"
        };

        public FactorialCalculator()
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
                    CheckFactorial();
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

        private void CheckFactorial()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite um número para verificar seu fatorial: ");

                int number = Convert.ToInt32(Console.ReadLine());

                long factorial = CalculateFactorial(number);

                Message.LogAndConsoleWrite($"O fatorial de {number} é: {factorial}");
                Message.PressAnyKeyToContinue();
            }
            catch (FormatException)
            {
                Message.Error("Entrada inválida. Por favor, insira um valor numérico inteiro.");
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }

        private long CalculateFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Número deve ser não-negativo para calcular o fatorial.");

            if (number == 0 || number == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
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

using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using System;

namespace ExerciseListOOP.Domain.Service
{
    internal class SquareRootCalculator : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.SquareRootCalculator();
        private readonly string TitleColor = "Yellow";
        private readonly string[] _mainMenuOptions =
        {
            "Calcular a raiz quadrada de um número", "Sair"
        };

        public SquareRootCalculator()
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
                    CalculateSquareRoot();
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

        private void CalculateSquareRoot()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite um número para calcular sua raiz quadrada: ");

                double number = Convert.ToDouble(Console.ReadLine());

                if (number < 0)
                {
                    Message.LogAndConsoleWrite("Não é possível calcular a raiz quadrada de um número negativo.");
                    Message.PressAnyKeyToContinue();
                    return;
                }

                double squareRoot = CalculateSquareRootNewtonRaphson(number);

                Message.LogAndConsoleWrite($"A raiz quadrada de {number} é: {squareRoot:F4}");
                Message.PressAnyKeyToContinue();
            }
            catch (FormatException)
            {
                Message.Error("Entrada inválida. Por favor, insira um valor numérico.");
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }

        private double CalculateSquareRootNewtonRaphson(double number)
        {
            double guess = number / 2.0;
            double epsilon = 1e-15; // Valor pequeno para precisão

            while (Math.Abs(guess * guess - number) > epsilon)
            {
                guess = (guess + number / guess) / 2.0;
            }

            return guess;
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

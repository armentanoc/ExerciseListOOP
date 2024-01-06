using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;

namespace ExerciseListOOP.Domain.Service
{
    internal class PrimeNumberChecker : IMenuConvertible
    {

        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.PrimeNumberChecker();
        private readonly string TitleColor = "Blue";
        private readonly string[] _mainMenuOptions =
        {
            "Verificar se um número é primo", "Sair"
        };
        public PrimeNumberChecker()
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
                    CheckIfPrime();
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

        private void CheckIfPrime()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite um número para verificar se é primo: ");

                int number = Convert.ToInt32(Console.ReadLine());

                bool isPrime = IsPrime(number);

                Message.LogAndConsoleWrite($"O número {number} {(isPrime ? "é" : "não é")} primo.");
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

        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
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

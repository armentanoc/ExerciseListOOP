using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;

namespace ExerciseListOOP.Domain.Service
{
    internal class PalindromeChecker : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.PalindromeChecker();
        private readonly string TitleColor = "Green";
        private readonly string[] _mainMenuOptions =
        {
            "Verificar se uma palavra é um palíndromo", "Sair"
        };

        public PalindromeChecker()
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
                    CheckIfPalindrome();
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

        private void CheckIfPalindrome()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite uma palavra para verificar se é um palíndromo: ");

                string input = Console.ReadLine().ToLower(); // Convert to lowercase for case-insensitive comparison

                bool isPalindrome = IsPalindrome(input);

                Message.LogAndConsoleWrite($"A palavra '{input}' {(isPalindrome ? "é" : "não é")} um palíndromo.");
                Message.PressAnyKeyToContinue();
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }

        private bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
                {
                    return false;
                }

                left++;
                right--;
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

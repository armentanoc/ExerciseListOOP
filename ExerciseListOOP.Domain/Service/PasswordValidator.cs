using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;

namespace ExerciseListOOP.Domain.Service
{
    internal class PasswordValidator : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.PasswordValidator();
        private readonly string TitleColor = "Green";
        private readonly string[] _mainMenuOptions =
        {
            "Validar senha", "Sair"
        };

        public PasswordValidator()
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
                    ValidatePassword();
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

        private void ValidatePassword()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite a senha a ser validada: ");

                string password = Console.ReadLine();

                if (IsPasswordValid(password))
                {
                    Message.LogAndConsoleWrite("Senha válida!");
                }
                else
                {
                    Message.LogAndConsoleWrite("Senha inválida. Certifique-se de que ela tenha no mínimo 8 caracteres, pelo menos uma letra maiúscula, uma letra minúscula e um número.");
                }

                Message.PressAnyKeyToContinue();
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }

        private bool IsPasswordValid(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
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

using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using System;
using System.Linq;

namespace ExerciseListOOP.Domain.Service
{
    internal class CpfValidator : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.CpfValidator();
        private readonly string TitleColor = "Yellow";
        private readonly string[] _mainMenuOptions = { "Validar CPF", "Sair" };

        public CpfValidator()
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
                    ValidateCpf();
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

        private void ValidateCpf()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite o CPF a ser validado (apenas números): ");

                string cpf = Console.ReadLine();

                bool isValid = IsCpfValid(cpf);

                Message.LogAndConsoleWrite(isValid ? "CPF válido!" : "CPF inválido. Certifique-se de que ele esteja no formato correto e passe no critério de validação do dígito verificador.");
                Message.PressAnyKeyToContinue();
            }
            catch (FormatException)
            {
                Message.Error("Entrada inválida. Certifique-se de inserir apenas números.");
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }
        private bool IsCpfValid(string cpf)
        {
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            int digit1 = (remainder < 2) ? 0 : (11 - remainder);
            tempCpf += digit1;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            int digit2 = (remainder < 2) ? 0 : (11 - remainder);

            return cpf.EndsWith(digit1.ToString() + digit2);
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

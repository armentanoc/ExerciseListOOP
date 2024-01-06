using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.ConsoleInteraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseListOOP.Domain.Service
{
    internal class WordFrequencyAnalyzer : IMenuConvertible
    {
        private readonly Menu _mainMenu;
        private readonly string MenuTitle = Title.WordFrequencyAnalyzer();
        private readonly string TitleColor = "Green";
        private readonly string[] _mainMenuOptions = { "Analisar Texto", "Sair" };

        public WordFrequencyAnalyzer()
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
                    AnalyzeText();
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

        private void AnalyzeText()
        {
            try
            {
                Message.WriteTitle(MenuTitle, TitleColor);
                Message.LogAndConsoleWrite("\nDigite o texto para análise de frequência de palavras: ");

                string inputText = Console.ReadLine();
                Dictionary<string, int> wordFrequency = CountWordFrequency(inputText);

                Message.LogAndConsoleWrite("Frequência de palavras no texto:");

                foreach (var entry in wordFrequency)
                {
                    Message.LogAndConsoleWrite($"{entry.Key}: {entry.Value}");
                }

                Message.PressAnyKeyToContinue();
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }

        private Dictionary<string, int> CountWordFrequency(string text)
        {
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            return wordFrequency;
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

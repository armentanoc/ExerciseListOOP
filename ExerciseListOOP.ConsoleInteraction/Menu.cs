using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseListOOP.ConsoleInteraction
{
    internal class Menu
    {
        public string[] Items { get; private set; }
        private int selectedIndex;

        public Menu(string[] menuItems)
        {
            Items = menuItems;
            selectedIndex = 0;
        }

        public int DisplayMenu(string? title = null)
        {
            ConsoleKeyInfo key;
            Console.CursorVisible = false;

            try
            {
                do
                {
                    Console.Clear();
                    RenderMenu(title);

                    key = Console.ReadKey(true);

                    HandleKeyPress(key);

                } while (key.Key != ConsoleKey.Enter);
            }
            finally
            {
                Console.Clear();
            }

            return selectedIndex;
        }

        private void RenderMenu(string? title = null)
        {
            if (title != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(title);
                Console.ResetColor();
            }

            Console.WriteLine("\nSelecione uma opção: \n");

            for (int i = 0; i < Items.Length; i++)
            {
                Console.ForegroundColor = (i == selectedIndex) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.BackgroundColor = (i == selectedIndex) ? ConsoleColor.Gray : ConsoleColor.Black;
                Console.WriteLine($"{Items[i]}");
                Console.ResetColor();
            }

            Console.WriteLine("\nAperte enter para confirmar.");
        }

        private void HandleKeyPress(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(Items.Length - 1, selectedIndex + 1);
                    break;
            }
        }

        public static void PressAnyKeyToReturn()
        {
            Console.WriteLine("\nPressione qualquer tecla para retornar.");
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
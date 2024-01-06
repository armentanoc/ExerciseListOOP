
using ExerciseListOOP.ConsoleInteraction.Components;
using ExerciseListOOP.Domain.Service;

namespace ExerciseListOOP.Domain
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu menuService = new MainMenu();
            string title = Title.POOList();
            string titleColor = "Cyan";

            try
            {
                while (true)
                {
                    int userSelection = menuService.Display(title, titleColor);
                    menuService.Analyze(userSelection);
                }
            }
            catch (Exception ex)
            {
                Message.CatchException(ex);
            }
        }
    }
}

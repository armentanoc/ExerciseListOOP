namespace ExerciseListOOP.Domain.Service
{
    public interface IMenuConvertible
    {
        string GetTitle();
        string GetTitleColor();
        int GetMainMenuLength();
        int Display(string title, string color);
        void Analyze(int selectedOption);
    }

}

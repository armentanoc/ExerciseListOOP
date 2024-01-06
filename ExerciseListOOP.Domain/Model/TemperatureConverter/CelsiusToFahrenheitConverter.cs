namespace ExerciseListOOP.Domain.Model.TemperatureConverter
{
    public class CelsiusToFahrenheitConverter : ITemperatureConverter
    {
        public double Convert(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
    }
}

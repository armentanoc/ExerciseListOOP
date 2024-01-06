﻿
namespace ExerciseListOOP.Domain.TemperatureConverter
{
    public class FahrenheitToCelsiusConverter : ITemperatureConverter
    {
        public double Convert(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}

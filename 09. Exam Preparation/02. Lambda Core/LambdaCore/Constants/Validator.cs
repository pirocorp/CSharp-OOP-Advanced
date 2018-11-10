namespace LambdaCore.Constants
{
    using System;

    public static class Validator
    {
        public static void ValidateNonNegativeInt(int value, string nameOfProperty)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameOfProperty, $"{nameOfProperty} must be non negative.");
            }
        }
    }
}
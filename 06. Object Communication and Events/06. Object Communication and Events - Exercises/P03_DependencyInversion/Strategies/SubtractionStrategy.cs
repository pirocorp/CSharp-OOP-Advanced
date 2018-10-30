namespace P03_DependencyInversion.Strategies
{
    using Interfaces;

    public class SubtractionStrategy : IStra
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}

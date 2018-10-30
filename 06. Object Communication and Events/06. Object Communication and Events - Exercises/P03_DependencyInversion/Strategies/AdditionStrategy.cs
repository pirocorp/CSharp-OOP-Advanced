namespace P03_DependencyInversion.Strategies
{
    using Interfaces;

    public class AdditionStrategy : IStra
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}

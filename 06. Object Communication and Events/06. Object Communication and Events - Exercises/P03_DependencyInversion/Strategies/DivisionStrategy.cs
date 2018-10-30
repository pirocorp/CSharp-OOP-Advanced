namespace P03_DependencyInversion.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class DivisionStrategy : IStra
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
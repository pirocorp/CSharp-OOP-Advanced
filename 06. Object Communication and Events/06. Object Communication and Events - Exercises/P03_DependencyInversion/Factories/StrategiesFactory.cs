namespace P03_DependencyInversion.Factories
{
    using Interfaces;
    using Strategies;

    public class StrategiesFactory : IStrategiesFactory
    {
        public StrategiesFactory()
        {
            
        }

        public IStra CreateStrategy(char operatorType)
        {
            IStra strategy = null;

            switch (operatorType)
            {
                case '+':
                    strategy = new AdditionStrategy();
                    break;
                case '-':
                    strategy = new SubtractionStrategy();
                    break;
                case '*':
                    strategy = new MultiplicationStrategy();
                    break;
                case '/':
                    strategy = new DivisionStrategy();
                    break;
            }

            return strategy;
        }
    }
}
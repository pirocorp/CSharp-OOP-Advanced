namespace P03_DependencyInversion
{
    using Factories;
    using Interfaces;
    using Strategies;

    public class PrimitiveCalculator
    {
        private readonly IStrategiesFactory strategiesFactory;
        private IStra strategy;

        public PrimitiveCalculator()
            :this(new StrategiesFactory())
        {

        }

        public PrimitiveCalculator(IStrategiesFactory strategiesFactory)
        {
            this.strategiesFactory = strategiesFactory;
            this.strategy = new AdditionStrategy();
        }

        public void changeStrategy(char op)
        {
            this.strategy = this.strategiesFactory.CreateStrategy(op);
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}

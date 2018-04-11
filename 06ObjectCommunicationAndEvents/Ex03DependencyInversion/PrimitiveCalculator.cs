using Ex03DependencyInversion.Contracts;
using Ex03DependencyInversion.Strategies;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private bool isAddition;
        private IStrategy strategy = new AdditionStrategy();

        public PrimitiveCalculator()
        {
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.strategy = new AdditionStrategy();
                    break;
                case '-':
                    this.strategy = new SubtractionStrategy();
                    break;
                case '/':
                    this.strategy = new DivisionStrategy();
                    break;
                case '*':
                    this.strategy = new MultiplicationStrategy();
                    break;
            }

        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            
                return this.strategy.Calculate(firstOperand, secondOperand);
            
            
            
        }
    }
}

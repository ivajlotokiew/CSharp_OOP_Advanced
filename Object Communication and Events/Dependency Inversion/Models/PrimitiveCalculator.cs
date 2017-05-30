namespace _03DependencyInversion.Models
{
    public class PrimitiveCalculator
    {
        private bool isAddition;
        private bool isSubtraction;
        private bool isDividing;
        private bool isMultiply;
        private readonly AdditionStrategy additionStrategy;
        private readonly SubtractionStrategy subtractionStrategy;
        private readonly DividingStrategy dividingStrategy;
        private readonly MultiplyingStrategy multiplyingStrategy;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.dividingStrategy = new DividingStrategy();
            this.multiplyingStrategy = new MultiplyingStrategy();
            this.isAddition = true;
            this.isDividing = false;
            this.isSubtraction = false;
            this.isMultiply = false;
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.isAddition = true;
                    this.isDividing = false;
                    this.isSubtraction = false;
                    this.isMultiply = false;
                    break;
                case '-':
                    this.isAddition = false;
                    this.isDividing = false;
                    this.isSubtraction = true;
                    this.isMultiply = false;
                    break;

                case '/':
                    this.isAddition = false;
                    this.isDividing = true;
                    this.isSubtraction = false;
                    this.isMultiply = false;
                    break;
                case '*':
                    this.isAddition = false;
                    this.isDividing = false;
                    this.isSubtraction = false;
                    this.isMultiply = true;
                    break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            if (this.isAddition)
            {
                return this.additionStrategy.Calculate(firstOperand, secondOperand);
            }
            else if (this.isSubtraction)
            {
                return this.subtractionStrategy.Calculate(firstOperand, secondOperand);
            }
            else if (this.isDividing)
            {
                return this.dividingStrategy.Calculate(firstOperand, secondOperand);
            }
            else
            {
                return this.multiplyingStrategy.Calculate(firstOperand, secondOperand);
            }
        }
    }
}

namespace _03DependencyInversion.Models
{
    public class SubtractionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}

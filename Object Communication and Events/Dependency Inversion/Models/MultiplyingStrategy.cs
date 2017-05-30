namespace _03DependencyInversion.Models
{
    public class MultiplyingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
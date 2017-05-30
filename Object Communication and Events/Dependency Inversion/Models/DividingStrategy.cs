namespace _03DependencyInversion.Models
{
    public class DividingStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
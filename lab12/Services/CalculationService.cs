using lab12.Models;

namespace lab12.Services
{
    public interface CalculationService
    {
        public string Calculation(int a, int b, string operation);

        public string Calculation(CalculationExpressionModel calculationExpression);

        public string Add(int a, int b);

        public string Divide(int a, int b);

        public string Multiply(int a, int b);

        public string Subtract(int a, int b);
    }
}

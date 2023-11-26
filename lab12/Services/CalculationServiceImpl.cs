using lab12.Models;

namespace lab12.Services
{
    public class CalculationServiceImpl : CalculationService
    {
        public string Calculation(int a, int b, string operation)
        {
            switch(operation)
            {
                case "+":
                    return Add(a, b);
                case "-":
                    return Subtract(a, b);
                case "*":  
                    return Multiply(a, b);
                case "/":   
                    return Divide(a, b);
                default:
                    return "error";
            }
        }
        public string Calculation(CalculationExpressionModel calculationExpression)
        {
            return Calculation(calculationExpression.firstNumber, calculationExpression.secondNumber, calculationExpression.operation);
        }

        public string Add(int a, int b)
        {
            return (a + b).ToString();
        }

        public string Divide(int a,int b)
        {
            return (b == 0) ? "error" : (a / b).ToString();
        }

        public string Multiply(int a, int b)
        {
            return (a * b).ToString();
        }

        public string Subtract(int a, int b)
        {
            return (a - b).ToString();
        }
    }
}

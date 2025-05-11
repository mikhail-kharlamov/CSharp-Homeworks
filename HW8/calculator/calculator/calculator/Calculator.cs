namespace Calculator;

public class Calculator
{
    public string DisplayValue;
    
    private double? number = null;
    
    private char? operation = null;

    private string buffer = string.Empty;

    public void AddDigit(char digit)
    {
        this.buffer += digit.ToString();
    }

    public void AddOperator(char operation)
    {
        if (this.operation is null)
        {
            this.number = double.Parse(this.buffer);
        }
        else
        {
            var newNumber = double.Parse(this.buffer);
            switch (this.operation)
            {
                case '+':
                    this.number += newNumber;
                    break;
                case '-':
                    this.number -= newNumber;
                    break;
                case '*':
                    this.number *= newNumber;
                    break;
                case '/':
                    this.number /= newNumber;
                    break;
            }
        }
        this.buffer = string.Empty;
        this.operation = operation;
    }
}
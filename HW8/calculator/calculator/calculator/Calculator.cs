namespace Calculator;

public class CalculatorLogic
{
    private string displayValue = "";

    private double number = 0;

    private char? operation = null;

    private string buffer = "";

    public string GetDisplay() => string.IsNullOrEmpty(this.displayValue) ? "0" : this.displayValue;

    public void AddDigit(char digit)
    {
        this.buffer += digit.ToString();
        this.displayValue = this.buffer;
    }

    public void SetOperator(char operation)
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

        this.displayValue = this.number.ToString();
        this.buffer = "";
        this.operation = operation;
    }

    public void Clear()
    {
        this.displayValue = "";
        this.number = 0;
        this.operation = null;
        this.buffer = "";
    }

    public void SetServiceOperator(char @operator)
    {
        switch (@operator)
        {
            case '.':
                if (!this.buffer[^1].Equals('.'))
                {
                    this.buffer += @operator;
                }
                break;
        }
    }
}
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
        if (this.displayValue != "0")
        {
            this.buffer += digit.ToString();
        }
        else
        {
            this.buffer = digit.ToString();
        }
        this.displayValue = this.buffer;
    }

    public void SetOperator(char operation)
    {
        if (!string.IsNullOrEmpty(this.buffer))
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
        }

        this.displayValue = this.number.ToString();
        this.buffer = "";
        if (operation != '=')
        {
            this.operation = operation;
        }
        else
        {
            this.operation = null;
        }
    }

    public void Clear()
    {
        this.displayValue = "";
        this.number = 0;
        this.operation = null;
        this.buffer = "";
    }

    public void SetServiceOperator(string @operator)
    {
        switch (@operator)
        {
            case ",":
                if (!this.buffer.Contains(','))
                {
                    this.buffer += ",";
                }
                break;
            case "+/-":
                if (!this.buffer[0].Equals('-'))
                {
                    this.buffer = "-" + this.buffer;
                }
                else
                {
                    this.buffer = this.buffer.Substring(1);
                }
                break;
        }
        
        this.displayValue = this.buffer;
    }
}
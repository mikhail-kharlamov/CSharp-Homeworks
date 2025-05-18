namespace Calculator;

public class CalculatorLogic
{
    private string displayValue = "0";

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
        this.displayValue = "0";
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
                if (!this.buffer.Contains('-'))
                {
                    this.buffer = "-" + this.buffer;
                }
                else
                {
                    this.buffer = this.buffer.Substring(1);
                }
                break;
            case "%":
                this.SetOperator('/');
                foreach (var digit in "100")
                {
                    this.AddDigit(digit);
                }
                this.SetOperator('=');
                return;
        }

        if (this.buffer == ",")
        {
            this.displayValue += this.buffer;
            this.buffer = this.displayValue;
        }
        else if (this.buffer == "-")
        {
            this.buffer += this.displayValue;
            this.displayValue = this.buffer;
        }
        else
        {
            this.displayValue = this.buffer;
        }
    }
}
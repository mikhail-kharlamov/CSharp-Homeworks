namespace calculator;

public class CalculatorEngine
{
    public string? DisplayValue => currentValue.ToString();

    private string inputBuffer  = string.Empty;
    
    private double? currentValue;

    private char? currentOperator;

    private bool isNewEntry;
    
    public void EnterDigit(char digit)
    {
        if (isNewEntry)
        {
            this.inputBuffer = digit.ToString();
            this.currentValue = double.Parse(this.inputBuffer);
            this.isNewEntry = false;
        }
        else
        {
            this.inputBuffer += digit;
            this.currentValue = double.Parse(this.inputBuffer);
        }
    }

    public void EnterOperator(char op)
    {
        if (this.currentOperator is null)
        {
            if (string.IsNullOrEmpty(this.inputBuffer) && this.currentValue is null)
            {
                throw new ArgumentException("Invalid operator"); //TODO make normal exception
            }
            this.currentOperator = op;
            this.isNewEntry = true;
            this.currentValue = double.Parse(this.inputBuffer);
            this.inputBuffer = string.Empty;
        }
        else
        {
            if (string.IsNullOrEmpty(this.inputBuffer) || this.currentValue is null)
            {
                throw new ArgumentException("Invalid operator"); //TODO make normal exception
            }

            switch (this.currentOperator)
            {
                case '+':
                    this.currentValue += double.Parse(this.inputBuffer);
                    break;
                case '-':
                    this.currentValue -= double.Parse(this.inputBuffer);
                    break;
                case '*':
                    this.currentValue *= double.Parse(this.inputBuffer);
                    break;
                case '/':
                    this.currentValue /= double.Parse(this.inputBuffer); //TODO make exception for 0 dividing
                    break;
            }
            
            this.inputBuffer = string.Empty;

            if ("+-*/".Contains(op))
            {
                this.currentOperator = op;
            }
            else if (op == '=')
            {
                this.currentOperator = null;
            }
            else
            {
                throw new ArgumentException("Invalid operator");
            }
        }
        
        this.isNewEntry = true;
        this.currentOperator = op;
        
        this.inputBuffer = string.Empty;
    }
    
    public void Clear()
    {}
}
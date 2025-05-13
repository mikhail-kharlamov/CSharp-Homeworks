namespace Calculator;

public class CalculatorLogic
{
    private double? _firstNumber;
    private string? _operator;
    private string _currentInput = "";

    public void AddDigit(string digit)
    {
        _currentInput += digit;
    }

    public void SetOperator(string op)
    {
        if (double.TryParse(_currentInput, out var num))
        {
            _firstNumber = num;
            _operator = op;
            _currentInput = "";
        }
    }

    public void Calculate()
    {
        if (_firstNumber.HasValue && double.TryParse(_currentInput, out var second))
        {
            double result = _operator switch
            {
                "+" => _firstNumber.Value + second,
                "-" => _firstNumber.Value - second,
                "*" => _firstNumber.Value * second,
                "/" => second != 0 ? _firstNumber.Value / second : 0,
                _ => 0
            };

            _currentInput = result.ToString();
            _firstNumber = null;
            _operator = null;
        }
    }

    public void Clear()
    {
        _firstNumber = null;
        _operator = null;
        _currentInput = "";
    }

    public string GetDisplay() => string.IsNullOrEmpty(_currentInput) ? "0" : _currentInput;
}
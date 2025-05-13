using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly CalculatorLogic _calculator = new();

    private string _display = "0";
    public string Display
    {
        get => _display;
        set
        {
            if (_display != value)
            {
                _display = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand DigitCommand { get; }
    public ICommand OperatorCommand { get; }
    public ICommand EqualCommand { get; }
    public ICommand ClearCommand { get; }

    public MainWindowViewModel()
    {
        DigitCommand = new RelayCommand(param =>
        {
            _calculator.AddDigit(param.ToString());
            Display = _calculator.GetDisplay();
        });

        OperatorCommand = new RelayCommand(param =>
        {
            _calculator.SetOperator(param.ToString());
            Display = _calculator.GetDisplay();
        });

        EqualCommand = new RelayCommand(_ =>
        {
            _calculator.Calculate();
            Display = _calculator.GetDisplay();
        });

        ClearCommand = new RelayCommand(_ =>
        {
            _calculator.Clear();
            Display = _calculator.GetDisplay();
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
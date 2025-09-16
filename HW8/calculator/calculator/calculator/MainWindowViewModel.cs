namespace Calculator;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly CalculatorLogic calculator = new();

    private string display = "0";
    public string Display
    {
        get => this.display;
        set
        {
            if (this.display != value)
            {
                this.display = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand DigitCommand { get; }
    public ICommand OperatorCommand { get; }
    public ICommand ClearCommand { get; }
    
    public ICommand ServiceCommand { get; }

    public MainWindowViewModel()
    {
        DigitCommand = new RelayCommand(param =>
        {
            this.calculator.AddDigit(param.ToString()[0]);
            this.Display = calculator.GetDisplay();
        });

        OperatorCommand = new RelayCommand(param =>
        {
            this.calculator.SetOperator(param.ToString()[0]);
            this.Display = calculator.GetDisplay();
        });

        ClearCommand = new RelayCommand(_ =>
        {
            this.calculator.Clear();
            this.Display = calculator.GetDisplay();
        });

        ServiceCommand = new RelayCommand(param =>
        {
            this.calculator.SetServiceOperator(param.ToString());
            this.Display = calculator.GetDisplay();
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
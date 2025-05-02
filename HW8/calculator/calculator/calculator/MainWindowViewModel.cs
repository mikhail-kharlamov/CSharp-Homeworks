using System.ComponentModel;
using System.Windows.Input;

namespace calculator;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly CalculatorEngine engine = new();

    public MainWindowViewModel()
    {
        DigitCommand = new RelayCommand(param => EnterDigit(param?.ToString()));
    }
    
    public ICommand DigitCommand { get; }
    
    public string Display => engine.DisplayValue;
    
    private void EnterDigit(string? digit)
    {
        if (string.IsNullOrEmpty(digit))
        {
            throw new ArgumentNullException(nameof(digit));
        }
        
        engine.EnterDigit(char.Parse(digit));
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged(string propertyName) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
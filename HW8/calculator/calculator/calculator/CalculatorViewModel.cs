namespace Calculator;

using ReactiveUI;
using System.Reactive;

public class CalculatorViewModel : ReactiveObject
{
    private string _display = "0";
    public string Display
    {
        get => _display;
        set => this.RaiseAndSetIfChanged(ref _display, value);
    }

    public ReactiveCommand<string, Unit> DigitCommand { get; }
    public ReactiveCommand<string, Unit> OperatorCommand { get; }
    public ReactiveCommand<string, Unit> ClearCommand { get; }
    public ReactiveCommand<string, Unit> ServiceCommand { get; }

    public CalculatorViewModel()
    {
        DigitCommand = ReactiveCommand.Create<string>(content => 
        {
            Display = (Display == "0") ? content : Display + content;
        });

        OperatorCommand = ReactiveCommand.Create<string>(content => 
        {
            Display += $" {content} ";
        });
        
        ClearCommand = ReactiveCommand.Create<string>(content => 
        {
            Display = (Display == "0") ? content : Display + content;
        });

        ServiceCommand = ReactiveCommand.Create<string>(content => 
        {
            Display += $" {content} ";
        });
    }
}
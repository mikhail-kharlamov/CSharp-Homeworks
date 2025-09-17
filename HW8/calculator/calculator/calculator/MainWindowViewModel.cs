// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace Calculator;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

/// <summary>
/// ViewModel class for the calculator's main window, implementing INotifyPropertyChanged
/// to support data binding and command handling.
/// </summary>
public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly CalculatorLogic calculator = new();

    private string display = "0";
    
    /// <summary>
    /// Gets or sets the current display value of the calculator.
    /// </summary>
    /// <value>
    /// The string representation of the current calculator display.
    /// </value>
    /// <remarks>
    /// Implements property change notification for data binding.
    /// </remarks>
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

    /// <summary>
    /// Command for handling digit button presses (0-9).
    /// </summary>
    public ICommand DigitCommand { get; }
    
    /// <summary>
    /// Command for handling arithmetic operator button presses (+, -, *, /, =).
    /// </summary>
    public ICommand OperatorCommand { get; }
    
    /// <summary>
    /// Command for handling the clear (C) button press.
    /// </summary>
    public ICommand ClearCommand { get; }
    
    /// <summary>
    /// Command for handling special service operations (decimal point, sign change, percentage).
    /// </summary>
    public ICommand ServiceCommand { get; }

    /// <summary>
    /// Initializes a new instance of the MainWindowViewModel class.
    /// </summary>
    /// <remarks>
    /// Sets up all command handlers and initializes calculator state.
    /// </remarks>
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

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    
    /// <summary>
    /// Raises the PropertyChanged event.
    /// </summary>
    /// <param name="name">The name of the property that changed.</param>
    /// <remarks>
    /// Uses CallerMemberName attribute to automatically get property name if not specified.
    /// </remarks>
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
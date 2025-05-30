// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace Calculator;

using System.Windows.Input;

/// <summary>
/// Implementation of <see cref="ICommand"/> that delegates execution to specified actions.
/// </summary>
/// <remarks>
/// This command implementation is commonly used in MVVM (Model-View-ViewModel) patterns
/// to bind UI actions to ViewModel methods while maintaining separation of concerns.
/// </remarks>
public class RelayCommand : ICommand
{
    private readonly Action<object?> execute;
    private readonly Func<object?, bool>? canExecute;

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class.
    /// </summary>
    /// <param name="execute">The action to execute when the command is invoked.</param>
    /// <param name="canExecute">Optional predicate to determine if the command can execute.</param>
    /// <exception cref="ArgumentNullException">Thrown when the execute action is null.</exception>
    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. Can be null.</param>
    /// <returns>
    /// true if this command can be executed; otherwise, false.
    /// Returns true if no canExecute predicate was provided to the constructor.
    /// </returns>
    public bool CanExecute(object? parameter) => this.canExecute?.Invoke(parameter) ?? true;

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="parameter">Data used by the command. Can be null.</param>
    public void Execute(object? parameter) => this.execute(parameter);

    /// <summary>
    /// Occurs when changes occur that affect whether the command should execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;
    
    /// <summary>
    /// Raises the <see cref="CanExecuteChanged"/> event to indicate
    /// the command's ability to execute has changed.
    /// </summary>
    /// <remarks>
    /// Call this method when conditions affecting the command's executability change.
    /// </remarks>
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
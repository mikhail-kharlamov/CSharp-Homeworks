// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace Calculator;

/// <summary>
/// Represents the core logic for a calculator with basic arithmetic operations.
/// Maintains calculator state and performs calculations.
/// </summary>
public class CalculatorLogic
{
    private string displayValue = "0";

    private double number = 0;

    private char? operation = null;

    private string buffer = "";

    /// <summary>
    /// Gets the current display value of the calculator.
    /// </summary>
    /// <returns>The string representation of the current display value.</returns>
    /// <remarks>
    /// Returns "0" if the display value is empty.
    /// </remarks>
    public string GetDisplay() => string.IsNullOrEmpty(this.displayValue) ? "0" : this.displayValue;

    /// <summary>
    /// Adds a digit to the current input buffer
    /// </summary>
    /// <param name="digit">The digit character to add (0-9).</param>
    /// <exception cref="ArgumentException">Thrown if the input is not a valid digit.</exception>
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

    /// <summary>
    /// Sets the arithmetic operation to perform.
    /// </summary>
    /// <param name="operation">The operation character (+, -, *, /, =).</param>
    /// <exception cref="ArgumentException">Thrown if the operation is not supported.</exception>
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

    /// <summary>
    /// Resets the calculator to its initial state.
    /// </summary>
    public void Clear()
    {
        this.displayValue = "0";
        this.number = 0;
        this.operation = null;
        this.buffer = "";
    }

    /// <summary>
    /// Performs special calculator operations.
    /// </summary>
    /// <param name="operator">The special operation to perform (",", "+/-", "%").</param>
    /// <exception cref="ArgumentException">Thrown if the operator is not supported.</exception>
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
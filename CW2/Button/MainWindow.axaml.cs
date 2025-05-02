using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;

namespace Button;

/// <summary>
/// Class for handling actions.
/// </summary>>
public partial class MainWindow : Window
{
    
    private double escapeDistance = 50;

    /// <summary>
    /// Constructor.
    /// </summary>>
    public MainWindow()
    {
        InitializeComponent();
        this.SizeChanged += this.WindowSizeChanged;
    }

    /// <summary>
    /// Method for handling actions if cursor near the button.
    /// </summary>>
    /// <param name="sender">The control that raised the event.</param>\
    /// /// <param name="e">Provides data about the pointer movement, including current position.</param>
    private void MovedOnButton(object? sender, PointerEventArgs e)
    {
        var buttonX = Canvas.GetLeft(EscapeButton) + EscapeButton.Bounds.Width / 2;
        var buttonY = Canvas.GetTop(EscapeButton) + EscapeButton.Bounds.Height / 2;
        var mouse = e.GetPosition(MainCanvas);

        var distance = Math.Sqrt(Math.Pow(mouse.X - buttonX, 2) + Math.Pow(mouse.Y - buttonY, 2));
        if (distance < this.escapeDistance)
        {
            this.SetNewPosition(mouse.X, mouse.Y);
        }
    }
    
    /// <summary>
    /// Method for handling actions if the button is pressed.
    /// </summary>>
    /// <param name="sender">The control that that was pressed.</param>\
    /// /// <param name="e">Provides data about the pointer press event.</param>
    private void ButtonPressed(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Method for handling actions if window size is changed.
    /// </summary>>
    /// <param name="sender">The window whose size has changed.</param>\
    /// /// <param name="e">Provides information about the new size of the window.</param>
    private void WindowSizeChanged(object? sender, SizeChangedEventArgs e)
    {
        if (EscapeButton.Bounds.Width + Canvas.GetLeft(EscapeButton) > this.Width)
        {
            Canvas.SetLeft(EscapeButton, this.Width - EscapeButton.Bounds.Width);
        }

        if (EscapeButton.Bounds.Height + Canvas.GetTop(EscapeButton) > this.Height)
        {
            Canvas.SetTop(EscapeButton, this.Height - EscapeButton.Bounds.Height);
        }
    }

    /// <summary>
    /// Method for setting the button position.
    /// </summary>>
    /// <param name="mouseX">The X coordinate of the mouse.</param>\
    /// /// <param name="mouseY">The Y coordinate of the mouse.</param>
    private void SetNewPosition(double mouseX, double mouseY)
    {
        var random = new Random();
        var x = random.NextDouble() * (MainCanvas.Bounds.Width - EscapeButton.Bounds.Width);
        var y = random.NextDouble() * (MainCanvas.Bounds.Height - EscapeButton.Bounds.Height);
        while (mouseX < x + EscapeButton.Bounds.Width / 2 && mouseX
               > x - EscapeButton.Bounds.Width / 2 && mouseY < y + EscapeButton.Bounds.Height / 2
               && mouseY > y + EscapeButton.Bounds.Height / 2)
        {
            x = random.NextDouble() * (MainCanvas.Bounds.Width - EscapeButton.Bounds.Width);
            y = random.NextDouble() * (MainCanvas.Bounds.Height - EscapeButton.Bounds.Height);
        }

        Canvas.SetLeft(EscapeButton, x);
        Canvas.SetTop(EscapeButton, y);
    }
}

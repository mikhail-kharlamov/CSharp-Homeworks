// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

using Avalonia;

namespace Calculator;

/// <summary>
/// The main entry point class for the Calculator application.
/// </summary>
internal class Program
{
    /// <summary>
    /// The main entry method for the application.
    /// </summary>
    /// <param name="args">Command line arguments passed to the application.</param>
    /// <remarks>
    /// This method configures and starts the Avalonia application using classic desktop lifetime.
    /// The <see cref="STAThreadAttribute"/> ensures the application runs in single-threaded
    /// apartment mode, which is required for some Windows components.
    /// </remarks>
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    /// <summary>
    /// Configures and builds the Avalonia application.
    /// </summary>
    /// <returns>
    /// An <see cref="AppBuilder"/> instance configured for the Calculator application.
    /// </returns>
    /// <remarks>
    /// This method:
    /// <list type="bullet">
    /// <item><description>Configures the application using the <see cref="App"/> class.</description></item>
    /// <item><description>Uses platform detection to determine the appropriate runtime settings.</description></item>
    /// <item><description>Sets up logging to trace output.</description></item>
    /// </list>
    /// </remarks>
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}
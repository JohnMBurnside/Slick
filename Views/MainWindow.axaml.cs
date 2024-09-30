using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using Slick.Classes;
using Avalonia.Interactivity;
namespace Slick.Views;
public partial class MainWindow : Window
{
    // Util Classes
    private DispatcherTimer timer;
    private DawnDuskCalc ddCalc;
    private DarkModeManager dmManager;
    private WallpaperManager wpManager;
    // Main Function
    public MainWindow()
    {
        InitializeComponent();
        ddCalc = new DawnDuskCalc();
        dmManager = new DarkModeManager();
        Debug.WriteLine("Initialized");
        StartClock();
    }
    public void ToggleDarkMode(object source, RoutedEventArgs args)
    {
        dmManager.Toggle();
    }
    public void AutoDarkMode(object source, RoutedEventArgs args)
    {
        Debug.WriteLine("Toggled");
    }
    private void StartClock()
    {
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (sender, e) => ClockText.Text = DateTime.Now.ToString("HH:mm:ss");
        timer.Start();
        Debug.WriteLine("Clock Started");
    }
}
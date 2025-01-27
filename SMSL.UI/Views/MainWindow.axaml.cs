using Avalonia.Controls;
using Avalonia.Interactivity;
using SMSL.UI.ViewModels;

namespace SMSL.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        #if DEBUG
        WindowGrid.ShowGridLines = true;
        TitleGrid.ShowGridLines = true;
        MainGrid.ShowGridLines = true;
        #endif
    }

    private void SideBar_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SideBar.SelectedIndex == -1)
        {
            return;
        }
        
        ContentPanel.Children.Clear();
        ContentPanel.Children.Add(((MainWindowViewModel) DataContext!).SideBarPages[SideBar.SelectedIndex].Page);
    }

    private void MinimizeButton_Click(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_Click(object? sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            MaximizeIcon.Text = "\uE922";
        }
        else
        {
            WindowState = WindowState.Maximized;
            MaximizeIcon.Text = "\uE923";
        }
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}

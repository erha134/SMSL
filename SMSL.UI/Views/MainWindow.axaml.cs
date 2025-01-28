using Avalonia.Controls;
using SMSL.UI.ViewModels;

namespace SMSL.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        #if DEBUG
        WindowGrid.ShowGridLines = true;
        MainGrid.ShowGridLines = true;
        #endif
    }
    
    // Custom Title Bar

    private void SideBar_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SideBar.SelectedIndex == -1)
        {
            return;
        }
        
        ContentPanel.Children.Clear();
        ContentPanel.Children.Add(((MainWindowViewModel) DataContext!).SideBarPages[SideBar.SelectedIndex].Page);
    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
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
    
    // FIXME
    private void CloseButton_OnPointerEntered(object? sender, PointerEventArgs e)
    {
        CloseButton.Background = new SolidColorBrush(Color.FromRgb(232, 17, 35));
        CloseButton.BorderBrush = new SolidColorBrush(Color.FromRgb(232, 17, 35));
    }
    
    // FIXME
    private void CloseButton_OnPointerExited(object? sender, PointerEventArgs e)
    {
        CloseButton.Background = Brushes.Transparent;
        CloseButton.BorderBrush = Brushes.Transparent;
    }
    
    // Window Drag
    
    private bool _isPointerPressed;
    private PixelPoint _startPosition = new(0, 0);
    private Point _mouseOffsetToOrigin = new(0, 0);

    private void TitleGrid_StartListenForDrag(object? sender, PointerPressedEventArgs e)
    {
        _startPosition = Position;
        _mouseOffsetToOrigin = e.GetPosition(this);
        _isPointerPressed = true;
    }

    private void TitleGrid_HandlePotentialDrag(object? sender, PointerEventArgs e)
    {
        if (!_isPointerPressed)
        {
            return;
        }
        
        var pos = e.GetPosition(this);
        _startPosition = new PixelPoint(
            (int) (_startPosition.X + pos.X - _mouseOffsetToOrigin.X), 
            (int) (_startPosition.Y + pos.Y - _mouseOffsetToOrigin.Y));
        Position = _startPosition;
    }

    private void TitleGrid_HandlePotentialDrop(object? sender, PointerReleasedEventArgs e)
    {
        var pos = e.GetPosition(this);
        _startPosition = new PixelPoint(
            (int) (_startPosition.X + pos.X - _mouseOffsetToOrigin.X), 
            (int) (_startPosition.Y + pos.Y - _mouseOffsetToOrigin.Y));
        Position = _startPosition;
        _isPointerPressed = false;
    }
}

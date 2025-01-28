using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace SMSL.UI.Controls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
        
        #if DEBUG
        TitleGrid.ShowGridLines = true;
        #endif
    }
    
    private void MinimizeButton_Click(object? sender, RoutedEventArgs e)
    {
        var root = (Window) VisualRoot!;
        
        root.WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_Click(object? sender, RoutedEventArgs e)
    {
        var root = (Window) VisualRoot!;
        
        if (root.WindowState == WindowState.Maximized)
        {
            root.WindowState = WindowState.Normal;
            MaximizeIcon.Text = "\uE922";
        }
        else
        {
            root.WindowState = WindowState.Maximized;
            MaximizeIcon.Text = "\uE923";
        }
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        var root = (Window) VisualRoot!;
        
        root.Close();
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
        var root = (Window) VisualRoot!;
        
        _startPosition = root.Position;
        _mouseOffsetToOrigin = e.GetPosition(this);
        _isPointerPressed = true;
    }

    private void TitleGrid_HandlePotentialDrag(object? sender, PointerEventArgs e)
    {
        var root = (Window) VisualRoot!;
        
        if (!_isPointerPressed)
        {
            return;
        }
        
        var pos = e.GetPosition(this);
        _startPosition = new PixelPoint(
            (int) (_startPosition.X + pos.X - _mouseOffsetToOrigin.X), 
            (int) (_startPosition.Y + pos.Y - _mouseOffsetToOrigin.Y));
        root.Position = _startPosition;
    }

    private void TitleGrid_HandlePotentialDrop(object? sender, PointerReleasedEventArgs e)
    {
        var root = (Window) VisualRoot!;
        
        var pos = e.GetPosition(this);
        _startPosition = new PixelPoint(
            (int) (_startPosition.X + pos.X - _mouseOffsetToOrigin.X), 
            (int) (_startPosition.Y + pos.Y - _mouseOffsetToOrigin.Y));
        root.Position = _startPosition;
        _isPointerPressed = false;
    }
}
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SMSL.UI.Views.Pages;

public abstract class PageBase : UserControl
{
    protected PageBase()
    {
        Loaded += OnPageLoaded;
        Unloaded += OnPageUnloaded;
    }

    protected virtual void OnPageLoaded(object? sender, RoutedEventArgs e)
    {
    }
    
    protected virtual void OnPageUnloaded(object? sender, RoutedEventArgs e)
    {
    }
}
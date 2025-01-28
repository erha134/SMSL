using System.Collections.Generic;
using SMSL.UI.Utils;
using SMSL.UI.Views.Pages;

namespace SMSL.UI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<SideBarPageItem> SideBarPages { get; } =
    [
        new("/Assets/home.svg", "Home", new HomePage()),
        new("/Assets/servers.svg", "Servers", new ServersPage()),
        new("/Assets/settings.svg", "Settings", new SettingsPage()),
        new("/Assets/about.svg", "About", new AboutPage()),
    ];
}

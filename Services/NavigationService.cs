using Avalonia.Controls;

namespace UI.Services;

public static class NavigationService
{
    public static void NavigateWindow(Window currentWindow, Window newWindow)
    {
        newWindow.Show();
        currentWindow.Close();
    }
}
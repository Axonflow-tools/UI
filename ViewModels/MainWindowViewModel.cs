using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI.Views;

namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _currentPage;
    
    [ObservableProperty]
    private string _toggleButtonText = "Go to Login";
    
    public MainWindowViewModel()
    {
        _currentPage = new RegisterPageViewModel();
    }
    
    [RelayCommand]
    private void TogglePage()
    {
        if (CurrentPage is RegisterPageViewModel)
        {
            CurrentPage = new LoginPageViewModel();
            ToggleButtonText = "Go to Register";
        }
        else
        {
            CurrentPage = new RegisterPageViewModel();
            ToggleButtonText = "Go to Login";
        }
    }
}
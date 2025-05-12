using CommunityToolkit.Mvvm.ComponentModel;
namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _currentPage = new ProjectSelectionViewModel();
    
}
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using UI.Models;
namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Project> Projects { get; } = new();
    

    public MainWindowViewModel()
    {
        Projects.Add(new Project
        {
            Name = "E-Commerce Website",
            Description = "Online store with payment integration",
            Location = "/projects/ecommerce"
        });
        
        Projects.Add(new Project
        {
            Name = "Mobile Banking App",
            Description = "Financial application with secure transactions",
            Location = "/Dev/BankingApp"
        });
    }
    
}
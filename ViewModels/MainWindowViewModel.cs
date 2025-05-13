using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI.Data;
using UI.Data.Models;
using UI.Services;

namespace UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly AppDbContext? _db;
    [ObservableProperty]
    private ObservableCollection<Project> _projects = new();
    

    public MainWindowViewModel()
    {
        _db = DatabaseService.Db;
        LoadProjects();
    }
    private void LoadProjects()
    {
        Projects = new ObservableCollection<Project>(_db!.Projects.ToList());
    }
    
    [RelayCommand]
    private void DeleteProject(Project project)
    {
        try
        {
            if (Directory.Exists(project.Location))
            {
                Directory.Delete(project.Location, recursive: true);
            }
        
            DatabaseService.Db.Projects.Remove(project);
            DatabaseService.Db.SaveChanges();
            Projects.Remove(project);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    
}
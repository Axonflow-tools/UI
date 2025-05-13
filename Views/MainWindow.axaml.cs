using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using DialogHostAvalonia;
using UI.Services;

namespace UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void FileSelectionHandler(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select a csv file",
            AllowMultiple = false,
            FileTypeFilter = new []
            {
                new FilePickerFileType("Csv Files")
                {
                    Patterns = new [] {"*.csv"}
                }
            }
        });

        var selectedFile = files[0];
        FileService.CurrentFile = selectedFile.Path.AbsolutePath;
        Console.WriteLine(FileService.CurrentFile);
        NavigationService.NavigateWindow(this, new EditorWindow());
    }

    private void CreateProject(object? sender, RoutedEventArgs e)
    {
        var projectCreationWindow = new ProjectCreationWindow();
        projectCreationWindow.ShowDialog(this);
    }
}
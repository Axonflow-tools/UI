using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using UI.Services;
using UI.ViewModels;

namespace UI.Views;

public partial class ProjectSelectionView : UserControl
{
    public ProjectSelectionView()
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
        Console.WriteLine(selectedFile.Path.AbsolutePath);
        FileService.CurrentFile = selectedFile.Path.AbsolutePath;
    }
}
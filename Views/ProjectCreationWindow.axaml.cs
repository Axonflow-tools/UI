using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using UI.Services;

namespace UI.Views;

public partial class ProjectCreationWindow : Window
{
    public ProjectCreationWindow()
    {
        InitializeComponent();
    }
    private async void OnBrowseFolderClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
            
        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Project Location",
            AllowMultiple = false
        });

        if (folders.Count > 0)
        {
            LocationTextBox.Text = folders[0].Path.LocalPath;
        }
    }

    private void OnCreateProjectClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string projectName = ProjectNameTextBox.Text?.Trim() ?? string.Empty;
        string location = LocationTextBox.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(projectName))
        {
            // Show error about missing project name
            return;
        }

        if (string.IsNullOrWhiteSpace(location))
        {
            // Show error about missing location
            return;
        }

        try
        {
            string projectPath = Path.Combine(location, projectName);
            string axonflowPath = Path.Combine(projectPath, ".axonflow");
        
            if (Directory.Exists(projectPath))
            {
                // Show error that folder already exists
                return;
            }

            // Create both directories
            Directory.CreateDirectory(projectPath);
            Directory.CreateDirectory(axonflowPath);
        
            // Optional: Create default files in the .axonflow directory
            string configFilePath = Path.Combine(axonflowPath, "config.json");
            File.WriteAllText(configFilePath, "{}"); // Empty JSON file
        
            // Close the window or show success message
            var mainWindow = (MainWindow)this.Owner!;
            NavigationService.NavigateWindow(this, new EditorWindow());
            mainWindow?.Close();
        }
        catch (Exception ex)
        {
            // Show error message
            Console.WriteLine($"Error creating project: {ex.Message}");
        }
    }
}
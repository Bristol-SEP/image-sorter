using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace app.Views;
/// <summary>
/// A view for the initial steps of adding an image and choosing the filters
/// </summary>
public partial class AddImageDisplayView : UserControl
{
    public AddImageDisplayView()
    {
        InitializeComponent();
        AddHandler(DragDrop.DropEvent, Drop);
    }

    /// <summary>
    /// Triggers a Folder picker and passes the selected folders into
    /// <see cref="IAddImageDisplayViewModel.AddFolders"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    /// <exception cref="NullReferenceException">Occurs if cannot get top level</exception>
    private async void OpenFileButton_Clicked(object sender, RoutedEventArgs args)
    {
        if (DataContext is not IAddImageDisplayViewModel viewModel) return;
        
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);
    
        // Start async operation to open the dialog.
        var folders = topLevel is not null
            ? await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Open Folder",
                AllowMultiple = true
            })
            : throw new NullReferenceException();
    
        // Pass into viewModel
        var folderList = folders.Select(folder => new SelectFolders(folder.Name, folder.Path.AbsolutePath)).ToList();
        viewModel.AddFolders(folderList);
    }

    // TODO implement drag and drop
    /// <summary>
    /// Event which is called when folder dropped into area
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void Drop(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataFormats().Contains(DataFormats.Files))
        {
            var files = e.Data.Get(DataFormats.Files);
            Console.WriteLine(files);
        }
        // if (e.Data.GetDataPresent(DataFormats.Files))
        // {
        //     string[] files = (string[])e.Data.GetData(DataFormats.Files);
        //     string fileName = Path.GetFileName(files[0]);
        //     Console.WriteLine(fileName);
        // }
        Console.WriteLine("drop");
    }
}
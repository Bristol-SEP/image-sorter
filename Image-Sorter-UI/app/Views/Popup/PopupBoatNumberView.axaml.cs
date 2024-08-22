using System;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;

namespace app.Views.Popup;

public partial class PopupBoatNumberView : UserControl
{
    public PopupBoatNumberView()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// Triggers a Folder picker and passes the selected folders into
    /// <see cref="IPopupBoatNumberViewModel.AddSearch"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    /// <exception cref="NullReferenceException">Occurs if cannot get top level</exception>
    private async void OpenFileButton_Clicked(object sender, RoutedEventArgs args)
    {
        if (DataContext is not IPopupBoatNumberViewModel viewModel) return;
        
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);
    
        // Start async operation to open the dialog.
        var folders = topLevel is not null
            ? await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Choose Folder",
                AllowMultiple = false
            })
            : throw new NullReferenceException();
    
        // Pass into viewModel
        var folder= folders.Select(folder => new SelectFolders(folder.Name, folder.Path.AbsolutePath.Replace("%20", " "))).ToList()[0];
        viewModel.AddSearch(folder);
    }
}
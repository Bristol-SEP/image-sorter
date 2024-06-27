using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Views;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel of the <see cref="MainWindow"/>
/// </summary>
public interface IMainWindowViewModel
{
   /// <summary>
   /// A list of <see cref="SelectFolders"/> 
   /// </summary>
   public ObservableCollection<SelectFolders> FolderList { get; }
    
    /// <summary>
    /// Holds the current display, when changed page shown will change
    /// </summary>
    public ViewModelBase CurrentPage { get; }
    
    /// <summary>
    /// Is true if the <see cref="CurrentPage"/> is set to that of <see cref="AddImageDisplayView"/>
    /// </summary>
    public bool IsImagePage { get; }
    
    /// <summary>
    /// Toggles the view in the main window
    /// </summary>
    public void ToggleView();
    
    /// <summary>
    /// Adds folders to <see cref="FolderList"/>
    /// </summary>
    /// <param name="folders">the folders being passed by the start processing button</param>
    public void AddFolders(IEnumerable<SelectFolders> folders);

    /// <summary>
    /// Remove folders from the <see cref="FolderList"/>
    /// </summary>
    /// <param name="folder">The Folder to be removed</param>
    public void RemoveFolders(SelectFolders folder)
    {
        FolderList.Remove(folder);
    }
}
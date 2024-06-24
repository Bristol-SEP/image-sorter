using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Views;
using Avalonia.Platform.Storage;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel for <see cref="AddImageDisplayView"/>
/// </summary>
public interface IAddImageDisplayViewModel
{
    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    public IMainWindowViewModel? MainModel { get; }
    
   /// <summary>
   /// A list of <see cref="FeatureGroup"/> used in feature selection
   /// within the <see cref="AddImageDisplayView"/>
   /// </summary>
   public List<FeatureGroup> FeatureList { get; }
   

   /// <summary>
   /// Is true when <see cref="MainWindowViewModel.FolderList"/> contains no items
   /// </summary>
   public bool FoldersEmpty { get; }
   
   /// <summary>
   /// Determines whether or not a prompt to select a <see cref="Feature"/>
   /// should appear
   /// </summary>
   public bool FeaturePrompt { get; }
   
   /// <summary>
   /// Determines whether or not a prompt to select a <see cref="SelectFolders">folder</see>
   /// should appear
   /// </summary>
   public bool FolderPrompt { get; }
   
    /// <summary>
    /// Sets the <see cref="IMainWindowViewModel"/> context
    /// </summary>
    /// <param name="mainViewModel">An instance of <see cref="IMainWindowViewModel"/></param>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel);
    
   /// <summary>
   /// Occurs when processing button is clicked, sends the data to the
   /// python script to be processed and moves display to <see cref="FolderStructureDisplayView"/>
   /// </summary>
   public void ButtonPressed();
   
   /// <summary>
   /// Add folders to the <see cref="MainWindowViewModel.FolderList"/>
   /// </summary>
   /// <param name="folders"><see cref="IReadOnlyList{T}">ReadOnlyList</see>
   /// of <see cref="IStorageFolder">Folders</see></param>
   public void AddFolders(List<SelectFolders> folders);

   /// <summary>
   /// Remove folders from the <see cref="MainWindowViewModel.FolderList"/>
   /// </summary>
   /// <param name="folder">The Folder to be removed</param>
   public void RemoveFolders(SelectFolders folder);
}
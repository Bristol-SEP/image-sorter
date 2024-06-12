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
   /// A list of <see cref="FeatureGroup"/> used in feature selection
   /// within the <see cref="AddImageDisplayView"/>
   /// </summary>
   public List<FeatureGroup> FeatureList { get; }
   
   /// <summary>
   /// A list of <see cref="SelectFolders"/> used in image selection
   /// within the <see cref="AddImageDisplayView"/>
   /// </summary>
   public ObservableCollection<SelectFolders> FolderList { get; }

   /// <summary>
   /// Is true when <see cref="FolderList"/> contains no items
   /// </summary>
   public bool FoldersEmpty { get; }
   
   /// <summary>
   /// Add folders to the <see cref="FolderList"/>
   /// </summary>
   /// <param name="folders"><see cref="IReadOnlyList{T}">ReadOnlyList</see>
   /// of <see cref="IStorageFolder">Folders</see></param>
   public void AddFolders(IReadOnlyList<IStorageFolder>? folders);

   /// <summary>
   /// Remove folders from the <see cref="FolderList"/>
   /// </summary>
   public void RemoveFolders(SelectFolders folder);
}
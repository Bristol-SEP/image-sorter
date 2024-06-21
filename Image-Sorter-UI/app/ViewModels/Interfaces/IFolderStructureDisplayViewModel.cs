using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Views;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel of the <see cref="FolderStructureDisplayView"/>
/// </summary>
public interface IFolderStructureDisplayViewModel
{
   /// <summary>
   /// A list of <see cref="SelectFolders"/> used in choosing folder structure 
   /// within the <see cref="FolderStructureDisplayView"/>
   /// </summary>
   public ObservableCollection<SelectFolders> FolderList { get; }
   
    /// <summary>
    /// Sets the <see cref="IMainWindowViewModel"/> context
    /// </summary>
    /// <param name="mainViewModel">An instance of <see cref="IMainWindowViewModel"/></param>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel);

    /// <summary>
    /// Adds folders to <see cref="FolderList"/>
    /// </summary>
    /// <param name="folders">the folders being passed by the start processing button</param>
    public void AddFolders(ObservableCollection<SelectFolders> folders);
    
   /// <summary>
   /// Occurs when add images button is clicked returns to the
   /// <see cref="AddImageDisplayView"/>
   /// </summary>
   public void ButtonPressed();
}
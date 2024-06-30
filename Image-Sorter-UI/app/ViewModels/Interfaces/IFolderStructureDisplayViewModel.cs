using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Views;
using Avalonia.Collections;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel of the <see cref="FolderStructureDisplayView"/>
/// </summary>
public interface IFolderStructureDisplayViewModel
{
    /// <summary>
    /// A <see cref="ObservableCollection{T}">ObservableCollection</see> of <see cref="DirectoryItem"/> 
    /// </summary>
    public ObservableCollection<DirectoryItem> FolderDirectories { get; set; }
    
    /// <summary>
    /// Sets the <see cref="IMainWindowViewModel"/> context
    /// </summary>
    /// <param name="mainViewModel">An instance of <see cref="IMainWindowViewModel"/></param>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel);

   /// <summary>
   /// Occurs when add images button is clicked returns to the
   /// <see cref="AddImageDisplayView"/>
   /// </summary>
   public void ButtonPressed();
}
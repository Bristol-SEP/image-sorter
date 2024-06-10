using System.Collections.Generic;
using app.Model;
using app.Views;

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
   public List<FeatureGroup> FeatureList { get; }
}
using app.Views;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel for <see cref="AddImageDisplayView"/>
/// </summary>
public interface IAddImageDisplayViewModel
{
   /// <summary>
   /// Occurs when processing button is clicked, sends the data to the
   /// python script to be processed and moves display to <see cref="FolderStructureDisplayView"/>
   /// </summary>
   /// <returns>True if successful otherwise false</returns>
   public bool ButtonPressed();
}
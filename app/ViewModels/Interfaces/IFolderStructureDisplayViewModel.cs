using app.Views;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel of the <see cref="FolderStructureDisplayView"/>
/// </summary>
public interface IFolderStructureDisplayViewModel
{
   /// <summary>
   /// Occurs when add images button is clicked returns to the
   /// <see cref="AddImageDisplayView"/>
   /// </summary>
   /// <returns>True if successful otherwise false</returns>
   public bool ButtonPressed();
}
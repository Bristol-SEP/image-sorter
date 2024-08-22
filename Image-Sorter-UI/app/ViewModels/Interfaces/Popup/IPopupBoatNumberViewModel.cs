using app.Model;

namespace app.ViewModels.Interfaces.Popup;

/// <summary>
/// The Feature details specific to Boat Numbers
/// </summary>
public interface IPopupBoatNumberViewModel
{
    /// <summary>
    /// The name of the folder to be created
    /// </summary>
    public string FolderName { get; set; }
    
    /// <summary>
    /// Reference to the location of the folder to be searched
    /// </summary>
    public SelectFolders AffectedFolder { get; }
    
    /// <summary>
    /// A string of the affected folders 
    /// </summary>
    public string FolderList { get; }

    /// <summary>
    /// Reference to the model for the view model
    /// </summary>
    public BoatNumberFeature BoatNumberFeature { get; }
    
    /// <summary>
    /// Toggles between 1 folder being affected and all folders on that level being affected
    /// </summary>
    public void AddFolderLevel();

    /// <summary>
    /// Adds the search folder to <see cref="BoatNumberFeature"/>
    /// </summary>
    /// <param name="folder">The folder to be used</param>
    public void AddSearch(SelectFolders folder);
}
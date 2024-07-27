namespace app.ViewModels.Interfaces.Popup;

/// <summary>
/// The feature details specific to Bow Numbers
/// </summary>
public interface IPopupBowNumberViewModel
{
    /// <summary>
    /// A string of the affected folders 
    /// </summary>
    public string FolderList { get; }
    
    /// <summary>
    /// Holds the number of boats which should be in grouped per folder
    /// </summary>
    public int BoatsPerFolder { get; set; }
    
    /// <summary>
    /// Decides whether all of the same number should have their own folder
    /// </summary>
    public bool IsIndividualFolders { get; }

    /// <summary>
    /// Toggles between 1 folder being affected and all folders on that level being affected
    /// </summary>
    public void AddFolderLevel();

    /// <summary>
    /// Toggles <see cref="IsIndividualFolders"/>
    /// </summary>
    public void ToggleIsIndividualFolder();

}
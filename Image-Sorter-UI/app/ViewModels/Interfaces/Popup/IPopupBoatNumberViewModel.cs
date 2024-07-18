namespace app.ViewModels.Interfaces.Popup;

public interface IPopupBoatNumberViewModel
{
    /// <summary>
    /// A string of the affected folders 
    /// </summary>
    public string FolderList { get; }

    /// <summary>
    /// Toggles between 1 folder being affected and all folders on that level being affected
    /// </summary>
    public void AddFolderLevel();
}
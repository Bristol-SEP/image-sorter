namespace app.ViewModels.Interfaces;

/// <summary>
/// A way of initialising views
/// </summary>
public interface IViewModelProvider
{
    /// <summary>
    /// Creates a new <see cref="MainWindowViewModel" /> instance
    /// </summary>
    /// <returns>A new <see cref="MainWindowViewModel" /> instance</returns>
    public IMainWindowViewModel GetMainViewModel();

    /// <summary>
    /// Creates a new <see cref="AddImageDisplayViewModel" /> instance
    /// </summary>
    /// <returns>A new <see cref="AddImageDisplayViewModel" /> instance</returns>
    public IAddImageDisplayViewModel GetAddImageViewModel();

    /// <summary>
    /// Creates a new <see cref="FolderStructureDisplayViewModel" /> instance
    /// </summary>
    /// <returns>A new <see cref="FolderStructureDisplayViewModel" /> instance</returns>
    public IFolderStructureDisplayViewModel GetFolderStructureViewModel();
    
}
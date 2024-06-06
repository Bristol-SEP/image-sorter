using app.Views;

namespace app.ViewModels.Interfaces;

public interface IMainWindowViewModel
{
    
    /// <summary>
    /// Holds the current display, when changed page shown will change
    /// </summary>
    public ViewModelBase CurrentPage { get; set; }
    
    /// <summary>
    /// Is true if the <see cref="CurrentPage"/> is set to that of <see cref="AddImageDisplayView"/>
    /// </summary>
    public bool IsImagePage { get; }
    
    /// <summary>
    /// Toggles the view in the main window
    /// </summary>
    public void ToggleView();
}
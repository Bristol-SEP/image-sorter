namespace app.ViewModels.Interfaces;

public interface IMainWindowViewModel
{
    
    /// <summary>
    /// Holds the current display, when changed page shown will change
    /// </summary>
    public ViewModelBase CurrentPage { get; set; }
    
    /// <summary>
    /// Toggles the view in the main window
    /// </summary>
    public void ToggleView();
}
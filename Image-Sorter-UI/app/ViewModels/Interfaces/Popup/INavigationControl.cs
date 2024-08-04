using app.ViewModels.Popup;

namespace app.ViewModels.Interfaces.Popup;

/// <summary>
/// The features required to navigate and close popups
/// </summary>
public interface INavigationControl
{
    /// <summary>
    /// Returns the popup to the <see cref="PopupMainPageViewModel"/>
    /// </summary>
    public void Return();

    /// <summary>
    /// Closes the popup
    /// </summary>
    public void Close();
}
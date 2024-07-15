using app.ViewModels.Popup;

namespace app.ViewModels.Interfaces.Popup;

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
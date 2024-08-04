namespace app.ViewModels.Interfaces.Popup;

/// <summary>
/// A set of generic elements required for all features on the popup
/// </summary>
public interface IPopupFeature
{
    /// <summary>
    /// Holds a reference to <see cref="IPopupMainPageViewModel"/> so
    /// you can go back
    /// </summary>
    public IPopupMainPageViewModel MainPage { get; }

    /// <summary>
    /// Sets the <see cref="MainPage"/>
    /// </summary>
    /// <param name="mainPage">An instance of <see cref="IPopupMainPageViewModel"/></param>
    public void SetContext(IPopupMainPageViewModel mainPage);

    /// <summary>
    /// Packs popup inputs and updates the display before closing the popup
    /// </summary>
    public void AddFeature();
}
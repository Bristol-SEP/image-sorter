using app.Model.Interfaces;

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

    /// <summary>
    /// Converts the specified model into <see cref="IFeatureFolderDetails"/>
    /// so that it may be affected by <see cref="FolderStructureDisplayViewModel"/>
    /// </summary>
    /// <returns>The model</returns>
    public IFeatureFolderDetails GetModelBasic();
}
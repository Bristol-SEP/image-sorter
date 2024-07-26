using app.Model.Interfaces;
using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBowNumberViewModel: ViewModelBase, IPopupBowNumberViewModel, IPopupFeature, INavigationControl
{
    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; private set; }
    
    /// <inheritdoc/>
    public string FolderList { get; }
    
    /// <inheritdoc/>
    public int BoatsPerFolder { get; }

    /// <inheritdoc/>
    public void SetContext(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

    /// <inheritdoc/>
    public void AddFeature()
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public void Return()
    {
        MainPage.BackToMain();
    }

    /// <inheritdoc/>
    public void Close()
    {
        Return();
        MainPage.ClosePopup();
    }

    public PopupBowNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

    /// <inheritdoc/>
    public void AddFolderLevel()
    {
        throw new System.NotImplementedException();
    }
}
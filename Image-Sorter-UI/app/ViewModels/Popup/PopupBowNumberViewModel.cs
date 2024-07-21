using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBowNumberViewModel: ViewModelBase, IPopupBowNumberViewModel, IPopupFeature, INavigationControl
{
    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; private set; }

    /// <inheritdoc/>
    public void SetContext(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

    public void AddFeature()
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public void Return()
    {
        MainPage.BackToMain();
    }

    public void Close()
    {
        Return();
        MainPage.ClosePopup();
    }

    public PopupBowNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }
}
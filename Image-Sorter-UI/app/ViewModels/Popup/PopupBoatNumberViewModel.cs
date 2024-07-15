using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBoatNumberViewModel: ViewModelBase, IPopupBoatNumberViewModel, IPopupFeature, INavigationControl
{
    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; private set; }

    /// <inheritdoc/>
    public void SetContext(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
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

    public PopupBoatNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }
}
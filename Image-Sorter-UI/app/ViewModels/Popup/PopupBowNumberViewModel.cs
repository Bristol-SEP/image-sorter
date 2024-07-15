using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBowNumberViewModel: ViewModelBase, IPopupBowNumberViewModel, IPopupFeature
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
    public PopupBowNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }
}
using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBowNumberViewModel: ViewModelBase, IPopupBowNumberViewModel, IPopupFeature
{
    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; }

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
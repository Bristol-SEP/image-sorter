using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBoatNumberViewModel: ViewModelBase, IPopupBoatNumberViewModel, IPopupFeature
{
    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; }
    
    /// <inheritdoc/>
    public void Return()
    {
        MainPage.BackToMain();
    }

    public PopupBoatNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }
}
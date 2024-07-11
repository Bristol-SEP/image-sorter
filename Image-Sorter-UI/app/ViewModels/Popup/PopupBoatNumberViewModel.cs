using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBoatNumberViewModel: ViewModelBase, IPopupBoatNumberViewModel
{
    public ViewModelBase MainPage { get; } = new ViewModelBase();
}
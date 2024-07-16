using System.Linq;
using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

public class PopupBoatNumberViewModel: ViewModelBase, IPopupBoatNumberViewModel, IPopupFeature, INavigationControl
{
    /// <inheritdoc/>
    public string FolderList
    {
        get
        {
            var folders = MainPage.FolderView.FeatureFolderList.Aggregate
                ("", (current, folder) 
                    => current + (folder.Folder.Name + ", "));
            folders = folders.Length <= 2 ? folders : folders.Remove(folders.Length - 2);
            return folders;
        }
    }

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
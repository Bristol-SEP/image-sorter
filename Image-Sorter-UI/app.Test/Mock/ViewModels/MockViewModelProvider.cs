using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using Image_Sorter_UI.Mock.ViewModels.Popup;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockViewModelProvider: IViewModelProvider
{
    public IMainWindowViewModel GetMainViewModel() => new MockMainWindowViewModel();

    public IAddImageDisplayViewModel GetAddImageViewModel() => new MockAddImageDisplayViewModel();

    public IFolderStructureDisplayViewModel GetFolderStructureViewModel() => new MockFolderStructureDisplayViewModel();
    public IPopupMainPageViewModel GetPopupMainPageViewModel() => new MockPopupMainPageViewModel();
}
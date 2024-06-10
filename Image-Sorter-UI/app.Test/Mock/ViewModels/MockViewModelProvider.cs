using app.ViewModels.Interfaces;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockViewModelProvider: IViewModelProvider
{
    public IMainWindowViewModel GetMainViewModel() => new MockMainWindowViewModel();

    public IAddImageDisplayViewModel GetAddImageViewModel() => new MockAddImageDisplayViewModel();

    public IFolderStructureDisplayViewModel GetFolderStructureViewModel() => new MockFolderStructureDisplayViewModel();
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Avalonia.Collections;
using Image_Sorter_UI.Mock.ViewModels.Popup;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockFolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    private IMainWindowViewModel? _mainModel;
    public ViewModelBase View { get; } = new MockPopupMainPageViewModel();
    public bool ShowPopup { get; } = false;
    public DirectoryPriorityList FolderDirectories { get; set; } = new(new ObservableCollection<SelectFolders>());
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainModel = mainViewModel;
    }

    public void ButtonPressed()
    {
        throw new System.NotImplementedException();
    }

    public void AddFeature(DirectoryItem item)
    {
        throw new System.NotImplementedException();
    }
}
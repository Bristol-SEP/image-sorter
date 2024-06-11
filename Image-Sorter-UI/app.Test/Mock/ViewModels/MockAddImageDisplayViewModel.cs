using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Avalonia.Platform.Storage;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockAddImageDisplayViewModel: ViewModelBase, IAddImageDisplayViewModel
{
    private IMainWindowViewModel? _mainView;
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainView = mainViewModel;
    }

    public void ButtonPressed()
    {
        throw new System.NotImplementedException();
    }

    public List<FeatureGroup> FeatureList => new();
    public ObservableCollection<SelectFolders> FolderList => new();
    public bool FoldersEmpty => true;
    public void AddFolders(IReadOnlyList<IStorageFolder>? folders)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveFolders()
    {
        throw new System.NotImplementedException();
    }
}
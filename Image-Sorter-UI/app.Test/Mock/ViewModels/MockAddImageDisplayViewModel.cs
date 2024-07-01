using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockAddImageDisplayViewModel: ViewModelBase, IAddImageDisplayViewModel
{
    public IMainWindowViewModel? MainModel { get; private set; }
    public List<FeatureGroup> FeatureList => new();
    public bool FoldersEmpty => true;
    public bool FeaturePrompt => true;
    public bool FolderPrompt => true;
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        MainModel = mainViewModel;
    }

    public void ButtonPressed()
    {
        throw new System.NotImplementedException();
    }

    public void AddFolders(List<SelectFolders> folders)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveFolders(SelectFolders folder)
    {
        throw new System.NotImplementedException();
    }
}
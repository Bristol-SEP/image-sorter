using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockFolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    public ViewModelBase View { get; set; } = new();
    public bool ShowPopup { get; set; } = false;
    public FeatureList FeatureList { get; set; } = new();
    public DirectoryPriorityList FolderDirectories { get; set; } = new(new ObservableCollection<SelectFolders>());
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
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
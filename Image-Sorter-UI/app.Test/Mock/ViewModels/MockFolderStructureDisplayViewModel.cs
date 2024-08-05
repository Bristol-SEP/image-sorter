using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Model.Interfaces;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Image_Sorter_UI.Mock.Model;
using ReactiveUI;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockFolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    /// <summary>
    /// Backing field for <see cref="FeatureFolderList"/>
    /// </summary>
    private ObservableCollection<DirectoryItem> _featureFolderList = new();
    
    /// <summary>
    /// Backing field for <see cref="FeatureFolderDetailsList"/>
    /// </summary>
    private ObservableCollection<IFeatureFolderDetails> _featureFolderDetailsList = new();

    public ViewModelBase View { get; set; } = new();

    public bool ShowPopup { get; set; }

    public ObservableCollection<DirectoryItem> FeatureFolderList
    {
        get => _featureFolderList;
        set => this.RaiseAndSetIfChanged(ref _featureFolderList, value);
    }

    public ObservableCollection<IFeatureFolderDetails> FeatureFolderDetailsList
    {
        get => _featureFolderDetailsList;
        private set => this.RaiseAndSetIfChanged(ref _featureFolderDetailsList, value);
    }
    public FeatureList FeatureList { get; set; } = new();
    public IDirectoryPriorityList FolderDirectories { get; set; } = new MockDirectoryPriorityList();
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

    public void UpdateFeatureFolderList(string name, List<DirectoryItem> featureModel)
    {
        var folder = new SelectFolders("default", "basicPath");
        var directoryItem = new DirectoryItem(folder, 1);
        FeatureFolderList = new ObservableCollection<DirectoryItem>();
    }

    public void RemoveFeature(DirectoryItem folder)
    {
        throw new System.NotImplementedException();
    }

    public void StructureFolder()
    {
        throw new System.NotImplementedException();
    }
}
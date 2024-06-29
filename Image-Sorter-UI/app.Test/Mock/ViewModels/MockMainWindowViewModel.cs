using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockMainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private readonly ViewModelBase _imagePage;
    private readonly ViewModelBase _folderPage;
    public ObservableCollection<SelectFolders> FolderList => new();
    public ViewModelBase CurrentPage { get; private set; }
    public bool IsImagePage { get; private set; } = true;

    public MockMainWindowViewModel()
    {
        _imagePage = new MockAddImageDisplayViewModel();
        _folderPage = new MockFolderStructureDisplayViewModel();
        CurrentPage = _imagePage;
    }
    public void ToggleView()
    {
        CurrentPage = IsImagePage ? _folderPage : _imagePage;
        IsImagePage = !IsImagePage;
    }

    public void AddFolders(IEnumerable<SelectFolders> folders)
    {
        foreach (var folder in folders)
        {
           FolderList.Add(folder); 
        }
    }
}
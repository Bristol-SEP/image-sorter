using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockMainWindowViewModel: ViewModelBase, IMainWindowViewModel
{
    public ObservableCollection<SelectFolders> FolderList => new();
    public ViewModelBase CurrentPage { get; } = new();
    public bool IsImagePage => false;
    public void ToggleView()
    {
        throw new System.NotImplementedException();
    }

    public void AddFolders(IEnumerable<SelectFolders> folders)
    {
        foreach (var folder in folders)
        {
           FolderList.Add(folder); 
        }
    }
}
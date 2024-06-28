using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockFolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    public Dictionary<SelectFolders, int> Directories { get; set; } = new();
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        throw new System.NotImplementedException();
    }

    public void ButtonPressed()
    {
        throw new System.NotImplementedException();
    }
}
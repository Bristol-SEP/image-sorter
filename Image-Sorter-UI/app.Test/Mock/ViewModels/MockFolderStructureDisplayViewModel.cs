using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Avalonia.Collections;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockFolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    private IMainWindowViewModel? _mainModel;
    public AvaloniaDictionary<string, int> FolderDirectories { get; set; } = new();
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainModel = mainViewModel;
    }

    public void ButtonPressed()
    {
        throw new System.NotImplementedException();
    }
}
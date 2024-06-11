using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;

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
}
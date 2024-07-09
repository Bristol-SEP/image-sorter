using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;

namespace Image_Sorter_UI.Mock.ViewModels.Popup;

public class MockPopupMainPageViewModel: ViewModelBase, IPopupMainPageViewModel
{
    private List<Feature> _featureGroup = new List<Feature>();
    public FeatureGroup FeatureGroup { get; } = new("test", new List<Feature>());
    public IFolderStructureDisplayViewModel FolderView { get; } = new MockFolderStructureDisplayViewModel();
    public void ChooseFeature(ViewModelBase view)
    {
        throw new System.NotImplementedException();
    }

    List<Feature> IPopupMainPageViewModel.FeatureGroup => _featureGroup;
}
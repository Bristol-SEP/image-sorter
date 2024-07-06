using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces.Popup;

namespace Image_Sorter_UI.Mock.ViewModels.Popup;

public class MockPopupMainPageViewModel: ViewModelBase, IPopupMainPageViewModel
{
    public FeatureGroup FeatureGroup { get; } = new("test", new List<Feature>());
}
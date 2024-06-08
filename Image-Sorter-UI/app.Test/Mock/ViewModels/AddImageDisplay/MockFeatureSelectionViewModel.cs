using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces.AddImageDisplay;

namespace Image_Sorter_UI.Mock.ViewModels.AddImageDisplay;

public class MockFeatureSelectionViewModel: IFeatureSelectionViewModel
{
    public ObservableCollection<FeatureGroup> FeatureList { get; set; }
}
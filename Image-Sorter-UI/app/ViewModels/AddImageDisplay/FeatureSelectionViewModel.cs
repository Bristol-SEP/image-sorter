using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces.AddImageDisplay;

namespace app.ViewModels.AddImageDisplay;

/// <inheritdoc cref="IFeatureSelectionViewModel"/>
public class FeatureSelectionViewModel: ViewModelBase, IFeatureSelectionViewModel
{
    /// <inheritdoc/>
    public ObservableCollection<FeatureGroup>? FeatureList { get; set; }
    
    public FeatureSelectionViewModel()
    {
        FeatureGroup rowing = new FeatureGroup("Rowing");
        rowing.AddFeature("Boat Code");
        rowing.AddFeature("Race Number");
        FeatureGroup test = new FeatureGroup("test");
        FeatureList = new ObservableCollection<FeatureGroup>(new List<FeatureGroup>
        {
            rowing,
            test
        });
    }
}
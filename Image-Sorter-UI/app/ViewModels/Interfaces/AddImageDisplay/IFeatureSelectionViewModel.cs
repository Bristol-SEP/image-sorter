using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;

namespace app.ViewModels.Interfaces.AddImageDisplay;

public interface IFeatureSelectionViewModel
{
public ObservableCollection<FeatureGroup> FeatureList { get; set; }
}
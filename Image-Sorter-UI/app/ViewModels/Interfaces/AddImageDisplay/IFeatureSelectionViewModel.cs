using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Views.AddImageDisplay;

namespace app.ViewModels.Interfaces.AddImageDisplay;

/// <summary>
/// The ViewModel for <see cref="FeatureSelection"/>
/// </summary>
public interface IFeatureSelectionViewModel
{
    /// <summary>
    /// A <see cref="ObservableCollection{T}">ObservableCollection</see> of type
    /// <see cref="FeatureGroup"/>
    /// </summary>
    public ObservableCollection<FeatureGroup> FeatureList { get; set; }
}
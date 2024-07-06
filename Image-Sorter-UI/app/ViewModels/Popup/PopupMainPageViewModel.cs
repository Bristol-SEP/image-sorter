using System;
using System.Collections.Generic;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

/// <summary>
/// The starting page of the popup
/// </summary>
public class PopupMainPageViewModel: ViewModelBase, IPopupMainPageViewModel
{
    /// <inheritdoc/>
    public FeatureGroup FeatureGroup { get; }

    /// <summary>
    /// Creates the context for the <see cref="PopupMainPageViewModel"/>
    /// </summary>
    /// <param name="featureList">The <see cref="FeatureGroup"/> of the specific sport</param>
    public PopupMainPageViewModel(IEnumerable<FeatureGroup> featureList)
    {
        FeatureGroup = new FeatureGroup("error", new List<Feature>());
        foreach (var featureGroup in featureList.Where(featureGroup => featureGroup.ShouldExpand))
        {
            FeatureGroup = featureGroup;
        }
    }
}
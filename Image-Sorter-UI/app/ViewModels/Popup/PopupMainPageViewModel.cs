using System;
using System.Collections.Generic;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;

namespace app.ViewModels.Popup;

/// <summary>
/// The starting page of the popup
/// </summary>
public class PopupMainPageViewModel: ViewModelBase, IPopupMainPageViewModel
{
    /// <inheritdoc/>
    public List<Feature> FeatureGroup { get; } = new();

    /// <inheritdoc/>
    public IFolderStructureDisplayViewModel FolderView { get; }

    public void BackToMain()
    {
        FolderView.View = this;
    }

    /// <inheritdoc/>
    public void ChooseFeature(ViewModelBase view)
    {
        FolderView.View = view;
    }

    /// <inheritdoc/>
    public void ClosePopup()
    {
        FolderView.ShowPopup = false;
    }

    /// <summary>
    /// Creates the context for the <see cref="PopupMainPageViewModel"/>
    /// </summary>
    /// <param name="featureList">The <see cref="FeatureGroup"/> of the specific sport</param>
    /// <param name="view">A reference to the <see cref="IFolderStructureDisplayViewModel"/></param>
    public PopupMainPageViewModel(IEnumerable<FeatureGroup> featureList, IFolderStructureDisplayViewModel view)
    {
        foreach (var featureGroup in featureList.Where(featureGroup => featureGroup.ShouldExpand))
        {
            FeatureGroup = featureGroup.Features.Where(feature => feature.Selected).ToList();
        }
        FolderView = view;
    }
}
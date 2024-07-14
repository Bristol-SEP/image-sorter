using System.Collections.Generic;
using app.ViewModels;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using app.ViewModels.Popup;

namespace app.Model;

public class FeatureList
{
    //TODO resolve the null reference occuring on this page
    /// <summary>
    /// Holds a reference to the <see cref="PopupMainPageViewModel"/>
    /// </summary>
    public IPopupMainPageViewModel MainView { get; private set; }
    
    /// <summary>
    /// A list of <see cref="FeatureGroup"/> that can be used
    /// for the popup
    /// </summary>
    public List<FeatureGroup> FeatureGroups { get; } 

    public FeatureList()
    {
        var rowingFeatures = new List<Feature>
        {
            new("Boat Code", new PopupBoatNumberViewModel(MainView)),
            new("Bow Number", new PopupBowNumberViewModel(MainView))
        };
        var rowing = new FeatureGroup("Rowing", rowingFeatures);
        FeatureGroups= new List<FeatureGroup>
        {
            rowing
        };
        MainView = new PopupMainPageViewModel(FeatureGroups, new FolderStructureDisplayViewModel());
    }

    /// <summary>
    /// Sets the context for the <see cref="PopupMainPageViewModel"/>
    /// </summary>
    /// <param name="folderViewModel">Instance of the <see cref="FolderStructureDisplayViewModel"/></param>
    public void MainViewContext(IFolderStructureDisplayViewModel folderViewModel)
    {
        MainView = new PopupMainPageViewModel(FeatureGroups, folderViewModel);
        var rowingFeatures = new List<Feature>
        {
            new("Boat Code", new PopupBoatNumberViewModel(MainView)),
            new("Bow Number", new PopupBowNumberViewModel(MainView))
        };
        var rowing = new FeatureGroup("Rowing", rowingFeatures);
        FeatureGroups.Add(rowing);
    }
}
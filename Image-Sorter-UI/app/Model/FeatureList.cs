using System.Collections.Generic;
using app.ViewModels.Popup;

namespace app.Model;

public class FeatureList
{
    public List<FeatureGroup> FeatureGroups { get; } 

    public FeatureList()
    {
        var rowingFeatures = new List<Feature>
        {
            new("Boat Code", new PopupBoatNumberViewModel()),
            new("Bow Number", new PopupBowNumberViewModel())
        };
        var rowing = new FeatureGroup("Rowing", rowingFeatures);
        FeatureGroups= new List<FeatureGroup>
        {
            rowing
        };
        
    }
}
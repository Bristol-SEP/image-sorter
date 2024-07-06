using System.Collections.Generic;

namespace app.Model;

public class FeatureList
{
    public List<FeatureGroup> FeatureGroups { get; } 

    public FeatureList()
    {
        var rowingFeatures = new List<Feature>
        {
            new("Boat Code"),
            new("Race Number")
        };
        var rowing = new FeatureGroup("Rowing", rowingFeatures);
        FeatureGroups= new List<FeatureGroup>
        {
            rowing
        };
        
    }
}
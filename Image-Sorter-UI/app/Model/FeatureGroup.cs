using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace app.Model;

public class FeatureGroup
{
    public List<string> Features { get; } 
    public string GroupName { get; set; }
    
    public FeatureGroup(string groupName, List<string> featureList)
    {
        GroupName = groupName;
        Features= featureList;
    }
}
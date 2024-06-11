using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace app.Model;

public class FeatureGroup
{
    /// <summary>
    /// The features related to the group
    /// </summary>
    public List<string> Features { get; } 
    
    /// <summary>
    /// The name of the group
    /// </summary>
    public string GroupName { get; set; }
    
    /// <summary>
    /// Creates an instance of FeatureGroup
    /// </summary>
    /// <param name="groupName">Name of group</param>
    /// <param name="featureList">A <see cref="List{T}">list</see> of the features related to that group</param>
    public FeatureGroup(string groupName, List<string> featureList)
    {
        GroupName = groupName;
        Features= featureList;
    }
}
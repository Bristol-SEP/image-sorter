using System.Collections;
using System.Collections.Generic;

namespace app.Model;

public class FeatureGroup 
{
    /// <summary>
    /// A collection of <see cref="Features"/> related to the group
    /// </summary>
    public List<Feature> Features { get; } 
    
    /// <summary>
    /// The name of the group
    /// </summary>
    public string GroupName { get; set; }
    
    /// <summary>
    /// Creates an instance of FeatureGroup
    /// </summary>
    /// <param name="groupName">Name of group</param>
    /// <param name="featureList">A <see cref="List{T}">list</see> of the features related to that group</param>
    public FeatureGroup(string groupName, List<Feature> featureList)
    {
        GroupName = groupName;
        Features = featureList;
    }

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}
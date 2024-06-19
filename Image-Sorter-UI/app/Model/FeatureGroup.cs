using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    /// Checks if feature group has any elements selected to decide
    /// where expander should expand
    /// </summary>
    public bool ShouldExpand => Features.Any(feature => feature.Selected);
    
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
}
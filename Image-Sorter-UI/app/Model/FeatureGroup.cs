using System.Collections.ObjectModel;

namespace app.Model;

public class FeatureGroup
{
    public ObservableCollection<string> FeatureList => new();
    public string GroupName { get; set; }

    public FeatureGroup(string groupName)
    {
        GroupName = groupName;
    }

    public void AddFeature(string feature)
    {
        FeatureList.Add(feature);
    }
}
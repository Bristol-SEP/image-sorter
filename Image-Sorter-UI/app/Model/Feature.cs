namespace app.Model;

/// <summary>
/// An object consisting of a <see cref="Name"/> and <see cref="Selected"/>.
/// To be used in collaboration with each feature that can be extracted from an image with
/// the python script
/// </summary>
public class Feature
{
    /// <summary>
    /// The name of the feature
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// A <see cref="bool"/> which is true when this feature is selected
    /// </summary>
    public bool Selected { get; private set; }

    /// <summary>
    /// Creates a new <see cref="Feature"/>
    /// </summary>
    /// <param name="name">The name of the feature</param>
    public Feature(string name)
    {
        Name = name;
        Selected = false;
    }

    /// <summary>
    /// Toggles the <see cref="Selected"/> to help select features
    /// </summary>
    public void ToggleSelected()
    {
        Selected = !Selected;
    }
}
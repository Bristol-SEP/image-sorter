using System.Security.Cryptography;

namespace app.Model;

public class Feature
{
    public string Name { get; }
    public bool Selected { get; set; } = false;

    public Feature(string name)
    {
        Name = name;
    }

    public void ToggleSelected()
    {
        Selected = !Selected;
    }
}
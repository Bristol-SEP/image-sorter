using System;

namespace app.Model;

public class Feature
{
    public string Name { get; }
    public bool Selected { get; private set; }

    public Feature(string name)
    {
        Name = name;
        Selected = false;
    }

    public void ToggleSelected()
    {
        Selected = !Selected;
    }
}
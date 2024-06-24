using System;

namespace app.Model;

public class SelectFolders
{
    /// <summary>
    /// The name of the folder
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The absolute path of the folder
    /// </summary>
    public string Path { get; }
    
    /// <summary>
    /// Creating an instance of SelectFolder datatype
    /// </summary>
    /// <param name="name">folder name</param>
    /// <param name="path">folder path</param>
    public SelectFolders(string name, string path)
    {
        Name = name;
        Path = path;
    }
}
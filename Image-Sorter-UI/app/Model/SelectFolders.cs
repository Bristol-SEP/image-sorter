using System;

namespace app.Model;

public class SelectFolders
{
    /// <summary>
    /// The name of the folder
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// The <see cref="Uri"/> path of the folder
    /// </summary>
    public Uri Path { get; }
    
    /// <summary>
    /// Creating an instance of SelectFolder datatype
    /// </summary>
    /// <param name="name">folder name</param>
    /// <param name="path">folder path</param>
    public SelectFolders(string name, Uri path)
    {
        Name = name;
        Path = path;
    }
}
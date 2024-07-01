namespace app.Model;

/// <summary>
/// A datatype which holds a folder and a level
/// </summary>
public class DirectoryItem
{
    /// <summary>
    /// An instance of <see cref="SelectFolders"/>
    /// </summary>
    public SelectFolders Folder { get; }
    
    /// <summary>
    /// The level within the folder structure (each subfolder +1)
    /// </summary>
    public int Level { get; }

    public DirectoryItem(SelectFolders folder, int level)
    {
        Folder = folder;
        Level = level;
    }
}
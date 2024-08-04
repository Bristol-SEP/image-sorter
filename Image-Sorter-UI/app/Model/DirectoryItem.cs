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
    public int Level { get; private set; }

    /// <summary>
    /// Is true if the folder is a feature and so has the ability to be deleted
    /// </summary>
    public bool IsFeature { get; }

    public DirectoryItem(SelectFolders folder, int level)
    {
        Folder = folder;
        Level = level;
        IsFeature = false;
    }

    public DirectoryItem(SelectFolders folder, int level, bool isFeature)
    {
        Folder = folder;
        Level = level;
        IsFeature = isFeature;
    }

    /// <summary>
    /// Adds 1 to the level of the item
    /// </summary>
    public void IndentFolder()
    {
        Level++;
    }
    
    /// <summary>
    /// Removes 1 to the level of the item
    /// </summary>
    public void DedentFolder()
    {
        Level--;
    }
}
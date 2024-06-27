using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace app.Model;

/// <summary>
/// A model with creates a <see cref="FolderDictionary"/>, showing the different subfolders
/// and their levels
/// </summary>
public class DirectoryPriorityList
{
    /// <summary>
    /// A <see cref="Dictionary{TKey,TValue}">Dictionary</see> which holds
    /// the selected folders and their subfolders in the form
    /// (<see cref="SelectFolders">Folder</see>, <see cref="int">priorityLevel</see>)
    /// Where priority level is the level of subfolder
    /// </summary>
    public readonly Dictionary<SelectFolders, int> FolderDictionary = new();

    /// <summary>
    /// Looks at the folder and adds its children (recursively in order with priority levels)
    /// to <see cref="FolderDictionary"/>
    /// </summary>
    /// <param name="folder">The folder whose children will be added</param>
    private void AddChildren(SelectFolders folder)
    {
        var rootPath = folder.Path;
        var directories = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
        foreach (var directory in directories)
        {
            var folderName = directory[(directory.LastIndexOf('/')+1)..];
            if (folderName[0] == '.' || folderName == "error") return;
            var newFolder = new SelectFolders(folderName, directory);
            var priorityLevel = FolderDictionary[folder];
            FolderDictionary.Add(newFolder, priorityLevel+1);
            AddChildren(newFolder);
        }
    }
    
    /// <summary>
    /// Creates a <see cref="FolderDictionary"/> holding all folders in the folder list
    /// and their children
    /// </summary>
    /// <param name="foldersList">A list of folders to be added</param>
    public DirectoryPriorityList(ObservableCollection<SelectFolders> foldersList)
    {
        foreach (var folder in foldersList)   
        {
           FolderDictionary.Add(folder, 0); 
           AddChildren(folder);
        }
    }
}
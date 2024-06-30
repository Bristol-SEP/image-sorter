using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using app.ViewModels;
using ReactiveUI;

namespace app.Model;

/// <summary>
/// A model with creates a <see cref="FolderDictionary"/>, showing the different subfolders
/// and their levels
/// </summary>
public class DirectoryPriorityList: ViewModelBase
{
    private ObservableCollection<DirectoryItem> _folderDictionary = new();

    /// <summary>
    /// A <see cref="Dictionary{TKey,TValue}">Dictionary</see> which holds
    /// the selected folders and their subfolders in the form
    /// (<see cref="SelectFolders">Folder</see>, <see cref="int">priorityLevel</see>)
    /// Where priority level is the level of subfolder
    /// </summary>
    public ObservableCollection<DirectoryItem> FolderDictionary
    {
        get => _folderDictionary;
        set => this.RaiseAndSetIfChanged(ref _folderDictionary, value);
    }

    /// <summary>
    /// Looks at the folder and adds its children (recursively in order with priority levels)
    /// to <see cref="FolderDictionary"/>
    /// </summary>
    /// <param name="folder">The folder whose children will be added</param>
    private void AddChildren(DirectoryItem folder)
    {
        var rootPath = folder.Folder.Path;
        var directories = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
        foreach (var directory in directories)
        {
            var folderName = directory[(directory.LastIndexOf('/')+1)..];
            if (folderName[0] == '.') continue;
            var newFolder = new SelectFolders(folderName, directory);
            var newItem = new DirectoryItem(newFolder, folder.Level + 1);
            FolderDictionary.Add(newItem);
            AddChildren(newItem);
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
            var item = new DirectoryItem(folder, 0);
           FolderDictionary.Add(item); 
           AddChildren(item);
        }
    }
}
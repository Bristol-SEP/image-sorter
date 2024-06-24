using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia;

namespace app.Model;

public class DirectoryPriorityList
{
    public readonly Dictionary<SelectFolders, int> FolderDictionary = new Dictionary<SelectFolders, int>();

    private void AddChildren(SelectFolders folder)
    {
        var rootPath = folder.Path;
        var directories = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
        foreach (var directory in directories)
        {
            var folderName = directory.Substring(directory.LastIndexOf('/')+1);
            if (folderName[0] == '.' || folderName == "error") return;
            var newFolder = new SelectFolders(folderName, directory);
            var priorityLevel = FolderDictionary[folder];
            FolderDictionary.Add(newFolder, priorityLevel+1);
            AddChildren(newFolder);
        }
    }
    
    public DirectoryPriorityList(ObservableCollection<SelectFolders> foldersList)
    {
        foreach (var folder in foldersList)   
        {
           FolderDictionary.Add(folder, 0); 
           AddChildren(folder);
        }
    }
}
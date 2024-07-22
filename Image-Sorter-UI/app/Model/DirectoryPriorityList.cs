using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using app.Model.Interfaces;
using app.ViewModels;
using DynamicData;
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
    /// Adds the new feature into <see cref="FolderDictionary"/>
    /// </summary>
    /// <param name="pos">Where the effected folder is located</param>
    /// <param name="featureFolder"></param>
    private void AddFeatureFolder(int pos, IFeatureFolderDetails featureFolder)
    {
        if(FolderDictionary[pos+1].Folder.Name == featureFolder.FolderName) return;
        var firstHalf = FolderDictionary.Where(feature =>
            FolderDictionary.IndexOf(feature) <= pos).ToList();
        var selectFolder = new SelectFolders(featureFolder.FolderName, firstHalf[pos].Folder.Path);
        var level = firstHalf[pos].Level + 1;
        var featureItem = new DirectoryItem(selectFolder, firstHalf[pos].Level + 1, true);
        firstHalf.Add(featureItem);
        for (var i = pos + 1; i < FolderDictionary.Count; i++)
        {
           var item = FolderDictionary[i];
           if(FolderDictionary[i].Level >= level) item.IndentFolder();
           firstHalf.Add(item);
        }
        
        FolderDictionary = new ObservableCollection<DirectoryItem>() { firstHalf };
    }

    /// <summary>
    /// Takes item and appends the structure of the directory list so the feature
    /// appears in the list
    /// </summary>
    /// <param name="item">The <see cref="IFeatureFolderDetails"/> to be added to structure</param>
    public void AddFeature(IFeatureFolderDetails item)
    {
        foreach (var folder in FolderDictionary)
        {
            var level = folder.Level;
            if (item.AffectedFolders.Contains(folder))
            {
               AddFeatureFolder(FolderDictionary.IndexOf(folder), item); 
            }
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
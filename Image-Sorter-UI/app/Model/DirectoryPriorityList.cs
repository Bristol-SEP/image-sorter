using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using app.Model.Interfaces;
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
    /// Adds the new feature into <see cref="FolderDictionary"/>
    /// </summary>
    /// <param name="pos">Where the effected folder is located</param>
    /// <param name="list">The list to alter and return</param>
    /// <param name="name">The name of the folder to be added</param>
    private List<DirectoryItem> AddFeatureFolder(int pos, IList<DirectoryItem> list, string name)
    {
        var selectFolder = new SelectFolders(name, list[pos].Folder.Path);
        var level = list[pos].Level + 1;
        var featureItem = new DirectoryItem(selectFolder, list[pos].Level + 1, true);
        var newList = list.Where(feature =>
            list.IndexOf(feature) <= pos).ToList();
        newList.Add(featureItem);
        if (pos == (list.Count - 1)) return newList;
        if(list[pos+1].Folder.Name == name) return list.ToList();
        for (var i = pos + 1; i < list.Count; i++)
        {
            var item = list[i];
            if(list[i].Level >= level) item.IndentFolder();
            else
            {
                var secondHalf = list.Where(feature =>
                    list.IndexOf(feature) >= i);
                newList.AddRange(secondHalf);
                break;
            }
            newList.Add(item);
        }

        return newList;
    }

    /// <summary>
    /// Takes item and appends the structure of the directory list so the feature
    /// appears in the list
    /// </summary>
    /// <param name="item">The <see cref="IFeatureFolderDetails"/> to be added to structure</param>
    /// <param name="name">The name of the folders to be added to structure</param>
    public void AddFeature(string name, List<DirectoryItem> item)
    {
        var list = FolderDictionary.ToList();
        foreach (var directoryItem in FolderDictionary)
        {
            if (item.Contains(directoryItem))
            {
                list = AddFeatureFolder(list.IndexOf(directoryItem), list, name);
            }
        }
        FolderDictionary = new ObservableCollection<DirectoryItem>(list);
    }

    /// <summary>
    /// Takes item and appends the structure of the directory list so the feature
    /// is removed from the list
    /// </summary>
    /// <param name="item">The <see cref="DirectoryItem"/> to be deleted from the structure</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void DeleteFeature(DirectoryItem item)
    {
        var pos = FolderDictionary.IndexOf(item);
        var level = item.Level;
        var list = FolderDictionary.Where(feature =>
            FolderDictionary.IndexOf(feature) < pos).ToList();
        for (var i = pos+1; i < FolderDictionary.Count; i++)
        {
            var folder = FolderDictionary[i];
            if(FolderDictionary[i].Level >= level) folder.DedentFolder();
            else
            {
                var secondHalf = FolderDictionary.Where(feature =>
                    FolderDictionary.IndexOf(feature) >= i);
                list.AddRange(secondHalf);
                break;
            }
            list.Add(folder);
        }
        FolderDictionary = new ObservableCollection<DirectoryItem>(list );
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
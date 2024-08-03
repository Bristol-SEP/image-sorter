using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace app.Model.Interfaces;

public interface IDirectoryPriorityList
{
    /// <summary>
    /// A <see cref="Dictionary{TKey,TValue}">Dictionary</see> which holds
    /// the selected folders and their subfolders in the form
    /// (<see cref="SelectFolders">Folder</see>, <see cref="int">priorityLevel</see>)
    /// Where priority level is the level of subfolder
    /// </summary>
    public ObservableCollection<DirectoryItem> FolderDictionary { get; set; }

    /// <summary>
    /// Takes item and appends the structure of the directory list so the feature
    /// appears in the list
    /// </summary>
    /// <param name="item">The <see cref="IFeatureFolderDetails"/> to be added to structure</param>
    /// <param name="name">The name of the folders to be added to structure</param>
    public void AddFeature(string name, List<DirectoryItem> item);

    /// <summary>
    /// Takes item and appends the structure of the directory list so the feature
    /// is removed from the list
    /// </summary>
    /// <param name="item">The <see cref="DirectoryItem"/> to be deleted from the structure</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void DeleteFeature(DirectoryItem item);
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.Model.Interfaces;
using DynamicData;

namespace Image_Sorter_UI.Mock.Model;

public class MockDirectoryPriorityList: IDirectoryPriorityList
{
    public ObservableCollection<DirectoryItem> FolderDictionary { get; set; } = new()
    {
        new DirectoryItem(new SelectFolders("test", "path"), 1)
    };
    public void AddFeature(string name, List<DirectoryItem> item)
    {
        foreach (var folder in item)
        {
            FolderDictionary.Add(folder);
        }
    }

    public void DeleteFeature(DirectoryItem item)
    {
        FolderDictionary.Remove(item);
    }
}
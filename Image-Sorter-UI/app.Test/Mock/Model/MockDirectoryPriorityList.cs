using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Model.Interfaces;

namespace Image_Sorter_UI.Mock.Model;

public class MockDirectoryPriorityList: IDirectoryPriorityList
{
    public ObservableCollection<DirectoryItem> FolderDictionary { get; set; } = new()
    {
        new DirectoryItem(new SelectFolders("test", "path"), 1)
    };
    public void AddFeature(string name, List<DirectoryItem> item)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteFeature(DirectoryItem item)
    {
        throw new System.NotImplementedException();
    }
}
using System.Collections.ObjectModel;
using app.Model;
using app.Model.Interfaces;

namespace Image_Sorter_UI.Mock.Model;

public class MockFeatureFolder: IFeatureFolderDetails
{
    public string FolderName { get; private set; } = "test feature";
    public bool Active { get; private set; }
    public ObservableCollection<DirectoryItem> AffectedFolders { get; } = new()
    {
        new DirectoryItem(new SelectFolders("test", "path"), 1)
    };
    public string ShellScript => "test";
    public void DeleteAffectedFolders(DirectoryItem folder)
    {
        if (AffectedFolders.Contains(folder)) AffectedFolders.Remove(folder);
    }

    public void RunShellScript()
    {
        FolderName = "ran";
    }

    public void Activate()
    {
        Active = true;
    }
}
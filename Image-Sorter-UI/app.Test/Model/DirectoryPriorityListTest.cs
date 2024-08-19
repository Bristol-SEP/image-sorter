using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class DirectoryPriorityListTest
{
    [Test]
    public void SetAndGetTest()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var folder1 = new SelectFolders("Folder1",  path + "/FolderStructure/Folder1");
        var folder2 = new SelectFolders("Folder2",  path + "/FolderStructure/Folder2");
        var folderStructure = new SelectFolders("FolderStructure",  path + "/FolderStructure");
        ObservableCollection<SelectFolders> folders = new() { folder1, folder2 };
        var model = new DirectoryPriorityList(folders);
        //no subfolders
        Assert.Multiple(() =>
        {
            Assert.That(model.FolderDictionary.Count, Is.EqualTo(2));
            Assert.That(model.FolderDictionary[0].Level, Is.EqualTo(0));
            Assert.That(model.FolderDictionary[1].Level, Is.EqualTo(0));
        });
        folders = new ObservableCollection<SelectFolders> { folderStructure };
        model = new DirectoryPriorityList(folders);
        Assert.Multiple(() =>
        {
            Assert.That(model.FolderDictionary.Count, Is.EqualTo(3));
            Assert.That(model.FolderDictionary[0].Folder.Name, Is.EqualTo("FolderStructure"));
            Assert.That(model.FolderDictionary[0].Level, Is.EqualTo(0));
            Assert.That(model.FolderDictionary[1].Level, Is.EqualTo(1));
            Assert.That(model.FolderDictionary[2].Level, Is.EqualTo(1));
        });
    }

    [Test]
    public void AddFeatureTest()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var folder1 = new SelectFolders("Folder1",  path + "/FolderStructure/Folder1");
        var folderStructure = new SelectFolders("FolderStructure",  path + "/FolderStructure");
        ObservableCollection<SelectFolders> folders = new() { folder1 };
        var model = new DirectoryPriorityList(folders);
        model.AddFeature("Boat Code", new List<DirectoryItem>(){model.FolderDictionary[0]}, true);
        Assert.Multiple(() =>
        {
            Assert.That(model.FolderDictionary.Count, Is.EqualTo(2));
            Assert.That(model.FolderDictionary[1].Folder.Name, Is.EqualTo("Boat Code"));
        });
        model.AddFeature("Boat Code", new List<DirectoryItem>(){model.FolderDictionary[0]}, true);
        Assert.That(model.FolderDictionary.Count, Is.EqualTo(2));
        
    }
    
    [Test]
    public void DeleteFeatureTest()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var folderStructure = new SelectFolders("FolderStructure",  path + "/FolderStructure");
        var folderStructure2 = new SelectFolders("FolderStructure2",  path + "/FolderStructure2");
        var folders = new ObservableCollection<SelectFolders> { folderStructure, folderStructure2 };
        var model = new DirectoryPriorityList(folders);
        Assert.Multiple(() =>
        {
            Assert.That(model.FolderDictionary.Count, Is.EqualTo(4));
            Assert.That(model.FolderDictionary[0].Level, Is.EqualTo(0));
            Assert.That(model.FolderDictionary[1].Level, Is.EqualTo(1));
            Assert.That(model.FolderDictionary[2].Level, Is.EqualTo(1));
            Assert.That(model.FolderDictionary[3].Level, Is.EqualTo(0));
        });
        model.DeleteFeature(model.FolderDictionary[0]);
        Assert.Multiple(() =>
        {
            Assert.That(model.FolderDictionary.Count, Is.EqualTo(3));
            Assert.That(model.FolderDictionary[0].Level, Is.EqualTo(0));
            Assert.That(model.FolderDictionary[1].Level, Is.EqualTo(0));
            Assert.That(model.FolderDictionary[2].Level, Is.EqualTo(0));
        });
    }
}
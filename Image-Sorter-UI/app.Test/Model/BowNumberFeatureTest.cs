using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class BowNumberFeatureTest
{
    [Test]
    public void SetupTest()
    {
        var model = new BowNumberFeature();
        Assert.Multiple(() =>
        {
            Assert.That(model.Active, Is.False);
            Assert.That(model.AffectedFolders, Is.Empty);
            Assert.That(model.FolderName, Is.Not.Null);
            Assert.That(model.ShellScript, Is.Not.Null);
        });
    }

    [Test]
    public void AddAffectedFoldersTest()
    {
        var model = new BowNumberFeature();
        var folders = new List<DirectoryItem>()
        {
            new DirectoryItem(new SelectFolders("test", "folder"), 1)
        };
        model.AddAffectedFolders(folders, true, 10);
        Assert.Multiple(() =>
        {
            Assert.That(model.AffectedFolders.Contains(folders[0]), Is.True);
            Assert.That(model.Active, Is.True);
            Assert.That(model.BowNumberFolders.Count, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void DeleteAffectedFoldersTest()
    {
        var folders = new List<DirectoryItem>()
        {
            new DirectoryItem(new SelectFolders("test", "folder"), 1)
        };
        var model = new BowNumberFeature()
        {
            AffectedFolders = new ObservableCollection<DirectoryItem>(folders),
            BowNumberFolders = new List<BowNumberDetails>()
            {
                new BowNumberDetails(folders[0], false, 20)
            }
        };
        model.DeleteAffectedFolders(folders[0]);
        Assert.Multiple(() =>
        {
            Assert.That(model.AffectedFolders, Is.Empty);
            Assert.That(model.Active, Is.False);
            Assert.That(model.BowNumberFolders, Is.Empty);
        });
        
    }
}
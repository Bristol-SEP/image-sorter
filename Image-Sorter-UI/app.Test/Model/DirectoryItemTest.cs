using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class DirectoryItemTest
{
    [Test]
    public void Setup()
    {
        var folder = new SelectFolders("test", "path");
        var model = new DirectoryItem(folder, 1);
        Assert.Multiple(() =>
        {
            Assert.That(model.Folder, Is.EqualTo(folder));
            Assert.That(model.Level, Is.EqualTo(1));
            Assert.That(model.IsFeature, Is.False);
        });
        model = new DirectoryItem(folder, 1, true);
        Assert.That(model.IsFeature, Is.True);
        
        
    }

    [Test]
    public void DedentFolder()
    {
        var folder = new SelectFolders("test", "path");
        var model = new DirectoryItem(folder, 1);
        model.DedentFolder();
        Assert.That(model.Level, Is.EqualTo(0));
    }
    
    [Test]
    public void IndentFolder()
    {
        var folder = new SelectFolders("test", "path");
        var model = new DirectoryItem(folder, 1);
        model.IndentFolder();
        Assert.That(model.Level, Is.EqualTo(2));
    }
}
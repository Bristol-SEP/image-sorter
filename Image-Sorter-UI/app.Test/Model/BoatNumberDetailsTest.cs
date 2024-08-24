using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class BoatNumberDetailsTest
{
    [Test]
    public void SetupTest()
    {
        var directoryItem = new DirectoryItem(new SelectFolders("test", "path"), 1);
        var selected = new SelectFolders("test2", "path2");
        var folderName = "test name";
        var model = new BoatNumberDetails(directoryItem, selected, folderName);
        Assert.Multiple(() =>
        {
            Assert.That(model.AffectedFolder, Is.EqualTo(directoryItem));
            Assert.That(model.TargetFolder, Is.EqualTo(selected));
            Assert.That(model.FolderName, Is.EqualTo(folderName));
        });
    }
}
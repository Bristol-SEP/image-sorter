using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class BowNumberDetailsTest
{
    [Test]
    public void SetupTest()
    {
        var directoryItem = new DirectoryItem(new SelectFolders("test", "path"), 1);
        var model = new BowNumberDetails(directoryItem, false, 10);
        Assert.Multiple(() =>
        {
            Assert.That(model.AffectedFolder, Is.EqualTo(directoryItem));
            Assert.That(model.BoatsPerFolder, Is.EqualTo(10));
            Assert.That(model.IsIndividualFolder, Is.False);
        });
    }
}
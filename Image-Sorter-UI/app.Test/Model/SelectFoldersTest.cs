using System;
using System.IO;
using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class SelectFoldersTest
{
    [Test]
    public void SetAndGetTest()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        if (path == null) return;
        var selectFolder = new SelectFolders("test", path);
        Assert.Multiple(() =>
        {
            Assert.That(selectFolder.Name, Is.EqualTo("test"));
            Assert.That(selectFolder.Path, Is.EqualTo(path));
        });
    }
}
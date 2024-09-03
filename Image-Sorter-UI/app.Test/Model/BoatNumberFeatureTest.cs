using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class BoatNumberFeatureTest
{
     [Test]
     public void SetupTest()
     {
         var model = new BoatNumberFeature();
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
         var model = new BoatNumberFeature();
         var folders = new List<DirectoryItem>()
         {
             new DirectoryItem(new SelectFolders("test", "folder"), 1)
         };
         model.AddAffectedFolders(folders, new SelectFolders("test", "path"), "test folder");
         Assert.Multiple(() =>
         {
             Assert.That(model.AffectedFolders.Contains(folders[0]), Is.True);
             Assert.That(model.Active, Is.True);
         });
     }
     
     [Test]
     public void DeleteAffectedFoldersTest()
     {
         var folders = new List<DirectoryItem>()
         {
             new(new SelectFolders("test", "folder"), 1)
         };
         var model = new BoatNumberFeature()
         {
             AffectedFolders = new ObservableCollection<DirectoryItem>(folders),
             BoatNumberFolder = new List<BoatNumberDetails>
             {
                 new(
                     folders[0], folders[0].Folder, "test folder")
             }
         };
         
         model.DeleteAffectedFolders(folders[0]);
         {
             Assert.That(model.AffectedFolders, Is.Empty);
             Assert.That(model.BoatNumberFolder, Is.Empty);
             Assert.That(model.Active, Is.False);
         }
     }   
}
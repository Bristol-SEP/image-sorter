using System;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class FolderStructureDisplayViewModelTest
{
   private readonly MockViewModelProvider _vmProvider = new();

   [Test]
   public void SetupTest()
   {
      var viewModel = new FolderStructureDisplayViewModel();
      Assert.Multiple(() =>
      {
         Assert.That(viewModel.FolderDirectories, Is.Not.Null);
         Assert.That(viewModel.ShowPopup, Is.False);
         Assert.That(viewModel.FeatureList, Is.Not.Null);
         Assert.That(viewModel.FeatureFolderList, Is.Not.Null);
         Assert.That(viewModel.FeatureFolderDetailsList, Is.Not.Null);
      });
   }
   
   [Test] 
   public void ButtonPressedTest()
   {
      var mainViewModel = _vmProvider.GetMainViewModel();
      IFolderStructureDisplayViewModel viewModel = new FolderStructureDisplayViewModel();
      Assert.Throws<NullReferenceException>((() => viewModel.ButtonPressed()));
      viewModel.SetMainViewModel(mainViewModel);
      var pageHeld = mainViewModel.CurrentPage;
      Assert.Throws<InvalidOperationException>((() => viewModel.ButtonPressed()));
      mainViewModel.ToggleView();
      viewModel.ButtonPressed();
      Assert.Multiple((() =>
      {
         Assert.That(mainViewModel.CurrentPage, Is.EqualTo(pageHeld));
         Assert.That(mainViewModel.IsImagePage, Is.True);
      }));
   }

   [Test]
   public void FolderDirectoriesTest()
   {
      IFolderStructureDisplayViewModel viewModel = new FolderStructureDisplayViewModel();
      Assert.That(viewModel.FolderDirectories.FolderDictionary, Is.Empty);
   }

   [Test]
   public void AddFeatureTest()
   {
      var viewModel = new FolderStructureDisplayViewModel();
      var folder = new SelectFolders("test", "path");
      var directoryItem = new DirectoryItem(folder, 1);
      viewModel.AddFeature(directoryItem);
      Assert.Multiple(() =>
      {
         Assert.That(viewModel.ShowPopup, Is.True);
         Assert.That(viewModel.FeatureFolderList, Contains.Item(directoryItem));
      });
   }

   [Test]
   public void UpdateFeatureFolderListTest()
   {
      var viewModel = new FolderStructureDisplayViewModel();
      // write after refactor of boatcode page 
   }

   [Test]
   public void RemoveFeatureTest()
   {
      // write after refactor of boatcode page
   }
}
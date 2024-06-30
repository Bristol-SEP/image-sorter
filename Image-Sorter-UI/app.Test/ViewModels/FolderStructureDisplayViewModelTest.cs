using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
}
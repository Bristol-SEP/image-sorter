using System;
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
      IMainWindowViewModel mainViewModel = _vmProvider.GetMainViewModel();
      IFolderStructureDisplayViewModel viewModel = new FolderStructureDisplayViewModel();
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
}
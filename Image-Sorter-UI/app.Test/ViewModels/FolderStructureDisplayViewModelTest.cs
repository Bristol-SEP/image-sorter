using System;
using app.ViewModels;
using app.ViewModels.Interfaces;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class FolderStructureDisplayViewModelTest
{
   [Test] 
   public void ButtonPressedTest()
   {
      IMainWindowViewModel mainViewModel = new MainWindowViewModel();
      IFolderStructureDisplayViewModel viewModel = new FolderStructureDisplayViewModel(mainViewModel);
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
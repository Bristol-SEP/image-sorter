using app.ViewModels;
using app.ViewModels.Interfaces;
using Image_Sorter_UI.Mocks.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class FolderStructureDisplayViewModelTest
{
   [Test] 
   public void ButtonPressedTest()
   {
      IMainWindowViewModel mainViewModel = new MockMainWindowViewModel();
      IFolderStructureDisplayViewModel viewModel = new FolderStructureDisplayViewModel(mainViewModel);
      Assert.That(viewModel.ButtonPressed, Is.True);
   }
}
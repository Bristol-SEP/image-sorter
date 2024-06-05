using app.ViewModels;
using app.ViewModels.Interfaces;
using Image_Sorter_UI.Mocks.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class AddImageDisplayViewModelTest
{
   [Test]
   public void ButtonPressedTest()
   {
      IMainWindowViewModel mainViewModel = new MockMainWindowViewModel();
      IAddImageDisplayViewModel viewModel = new AddImageDisplayViewModel(mainViewModel);
      Assert.That(viewModel.ButtonPressed, Is.True);
   }
}
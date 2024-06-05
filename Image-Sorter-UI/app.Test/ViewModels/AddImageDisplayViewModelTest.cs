using System;
using app.ViewModels;
using app.ViewModels.Interfaces;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class AddImageDisplayViewModelTest
{
    [Test]
    public void ButtonPressedTest()
    {
        IMainWindowViewModel mainViewModel = new MainWindowViewModel();
        IAddImageDisplayViewModel viewModel = new AddImageDisplayViewModel(mainViewModel);
        var pageHeld = mainViewModel.CurrentPage;
        viewModel.ButtonPressed();
        Assert.Multiple((() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.Not.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.False);
            Assert.Throws<InvalidOperationException>(() => viewModel.ButtonPressed());
        }));
    }
}
using System;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class AddImageDisplayViewModelTest
{
    private readonly MockViewModelProvider _vmProvider = new();
    [Test]
    public void ButtonPressedTest()
    {
        IMainWindowViewModel mainViewModel = _vmProvider.GetMainViewModel();
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
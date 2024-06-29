using System;
using app.ViewModels;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class MainWindowViewModelTest
{
    private readonly MockViewModelProvider _vmProvider = new();
    [Test]
    public void ConstructorTest()
    {
        var viewModel = new MainWindowViewModel(_vmProvider);
        Console.WriteLine(viewModel.CurrentPage);
        Assert.That(viewModel.CurrentPage, Is.Not.Null);
    }

    [Test]
    public void ToggleViewTest()
    {
        var viewModel = new MainWindowViewModel(_vmProvider);
        var firstPage = viewModel.CurrentPage;
        Assert.Multiple((() =>
        {
            Assert.That(viewModel.IsImagePage, Is.True);
            Assert.AreEqual(firstPage.GetType(), _vmProvider.GetAddImageViewModel().GetType());
        }));
        viewModel.ToggleView();
        var secondPage = viewModel.CurrentPage;
        Assert.That(firstPage, Is.Not.EqualTo(secondPage));
        viewModel.ToggleView();
        Assert.Multiple((() =>
        {
            Assert.That(firstPage, Is.EqualTo(viewModel.CurrentPage));
            Assert.That(secondPage, Is.Not.EqualTo(viewModel.CurrentPage));
            Assert.That(viewModel.IsImagePage, Is.True);
        }));
        viewModel.ToggleView();
        Assert.Multiple((() =>
        {
            Assert.That(firstPage, Is.Not.EqualTo(viewModel.CurrentPage));
            Assert.That(secondPage, Is.EqualTo(viewModel.CurrentPage));
            Assert.That(viewModel.IsImagePage, Is.False);
        }));
    }
}
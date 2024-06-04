using app.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
public class MainWindowViewModelTest
{
    [Test]
    public void ConstructorTest()
    {
        var viewModel = new MainWindowViewModel();
        Assert.That(viewModel.CurrentPage, Is.Not.Null);
    }

    [Test]
    public void ToggleViewTest()
    {
        var viewModel = new MainWindowViewModel();
        var firstPage = viewModel.CurrentPage;
        viewModel.ToggleView();
        var secondPage = viewModel.CurrentPage;
        Assert.That(firstPage, Is.Not.EqualTo(secondPage));
        viewModel.ToggleView();
        Assert.Multiple((() =>
        {
            Assert.That(firstPage, Is.EqualTo(viewModel.CurrentPage));
            Assert.That(secondPage, Is.Not.EqualTo(viewModel.CurrentPage));
        }));
        viewModel.ToggleView();
        Assert.Multiple((() =>
        {
            Assert.That(firstPage, Is.Not.EqualTo(viewModel.CurrentPage));
            Assert.That(secondPage, Is.EqualTo(viewModel.CurrentPage));
        }));
    }
}
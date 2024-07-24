using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using app.ViewModels.Popup;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels.Popup;

[TestFixture]
public class PopupBoatNumberViewModelTest
{
    private readonly IViewModelProvider _vmProvider = new MockViewModelProvider();
    
    [Test]
    public void SetupTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.MainPage, Is.EqualTo(mainPage));
            // TODO remove this feature model for just an affected folders section
            Assert.That(viewModel.FeatureModel.FolderName, Is.EqualTo("Boat Codes"));
            Assert.That(viewModel.FeatureModel.AffectedFolders, Is.Empty);
            Assert.That(viewModel.FolderList, Is.Empty);
        });
    }

    [Test]
    public void AddFolderLevelTest()
    {
        // The FeatureFolderList is too entangled to create these test
    }

    [Test]
    public void SetContextTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        var newMainPage = _vmProvider.GetPopupMainPageViewModel();
        Assert.That(viewModel.MainPage, Is.EqualTo(mainPage));
        viewModel.SetContext(newMainPage);
        Assert.That(viewModel.MainPage, Is.EqualTo(newMainPage));
    }

    [Test]
    public void AddFeatureTest()
    {
        // Write after cleanup
    }

    [Test]
    public void ReturnTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        mainPage.FolderView.View = viewModel;
        viewModel.Return();
        Assert.That(mainPage.FolderView.View, Is.EqualTo(mainPage));
    }

    [Test]
    public void CloseTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        mainPage.FolderView.ShowPopup = true;
        viewModel.Close();
        Assert.Multiple(() =>
        {
            Assert.That(mainPage.FolderView.View, Is.EqualTo(mainPage));
            Assert.That(mainPage.FolderView.ShowPopup, Is.False);
        });
    }
}
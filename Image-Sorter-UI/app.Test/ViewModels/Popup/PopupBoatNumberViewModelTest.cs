using System;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.Model.Interfaces;
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
            Assert.That(viewModel.FolderList, Is.EqualTo("test"));
            Assert.That(viewModel.BoatNumberFeature, Is.TypeOf<BoatNumberFeature>());
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
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        mainPage.FolderView.ShowPopup = true;
        viewModel.FolderName = "test";
        viewModel.AddFeature();
        Assert.That(viewModel.FolderName, Is.EqualTo(""));
    }

    [Test]
    public void AddSearchTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        var folder = new SelectFolders("target", "targetPath");
        Assert.That(viewModel.AffectedFolder, Is.Not.EqualTo(folder));
        viewModel.AddSearch(folder);
        Assert.That(viewModel.AffectedFolder, Is.EqualTo(folder));
    }

    [Test]
    public void ReturnTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        mainPage.FolderView.View = viewModel;
        var folder = new SelectFolders("test", "path");
        var directoryItem = new DirectoryItem(folder, 1);
        mainPage.FolderView.FeatureFolderList = new ObservableCollection<DirectoryItem>() { directoryItem };
        viewModel.Return();
        Assert.That(mainPage.FolderView.View, Is.EqualTo(mainPage));
    }

    [Test]
    public void CloseTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        var folder = new SelectFolders("test", "path");
        var directoryItem = new DirectoryItem(folder, 1);
        mainPage.FolderView.FeatureFolderList = new ObservableCollection<DirectoryItem>() { directoryItem };
        mainPage.FolderView.ShowPopup = true;
        viewModel.Close();
        Assert.Multiple(() =>
        {
            Assert.That(mainPage.FolderView.View, Is.EqualTo(mainPage));
            Assert.That(mainPage.FolderView.ShowPopup, Is.False);
        });
    }

    [Test]
    public void GetModelBasicTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBoatNumberViewModel(mainPage);
        Assert.That(viewModel.GetModelBasic(), Is.TypeOf<BoatNumberFeature>());
    }
}
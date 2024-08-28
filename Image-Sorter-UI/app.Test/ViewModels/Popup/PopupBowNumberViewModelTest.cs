using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces;
using app.ViewModels.Popup;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels.Popup;

[TestFixture]
public class PopupBowNumberViewModelTest
{
    private readonly IViewModelProvider _vmProvider = new MockViewModelProvider();
    
    [Test]
    public void SetupTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBowNumberViewModel(mainPage);
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.MainPage, Is.EqualTo(mainPage));
            Assert.That(viewModel.FolderList, Is.Empty);
            Assert.That(viewModel.BoatsPerFolder, Is.EqualTo(10));
            Assert.That(viewModel.BowNumberFeature, Is.TypeOf<BowNumberFeature>());
            Assert.That(viewModel.IsIndividualFolders, Is.True);
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
        var viewModel = new PopupBowNumberViewModel(mainPage);
        var newMainPage = _vmProvider.GetPopupMainPageViewModel();
        Assert.That(viewModel.MainPage, Is.EqualTo(mainPage));
        viewModel.SetContext(newMainPage);
        Assert.That(viewModel.MainPage, Is.EqualTo(newMainPage));
    }

    [Test]
    public void AddFeatureTest()
    {
        // TODO write test for this function
    }

    [Test]
    public void ReturnTest()
    {
        var mainPage = _vmProvider.GetPopupMainPageViewModel();
        var viewModel = new PopupBowNumberViewModel(mainPage);
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
        var viewModel = new PopupBowNumberViewModel(mainPage);
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
        var viewModel = new PopupBowNumberViewModel(mainPage);
        Assert.That(viewModel.GetModelBasic(), Is.TypeOf<BowNumberFeature>());
    }}
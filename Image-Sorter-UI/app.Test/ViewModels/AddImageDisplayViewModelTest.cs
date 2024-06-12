using System;
using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using Avalonia.Platform.Storage;
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
        var mainViewModel = _vmProvider.GetMainViewModel();
        IAddImageDisplayViewModel viewModel = new AddImageDisplayViewModel();
        Assert.Throws<NullReferenceException>((() => viewModel.ButtonPressed()));
        viewModel.SetMainViewModel(mainViewModel);
        var pageHeld = mainViewModel.CurrentPage;
        viewModel.ButtonPressed();
        Assert.Multiple((() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.Not.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.False);
            Assert.Throws<InvalidOperationException>(() => viewModel.ButtonPressed());
        }));
    }

    private IAddImageDisplayViewModel ViewModel
    {
        get
        {
            var mainViewModel = _vmProvider.GetMainViewModel();
            var viewModel = new AddImageDisplayViewModel();           
            viewModel.SetMainViewModel(mainViewModel);
            return viewModel;
        }
    }
    
    [Test]
    public void FeatureListTest()
    {
        var features = ViewModel.FeatureList;
        Assert.That(features[0].GroupName, Is.EqualTo("Rowing"));
        foreach (var group in features)
        {
           Assert.That(group.Features.Count, Is.Not.EqualTo(0)); 
        }
    }

    //TODO create a IStorageFolder example to test
    [Test]
    public void AddFoldersTest()
    {
        Assert.Multiple((() =>
        {
            Assert.That(ViewModel.FolderList.Count, Is.EqualTo(0));
            Assert.That(ViewModel.FoldersEmpty, Is.True);
        }));
        ViewModel.AddFolders(new List<IStorageFolder>());
        Assert.Multiple((() =>
        {
            Assert.That(ViewModel.FolderList.Count, Is.EqualTo(0));
            Assert.That(ViewModel.FoldersEmpty, Is.True);
        }));
        
    }

    // TODO update this test when IStorageFolder example is implemented
    // TODO make mock URI to be used
    [Test]
    public void RemoveFoldersTest()
    {
        
    }
}
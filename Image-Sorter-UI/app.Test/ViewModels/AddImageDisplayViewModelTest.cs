using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using app.Views;
using Avalonia.Controls;
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
        // setup
        var mainViewModel = _vmProvider.GetMainViewModel();
        IAddImageDisplayViewModel viewModel = new AddImageDisplayViewModel();
        Assert.Throws<NullReferenceException>((() => viewModel.ButtonPressed()));
        viewModel.SetMainViewModel(mainViewModel);
        var pageHeld = mainViewModel.CurrentPage;
        // empty test
        viewModel.ButtonPressed();
        Assert.Multiple(() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.True);
            Assert.That(viewModel.FeaturePrompt, Is.True);
            Assert.That(viewModel.FolderPrompt, Is.True);
        });
        // feature not selected test
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var mock = new SelectFolders("Mock",  new Uri(path + "/Mock"));
        viewModel.FolderList.Add(mock);
        viewModel.ButtonPressed();
        Assert.Multiple(() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.True);
            Assert.That(viewModel.FeaturePrompt, Is.True);
            Assert.That(viewModel.FolderPrompt, Is.False);
        });
        // folder not selected test
        viewModel.FolderList.Remove(mock);
        viewModel.FeatureList[0].Features[0].ToggleSelected();
        viewModel.ButtonPressed();
        Assert.Multiple(() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.True);
            Assert.That(viewModel.FeaturePrompt, Is.False);
            Assert.That(viewModel.FolderPrompt, Is.True);
        });
        // all selected
        viewModel.FolderList.Add(mock);
        viewModel.ButtonPressed();
        Assert.Multiple(() =>
        {
            Assert.That(mainViewModel.CurrentPage, Is.Not.EqualTo(pageHeld));
            Assert.That(mainViewModel.IsImagePage, Is.False);
            Assert.That(viewModel.FeaturePrompt, Is.False);
            Assert.That(viewModel.FolderPrompt, Is.False);
            Assert.Throws<InvalidOperationException>(() => viewModel.ButtonPressed());
        });
    }

    [Test]
    public void FeatureListTest()
    {
        var viewModel = new AddImageDisplayViewModel();
        var features = viewModel.FeatureList;
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
        var viewModel = new AddImageDisplayViewModel();
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.FolderList.Count, Is.EqualTo(0));
            Assert.That(viewModel.FoldersEmpty, Is.True);
        });
        var topLevel = TopLevel.GetTopLevel(new AddImageDisplayView());
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var mockUri = new Uri(path + "/Mock");
        var mock = topLevel?.StorageProvider.TryGetFolderFromPathAsync(mockUri);
        if (mock?.Result != null)
        {
            var list = new ReadOnlyCollection<IStorageFolder>(new List<IStorageFolder>
            {
                mock.Result
            });
            viewModel.AddFolders(list);
        }

        Assert.Multiple(() =>
        {
            Assert.That(viewModel.FolderList.Count, Is.EqualTo(1));
            Assert.That(viewModel.FoldersEmpty, Is.False);
        });
        
    }

    [Test]
    public void RemoveFoldersTest()
    {
        var viewModel = new AddImageDisplayViewModel();
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var mock = new SelectFolders("Mock",  new Uri(path + "/Mock"));
        var view = new SelectFolders("Views", new Uri(path + "/Views"));
        
        viewModel.FolderList.Add(mock);
        viewModel.FolderList.Add(view);
        
        Assert.That(viewModel.FolderList.Count, Is.EqualTo(2));
        
        viewModel.RemoveFolders(mock);
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.FolderList.Count, Is.EqualTo(1));
            Assert.That(viewModel.FolderList.Contains(mock), Is.False);
        });

        viewModel.RemoveFolders(view);
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.FolderList.Count, Is.EqualTo(0));
            Assert.That(viewModel.FolderList.Contains(view), Is.False);
            Assert.That(viewModel.FoldersEmpty, Is.True);
        });
        
        viewModel.RemoveFolders(mock);
        Assert.Multiple(() =>
        {
            Assert.That(viewModel.FolderList.Count, Is.EqualTo(0));
            Assert.That(viewModel.FolderList.Contains(mock), Is.False);
            Assert.That(viewModel.FoldersEmpty, Is.True);
        });
    }
}
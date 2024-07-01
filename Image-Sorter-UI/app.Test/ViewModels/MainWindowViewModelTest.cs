using System;
using System.Collections.Generic;
using System.IO;
using app.Model;
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

    [Test]
    public void AddFoldersTest()
    {
        var mainModel = new MainWindowViewModel(_vmProvider);
        Assert.Multiple(() =>
        {
            Assert.That(mainModel.FolderList.Count, Is.EqualTo(0));
        });
        
        var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
        var mock = new SelectFolders("Mock",  path + "/Mock");
        var view = new SelectFolders("Views", path + "/Views");
        // add single element
        var folderList = new List<SelectFolders> { mock };
        mainModel.AddFolders(folderList);
        Assert.Multiple(() =>
        {
            Assert.That(mainModel.FolderList.Count, Is.EqualTo(1));
            Assert.That(mainModel.FolderList.Contains(mock));
        });
        // add multiple elements
        folderList.Add(view);
        mainModel.AddFolders(folderList);
        Assert.Multiple(() =>
        {
            Assert.That(mainModel.FolderList.Count, Is.EqualTo(2));
            Assert.That(mainModel.FolderList.Contains(mock));
            Assert.That(mainModel.FolderList.Contains(view));
        });
        // parent priority
        if (path == null) return;
        var parent = new SelectFolders("Parent", path);
        folderList = new List<SelectFolders> { parent };
        mainModel.AddFolders(folderList);
        Assert.Multiple(() =>
        {
            Assert.That(mainModel.FolderList.Count, Is.EqualTo(1));
            Assert.That(mainModel.FolderList.Contains(parent));
            Assert.That(!mainModel.FolderList.Contains(view));
            Assert.That(!mainModel.FolderList.Contains(mock));
        });
        folderList = new List<SelectFolders> { mock, view };
        mainModel.AddFolders(folderList);
        Assert.Multiple(() =>
        {
            Assert.That(mainModel.FolderList.Count, Is.EqualTo(1));
            Assert.That(mainModel.FolderList.Contains(parent));
            Assert.That(!mainModel.FolderList.Contains(view));
            Assert.That(!mainModel.FolderList.Contains(mock));
        });
        
    }
}
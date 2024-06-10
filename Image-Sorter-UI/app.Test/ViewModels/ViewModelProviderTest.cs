using app.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels;

[TestFixture]
[NonParallelizable]
public class ViewModelProviderTest
{
    [Test]
    public void SingletonPatternTest()
    {
        var instance1 = ViewModelProvider.Instance;
        var instance2 = ViewModelProvider.Instance;

        Assert.That(instance2, Is.SameAs(instance1));
    }

    [Test]
    public void GetMainViewModelTest()
    {
        var mainViewModel = ViewModelProvider.Instance.GetMainViewModel();
        Assert.That(mainViewModel, Is.InstanceOf<MainWindowViewModel>());
    }

    [Test]
    public void GetAddImageViewModelTest()
    {
        var addImageViewModel = ViewModelProvider.Instance.GetAddImageViewModel();
        Assert.That(addImageViewModel, Is.InstanceOf<AddImageDisplayViewModel>());
    }
    
    [Test]
    public void GetFolderStructureViewModelTest()
    {
        var folderStructureViewModel = ViewModelProvider.Instance.GetFolderStructureViewModel();
        Assert.That(folderStructureViewModel, Is.InstanceOf<FolderStructureDisplayViewModel>());
    }
}
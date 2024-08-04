using app.Model;
using app.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class FeatureTest
{
    [Test]
    public void SetAndGetTest()
    {
        var feature = new Feature("test", new ViewModelBase());
        Assert.Multiple(() =>
        {
            Assert.That(feature.Name, Is.EqualTo("test"));
            Assert.That(feature.Selected, Is.False);
        });
    }

    [Test]
    public void ToggleSelectedTest()
    {
        var feature = new Feature("test", new ViewModelBase());
        Assert.That(feature.Selected, Is.False);
        feature.ToggleSelected();
        Assert.That(feature.Selected, Is.True);
        feature.ToggleSelected();
        Assert.That(feature.Selected, Is.False);
    }
}
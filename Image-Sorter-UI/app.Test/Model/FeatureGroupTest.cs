using System.Collections.Generic;
using app.Model;
using NUnit.Framework;

namespace Image_Sorter_UI.Model;

[TestFixture]
public class FeatureGroupTest
{
    [Test]
    public void SetAndGetTest()
    {
        var featureList = new List<Feature>();
        var featureGroup = new FeatureGroup("testGroup", featureList);
        Assert.Multiple(() =>
        {
            Assert.That(featureGroup.GroupName, Is.EqualTo("testGroup"));
            Assert.That(featureGroup.ShouldExpand, Is.False);
            Assert.That(featureGroup.Features, Is.EqualTo(featureList));
        });
    }

    [Test]
    public void ShouldExpandTest()
    {
        var feature = new Feature("test");
        var featureList = new List<Feature> { feature };
        var featureGroup = new FeatureGroup("testGroup", featureList);
        Assert.That(featureGroup.ShouldExpand, Is.False);
        feature.ToggleSelected();
        Assert.That(featureGroup.ShouldExpand, Is.True);
        feature.ToggleSelected();
        Assert.That(featureGroup.ShouldExpand, Is.False);
    }
}
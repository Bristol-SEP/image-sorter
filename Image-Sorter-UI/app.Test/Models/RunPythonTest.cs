using app.Models;
using NUnit.Framework;

namespace Image_Sorter_UI.Models;

[TestFixture]
public class RunPythonTest
{
   [Test]
   public void RunScriptTest()
   {
      var model = new RunPython();
      Assert.That(model.RunScript(), Is.EqualTo(true));
   }
}
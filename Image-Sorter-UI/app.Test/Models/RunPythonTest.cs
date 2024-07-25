using app.Models;
using NUnit.Framework;

namespace Image_Sorter_UI.Models;

[TestFixture]
public class RunPythonTest
{
   [Test]
   public void RunScriptTest()
   {
      // currently test only checks that a python script can be ran without issues
      // not the outputs or anything
      var model = new RunPython();
      Assert.That(model.RunScript(), Is.EqualTo(true));
   }
}
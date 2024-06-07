using System;
using Python.Runtime;

namespace app.Models;

public class RunPython
{
   public bool RunScript()
   {
      Runtime.PythonDLL = @"C:\usr\local\Cellar\python@3.11\3.11.9\Frameworks\Python.framework\Versions\3.11\lib\libpython3.11.dylib";

      // Initialize engine
      PythonEngine.Initialize();
      
      // Create a scope for the Python code
      using (Py.GIL())
      {
         try
         {
            string pythonScriptPath = @"~/Documents/image-sorter/Image-Sorter-UI/app.Test/Assets";
            PythonEngine.Exec($"import sys; sys.path.append(r'{pythonScriptPath}')");

            // Import python script
            dynamic pyScript = Py.Import("testPython");

            // call function from python script
            dynamic result = pyScript.noParamTest();

            // Print result
            Console.WriteLine($"Result from Python script: {result}");
         }
         catch (Exception e)
         {
            Console.WriteLine(($"An error occurred: {e.Message}"));
         }
         
         // Shutdown the Python engine
         PythonEngine.Shutdown();
         return true;
      }
   }
}
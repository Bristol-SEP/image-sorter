using System;
using System.IO;
using Python.Runtime;

namespace app.Models;

public class RunPython
{
   // TODO set function/class to take in a parameter script and run it with variables (features)
   // test script can be found in app.Test/Assets/testPython
   public bool RunScript()
   {
      // TODO this is where the issue is coming from, cannot find correct DLL and how to package it 
      // so can run on others computers
      // see app.Test/Models/RunPythonTest this is a useful way of running this script in isolation
      // Runtime.PythonDLL = @"C:\Python312\python312.dll";
      // Console.WriteLine("here start");

      // Ensure the Python DLL path is correct
      string pythonDllPath = @"C:\Python312\python312.dll";
      if (!File.Exists(pythonDllPath)){
         Console.WriteLine($"Python DLL not found at {pythonDllPath}");
         return false;
      }

      Runtime.PythonDLL = pythonDllPath;
      Console.WriteLine("Python DLL path set");

      // Set the Python script path
      //Currently the working directory is going from the tests ("Coding Projects\image-sorter\Image-Sorter-UI\app.Test\bin\Debug\net6.0\")
      //The python script is in the app.Test\Assets file
      //For the real thing this will all have to be changed to the relevant files
      string relativePythonScriptPath = @"Assets"; 
      string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
      Console.WriteLine($"Current Directory {currentDirectory}");

      string baseDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\")); 
      Console.WriteLine($"Base Directory {baseDirectory}");

      string pythonScriptPath = Path.Combine(baseDirectory, relativePythonScriptPath);
      Console.WriteLine($"Python Script Directory {pythonScriptPath}");


      if (!Directory.Exists(pythonScriptPath)){
         Console.WriteLine($"Python script directory not found at {pythonScriptPath}");
         return false;
      }



      try{
         // Initialize engine
         PythonEngine.Initialize();
         Console.WriteLine("Python engine initialized");
         
         // Create a scope for the Python code
         using (Py.GIL())
         {
            try
            {
               PythonEngine.Exec($"import sys; sys.path.append(r'{pythonScriptPath}')");
               Console.WriteLine($"Python script path appended: {pythonScriptPath}");

               // Import python script
               dynamic pyScript = Py.Import("testPython");
               Console.WriteLine("Python script imported");

               // call function from python script
               dynamic result = pyScript.noParamTest();
               Console.WriteLine($"Result from Python script: {result}");

               result = pyScript.paramTest(1, 2);
               Console.WriteLine($"Result from Python script: {result}");

               result = pyScript.manyParamTest(1, 2, 3, 4);
               Console.WriteLine($"Result from Python script: {result}");



            }
            catch (Exception e)
            {
               Console.WriteLine($"An error occurred after initalisation: {e.Message}");
               return false;

            }

      }
      }catch (Exception e){
         Console.WriteLine($"An error occurred before initialisation: {e.Message}");
         return false;
      }

      finally{
         // Shutdown the Python engine
         PythonEngine.Shutdown();
         Console.WriteLine("Python engine shutdown");
      }
         
      return true;
         
   }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using app.Model.Interfaces;
using app.ViewModels;
using ReactiveUI;

namespace app.Model;

/// <summary>
/// Holds the details for this feature
/// </summary>
public class BoatNumberFeature: ViewModelBase, IFeatureFolderDetails
{
    /// <summary>
    /// Backing field for <see cref="AffectedFolders"/>
    /// </summary>
    private ObservableCollection<DirectoryItem> _affectedFolders = new();
    
    /// <summary>
    /// A link to the directory where the shell scripts are held
    /// </summary>
    private readonly string _directory = Directory.GetParent(Directory.GetCurrentDirectory())?
        .Parent?.Parent + "/Scripts/";

    /// <summary>
    /// A function to run the shell script
    /// </summary>
    /// <param name="affectedFolder">The path of a folder from <see cref="AffectedFolders"/></param>
    /// <param name="targetFolder">The folder to search through</param>
    /// <param name="folderName">The name for the primary folder</param>
    /// <exception cref="Exception">Occurs if shell script has an error</exception>
    private void RestructureBoatNumbers(string affectedFolder, string targetFolder, string folderName)
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"{ShellScript} \"{affectedFolder}\" \"{targetFolder}\" \"{folderName}\" ",
                WorkingDirectory = _directory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            }
        };
        
        proc.Start();
        
        // Read the output (if needed)
        var output = proc.StandardOutput.ReadToEnd();
        var error = proc.StandardError.ReadToEnd();
             
        // Wait for the process to exit
        proc.WaitForExit();
             
        Console.WriteLine(output);
        
        // Write the error to the console, if any
        if (!string.IsNullOrEmpty(error))
        {
            throw new Exception(error);
        }
    }
    
    /// <inheritdoc/>
    public string FolderName => "Boat Codes";

    /// <inheritdoc/>
    public bool Active { get; private set; }

    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> AffectedFolders
    {
        get => _affectedFolders;
        set => this.RaiseAndSetIfChanged(ref _affectedFolders, value);
    }

    /// <summary>
    /// A list of <see cref="BoatNumberDetails"/> used to display the personalised
    /// features for each folder
    /// </summary>
    public List<BoatNumberDetails> BoatNumberFolder = new();

    /// <inheritdoc/>
    public string ShellScript => "BoatNumberScript.sh";

    /// <summary>
    /// Adds new folders to <see cref="AffectedFolders"/>
    /// </summary>
    /// <param name="folders">Folders to be added</param>
    /// <param name="targetFolder">Folder to be searched through</param>
    /// <param name="folderName">The name of the folder</param>
    public void AddAffectedFolders(IEnumerable<DirectoryItem> folders, DirectoryItem targetFolder, string folderName)
    {
        foreach (var folder in folders.Where(folder => !AffectedFolders.Contains(folder)))
        {
            AffectedFolders.Add(folder);
            BoatNumberFolder.Add(
                new BoatNumberDetails(folder, targetFolder, folderName));
        }

        Active = true;
    }

    /// <inheritdoc/>
    public void DeleteAffectedFolders(DirectoryItem folder)
    {
        AffectedFolders.Remove(folder);
        BoatNumberFolder.Remove(BoatNumberFolder.First(boatNumber => boatNumber.AffectedFolder == folder));
        if (AffectedFolders.Count == 0) Active = false;
    }

    public void RunShellScript()
    {
        foreach (var folder in BoatNumberFolder)
        {
            var affectedFolder = folder.AffectedFolder.Folder.Path;
            var targetFolder = folder.TargetFolder.Folder.Path;
            var folderName = folder.FolderName;
            RestructureBoatNumbers(affectedFolder, targetFolder, folderName);
        }
    }
}
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
/// Holds the details for the bow number feature
/// </summary>
public class BowNumberFeature: ViewModelBase, IFeatureFolderDetails
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
    /// <param name="affectedFolder">The <see cref="BowNumberDetails.AffectedFolder"/></param>
    /// <param name="numberOfBoats">The <see cref="BowNumberDetails.BoatsPerFolder"/></param>
    /// <param name="isIndividualFolder">The <see cref="BowNumberDetails.IsIndividualFolder"/></param>
    /// <exception cref="Exception">Occurs if shell script has an error</exception>
    private void RestructureBowNumbers(string affectedFolder, string numberOfBoats, string isIndividualFolder)
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"{ShellScript} \"{affectedFolder}\" {numberOfBoats} {isIndividualFolder}",
                WorkingDirectory = _directory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            }
        };
        
        proc.Start();
        
        // Read the output (if needed)
        var error = proc.StandardError.ReadToEnd();
             
        // Wait for the process to exit
        proc.WaitForExit();
             
        // Write the error to the console, if any
        if (!string.IsNullOrEmpty(error))
        {
            throw new Exception(error);
        }
    }
    /// <inheritdoc/>
    public string FolderName => "Bow Number";
    
    /// <inheritdoc/>
    public bool Active { get; private set; }

    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> AffectedFolders
    {
        get => _affectedFolders;
        set => this.RaiseAndSetIfChanged(ref _affectedFolders, value);
    }

    /// <summary>
    /// A list of <see cref="BowNumberDetails"/> used to display the personalised
    /// features for each folder
    /// </summary>
    public List<BowNumberDetails> BowNumberFolders = new();

    /// <inheritdoc/>
    public string ShellScript { get; private set; } = "BowNumberScript.sh";

    /// <summary>
    /// Adds new folders to <see cref="AffectedFolders"/>
    /// </summary>
    /// <param name="folders">Folders to be added</param>
    /// <param name="isIndividualFolder">Parameter to create <see cref="BowNumberDetails"/></param>
    /// <param name="boatsPerFolder">Parameter to create <see cref="BowNumberDetails"/></param>
    public void AddAffectedFolders(IEnumerable<DirectoryItem> folders, bool isIndividualFolder, int boatsPerFolder)
    {
        foreach (var folder in folders.Where(folder => !AffectedFolders.Contains(folder)))
        {
            AffectedFolders.Add(folder);
            BowNumberFolders.Add(
                new BowNumberDetails(folder, isIndividualFolder, boatsPerFolder)
            );
        }

        Active = true;
    }

    /// <inheritdoc/>
    public void DeleteAffectedFolders(DirectoryItem folder)
    {
        AffectedFolders.Remove(folder);
        BowNumberFolders.Remove(BowNumberFolders.First(bowNumber => bowNumber.AffectedFolder == folder));
        if (AffectedFolders.Count == 0) Active = false;
    }
    
    /// <inheritdoc/>
    public void RunShellScript()
    {
        foreach (var folder in BowNumberFolders)
        {
            var affectedFolder = folder.AffectedFolder.Folder.Path;
            var numberOfBoats = folder.BoatsPerFolder.ToString();
            var isIndividualFolder = folder.IsIndividualFolder.ToString();
            RestructureBowNumbers(affectedFolder, numberOfBoats, isIndividualFolder);
        }
    }

    /// <summary>
    /// Method used to alter the shell script. To be used for writing tests
    /// </summary>
    /// <param name="script">The mock script to be used</param>
    public void ChangeShellScript(string script)
    {
        ShellScript = script;
    }
}
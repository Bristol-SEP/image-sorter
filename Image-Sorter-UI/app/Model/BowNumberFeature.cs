using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public string ShellScript
    {
        get
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            var file = path + "/Scripts/BowNumberScript.sh";
            return file;
        }
    }

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

    public void RunShellScript()
    {
        Console.WriteLine("entered");
    }
}
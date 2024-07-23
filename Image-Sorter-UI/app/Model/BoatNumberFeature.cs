using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    /// <inheritdoc/>
    public string ShellScript => "";

    /// <inheritdoc/>
    public void AddAffectedFolders(ObservableCollection<DirectoryItem> folders)
    {
        foreach (var folder in folders)
        {
            if (!AffectedFolders.Contains(folder)) AffectedFolders.Add(folder);
        }
        Active = true;
    }

    public void DeleteAffectedFolders(DirectoryItem folder)
    {
        AffectedFolders.Remove(folder);
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model.Interfaces;
using app.ViewModels;
using ReactiveUI;

namespace app.Model;

public class BowNumberFeature: ViewModelBase, IFeatureFolderDetails
{
    /// <summary>
    /// Backing field for <see cref="AffectedFolders"/>
    /// </summary>
    private ObservableCollection<DirectoryItem> _affectedFolders = new();
    
    /// <summary>
    /// Backing field for <see cref="IsIndividualFolders"/>
    /// </summary>
    // private bool _isIndividualFolders = true;
    
    /// <inheritdoc/>
    public string FolderName => "Bow Number";
    
    /// <inheritdoc/>
    public bool Active { get; private set; }

    /// <summary>
    /// Decides whether all of the same number should have their own folder
    /// </summary>
    public bool IsIndividualFolders { get; set; }
    // {
    //     get => _isIndividualFolders;
    //     set => this.RaiseAndSetIfChanged(ref _isIndividualFolders, value);
    // }
    
    /// <summary>
    /// Holds the number of boats which should be in grouped per folder
    /// </summary>
    public int BoatsPerFolder { get; set; }
    
    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> AffectedFolders
    {
        get => _affectedFolders;
        set => this.RaiseAndSetIfChanged(ref _affectedFolders, value);
    }

    /// <inheritdoc/>
    public string ShellScript => "";
    
    /// <summary>
    /// Toggles the <see cref="IsIndividualFolders"/>
    /// </summary>
    public void ToggleIsIndividualFolder()
    {
        IsIndividualFolders = !IsIndividualFolders;
    }
    
    /// <inheritdoc/>
    public void AddAffectedFolders(List<DirectoryItem> folders)
    {
        foreach (var folder in folders.Where(folder => !AffectedFolders.Contains(folder)))
        {
            AffectedFolders.Add(folder);
        }

        Active = true;
    }

    /// <inheritdoc/>
    public void DeleteAffectedFolders(DirectoryItem folder)
    {
        AffectedFolders.Remove(folder);
        if (AffectedFolders.Count == 0) Active = false;
    }
}
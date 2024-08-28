using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Views;

namespace app.Model.Interfaces;

/// <summary>
/// A model which holds the details required to run a script for a feature
/// </summary>
public interface IFeatureFolderDetails
{
    /// <summary>
    /// The name which will be present in the <see cref="FolderStructureDisplayView"/>
    /// UI
    /// </summary>
    public string FolderName { get; }
    
    /// <summary>
    /// Shows which features scripts are to be run when button clicked
    /// </summary>
    public bool Active { get; }
    
    /// <summary>
    /// The folders where the features subfolders will be placed
    /// </summary>
    public ObservableCollection<DirectoryItem> AffectedFolders { get; }

    /// <summary>
    /// The shell script that is ran to create these features
    /// </summary>
    public string ShellScript { get; }

    /// <summary>
    /// Removes a folder from <see cref="AffectedFolders"/>
    /// </summary>
    /// <param name="folder">Folder to be removed</param>
    public void DeleteAffectedFolders(DirectoryItem folder);
}
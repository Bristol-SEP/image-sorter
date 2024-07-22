using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Views;

namespace app.Model.Interfaces;

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
    /// Adds new folders to <see cref="AffectedFolders"/>
    /// </summary>
    /// <param name="folders">Folders to be added</param>
    public void AddAffectedFolders(ObservableCollection<DirectoryItem> folders);
}
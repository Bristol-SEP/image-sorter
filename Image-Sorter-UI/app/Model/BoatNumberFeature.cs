using System.Collections.ObjectModel;
using app.Model.Interfaces;

namespace app.Model;

/// <summary>
/// Holds the details for this feature
/// </summary>
public class BoatNumberFeature: IFeatureFolderDetails
{
    /// <inheritdoc/>
    public string FolderName => "Boat Codes";

    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> AffectedFolders => new();

    /// <inheritdoc/>
    public string ShellScript => "";

    /// <inheritdoc/>
    public void AddAffectedFolders(ObservableCollection<DirectoryItem> folders)
    {
        foreach (var folder in folders)
        {
           if(!AffectedFolders.Contains(folder)) AffectedFolders.Add(folder); 
        } 
    }
}
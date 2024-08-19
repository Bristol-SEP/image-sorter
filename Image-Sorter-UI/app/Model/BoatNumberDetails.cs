namespace app.Model;

public class BoatNumberDetails
{
    /// <summary>
    /// The folder which holds this feature
    /// </summary>
    public DirectoryItem AffectedFolder { get; }
    
    /// <summary>
    /// The folder which is searched
    /// </summary>
    public DirectoryItem TargetFolder { get; }
    
    /// <summary>
    /// Holds the name of the main folder to be created
    /// </summary>
    public string FolderName { get; }

    /// <summary>
    /// Creates an instance of <see cref="BoatNumberDetails"/>
    /// </summary>
    /// <param name="affectedFolder">The value for <see cref="AffectedFolder"/></param>
    /// <param name="targetFolder">The value for <see cref="AffectedFolder"/></param>
    /// <param name="folderName">The value for <see cref="FolderName"/></param>
    public BoatNumberDetails(DirectoryItem affectedFolder, DirectoryItem targetFolder, string folderName)
    {
        AffectedFolder = affectedFolder;
        TargetFolder = targetFolder;
        FolderName = folderName;
    }
}
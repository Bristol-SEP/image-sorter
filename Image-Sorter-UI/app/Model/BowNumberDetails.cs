namespace app.Model;

public class BowNumberDetails
{
    /// <summary>
    /// The folder which holds this feature
    /// </summary>
    public DirectoryItem AffectedFolder { get; }
    
    /// <summary>
    /// Whether the same bow number images should be grouped
    /// </summary>
    public bool IsIndividualFolder { get; }
    
    /// <summary>
    /// The grouping of bow number folders
    /// </summary>
    public int BoatsPerFolder { get; }

    /// <summary>
    /// Creates a instance of <see cref="BowNumberDetails"/>
    /// </summary>
    /// <param name="affectedFolder">The value for <see cref="AffectedFolder"/></param>
    /// <param name="isIndividualFolder">The value for <see cref="IsIndividualFolder"/></param>
    /// <param name="boatsPerFolder">The value for <see cref="BoatsPerFolder"/></param>
    public BowNumberDetails(DirectoryItem affectedFolder, bool isIndividualFolder, int boatsPerFolder)
    {
        AffectedFolder = affectedFolder;
        IsIndividualFolder = isIndividualFolder;
        BoatsPerFolder = boatsPerFolder;
    }
}
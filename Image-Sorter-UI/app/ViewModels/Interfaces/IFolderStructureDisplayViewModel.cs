using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.Model.Interfaces;
using app.Views;

namespace app.ViewModels.Interfaces;

/// <summary>
/// The ViewModel of the <see cref="FolderStructureDisplayView"/>
/// </summary>
public interface IFolderStructureDisplayViewModel
{
    /// <summary>
    /// The page to be displayed in the popup
    /// </summary>
    public ViewModelBase View { get; set; }
    
    /// <summary>
    /// a boolean which decides whether to show the popup page
    /// </summary>
    public bool ShowPopup { get; set; }
    
    /// <summary>
    /// A <see cref="ObservableCollection{T}">ObservableCollection</see> of <see cref="DirectoryItem"/>
    /// who are to have a subfolder for a feature added
    /// </summary>
    public ObservableCollection<DirectoryItem> FeatureFolderList { get; set; }
    
    /// <summary>
    /// Is a <see cref="List{T}">list</see> of <see cref="IFeatureFolderDetails"/>
    /// so program knows which scripts to run and where
    /// </summary>
    public List<IFeatureFolderDetails> FeatureFolderDetailsList { get; }
    
    /// <summary>
    /// A list of <see cref="FeatureGroup"/> used in folder adding
    /// within the <see cref="FolderStructureDisplayView"/>
    /// </summary>
    public FeatureList FeatureList { get; set; }
    
    /// <summary>
    /// A <see cref="DirectoryPriorityList"/> used to find the directory levels
    /// </summary>
    public DirectoryPriorityList FolderDirectories { get; set; }
    
    /// <summary>
    /// Sets the <see cref="IMainWindowViewModel"/> context
    /// </summary>
    /// <param name="mainViewModel">An instance of <see cref="IMainWindowViewModel"/></param>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel);

    /// <summary>
    /// Occurs when add images button is clicked returns to the
    /// <see cref="AddImageDisplayView"/>
    /// </summary>
    public void ButtonPressed();

    public void AddFeature(DirectoryItem item);

    /// <summary>
    /// A function to update <see cref="FeatureFolderDetailsList"/>
    /// and the UI along with it
    /// </summary>
    /// <param name="featureModel"></param>
    public void UpdateFeatureFolderList(IFeatureFolderDetails featureModel);
}
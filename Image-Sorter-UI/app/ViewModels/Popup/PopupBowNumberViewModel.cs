using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.Model.Interfaces;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using ReactiveUI;

namespace app.ViewModels.Popup;

// Plan is to have the model be in this page rather than folder page all the changes to model 
// should happen here
public class PopupBowNumberViewModel: ViewModelBase, IPopupBowNumberViewModel, IPopupFeature, INavigationControl
{
    /// <summary>
    /// Looks through <see cref="DirectoryPriorityList"/> and returns all the folders
    /// with the same parent on the same level
    /// </summary>
    /// <param name="item">The <see cref="DirectoryItem"/> that is on the correct level</param>
    /// <param name="dictionary">The <see cref="DirectoryPriorityList"/> which is searched</param>
    /// <returns>A <see cref="ObservableCollection{T}">ObservableCollection</see> of
    /// <see cref="DirectoryItem"/> holding all the folders with the same parent on the same
    /// level</returns>
    private List<DirectoryItem> GetAllFoldersOfLevel(DirectoryItem item,
        IDirectoryPriorityList dictionary)
    {
        var folders = new List<DirectoryItem>();
        var level = item.Level;
        var levelBreak = false;
        var found = false;
        foreach (var dictionaryItem in dictionary.FolderDictionary)
        {
            if (dictionaryItem.Level == level)
            {
                folders = levelBreak ? new List<DirectoryItem>() : folders;
                folders.Add(dictionaryItem);
                if (dictionaryItem == item) found = true;
                levelBreak = false;
            }
            else if (dictionaryItem.Level < level)
            {
                if (found) break;
                levelBreak = true;
            }
        }
        return folders;
    }

    /// <summary>
    /// Takes an <see cref="ObservableCollection{T}">ObservableCollection</see>
    /// and converts it into a string of all the present items
    /// </summary>
    /// <param name="list">The items to be turned into a continuous string</param>
    /// <returns>A string of all the present items</returns>
    private string ListToString(IEnumerable<DirectoryItem> list)
    {
        var folders = list.Aggregate
        ("", (current, folder) 
            => current + (folder.Folder.Name + ", "));
        folders = folders.Length <= 2 ? folders : folders.Remove(folders.Length - 2);
        return folders;
    }

    /// <summary>
    /// backing field for <see cref="FolderList"/>
    /// </summary>
    private string _folderList = "Error";

    /// <summary>
    /// Holds the instance of the original selected item so it may be toggled
    /// between one and many
    /// </summary>
    private DirectoryItem _coreFolder;
    
    /// <summary>
    /// Backing field for <see cref="FeatureFolderList"/>
    /// </summary>
    private List<DirectoryItem> _featureFolderList = new();
    
    /// <summary>
    /// Holds an instance of <see cref="IFolderStructureDisplayViewModel.FolderDirectories"/>
    /// </summary>
    private List<DirectoryItem> FeatureFolderList
    {
        get
        {
            if (_featureFolderList.Any()) return _featureFolderList;
            var ffl = MainPage.FolderView.FeatureFolderList;
            _coreFolder = ffl[0];
            return ffl.ToList();
        }
        set
        {
            FolderList = ListToString(value);
            this.RaiseAndSetIfChanged(ref _featureFolderList, value);
        }
    }

    /// <summary>
    /// Backing field for <see cref="BoatsPerFolder"/>
    /// </summary>
    private int _boatsPerFolder = 10;

    /// <summary>
    /// Backing field for <see cref="BowNumberFeature"/>
    /// </summary>
    private BowNumberFeature _bowNumberFeature = new();
    
    /// <summary>
    /// A method to update <see cref="BowNumberFeature"/>
    /// </summary>
    private void SetFolderChanges()
    {
        BowNumberFeature.AddAffectedFolders(FeatureFolderList, IsIndividualFolders, BoatsPerFolder);
    }

    /// <summary>
    /// Backing field for <see cref="IsIndividualFolders"/>
    /// </summary>
    private bool _isIndividualFolders = true;
    
    /// <inheritdoc/>
    public string FolderList
    {
        get => _folderList == "Error" ? ListToString(MainPage.FolderView.FeatureFolderList) : _folderList;
        private set => this.RaiseAndSetIfChanged(ref _folderList, value);
    }

    /// <inheritdoc/>
    public int BoatsPerFolder
    {
        // get => _boatsPerFolder;
        get
        {
            if (!_isIndividualFolders && _boatsPerFolder == 0)
            {
                IsIndividualFolders = true;
            }

            return _boatsPerFolder;
        }
        set => this.RaiseAndSetIfChanged(ref _boatsPerFolder, value);
    }

    /// <inheritdoc/>
    public bool IsIndividualFolders
    {
        get
        {
            if (!_isIndividualFolders && _boatsPerFolder == 0)
            {
                BoatsPerFolder = 5;
            }

            return _isIndividualFolders;
        }
        private set => this.RaiseAndSetIfChanged(ref _isIndividualFolders, value);
    }

    /// <inheritdoc/>
    public BowNumberFeature BowNumberFeature
    {
        get => _bowNumberFeature;
        set => this.RaiseAndSetIfChanged(ref _bowNumberFeature, value);
    }

    /// <inheritdoc/>
    public void AddFolderLevel()
    {
        FeatureFolderList = FeatureFolderList.Count > 1 ? 
            new List<DirectoryItem>() { _coreFolder } : 
            GetAllFoldersOfLevel(_coreFolder, MainPage.FolderView.FolderDirectories);
    }

    /// <inheritdoc/>
    public void ToggleIsIndividualFolder()
    {
        IsIndividualFolders = !IsIndividualFolders;
    }

    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; private set; }

    /// <inheritdoc/>
    public void SetContext(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

    /// <inheritdoc/>
    public void AddFeature()
    {
        SetFolderChanges();
        var foldersName = "Bow Number(";
        if (IsIndividualFolders) foldersName += BoatsPerFolder == 0 ? "Individual Folders" : "Individual Folders, ";
        if (BoatsPerFolder != 0) foldersName += "Boats Per Folder: " + BoatsPerFolder;
        foldersName += ")";
        MainPage.FolderView.UpdateFeatureFolderList(foldersName, FeatureFolderList, false);
        FeatureFolderList.Clear();
        BoatsPerFolder = 10;
        IsIndividualFolders = true;
        Close();
    }

    public IFeatureFolderDetails GetModelBasic()
    {
        return BowNumberFeature;
    }

    /// <inheritdoc/>
    public void Return()
    {
        FeatureFolderList.Clear();
        FolderList = "Error";
        BoatsPerFolder = 10;
        IsIndividualFolders = true;
        MainPage.BackToMain();
    }

    /// <inheritdoc/>
    public void Close()
    {
        Return();
        MainPage.ClosePopup();
    }

    public PopupBowNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }
}
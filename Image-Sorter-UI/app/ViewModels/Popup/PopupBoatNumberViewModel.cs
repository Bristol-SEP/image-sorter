using System;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces.Popup;
using ReactiveUI;

namespace app.ViewModels.Popup;

public class PopupBoatNumberViewModel: ViewModelBase, IPopupBoatNumberViewModel, IPopupFeature, INavigationControl
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
    private ObservableCollection<DirectoryItem> GetAllFoldersOfLevel(DirectoryItem item,
        DirectoryPriorityList dictionary)
    {
        var list = dictionary.FolderDictionary;
        var start = list.IndexOf(item);
        var level = item.Level;
        var folders = new ObservableCollection<DirectoryItem>();
        while (list[start].Level >= level)
        {
            start--;
        }
        start++;
        while (list[start].Level >= level)
        {
            if (list[start].Level == level)
            {
                folders.Add(list[start]);
            }
            start++;
        }
        return folders;
    }   
    
    //TODO have FeatureFolderList be a private variable and implement so FolderList will update
    // when there is a change
    /// <inheritdoc/>
    public string FolderList
    {
        get
        {
            var folders = MainPage.FolderView.FeatureFolderList.Aggregate
                ("", (current, folder) 
                    => current + (folder.Folder.Name + ", "));
            folders = folders.Length <= 2 ? folders : folders.Remove(folders.Length - 2);
            return folders;
        }
    }

    /// <inheritdoc/>
    public void AddFolderLevel()
    {
        var folders = MainPage.FolderView.FeatureFolderList;
        folders = folders.Count > 1 ? 
            new ObservableCollection<DirectoryItem>() { folders[0] } : 
            GetAllFoldersOfLevel(folders[0], MainPage.FolderView.FolderDirectories);
        MainPage.FolderView.FeatureFolderList = folders;
    }

    /// <inheritdoc/>
    public IPopupMainPageViewModel MainPage { get; private set; }

    /// <inheritdoc/>
    public void SetContext(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

    /// <inheritdoc/>
    public void Return()
    {
        MainPage.BackToMain();
    }

    public void Close()
    {
        Return();
        MainPage.ClosePopup();
    }

    public PopupBoatNumberViewModel(IPopupMainPageViewModel mainPage)
    {
        MainPage = mainPage;
    }

}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace app.ViewModels;

/// <inheritdoc cref="IMainWindowViewModel"/>
public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    /// <summary>
    /// backing field for <see cref="CurrentPage"/>
    /// </summary>
    private ViewModelBase _currentPage;

    /// <summary>
    /// Holds an instance of <see cref="FolderStructureDisplayViewModel"/>
    /// </summary>
    private IFolderStructureDisplayViewModel FolderStructureDisplayViewModel { get; }
    
    /// <summary>
    /// Holds an instance of <see cref="AddImageDisplayViewModel"/>
    /// </summary>
    private IAddImageDisplayViewModel AddImageDisplayViewModel { get; }
    
    /// <summary>
    /// Removes separators from the end of file paths
    /// </summary>
    /// <param name="absolutePath">A <see cref="string"/> of the absolute path of a <see cref="Uri"/></param>
    /// <returns></returns>
    private static string EndsWithSeparator(string absolutePath)
    {
        return absolutePath.TrimEnd('/','\\') + "/";
    }
    
    // TODO This is a little bit of a hack maybe refactor at a later date
    /// <summary>
    /// Checks if file is already in <see cref="MainWindowViewModel.FolderList"/>,
    /// also checks that folder is not a child of any folders already
    /// present in <see cref="MainWindowViewModel.FolderList"/>, removes child folders from
    /// <see cref="MainWindowViewModel.FolderList"/> if folder being added is a parent
    /// </summary>
    /// <param name="folder">The folder being searched for</param>
    /// <returns>True if folder is not already present in <see cref="MainWindowViewModel.FolderList"/> and is not a child</returns>
    private bool IsNotPresent(SelectFolders folder)
    {
        var children = new List<SelectFolders>();
        var folderPath = EndsWithSeparator(folder.Path);
        foreach (var presentFolder in FolderList)
        {
            var presentPath = EndsWithSeparator(presentFolder.Path);
            if (presentPath.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase)) children.Add(presentFolder);
            else if (folderPath.StartsWith(presentPath, StringComparison.OrdinalIgnoreCase)) return false;
        }

        foreach (var child in children)
        {
            RemoveFolders(child);
        }

        return true;
    }
    
    /// <inheritdoc/>
    public ObservableCollection<SelectFolders> FolderList { get; } = new();

    /// <inheritdoc/>
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    /// <inheritdoc/>
    public bool IsImagePage => _currentPage == AddImageDisplayViewModel;

    public MainWindowViewModel(IViewModelProvider vmProvider)
    {
        AddImageDisplayViewModel = vmProvider.GetAddImageViewModel();
        AddImageDisplayViewModel.SetMainViewModel(this);
        FolderStructureDisplayViewModel = vmProvider.GetFolderStructureViewModel();
        FolderStructureDisplayViewModel.SetMainViewModel(this);
        _currentPage = (ViewModelBase)AddImageDisplayViewModel;
    }

    /// <inheritdoc/>
    public void ToggleView()
    {
        if (IsImagePage)
        {
            CurrentPage = (ViewModelBase)FolderStructureDisplayViewModel;
            var directoryPriorityList = new DirectoryPriorityList(FolderList);
            FolderStructureDisplayViewModel.FolderDirectories = directoryPriorityList.FolderDictionary;
            return;
        }
        CurrentPage = (ViewModelBase)AddImageDisplayViewModel;
    }

    /// <inheritdoc/>
    public void AddFolders(IEnumerable<SelectFolders> folders)
    {
        foreach (var folder in folders.Where(IsNotPresent))
        {
            FolderList.Add(folder);
        }
    }

    /// <inheritdoc/>
    public void RemoveFolders(SelectFolders folder)
    {
        FolderList.Remove(folder);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockMainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    private readonly ViewModelBase _imagePage;
    private readonly ViewModelBase _notImagePage;
    private ViewModelBase _currentPage;
    private ObservableCollection<SelectFolders> _foldersList = new();

    /// <summary>
    /// Removes separators from the end of file paths
    /// </summary>
    /// <param name="absolutePath">A <see cref="string"/> of the absolute path of a <see cref="Uri"/></param>
    /// <returns></returns>
    private static string EndsWithSeparator(string absolutePath)
    {
        return absolutePath.TrimEnd('/','\\') + "/";
    }
    
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
    public ObservableCollection<SelectFolders> FolderList
    {
        get => _foldersList;
        set => this.RaiseAndSetIfChanged(ref _foldersList, value);
    } 
    public bool IsImagePage => CurrentPage == _imagePage;
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public MockMainWindowViewModel()
    {
        _imagePage = new ViewModelBase();
        _notImagePage = new ViewModelBase();
        _currentPage = _imagePage;
    }

    public void ToggleView()
    {
        if (IsImagePage)
        {
            CurrentPage = _notImagePage;
            return;
        }

        CurrentPage = _imagePage;
    }
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
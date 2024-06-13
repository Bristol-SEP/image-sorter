using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.ViewModels.Interfaces;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;

namespace app.ViewModels;

/// <inheritdoc cref="IAddImageDisplayViewModel"/>
public class AddImageDisplayViewModel: ViewModelBase, IAddImageDisplayViewModel
{
    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private  IMainWindowViewModel? _mainModel;

    // TODO This is a little bit of a hack maybe refactor at a later date
    /// <summary>
    /// Checks if file is already in <see cref="FolderList"/>,
    /// also checks that folder is not a child of any folders already
    /// present in <see cref="FolderList"/>, removes child folders from
    /// <see cref="FolderList"/> if folder being added is a parent
    /// </summary>
    /// <param name="folder">The folder being searched for</param>
    /// <returns>True if folder is not already present in <see cref="FolderList"/> and is not a child</returns>
    private bool IsNotPresent(SelectFolders folder)
    {
        var children = new List<SelectFolders>();
        var folderPath = EndsWithSeparator(folder.Path.AbsolutePath);
        foreach (var presentFolder in FolderList)
        {
            var presentPath = EndsWithSeparator(presentFolder.Path.AbsolutePath);
            if (presentPath.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase)) children.Add(presentFolder);
            else if (folderPath.StartsWith(presentPath, StringComparison.OrdinalIgnoreCase)) return false;
        }

        foreach (var child in children)
        {
            FolderList.Remove(child);
        }

        return true;
    }
    
    /// <summary>
    /// Removes separators from the end of file paths
    /// </summary>
    /// <param name="absolutePath">A <see cref="string"/> of the absolute path of a <see cref="Uri"/></param>
    /// <returns></returns>
    private static string EndsWithSeparator(string absolutePath)
    {
        return absolutePath?.TrimEnd('/','\\') + "/";
    }
    
    public AddImageDisplayViewModel()
    {
        var rowingFeatures = new List<string>
        {
            "Boat Code",
            "Race Number"
        };
        var rowing = new FeatureGroup("Rowing", rowingFeatures);
        FeatureList = new List<FeatureGroup>
        {
            rowing
        };
    }
    
    /// <inheritdoc/>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainModel = mainViewModel;
    }
    
    /// <inheritdoc/>
    /// TODO pass data into python script
    public void ButtonPressed()
    {
        if (_mainModel is null) throw new NullReferenceException();
        if (!_mainModel.IsImagePage) throw new InvalidOperationException();
        _mainModel.ToggleView();
    }

    /// <inheritdoc/>
    public List<FeatureGroup> FeatureList { get; }

    /// <inheritdoc/>
    public ObservableCollection<SelectFolders> FolderList { get; } = new();

    /// <inheritdoc/>
    public bool FoldersEmpty => FolderList.Count == 0; 

    // TODO implement protection so child folders cannot be added if parent is present
    /// <inheritdoc/>
    public void AddFolders(IReadOnlyList<IStorageFolder>? folders)
    {
        if (folders is null) return;
        foreach (var folder in folders)
        {
            var folderModel = new SelectFolders(folder.Name, folder.Path);
            if(IsNotPresent(folderModel)) FolderList.Add(folderModel);
        }
        this.RaisePropertyChanged(nameof(FoldersEmpty));
    }

    /// <inheritdoc/>
    public void RemoveFolders(SelectFolders folder)
    {
        FolderList.Remove(folder);
        this.RaisePropertyChanged(nameof(FoldersEmpty));
    }
    
}
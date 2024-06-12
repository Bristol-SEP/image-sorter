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

    /// <summary>
    /// Checks if file is already in <see cref="FolderList"/>
    /// </summary>
    /// <param name="folder">The folders being searched for</param>
    /// <returns>True if folder is not already present in <see cref="FolderList"/></returns>
    private bool IsNotPresent(SelectFolders folder)
    {
        return FolderList.All(presentFolder => !presentFolder.Path.Equals(folder.Path));
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
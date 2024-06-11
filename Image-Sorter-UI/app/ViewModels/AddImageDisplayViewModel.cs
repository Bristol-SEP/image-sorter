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
    /// A backing field for <see cref="FolderList"/>
    /// </summary>
    private ObservableCollection<SelectFolders> _foldersList = new();
    
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

    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private  IMainWindowViewModel? _mainModel;
    
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
    public ObservableCollection<SelectFolders> FolderList
    {
        get => _foldersList;
        private set => this.RaiseAndSetIfChanged(ref _foldersList, value);
    }

    /// <inheritdoc/>
    public bool FoldersEmpty => FolderList.Count == 0; 

    /// <inheritdoc/>
    public void AddFolders(IReadOnlyList<IStorageFolder>? folders)
    {
        if (folders is null) return;
        foreach (var folder in folders)
        {
            var folderModel = new SelectFolders(folder.Name, folder.Path);
            Console.WriteLine(folderModel.Name);
            FolderList.Add(folderModel);
            Console.WriteLine(FoldersEmpty);
        }
        this.RaisePropertyChanged(nameof(FoldersEmpty));
    }

    /// <inheritdoc/>
    public void RemoveFolders()
    {
        throw new NotImplementedException();
    }
    
}
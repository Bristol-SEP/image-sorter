using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using app.Model;
using app.Model.Interfaces;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using ReactiveUI;

namespace app.ViewModels;

/// <inheritdoc cref="IFolderStructureDisplayViewModel"/>
public class FolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    /// <summary>
    /// Backing field for <see cref="FolderDirectories"/>
    /// </summary>
    private IDirectoryPriorityList _directories = new DirectoryPriorityList(new ObservableCollection<SelectFolders>());

    /// <summary>
    /// Backing field for <see cref="ShowPopup"/>
    /// </summary>
    private bool _showPopup;
    
    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private IMainWindowViewModel? MainModel { get; set; }

    /// <summary>
    /// Backing field for <see cref="View"/>
    /// </summary>
    private ViewModelBase _view = new();

    /// <summary>
    /// Backing field for <see cref="FeatureFolderDetailsList"/>
    /// </summary>
    private ObservableCollection<IFeatureFolderDetails> _featureFolderDetailsList = new();
    
    /// <summary>
    /// Backing field for <see cref="FeatureFolderList"/>
    /// </summary>
    private ObservableCollection<DirectoryItem> _featureFolderList = new();

    /// <inheritdoc/>
    public ViewModelBase View
    {
        get => _view;
        set => this.RaiseAndSetIfChanged(ref _view, value);
    }

    /// <inheritdoc/>
    public bool ShowPopup
    {
        get => _showPopup;
        set => this.RaiseAndSetIfChanged(ref _showPopup, value);
    }

    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> FeatureFolderList
    {
        get => _featureFolderList;
        set => this.RaiseAndSetIfChanged(ref _featureFolderList, value);
    }

    /// <inheritdoc/>
    public ObservableCollection<IFeatureFolderDetails> FeatureFolderDetailsList
    {
        get => _featureFolderDetailsList;
        private set => this.RaiseAndSetIfChanged(ref _featureFolderDetailsList, value);
    } 

    /// <inheritdoc/>
    public FeatureList FeatureList
    {
        get => new();
        set
        {
            value.MainViewContext(this);
            View = (ViewModelBase)value.MainView;
            foreach (var view in value.FeatureGroups.SelectMany(group => 
                         group.Features.Select(feature => 
                             (IPopupFeature)feature.View)))
            {
                FeatureFolderDetailsList.Add(view.GetModelBasic());
            }
        }
    }

    /// <inheritdoc/>
    public IDirectoryPriorityList FolderDirectories
    {
        get => _directories;
        set => this.RaiseAndSetIfChanged(ref _directories, value);
    }

    /// <inheritdoc/>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        MainModel = mainViewModel;
    }

    /// <inheritdoc/>
    public void ButtonPressed()
    {
        if (MainModel is null) throw new NullReferenceException();
        if (MainModel.IsImagePage) throw new InvalidOperationException();
        MainModel.ToggleView();
    }

    /// <inheritdoc/>
    public void AddFeature(DirectoryItem item)
    {
        ShowPopup = true;
        FeatureFolderList = new ObservableCollection<DirectoryItem>() { item };
    }

    /// <inheritdoc/>
    public void UpdateFeatureFolderList(string name, List<DirectoryItem> featureModel)
    {
        // update the UI
        FolderDirectories.AddFeature(name, featureModel);
    }

    /// <inheritdoc/>
    public void RemoveFeature(DirectoryItem folder)
    {
        // remove folder from list
        FolderDirectories.DeleteFeature(folder);
        // remove parent folder from affected folders in model
        foreach (var featureFolder in FeatureFolderDetailsList)
        {
            foreach (var directoryItem in featureFolder.AffectedFolders.Where(feature =>
                         feature.Folder.Path == folder.Folder.Path))
            {
                featureFolder.DeleteAffectedFolders(directoryItem);
                return;
            }
        }
    }

    /// <inheritdoc/>
    public void StructureFolder()
    {
        
        foreach (var folder in FeatureFolderDetailsList.Where(feature => feature.Active))
        {
           folder.RunShellScript(); 
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces;
using app.ViewModels.Popup;
using ReactiveUI;

namespace app.ViewModels;

/// <inheritdoc cref="IFolderStructureDisplayViewModel"/>
public class FolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    /// <summary>
    /// Backing field for <see cref="FolderDirectories"/>
    /// </summary>
    private DirectoryPriorityList _directories = new(new ObservableCollection<SelectFolders>());

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
    private ViewModelBase _view = new PopupMainPageViewModel();

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
        private set => this.RaiseAndSetIfChanged(ref _showPopup, value);
    }

    /// <inheritdoc/>
    public List<FeatureGroup> FeatureList
    {
        get => new();
        set => View = new PopupMainPageViewModel(value, this);
    }

    /// <inheritdoc/>
    public DirectoryPriorityList FolderDirectories
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

    public void AddFeature(DirectoryItem item)
    {
        ShowPopup = true;
        FolderDirectories.AddFeature(item);
    }
}
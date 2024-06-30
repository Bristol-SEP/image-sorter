using System;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace app.ViewModels;

/// <inheritdoc cref="IFolderStructureDisplayViewModel"/>
public class FolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    /// <summary>
    /// Backing field for <see cref="Directories"/>
    /// </summary>
    private ObservableCollection<DirectoryItem> _directories = new();
    
    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private IMainWindowViewModel? MainModel { get; set; }

    /// <inheritdoc/>
    public ObservableCollection<DirectoryItem> FolderDirectories
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
}
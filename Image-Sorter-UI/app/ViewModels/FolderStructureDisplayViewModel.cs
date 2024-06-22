using System;
using System.Collections.ObjectModel;
using app.Model;
using app.ViewModels.Interfaces;

namespace app.ViewModels;

/// <inheritdoc cref="IFolderStructureDisplayViewModel"/>
public class FolderStructureDisplayViewModel: ViewModelBase, IFolderStructureDisplayViewModel
{
    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private IMainWindowViewModel? MainModel
    {
        get => null;
        set
        {
            if (value is not null) FoldersList = value.FolderList;
        }
    }

    // TODO make into a adjacency list
    /// <inheritdoc/>
    public ObservableCollection<SelectFolders> FoldersList { get; private set; } = new();

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
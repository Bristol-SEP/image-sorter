using System;
using System.Collections.Generic;
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
            if (value is not null) DirectoryPriorityList = new DirectoryPriorityList(value.FolderList);
        }
    }

    /// <inheritdoc/>
    public Dictionary<SelectFolders, int> Directories { get; private set; } = new();

    private DirectoryPriorityList? DirectoryPriorityList
    {
        set
        {
            if (value is not null)
            {
                Directories = value.FolderDictionary;
            }
        }
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
using System;
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
    private IMainWindowViewModel? _mainModel;

    /// <inheritdoc/>
    public void SetMainViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainModel = mainViewModel;
    }

    /// <inheritdoc/>
    public void ButtonPressed()
    {
        if (_mainModel is null) throw new NullReferenceException();
        if (_mainModel.IsImagePage) throw new InvalidOperationException();
        _mainModel.ToggleView();
    }
}
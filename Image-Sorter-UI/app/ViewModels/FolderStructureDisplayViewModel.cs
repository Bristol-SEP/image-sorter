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
    private readonly IMainWindowViewModel? _mainModel;
    public FolderStructureDisplayViewModel(IMainWindowViewModel mainModel)
    {
        _mainModel = mainModel;
    }
    /// <inheritdoc/>
    public bool ButtonPressed()
    {
        if (_mainModel is null) return false;
        _mainModel.ToggleView();
        return true;
    }
}
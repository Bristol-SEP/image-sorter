using app.ViewModels.Interfaces;

namespace app.ViewModels;

/// <inheritdoc cref="IAddImageDisplayViewModel"/>
public class AddImageDisplayViewModel: ViewModelBase, IAddImageDisplayViewModel
{
    public AddImageDisplayViewModel(IMainWindowViewModel mainViewModel)
    {
        _mainModel = mainViewModel;
    }

    /// <summary>
    /// A reference to <see cref="MainWindowViewModel"/>
    /// which allows the <see cref="MainWindowViewModel.ToggleView"/>
    /// to be called
    /// </summary>
    private readonly IMainWindowViewModel? _mainModel;
    
    /// <inheritdoc/>
    /// TODO pass data into python script
    public bool ButtonPressed()
    {
        if (_mainModel is null) return false;
        _mainModel.ToggleView(); 
        return true;

    }
}
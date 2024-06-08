using System;
using app.ViewModels.Interfaces;

namespace app.ViewModels;

/// <inheritdoc cref="IAddImageDisplayViewModel"/>
public class AddImageDisplayViewModel: ViewModelBase, IAddImageDisplayViewModel
{
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
}
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace app.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    /// <summary>
    /// backing field for <see cref="CurrentPage"/>
    /// </summary>
    private ViewModelBase _currentPage;

    /// <summary>
    /// Holds an instance of <see cref="FolderStructureDisplayViewModel"/>
    /// </summary>
    private readonly ViewModelBase _folderStructureDisplayView;
    
    /// <summary>
    /// Holds an instance of <see cref="AddImageDisplayViewModel"/>
    /// </summary>
    private readonly ViewModelBase _addImageDisplayView;
    
    /// <inheritdoc/>
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public MainWindowViewModel()
    {
        _addImageDisplayView = new AddImageDisplayViewModel(this);
        _folderStructureDisplayView= new FolderStructureDisplayViewModel(this);
        _currentPage = _addImageDisplayView;
    }

    /// <inheritdoc/>
    public void ToggleView()
    {
        if (CurrentPage == _addImageDisplayView)
        {
            CurrentPage = _folderStructureDisplayView;
            return;
        }
        CurrentPage = _addImageDisplayView;
    }
}

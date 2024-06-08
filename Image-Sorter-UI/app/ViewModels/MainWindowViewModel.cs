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
    private IFolderStructureDisplayViewModel FolderStructureDisplayViewModel { get; }
    
    /// <summary>
    /// Holds an instance of <see cref="AddImageDisplayViewModel"/>
    /// </summary>
    private IAddImageDisplayViewModel AddImageDisplayViewModel { get; }
    
    /// <inheritdoc/>
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    /// <inheritdoc/>
    public bool IsImagePage => _currentPage == AddImageDisplayViewModel;

    public MainWindowViewModel(IViewModelProvider vmProvider)
    {
        AddImageDisplayViewModel = vmProvider.GetAddImageViewModel();
        AddImageDisplayViewModel.SetMainViewModel(this);
        FolderStructureDisplayViewModel = vmProvider.GetFolderStructureViewModel();
        FolderStructureDisplayViewModel.SetMainViewModel(this);
        _currentPage = (ViewModelBase)AddImageDisplayViewModel;
    }

    /// <inheritdoc/>
    public void ToggleView()
    {
        if (IsImagePage)
        {
            CurrentPage = (ViewModelBase)FolderStructureDisplayViewModel;
            return;
        }
        CurrentPage = (ViewModelBase)AddImageDisplayViewModel;
    }
}

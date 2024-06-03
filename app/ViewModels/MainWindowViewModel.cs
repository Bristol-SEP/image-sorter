using app.ViewModels.Interfaces;
using ReactiveUI;

namespace app.ViewModels;

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    /// <summary>
    /// backing field for <see cref="CurrentPage"/>
    /// </summary>
    private ViewModelBase _currentPage = new AddImageDisplayViewModel();
    
    /// <inheritdoc/>
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    /// <inheritdoc/>
    public void ToggleView()
    {
        if (CurrentPage is AddImageDisplayViewModel)
        {
            CurrentPage = new FolderStructureDisplayViewModel();
            return;
        }
        CurrentPage = new AddImageDisplayViewModel();
    }
}

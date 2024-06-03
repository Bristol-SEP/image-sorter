using ReactiveUI;

namespace app.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// backing field for <see cref="CurrentPage"/>
    /// </summary>
    private ViewModelBase _currentPage = new AddImageDisplayViewModel();
    
    /// <summary>
    /// Holds the current display, when changed page shown will change
    /// </summary>
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }
}

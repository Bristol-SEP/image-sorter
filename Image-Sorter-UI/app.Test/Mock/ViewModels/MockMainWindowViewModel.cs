using app.ViewModels;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace Image_Sorter_UI.Mock.ViewModels;

public class MockMainWindowViewModel: ViewModelBase, IMainWindowViewModel
{
    private readonly ViewModelBase _imagePage;
    private readonly ViewModelBase _notImagePage;
    private ViewModelBase _currentPage;

    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public MockMainWindowViewModel()
    {
        _imagePage = new ViewModelBase();
        _notImagePage = new ViewModelBase();
        _currentPage = _imagePage;
    }

    public bool IsImagePage => CurrentPage == _imagePage;
    public void ToggleView()
    {
        if (IsImagePage)
        {
            CurrentPage = _notImagePage;
            return;
        }

        CurrentPage = _imagePage;
    }
}
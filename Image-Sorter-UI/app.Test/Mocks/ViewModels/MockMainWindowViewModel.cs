using app.ViewModels;
using app.ViewModels.Interfaces;
using ReactiveUI;

namespace Image_Sorter_UI.Mocks.ViewModels;

public class MockMainWindowViewModel: ViewModelBase, IMainWindowViewModel
{
    private ViewModelBase _currentPage = new();
    
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public void ToggleView()
    {
    }
}
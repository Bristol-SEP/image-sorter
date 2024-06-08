using app.ViewModels.AddImageDisplay;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.AddImageDisplay;

namespace app.ViewModels;

public sealed class ViewModelProvider : IViewModelProvider
{
    /// <summary>
    /// The backing field for the <see cref="ViewModelProvider" /> property
    /// </summary>
    private static ViewModelProvider? _viewModelProvider;

    private ViewModelProvider()
    {
    }

    /// <summary>
    /// A global instance of <see cref="ViewModelProvider" />
    /// </summary>
    public static ViewModelProvider Instance => _viewModelProvider ??= new ViewModelProvider();

    /// <inheritdoc/>
    public IMainWindowViewModel GetMainViewModel() =>
        new MainWindowViewModel(this);

    /// <inheritdoc/>
    public IAddImageDisplayViewModel GetAddImageViewModel() =>
        new AddImageDisplayViewModel(GetMainViewModel());
    
    /// <inheritdoc/>
    public IFolderStructureDisplayViewModel GetFolderStructureViewModel() =>
        new FolderStructureDisplayViewModel(GetMainViewModel());
    
    /// <inheritdoc/>
    public IFeatureSelectionViewModel GetFeatureSelectionViewModel() =>
        new FeatureSelectionViewModel();
}
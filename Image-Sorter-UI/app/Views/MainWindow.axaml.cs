using app.ViewModels.Interfaces;
using Avalonia.ReactiveUI;

namespace app.Views;

/// <summary>
/// A view which hosts all subviews within it
/// </summary>
public partial class MainWindow : ReactiveWindow<IMainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
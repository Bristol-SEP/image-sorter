using app.ViewModels.Interfaces;
using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace app.Views;

public partial class MainWindow : ReactiveWindow<IMainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
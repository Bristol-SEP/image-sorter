using app.Views;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace app.Styles;

/// <summary>
/// A style which displays a folder and an add feature so subfolders of features
/// can be implemented. To be used in <see cref="FolderStructureDisplayView"/>
/// </summary>
public class FolderOrdering : TemplatedControl
{
    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="Text"/>
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<StageText, string>(nameof(Text), defaultValue:"Text");

    /// <summary>
    /// The text that appears in the rectangle
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
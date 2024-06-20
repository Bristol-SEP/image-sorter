using System;
using System.Net.Mime;
using app.Model;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace app.Styles;

public class ImageFolder : TemplatedControl
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

    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="SelectFolders"/>
    /// </summary>
    public static readonly StyledProperty<SelectFolders> SelectFoldersProperty =
        AvaloniaProperty.Register<StageText, SelectFolders>(nameof(SelectFolders));

    /// <summary>
    /// The text that appears in the rectangle
    /// </summary>
    public SelectFolders SelectFolders
    {
        get => GetValue(SelectFoldersProperty);
        set => SetValue(SelectFoldersProperty, value);
    }
}
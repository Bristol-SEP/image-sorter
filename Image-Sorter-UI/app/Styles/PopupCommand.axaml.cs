using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace app.Styles;

public class PopupCommand : TemplatedControl
{
    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="Text"/>
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<PopupCommand, string>(nameof(Text), defaultValue:"Text");

    /// <summary>
    /// The text that appears in the rectangle
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="IsFeaturePage"/>
    /// </summary>
    public static readonly StyledProperty<bool> IsFeaturePageProperty =
        AvaloniaProperty.Register<StageText, bool>(nameof(IsFeaturePage), defaultValue:true);

    /// <summary>
    /// The text that appears in the rectangle
    /// </summary>
    public bool IsFeaturePage
    {
        get => GetValue(IsFeaturePageProperty);
        set => SetValue(IsFeaturePageProperty, value);
    }
}
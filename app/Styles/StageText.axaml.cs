using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace app.Styles;

public class StageText : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<StageText, string>(nameof(Text));

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly StyledProperty<string> NumberProperty =
        AvaloniaProperty.Register<StageText, string>(nameof(Number));

    public string Number 
    {
        get => GetValue(NumberProperty);
        set => SetValue(NumberProperty, value);
    }
    public double RectangleWidth
    {
        get => GetValue(RectangleWidthProperty);
        set => SetValue(RectangleWidthProperty, value);
    }
    public static readonly StyledProperty<double> RectangleWidthProperty =
        AvaloniaProperty.Register<StageText, double>(nameof(RectangleWidth));

    public double RectangleHeight
    {
        get => GetValue(RectangleHeightProperty);
        set => SetValue(RectangleHeightProperty, value);
    }
    public static readonly StyledProperty<double> RectangleHeightProperty =
        AvaloniaProperty.Register<StageText, double>(nameof(RectangleHeight));
}
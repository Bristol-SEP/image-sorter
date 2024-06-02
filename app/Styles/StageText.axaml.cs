using Avalonia;
using Avalonia.Controls.Primitives;

namespace app.Styles;

public class StageText : TemplatedControl
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
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="Number"/>
    /// </summary>
    public static readonly StyledProperty<string> NumberProperty =
        AvaloniaProperty.Register<StageText, string>(nameof(Number), defaultValue:"0");

    /// <summary>
    /// The number that appears in the circle
    /// </summary>
    public string Number 
    {
        get => GetValue(NumberProperty);
        set => SetValue(NumberProperty, value);
    }
    
    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="RectangleWidth"/>
    /// </summary>
    public static readonly StyledProperty<double> RectangleWidthProperty =
        AvaloniaProperty.Register<StageText, double>(nameof(RectangleWidth), defaultValue:150);

    /// <summary>
    /// The width of the shape
    /// </summary>
    public double RectangleWidth
    {
        get => GetValue(RectangleWidthProperty);
        set => SetValue(RectangleWidthProperty, value);
    }
    
    /// <summary>
    /// A <see cref="StyledProperty{TValue}">StyledProperty</see> that defines the <see cref="RectangleWidth"/>
    /// </summary>
    public static readonly StyledProperty<double> RectangleHeightProperty =
        AvaloniaProperty.Register<StageText, double>(nameof(RectangleHeight), defaultValue:40);
    
    /// <summary>
    /// The height of the shape
    /// </summary>
    public double RectangleHeight
    {
        get => GetValue(RectangleHeightProperty);
        set => SetValue(RectangleHeightProperty, value);
    }
}
using Avalonia.Controls;

namespace BD.WTTS.UI.Views.Windows;

public partial class DebugWindow : CoreWindow
{
    public DebugWindow()
    {
        InitializeComponent();

        Width = 1080;
        Height = 660;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    void SetupSide(string name, StandardCursorType cursor, WindowEdge edge)
    {
        var ctl = this.Get<Control>(name);
        ctl.Cursor = new Cursor(cursor);
        ctl.PointerPressed += (i, e) =>
        {
            PlatformImpl?.BeginResizeDrag(edge, e);
        };
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        this.Get<Control>("TitleBar").PointerPressed += (i, e) =>
        {
            PlatformImpl?.BeginMoveDrag(e);
        };
        SetupSide("Left", StandardCursorType.LeftSide, WindowEdge.West);
        SetupSide("Right", StandardCursorType.RightSide, WindowEdge.East);
        SetupSide("Top", StandardCursorType.TopSide, WindowEdge.North);
        SetupSide("Bottom", StandardCursorType.BottomSide, WindowEdge.South);
        SetupSide("TopLeft", StandardCursorType.TopLeftCorner, WindowEdge.NorthWest);
        SetupSide("TopRight", StandardCursorType.TopRightCorner, WindowEdge.NorthEast);
        SetupSide("BottomLeft", StandardCursorType.BottomLeftCorner, WindowEdge.SouthWest);
        SetupSide("BottomRight", StandardCursorType.BottomRightCorner, WindowEdge.SouthEast);
        this.Get<Button>("MinimizeButton").Click += (sender, e) =>
        {
            this.WindowState = WindowState.Minimized;
        };
        this.Get<Button>("MaximizeButton").Click += (sender, e) =>
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        };
        this.Get<Button>("RestoreButton").Click += (sender, e) =>
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        };
        this.Get<Button>("CloseButton").Click += (sender, e) =>
        {
            Close();
        };
    }
}
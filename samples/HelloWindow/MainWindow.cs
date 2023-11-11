using Nero.Windowing;

namespace HelloWindow;

public class MainWindow : Window
{
    protected override WindowCreationOpts Initialize()
    {
        return new WindowCreationOpts()
        {
            Title = "Hello Window",
            Size = (800, 600),
            View = new MainView(),
        };
    }
}

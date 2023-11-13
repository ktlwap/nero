namespace Nero.Windowing;

public readonly struct WindowCreationOpts
{
    public string Title { get; init; }
    public (int, int) Size { get; init; }
    public View View { get; init; }
    public Monitor? Monitor { get; init; }

    public WindowCreationOpts()
    {
        Title = "Nero";
        Size = (800, 600);
        View = new EmptyView();
    }
}

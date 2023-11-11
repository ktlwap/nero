using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Nero.Windowing;

public abstract class Window
{
    private readonly IWindow _window;
    
    protected Window()
    {
        WindowCreationOpts windowCreationOpts = Initialize();
        
        WindowOptions windowOptions = WindowOptions.Default;
        windowOptions.Size = new Vector2D<int>(windowCreationOpts.Size.Item1, windowCreationOpts.Size.Item2);
        windowOptions.Title = windowCreationOpts.Title;
        windowOptions.PreferredDepthBufferBits = 24;
        windowOptions.PreferredStencilBufferBits = 8;
        windowOptions.IsEventDriven = true;
        
        _window = Silk.NET.Windowing.Window.Create(windowOptions);
    }

    internal void Run()
    {
        _window.Run();
        _window.Dispose();
    }

    internal void Close()
    {
        _window.Close();
    }

    protected abstract WindowCreationOpts Initialize();

    #region WINDOW_EVENTS

    protected virtual void OnStart() { }

    protected virtual void OnClose() { }
    
    #endregion
}

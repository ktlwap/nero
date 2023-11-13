using Nero.Widgets;
using Nero.Widgets.Layout;
using Silk.NET.Windowing;

namespace Nero.Windowing;

public abstract class View
{
    private Container _container;
    private Renderer? _renderer;
    private IWindow? _window;
    
    protected View()
    {
        _container = Initialize();
    }

    internal void Start(IWindow window)
    {
        _window = window;
        _renderer = new Renderer(window);
    }
    
    internal void Render(double deltaTime)
    {
        Bounds bounds = new Bounds()
        {
            X = 0,
            Y = 0,
            W = _window!.Size.X,
            H = _window.Size.Y,
        };
        
        _container.Draw(_renderer!.Nvg, bounds);
    }

    internal void Stop()
    {
        
    }

    protected abstract Container Initialize();
}

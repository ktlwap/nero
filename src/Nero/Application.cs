using Nero.Windowing;

namespace Nero;

public static class Application
{
    private class Instance
    {
        public Window Window { get; init; }
    }

    private static readonly List<Instance> _instances = new List<Instance>();

    /// <summary>
    /// Returns all available windows.
    /// </summary>
    public static IReadOnlyCollection<Window> Windows
        => _instances.AsParallel().Select(i => i.Window).ToList();
    
    /// <summary>
    /// Opens given window on current thread.
    /// </summary>
    /// <typeparam name="TWindow"></typeparam>
    public static void Run<TWindow>()
        where TWindow : Window, new()
    {
        lock (_instances)
        {
            TWindow window = new TWindow();
            _instances.Add(new Instance()
            {
                Window = window
            });
            
            window.Run();
        }
    }

    public static void Close(Window window)
    {
        lock (_instances)
        {
            for (int i = 0; i < _instances.Count; ++i)
            {
                if (_instances[i].Window == window)
                {
                    _instances.RemoveAt(i);
                    window.Close();
                    break;
                }
            }
        }
    }
}

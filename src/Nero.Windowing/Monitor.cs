using Nero.Widgets.Layout;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Nero.Windowing;

/// <summary>
/// Represents specifications of a monitor.
/// </summary>
public readonly struct Monitor
{
    public string Name { get; init; }
    public int Index { get; init; }
    public float Gamma { get; init; }
    public int RefreshRate { get; init; }
    public (int, int) Resolution { get; init; }
    public Bounds Bounds { get; init; }
    internal IMonitor NativeMonitor { get; init; }

    /// <summary>
    /// Returns specifications of main monitor.
    /// </summary>
    /// <returns></returns>
    public static Monitor GetMainMonitor()
    {
        IMonitor nativeMonitor = Silk.NET.Windowing.Monitor.GetMainMonitor(null);
        return ConvertNativeToAbstract(nativeMonitor);
    }
    
    /// <summary>
    /// Returns specifications of all monitors.
    /// </summary>
    /// <returns></returns>
    public static List<Monitor> GetMonitors()
    {
        return Silk.NET.Windowing.Monitor.GetMonitors(null).Select(ConvertNativeToAbstract).ToList();
    }

    private static Monitor ConvertNativeToAbstract(IMonitor nativeMonitor)
    {
        Vector2D<int> resolution = nativeMonitor.VideoMode.Resolution.GetValueOrDefault(-Vector2D<int>.One);

        return new Monitor()
        {
            Name = nativeMonitor.Name,
            Index = nativeMonitor.Index,
            Gamma = nativeMonitor.Gamma,
            RefreshRate = nativeMonitor.VideoMode.RefreshRate.GetValueOrDefault(-1),
            Resolution = (resolution.X, resolution.Y),
            Bounds = new Bounds()
            {
                X = nativeMonitor.Bounds.Origin.X,
                Y = nativeMonitor.Bounds.Origin.Y,
                W = nativeMonitor.Bounds.Size.X,
                H = nativeMonitor.Bounds.Size.Y
            },
            NativeMonitor = nativeMonitor
        };
    }
}

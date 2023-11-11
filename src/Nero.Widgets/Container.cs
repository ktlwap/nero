using Nero.Commons.Events;
using Nero.Widgets.Layout;
using SilkyNvg;

namespace Nero.Widgets;

public abstract class Container
{
    public abstract void Draw(Nvg nvg, Bounds bounds);

    public abstract WidgetEventStatus Event(Bounds bounds, WidgetEvent @event);
    
    protected void RequestRedraw()
    {
        throw new NotImplementedException();
    }
}

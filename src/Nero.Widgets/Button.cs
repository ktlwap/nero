using Nero.Commons.Events;
using Nero.Widgets.Layout;
using SilkyNvg;

namespace Nero.Widgets;

public sealed class Button : Container
{
    public override void Draw(Nvg nvg, Bounds bounds)
    {
        
    }

    public override WidgetEventStatus Event(Bounds bounds, WidgetEvent @event)
    {
        RequestRedraw();
        
        return WidgetEventStatus.Processed;
    }
}

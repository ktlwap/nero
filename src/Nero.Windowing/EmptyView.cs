using Nero.Widgets;

namespace Nero.Windowing;

public class EmptyView : View
{
    protected override Container Initialize()
        => new Empty();
}

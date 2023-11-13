namespace Nero.Widgets.Layout;

public readonly struct Bounds : IEquatable<Bounds>
{
    public float X { get; init; }
    public float Y { get; init; }
    public float W { get; init; }
    public float H { get; init; }

    public bool Equals(Bounds other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && W.Equals(other.W) && H.Equals(other.H);
    }

    public override bool Equals(object? obj)
    {
        return obj is Bounds other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, W, H);
    }
}

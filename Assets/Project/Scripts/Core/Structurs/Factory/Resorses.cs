using ProductProduce;

public readonly struct Resorses
{
    public readonly BlackProduct Black;
    public readonly RedProduct Red;
    public Resorses(in BlackProduct black) : this()
    {
        Black = black;
    }
    public Resorses(in BlackProduct black,in RedProduct red) : this()
    {
        Black = black;
        Red = red;
    }
}

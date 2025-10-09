

abstract class LevelElement
{
    public int x { get; set; }
    public int y { get; set; }

    public int offset { get; set; } = 6;

    public char elementChar { get; set; }

    public ConsoleColor Color { get; set; }

    public void Draw()
    {
        Console.SetCursorPosition(this.x, this.y);
        Console.ForegroundColor = this.Color;
        Console.Write(this.elementChar);
        Console.ResetColor();
    }
}
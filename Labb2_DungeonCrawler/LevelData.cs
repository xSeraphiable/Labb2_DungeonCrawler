


class LevelData
{
    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements { get { return _elements; } }

    public void Load(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                if (reader.Read() is 'r')
                {
                    _elements.Add(new Rat());
                }
                else if (reader.Read() is '#')
                {
                    _elements.Add(new Wall());
                }
                else if (reader.Read() is 's')
                {
                    _elements.Add(new Snake());
                }
            }
        }
    }
}
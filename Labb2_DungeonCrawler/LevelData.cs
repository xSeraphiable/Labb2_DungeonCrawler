


class LevelData
{
    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements { get { return _elements; } }

    public void Load(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            int row = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'r')
                    {
                        _elements.Add(new Rat() { x = i, y = row });
                    }
                    else if (line[i] == '#')
                    {
                        _elements.Add(new Wall() { x = i, y = row });
                    }
                    else if (line[i] == 's')
                    {
                        _elements.Add(new Snake() { x = i, y = row });
                    }
                    
                }
                row++;
                
            }
        }
    }
}
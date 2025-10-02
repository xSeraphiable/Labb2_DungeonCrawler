
Console.Title = "Ame's DC";
Console.WriteLine("Detta är mitt Dungeon Crawler-spel");


Directory.SetCurrentDirectory(@"C:\Users\amand\source\repos\Labb2_DungeonCrawler\Labb2_DungeonCrawler\Levels");
Console.WriteLine(Directory.GetCurrentDirectory());

var levelOne = new LevelData();
levelOne.Load("Level1.txt");

foreach (var element in levelOne.Elements)
{
    Console.Write(element.displayChar);
}

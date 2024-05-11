using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("Birds.json");
var model = JsonConvert.DeserializeObject<Main>(jsonStr);

Console.WriteLine(jsonStr);

string jsonStr2 = await File.ReadAllTextAsync("MyanmarProverbs.json");
var model2 = JsonConvert.DeserializeObject<Main>(jsonStr);


Console.ReadLine();


public class Main
{
    public Tbl_Bird[] Tbl_Bird { get; set; }
}

public class Tbl_Bird
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}




using Newtonsoft.Json;

string json = System.IO.File.ReadAllText(@"response.json");


List<Root> items = JsonConvert.DeserializeObject<Root[]>(json).ToList();
char[] splitters = new char[] { '\n', ' ' };
List<string> x = items[0].description.Split(splitters, StringSplitOptions.RemoveEmptyEntries).ToList();
int LineNumber = 1;
Console.Write(LineNumber.ToString() + " " + items[1].description + "\n" + (++LineNumber).ToString() + " ");

for (int i = 2; i < items.Count - 1; i++)
{
    var asd = items[i].boundingPoly.vertices[0].y;
    var asd2 = items[i - 1].boundingPoly.vertices[0].y;

    if (asd - asd2 > 15) //alt köşelerdeki sapma değerini 15 olarak düşün.
    {
        LineNumber++;
        Console.Write("\n");
        Console.Write(LineNumber.ToString() + " " + items[i].description);
    }
    else
    {
        Console.Write(" " + items[i].description);
    }
}

Console.ReadLine();

public class Root
{
    public string? locale { get; set; }
    public string? description { get; set; }
    public BoundingPoly? boundingPoly { get; set; }
}
public class BoundingPoly
{
    public List<Vertex>? vertices { get; set; }
}
public class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
}
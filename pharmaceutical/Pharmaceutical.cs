namespace Medical;

public class Pharmaceutical
{
    public string Name { get; set; } = string.Empty;
    public int Amout { get; set; }
    public decimal Price { get; set; }
    public string DocName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Pharmaceutical() { }
    public Pharmaceutical(string name, int amout, decimal price, string docName)
    {
        Name = name;
        Amout = amout;
        Price = price;
        DocName = docName;
        CreatedAt = DateTime.Now;
    }
    internal void Display()
    {
        Console.WriteLine($@"Name: {Name},
     Amout: {Amout},
      Price: {Price},
       DocName: {DocName},
        CreatedAt: {CreatedAt}");
        System.Console.WriteLine("=============================\n");
    }

}
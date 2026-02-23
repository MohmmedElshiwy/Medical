using System.Text.Json;

namespace Medical;

public class PharmaceuticalManagment
{
    public PharmaceuticalManagment()
    {
        load();
    }
    private List<Pharmaceutical> pharmaceuticals = new();
    private readonly string filePath = "pharmaceuticals.json";

    #region Create Medicin

    internal List<Pharmaceutical> CreateMedicin(Pharmaceutical pharmaceutical)
    {
        if (pharmaceuticals.Any(p => !string.IsNullOrWhiteSpace(p.Name) && p.Name.Equals(pharmaceutical.Name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Medicine with this name already exists.");
            return pharmaceuticals;
        }
        pharmaceuticals.Add(pharmaceutical);
        Console.WriteLine("Medicine added successfully.");
        Save();
        return pharmaceuticals;
    }

    #endregion

    #region DisplayAll
    internal List<Pharmaceutical> DisplayAll()
    {
        if (pharmaceuticals.Count == 0)
        {
            Console.WriteLine("No medicines available.");
            return new List<Pharmaceutical>();
        }

        return pharmaceuticals;
    }
    #endregion


    #region Save

    private void Save()
    {

        var op = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(pharmaceuticals, op);
        File.WriteAllText(filePath, json);
    }

    #endregion

    #region Load

    internal void load()
    {
        if (!File.Exists(filePath))

            return;
        string json = File.ReadAllText(filePath);
        pharmaceuticals = JsonSerializer.Deserialize<List<Pharmaceutical>>(json) ?? new List<Pharmaceutical>();


    }


    #endregion

}




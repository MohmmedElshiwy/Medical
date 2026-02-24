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


    #region Search

    internal List<Pharmaceutical> Search(string name)
    {
        if (pharmaceuticals.Count == 0)
        {
            Console.WriteLine("No medicines available.");
        }
        return pharmaceuticals.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    #endregion





    #region update 
   internal void Update(string name)
    {

        if (pharmaceuticals.Count == 0)
        {
            System.Console.WriteLine("There's no Medicin ");
            return;
        }
        var result = pharmaceuticals.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Count == 0)
        {
            System.Console.WriteLine("There's no Medicin Matched");
            return;
        }
        if (result.Count == 1)
        {
            var updateMedicin = result[0];
            updateMedicin.Display();
            System.Console.WriteLine("Enter New Amount Medicin");
            if(int.TryParse(Console.ReadLine().Trim(),out int newAmount))
            updateMedicin.Amout = newAmount;
            System.Console.WriteLine("Enter New Price Medicin");
            if(decimal.TryParse(Console.ReadLine().Trim(),out decimal newPrice))
            updateMedicin.Price = newPrice;
            Save();
            return;

        }
        else
        {

            for (int i = 0; i < result.Count; i++)
            {
                System.Console.WriteLine($"Index : {i}");
                result[i].Display();
            }

        }
        System.Console.WriteLine("Enter The Number Of Med :");
        int input ;

    while( true){   if(!int.TryParse(Console.ReadLine().Trim(),out input)|| input <0 || input < result.Count)
        {
            System.Console.WriteLine("Invalid Input!");
            continue;
        }
            else
            {
                System.Console.WriteLine("Enter New Amunt Of Med: ");
            
                if(int.TryParse(Console.ReadLine().Trim(),out int newAmount))
                {
                    result[input-1].Amout= newAmount;
                }
                
                System.Console.WriteLine("Enter New Price Of Med: ");
                if(decimal.TryParse(Console.ReadLine().Trim(),out decimal newPrice))
                {
                    result[input-1].Price= newPrice;
                }
                Save();
            }
        };

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




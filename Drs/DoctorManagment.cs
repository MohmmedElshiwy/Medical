using System.Text.Json;

namespace Medical;

public class DoctorManagment
{
    private List<Doctor> Doctors = new();

    public Doctor ? CurrentDoctor { get; private set; }
    private readonly string filePath = "Doctors.json";
    public DoctorManagment()
    {
        load();
    }

    #region Create Doc
    internal void CreateDoctor(Doctor doctor)
    {
        if (Doctors.Any(d => d.IdNumber == doctor.IdNumber))
        {
            Console.WriteLine("Doctor with this ID already exists.");
            return;
        }
        Doctors.Add(doctor);
        Console.WriteLine("Doctor added successfully.");
        save();
    }

    #endregion




    #region Display
    internal List<Doctor> DisplayAll()
    {
        if (Doctors.Count == 0)
        {
            Console.WriteLine("No doctors available.");

        }

        return Doctors.ToList();
    }
    #endregion




    #region Search
    internal List<Doctor> SearchDoctor(string name)
    {
        if (Doctors.Count == 0)
        {
            System.Console.WriteLine("There are No Doctor");
        }
        return Doctors.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || d.IdNumber.Equals(name)).ToList();


    }

    #endregion




    #region Update

    internal void Update(string Search)
    {
        var result = SearchDoctor(Search);
        if (result.Count == 0)
        {
            System.Console.WriteLine("There are No Doctor Matched");
            return;
        }
        Doctor updateDoc;
        if (result.Count == 1)
        {
            updateDoc = result[0];
            updateDoc.Display();

        }
        else
        {
            for (int i = 0; i < result.Count; i++)
            {
                System.Console.WriteLine($"{i + 1} - {result[i].Name}");
                System.Console.WriteLine($" {result[i].Age}");
                System.Console.WriteLine($"{result[i].IdNumber}");
                System.Console.WriteLine("=================================\n");
            }
            System.Console.WriteLine("Enter the Number Of Doctor You Want to Update his inof");
            int input;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine()!.Trim(), out input) || input == 0 || input > result.Count)
                {
                    System.Console.WriteLine("invalid input");
                    continue;
                }

                else
                {
                    updateDoc = result[input - 1];

                    break;
                }

            }

    
        }

        System.Console.WriteLine("Enter new Name(press Enter to keep same):");
        string newName = Console.ReadLine()!.Trim();

        if (!string.IsNullOrWhiteSpace(newName))
        {
            updateDoc.Name = newName;
        }

        System.Console.WriteLine("Enter new Age(press Enter to keep same):");
        string ageInput = Console.ReadLine()!.Trim();
        if (int.TryParse(ageInput, out int newAge))
            updateDoc.Age = newAge;


        System.Console.WriteLine("Enter new ID(press Enter to keep same):");
        string newId = Console.ReadLine()!.Trim();
        if (!string.IsNullOrWhiteSpace(newId))

            updateDoc.IdNumber = newId;
        System.Console.WriteLine("Doctor updated successfully.");
        save();

    }



    #endregion




    #region Remove

    internal void RemoveDoc(string input)
    {
        if (Doctors?.Count == 0) System.Console.WriteLine("There Are no Doc Dound");
        var result = SearchDoctor(input);

        Doctor docRemove;
        if (result.Count == 1)
        {
            docRemove = result[0];
            docRemove.Display();
            Doctors?.Remove(docRemove);
            System.Console.WriteLine("Doc Removed Successfuly");


        }
        else
        {


            for (int i = 0; i < result.Count; i++)
            {
                System.Console.WriteLine($"{i + 1} - {result[i].Name}");
            }
        }
        Console.WriteLine("Enter the number of doctor to Remove:");

        int choice;
        while (!int.TryParse(Console.ReadLine()!.Trim(), out choice) || choice <= 0 || choice > result.Count)
        {
            Console.WriteLine("Invalid input, try again:");
        }
        docRemove = result[choice - 1];
        Doctors?.Remove(docRemove);

        System.Console.WriteLine("Doc Removed Successfuly");
        save();


    }


    #endregion




    #region Save

    private void save()
    {
        var op = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(Doctors, op);
        File.WriteAllText("Doctors.json", json);
    }

    #endregion




    #region Load 

    internal void load()
    {
        if (!File.Exists(filePath))
            return;
        string json = File.ReadAllText(filePath);
        Doctors = JsonSerializer.Deserialize<List<Doctor>>(json) ?? new List<Doctor>();
    }

    #endregion





    #region Login

    internal void Login()
    {
        if (Doctors.Count == 0)
        {
            System.Console.WriteLine("No doctors available. Please add a doctor first.");
            return;
        }
        int attempts = 0;
        int maxAttempts = 3;
        int delay = 5000; // 5 seconds

        while (attempts < maxAttempts)
        {
            System.Console.WriteLine("Enter UserName");
            string UserName = Console.ReadLine()!.Trim();
            System.Console.WriteLine("Enter Password");
            string Password = Console.ReadLine()!.Trim();
            var doctor = Doctors.FirstOrDefault(d => d.UserName.Equals( UserName, StringComparison.OrdinalIgnoreCase) && d.Password == Password);
            if (doctor != null)
            {
                System.Console.WriteLine("Login successful!");
                CurrentDoctor = doctor;
                return;
            }
            else
            {
                attempts++;
                System.Console.WriteLine($"Invalid credentials. Attempt {attempts} of {maxAttempts}.");
                if (attempts >=maxAttempts)
                {
                    System.Console.WriteLine($"Please wait 5 seconds before trying again.");
                    System.Threading.Thread.Sleep(delay);
                attempts = 0;
                System.Console.WriteLine("Try logging in again.");
                }
                else
                    System.Console.WriteLine("Please wait .5 seconds before trying again.");
                System.Threading.Thread.Sleep(500);

            }
        }
    }
    #endregion
}

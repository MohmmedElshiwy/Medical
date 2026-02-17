namespace Medical;

public class Doctor
{
    internal string Name { get; set; }
    internal int Age { get; set; }

    internal string IdNumber { get; set; }

    public Doctor(string name, int age, string idNumber)
    {
        Name = name;
        Age = age;
        IdNumber = idNumber;
    }
    public void Display()
    {
        System.Console.WriteLine($"Name : {Name}");
        System.Console.WriteLine($"Age : {Age}");
        System.Console.WriteLine($"ID : {IdNumber}");
        System.Console.WriteLine("=============================\n");

    }
}



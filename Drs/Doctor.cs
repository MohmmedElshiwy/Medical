namespace Medical;

public class Doctor
{
    public string Name { get; set; }= string.Empty;
    public int Age { get; set; }

    public string IdNumber { get; set; }= string.Empty;
    
    public string UserName { get; set; }= string.Empty;
    public string Password { get; set; }= string.Empty;
    public Doctor() { }

    public Doctor(string name, int age, string idNumber,string userName,string password)
    {
        Name = name;
        Age = age;
        IdNumber = idNumber;
        UserName = userName;
        Password = password;
    }
    public void Display()
    {
        System.Console.WriteLine($"Name : {Name}");
        System.Console.WriteLine($"Age : {Age}");
        System.Console.WriteLine($"ID : {IdNumber}");
        System.Console.WriteLine($"UserName : {UserName}");
        System.Console.WriteLine("=============================\n");


    }
}



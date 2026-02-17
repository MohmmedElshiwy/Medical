using Medical;

DoctorManagment managment = new();
System.Console.WriteLine("Loading.....");
System.Console.WriteLine("Welcome TO Pharmacy System Managment");

while (true)
{
    System.Console.WriteLine("\n 1.Doctors");
    System.Console.WriteLine("\n 2.Medicin");
    System.Console.WriteLine("\n 3.Sales");
    System.Console.WriteLine("\n 4.Suppliers");
    System.Console.WriteLine("\n 5.Purchases");
    System.Console.WriteLine("\n 6.Exite");

    if (!int.TryParse(Console.ReadLine().Trim(), out int Choise) || Choise <= 0 || Choise > 6)
    {
        System.Console.WriteLine("Invalid Input Try Again!");
        continue;
    }
    switch (Choise)
    {

        #region Doctors
        case 1:
            bool flag = true;
            while (flag)
            {
                System.Console.WriteLine("1.Add Dcotor");
                System.Console.WriteLine("2.Display All Dcotor");
                System.Console.WriteLine("3.Search Dcotor");
                System.Console.WriteLine("4.Update Dcotor");
                System.Console.WriteLine("5.Remove Dcotor");
                System.Console.WriteLine("6.Return To The Main Menu");
                if (!int.TryParse(Console.ReadLine().Trim(), out int DocInput) || DocInput <= 0 || DocInput > 6)
                {
                    System.Console.WriteLine("Invalid Input Try Again!");
                    continue;
                }
                switch (DocInput)
                {
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        managment.DisplayAll();
                        break;
                    case 3:
                        SearchDoctor();
                        break;
                    case 4:
                        UpdateDoctor();
                        break;
                        case 5:
                        RemoveDoc();
                        break;
                        
                    case 6:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Not implemented yet.");
                        break;
                }

            }
            break;


        #endregion

        case 6:
            System.Console.WriteLine("GoodBay");
            return;
        default:
            System.Console.WriteLine("invalid input");
            break;

    }
}

#region Doctors Methods






#region Add Doc
void AddDoctor()

{
    System.Console.WriteLine("Enter Name OF Doctor :\n");
    string Name = Console.ReadLine().Trim();

    System.Console.WriteLine("Enter Age : \n");
    int Age;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine().Trim(), out Age) || Age < 18)
        {
            System.Console.WriteLine("Age Shoud be 18 OR More");
            continue;
        }
        else break;

    }

    System.Console.WriteLine("Enter GovernmentId");
    string GovernmentId = Console.ReadLine().Trim();
    if (GovernmentId.Length < 14)
    {
        System.Console.WriteLine("Invalid ID");
        System.Console.WriteLine("UnSuccessfuly");
        return;
    }

    Doctor doctor = new(Name, Age, GovernmentId);
    managment.CreateDoctor(doctor);


}

#endregion





#region  Search
void SearchDoctor()
{
    System.Console.WriteLine("Enter Name Of Doc Or ID");
    string input = Console.ReadLine().Trim();
    var result = managment.SearchDoctor(input);
    if (result.Count == 0)
    {

        Console.WriteLine("Doctor not found.");
        return;
    }
    foreach (var d in result)
    {
        d.Display();
    }
}


#endregion





#region Update



void UpdateDoctor()
{
    System.Console.WriteLine("Enter The Name Of Doc");
    string name = Console.ReadLine().Trim();
    managment.Update(name);
}
#endregion





#region Remove
    
    void RemoveDoc()
{
    System.Console.WriteLine("Enter Name OF Doc You Want Remove");
    string input= Console.ReadLine()?.Trim();
    managment.RemoveDoc(input);
}
#endregion



#endregion




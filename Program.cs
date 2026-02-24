using Medical;

DoctorManagment managmentDoc = new();
managmentDoc.Login();
PharmaceuticalManagment managmentPharm = new();
System.Console.WriteLine("Loading.....");
System.Console.WriteLine("Welcome TO Pharmacy System Managment");

while (true)
{
    System.Console.WriteLine($"\nHello Dr.{managmentDoc.CurrentDoctor?.Name}, What Do You Want To Do ?\n");
    if (managmentDoc.CurrentDoctor?.Name == "Admin")
    {
        
    System.Console.WriteLine("\n 1.Doctors");
    }
    System.Console.WriteLine("\n 2.Medicin");
    System.Console.WriteLine("\n 3.Sales");
    System.Console.WriteLine("\n 4.Suppliers");
    System.Console.WriteLine("\n 5.Purchases");
    System.Console.WriteLine("\n 6.Exite");

    if (!int.TryParse(Console.ReadLine()!.Trim(), out int Choise) || Choise <= 0 || Choise > 6)
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
                if (!int.TryParse(Console.ReadLine()!.Trim(), out int DocInput) || DocInput <= 0 || DocInput > 6)
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
                        var docs = managmentDoc.DisplayAll();
                        for (int i = 0; i < docs.Count; i++)
                        {
                           System.Console.WriteLine($"\n{i + 1} - ");
                           docs[i].Display(); 
                        }
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
        #region Medicin
        case 2:
            bool flagMed = true;
            while (flagMed)
            {
                System.Console.WriteLine("1.Add Medicin");
                System.Console.WriteLine("2.Display All Medicin");
                System.Console.WriteLine("3.Search Medicin");
                System.Console.WriteLine("4.Update Medicin");
                System.Console.WriteLine("5.Remove Medicin");
                System.Console.WriteLine("6.Return To The Main Menu");
                if (!int.TryParse(Console.ReadLine()!.Trim(), out int MedInput) || MedInput <= 0 || MedInput > 6)
                {
                    System.Console.WriteLine("Invalid Input Try Again!");
                    continue;
                }
                switch (MedInput)
                {
                    case 1:
                        AddMedicin();
                        break;
                    case 2:
                        var med = managmentPharm.DisplayAll();
                        for (int i = 0; i < med.Count; i++)
                        {
                            System.Console.WriteLine($@"{i + 1} - {med[i].Name} 
                          Amounr:  {med[i].Amout}
                          Price:  {med[i].Price}
                          DocName:  {med[i].DocName}
                          CreatedAt  {med[i].CreatedAt}
                            ");
                        }
                        break;
                    case 3:
                        SearchMedicin();
                        break;
                    case 4:
                       UpdateMedicin();
                        break;
                    case 5:
                        //RemoveMedicin(); --- IGNORE ---
                        break;
                    case 6:
                        flagMed = false;
                        break;
                    default:
                        Console.WriteLine("Not implemented yet.");
                        break;
                }

            }
            break;
        #endregion
        case 6:
            System.Console.WriteLine($"GoodBay Dr : {managmentDoc.CurrentDoctor?.Name ?? "Admin"}!");
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
    string Name = Console.ReadLine()!.Trim();

    System.Console.WriteLine("Enter Age : \n");
    int Age;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine()!.Trim(), out Age) || Age < 18)
        {
            System.Console.WriteLine("Age Shoud be 18 OR More");
            continue;
        }
        else break;

    }

    System.Console.WriteLine("Enter GovernmentId");
    string GovernmentId = Console.ReadLine()!.Trim();
    if (GovernmentId.Length < 14)
    {
        System.Console.WriteLine("Invalid ID");
        System.Console.WriteLine("UnSuccessfuly");
        return;
    }
    System.Console.WriteLine("Enter UserName");
    string UserName = Console.ReadLine()!.Trim();
    System.Console.WriteLine("Enter Password");
    string Password = Console.ReadLine()!.Trim();
    Doctor doctor = new(Name, Age, GovernmentId,UserName,Password);
    managmentDoc.CreateDoctor(doctor);


}

#endregion





#region  Search
void SearchDoctor()
{
    System.Console.WriteLine("Enter Name Of Doc Or ID");
    string input = Console.ReadLine()!.Trim();
    var result = managmentDoc.SearchDoctor(input);
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
    string name = Console.ReadLine()!.Trim();
    managmentDoc.Update(name);
}
#endregion





#region Remove

void RemoveDoc()
{
    System.Console.WriteLine("Enter Name OF Doc You Want Remove");
    string input = Console.ReadLine()!.Trim();
    managmentDoc.RemoveDoc(input);
}
#endregion



#endregion



#region Medicin Methods

void AddMedicin()
{
    System.Console.WriteLine("Enter Name OF Medicin :\n");
    string Name = Console.ReadLine()!.Trim();

    System.Console.WriteLine("Enter Amout : \n");
    int Amout;
    while (true)
    {
        if (!int.TryParse(Console.ReadLine()!.Trim(), out Amout) || Amout < 0)
        {
            System.Console.WriteLine("Amout Shoud be 0 OR More");
            continue;
        }
        else break;

    }

    System.Console.WriteLine("Enter Price");
    decimal Price;
    while (true)
    {
        if (!decimal.TryParse(Console.ReadLine()!.Trim(), out Price) || Price < 0)
        {
            System.Console.WriteLine("Price Shoud be 0 OR More");
            continue;
        }
        else break;

    }

  
    string DocName =managmentDoc.CurrentDoctor!.Name;
    Pharmaceutical pharmaceutical = new(Name, Amout, Price, DocName);
    managmentPharm.CreateMedicin(pharmaceutical);
}




#region Search
    

    void SearchMedicin()
{
    System.Console.WriteLine("Enter Name Of Medicin");
    string input = Console.ReadLine()!.Trim();
    var result = managmentPharm.Search(input);
    if(result.Count == 0)
    {
        System.Console.WriteLine("Medicin Not Found");
        return;
    }
    foreach(var m in result)
    {
        m.Display();
    }
}
    #endregion



#region Update

void UpdateMedicin()
{
    
    System.Console.WriteLine("Enter Name Of Medicin");
    string name = Console.ReadLine()!.Trim();
    managmentPharm.Update(name);
}    
#endregion


#endregion
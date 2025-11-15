
Console.Title = " CONTACTS  ";
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\n           Welcome to your Contact List\n ");
Console.ResetColor();
Console.WriteLine(" Press any key to continue... ");
Console.ReadKey();
Console.Clear();

bool runing = true;
List<int> IDs = new List<int>();
Dictionary<int, string> Names = new Dictionary<int, string>();
Dictionary<int, string> LastNames = new Dictionary<int, string>();
Dictionary<int, string> Addresses = new Dictionary<int, string>();
Dictionary<int, string> Telephones = new Dictionary<int, string>();
Dictionary<int, string> Emails = new Dictionary<int, string>();
Dictionary<int, int> Ages = new Dictionary<int, int>();
Dictionary<int, bool> BestFriends = new Dictionary<int, bool>();

while (runing)
{
    Console.Clear();

    // MENU ESTILIZADO
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("               CONTACTS LIST               ");
    Console.WriteLine(" |----------------------------------------|");
    Console.WriteLine("  1. Add Contact         2. View Contacts  ");
    Console.WriteLine("  3. Search Contact      4. Modify Contact ");
    Console.WriteLine("  5. Delete Contact      6. Exit           ");
    Console.ResetColor();
    Console.Write("\n Enter your option number: ");

    string optionInput = Console.ReadLine() ?? "";
    while (!IsNumeric(optionInput))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Please enter a valid number");
        Console.ResetColor();
        Console.Write(" Enter your option number: ");
        optionInput = Console.ReadLine() ?? "";
    }
    int Option = Convert.ToInt32(optionInput);

    Console.Clear();
    switch (Option)
    {
        case 1:
            AddContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);
            PressToContinue();
            break;

        case 2:
            ShowContacts(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);
            PressToContinue();
            break;

        case 3:
            SearchContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);
            PressToContinue();
            break;

        case 4:
            ModifyContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);
            PressToContinue();
            break;

        case 5:
            DeleteContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);
            PressToContinue();
            break;

        case 6:
            runing = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Leaving the program... ");
            Console.ResetColor();
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Invalid Option. Try Again.");
            Console.ResetColor();
            PressToContinue();
            break;
    }
}

bool IsNumeric(string Text)
{
    Text ??= "";
    if (string.IsNullOrEmpty(Text))
        return false;
    foreach (char c in Text)
    {
        if (!char.IsDigit(c))
            return false;
    }
    return true;
}

void PressToContinue()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("\n Press any key to continue... ");
    Console.ResetColor();
    Console.ReadKey();
    Console.Clear();
}

// Funciones 
void AddContact(List<int> IDs,
    Dictionary<int, string> Names, Dictionary<int, string> LastNames,
    Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
    Dictionary<int, string> Emails, Dictionary<int, int> Ages,
    Dictionary<int, bool> BestFriends)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" --ADD NEW CONTACT-- ");
    Console.ResetColor();

    Console.Write(" Name: ");
    string Name = Console.ReadLine() ?? "";
    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This field cannot be empty.");
        Console.ResetColor();
        Console.Write(" Name: ");
        Name = Console.ReadLine() ?? "";
    }
    Console.Write(" LastName: ");
    string LastName = Console.ReadLine() ?? "";
    while (string.IsNullOrWhiteSpace(LastName))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This field cannot be empty.");
        Console.ResetColor();
        Console.Write(" LastName: ");
        LastName = Console.ReadLine() ?? "";
    }
    string Email;
    while (true)
    {
        Console.Write(" Email: ");
        Email = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(Email))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Email cannot be empty.");
            Console.ResetColor();
            Console.Write(" Email: ");
            Email = Console.ReadLine() ?? "";
        }
        if (IsValidEmail(Email))
            break;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Invalid Email. Enter a valid Email.");
        Console.ResetColor();
    }
    Console.Write(" Address: ");
    string Address = Console.ReadLine() ?? "";
    while (string.IsNullOrWhiteSpace(Address))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This field cannot be empty.");
        Console.ResetColor();
        Console.Write(" Address: ");
        Address = Console.ReadLine() ?? "";
    }
    Console.Write(" Telephone: ");
    string Telephone = Console.ReadLine() ?? "";
    while (string.IsNullOrWhiteSpace(Telephone))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This field cannot be empty.");
        Console.ResetColor();
        Console.Write(" Telephone: ");
        Telephone = Console.ReadLine() ?? "";
    }
    Console.Write(" Age: ");
    string AgeInput = Console.ReadLine() ?? "";
    while (!IsNumeric(AgeInput))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Enter a valid number.");
        Console.ResetColor();
        Console.Write(" Enter Age: ");
        AgeInput = Console.ReadLine() ?? "";
    }
    int Age = Convert.ToInt32(AgeInput);
    Console.WriteLine(" Is a BestFriend? \n1.Yes \n2.No ");
    string BestInput = Console.ReadLine() ?? "";
    while (!IsNumeric(BestInput) || (BestInput != "1" && BestInput != "2"))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Enter only 1 or 2.");
        Console.ResetColor();
        BestInput = Console.ReadLine() ?? "";
    }
    bool IsBestFriend = (BestInput == "1");

    int ID = IDs.Count + 1;

    IDs.Add(ID);
    Names.Add(ID, Name);
    LastNames.Add(ID, LastName);
    Addresses.Add(ID, Address);
    Telephones.Add(ID, Telephone);
    Emails.Add(ID, Email);
    Ages.Add(ID, Age);
    BestFriends.Add(ID, IsBestFriend);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\n Contact successfully added with ID: {ID}\n");
    Console.ResetColor();
}

void ShowContacts(List<int> IDs,
    Dictionary<int, string> Names, Dictionary<int, string> LastNames,
    Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
    Dictionary<int, string> Emails, Dictionary<int, int> Ages,
    Dictionary<int, bool> BestFriends)
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("\n --CONTACT LIST-- \n");
    Console.ResetColor();

    if (IDs.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" No contacts registered. ");
        Console.ResetColor();
        return;
    }

    foreach (int ID in IDs)
    {
        string Best = BestFriends[ID] ? "Yes" : "No";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"ID: {ID} | {Names[ID]} {LastNames[ID]} | {Emails[ID]} | {Addresses[ID]} | {Telephones[ID]} | Age: {Ages[ID]} | BestFriend: {Best}");
        Console.ResetColor();
    }
}

void SearchContact(List<int> IDs,
    Dictionary<int, string> Names, Dictionary<int, string> LastNames,
    Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
    Dictionary<int, string> Emails, Dictionary<int, int> Ages,
    Dictionary<int, bool> BestFriends)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" --SEARCH CONTACT-- ");
    Console.ResetColor();

    Console.Write(" Enter the name or last name: ");
    string Term = Console.ReadLine() ?? "";
    while (string.IsNullOrWhiteSpace(Term))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" This field cannot be empty.");
        Console.ResetColor();
        Console.Write(" Enter the name or last name: ");
        Term = Console.ReadLine() ?? "";
    }

    bool Found = false;
    foreach (int ID in IDs)
    {
        if (Names[ID].ToLower().Contains(Term.ToLower()) || LastNames[ID].ToLower().Contains(Term.ToLower()))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nID: {ID} | {Names[ID]} {LastNames[ID]} | {Emails[ID]} | {Addresses[ID]} | {Telephones[ID]} | Age: {Ages[ID]} | BestFriend: {(BestFriends[ID] ? "Yes" : "No")}");
            Console.ResetColor();
            Found = true;
        }
    }

    if (!Found)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Contact not found.");
        Console.ResetColor();
    }
}

void ModifyContact(List<int> IDs,
    Dictionary<int, string> Names, Dictionary<int, string> LastNames,
    Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
    Dictionary<int, string> Emails, Dictionary<int, int> Ages,
    Dictionary<int, bool> BestFriends)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" --MODIFY CONTACT-- ");
    Console.ResetColor();

    Console.Write(" Enter the ID to modify: ");
    string idInput = Console.ReadLine() ?? "";
    while (!IsNumeric(idInput))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Enter a valid number.");
        Console.ResetColor();
        Console.Write(" Enter the ID to modify: ");
        idInput = Console.ReadLine() ?? "";
    }
    int ID = Convert.ToInt32(idInput);

    if (!IDs.Contains(ID))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" The ID does not exist.");
        Console.ResetColor();
        return;
    }

    Console.WriteLine(" Leave the field blank if you don't want to modify it.");

    Console.Write($" New name ({Names[ID]}): ");
    string NewName = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewName)) Names[ID] = NewName;

    Console.Write($" New LastName ({LastNames[ID]}): ");
    string NewLast = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewLast)) LastNames[ID] = NewLast;

    Console.Write($" New Email ({Emails[ID]}): ");
    string NewEmail = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewEmail) && IsValidEmail(NewEmail))
        Emails[ID] = NewEmail;

    Console.Write($" New Address ({Addresses[ID]}): ");
    string NewAddress = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewAddress)) Addresses[ID] = NewAddress;

    Console.Write($" New Telephone ({Telephones[ID]}): ");
    string NewPhone = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewPhone)) Telephones[ID] = NewPhone;

    Console.Write($" New Age ({Ages[ID]}): ");
    string NewAgeStr = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(NewAgeStr) && IsNumeric(NewAgeStr))
        Ages[ID] = Convert.ToInt32(NewAgeStr);

    Console.Write(" Are you still be best friend?  (1. Yes / 2. No / Enter to skip): ");
    string bestStr = Console.ReadLine() ?? "";
    if (!string.IsNullOrWhiteSpace(bestStr) && IsNumeric(bestStr))
        BestFriends[ID] = Convert.ToInt32(bestStr) == 1;

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Contact successfully modified.\n");
    Console.ResetColor();
}

void DeleteContact(List<int> IDs,
    Dictionary<int, string> Names, Dictionary<int, string> LastNames,
    Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
    Dictionary<int, string> Emails, Dictionary<int, int> Ages,
    Dictionary<int, bool> BestFriends)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" --DELETE CONTACT-- ");
    Console.ResetColor();

    Console.Write(" Enter the ID to delete: ");
    string idInput = Console.ReadLine() ?? "";
    while (!IsNumeric(idInput))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Enter a valid number.");
        Console.ResetColor();
        Console.Write(" Enter the ID to delete: ");
        idInput = Console.ReadLine() ?? "";
    }
    int ID = Convert.ToInt32(idInput);

    if (!IDs.Contains(ID))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" The ID does not exist.");
        Console.ResetColor();
        return;
    }

    Console.Write($" Are you sure that you want to delete {Names[ID]} {LastNames[ID]}?  (1. Yes / 2. No): ");
    string confirm = Console.ReadLine() ?? "";
    while (!IsNumeric(confirm) || (confirm != "1" && confirm != "2"))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Enter only 1 or 2.");
        Console.ResetColor();
        Console.Write($" Are you sure that you want to delete {Names[ID]} {LastNames[ID]}?  (1. Yes / 2. No): ");
        confirm = Console.ReadLine() ?? "";
    }

    if (confirm != "1")
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Cancelled.");
        Console.ResetColor();
        return;
    }

    IDs.Remove(ID);
    Names.Remove(ID);
    LastNames.Remove(ID);
    Addresses.Remove(ID);
    Telephones.Remove(ID);
    Emails.Remove(ID);
    Ages.Remove(ID);
    BestFriends.Remove(ID);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" Contact successfully deleted.\n");
    Console.ResetColor();
}

bool IsValidEmail(string Email)
{
    if (string.IsNullOrEmpty(Email))
        return false;

    Email = Email.ToLower();
    string[] validDomains = { "@gmail.com", "@hotmail.com", "@outlook.com", "@yahoo.com", "@icloud.com", "@edu.com" };

    foreach (string domain in validDomains)
    {
        if (Email.Contains(domain) && Email.Contains("@") && Email.IndexOf('@') > 0)
            return true;
    }
    return false;
}
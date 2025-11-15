using System;
using System.Collections.Generic;

namespace ContactesClassV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to my contacts list ");

            bool runing= true;
            List<int> IDs= new List<int>();
            Dictionary<int, string> Names= new Dictionary<int, string> ();
            Dictionary<int, string> LastNames= new Dictionary<int, string> ();
            Dictionary<int, string> Addresses= new Dictionary<int, string> ();
            Dictionary<int, string> Telephones= new Dictionary<int, string> ();
            Dictionary<int, string> Emails= new Dictionary<int, string> ();
            Dictionary<int, int> Ages= new Dictionary<int, int> ();
            Dictionary<int, bool> BestFriends= new Dictionary<int, bool> ();

            while (runing)
            {
                Console.WriteLine(@"  1. Add Contact      2. View Contacts        3. Search Contact    
  4. Modify Contact   5. Delete Contact    6. Exit ");

                Console.WriteLine(" Enter your option number: ");

                int Option= Convert.ToInt32(Console.ReadLine());

                switch (Option)
                {
                    case 1:
                        AddContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);

                        break;

                    case 2:
                        ShowContacts(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);

                        break;

                    case 3:
                        SearchContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);

                        break;

                    case 4:
                        ModifyContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);

                        break;

                    case 5:
                        DeleteContact(IDs, Names, LastNames, Addresses, Telephones, Emails, Ages, BestFriends);

                        break;

                    case 6:
                        runing= false;
                        Console.WriteLine(" Leaving the program...");

                        break;

                    default:
                        Console.WriteLine(" Invalid Option. Try Again.");

                        break;
                }
            }
        }

        static bool IsNumeric(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;
            foreach (char c in Text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        static void AddContact(List<int> IDs, 
            Dictionary<int, string> Names, Dictionary<int, string> LastNames,
            Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
            Dictionary<int, string> Emails, Dictionary<int, int> Ages, 
            Dictionary<int, bool> BestFriends)
        {
            Console.WriteLine(" --Add New Contact-- ");

            Console.Write(" Name: ");
            string Name= Console.ReadLine();

            Console.Write(" LastName: ");
            string LastName= Console.ReadLine();

            string Email;
            while (true)
            {
                Console.Write(" Email: ");
                Email= Console.ReadLine();

                if (IsValidEmail(Email))

                    break;

                else
                    Console.WriteLine(" Invalid Email. Enter a valid Email.");
            }

            Console.Write(" Address: ");
            string Address= Console.ReadLine();

            Console.Write(" Telephone: ");
            string Telephone= Console.ReadLine();

            Console.Write(" Age: ");
            string AgeInput = Console.ReadLine();
            while (!IsNumeric(AgeInput))
            {
                Console.WriteLine(" Enter a valid number.");
                Console.Write(" Enter Age: ");
                AgeInput= Console.ReadLine();
            }
            int Age= Convert.ToInt32(AgeInput);

            Console.WriteLine(" Is a BestFriend? \n1.Yes \n2.No ");
            string BestInput= Console.ReadLine();
            while (!IsNumeric(BestInput)||(BestInput!= "1" && BestInput!= "2"))
            {
                Console.WriteLine(" Debe digitar 1 o 2.");
                BestInput= Console.ReadLine();
            }
            bool IsBestFriend=(BestInput== "1");

            int ID= IDs.Count+ 1;

            IDs.Add(ID);
            Names.Add(ID, Name);
            LastNames.Add(ID, LastName);
            Addresses.Add(ID, Address);
            Telephones.Add(ID, Telephone);
            Emails.Add(ID, Email);
            Ages.Add(ID, Age);
            BestFriends.Add(ID, IsBestFriend);

            Console.WriteLine($"Contact successfully added with ID: {ID}\n");
        }
        static void ShowContacts(List<int> IDs, 
            Dictionary<int, string> Names, Dictionary<int, string> LastNames,
            Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
            Dictionary<int, string> Emails, Dictionary<int, int> Ages, 
            Dictionary<int, bool> BestFriends)
        {
            Console.WriteLine("\n --Contact List-- ");

            if (IDs.Count== 0)
            {
                Console.WriteLine(" No contacts registered. ");
                return; 
            }
            Console.WriteLine(" ID          Name            LastName             Email                      Address                 Telephone               Age         BestFriend ");
            Console.WriteLine();
            foreach (int ID in IDs)
            {
                string Best= BestFriends[ID] ? "Yes" : "No";
                Console.WriteLine($"{ID,-3} {Names[ID],-15} {LastNames[ID],-16} {Emails[ID],-25} {Addresses[ID],-20} {Telephones[ID],-16} {Ages[ID],-5} {Best}");
            }
            Console.WriteLine();
        }
        static void SearchContact(List<int> IDs, 
            Dictionary<int, string> Names, Dictionary<int, string> LastNames,
            Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
            Dictionary<int, string> Emails, Dictionary<int, int> Ages, 
            Dictionary<int, bool> BestFriends)
        {
            Console.WriteLine(" Enter the name or lastname for search: ");
            string Term= Console.ReadLine().ToLower();
            bool Found= false;
            foreach (int ID in IDs)
            {
                if (Names[ID].ToLower().Contains(Term) || LastNames[ID].ToLower().Contains(Term))
                {
                    Console.WriteLine($"\nID: {ID}");
                    Console.WriteLine($" Name: {Names[ID]} {LastNames[ID]}");
                    Console.WriteLine($" Email: {Emails[ID]}");
                    Console.WriteLine($" Address: {Addresses[ID]}");
                    Console.WriteLine($" Telephone: {Telephones[ID]}");
                    Console.WriteLine($" Age: {Ages[ID]}");
                    Console.WriteLine($" BestFriend: {(BestFriends[ID] ? "Yes" : "No")}");
                    Found= true;
                }
            }
            if (!Found)
                Console.WriteLine(" Contact not found.");
        }
        static void ModifyContact(List<int> IDs, 
            Dictionary<int, string> Names, Dictionary<int, string> LastNames,
            Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
            Dictionary<int, string> Emails, Dictionary<int, int> Ages, 
            Dictionary<int, bool> BestFriends)
        {
            Console.Write("\nEnter the ID to modify: ");
            int ID= Convert.ToInt32(Console.ReadLine());

            if (!IDs.Contains(ID))
            {
                Console.WriteLine(" The ID does not exist.");
                return;
            }
            Console.WriteLine(" Leave the field blank if you don't wish to modify it.");

            Console.Write($" New name ({Names[ID]}): ");
            string NewName= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewName)) Names[ID]= NewName;

            Console.Write($" New LastName ({LastNames[ID]}): ");
            string NewLast= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewLast)) LastNames[ID]= NewLast;

            Console.Write($" New Email ({Emails[ID]}): ");
            string NewEmail= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewEmail) && IsValidEmail(NewEmail))
                Emails[ID]= NewEmail;

            Console.Write($" New Address ({Addresses[ID]}): ");
            string NewAddress= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewAddress)) Addresses[ID]= NewAddress;

            Console.Write($" New Telephone ({Telephones[ID]}): ");
            string NewPhone= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewPhone)) Telephones[ID]= NewPhone;

            Console.Write($" New Age ({Ages[ID]}): ");
            string NewAgeStr= Console.ReadLine();
            if (!string.IsNullOrEmpty(NewAgeStr)) Ages[ID]= Convert.ToInt32(NewAgeStr);

            Console.Write(" Are you still be best friend?  (1. Yes / 2. No / Press enter to leave it as is): ");
            string bestStr= Console.ReadLine();
            if (!string.IsNullOrEmpty(bestStr))
                BestFriends[ID]= Convert.ToInt32(bestStr)== 1;
            Console.WriteLine(" Contact successfully modified.\n");
        }
        static void DeleteContact(List<int> IDs, 
            Dictionary<int, string> Names, Dictionary<int, string> LastNames,
            Dictionary<int, string> Addresses, Dictionary<int, string> Telephones,
            Dictionary<int, string> Emails, Dictionary<int, int> Ages, 
            Dictionary<int, bool> BestFriends)
        {
            Console.WriteLine(" Enter the ID to delete: ");
            int ID= Convert.ToInt32(Console.ReadLine());
            if (!IDs.Contains(ID))
            {
                Console.WriteLine(" The ID does not exist.");
                return;
            }
            Console.Write($" Are you sure that you want to delete {Names[ID]} {LastNames[ID]}?  (1. Yes / 2. No): ");
            int confirm= Convert.ToInt32(Console.ReadLine());
            if (confirm!= 1)
            {
                Console.WriteLine(" Canceled. ");
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
            Console.WriteLine(" Contact successfully deleted.\n");
        }
        static bool IsValidEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email)) 
                return false;
            Email= Email.ToLower();
            string[] validDomains= { "@gmail.com", "@hotmail.com", "@outlook.com", "@yahoo.com", "@icloud.com", "@edu.com" };
            foreach (string domain in validDomains)
            {
                if (Email.Contains(domain) && Email.Contains("@") && Email.IndexOf('@')> 0)
                    return true;
            }
            return false;
        }
    }
}
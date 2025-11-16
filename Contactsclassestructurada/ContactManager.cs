#nullable disable
using System;
using System.Collections.Generic;

public class ContactManager
{
    private List<Contact> Contacts = new List<Contact>();

    public void AddContact()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" --ADD NEW CONTACT-- ");
        Console.ResetColor();

        Console.Write(" Name: ");
        string name = ReadNonEmpty();

        Console.Write(" LastName: ");
        string lastName = ReadNonEmpty();

        string email;
        while (true)
        {
            Console.Write(" Email: ");
            email = ReadNonEmpty();
            if (IsValidEmail(email)) break;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Invalid Email. Enter a valid Email.");
            Console.ResetColor();
        }

        Console.Write(" Address: ");
        string address = ReadNonEmpty();

        Console.Write(" Telephone: ");
        string telephone = ReadNonEmpty();

        Console.Write(" Age: ");
        string ageStr = Console.ReadLine();
        while (!IsNumeric(ageStr))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Enter a valid number.");
            Console.ResetColor();
            Console.Write(" Age: ");
            ageStr = Console.ReadLine();
        }
        int age = Convert.ToInt32(ageStr);

        Console.WriteLine(" Is a BestFriend? \n1.Yes \n2.No ");
        string best = Console.ReadLine();
        while (!IsNumeric(best) || (best != "1" && best != "2"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Enter only 1 or 2.");
            Console.ResetColor();
            best = Console.ReadLine();
        }
        bool isBest = best == "1";

        int id = Contacts.Count + 1;

        Contact newContact = new Contact(id, name, lastName, address, telephone, email, age, isBest);
        Contacts.Add(newContact);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n Contact successfully added with ID: {id}\n");
        Console.ResetColor();
    }

    public void ShowContacts()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\n --CONTACT LIST-- \n");
        Console.ResetColor();

        if (Contacts.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" No contacts registered. ");
            Console.ResetColor();
            return;
        }

        foreach (var c in Contacts)
            c.Show();
    }

    public void SearchContact()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" --SEARCH CONTACT-- ");
        Console.ResetColor();

        Console.Write(" Enter the name or last name: ");
        string term = ReadNonEmpty().ToLower();

        bool found = false;

        foreach (var c in Contacts)
        {
            if (c.Name.ToLower().Contains(term) || c.LastName.ToLower().Contains(term))
            {
                c.Show();
                found = true;
            }
        }

        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Contact not found.");
            Console.ResetColor();
        }
    }

    public void ModifyContact()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" --MODIFY CONTACT-- ");
        Console.ResetColor();

        Console.Write(" Enter the ID to modify: ");
        string idStr = Console.ReadLine();
        while (!IsNumeric(idStr))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Enter a valid number.");
            Console.ResetColor();
            Console.Write(" Enter the ID to modify: ");
            idStr = Console.ReadLine();
        }
        int id = Convert.ToInt32(idStr);

        Contact c = Contacts.Find(x => x.ID == id);
        if (c == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" The ID does not exist.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(" Leave empty if you don't want to modify it.");

        Console.Write($" New name ({c.Name}): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName)) c.Name = newName;

        Console.Write($" New LastName ({c.LastName}): ");
        string newLast = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLast)) c.LastName = newLast;

        Console.Write($" New Email ({c.Email}): ");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail) && IsValidEmail(newEmail))
            c.Email = newEmail;

        Console.Write($" New Address ({c.Address}): ");
        string newAddr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddr)) c.Address = newAddr;

        Console.Write($" New Telephone ({c.Telephone}): ");
        string newTel = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTel)) c.Telephone = newTel;

        Console.Write($" New Age ({c.Age}): ");
        string newAge = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAge) && IsNumeric(newAge))
            c.Age = Convert.ToInt32(newAge);

        Console.Write(" Are you still best friends? (1. Yes / 2. No / Enter to skip): ");
        string best = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(best) && IsNumeric(best))
            c.BestFriend = Convert.ToInt32(best) == 1;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" Contact successfully modified.\n");
        Console.ResetColor();
    }

    public void DeleteContact()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" --DELETE CONTACT-- ");
        Console.ResetColor();

        Console.Write(" Enter the ID to delete: ");
        string idStr = Console.ReadLine();
        while (!IsNumeric(idStr))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Enter a valid number.");
            Console.ResetColor();
            Console.Write(" Enter the ID to delete: ");
            idStr = Console.ReadLine();
        }
        int id = Convert.ToInt32(idStr);

        Contact c = Contacts.Find(x => x.ID == id);
        if (c == null)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" The ID does not exist.");
            Console.ResetColor();
            return;
        }

        Console.Write($" Are you sure that you want to delete {c.Name} {c.LastName}?  (1. Yes / 2. No): ");
        string confirm = Console.ReadLine();
        while (!IsNumeric(confirm) || (confirm != "1" && confirm != "2"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Enter only 1 or 2.");
            Console.ResetColor();
            Console.Write($" Are you sure that you want to delete {c.Name} {c.LastName}?  (1. Yes / 2. No): ");
            confirm = Console.ReadLine();
        }

        if (confirm == "1")
        {
            Contacts.Remove(c);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Contact successfully deleted.\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Cancelled.");
            Console.ResetColor();
        }
    }

    private static bool IsNumeric(string text)
    {
        if (string.IsNullOrEmpty(text)) return false;
        foreach (char c in text)
            if (!char.IsDigit(c)) return false;
        return true;
    }

    private static string ReadNonEmpty()
    {
        string text = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(text))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" This field cannot be empty.");
            Console.ResetColor();
            text = Console.ReadLine();
        }
        return text;
    }

    private static bool IsValidEmail(string Email)
    {
        Email = Email.ToLower();
        string[] validDomains = { "@gmail.com", "@hotmail.com", "@outlook.com", "@yahoo.com", "@icloud.com", "@edu.com" };

        foreach (string d in validDomains)
        {
            if (Email.Contains(d) && Email.Contains("@") && Email.IndexOf('@') > 0)
                return true;
        }

        return false;
    }
}

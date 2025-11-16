#nullable disable
using System;

public class Program
{
    public static void Main()
    {
        Console.Title = " CONTACTS  ";
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n           Welcome to your Contact List\n ");
        Console.ResetColor();
        Console.WriteLine(" Press any key to continue... ");
        Console.ReadKey();
        Console.Clear();

        ContactManager manager = new ContactManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("               CONTACTS LIST               ");
            Console.WriteLine(" |----------------------------------------|");
            Console.WriteLine("  1. Add Contact         2. View Contacts  ");
            Console.WriteLine("  3. Search Contact      4. Modify Contact ");
            Console.WriteLine("  5. Delete Contact      6. Exit           ");
            Console.ResetColor();
            Console.Write("\n Enter your option number: ");

            string option = Console.ReadLine();
            while (!IsNumeric(option))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Please enter a valid number");
                Console.ResetColor();
                Console.Write(" Enter your option number: ");
                option = Console.ReadLine();
            }
            int selected = Convert.ToInt32(option);

            Console.Clear();
            switch (selected)
            {
                case 1: manager.AddContact(); Pause(); break;
                case 2: manager.ShowContacts(); Pause(); break;
                case 3: manager.SearchContact(); Pause(); break;
                case 4: manager.ModifyContact(); Pause(); break;
                case 5: manager.DeleteContact(); Pause(); break;
                case 6:
                    running = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n Leaving the program... ");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Invalid Option. Try Again.");
                    Console.ResetColor();
                    Pause();
                    break;
            }
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n Press any key to continue... ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        static bool IsNumeric(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            foreach (char c in text)
                if (!char.IsDigit(c)) return false;

            return true;
        }
    }
}

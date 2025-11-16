#nullable disable
using System;

public class Contact
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool BestFriend { get; set; }

    public Contact(int id, string name, string lastName, string address, string telephone,
        string email, int age, bool bestFriend)
    {
        ID = id;
        Name = name;
        LastName = lastName;
        Address = address;
        Telephone = telephone;
        Email = email;
        Age = age;
        BestFriend = bestFriend;
    }

    public void Show()
    {
        string best = BestFriend ? "Yes" : "No";
        Console.WriteLine($"ID: {ID} | {Name} {LastName} | {Email} | {Address} | {Telephone} | Age: {Age} | BestFriend: {best}");
    }
}

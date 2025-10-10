int number = 0;

Console.WriteLine("Please insert a value: ");
number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if (number % 2 == 0)
{
    Console.WriteLine("The inserted value is even.");
}
else
{
    Console.WriteLine("The inserted value is uneven.");
}
Console.ReadKey();
using ADONET_Demo.Service;
using Sharprompt;

string choice = Prompt.Select("", new string[] { "User qo'shish", "Ma'lumot o'chirish" });
if (choice == "User qo'shish")
{
    Console.Write("Ismni kiriring: ");
    string name = Console.ReadLine();

    Console.Write("Yoshni kiriring: ");
    int age = int.Parse(Console.ReadLine());

    UserService.GenericCreate(name, age);
}
else
{
    Console.Write("Database nomini kiriting: ");
    string DatabaseName = Console.ReadLine();

    Console.Write("Table nomini kiriting: ");
    string TableName = Console.ReadLine();

    Console.WriteLine("Shartni kiriting(WHERE bilan boshlagan holda): ");
    string Condition = Console.ReadLine();

    UserService.GenericDelete(DatabaseName, TableName, Condition);
}
    //UserService.GetById(DatabaseName, TableName, Condition);

using ADONET_Demo.Service;


Console.Write("Database nomini kiriting: ");
string DatabaseName = Console.ReadLine();

Console.Write("Table nomini kiriting: ");
string TableName = Console.ReadLine();

Console.WriteLine("Shartni kiriting(WHERE bilan boshlagan holda): ");
string Condition = Console.ReadLine();

//UserService.GetById(DatabaseName, TableName, Condition);
//UserService.GenericUserDelete(DatabaseName, TableName, Condition);
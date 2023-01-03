// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.Write("What is your first name: ");
string? FirstName = Console.ReadLine(); // ReadLine allows you to insert a value into what will be used as a variable.

Console.WriteLine($"Your first name is {FirstName}"); //Reminder that the dollar sign is a string interpolation meaning it allows you to apply curly braces to bring in another variable.

Console.ReadLine(); // This allows you to run the console without having to be in Visual Studio. And it works yay!!! Without the ReadLine, it will close the console immediately have entering in the value for the first ReadLine.

//dotnet -h in powershell provides sdk commands.
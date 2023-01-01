using System;

namespace Strings
{
    internal class Strings
    {
        static void Main(string[] args) //if multiple voids exist, only the one stated as Main will establish itself.
        {
            string MyName = "Orion";

            string MyDescription = " is good looking!";

            string message = MyName + MyDescription;

            string CapsMessage = message.ToUpper();

            string LowercaseMessage = message.ToLower();

            Console.WriteLine("My name is " + MyName + ".");
            Console.WriteLine(CapsMessage);
            Console.WriteLine(LowercaseMessage);
            Console.Read();
        }
    }
}

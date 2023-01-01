using System;

namespace Datatypes
{
    internal class Datatypes
    {
        static void Second(string[] args)
        {
            //declaring a variable.
            int num1;
            //assigning a value to a variable.
            num1 = 13;
            //declare and initializing a variable in one go.
            int num2 = 13;

            int sum = num1 + num2;
            Console.WriteLine(num1 + num2);
            Console.WriteLine("The sum of 13 plus 13 is " + sum + " and if it is multiplied by or squared the answer will emerge as " + sum * num1 + ".");

            //This is all known as concatenation - a series of interconnected things or events.

            // how to declare multiple variables at once.
            //int num3, num4, num5;
            // Side note b ecareful of when you reassign a value. If you are using a sentence like the one above, it would be a bad idea to change one of the int values before the statement is read unless the statement is meant to reflect the change that you've made.

            double d1 = 3.1415;
            double d2 = 5.1;
            double dDiv = d1 / d2;
            //doubles are used instead of decimals when the most precise answer is necessary.
            Console.WriteLine("d1/d2 is " + dDiv);

            float f1 = 3.1415f; //considered a double value unless the f is listed at the end.
            float f2 = 5.1f;
            float fDiv = f1 / f2;
            //floats use a rounded to the 7th decimal place.
            Console.WriteLine("f1/f2 is " + fDiv);

            double dIDiv = d1 / num1;
            Console.WriteLine(dIDiv);// receive double result due to the variable being a double.

            //int diDivInt = d1 / num1; //can't convert like the double did. This usually comes up as a problem if the data is coming in from an external source.


            Console.Read();
        }
    }
}

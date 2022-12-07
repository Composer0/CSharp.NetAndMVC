using System;

namespace _02_Variables
{
    internal class Lecture
    {
        int age = 15;//This is a variable of type integer
        public static void Main(string[] args)
        {
            int age = 20; //New value is assigned.
            Console.WriteLine(age);//Output will be 20 as the variable is being called.
        }
        //if a value is not assigned a default value will be assigned. For example with int, the default value will be 0.
        //Variables are still scoped in C#. If they are in the method... I'm assuming public static void Main(string[] args) then can only work within the method just like a function. If declared outside of the methods they can be used in multiple methods.

        //static
        //{
         //   int iAmANumber = 5;
       // }
        //Type Name Data

        //int holds a number
        //float pi = 3.1425
        //Type Name Data
        //bool isGPSEnabled = true

        //The first word is the data type. It must be indicated prior to declaring a variable.
        //Float used to store numbers with decimal points.
        //bool is used to store true or false values.

        //string... "names"
        //char stores characters such as @. Ex. char at = '@'


        //Primitive Data Types
        //sbyte = it portrays whole numbers from -128 to 127. stands for signed byte.
        //short = stores whole numbers from -32767 to 32767.
        //int = stores whole numbers from -2147483648 to 2147483647.
        //long = stores whole numbers from -9223327036854775808 to 9223372036854775807.

        //When to use each data type. It is recommended to use the smallest one based on your data.

        //float x 99.99f;
        // allows decimals and a range from 1.55 x 10 ^-45 to 3.4 x 10^38 7-digit precision.
        //the f at the end of the number is to prevent the program from detecting a double value, therefore the number will be correctly read as having a decimal.
        
        //double x =1.5;
        //allows decimals and an even higher range than the float. 15-digit precision. Adding an f to this data type will result in the same problem as the float.

        //decimal x = 1.5;
        //allows decimals and an even higher range than the double. 28-digit precision.


        //Float is mostly used in graphics libraries (high demands for processing powers) Visual Libraries
        //Double is mostly used for real world values (except money calculations) Not Money
        //Decimal is mostly used in financial applications (high level of accuracy) Money
    
        //bool switch = false;
        //char singleLetter = 'A';
        //only allows a single literal letter or character.
        //string... you already now this.
    
    
    
    }
}

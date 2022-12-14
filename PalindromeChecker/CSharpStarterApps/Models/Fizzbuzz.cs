using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpStarterApps.Models
{
    public class FizzBuzz
    {
        public int FizzValue { get; set; }
        public int BuzzValue { get; set; }
        public List<string> Result { get; set; } = new();
        //List allow for the adding and removal of items. List of T or Type. String is the type in this circumstance. new() instantiate the list making it ready to be used immediately.
    }
}
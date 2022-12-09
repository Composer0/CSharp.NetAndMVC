using System.Collections.Generic;

namespace FizzBuzz.Models
{
    public class FizzBuzz
    {
        public int FizzValue { get; set; }
        public int BuzzValue { get; set; }
        public List<string> Result { get; set; } = new();
        //List allow for the adding and removal of items. List of T or Type. String is the type in this circumstance.
    }
}
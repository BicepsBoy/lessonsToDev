using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLib
{
    internal class Record
    {
        public readonly string Name;
        public readonly double Lenght;

        public Record(string name, double lenght)
        {
            Name = name;
            Lenght = lenght;
        }
    }
}

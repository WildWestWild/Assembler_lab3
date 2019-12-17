using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileTxt = @"C:\commands.txt";
            Parsing p = new Parsing();
            p.ReadTxtFile(fileTxt);
        }
    }
}

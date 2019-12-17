using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_lab3
{
    class Parsing
    {
        private int[] Reg = new int[16];
        private int[] cmem = new int[1024];
        private int[] dmem = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160 };
        private int literal; // Числовое значение 
        private int dest; // Номер регистра для записи результата
        private int op1; // Номер регистра первого операнда
        private int op2; // Номер регистра второго операнда
        private bool flag = true;
        // Ввод в консоль.
        public void EnterConsole() 
        {
            while (flag)
            {
                Console.Write("Введите команду: ");
                string consoleEnter = Console.ReadLine();
                GetArrayToken(consoleEnter);
                
            }
        }
        // Метод определяющий главный токен.
        private void GetArrayToken(string consoleEnter) {
            // Парсинг в массив токинов
            string[] arrayOfStrings =  consoleEnter.Split(' ');
            if (arrayOfStrings.Length == 0)
            {
                new Exception();
            }
            Switcher(arrayOfStrings);
        }
        private void Switcher(string[] arrayOfStrings)
        {
            string cmdType = arrayOfStrings[0];
            byte lenght = (byte)arrayOfStrings.Length;
            switch (cmdType)
            {
                case "lite" : LiteCommand(arrayOfStrings, lenght, "lite: "); break;
                case "dmem": DmemCommand(arrayOfStrings, lenght, "dmem: "); break;
                case "plus": PlusCommand(arrayOfStrings, lenght, "plus: "); break;
                case "lp":   LpCommand(arrayOfStrings, lenght, "lp: ");   break;
                case "end":   IfCommnad(arrayOfStrings, lenght, "end: ");  break;
                default:
                    break;
            }
        }
        private void LiteCommand(string[] arrayOfStrings, byte lenght, string nameCommand)
        {
            if (lenght != 3)
            {
                new Exception();
            }
            else
            {
                dest = Convert.ToInt32(arrayOfStrings[1].Substring(1));
                literal = Convert.ToInt32(arrayOfStrings[2]);
                Reg[dest] = literal;
                Console.WriteLine(nameCommand + arrayOfStrings[1]+ " = " + Reg[dest]); 
            }
        }
        private void DmemCommand(string[] arrayOfStrings, byte lenght, string nameCommand)
        {
            if (lenght != 3)
            {
                new Exception();
            }
            else
            {
                op1 = Convert.ToInt32(arrayOfStrings[1].Substring(1));
                op2 = Convert.ToInt32(arrayOfStrings[2].Substring(1));
                Reg[op1] = dmem[Reg[op2]];
                Console.WriteLine(nameCommand + arrayOfStrings[1] + " = " + dmem[Reg[op2]]);
            }
        }
        private void PlusCommand(string[] arrayOfStrings, byte lenght, string nameCommand)
        {
            if (lenght != 4)
            {
                new Exception();
            }
            else
            {
                dest = Convert.ToInt32(arrayOfStrings[1].Substring(1));
                op1 = Convert.ToInt32(arrayOfStrings[2].Substring(1));
                op2 = Convert.ToInt32(arrayOfStrings[3].Substring(1));
                Reg[dest] = Reg[op1] + Reg[op2];
                Console.WriteLine(nameCommand + arrayOfStrings[1] + " = " + Reg[op1] + " + " + Reg[op2]);
            }
        }
        private void LpCommand(string[] arrayOfStrings, byte lenght, string nameCommand)
        {
            if (lenght != 4)
            {
                new Exception();
            }
            else
            {
                dest = Convert.ToInt32(arrayOfStrings[1].Substring(1));
                op1 = Convert.ToInt32(arrayOfStrings[2].Substring(1));
                literal = Convert.ToInt32(arrayOfStrings[3]);
                Reg[dest] = Reg[op1] + literal;
                Console.WriteLine(nameCommand + arrayOfStrings[1] + " = " + Reg[op1] + " + " + literal);
            }
        }
        private void IfCommnad(string[] arrayOfStrings, byte lenght, string nameCommand)
        {
            if (lenght != 1)
            {
                new Exception();
            }
            else
            {
                flag = false;
            }
        }
        public void ReadTxtFile(string filePath)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    GetArrayToken(line);
                }
            }
        }
    }
}

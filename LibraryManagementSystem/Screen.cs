using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Screen
    {

        int tableWidth = 85;
        public void PrintLine()
        {
           Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t" + new string('-', tableWidth));
           Console.ResetColor();
        }
        public void ClearAndNewLine()
        {
            Console.Clear();
            Console.WriteLine();
        }
        public void PrintRow(params string[] columns)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine("\t" + row);
            Console.ResetColor();

        }
        public void RedPrint(params string[] columns)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (string row in columns)
            {
                Console.Write("\n\n\t\t\t\t" + row);
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        internal void ChoicePrint()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\t\t\t\t" + "Enter your choice: ");
            Console.ResetColor();
        }

        internal string ReadPassword()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string pass = "";
            bool continueReading = true;
            while (continueReading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char p = consoleKeyInfo.KeyChar;

                if (p == '\r')
                    continueReading = false;
                else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (pass.Length > 0)
                    {

                        Console.Write("\b \b");
                        pass = pass.Remove(pass.Length - 1); 
                    }
                    
                }
                else
                {
                    Console.Write("*");
                    pass += p;
                }
            }
            Console.ResetColor();
            return pass;
        }
        internal void SuccessPrint(string msg)
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\n"+msg+ " Successfully...\n\n");

            Console.ResetColor();
        }
        public void WaitAndClear()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\t\t\t\tPress any Key to continue...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void NormalPrint(params string[] columns)
        {
            Console.ResetColor();
            //Console.Write(s+"\n");
            foreach (string row in columns)
            {
                Console.Write("\n\n\t\t\t\t" + row);
            }

        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

using Exercicio.Entities;
using System;
using System.IO;

namespace Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<LogRecord> conjunto = new HashSet<LogRecord>();

            Console.Write("Enter full path: ");
            string? path = Console.ReadLine();

            try
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] vect = sr.ReadLine().Split(' ');
                        string userName = vect[0];
                        DateTime instant = DateTime.Parse(vect[1]);
                        LogRecord logRecord = new(userName, instant);
                        conjunto.Add(logRecord);
                    }

                    Console.WriteLine("Total users: " + conjunto.Count);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error accurred: " + e.Message);
            }
        }
    }
}
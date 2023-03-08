using System;
using System.Security.Cryptography.X509Certificates;

namespace Excel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Cols: ");
            int cols = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nRows: ");
            int rows  = Convert.ToInt32(Console.ReadLine());
            Table table = new Table(cols, rows);
            while(true)
            {
                Console.Write("\nTest: ");
                string index = Console.ReadLine();
                table.Test1(index);
            }
            
        }
    }
}

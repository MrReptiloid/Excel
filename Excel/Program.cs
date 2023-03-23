using System;

namespace Excel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Table table = new Table();

            Console.Clear();

            table.CalcTable();
            table.PrintHeader();
            table.PrintValuesInCells();

        }
    }
}

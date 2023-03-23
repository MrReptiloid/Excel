using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Excel
{
    public class Table
    {
        public Table()
        {
            GetAndSetTableSize();
            PrintHeader();
            SetValuesInCells();
        }

        public List<ICell> Cells { get; set; }
        
        public int Cols { get; private set; }
        public int Rows { get; private set; }

        private void GetAndSetTableSize()
        {
            Console.Write("Cols: ");
            Cols = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nRows: ");
            Rows = Convert.ToInt32(Console.ReadLine());
        }

        private void SetValuesInCells()
        {
            
            Cells = new List<ICell>();
            Point position = new Point(3, 2);

            Console.SetCursorPosition(position.X, position.Y);
            for (int i = 0; i < Cols * Rows; i++)
            {
                string value = "";
                for (int j = 0; j < 13; j++)
                {
                    var ch = Console.ReadKey();

                    if (ch.KeyChar != 9)
                    {
                        value += Convert.ToChar(ch.KeyChar);
                    }
                    else break;
                }

                Cells.Add(CellFactory.CreateManager(value));

                //CellFactory cellFactory = GetCellFactory(value);
                //ICell cell = cellFactory.NewCell(value);
                //Cells.Add(cell);

                position = GetNewPosition(position);

                Console.SetCursorPosition(position.X, position.Y);
            }
        }

        private Point GetNewPosition(Point position)
        {
            if ((position.X > 14 * (Cols - 1)))
            {
                position.X = 3;
                position.Y += 2;
            }
            else
            {
                position.X += 14;
            }

            return position;
        }

        public void PrintValuesInCells()
        {
            Point position = new Point(3, 2);
            Console.SetCursorPosition(position.X, position.Y);
            for (int i = 0; i < Cols * Rows; i++)
            {
                Console.Write(Cells[i].value);

                position = GetNewPosition(position);

                Console.SetCursorPosition(position.X, position.Y);
            }
        }
        
        public void PrintHeader()
        {
            Console.Clear();
            Console.Write("  ");

            for (int i = 0; i < Cols; i++)
            {
                char ch = Convert.ToChar(i + 'A');
                Console.Write("|      " + ch + "      ");
            }

            Console.Write("|\n");
            var str = new string('-', Cols * 14 + 3);

            for (int i = 1; i <= Rows; i++)
            {
                Console.WriteLine(str);
                Console.WriteLine(i);
                
                for (int j = 0; j < Cols+1; j++)
                {
                    Console.SetCursorPosition(j*14+2, i*2);
                    Console.Write('|');
                }

                Console.SetCursorPosition(0, i*2+1);
            }

            Console.WriteLine(str);
        }

        public void CalcTable()
        {
            Calculation calculation = new Calculation();
            foreach (ICell cell in Cells)
            {
                if (cell.type == CellType.Formula)
                    cell.value = cell.value.Remove(0, 1);
                try
                {
                    cell.value = calculation.Evaluate(cell.value, this.Cells, this.Cols).ToString();
                }
                catch
                {
                    cell.value = "NaN";
                }
               
            }
        }
    }
}

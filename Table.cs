namespace Excel
{
    public class Table
    {
        public Table(int _cols, int _rows)
        {
            cols = _cols;
            rows = _rows;
            CreateCells();
            PrintHeader();
            WriteValuesInCells();
        }

        public int cols;
        public int rows;
        public List<Cell> cells;

        public void CreateCells()
        {
            cells = new List<Cell>();
            for (int i = 0; i< cols * rows; i++)
            {
                cells.Add(new Cell(""));
            }
        }

        public void PrintHeader()
        {
            Console.Clear();
            Console.Write("  ");

            for (int i = 0; i < cols; i++)
            {
                char ch = Convert.ToChar('A' + i);
                Console.Write("     " + ch + "     ");
            }

            Console.WriteLine();

            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine("\n" + i);
            }
        }

        public void WriteValuesInCells()
        {
            var x = 3;
            var y = 2;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < cols * rows; i++)
            {
                string value = "";
                for (int j = 0; j < 10; j++)
                {
                    var ch = Console.ReadKey();


                    if (ch.KeyChar != 9)
                    {
                        value += Convert.ToChar(ch.KeyChar);
                    }
                    else break;
                    cells[i].value = value;

                }

                if ((x > 11 * (cols - 1)))
                {
                    x = 3;
                    y += 2;
                }
                else
                {
                    x += 11;
                }

                Console.SetCursorPosition(x, y);

            }
        }
        public void Test1(string index)
        {
            if (index[0] >= 'A' && index[0] <= 'Z')
            {
                var ch = Convert.ToInt32(index[0] - 'A');
                var num = "";
                for(int i = 1; i < index.Length; i++)
                {
                    num += index[i];
                }
                Console.Write(cells[ch + Convert.ToInt32(num) * cols - cols].value);
            }
            
        } 
        
    }
}

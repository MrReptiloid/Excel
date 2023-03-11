namespace Excel
{
    public class Table
    {
        public Table()
        {
            GetAndSetTableSize();
            CreateCells();
            PrintHeader();
            SetValuesInCells();
        }

        private List<Cell> cells;
        private Calculation calculation = new Calculation();

        public int cols;
        public int rows;

        public void GetAndSetTableSize()
        {
            Console.Write("Cols: ");
            cols = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nRows: ");
            rows = Convert.ToInt32(Console.ReadLine());
        }

        public void CreateCells()
        {
            cells = new List<Cell>();
            for (int i = 0; i < cols * rows; i++)
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
                Console.Write("|      " + ch + "      ");
            }

            Console.Write("|\n");
            var str = new String('-', cols * 14 + 3);

            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine(str);
                Console.WriteLine(i);
                
                for (int j = 0; j < cols+1; j++)
                {
                    Console.SetCursorPosition(j*14+2, i*2);
                    Console.Write('|');
                }

                Console.SetCursorPosition(0, i*2+1);
            }

            Console.WriteLine(str);
        }

        public void SetValuesInCells()
        {
            var x = 3;
            var y = 2;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < cols * rows; i++)
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

                    cells[i].value = value;
                }

                if ((x > 14 * (cols - 1)))
                {
                    x = 3;
                    y += 2;
                }
                else
                {
                    x += 14;
                }

                Console.SetCursorPosition(x, y);
            }
        }

        public string CalcCell(string input)
        {
            var output = "";
            for (int i = 0; i < input.Length; i++)
            {
                var str = "";
                if (input[i] >= 'A' && input[i] <= cols + 'A' - 1)
                {
                    var n = i;
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] >= '0' && input[j] <= '9')
                        {
                            i++;
                            str += input[j];
                        }
                        else break;
                    }
                    if (str.Length > 0) output += cells[input[n] - 'A' + (Convert.ToInt32(str) - 1) * cols].value;
                }
                else if (str.Length == 0)
                {
                    output += input[i];
                }
            }

            try
            {
                var result = calculation.Evaluate(output).ToString();
                return result;
            }
            catch
            {
                return output;
            }
        }

        public void CalcTable()
        {
            for (int i = 0; i < cols * rows; i++)
            {
                cells[i].value = CalcCell(cells[i].value);
            }
        }

        public void PrintValuesInCells()
        {
            var x = 3;
            var y = 2;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < cols * rows; i++)
            {
                Console.Write(cells[i].value);

                if ((x > 14 * (cols - 1)))
                {
                    x = 3;
                    y += 2;
                }
                else
                {
                    x += 14;
                }

                Console.SetCursorPosition(x, y);
            }
        }

    }
}

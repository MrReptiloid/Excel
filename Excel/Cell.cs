using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    public class Cell
    {
        public Cell(string? _vlaue)
        {
            value = _vlaue;
        }
        public string? value { get; set; }
    }
}

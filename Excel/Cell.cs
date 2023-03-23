using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    public enum CellType
    {
        Number,
        Text,
        Formula
    }

    public interface ICell
    {
        public string value { get; set; }
        public CellType type { get; }
    }

    public class FormulaCell : ICell
    {
        public FormulaCell(string _value)
        {
            value = _value;
        }

        public string value { get; set; }
        public CellType type => CellType.Formula;
    }

    public class NumberCell : ICell
    {
        public NumberCell(string _value)
        {
            value = _value;
        }

        public string value { get; set; }
        public CellType type => CellType.Number;
    }

    public class TextCell : ICell
    {
        public TextCell(string _value)
        {
            value = _value;
        }

        public string value { get; set; }
        public CellType type => CellType.Text;
    }
}

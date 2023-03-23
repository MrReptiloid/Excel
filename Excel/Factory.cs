using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    public class CellFactory
    {
        private CellFactory() { }

        private Dictionary<CellType, Func<string, ICell>> factory = new Dictionary<CellType, Func<string, ICell>>()
        {
            { CellType.Formula, (value) => new FormulaCell(value) },
            { CellType.Number, (value) => new NumberCell(value) },
            { CellType.Text, (value) => new TextCell(value) }
        };

        private ICell CrateNewCell(CellType cellType, string value) => factory[cellType](value);

        public static ICell CreateManager(string value)
        {
            if (value.StartsWith('='))
                return new CellFactory().CrateNewCell(CellType.Formula, value);
            else if (value.IndexOfAny(new char[] { '+', '-', '*', '/'}) != -1)
                return new CellFactory().CrateNewCell(CellType.Number, value);
            else 
                return new CellFactory().CrateNewCell(CellType.Text, value);

        }
    }
}

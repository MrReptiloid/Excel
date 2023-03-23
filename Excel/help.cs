using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text
{
    //class CellFact
    //{
    //    private Dictionary<typeOfCell, Func<ICell>> factory = new Dictionary<typeOfCell, Func<ICell>> {
    //         {
    //             typeOfCell.Formula,
    //            ()=> new FormulaCell("")
    //         },
    //         {
    //             typeOfCell.Number,
    //             ()=> new NumberCell("")
    //         }
    //     };

    //    private CellFact()
    //    {

    //    }

    //    private ICell NewCell1(typeOfCell type) =>
    //          factory[type]();

    //    public static ICell NewCell(string value)
    //    {
    //        if (double.TryParse(value, out _))
    //        {
    //            return new CellFact().NewCell1(typeOfCell.Number);
    //        }
    //        else if (value.StartsWith('='))
    //        {
    //            return _cellFactories[1];
    //        }
    //        else
    //        {
    //            return _cellFactories[2];
    //        }

    //    }

    //    private ICell NewCell(typeOfCell cellType)
    //    {
    //        switch (cellType)
    //        {
    //            case typeOfCell.Number:

    //                return new NumberCell
    //                break;
    //            case typeOfCell.Text:
    //                break;
    //            case typeOfCell.Formula:
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //}
}

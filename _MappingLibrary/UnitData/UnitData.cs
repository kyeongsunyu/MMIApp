using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public  class UnitData
    {
       public int Columns;
       public int Rows;
       public int BlockRows;
       public int BlockColumns;
       public int[,] Coloridx;
       public string[,] msg;   


       public UnitData(int ColCnt, int RowCnt)
       {
            BlockRows = 1;
            BlockColumns = 1;

            Columns = ColCnt;
            Rows = RowCnt;
            Coloridx = new int[ColCnt, RowCnt];
            msg = new string[ColCnt, RowCnt];
        }

    }
}

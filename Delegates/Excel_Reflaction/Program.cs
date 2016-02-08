using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Reflaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Type excelAppType = Type.GetTypeFromProgID("Excel.Application", true);
            dynamic excel = Activator.CreateInstance(excelAppType);
            excel.Visible = true;

            dynamic wb = excel.Workbooks.Add();
            excel.Cells[1, 1].Value2 = "foo";

            excel.Cells[1, 1].Font.FontStyle = "Bold";
        }
    }
}

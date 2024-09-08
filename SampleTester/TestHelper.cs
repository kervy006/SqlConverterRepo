using System.Data;

namespace SampleTester
{
    internal class TestHelper
    {
        internal static DataTable DatatableWithColumnHeader()
        {
            var dataTableWithColumnHeader = new DataTable();
            dataTableWithColumnHeader.Columns.Add(TestConstant.columnName1);
            dataTableWithColumnHeader.Columns.Add(TestConstant.columnName2);

            return dataTableWithColumnHeader;
        }
        internal static DataTable SampleDatatableWithData()
        {
            var sampleDatatableWithData = DatatableWithColumnHeader();
            //Create rowdata
            sampleDatatableWithData.Rows.Add(1, "Alpha");
            sampleDatatableWithData.Rows.Add(2, "Beta");

            return sampleDatatableWithData;
        }
        internal static DataTable SampleDatatableWithNoDataRow()
        {
            //Create column
            var SampleDatatableWithNoDataRow = DatatableWithColumnHeader();
            
            return SampleDatatableWithNoDataRow;
        }

    }
}

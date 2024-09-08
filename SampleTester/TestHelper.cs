using System.Data;

namespace SampleTester
{
    internal class TestHelper
    {
        internal static DataTable SampleDatatableWithData()
        {
            var sampleDatatableWithData = new DataTable();
            //add column header
            sampleDatatableWithData.Columns.Add(TestConstant.columnName1);
            sampleDatatableWithData.Columns.Add(TestConstant.columnName2);
            //Create row data
            sampleDatatableWithData.Rows.Add(1, "Alpha");
            sampleDatatableWithData.Rows.Add(2, "Beta");

            return sampleDatatableWithData;
        }
    }
}

using SqlConverterLibrary;
using ConverterConsoleApp.Constants;
using ConverterConsoleApp.Models;

namespace SampleTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ACTION_ConvertSqlToExcel_SHOULD_GenerateExcelFile()
        {
            //Arrange
            var fakeUserInput = new UserInput("TestExcel", Constant.XlsxExtension);
            var fullFilePath = fakeUserInput.FullFilePath;
            SqlConverter convert = new SqlToExcelConverter();
            //Act
            convert.ConvertSql(TestHelper.SampleDatatableWithData(), fullFilePath);
            //Assert
            Assert.IsTrue(File.Exists(fullFilePath));
        }
        [TestMethod]
        public void ACTION_ConvertSqlToText_SHOULD_GenerateTextFile()
        {
            //Arrange
            var fakeUserInput = new UserInput("TestText", Constant.TxtExtension);
            var fullFilePath = fakeUserInput.FullFilePath;
            SqlConverter convert = new SqlToTxtConverter();
            //Act
            convert.ConvertSql(TestHelper.SampleDatatableWithData(), fullFilePath);
            //Assert
            Assert.IsTrue(File.Exists(fullFilePath));
        }
    }
}
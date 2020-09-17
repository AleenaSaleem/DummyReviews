using System.Collections.Generic;
using System.Linq;
using Xunit;
using Sender;

namespace SenderTests
{
    public class MockConsoleOutput : ISenderOutput
    {
        internal List<List<string>> OutputOnConsole = new List<List<string>>();
        internal int NRows, NColumns;
        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            var dataList = data.ToList();
            NRows = ConsoleOutput.GetNumberOfRows(dataList);
            NColumns = ConsoleOutput.GetNumberOfColumns(dataList);
            foreach (var newRow in dataList.Select(row => row.ToList()))
            {
                OutputOnConsole.Add(newRow);
            }
        }
    }

    public class SenderOutputTests
    {
        private readonly List<List<string>> _testInput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

        [Fact]
        public void WhenCalledWithTwoDimensionalIEnumerableThenGiveProperRowAndColumnCountAndAccessValuesRowWiseFromData()
        {

            var mockConsoleOutput = new MockConsoleOutput();
            mockConsoleOutput.WriteOutput(_testInput);

            var testOutput = mockConsoleOutput.OutputOnConsole;
            Assert.Equal(4, mockConsoleOutput.NRows);
            Assert.Equal(2, mockConsoleOutput.NColumns);
            Assert.Equal(_testInput, testOutput);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberOfColumnsInData()
        {
            var nColumns = ConsoleOutput.GetNumberOfColumns(_testInput);
            Assert.True(nColumns == 2);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberOfRowsInData()
        {
            var nRows = ConsoleOutput.GetNumberOfRows(_testInput);
            Assert.True(nRows == 4);
        }

    }
}

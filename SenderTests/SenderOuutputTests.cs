using System;
using System.Collections.Generic;
using Xunit;
using Sender;
namespace SenderTests
{
    public class MockConsoleOutput : ISenderOutput
    {
        internal List<List<String>> OutputOnConsole = new List<List<string>>();
        internal int nRows, nColumns;
        public void WriteOutput(IEnumerable<IEnumerable<String>> data)
        {
            nRows = ConsoleOutput.GetNumberofRows(data);
            nColumns = ConsoleOutput.GetNumberofColumns(data);
            List<String> newRow;
            foreach (IEnumerable<String> row in data)
            {
                newRow = new List<string>();
                foreach (String value in row)
                {
                    newRow.Add(value);
                }
                OutputOnConsole.Add(newRow);
            }
        }
    }

    public class SenderOutputTests
    {
         List<List<String>> testinput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };
        
        [Fact]
        public void WhenCalledWithTwoDimensionalIEnumerableThenGiveProperRowAndColumnCountAndAccessValuesRowWiseFromData()
        {

            MockConsoleOutput mockConsoleOuput = new MockConsoleOutput();
            mockConsoleOuput.WriteOutput(testinput);

            List<List<String>> testoutput = mockConsoleOuput.OutputOnConsole;
            Assert.Equal(4, mockConsoleOuput.nRows);
            Assert.Equal(2, mockConsoleOuput.nColumns);
            Assert.Equal(testinput, testoutput);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberofColumnsinData()
        {
           
            int nColumns = ConsoleOutput.GetNumberofColumns(testinput);
            Assert.True(nColumns == 2);
        }
        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberofRowsinData()
        {
            
            int nRows = ConsoleOutput.GetNumberofRows(testinput);
            Assert.True(nRows == 4);
        }

    }
}


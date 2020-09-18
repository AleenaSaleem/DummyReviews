using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{
    
    public class MockConsoleInput : IReceiverInput
    {
        int nRows;
        int nColumns;
        readonly string tempRows,tempCols;
        public MockConsoleInput(string tempRows,string tempCols)
        {
            this.tempRows = tempRows;
            this.tempCols = tempCols;
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            nRows = ReadNumberOfRows();
            nColumns = ReadNumberOfColumns();
            var InputFromSender = new List<List<string>>();
            for (int i = 0; i < nRows; i++)
            {
                var newRow = new List<string>();
                for (int j = 0; j < nColumns; j++)
                {
                    newRow.Add("sample" + i.ToString() + j.ToString());
                    
                }
                InputFromSender.Add(newRow);
            }
            return InputFromSender;
        }
     
        public int ReadNumberOfRows()
        {
            int numRows = 0;
            if (!string.IsNullOrEmpty(tempRows))
            {
                numRows = int.Parse(tempRows);
            }
            return numRows;
        }
        public int ReadNumberOfColumns()
        {
            int numCols = 0;
            if (!string.IsNullOrEmpty(tempCols))
            {
                numCols = int.Parse(tempCols);
            }
            return numCols;

        }
    }
        
        public class ReceiverInputTests
        {
            
        [Fact]
            public void TestExpectingAnIEnumerableToBeReturnedWhenCalledWithNumRowsAndNumColsAndData()
            {
                
                MockConsoleInput mockObject = new MockConsoleInput("3","3");
                var ActualTestOutput = (List<List<string>>)mockObject.ReadInput();
                Assert.Equal("sample00",ActualTestOutput[0][0]);
            }
        [Fact]
        public void TestExpectingOutputToBeEmptyWhenNumRowsOrNumColsReadFromConsoleAreNullOrEmpty()
        {
            MockConsoleInput mockObject = new MockConsoleInput(string.Empty, string.Empty);
            var ActualTestOutput = (List<List<string>>)mockObject.ReadInput();
            Assert.True(ActualTestOutput.Count == 0);
        }

    }
}

using System.Collections.Generic;
using Receiver;
using Moq;
using Xunit;

namespace ReceiverTests
{
    
   /* public class MockConsoleInput : IReceiverInput
    {
        
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            int nRows, nColumns;
            nRows = 3;
            nColumns = 3;
            var InputFromSender = new List<List<string>>();
            for (int i = 0; i < nRows; i++)
            {
                var new_row = new List<string>();
                for (int j = 0; j < nColumns; j++)
                {
                    new_row.Add("sample" + i.ToString() + j.ToString());
                    
                }
                InputFromSender.Add(new_row);
            }
            return InputFromSender;
        }
        public void InputExceptionHandler(IEnumerable<IEnumerable<string>> Input)
        {
            if (!Input.Any())
            {
                throw new InvalidDataException();
            }
        }
    }*/
        
        public class ReceiverInputTests
        {
            private IReceiverInput GetMockConsoleInput()
            {
                Mock<ConsoleInput> mockObject = new Mock<ConsoleInput>();
                var twoDimList = new List<List<string>>();
                List<string> temp = new List<string>() { "sample1", "sample2" };
                twoDimList.Add(temp);
                temp.Add("sample2");
                twoDimList.Add(temp);
                mockObject.Setup(rep => rep.ReadInput()).Returns((twoDimList));
                mockObject.Setup(rep => rep.ReadNumberOfRows()).Returns(twoDimList.Count);
                mockObject.Setup(rep => rep.ReadNumberOfColumns()).Returns(1);
                return mockObject.Object;
            }
        [Fact]
            public void TestExpectingAnIEnumerableToBeReturnedWhenCalledWithNumRowsAndNumColsAndData()
            {
                
                ConsoleInput mockObject = (ConsoleInput)this.GetMockConsoleInput();
                var ActualTestOutput = (List<List<string>>)mockObject.ReadInput();
                Assert.Equal(2, mockObject.ReadNumberOfRows());
                Assert.Equal(1, mockObject.ReadNumberOfColumns());
                Assert.Equal("sample1",ActualTestOutput[0][0]);
            }

        }
}

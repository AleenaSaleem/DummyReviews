using System.Collections.Generic;
using System.Diagnostics;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        public CsvInput csvInput = new CsvInput(filepath);
        public ConsoleOutput consoleOutput = new ConsoleOutput();
        public Controller controller = new Controller(csvInput, consoleOutput);
        public List<List<string>> parsedInput = (List<List<string>>) controller.ReadInput();
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            var type = controller.InputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }

        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            
            Assert.Equal("sampledata", parsedInput[0][0]);
        }

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.outputData[0][0]);
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        public CsvInput csvInput;
        public ConsoleOutput consoleOutput;
       
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            csvInput  = new CsvInput(filepath);
            consoleOutput= = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            var type = controller.InputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }

        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            csvInput  = new CsvInput(filepath);
            consoleOutput= = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            public List<List<string>> parsedInput = (List<List<string>>) controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            csvInput  = new CsvInput(filepath);
            consoleOutput= = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            public List<List<string>> parsedInput = (List<List<string>>) controller.ReadInput();
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.outputData[0]);
        }
    }
}

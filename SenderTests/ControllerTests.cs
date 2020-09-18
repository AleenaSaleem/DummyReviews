using System.Collections.Generic;
using System.Diagnostics;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            CsvInput csvInput = new CsvInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            var type = controller.InputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }

        

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            CsvInput csvInput = new CsvInput(filepath);
            ConsoleOutput consoleOutput =new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.outputData[0]);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            CsvInput csvInput = new CsvInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }
    }
}

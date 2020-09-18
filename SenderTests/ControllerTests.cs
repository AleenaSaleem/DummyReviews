using System.Collections.Generic;
using System.Diagnostics;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        CsvInput csvInput = new CsvInput(filepath);
        ConsoleOutput consoleOutput = new ConsoleOutput();
        Controller controller = new Controller(csvInput, consoleOutput);
        List<List<string>> parsedInput = (List<List<string>>) controller.ReadInput();
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            var csvInput = new CsvInput("TestSample.csv");
            var output = new ConsoleOutput();
            var controller = new Controller(csvInput, output);
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
            Assert.Equal("sampledata", consoleOutput.OutputOnConsole[0][0]);
        }
    }
}

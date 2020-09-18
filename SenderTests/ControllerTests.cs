using System.Collections.Generic;
using System.Diagnostics;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
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
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new ConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedInput = (List<List<string>>) controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new MockConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedInput = (List<List<string>>) controller.ReadInput();
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.OutputOnConsole[0][0]);
        }
    }
}
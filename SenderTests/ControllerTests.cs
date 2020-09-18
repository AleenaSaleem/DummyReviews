using System.Collections.Generic;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string Filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            CsvInput csvInput = new CsvInput(Filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            Assert.Equal(csvInput, controller.InputInterface);
            Assert.Equal(consoleOutput, controller.OutputInterface);
        }

        

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            CsvInput csvInput = new CsvInput(Filepath);
            ConsoleOutput consoleOutput =new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.OutputData[0]);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            CsvInput csvInput = new CsvInput(Filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }
    }
}

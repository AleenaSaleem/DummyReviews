using System.Collections.Generic;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string Filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
        readonly CsvInput csvInput = new CsvInput(Filepath);
        readonly ConsoleOutput consoleOutput = new ConsoleOutput();
        Controller controller;
       
        
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            CsvInput _csvInput = new CsvInput(Filepath);
            ConsoleOutput _consoleOutput = new ConsoleOutput();
            Controller _controller = new Controller(_csvInput, _consoleOutput);
            Assert.Equal(_csvInput, _controller.InputInterface);
            Assert.Equal(_consoleOutput, _controller.OutputInterface);
        }

        

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {

            controller =  new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", consoleOutput.OutputData[0]);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }
    }
}

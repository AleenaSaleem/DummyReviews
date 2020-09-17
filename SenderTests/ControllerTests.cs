using System.Diagnostics;
using Xunit;
using System.Collections.Generic;

namespace SenderTests
{
    public class ControllerTests
    {
        [Fact]
        public static void TestExpectingAnObjectOfCSVInputTypeToBeAssignedToControllersInputInterface()
        {

            CSVInput csvInput = new CSVInput("TestSample.csv");
            ConsoleOutput output = new ConsoleOutput();
            Controller controller = new Controller(csvInput, output);
            var type = controller.inputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            string filepath =@"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            var parsedinput = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sampledata", parsedinput[0][0]);
        }
        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            MockConsoleOutput consoleOutput = new MockConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            var parsedinput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedinput);
            Assert.Equal("sampledata", consoleOutput.OutputOnConsole[0][0]);
        }
        
    }
}

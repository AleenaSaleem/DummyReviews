

using Xunit;
using Receiver;
using System.Collections.Generic;

namespace ReceiverTests
{
    public class ControllerTests
    {
        [Fact]
        public void TestExpectingCorrectAssignmentToControllersDataMembersWhenCalledWithValidObjects()
        {
            ConsoleInput consoleInput = new ConsoleInput();
            string filepath = @"D:\a\DummyReviews\DummyReviews\ReceiverTests\output.csv";
            CSVOutput csvOutput = new CSVOutput(filepath);
            Controller controller = new Controller(consoleInput, csvOutput);
            Assert.Equal(consoleInput, controller.InputInterface);
            Assert.Equal(csvOutput, controller.OutputInterface);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalled()
        {
            MockConsoleInput mockInput = new MockConsoleInput();
            string filepath = "same_random_path";
            MockCSVOutput mockOutput = new MockCSVOutput(filepath);
            Controller controller = new Controller(mockInput, mockOutput);
            var output = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sample00", output[0][0]);
        }
        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithValidIDictionary()
        {
            MockConsoleInput mockInput = new MockConsoleInput();
            string filepath = "same_random_path";
            MockCSVOutput mockOutput = new MockCSVOutput(filepath);
            Controller controller = new Controller(mockInput, mockOutput);
            IDictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("sample1", 1);
            dict.Add("sample2", 2);
            controller.WriteOutput(dict);
            Assert.True(mockOutput.OutputStatus);
            Assert.Equal("sample1,1", mockOutput.MockFileOutput[0]);
        }
    }
}


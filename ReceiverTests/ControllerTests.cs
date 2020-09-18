using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{
    public class ControllerTests
    {
        [Fact]
        public void TestExpectingCorrectAssignmentToControllersDataMembersWhenCalledWithValidObjects()
        {
            var consoleInput = new ConsoleInput();
            var filepath = @"D:\a\DummyReviews\DummyReviews\ReceiverTests\output.csv";
            var csvOutput = new CSVOutput(filepath);
            var controller = new Controller(consoleInput, csvOutput);
            Assert.Equal(consoleInput, controller.InputInterface);
            Assert.Equal(csvOutput, controller.OutputInterface);
        }

        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalled()
        {
            var mockInput = new MockConsoleInput();
            var filepath = "same_random_path";
            var mockOutput = new MockCSVOutput(filepath);
            var controller = new Controller(mockInput, mockOutput);
            var output = (List<List<string>>) controller.ReadInput();
            Assert.Equal("sample00", output[0][0]);
        }

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithValidIDictionary()
        {
            var mockInput = new MockConsoleInput();
            var filepath = "same_random_path";
            var mockOutput = new MockCSVOutput(filepath);
            var controller = new Controller(mockInput, mockOutput);
            IDictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("sample1", 1);
            dict.Add("sample2", 2);
            controller.WriteOutput(dict);
            Assert.True(mockOutput.OutputStatus);
            Assert.Equal("sample1,1", mockOutput.MockFileOutput[0]);
        }
    }
}
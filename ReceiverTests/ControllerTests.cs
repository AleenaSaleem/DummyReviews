
using Xunit;
using Receiver;
using System.Collections.Generic;
using Moq;
namespace ReceiverTests
{
    public class ControllerTests
    {
        private IReceiverInput GetMockConsoleInput()
        {
            Mock<ConsoleInput> mockObject = new Mock<ConsoleInput>();
            var twoDimList = new List<List<string>>();
            List<string> temp = new List<string>() { "sample1", "sample2" };
            twoDimList.Add(temp);
            temp.Add("sample2");
            twoDimList.Add(temp);
            mockObject.Setup(rep => rep.ReadInput()).Returns((twoDimList));
            mockObject.Setup(rep => rep.ReadNumberOfRows()).Returns(twoDimList.Count);
            mockObject.Setup(rep => rep.ReadNumberOfColumns()).Returns(1);
            return mockObject.Object;
        }
        [Fact]
        public void TestExpectingCorrectAssignmentToControllersDataMembersWhenCalledWithValidObjects()
        {
            ConsoleInput consoleInput = (ConsoleInput)this.GetMockConsoleInput();
            string filepath = @"E:\BootCamp\ReceiverInput\output.csv";
            CSVOutput csvOutput = new CSVOutput(filepath);
            Controller controller = new Controller(consoleInput, csvOutput);
            Assert.Equal(consoleInput, controller.InputInterface);
            Assert.Equal(csvOutput, controller.OutputInterface);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalled()
        {
            ConsoleInput mockInput = (ConsoleInput)GetMockConsoleInput();
            string filepath = "same_random_path";
            MockCSVOutput mockOutput = new MockCSVOutput(filepath);
            Controller controller = new Controller(mockInput, mockOutput);
            var output = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sample1", output[0][0]);
        }
        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithValidIDictionary()
        {
            ConsoleInput mockInput = (ConsoleInput)GetMockConsoleInput();
            string filepath = "same_random_path";
            MockCSVOutput mockOutput = new MockCSVOutput(filepath);
            Controller controller = new Controller(mockInput, mockOutput);
            IDictionary<string, int> dict = new Dictionary<string, int>
            {
                { "sample1", 1 },
                { "sample2", 2 }
            };
            controller.WriteOutput(dict);
            Assert.True(mockOutput.OutputStatus);
            Assert.Equal("sample1,1", mockOutput.MockFileOutput[0]);
        }
    }
}

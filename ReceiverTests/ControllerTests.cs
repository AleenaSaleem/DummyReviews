
using Xunit;
using ReceiverInput;
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

    }
}

﻿using System.Diagnostics;
using Xunit;
using Sender;
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
        static void Main()
        {

        }
    }
}

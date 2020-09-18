using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace InputToSender
{
    public class Controller
    {
        public readonly ISenderInput InputInterface;
        public readonly ISenderOutput OutputInterface;
        public Controller(ISenderInput inputInterface, ISenderOutput outputInterface)
        {
            this.InputInterface = inputInterface;
            this.OutputInterface = outputInterface;
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            InputInterface.InputExceptionHandler();
            return InputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> parsedData)
        {
            OutputInterface.WriteOutput(parsedData);
        }
        [ExcludeFromCodeCoverage]
        static void Main()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedinput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedinput);
        }
    }
}

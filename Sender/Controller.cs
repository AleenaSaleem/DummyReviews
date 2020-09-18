using System.Collections.Generic;

namespace Sender
{
    public class Controller
    {
        public ISenderInput InputInterface;
        public ISenderOutput OutputInterface;

        public Controller(ISenderInput InputInterface, ISenderOutput OutputInterface)
        {
            if (InputInterface != null) this.InputInterface = InputInterface;
            if (OutputInterface != null) this.OutputInterface = OutputInterface;
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

        private static void Main(string[] args)
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\Sender\Comments.csv";
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new ConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedInput = (List<List<string>>) controller.ReadInput();
            controller.WriteOutput(parsedInput);
        }
    }
}
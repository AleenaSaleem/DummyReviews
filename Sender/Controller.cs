using System.Collections.Generic;

namespace Sender
{
    public class Controller
    {
        public ISenderInput InputInterface;
        public ISenderOutput OutputInterface;
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
        /*static void Main()
        {
            const string filepath = @"E:\BootCamp\Sender\SenderTests\EmptySample.csv";
            //string filter = args[0];
            //Console.WriteLine(filter);
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new ConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedinput = (List<List<string>>)controller.ReadInput();
            //Console.WriteLine(parsedinput.Count);
            controller.WriteOutput(parsedinput);
        }*/
    }
}

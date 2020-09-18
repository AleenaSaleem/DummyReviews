using System;
using System.Collections.Generic;


namespace Receiver
{
    public class Controller
    {
       public IReceiverInput InputInterface;
       public IReceiverOutput OutputInterface;
        public Controller(IReceiverInput InputInterface, IReceiverOutput OutputInterface) 
        {
            if(InputInterface!=null)
            {
                this.InputInterface = InputInterface;
            }
            if(OutputInterface!=null)
            {
                this.OutputInterface = OutputInterface;
            }
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            var Output = InputInterface.ReadInput();
            InputInterface.InputExceptionHandler(Output);
            return Output;
        }
        public void WriteOutput(IDictionary<string, int> wordCount)
        {
            OutputInterface.WriteOutput(wordCount);
        }
        static void Main()
        {
            ConsoleInput consoleInput = new ConsoleInput();
            string filepath = @"D:\a\DummyReviews\DummyReviews\Receiver\output.csv";
            CSVOutput csvOutput = new CSVOutput(filepath);
            Controller controller = new Controller(consoleInput,csvOutput);
            Console.WriteLine("----------------------Reading Sender Data----------------------");
            var Output = (List<List<string>>)controller.ReadInput();
            Analyser commentanalyser = new Analyser();
            var wordCount = commentanalyser.CountWordFrequency(Output); 
            controller.WriteOutput(wordCount);
        }
    }
}


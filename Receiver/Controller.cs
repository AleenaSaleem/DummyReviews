using System;
using System.Collections.Generic;


namespace ReceiverInput
{
    public class Controller
    {
       public IReceiverInput InputInterface;
       public IReceiverOutput OutputInterface;
        public Controller(IReceiverInput InputInterface, IReceiverOutput OutputInterface) 
        {
            this.InputInterface = InputInterface;
            this.OutputInterface = OutputInterface;
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
        static void Main(string[] args)
        {
            ConsoleInput consoleInput = new ConsoleInput();
            string filepath = @"E:\BootCamp\ReceiverInput\output.csv";
            CSVOutput csvOutput = new CSVOutput(filepath);
            Controller controller = new Controller(consoleInput,csvOutput);
            var Output = (List<List<string>>)controller.ReadInput();
            foreach(var row in Output)
            {
                foreach(var str in row)
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine("----------");
            Analyser commentanalyser = new Analyser();
            var wordCount = commentanalyser.CountWordFrequency(Output);
            foreach (var ele2 in wordCount)
            {
                Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
            }
            
            controller.WriteOutput(wordCount);
        }
    }
}


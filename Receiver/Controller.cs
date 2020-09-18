using System;
using System.Collections.Generic;

namespace Receiver
{
    public class Controller
    {
        public readonly IReceiverInput InputInterface;
        public readonly IReceiverOutput OutputInterface;

        public Controller(IReceiverInput inputInterface, IReceiverOutput outputInterface)
        {
            InputInterface = inputInterface;
            OutputInterface = outputInterface;
        }

        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            var output = InputInterface.ReadInput();
            InputInterface.InputExceptionHandler(output);
            return output;
        }

        public void WriteOutput(IDictionary<string, int> wordCount)
        {
            OutputInterface.WriteOutput(wordCount);
        }

        private static void Main()
        {
            var consoleInput = new ConsoleInput();
            var filepath = @"D:\a\DummyReviews\DummyReviews\Receiver\output.csv";
            var csvOutput = new CSVOutput(filepath);
            var controller = new Controller(consoleInput, csvOutput);
            Console.WriteLine("----------------------Reading Sender Data----------------------");
            var output = (List<List<string>>) controller.ReadInput();
            var commentanalyser = new Analyser();
            var wordCount = commentanalyser.CountWordFrequency(output);
            controller.WriteOutput(wordCount);
        }
    }
}
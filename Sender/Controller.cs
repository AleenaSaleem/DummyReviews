﻿using System;
using System.Collections.Generic;

namespace Sender
{
    public class Controller
    {
        public ISenderInput inputInterface;
        public ISenderOutput outputInterface;
        public Controller(ISenderInput inputInterface, ISenderOutput outputInterface)
        {
            this.inputInterface = inputInterface;
            this.outputInterface = outputInterface;
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            return inputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> parsedData)
        {
            outputInterface.WriteOutput(parsedData);
        }
        static void Main(string[] args)
        {
            string filepath = @"E:\BootCamp\ReviewOfReviews\Sender\Comments.csv";
            //string filter = args[0];
            //Console.WriteLine(filter);
            CSVInput csvInput = new CSVInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedinput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedinput);
        }
    }
}

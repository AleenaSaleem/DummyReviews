using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Receiver
{
    public interface IReceiverInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
        void InputExceptionHandler(IEnumerable<IEnumerable<string>> input);
    }
    public class ConsoleInput : IReceiverInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            int n_rows= int.Parse(Console.ReadLine());
            int n_cols = int.Parse(Console.ReadLine());
            var inputFromSender = new List<List<string>>();
            for (int i = 0; i < n_rows; i++)
            {
                var newRow = new List<string>();
                for (int j = 0; j < n_cols; j++)
                {
                    newRow.Add(Console.ReadLine());
                    
                }
                inputFromSender.Add(newRow);
            }
            return inputFromSender;
        }

        public void InputExceptionHandler(IEnumerable<IEnumerable<string>> input)
        {
            if (!input.Any())
            {
                throw new InvalidDataException();
            }
        }

    }
}


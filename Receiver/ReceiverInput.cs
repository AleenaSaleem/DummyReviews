using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Receiver
{
    public interface IReceiverInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
        void InputExceptionHandler(IEnumerable<IEnumerable<string>> Input);
    }
    public class ConsoleInput:IReceiverInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            int n_rows, n_cols;
            n_rows = int.Parse(Console.ReadLine());
            n_cols = int.Parse(Console.ReadLine());
            var InputFromSender = new List<List<string>>();
            for(int i = 0; i < n_rows; i++)
            {
                var new_row = new List<string>();
                for(int j = 0; j < n_cols; j++)
                {
                    new_row.Add(Console.ReadLine());
;                }
                InputFromSender.Add(new_row);
            }
            return InputFromSender;
        }

        public void InputExceptionHandler(IEnumerable<IEnumerable<string>> Input)
        {
            if (!Input.Any())
            {
                throw new InvalidDataException();
            }
        }
        
        public int GetNumberOfColumns(IEnumerable<IEnumerable<string>> Input)
        {
            int column_count = 0;
            foreach (IEnumerable<String> row in Input)
            {
                foreach (String value in row)
                {
                    column_count++;
                }
                break;
            }
            return column_count;
        }
        public int GetNumberOfRows(IEnumerable<IEnumerable<string>> Input)
        {
            int row_count = 0;
            foreach (IEnumerable<String> row in Input)
            {
                row_count++;
            }
            return row_count;
        }
    }
}

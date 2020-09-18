using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Receiver
{
    public interface IReceiverInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
    }

    public class ConsoleInput : IReceiverInput
    {
        public virtual IEnumerable<IEnumerable<string>> ReadInput()
        {
            var nRows = ReadNumberOfRowsFromConsole();
            var nCols = ReadNumberOfColumnsFromConsole();
            var inputFromSender = new List<List<string>>();
            for (var i = 0; i < nRows; i++)
            {
                var newRow = new List<string>();
                for (var j = 0; j < nCols; j++) newRow.Add(Console.ReadLine());
                inputFromSender.Add(newRow);
            }

            return inputFromSender;
        }
        public virtual int ReadNumberOfRows()
        {
            int nRows=0;  
            string temp=Console.ReadLine();
            if(temp!=null){
                nRows = int.Parse(temp);
            }
            
            return nRows;
        }
        public virtual int ReadNumberOfColumns()
        {
            int nCols=0;
            string temp=Console.ReadLine();
            if(temp!=null)
                nCols = int.Parse(temp);
            return nCols;
        }

        public void InputExceptionHandler( IEnumerable<IEnumerable<string>> input)
        {
            if (!input.Any()) throw new InvalidDataException();
        }
    }
}

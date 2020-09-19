using System.Collections.Generic;
using Xunit;
using Receiver;

namespace ReceiverTests
{

    /*public class MockCSVOutput : IReceiverOutput
    {
        string filepath;
        public List<string> MockFileOutput = new List<string>();
        public bool OutputStatus;
        public MockCSVOutput(string filepath)
        {
            this.filepath = filepath;
            this.OutputStatus = false;
        }
        public void WriteOutput(IDictionary<string, int> WordFrequency)
        {
            foreach (var line in WordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                MockFileOutput.Add(newLine);
                
            }
            this.OutputStatus = true;
        }
    }*/

    public class ReceiverOutputTests
    {
        [Fact]
        public void TestExpectingStatusOfFileWrittenAsTrueWhenCalledWithDictionaryOfWordFrequency()
        {
            CsvOutput csvOutput = new CsvOutput("Random_file_path");
            IDictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("sample1", 1);
            dict.Add("sample2", 2);
            csvOutput.WriteOutput(dict);
            Assert.True(csvOutput.OutputStatus);
        }
        [Fact]
        public void TestExpectingValidMockFileOutputWhenCalledWithDictionaryOfWordFrequency()
        {
            CsvOutput mockOutput = new CsvOutput("Random_file_path");
            IDictionary<string, int> dict = new Dictionary<string, int>
            {
                { "sample1", 1 },
                { "sample2", 2 }
            };
            mockOutput.WriteOutput(dict);
            Assert.Equal("sample1,1", mockOutput.FileOutput[0]);
        }
        [Fact]
        public void TestExpectingFileOutputToBeEmptyWhenCalledWithEmptyIDictionary()
        {
            CsvOutput mockOutput = new CsvOutput("Random_file_path");
            IDictionary<string, int> dict = new Dictionary<string, int>();
            mockOutput.WriteOutput(dict);
            Assert.True(mockOutput.FileOutput.Count == 0);
        }
    }
}

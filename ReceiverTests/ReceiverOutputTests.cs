using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{
    public class MockCSVOutput : IReceiverOutput
    {
        private string filepath;
        public List<string> MockFileOutput = new List<string>();
        public bool OutputStatus;

        public MockCSVOutput(string filepath)
        {
            this.filepath = filepath;
            OutputStatus = false;
        }

        public void WriteOutput(IDictionary<string, int> WordFrequency)
        {
            foreach (var line in WordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                MockFileOutput.Add(newLine);
            }

            OutputStatus = true;
        }
    }

    public class ReceiverOutputTests
    {
        [Fact]
        public void TestExpectingStatusOfFileWrittenAsTrueWhenCalledWithDictionaryOfWordFrequnecy()
        {
            var mockOutput = new MockCSVOutput("Random_file_path");
            IDictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("sample1", 1);
            dict.Add("sample2", 2);
            mockOutput.WriteOutput(dict);
            Assert.True(mockOutput.OutputStatus);
        }

        [Fact]
        public void TestExpectingValidMockFileOutputWhenCalledWithDictionaryOfWordFrequnecy()
        {
            var mockOutput = new MockCSVOutput("Random_file_path");
            IDictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("sample1", 1);
            dict.Add("sample2", 2);
            mockOutput.WriteOutput(dict);
            Assert.Equal("sample1,1", mockOutput.MockFileOutput[0]);
        }
    }
}
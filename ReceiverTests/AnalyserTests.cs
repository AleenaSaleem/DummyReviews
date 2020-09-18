using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{
    public class AnalyserTests
    {
        [Fact]
        public void TestExpectingIEnumenrableContainingWordsSeparatedBYSpaceWhenCalledWithValidIEnumerable()
        {
            var TestInput = new List<string>();
            TestInput.Add("this is sample test string");
            var Output = (List<string>) Analyser.GetSeparatedWordsBySpaceFromARow(TestInput);
            Assert.Equal("this", Output[0]);
            Assert.Equal("is", Output[1]);
        }

        [Fact]
        public void TestExpectingAnUpdatedDictionaryOfWordFrequencyWhenCalledWithDictionaryToUpdateAndIEnumerable()
        {
            var TestInput = new List<string>();
            TestInput.Add("this");
            TestInput.Add("sample");
            IDictionary<string, int> DictToUpdate = new Dictionary<string, int>();
            DictToUpdate.Add("dummy", 1);
            DictToUpdate.Add("sample", 1);
            var updatedDict = Analyser.AddWordCountInDictionary(DictToUpdate, TestInput);
            Assert.True(updatedDict["this"] == 1);
            Assert.True(updatedDict["sample"] == 2);
        }

        [Fact]
        public void TestExpectingWordFrequencyOfAllWordsWhenCalledWithATwoDimensionalIEnumerable()
        {
            var TestAnalyser = new Analyser();
            var TestInput = new List<List<string>>();
            var tempList1 = new List<string>();
            tempList1.Add("sample string1");
            var tempList2 = new List<string>();
            tempList2.Add("sample string2");
            TestInput.Add(tempList1);
            TestInput.Add(tempList2);
            var TestOutput = TestAnalyser.CountWordFrequency(TestInput);
            Assert.True(TestOutput["string1"] == 1);
            Assert.True(TestOutput["sample"] == 2);
        }
    }
}
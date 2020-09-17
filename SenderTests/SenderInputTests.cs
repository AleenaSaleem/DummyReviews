using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using Sender;

namespace SenderTests
{
    /*public class MockInputInterface: ISenderInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput(string filepath)
        {
            List < List<string> >  MockInput= new List<List<string>>();
            List<string> row = new List<string>();
            row.Add("sample string");
            MockInput.Add(row);
            return MockInput;
        }
    }*/
    public class SenderInputTests
    {
        [Fact]
        public void TestExpectingValidFilepathAssignmentToClassMemberWhenCalledWithValidFilepath()
        {
            string filepath = @"EmptySample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            Assert.Equal("EmptySample.csv", csvInput.filepath);
        }
        [Fact]
        public void TestExpectingCSVFileToBeReadWhenCalledWithFilePath()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            List<List<string>> testOutput = (List<List<string>>)csvInput.ReadInput();
            Debug.Assert(testOutput[0][0] == "sampledata");
            Console.WriteLine(testOutput[0][0]);
            Console.WriteLine("test");
        }
        [Fact]
        public void TestExpectingOutputToBeEmptyWhenCalledWithFilePathWhereFileIsEmpty()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\EmptySample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            List<List<string>> testOutput = (List<List<string>>)csvInput.ReadInput();
            Assert.True(testOutput.Count==0);
        }
        [Fact]
        public void TestExpectingExceptionWhenFileCouldNotBeFoundOrOpened()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample2.csv";
            CSVInput csvInput = new CSVInput(filepath);
            Assert.True(csvInput.InputExceptionHandler());
        }
        [Fact]
        public void TestExpectingNoExceptionWhenFileExists()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            Assert.False(csvInput.InputExceptionHandler());
        }
    }
}

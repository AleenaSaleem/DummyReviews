using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;
using Sender;

namespace SenderTests
{
    public class SenderInputTests
    {
        [Fact]
        public void TestExpectingValidFilepathAssignmentToClassMemberWhenCalledWithValidFilepath()
        {
            const string filepath = @"EmptySample.csv";
            var csvInput = new CsvInput(filepath);
            Assert.Equal("EmptySample.csv", csvInput.Filepath);
        }

        [Fact]
        public void TestExpectingCsvFileToBeReadWhenCalledWithFilePath()
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            var csvInput = new CsvInput(filepath);
            var testOutput = (List<List<string>>)csvInput.ReadInput();
            Debug.Assert(testOutput[0][0] == "sampledata");
        }

        [Fact]
        public void TestExpectingOutputToBeEmptyWhenCalledWithFilePathWhereFileIsEmpty()
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\EmptySample.csv";
            var csvInput = new CsvInput(filepath);
            var testOutput = (List<List<string>>)csvInput.ReadInput();
            Assert.True(testOutput.Count == 0);
        }

        [Fact]
        public void TestExpectingTrueWhenCheckIfFileExistsMethodIsCalledFromThisMethod()
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            var csvInput = new CsvInput(filepath);
            Assert.True(csvInput.InputExceptionHandler());
        }

        [Fact]
        public void TestExpectingExceptionWhenFileDoesNotExistsOrCouldNotBeFound()
        {
            const string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample2.csv";
            var csvInput = new CsvInput(filepath);
            Assert.Throws<FileNotFoundException>(() => csvInput.CheckIfFileExists());
        }
    }
}

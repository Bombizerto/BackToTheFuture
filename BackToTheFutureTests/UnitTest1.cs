using System;
using Xunit;
using BackToTheFutureLib;
using System.Collections.Generic;

namespace BackToTheFutureTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestSerializeToJson()
        {
            string path = "C:\\Users\\aidan.marinelarena\\Documents\\BackToTheFuture\\";
            List<FileLog> files = FolderScanner.ScanFolder(path);
            FolderScanner.SerializeToJson(path, FolderScanner.FindDuplicates(files));
            Assert.True(true);
        }
        
        [Fact]
        public void TestDeserializeFromJson()
        {
            string path = "C:\\Users\\aidan.marinelarena\\Documents\\BackToTheFuture\\Result.json";
            FolderScanner.DeserializeFromJson(path);
            Assert.True(true);
        }
    }
}

using System.Diagnostics;

namespace ScanSnapImageOrganizer.Test
{
    //! @brief 単体テストのテスター
    internal class UnitTester
    {
        //! @brief 単体テストを全て行う
        public void TestAll()
        {
#if DEBUG
            TestFileNameFilter();
#endif
        }

        //! @brief FileNameFilterの関数の単体テストを行う
        public void TestFileNameFilter()
        {
#if DEBUG
            //正規表現が間違っていた場合ヒットしないかのテスト
            var filter = new IO.FileNameFilter(@"");
            var testFilePathList = new List<string>() { "TestFilePath.jpg", "TestFilePath_000.jpg", "TestFilePath_001.jpg" };
            Debug.Assert(filter.ListTitleFilePaths(testFilePathList).Count == 0);

            //与えた正規表現できちんとヒットするかどうかのテスト
            filter = new IO.FileNameFilter(@".*_[0-9]{3}\.jpg");
            Debug.Assert(filter.ListTitleFilePaths(testFilePathList).Count == 1);
#endif
        }
    }
}

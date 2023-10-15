using System.Reflection;

namespace ScanSnapImageOrganizer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
#if DEBUG
            var unitTester = new Test.UnitTester();
            unitTester.TestAll();
#endif

            //画像ファイルのパスのリストを取得
            //特に指定がない限り、フォルダ分けしたいフォルダに放り込む使い方を想定
            var targetDirectoryPath = 0 < args.Length ? args[0] : "";
            if (string.IsNullOrEmpty(targetDirectoryPath) || string.IsNullOrWhiteSpace(targetDirectoryPath))
            {
                targetDirectoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
            var allImageFilePaths = Directory.GetFiles(targetDirectoryPath, @"*.jpg").ToList();
            
            //各本の表紙のリストを取得
            var filter = new IO.FileNameFilter(@".*_[0-9]{3}\.jpg");
            var titleFilePaths = filter.ListTitleFilePaths(allImageFilePaths);


            Console.WriteLine("ScanSnapで生成した画像ファイルのフォルダ分けを開始します");
            Console.WriteLine($"今回の実行時間：{DateTime.Now}");
            Console.WriteLine($"フォルダ分け対象のディレクトリ：{targetDirectoryPath}");
            Console.WriteLine("ScanSnapで生成した画像ファイルのフォルダ分けを完了しました");
        }
    }
}
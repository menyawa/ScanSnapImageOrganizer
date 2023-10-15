using System.Text.RegularExpressions;

namespace ScanSnapImageOrganizer.IO
{
    //! @brief ファイル名のリストのフィルター
    internal class FileNameFilter
    {
        private string _sequentialFileNamePattern; //! @brief 連番が振られている(2ページ目以降の)ファイル名のパターン(正規表現)

        //! @brief コンストラクタ
        //! 
        //! @param[in] newNumberFileNamePattern 連番が振られている(2ページ目以降の)ファイル名のパターン(正規表現)
        public FileNameFilter(string newSequentialFileNamePattern)
        {
            _sequentialFileNamePattern = newSequentialFileNamePattern;
        }

        //! @brief タイトルが書かれたファイルのパスをリストアップする
        //! 
        //! @param[in] targetFileNameList 走査対象のファイルパスのリスト
        //! 
        //! @return タイトルのファイルパスのリスト
        public List<string> ListTitleFilePaths(in List<string> targetFilePathList)
        {
            var regex = new Regex(_sequentialFileNamePattern, RegexOptions.IgnoreCase);
            return targetFilePathList.Where(element => regex.IsMatch(element) == false).ToList();
        }
    }
}

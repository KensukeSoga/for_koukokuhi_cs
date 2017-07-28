using Isid.NJ;

namespace Isid.KKH.Main
{
    class ApliConfigureFileInfo : INJConfigureFileInfo
    {
        #region INJConfigureFileInfo メンバ


        /// <summary>
        /// Log4Net用設定ファイルのパスを取得します。

        /// </summary>
        /// <returns>Log4Net用設定ファイルのパス</returns>
        public string GetLog4NetConfigureFilePath()
        {
            return "..\\..\\Runtime\\log4net.xml";
        }
        #endregion
    }
}

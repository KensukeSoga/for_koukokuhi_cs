using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHView.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelDispatcher
    {

        #region フィールド
        /// <summary>
        /// テンプレートExcelファイル名 
        /// </summary>
        private string _templateXlsFile;
        /// <summary>
        /// マクロExcelファイル名 
        /// </summary>
        private string _macroXlsFile;

        /// <summary>
        /// テンプレートリソース　バイト配列 
        /// </summary>
        private Byte[] _templateXls;
        /// <summary>
        /// マクロリソース　バイト配列 
        /// </summary>
        private Byte[] _macroXls;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="templateXlsFile">テンプレートExcelファイル名</param>
        /// <param name="macroXlsFile">マクロExcelファイル名</param>
        /// <param name="templateXls">テンプレートリソース</param>
        /// <param name="macroXls">マクロリソース</param>
        public ExcelDispatcher(string templateXlsFile,
                                string macroXlsFile,
                                Byte[] templateXls,
                                Byte[] macroXls)
        {
            this._templateXlsFile = templateXlsFile;
            this._macroXlsFile = macroXlsFile;
            this._templateXls = templateXls;
            this._macroXls = macroXls;
        }
        #endregion コンストラクタ

        #region publicメソッド
        /// <summary>
        /// Excelマクロを起動する 
        /// </summary>
        public void ProcessStart()
        {
            // Excelファイルを出力する 
            if (!CreateMacroFiles())
            {
                // マクロファイル出力エラー 
                return;
            }

            int retryCount = KKHParameter.GetInstance().ExcelStartRetryCount;
            bool isExecute = false;
            int loopCnt = 0;
            while (true)
            {
                try
                {
                    // Excel起動 
                    System.Diagnostics.Process hProcess = System.Diagnostics.Process.Start(this._macroXlsFile);

                    isExecute = true;
                }
                catch (Exception)
                {
                    if (loopCnt >= retryCount)
                    {
                        // アクセス権エラー 
                        //MessageUtility.ShowMessageBoxByDB(MessageCode.BD_E0010);
                    }
                }

                loopCnt++;

                if (isExecute || loopCnt > retryCount)
                {
                    break;
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
        #endregion publicメソッド

        #region privateメソッド
        /// <summary>
        /// Excelマクロファイル出力処理 
        /// </summary>
        /// <returns></returns>
        private bool CreateMacroFiles()
        {
            // ファイル出力例外をキャッチする 
            try
            {
                // マクロExcelファイルをファイル出力する 
                File.WriteAllBytes(this._macroXlsFile, this._macroXls);
                SetupAccessRule(this._macroXlsFile);
                // テンプレートExcelファイルを出力する 
                File.WriteAllBytes(this._templateXlsFile, this._templateXls);
                SetupAccessRule(this._templateXlsFile);

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                //MessageUtility.ShowMessageBoxByDB(MessageCode.BD_E0011);

            }
            catch (IOException)
            {
                //MessageUtility.ShowMessageBoxByDB(MessageCode.BD_E0011);

            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// ファイルアクセス権限設定処理 
        /// </summary>
        /// <returns></returns>
        private void SetupAccessRule(string filePath)
        {
            FileSystemAccessRule rule = new FileSystemAccessRule(new NTAccount("everyone"), 
                                                                 FileSystemRights.FullControl, 
                                                                 AccessControlType.Allow);
            FileSecurity security = File.GetAccessControl(filePath);
            security.AddAccessRule(rule);
            File.SetAccessControl(filePath, security);
        }


        #endregion privateメソッド
    }
}

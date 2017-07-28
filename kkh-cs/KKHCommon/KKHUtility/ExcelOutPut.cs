using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcelDefine
    {
        /// <summary>
        /// テキスト型 
        /// </summary>
        public const string EXCELVARCHAR = "memo";
        /// <summary>
        /// 
        /// </summary>
        public const string EXCEL_EXT_2007 = ".xlsx";
        
        /// <summary>
        /// 
        /// </summary>
        public const string EXCEL_EXT_200X = ".xls";

        //エラー 
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_NO_ERROR = 0x0;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_OPEN_ERROR = 0x10;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_CLOSE_ERROR = 0x11;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_TABLE_ERROR = 0x15;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_INSERT_ERROR = 0x1a;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 EXCEL_OTHER_ERROR = 0x1f;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExcelOutPut
    {
        //時刻表示指定 
        /// <summary>
        /// 
        /// </summary>
        public string strEXCELTIME;

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ExcelOutPut()
        {
            this.strEXCELTIME = "yyyy/MM/dd hh:mm:ss";
        }

        /// <summary>
        /// エクセル出力関数(DataTable)
        /// </summary>
        /// <param name="strFileName">ファイル名</param>
        /// <param name="dt">DataTable</param>
        /// <param name="strErrMessage">エラーメッセージ</param>
        /// <param name="strSheetName"></param>
        /// <returns>リターン値</returns>
        public Int32 ExcelOutFromDataTable(
            string strFileName,
            string strSheetName,
            DataTable dt,
            ref string strErrMessage
          )
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection();
            string strCommand = "create table ";
            string strTable = "";

            try
            {
                this.ExcelProvider(strFileName, ref strTable, ref conn);
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    strErrMessage = "ファイルが開けません" +
                      Environment.NewLine + ex.Message;
                    return ExcelDefine.EXCEL_OPEN_ERROR;
                }

                //ファイルを作成
                command = conn.CreateCommand();

                // テーブルを作成
                if (strSheetName == "")
                {
                    strTable = "1";
                }
                else
                {
                    strTable = strSheetName;
                }
                strCommand += "[" + strTable + "]" + "(";
                for (Int32 i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].DataType.Name == "Integer" |
                      dt.Columns[i].DataType.Name == "Int32" |
                      dt.Columns[i].DataType.Name == "Decimal" |
                      dt.Columns[i].DataType.Name == "Long" |
                      dt.Columns[i].DataType.Name == "Double" |
                      dt.Columns[i].DataType.Name == "Short")
                    {
                        //セルの書式を数値型に設定　
                        strCommand += "[" + dt.Columns[i].ColumnName + "] int ";
                    }
                    else if (dt.Columns[i].DataType.Name == "DateTime")
                    {
                        //セルの書式を日付型に設定　
                        strCommand += "[" + dt.Columns[i].ColumnName + "] time ";
                    }
                    else
                    {
                        strCommand += "[" + dt.Columns[i].ColumnName + "] " + ExcelDefine.EXCELVARCHAR;
                    }
                    //最後じゃなければ「，」をつける
                    if (i != dt.Columns.Count - 1)
                    {
                        strCommand += ",";
                    }
                }
                strCommand += ")";
                command.CommandText = strCommand;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    strErrMessage = "Tableの作成に失敗しました" + Environment.NewLine +
                      "コマンド：" + strCommand + " " + Environment.NewLine +
                      ex.Message;
                    conn.Close();
                    return ExcelDefine.EXCEL_TABLE_ERROR;
                }

                //データ入力(パラメータマッチング)
                strCommand = " INSERT INTO " + "[" + strTable + "]" + " VALUES (";
                for (Int32 i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].DataType == null)
                    {
                        continue;
                    }
                    strCommand += "?";
                    //最後じゃなければ「，」をつける
                    if (i != dt.Columns.Count - 1)
                    {
                        strCommand += ",";
                    }
                }
                strCommand += ")";


                command.CommandText = strCommand;
                foreach (DataRow dtRow in dt.Rows)
                {
                    command.Parameters.Clear();
                    for (Int32 i = 0; i < dt.Columns.Count; i++)
                    {
                        //日時の場合
                        if (dt.Columns[i].DataType.Name == "DateTime")
                        {
                            DateTime dTime = (DateTime)dtRow[i];
                            command.Parameters.AddWithValue(
                              "@" + i.ToString(),
                              "time"
                              ).Value = dTime.ToString(this.strEXCELTIME);
                        }
                        //数値の場合
                        else if (dt.Columns[i].DataType.Name == "Integer" |
                          dt.Columns[i].DataType.Name == "Int32" |
                          dt.Columns[i].DataType.Name == "Decimal" |
                          dt.Columns[i].DataType.Name == "Long" |
                          dt.Columns[i].DataType.Name == "Double" |
                          dt.Columns[i].DataType.Name == "Short")
                        {
                            command.Parameters.AddWithValue("@" + i.ToString(), "int").Value = dtRow[i];
                        }
                        //それ以外の場合
                        else
                        {
                            command.Parameters.AddWithValue("@" + i.ToString(), "text").Value = dtRow[i];
                        }
                    }

                    try
                    {
                        //コマンド実行
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        strErrMessage = "データ出力に失敗しました" + Environment.NewLine +
                          "コマンド：" + command.CommandText + " " +
                          Environment.NewLine + ex.Message;
                        conn.Close();
                        return ExcelDefine.EXCEL_INSERT_ERROR;
                    }
                }

                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    strErrMessage = "Excelファイルの終了処理に失敗しました" +
                      Environment.NewLine + ex.Message;
                    return ExcelDefine.EXCEL_CLOSE_ERROR;
                }

                return ExcelDefine.EXCEL_NO_ERROR;
            }
            catch (Exception ex)
            {
                strErrMessage = "Excelファイルの出力処理に失敗しました" +
                  Environment.NewLine + ex.Message;
                return ExcelDefine.EXCEL_OTHER_ERROR;
            }
        }

        /// <summary>
        /// エクセル出力関数(DataGridViewから)
        /// </summary>
        /// <param name="strFileName">ファイル名</param>
        /// <param name="bCurr">trueなら選択のみ</param>
        /// <param name="dgv">DataGridView</param>
        /// <param name="strErrMessage">エラーメッセージ</param>
        /// <param name="strSheetName"></param>
        /// <returns>リターン値</returns>
        public Int32 ExcelDGVOut(
            string strFileName,
            string strSheetName,
            Boolean bCurr,
            DataGridView dgv,
            ref string strErrMessage
          )
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection conn = new OleDbConnection();
            string strCommand = "create table ";
            string strTable = "";
            Int32 iRet = ExcelDefine.EXCEL_NO_ERROR;

            try
            {
                this.ExcelProvider(strFileName, ref strTable, ref conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    strErrMessage = "ファイルが開けません" +
                      Environment.NewLine + ex.Message;
                    return ExcelDefine.EXCEL_OPEN_ERROR;
                }

                //ファイルを作成
                command = conn.CreateCommand();

                // テーブルを作成
                if (strSheetName == "")
                {
                    strTable = "1";
                }
                else
                {
                    strTable = strSheetName;
                }
                strCommand += "[" + strTable + "]" + "(";
                for (Int32 i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].ValueType.Name == "Integer" |
                      dgv.Columns[i].ValueType.Name == "Int32" |
                      dgv.Columns[i].ValueType.Name == "Decimal" |
                      dgv.Columns[i].ValueType.Name == "Long" |
                      dgv.Columns[i].ValueType.Name == "Double" |
                      dgv.Columns[i].ValueType.Name == "Short")
                    {
                        //セルの書式を数値型に設定　
                        strCommand += "[" + dgv.Columns[i].HeaderText + "] int ";
                    }
                    else if (dgv.Columns[i].ValueType.Name == "DateTime")
                    {
                        //セルの書式を日付型に設定　
                        strCommand += "[" + dgv.Columns[i].HeaderText + "] time ";
                    }
                    else
                    {
                        strCommand += "[" + dgv.Columns[i].HeaderText + "] " + ExcelDefine.EXCELVARCHAR;
                    }
                    //最後じゃなければ「，」をつける
                    if (i != dgv.Columns.Count - 1)
                    {
                        strCommand += ",";
                    }
                }
                strCommand += ")";
                command.CommandText = strCommand;

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    strErrMessage = "Tableの作成に失敗しました" + Environment.NewLine +
                      "コマンド：" + strCommand + " " + Environment.NewLine +
                      ex.Message;
                    conn.Close();
                    return ExcelDefine.EXCEL_TABLE_ERROR;
                }

                //データ入力(パラメータマッチング)
                strCommand = " INSERT INTO " + "[" + strTable + "]" + " VALUES (";
                for (Int32 i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].ValueType == null)
                    {
                        continue;
                    }
                    strCommand += "?";
                    //最後じゃなければ「，」をつける
                    if (i != dgv.Columns.Count - 1)
                    {
                        strCommand += ",";
                    }
                }
                strCommand += ")";

                command.CommandText = strCommand;
                //全部出力
                if (bCurr == false)
                {
                    foreach (DataGridViewRow dtRow in dgv.Rows)
                    {
                        if ((iRet = this.DGVSetFunc(
                          dgv,
                          dtRow,
                          ref conn,
                          ref command,
                          ref strErrMessage
                          )) != ExcelDefine.EXCEL_NO_ERROR
                          )
                        {
                            return iRet;
                        }
                    }
                }
                //選択のみ出力
                else
                {
                    DataGridViewSelectedRowCollection dtRows = dgv.SelectedRows;
                    foreach (DataGridViewRow dtRow in dtRows)
                    {
                        if ((iRet = this.DGVSetFunc(
                          dgv,
                          dtRow,
                          ref conn,
                          ref command,
                          ref strErrMessage
                          )) != ExcelDefine.EXCEL_NO_ERROR
                          )
                        {
                            return iRet;
                        }
                    }
                }
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    strErrMessage = "Excelファイルの終了処理に失敗しました" +
                      Environment.NewLine + ex.Message;
                    return ExcelDefine.EXCEL_CLOSE_ERROR;
                }

                return iRet;
            }
            catch (Exception ex)
            {
                strErrMessage = "Excelファイルの出力処理に失敗しました" +
                  Environment.NewLine + ex.Message;
                conn.Close();
                return ExcelDefine.EXCEL_OTHER_ERROR;
            }
        }

        /// <summary>
        /// プロバイダ選定 
        /// </summary>
        /// <param name="strFileName">保存ファイル名</param>
        /// <param name="strTable">テーブル名またはファイル名</param>
        /// <param name="conn">OleDbConnectionハンドル</param>
        private void ExcelProvider(
          string strFileName,
          ref string strTable,
          ref OleDbConnection conn
          )
        {
            string strExt;

            //ファイルの拡張子チェック
            //拡張子で判断しないとプロバイダが受け付けてくれないため
            strExt = Path.GetExtension(strFileName);

            if (String.Compare(strExt, ExcelDefine.EXCEL_EXT_2007,true) == 0)
            {
                conn = new OleDbConnection(
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                  strFileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
                //strTable = "1";
            }
            else if (String.Compare(strExt, ExcelDefine.EXCEL_EXT_200X, true) == 0)
            {
                conn = new OleDbConnection(
                  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                  strFileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"");
                //strTable = "1";
            }
            else
            {
                //csvファイルにするとschema.iniが作成されるが仕様である
                //非常に時間がかかる
                conn = new OleDbConnection(
                  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                  Path.GetDirectoryName(strFileName) +
                  ";Extended Properties=\"Text;FMT=Delimited;HDR=Yes\"");
                strTable = Path.GetFileName(strFileName);
            }
        }

        /// <summary>
        /// DataGridViewからExcelファイルに出力 
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="dtRow">DataRow</param>
        /// <param name="conn">OleDbConnection</param>
        /// <param name="command">OleDbCommand</param>
        /// <param name="strErrMessage">エラーメッセージ</param>
        /// <returns>エラー値</returns>
        private Int32 DGVSetFunc(
          DataGridView dgv,
          DataGridViewRow dtRow,
          ref OleDbConnection conn,
          ref OleDbCommand command,
          ref string strErrMessage
          )
        {
            command.Parameters.Clear();
            for (Int32 i = 0; i < dgv.Columns.Count; i++)
            {
                //日時の場合
                if (dgv.Columns[i].ValueType.Name == "DateTime")
                {
                    DateTime dTime = (DateTime)dtRow.Cells[i].Value;
                    command.Parameters.AddWithValue(
                      "@" + i.ToString(),
                      "time"
                      ).Value = dTime.ToString(this.strEXCELTIME);
                }
                //数値の場合
                else if (dgv.Columns[i].ValueType.Name == "Integer" |
                  dgv.Columns[i].ValueType.Name == "Int32" |
                  dgv.Columns[i].ValueType.Name == "Decimal" |
                  dgv.Columns[i].ValueType.Name == "Long" |
                  dgv.Columns[i].ValueType.Name == "Double" |
                  dgv.Columns[i].ValueType.Name == "Short")
                {
                    command.Parameters.AddWithValue("@" + i.ToString(), "int").Value = dtRow.Cells[i].Value;
                }
                //それ以外の場合
                else
                {
                    command.Parameters.AddWithValue("@" + i.ToString(), "text").Value = dtRow.Cells[i].Value;
                }
            }

            try
            {
                //コマンド実行
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strErrMessage = "データ出力に失敗しました" + Environment.NewLine +
                  "コマンド：" + command.CommandText + " " +
                  Environment.NewLine + ex.Message;
                return ExcelDefine.EXCEL_INSERT_ERROR;
            }
            return ExcelDefine.EXCEL_NO_ERROR;
        }
    }
}

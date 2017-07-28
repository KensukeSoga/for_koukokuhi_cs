using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using FarPoint.Win.Spread;
using FarPoint.Excel;
using FarPoint.Win;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; 

using System.Text.RegularExpressions;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// スプレッド内容のEXCEL出力 
    /// </summary>
    public class KKHSpreadOutPutExcelHandler : IDisposable
    {
        #region 定数
        /// <summary>
        /// シート名定数 
        /// </summary>
        private const string SHEET_TEMP_NAME = "CopySheet";

        /// <summary>
        /// 出力するExcelの拡張子  
        /// </summary>
        public const string OUTPUT_EXCEL_EXT = ".xls";
        #endregion

        #region フィールド


        /// <summary>
        /// スプレッド 
        /// </summary>
        private FpSpread _spread;
        /// <summary>
        /// 出力ファイル名 
        /// </summary>
        private string _outFileName;
        /// <summary>
        /// Excelファイル出力確認フラグ 
        /// </summary>
        private bool _outFlg = false;

        /// <summary>
        /// 出力Excel情報 
        /// （2009/02/23 ISID-IT T.TAKEI ADD） 
        /// </summary>
        private List<string> _outPutExcelInfo = null;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="spread">スプレッド</param>
        /// <param name="outFileName">出力ファイル名</param>
        public KKHSpreadOutPutExcelHandler(FpSpread spread, string outFileName)
        {
            this._spread = spread;
            this._outFileName = outFileName + OUTPUT_EXCEL_EXT;
        }
        #endregion

        #region 外部公開メソッド

        /// <summary>
        /// Excelファイル出力処理 
        /// </summary>
        public void OutPutExcel()
        {
            if (this._spread != null && this._spread.ActiveSheet != null)
            {
                excelCreate();
            }
        }

        /// <summary>
        /// Excelファイル出力処理 
        /// （2009/02/23 ISID-IT T.TAKEI ADD） 
        /// </summary>
        /// <param name="outPutExcelInfo"></param>
        public void OutPutExcel(List<string> outPutExcelInfo)
        {
            _outPutExcelInfo = outPutExcelInfo;

            //Excelファイル出力処理 
            OutPutExcel();
        }

        /// <summary>
        /// Excelファイル起動処理 
        /// </summary>
        public void ProcessStart()
        {
            if (_outFlg)
            {
                while (true)
                {
                    if (System.IO.File.Exists(this._outFileName))
                    {
                        break;
                    }
                }
                System.Diagnostics.Process hProcess = System.Diagnostics.Process.Start(this._outFileName);
            }
        }

        #endregion


        // ----------------------------------------------------------
        // DataGridViewをEXCELに出力するサンプル(C#.NET/VS2005)
        // Excelを参照設定する必要があります 
        // [参照の追加],[COM],[Microsoft Excel *.* Object Library] 
        // using Excel = Microsoft.Office.Interop.Excel; (必要) 
        // using System.Runtime.InteropServices; (必要) 
        public void SaveExcel()
        {
            // EXCEL起動 
            Excel.Application objExcel = null;
            Excel.Workbook objWorkBook = null;
            Excel.Worksheet objWorkSheet = null;
            objExcel = new Excel.Application();
            objWorkBook = objExcel.Workbooks.Add(
                Excel.XlWBATemplate.xlWBATWorksheet);

            //子スプレッド用 
            FarPoint.Win.Spread.SheetView childSpd;
            // EXCELにデータ転送 
            objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];

            // SPREADの項目取得.
            //データセル用 
            String[,] v = new String[
             this._spread.Sheets[0].Rows.Count, this._spread.Sheets[0].Columns.Count];
            //ヘッダー用 
            String ht = "";
            //カラム用（ヘッダ、データで使用） 
            int colcnt = 1;
            int rowcnt = 1;
            int c_colcnt = 1;

            //全部文字列に　TODO：いいのかな
            ((Excel.Range)objWorkSheet.get_Range(
                objWorkSheet.Cells[1, 3],
                objWorkSheet.Cells[65535, 3])).NumberFormatLocal = "@";

            //ヘッダ取得 
            for (int c = 0; c <= this._spread.Sheets[0].Columns.Count - 1; c++)
            {
                Column col = this._spread.Sheets[0].Columns[c];
                //ht = this._spread.Sheets[0].Columns[c].Label;
                //v[0, c] = ht;
                //表示列のみ表示 
                if (this._spread.Sheets[0].Columns[c].Visible == true)
                {
                    //値反映 
                    objWorkSheet.get_Range(objWorkSheet.Cells[1, colcnt], objWorkSheet.Cells[1, colcnt]).Value2 =
                        this._spread.Sheets[0].Columns[c].Label;

                    //色反映 
                    objWorkSheet.get_Range(objWorkSheet.Cells[1, colcnt], objWorkSheet.Cells[1, colcnt]).Interior.Color =
                       ColorTranslator.ToOle(col.BackColor);

                    //幅反映 
                    ((Excel.Range)objWorkSheet.get_Range(
                          objWorkSheet.Cells[1, colcnt], objWorkSheet.Cells[1, colcnt])).ColumnWidth = 
                          this._spread.Sheets[0].Columns[c].Width / 10;

                    colcnt++;
                }
            }
            
            // SPREADのセルのデータ取得 
            for (int r = 0; r <= this._spread.Sheets[0].Rows.Count - 1; r++)
            {
                colcnt = 1;
                for (int c = 0; c <= this._spread.Sheets[0].Columns.Count - 1; c++)
                {
                    //表示列のみ表示 
                    if (this._spread.Sheets[0].Columns[c].Visible == true)
                    {
                        //値反映 
                        objWorkSheet.get_Range(objWorkSheet.Cells[r + 2, colcnt], objWorkSheet.Cells[r + 2, colcnt]).Value2 =
                            this._spread.Sheets[0].Cells[r,c].Value;

                        //色反映 
                        //objWorkSheet.get_Range(objWorkSheet.Cells[r + 2, colcnt], objWorkSheet.Cells[r + 2, colcnt]).Interior.Color =
                        //   ColorTranslator.ToOle(this._spread.Sheets[0].Cells[r, c].BackColor);

                        colcnt++;
                    }

                }

                //子スプレッドが存在したら出力 
                childSpd = this._spread.Sheets[0].GetChildView(r, 0);
                if (childSpd.RowCount != 0)
                {
                    c_colcnt = 1;
                    //ヘッダ取得  
                    for (int c = 0; c <= childSpd.Columns.Count - 1; c++)
                    {
                        Column col = childSpd.Columns[c];

                        rowcnt++;
                        //表示列のみ表示 
                        if (childSpd.Columns[c].Visible == true)
                        {
                            //値反映 
                            objWorkSheet.get_Range(objWorkSheet.Cells[rowcnt, colcnt], objWorkSheet.Cells[rowcnt, colcnt]).Value2 =
                                childSpd.Columns[c].Label;

                            //色反映 
                            objWorkSheet.get_Range(objWorkSheet.Cells[rowcnt, colcnt], objWorkSheet.Cells[rowcnt, colcnt]).Interior.Color =
                               ColorTranslator.ToOle(col.BackColor);

                            colcnt++;
                        }
                    }

                    // 子SPREADのセルのデータ取得 
                    for (int cr = 0; cr <= childSpd.Rows.Count - 1; cr++)
                    {
                        c_colcnt = 1;
                        for (int cc = 0; cc <= childSpd.Columns.Count - 1; cc++)
                        {
                            //表示列のみ表示 
                            if (childSpd.Columns[cc].Visible == true)
                            {
                                //値反映 
                                objWorkSheet.get_Range(objWorkSheet.Cells[rowcnt + 2, colcnt], objWorkSheet.Cells[rowcnt + 2, colcnt]).Value2 =
                                    this._spread.Sheets[0].Cells[cr, cc].Value;

                                //色反映 
                                //objWorkSheet.get_Range(objWorkSheet.Cells[rowcnt + 2, colcnt], objWorkSheet.Cells[rowcnt + 2, colcnt]).Interior.Color =
                                //   ColorTranslator.ToOle(this._spread.Sheets[0].Cells[cr, cc].BackColor);

                                colcnt++;
                            }

                        }
                        rowcnt++;
                    }


                }

                rowcnt++;
            }



            //objWorkSheet.get_Range(
            //    objWorkSheet.Cells[1, 1], objWorkSheet.Cells[
            //    this._spread.Sheets[0].Rows.Count, this._spread.Sheets[0].Columns.Count]).Value2 = v;

            // エクセル表示 
            objExcel.Visible = true;

            // EXCEL解放 
            Marshal.ReleaseComObject(objWorkBook);
            Marshal.ReleaseComObject(objExcel);
            Marshal.ReleaseComObject(objWorkSheet);
            objWorkSheet = null;
            objWorkBook = null;
            objExcel = null;
        }
        // ----------------------------------------------------------

        #region 内部メソッド[Excel出力]

        /// <summary>
        /// Excel内容を設定する 
        /// </summary>
        private void excelCreate()
        {
            // スプレッドを新規作成 
            FpSpread spdOutPut = new FpSpread();
            spdOutPut.FocusRenderer = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer(0);

            bool flg = false;

            foreach (SheetView sheet in this._spread.Sheets)
            {
                // スプレッドにシートをコピー 
                if (sheet.Visible == true && sheet.Rows.Count > 0)
                {
                    //表示されているシートのみ 
                    spdOutPut.Sheets.Add(copySheetView(sheet));

                    //アクティブシートを選択 
                    if (this._spread.ActiveSheet.SheetName.Equals(sheet.SheetName))
                    {
                        spdOutPut.ActiveSheetIndex = spdOutPut.Sheets.Count - 1;

                        //アクティブシートへExcel出力情報を追加
                        //（2009/02/23 ISID-IT T.TAKEI ADD） 
                        addOutPutExcelInfo(spdOutPut.ActiveSheet);
                    }

                    flg = true;
                }
            }

            if (flg)
            {
                try
                {
                    //作成したスプレットをExcelファイルへ保存 
                    //出力したExcelファイルのセルを他のExcelファイルへコピーするとセルの色が変更される問題に対応 
                    spdOutPut.SaveExcel(this._outFileName, ExcelSaveFlags.SaveCustomColumnHeaders
                                                                | ExcelSaveFlags.UseDefaultColorPalette);

                    this._outFlg = true;
                }
                catch 
                {
                    // アクセス権エラー 
                    
                }
            }

            //メモリの開放
            spdOutPut.Dispose();
            spdOutPut = null;
        }

        /// <summary>
        /// スプレットのシートの内容をコピーしたシートを作成
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private SheetView copySheetView(SheetView sheet)
        {
            //シートコピーして出力  
            // シートを新規作成 
            SheetView sheetCopy = new SheetView();

            //これをすると列がずれるので削除 
            //アクティブシートオブジェクト情報を新規作成シートに当てはめる 
            //sheetCopy = Serializer.LoadObjectXml(sheet.GetType(),
            //                                       Serializer.GetObjectXml(sheet, SHEET_TEMP_NAME),
            //                                           SHEET_TEMP_NAME) as SheetView;

            //JSE ADD CNP対応 2012/07/13 STA
            //バインド解除　スプレッド列移動対応 
            sheetCopy.DataSource = null;

            //初期設定 
            sheetCopy.Rows.Count = sheet.Rows.Count;
            sheetCopy.Columns.Count = sheet.Columns.Count;

            //シート名をコピー 
            sheetCopy.SheetName = sheet.SheetName;

            //シート全体に設定されている罫線情報を初期化 
            GridLine gridline = new GridLine(GridLineType.None);
            sheetCopy.HorizontalGridLine = gridline;
            sheetCopy.VerticalGridLine = gridline;

            #region ヘッダーの作成

            //行ヘッダーの背景色初期化 
            sheetCopy.ColumnHeader.Rows[-1].BackColor = Color.Empty;

            //--------------------------------------------------------------------------------------------
            // オートフィルタ OR ソートがあるヘッダをセル結合する（Excelにタイトルが２行表示されない為） 
            //--------------------------------------------------------------------------------------------

            //列ヘッダーの行数を取得 
            int columnHederRowCount = sheetCopy.ColumnHeader.Rows.Count;

            if (columnHederRowCount > 1)
            {
                //列ヘッダーが1行以上存在する場合は列ヘッダーのマージ処理 
                for (int i = 0; i < sheetCopy.Columns.Count; i++)
                {
                    if (columnHederRowCount == 2)
                    {
                        //カラムヘッダーが2行ある場合 
                        String value0 = sheetCopy.ColumnHeader.Cells[0, i].Text.Trim();
                        String value1 = sheetCopy.ColumnHeader.Cells[1, i].Text.Trim();

                        //ヘッダー内容の精査 
                        if (value0.Equals(value1))
                        {
                            value1 = "";
                        }

                        if (KKHUtility.IsBlank(value0))
                        {
                            //ヘッダー0が空白の場合 
                            sheetCopy.AddColumnHeaderSpanCell(0, i, 3, 1);
                        }

                        if (KKHUtility.IsBlank(value1))
                        {
                            //ヘッダー2行目が空白の場合ヘッダーをマージ 
                            sheetCopy.AddColumnHeaderSpanCell(0, i, 2, 1);
                        }

                        //sheetCopy.AddColumnHeaderSpanCell(0, i, 2, 1);

                    }
                    else if (columnHederRowCount == 3)
                    {
                        //カラムヘッダーが3行ある場合 
                        String value0 = sheetCopy.ColumnHeader.Cells[0, i].Text.Trim();
                        String value1 = sheetCopy.ColumnHeader.Cells[1, i].Text.Trim();
                        String value2 = sheetCopy.ColumnHeader.Cells[2, i].Text.Trim();

                        //ヘッダー内容の精査
                        if (value0.Equals(value1))
                        {
                            value1 = "";
                        }

                        if (value1.Equals(value2))
                        {
                            value2 = "";
                        }

                        if (KKHUtility.IsBlank(value0))
                        {
                            //ヘッダー1行名が空白の場合 
                            if (KKHUtility.IsBlank(value1))
                            {
                                //ヘッダー2行目もブランク
                                if (sheetCopy.ColumnHeader.Cells[0, i].RowSpan == 2)
                                {
                                    //ヘッダー１行目がマージされていない場合 
                                    sheetCopy.AddColumnHeaderSpanCell(0, i, 3, 1);
                                }
                                else
                                {
                                    //ヘッダー1行目がマージされている場合 
                                    sheetCopy.AddColumnHeaderSpanCell(1, i, 2, 1);
                                }

                            }
                            else
                            {
                                //ヘッダー2行目は設定されている 
                                if (KKHUtility.IsBlank(value2))
                                {
                                    //ヘッダー3行目がブランクの場合3行マージ   
                                    sheetCopy.AddColumnHeaderSpanCell(1, i, 2, 1);
                                }
                            }
                        }
                        else
                        {
                            //ヘッダー0が設定されている 
                            if (KKHUtility.IsBlank(value1) && KKHUtility.IsBlank(value2))
                            {
                                //ヘッダー2行目、3行目がともに空白の場合 
                                if (sheetCopy.ColumnHeader.Cells[0, i].RowSpan == 2)
                                {
                                    //ヘッダー１行目がマージされていない場合  
                                    sheetCopy.AddColumnHeaderSpanCell(0, i, 3, 1);
                                }
                                else
                                {
                                    //ヘッダー１行目がマージされている場合  
                                    sheetCopy.AddColumnHeaderSpanCell(1, i, 2, 1);
                                }
                            }
                            else
                            {
                                if (KKHUtility.IsBlank(value1))
                                {
                                    //ヘッダー１が空白の場合1行目と2行目のヘッダーを結合
                                    sheetCopy.AddColumnHeaderSpanCell(0, i, 3, 1);
                                }
                                else
                                {
                                    if (KKHUtility.IsBlank(value2))
                                    {
                                        //ヘッダー２が空白の場合2行目と3行目のヘッダーを結合
                                        sheetCopy.AddColumnHeaderSpanCell(1, i, 2, 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            //列の背景色初期化（データ範囲外まで色が塗られるのを阻止するため） 
            sheetCopy.Columns[0, sheetCopy.Columns.Count - 1].BackColor = Color.Empty;
            //行の背景色初期化（データ範囲外まで色が塗られるのを阻止するため） 
            sheetCopy.Rows[0, sheetCopy.Rows.Count - 1].BackColor = Color.Empty;

            //結合行のリスト 
            List<int> columnSpanRowList = new List<int>();

            //スプレットExcel出力レスポンスの改善  
            //データモデルを使用して明細一覧を作成 
            //日付型のスタイル 
            NamedStyle dateNamedStyle = new NamedStyle("Date");
            dateNamedStyle.HorizontalAlignment = CellHorizontalAlignment.Center;
            DateTimeCellType dateTimeCell = new DateTimeCellType();
            dateTimeCell.DateTimeFormat = DateTimeFormat.ShortDate;
            dateNamedStyle.CellType = dateTimeCell;

            //テキスト型のスタイル 
            NamedStyle textNamedStyle = new NamedStyle("Text");
            textNamedStyle.HorizontalAlignment = CellHorizontalAlignment.Left;
            textNamedStyle.CellType = new TextCellType();

            //チェックボックスのテキスト型スタイル 
            NamedStyle checkTextNamedStyle = new NamedStyle("CheckText");
            checkTextNamedStyle.HorizontalAlignment = CellHorizontalAlignment.Center;
            checkTextNamedStyle.CellType = new TextCellType();

            //スタイルをシートに設定 
            sheetCopy.NamedStyles = new NamedStyleCollection();
            sheetCopy.NamedStyles.Add(dateNamedStyle);
            sheetCopy.NamedStyles.Add(textNamedStyle);
            sheetCopy.NamedStyles.Add(checkTextNamedStyle);

            //シートのデフォルトスタイルモデルを作成 
            DefaultSheetStyleModel styleModel = (DefaultSheetStyleModel)sheetCopy.Models.Style;
            DefaultSheetDataModel dataModel = (DefaultSheetDataModel)sheetCopy.Models.Data;

            //シートのスタイルオブジェクトを取得 
            StyleInfo dateStyle = sheetCopy.NamedStyles.Find("Date");
            StyleInfo textStyle = sheetCopy.NamedStyles.Find("Text");
            StyleInfo checkTextStyle = sheetCopy.NamedStyles.Find("CheckText");

            //シート名をコピーシートにセット  
            for (int l = sheet.Columns.Count - 1; l > -1; l--)
            {
                sheetCopy.Columns[l].Label = sheet.Columns[l].Label;
                sheetCopy.Columns[l].CellType = sheet.Columns[l].CellType;
                sheetCopy.Columns[l].Width = sheet.Columns[l].Width;
            }

            // 全カラム　ループ 
            for (int l = sheet.Columns.Count - 1; l > -1; l--)
            {
                //列単位での色設定取得 
                Color columnColor = sheet.Columns[l].BackColor;
                Font fnt = sheet.Columns[l].Font;
                if (fnt != null)
                {
                    fnt = sheet.Columns[l].Font;
                }

                //全行ループ 
                for (int i = 0; i < sheet.RowCount; i++)
                {
                    if (!sheet.Cells[i, l].ColumnSpan.Equals(1))
                    {
                        //列結合行の場合表示列を検索 
                        int tempColumns = 0;
                        for (int x = 0; x < sheet.Columns.Count; x++)
                        {
                            if (sheet.Columns[l + x].Visible.Equals(true))
                            {
                                tempColumns = x;
                                break;
                            }
                        }

                        sheetCopy.Cells[i, l + tempColumns].Text = sheet.Cells[i, l].Text;

                        //結合した行を保持 
                        columnSpanRowList.Add(i);

                        //以降の処理は行わない 
                        continue;
                    }

                    String dispTxt = string.Empty;
                    Cell cell = sheet.Cells[i, l];
                    Cell copyCell = sheetCopy.Cells[i, l];

                    //セルタイプごとの表示内容の補正 
                    if (cell.CellType is CheckBoxCellType
                         || sheet.Columns[l].CellType is CheckBoxCellType)
                    {
                        //チェックボックスタイプのセル 
                        if (cell.Text.Equals("True"))
                        {
                            dispTxt = "☑";
                        }
                        else
                        {
                            dispTxt = "";
                        }
                        styleModel.SetDirectInfo(i, l, checkTextStyle);
                        dataModel.SetValue(i, l, dispTxt);
                    }
                    else if (cell.CellType is ComboBoxCellType
                        || sheet.Columns[l].CellType is ComboBoxCellType)
                    {
                        //コンボボックスタイプのセル 
                        ComboBoxCellType comboBoxCell = (ComboBoxCellType)cell.CellType;
                        if (KKHUtility.IsNull(comboBoxCell))
                        {
                            comboBoxCell = (ComboBoxCellType)sheet.Columns[l].CellType;
                        }

                        if (comboBoxCell.EditorValue.Equals(EditorValue.ItemData))
                        {
                            comboBoxCell.EditorValue = EditorValue.String;
                            dispTxt = KKHUtility.ToString(cell.Text);
                            comboBoxCell.EditorValue = EditorValue.ItemData;
                        }
                        else if (comboBoxCell.EditorValue.Equals(EditorValue.Index))
                        {
                            comboBoxCell.EditorValue = EditorValue.String;
                            dispTxt = KKHUtility.ToString(cell.Text);
                            comboBoxCell.EditorValue = EditorValue.Index;
                        }
                        else
                        {
                            dispTxt = KKHUtility.ToString(cell.Text);
                        }

                        if (KKHUtility.IsBlank(dispTxt))
                        {
                            dispTxt = cell.Text;
                        }

                        //スプレットのセル型を変更 
                        styleModel.SetDirectInfo(i, l, textStyle);
                        dataModel.SetValue(i, l, dispTxt);
                    }
                    else if (cell.CellType is MaskCellType
                        || sheet.Columns[l].CellType is MaskCellType)
                    {
                        //マスクテキストタイプのセル 
                        if (isDateCell(cell.Text))
                        {
                            styleModel.SetDirectInfo(i, l, dateStyle);
                            dataModel.SetValue(i, l, KKHUtility.StringCnvDateTime(cell.Text));
                        }
                        else
                        {
                            //マスク型のセル 
                            styleModel.SetDirectInfo(i, l, textStyle);
                            dataModel.SetValue(i, l, cell.Text);
                        }
                    }
                    else if (cell.CellType is ButtonCellType
                           || sheet.Columns[l].CellType is ButtonCellType)
                    {
                        //ボタンタイプのセル 
                        ButtonCellType buttonCell = (ButtonCellType)cell.CellType;
                        if (KKHUtility.IsNull(buttonCell))
                        {
                            buttonCell = (ButtonCellType)sheet.Columns[l].CellType;
                        }

                        if (!KKHUtility.IsNull(buttonCell))
                        {
                            dispTxt = KKHUtility.ToString(buttonCell.Text);
                        }

                        //スプレットのセル型を変更 
                        styleModel.SetDirectInfo(i, l, textStyle);
                        dataModel.SetValue(i, l, dispTxt);
                    }
                    else if (cell.CellType is NumberCellType
                        || sheet.Columns[l].CellType is NumberCellType)
                    {
                        //2011/12/22 HLC J.Morobayashi DELETE START
                        //数値型のセル
                        //copyCell.CellType = cell.CellType;
                        //copyCell.Value = cell.Value;
                        //2011/12/22 HLC J.Morobayashi DELETE END 


                        //2011/12/22 HLC J.Morobayashi ADD START
                        if (cell.CellType is NumberCellType)
                        {
                            //数値型のセル 
                            copyCell.CellType = cell.CellType;
                            copyCell.Value = cell.Value;
                        }
                        else if (sheet.Columns[l].CellType is NumberCellType)
                        {
                            //数値型のセル 
                            copyCell.CellType = sheet.Columns[l].CellType;
                            copyCell.Value = cell.Value;
                        }
                        else 
                        {
                            copyCell.CellType = cell.CellType;
                            copyCell.Value = cell.Value;
                        }
                        //2011/12/22 HLC J.Morobayashi ADD END 
                    }
                    else
                    {
                        //その他のセル 
                        if (isDateCell(cell.Text))
                        {
                            //セル内の値が日付形式の場合は日付が他のセルとして描写 
                            styleModel.SetDirectInfo(i, l, dateStyle);
                            dataModel.SetValue(i, l, KKHUtility.StringCnvDateTime(cell.Text));
                        }
                        else
                        {
                            //日付形式以外の場合はテキスト型のセルとして描写 
                            styleModel.SetDirectInfo(i, l, textStyle);
                            dataModel.SetValue(i, l, cell.Text);
                        }
                    }

                    //セルのフォントを設定 
                    copyCell.Font = cell.Font;

                    //文字の色を設定 
                    copyCell.ForeColor = cell.ForeColor;

                    //行単位での色設定取得 
                    Color rowColor = sheet.Rows[i].BackColor;
                    //セルの背景色を設定 
                    if (cell.BackColor.Equals(Color.White) || cell.BackColor.Equals(Color.Empty))
                    {

                        //copyCell.BackColor = cell.BackColor;

                        //*************************************************************
                        //セル単位で色を設定している場合もあるため、コメントアウト 
                        //*************************************************************

                        //行の背景が白以外の場合 
                        if (!rowColor.Equals(Color.White.Name) && !rowColor.Equals(Color.Empty))
                        {
                            //行の背景色がしろでない場合 
                            copyCell.BackColor = rowColor;
                        }
                        else
                        {
                            //列の背景が白の以外の場合 
                            if (!columnColor.Equals(Color.White.Name) && !columnColor.Equals(Color.Empty))
                            {
                                //行の背景色がしろでない場合 
                                copyCell.BackColor = columnColor;
                            }
                        }
                    }
                    else
                    {
                        //背景色が白、設定なし以外 
                        copyCell.BackColor = cell.BackColor;
                    }
                }
            }

            // シートの再調整
            //非表示列の保持用変数初期化 
            List<int> delColumn = new List<int>();
            for (int l = sheet.Columns.Count - 1; l >= 0; l--)
            {
                if (sheet.Columns[l].Visible == true)
                {
                    //列幅の設定 
                    sheetCopy.Columns[l].Width = sheet.Columns[l].Width;
                }
                else
                {
                    delColumn.Add(l);
                }
            }

            //非表示列の削除 
            if (delColumn.Count != 0)
            {
                for (int l = 0; l <= delColumn.Count - 1; l++)
                {
                    //削除処理でのエラーはハンドリングしない 
                    try
                    {
                        sheetCopy.Columns.Remove(delColumn[l], 1);
                    }
                    catch
                    { }
                }

                //列を削除後結合行を復活 
                foreach (int columnSpanRow in columnSpanRowList)
                {
                    //行を全結合 
                    sheetCopy.Cells[columnSpanRow, 0].ColumnSpan = sheetCopy.ColumnCount;
                }
            }

            //罫線などのシート情報を設定する  
            setSheetInfo(sheetCopy,sheet);

            #region 子明細設定(存在しないのでコメントアウト)
            //子明細情報を出力シートに設定(現在は存在しないためコメントアウト)
            for (int spreadRow = sheet.RowCount - 1; spreadRow > -1; spreadRow--)
            {
                ////子スプレッド表示フラグ 
                //bool expandFlg = false;

                //行が展開できる場合 
                if (sheet.GetRowExpandable(spreadRow))
                {
                    //子ビューが表示されている場合 
                    if (sheet.IsRowExpanded(spreadRow))
                    {
                        //子ビューのシートが表示状態の場合、そのシートを取得 
                        SheetView childView = sheet.GetChildView(spreadRow, 0);

                        //取得できたシート情報を指定行の下に行ごと追加する 
                        addChildSheetViewRows(sheetCopy, spreadRow, childView);
                    }

                    ////子スプレッドが非表示の場合 
                    //if (!sheet.IsRowExpanded(spreadRow))
                    //{
                    //    //子スプレッドフラグをtrue
                    //    expandFlg = true;

                    //    //子シートを表示する 
                    //    sheet.ExpandRow(spreadRow, true);
                    //}

                    ////子明細のシートが表示状態の場合子明細の子供のシートを取得 
                    //SheetView childView = sheet.GetChildView(spreadRow,0);

                    ////取得できた子明細のシート情報を指定行の下に行ごと追加する 
                    //addChildSheetViewRows(sheetCopy, spreadRow, childView);

                    ////子スプレッドフラグをtrueにした場合 
                    //if (expandFlg)
                    //{
                    //    //子シートを非表示に戻しておく 
                    //    sheet.ExpandRow(spreadRow, false);
                    //}


                }
            }
            #endregion

            //---------------------
            // 印刷情報を設定する 
            //---------------------
            setPrintInfo(sheetCopy);

            //固定列を設定 
            sheetCopy.FrozenColumnCount = 0;

            return sheetCopy;
        }

        /// <summary>
        /// シート情報を設定する 
        /// </summary>
        /// <param name="sheetCopy">SheetView</param>
        /// <param name="sheet">SheetView</param>
        private void setSheetInfo(SheetView sheetCopy, SheetView sheet)
        {
            // Color.Black2箇所とColor.LightYellowは定数化 
            // 列ヘッダの境界線を設定 
            sheetCopy.ColumnHeader.Cells[0, 0, sheetCopy.ColumnHeader.Rows.Count - 1, sheetCopy.ColumnCount - 1].Border
                                        = new LineBorder(KKHSystemColor.AcomExcelOutPutSpreadColor.Border, 1, true, true, true, true);
            sheetCopy.ColumnHeader.Cells[0, 0, sheetCopy.ColumnHeader.Rows.Count - 1, sheetCopy.ColumnCount - 1].BackColor
                                        = KKHSystemColor.AcomExcelOutPutSpreadColor.Header;

            // データ行の罫線を設定 
            sheetCopy.Cells[0, 0, sheetCopy.RowCount - 1, sheetCopy.ColumnCount - 1].Border
                                        = new LineBorder(KKHSystemColor.AcomExcelOutPutSpreadColor.Border, 1, true, true, true, true);

            // シート保護の解除 
            sheetCopy.Protect = false;
        }

        #region 子明細設定(存在しないのでコメントアウト)
        /// <summary>
        /// 子明細シートの内容をスプレットの指定行の下に行ごと追加する
        /// </summary>
        /// <param name="sheetCopy">子明細の情報が追加されるシート</param>
        /// <param name="spreadRow">指定行</param>
        /// <param name="childView">追加される子明細のシート</param>
        private void addChildSheetViewRows(SheetView sheetCopy, int spreadRow, SheetView childView)
        {
            //子明細ヘッダー用の行を一行追加
            int dispRow = spreadRow + 1;
            sheetCopy.Rows.Add(dispRow, 1);

            //カラムヘッダーを描写 
            int dispCol = 1;
            for (int col = 0; col < childView.ColumnHeader.Columns.Count - 1; col++)
            {
                if (childView.ColumnHeader.Columns[col].Visible == true)
                {
                    if (sheetCopy.ColumnCount <= dispCol)
                    {
                        sheetCopy.Columns.Add(dispCol, 1);
                    }
                    //表示列のみ設定 
                    //sheetCopy.Cells[dispRow, dispCol].BackColor = KKHSystemColor.ExcelOutPutSpreadColor.ChildHeader;
                    sheetCopy.Cells[dispRow, dispCol].BackColor = KKHSystemColor.AcomExcelOutPutSpreadColor.Header;
                    sheetCopy.Cells[dispRow, dispCol].ForeColor = childView.ColumnHeader.Cells[0, col].ForeColor;
                    sheetCopy.Cells[dispRow, dispCol].HorizontalAlignment = childView.ColumnHeader.Cells[0, col].HorizontalAlignment;
                    sheetCopy.Cells[dispRow, dispCol].VerticalAlignment = childView.ColumnHeader.Cells[0, col].VerticalAlignment;
                    sheetCopy.Cells[dispRow, dispCol].Font = childView.ColumnHeader.Cells[0, col].Font; //JSE ADD CNP対応 2012/07/12
                    //セルの型をテキストに設定 
                    sheetCopy.Cells[dispRow, dispCol].CellType = new TextCellType();
                    sheetCopy.Cells[dispRow, dispCol].Text = KKHUtility.ToString(childView.ColumnHeader.Cells[0, col].Value);

                    //列幅を設定 
                    if (sheetCopy.Columns[dispCol].Width < childView.ColumnHeader.Columns[col].Width)
                    {
                        //設定されている列幅を出力 
                        sheetCopy.Columns[dispCol].Width = childView.ColumnHeader.Columns[col].Width;
                    }

                    dispCol++;
                }
            }


            //Excelへ出力するスプレットのセルタイプを事前にインスタンス化 
            //（2009/04/02 ISID-it T.Takei Excel出力のレスポンス改善のため） 
            //日付型のセル 
            DateTimeCellType dateTimeCell = new DateTimeCellType();
            dateTimeCell.DateTimeFormat = DateTimeFormat.ShortDate;
            //テキスト型のセル 
            TextCellType textCell = new TextCellType();

            //ヘッダー以外を描写 
            for (int insertRow = 0; insertRow < childView.RowCount; insertRow++)
            {
                //子明細のデータを追加する行をスプレットに追加 
                dispRow = spreadRow + 1 + insertRow + 1;
                sheetCopy.Rows.Add(dispRow, 1);

                dispCol = 1;
                for (int col = 0; col < childView.ColumnHeader.Columns.Count - 1; col++)
                {
                    if (childView.ColumnHeader.Columns[col].Visible == true)
                    {
                        //セルの内容を描写 
                        sheetCopy.Cells[dispRow, dispCol].BackColor = childView.Cells[insertRow, col].BackColor;
                        sheetCopy.Cells[dispRow, dispCol].ForeColor = childView.Cells[insertRow, col].ForeColor;
                        sheetCopy.Cells[dispRow, dispCol].HorizontalAlignment = childView.Cells[insertRow, col].HorizontalAlignment;
                        sheetCopy.Cells[dispRow, dispCol].VerticalAlignment = childView.Cells[insertRow, col].VerticalAlignment;
                        sheetCopy.Cells[dispRow, dispCol].CellType = new TextCellType();

                        String dispTxt = string.Empty;
                        Cell cell = childView.Cells[insertRow, col];

                        //セルタイプごとの表示内容の補正 
                        if (cell.CellType is CheckBoxCellType
                             || childView.Columns[col].CellType is CheckBoxCellType)
                        {
                            //チェックボックスタイプのセル 
                            if (cell.Text.Equals("True"))
                            {
                                dispTxt = "☑";
                            }
                            else
                            {
                                dispTxt = "";
                            }

                            //スプレットのセル型を変更 
                            sheetCopy.Cells[dispRow, dispCol].CellType = textCell;
                            sheetCopy.Cells[dispRow, dispCol].Text = dispTxt;

                            //チェックボックス型のセルの場合は表示位置をセルの中心に設定 
                            //（2009/04/02 ISID-it T.TAKEI ADD） 
                            sheetCopy.Cells[dispRow, dispCol].HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (cell.CellType is ComboBoxCellType
                            || childView.Columns[col].CellType is ComboBoxCellType)
                        {
                            //コンボボックスタイプのセル 
                            ComboBoxCellType comboBoxCell = (ComboBoxCellType)cell.CellType;

                            if (KKHUtility.IsNull(comboBoxCell))
                            {
                                comboBoxCell = (ComboBoxCellType)childView.Columns[col].CellType;
                            }

                            if (comboBoxCell.EditorValue.Equals(EditorValue.ItemData))
                            {
                                comboBoxCell.EditorValue = EditorValue.String;
                                dispTxt = KKHUtility.ToString(cell.Text);
                                comboBoxCell.EditorValue = EditorValue.ItemData;
                            }
                            else if (comboBoxCell.EditorValue.Equals(EditorValue.Index))
                            {
                                comboBoxCell.EditorValue = EditorValue.String;
                                dispTxt = KKHUtility.ToString(cell.Text);
                                comboBoxCell.EditorValue = EditorValue.Index;
                            }
                            else
                            {
                                dispTxt = KKHUtility.ToString(cell.Text);
                            }

                            //スプレットのセル型を変更 
                            sheetCopy.Cells[dispRow, dispCol].CellType = textCell;
                            sheetCopy.Cells[dispRow, dispCol].Text = cell.Text;
                        }
                        else if (cell.CellType is MaskCellType
                                    || childView.Columns[col].CellType is MaskCellType)
                        {
                            if (isDateCell(cell.Text))
                            {
                                sheetCopy.Cells[dispRow, dispCol].CellType = dateTimeCell;
                                sheetCopy.Cells[dispRow, dispCol].Value = KKHUtility.StringCnvDateTime(cell.Text);
                                sheetCopy.Cells[dispRow, dispCol].HorizontalAlignment = CellHorizontalAlignment.Center;
                            }
                            else
                            {
                                //マスク型のセル 
                                sheetCopy.Cells[dispRow, dispCol].CellType = textCell;
                                sheetCopy.Cells[dispRow, dispCol].Text = cell.Text;
                            }
                        }
                        else if (cell.CellType is ButtonCellType
                                         || childView.Columns[col].CellType is ButtonCellType)
                        {
                            //ボタンタイプのセル 
                            ButtonCellType buttonCell = (ButtonCellType)cell.CellType;
                            if (KKHUtility.IsNull(buttonCell))
                            {
                                buttonCell = (ButtonCellType)childView.Columns[col].CellType;
                            }

                            if (!KKHUtility.IsNull(buttonCell))
                            {
                                dispTxt = KKHUtility.ToString(buttonCell.Text);
                            }

                            //スプレットのセル型を変更 
                            sheetCopy.Cells[dispRow, dispCol].CellType = textCell;
                            sheetCopy.Cells[dispRow, dispCol].Text = dispTxt;
                        }
                        else
                        {
                            if (isDateCell(cell.Text))
                            {
                                sheetCopy.Cells[dispRow, dispCol].CellType = dateTimeCell;
                                sheetCopy.Cells[dispRow, dispCol].Value = KKHUtility.StringCnvDateTime(cell.Text);
                                sheetCopy.Cells[dispRow, dispCol].HorizontalAlignment = CellHorizontalAlignment.Center;
                            }
                            else
                            {
                                sheetCopy.Cells[dispRow, dispCol].CellType = childView.Columns[col].CellType;
                                sheetCopy.Cells[dispRow, dispCol].Text = cell.Text;
                            }
                        }

                        dispCol++;
                    }
                }
            }

            //罫線を描写する 
            sheetCopy.Cells[spreadRow + 1, 1, dispRow, dispCol - 1].Border
                                        = new LineBorder(KKHSystemColor.AcomExcelOutPutSpreadColor.Border, 1,
                                                            true, true, true, true);

        }

        #endregion

        /// <summary>
        /// 印刷情報を設定する 
        /// </summary>
        /// <param name="sheetCopy">SheetView</param>
        private void setPrintInfo(SheetView sheetCopy)
        {
            //---------------------
            // 印刷情報を設定する 
            //---------------------
            // グリッド線を印刷するかどうか 
            sheetCopy.PrintInfo.ShowGrid = true;
            // 印刷時のページの向き 
            sheetCopy.PrintInfo.Orientation = PrintOrientation.Landscape;
            // 余白 
            sheetCopy.PrintInfo.Margin.Top = 95;
            sheetCopy.PrintInfo.Margin.Bottom = 95;
            sheetCopy.PrintInfo.Margin.Left = 75;
            sheetCopy.PrintInfo.Margin.Right = 75;
            sheetCopy.PrintInfo.Margin.Header = 50;
            sheetCopy.PrintInfo.Margin.Footer = 50;
            // コントロール全体の周囲の境界線を印刷するかどうか 
            sheetCopy.PrintInfo.ShowBorder = true;
            // 画面に表示されている通りにカラー印刷するかどうか 
            sheetCopy.PrintInfo.ShowColor = true;
            // 列ヘッダを印刷するかどうか 
            sheetCopy.PrintInfo.ShowColumnHeaders = false;
            // 行ヘッダを印刷するかどうか 
            sheetCopy.PrintInfo.ShowRowHeaders = false;
            // 印刷する前に印刷ダイアログを表示するかどうか 
            sheetCopy.PrintInfo.ShowPrintDialog = true;
            // 印刷するときに使用する拡大／縮小率 
            sheetCopy.PrintInfo.ZoomFactor = 1.0F;
        }

        // 指定されたシートへExcel出力情報を付加する  
        /// <summary>
        /// 指定されたシートへExcel出力情報を付加する  
        /// （2009/02/23 ISID-IT T.TAKEI ADD） 
        /// </summary>
        /// <param name="shView"></param>
        private void addOutPutExcelInfo(SheetView shView)
        {
            if (KKHUtility.IsNull(_outPutExcelInfo))
            {
                //出力Excel情報が設定されていない場合は処理を行わない 
                return;
            }

            if (_outPutExcelInfo.Count.Equals(0))
            {
                //出力Excel情報が設定されていない場合は処理を行わない 
                return;
            }

            //現在の行数を取得 
            int nowRowsCount = shView.Rows.Count;
            //出力情報を追加する列をシートへ追加 
            shView.Rows.Add(shView.Rows.Count, _outPutExcelInfo.Count + 1);

            //出力情報を設定 
            foreach (string outPutString in _outPutExcelInfo)
            {
                shView.Cells[nowRowsCount + 1, 0].CellType = new TextCellType();
                shView.Cells[nowRowsCount + 1, 0].Text = outPutString;
                shView.Cells[nowRowsCount + 1, 0].HorizontalAlignment = CellHorizontalAlignment.Left;

                nowRowsCount += 1;
            }
        }

        /// <summary>
        /// セルのテキストがYYYY/MM/DD形式か否かを確認 
        /// </summary>
        /// <param name="cellText"></param>
        /// <returns></returns>
        private bool isDateCell(String cellText)
        {
            if (!cellText.Length.Equals(10))
            {
                //10文字で無ければ処理終了 
                return false;
            }

            if (!(cellText.Substring(4, 1).Equals("/") && cellText.Substring(7, 1).Equals("/")))
            {
                //4文字目、7文字目が/でない場合は処理終了 
                return false;
            }

            //日付のチェック（軽量版でチェック） 
            if (!DateCheck(cellText))
            {
                return false;
            }

            //日付のチェック 
            if (!KKHUtility.StringCnvDateTime(cellText).Equals(DateTime.MinValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 日付のチェック（軽量版） 
        /// </summary>
        /// <param name="cellText"></param>
        /// <returns></returns>
        private bool DateCheck(String cellText)
        {
            int[] intMpD = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; //各月の最大日数を保持 
            string[] strYMD = cellText.Split('/');  //YYYY,MM,DDで分割 
            int year = 0;
            int month = 0;
            int day = 0;

            try
            {
                if (!(new Regex(@"^[0-9]{4}/[0-9]{2}/[0-9]{2}$").IsMatch(cellText))) { return false; }

                if (!strYMD.Length.Equals(3)) { return false; };

                year = Convert.ToInt32(strYMD[0]);
                month = Convert.ToInt32(strYMD[1]);
                day = Convert.ToInt32(strYMD[2]);

                if (month < 1 || 12 < month) { return false; } /*月のチェック*/
                if (day < 1 || intMpD[month] < day) { return false; } /*日のチェック*/
                if (month != 2) { return true; } /*閏年チェック*/
                if (day < 29) { return true; } /*閏年チェック*/
                if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0))) { return true; } /*閏年チェック*/

                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region IDisposable メンバ


        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this._spread = null;
        }

        #endregion
    }
}

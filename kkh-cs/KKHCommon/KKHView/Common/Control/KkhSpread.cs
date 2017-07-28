using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility;
using System.Collections;
using FarPoint.Win.Spread.CellType;

namespace Isid.KKH.Common.KKHView.Common.Control
{

    /// <summary>
    /// Kkhスプレッドコントロール 
    /// 　通常のスプレッドとの変更点 
    /// 　①シートコーナーにエクセルを行うカスタムセルを実装 
    /// 　②Ctrl + Vでの貼り付けを値のみの貼り付けに変更 
    /// 　③貼り付けの対象にヘッダを含まないように変更(TODO:途中でClipboardOptionsを変更した場合に反映されなくなる問題がある) 
    /// 　④自動ソートが「昇順→降順→未ソート」の順に切りかわる(TODO：DataModelにまでソートが反映されていると未ソートへは戻らない)
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2011/12/13</description>
    ///       <description>Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KkhSpread : FpSpread
    {
        //初期表示時のイベントかどうかを判定する為のフラグ 
        bool firstFlag = true;

        #region プロパティ
        private bool useExcelDump = true;
        /// <summary>
        /// Excelダンプ出力機能の使用可否 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool UseExcelDump
        {
            get { return useExcelDump; }
            set { useExcelDump = value; }
        }

        private string[] _outPutExcelInfo;
        /// <summary>
        /// 欄外に表示する文字列 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        [DefaultValue(null)]
        public string[] OutPutExcelInfo
        {
            get { return _outPutExcelInfo; }
            set { _outPutExcelInfo = value; }
        }

        private string _excelFileName = "";
        /// <summary>
        /// 出力するExcelファイル名のデフォルト値 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        [DefaultValue("")]
        public string ExcelFileName
        {
            get { return _excelFileName; }
            set { _excelFileName = value; }
        }

        private string _initialDirectory = "";
        /// <summary>
        /// 出力するディレクトリのデフォルト値 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        [DefaultValue("")]
        public string InitialDirectory
        {
            get { return _initialDirectory; }
            set { _initialDirectory = value; }
        }


        /// <summary>
        /// カスタムソートが有効かどうか
        /// </summary>
        protected Boolean _enableCustomSorting = false;

        /// <summary>
        /// カスタムソートが有効かどうか
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        [DefaultValue("false")]
        public Boolean EnableCustomSorting
        {
            set { _enableCustomSorting = value; }
            get { return _enableCustomSorting; }
        }

        #endregion プロパティ

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        public KkhSpread()
            : base()
        {
            //入力マップ初期設定 
            InitForInputMap();

            //イベントの設定 
            this.AutoSortingColumn += new FarPoint.Win.Spread.AutoSortingColumnEventHandler(this.KKHSpread_AutoSortingColumn);
            this.AutoSortedColumn += new FarPoint.Win.Spread.AutoSortedColumnEventHandler(this.KKHSpread_AutoSortedColumn);
        }

        #endregion コンストラクタ

        // とりあえず柄だけ定義。 
        // 内部・外部公開ﾒｿｯﾄﾞ及びﾌﾟﾛﾊﾟﾃｨ必要に応じ、随時記述してください。 
        // 尚、ｶｽﾀﾑｺﾝﾄﾛｰﾙ等の共通系は修正等逐次連携しましょう。 

        #region キー操作関連
        /// <summary>
        /// 入力マップ初期設定 
        /// </summary>
        private void InitForInputMap()
        {
            //*************************************
            //インプットマップの設定 
            //*************************************
            InputMap im = new InputMap();

            //非編集セルでのInputMap 
            im = this.GetInputMap(InputMapMode.WhenFocused);
            //貼り付けの対象は「値のみ」 とする 
            im.Put(new Keystroke(Keys.V, Keys.Control), SpreadActions.ClipboardPasteValues);
        }
        #endregion キー操作関連

        #region 自動ソート機能拡張

        /// <summary>
        /// カスタムソートクラス
        /// </summary>
        protected class CustomComparer : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                int retval = 0;

                if (( a == null ) && ( b == null ))
                {
                    return 0;
                }
                else if (a == null)
                {
                    retval = 1;
                }
                else if (b == null)
                {
                    retval = -1;
                }
                else
                {
                    if
                    (
                        ( KKHUtility.KKHUtility.IsNumeric(a.ToString()) ) &&
                        ( KKHUtility.KKHUtility.IsNumeric(b.ToString()) )
                    )
                    {
                        Decimal va = KKHUtility.KKHUtility.DecParse(a.ToString());

                        Decimal vb = KKHUtility.KKHUtility.DecParse(b.ToString());

                        if (va == vb)
                        {
                            retval = 0;
                        }
                        else if (va > vb)
                        {
                            retval = 1;
                        }
                        else
                        {
                            retval = -1;
                        }
                    }
                    else
                    {
                        retval = String.Compare(a.ToString(), b.ToString());
                    }
                }

                return retval;
            }
        }
        /// <summary>
        /// 自動ソート実施前のソートインジケータ 
        /// </summary>
        private SortIndicator bfSortIndicator = SortIndicator.None;

        /// <summary>
        /// 自動ソート実行中イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KKHSpread_AutoSortingColumn(object sender, AutoSortingColumnEventArgs e)
        {
            //自動ソート実施前のソートインジケータを保持する 
            bfSortIndicator = e.Sheet.Columns[e.Column].SortIndicator;
        }

        /// <summary>
        /// 自動ソート実行後イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KKHSpread_AutoSortedColumn(object sender, AutoSortedColumnEventArgs e)
        {
            if (bfSortIndicator == FarPoint.Win.Spread.Model.SortIndicator.None)
            {
                //昇順 
                if (( EnableCustomSorting ) && ( e.Sheet.Columns[e.Column].CellType is NumberCellType ))
                {
                    e.Sheet.SortRows(e.Column, true, e.ShowIndicator, new CustomComparer());
                }
                else
                {
                    e.Sheet.SortRows(e.Column, true, e.ShowIndicator);
                }

                e.Sheet.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Ascending;
            }
            else if (bfSortIndicator == FarPoint.Win.Spread.Model.SortIndicator.Ascending)
            {
                //降順 
                if (( EnableCustomSorting ) && ( e.Sheet.Columns[e.Column].CellType is NumberCellType ))
                {
                    e.Sheet.SortRows(e.Column, false, e.ShowIndicator, new CustomComparer());
                }
                else
                {
                    e.Sheet.SortRows(e.Column, false, e.ShowIndicator);
                }

                e.Sheet.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Descending;
            }
            else
            {
                //初期状態 
                e.Sheet.Models.ResetViewRowIndexes();
                e.Sheet.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
                //e.Sheet.Columns[e.Column].ResetSortIndicator();
            }
        }
        #endregion 自動ソート機能拡張

        #region クリップボード操作関連 
        private object clipboardOptions = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public override void OnClipboardChanging(EventArgs e)
        {
            //ヘッダを貼り付けの対象外とする為の対応(コピー&切り取りの場合はClipboardOptionsを戻す) 
            if (clipboardOptions == null) { clipboardOptions = this.ClipboardOptions; }//
            this.ClipboardOptions = (ClipboardOptions)clipboardOptions;

            base.OnClipboardChanging(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClipboardPasting(ClipboardPastingEventArgs e)
        {
            //ヘッダを貼り付けの対象外とする為の対応(貼り付けの場合はClipboardOptionsをNoHeadersにする) 
            if (clipboardOptions == null) { clipboardOptions = this.ClipboardOptions; }
            this.ClipboardOptions = ClipboardOptions.NoHeaders;

            base.OnClipboardPasting(e);
        }
        #endregion クリップボード操作関連

        #region Excel出力機能関連 

        /// <summary>
        /// 
        /// </summary>
        private void ExcelOut()
        {
            if (this.ActiveSheet.Rows.Count == 0)
            {
                //帳票出力不可メッセージ表示 
                //MessageBox.Show("帳票作成対象データが表示されていません", "作成対象なし", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0061, null, "作成対象なし", MessageBoxButtons.OK);
                return;
            }

            // 出力パス 
            string excelOutPut = string.Empty;

            //SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            //ファイル名を指定 
            if (KKHUtility.KKHUtility.ToString(_excelFileName) == "")
            {
                sfd.FileName = this.Name + "_" + DateTime.Now.ToString("yyyyMMdd") + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;
                //sfd.FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + this.Name + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;
            }
            else
            {
                sfd.FileName = _excelFileName + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;
            }

            //初期表示フォルダを指定 
            if (_initialDirectory == "")
            {
                sfd.InitialDirectory = @"C:\work\";
            }
            else
            {
                sfd.InitialDirectory = _initialDirectory;
            }

            //[ファイルの種類]を指定 
            sfd.Filter = "EXCELﾌｧｲﾙ|*" + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;

            //「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 2;

            //タイトルを設定 
            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に復元するようにする 
            sfd.RestoreDirectory = true;

            //ダイアログを表示する 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //文字列末の".xls"を削除する 
                sfd.FileName = sfd.FileName.Substring(0, sfd.FileName.Length - KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT.Length);

                //OKボタンがクリックされたとき 　
                excelOutPut = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            else
            {
                return;
            }

            using (KKHSpreadOutPutExcelHandler spreadOutPutExcelHandler
                = new KKHSpreadOutPutExcelHandler(this, sfd.FileName))
            {
                //spreadOutPutExcelHandler.OutPutExcel();
                List<string> outPutExcelInfo = new List<string>();
                if (_outPutExcelInfo != null)
                {
                    foreach (string str in _outPutExcelInfo)
                    {
                        outPutExcelInfo.Add(str);
                    }
                }
                spreadOutPutExcelHandler.OutPutExcel(outPutExcelInfo);
                spreadOutPutExcelHandler.ProcessStart();
            }
        }
        #endregion Excel出力機能関連

        #region イベント(On～)のoverride
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //デザイナには反映しない 
            if (DesignMode == false)
            {
                //最初の表示の際にのみ実施 
                if (firstFlag == true)
                {
                    //エクセル出力機能を使用 
                    if (useExcelDump == true)
                    {
                        foreach (SheetView sheet in this.Sheets)
                        {
                            ExcelDumpCellType cellType = new ExcelDumpCellType();
                            sheet.SheetCornerStyle.CellType = cellType;
                            //シートコーナーの縦横のサイズを画像が表示できるサイズに強制変更========================================================================= 
                            if (sheet.ColumnHeader.Rows.Count > 0)
                            {
                                float colHeaderHeight = 0F;
                                foreach (Row colHeaderRow in sheet.ColumnHeader.Rows)
                                {
                                    colHeaderHeight = colHeaderHeight + colHeaderRow.Height;
                                }
                                if (colHeaderHeight < cellType.BackgroundImage.Image.Height)
                                {
                                    sheet.ColumnHeader.Rows[0].Height = sheet.ColumnHeader.Rows[0].Height + (cellType.BackgroundImage.Image.Height - colHeaderHeight);
                                }
                            }

                            if (sheet.RowHeader.Columns.Count > 0)
                            {
                                float rowHeaderWidth = 0F;
                                foreach (Column rowHeaderCol in sheet.RowHeader.Columns)
                                {
                                    rowHeaderWidth = rowHeaderWidth + rowHeaderCol.Width;
                                }
                                if (rowHeaderWidth < cellType.BackgroundImage.Image.Height)
                                {
                                    sheet.RowHeader.Columns[0].Width = sheet.RowHeader.Columns[0].Width + (cellType.BackgroundImage.Image.Width - rowHeaderWidth);
                                }
                            }
                            //========================================================================================================================================

                        }
                    }
                    firstFlag = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellClick(CellClickEventArgs e)
        {
            if (useExcelDump == true)
            {
                object clickCellType;
                if (e.RowHeader == true && e.ColumnHeader == true)
                {
                    clickCellType = e.View.GetSheetView().SheetCornerStyle.CellType;
                }
                else if (e.RowHeader == true)
                {
                    clickCellType = e.View.GetSheetView().RowHeader.Cells[e.Row, e.Column].CellType;
                }
                else if (e.ColumnHeader == true)
                {
                    clickCellType = e.View.GetSheetView().ColumnHeader.Cells[e.Row, e.Column].CellType;
                }
                else
                {
                    clickCellType = e.View.GetSheetView().Cells[e.Row, e.Column].CellType;
                }
                //クリックされたセルがExcel出力用のセルの場合 
                if (clickCellType is ExcelDumpCellType)
                {
                    ExcelOut();
                    e.Cancel = true;
                    return;//エクセル出力処理後は処理を終了する 
                }
            }
            base.OnCellClick(e);
        }
        #endregion イベント(On～)のoverride

        #region カスタムセルクラス 
        //【カスタムセルクラスの記述】 

        /// <summary>
        /// 
        /// </summary>
        private class ExcelDumpCellType : FarPoint.Win.Spread.CellType.TextCellType
        {
            #region プロパティ
            private Image sheetCornerBackgroundImage = (System.Drawing.Image)(Properties.Resources.Excel);
            /// <summary>
            /// セルの背景に表示する画像 
            /// </summary>
            private Image SheetCornerBackgroundImage
            {
                get { return sheetCornerBackgroundImage; }
                set 
                { 
                    sheetCornerBackgroundImage = value;
                    SetImage();
                }
            }
            #endregion プロパティ

            #region コンストラクタ
            public ExcelDumpCellType()
            {
                SetImage();
            }
            #endregion コンストラクタ

            /// <summary>
            /// 背景イメージを設定する 
            /// </summary>
            private void SetImage()
            {
                FarPoint.Win.Picture picture1 = new FarPoint.Win.Picture();
                picture1.Image = SheetCornerBackgroundImage;
                picture1.TransparencyColor = System.Drawing.Color.Empty;
                picture1.TransparencyTolerance = 0;
                picture1.AlignHorz = FarPoint.Win.HorizontalAlignment.Center;
                picture1.AlignVert = FarPoint.Win.VerticalAlignment.Center;

                this.BackgroundImage = picture1;
            }
        }
        #endregion カスタムセルクラス

    }
}

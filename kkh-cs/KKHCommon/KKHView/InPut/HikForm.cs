using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using System.IO;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.InPut;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using FarPoint.Win.Spread;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Common.KKHView.InPut
{
    public partial class HikForm : KKHForm
    {
        #region メンバ定数・変数
        /// <summary>
        /// フィルタ(IrYyMm)
        /// </summary>
        private static readonly string FILTER_IRYYMM = "IrYyMm = ";

        /// <summary>
        /// フィルタ(Flg)
        /// </summary>
        private static readonly string FILTER_SAISINFLG1 = "SaisinFlg = '1'";

        /// <summary>
        /// フィルタ(並び順)
        /// </summary>
        private static readonly string FILTER_ORDER_RIREKI = "IRBAN, IRROWBAN, RIRENO DESC";

        /// <summary>
        /// SPREADカラム番号[履歴管理番号](1)
        /// </summary>
        private const int SPD_COLUMUNS_RIRENO = 1;

        /// <summary>
        /// SPREADカラム番号[サイズコード](7)
        /// </summary>
        private const int SPD_COLUMUNS_SIZECD = 7;

        /// <summary>
        /// SPREADカラム番号[形態区分コード](14)
        /// </summary>
        private const int SPD_COLUMUNS_KEITAICD = 14;

        /// <summary>
        /// SPREADカラム番号[交通掲載コード](28)
        /// </summary>
        private const int SPD_COLUMUNS_KOUTUKEICD = 28;

        /// <summary>
        /// SPREADカラム番号[最新フラグ](53)
        /// </summary>
        private const int SPD_COLUMUNS_SAISINFLG = 53;

        /// <summary>
        /// 発注取込用データ(全件)
        /// </summary>
        InPutHik _dsHikTrkm_All;

        /// <summary>
        /// 発注取込用データ(スプレッド表示中のみ)
        /// </summary>
        InPutHik _dsHikTrkm_SpdList;
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HikForm()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ

        #region イベント
        /// <summary>
        /// 「画面」が初期表示されたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HikForm_Shown(object sender, EventArgs e)
        {
            // 発注取込用データセットと一覧表示データセットの初期セット
            _dsHikTrkm_All = new InPutHik();
            _dsHikTrkm_SpdList = new InPutHik();

            // コンボボックスの初期値セット
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(int));
            SybtNameTable.Rows.Add("雑誌", 22);
            SybtNameTable.Rows.Add("電波", 11);
            SybtNameTable.Rows.Add("交通", 31);

            cbxSybtName.DataSource = SybtNameTable;
            cbxSybtName.DisplayMember = "Display";
            cbxSybtName.ValueMember = "Value";
        }

        /// <summary>
        /// 「読込ファイル一覧」ボタンコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            // 
        }

        /// <summary>
        /// 「帳票作成」ボタンコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelOut_Click(object sender, EventArgs e)
        {
            if (_dsHikTrkm_All.InPutHikData.Count == 0)
            {
                // 一覧が0件の場合は処理終了                return;
            }

            // 出力パス
            string excelOutPut = string.Empty;

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //ファイル名を指定
            sfd.FileName = "発注データ取込.xls";

            //初期表示フォルダを指定
            sfd.InitialDirectory = @"C:\work\";

            //[ファイルの種類]を指定
            sfd.Filter = "EXCELﾌｧｲﾙ|*.xls";

            //「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 2;

            //タイトルを設定
            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に復元するようにする
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                excelOutPut = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            else
            {
                return;
            }

            using (KKHSpreadOutPutExcelHandler spreadOutPutExcelHandler
                = new KKHSpreadOutPutExcelHandler(this.spdHikList, sfd.FileName))
            {
                spreadOutPutExcelHandler.OutPutExcel();
                spreadOutPutExcelHandler.ProcessStart();
            }
        }

        /// <summary>
        /// 「終了」ボタンコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 「表示」ボタンコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 指定年月日の確認と設定
            string strCheckYyMm = tbxYyMm.Text;
            bool isCheckYyMm = false;

            // 指定年月確認
            if (strCheckYyMm.Length == 6)
            {
                strCheckYyMm = strCheckYyMm.Insert(4, "/");
                DateTime dtimeCheckYyMm;

                // 年月正常確認
                if (DateTime.TryParse(strCheckYyMm, out dtimeCheckYyMm) == true)
                {
                    // 指定年月正常
                    isCheckYyMm = true;
                }
            }

            if (isCheckYyMm == false)
            {
                // 指定年月エラー
                return;
            }

            // 種別の設定
            string strSybt = cbxSybtName.SelectedValue.ToString();

            // パラメータの設定
            InPutProcessController inPutProcessController = InPutProcessController.GetInstance();
            FindHikByCondServiceResult result
                = inPutProcessController.FindHikByCond("10", "20", "30", strSybt, tbxYyMm.Text);

            // 取得データを全件DataSetにセット
            _dsHikTrkm_All.Clear();
            _dsHikTrkm_All.Merge(result.HikDataSet);

            // スプレッド更新
            if (rbnSaiSin.Checked == true)
            {
                UpdateSpd_SaiSin();
            }
            else
            {
                UpdateSpd_Rireki();
            }
        }

        /// <summary>
        /// 「種別」コンボボックスのリストが閉じられた時に発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxBaiName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 列表示変更

            // スプレッドのクリア
            UpdateSpd_Design(new InPutHik());
        }

        /// <summary>
        /// 「最新」ラジオコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnSaiSin_CheckedChanged(object sender, EventArgs e)
        {
            // チェック確認
            if (rbnSaiSin.Checked == false)
            {
                return;
            }

            // 一覧件数確認
            if (_dsHikTrkm_SpdList.InPutHikData.Rows.Count == 0)
            {
                return;
            }

            // 「最新」のみを表示
            UpdateSpd_SaiSin();
        }

        /// <summary>
        /// 「履歴」ラジオコントロールがクリックされたときに発生します        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnRireki_CheckedChanged(object sender, EventArgs e)
        {
            // チェック確認
            if (rbnRireki.Checked == false)
            {
                return;
            }

            // 一覧件数確認
            if (_dsHikTrkm_SpdList.InPutHikData.Rows.Count == 0)
            {
                return;
            }

            // スプレッドの更新(履歴)
            UpdateSpd_Rireki();
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// スプレッド更新(最新)
        /// </summary>
        private void UpdateSpd_SaiSin()
        {
            // 一覧のフィルタ実行
            string strFilter = FILTER_SAISINFLG1;
            if (cbxSybtName.SelectedValue.ToString() == "11")
            {
                // 電波の場合は、当月のみ対象
                strFilter += " AND " + FILTER_IRYYMM + "'" + tbxYyMm.Text + "'";
            }
            InPutHik dsHikTrkm_Filter = new InPutHik();
            DataRow[] selectedHikListRows = _dsHikTrkm_All.InPutHikData.Select(strFilter);
            dsHikTrkm_Filter.Merge(selectedHikListRows);

            // スプレッドの更新
            UpdateSpd_Design(dsHikTrkm_Filter);
        }

        /// <summary>
        /// スプレッド更新(履歴)
        /// </summary>
        private void UpdateSpd_Rireki()
        {
            // 履歴の場合は並び順を変更
            InPutHik dsHikTrkm_Filter = new InPutHik();
            DataRow[] selectedHikListRows = _dsHikTrkm_All.InPutHikData.Select("", FILTER_ORDER_RIREKI);
            dsHikTrkm_Filter.Merge(selectedHikListRows);

            // スプレッドの更新(一覧全件表示)
            UpdateSpd_Design(dsHikTrkm_Filter);
        }

        /// <summary>
        /// スプレッドの表示更新
        /// </summary>
        /// <param name="dsInPutHik"></param>
        private void UpdateSpd_Design(InPutHik dsInPutHik)
        {
            _dsHikTrkm_SpdList.Clear();
            _dsHikTrkm_SpdList.Merge(dsInPutHik);
            _dsHikTrkm_All.AcceptChanges();

            // バインド
            spdHikTrkmList_Sheet1.DataSource = _dsHikTrkm_SpdList;
            spdHikTrkmList_Sheet1.DataMember = _dsHikTrkm_SpdList.InPutHikData.TableName;

            // スプレッドのタイトル更新
            UpdateSpd_TitleList();

            if (rbnRireki.Checked == true)
            {
                // 履歴の場合は、背景色を変更
                UpdateSpd_Design_RirekiBackColor();
            }
            
        }

        /// <summary>
        /// スプレッドのタイトル更新
        /// </summary>
        private void UpdateSpd_TitleList()
        {
            string strSelectSybt = cbxSybtName.SelectedValue.ToString();

            if (strSelectSybt == "22")
            {
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_SIZECD].Visible = true;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KEITAICD].Visible = false;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KOUTUKEICD].Visible = false;
            }

            if (strSelectSybt == "11")
            {
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_SIZECD].Visible = false;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KEITAICD].Visible = true;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KOUTUKEICD].Visible = false;
            }

            if (strSelectSybt == "31")
            {
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_SIZECD].Visible = false;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KEITAICD].Visible = false;
                spdHikTrkmList_Sheet1.ColumnHeader.Columns[SPD_COLUMUNS_KOUTUKEICD].Visible = true;
            }
        }

        /// <summary>
        /// スプレッドの履歴背景色更新
        /// </summary>
        private void UpdateSpd_Design_RirekiBackColor()
        {
            for (int rowIndex = 0; rowIndex < spdHikTrkmList_Sheet1.Rows.Count; rowIndex++)
            {
                Row row = spdHikTrkmList_Sheet1.Rows[rowIndex];
                Cell cell_SaisinFlg 
                    = spdHikTrkmList_Sheet1.Cells[rowIndex, SPD_COLUMUNS_SAISINFLG];

                Cell cell_RireNo = spdHikTrkmList_Sheet1.Cells[rowIndex, SPD_COLUMUNS_RIRENO];
                
                // 背景色を設定
                cell_RireNo.BackColor = KKHSystemColor.AcomFormColor.RirekiCngBackColor;
            }
        }

        #endregion
    }
}
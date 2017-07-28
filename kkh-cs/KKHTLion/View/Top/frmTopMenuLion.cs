using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Mast.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Lion.View.Detail;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;

namespace Isid.KKH.Lion.View.Top
{
    /// <summary>
    /// トップメニュー画面(Lion).
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012//</description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmTopMenuLion : TopMenuForm, INaviParameter
    {
        #region 定数.

        /// <summary>
        /// アプリID_CMTV
        /// </summary>
        private const String APLID_CMTV = "CmTv";

        /// <summary>
        /// アプリID_CMRD
        /// </summary>
        private const String APLID_CMRD = "CmRd";

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// ナビパラメータ.
        /// </summary>
        private KKHNaviParameter topNaviParameter;

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public frmTopMenuLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面遷移するたびに発生します。.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void frmTopMenuLion_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;

            this.ActiveControl = null;
        }

        #region ボタンクリックイベント.

        /// <summary>
        /// 請求原票取込履歴ボタンクリック(リストボックス表示).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryDownLoad_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toHisDownlodData";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// FD出力ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFD_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toFDLion";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// CM秒数テレビボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCmTv_Click(object sender, EventArgs e)
        {
            CallCmTV();

            this.ActiveControl = null;
        }

        /// <summary>
        /// CM秒数ラジオボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCmRd_Click(object sender, EventArgs e)
        {
            CallCmRd();

            this.ActiveControl = null;
        }

        /// <summary>
        /// TVSpotデータ取り込みボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhTVSpot_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toFindLionTVSpot";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);

            this.ActiveControl = null;
        }

        #endregion ボタンクリックイベント.

        #region CM秒数.

        #region CM秒数－テレビ.

        /// <summary>
        /// CM秒数(テレビ)起動.
        /// </summary>
        private void CallCmTV()
        {
            //ファイル入出力情報の取得.
            GetOutputInfo();

            //***********************************
            //接続確認.
            //***********************************
            if (!CheckSystemDrive("R:"))
            {
                return;
            }

            //***********************************
            //起動確認.
            //***********************************
            if (!CheckSystemStarting(Path.Combine(AddressKido, "TV起動中.xls")))
            {
                return;
            }

            //***********************************
            //起動確認.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すれば削除する.
            //***********************************
            if (!AddressKido_old.Trim().Equals(string.Empty))
            {
                if (!CheckSystemStarting(Path.Combine(AddressKido_old, "TV起動中.xls")))
                {
                    return;
                }
            }

            //***********************************
            //起動ファイル作成.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すればこちらを使用.
            //***********************************
            if (!CreateStartingFile(AddressKido, "TV起動中.xls"))
            {
                return;
            }

            //***********************************
            //起動ファイル作成.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すれば削除する.
            //***********************************
            if (!AddressKido_old.Trim().Equals(string.Empty))
            {
                if (!CreateStartingFile(AddressKido_old, "TV起動中.xls"))
                {
                    return;
                }
            }

            //***********************************
            //マスタ同期.
            //***********************************
            //RefreshMast();

            //***********************************
            //マスタデータ取得～ファイル出力.
            //***********************************
            //=========================
            //ADブランドマスタ.
            //=========================
            OutputExcelAdBrand();

            //=========================
            //ANB対応マスタ.
            //=========================
            OutputExcelANB();

            //***********************************
            //エクセル起動.
            //***********************************
            if (!File.Exists(Path.Combine(AddressSystem, tvCmMacroFname)))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0021, new string[] { null }, "広告費明細システム", MessageBoxButtons.OK);
                return;
            }

            System.Diagnostics.Process.Start("excel", Path.Combine(AddressSystem, tvCmMacroFname));

            // オペレーションログの出力.
            KKHLogUtilityLion.WriteOperationLogToDB(topNaviParameter, APLID_CMTV, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_CMTV, KKHLogUtilityLion.DESC_OPERATION_LOG_CMTV);
        }

        #endregion CM秒数－テレビ.

        #region CM秒数－ラジオ.

        /// <summary>
        /// CM秒数(ラジオ)起動.
        /// </summary>
        private void CallCmRd()
        {
            //ファイル入出力情報の取得.
            GetOutputInfo();

            //***********************************
            //接続確認.
            //***********************************
            if (!CheckSystemDrive("R:"))
            {
                return;
            }

            //***********************************
            //起動確認.
            //***********************************
            if (!CheckSystemStarting(Path.Combine(AddressKido, "RD起動中.xls")))
            {
                return;
            }

            //***********************************
            //起動確認.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すれば削除する.
            //***********************************
            if (!AddressKido_old.Trim().Equals(string.Empty))
            {
                if (!CheckSystemStarting(Path.Combine(AddressKido_old, "RD起動中.xls")))
                {
                    return;
                }
            }

            //***********************************
            //起動ファイル作成.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すればこちらを使用.
            //***********************************
            if (!CreateStartingFile(AddressKido, "RD起動中.xls"))
            {
                return;
            }

            //***********************************
            //起動ファイル作成.
            //※現行システムと並行運用時のみ.
            //平行運用が終了すれば削除する.
            //***********************************
            if (!AddressKido_old.Trim().Equals(string.Empty))
            {
                if (!CreateStartingFile(AddressKido_old, "RD起動中.xls"))
                {
                    return;
                }
            }

            //***********************************
            //マスタ同期.
            //***********************************
            //RefreshMast();

            //***********************************
            //マスタデータ取得～ファイル出力.
            //***********************************
            //=========================
            //ADブランドマスタ.
            //=========================
            OutputExcelAdBrand();

            //=========================
            //ANB対応マスタ.
            //=========================
            OutputExcelANB();

            //***********************************
            //エクセル起動.
            //***********************************
            //エクセル起動.
            if (!File.Exists(Path.Combine(AddressSystem, rdCmMacroFname)))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0021, new string[] { null }, "広告費明細システム", MessageBoxButtons.OK);
                return;
            }

            System.Diagnostics.Process.Start("excel", Path.Combine(AddressSystem, rdCmMacroFname));

            // オペレーションログの出力.
            KKHLogUtilityLion.WriteOperationLogToDB(topNaviParameter,
                APLID_CMRD, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_CMRD, KKHLogUtilityLion.DESC_OPERATION_LOG_CMRD);
        }

        #endregion CM秒数－ラジオ.

        #region マスタExcel出力(ADブランドマスタ).

        /// <summary>
        /// ADブランドマスタのデータをExcelに出力します。.
        /// </summary>
        private void OutputExcelAdBrand()
        {
            string errMsg = "";//エクセル出力のエラーメッセージ.
            KKH.Common.KKHUtility.ExcelOutPut excelOutPut = new Isid.KKH.Common.KKHUtility.ExcelOutPut();
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            //データ取得.
            FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(topNaviParameter.strEsqId
                                                                                                , topNaviParameter.strEgcd
                                                                                                , topNaviParameter.strTksKgyCd
                                                                                                , topNaviParameter.strTksBmnSeqNo
                                                                                                , topNaviParameter.strTksTntSeqNo
                                                                                                , KKHLionConst.C_MAST_BRAND_CD
                                                                                                , "");

            //出力用データテーブル編集.
            DataTable dtBrand = new DataTable("AD_BRAND");
            dtBrand.Columns.Add("ブランドコード", Type.GetType("System.String"));
            dtBrand.Columns.Add("商品名", Type.GetType("System.String"));
            dtBrand.Columns.Add("商品記号", Type.GetType("System.String"));
            foreach (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                dtBrand.Rows.Add(row.Column1, row.Column2, row.Column3);
            }

            if (File.Exists(Path.Combine(AddressOutMst, AdBrandFname)) == true)
            {
                //出力するファイルが存在していたら削除.
                File.Delete(Path.Combine(AddressOutMst, AdBrandFname));
            }
            //Excelファイル出力.
            excelOutPut.ExcelOutFromDataTable(Path.Combine(AddressOutMst, AdBrandFname), AdBrandSname, dtBrand, ref errMsg);

            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
            }
        }

        #endregion マスタExcel出力(ADブランドマスタ).

        #region マスタExcel出力(ANB対応マスタ).

        /// <summary>
        /// ANB対応マスタのデータをExcelに出力します。.
        /// </summary>
        private void OutputExcelANB()
        {
            string errMsg = "";//エクセル出力のエラーメッセージ.
            KKH.Common.KKHUtility.ExcelOutPut excelOutPut = new Isid.KKH.Common.KKHUtility.ExcelOutPut();
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            //データ取得.
            FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(topNaviParameter.strEsqId
                                                        , topNaviParameter.strEgcd
                                                        , topNaviParameter.strTksKgyCd
                                                        , topNaviParameter.strTksBmnSeqNo
                                                        , topNaviParameter.strTksTntSeqNo
                                                        , "0023"//KKHLionConst.C_MAST_BRAND_CD
                                                        , "");

            //出力用データテーブル編集.
            DataTable dtANB = new DataTable("ANB");
            dtANB.Columns.Add("局コード", Type.GetType("System.String"));
            dtANB.Columns.Add("局名", Type.GetType("System.String"));
            dtANB.Columns.Add("変更日付", Type.GetType("System.String"));
            dtANB.Columns.Add("局誌コード", Type.GetType("System.String"));
            foreach (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                dtANB.Rows.Add(row.Column1, row.Column2, row.Column3, row.Column4);
            }

            if (File.Exists(Path.Combine(AddressOutMst, AnbFname)) == true)
            {
                //出力するファイルが存在していたら削除.
                File.Delete(Path.Combine(AddressOutMst, AnbFname));
            }
            //Excelファイル出力.
            excelOutPut.ExcelOutFromDataTable(Path.Combine(AddressOutMst, AnbFname), AnbSname, dtANB, ref errMsg);

            if (errMsg != "")
            {
                MessageBox.Show(errMsg);
            }
        }

        #endregion マスタExcel出力(ANB対応マスタ).

        #region マスタ(DB)リフレッシュ.

        /// <summary>
        /// マスタ最新化.
        /// </summary>
        private void RefreshMast()
        {
            Isid.KKH.Lion.Schema.MastLion.TvCmLionDataTable prTvBmast;//TV秒数マスタ用.
            Isid.KKH.Lion.Schema.MastLion.RdCmLionDataTable prRdBmast;//RD秒数マスタ用.
            Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable prTvRmast;//TV料金マスタ用.
            Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable prRdRmast;//RD料金マスタ用.

            //マスタ取得処理/////////////////////////////////////////////////////////////////////////////////////////

            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;

            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            //CM秒数TVデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(Address, Pass, TempAddress, TvbFname, KKHLionConst.C_WRFL_TVCMST, topNaviParameter))
            {
                //データテーブルVOにデータ読込開始.
                prTvBmast = mstf.findTvBDataCSVRead(Address + TvbFname, "201203");
                if (prTvBmast == null)
                {
                    //エラー.
                }
            }

            //CM秒数ラジオデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(Address, Pass, TempAddress, RdbFname, KKHLionConst.C_WRFL_RDCMST, topNaviParameter))
            {
                //データテーブルVOにデータ読込開始.
                prRdBmast = mstf.findRdBDataCSVRead(Address + RdbFname, "200902");
                if (prRdBmast == null)
                {
                    //エラー.
                }
            }

            //TV系列局金額設定マスタデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, TvRFname, KKHLionConst.C_WRFL_TVRMST, topNaviParameter))
            {
                //データテーブルVOにデータ読込開始.
                prTvRmast = mstf.findTvRDataCSVRead(AddressMst + TvRFname, topNaviParameter);
                if (prTvRmast == null)
                {
                    //エラー.
                }
            }

            //RD系列局金額設定マスタデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, RdRFname, KKHLionConst.C_WRFL_RDRMST, topNaviParameter))
            {
                //データテーブルVOにデータ読込開始.
                prRdRmast = mstf.findRdRDataCSVRead(AddressMst + RdRFname, topNaviParameter);
                if (prRdRmast == null)
                {
                    //エラー.
                }
            }

            //●↓ここからワークテーブルリフレッシュタイム↓●.
            //TV番組マスタデータワークテーブルリフレッシュ処理.
            //ファイル取得、比較.
            //Boolean blok = false;
            if (tims.findMastGet(AddressMst, Pass, TempAddress, TvBnFname, KKHLionConst.C_WRFL_TVBMST, topNaviParameter))
            {
                //ワークテーブルリフレッシュ（TV番組マスタ）.
                Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable();
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                mstdatavo = mstf.TvBnSetCsvData(AddressMst + TvBnFname, topNaviParameter);

                masterMaintenanceProcessController.RegisterMasterResult(
                                                                  topNaviParameter.strEsqId,
                                                                  KKHLionConst.C_TRKPL,
                                                                  topNaviParameter.strEgcd,
                                                                  topNaviParameter.strTksKgyCd,
                                                                  topNaviParameter.strTksBmnSeqNo,
                                                                  topNaviParameter.strTksTntSeqNo,
                                                                  "",
                                                                  "",
                                                                  mstdatavo,
                                                                  dtNow);
            }

            //ラジオ番組マスタデータワークテーブルリフレッシュ処理.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, RdBnFname, KKHLionConst.C_WRFL_RDBMST, topNaviParameter))
            {
                //ワークテーブルリフレッシュ（ラジオ番組マスタ).
                Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable();
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                mstdatavo = mstf.RdBnSetCsvData(AddressMst + RdBnFname, topNaviParameter);

                masterMaintenanceProcessController.RegisterRdMasterResult(
                                                                  topNaviParameter.strEsqId,
                                                                  KKHLionConst.C_TRKPL,
                                                                  topNaviParameter.strEgcd,
                                                                  topNaviParameter.strTksKgyCd,
                                                                  topNaviParameter.strTksBmnSeqNo,
                                                                  topNaviParameter.strTksTntSeqNo,
                                                                  "",
                                                                  "",
                                                                  mstdatavo,
                                                                  dtNow);
            }

            //TV局マスタデータワークテーブルリフレッシュ処理.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, TvKFname, KKHLionConst.C_WRFL_TVKMST, topNaviParameter))
            {
                //ワークテーブルリフレッシュ（TV局マスタ）.
                Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable();
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                mstdatavo = mstf.TvKSetCsvData(AddressMst + TvKFname, topNaviParameter);

                masterMaintenanceProcessController.RegisterTvKMasterResult(
                                                                  topNaviParameter.strEsqId,
                                                                  KKHLionConst.C_TRKPL,
                                                                  topNaviParameter.strEgcd,
                                                                  topNaviParameter.strTksKgyCd,
                                                                  topNaviParameter.strTksBmnSeqNo,
                                                                  topNaviParameter.strTksTntSeqNo,
                                                                  "",
                                                                  "",
                                                                  mstdatavo,
                                                                  dtNow);
            }

            //ラジオ局マスタデータワークテーブルリフレッシュ処理.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, RdKFname, KKHLionConst.C_WRFL_RDKMST, topNaviParameter))
            {
                //ワークテーブルリフレッシュ（ラジオ局マスタ）.
                Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable();
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                mstdatavo = mstf.RdKSetCsvData(AddressMst + RdKFname, topNaviParameter);

                masterMaintenanceProcessController.RegisterRdKMasterResult(
                                                                  topNaviParameter.strEsqId,
                                                                  KKHLionConst.C_TRKPL,
                                                                  topNaviParameter.strEgcd,
                                                                  topNaviParameter.strTksKgyCd,
                                                                  topNaviParameter.strTksBmnSeqNo,
                                                                  topNaviParameter.strTksTntSeqNo,
                                                                  "",
                                                                  "",
                                                                  mstdatavo,
                                                                  dtNow);
            }
        }

        #endregion マスタ(DB)リフレッシュ.

        #region ドライブ接続チェック.

        /// <summary>
        /// ドライブ接続チェック.
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>判定結果</returns>
        private bool CheckSystemDrive(string path)
        {
            // ドライブ接続チェック.
            if (!Directory.Exists(path))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0023,
                    new string[] { path + "ドライブ" }, "広告費明細システム", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        #endregion ドライブ接続チェック.

        #region システム起動チェック.

        /// <summary>
        /// システム起動チェック.
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>判定結果</returns>
        private bool CheckSystemStarting(string path)
        {
            // ファイルの存在チェック.
            if (File.Exists(path))
            {
                // 存在する場合、メッセージを表示し終了する.
                MessageUtility.ShowMessageBox(MessageCode.HB_I0014, null, "広告費明細システム", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        #endregion システム起動チェック.

        #region 起動ファイル作成.

        /// <summary>
        /// 起動ファイル作成.
        /// </summary>
        private bool CreateStartingFile(string path, string name)
        {
            if (!Directory.Exists(path))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0022, new string[] { null }, "広告費明細システム", MessageBoxButtons.OK);
                return false;
            }

            File.Create(Path.Combine(path, name)).Close();
            return true;
        }

        private bool CreateStartingFile(string path, string name, string path2, string name2)
        {
            if (!Directory.Exists(path) || !Directory.Exists(path2))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0022, new string[] { null }, "広告費明細システム", MessageBoxButtons.OK);
                return false;
            }

            File.Create(Path.Combine(path, name)).Close();
            File.Create(Path.Combine(path2, name2)).Close();

            return true;
        }

        #endregion 起動ファイル作成.

        //共通クラス作成を検討.
        #region CM秒数関連情報取得・設定.

        //変数.
        private string Address = "";                  //アドレス(秒数系)
        private string AddressMst = "";               //アドレス(Excel→DB系)
        private string AddressOutMst = "";            //アドレス(DB→Excel系)--現[R:\E05-LION\NEWSYSTEM\LION\MAS]
        private string AddressSystem = "";            //アドレス(システム系) --現[R:\E05-LION\NEWSYSTEM\LION\SYSTEM]
        private string AddressKido = "";              //アドレス(システム系) --現[R:\E05-LION\NEWSYSTEM\LION\KIDO]
        private string AddressKido_old = "";          //アドレス(システム系) --旧[R:\E05-LION\KIDO]
        private string Pass = "";                     //パスワード.
        private string TempAddress = "";              //テンプアドレス.
        private string TvbFname = "";                 //テレビ秒数用ファイルネーム.
        private string RdbFname = "";                 //テレビ秒数用ファイルネーム.
        private string TvRFname = "";                 //テレビ系列局金額設定マスタファイル用ファイルネーム.
        private string RdRFname = "";                 //ラジオ系列局金額設定マスタファイル用ネーム.
        private string TvBnFname = "";                //テレビ番組マスタ用ファイルネーム.
        private string RdBnFname = "";                //ラジオ番組マスタ用ファイルネーム.
        private string TvKFname = "";                 //テレビ局マスタ用ファイルネーム.
        private string RdKFname = "";                 //ラジオ局マスタ用ファイルネーム.
        private const string AdBrandFname = "Adﾌﾞﾗﾝﾄﾞ.XLS"; //ADブランドマスタファイル名 --TODO：CONST→DB管理.
        private const string AnbFname = "ANBﾏｽﾀ.XLS";       //ANBマスタファイル名 --TODO：CONST→DB管理.
        private const string AdBrandSname = "ADﾌﾞﾗﾝﾄﾞﾏｽﾀ_V";//ADブランドマスタシート名 --TODO：CONST→DB管理.
        private const string AnbSname = "ANB対応_V";        //ANBマスタシート名 --TODO：CONST→DB管理.

        private const string tvCmMacroFname = @"TV予定EX.XLA";//CM秒数(テレビ)実行マクロファイル名--TODO：CONST→DB管理.
        private const string rdCmMacroFname = @"RD予定EX.XLA";//CM秒数(ラジオ)実行マクロファイル名--TODO：CONST→DB管理.

        private void GetOutputInfo()
        {

            FindCommonByCondServiceResult plDtMast = new FindCommonByCondServiceResult();//アドレス系システムマスタ用.
            FindCommonByCondServiceResult plDtMast2 = new FindCommonByCondServiceResult();//ファイル系システムマスタ用.

            //取得（アドレス）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            topNaviParameter.strEsqId,
                                                                                            topNaviParameter.strEgcd,
                                                                                            topNaviParameter.strTksKgyCd,
                                                                                            topNaviParameter.strTksBmnSeqNo,
                                                                                            topNaviParameter.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRFL_SYBT,
                                                                                            KKHLionConst.C_SMASTA_FLD1);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast = comResult;
            }

            //アドレス、パス、添付アドレスを取得設定.
            Address = plDtMast.CommonDataSet.SystemCommon[0].field3.ToString();
            AddressMst = plDtMast.CommonDataSet.SystemCommon[0].field4.ToString();
            AddressOutMst = plDtMast.CommonDataSet.SystemCommon[0].field5.ToString();
            AddressSystem = plDtMast.CommonDataSet.SystemCommon[0].field6.ToString();
            AddressKido = plDtMast.CommonDataSet.SystemCommon[0].field7.ToString();
            AddressKido_old = plDtMast.CommonDataSet.SystemCommon[0].field8.ToString();
            Pass = plDtMast.CommonDataSet.SystemCommon[0].field10.ToString();
            TempAddress = plDtMast.CommonDataSet.SystemCommon[0].field2.ToString();

            //取得（ファイル）.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            topNaviParameter.strEsqId,
                                                                                            topNaviParameter.strEgcd,
                                                                                            topNaviParameter.strTksKgyCd,
                                                                                            topNaviParameter.strTksBmnSeqNo,
                                                                                            topNaviParameter.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRKT_SYBT,
                                                                                            KKHLionConst.C_WRKTF_FLD1);

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast2 = comResult2;
            }

            //ファイル名を取得設定.
            TvbFname = plDtMast2.CommonDataSet.SystemCommon[0].field8.ToString();
            RdbFname = plDtMast2.CommonDataSet.SystemCommon[0].field9.ToString();
            TvBnFname = plDtMast2.CommonDataSet.SystemCommon[0].field2.ToString();
            RdBnFname = plDtMast2.CommonDataSet.SystemCommon[0].field3.ToString();
            TvKFname = plDtMast2.CommonDataSet.SystemCommon[0].field4.ToString();
            RdKFname = plDtMast2.CommonDataSet.SystemCommon[0].field5.ToString();
            TvRFname = plDtMast2.CommonDataSet.SystemCommon[0].field6.ToString();
            RdRFname = plDtMast2.CommonDataSet.SystemCommon[0].field7.ToString();
        }

        #endregion CM秒数関連情報取得・設定.

        private void btnHistoryDownLoad_Click_1(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toHisDownlodData";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        #endregion CM秒数.

        /// <summary>
        /// 帳票ボタンのボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1")
            {
                topNaviParameter.strFrmInputNm = "toNewReportLion";
            }
            else if (value.Value == "2")
            {
                topNaviParameter.strFrmInputNm = "toReportProofLion";
            }
            else if (value.Value == "3")
            {
                topNaviParameter.strFrmInputNm = "toFDLion";
            }
            //2012/02/04 add start okazaki
            else if (value.Value == "4")
            {
                topNaviParameter.strFrmInputNm = "toDetailListLion";
            }
            //2012/02/04 add end okazaki
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
            //制作室リスト・追加変更リスト.
            else if (value.Value == "5")
            {
                topNaviParameter.strFrmInputNm = "toReportAddChangeLion";
            }
            //請求予定表チェックリスト.
            else if (value.Value == "6")
            {
                topNaviParameter.strFrmInputNm = "toReportInvoicePlanLion";
            }
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

            /* 2014/11/10 ライオン追加要望対応 HLC fujimoto ADD start */
            else if (value.Value == "7")
            {
                topNaviParameter.strFrmInputNm = "toReportOrderDiffLion";
            }
            /* 2014/11/10 ライオン追加要望対応 HLC fujimoto ADD end */

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// MouseMoveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMasterMaintenance_MouseHover(object sender, EventArgs e)
        {
            this.btnMasterMaintenance.ShowPopupForm();
        }

        /// <summary>
        /// [マスタ]ボタンPopupButtonClick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnMasterMaintenance_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            //ボタン名(画面名)を取得.
            topNaviParameter.StrValue1 = value.Value.ToString();
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        #endregion イベント.

    }

}
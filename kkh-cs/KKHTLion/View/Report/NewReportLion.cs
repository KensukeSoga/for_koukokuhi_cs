using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Lion.Schema;
using System.Collections;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

namespace Isid.KKH.Lion.View.Report
{
    public partial class NewReportLion : KKHForm
    {
        #region 定数.

        /// <summary>
        /// 合計行出力数.
        /// </summary>
        private const int TOTAL_AMOUNT_ROWS = 1;
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Lion_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Lion_NewReport_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "LionNewReport.xlsm";
        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "NewRep";

        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
        //通販＋通販以外.
        /// <summary>
        /// XMLデータファイル(新聞).
        /// </summary>
        private const String XML_FILE_NP = "LionDataNewspaper.xml";
        /// <summary>
        /// XMLデータファイル(雑誌).
        /// </summary>
        private const String XML_FILE_MZ = "LionDataMagazine.xml";
        /// <summary>
        /// XMLデータファイル(交通).
        /// </summary>
        private const String XML_FILE_TF = "LionDataTraffic.xml";
        /// <summary>
        /// XMLデータファイル(事業費).
        /// </summary>
        private const String XML_FILE_JI = "LionDataJigyouhi.xml";
        /// <summary>
        /// XMLデータファイル(モバイル).
        /// </summary>
        private const String XML_FILE_MO = "LionDataMobile.xml";
        /// <summary>
        /// XMLデータファイル(インターネット).
        /// </summary>
        private const String XML_FILE_IN = "LionDataInternet.xml";
        /// <summary>
        /// XMLデータファイル(チラシ).
        /// </summary>
        private const String XML_FILE_TI = "LionDataTirashi.xml";
        /// <summary>
        /// XMLデータファイル(その他).
        /// </summary>
        private const String XML_FILE_OT = "LionDataOther.xml";
        /// <summary>
        /// XMLデータファイル(サンプリング).
        /// </summary>
        private const String XML_FILE_SA = "LionDataSampling.xml";
        /// <summary>
        /// XMLデータファイル(テレビタイム).
        /// </summary>
        private const String XML_FILE_TT = "LionDataTvTime.xml";
        /// <summary>
        /// XMLデータファイル(テレビスポット).
        /// </summary>
        private const String XML_FILE_TS = "LionDataTvSpot.xml";
        /// <summary>
        /// XMLデータファイル(ラジオタイム).
        /// </summary>
        private const String XML_FILE_RT = "LionDataRdTime.xml";
        /// <summary>
        /// XMLデータファイル(ラジオスポット).
        /// </summary>
        private const String XML_FILE_RS = "LionDataRdSpot.xml";
        /// <summary>
        /// XMLデータファイル(BS/CS).
        /// </summary>
        private const String XML_FILE_BS = "LionDataBSCS.xml";

        //通販.
        /// <summary>
        /// XMLデータファイル(新聞＜通販＞).
        /// </summary>
        private const String XML_FILE_NP_WIMO = "LionDataNewspaperWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(雑誌＜通販＞).
        /// </summary>
        private const String XML_FILE_MZ_WIMO = "LionDataMagazineWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(交通＜通販＞).
        /// </summary>
        private const String XML_FILE_TF_WIMO = "LionDataTrafficWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(事業費＜通販＞).
        /// </summary>
        private const String XML_FILE_JI_WIMO = "LionDataJigyouhiWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(モバイル＜通販＞).
        /// </summary>
        private const String XML_FILE_MO_WIMO = "LionDataMobileWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(インターネット＜通販＞).
        /// </summary>
        private const String XML_FILE_IN_WIMO = "LionDataInternetWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(チラシ＜通販＞).
        /// </summary>
        private const String XML_FILE_TI_WIMO = "LionDataTirashiWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(その他＜通販＞).
        /// </summary>
        private const String XML_FILE_OT_WIMO = "LionDataOtherWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(サンプリング＜通販＞).
        /// </summary>
        private const String XML_FILE_SA_WIMO = "LionDataSamplingWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(テレビタイム＜通販＞).
        /// </summary>
        private const String XML_FILE_TT_WIMO = "LionDataTvTimeWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(テレビスポット＜通販＞).
        /// </summary>
        private const String XML_FILE_TS_WIMO = "LionDataTvSpotWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(ラジオタイム＜通販＞).
        /// </summary>
        private const String XML_FILE_RT_WIMO = "LionDataRdTimeWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(ラジオスポット＜通販＞).
        /// </summary>
        private const String XML_FILE_RS_WIMO = "LionDataRdSpotWithMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(BS/CS＜通販＞).
        /// </summary>
        private const String XML_FILE_BS_WIMO = "LionDataBSCSWithMailOrder.xml";

        //通販以外.
        /// <summary>
        /// XMLデータファイル(新聞＜通販以外＞).
        /// </summary>
        private const String XML_FILE_NP_WOMO = "LionDataNewspaperWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(雑誌＜通販以外＞).
        /// </summary>
        private const String XML_FILE_MZ_WOMO = "LionDataMagazineWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(交通＜通販以外＞).
        /// </summary>
        private const String XML_FILE_TF_WOMO = "LionDataTrafficWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(事業費＜通販以外＞).
        /// </summary>
        private const String XML_FILE_JI_WOMO = "LionDataJigyouhiWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(モバイル＜通販以外＞).
        /// </summary>
        private const String XML_FILE_MO_WOMO = "LionDataMobileWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(インターネット＜通販以外＞).
        /// </summary>
        private const String XML_FILE_IN_WOMO = "LionDataInternetWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(チラシ＜通販以外＞).
        /// </summary>
        private const String XML_FILE_TI_WOMO = "LionDataTirashiWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(その他＜通販以外＞).
        /// </summary>
        private const String XML_FILE_OT_WOMO = "LionDataOtherWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(サンプリング＜通販以外＞).
        /// </summary>
        private const String XML_FILE_SA_WOMO = "LionDataSamplingWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(テレビタイム＜通販以外＞).
        /// </summary>
        private const String XML_FILE_TT_WOMO = "LionDataTvTimeWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(テレビスポット＜通販以外＞).
        /// </summary>
        private const String XML_FILE_TS_WOMO = "LionDataTvSpotWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(ラジオタイム＜通販以外＞).
        /// </summary>
        private const String XML_FILE_RT_WOMO = "LionDataRdTimeWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(ラジオスポット＜通販以外＞).
        /// </summary>
        private const String XML_FILE_RS_WOMO = "LionDataRdSpotWithoutMailOrder.xml";
        /// <summary>
        /// XMLデータファイル(BS/CS＜通販以外＞).
        /// </summary>
        private const String XML_FILE_BS_WOMO = "LionDataBSCSWithoutMailOrder.xml";

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 消費税.
        /// </summary>
        private double _mDblShohizei;
        /// <summary>
        /// 帳票保存先用変数.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string _mStrRepFileMei = string.Empty;
        /// <summary>
        /// 検索日.
        /// </summary>
        private string _mStrDD;
        /// <summary>
        /// コピーマクロ削除用string.
        /// </summary>
        private string _mStrMacroDel = string.Empty;
        /// <summary>
        /// データセット.
        /// </summary>
        RepDsLion LionDs = new RepDsLion();
        /// <summary>
        /// 保存用データセット.
        /// </summary>
        MastLion MastLionDs = new MastLion();
        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
        /// <summary>
        /// ADブランドマスタデータテーブル.
        /// </summary>
        DataTable dtBrand = new DataTable("AD_BRAND");
        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public NewReportLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面遷移時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void NewReportLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームShown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewReportLion_Shown(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            //検索年月日取得.
            string hostdate = getHostDate();
            dtpYyyyMmDd.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(hostdate);
            _mStrDD = hostdate.Substring(6, 2);

            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //Excelボタンを非活性化.
            btnXls.Enabled = false;

            //スプレッド初期化.
            SpredSyokika();

            //消費税取得（マスタから）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //消費税.
                _mDblShohizei = KKHUtility.DouParse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス.
                _mStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //保存情報＋帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.ReportType,
                                                                                            "004");

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                _mStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                _mStrRepFileMei = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //グリッドの設定.
            statusStrip1.Items["tslval1"].Text = "0件";
            btnXls.Enabled = false;

            //**********************
            //コンボボックスの設定.
            //**********************
            CmbSetting();

            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
            //*************************
            //ADブランドマスタ取得.
            //*************************
            GetAdBrand();
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

            //*************************
            //ライオンマスタの取得.
            //*************************
            KKHLionReadMastFile mast = new KKHLionReadMastFile();
            MastLionDs = mast.GetLionMast(_naviParam);

            if (MastLionDs.TvBnLion.Count == 0 &&
                MastLionDs.RdBnLion.Count == 0 &&
                MastLionDs.TvKLion.Count == 0 &&
                MastLionDs.RdKLion.Count == 0)
            {
                //MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "見積書", MessageBoxButtons.OK);
                base.CloseLoadingDialog();
                Navigator.Backward(this, null, _naviParam, true);
                return;
            }

            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 戻るボタンを押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_mStrMacroDel))
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_mStrMacroDel);

                // マクロファイルの削除（VBA側では削除できない為）.
                // ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // ファイルを削除する.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        #region 検索ボタン.

        /// <summary>
        /// 検索ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //データ表示.
            Display();

            //ローディング表示終了.
            base.CloseLoadingDialog();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        #endregion 検索ボタン.

        #region 帳票出力ボタン.

        /// <summary>
        /// エクセルボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();
            excelFileSet();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;

            base.CloseLoadingDialog();
        }

        #endregion 帳票出力ボタン.

        #region ヘルプボタン.

        /// <summary>
        /// ヘルプボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード.
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
        }

        #endregion ヘルプボタン.

        #endregion イベント.

        #region メソッド.

        #region 帳票出力ボタン歩活性化.

        /// <summary>
        /// 帳票出力非活性化.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする.
            btnXls.Enabled = false;
        }

        #endregion 帳票出力ボタン非活性化.

        #region 営業日取得.

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        #endregion 営業日取得.

        #region コンボボックス設定.

        /// <summary>
        /// コンボボックスの設定.
        /// </summary>
        private void CmbSetting()
        {
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.TV_TIME, KKHLionConst.BaitaiCd.TV_TIME);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.TV_SPOT, KKHLionConst.BaitaiCd.TV_SPOT);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.BSCS, KKHLionConst.BaitaiCd.BSCS);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.RADIO_TIME, KKHLionConst.BaitaiCd.RADIO_TIME);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.RADIO_SPOT, KKHLionConst.BaitaiCd.RADIO_SPOT);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.SHINBUN, KKHLionConst.BaitaiCd.SHINBUN);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.ZASHI, KKHLionConst.BaitaiCd.ZASHI);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.KOUTSU, KKHLionConst.BaitaiCd.KOUTSU);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.TIRASHI, KKHLionConst.BaitaiCd.TIRASHI);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.SAMPLING, KKHLionConst.BaitaiCd.SAMPLING);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.INTERNET, KKHLionConst.BaitaiCd.INTERNET);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.MOBILE, KKHLionConst.BaitaiCd.MOBILE);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.JIGYOUHI, KKHLionConst.BaitaiCd.JIGYOUHI);
            SybtNameTable.Rows.Add(KKHLionConst.BaitaiName.SONOTA, KKHLionConst.BaitaiCd.SONOTA);

            cmbBaitai.DataSource = SybtNameTable;
            cmbBaitai.DisplayMember = "Display";
            cmbBaitai.ValueMember = "Value";
            cmbBaitai.SelectedValue = KKHLionConst.BaitaiCd.TV_TIME;
        }

        #endregion コンボボックス設定.

        #region データ表示.

        /// <summary>
        /// データ表示.
        /// </summary>
        private void Display()
        {
            //媒体コードを取得.
            string baitaiCd = cmbBaitai.SelectedValue.ToString();

            // 年月の取得.
            string yyyyMm = dtpYyyyMmDd.Value.ToString("yyyyMM");
            //string yyyyMm = getYYYYMM();

            //CM秒数用.
            KKHLionReadMastFile readMastFile = new KKHLionReadMastFile();

            //パラメーター.
            ReportLionProcessController.FindNewReportLionParam param = new ReportLionProcessController.FindNewReportLionParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yyyyMm;
            param.baitaiCd = baitaiCd;

            //*******************.
            //サービスの呼び出し.
            //*******************.
            ReportLionProcessController processController = ReportLionProcessController.GetInstance();
            FindReportLionByCondServiceResult result = processController.FindReportNewLionByCond(param);

            if (result.HasError)
            {
                return;
            }

            //検索結果が0件の場合.
            if (result.dsRepLionDataSet.NewRepLion.Rows.Count == 0)
            {
                //スプレッド初期化.
                SpredSyokika();

                //Excelボタン押下不可.
                btnXls.Enabled = false;

                statusStrip1.Items["tslval1"].Text = "0件";

                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "見積書", MessageBoxButtons.OK);
                return;
            }

            //スプレッド初期化.
            SpredSyokika();

            //Excelボタン押下可能.
            btnXls.Enabled = true;

            //データセット初期化.
            LionDs = new RepDsLion();

            //****************************************.
            //スプレッドに表示(件数分表示).
            //****************************************.

            #region テレビタイム.

            //テレビタイムの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TV_TIME))
            {
                sprTvTime.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("",""))
                {
                    //表示順が0以外の場合のみ表示.
                    if (row.Area.Equals("0")) { continue; }

                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //番組名.
                    addrow.Column1 = row.Kenname.Trim();

                    //放送局.
                    string housoukyoku = string.Empty;
                    if (!string.IsNullOrEmpty(row.Housoukyoku.Trim()))
                    {
                        housoukyoku = row.Housoukyoku.Trim();
                        if (row.NetKyoku.Trim().Equals("000"))
                        {
                            housoukyoku = housoukyoku + "ローカル";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(row.NetKyoku.Trim()))
                            {
                                long netkyoku = long.Parse(row.NetKyoku.Trim());
                                housoukyoku = housoukyoku + "他" + netkyoku + "局";
                            }
                            else
                            {
                                housoukyoku = housoukyoku + "他";
                            }
                        }
                        addrow.Column2 = housoukyoku;
                    }
                    else
                    {
                        addrow.Column2 = string.Empty;
                    }
                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    if (!string.IsNullOrEmpty(row.Cmbyousu.Trim()))
                    {
                        long cm = KKHUtility.LongParse(row.Cmbyousu.Trim());
                        long honsu = KKHUtility.LongParse(row.Honsu.Trim());
                        //long cm = long.Parse(row.Cmbyousu.Trim());
                        //long honsu = long.Parse(row.Honsu.Trim());

                        //CM秒数.
                        if (cm != 0 && honsu != 0)
                        {
                            addrow.Column4 = cm.ToString() + "×" + honsu.ToString();
                        }
                        else
                        {
                            addrow.Column4 = "";
                        }
                    }
                    else
                    {
                        addrow.Column4 = string.Empty;
                    }
                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //放送期間.
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column8 = string.Empty;

                    //okazaki
                    //備考（電波料）.
                    if (!string.IsNullOrEmpty(row.SUMSEIGAK.Trim()))
                    {
                        addrow.Column8 = double.Parse(row.SUMSEIGAK.Trim()).ToString("#,0") + "に関しては5%割引";
                    }
                    //okazaki

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示順が0の場合のみ表示.
                    if (!row.Area.Equals("0")) { continue; }

                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //番組名.
                    addrow.Column1 = row.Kenname.Trim();

                    //放送局.
                    string housoukyoku = string.Empty;
                    if (!string.IsNullOrEmpty(row.Housoukyoku.Trim()))
                    {
                        housoukyoku = row.Housoukyoku.Trim();
                        if (row.NetKyoku.Trim().Equals("000"))
                        {
                            housoukyoku = housoukyoku + "ローカル";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(row.NetKyoku.Trim()))
                            {
                                long netkyoku = long.Parse(row.NetKyoku.Trim());
                                housoukyoku = housoukyoku + "他" + netkyoku + "局";
                            }
                            else
                            {
                                housoukyoku = housoukyoku + "他";
                            }
                        }
                        addrow.Column2 = housoukyoku;
                    }
                    else
                    {
                        addrow.Column2 = string.Empty;
                    }
                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    if (!string.IsNullOrEmpty(row.Cmbyousu.Trim()))
                    {
                        long cm = KKHUtility.LongParse(row.Cmbyousu.Trim());
                        long honsu = KKHUtility.LongParse(row.Honsu.Trim());
                        //long cm = long.Parse(row.Cmbyousu.Trim());
                        //long honsu = long.Parse(row.Honsu.Trim());

                        //CM秒数.
                        if (cm != 0 && honsu != 0)
                        {
                            addrow.Column4 = cm.ToString() + "×" + honsu.ToString();
                        }
                        else
                        {
                            addrow.Column4 = "";
                        }
                    }
                    else
                    {
                        addrow.Column4 = string.Empty;
                    }
                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //放送期間.
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(), true);
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(), false);

                    //備考.
                    addrow.Column8 = string.Empty;

                    //okazaki
                    //備考（電波料）.
                    if (!string.IsNullOrEmpty(row.SUMSEIGAK.Trim()))
                    {
                        addrow.Column8 = double.Parse(row.SUMSEIGAK.Trim()).ToString("#,0") + "に関しては5%割引";
                    }
                    //okazaki

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";
                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprTvTime.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprTvTime.Columns[8].Visible = false;
                sprTvTime.Columns[9].Visible = false;
                sprTvTime.Columns[10].Visible = false;
                sprTvTime.Columns[11].Visible = false;
                sprTvTime.Columns[12].Visible = false;
            }

            #endregion テレビタイム.

            #region テレビスポット.

            //テレビスポットの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TV_SPOT))
            {
                //シートの表示.
                sprTvspot.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //放送局.
                    addrow.Column2 = row.Housoukyoku.Trim();

                    //エリア.
                    addrow.Column3 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //素材秒数.
                    addrow.Column6 = KKHUtility.IntParse(row.Cmbyousu.Trim()).ToString();

                    //放送期間.
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column8 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column9 = string.Empty;

                    //請求ブランド.
                    addrow.Column10 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column11 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column3 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprTvspot.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprTvspot.Columns[11].Visible = false;
                sprTvspot.Columns[12].Visible = false;
            }

            #endregion テレビスポット.

            #region BSCS

            //BSCSの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.BSCS))
            {
                //シートの表示.
                sprBscs.Visible = true;
                MastLionDs.TvCmLion.Clear();

                MastLionDs.TvCmLion.Merge(readMastFile.GetLionTvRdCm(_naviParam, dtpYyyyMmDd.Value.ToString("yyyyMM")).TvCmLion);

                //テレビCMのデータが無い場合.
                if (MastLionDs.TvCmLion.Rows.Count == 0)
                {
                    /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL start */
                    // 取得できない場合の初期化中止.

                    ////スプレッド初期化.
                    //SpredSyokika();

                    ////Excelボタン押下不可.
                    //btnXls.Enabled = false;

                    //statusStrip1.Items["tslval1"].Text = "0件";

                    //MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "見積書", MessageBoxButtons.OK);
                    //return;
                    /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL end */
                }

                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //番組名.
                    addrow.Column1 = row.Banmei.Trim();

                    //放送局.
                    addrow.Column2 = row.Housoukyoku.Trim();

                    //媒体コード.
                    // addrow.Column3 = row.Baitaicd.Trim();

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //CM秒数.
                    addrow.Column6 = row.Cmbyousu.Trim();

                    //放送期間.
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column8 = kikanHyouji(row.Kikan.Trim(),false);

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column3 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprBscs.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprBscs.Columns[11].Visible = false;
                sprBscs.Columns[12].Visible = false;
            }

            #endregion BSCS

            #region ラジオタイム.

            //ラジオタイムの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.RADIO_TIME))
            {
                //シートの表示.
                sprRadiotime.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示順が0以外の場合のみ表示.
                    if (row.Area.Equals("0")) { continue; }

                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //番組名.
                    addrow.Column1 = row.Banmei.Trim();

                    //放送局.
                    addrow.Column2 = row.Housoukyoku.Trim();

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    if (!string.IsNullOrEmpty(row.Cmbyousu.Trim()))
                    {
                        long cm = KKHUtility.LongParse(row.Cmbyousu.Trim());
                        long honsu = KKHUtility.LongParse(row.Honsu.Trim());

                        //CM秒数.
                        if (cm != 0 && honsu != 0)
                        {
                            addrow.Column4 = cm.ToString() + "×" + honsu.ToString();
                        }
                        else
                        {
                            addrow.Column4 = "";
                        }
                    }
                    else
                    {
                        addrow.Column4 = string.Empty;
                    }

                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //放送期間.
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column8 = string.Empty;

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示順が0の場合のみ表示.
                    if (!row.Area.Equals("0")) { continue; }

                    //表示用DataRow.
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //番組名.
                    addrow.Column1 = row.Banmei.Trim();

                    //放送局.
                    addrow.Column2 = row.Housoukyoku.Trim();

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    if (!string.IsNullOrEmpty(row.Cmbyousu.Trim()))
                    {
                        long cm = KKHUtility.LongParse(row.Cmbyousu.Trim());
                        long honsu = KKHUtility.LongParse(row.Honsu.Trim());

                        //CM秒数.
                        if (cm != 0 && honsu != 0)
                        {
                            addrow.Column4 = cm.ToString() + "×" + honsu.ToString();
                        }
                        else
                        {
                            addrow.Column4 = "";
                        }
                    }
                    else
                    {
                        addrow.Column4 = string.Empty;
                    }

                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //放送期間.
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column8 = string.Empty;

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);

                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprRadiotime.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprRadiotime.Columns[8].Visible = false;
                sprRadiotime.Columns[9].Visible = false;
                sprRadiotime.Columns[10].Visible = false;
                sprRadiotime.Columns[11].Visible = false;
                sprRadiotime.Columns[12].Visible = false;
            }

            #endregion ラジオタイム.

            #region ラジオスポット.

            //ラジオスポットの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.RADIO_SPOT))
            {
                //シートの表示.
                sprRadiospot.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //放送局.
                    addrow.Column2 = row.Housoukyoku.Trim();

                    //エリア.
                    addrow.Column3 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //放送料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //秒数.
                    addrow.Column6 = KKHUtility.IntParse(row.Cmbyousu.Trim()).ToString();

                    //放送期間.
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column8 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column9 = string.Empty;

                    //請求ブランド.
                    addrow.Column10 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column11 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column3 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprRadiospot.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprRadiospot.Columns[11].Visible = false;
                sprRadiospot.Columns[12].Visible = false;

            }

            #endregion ラジオスポット.

            #region 新聞.

            //新聞の場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SHINBUN))
            {
                //シートの表示.
                sprShinbun.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //件名.
                    addrow.Column1 = row.Kenname.Trim();

                    //紙名.
                    addrow.Column2 = row.Shimei.Trim();

                    addrow.Column3 = string.Empty;

                    //局誌コード.
                    if (!string.IsNullOrEmpty(row.KyokuCd.Trim()))
                    {
                        addrow.Column4 = row.KyokuCd.Trim();
                    }

                    //掲載.
                    if (!string.IsNullOrEmpty(row.Syurui.Trim()))
                    {
                        if (row.Syurui.Trim().Equals("1"))
                        {
                            addrow.Column5 = "朝刊";
                        }
                        else if (row.Syurui.Trim().Equals("2"))
                        {
                            addrow.Column5 = "夕刊";
                        }
                        else
                        {
                            addrow.Column5 = "-";
                        }
                    }
                    else
                    {
                        addrow.Column5 = "-";
                    }

                    //見積料.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column6 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //定価料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column7 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //スペース.
                    addrow.Column8 = row.Space.Trim();

                    //掲載期間.
                    addrow.Column9 = kikanHyouji(row.Kikan.Trim(),true);

                    //備考.
                    addrow.Column11 = string.Empty;

                    //請求ブランド.
                    addrow.Column12 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column13 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column5 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column6 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column7 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                //スプレッドシートに反映.
                sprShinbun.DataSource = LionDs.NewRepLionDisplay;


                //*********************
                //列非表示.
                //*********************
                //sprShinbun.Columns[9].Visible = false;
            }

            #endregion 新聞.

            #region 雑誌.

            //雑誌の場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.ZASHI))
            {
                //シートの表示.
                sprZashi.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //雑誌名.
                    addrow.Column2 = row.Zashimei.Trim();

                    //雑誌コード.
                    addrow.Column3 = row.Zashicd.Trim();

                    //見積料.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }
                    //定価料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column5 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }
                    //スペース.
                    addrow.Column6 = row.Space.Trim();

                    //掲載期間.
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),true);

                    //備考.
                    addrow.Column9 = string.Empty;

                    //請求ブランド.
                    addrow.Column10 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column11 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column3 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column5 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                //スプレッドシートに反映.
                sprZashi.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprZashi.Columns[11].Visible = false;
                sprZashi.Columns[12].Visible = false;
            }

            #endregion 雑誌.

            #region 交通.

            //交通の場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.KOUTSU))
            {
                //シートの表示.
                sprKoutsu.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //掲出.
                    addrow.Column2 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //定価料金.
                    addrow.Column4 = string.Empty;

                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(), false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                //スプレッドシートに反映.
                sprKoutsu.DataSource = LionDs.NewRepLionDisplay;


                //*********************
                //列非表示.
                //*********************
                sprKoutsu.Columns[9].Visible = false;
                sprKoutsu.Columns[10].Visible = false;
                sprKoutsu.Columns[11].Visible = false;
                sprKoutsu.Columns[12].Visible = false;
            }

            #endregion 交通.

            #region チラシ.

            //チラシの場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TIRASHI))
            {
                //シートの表示.
                sprTirashi.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //掲出.
                    addrow.Column2 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprTirashi.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprTirashi.Columns[9].Visible = false;
                sprTirashi.Columns[10].Visible = false;
                sprTirashi.Columns[11].Visible = false;
                sprTirashi.Columns[12].Visible = false;
            }

            #endregion チラシ.

            #region サンプリング.

            //サンプリング.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SAMPLING))
            {
                sprSampling.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //種類.
                    addrow.Column2 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }
                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprSampling.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprSampling.Columns[9].Visible = false;
                sprSampling.Columns[10].Visible = false;
                sprSampling.Columns[11].Visible = false;
                sprSampling.Columns[12].Visible = false;
            }

            #endregion サンプリング.

            #region インターネット.

            //インターネット.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.INTERNET))
            {
                sprInterNet.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //掲出.
                    addrow.Column2 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);

                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprInterNet.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprInterNet.Columns[9].Visible = false;
                sprInterNet.Columns[10].Visible = false;
                sprInterNet.Columns[11].Visible = false;
                sprInterNet.Columns[12].Visible = false;
            }

            #endregion インターネット.

            #region モバイル.

            //モバイル.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.MOBILE))
            {
                sprMobile.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //掲出.
                    addrow.Column2 = string.Empty;

                    //費目名.
                    //addrow.Column3 = row.Himokumei;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                        addrow.Column5 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }

                    //掲載期間.
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column7 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column8 = string.Empty;

                    //請求ブランド.
                    addrow.Column9 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column10 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }
                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column3 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column5 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprMobile.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprMobile.Columns[10].Visible = false;
                sprMobile.Columns[11].Visible = false;
                sprMobile.Columns[12].Visible = false;

            }

            #endregion モバイル.

            #region "事業費"

            //事業費の場合.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.JIGYOUHI))
            {
                //シートの表示.
                sprJigyouhi.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.
                double TeikaryoukinGoukei = 0;      //定価料金合計.
                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //種類.
                    addrow.Column2 = row.Syurui.Trim();

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }
                    //定価料金.
                    if (!string.IsNullOrEmpty(row.Teikaryokin.Trim()))
                    {
                        addrow.Column4 = double.Parse(row.Teikaryokin.Trim()).ToString("#,0");
                    }

                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //定価料金加算.
                    double tryTeika = 0;             //tryparse用.
                    double.TryParse(row.Teikaryokin.Trim(), out tryTeika);
                    TeikaryoukinGoukei = TeikaryoukinGoukei + tryTeika;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");

                //定価料金合計.
                TeikaryoukinGoukei = Math.Truncate(TeikaryoukinGoukei);
                Ryoukinrow.Column4 = TeikaryoukinGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                //スプレッドシートに反映.
                sprJigyouhi.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprJigyouhi.Columns[9].Visible = false;
                sprJigyouhi.Columns[10].Visible = false;
                sprJigyouhi.Columns[11].Visible = false;
                sprJigyouhi.Columns[12].Visible = false;

            }

            #endregion 事業費.

            #region その他.

            //その他.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SONOTA))
            {
                sprSonota.Visible = true;
                double MitumoriGoukei = 0;          //見積もり料金合計.

                foreach (RepDsLion.NewRepLionRow row in result.dsRepLionDataSet.NewRepLion.Select("", ""))
                {
                    //表示用DataRow
                    RepDsLion.NewRepLionDisplayRow addrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                    //商品名.
                    addrow.Column1 = row.Kenname.Trim();

                    //種類.
                    addrow.Column2 = string.Empty;

                    //見積もり料金.
                    if (!string.IsNullOrEmpty(row.Mitumoriryo.Trim()))
                    {
                        addrow.Column3 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                        addrow.Column4 = double.Parse(row.Mitumoriryo.Trim()).ToString("#,0");
                    }


                    //掲載期間.
                    addrow.Column5 = kikanHyouji(row.Kikan.Trim(),true);
                    addrow.Column6 = kikanHyouji(row.Kikan.Trim(),false);

                    //備考.
                    addrow.Column7 = string.Empty;

                    //請求ブランド.
                    addrow.Column8 = row.Seikyubrand.Trim();

                    //コード.
                    addrow.Column9 = row.Code.Trim();

                    //見積もり料金加算.
                    double tryMitumori = 0;        //tryparse用.
                    double.TryParse(row.Mitumoriryo.Trim(), out  tryMitumori);
                    MitumoriGoukei = MitumoriGoukei + tryMitumori;

                    //行を追加.
                    LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(addrow);
                }

                //見積もり料金合計、定価料金合計表示用ROW
                RepDsLion.NewRepLionDisplayRow Ryoukinrow = LionDs.NewRepLionDisplay.NewNewRepLionDisplayRow();

                //合計.
                Ryoukinrow.Column2 = "合計";

                //見積もり料金合計.
                MitumoriGoukei = Math.Truncate(MitumoriGoukei);
                Ryoukinrow.Column3 = MitumoriGoukei.ToString("#,0");
                Ryoukinrow.Column4 = MitumoriGoukei.ToString("#,0");

                //行を追加.
                LionDs.NewRepLionDisplay.AddNewRepLionDisplayRow(Ryoukinrow);

                sprSonota.DataSource = LionDs.NewRepLionDisplay;

                //*********************
                //列非表示.
                //*********************
                sprSonota.Columns[9].Visible = false;
                sprSonota.Columns[10].Visible = false;
                sprSonota.Columns[11].Visible = false;
                sprSonota.Columns[12].Visible = false;
            }

            #endregion その他.

            statusStrip1.Items["tslval1"].Text = (LionDs.NewRepLionDisplay.Rows.Count - TOTAL_AMOUNT_ROWS).ToString() + "件";

        }

        #endregion データ表示.

        #region スプレッド初期化.

        /// <summary>
        /// スプレッド初期化.
        /// </summary>
        private void SpredSyokika()
        {
            sprTvTime.Visible = false;
            sprTvspot.Visible = false;
            sprBscs.Visible = false;
            sprRadiotime.Visible = false;
            sprRadiospot.Visible = false;
            sprShinbun.Visible = false;
            sprZashi.Visible = false;
            sprKoutsu.Visible = false;
            sprTirashi.Visible = false;
            sprSampling.Visible = false;
            sprInterNet.Visible = false;
            sprMobile.Visible = false;
            sprJigyouhi.Visible = false;
            sprSonota.Visible = false;

            sprTvTime.RowCount = 0;
            sprTvspot.RowCount = 0;
            sprBscs.RowCount = 0;
            sprRadiotime.RowCount = 0;
            sprRadiospot.RowCount = 0;
            sprShinbun.RowCount = 0;
            sprZashi.RowCount = 0;
            sprKoutsu.RowCount = 0;
            sprTirashi.RowCount = 0;
            sprSampling.RowCount = 0;
            sprInterNet.RowCount = 0;
            sprMobile.RowCount = 0;
            sprJigyouhi.RowCount = 0;
            sprSonota.RowCount = 0;

            //***********************************
            //スプレッドシートのタブを非表示.
            //***********************************
            kkhSpread1.TabStripPolicy = TabStripPolicy.Never;
        }

        #endregion スプレッド初期化.

        #region 帳票出力設定.

        /// <summary>
        /// エクセルファイル出力の設定.
        /// </summary>
        private void excelFileSet()
        {
            //ファイル保存場所設定クラスのインスタンス化.
            SaveFileDialog sfd = new SaveFileDialog();

            //現在日時.
            DateTime nowdate = DateTime.Now;

            //初期ファイル名.
            //sfd.FileName = nowdate.ToString("yyyyMMdd") + _mStrRepFileMei + ".xls";
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD start */
            //sfd.FileName = _mStrRepFileMei + "_" +nowdate.ToString("yyyyMMdd") + ".xls";
            sfd.FileName = _mStrRepFileMei + "_" + nowdate.ToString("yyyyMMddHHmm") + ".xls";
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD end */

            //初期ファイル保存先.
            sfd.InitialDirectory = _mStrRepAdrs;

            //ファイル種類の選択肢を設定.
            sfd.Filter = "XLSファイル(*.xls)|*.xls";

            //初期ファイル種類の設定.
            //[すべてのファイル]を設定.
            sfd.FilterIndex = 0;

            //タイトルの設定.
            sfd.Title = "保存先のファイルを設定して下さい。";

            base.CloseLoadingDialog();

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示し、Okボタンが押下されたら.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                base.ShowLoadingDialog();
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する。.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "見積書", MessageBoxButtons.OK);

                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }
            //
            sfd.Dispose();
        }

        #endregion 帳票出力設定.

        #region 帳票出力.

        /// <summary>
        /// エクセル出力.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            //作業用フォルダパス.
            string workFolderPath = _mStrRepTempAdrs;
            string macrofile = workFolderPath + REP_MACRO_FILENAME;
            string tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            //テーブル追加用データRow.
            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macrofile, Isid.KKH.Lion.Properties.Resources.LionNewReport);
                File.WriteAllBytes(tempfile, Isid.KKH.Lion.Properties.Resources.Lion_NewReport_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("テンプレートExcelファイルがありません。"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("マクロExcelファイルがありません。"); }

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SHOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAICD", Type.GetType("System.String"));
                dtTable.Columns.Add("LASTDAY", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();
                dtRow["SAVEDIR"] = filenm;
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = dtpYyyyMmDd.Value.ToString("yyyyMM");
                //dtRow["SELHDK"] = udYYYY.Value.ToString() + _strMM;
                dtRow["SHOHIZEI"] = _mDblShohizei.ToString();

                //************************
                //前月の最終日を取得.
                //************************
                ////年を取得.
                //int intYYYY = int.Parse(dtpYyyyMmDd.Value.ToString().Substring(0, 4));
                ////int _intYYYY = int.Parse(udYYYY.Value.ToString());

                ////月を取得.
                //int intMM = int.Parse(dtpYyyyMmDd.Value.ToString().Substring(5, 2));
                ////int _intMM = int.Parse(udMM.Value.ToString());

                ////１月の場合年を1年前に戻す.
                //if (intMM == 1)
                //{
                //    intYYYY = intYYYY - 1;
                //    intMM = 12;
                //}
                //else
                //{
                //    intMM = intMM - 1;
                //}
                //int lastday = DateTime.DaysInMonth(intYYYY, intMM);
                //string stmm = string.Empty;
                //if (intMM.ToString().Length == 1)
                //{
                //    stmm = "0" + intMM.ToString();
                //}
                //else
                //{
                //    stmm = intMM.ToString();
                //}
                //dtRow["LASTDAY"] = intYYYY.ToString() + stmm + lastday.ToString();

                DateTime dtTmp = new DateTime(int.Parse(dtpYyyyMmDd.Value.ToString().Substring(0, 4)),
                                int.Parse(dtpYyyyMmDd.Value.ToString().Substring(5, 2)),
                                1,
                                0,
                                0,
                                0);
                dtRow["LASTDAY"] = dtTmp.AddDays(-1);
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //dtRow["BAITAICD"] = cmbBaitai.SelectedValue.ToString();
                //インターネット.
                HyousiSelect(KKHLionConst.BaitaiCd.INTERNET);
                //チラシ.
                HyousiSelect(KKHLionConst.BaitaiCd.TIRASHI);
                //サンプリング.
                HyousiSelect(KKHLionConst.BaitaiCd.SAMPLING);
                //事業費.
                HyousiSelect(KKHLionConst.BaitaiCd.JIGYOUHI);
                //その他.
                HyousiSelect(KKHLionConst.BaitaiCd.SONOTA);

                /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL start */
                //※合計は未使用のため削除.
                ////全媒体が選択された時表紙を出す。.
                //ReportLionProcessController.FindNewReportLionParam param = new ReportLionProcessController.FindNewReportLionParam();
                //param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                //param.egCd = _naviParam.strEgcd;
                //param.tksKgyCd = _naviParam.strTksKgyCd;
                //param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                //param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                //param.yymm = dtpYyyyMmDd.Value.ToString("yyyyMM");
                //param.baitaiCd = "900";
                //ReportLionProcessController processController = ReportLionProcessController.GetInstance();
                //FindReportLionByCondServiceResult Hyousiresult = processController.FindReportNewLionByCond(param);
                //if (Hyousiresult.HasError)
                //{
                //    return;
                //}

                ////取得した合計額をデータセットに設定する。.
                //foreach (RepDsLion.NewRepLionRow HyosiRow in (RepDsLion.NewRepLionRow[])Hyousiresult.dsRepLionDataSet.NewRepLion.Select("", ""))
                //{
                //    if (HyosiRow.Baitaicd.Trim().Equals("006")
                //        || HyosiRow.Baitaicd.Trim().Equals("011")
                //        || HyosiRow.Baitaicd.Trim().Equals("012")
                //        || HyosiRow.Baitaicd.Trim().Equals("013"))
                //    {
                //    }
                //    else
                //    {
                //        RepDsLion.GoukeiGakRow addrow = LionDs.GoukeiGak.NewGoukeiGakRow();

                //        addrow.BaitaiCd = HyosiRow.Baitaicd.Trim();
                //        if (string.IsNullOrEmpty(HyosiRow.SUMSEIGAK.Trim()))
                //        {
                //            addrow.SumSeiGak = string.Empty;
                //        }
                //        else
                //        {
                //            addrow.SumSeiGak = HyosiRow.SUMSEIGAK.Trim();
                //        }
                //        if (string.IsNullOrEmpty(HyosiRow.SUMSZEIGAK.Trim()))
                //        {
                //            addrow.SumSzeiGak = string.Empty;
                //        }
                //        else
                //        {
                //            addrow.SumSzeiGak = HyosiRow.SUMSZEIGAK.Trim();
                //        }

                //        addrow.BaitaikoCd = HyosiRow.BaitaikoCd.Trim();
                //        LionDs.GoukeiGak.AddGoukeiGakRow(addrow);
                //    }
                //}
                //LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_Goukei.xml"));
                /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL end */

                /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
                //ADブランドマスタから通販のブランドを抽出するための文字列を作成.
                string strWhere = string.Empty;
                DataRow[] row = dtBrand.Select("MOKBN = TRUE");

                for (int i = 0; i < dtBrand.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        strWhere += ", ";
                    }

                    strWhere += "'" + row[i]["BRDCD"].ToString() + "'";
                }
                
                //テレビタイム.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TV_TIME, strWhere);
                //テレビスポット.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TV_SPOT, strWhere);
                //BSCS.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.BSCS, strWhere);
                //ラジオタイム.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.RADIO_TIME, strWhere);
                //ラジオスポット.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.RADIO_SPOT, strWhere);
                //新聞.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SHINBUN, strWhere);
                //雑誌.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.ZASHI, strWhere);
                //交通.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.KOUTSU, strWhere);
                //チラシ.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TIRASHI, strWhere);
                //サンプリング.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SAMPLING, strWhere);
                //インターネット.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.INTERNET, strWhere);
                //モバイル.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.MOBILE, strWhere);
                //事業費.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.JIGYOUHI, strWhere);
                //その他.
                XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SONOTA, strWhere);

                ////テレビタイム.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TV_TIME);
                ////テレビスポット.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TV_SPOT);
                ////BSCS.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.BSCS);
                ////ラジオタイム.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.RADIO_TIME);
                ////ラジオスポット.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.RADIO_SPOT);
                ////新聞.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SHINBUN);
                ////雑誌.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.ZASHI);
                ////交通.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.KOUTSU);
                ////チラシ.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.TIRASHI);
                ////サンプリング.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SAMPLING);
                ////インターネット.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.INTERNET);
                ////モバイル.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.MOBILE);
                ////事業費.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.JIGYOUHI);
                ////その他.
                //XmlDataSyutuRyoku(KKHLionConst.BaitaiCd.SONOTA);
                /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD end */

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _mStrMacroDel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力.
                KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_NewReport, KKHLogUtilityLion.DESC_OPERATION_LOG_NEWREPORT);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion 帳票出力.

        #region 期間表示設定.

        /// <summary>
        /// 期間の表示形式.
        /// </summary>
        /// <param name="MRyymm"></param>
        /// <returns></returns>
        private string kikanHyouji(string MRyymm)
        {
            if (MRyymm.Length == 8)
            {
                return MRyymm.Substring(0, 4) + "/" + MRyymm.Substring(4, 2) + "/" + MRyymm.Substring(6, 2);
            }

            //文字数が16のものしか変更しない.
            if (MRyymm.Length != 16) { return MRyymm; }

            string stYy = MRyymm.Substring(0, 4);
            string stMm = MRyymm.Substring(4, 2);
            string stDd = MRyymm.Substring(6, 2);
            string edYy = MRyymm.Substring(8, 4);
            string edMm = MRyymm.Substring(12, 2);
            string edDd = MRyymm.Substring(14);

            return stYy + "/" + stMm + "/" + stDd + "-" + edYy + "/" + edMm + "/" + edDd;
        }

        /// <summary>
        /// 期間の表示形式.
        /// </summary>
        /// <param name="MRyymm"></param>
        /// <param name="fDate">true:期間From false:期間To</param>
        /// <returns></returns>
        private string kikanHyouji(string MRyymm, Boolean fDate)
        {
            //文字数が8桁.
            if (MRyymm.Length == 8)
            {
                //日付の妥当性チェック.
                if (KKHUtility.IsDate(MRyymm, "yyyyMMdd"))
                {
                    if (fDate)
                    {
                        //From
                        return KKHUtility.StringCnvDateTime(MRyymm.Substring(0, 8)).ToString("M/d");
                    }
                    else
                    {
                        //To
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }

            //文字数は16桁のみ.
            if (MRyymm.Length != 16) { return string.Empty; }

            //日付の妥当性チェック.
            if (!KKHUtility.IsDate(MRyymm.Substring(0, 8), "yyyyMMdd") ||
                !KKHUtility.IsDate(MRyymm.Substring(8, 8), "yyyyMMdd"))
            {
                return string.Empty;
            }

            if (fDate)
            {
                //From
                return KKHUtility.StringCnvDateTime(MRyymm.Substring(0, 8)).ToString("M/d");
            }
            else
            {
                //To
                return KKHUtility.StringCnvDateTime(MRyymm.Substring(8, 8)).ToString("M/d");
            }
        }

        #endregion 期間表示設定.

        #region 表紙選択.

        /// <summary>
        /// 表紙が選択された時.
        /// </summary>
        /// <param name="baitai"></param>
        private void HyousiSelect(string baitai)
        {
            string workFolderPath = _mStrRepTempAdrs;
            //パラメーター.
            ReportLionProcessController.FindNewReportLionParam param = new ReportLionProcessController.FindNewReportLionParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = dtpYyyyMmDd.Value.ToString("yyyyMM");
            param.baitaiCd = baitai;

            //*******************.
            //サービスの呼び出し.
            //*******************.
            ReportLionProcessController processController = ReportLionProcessController.GetInstance();
            FindReportLionByCondServiceResult result = processController.FindReportNewLionByCond(param);
            if (result.HasError)
            {
                return;
            }

            LionDs.NewRepLion.Clear();
            LionDs.GoukeiGak.Clear();
            foreach (RepDsLion.NewRepLionRow row in (RepDsLion.NewRepLionRow[])result.dsRepLionDataSet.NewRepLion.Select("", ""))
            {
                RepDsLion.NewRepLionRow addrow = LionDs.NewRepLion.NewNewRepLionRow();
                //件名.
                addrow.Kenname  = row.Kenname.Trim();
                //宣伝費.
                addrow.SUMSEIGAK = row.Mitumoriryo.Trim();
                //消費税率.
                addrow.ShohizeiRitu = row.ShohizeiRitu.Trim();
                //消費税.
                addrow.SUMSZEIGAK = row.Szeigak.Trim();

                LionDs.NewRepLion.AddNewRepLionRow(addrow);
            }

            //出力媒体を決める。.
            if (baitai.Equals(KKHLionConst.BaitaiCd.INTERNET))
            {
                LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_INTERNET.xml"));
            }
            else if (baitai.Equals(KKHLionConst.BaitaiCd.TIRASHI))
            {
                LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_TIRASHI.xml"));
            }
            else if (baitai.Equals(KKHLionConst.BaitaiCd.SAMPLING))
            {
                LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_SAMPLING.xml"));
            }
            else if (baitai.Equals(KKHLionConst.BaitaiCd.JIGYOUHI))
            {
                LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_JIGYOUHI.xml"));
            }
            else if (baitai.Equals(KKHLionConst.BaitaiCd.SONOTA))
            {
                LionDs.WriteXml(Path.Combine(workFolderPath, "Lion_SONOTA.xml"));
            }
        }

        #endregion 表紙出力.

        #region XMLデータ出力.

        /// <summary>
        /// Xmlデータセット出力.
        /// </summary>
        /// <param name="baitaiCd">媒体区分</param>
        /// <param name="filter">検索用フィルタ文字列</param>
        private void XmlDataSyutuRyoku(string baitaiCd, String filter)
        {
            string workFolderPath = _mStrRepTempAdrs;

            ReportLionProcessController.FindNewReportLionParam param = new ReportLionProcessController.FindNewReportLionParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = dtpYyyyMmDd.Value.ToString("yyyyMM");
            param.baitaiCd = baitaiCd;
            ReportLionProcessController processController = ReportLionProcessController.GetInstance();
            FindReportLionByCondServiceResult result = processController.FindReportNewLionByCond(param);
            if (result.HasError)
            {
                return;
            }
            LionDs.RepLion.Clear();
            LionDs.RepLionSyohiZei.Clear();
            LionDs.BaitaiCdName.Clear();
            LionDs.GoukeiGak.Clear();
            LionDs.NewRepLion.Clear();

            LionDs.NewRepLion.Merge(result.dsRepLionDataSet.NewRepLion);

            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD start */
            //通販、通販以外用にクローンデータテーブル作成.
            DataTable dtWIMO = new DataTable("DataTable1");
            DataTable dtWOMO = new DataTable("DataTable2");

            //クローンデータテーブルにコピー.
            dtWIMO = LionDs.NewRepLion.Copy();
            dtWOMO = LionDs.NewRepLion.Copy();

            //媒体ごとにXML出力.
            //テレビタイム.
            if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TV_TIME))
            {
                ////クローンデータテーブルから合致するレコードを削除.
                //DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                //DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                ////件数≠0の場合、XML出力.
                ////通販.
                //if (dtWIMO.Rows.Count != 0)
                //{
                //    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TT_WIMO));
                //}
                ////通販以外.
                //if (dtWOMO.Rows.Count != 0)
                //{
                //    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TT_WOMO));
                //}
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_TT));
                }
            }
            //テレビスポット.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TV_SPOT))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TS_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TS_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_TS));
                }
            }
            //BS/CS
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.BSCS))
            {
                ////クローンデータテーブルから合致するレコードを削除.
                //DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                //DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                ////件数≠0の場合、XML出力.
                ////通販.
                //if (dtWIMO.Rows.Count != 0)
                //{
                //    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_BS_WIMO));
                //}
                ////通販以外.
                //if (dtWOMO.Rows.Count != 0)
                //{
                //    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_BS_WOMO));
                //}
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_BS));
                }
            }
            //ラジオタイム.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.RADIO_TIME))
            {
                ////クローンデータテーブルから合致するレコードを削除.
                //DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                //DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                ////件数≠0の場合、XML出力.
                ////通販.
                //if (dtWIMO.Rows.Count != 0)
                //{
                //    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_RT_WIMO));
                //}
                ////通販以外.
                //if (dtWOMO.Rows.Count != 0)
                //{
                //    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_RT_WOMO));
                //}
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_RT));
                }
            }
            //ラジオスポット.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.RADIO_SPOT))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_RS_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_RS_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_RS));
                }
            }
            //新聞.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SHINBUN))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_NP_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_NP_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_NP));
                }
            }
            //雑誌.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.ZASHI))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_MZ_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_MZ_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_MZ));
                }
            }
            //交通.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.KOUTSU))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TF_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TF_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_TF));
                }
            }
            //チラシ.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.TIRASHI))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TI_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_TI_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_TI));
                }
            }
            //サンプリング.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SAMPLING))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_SA_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_SA_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_SA));
                }
            }
            //インターネット.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.INTERNET))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_IN_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_IN_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_IN));
                }
            }
            //モバイル.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.MOBILE))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_MO_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_MO_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_MO));
                }
            }
            //事業費.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.JIGYOUHI))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_JI_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_JI_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_JI));
                }
            }
            //その他.
            else if (baitaiCd.Equals(KKHLionConst.BaitaiCd.SONOTA))
            {
                //クローンデータテーブルから合致するレコードを削除.
                DeleteSelectRows(dtWIMO, "Code NOT IN ( " + filter + ")");
                DeleteSelectRows(dtWOMO, "Code IN (" + filter + ")");

                //件数≠0の場合、XML出力.
                //通販.
                if (dtWIMO.Rows.Count != 0)
                {
                    dtWIMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_OT_WIMO));
                }
                //通販以外.
                if (dtWOMO.Rows.Count != 0)
                {
                    dtWOMO.WriteXml(Path.Combine(workFolderPath, XML_FILE_OT_WOMO));
                }
                //通販＋通販以外.
                if (dtWIMO.Rows.Count != 0 && dtWOMO.Rows.Count != 0)
                {
                    LionDs.NewRepLion.WriteXml(Path.Combine(workFolderPath, XML_FILE_OT));
                }
            }
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD end */
        }

        #endregion XMLデータ出力.

        #region マスタ取得(ADブランドマスタ).

        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
        /// <summary>
        /// ADブランドマスタデータ取得.
        /// </summary>
        private void GetAdBrand()
        {
            KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController processController = 
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();

            //データ取得.
            FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(_naviParam.strEsqId
                                                                                                , _naviParam.strEgcd
                                                                                                , _naviParam.strTksKgyCd
                                                                                                , _naviParam.strTksBmnSeqNo
                                                                                                , _naviParam.strTksTntSeqNo
                                                                                                , KKHLionConst.C_MAST_BRAND_CD
                                                                                                , "");

            //ADブランドマスタデータテーブル編集.
            //ブランドコード.
            dtBrand.Columns.Add("BRDCD", Type.GetType("System.String"));
            //商品名.
            dtBrand.Columns.Add("PRDNM", Type.GetType("System.String"));
            //商品記号.
            dtBrand.Columns.Add("PRDCD", Type.GetType("System.String"));
            //ジャンルコード.
            dtBrand.Columns.Add("GNLCD", Type.GetType("System.String"));
            //事業部.
            dtBrand.Columns.Add("JGYCD", Type.GetType("System.String"));
            //通販区分.
            dtBrand.Columns.Add("MOKBN", Type.GetType("System.String"));

            foreach (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                if (row.Column6.ToUpper().Equals("TRUE"))
                {
                    dtBrand.Rows.Add(row.Column1, row.Column2, row.Column3, row.Column4, row.Column5, row.Column6.ToUpper());
                }
            }
        }
        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

        #endregion マスタ取得(ADブランドマスタ).

        #region データテーブルから合致するレコードを削除.

        /// <summary>
        /// 条件に合致数レコードをDataTableから削除.
        /// </summary>
        /// <param name="dt">データテーブル</param>
        /// <param name="filter">条件</param>
        /// <returns>0:正常終了 -1:異常終了</returns>
        public static int DeleteSelectRows(DataTable dt, string filter)
        {
            try
            {
                DataRow[] rows = dt.Select(filter);

                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].RowState != DataRowState.Deleted)
                    {
                        rows[i].Delete();
                    }
                }
                dt.AcceptChanges();
                return 0;
            }
            catch (Exception)
            {
                dt.RejectChanges();
                return -1;
            }
        }

        #endregion データテーブルから合致するレコードを削除.

        #endregion メソッド.
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
using Isid.KKH.Common.KKHUtility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// 媒体別帳票画面.
    /// </summary>
    public partial class ReportAshByMedium : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数.
        #region 局コード.
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string KYKCD_SHINBN = "202";
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string KYKCD_ZASHI = "203";
        /// <summary>
        /// テレビタイム、スポット.
        /// </summary>
        public const string KYKCD_TV = "204";
        /// <summary>
        /// ラジオタイム、スポット.
        /// </summary>
        public const string KYKCD_RADIO = "205";
        /// <summary>
        /// 屋外広告、イベント.
        /// </summary>
        public const string KYKCD_KOEVE = "217";
        /// <summary>
        /// 制作.
        /// </summary>
        public const string KYKCD_SEISAK = "216";
        /* 2013/02/22 PR媒体追加対応 JSE Okazaki ADD Start */
        /// <summary>
        /// PR.
        /// </summary>
        public const string KYKCD_PR = "221";
        /* 2013/02/22 PR媒体追加対応 JSE Okazaki ADD End */
        /// <summary>
        /// その他､ニューメディア､インターネット､BS､CS.
        /// </summary>
        public const string KYKCD_SONOTA = "218";
        /// <summary>
        /// 交通.
        /// </summary>
        public const string KYKCD_OOH = "206";
        /// <summary>
        /// メディアフィー.
        /// </summary>
        public const string KYKCD_MEDIAFEE = "219";
        /// <summary>
        /// ブランド管理フィー.
        /// </summary>
        public const string KYKCD_BLAND = "220";
        #endregion 局コード.

        #region 帳票.
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_Medium.xlsm";
        private static readonly string REP_MACRO_FILENAME_BEER = "AshBeer_Medium.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロテンプレート)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_Medium_Template.xlsx";
        private static readonly string REP_TEMPLATE_FILENAME_BEER = "AshBeer_Medium_Template.xlsx";
        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_Medium_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_Medium_Prop.xml";
        #endregion 帳票.

        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD Start */
        #region 固定文言.
        /// <summary>
        /// 得意先コード(アサヒ飲料).
        /// </summary>
        public const string TOKUISAKI_CODE_INRYOU = "285147";
        /// <summary>
        /// 得意先コード(アサヒビール).
        /// </summary>
        public const string TOKUISAKI_CODE_BEER = "016802";
        #endregion 固定文言.
        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD End */
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 媒体区分用データテーブル.
        /// </summary>
        private RepDsAsh.BaiCdDataTable bct = new RepDsAsh.BaiCdDataTable();
        /// <summary>
        /// 商品マスタデータテーブル.
        /// </summary>
        private RepDsAsh.SyohinDataTable sdt = new RepDsAsh.SyohinDataTable();
        /// <summary>
        /// 年月.
        /// </summary>
        string _yearMonth = string.Empty;
        /// <summary>
        /// 媒体判断用.
        /// </summary>
        int baikbn = 0;
        /// <summary>
        /// コンボ選択媒体名格納.
        /// </summary>
        string baitaiName = string.Empty;
        /// <summary>
        /// 保管用データセット.
        /// </summary>
        private RepDsAsh repds = new RepDsAsh();
        /// <summary>
        /// 削除用データセット.
        /// </summary>
        private RepDsAsh tableToDel = new RepDsAsh();
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 消費税.
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// コピーマクロ削除用string.
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// 媒体確認用.
        /// </summary>
        Dictionary<string, int> _dicBaitai;
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportAshByMedium()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 画面遷移時に発生.
        /// <summary>
        /// 画面遷移時に発生.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAshByMedium_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }
        #endregion 画面遷移時に発生.

        #region フォームロード時.
        /// <summary>
        /// フォームロード時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshByMedium_Shown(object sender, EventArgs e)
        {
            //ローディング表示.
            base.ShowLoadingDialog();

            //編集.
            EditControl();

            //データ取得.
            MediaCdGet();

            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //消費税セット.
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }


            //保存情報 + 帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "001");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //ローディング非表示.
            base.CloseLoadingDialog();
        }
        #endregion フォームロード時.

        #region 戻るボタンクリック.
        /// <summary>
        /// 戻るボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                //マクロファイルの削除(VBA側では削除できない為).
                //ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    //読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    //ファイルを削除する.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }
        #endregion 戻るボタンクリック.

        #region 検索ボタンクリック.
        /// <summary>
        /// 検索ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //XMLデータセットクリア.
            repds.Clear();

            //表示.
            DisplayView();
            this.ActiveControl = null;
        }
        #endregion 表示ボタンクリック.

        #region Excelボタンクリック.
        /// <summary>
        /// Excelボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //Excel作成用データ格納.
            excelDataSet();
            this.ActiveControl = null;
        }
        #endregion Excelボタンクリック.

        #region ヘルプボタンクリック処理.
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
            this.ActiveControl = null;
        }
        #endregion ヘルプボタンクリック処理.

        #region 年月コンボボックスアクティブ.
        /// <summary>
        /// 年月コンボボックスアクティブ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }
        #endregion 年月コンボボックスアクティブ.
        #endregion イベント.

        #region メソッド.
        #region コンボボックスの設定.
        /// <summary>
        /// コンボボックスの設定.
        /// </summary>
        private void cmbSet()
        {
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki DEL Start */
            //string[] item ={KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //string[] item = null;
            ////得意先がアサヒビールの場合 
            //if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
            //{
            //    //媒体マスタから名称を取得(最後にSUM_BAITAI,ALL_BAITAI追加).
            //    item = new string[]
            //    {KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.PR,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //}
            //else
            //{
            //    //媒体マスタから名称を取得(最後にSUM_BAITAI,ALL_BAITAI追加).
            //    item = new string[]
            //    {KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //}
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki DEL End */

            /* 2013/02/22 アサヒ対応 Miyanoue ADD Start */
            //コンボボックスの生成.
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);

            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiNm, resultList[i].baitaiCd);
            }
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SUM_BAITAI, KkhConstAsh.BaitaiCd.GOKEI);
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            cmbMedia.DataSource = SybtNameTable;
            cmbMedia.DisplayMember = "Display";
            cmbMedia.ValueMember = "Value";
            cmbMedia.SelectedValue = KkhConstAsh.BaitaiCd.ALL_BAITAI;
            /* 2013/02/22 アサヒ対応 Miyanoue ADD End */
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki DEL Start */
            //初期値は全媒体.
            ////cmbMedia.SelectedIndex = 19;
            //初期値は全媒体.
            //cmbMedia.SelectedIndex = cmbMedia.Items.Count - 1;
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki DEL Start */
        }
        #endregion コンボボックスの設定.

        #region 各コントロール編集.
        /// <summary>
        /// 各コントロール編集.
        /// </summary>
        private void EditControl()
        {
            //年月の取得.
            String hostDate = "";
            hostDate = getHostDate();
            if (hostDate != "")
            {
                hostDate = hostDate.Trim().Replace("/", "");
                if (hostDate.Trim().Length >= 6)
                {
                    txtYm.Value = hostDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = hostDate;
                }
                txtYm.cmbYM_SetDate();
            }

            //ステータスの設定.
            txtYm.Value = hostDate.Substring(0, 6);
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //コンボ設定.
            cmbSet();
        }
        #endregion 各コントロール編集.

        #region 営業日取得.
        /// <summary>
        /// 営業日取得.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }
        #endregion 営業日取得.

        #region データ表示.
        /// <summary>
        /// データ表示.
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //媒体コード.
            RepDsAsh.BaiCdRow[] drBaitaiCode = (RepDsAsh.BaiCdRow[])bct.Select("", "");
            //商品.
            RepDsAsh.SyohinRow[] drSyohin = (RepDsAsh.SyohinRow[])sdt.Select("", "");

            /*
             * 初期設定.
             */
            //媒体コード用.
            string strBaitaiCd = string.Empty;
            //受注明細No(保持用).
            string strJyuchuMeisaiNoHoji = string.Empty;
            //小計用.
            double dblSyoukei = 0;
            //非課税. 
            double dblHikazei = 0;
            //金額合計.
            double dblGoukei = 0;
            //小計(保持用).
            double dblSupposeSyoukei = 0;
            //年月のセット.
            _yearMonth = txtYm.Value;
            int intCnt = 0;
            //件数.
            int intKensu = 0;
            //媒体件数.
            int intBaitaiKensu = 0;
            /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
            //小計金額.
            double dblAmount = 0;
            ///* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
            //消費税(保持用).
            //double dblSupposeSyohizei = 0;
            //List<double> lstZeiRate = new List<double>();
            //List<double> lstAmount = new List<double>();
            //double dblMediaTaxSumFromRows = 0;
            //int intListIndex = 0;
            ///* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
            /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD End */
            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL Start */
            ////端数調整額格納用.
            //double dblTyousei = 0;
            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL End */

            /*
             * パラメータのセット.
             */
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = _yearMonth;

            /*
             * 検索.
             */
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMedia(param);
            //エラーの場合.
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }
            RepDsAsh.RepAshMediaRow[] resultRow = (RepDsAsh.RepAshMediaRow[])result.dsAshDataSet.RepAshMedia.Select("", "");
            //検索結果が0件の場合.
            if (resultRow.Length == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = resultRow.Length.ToString() + "件";
                btnXls.Enabled = false;
                cmbMedia.Enabled = false;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            /*
             * データセットのインスタンス生成.
             */
            RepDsAsh dsash = new RepDsAsh();
            RepDsAsh.displayMediaRow drNewDispMedia = dsash.displayMedia.NewdisplayMediaRow();
            drNewDispMedia = syokirowSet(drNewDispMedia);
            //媒体確認用.
            _dicBaitai = new Dictionary<string, int>();
            /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
            // 媒体マスタから取得.
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */

            //取得した媒体別帳票情報分ループ処理.
            foreach (RepDsAsh.RepAshMediaRow row in resultRow)
            {
                //初期設定.
                string strClcResult1 = string.Empty;
                string strClcResult2 = string.Empty;
                //表示用データRow.
                RepDsAsh.displayMediaRow drDispMedia = dsash.displayMedia.NewdisplayMediaRow();
                //表示用(合計用)データRow.
                RepDsAsh.displayMediaRow drDispMediaGoukei = dsash.displayMedia.NewdisplayMediaRow();
                //表示用(小計用)データRow.
                RepDsAsh.displayMediaRow drDispMediaSyoukei = dsash.displayMedia.NewdisplayMediaRow();

                //データRow初期セット.
                drDispMedia = syokirowSet(drDispMedia);

                //1回目のループ時の場合.
                if (intCnt == 0)
                {
                    //媒体コード保持.
                    strBaitaiCd = row.code1;
                }
                //媒体コードと媒体件数を保持.
                if (!_dicBaitai.ContainsKey(strBaitaiCd))
                {
                    intBaitaiKensu++;
                    _dicBaitai.Add(strBaitaiCd, intBaitaiKensu);
                }

                /*
                 * 小計(前回の媒体コードと違う場合).
                 */
                if (strBaitaiCd != row.code1.Trim())
                {
                    //表示用データRow.
                    drDispMedia = syokirowSet(drDispMedia);
                    //表示用（合計用）データRow.
                    drDispMediaGoukei = syokirowSet(drDispMediaGoukei);
                    //表示用(小計用)データRow.
                    drDispMediaSyoukei = syokirowSet(drDispMediaSyoukei);
                    //受注明細No保持用を初期化.  
                    strJyuchuMeisaiNoHoji = string.Empty;
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL Start */
                    //double dblSumTax = 0;
                    //double dblSumTax2 = 0;
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL End */

                    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                    #region 端数調整額処理(削除).
                    ///* 2013/12/04 消費税対応 HLC H.Watabe MOD Start */
                    ////RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();
                    ////dblTyousei = dblSyoukei - dblHikazei;
                    ////dblTyousei = dblTyousei * 1.05;
                    ////dblTyousei = dblTyousei * dblSupposeSyohizei;
                    ////dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
                    ////dblTyousei = ToHalfAdjust(dblTyousei, 0);
                    ////double dblSumTax2 = ToHalfAdjust(dblTyousei, 0) + dblSupposeSyoukei;
                    //RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();
                    //double dblSumTax = 0;
                    //for (int index = 0; index < lstZeiRate.Count; index++)
                    //{
                    //    /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD Start */
                    //    dblSumTax += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    //アサヒ飲料の場合.
                    //    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                    //    {
                    //        dblSumTax += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    }
                    //    //アサヒビールの場合.
                    //    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                    //    {
                    //        dblSumTax += Math.Round((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    }
                    //    /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD End */
                    //}
                    ////dblTyousei = dblSyoukei - dblHikazei;
                    ////dblTyousei = dblTyousei * 1.05;
                    ////dblTyousei = dblTyousei * dblSupposeSyohizei;
                    ////dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
                    ////dblTyousei = ToHalfAdjust(dblTyousei, 0);
                    //dblTyousei = dblSumTax - dblMediaTaxSumFromRows;
                    //double dblSumTax2 = dblSumTax;
                    ////int goukeikingak = (int)ToHalfAdjust(dblSumTax2, 1);
                    ///* 2013/12/04 消費税対応 HLC H.Watabe MOD End */
                    #endregion 端数調整額処理(削除).

                    //媒体情報(保持用)の取得.
                    RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();

                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL Start */
                    ////各媒体の明細件数分ループ処理.
                    //for (int index = 0; index < lstZeiRate.Count; index++)
                    //{
                    //    //小計金額.
                    //    dblSumTax += lstAmount[index];
                    //}
                    //dblSumTax2 = dblSumTax;
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL End */
                    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */

                    //局コード.
                    drDispMediaSyoukei.kyoku = KKHSystemConst.KoteiMongon.SYOKEI;
                    //媒体コード.
                    drDispMediaSyoukei.baitaiCd = strBaitaiCd + "3";
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                    //小計金額.
                    //drDispMediaSyoukei.kingak = dblSumTax2.ToString();
                    drDispMediaSyoukei.kingak = dblAmount.ToString();
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                    /*
                     * XML用.
                     */
                    //媒体コード.
                    drAllBaitai.baitaicd = strBaitaiCd;
                    //税なし金額.
                    drAllBaitai.zeinasi = dblSyoukei.ToString();
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                    //合計金額.
                    //drAllBaitai.goukei = dblSumTax2.ToString();
                    drAllBaitai.goukei = dblAmount.ToString();
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                    //挿入.
                    repds.allbaitai.AddallbaitaiRow(drAllBaitai);

                    /*
                     * 初期化.
                     */
                    //小計初期化.
                    dblSyoukei = 0;
                    //非課税初期化.
                    dblHikazei = 0;
                    //小計(保持用)初期化.
                    dblSupposeSyoukei = 0;
                    /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                    dsash.displayMedia.AdddisplayMediaRow(drDispMediaSyoukei);
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                    //小計金額用リスト初期化.
                    dblAmount = 0;
                    //媒体合計初期化.
                    //dblMediaTaxSumFromRows = 0;
                    //消費税用リスト初期化.
                    //lstZeiRate.Clear();
                    //lstAmount.Clear();
                    /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga MOD End */
                    /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
                    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL Start */
                    ////端数調整を税金、合計金額に反映させる.
                    //double num = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei.ToString());
                    //num = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak.ToString());
                    //dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei = num.ToString();
                    //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak = num.ToString();
                    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL End */
                }

                /*
                 * 共通処理.
                 */
                //件名 .
                drDispMedia.kenName = row.kkNameKj;

                //値引.
                drDispMedia.nebiki = row.seiGak;

                /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                //小計格納リストの作成.
                switch (row.code1.Trim())
                {
                    //テレビタイム、ラジオタイム、BS、CS、メディアフィー、ブランドフィー、テレビネットスポットの場合.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    case KkhConstAsh.BaitaiCd.BS:
                    case KkhConstAsh.BaitaiCd.CS:
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                    /* 2015/06/08 アサヒ対応 HLC H.Fujisaki ADD End */
                        //NAME33でフィルタを行う.
                        string filter = "NAME33 = '" + row.name33 + "'";
                        RepDsAsh.RepAshMediaTempRow[] resultRow2 = (RepDsAsh.RepAshMediaTempRow[])result.dsAshDataSet.RepAshMediaTemp.Select(filter);
                        foreach (RepDsAsh.RepAshMediaTempRow rows in resultRow2)
                        {
                            //小計金額.
                            dblAmount += double.Parse(rows.seiGak) + double.Parse(rows.kngk1);
                            #region 小計金額(削除).
                            //if (lstZeiRate.Count != 0)
                            //{
                            //    bool rateGetFlg = false;
                            //    //消費税リストと比較.
                            //    for (intListIndex = 0; intListIndex < lstZeiRate.Count; intListIndex++)
                            //    {
                            //        if (lstZeiRate[intListIndex] == double.Parse(rows.ritu1.Trim()))
                            //        {
                            //            rateGetFlg = true;
                            //            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                            //            //小計金額(請求金額 + 消費税).
                            //            //lstAmount[intListIndex] += double.Parse(rows.seiGak);
                            //            lstAmount[intListIndex] += double.Parse(rows.seiGak) + double.Parse(rows.kngk1);
                            //            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                            //            break;
                            //        }
                            //    }
                            //    //無い場合は追加.
                            //    if (rateGetFlg == false)
                            //    {
                            //        lstZeiRate.Add(double.Parse(rows.ritu1.Trim()));
                            //        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                            //        //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                            //        //小計金額(請求金額 + 消費税).
                            //        lstAmount.Add(double.Parse((row.seiGak) + double.Parse((row.kngk1))));
                            //        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                            //        intListIndex = lstZeiRate.Count - 1;
                            //    }
                            //}
                            //else
                            //{
                            //    lstZeiRate.Add(double.Parse(rows.ritu1.Trim()));
                            //    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                            //    //lstAmount.Add(double.Parse(rows.seiGak.Trim()));
                            //    //小計金額(請求金額 + 消費税).
                            //    lstAmount.Add(double.Parse(rows.seiGak) + double.Parse(rows.kngk1));
                            //    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                            //    intListIndex = lstZeiRate.Count - 1;
                            //}
                            #endregion 小計金額(削除).
                        }
                        break;
                    //テレビタイム、ラジオタイム、BS、CS、メディアフィー、ブランドフィー、テレビネットスポット以外の場合.
                    default:
                        //小計金額.
                        dblAmount += double.Parse(row.seiGak) + double.Parse(row.kngk1);
                        #region 小計金額(削除).
                        //if (lstZeiRate.Count != 0)
                        //{
                        //    bool rateGetFlg = false;
                        //    //消費税リストと比較.
                        //    for (intListIndex = 0; intListIndex < lstZeiRate.Count; intListIndex++)
                        //    {
                        //        if (lstZeiRate[intListIndex] == double.Parse(row.ritu1.Trim()))
                        //        {
                        //            rateGetFlg = true;
                        //            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                        //            //小計金額(請求金額 + 消費税).
                        //            //lstAmount[intListIndex] += double.Parse(row.seiGak.Trim());
                        //            lstAmount[intListIndex] += double.Parse(row.seiGak) + double.Parse(row.kngk1);
                        //            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                        //            break;
                        //        }
                        //    }
                        //    //無い場合は追加.
                        //    if (rateGetFlg == false)
                        //    {
                        //        lstZeiRate.Add(double.Parse(row.ritu1.Trim()));
                        //        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                        //        //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                        //        //小計金額(請求金額 + 消費税).
                        //        lstAmount.Add(double.Parse((row.seiGak) + double.Parse((row.kngk1))));
                        //        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                        //        intListIndex = lstZeiRate.Count - 1;
                        //    }
                        //}
                        //else
                        //{
                        //    lstZeiRate.Add(double.Parse(row.ritu1.Trim()));
                        //    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                        //    //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                        //    //小計金額(請求金額 + 消費税).
                        //    lstAmount.Add(double.Parse(row.seiGak) + double.Parse(row.kngk1));
                        //    /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */
                        //    intListIndex = lstZeiRate.Count - 1;
                        //}
                        #endregion 小計金額(削除).
                        break;
                }
                /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */

                //消費税率.
                drDispMedia.syouhiRitu = row.ritu1;
                /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD Start */
                //消費税.
                drDispMedia.syouhiZei = row.kngk1;
                #region 消費税(削除).
                //if (row.ritu1.Trim() == "0")
                //{
                //    drDispMedia.syouhiZei = "0";
                //}
                //else
                //{
                //    /* 2013/11/26 消費税対応 HLC H.Watabe MOD Start */
                //    double syouhi = 0;
                //    double syohizei = 0;
                //    switch (row.code1.Trim())
                //    {
                //        case KkhConstAsh.BaitaiCd.TV_TIME:
                //        case KkhConstAsh.BaitaiCd.RADIO_TIME:
                //        case KkhConstAsh.BaitaiCd.BS:
                //        case KkhConstAsh.BaitaiCd.CS:
                //        case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                //        case KkhConstAsh.BaitaiCd.BRAND_FEE:
                //        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                //        case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                //        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                //            string filter = "NAME33 = '" + row.name33 + "'";
                //            RepDsAsh.RepAshMediaTempRow[] resultRow2 = (RepDsAsh.RepAshMediaTempRow[])result.dsAshDataSet.RepAshMediaTemp.Select(filter);
                //            foreach (RepDsAsh.RepAshMediaTempRow rows in resultRow2)
                //            {
                //                dblSupposeSyohizei = 1 + (double.Parse(rows.ritu1.Trim()) * 0.01);
                //                syouhi = (double.Parse(rows.ritu1.Trim()) * 0.01) * double.Parse(rows.seiGak.Trim());
                //                /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD Start */
                //                //syohizei = syohizei + (long)Math.Truncate(syouhi);
                //                if (_naviParam.strTksKgyCd == "285147")
                //                {
                //                    syohizei = syohizei + (long)Math.Truncate(syouhi);
                //                }
                //                else if (_naviParam.strTksKgyCd == "016802")
                //                {
                //                    syohizei = syohizei + (long)Math.Round(syouhi);
                //                }
                //                /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD End */
                //            }
                //            drDispMedia.syouhiZei = syohizei.ToString();
                //            break;
                //        default:
                //            dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                //            syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(drDispMedia.nebiki.Trim());
                //            /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD Start */
                //            //syohizei = (long)Math.Truncate(syouhi);
                //            if (_naviParam.strTksKgyCd == "285147")
                //            {
                //                syohizei = (long)Math.Truncate(syouhi);
                //            }
                //            else if (_naviParam.strTksKgyCd == "016802")
                //            {
                //                syohizei = (long)Math.Round(syouhi);
                //            }
                //            /* 2015/06/08 アサヒ消費税対応 HLC K.Fujisaki MOD End */
                //            drDispMedia.syouhiZei = syohizei.ToString();
                //            break;
                //    }
                //    //消費税の格納変数.
                //    //dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                //    //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(drDispMedia.nebiki.Trim());
                //    //double syohizei = (long)Math.Truncate(syouhi);
                //    //int syohizei = (int)Math.Truncate(syouhi);
                //    /* 2013/11/26 消費税対応 HLC H.Watabe MOD End */
                //}
                #endregion 消費税(削除).
                /* 2016/11/22 アサヒ消費税対応 HLC K.Soga MOD End */

                #region 媒体毎で値の設定を行う.
                switch (row.code1.Trim())
                {
                    #region テレビタイム、ラジオタイム、テレビネットスポット.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD Start */
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                        /* 2015/06/08 アサヒ対応 K.Fujisaki ADD End */
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //局ネット.
                        drDispMedia.kyokuNet = row.sonota7.ToString() + "局ネット";
                        /* 2015/06/08 アサヒ対応 K.Fujisaki MOD Start */
                        //if (row.code1.Equals(KkhConstAsh.BaitaiCd.TV_TIME))
                        if (row.code1.Equals(KkhConstAsh.BaitaiCd.TV_TIME) || row.code1.Equals(KkhConstAsh.BaitaiCd.TV_NETSPOT))
                        /* 2015/06/08 アサヒ対応 K.Fujisaki MOD end */
                        {
                            //媒体名.
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TV_TIME;
                            //放送曜日.
                            drDispMedia.housouWeek = weekDayGet(row.name5, row.name9);
                            //局.
                            if (string.IsNullOrEmpty(row.sonota8.Trim()))
                            {
                                drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_TV);
                            }
                            else
                            {
                                drDispMedia.kyoku = getBaiName1(row.sonota8.ToString(), drBaitaiCode, KYKCD_TV);
                            }
                        }
                        else
                        {
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_TIME;
                            //媒体名.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_TIME;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO;
                            }
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD End */
                            //局.
                            if (string.IsNullOrEmpty(row.sonota8.Trim()))
                            {
                                drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_RADIO);
                            }
                            else
                            {
                                drDispMedia.kyoku = getBaiName1(row.sonota8.ToString(), drBaitaiCode, KYKCD_RADIO);
                            }
                        }
                        //時間.
                        drDispMedia.jikan = timeFormatSet(row.name6.ToString());
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //件名.
                        drDispMedia.kenName = row.kkNameKj.Trim();
                        //件数.
                        intKensu++;
                        break;
                    #endregion テレビタイム、ラジオタイム、テレビネットスポット.

                    #region メディアフィー、ブランド管理フィー.
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //時間.
                        drDispMedia.jikan = timeFormatSet(row.name6.Trim());
                        //ネット局数.
                        if (!string.IsNullOrEmpty(row.sonota7.Trim()))
                        {
                            drDispMedia.kyokuNet = row.sonota7.Trim();
                        }
                        switch (row.code1.Trim())
                        {
                            case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                                //局.
                                drDispMedia.kyoku = getBaiName2(row.code2, drBaitaiCode, KYKCD_MEDIAFEE);
                                //媒体名.
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.MEDIA_FEE;
                                break;
                            case KkhConstAsh.BaitaiCd.BRAND_FEE:
                                //局.
                                drDispMedia.kyoku = getBaiName2(row.code2, drBaitaiCode, KYKCD_BLAND);
                                //媒体名.
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BRAND_FEE;
                                break;
                        }
                        //件数.
                        intKensu++;
                        break;
                    #endregion メディアフィー、ブランド管理フィー.

                    #region ラジオスポット.
                    case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //本数.
                        if (string.IsNullOrEmpty(row.sonota2))
                        {
                            drDispMedia.honSu = String.Empty;
                        }
                        else
                        {
                            drDispMedia.honSu = KKHUtility.LongParse(row.sonota2.Trim()) + "本";
                        }
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_RADIO);
                        /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                        //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                        //媒体名.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                        }
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO;
                        }
                        /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD End */
                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //件数.
                        intKensu++;
                        break;
                    #endregion ラジオスポット.

                    #region テレビスポット.
                    case KkhConstAsh.BaitaiCd.TV_SPOT:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //本数.
                        if (string.IsNullOrEmpty(row.sonota2.Trim()))
                        {
                            drDispMedia.honSu = "0本";
                        }
                        else
                        {
                            drDispMedia.honSu = KKHUtility.LongParse(row.sonota2.Trim()) + "本";
                        }
                        //媒体名.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TV_SPOT;
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_TV);
                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //件数.
                        intKensu++;
                        break;
                    #endregion テレビスポット.

                    #region 新聞.
                    case KkhConstAsh.BaitaiCd.SHINBUN:
                        if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                        {
                            //消費税の格納変数.
                            double wk = 0;
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga DEL Start */
                            ///* 2013/03/27 HLC T.Sonobe MOD Start */
                            ////dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //if (row.ritu1.Trim() != "0")
                            //{
                            //    dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //}
                            ///* 2013/03/27 HLC T.Sonobe MOD End */
                            //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(row.seiGak.Trim());
                            ///* 2015/06/08 アサヒ対応 K.Fujisaki MOD Start */
                            ////int syohizei = (int)Math.Truncate(syouhi);
                            //int syohizei = 0;
                            //if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            //{
                            //    syohizei = (int)Math.Truncate(syouhi);
                            //}
                            //else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            //{
                            //    syohizei = (int)Math.Round(syouhi);
                            //}
                            ///* 2015/06/08 アサヒ対応 K.Fujisaki MOD End */
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga DEL End */

                            //前回の受注明細消費税額が存在する場合(複数受注明細が存在する場合).
                            if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                            {
                                //前回の受注明細消費税額を取得.
                                wk = double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                            }
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                            //double wk2 = wk + syohizei;
                            //合算した消費税金額を取得.
                            double wk2 = wk + double.Parse(row.kngk1);
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                            //媒体情報が1件
                            if (dsash.displayMedia.Rows.Count > 1)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei = wk2.ToString();
                            }
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                            //小計.
                            //dblSupposeSyoukei += double.Parse(syohizei.ToString()) + double.Parse(row.seiGak.Trim());
                            dblSupposeSyoukei += double.Parse(row.kngk1) + double.Parse(row.seiGak);
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                            /*
                             * 値引.
                             */
                            //合算.
                            strClcResult1 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki = strClcResult1;

                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2)
                            {
                                case "掲載料":
                                    string ksaiRyo = "0";
                                    string ksaiNebi = "0";

                                    //合算. 
                                    //掲載料. 
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //掲載料値引率.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                case "指定料":
                                case "組替料":
                                case "二連版料":

                                    string siteRyo = "0";
                                    string siteNebi = "0";

                                    //合算.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo))
                                    {
                                        siteRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, siteRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo = strClcResult1;


                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter))
                                    {
                                        siteNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, siteNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter = strClcResult2;

                                    //指定料値引率.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                case "色刷料":

                                    string sikiRyo = "0";
                                    string sikiNebi = "0";

                                    //合算.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo))
                                    {
                                        sikiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, sikiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter))
                                    {
                                        sikiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, sikiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter = strClcResult2;

                                    //色刷料値引率.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                default:

                                    ksaiRyo = "0";
                                    ksaiNebi = "0";

                                    /*
                                     * 合算.
                                     */
                                    //掲載料. 
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }

                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    //値引後.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //種別名＆費目名.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                            }

                            //媒体コード.
                            strBaitaiCd = row.code1.Trim();
                            //値引率.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiRitu = "-";
                            //局.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_SHINBN);
                            /* 2015/03/31 アサヒ対応 Miyanoue MOD Start */
                            //媒体名.
                            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            }
                            /* 2015/03/31 アサヒ対応 Miyanoue MOD End */
                            //掲載年月日.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiYyMmDd = YyMmDd(row.name5.Trim());
                            //件名.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kenName = row.kkNameKj.Trim();
                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2)
                            {
                                case "掲載料":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                                case "指定料":
                                case "組替料":
                                case "二連版料":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2 = row.name2.Trim();
                                    break;
                                case "色刷料":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName3 = row.name2.Trim();
                                    break;
                                default:
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                            }
                            //記雑区分.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kizatuKbn = kizatuGet(row.sonota5.Trim());
                            //掲載版.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiBan = keisaiGet(row.sonota6.Trim());
                            //スペース.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].space = row.name1;
                            //朝夕区分.
                            if (row.sonota3.Trim() == "1")
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = "朝";
                            }
                            else if (row.sonota3.Trim() == "2")
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = "夕";
                            }
                            else
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = string.Empty;
                            }
                        }
                        else
                        {
                            //媒体コード.
                            strBaitaiCd = row.code1.Trim();
                            //値引率.
                            drDispMedia.nebiRitu = "-";
                            //局.
                            drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_SHINBN);
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                            //媒体名.
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            }
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                            //掲載年月日.
                            drDispMedia.keisaiYyMmDd = YyMmDd(row.name5.Trim());
                            //件名.
                            drDispMedia.kenName = row.kkNameKj.Trim();
                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2)
                            {
                                case "掲載料":
                                    drDispMedia.keisaiRyo = row.hnmeGak;
                                    drDispMedia.keisaiNebiAfter = row.seiGak;
                                    drDispMedia.keisaiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    break;
                                case "指定料":
                                case "組替料":
                                case "二連版料":
                                    drDispMedia.siteiRyo = row.hnmeGak;
                                    drDispMedia.siteiNebiAfter = row.seiGak;
                                    drDispMedia.siteiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName2 = row.name2.Trim();
                                    break;
                                case "色刷料":
                                    drDispMedia.sikisatuRyo = row.hnmeGak;
                                    drDispMedia.sikisatuNebiAfter = row.seiGak;
                                    drDispMedia.sikisatuRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName3 = row.name2.Trim();
                                    break;
                                default:
                                    drDispMedia.keisaiRyo = row.hnmeGak;
                                    drDispMedia.keisaiNebiAfter = row.seiGak;
                                    drDispMedia.keisaiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    break;
                            }
                            //記雑区分.
                            drDispMedia.kizatuKbn = kizatuGet(row.sonota5.Trim());
                            //掲載版.
                            drDispMedia.keisaiBan = keisaiGet(row.sonota6.Trim());
                            //スペース.
                            drDispMedia.space = row.name1;
                            //朝夕区分.
                            if (row.sonota3.Trim() == "1")
                            {
                                drDispMedia.asayuKbn = "朝";
                            }
                            else if (row.sonota3.Trim() == "2")
                            {
                                drDispMedia.asayuKbn = "夕";
                            }
                            else
                            {
                                drDispMedia.asayuKbn = string.Empty;
                            }

                            //合計 .
                            dblGoukei = 0;

                            //件数.
                            intKensu++;
                        }
                        break;
                    #endregion 新聞.

                    #region 雑誌.
                    case KkhConstAsh.BaitaiCd.ZASHI:
                        //受注明細Noが同一の場合.
                        if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                        {
                            //消費税の格納変数.
                            double wk = 0;

                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga DEL Start */
                            ///* 2013/03/27 HLC T.Sonobe MOD Start */
                            ////dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //if (row.ritu1.Trim() != "0")
                            //{
                            //    dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //}
                            ///* 2013/03/27 HLC T.Sonobe MOD End */
                            //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(row.seiGak.Trim());

                            ///* 2015/06/08 アサヒ対応 K.Fujisaki MOD Start */
                            ////int syohizei = (int)Math.Truncate(syouhi);
                            //int syohizei = 0;
                            //if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            //{
                            //    syohizei = (int)Math.Truncate(syouhi);
                            //}
                            //else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            //{
                            //    syohizei = (int)Math.Round(syouhi);
                            //}
                            ///* 2015/06/08 アサヒ対応 K.Fujisaki MOD End */
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga DEL End */

                            //前回の受注明細消費税額が存在する場合(複数受注明細が存在する場合).
                            if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                            {
                                //前回の受注明細消費税額を取得.
                                wk = double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                            }

                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                            //double wk2 = wk + syohizei;
                            //合算した消費税金額を取得.
                            double wk2 = wk + double.Parse(row.kngk1);
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                            //媒体情報が1件
                            if (dsash.displayMedia.Rows.Count > 1)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei = wk2.ToString();
                            }

                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD Start */
                            //小計.
                            //dblSupposeSyoukei += double.Parse(syohizei.ToString()) + double.Parse(row.seiGak.Trim());
                            dblSupposeSyoukei += double.Parse(row.kngk1) + double.Parse(row.seiGak);
                            /* 2017/02/01 アサヒ消費税不具合対応 HLC K.Soga MOD End */

                            /*
                             * 値引.
                             */
                            //合算.
                            strClcResult1 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki = strClcResult1;

                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2.Trim())
                            {
                                case "掲載料":
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    string ksaiRyo = "0";
                                    string ksaiNebi = "0";

                                    //合算.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }

                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //掲載料値引率.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2) || dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim().Equals(row.name2.Trim()))
                                    {
                                        drDispMedia.syuAndHiName2 = row.name2.Trim();
                                        drDispMedia.siteiRyo = "0";

                                        //合算.
                                        strClcResult1 = clcRyokin(row.hnmeGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo = strClcResult1;

                                        strClcResult2 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter = strClcResult2;
                                    }
                                    else
                                    {
                                        drDispMedia.syuAndHiName3 = row.name2.Trim();
                                        drDispMedia.sikisatuRyo = "0";

                                        //合算.
                                        strClcResult1 = clcRyokin(row.hnmeGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo = strClcResult1;

                                        strClcResult2 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter = strClcResult2;

                                    }
                                    break;
                            }

                            //媒体コード.
                            strBaitaiCd = row.code1.Trim();
                            //値引率.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiRitu = row.hnnert;
                            //局.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kyoku = getBaiName2(row.code6.Trim(), drBaitaiCode, KYKCD_ZASHI);
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD　Start */
                            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            //媒体名.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASSHI_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            }
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD　End */
                            //期間.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kikan = YyMmDd(row.name5.Trim());
                            //スペース.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].space = row.name1.Trim();
                            //件名.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2.Trim())
                            {
                                case "掲載料":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = "0";
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim()) || dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim().Equals(row.name2.Trim()))
                                    {
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2 = row.name2.Trim();
                                    }
                                    else
                                    {
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName3 = row.name2.Trim();
                                    }
                                    break;
                            }
                        }
                        //受注明細Noが異なる場合.
                        else
                        {
                            //媒体コード.
                            strBaitaiCd = row.code1.Trim();
                            //値引率.
                            drDispMedia.nebiRitu = row.hnnert;
                            //局.
                            drDispMedia.kyoku = getBaiName2(row.code6.Trim(), drBaitaiCode, KYKCD_ZASHI);
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue ADD Start */
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            //媒体名.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASSHI_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            }
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue ADD End */
                            //期間.
                            drDispMedia.kikan = YyMmDd(row.name5.Trim());
                            //drDispMedia.kikan = YyMmDd(row.name5.Trim());
                            //スペース.
                            drDispMedia.space = row.name1.Trim();
                            //種別名＆費目名.
                            //drDispMedia.syuAndHiName = row.name2.Trim();
                            //件名.
                            drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                            //費目名により挿入するデータのカラムを指定する.
                            switch (row.name2.Trim())
                            {
                                case "掲載料":
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    drDispMedia.keisaiRyo = "0";
                                    if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                    {
                                        drDispMedia.keisaiRyo = row.hnmeGak.Trim();
                                    }
                                    drDispMedia.keisaiNebiAfter = row.seiGak.Trim();
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(drDispMedia.syuAndHiName2.Trim()))
                                    {
                                        drDispMedia.syuAndHiName2 = row.name2.Trim();
                                        drDispMedia.siteiRyo = "0";

                                        if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                        {
                                            drDispMedia.siteiRyo = row.hnmeGak.Trim();
                                        }
                                        drDispMedia.siteiNebiAfter = row.seiGak.Trim();
                                    }
                                    else
                                    {
                                        drDispMedia.syuAndHiName3 = row.name2.Trim();
                                        drDispMedia.sikisatuRyo = "0";

                                        if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                        {
                                            drDispMedia.sikisatuRyo = row.hnmeGak.Trim();
                                        }
                                        drDispMedia.sikisatuNebiAfter = row.seiGak.Trim();
                                    }
                                    break;
                            }

                            //合計.
                            dblGoukei = 0;

                            //件数.
                            intKensu++;
                        }
                        break;
                    #endregion 雑誌.

                    #region 交通.
                    case KkhConstAsh.BaitaiCd.KOUTSU:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_OOH);
                        /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                        //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSU;
                        //媒体名.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSUU_KOUKOKU;
                        }
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSU;
                        }
                        /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD End */
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //種別名＆費目名.
                        drDispMedia.syuAndHiName = row.name6.Trim() + " " + row.himknmKj.Trim();
                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //件数.
                        intKensu++;
                        break;
                    #endregion 交通.

                    #region 屋外広告、イベント.
                    case KkhConstAsh.BaitaiCd.OKUGAI:
                    case KkhConstAsh.BaitaiCd.EVENT:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_KOEVE);
                        switch (row.code1.Trim())
                        {
                            //媒体名.
                            case KkhConstAsh.BaitaiCd.OKUGAI:
                                /* 2015/03/31 アサヒ対応 Miyanoue Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUKOKURYOU_OKUGAI;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
                                }
                                /* 2015/03/31 アサヒ対応 Miyanoue End */
                                break;
                            case KkhConstAsh.BaitaiCd.EVENT:
                                /* 2015/03/31 アサヒ対応 Miyanoue Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT;
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT_KOUKOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT;
                                }
                                /* 2015/03/31 アサヒ対応 Miyanoue End */
                                break;
                        }

                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                        //件数.
                        intKensu++;
                        break;
                    #endregion 屋外広告、イベント.

                    #region 製作.
                    case KkhConstAsh.BaitaiCd.SEISAKU:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SEISAK);
                        //媒体名.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SEISAKU;
                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //件数.
                        intKensu++;
                        break;
                    #endregion 製作.

                    /* 2013/02/22 PR媒体追加対応 JSE Okazaki ADD Start */
                    #region PR.
                    case KkhConstAsh.BaitaiCd.PR:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //局.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SEISAK);
                        //媒体名.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.PR;
                        //件名.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //件数.
                        intKensu++;
                        break;
                    #endregion PR.
                    /* 2013/02/22 PR媒体追加対応 JSE Okazaki ADD End */

                    #region その他.
                    default:
                        //次用に媒体コードセット.
                        strBaitaiCd = row.code1.Trim();
                        //値引率.
                        drDispMedia.nebiRitu = row.hnnert;
                        //金額.
                        drDispMedia.kingak = row.hnmeGak;
                        /* 2015/07/08 HLC K.Soga アサヒ対応 MOD Start */
                        //局.
                        //drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SONOTA);
                        drDispMedia.kyoku = getBaiNameSonota(row.code2.Trim(), drBaitaiCode, KYKCD_SONOTA, strBaitaiCd);
                        /* 2015/07/08 HLC K.Soga アサヒ対応 MOD End */
                        //期間.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        switch (row.code1.Trim())
                        {//媒体名.
                            case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.NEW_MEDIA;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.INTERNET:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.INTERNET;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.BS:
                                /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS;
                                //媒体名.
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS_INRYOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS;
                                }
                                /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD End */
                                break;
                            case KkhConstAsh.BaitaiCd.CS:
                                /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS;
                                //媒体名.
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS_INRYOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS;
                                }
                                /* 2015/03/31 アサヒ対応 JSE Miyanoue MOD End */
                                break;
                            case KkhConstAsh.BaitaiCd.TYOUSA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TYOUSA;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SONOTA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SONOTA;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue ADD Start */
                            case KkhConstAsh.BaitaiCd.IMAGEGIRL:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.IMAGEGIRL;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.JIMOTO:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.JIMOTO;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.NIKKA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.NIKKA;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.PR_INRYOU:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.PR_INRYOU;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.AMEFUT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.AMEFUT;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.TALENT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TALENT;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.COPYRIGHT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.COPYRIGHT;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SOZAI:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SOZAI;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.CF:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CF;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SEISAKU_FEE:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SEISAKU_FEE;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.JASRAC:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.JASRAC;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SYANAISHIRYOU:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SYANAISHIRYOU;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.KOUKOKURYO:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUKOKURYO;
                                //件名.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            /* 2015/03/31 アサヒ対応 JSE Miyanoue ADD End */
                        }

                        //件数.
                        intKensu++;
                        break;
                    #endregion その他.
                }
                #endregion 媒体毎で値の設定を行う.

                /* 2015/06/02 アサヒ対応 HLC K.Fujisaki ADD Start */
                // 旧媒体コードから新媒体名称、新媒体コードを取得する.
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(row.code1.Trim());
                drDispMedia.baitaiName = res.baitaiNm;
                /* 2015/06/02 アサヒ対応 HLC K.Fujisaki ADD End */
                /* 2017/01/31 アサヒ消費税対応 HLC K.Soga DEL Start */
                /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                //調整用に値を保持.
                //dblMediaTaxSumFromRows += double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
                /* 2017/01/31 アサヒ消費税対応 HLC K.Soga DEL End */

                /*
                 * 合計を算出する.
                 */
                //受注明細Noが同一の場合.
                if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                {
                    //媒体コードが新聞、雑誌.
                    if (row.code1.Trim() == KkhConstAsh.BaitaiCd.SHINBUN || row.code1.Trim() == KkhConstAsh.BaitaiCd.ZASHI)
                    {
                        //値引後掲載料.
                        double nebiKsai = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                        {
                            nebiKsai = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter);
                        }

                        //値引後指定料.
                        double nebiSitei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter))
                        {
                            nebiSitei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter);
                        }

                        //値引後色刷料.
                        double dblNebikiIro = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter))
                        {
                            dblNebikiIro = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter);
                        }

                        //消費税.
                        double dblShohiZei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                        {
                            dblShohiZei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                        }

                        dblGoukei = nebiKsai + nebiSitei + dblNebikiIro + dblShohiZei;

                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 1].kingak = dblGoukei.ToString();

                        //小計用に金額格納(値引の足し算).
                        dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());
                    }
                    //媒体コードが新聞、雑誌以外.
                    else
                    {
                        //値引額.
                        double dblNebikiGaku = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki))
                        {
                            dblNebikiGaku = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                        }

                        //消費税.
                        double dblShohiZei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                        {
                            dblShohiZei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                        }

                        dblGoukei = dblNebikiGaku + dblShohiZei;

                        //媒体コード.
                        drDispMedia.baitaiCd = row.code1 + "1";

                        //Rowの追加.
                        dsash.displayMedia.AdddisplayMediaRow(drDispMedia);

                        //XML用にデータを入れる.
                        repds.displayMedia.ImportRow(drDispMedia);

                        //表示用合計のセット.
                        drDispMediaGoukei.kyoku = "合計";
                        //合計を算出する.
                        dblGoukei = double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                        /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                        //dblMediaTaxSumFromRows += dblGoukei;
                        /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
                        drDispMediaGoukei.kingak = dblGoukei.ToString();
                        drDispMediaGoukei.baitaiCd = row.code1 + "2";

                        //小計用に金額格納(値引の足し算).
                        dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());

                        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD Start */
                        //小計用.
                        //dblSupposeSyoukei += Math.Truncate(dblGoukei);
                        //アサヒ飲料の場合.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            dblSupposeSyoukei += Math.Truncate(dblGoukei);
                        }
                        //アサヒビールの場合.
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            dblSupposeSyoukei += Math.Round(dblGoukei);
                        }
                        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD End */
                        /* 2013/03/28 HLC T.Sonobe DEL Start */
                        //if (row.ritu1.Trim() == "0")
                        //{
                        //    //消費税率が0の場合請求金額を足していく.
                        //    dblHikazei += double.Parse(row.seiGak.Trim());
                        //}
                        /* 2013/03/28 HLC T.Sonobe DEL End */

                        dblGoukei = 0;
                        dsash.displayMedia.AdddisplayMediaRow(drDispMediaGoukei);
                    }

                    if (row.ritu1.Trim() == "0")
                    {
                        //消費税率が0の場合請求金額を足していく.
                        dblHikazei += double.Parse(row.seiGak.Trim());
                    }
                }
                //受注明細Noが異なる場合.
                else
                {
                    //媒体コード.
                    drDispMedia.baitaiCd = row.code1 + "1";

                    //Rowの追加.
                    dsash.displayMedia.AdddisplayMediaRow(drDispMedia);

                    //XML用にデータを入れる.
                    repds.displayMedia.ImportRow(drDispMedia);

                    //表示用合計のセット.
                    drDispMediaGoukei.kyoku = "合計";
                    //合計を算出する.
                    dblGoukei = double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                    /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                    //dblMediaTaxSumFromRows += dblGoukei;
                    /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
                    drDispMediaGoukei.kingak = dblGoukei.ToString();
                    drDispMediaGoukei.baitaiCd = row.code1 + "2";

                    //小計用に金額格納(値引の足し算).
                    dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());

                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD Start */
                    //小計用.
                    //dblSupposeSyoukei += Math.Truncate(dblGoukei);
                    //アサヒ飲料の場合.
                    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                    {
                        dblSupposeSyoukei += Math.Truncate(dblGoukei);
                    }
                    //アサヒビールの場合.
                    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                    {
                        dblSupposeSyoukei += Math.Round(dblGoukei);
                    }
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD End */

                    if (row.ritu1.Trim() == "0")
                    {
                        //消費税率が0の場合請求金額を足していく.
                        dblHikazei += double.Parse(row.seiGak.Trim());
                    }

                    dblGoukei = 0;
                    dsash.displayMedia.AdddisplayMediaRow(drDispMediaGoukei);
                }

                //受注明細No保持.
                strJyuchuMeisaiNoHoji = row.name33.Substring(0, 14);

                intCnt++;
            }

            /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL Start */
            ///* 2013/12/06 消費税対応 HLC H.Watabe MOD Start */
            //double sum = 0;
            //for (int index = 0; index < lstZeiRate.Count; index++)
            //{
            //    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD Start */
            //    //sum += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    //飲料の場合.
            //    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
            //    {
            //        sum += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    }
            //    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
            //    {
            //        sum += Math.Round((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    }
            //    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD End */
            //}
            /* 2017/01/31 アサヒ消費税不具合対応 HLC K.Soga DEL End */
            //dblTyousei = (dblSyoukei - dblHikazei) * 1.05; //+ dblHikazei) - dblSupposeSyoukei;
            //dblTyousei = (dblSyoukei - dblHikazei) * dblSupposeSyohizei;
            //dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
            //dblTyousei = ToHalfAdjust(dblTyousei, 0);
            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL Start */
            //dblTyousei = sum - dblMediaTaxSumFromRows;
            /* 2013/12/06 消費税対応 HLC H.Watabe MOD End */
            //double dbdb = ToHalfAdjust(dblTyousei, 0) + dblSupposeSyoukei;
            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL End */
            //小計.
            drNewDispMedia.kyoku = KKHSystemConst.KoteiMongon.SYOKEI;
            //小計金額.
            drNewDispMedia.kingak = dblSupposeSyoukei.ToString();
            //媒体コード.
            drNewDispMedia.baitaiCd = strBaitaiCd + "3";

            RepDsAsh.allbaitaiRow allbaitairow1 = repds.allbaitai.NewallbaitaiRow();

            /*
             * XML用.
             */
            allbaitairow1.baitaicd = strBaitaiCd;
            allbaitairow1.zeinasi = dblSyoukei.ToString();
            allbaitairow1.goukei = dblSupposeSyoukei.ToString();

            //挿入.
            repds.allbaitai.AddallbaitaiRow(allbaitairow1);
            dsash.displayMedia.AdddisplayMediaRow(drNewDispMedia);

            /*
             * 初期化.
             */
            //小計.
            dblSyoukei = 0;
            //非課税.
            dblHikazei = 0;
            //小計.
            dblSupposeSyoukei = 0;

            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL Start */
            #region 端数調整(削除).
            /* 2013/04/09 HLC T.Sonobe ADD Start */
            //端数調整を税金、合計金額に反映させる.
            //double dnum = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei.ToString());
            //消費税.
            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei = dnum.ToString();
            //dnum = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak.ToString());
            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak = dnum.ToString();
            /* 2013/04/09 HLC T.Sonobe ADD End */
            #endregion 端数調整(削除).
            /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL End */

            //カンマ設定.
            SetComma(dsash);

            repds.displayMedia.Clear();
            repds.displayMedia.Merge(dsash.displayMedia);
            RepDsAsh.displayMediaRow[] delrow = (RepDsAsh.displayMediaRow[])repds.displayMedia.Select("kyoku IN ('" + "合計" + "','" + "小計" + "')");
            foreach (RepDsAsh.displayMediaRow row in delrow)
            {
                repds.displayMedia.Rows.Remove(row);
            }

            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD Start */
            //AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //旧媒体コードから新媒体名称、新媒体コードを取得する.
            for (int i = 0; i < dsash.displayMedia.Rows.Count; i++)
            {
                String baitaiCd = dsash.displayMedia[i].baitaiCd;
                String baitaiNm = dsash.displayMedia[i].baitaiName;
                //媒体コード長.
                int totalLen = baitaiCd.Length;
                //下1桁を除いた媒体コード長さ.
                int len = totalLen - 1;
                //媒体コードを変換する.
                String bCd = baitaiCd.Substring(0, len);
                String bCd1keta = baitaiCd.Substring(len, 1);
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(bCd);
                String resultBaitaiCd = res.baitaiCd + bCd1keta;

                dsash.displayMedia[i].tokuisakiBaitaiCd = resultBaitaiCd;
                dsash.displayMedia[i].tokuisakiBaitaiName = res.baitaiNm;
            }
            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD End */

            //スプレッドデータソースへ入れる.
            medMain_Sheet1.DataSource = dsash.displayMedia;
            //エクセルボタン.
            btnXls.Enabled = true;
            //出力媒体.
            cmbMedia.Enabled = true;

            //件数の表示.
            lblKensu.Text = intKensu.ToString() + "件";

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion データ表示.

        #region データRow初期セット.
        /// <summary>
        /// データRow初期セット.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayMediaRow syokirowSet(RepDsAsh.displayMediaRow addrow)
        {
            addrow.asayuKbn = string.Empty;
            addrow.baitaiCd = string.Empty;
            addrow.tokuisakiBaitaiCd = string.Empty;
            addrow.baitaiName = string.Empty;
            addrow.tokuisakiBaitaiName = string.Empty;
            addrow.hinSyu = string.Empty;
            addrow.honSu = string.Empty;
            addrow.housouWeek = string.Empty;
            addrow.jikan = string.Empty;
            addrow.keisaiBan = string.Empty;
            addrow.keisaiNebiAfter = string.Empty;
            addrow.keisaiRyo = string.Empty;
            addrow.keisaiRyoNebiRitu = string.Empty;
            addrow.keisaiSyubetu = string.Empty;
            addrow.keisaiYyMmDd = string.Empty;
            addrow.kenName = string.Empty;
            addrow.kikan = string.Empty;
            addrow.kingak = string.Empty;
            addrow.kizatuKbn = string.Empty;
            addrow.kyoku = string.Empty;
            addrow.kyokuNet = string.Empty;
            addrow.nebiki = string.Empty;
            addrow.nebiRitu = string.Empty;
            addrow.seisakuhi = string.Empty;
            addrow.sikisatuNebiAfter = string.Empty;
            addrow.sikisatuRyo = string.Empty;
            addrow.sikisatuRyoNebiRitu = string.Empty;
            addrow.siteiNebiAfter = string.Empty;
            addrow.siteiRyo = string.Empty;
            addrow.siteiRyoNebiRitu = string.Empty;
            addrow.space = string.Empty;
            addrow.syouhiRitu = string.Empty;
            addrow.syouhiZei = string.Empty;
            addrow.syuAndHiName = string.Empty;
            addrow.syuAndHiName2 = string.Empty;
            addrow.syuAndHiName3 = string.Empty;
            return addrow;
        }
        #endregion データRow初期セット.

        #region 時間の形式セット.
        /// <summary>
        /// 時間の形式セット.
        /// </summary>
        /// <param name="oldTime"></param>
        /// <returns></returns>
        private string timeFormatSet(string oldTime)
        {
            //長さが11以外は処理しない.
            if (oldTime.Trim().Length != 11) 
            {
                return string.Empty; 
            }

            string newTime = oldTime.Replace(":", "時");
            string leftTime = newTime.Substring(0, 5) + "分";
            string rightTime = newTime.Substring(5, 6) + "分";
            newTime = leftTime + rightTime;

            return newTime;
        }
        #endregion 時間の形式セット.

        #region 期間の形式セット.
        /// <summary>
        /// 期間の形式セット.
        /// </summary>
        /// <param name="oldKikan"></param>
        /// <returns></returns>
        private string kikanFormatSet(string oldKikan)
        {

            if (oldKikan.Trim().Length == 25) 
            {
                return oldKikan; 
            }

            //長さが16以外は処理しない.
            if (oldKikan.Trim().Length != 16)
            {
                //長さが８の場合は開始年月だけ取得.
                if (oldKikan.Trim().Length == 8)
                {
                    string tankikan = oldKikan.Substring(0, 4) + "年" +
                                      oldKikan.Substring(4, 2) + "月" +
                                      oldKikan.Substring(6, 2) + "日－" + "年　月　日";
                    return tankikan;
                }
                return string.Empty;
            }


            string newKikan = oldKikan.Substring(0, 4) + "年" +
                              oldKikan.Substring(4, 2) + "月" +
                              oldKikan.Substring(6, 2) + "日－" +
                              oldKikan.Substring(8, 4) + "年" +
                              oldKikan.Substring(12, 2) + "月" +
                              oldKikan.Substring(14, 2) + "日";

            return newKikan;
        }
        #endregion 期間の形式セット.

        #region 放送曜日の取得.
        /// <summary>
        /// 放送曜日の取得.
        /// </summary>
        /// <param name="oldYymm"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        private string weekDayGet(string oldYymm, string week)
        {
            //長さが16以外は処理しない.
            if (oldYymm.Length != 16) 
            {
                return string.Empty; 
            }

            if (string.IsNullOrEmpty(week)) 
            {
                return string.Empty; 
            }

            //曜日セット.
            string Youbi = string.Empty;
            //日付取得.
            int day = 0;
            //日付(string).
            string strDay = string.Empty;
            //年月の取得.
            string newYymm = oldYymm.Substring(0, 4) + "/" + oldYymm.Substring(4, 2);
            //曜日重複チェック.
            string tfFlag = string.Empty;

            //曜日取得分繰り返す.
            for (int i = 0; i < week.Replace("0", string.Empty).Length; i++)
            {
                day = week.IndexOf("1", day) + 1;
                if (day.ToString().Length == 1)
                {
                    strDay = "0" + day.ToString();
                }
                else
                {
                    strDay = day.ToString();
                }
                DateTime dt = DateTime.Parse(newYymm + "/" + strDay);

                //曜日のセット.
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        if (tfFlag.Contains("1")) { break; }
                        Youbi = Youbi + "月、";
                        tfFlag = tfFlag + "1";
                        break;
                    case DayOfWeek.Tuesday:
                        if (tfFlag.Contains("2")) { break; }
                        Youbi = Youbi + "火、";
                        tfFlag = tfFlag + "2";
                        break;
                    case DayOfWeek.Wednesday:
                        if (tfFlag.Contains("3")) { break; }
                        Youbi = Youbi + "水、";
                        tfFlag = tfFlag + "3";
                        break;
                    case DayOfWeek.Thursday:
                        if (tfFlag.Contains("4")) { break; }
                        Youbi = Youbi + "木、";
                        tfFlag = tfFlag + "4";
                        break;
                    case DayOfWeek.Friday:
                        if (tfFlag.Contains("5")) { break; }
                        Youbi = Youbi + "金、";
                        tfFlag = tfFlag + "5";
                        break;
                    case DayOfWeek.Saturday:
                        if (tfFlag.Contains("6")) { break; }
                        Youbi = Youbi + "土、";
                        tfFlag = tfFlag + "6";
                        break;
                    case DayOfWeek.Sunday:
                        if (tfFlag.Contains("7")) { break; }
                        Youbi = Youbi + "日、";
                        tfFlag = tfFlag + "7";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Youbi))
            {
                //最後の","を取り除く.
                if (Youbi.Substring(Youbi.Length - 1, 1).Equals("、")) { Youbi = Youbi.Substring(0, Youbi.Length - 1); }
                return Youbi;
            }

            return string.Empty;
        }
        #endregion 放送曜日の取得.

        #region 媒体名取得.
        /// <summary>
        /// 媒体名取得.
        /// </summary>
        private void MediaCdGet()
        {
            //パラメーターのセット.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = string.Empty;

            //検索.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMediaCode(param);
            bct = result.dsAshDataSet.BaiCd;
            sdt = result.dsAshDataSet.Syohin;
        }
        #endregion 媒体名取得.

        #region マスタからの局名取得１パターン目.
        /// <summary>
        /// マスタからの局名取得１パターン目.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string getBaiName1(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd)
        {
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            {
                return string.Empty; 
            }

            //局名.
            string kyoku = string.Empty;
            foreach (RepDsAsh.BaiCdRow row in bcrow)
            {
                //入力された値の場合.
                if (row.field4.Equals(kyokuryakusyo.Trim()))
                {
                    //マスタと同じ種別の場合.
                    if (row.sybt.Equals(baitaiCd))
                    {
                        kyoku = row.field2.ToString();
                        return kyoku;
                    }
                }
            }

            return kyoku;
        }
        #endregion マスタからの局名取得１パターン目.

        #region マスタから局取得2パターン目.
        /// <summary>
        /// マスタから局取得2パターン目.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string getBaiName2(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd)
        {
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            {
                return string.Empty; 
            }

            //局名.
            foreach (RepDsAsh.BaiCdRow row in bcrow)
            {
                //入力された値の場合.
                if (row.field1.Equals(kyokuryakusyo.Trim()))
                {
                    //マスタと同じ種別の場合.
                    if (row.sybt.Equals(baitaiCd))
                    {
                        return row.field2.ToString();
                    }
                }
            }

            return string.Empty;
        }
        #endregion マスタから局取得2パターン目.

        /* 2015/07/08 アサヒ対応 HLC K.Soga ADD Start */
        #region マスタから局取得その他マスター用.
        /// <summary>
        /// マスタから局取得その他マスター用.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <param name="baiCd"></param>
        /// <returns></returns>
        private string getBaiNameSonota(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd, string baicd)
        {
            //局コードが空の場合.
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            { 
                return string.Empty; 
            }

            //局名の取得.
            RepDsAsh.BaiCdRow[] row = (RepDsAsh.BaiCdRow[])bct.Select("sybt = '" + baitaiCd + "' AND Field1 = '" + kyokuryakusyo + "' AND Field9 = '" + baicd + "' ");

            //取得した件数が0件の場合.
            if (row.Length == 0)
            {
                return string.Empty;
            }
            else
            {   
                return row[0].field2.ToString();
            }
        }
        #endregion マスタから局取得その他マスター用.
        /* 2015/07/08 アサヒ対応 HLC K.Soga ADD End */

        #region 掲載版取得.
        /// <summary>
        /// 掲載版取得.
        /// </summary>
        /// <param name="sonota6"></param>
        /// <returns></returns>
        private string keisaiGet(string sonota6)
        {
            if (string.IsNullOrEmpty(sonota6)) 
            {
                return string.Empty; 
            }
            string keisaiban = string.Empty;
            switch (sonota6)
            {
                case KkhConstAsh.KeisaiKbn.KEIKBN_ZENBAN:
                    keisaiban = "全版通し";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOU:
                    keisaiban = "統合版";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOUNUKI:
                    keisaiban = "統合抜き";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_YUKAN:
                    keisaiban = "夕刊＋統合版";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TIIKIKOUKOKU:
                    keisaiban = "地域広告";
                    break;
            }

            return keisaiban;
        }
        #endregion 掲載版取得.

        #region 記雑区分取得.
        /// <summary>
        /// 記雑区分取得.
        /// </summary>
        /// <param name="sonota5"></param>
        /// <returns></returns>
        private string kizatuGet(string sonota5)
        {
            if (string.IsNullOrEmpty(sonota5)) 
            {
                return string.Empty; 
            }

            string kizatu = string.Empty;

            switch (sonota5)
            {
                case KKHSystemConst.KizatsuKbn.KIZKN_KIJISITA:
                    kizatu = "記事下";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_KIJINAKA:
                    kizatu = "記事中";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_TOSYUTU:
                    kizatu = "突　出";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_DAIJI:
                    kizatu = "題　字";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_HASAKOMI:
                    kizatu = "挟　込";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_TOKUSYU:
                    kizatu = "特殊雑報";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_ANNAI:
                    kizatu = "案　内";
                    break;
            }

            return kizatu;
        }
        #endregion 記雑区分取得.

        #region 年月日取得.
        /// <summary>
        /// 年月日取得.
        /// </summary>
        /// <param name="oldYymmdd"></param>
        /// <returns></returns>
        private string YyMmDd(string oldYymmdd)
        {
            if (oldYymmdd.Length != 8) 
            {
                return string.Empty; 
            }

            string newYymmdd = oldYymmdd.Substring(0, 4) + "年" + oldYymmdd.Substring(4, 2) + "月" + oldYymmdd.Substring(6, 2) + "日";

            return newYymmdd;
        }
        #endregion 年月日取得.

        #region 商品ネーム取得.
        /// <summary>
        /// 商品ネーム取得.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="srow"></param>
        /// <param name="sybt"></param>
        /// <returns></returns>
        private string mastNameGet(string key, RepDsAsh.SyohinRow[] srow, string sybt)
        {
            if (string.IsNullOrEmpty(key)) 
            {
                return string.Empty; 
            }

            foreach (RepDsAsh.SyohinRow row in srow)
            {
                if (row.field1.Equals(key) && row.sybt.Equals(sybt))
                {
                    if (row.field2.Length > 20)
                    {
                        return row.field2.Substring(0, 20);
                    }
                    else
                    {
                        return row.field2;
                    }
                }
            }

            return string.Empty;
        }
        #endregion 商品ネーム取得.

        #region Excel作成用データ格納.
        /// <summary>
        /// Excel作成用データ格納.
        /// </summary>
        private void excelDataSet()
        {
            //パラメーターのセット.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = _yearMonth;

            //検索.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMedia(param);

            if (result.HasError)
            {
                return;
            }

            RepDsAsh.RepAshMediaRow[] resultRow = (RepDsAsh.RepAshMediaRow[])result.dsAshDataSet.RepAshMedia.Select("", "");

            baikbn = cmbMedia.SelectedIndex;
            /* 2013/03/04 アサヒ対応 JSE Miyanoue MOD Strat */
            //baitaiName = cmbMedia.SelectedItem.ToString();
            baitaiName = cmbMedia.Text.ToString();
            /* 2013/03/04 アサヒ対応 JSE Miyanoue MOD End */
            /* 2015/06/29 アサヒビール問い合わせ対応 K.Fujisaki DEL Start */
            ////「屋外広告」の場合は「屋外」に置き換える.
            //if (baitaiName.Equals(KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU))
            //{
            //    baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
            //}
            /* 2015/06/29 アサヒビール問い合わせ対応 K.Fujisaki DEL End */

            tableToDel.Clear();
            tableToDel.displayMedia.Merge(repds.displayMedia);
            tableToDel.allbaitai.Merge(repds.allbaitai);
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki MOD Start */
            //if (cmbMedia.SelectedIndex == 18 || cmbMedia.SelectedIndex == 19)
            if (cmbMedia.SelectedIndex == cmbMedia.Items.Count - 2 || cmbMedia.SelectedIndex == cmbMedia.Items.Count - 1)
            /* 2013/02/22 PR媒体追加対応 JSE Okazaki MOD End */
            {
                //何もしない.
            }
            else
            {
                RepDsAsh.displayMediaRow[] Checkrow = (RepDsAsh.displayMediaRow[])repds.displayMedia.Select("", "");

                //選択された媒体のデータが存在するかのフラグ.
                bool chflg = false;
                foreach (RepDsAsh.displayMediaRow chrow in Checkrow)
                {
                    //スプレッドの[baitaiName]がnull以外を対象とする.
                    if (!string.IsNullOrEmpty(chrow.baitaiName))
                    {
                        //[出力媒体選択]で指定した媒体の場合、フラグをtrueにする.
                        if (chrow.baitaiName.Equals(baitaiName))
                        {
                            chflg = true; 
                        }
                    }
                }
                //フラグがfalseの場合.
                if (!chflg)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0038, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                //必要のない媒体データの削除.
                RepDsAsh.displayMediaRow[] delrow1 = (RepDsAsh.displayMediaRow[])tableToDel.displayMedia.Select("baitaiName NOT IN ('" + baitaiName + "')");
                foreach (RepDsAsh.displayMediaRow row1 in delrow1)
                {
                    tableToDel.displayMedia.Rows.Remove(row1);
                }

                string MerelyBaitai = string.Empty;
                RepDsAsh.allbaitaiRow[] delrow2 = (RepDsAsh.allbaitaiRow[])tableToDel.allbaitai.Select("baitaicd NOT IN ('" + baitaiCdOfIndex(baikbn) + "')");
                foreach (RepDsAsh.allbaitaiRow row2 in delrow2)
                {
                    tableToDel.allbaitai.Rows.Remove(row2);
                }
                RepDsAsh.displayMediaRow[] delrow3 = (RepDsAsh.displayMediaRow[])tableToDel.displayMedia.Select("baitaiName is null");
                foreach (RepDsAsh.displayMediaRow row3 in delrow3)
                {
                    tableToDel.displayMedia.Rows.Remove(row3);
                }
            }
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD Start */
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //旧媒体コードから新媒体名称、新媒体コードを取得する.
            for (int i = 0; i < tableToDel.displayMedia.Rows.Count; i++)
            {
                String baitaiCd = tableToDel.displayMedia[i].baitaiCd;
                String baitaiNm = tableToDel.displayMedia[i].baitaiName;

                //媒体コード長.
                int totalLen = baitaiCd.Length;
                //下1桁を除いた媒体コード長さ.
                int len = totalLen - 1;

                //媒体コードを変換する.
                String bCd = baitaiCd.Substring(0, len);
                String bCd1keta = baitaiCd.Substring(len, 1);

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(bCd);

                String resultBaitaiCd = res.baitaiCd + bCd1keta;
                tableToDel.displayMedia[i].tokuisakiBaitaiCd = resultBaitaiCd;
                tableToDel.displayMedia[i].tokuisakiBaitaiName = res.baitaiNm;
            }
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD End */

            //エクセル出力ファイルの設定.
            excelFileSet();
        }
        #endregion Excel作成用データ格納.

        #region エクセル出力のファイル設定.
        /// <summary>
        /// エクセル出力のファイル設定.
        /// </summary>
        private void excelFileSet()
        {
            //ファイル保存場所設定クラスのインスタンス化.
            SaveFileDialog sfd = new SaveFileDialog();
            //現在日時.
            DateTime nowdate = DateTime.Now;

            //初期ファイル名.
            if (cmbMedia.Text.Trim() != KkhConstAsh.BaitaiNm.ALL_BAITAI)
            {
                sfd.FileName = pStrRepFilNam + "_" + cmbMedia.Text.Trim() + nowdate.ToString("yyyyMMddHHmmss") + ".xlsx";
            }
            else
            {
                sfd.FileName = pStrRepFilNam + "_" + nowdate.ToString("yyyyMMddHHmmss") + ".xlsx";
            }
            //初期ファイル保存先.
            sfd.InitialDirectory = pStrRepAdrs;
            //ファイル種類の選択肢を設定.
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            //初期ファイル種類の設定.
            //[すべてのファイル]を設定.
            sfd.FilterIndex = 0;
            //タイトルの設定.
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示し、Okボタンが押下された場合.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                //出力実行.
                this.ExcelOut(sfd.FileName);
            }
        }
        #endregion エクセル出力のファイル設定.

        #region エクセル出力.
        /// <summary>
        /// エクセル出力.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            /* 2015/03/17 アサヒ対応 JSE Miyanoue ADD Start */
            string macrofile = "";
            string tempfile = "";

            //作業用フォルダパス.
            string workFolderPath = pStrRepTempAdrs;
            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
            {
                macrofile = workFolderPath + REP_MACRO_FILENAME;
                tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            }
            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
            {
                macrofile = workFolderPath + REP_MACRO_FILENAME_BEER;
                tempfile = workFolderPath + REP_TEMPLATE_FILENAME_BEER;
            }
            /* 2015/03/17 アサヒ対応 JSE Miyanoue ADD End */

            //テーブル追加用データRow.
            DataRow dtRow;

            try
            {
                /* 2015/03/17 アサヒ対応 JSE Miyanoue MOD Start */
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                //File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Medium);
                //File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Medium_Template);

                //飲料の場合.
                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                {
                    File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Medium);
                    File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Medium_Template);
                }
                //ビールの場合.
                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                {
                    File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.AshBeer_Medium);
                    File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.AshBeer_Medium_Template);
                }
                /* 2015/03/17 アサヒ対応 JSE Miyanoue MOD End */

                if (System.IO.File.Exists(tempfile) == false) 
                {
                    throw new Exception("テンプレートExcelファイルがありません。"); 
                }

                if (System.IO.File.Exists(macrofile) == false) 
                {
                    throw new Exception("マクロExcelファイルがありません。"); 
                }

                //データセットXML出力.
                tableToDel.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                /*
                 * パラメータXML作成、出力.
                 */
                //変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                //データセットにテーブルを追加する.
                //PRODUCTSというテーブルを作成する. 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAINAME", Type.GetType("System.String"));
                dtTable.Columns.Add("HEADERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAICOUNT", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["BAITAINAME"] = baitaiName;

                string headerName = string.Empty;
                string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
                if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Ash))
                {
                    headerName = KKHSystemConst.TksKgyName.TksKgyName_Ash;
                }
                else if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear))
                {
                    headerName = KKHSystemConst.TksKgyName.TksKgyName_AshBear;
                }
                if (string.IsNullOrEmpty(headerName))
                {
                    throw new Exception();
                }
                dtRow["HEADERNAME"] = headerName;

                //該当媒体カウント取得.
                string baitaicount = "";
                if (_dicBaitai.ContainsKey(baitaiCdOfIndex(baikbn)))
                {
                    baitaicount = _dicBaitai[baitaiCdOfIndex(baikbn)].ToString();
                }
                dtRow["BAITAICOUNT"] = baitaicount;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                /* 2015/03/17 アサヒ対応 JSE Miyanoue ADD Start */
                /*
                 * エクセル起動.
                 */
                //飲料の場合.
                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                {
                    System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                    //削除用に保持(戻るボタン押下時に削除する為).
                    _strmacrodel = workFolderPath + REP_MACRO_FILENAME;
                }
                //ビールの場合.
                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                {
                    System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME_BEER);

                    //削除用に保持(戻るボタン押下時に削除する為).
                    _strmacrodel = workFolderPath + REP_MACRO_FILENAME_BEER;
                }
                /* 2015/03/17 アサヒ対応 JSE Miyanoue ADD End */

                // オペレーションログの出力.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_MEDIUM, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_Medium, KKHLogUtilityAsh.DESC_OPERATION_LOG_Medium);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion エクセル出力.

        #region インデックスから媒体コード取得.
        /// <summary>
        /// インデックスから媒体コード取得.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string baitaiCdOfIndex(int index)
        {
            switch (index)
            {
                case 0://テレビタイム.
                    return KkhConstAsh.BaitaiCd.TV_TIME;
                case 1://ラジオタイム.
                    return KkhConstAsh.BaitaiCd.RADIO_TIME;
                case 2://ラジオスポット.
                    return KkhConstAsh.BaitaiCd.RADIO_SPOT;
                case 3://テレビスポット.
                    return KkhConstAsh.BaitaiCd.TV_SPOT;
                case 4://新聞.
                    return KkhConstAsh.BaitaiCd.SHINBUN;
                case 5://雑誌.
                    return KkhConstAsh.BaitaiCd.ZASHI;
                case 6://交通.
                    return KkhConstAsh.BaitaiCd.KOUTSU;
                case 7://制作.
                    return KkhConstAsh.BaitaiCd.SEISAKU;
                /* 2013/02/22 PR媒体追加対応 JSE Okazaki MOD Start */
                //case 8://その他.
                //    return KkhConstAsh.BaitaiCd.SONOTA;
                //case 9://ﾆｭｰﾒﾃﾞｨｱ.
                //    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                //case 10://ｲﾝﾀｰﾈｯﾄ.
                //    return KkhConstAsh.BaitaiCd.INTERNET;
                //case 11://BS.
                //    return KkhConstAsh.BaitaiCd.BS;
                //case 12://CS.
                //    return KkhConstAsh.BaitaiCd.CS;
                //case 13://屋外広告.
                //    return KkhConstAsh.BaitaiCd.OKUGAI;
                //case 14://ｲﾍﾞﾝﾄ.
                //    return KkhConstAsh.BaitaiCd.EVENT;
                //case 15://調査.
                //    return KkhConstAsh.BaitaiCd.TYOUSA;
                //case 16://メディアフィー.
                //    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                //case 17://ブランド管理フィー.
                //    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                case 8://PR.
                    return KkhConstAsh.BaitaiCd.PR;
                case 9://その他.
                    return KkhConstAsh.BaitaiCd.SONOTA;
                case 10://ﾆｭｰﾒﾃﾞｨｱ.
                    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                case 11://ｲﾝﾀｰﾈｯﾄ.
                    return KkhConstAsh.BaitaiCd.INTERNET;
                case 12://BS.
                    return KkhConstAsh.BaitaiCd.BS;
                case 13://CS.
                    return KkhConstAsh.BaitaiCd.CS;
                case 14://屋外広告.
                    return KkhConstAsh.BaitaiCd.OKUGAI;
                case 15://ｲﾍﾞﾝﾄ.
                    return KkhConstAsh.BaitaiCd.EVENT;
                case 16://調査.
                    return KkhConstAsh.BaitaiCd.TYOUSA;
                case 17://メディアフィー.
                    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                case 18://ブランド管理フィー.
                    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                /* 2013/02/22 PR媒体追加対応 JSE Okazaki MOD End */
            }

            return string.Empty;
        }
        #endregion インデックスから媒体コード取得.

        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL Start */
        #region 小数点を指定の位置で四捨五入する.
        ///// <summary>
        ///// 小数点を指定の位置で四捨五入する.
        ///// </summary>
        ///// <param name="dValue">四捨五入する値</param>
        ///// <param name="iDigits">小数点以下の桁数</param>
        ///// <returns></returns>
        //public static double ToHalfAdjust(double dValue, int iDigits)
        //{
        //    double dv = dValue % 1.0;
        //    if (dv.ToString().Length <= 1) { return dValue; }

        //    double dCoef = System.Math.Pow(10, iDigits);

        //    return dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
        //                        System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
        //}
        #endregion 小数点を指定の位置で四捨五入する.
        /* 2016/11/22 アサヒ消費税対応 HLC K.Soga DEL End */

        #region 合算処理.
        /// <summary>
        /// 合算処理.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private string clcRyokin(string val1, string val2)
        {
            if (string.IsNullOrEmpty(val1))
            {
                val1 = "0";
            }
            if (string.IsNullOrEmpty(val2))
            {
                val2 = "0";
            }
            double dbl1 = double.Parse(val1);
            double dbl2 = double.Parse(val2);
            double dbl3 = dbl1 + dbl2;

            return dbl3.ToString();
        }
        #endregion 合算処理.

        #region カンマ設定.
        /// <summary>
        /// カンマ設定.
        /// </summary>
        private void SetComma(RepDsAsh dsash)
        {
            for (int i = 0; i < dsash.displayMedia.Rows.Count; i++)
            {
                double kanma = 0;
                //金額.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].kingak))
                {
                    kanma = double.Parse(dsash.displayMedia[i].kingak);
                    dsash.displayMedia[i].kingak = kanma.ToString("#,0");
                }
                //値引額.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].nebiki))
                {
                    kanma = double.Parse(dsash.displayMedia[i].nebiki);
                    dsash.displayMedia[i].nebiki = kanma.ToString("#,0");
                }
                //消費税.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].syouhiZei))
                {
                    kanma = double.Parse(dsash.displayMedia[i].syouhiZei);
                    dsash.displayMedia[i].syouhiZei = kanma.ToString("#,0");
                }
                //掲載料.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].keisaiRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].keisaiRyo);
                    dsash.displayMedia[i].keisaiRyo = kanma.ToString("#,0");
                }
                //指定料.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].siteiRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].siteiRyo);
                    dsash.displayMedia[i].siteiRyo = kanma.ToString("#,0");
                }
                //色刷料.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].sikisatuRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].sikisatuRyo);
                    dsash.displayMedia[i].sikisatuRyo = kanma.ToString("#,0");
                }
                //制作費.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].seisakuhi))
                {
                    kanma = double.Parse(dsash.displayMedia[i].seisakuhi);
                    dsash.displayMedia[i].seisakuhi = kanma.ToString("#,0");
                }
                //掲載料値引後.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].keisaiNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].keisaiNebiAfter);
                    dsash.displayMedia[i].keisaiNebiAfter = kanma.ToString("#,0");
                }
                //指定料値引後.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].siteiNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].siteiNebiAfter);
                    dsash.displayMedia[i].siteiNebiAfter = kanma.ToString("#,0");
                }
                //色刷料値引後.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].sikisatuNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].sikisatuNebiAfter);
                    dsash.displayMedia[i].sikisatuNebiAfter = kanma.ToString("#,0");
                }
            }
        }
        #endregion カンマ設定.
        #endregion  メソッド.
    }
}
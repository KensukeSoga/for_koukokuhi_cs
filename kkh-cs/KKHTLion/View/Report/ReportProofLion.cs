using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Lion.Properties;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.Utility;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// ライオンプルーフリスト出力.
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
    ///       <description>2012/02/13</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportProofLion : KKHForm
    {
        #region 定数.

        #region 媒体区分.

        /// <summary>
        /// 媒体：テレビタイム.
        /// </summary>
        private const string C_BAITAI_TV_TIME = "テレビタイム";
        /// <summary>
        /// 媒体：ラジオタイム.
        /// </summary>
        private const string C_BAITAI_RD_TIME = "ラジオタイム";
        /// <summary>
        /// 媒体：テレビスポット.
        /// </summary>
        private const string C_BAITAI_TV_SPOT = "テレビスポット";
        /// <summary>
        /// 媒体：ラジオスポット.
        /// </summary>
        private const string C_BAITAI_RD_SPOT = "ラジオスポット";
        /// <summary>
        /// 媒体：新聞.
        /// </summary>
        private const string C_BAITAI_SHINBUN = "新聞";
        /// <summary>
        /// 媒体：雑誌.
        /// </summary>
        private const string C_BAITAI_ZASHI = "雑誌";
        /// <summary>
        /// 媒体：交通.
        /// </summary>
        private const string C_BAITAI_KOTSU = "交通";
        /// <summary>
        /// 媒体：その他.
        /// </summary>
        private const string C_BAITAI_SONOTA = "その他";
        /// <summary>
        /// 媒体：制作.
        /// </summary>
        private const string C_BAITAI_SEISAKU = "制作";
        /// <summary>
        /// 媒体：テレビCM秒数.
        /// </summary>
        private const string C_BAITAI_TV_CM = "ＴＶＣＭ秒数";
        /// <summary>
        /// 媒体：ラジオCM秒数.
        /// </summary>
        private const string C_BAITAI_RD_CM = "ラジオＣＭ秒数";
        /// <summary>
        /// 媒体：チラシ.
        /// </summary>
        private const string C_BAITAI_CHIRASHI = "チラシ";
        /// <summary>
        /// 媒体：サンプリング.
        /// </summary>
        private const string C_BAITAI_SAMPLING = "サンプリング";
        /// <summary>
        /// 媒体：BS/CS
        /// </summary>
        private const string C_BAITAI_BS_CS = "ＢＳ・ＣＳ";
        /// <summary>
        /// 媒体：インターネット.
        /// </summary>
        private const string C_BAITAI_INTERNET = "インターネット";
        /// <summary>
        /// 媒体：モバイル.
        /// </summary>
        private const string C_BAITAI_MOBILE = "モバイル";
        /// <summary>
        /// 媒体：事業費.
        /// </summary>
        private const string C_BAITAI_JIGYOUBU = "事業費";

        #endregion 媒体区分.

        #region 帳票出力関連.

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Lion_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Lion_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Lion_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Lion_Mcr.xlsm";
        /// <summary>
        /// 汎用マスタ：ブランドマスタ＜未使用＞.
        /// </summary>
        //private static readonly string C_HBAMST_SYBT_BRAND = "0005";
        /// <summary>
        /// レポートライオンデータテーブル名.
        /// </summary>
        private const string LION_TBLNM = "RepLion";
        /// <summary>
        /// リレーション名(TVブランド)
        /// </summary>
        private const string RELNM_TVBRAND = "TvCmLion_BrandLion";
        /// <summary>
        /// リレーション名(TV局)
        /// </summary>
        private const string RELNM_TVKYOKU = "TvCmLion_TvKLion";
        /// <summary>
        /// リレーション名(TV番組)
        /// </summary>
        private const string RELNM_TVBANGUMI = "TvCmLion_TvBnLion";
        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "Proof";

        /* 2014/09/30 消費税端数調整対応 HLC fujimoto ADD start */
        /// <summary>
        /// 帳票ファイル名.
        /// </summary>
        private const string REP_FILENAME = "プルーフリスト";
        /* 2014/09/30 消費税端数調整対応 HLC fujimoto ADD end */

        #endregion 帳票出力関連.

        #region プルーフリストスプレッド列インデックス.

        #region テレビタイム.

        private const int COLIDX_TIME_CARDNO = 0;         //カードNo.
        private const int COLIDX_TIME_YYMM = 1;           //年月.
        private const int COLIDX_TIME_DAIRITENCD = 2;     //代理店コード.
        private const int COLIDX_TIME_BAITAICD = 3;       //媒体区分.
        private const int COLIDX_TIME_PGNCD = 4;          //番組コード.
        private const int COLIDX_TIME_KYKCD = 5;          //局誌コード.
        private const int COLIDX_TIME_KYKNM = 6;          //局誌名称.
        private const int COLIDX_TIME_DNPAMT = 7;         //電波料.
        private const int COLIDX_TIME_NETAMT = 8;         //ネット料.
        private const int COLIDX_TIME_SEIAMT = 9;         //制作料.
        private const int COLIDX_TIME_INVAMT = 10;        //請求金額合計.
        private const int COLIDX_TIME_BRDTAXAMT = 11;     //ブランド消費税額.
        private const int COLIDX_TIME_TAXAMT = 12;        //消費税額.
        private const int COLIDX_TIME_ONAIRQTY = 13;      //放送回数.
        private const int COLIDX_TIME_PGMNM = 14;         //番組名.

        #endregion テレビタイム.

        #region テレビスポット.

        private const int COLIDX_SPOT_CARDNO = 0;         //カードNo.
        private const int COLIDX_SPOT_YYMM = 1;           //データ年月.
        private const int COLIDX_SPOT_DAIRITENCD = 2;     //代理店コード.
        private const int COLIDX_SPOT_BAITAICD = 3;       //媒体区分.
        private const int COLIDX_SPOT_BRDCD = 4;          //ブランドコード.
        private const int COLIDX_SPOT_BRDNM = 5;          //ブランド名称.
        private const int COLIDX_SPOT_KYKCD = 6;          //局誌コード.
        private const int COLIDX_SPOT_KYKNM = 7;          //局誌名称.
        private const int COLIDX_SPOT_INVAMT = 8;         //請求額.
        private const int COLIDX_SPOT_BRDTAXAMT = 9;      //ブランド消費税額.
        private const int COLIDX_SPOT_TAXAMT = 10;        //消費税額.
        private const int COLIDX_SPOT_CMSEC = 11;         //CM1本の秒数.
        private const int COLIDX_SPOT_CMTIME = 12;        //本数.
        private const int COLIDX_SPOT_TOTALCMSEC = 13;    //秒数.
        private const int COLIDX_SPOT_CMPTERM = 14;       //キャンペーン期間.

        #endregion テレビスポット.

        #region BS/CS.

        private const int COLIDX_BSCS_CARDNO = 0;       //カードNo.
        private const int COLIDX_BSCS_YYMM = 1;         //データ年月.
        private const int COLIDX_BSCS_DAIRITENCD = 2;   //代理店コード.
        private const int COLIDX_BSCS_BAITAICD = 3;     //媒体区分.
        private const int COLIDX_BSCS_PGMCD = 4;        //番組コード.
        private const int COLIDX_BSCS_KYKCD = 5;        //局誌コード.
        private const int COLIDX_BSCS_KYKNM = 6;        //局誌名称.
        private const int COLIDX_BSCS_DNPAMT = 7;       //電波料.
        private const int COLIDX_BSCS_INVAMT = 8;       //請求額合計.
        private const int COLIDX_BSCS_BRDTAXAMT = 9;    //ブランド消費税額.
        private const int COLIDX_BSCS_TAXAMT = 10;      //消費税額.
        private const int COLIDX_BSCS_ONAIRTM = 11;     //放送回数.
        private const int COLIDX_BSCS_PGMNM = 12;       //番組名.

        #endregion BS/CS.

        #region 新聞.

        private const int COLIDX_NP_CARDNO = 0;     //カードNo.
        private const int COLIDX_NP_YYMM = 1;       //データ年月.
        private const int COLIDX_NP_DAIRITENCD = 2; //代理店コード.
        private const int COLIDX_NP_BAITAICD = 3;   //媒体区分.
        private const int COLIDX_NP_BRDCD = 4;      //ブランドコード.
        private const int COLIDX_NP_BRDNM = 5;      //ブランド名称.
        private const int COLIDX_NP_NPCD = 6;       //新聞コード.
        private const int COLIDX_NP_NPNM = 7;       //新聞名称.
        private const int COLIDX_NP_QUTAMT = 8;     //実施料.
        private const int COLIDX_NP_INVAMT = 9;     //請求額.
        private const int COLIDX_NP_BRDTAXAMT = 10; //ブランド消費税額.
        private const int COLIDX_NP_TAXAMT = 11;    //消費税額.
        private const int COLIDX_NP_RMK = 12;       //備考.

        #endregion 新聞.

        #region 雑誌.

        private const int COLIDX_MZ_CARDNO = 0;     //カードNo.
        private const int COLIDX_MZ_YYMM = 1;       //データ年月.
        private const int COLIDX_MZ_DAIRITENCD = 2; //代理店コード.
        private const int COLIDX_MZ_BAITAICD = 3;   //媒体区分.
        private const int COLIDX_MZ_BRDCD = 4;      //ブランドコード.
        private const int COLIDX_MZ_BRDNM = 5;      //ブランド名称.
        private const int COLIDX_MZ_MZCD = 6;       //雑誌コード.
        private const int COLIDX_MZ_MZNM = 7;       //雑誌名称.
        private const int COLIDX_MZ_SPC = 8;        //スペース.
        private const int COLIDX_MZ_QOTAMT = 9;     //実施料.
        private const int COLIDX_MZ_INVAMT = 10;    //請求額.
        private const int COLIDX_MZ_BRDTAXAMT = 11; //ブランド消費税額.
        private const int COLIDX_MZ_TAXAMT = 12;    //消費税額.
        private const int COLIDX_MZ_RMK = 13;       //備考.

        #endregion 雑誌.

        #region 交通.

        private const int COLIDX_TR_CARDNO = 0;     //カードNo.
        private const int COLIDX_TR_YYMM = 1;       //データ年月.
        private const int COLIDX_TR_DAIRITENCD = 2; //代理店コード.
        private const int COLIDX_TR_BAITAICD = 3;   //媒体区分.
        private const int COLIDX_TR_BRDCD = 4;      //ブランドコード.
        private const int COLIDX_TR_BRDNM = 5;      //ブランド名称.
        private const int COLIDX_TR_PREFCD = 6;     //県コード.
        private const int COLIDX_TR_PREFNM = 7;     //県名称.
        private const int COLIDX_TR_INVAMT = 8;     //請求額.
        private const int COLIDX_TR_BRDTAXAMT = 9;  //ブランド消費税額.
        private const int COLIDX_TR_TAXAMT = 10;    //消費税額.
        private const int COLIDX_TR_RAILNM = 11;    //路線名.
        private const int COLIDX_TR_TERM = 12;      //期間.
        private const int COLIDX_TR_RMK = 13;       //備考.

        #endregion 交通.

        #region インターネット.

        private const int COLIDX_INT_CARDNO = 0;        //カードNo.
        private const int COLIDX_INT_YYMM = 1;          //データ年月.
        private const int COLIDX_INT_DAIRITENCD = 2;    //代理店コード.
        private const int COLIDX_INT_BAITAICD = 3;      //媒体区分.
        private const int COLIDX_INT_BRDCD = 4;         //ブランドコード.
        private const int COLIDX_INT_BRDNM = 5;         //ブランド名称.
        private const int COLIDX_INT_KYKCD = 6;         //局誌コード.
        private const int COLIDX_INT_KYKNM = 7;         //局誌名称.
        private const int COLIDX_INT_INVAMT = 8;        //作成料.
        private const int COLIDX_INT_BRDTAXAMT = 9;     //ブランド消費税額.
        private const int COLIDX_INT_TAXAMT = 10;       //消費税額.
        private const int COLIDX_INT_SUBJECT = 11;      //件名.

        #endregion インターネット.

        #region その他.

        private const int COLIDX_OTH_CARDNO = 0;        //カードNo.
        private const int COLIDX_OTH_YYMM = 1;          //データ年月.
        private const int COLIDX_OTH_DAIRITENCD = 2;    //代理店コード.
        private const int COLIDX_OTH_BAITAICD = 3;      //媒体区分.
        private const int COLIDX_OTH_BRDCD = 4;         //ブランドコード.
        private const int COLIDX_OTH_BRDNM = 5;         //ブランド名称.
        private const int COLIDX_OTH_INVAMT = 6;        //請求額.
        private const int COLIDX_OTH_BRDTAXAMT = 7;     //ブランド消費税額.
        private const int COLIDX_OTH_TAXAMT = 8;        //消費税額.
        private const int COLIDX_OTH_SUBJECT = 9;       //件名.

        #endregion その他.

        #endregion プルーフリストスプレッド系インデックス.

        #endregion 定数.

        #region 構造体.

        /// <summary>
        /// 消費税データ用構造体.
        /// </summary>
        private class GoukeiData
        {
            public double taxRateList;       //消費税率.
            public double goukeiList;        //合計金額.
        };

        #endregion 構造体.

        #region メンバ変数.

        /// <summary>
        /// Naviパラメータ.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// ライオンのデータセット.
        /// </summary>
        DataSet _dsLion = null;

        //保存用データセット＜未使用＞.
        //private FindCommonByCondServiceResult _dtAddrMst;     //アドレス系システムマスタ用.
        //private FindCommonByCondServiceResult _dtFileMst;    //ファイル系システムマスタ用.
        //private MastLion.TvCmLionDataTable _dtTvByoMst;     //TV秒数マスタ用.
        //private MastLion.RdCmLionDataTable _dtRdByoMst;     //RD秒数マスタ用.

        /// <summary>
        /// 保存用データセット(全体用)
        /// </summary>
        private MastLion MastLionDs = new MastLion();

        // 消費税.
        private double _dblShohizei;

        // コピーマクロ削除用string.
        private string _mStrMacroDel;

        /// <summary>
        /// 検索日.
        /// </summary>
        private string _mStrDD;
        /// <summary>
        /// 媒体名.
        /// </summary>
        private string _mStrBaitaiMei;
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string _mStrRepFileMei = string.Empty;
        /// <summary>
        /// REP_KEY_SYBT：001
        /// </summary>
        private const string REP_KEY_SYBT = "001";
        /// <summary>
        /// 消費税別合計.
        /// </summary>
        private List<GoukeiData> RateGoukei = new List<GoukeiData>();

        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
        /// <summary>
        /// ブランド別消費税リスト.
        /// </summary>
        private List<GoukeiData> brandTaxList = new List<GoukeiData>();
        /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportProofLion()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面表示時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportLion_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 戻るボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender , EventArgs e)
        {
            if (_mStrMacroDel != null)
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

            Navigator.Backward(this , null , _naviParam , true);
        }

        /// <summary>
        /// 検索ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender , EventArgs e)
        {
            //*************************************.
            // DBよりレコードを取得.
            //*************************************.
            //レコード取得メソッド.
            this.GetRecord();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 出力ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender , EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            //日付とか.
            DateTime now = DateTime.Now;

            //はじめのファイル名を指定する.
            //sfd.FileName = now.ToString("yyyyMMdd") + _mStrRepFileMei + ".xls";
            /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD start */
            //sfd.FileName = _mStrRepFileMei + "_" + now.ToString("yyyyMMdd") + ".xls";
            sfd.FileName = REP_FILENAME + "_" + _mStrBaitaiMei + "_" + now.ToString("yyyyMMddHHmm") + ".xls";
            /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD end */

            //はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = _mStrRepAdrs;

            //[ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter = "XLSファイル(*.xls)|*.xls";

            //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            //タイトルを設定する.
            sfd.Title = "保存先のファイルを設定して下さい。";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示する.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する。.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "プルーフリスト", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

            sfd.Dispose();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 画面表示時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportLion_Shown(object sender , EventArgs e)
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
            SprSyokika();

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

                //消費税セット.
                _dblShohizei = KKHUtility.DouParse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
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
                                                                                            REP_KEY_SYBT);

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
                //MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "プルーフリスト", MessageBoxButtons.OK);
                base.CloseLoadingDialog();
                Navigator.Backward(this , null , _naviParam , true);
                return;
            }

            //コンボボックスの先頭の項目をセット.
            cmbBaitai.SelectedIndex = 0;
            base.CloseLoadingDialog();
        }

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

        #endregion イベント.

        #region メソッド.

        /// <summary>
        /// レコード取得メソッド.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            #region 共通処理.

            //媒体名を取得.
            _mStrBaitaiMei = cmbBaitai.Text;

            // 年月の取得.
            string yyyyMm = dtpYyyyMmDd.Value.ToString("yyyyMM");
            //string yyyyMm = getYYYYMM();

            FindReportLionByCondServiceResult result = new FindReportLionByCondServiceResult();
            KKHLionReadMastFile readMastFile = new KKHLionReadMastFile();

            //媒体がテレビ、ラジオCM秒数以外の場合.
            if (_mStrBaitaiMei != C_BAITAI_TV_CM
                && _mStrBaitaiMei != C_BAITAI_RD_CM)
            {
                //*******************.
                //サービスの呼び出し.
                //*******************.
                ReportLionProcessController processController = ReportLionProcessController.GetInstance();
                result = processController.FindRepLionByCond(
                                                          _naviParam.strEsqId ,
                                                          _naviParam.strEgcd ,
                                                          _naviParam.strTksKgyCd ,
                                                          _naviParam.strTksBmnSeqNo ,
                                                          _naviParam.strTksTntSeqNo ,
                                                          yyyyMm ,
                                                          _mStrBaitaiMei
                                                          );

                //エラーの場合.
                if (result.HasError)
                {
                    statusStrip1.Items["tslval1"].Text = "0件";

                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }

                //取得結果が0件の場合.
                if (( result.dsRepLionDataSet.RepLion.Rows.Count == 0 )
                    && ( _mStrBaitaiMei != C_BAITAI_SONOTA ))
                {
                    //スプレッド初期化.
                    SprSyokika();

                    //Excelボタン押下不可能.
                    btnXls.Enabled = false;

                    _dsLion = null;

                    statusStrip1.Items["tslval1"].Text = "0件";

                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
                }
            }

            //スプレッドシートの初期化.
            SprSyokika();

            //初期化.
            RateGoukei.Clear();
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
            brandTaxList.Clear();
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

            #endregion 共通処理.

            //****************************************.
            //スプレッドに表示(件数分表示).
            //****************************************.
            //シートを判別.

            #region 制作.

            //制作の場合.
            if (_mStrBaitaiMei.Equals(C_BAITAI_SEISAKU))
            {
                //シートを表示する.
                sprSeisaku.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    int _intseisakuRow = 0;                                       //行数.
                    string _strseisakuBrandCd = string.Empty;                     //ブランドコード.
                    string JanleName = string.Empty;                              //ジャンル名.
                    string JanleCd = string.Empty;                                //ジャンルコード.
                    string Yymm = yyyyMm;                                        //データ年月.
                    string CardNo = string.Empty;                                 //カードNo.
                    string AgentCd = string.Empty;                                //代理店コード.
                    string BrandName = string.Empty;                              //代理店名.
                    double SeisakuSyohizeiGak = 0;                                //制作消費税.
                    double SeisakuSyohizeiGak_Talent = 0;                         //制作消費税(タレント用)
                    double _brandSeiSyoukeiseisaku = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeiseisaku = 0;                           //代理店請求額小計.
                    double SumSyouhiZeiGak = 0;                                   //消費税合計.
                    double _JanleSeiSyoukeiseisaku = 0;                           //ジャンル請求額.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strseisakuBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                            JanleName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLENAME"].ToString();
                            JanleCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLECD"].ToString();
                            CardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();
                            AgentCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();
                            BrandName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();
                        }

                        //ブランドコードのブレイク.
                        if (!_strseisakuBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //制作消費税を入力.
                            if (SeisakuSyohizeiGak != 0)
                            {
                                //ジャンル名称.
                                sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
                                //カードNo.
                                sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
                                //データ年月 .
                                sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
                                //代理店コード .
                                sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
                                //媒体区分.
                                sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
                                //媒体名称.
                                sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(1)";
                                //ブランドコード.
                                sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
                                //ブランド名称.
                                sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
                                //消費税.
                                //2013/07/01 hlc sonobe 件名追加 Update Start
                                //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
                                sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
                                //2013/07/01 hlc sonobe 件名追加 Update End
                                //消費税合計を加算.
                                SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;
                                //スプレッドシートに行を追加.
                                sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                                _intseisakuRow++;
                            }
                            //制作消費税(タレント用)を入力.
                            if (SeisakuSyohizeiGak_Talent != 0)
                            {
                                //ジャンル名称.
                                sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
                                //カードNo
                                sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
                                //データ年月.
                                sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
                                //代理店コード.
                                sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
                                //媒体区分.
                                sprSeisaku.Cells[_intseisakuRow, 4].Value = "41";
                                //媒体名称.
                                sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(2)";
                                //ブランドコード.
                                sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
                                //ブランド名称.
                                sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
                                //消費税.
                                //2013/07/01 hlc sonobe 件名追加 Update Start
                                //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                                sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                                //2013/07/01 hlc sonobe 件名追加 Update End
                                //消費税合計を加算.
                                SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;
                                //スプレッドシートに行を追加.
                                sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                                _intseisakuRow++;
                            }

                            //2013/07/01 hlc sonobe 件名追加 Update Start
                            ////ブランド名称.
                            //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ブランド計";
                            ////請求額.
                            //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_brandSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent).ToString("#,0");
                            //ブランド名称.
                            sprSeisaku.Cells[_intseisakuRow, 8].Value = "ブランド計";
                            //請求額.
                            sprSeisaku.Cells[_intseisakuRow, 9].Value = (_brandSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent).ToString("#,0");
                            //2013/07/01 hlc sonobe 件名追加 Update End

                            _JanleSeiSyoukeiseisaku = _JanleSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;
                            _dairiSeiSyoukeiseisaku = _dairiSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;

                            //初期化.
                            SeisakuSyohizeiGak = 0;
                            SeisakuSyohizeiGak_Talent = 0;
                            _brandSeiSyoukeiseisaku = 0;

                            //データ格納.
                            _strseisakuBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                            JanleName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLENAME"].ToString();
                            CardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();
                            AgentCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();
                            BrandName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                            //スプレッドシートに行を追加.
                            sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                            _intseisakuRow++;
                        }

                        //ジャンルコードのブレイク.
                        if (!JanleCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLECD"].ToString()))
                        {
                            //2013/07/01 hlc sonobe 件名追加 Update Start
                            ////ジャンル名称.
                            //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ジャンル計";
                            ////請求額.
                            //sprSeisaku.Cells[_intseisakuRow, 8].Value = _JanleSeiSyoukeiseisaku.ToString("#,0");
                            //ジャンル名称.
                            sprSeisaku.Cells[_intseisakuRow, 8].Value = "ジャンル計";
                            //請求額.
                            sprSeisaku.Cells[_intseisakuRow, 9].Value = _JanleSeiSyoukeiseisaku.ToString("#,0");
                            //2013/07/01 hlc sonobe 件名追加 Update End

                            _JanleSeiSyoukeiseisaku = 0;

                            JanleCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLECD"].ToString();

                            //スプレッドシートに行を追加.
                            sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                            _intseisakuRow++;
                        }

                        //ジャンル名.
                        sprSeisaku.Cells[_intseisakuRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JANLENAME"].ToString();

                        //カードNo
                        sprSeisaku.Cells[_intseisakuRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprSeisaku.Cells[_intseisakuRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprSeisaku.Cells[_intseisakuRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprSeisaku.Cells[_intseisakuRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //媒体名称.
                        sprSeisaku.Cells[_intseisakuRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BAITAINAME"].ToString();

                        //ブランドコード.
                        sprSeisaku.Cells[_intseisakuRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprSeisaku.Cells[_intseisakuRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //2013/07/01 hlc sonobe 件名追加 Start
                        //件名.
                        sprSeisaku.Cells[_intseisakuRow, 8].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kenmei"].ToString();
                        //2013/07/01 hlc sonobe 件名追加 End

                        //請求額・媒体消費税額を分ける.
                        double SeikyuGak = 0;
                        if (result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString().Trim().Equals("012"))
                        {
                            switch (result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString().Trim())
                            {
                                case "20":
                                case "21":
                                case "23":
                                case "24":
                                case "25":
                                case "27":
                                case "29":
                                case "33":
                                case "35":
                                case "36":
                                case "37":
                                case "38":
                                case "39":
                                    //消費税が0またはempty以外の場合.
                                    if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals(""))
                                    {
                                        SeisakuSyohizeiGak = SeisakuSyohizeiGak + Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString()));
                                    }
                                    SeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                                    //2013/07/01 hlc sonobe 件名追加 Update Start
                                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
                                    sprSeisaku.Cells[_intseisakuRow, 9].Value = SeikyuGak;
                                    //2013/07/01 hlc sonobe 件名追加 Update End
                                    break;
                                case "31":
                                    //消費税が0またはempty以外の場合.
                                    if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals(""))
                                    {
                                        SeisakuSyohizeiGak_Talent = SeisakuSyohizeiGak_Talent + Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString()));
                                    }
                                    SeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                                    //2013/07/01 hlc sonobe 件名追加 Update Start
                                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
                                    sprSeisaku.Cells[_intseisakuRow, 9].Value = SeikyuGak;
                                    //2013/07/01 hlc sonobe 件名追加 Update End
                                    break;
                            }
                        }

                        //消費税が0またはempty以外の場合.
                        if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString().Trim().Equals(""))
                        {
                            ////2013/07/01 hlc sonobe 件名追加 Update Start
                            //消費税.
                            //sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString()))).ToString("#,0");
                            sprSeisaku.Cells[_intseisakuRow, 10].Value = (Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString()))).ToString("#,0");
                            ////2013/07/01 hlc sonobe 件名追加 Update End
                        }

                        ////2013/07/01 hlc sonobe 件名追加 Start
                        ////件名.
                        //sprSeisaku.Cells[_intseisakuRow, 10].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kenmei"].ToString();
                        ////2013/07/01 hlc sonobe 件名追加 End

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiseisaku = _brandSeiSyoukeiseisaku + SeikyuGak;
                        //ジャンル計.
                        _JanleSeiSyoukeiseisaku = _JanleSeiSyoukeiseisaku + SeikyuGak;
                        //代理店請求額.
                        _dairiSeiSyoukeiseisaku = _dairiSeiSyoukeiseisaku + SeikyuGak;

                        _intseisakuRow++;
                    }

                    //制作消費税を入力.
                    if (SeisakuSyohizeiGak != 0)
                    {
                        //スプレッドシートに行を追加.
                        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                        //ジャンル名称.
                        sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
                        //カードNo.
                        sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
                        //データ年月.
                        sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
                        //代理店コード.
                        sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
                        //媒体区分.
                        sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
                        //媒体名称.
                        sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(1)";
                        //ブランドコード.
                        sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
                        //ブランド名称.
                        sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
                        //消費税.
                        //2013/07/01 hlc sonobe 件名追加 Update Start
                        //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
                        sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
                        //2013/07/01 hlc sonobe 件名追加 Update End
                        SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;

                        //加算.
                        _intseisakuRow++;
                    }

                    //制作消費税(タレント用)を入力.
                    if (SeisakuSyohizeiGak_Talent != 0)
                    {
                        //スプレッドシートに行を追加.
                        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                        //ジャンル名称.
                        sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
                        //カードNo
                        sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
                        //データ年月.
                        sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
                        //代理店コード.
                        sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
                        //媒体区分.
                        sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
                        //媒体名称.
                        sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(2)";
                        //ブランドコード.
                        sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
                        //ブランド名称.
                        sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
                        //消費税.
                        //2013/07/01 hlc sonobe 件名追加 Update Start
                        //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                        sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                        //2013/07/01 hlc sonobe 件名追加 Update End
                        SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;

                        //加算.
                        _intseisakuRow++;
                    }

                    //消費税合計.
                    //SumSyouhiZeiGak = SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;
                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    //2013/07/01 hlc sonobe 件名追加 Update Start
                    //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ブランド計";
                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_brandSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = "ブランド計";
                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (_brandSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    //2013/07/01 hlc sonobe 件名追加 Update End
                    //************************************.
                    //ジャンル計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    _intseisakuRow++;
                    //2013/07/01 hlc sonobe 件名追加 Update Start
                    //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ジャンル計";
                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_JanleSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = "ジャンル計";
                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (_JanleSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    //2013/07/01 hlc sonobe 件名追加 Update End
                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    _intseisakuRow++;
                    //2013/07/01 hlc sonobe 件名追加 Update Start
                    //sprSeisaku.Cells[_intseisakuRow, 7].Value = "代理店計";
                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_dairiSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = "代理店計";
                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (_dairiSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
                    //2013/07/01 hlc sonobe 件名追加 Update End
                    
                    /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD start */
                    //************************************.
                    //代理店計(税抜)行を作成.
                    //************************************.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    _intseisakuRow++;
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = "代理店計（税抜）";
                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (_dairiSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent - SumSyouhiZeiGak).ToString("#,0");
                    /* 2014/07/31 消費税端数調整対応 HLC fujimoto ADD end */

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    _intseisakuRow++;
                    //2013/07/01 hlc sonobe 件名追加 Update Start
                    //sprSeisaku.Cells[_intseisakuRow, 7].Value = "消費税計";
                    //sprSeisaku.Cells[_intseisakuRow, 8].Value =  (Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = "消費税計";
                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");
                    //2013/07/01 hlc sonobe 件名追加 Update End
                    //初期化.
                    SumSyouhiZeiGak = 0;
                    SeisakuSyohizeiGak = 0;
                    SeisakuSyohizeiGak_Talent = 0;

                    //************************************.
                    //値の位置.
                    //************************************.
                    sprSeisaku.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Left;
                    for (int i = 1; i < 5; i++)
                    {
                        sprSeisaku.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //媒体名称.
                    sprSeisaku.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //ブランドコード.
                    sprSeisaku.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //ブランド名称.
                    sprSeisaku.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //2013/07/01 hlc sonobe 件名追加 Update Start
                    ////請求額.
                    //sprSeisaku.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

                    ////消費税.
                    //sprSeisaku.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;
                    //請求額.
                    sprSeisaku.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //消費税.
                    sprSeisaku.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;
                    //2013/07/01 hlc sonobe 件名追加 Update End

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion 制作.

            #region テレビタイム、ラジオタイム.

            //テレビタイムの場合.
            if (_mStrBaitaiMei == C_BAITAI_TV_TIME || _mStrBaitaiMei == C_BAITAI_RD_TIME)
            {
                //シートを表示する.
                sprTVTime.Visible = true;

                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    //************
                    //変数初期化.
                    //************
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblDenpaRyoShoKei = 0;          //電波料小計.
                    double _dblNetRyoShoKei = 0;            //ネット料小計.
                    double _dblSeisakuHiShoKei = 0;         //制作費小計.
                    double _dblSeikyuGakShoKei = 0;         //請求額小計.
                    double _dblDenpaRyoGoKei = 0;           //電波料合計.
                    double _dblNetRyoGoKei = 0;             //ネット料合計.
                    double _dblSeisakuHiGoKei = 0;          //制作費合計.
                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _taxAmount = 0;                  //明細毎消費税額.
                    double _taxAmountTotal = 0;             //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;             //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;        //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0 ; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count ; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTVTime.Rows.Add(sprTVTime.RowCount ,1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //カードNo、番組コードを保持.
                            _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();
                            _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BANGUMICD"].ToString();
                        }

                        //カードＮｏ、番組コードが異なる場合.
                        if (_strCardNo != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString()
                            || _strBangumiCD != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BANGUMICD"].ToString())
                        {
                            //カード計行を作成.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_KYKNM].Value = "カード計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //電波料小計.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_DNPAMT].Value = _dblDenpaRyoShoKei.ToString("#,0");

                            //ネット料小計.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_NETAMT].Value = _dblNetRyoShoKei.ToString("#,0");

                            //制作費小計.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_SEIAMT].Value = _dblSeisakuHiShoKei.ToString("#,0");

                            //請求額小計.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_INVAMT].Value = _dblSeikyuGakShoKei.ToString("#,0");

                            //各小計を初期化.
                            _dblDenpaRyoShoKei = 0;             //電波料小計.
                            _dblNetRyoShoKei = 0;               //ネット料計.
                            _dblSeisakuHiShoKei = 0;            //制作費小計.
                            _dblSeikyuGakShoKei = 0;            //請求額小計.

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprTVTime.Cells[_intRow, COLIDX_TIME_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //カードNo、番組コードを保持.
                            _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();
                            _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BANGUMICD"].ToString();

                            //スプレッドシートに行を追加.
                            sprTVTime.Rows.Add(sprTVTime.RowCount , 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //番組コード.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_PGNCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BANGUMICD"].ToString();

                        //局誌コード.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_KYKCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUCD"].ToString();

                        //局誌名称.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_KYKNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUMEI"].ToString();

                        //電波料 = 請求額 - ネット料 - 制作費.
                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        //ネット料.
                        double _dblNetRyo = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KNGK2"].ToString());
                        //制作費.
                        double _dblSeisakuHi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KNGK3"].ToString());
                        //電波料.
                        double _dblDenpaRyo = _dblSeikyuGak - _dblNetRyo - _dblSeisakuHi;

                        sprTVTime.Cells[_intRow, COLIDX_TIME_DNPAMT].Value = _dblDenpaRyo.ToString("#,0");

                        //ネット料.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_NETAMT].Value = _dblNetRyo.ToString("#,0");

                        //制作費.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_SEIAMT].Value = _dblSeisakuHi.ToString("#,0");

                        //請求額.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_INVAMT].Value = _dblSeikyuGak.ToString("#,0");

                        //ブランド毎消費税額.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIGAK"].ToString());
                        sprTVTime.Cells[_intRow, COLIDX_TIME_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;
                        
                        //放送回数.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_ONAIRQTY].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SONOTA5"].ToString();

                        //番組名.
                        sprTVTime.Cells[_intRow, COLIDX_TIME_PGMNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BANGUMIMEI"].ToString();

                        //******************.
                        //各小計額をセット.
                        //******************.
                        //電波料小計.
                        _dblDenpaRyoShoKei += _dblDenpaRyo;

                        //ネット料小計.
                        _dblNetRyoShoKei += _dblNetRyo;

                        //制作費小計.
                        _dblSeisakuHiShoKei += _dblSeisakuHi;

                        //請求金額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //******************.
                        //各合計額をセット.
                        //******************.
                        //電波料合計.
                        _dblDenpaRyoGoKei += _dblDenpaRyo;

                        //ネット料合計.
                        _dblNetRyoGoKei += _dblNetRyo;

                        //制作費合計.
                        _dblSeisakuHiGoKei += _dblSeisakuHi;

                        //請求金額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += _dblSeikyuGak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = (_dblSeikyuGak);
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += _dblSeikyuGak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = _dblSeikyuGak;
                            brandTaxList.Add(list);
                        }

                        //行数を加算.
                        _intRow++;
                    }

                    //******************.
                    //カード計行を作成.
                    //******************.
                    //スプレッドシートに行を追加.
                    sprTVTime.Rows.Add(sprTVTime.RowCount , 1);

                    sprTVTime.Cells[_intRow, COLIDX_TIME_KYKNM].Value = "カード計";
                    //電波料合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_DNPAMT].Value = _dblDenpaRyoShoKei.ToString("#,0");
                    //ネット料合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_NETAMT].Value = _dblNetRyoShoKei.ToString("#,0");
                    //制作費合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_SEIAMT].Value = _dblSeisakuHiShoKei.ToString("#,0");
                    //請求額合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_INVAMT].Value = _dblSeikyuGakShoKei.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTVTime.Rows.Add(sprTVTime.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprTVTime.Cells[_intRow, COLIDX_TIME_KYKNM].Value = "代理店計";

                    //電波料合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_DNPAMT].Value = _dblDenpaRyoGoKei.ToString("#,0");

                    //ネット料合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_NETAMT].Value = _dblNetRyoGoKei.ToString("#,0");

                    //制作費合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_SEIAMT].Value = _dblSeisakuHiGoKei.ToString("#,0");

                    //請求額合計.
                    sprTVTime.Cells[_intRow, COLIDX_TIME_INVAMT].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTVTime.Rows.Add(sprTVTime.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprTVTime.Cells[_intRow, COLIDX_TIME_KYKNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprTVTime.Cells[_intRow, COLIDX_TIME_INVAMT].Value = ckgoukei;

                    sprTVTime.Cells[_intRow, COLIDX_TIME_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprTVTime.Cells[_intRow, COLIDX_TIME_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprTVTime.Cells[_intRow, COLIDX_TIME_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprTVTime.Cells[_intRow, COLIDX_TIME_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                }

                #endregion シートにセット.
            }

            #endregion テレビタイム、ラジオタイム.

            #region テレビスポット、ラジオスポット.

            //テレビスポット、またはラジオスポットの場合.
            if (_mStrBaitaiMei == C_BAITAI_TV_SPOT || _mStrBaitaiMei == C_BAITAI_RD_SPOT)
            {
                //シートを表示する.
                sprTVSpot.Visible = true;

                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    //************
                    //変数初期化.
                    //************
                    string _strBrandCd = string.Empty;      //ブランドコード.
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblSeikyuGakShoKei = 0;         //請求額小計.
                    double _dblHonsuShokei = 0;             //本数小計.
                    double _dblByosuShoKei = 0;             //CM秒数小計.
                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _dblHonsuGokei = 0;              //CM本数合計.
                    double _dblByosuGoKei = 0;              //CM秒数合計.
                    double _taxAmount = 0;                  //明細毎消費税額.
                    double _taxAmountTotal = 0;             //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;             //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;        //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0 ; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count ; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTVSpot.Rows.Add(sprTVSpot.RowCount , 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを保持.
                            _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }

                        //ブランドコードが異なる場合.
                        if (_strBrandCd != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString())
                        {
                            //ブランド計行を作成.
                            sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //請求額小計.
                            sprTVSpot.Cells[_intRow, COLIDX_SPOT_INVAMT].Value = _dblSeikyuGakShoKei.ToString("#,0");

                            //本数小計.
                            sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMTIME].Value = _dblHonsuShokei;

                            //秒数小計.
                            sprTVSpot.Cells[_intRow, COLIDX_SPOT_TOTALCMSEC].Value = _dblByosuShoKei;

                            //各小計を初期化.
                            _dblSeikyuGakShoKei = 0;            //請求額小計.
                            _dblHonsuShokei = 0;                //本数小計.
                            _dblByosuShoKei = 0;                //秒数小計.

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //ブランドコードを保持.
                            _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprTVSpot.Rows.Add(sprTVSpot.RowCount , 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //局誌コード.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUCD"].ToString();

                        //局誌名称.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUMEI"].ToString();

                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_INVAMT].Value = _dblSeikyuGak.ToString("#,0");

                        //ブランド毎消費税額.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIGAK"].ToString());
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;

                        //CM1本の秒数.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMSEC].Value = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SONOTA7"].ToString());

                        //本数.
                        double _dblHonsu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SONOTA5"].ToString());
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMTIME].Value = _dblHonsu;

                        //秒数.
                        double _dblByosu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BYOSUGOKEI"].ToString());
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_TOTALCMSEC].Value = _dblByosu;

                        //期間.
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMPTERM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME7"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //請求額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //本数小計.
                        _dblHonsuShokei += _dblHonsu;

                        //秒数小計.
                        _dblByosuShoKei += _dblByosu;

                        //**************************.
                        //各合計額を変数にセット.
                        //**************************.
                        //請求額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //本数合計.
                        _dblHonsuGokei += _dblHonsu;

                        //秒数合計.
                        _dblByosuGoKei += _dblByosu;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += _dblSeikyuGak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = _dblSeikyuGak;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += _dblSeikyuGak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = _dblSeikyuGak;
                            brandTaxList.Add(list);
                        }

                        //行数を加算.
                        _intRow++;
                    }

                    //******************.
                    //カード計行を作成.
                    //******************.
                    //スプレッドシートに行を追加.
                    sprTVSpot.Rows.Add(sprTVSpot.RowCount , 1);

                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKNM].Value = "ブランド計";

                    //請求額小計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_INVAMT].Value = _dblSeikyuGakShoKei.ToString("#,0");

                    //本数小計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMTIME].Value = _dblHonsuShokei.ToString("#,0");

                    //秒数小計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_TOTALCMSEC].Value = _dblByosuShoKei.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTVSpot.Rows.Add(sprTVSpot.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKNM].Value = "代理店計";

                    //請求額合計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_INVAMT].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //本数合計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_CMTIME].Value = _dblHonsuGokei;

                    //秒数小計.
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_TOTALCMSEC].Value = _dblByosuGoKei;

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTVSpot.Rows.Add(sprTVSpot.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_KYKNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_INVAMT].Value = ckgoukei;

                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprTVSpot.Cells[_intRow, COLIDX_SPOT_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprTVSpot.Cells[_intRow, COLIDX_SPOT_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion テレビスポット、ラジオスポット.

            #region BS/CS

            //BS・CSの場合.
            if (_mStrBaitaiMei.Equals(C_BAITAI_BS_CS))
            {
                //シートを表示する.
                sprBSCS.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strbscsCardNo = string.Empty;       //カードNo.
                    string _strbscsProgramCd = string.Empty;    //プログラムコード.

                    int _intRow = 0;                            //行数.
                    double _cardSeiSyoukeibscs = 0;             //カード計.
                    double _dairiSeiSyoukeibscs = 0;            //代理店請求額小計.
                    double _taxAmount = 0;                      //明細毎消費税額.
                    double _taxAmountTotal = 0;                 //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;                 //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;            //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprBSCS.Rows.Add(sprBSCS.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //カードNo.、プログラムコードを格納.
                            _strbscsCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Code6"].ToString();
                            _strbscsProgramCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["PROGRAMCD"].ToString();
                        }

                        //カードNoまたは、プログラムコードが変化した場合計を挿入する.
                        if (!_strbscsCardNo.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Code6"].ToString()) || !_strbscsProgramCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["PROGRAMCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKNM].Value = "カード計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //カード請求料計.
                            sprBSCS.Cells[_intRow, COLIDX_BSCS_DNPAMT].Value = _cardSeiSyoukeibscs.ToString("#,0");
                            sprBSCS.Cells[_intRow, COLIDX_BSCS_INVAMT].Value = _cardSeiSyoukeibscs.ToString("#,0");

                            //各小計を初期化.
                            _cardSeiSyoukeibscs = 0;

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprBSCS.Cells[_intRow, COLIDX_BSCS_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //カードNo.、プログラムコードを格納.
                            _strbscsCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();
                            _strbscsProgramCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["PROGRAMCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprBSCS.Rows.Add(sprBSCS.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //番組コード.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_PGMCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["PROGRAMCD"].ToString();

                        //局誌コード.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUCD"].ToString();

                        //局誌名称.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUMEI"].ToString();

                        //電波料.
                        double BsCsSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_DNPAMT].Value = BsCsSei.ToString("#,0");

                        //請求額合計.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_INVAMT].Value = BsCsSei.ToString("#,0");

                        //放送回数.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_ONAIRTM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["HONSU"].ToString();

                        //番組名.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_PGMNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["PROGRAMNAME"].ToString();

                        //ブランド毎消費税額.
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _cardSeiSyoukeibscs += BsCsSei;
                        //代理店請求額.
                        _dairiSeiSyoukeibscs += BsCsSei;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += BsCsSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = BsCsSei;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += BsCsSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = BsCsSei;
                            brandTaxList.Add(list);
                        }

                        _intRow++;
                    }

                    //************************************.
                    //カード計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprBSCS.Rows.Add(sprBSCS.RowCount, 1);
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKNM].Value = "カード計";
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_DNPAMT].Value = _cardSeiSyoukeibscs.ToString("#,0");
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_INVAMT].Value = _cardSeiSyoukeibscs.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprBSCS.Rows.Add(sprBSCS.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKNM].Value = "代理店計";
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_DNPAMT].Value = _dairiSeiSyoukeibscs.ToString("#,0");
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_INVAMT].Value = _dairiSeiSyoukeibscs.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprBSCS.Rows.Add(sprBSCS.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_KYKNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_INVAMT].Value = ckgoukei;

                    sprBSCS.Cells[_intRow, COLIDX_BSCS_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprBSCS.Cells[_intRow, COLIDX_BSCS_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprBSCS.Cells[_intRow, COLIDX_BSCS_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion BS/CS

            #region 新聞.

            //新聞の場合.
            if (_mStrBaitaiMei == C_BAITAI_SHINBUN)
            {
                //シートを表示する.
                sprNP.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strShiBrandCd = string.Empty;   //ブランドコード.
                    double _brandJissiSyoukei = 0;          //ブランド実施料小計.
                    double _brandSeiSyoukei = 0;            //ブランド請求額小計.
                    double _dairiJissiSyoukei = 0;          //代理店実施料小計.
                    double _dairiSeiSyoukei = 0;            //代理店請求額小計.
                    int _intRow = 0;                        //行数.
                    double _taxAmount = 0;                  //明細毎消費税額.
                    double _taxAmountTotal = 0;             //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;             //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;        //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprNP.Rows.Add(sprNP.RowCount, 1);
                        //1回目の場合.
                        if (i == 0)
                        {
                            _strShiBrandCd =  result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }
                        //ブランドコードが変化した場合計を挿入する.
                        if (!_strShiBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprNP.Cells[_intRow, COLIDX_NP_NPNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //ブランド実施料計.
                            sprNP.Cells[_intRow, COLIDX_NP_QUTAMT].Value = _brandJissiSyoukei.ToString("#,0");
                            //ブランド請求料計.
                            sprNP.Cells[_intRow, COLIDX_NP_INVAMT].Value = _brandSeiSyoukei.ToString("#,0");

                            //各小計を初期化.
                            _brandJissiSyoukei = 0;
                            _brandSeiSyoukei = 0;

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprNP.Cells[_intRow, COLIDX_NP_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal = _brandTaxAmountTotal + _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //ブランドコードを保持.
                            _strShiBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprNP.Rows.Add(sprNP.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprNP.Cells[_intRow, COLIDX_NP_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprNP.Cells[_intRow, COLIDX_NP_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprNP.Cells[_intRow, COLIDX_NP_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprNP.Cells[_intRow, COLIDX_NP_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprNP.Cells[_intRow, COLIDX_NP_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprNP.Cells[_intRow, COLIDX_NP_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                       //新聞コード.
                        sprNP.Cells[_intRow, COLIDX_NP_NPCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shinCD"].ToString();

                        //新聞名称.
                        sprNP.Cells[_intRow, COLIDX_NP_NPNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shinMEI"].ToString();

                        //実施料.
                        double ShinJissi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME4"].ToString());
                        sprNP.Cells[_intRow, COLIDX_NP_QUTAMT].Value = ShinJissi.ToString("#,0");

                        //請求金額.
                        double ShinSeigak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprNP.Cells[_intRow, COLIDX_NP_INVAMT].Value = ShinSeigak.ToString("#,0");

                        //備考.
                        sprNP.Cells[_intRow, COLIDX_NP_RMK].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME8"].ToString();

                        //ブランド毎消費税額.
                        sprNP.Cells[_intRow, COLIDX_NP_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprNP.Cells[_intRow, COLIDX_NP_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計実施料.
                        _brandJissiSyoukei += ShinJissi;
                        //ブランド計請求額.
                        _brandSeiSyoukei += ShinSeigak;
                        //代理店実施料.
                        _dairiJissiSyoukei += ShinJissi;
                        //代理店請求額.
                        _dairiSeiSyoukei += ShinSeigak;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += ShinSeigak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = ShinSeigak;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += ShinSeigak;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = ShinSeigak;
                            brandTaxList.Add(list);
                        }

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprNP.Rows.Add(sprNP.RowCount, 1);
                    sprNP.Cells[_intRow, COLIDX_NP_NPNM].Value = "ブランド計";
                    sprNP.Cells[_intRow, COLIDX_NP_QUTAMT].Value = _brandJissiSyoukei.ToString("#,0");
                    sprNP.Cells[_intRow, COLIDX_NP_INVAMT].Value = _brandSeiSyoukei.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprNP.Cells[_intRow, COLIDX_NP_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprNP.Rows.Add(sprNP.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprNP.Cells[_intRow, COLIDX_NP_NPNM].Value = "代理店計";
                    sprNP.Cells[_intRow, COLIDX_NP_QUTAMT].Value = _dairiJissiSyoukei.ToString("#,0");
                    sprNP.Cells[_intRow, COLIDX_NP_INVAMT].Value = _dairiSeiSyoukei.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprNP.Rows.Add(sprNP.RowCount, 1);
                    //行数を加算.
                    _intRow++;

                    sprNP.Cells[_intRow, COLIDX_NP_NPNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprNP.Cells[_intRow, COLIDX_NP_INVAMT].Value = ckgoukei;

                    sprNP.Cells[_intRow, COLIDX_NP_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprNP.Cells[_intRow, COLIDX_NP_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprNP.Cells[_intRow, COLIDX_NP_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprNP.Cells[_intRow, COLIDX_NP_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion 新聞.

            #region 雑誌.

            //雑誌の場合.
            if (_mStrBaitaiMei == C_BAITAI_ZASHI)
            {
                //シートを表示する.
                sprMZ.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strMzBrandCd = string.Empty;        //ブランドコード.
                    double _brandJissiSyoukeiMZ = 0;            //ブランド実施料.
                    double _brandSeiSyoukeiMZ = 0;              //ブランド請求額.
                    double _dairiJissiSyoukeiMZ = 0;            //代理店実施料小計.
                    double _dairiSeiSyoukeiMZ = 0;              //代理店請求額小計.
                    int _intRow = 0;                            //行数.
                    double _taxAmount = 0;                      //明細毎消費税額.
                    double _taxAmountTotal = 0;                 //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;                 //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;            //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprMZ.Rows.Add(sprMZ.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを格納.
                            _strMzBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }

                        //ブランドコードが変化した場合計を挿入する.
                        if (!_strMzBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprMZ.Cells[_intRow, COLIDX_MZ_MZNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //ブランド実施料計.
                            sprMZ.Cells[_intRow, COLIDX_MZ_QOTAMT].Value = _brandJissiSyoukeiMZ.ToString("#,0");
                            //ブランド請求料計.
                            sprMZ.Cells[_intRow, COLIDX_MZ_INVAMT].Value = _brandSeiSyoukeiMZ.ToString("#,0");
                            //各小計を初期化.
                            _brandJissiSyoukeiMZ = 0;
                            _brandSeiSyoukeiMZ = 0;

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprMZ.Cells[_intRow, COLIDX_MZ_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //ブランドコードを保持.
                            _strMzBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprMZ.Rows.Add(sprMZ.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprMZ.Cells[_intRow, COLIDX_MZ_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprMZ.Cells[_intRow, COLIDX_MZ_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprMZ.Cells[_intRow, COLIDX_MZ_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprMZ.Cells[_intRow, COLIDX_MZ_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprMZ.Cells[_intRow, COLIDX_MZ_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprMZ.Cells[_intRow, COLIDX_MZ_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //雑誌コード.
                        sprMZ.Cells[_intRow, COLIDX_MZ_MZCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiCD"].ToString();

                        //雑誌名称.
                        sprMZ.Cells[_intRow, COLIDX_MZ_MZNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiNAME"].ToString();

                        //スペース.
                        sprMZ.Cells[_intRow, COLIDX_MZ_SPC].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Space"].ToString();

                        //実施料.
                        double MzJissi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME4"].ToString()) + KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kngk3"].ToString());
                        sprMZ.Cells[_intRow, COLIDX_MZ_QOTAMT].Value = MzJissi.ToString("#,0");

                        //請求額.
                        double MzSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprMZ.Cells[_intRow, COLIDX_MZ_INVAMT].Value = MzSei.ToString("#,0");

                        //ブランド毎消費税額.
                        sprMZ.Cells[_intRow, COLIDX_MZ_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprMZ.Cells[_intRow, COLIDX_MZ_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;

                        //備考.
                        sprMZ.Cells[_intRow, COLIDX_MZ_RMK].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME8"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計実施料.
                        _brandJissiSyoukeiMZ += MzJissi;
                        //ブランド計請求額.
                        _brandSeiSyoukeiMZ += MzSei;
                        //代理店実施料.
                        _dairiJissiSyoukeiMZ += MzJissi;
                        //代理店請求額.
                        _dairiSeiSyoukeiMZ += MzSei;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += MzSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = MzSei;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += MzSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = MzSei;
                            brandTaxList.Add(list);
                        }

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprMZ.Rows.Add(sprMZ.RowCount, 1);
                    sprMZ.Cells[_intRow, COLIDX_MZ_MZNM].Value = "ブランド計";
                    sprMZ.Cells[_intRow, COLIDX_MZ_QOTAMT].Value = _brandJissiSyoukeiMZ.ToString("#,0");
                    sprMZ.Cells[_intRow, COLIDX_MZ_INVAMT].Value = _brandSeiSyoukeiMZ.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprMZ.Cells[_intRow, COLIDX_MZ_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprMZ.Rows.Add(sprMZ.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprMZ.Cells[_intRow, COLIDX_MZ_MZNM].Value = "代理店計";
                    sprMZ.Cells[_intRow, COLIDX_MZ_QOTAMT].Value = _dairiJissiSyoukeiMZ.ToString("#,0");
                    sprMZ.Cells[_intRow, COLIDX_MZ_INVAMT].Value = _dairiSeiSyoukeiMZ.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprMZ.Rows.Add(sprMZ.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprMZ.Cells[_intRow, COLIDX_MZ_MZNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprMZ.Cells[_intRow, COLIDX_MZ_INVAMT].Value = ckgoukei;

                    sprMZ.Cells[_intRow, COLIDX_MZ_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprMZ.Cells[_intRow, COLIDX_MZ_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprMZ.Cells[_intRow, COLIDX_MZ_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprMZ.Cells[_intRow, COLIDX_MZ_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion 雑誌.

            #region 交通.

            //交通の場合.
            if (_mStrBaitaiMei == C_BAITAI_KOTSU)
            {
                //シートを表示する.
                sprTraffic.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strOohBrandCd = string.Empty;       //ブランドコード.
                    int _intRow = 0;                         //行数.
                    double _brandSeiSyoukeiOoh = 0;             //ブランド請求額.
                    double _dairiSeiSyoukeiOoh = 0;             //代理店請求額小計.
                    double _taxAmount = 0;                      //明細毎消費税額.
                    double _taxAmountTotal = 0;                 //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;                 //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;            //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTraffic.Rows.Add(sprTraffic.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strOohBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }

                        //ブランドコードが変化した場合計を挿入する.
                        if (!_strOohBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprTraffic.Cells[_intRow, COLIDX_TR_PREFNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //ブランド請求料計.
                            sprTraffic.Cells[_intRow, COLIDX_TR_INVAMT].Value = _brandSeiSyoukeiOoh.ToString("#,0");

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprTraffic.Cells[_intRow, COLIDX_TR_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            //各小計を初期化.
                            _brandSeiSyoukeiOoh = 0;

                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            //ブランドコードを格納.
                            _strOohBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprTraffic.Rows.Add(sprTraffic.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprTraffic.Cells[_intRow, COLIDX_TR_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprTraffic.Cells[_intRow, COLIDX_TR_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprTraffic.Cells[_intRow, COLIDX_TR_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprTraffic.Cells[_intRow, COLIDX_TR_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprTraffic.Cells[_intRow, COLIDX_TR_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprTraffic.Cells[_intRow, COLIDX_TR_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //県コード.
                        sprTraffic.Cells[_intRow, COLIDX_TR_PREFCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KENCD"].ToString();

                        //県名.
                        sprTraffic.Cells[_intRow, COLIDX_TR_PREFNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KENNAME"].ToString();

                        //請求額.
                        double OohSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprTraffic.Cells[_intRow, COLIDX_TR_INVAMT].Value = OohSei.ToString("#,0");

                        //路線名.
                        sprTraffic.Cells[_intRow, COLIDX_TR_RAILNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["RosenNAME"].ToString();

                        //期間.
                        if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString()))
                        {
                            result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"] = "";
                        }
                        else
                        {
                            sprTraffic.Cells[_intRow, COLIDX_TR_TERM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString();
                        }
                        //備考.
                        if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME8"].ToString()))
                        {
                            result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME8"] = "";
                        }
                        else
                        {
                            sprTraffic.Cells[_intRow, COLIDX_TR_RMK].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME8"].ToString();
                        }

                        //ブランド毎消費税額.
                        sprTraffic.Cells[_intRow, COLIDX_TR_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprTraffic.Cells[_intRow, COLIDX_TR_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;
                        
                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiOoh += OohSei;
                        //代理店請求額.
                        _dairiSeiSyoukeiOoh += OohSei;
                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //2014/01/28 hlc sonobe
                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += OohSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = OohSei;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += OohSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = OohSei;
                            brandTaxList.Add(list);
                        }

                        _intRow++;
                    }

                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTraffic.Rows.Add(sprTraffic.RowCount, 1);
                    sprTraffic.Cells[_intRow, COLIDX_TR_PREFNM].Value = "ブランド計";
                    sprTraffic.Cells[_intRow, COLIDX_TR_INVAMT].Value = _brandSeiSyoukeiOoh.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprTraffic.Cells[_intRow, COLIDX_TR_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTraffic.Rows.Add(sprTraffic.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprTraffic.Cells[_intRow, COLIDX_TR_PREFNM].Value = "代理店計";
                    sprTraffic.Cells[_intRow, COLIDX_TR_INVAMT].Value = _dairiSeiSyoukeiOoh.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTraffic.Rows.Add(sprTraffic.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprTraffic.Cells[_intRow, COLIDX_TR_PREFNM].Value = "消費税計";
                    
                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprTraffic.Cells[_intRow, COLIDX_TR_INVAMT].Value = ckgoukei;

                    sprTraffic.Cells[_intRow, COLIDX_TR_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprTraffic.Cells[_intRow, COLIDX_TR_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprTraffic.Cells[_intRow, COLIDX_TR_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprTraffic.Cells[_intRow, COLIDX_TR_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;
                    //Excelボタン押下可能.
                    btnXls.Enabled = true;
                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";
                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.
                }
            }

            #endregion 交通.

            #region インターネット、モバイル.

            //インターネット、モバイルの場合.
            if (_mStrBaitaiMei.Equals(C_BAITAI_INTERNET)
                || _mStrBaitaiMei.Equals(C_BAITAI_MOBILE))
            {
                //シートを表示する.
                sprInternet.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strinternetBrandCd = string.Empty;  //ブランドコード.
                    int _intRow = 0;                            //行数.
                    double _brandSeiSyoukeiinternet = 0;        //ブランド請求額.
                    double _dairiSeiSyoukeiinternet = 0;        //代理店請求額小計.
                    double _taxAmount = 0;                      //明細毎消費税額.
                    double _taxAmountTotal = 0;                 //名刺毎消費税額合計.
                    double _brandTaxAmount = 0;                 //ブランド毎消費税額.
                    double _brandTaxAmountTotal = 0;            //ブランド毎消費税額合計.

                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprInternet.Rows.Add(sprInternet.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを格納.
                            _strinternetBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }

                        //ブランドコードが変化した場合計を挿入する.
                        if (!_strinternetBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprInternet.Cells[_intRow, COLIDX_INT_BRDNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //ブランド請求料計.
                            sprInternet.Cells[_intRow, COLIDX_INT_INVAMT].Value = _brandSeiSyoukeiinternet.ToString("#,0");

                            //各小計を初期化.
                            _brandSeiSyoukeiinternet = 0;

                            //ブランド毎消費税額算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税額.
                            sprInternet.Cells[_intRow, COLIDX_INT_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税額合計.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            _strinternetBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprInternet.Rows.Add(sprInternet.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprInternet.Cells[_intRow, COLIDX_INT_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprInternet.Cells[_intRow, COLIDX_INT_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprInternet.Cells[_intRow, COLIDX_INT_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprInternet.Cells[_intRow, COLIDX_INT_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprInternet.Cells[_intRow, COLIDX_INT_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprInternet.Cells[_intRow, COLIDX_INT_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //局誌コード.
                        if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUSHICD"].ToString()))
                        {
                            sprInternet.Cells[_intRow, COLIDX_INT_KYKCD].Value = "";
                        }
                        else
                        {
                            sprInternet.Cells[_intRow, COLIDX_INT_KYKCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUSHICD"].ToString();
                        }

                        //局誌名称.
                        if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUSHINAME"].ToString()))
                        {
                            sprInternet.Cells[_intRow, COLIDX_INT_KYKNM].Value = "";
                        }
                        else
                        {
                            sprInternet.Cells[_intRow, COLIDX_INT_KYKNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KYOKUSHINAME"].ToString();
                        }

                        //作成料.
                        double internetSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprInternet.Cells[_intRow, COLIDX_INT_INVAMT].Value = internetSei.ToString("#,0");

                        //件名.
                        sprInternet.Cells[_intRow, COLIDX_INT_SUBJECT].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KENMEI"].ToString();

                        //ブランド毎消費税額.
                        sprInternet.Cells[_intRow, COLIDX_INT_BRDTAXAMT].Value = "";
                        //明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprInternet.Cells[_intRow, COLIDX_INT_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;
                        
                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiinternet += internetSei;
                        //代理店請求額.
                        _dairiSeiSyoukeiinternet += internetSei;

                        //消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                        
                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += internetSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());
                            data.goukeiList = (internetSei);
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                //対象データテーブル行.
                                if (brandTaxList[j].taxRateList == ckrate)
                                {
                                    brandTaxList[j].goukeiList += internetSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            //初回データ作成.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = internetSei;
                            brandTaxList.Add(list);
                        }

                        _intRow++;
                    }

                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprInternet.Rows.Add(sprInternet.RowCount, 1);
                    sprInternet.Cells[_intRow, COLIDX_INT_BRDNM].Value = "ブランド計";
                    sprInternet.Cells[_intRow, COLIDX_INT_INVAMT].Value = _brandSeiSyoukeiinternet.ToString("#,0");

                    //ブランド毎消費税額算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税額.
                    sprInternet.Cells[_intRow, COLIDX_INT_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税額合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprInternet.Rows.Add(sprInternet.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprInternet.Cells[_intRow, COLIDX_INT_BRDNM].Value = "代理店計";
                    sprInternet.Cells[_intRow, COLIDX_INT_INVAMT].Value = _dairiSeiSyoukeiinternet.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprInternet.Rows.Add(sprInternet.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprInternet.Cells[_intRow, COLIDX_INT_BRDNM].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprInternet.Cells[_intRow, COLIDX_INT_INVAMT].Value = ckgoukei;

                    sprInternet.Cells[_intRow, COLIDX_INT_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprInternet.Cells[_intRow, COLIDX_INT_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprInternet.Cells[_intRow, COLIDX_INT_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprInternet.Cells[_intRow, COLIDX_INT_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsRepLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット.

                }
            }

            #endregion インターネット、モバイル.

            #region チラシ、サンプリング、事業費、その他.

            //チラシ、サンプリング、事業費、その他の場合.
            if (_mStrBaitaiMei.Equals(C_BAITAI_CHIRASHI) 
                || _mStrBaitaiMei.Equals(C_BAITAI_SAMPLING)
                || _mStrBaitaiMei.Equals(C_BAITAI_JIGYOUBU)
                || _mStrBaitaiMei.Equals(C_BAITAI_SONOTA))
            {
                //シートを表示する.
                sprOther.Visible = true;
                if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    int _intRow = 0;                            //行数.
                    string _strsonotaBrandCd = string.Empty;    //ブランドコード.
                    double _brandSeiSyoukeisonota = 0;          //ブランド請求額.
                    double _dairiSeiSyoukeisonota = 0;          //代理店請求額小計.
                    double _taxAmount = 0;                      //明細毎消費税.
                    double _taxAmountTotal = 0;                 //明細毎消費税合計.
                    double _brandTaxAmount = 0;                 //ブランド毎消費税.
                    double _brandTaxAmountTotal = 0;            //ブランド毎消費税合計.
                    
                    #region シートにセット.

                    for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprOther.Rows.Add(sprOther.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを格納.
                            _strsonotaBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();
                        }

                        //ブランドコードが変化した場合計を挿入する.
                        if (!_strsonotaBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString()))
                        {
                            //ブランド計行を作成.
                            sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "ブランド計";

                            //***********************
                            //各小計をセット.
                            //***********************
                            //ブランド請求料計.
                            sprOther.Cells[_intRow, 6].Value = _brandSeiSyoukeisonota.ToString("#,0");

                            //各小計を初期化.
                            //ブランド請求額.
                            _brandSeiSyoukeisonota = 0;

                            //ブランド毎消費税合計算出.
                            for (int j = 0; j < brandTaxList.Count; j++)
                            {
                                // 対象データテーブル行.
                                _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                            }

                            //ブランド毎消費税.
                            sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].Value = _brandTaxAmount;
                            //ブランド毎消費税合計に加算.
                            _brandTaxAmountTotal += _brandTaxAmount;

                            //初期化.
                            brandTaxList.Clear();
                            _brandTaxAmount = 0;

                            _strsonotaBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                            //スプレッドシートに行を追加.
                            sprOther.Rows.Add(sprOther.RowCount, 1);

                            //行数を加算.
                            _intRow++;
                        }

                        //カードNo.
                        sprOther.Cells[_intRow, COLIDX_OTH_CARDNO].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE6"].ToString();

                        //データ年月.
                        sprOther.Cells[_intRow, COLIDX_OTH_YYMM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["YYMM"].ToString();

                        //代理店コード.
                        sprOther.Cells[_intRow, COLIDX_OTH_DAIRITENCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE4"].ToString();

                        //媒体区分.
                        sprOther.Cells[_intRow, COLIDX_OTH_BAITAICD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["CODE1"].ToString();

                        //ブランドコード.
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDCD].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDCD"].ToString();

                        //ブランド名称.
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BRANDMEI"].ToString();

                        //請求額.
                        double sonotaSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SEIGAK"].ToString());
                        sprOther.Cells[_intRow, COLIDX_OTH_INVAMT].Value = sonotaSei.ToString("#,0");

                        //件名.
                        sprOther.Cells[_intRow, COLIDX_OTH_SUBJECT].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KENMEI"].ToString();

                        // ブランド毎消費税.
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].Value = "";
                        // 明細毎消費税額.
                        _taxAmount = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["NAME1"].ToString());
                        sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].Value = _taxAmount;
                        _taxAmountTotal += _taxAmount;

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeisonota += sonotaSei;
                        //代理店請求額.
                        _dairiSeiSyoukeisonota += sonotaSei;

                        // 消費税率.
                        double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SHOHIZEIRITU"].ToString());

                        //消費税リストを作成する.
                        Boolean blnRate = false;
                        if (RateGoukei != null)
                        {
                            for (int x = 0; x < RateGoukei.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (RateGoukei[x].taxRateList == ckrate)
                                {
                                    RateGoukei[x].goukeiList += sonotaSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData data = new GoukeiData();
                            data.taxRateList = ckrate;
                            data.goukeiList = sonotaSei;
                            RateGoukei.Add(data);
                        }

                        //ブランド毎消費税リスト作成.
                        blnRate = false;
                        if (brandTaxList != null)
                        {
                            for (int x = 0; x < brandTaxList.Count; x++)
                            {
                                // 対象データテーブル行.
                                if (brandTaxList[x].taxRateList == ckrate)
                                {
                                    brandTaxList[x].goukeiList += sonotaSei;
                                    blnRate = true;
                                }
                            }
                        }

                        if (!blnRate)
                        {
                            // 初回データ設定.
                            GoukeiData list = new GoukeiData();
                            list.taxRateList = ckrate;
                            list.goukeiList = sonotaSei;
                            brandTaxList.Add(list);
                        }

                        _intRow++;
                    }

                    //************************************.
                    //ブランド計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "ブランド計";
                    sprOther.Cells[_intRow, COLIDX_OTH_INVAMT].Value = _brandSeiSyoukeisonota.ToString("#,0");

                    //ブランド毎消費税合計算出.
                    for (int j = 0; j < brandTaxList.Count; j++)
                    {
                        // 対象データテーブル行.
                        _brandTaxAmount += Math.Round(brandTaxList[j].goukeiList * brandTaxList[j].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }

                    //ブランド毎消費税.
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].Value = _brandTaxAmount;
                    //ブランド毎消費税合計に加算.
                    _brandTaxAmountTotal += _brandTaxAmount;

                    //初期化.
                    brandTaxList.Clear();
                    _brandTaxAmount = 0;

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "代理店計";
                    sprOther.Cells[_intRow, COLIDX_OTH_INVAMT].Value = _dairiSeiSyoukeisonota.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    //行数を加算.
                    _intRow++;
                    sprOther.Cells[_intRow, 5].Value = "消費税計";

                    double ckgoukei = 0;
                    for (int y = 0; y < RateGoukei.Count; y++)
                    {
                        // 対象データテーブル行.
                        ckgoukei += Math.Round(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList, 0, MidpointRounding.AwayFromZero);
                    }
                    sprOther.Cells[_intRow, COLIDX_OTH_INVAMT].Value = ckgoukei;

                    sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].Value = _brandTaxAmountTotal;
                    sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].Value = _taxAmountTotal;

                    //請求金額合計×消費税率≠ブランド毎消費税額合計の場合.
                    if (ckgoukei != _brandTaxAmountTotal)
                    {
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    //請求金額合計×消費税率≠明細毎消費税額合計の場合.
                    if (ckgoukei != _taxAmountTotal)
                    {
                        sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].BackColor = Color.FromArgb(255, 182, 193);
                    }

                    #endregion シートにセット.
                }

                //その他の場合、全媒体消費税を算出.
                if (_mStrBaitaiMei.Equals(C_BAITAI_SONOTA))
                {
                    //****************************
                    //全媒体消費税算出.
                    //****************************
                    double SyouhizeiGak = 0;        //消費税額1
                    double SyouhizeiGak2 = 0;       //消費税額2
                    double SyouhizeiGak3 = 0;       //消費税額3

                    //消費税対応 2014/1/28 add HLC sonobe start
                    Decimal befTaxRate;
                    List<decimal> taxRateList = new List<decimal>();
                    List<decimal> initList = new List<decimal>();
                    List<List<decimal>> tvTaxRateList = new List<List<decimal>>();
                    List<List<decimal>> rdTaxRateList = new List<List<decimal>>();
                    List<List<decimal>> etcTaxRateList = new List<List<decimal>>();
                    decimal tvTaxRate = 0;
                    decimal rdTaxRate = 0;
                    decimal etcTaxRate = 0;

                    RepDsLion.RepLionSyohiZeiRow[] sortTaxRows = (RepDsLion.RepLionSyohiZeiRow[])result.dsRepLionDataSet.RepLionSyohiZei.Select("", "ShohizeiRITU");
                    if (sortTaxRows.Length != 0)
                    {
                        taxRateList.Add(KKHUtility.DecParse(sortTaxRows[0].ShohizeiRitu));
                        initList.Add(0);
                        befTaxRate = KKHUtility.DecParse(sortTaxRows[0].ShohizeiRitu);
                        //消費税リストを作成する.
                        foreach (RepDsLion.RepLionSyohiZeiRow sortTaxRow in sortTaxRows)
                        {
                            if (befTaxRate != KKHUtility.DecParse(sortTaxRow.ShohizeiRitu))
                            {
                                taxRateList.Add(KKHUtility.DecParse(sortTaxRow.ShohizeiRitu));
                            }

                            befTaxRate = KKHUtility.DecParse(sortTaxRow.ShohizeiRitu);
                        }

                        tvTaxRateList.Add(taxRateList);
                        tvTaxRateList.Add(new List<decimal>());
                        rdTaxRateList.Add(taxRateList);
                        rdTaxRateList.Add(new List<decimal>());
                        etcTaxRateList.Add(taxRateList);
                        etcTaxRateList.Add(new List<decimal>());
                        foreach (decimal taxrate in taxRateList)
                        {
                            tvTaxRateList[1].Add(0);
                            rdTaxRateList[1].Add(0);
                            etcTaxRateList[1].Add(0);
                        }
                    }
                    //消費税対応 2014/1/28 add HLC sonobe end

                    foreach (RepDsLion.RepLionSyohiZeiRow row in result.dsRepLionDataSet.RepLionSyohiZei.Select("", ""))
                    {
                        switch (row.code6.Trim())
                        {
                            //テレビ.
                            case "001":
                            case "002":
                                if (row.code6.Trim().Equals("001"))
                                {
                                    //消費税対応 2014/01/28 Up HLC sonobe start
                                    //SyouhizeiGak = KKHUtility.DouParse(row.shohizeiGak);

                                    int index = 0;
                                    foreach (decimal taxRate in tvTaxRateList[0])
                                    {
                                        if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
                                        {
                                            tvTaxRateList[1][index] = tvTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
                                            break;
                                        }
                                        index++;
                                    }


                                    SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);
                                    //消費税対応 2014/01/28 Up HLC sonobe end
                                }
                                else
                                {
                                    //ｶｰﾄﾞNo 001と002の合計で消費税計算.
                                    //消費税対応 2014/01/28 UpHLC sonobe start
                                    //SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);

                                    int index = 0;
                                    foreach (decimal taxRate in tvTaxRateList[0])
                                    {
                                        if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
                                        {
                                            tvTaxRateList[1][index] = tvTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
                                            break;
                                        }
                                        index++;
                                    }

                                    SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);
                                    //消費税対応 2014/01/28 Up HLC sonobe end
                                }
                                break;

                            //ラジオ.
                            case "003":
                            case "004":
                                if (row.code6.Trim().Equals("003"))
                                {
                                    //消費税対応 2014/01/28 Up HLC sonobe start
                                    //SyouhizeiGak2 = KKHUtility.DouParse(row.shohizeiGak);

                                    int index = 0;
                                    foreach (decimal taxRate in rdTaxRateList[0])
                                    {
                                        if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
                                        {
                                            rdTaxRateList[1][index] = rdTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
                                            break;
                                        }
                                        index++;
                                    }

                                    SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);
                                    //消費税対応 2014/01/28 Up HLC sonobe end
                                }
                                else
                                {
                                    //ｶｰﾄﾞNo 003と004の合計で消費税計算.

                                    //消費税対応 2014/01/28 Up HLC sonobe start
                                    //SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);

                                    int index = 0;
                                    foreach (decimal taxRate in rdTaxRateList[0])
                                    {
                                        if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
                                        {
                                            rdTaxRateList[1][index] = rdTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
                                            break;
                                        }
                                        index++;
                                    }

                                    SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);
                                    //消費税対応 2014/01/28 Up HLC sonobe end
                                }
                                break;

                            default:

                                //SyouhizeiGak3 = SyouhizeiGak3 + Math.Truncate(KKHUtility.DouParse(row.shohizeiGak));
                                //消費税対応 2014/01/28 Up HLC sonobe start
                                //請求額 * 消費税率.
                                //SyouhizeiGak3 = SyouhizeiGak3 + Math.Floor(KKHUtility.DouParse(row.shohizeiGak) * _dblShohizei);

                                int index1 = 0;
                                foreach (decimal taxRate in etcTaxRateList[0])
                                {
                                    if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
                                    {
                                        etcTaxRateList[1][index1] = etcTaxRateList[1][index1] + Math.Truncate(KKHUtility.DecParse(row.shohizeiGak) * taxRate);
                                        break;
                                    }
                                    index1++;
                                }
                                //Csyouhigak_3 = Csyouhigak_3 + Math.Truncate(KKHUtility.DecParse(resultRow.seikyuu) * _taxRate);

                                SyouhizeiGak3 = SyouhizeiGak3 + Math.Floor(KKHUtility.DouParse(row.shohizeiGak));
                                //消費税対応 2014/01/28 Up HLC sonobe end

                                break;
                        }

                    }

                    //SyouhizeiGak = Math.Truncate(SyouhizeiGak);
                    //SyouhizeiGak2 = Math.Truncate(SyouhizeiGak2);
                    //請求額 * 消費税率.
                    //消費税対応 2014/01/28 Up HLC sonobe start
                    //SyouhizeiGak = Math.Floor(SyouhizeiGak * _dblShohizei);
                    //SyouhizeiGak2 = Math.Floor(SyouhizeiGak2 * _dblShohizei);
                    ////消費税合計.
                    //double SyouhizeiGakSum = SyouhizeiGak + SyouhizeiGak2 + SyouhizeiGak3;

                    for (int index = 0; index < taxRateList.Count; index++)
                    {
                        tvTaxRate = tvTaxRate + Math.Truncate((tvTaxRateList[1][index] * tvTaxRateList[0][index]));
                        rdTaxRate = rdTaxRate + Math.Truncate((rdTaxRateList[1][index] * rdTaxRateList[0][index]));
                        etcTaxRate = etcTaxRate + Math.Truncate(etcTaxRateList[1][index]);
                    }

                    //消費税合計.
                    Decimal SyouhizeiGakSum = tvTaxRate + rdTaxRate + etcTaxRate;
                    //消費税対応 2014/01/28 Up HLC sonobe end

                    int _intRow = sprOther.RowCount - 1;

                    //シートにセット.
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    _intRow++;

                    //カードNo
                    sprOther.Cells[_intRow, COLIDX_OTH_CARDNO].Value = "010";
                    //データ年月.
                    sprOther.Cells[_intRow, COLIDX_OTH_YYMM].Value = yyyyMm;
                    //代理店.
                    sprOther.Cells[_intRow, COLIDX_OTH_DAIRITENCD].Value = "1001";
                    //媒体区分.
                    sprOther.Cells[_intRow, COLIDX_OTH_BAITAICD].Value = "50";
                    //ブランドコード.
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDCD].Value = "9000";

                    MastLion.BrandLionRow[] brandName = (MastLion.BrandLionRow[])MastLionDs.BrandLion.Select("Column1 = '" + "9000" + "'", "");

                    if (( brandName.Length != 0 ) && ( !brandName[0].IsColumn2Null() ))
                    {
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = brandName[0].Column2;
                    }
                    else
                    {
                        sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "";
                    }

                    //消費税額.
                    sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].Value = SyouhizeiGakSum.ToString("#,0");
                    //件名.
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDTAXAMT].Value = "";

                    //その他の情報をデータセットに追加.
                    DataRow dtRow;
                    dtRow = result.dsRepLionDataSet.RepLion.NewRow();
                    dtRow["CODE6"] = sprOther.Cells[_intRow, COLIDX_OTH_CARDNO].Value;
                    dtRow["YYMM"] = sprOther.Cells[_intRow, COLIDX_OTH_YYMM].Value;
                    dtRow["CODE4"] = sprOther.Cells[_intRow, COLIDX_OTH_DAIRITENCD].Value;
                    dtRow["CODE1"] = sprOther.Cells[_intRow, COLIDX_OTH_BAITAICD].Value;
                    dtRow["BRANDCD"] = sprOther.Cells[_intRow, COLIDX_OTH_BRDCD].Value;
                    dtRow["BRANDMEI"] = sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value;
                    dtRow["SEIGAK"] = "0";
                    dtRow["KENMEI"] = "";
                    dtRow["NAME1"] = "0";
                    result.dsRepLionDataSet.RepLion.Rows.Add(dtRow);

                    //****************************
                    //ブランド計.
                    //****************************
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    _intRow++;
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "ブランド計";
                    sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].Value = SyouhizeiGakSum.ToString("#,0");

                    //****************************
                    //代理店計.
                    //****************************
                    //スプレッドシートに行を追加.
                    sprOther.Rows.Add(sprOther.RowCount, 1);
                    _intRow++;
                    sprOther.Cells[_intRow, COLIDX_OTH_BRDNM].Value = "代理店計";
                    sprOther.Cells[_intRow, COLIDX_OTH_TAXAMT].Value = SyouhizeiGakSum.ToString("#,0");
                }

                //取得結果データをDataSetにセット.
                _dsLion = result.dsRepLionDataSet;

                //Excelボタン押下可能.
                btnXls.Enabled = true;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = ( result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count).ToString() + "件";

                //垂直スクロールバーを表示する.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }

            #endregion その他.

            #region テレビCM秒数.

            //テレビCM秒数.
            if (_mStrBaitaiMei == C_BAITAI_TV_CM)
            {
                MastLionDs.TvCmLion.Clear();
                MastLionDs.TvCmLion.Merge(readMastFile.GetLionTvRdCm(_naviParam, yyyyMm).TvCmLion);

                //シートを表示する.
                sprTVCM.Visible = true;

                //テレビCMのデータが無い場合.
                if (MastLionDs.TvCmLion.Rows.Count == 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
                    //Excelボタン押下不可.
                    btnXls.Enabled = false;
                }
                else if (KKHLionCMDateCheck.checkTVCMDate(yyyyMm, MastLionDs.TvCmLion) != false)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0110, null, "プルーフリスト", MessageBoxButtons.OK);
                    //Excelボタン押下不可.
                    btnXls.Enabled = false;

                    //データをクリア.
                    MastLionDs.TvCmLion.Clear();
                }
                else
                {
                    //Excelボタン押下可能.
                    btnXls.Enabled = true;
                }
                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //************
                //変数初期化.
                //************
                int TvCmRow = 0;                        //行数.
                string TvCmBangumiCd = string.Empty;    //番組コード.
                long TvCmTotal = 0;                     //合計秒数.

                #region シートにセット.

                foreach (MastLion.TvCmLionRow row in MastLionDs.TvCmLion)
                {
                    //********************************.
                    //スプレッドシートに行を追加.
                    //********************************.
                    sprTVCM.Rows.Add(sprTVCM.RowCount, 1);

                    //カードNo.
                    sprTVCM.Cells[TvCmRow, 0].Value = row.CardKbn;

                    //データ年月.
                    sprTVCM.Cells[TvCmRow, 1].Value = row.YearMonth;

                    //代理店コード.
                    sprTVCM.Cells[TvCmRow, 2].Value = row.DairitenCd;

                    //媒体区分.
                    sprTVCM.Cells[TvCmRow, 3].Value = row.baitaiKbn;

                    //番組コード.
                    sprTVCM.Cells[TvCmRow, 4].Value = row.BangumiCd;

                    //ブランドコード.
                    sprTVCM.Cells[TvCmRow, 5].Value = row.BrandCd;

                    //ブランド名称.
                    if (row.GetBrandLionRows().Length != 0)
                    {
                        sprTVCM.Cells[TvCmRow, 6].Value = row.GetBrandLionRows()[0].Column2;
                        row.BrandName = row.GetBrandLionRows()[0].Column2;
                    }

                    //局誌コード.
                    sprTVCM.Cells[TvCmRow, 7].Value = row.KyokusiCd;

                    //局誌名称.
                    if (row.GetTvKLionRows().Length != 0)
                    {
                        sprTVCM.Cells[TvCmRow, 8].Value = row.GetTvKLionRows()[0].KYOKUNAME;
                        row.KyokusiName = row.GetTvKLionRows()[0].KYOKUNAME;
                    }

                    //総秒数.
                    sprTVCM.Cells[TvCmRow, 9].Value = row.Sobyosu;

                    //秒数.
                    sprTVCM.Cells[TvCmRow, 10].Value = row.Byosu;

                    //回数.
                    sprTVCM.Cells[TvCmRow, 11].Value = row.OnAirKaisu;

                    //番組名.
                    if (row.GetTvBnLionRows().Length != 0)
                    {
                        sprTVCM.Cells[TvCmRow, 12].Value = row.GetTvBnLionRows()[0].BANNAME;
                        row.BangumiName = row.GetTvBnLionRows()[0].BANNAME;
                    }

                    //番組コードが変化した場合、総秒数を加算する.
                    if (!TvCmBangumiCd.Equals(row.BangumiCd.ToString()))
                    {
                        TvCmBangumiCd = row.BangumiCd.ToString();
                        TvCmTotal += row.Sobyosu;
                    }

                    TvCmRow++;
                }

                //********************************.
                //スプレッドシートに合計行を追加.
                //********************************.
                if (!sprTVCM.RowCount.Equals(0))
                {
                    sprTVCM.Rows.Add(sprTVCM.RowCount, 1);
                    sprTVCM.Cells[TvCmRow, 8].Value = "総秒数合計";
                    sprTVCM.Cells[TvCmRow, 9].Value = TvCmTotal;
                }

                //************************************.
                //値の位置.
                //************************************.
                for (int i = 0; i < 6; i++)
                {
                    sprTVCM.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //ブランド名称.
                sprTVCM.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

                //局誌コード.
                sprTVCM.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

                //局誌名称.
                sprTVCM.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

                //総秒数.
                sprTVCM.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Center;

                //秒数.
                sprTVCM.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

                //回数.
                sprTVCM.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

                //番組名.
                sprTVCM.Columns[12].HorizontalAlignment = CellHorizontalAlignment.Center;

                //垂直スクロールバーを表示する.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = MastLionDs.TvCmLion.Count.ToString() + "件";

                //取得結果データをDataSetにセット.
                //_dsLion = result.dsRepLionDataSet;
                //_dsLion = MastLionDs;
                _dsLion = new MastLion();
                _dsLion.Tables["TvCmLion"].Merge(MastLionDs.TvCmLion);

                #endregion シートにセット.
            }

            #endregion テレビCM秒数.

            #region ラジオCM秒数.

            //ラジオCM秒数の場合.
            if (_mStrBaitaiMei == C_BAITAI_RD_CM)
            {
                MastLionDs.RdCmLion.Clear();
                MastLionDs.RdCmLion.Merge(readMastFile.GetLionTvRdCm(_naviParam, yyyyMm).RdCmLion);

                //シートを表示する.
                sprRDCM.Visible = true;

                //ラジオCMのデータが無い場合.
                if (MastLionDs.RdCmLion.Count == 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
                    //Excelボタン押下不可.
                    btnXls.Enabled = false;
                }
                else if (KKHLionCMDateCheck.checkRDCMDate(yyyyMm, MastLionDs.RdCmLion) != false)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0110, null, "プルーフリスト", MessageBoxButtons.OK);
                    //Excelボタン押下不可.
                    btnXls.Enabled = false;
                    //データをクリア.
                    MastLionDs.RdCmLion.Clear();
                }
                else
                {
                    //Excelボタン押下可能.
                    btnXls.Enabled = true;
                }
                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //************
                //変数初期化.
                //************
                int RdCmRow = 0;                        //行数.
                string RdCmBangumiCd = string.Empty;    //番組コード.
                long RdCmTotal = 0;                     //合計秒数.

                #region シートにセット.

                foreach (MastLion.RdCmLionRow Rdrow in MastLionDs.RdCmLion)
                {
                    //********************************.
                    //スプレッドシートに行を追加.
                    //********************************.
                    sprRDCM.Rows.Add(sprRDCM.RowCount, 1);

                    //カードNo.
                    sprRDCM.Cells[RdCmRow, 0].Value = Rdrow.CardKbn;

                    //データ年月.
                    sprRDCM.Cells[RdCmRow, 1].Value = Rdrow.YearMonth;

                    //代理店コード.
                    sprRDCM.Cells[RdCmRow, 2].Value = Rdrow.DairitenCd;

                    //媒体区分.
                    sprRDCM.Cells[RdCmRow, 3].Value = Rdrow.baitaiKbn;

                    //番組コード.
                    sprRDCM.Cells[RdCmRow, 4].Value = Rdrow.BangumiCd;

                    //ブランドコード.
                    sprRDCM.Cells[RdCmRow, 5].Value = Rdrow.BrandCd;

                    //ブランド名称.
                    if (Rdrow.GetBrandLionRows().Length != 0)
                    {
                        sprRDCM.Cells[RdCmRow, 6].Value = Rdrow.GetBrandLionRows()[0].Column2;
                        Rdrow.BrandName = Rdrow.GetBrandLionRows()[0].Column2;
                    }

                    //局誌コード.
                    sprRDCM.Cells[RdCmRow, 7].Value = Rdrow.KyokusiCd;

                    //局誌名称.
                    if (Rdrow.GetRdKLionRows().Length != 0)
                    {
                        sprRDCM.Cells[RdCmRow, 8].Value = Rdrow.GetRdKLionRows()[0].KYOKUNAME;
                        Rdrow.KyokusiName = Rdrow.GetRdKLionRows()[0].KYOKUNAME;
                    }

                    //総秒数.
                    sprRDCM.Cells[RdCmRow, 9].Value = Rdrow.Sobyosu;

                    //秒数.
                    sprRDCM.Cells[RdCmRow, 10].Value = Rdrow.Byosu;

                    //回数.
                    sprRDCM.Cells[RdCmRow, 11].Value = Rdrow.OnAirKaisu;

                    //番組名.
                    if (Rdrow.GetRdBnLionRows().Length != 0)
                    {
                        sprRDCM.Cells[RdCmRow, 12].Value = Rdrow.GetRdBnLionRows()[0].BANNAME;
                        Rdrow.BangumiName = Rdrow.GetRdBnLionRows()[0].BANNAME;
                    }

                    //番組コードが変化した場合、総秒数を加算する.
                    if (!RdCmBangumiCd.Equals(Rdrow.BangumiCd.ToString()))
                    {
                        RdCmBangumiCd = Rdrow.BangumiCd.ToString();
                        RdCmTotal += Rdrow.Sobyosu;
                    }

                    RdCmRow++;
                }

                //********************************.
                //スプレッドシートに合計行を追加.
                //********************************.
                if (!sprRDCM.RowCount.Equals(0))
                {
                    sprRDCM.Rows.Add(sprRDCM.RowCount, 1);
                    sprRDCM.Cells[RdCmRow, 8].Value = "総秒数合計";
                    sprRDCM.Cells[RdCmRow, 9].Value = RdCmTotal;
                }

                //************************************.
                //値の位置.
                //************************************.
                for (int i = 0; i < 6; i++)
                {
                    sprRDCM.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                }

                //ブランド名称.
                sprRDCM.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

                //局誌コード.
                sprRDCM.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

                //局誌名称.
                sprRDCM.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

                //総秒数.
                sprRDCM.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Center;

                //秒数.
                sprRDCM.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

                //回数.
                sprRDCM.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

                //番組名.
                sprRDCM.Columns[12].HorizontalAlignment = CellHorizontalAlignment.Center;

                //垂直スクロールバーを表示する.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = MastLionDs.RdCmLion.Count.ToString() + "件";

                //取得結果データをDataSetにセット.
                //_dsLion = MastLionDs;

                _dsLion = new MastLion();
                _dsLion.Tables["RdCmLion"].Merge(MastLionDs.RdCmLion);

                #endregion シートにセット.
            }

            #endregion ラジオCM秒数.

            //ローディング表示終了.
            base.CloseLoadingDialog();

            #region ＜未使用＞.

            /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL start */
            //※大幅改修に伴い、旧ソースをコメントアウト.

            ////ローディング表示開始.
            //base.ShowLoadingDialog();

            //# region 共通処理.

            ////媒体名を取得.
            //_mStrBaitaiMei = cmbBaitai.Text;

            //// 年月の取得.
            //string yyyyMm = dtpYyyyMmDd.Value.ToString("yyyyMM");
            ////string yyyyMm = getYYYYMM();

            //FindReportLionByCondServiceResult result = new FindReportLionByCondServiceResult();
            //KKHLionReadMastFile readMastFile = new KKHLionReadMastFile();


            ////媒体がテレビ、ラジオCM秒数以外の場合.
            //if (_mStrBaitaiMei != C_BAITAI_TV_CM
            //    && _mStrBaitaiMei != C_BAITAI_RD_CM)
            //{
            //    //*******************.
            //    //サービスの呼び出し.
            //    //*******************.
            //    ReportLionProcessController processController = ReportLionProcessController.GetInstance();
            //    result = processController.FindRepLionByCond(
            //                                              _naviParam.strEsqId,
            //                                              _naviParam.strEgcd,
            //                                              _naviParam.strTksKgyCd,
            //                                              _naviParam.strTksBmnSeqNo,
            //                                              _naviParam.strTksTntSeqNo,
            //                                              yyyyMm,
            //                                              _mStrBaitaiMei
            //                                              );

            //    //エラーの場合.
            //    if (result.HasError)
            //    {
            //        statusStrip1.Items["tslval1"].Text = "0件";

            //        //ローディング表示終了.
            //        base.CloseLoadingDialog();
            //        return;
            //    }

            //    //取得結果が0件の場合.
            //    if ((result.dsRepLionDataSet.RepLion.Rows.Count == 0)
            //        && (_mStrBaitaiMei != C_BAITAI_SONOTA))
            //    {
            //        //スプレッド初期化.
            //        SprSyokika();

            //        //Excelボタン押下不可能.
            //        btnXls.Enabled = false;

            //        _dsLion = null;

            //        statusStrip1.Items["tslval1"].Text = "0件";

            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
            //    }
            //}

            ////スプレッドシートの初期化.
            //SprSyokika();

            ////初期化.
            //RateGoukei.Clear();

            //# endregion 共通処理.

            ////****************************************.
            ////スプレッドに表示(件数分表示).
            ////****************************************.
            ////シートを判別.

            //# region テレビタイム.

            ////テレビタイムの場合.
            //if (_mStrBaitaiMei == C_BAITAI_TV_TIME)
            //{

            //    //シートを表示する.
            //    sprTV_Time.Visible = true;

            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        //************
            //        //変数初期化.
            //        //************
            //        string _strCardNo = string.Empty;       //カードNo.
            //        string _strBangumiCD = string.Empty;    //番組コード.
            //        int _intRow = 0;                        //行数.

            //        double _dblDenpaRyoShoKei = 0;             //電波料小計.
            //        double _dblNetRyoShoKei = 0;               //ネット料小計.
            //        double _dblSeisakuHiShoKei = 0;            //制作費小計.
            //        double _dblSeikyuGakShoKei = 0;            //請求額小計.

            //        double _dblDenpaRyoGoKei = 0;           //電波料合計.
            //        double _dblNetRyoGoKei = 0;             //ネット料合計.
            //        double _dblSeisakuHiGoKei = 0;          //制作費合計.
            //        double _dblSeikyuGakGoKei = 0;          //請求額合計.
            //        double _dblShohizeiGakGokei = 0;        //消費税額合計.

            //        # region シートにセット.
            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprTV_Time.Rows.Add(sprTV_Time.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                //カードNo、番組コードを保持.
            //                _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();
            //            }

            //            //カードＮｏ、番組コードが異なる場合.
            //            if (_strCardNo != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString()
            //                || _strBangumiCD != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString())
            //            {
            //                //カード計行を作成.
            //                sprTV_Time.Cells[_intRow, 6].Value = "カード計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //電波料小計.
            //                sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyoShoKei.ToString("#,0");

            //                //ネット料小計.
            //                sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyoShoKei.ToString("#,0");

            //                //制作費小計.
            //                sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHiShoKei.ToString("#,0");

            //                //請求額小計.
            //                sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //                //各小計を初期化.
            //                _dblDenpaRyoShoKei = 0;             //電波料小計.
            //                _dblNetRyoShoKei = 0;               //ネット料計.
            //                _dblSeisakuHiShoKei = 0;            //制作費小計.
            //                _dblSeikyuGakShoKei = 0;            //請求額小計.

            //                //カードNo、番組コードを保持.
            //                _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprTV_Time.Rows.Add(sprTV_Time.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprTV_Time.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprTV_Time.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprTV_Time.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprTV_Time.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //番組コード.
            //            sprTV_Time.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

            //            //局誌コード.
            //            sprTV_Time.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

            //            //局誌名称.
            //            sprTV_Time.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

            //            //電波料 = 請求額 - ネット料 - 制作費.
            //            //請求額.
            //            double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            //double _dblSeikyuGak = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            //ネット料.
            //            double _dblNetRyo = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
            //            //double _dblNetRyo = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
            //            //制作費.
            //            double _dblSeisakuHi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
            //            //double _dblSeisakuHi = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
            //            //電波料.
            //            double _dblDenpaRyo = _dblSeikyuGak - _dblNetRyo - _dblSeisakuHi;

            //            sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyo.ToString("#,0");

            //            //ネット料.
            //            sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyo.ToString("#,0");

            //            //制作費.
            //            sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHi.ToString("#,0");

            //            //請求額.
            //            sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGak.ToString("#,0");

            //            //放送回数.
            //            sprTV_Time.Cells[_intRow, 11].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString();

            //            //番組名.
            //            sprTV_Time.Cells[_intRow, 12].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiMei"].ToString();

            //            //******************.
            //            //各小計額をセット.
            //            //******************.
            //            //電波料小計.
            //            _dblDenpaRyoShoKei += _dblDenpaRyo;

            //            //ネット料小計.
            //            _dblNetRyoShoKei += _dblNetRyo;

            //            //制作費小計.
            //            _dblSeisakuHiShoKei += _dblSeisakuHi;

            //            //請求金額小計.
            //            _dblSeikyuGakShoKei += _dblSeikyuGak;

            //            //******************.
            //            //各合計額をセット.
            //            //******************.
            //            //電波料合計.
            //            _dblDenpaRyoGoKei += _dblDenpaRyo;

            //            //ネット料合計.
            //            _dblNetRyoGoKei += _dblNetRyo;

            //            //制作費合計.
            //            _dblSeisakuHiGoKei += _dblSeisakuHi;

            //            //請求金額合計.
            //            _dblSeikyuGakGoKei += _dblSeikyuGak;

            //            //消費税額合計.
            //            _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
            //            //_dblShohizeiGakGokei += double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + _dblSeikyuGak;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (_dblSeikyuGak);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            //行数を加算.
            //            _intRow++;
            //        }

            //        //******************.
            //        //カード計行を作成.
            //        //******************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Time.Rows.Add(sprTV_Time.RowCount, 1);

            //        sprTV_Time.Cells[_intRow, 6].Value = "カード計";
            //        //電波料合計.
            //        sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyoShoKei.ToString("#,0");
            //        //ネット料合計.
            //        sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyoShoKei.ToString("#,0");
            //        //制作費合計.
            //        sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHiShoKei.ToString("#,0");
            //        //請求額合計.
            //        sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Time.Rows.Add(sprTV_Time.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprTV_Time.Cells[_intRow, 6].Value = "代理店計";

            //        //電波料合計.
            //        sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyoGoKei.ToString("#,0");

            //        //ネット料合計.
            //        sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyoGoKei.ToString("#,0");

            //        //制作費合計.
            //        sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHiGoKei.ToString("#,0");

            //        //請求額合計.
            //        sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGakGoKei.ToString("#,0");

            //        //************************************.
            //        //消費税行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Time.Rows.Add(sprTV_Time.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprTV_Time.Cells[_intRow, 6].Value = "消費税計";

            //        //sprTV_Time.Cells[_intRow, 10].Value = _dblShohizeiGakGokei.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprTV_Time.Cells[_intRow, 10].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);
            //        //sprTV_Time.Cells[_intRow, 10].Value = Math.Floor(_dblShohizeiGakGokei);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprTV_Time.Cells[_intRow, 10].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 6; i++)
            //        {
            //            sprTV_Time.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //放送回数.
            //        sprTV_Time.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            //    }

            //        # endregion シートにセット.
            //}

            //# endregion テレビタイム.

            //# region ラジオタイム.

            ////ラジオタイムの場合.
            //if (_mStrBaitaiMei == C_BAITAI_RD_TIME)
            //{

            //    //シートを表示する.
            //    sprRd_Time.Visible = true;

            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        //************
            //        //変数初期化.
            //        //************
            //        string _strCardNo = string.Empty;       //カードNo.
            //        string _strBangumiCD = string.Empty;    //番組コード.
            //        int _intRow = 0;                        //行数.

            //        double _dblDenpaRyoShoKei = 0;             //電波料小計.
            //        double _dblNetRyoShoKei = 0;               //ネット料小計.
            //        double _dblSeisakuHiShoKei = 0;            //制作費小計.
            //        double _dblSeikyuGakShoKei = 0;            //請求額小計.

            //        double _dblDenpaRyoGoKei = 0;           //電波料合計.
            //        double _dblNetRyoGoKei = 0;             //ネット料合計.
            //        double _dblSeisakuHiGoKei = 0;          //制作費合計.
            //        double _dblSeikyuGakGoKei = 0;          //請求額合計.
            //        double _dblShohizeiGakGokei = 0;        //消費税額合計.

            //        # region シートにセット.
            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprRd_Time.Rows.Add(sprRd_Time.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                //カードNo、番組コードを保持.
            //                _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();
            //            }

            //            //カードNo、番組コードが異なる場合.
            //            if (_strCardNo != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString()
            //                || _strBangumiCD != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString())
            //            {
            //                //カード計行を作成.
            //                sprRd_Time.Cells[_intRow, 6].Value = "カード計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //電波料小計.
            //                sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyoShoKei.ToString("#,0");

            //                //ネット料小計.
            //                sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyoShoKei.ToString("#,0");

            //                //制作費小計.
            //                sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHiShoKei.ToString("#,0");

            //                //請求額小計.
            //                sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //                //各小計を初期化.
            //                _dblDenpaRyoShoKei = 0;             //電波料小計.
            //                _dblNetRyoShoKei = 0;               //ネット料計.
            //                _dblSeisakuHiShoKei = 0;            //制作費小計.
            //                _dblSeikyuGakShoKei = 0;            //請求額小計.

            //                //カードNo、番組コードを保持.
            //                _strCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                _strBangumiCD = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprRd_Time.Rows.Add(sprRd_Time.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprRd_Time.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprRd_Time.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprRd_Time.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprRd_Time.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //番組コード.
            //            sprRd_Time.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

            //            //局誌コード.
            //            sprRd_Time.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

            //            //局誌名称.
            //            sprRd_Time.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

            //            //電波料 = 請求額 - ネット料 - 制作費.
            //            //請求額.
            //            double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            //ネット料.
            //            double _dblNetRyo = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
            //            //制作費.
            //            double _dblSeisakuHi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
            //            //電波料.
            //            double _dblDenpaRyo = _dblSeikyuGak - _dblNetRyo - _dblSeisakuHi;

            //            sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyo.ToString("#,0");

            //            //ネット料.
            //            sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyo.ToString("#,0");

            //            //制作費.
            //            sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHi.ToString("#,0");

            //            //請求額.
            //            sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGak.ToString("#,0");

            //            //放送回数.
            //            sprRd_Time.Cells[_intRow, 11].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString();

            //            //番組名.
            //            sprRd_Time.Cells[_intRow, 12].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiMei"].ToString();

            //            //******************.
            //            //各小計額をセット.
            //            //******************.
            //            //電波料小計.
            //            _dblDenpaRyoShoKei += _dblDenpaRyo;

            //            //ネット料小計.
            //            _dblNetRyoShoKei += _dblNetRyo;

            //            //制作費小計.
            //            _dblSeisakuHiShoKei += _dblSeisakuHi;

            //            //請求金額小計.
            //            _dblSeikyuGakShoKei += _dblSeikyuGak;

            //            //******************.
            //            //各合計額をセット.
            //            //******************.
            //            //電波料合計.
            //            _dblDenpaRyoGoKei += _dblDenpaRyo;

            //            //ネット料合計.
            //            _dblNetRyoGoKei += _dblNetRyo;

            //            //制作費合計.
            //            _dblSeisakuHiGoKei += _dblSeisakuHi;

            //            //請求金額合計.
            //            _dblSeikyuGakGoKei += _dblSeikyuGak;

            //            //消費税額合計.
            //            _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
            //            //_dblShohizeiGakGokei += double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + _dblSeikyuGak;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (_dblSeikyuGak);
            //                RateGoukei.Add(data);

            //            }
            //            //2014/01/28 hlc sonobe end

            //            //行数を加算.
            //            _intRow++;
            //        }

            //        //******************.
            //        //カード計行を作成.
            //        //******************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Time.Rows.Add(sprRd_Time.RowCount, 1);

            //        sprRd_Time.Cells[_intRow, 6].Value = "カード計";
            //        //電波料合計.
            //        sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyoShoKei.ToString("#,0");
            //        //ネット料合計.
            //        sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyoShoKei.ToString("#,0");
            //        //制作費合計.
            //        sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHiShoKei.ToString("#,0");
            //        //請求額合計.
            //        sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Time.Rows.Add(sprRd_Time.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprRd_Time.Cells[_intRow, 6].Value = "代理店計";

            //        //電波料合計.
            //        sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyoGoKei.ToString("#,0");

            //        //ネット料合計.
            //        sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyoGoKei.ToString("#,0");

            //        //制作費合計.
            //        sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHiGoKei.ToString("#,0");

            //        //請求額合計.
            //        sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGakGoKei.ToString("#,0");

            //        //************************************.
            //        //消費税行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Time.Rows.Add(sprRd_Time.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprRd_Time.Cells[_intRow, 6].Value = "消費税計";

            //        //sprRd_Time.Cells[_intRow, 10].Value = _dblShohizeiGakGokei.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprRd_Time.Cells[_intRow, 10].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);
            //        //sprRd_Time.Cells[_intRow, 10].Value = Math.Floor(_dblShohizeiGakGokei);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprRd_Time.Cells[_intRow, 10].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 6; i++)
            //        {
            //            sprRd_Time.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //放送回数.
            //        sprRd_Time.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            //    }
            //        # endregion シートにセット.
            //}

            //# endregion ラジオタイム.

            //# region テレビスポット.

            ////テレビスポットの場合.
            //if (_mStrBaitaiMei == C_BAITAI_TV_SPOT)
            //{
            //    //シートを表示する.
            //    sprTV_Spot.Visible = true;

            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        //************
            //        //変数初期化.
            //        //************
            //        string _strBrandCd = string.Empty;      //ブランドコード.
            //        string _strCardNo = string.Empty;       //カードNo.
            //        string _strBangumiCD = string.Empty;    //番組コード.
            //        int _intRow = 0;                        //行数.

            //        double _dblSeikyuGakShoKei = 0;         //請求額小計.
            //        double _dblHonsuShokei = 0;             //本数小計.
            //        double _dblByosuShoKei = 0;             //CM秒数小計.

            //        double _dblSeikyuGakGoKei = 0;          //請求額合計.
            //        double _dblHonsuGokei = 0;              //CM本数合計.
            //        double _dblByosuGoKei = 0;              //CM秒数合計.

            //        double _dblShohizeiGakGokei = 0;        //消費税額合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                //ブランドコードを保持.
            //                _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが異なる場合.
            //            if (_strBrandCd != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString())
            //            {
            //                //ブランド計行を作成.
            //                sprTV_Spot.Cells[_intRow, 7].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //請求額小計.
            //                sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //                //本数小計.
            //                sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsuShokei;

            //                //秒数小計.
            //                sprTV_Spot.Cells[_intRow, 11].Value = _dblByosuShoKei;

            //                //各小計を初期化.
            //                _dblSeikyuGakShoKei = 0;            //請求額小計.
            //                _dblHonsuShokei = 0;                //本数小計.
            //                _dblByosuShoKei = 0;                //秒数小計.

            //                //ブランドコードを保持.
            //                _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprTV_Spot.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprTV_Spot.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprTV_Spot.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprTV_Spot.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprTV_Spot.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprTV_Spot.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //局誌コード.
            //            sprTV_Spot.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

            //            //局誌名称.
            //            sprTV_Spot.Cells[_intRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

            //            //請求額.
            //            double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            //double _dblSeikyuGak = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGak.ToString("#,0");

            //            //CM1本の秒数.
            //            sprTV_Spot.Cells[_intRow, 9].Value = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());
            //            //sprTV_Spot.Cells[_intRow, 9].Value = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());

            //            //本数.
            //            double _dblHonsu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
            //            //double _dblHonsu = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
            //            sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsu;

            //            //秒数.
            //            double _dblByosu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
            //            //double _dblByosu = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
            //            sprTV_Spot.Cells[_intRow, 11].Value = _dblByosu;

            //            //期間.
            //            //String wk = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name7"].ToString();
            //            //String wkFrom = "";
            //            //String wkTo = "";
            //            //if (wk.Length > 15)
            //            //{
            //            //    wkFrom = wk.Substring(0, 8);
            //            //    wkTo = wk.Substring(8, 8);
            //            //}
            //            //if (KKHUtility.IsDate(wkFrom, "yyyyMMdd") && KKHUtility.IsDate(wkTo, "yyyyMMdd"))
            //            //{
            //            //    sprTV_Spot.Cells[_intRow, 12].Value = wkFrom.Insert(6, "/").Insert(4, "/") + " - " + wkTo.Insert(6, "/").Insert(4, "/");
            //            //}
            //            //else
            //            //{
            //            //    sprTV_Spot.Cells[_intRow, 12].Value = "";
            //            //}
            //            sprTV_Spot.Cells[_intRow, 12].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name7"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //請求額小計.
            //            _dblSeikyuGakShoKei += _dblSeikyuGak;

            //            //本数小計.
            //            _dblHonsuShokei += _dblHonsu;

            //            //秒数小計.
            //            _dblByosuShoKei += _dblByosu;

            //            //**************************.
            //            //各合計額を変数にセット.
            //            //**************************.
            //            //請求額合計.
            //            _dblSeikyuGakGoKei += _dblSeikyuGak;

            //            //消費税額合計.
            //            _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

            //            //本数合計.
            //            _dblHonsuGokei += _dblHonsu;

            //            //秒数合計.
            //            _dblByosuGoKei += _dblByosu;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + _dblSeikyuGak;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (_dblSeikyuGak);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            //行数を加算.
            //            _intRow++;
            //        }

            //        //******************.
            //        //カード計行を作成.
            //        //******************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

            //        sprTV_Spot.Cells[_intRow, 7].Value = "ブランド計";

            //        //請求額小計.
            //        sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //        //本数小計.
            //        sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsuShokei.ToString("#,0");

            //        //秒数小計.
            //        sprTV_Spot.Cells[_intRow, 11].Value = _dblByosuShoKei.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprTV_Spot.Cells[_intRow, 7].Value = "代理店計";

            //        //請求額合計.
            //        sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakGoKei.ToString("#,0");

            //        //本数合計.
            //        sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsuGokei;

            //        //秒数小計.
            //        sprTV_Spot.Cells[_intRow, 11].Value = _dblByosuGoKei;

            //        //************************************.
            //        //消費税行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprTV_Spot.Cells[_intRow, 7].Value = "消費税計";

            //        //sprTV_Spot.Cells[_intRow, 8].Value = _dblShohizeiGakGokei.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprTV_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);
            //        //sprTV_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblShohizeiGakGokei);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprTV_Spot.Cells[_intRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprTV_Spot.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprTV_Spot.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //局コード.
            //        sprTV_Spot.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //局名称.
            //        sprTV_Spot.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        # endregion シートにセット.
            //    }
            //}

            //# endregion テレビスポット.

            //# region ラジオスポット.

            ////ラジオスポットの場合.
            //if (_mStrBaitaiMei == C_BAITAI_RD_SPOT)
            //{
            //    //シートを表示する.
            //    sprRd_Spot.Visible = true;

            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        //************
            //        //変数初期化.
            //        //************
            //        string _strBrandCd = string.Empty;      //ブランドコード.
            //        string _strCardNo = string.Empty;       //カードNo.
            //        string _strBangumiCD = string.Empty;    //番組コード.
            //        int _intRow = 0;                        //行数.

            //        double _dblSeikyuGakShoKei = 0;         //請求額小計.
            //        double _dblHonsuShokei = 0;             //本数小計.
            //        double _dblByosuShoKei = 0;             //CM秒数小計.

            //        double _dblSeikyuGakGoKei = 0;          //請求額合計.
            //        double _dblHonsuGokei = 0;              //CM本数合計.
            //        double _dblByosuGoKei = 0;              //CM秒数合計.

            //        double _dblShohizeiGakGokei = 0;        //消費税額合計.

            //        # region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprRd_Spot.Rows.Add(sprRd_Spot.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                //ブランドコードを保持.
            //                _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが異なる場合.
            //            if (_strBrandCd != result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString())
            //            {
            //                //ブランド計行を作成.
            //                sprRd_Spot.Cells[_intRow, 7].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //請求額小計.
            //                sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //                //本数小計.
            //                sprRd_Spot.Cells[_intRow, 10].Value = _dblHonsuShokei;

            //                //秒数小計.
            //                sprRd_Spot.Cells[_intRow, 11].Value = _dblByosuShoKei;

            //                //各小計を初期化.
            //                _dblSeikyuGakShoKei = 0;            //請求額小計.
            //                _dblHonsuShokei = 0;                //本数小計.
            //                _dblByosuShoKei = 0;                //秒数小計.

            //                //ブランドコードを保持.
            //                _strBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprRd_Spot.Rows.Add(sprRd_Spot.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprRd_Spot.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprRd_Spot.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprRd_Spot.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprRd_Spot.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprRd_Spot.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprRd_Spot.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //局誌コード.
            //            sprRd_Spot.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

            //            //局誌名称.
            //            sprRd_Spot.Cells[_intRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

            //            //請求額.
            //            double _dblSeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGak.ToString("#,0");

            //            //CM1本の秒数.
            //            sprRd_Spot.Cells[_intRow, 9].Value = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());

            //            //本数.
            //            double _dblHonsu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
            //            sprRd_Spot.Cells[_intRow, 10].Value = _dblHonsu;

            //            //秒数.
            //            double _dblByosu = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
            //            sprRd_Spot.Cells[_intRow, 11].Value = _dblByosu;

            //            //期間.
            //            sprRd_Spot.Cells[_intRow, 12].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name7"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //請求額小計.
            //            _dblSeikyuGakShoKei += _dblSeikyuGak;

            //            //本数小計.
            //            _dblHonsuShokei += _dblHonsu;

            //            //秒数小計.
            //            _dblByosuShoKei += _dblByosu;

            //            //**************************.
            //            //各合計額を変数にセット.
            //            //**************************.
            //            //請求額合計.
            //            _dblSeikyuGakGoKei += _dblSeikyuGak;

            //            //消費税額合計.
            //            _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

            //            //本数合計.
            //            _dblHonsuGokei += _dblHonsu;

            //            //秒数合計.
            //            _dblByosuGoKei += _dblByosu;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + _dblSeikyuGak;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (_dblSeikyuGak);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            //行数を加算.
            //            _intRow++;
            //        }

            //        //******************.
            //        //カード計行を作成.
            //        //******************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Spot.Rows.Add(sprRd_Spot.RowCount, 1);

            //        sprRd_Spot.Cells[_intRow, 7].Value = "ブランド計";

            //        //請求額小計.
            //        sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakShoKei.ToString("#,0");

            //        //本数小計.
            //        sprRd_Spot.Cells[_intRow, 10].Value = _dblHonsuShokei;

            //        //秒数小計.
            //        sprRd_Spot.Cells[_intRow, 11].Value = _dblByosuShoKei;

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Spot.Rows.Add(sprRd_Spot.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprRd_Spot.Cells[_intRow, 7].Value = "代理店計";

            //        //請求額合計.
            //        sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakGoKei.ToString("#,0");

            //        //本数合計.
            //        sprRd_Spot.Cells[_intRow, 10].Value = _dblHonsuGokei;

            //        //秒数小計.
            //        sprRd_Spot.Cells[_intRow, 11].Value = _dblByosuGoKei;

            //        //************************************.
            //        //消費税行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprRd_Spot.Rows.Add(sprRd_Spot.RowCount, 1);

            //        //行数を加算.
            //        _intRow++;

            //        sprRd_Spot.Cells[_intRow, 7].Value = "消費税計";

            //        //sprRd_Spot.Cells[_intRow, 8].Value = _dblShohizeiGakGokei.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprRd_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);
            //        //sprRd_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblShohizeiGakGokei);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }

            //        sprRd_Spot.Cells[_intRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprRd_Spot.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprRd_Spot.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //局コード.
            //        sprRd_Spot.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //局名称.
            //        sprRd_Spot.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        # endregion シートにセット.
            //    }
            //}

            //#endregion ラジオスポット.

            //#region 新聞.

            ////新聞の場合.
            //if (_mStrBaitaiMei == C_BAITAI_SHINBUN)
            //{
            //    //シートを表示する.
            //    sprShin.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        string _strShiBrandCd = string.Empty;                     //ブランドコード.
            //        double _brandJissiSyoukei = 0;                            //ブランド実施料小計.
            //        double _brandSeiSyoukei = 0;                              //ブランド請求額小計.
            //        double _dairiJissiSyoukei = 0;                            //代理店実施料小計.
            //        double _dairiSeiSyoukei = 0;                              //代理店請求額小計.
            //        double _SyouhizeiGoukei = 0;                              //消費税合計.
            //        int _intShinRow = 0;                                      //行数.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprShin.Rows.Add(sprShin.RowCount, 1);
            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strShiBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }
            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strShiBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprShin.Cells[_intShinRow, 7].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド実施料計.
            //                sprShin.Cells[_intShinRow, 8].Value = _brandJissiSyoukei.ToString("#,0");
            //                //ブランド請求料計.
            //                sprShin.Cells[_intShinRow, 9].Value = _brandSeiSyoukei.ToString("#,0");

            //                //各小計を初期化.
            //                _brandJissiSyoukei = 0;
            //                _brandSeiSyoukei = 0;

            //                _strShiBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprShin.Rows.Add(sprShin.RowCount, 1);

            //                //行数を加算.
            //                _intShinRow++;
            //            }

            //            //カードNo.
            //            sprShin.Cells[_intShinRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprShin.Cells[_intShinRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprShin.Cells[_intShinRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprShin.Cells[_intShinRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprShin.Cells[_intShinRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprShin.Cells[_intShinRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //新聞コード.
            //            sprShin.Cells[_intShinRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shinCd"].ToString();

            //            //新聞名称.
            //            sprShin.Cells[_intShinRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shinMei"].ToString();

            //            //実施料.
            //            double ShinJissi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name4"].ToString());
            //            sprShin.Cells[_intShinRow, 8].Value = ShinJissi.ToString("#,0");

            //            //請求金額.
            //            double ShinSeigak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
            //            sprShin.Cells[_intShinRow, 9].Value = ShinSeigak.ToString("#,0");

            //            //備考.
            //            sprShin.Cells[_intShinRow, 10].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計実施料.
            //            _brandJissiSyoukei = _brandJissiSyoukei + ShinJissi;
            //            //ブランド計請求額.
            //            _brandSeiSyoukei = _brandSeiSyoukei + ShinSeigak;
            //            //代理店実施料.
            //            _dairiJissiSyoukei = _dairiJissiSyoukei + ShinJissi;
            //            //代理店請求額.
            //            _dairiSeiSyoukei = _dairiSeiSyoukei + ShinSeigak;
            //            //消費税合計.
            //            double ShinSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
            //            _SyouhizeiGoukei = _SyouhizeiGoukei + ShinSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + ShinSeigak;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (ShinSeigak);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            //行数を加算.
            //            _intShinRow++;
            //        }
            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprShin.Rows.Add(sprShin.RowCount, 1);
            //        sprShin.Cells[_intShinRow, 7].Value = "ブランド計";
            //        sprShin.Cells[_intShinRow, 8].Value = _brandJissiSyoukei.ToString("#,0");
            //        sprShin.Cells[_intShinRow, 9].Value = _brandSeiSyoukei.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprShin.Rows.Add(sprShin.RowCount, 1);
            //        //行数を加算.
            //        _intShinRow++;
            //        sprShin.Cells[_intShinRow, 7].Value = "代理店計";
            //        sprShin.Cells[_intShinRow, 8].Value = _dairiJissiSyoukei.ToString("#,0");
            //        sprShin.Cells[_intShinRow, 9].Value = _dairiSeiSyoukei.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprShin.Rows.Add(sprShin.RowCount, 1);
            //        //行数を加算.
            //        _intShinRow++;
            //        sprShin.Cells[_intShinRow, 7].Value = "消費税計";
            //        //sprShin.Cells[_intShinRow, 8].Value = _SyouhizeiGoukei.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprShin.Cells[_intShinRow, 8].Value = Math.Floor(_dairiSeiSyoukei * _dblShohizei);
            //        //sprShin.Cells[_intShinRow, 8].Value = Math.Floor(_SyouhizeiGoukei);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprShin.Cells[_intShinRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprShin.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprShin.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //新聞コード.
            //        sprShin.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //新聞名称.
            //        sprShin.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //実施料.
            //        sprShin.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //請求額.
            //        sprShin.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //備考.
            //        sprShin.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion 新聞.

            //#region 雑誌.

            ////雑誌の場合.
            //if (_mStrBaitaiMei == C_BAITAI_ZASHI)
            //{
            //    //シートを表示する.
            //    sprZashi.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        string _strMzBrandCd = string.Empty;                     //ブランドコード.
            //        double _brandJissiSyoukeiMZ = 0;                         //ブランド実施料.
            //        double _brandSeiSyoukeiMZ = 0;                           //ブランド請求額.
            //        double _dairiJissiSyoukeiMZ = 0;                         //代理店実施料小計.
            //        double _dairiSeiSyoukeiMZ = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeiMZ = 0;                           //消費税合計.
            //        int _intMzRow = 0;                                       //行数.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprZashi.Rows.Add(sprZashi.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strMzBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strMzBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprZashi.Cells[_intMzRow, 7].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド実施料計.
            //                sprZashi.Cells[_intMzRow, 9].Value = _brandJissiSyoukeiMZ.ToString("#,0");
            //                //ブランド請求料計.
            //                sprZashi.Cells[_intMzRow, 10].Value = _brandSeiSyoukeiMZ.ToString("#,0");
            //                //各小計を初期化.
            //                _brandJissiSyoukeiMZ = 0;
            //                _brandSeiSyoukeiMZ = 0;

            //                _strMzBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprZashi.Rows.Add(sprZashi.RowCount, 1);

            //                //行数を加算.
            //                _intMzRow++;
            //            }

            //            //カードNo.
            //            sprZashi.Cells[_intMzRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprZashi.Cells[_intMzRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprZashi.Cells[_intMzRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprZashi.Cells[_intMzRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprZashi.Cells[_intMzRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprZashi.Cells[_intMzRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //雑誌コード.
            //            sprZashi.Cells[_intMzRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiCd"].ToString();

            //            //雑誌名称.
            //            sprZashi.Cells[_intMzRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiName"].ToString();

            //            //スペース.
            //            sprZashi.Cells[_intMzRow, 8].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Space"].ToString();

            //            //実施料.
            //            double MzJissi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name4"].ToString()) + KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kngk3"].ToString());
            //            sprZashi.Cells[_intMzRow, 9].Value = MzJissi.ToString("#,0");

            //            //請求額.
            //            double MzSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprZashi.Cells[_intMzRow, 10].Value = MzSei.ToString("#,0");

            //            //備考.
            //            sprZashi.Cells[_intMzRow, 11].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計実施料.
            //            _brandJissiSyoukeiMZ = _brandJissiSyoukeiMZ + MzJissi;
            //            //ブランド計請求額.
            //            _brandSeiSyoukeiMZ = _brandSeiSyoukeiMZ + MzSei;
            //            //代理店実施料.
            //            _dairiJissiSyoukeiMZ = _dairiJissiSyoukeiMZ + MzJissi;
            //            //代理店請求額.
            //            _dairiSeiSyoukeiMZ = _dairiSeiSyoukeiMZ + MzSei;
            //            //消費税合計.
            //            double MagSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeiMZ = _SyouhizeiGoukeiMZ + MagSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + MzSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (MzSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intMzRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprZashi.Rows.Add(sprZashi.RowCount, 1);
            //        sprZashi.Cells[_intMzRow, 7].Value = "ブランド計";
            //        sprZashi.Cells[_intMzRow, 9].Value = _brandJissiSyoukeiMZ.ToString("#,0");
            //        sprZashi.Cells[_intMzRow, 10].Value = _brandSeiSyoukeiMZ.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprZashi.Rows.Add(sprZashi.RowCount, 1);
            //        //行数を加算.
            //        _intMzRow++;
            //        sprZashi.Cells[_intMzRow, 7].Value = "代理店計";
            //        sprZashi.Cells[_intMzRow, 9].Value = _dairiJissiSyoukeiMZ.ToString("#,0");
            //        sprZashi.Cells[_intMzRow, 10].Value = _dairiSeiSyoukeiMZ.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprZashi.Rows.Add(sprZashi.RowCount, 1);
            //        //行数を加算.
            //        _intMzRow++;
            //        sprZashi.Cells[_intMzRow, 7].Value = "消費税計";
            //        //sprZashi.Cells[_intMzRow, 9].Value = _SyouhizeiGoukeiMZ.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprShin.Cells[_intShinRow, 8].Value = Math.Floor(_dairiSeiSyoukei * _dblShohizei);
            //        //sprZashi.Cells[_intMzRow, 9].Value = Math.Floor(_SyouhizeiGoukeiMZ);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }

            //        sprZashi.Cells[_intMzRow, 9].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprZashi.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprZashi.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //雑誌コード.
            //        sprZashi.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //雑誌名称.
            //        sprZashi.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //スペース.
            //        sprZashi.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //実施料.
            //        sprZashi.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //請求額.
            //        sprZashi.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //備考.
            //        sprZashi.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion 雑誌.

            //#region テレビCM秒数.

            ////テレビCM秒数.
            //if (_mStrBaitaiMei == C_BAITAI_TV_CM)
            //{
            //    MastLionDs.TvCmLion.Clear();
            //    MastLionDs.TvCmLion.Merge(readMastFile.GetLionTvRdCm(_naviParam, yyyyMm).TvCmLion);

            //    //シートを表示する.
            //    sprTV_Cm.Visible = true;

            //    //テレビCMのデータが無い場合.
            //    if (MastLionDs.TvCmLion.Rows.Count == 0)
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
            //        //Excelボタン押下不可.
            //        btnXls.Enabled = false;
            //    }
            //    else if (KKHLionCMDateCheck.checkTVCMDate(yyyyMm, MastLionDs.TvCmLion) != false)
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0110, null, "プルーフリスト", MessageBoxButtons.OK);
            //        //Excelボタン押下不可.
            //        btnXls.Enabled = false;

            //        //データをクリア.
            //        MastLionDs.TvCmLion.Clear();
            //    }
            //    else
            //    {
            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;
            //    }
            //    //垂直スクロールバーを作業中は非表示にする.
            //    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //    //************
            //    //変数初期化.
            //    //************
            //    int TvCmRow = 0;                        //行数.
            //    string TvCmBangumiCd = string.Empty;    //番組コード.
            //    long TvCmTotal = 0;                     //合計秒数.

            //    #region シートにセット.

            //    foreach (MastLion.TvCmLionRow row in MastLionDs.TvCmLion)
            //    {
            //        //********************************.
            //        //スプレッドシートに行を追加.
            //        //********************************.
            //        sprTV_Cm.Rows.Add(sprTV_Cm.RowCount, 1);

            //        //カードNo.
            //        sprTV_Cm.Cells[TvCmRow, 0].Value = row.CardKbn;

            //        //データ年月.
            //        sprTV_Cm.Cells[TvCmRow, 1].Value = row.YearMonth;

            //        //代理店コード.
            //        sprTV_Cm.Cells[TvCmRow, 2].Value = row.DairitenCd;

            //        //媒体区分.
            //        sprTV_Cm.Cells[TvCmRow, 3].Value = row.baitaiKbn;

            //        //番組コード.
            //        sprTV_Cm.Cells[TvCmRow, 4].Value = row.BangumiCd;

            //        //ブランドコード.
            //        sprTV_Cm.Cells[TvCmRow, 5].Value = row.BrandCd;

            //        //ブランド名称.
            //        if (row.GetBrandLionRows().Length != 0)
            //        {
            //            sprTV_Cm.Cells[TvCmRow, 6].Value = row.GetBrandLionRows()[0].Column2;
            //            row.BrandName = row.GetBrandLionRows()[0].Column2;
            //        }

            //        //局誌コード.
            //        sprTV_Cm.Cells[TvCmRow, 7].Value = row.KyokusiCd;

            //        //局誌名称.
            //        if (row.GetTvKLionRows().Length != 0)
            //        {
            //            sprTV_Cm.Cells[TvCmRow, 8].Value = row.GetTvKLionRows()[0].KYOKUNAME;
            //            row.KyokusiName = row.GetTvKLionRows()[0].KYOKUNAME;
            //        }

            //        //総秒数.
            //        sprTV_Cm.Cells[TvCmRow, 9].Value = row.Sobyosu;

            //        //秒数.
            //        sprTV_Cm.Cells[TvCmRow, 10].Value = row.Byosu;

            //        //回数.
            //        sprTV_Cm.Cells[TvCmRow, 11].Value = row.OnAirKaisu;

            //        //番組名.
            //        if (row.GetTvBnLionRows().Length != 0)
            //        {
            //            sprTV_Cm.Cells[TvCmRow, 12].Value = row.GetTvBnLionRows()[0].BANNAME;
            //            row.BangumiName = row.GetTvBnLionRows()[0].BANNAME;
            //        }

            //        //番組コードが変化した場合、総秒数を加算する.
            //        if (!TvCmBangumiCd.Equals(row.BangumiCd.ToString()))
            //        {
            //            TvCmBangumiCd = row.BangumiCd.ToString();
            //            TvCmTotal += row.Sobyosu;
            //        }

            //        TvCmRow++;
            //    }

            //    //********************************.
            //    //スプレッドシートに合計行を追加.
            //    //********************************.
            //    if (!sprTV_Cm.RowCount.Equals(0))
            //    {
            //        sprTV_Cm.Rows.Add(sprTV_Cm.RowCount, 1);
            //        sprTV_Cm.Cells[TvCmRow, 8].Value = "総秒数合計";
            //        sprTV_Cm.Cells[TvCmRow, 9].Value = TvCmTotal;
            //    }

            //    //************************************.
            //    //値の位置.
            //    //************************************.
            //    for (int i = 0; i < 6; i++)
            //    {
            //        sprTV_Cm.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //    }
            //    //ブランド名称.
            //    sprTV_Cm.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //局誌コード.
            //    sprTV_Cm.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

            //    //局誌名称.
            //    sprTV_Cm.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //総秒数.
            //    sprTV_Cm.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Center;

            //    //秒数.
            //    sprTV_Cm.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

            //    //回数.
            //    sprTV_Cm.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //番組名.
            //    sprTV_Cm.Columns[12].HorizontalAlignment = CellHorizontalAlignment.Center;

            //    //垂直スクロールバーを表示する.
            //    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //    //件数をセット.
            //    statusStrip1.Items["tslval1"].Text = MastLionDs.TvCmLion.Count.ToString() + "件";

            //    //取得結果データをDataSetにセット.
            //    //_dsLion = result.dsRepLionDataSet;
            //    //_dsLion = MastLionDs;
            //    _dsLion = new MastLion();
            //    _dsLion.Tables["TvCmLion"].Merge(MastLionDs.TvCmLion);

            //    #endregion シートにセット.
            //}

            //# endregion テレビスポット.

            //#region ラジオCM秒数.

            ////ラジオCM秒数の場合.
            //if (_mStrBaitaiMei == C_BAITAI_RD_CM)
            //{
            //    MastLionDs.RdCmLion.Clear();
            //    MastLionDs.RdCmLion.Merge(readMastFile.GetLionTvRdCm(_naviParam, yyyyMm).RdCmLion);

            //    //シートを表示する.
            //    sprRd_Cm.Visible = true;

            //    //ラジオCMのデータが無い場合.
            //    if (MastLionDs.RdCmLion.Count == 0)
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "プルーフリスト", MessageBoxButtons.OK);
            //        //Excelボタン押下不可.
            //        btnXls.Enabled = false;
            //    }
            //    else if (KKHLionCMDateCheck.checkRDCMDate(yyyyMm, MastLionDs.RdCmLion) != false)
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0110, null, "プルーフリスト", MessageBoxButtons.OK);
            //        //Excelボタン押下不可.
            //        btnXls.Enabled = false;
            //        //データをクリア.
            //        MastLionDs.RdCmLion.Clear();
            //    }
            //    else
            //    {
            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;
            //    }
            //    //垂直スクロールバーを作業中は非表示にする.
            //    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //    //************
            //    //変数初期化.
            //    //************
            //    int RdCmRow = 0;                        //行数.
            //    string RdCmBangumiCd = string.Empty;    //番組コード.
            //    long RdCmTotal = 0;                     //合計秒数.

            //    #region シートにセット.

            //    foreach (MastLion.RdCmLionRow Rdrow in MastLionDs.RdCmLion)
            //    {
            //        //********************************.
            //        //スプレッドシートに行を追加.
            //        //********************************.
            //        sprRd_Cm.Rows.Add(sprRd_Cm.RowCount, 1);

            //        //カードNo.
            //        sprRd_Cm.Cells[RdCmRow, 0].Value = Rdrow.CardKbn;

            //        //データ年月.
            //        sprRd_Cm.Cells[RdCmRow, 1].Value = Rdrow.YearMonth;

            //        //代理店コード.
            //        sprRd_Cm.Cells[RdCmRow, 2].Value = Rdrow.DairitenCd;

            //        //媒体区分.
            //        sprRd_Cm.Cells[RdCmRow, 3].Value = Rdrow.baitaiKbn;

            //        //番組コード.
            //        sprRd_Cm.Cells[RdCmRow, 4].Value = Rdrow.BangumiCd;

            //        //ブランドコード.
            //        sprRd_Cm.Cells[RdCmRow, 5].Value = Rdrow.BrandCd;

            //        //ブランド名称.
            //        if (Rdrow.GetBrandLionRows().Length != 0)
            //        {
            //            sprRd_Cm.Cells[RdCmRow, 6].Value = Rdrow.GetBrandLionRows()[0].Column2;
            //            Rdrow.BrandName = Rdrow.GetBrandLionRows()[0].Column2;
            //        }

            //        //局誌コード.
            //        sprRd_Cm.Cells[RdCmRow, 7].Value = Rdrow.KyokusiCd;

            //        //局誌名称.
            //        if (Rdrow.GetRdKLionRows().Length != 0)
            //        {
            //            sprRd_Cm.Cells[RdCmRow, 8].Value = Rdrow.GetRdKLionRows()[0].KYOKUNAME;
            //            Rdrow.KyokusiName = Rdrow.GetRdKLionRows()[0].KYOKUNAME;
            //        }

            //        //総秒数.
            //        sprRd_Cm.Cells[RdCmRow, 9].Value = Rdrow.Sobyosu;

            //        //秒数.
            //        sprRd_Cm.Cells[RdCmRow, 10].Value = Rdrow.Byosu;

            //        //回数.
            //        sprRd_Cm.Cells[RdCmRow, 11].Value = Rdrow.OnAirKaisu;

            //        //番組名.
            //        if (Rdrow.GetRdBnLionRows().Length != 0)
            //        {
            //            sprRd_Cm.Cells[RdCmRow, 12].Value = Rdrow.GetRdBnLionRows()[0].BANNAME;
            //            Rdrow.BangumiName = Rdrow.GetRdBnLionRows()[0].BANNAME;
            //        }

            //        //番組コードが変化した場合、総秒数を加算する.
            //        if (!RdCmBangumiCd.Equals(Rdrow.BangumiCd.ToString()))
            //        {
            //            RdCmBangumiCd = Rdrow.BangumiCd.ToString();
            //            RdCmTotal += Rdrow.Sobyosu;
            //        }

            //        RdCmRow++;
            //    }

            //    //********************************.
            //    //スプレッドシートに合計行を追加.
            //    //********************************.
            //    if (!sprRd_Cm.RowCount.Equals(0))
            //    {
            //        sprRd_Cm.Rows.Add(sprRd_Cm.RowCount, 1);
            //        sprRd_Cm.Cells[RdCmRow, 8].Value = "総秒数合計";
            //        sprRd_Cm.Cells[RdCmRow, 9].Value = RdCmTotal;
            //    }

            //    //************************************.
            //    //値の位置.
            //    //************************************.
            //    for (int i = 0; i < 6; i++)
            //    {
            //        sprRd_Cm.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //    }

            //    //ブランド名称.
            //    sprRd_Cm.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //局誌コード.
            //    sprRd_Cm.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

            //    //局誌名称.
            //    sprRd_Cm.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //総秒数.
            //    sprRd_Cm.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Center;

            //    //秒数.
            //    sprRd_Cm.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

            //    //回数.
            //    sprRd_Cm.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

            //    //番組名.
            //    sprRd_Cm.Columns[12].HorizontalAlignment = CellHorizontalAlignment.Center;

            //    //垂直スクロールバーを表示する.
            //    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //    //件数をセット.
            //    statusStrip1.Items["tslval1"].Text = MastLionDs.RdCmLion.Count.ToString() + "件";

            //    //取得結果データをDataSetにセット.
            //    //_dsLion = MastLionDs;

            //    _dsLion = new MastLion();
            //    _dsLion.Tables["RdCmLion"].Merge(MastLionDs.RdCmLion);

            //    #endregion シートにセット.
            //}

            //#endregion ラジオCM秒数.

            //#region 交通.

            ////交通の場合.
            //if (_mStrBaitaiMei == C_BAITAI_KOTSU)
            //{
            //    //シートを表示する.
            //    sprKoutsuu.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //        string _strOohBrandCd = string.Empty;                       //ブランドコード.
            //        int _intRow = 0;                                       //行数.
            //        double _brandSeiSyoukeiOoh = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeiOoh = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeiOoh = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strOohBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strOohBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprKoutsuu.Cells[_intRow, 7].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprKoutsuu.Cells[_intRow, 8].Value = _brandSeiSyoukeiOoh.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeiOoh = 0;

            //                _strOohBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprKoutsuu.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprKoutsuu.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprKoutsuu.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprKoutsuu.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprKoutsuu.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprKoutsuu.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //県コード.
            //            sprKoutsuu.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenCd"].ToString();

            //            //県名.
            //            sprKoutsuu.Cells[_intRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenName"].ToString();

            //            //請求額.
            //            double OohSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprKoutsuu.Cells[_intRow, 8].Value = OohSei.ToString("#,0");

            //            //路線名.
            //            sprKoutsuu.Cells[_intRow, 9].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["RosenName"].ToString();

            //            //期間.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString()))
            //            {
            //                result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"] = "";
            //            }
            //            else
            //            {
            //                sprKoutsuu.Cells[_intRow, 10].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString();
            //            }
            //            //備考.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString()))
            //            {
            //                result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"] = "";
            //            }
            //            else
            //            {
            //                sprKoutsuu.Cells[_intRow, 11].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();
            //            }

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeiOoh = _brandSeiSyoukeiOoh + OohSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeiOoh = _dairiSeiSyoukeiOoh + OohSei;
            //            //消費税合計.
            //            double KoutsuSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeiOoh = _SyouhizeiGoukeiOoh + KoutsuSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + OohSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (OohSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);
            //        sprKoutsuu.Cells[_intRow, 7].Value = "ブランド計";
            //        sprKoutsuu.Cells[_intRow, 8].Value = _brandSeiSyoukeiOoh.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprKoutsuu.Cells[_intRow, 7].Value = "代理店計";
            //        sprKoutsuu.Cells[_intRow, 8].Value = _dairiSeiSyoukeiOoh.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprKoutsuu.Cells[_intRow, 7].Value = "消費税計";
            //        //sprKoutsuu.Cells[_intRow, 8].Value = _SyouhizeiGoukeiOoh.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprKoutsuu.Cells[_intRow, 8].Value = Math.Floor(_dairiSeiSyoukeiOoh * _dblShohizei);
            //        //sprKoutsuu.Cells[_intRow, 8].Value = Math.Floor(_SyouhizeiGoukeiOoh);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprKoutsuu.Cells[_intRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        //カードNO
            //        sprKoutsuu.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        //データ年月.
            //        sprKoutsuu.Columns[1].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        //代理店コード.
            //        sprKoutsuu.Columns[2].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        //媒体区分.
            //        sprKoutsuu.Columns[3].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        //ブランドコード.
            //        sprKoutsuu.Columns[4].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        //ブランド名称.
            //        sprKoutsuu.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        //県コード.
            //        sprKoutsuu.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;
            //        //県名称.
            //        sprKoutsuu.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        //請求金額.
            //        sprKoutsuu.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;
            //        //路線名.
            //        sprKoutsuu.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        //期間.
            //        sprKoutsuu.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        //備考.
            //        sprKoutsuu.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;
            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;
            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;
            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";
            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion 交通.

            //#region 事業費.

            ////事業費の場合.
            //if (_mStrBaitaiMei == C_BAITAI_JIGYOUBU)
            //{
            //    //シートを表示する.
            //    sprJigyoubu.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strJigyouBrandCd = string.Empty;                       //ブランドコード.
            //        int _intJigyouRow = 0;                                       //行数.
            //        double _brandSeiSyoukeiJigyou = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeiJigyou = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeiJigyou = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strJigyouBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strJigyouBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprJigyoubu.Cells[_intJigyouRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprJigyoubu.Cells[_intJigyouRow, 6].Value = _brandSeiSyoukeiJigyou.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeiJigyou = 0;

            //                _strJigyouBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);

            //                //行数を加算.
            //                _intJigyouRow++;
            //            }

            //            //カードNo.
            //            sprJigyoubu.Cells[_intJigyouRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprJigyoubu.Cells[_intJigyouRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprJigyoubu.Cells[_intJigyouRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprJigyoubu.Cells[_intJigyouRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprJigyoubu.Cells[_intJigyouRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprJigyoubu.Cells[_intJigyouRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //請求額.
            //            double JigyouSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprJigyoubu.Cells[_intJigyouRow, 6].Value = JigyouSei.ToString("#,0");

            //            //件名.
            //            sprJigyoubu.Cells[_intJigyouRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeiJigyou = _brandSeiSyoukeiJigyou + JigyouSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeiJigyou = _dairiSeiSyoukeiJigyou + JigyouSei;
            //            //消費税合計.
            //            double JigyouSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeiJigyou = _SyouhizeiGoukeiJigyou + JigyouSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + JigyouSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (JigyouSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intJigyouRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);
            //        sprJigyoubu.Cells[_intJigyouRow, 5].Value = "ブランド計";
            //        sprJigyoubu.Cells[_intJigyouRow, 6].Value = _brandSeiSyoukeiJigyou.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);
            //        //行数を加算.
            //        _intJigyouRow++;
            //        sprJigyoubu.Cells[_intJigyouRow, 5].Value = "代理店計";
            //        sprJigyoubu.Cells[_intJigyouRow, 6].Value = _dairiSeiSyoukeiJigyou.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);
            //        //行数を加算.
            //        _intJigyouRow++;
            //        sprJigyoubu.Cells[_intJigyouRow, 5].Value = "消費税計";
            //        //sprJigyoubu.Cells[_intJigyouRow, 6].Value = _SyouhizeiGoukeiJigyou.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprJigyoubu.Cells[_intJigyouRow, 6].Value = Math.Floor(_dairiSeiSyoukeiJigyou * _dblShohizei);
            //        sprJigyoubu.Cells[_intJigyouRow, 6].Value = Math.Floor(_SyouhizeiGoukeiJigyou);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprJigyoubu.Cells[_intJigyouRow, 6].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprJigyoubu.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprJigyoubu.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //請求額.
            //        sprJigyoubu.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprJigyoubu.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion 事業費.

            //#region チラシ.

            ////チラシの場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_CHIRASHI))
            //{
            //    //シートを表示する.
            //    sprTirashi.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strtirashiBrandCd = string.Empty;                      //ブランドコード.
            //        int _inttirashiRow = 0;                                       //行数.
            //        double _brandSeiSyoukeitirashi = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeitirashi = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeitirashi = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprTirashi.Rows.Add(sprTirashi.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strtirashiBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strtirashiBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprTirashi.Cells[_inttirashiRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprTirashi.Cells[_inttirashiRow, 6].Value = _brandSeiSyoukeitirashi.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeitirashi = 0;

            //                _strtirashiBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprTirashi.Rows.Add(sprTirashi.RowCount, 1);

            //                //行数を加算.
            //                _inttirashiRow++;
            //            }

            //            //カードNo.
            //            sprTirashi.Cells[_inttirashiRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprTirashi.Cells[_inttirashiRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprTirashi.Cells[_inttirashiRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprTirashi.Cells[_inttirashiRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprTirashi.Cells[_inttirashiRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprTirashi.Cells[_inttirashiRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //請求額.
            //            double tirashiSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprTirashi.Cells[_inttirashiRow, 6].Value = tirashiSei.ToString("#,0");

            //            //件名.
            //            sprTirashi.Cells[_inttirashiRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeitirashi = _brandSeiSyoukeitirashi + tirashiSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeitirashi = _dairiSeiSyoukeitirashi + tirashiSei;
            //            //消費税合計.
            //            double tirashiSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeitirashi = _SyouhizeiGoukeitirashi + tirashiSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + tirashiSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (tirashiSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _inttirashiRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTirashi.Rows.Add(sprTirashi.RowCount, 1);
            //        sprTirashi.Cells[_inttirashiRow, 5].Value = "ブランド計";
            //        sprTirashi.Cells[_inttirashiRow, 6].Value = _brandSeiSyoukeitirashi.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTirashi.Rows.Add(sprTirashi.RowCount, 1);
            //        //行数を加算.
            //        _inttirashiRow++;
            //        sprTirashi.Cells[_inttirashiRow, 5].Value = "代理店計";
            //        sprTirashi.Cells[_inttirashiRow, 6].Value = _dairiSeiSyoukeitirashi.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprTirashi.Rows.Add(sprTirashi.RowCount, 1);
            //        //行数を加算.
            //        _inttirashiRow++;
            //        sprTirashi.Cells[_inttirashiRow, 5].Value = "消費税計";
            //        //sprTirashi.Cells[_inttirashiRow, 6].Value = _SyouhizeiGoukeitirashi.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprTirashi.Cells[_inttirashiRow, 6].Value = Math.Floor(_dairiSeiSyoukeitirashi * _dblShohizei);
            //        //sprTirashi.Cells[_inttirashiRow, 6].Value = Math.Floor(_SyouhizeiGoukeitirashi);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprTirashi.Cells[_inttirashiRow, 6].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprTirashi.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }
            //        //ブランド名称.
            //        sprTirashi.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //請求額.
            //        sprTirashi.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprTirashi.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion チラシ.

            //#region モバイル.

            ////モバイルの場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_MOBILE))
            //{
            //    //シートを表示する.
            //    sprMobile.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strmobileBrandCd = string.Empty;                      //ブランドコード.
            //        int _intmobileRow = 0;                                       //行数.
            //        double _brandSeiSyoukeimobile = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeimobile = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeimobile = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprMobile.Rows.Add(sprMobile.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strmobileBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strmobileBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprMobile.Cells[_intmobileRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprMobile.Cells[_intmobileRow, 8].Value = _brandSeiSyoukeimobile.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeimobile = 0;

            //                _strmobileBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprMobile.Rows.Add(sprMobile.RowCount, 1);

            //                //行数を加算.
            //                _intmobileRow++;
            //            }

            //            //カードNo.
            //            sprMobile.Cells[_intmobileRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprMobile.Cells[_intmobileRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprMobile.Cells[_intmobileRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprMobile.Cells[_intmobileRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprMobile.Cells[_intmobileRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprMobile.Cells[_intmobileRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //局誌コード.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString()))
            //            {
            //                sprMobile.Cells[_intmobileRow, 6].Value = "";
            //            }
            //            else
            //            {
            //                sprMobile.Cells[_intmobileRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString();
            //            }

            //            //局誌名称.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString()))
            //            {
            //                sprMobile.Cells[_intmobileRow, 7].Value = "";
            //            }
            //            else
            //            {
            //                sprMobile.Cells[_intmobileRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString();
            //            }

            //            //作成料.
            //            double mobileSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprMobile.Cells[_intmobileRow, 8].Value = mobileSei.ToString("#,0");

            //            //件名.
            //            sprMobile.Cells[_intmobileRow, 9].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeimobile = _brandSeiSyoukeimobile + mobileSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeimobile = _dairiSeiSyoukeimobile + mobileSei;
            //            //消費税合計.
            //            double mobileSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeimobile = _SyouhizeiGoukeimobile + mobileSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + mobileSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (mobileSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intmobileRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprMobile.Rows.Add(sprMobile.RowCount, 1);
            //        sprMobile.Cells[_intmobileRow, 5].Value = "ブランド計";
            //        sprMobile.Cells[_intmobileRow, 8].Value = _brandSeiSyoukeimobile.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprMobile.Rows.Add(sprMobile.RowCount, 1);
            //        //行数を加算.
            //        _intmobileRow++;
            //        sprMobile.Cells[_intmobileRow, 5].Value = "代理店計";
            //        sprMobile.Cells[_intmobileRow, 8].Value = _dairiSeiSyoukeimobile.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprMobile.Rows.Add(sprMobile.RowCount, 1);
            //        //行数を加算.
            //        _intmobileRow++;
            //        sprMobile.Cells[_intmobileRow, 5].Value = "消費税計";
            //        //sprMobile.Cells[_intmobileRow, 8].Value = _SyouhizeiGoukeimobile.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprMobile.Cells[_intmobileRow, 8].Value = Math.Floor(_dairiSeiSyoukeimobile * _dblShohizei);
            //        //sprMobile.Cells[_intmobileRow, 8].Value = Math.Floor(_SyouhizeiGoukeimobile);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprMobile.Cells[_intmobileRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprMobile.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }
            //        //ブランド名称.
            //        sprMobile.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //局誌コード.
            //        sprMobile.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //局誌名称.
            //        sprMobile.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //作成料.
            //        sprMobile.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprMobile.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion モバイル.

            //#region サンプリング.

            ////サンプリングの場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_SAMPLING))
            //{
            //    //シートを表示する.
            //    sprSample.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strsampleBrandCd = string.Empty;                      //ブランドコード.
            //        int _intsampleRow = 0;                                       //行数.
            //        double _brandSeiSyoukeisample = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeisample = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeisample = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprSample.Rows.Add(sprSample.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strsampleBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }
            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strsampleBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprSample.Cells[_intsampleRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprSample.Cells[_intsampleRow, 6].Value = _brandSeiSyoukeisample.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeisample = 0;

            //                _strsampleBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprSample.Rows.Add(sprSample.RowCount, 1);

            //                //行数を加算.
            //                _intsampleRow++;
            //            }

            //            //カードNo.
            //            sprSample.Cells[_intsampleRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprSample.Cells[_intsampleRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprSample.Cells[_intsampleRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprSample.Cells[_intsampleRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprSample.Cells[_intsampleRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprSample.Cells[_intsampleRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //請求額.
            //            double sampleSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprSample.Cells[_intsampleRow, 6].Value = sampleSei.ToString("#,0");

            //            //件名.
            //            sprSample.Cells[_intsampleRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeisample = _brandSeiSyoukeisample + sampleSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeisample = _dairiSeiSyoukeisample + sampleSei;
            //            //消費税合計.
            //            double sampleSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeisample = _SyouhizeiGoukeisample + sampleSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + sampleSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (sampleSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intsampleRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSample.Rows.Add(sprSample.RowCount, 1);
            //        sprSample.Cells[_intsampleRow, 5].Value = "ブランド計";
            //        sprSample.Cells[_intsampleRow, 6].Value = _brandSeiSyoukeisample.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSample.Rows.Add(sprSample.RowCount, 1);
            //        //行数を加算.
            //        _intsampleRow++;
            //        sprSample.Cells[_intsampleRow, 5].Value = "代理店計";
            //        sprSample.Cells[_intsampleRow, 6].Value = _dairiSeiSyoukeisample.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSample.Rows.Add(sprSample.RowCount, 1);
            //        //行数を加算.
            //        _intsampleRow++;
            //        sprSample.Cells[_intsampleRow, 5].Value = "消費税計";
            //        //sprSample.Cells[_intsampleRow, 6].Value = _SyouhizeiGoukeisample.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprSample.Cells[_intsampleRow, 6].Value = Math.Floor(_dairiSeiSyoukeisample * _dblShohizei);
            //        //sprSample.Cells[_intsampleRow, 6].Value = Math.Floor(_SyouhizeiGoukeisample);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprSample.Cells[_intsampleRow, 6].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprSample.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprSample.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //請求額.
            //        sprSample.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprSample.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion サンプリング.

            //#region インターネット.

            ////インターネットの場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_INTERNET))
            //{
            //    //シートを表示する.
            //    sprInternet.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strinternetBrandCd = string.Empty;                      //ブランドコード.
            //        int _intRow = 0;                                       //行数.
            //        double _brandSeiSyoukeiinternet = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeiinternet = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeiinternet = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprInternet.Rows.Add(sprInternet.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strinternetBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strinternetBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprInternet.Cells[_intRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprInternet.Cells[_intRow, 8].Value = _brandSeiSyoukeiinternet.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeiinternet = 0;

            //                _strinternetBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprInternet.Rows.Add(sprInternet.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprInternet.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprInternet.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprInternet.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprInternet.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprInternet.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprInternet.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //局誌コード.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString()))
            //            {
            //                sprInternet.Cells[_intRow, 6].Value = "";
            //            }
            //            else
            //            {
            //                sprInternet.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString();
            //            }

            //            //局誌名称.
            //            if (string.IsNullOrEmpty(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString()))
            //            {
            //                sprInternet.Cells[_intRow, 7].Value = "";
            //            }
            //            else
            //            {
            //                sprInternet.Cells[_intRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString();
            //            }

            //            //作成料.
            //            double internetSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprInternet.Cells[_intRow, 8].Value = internetSei.ToString("#,0");

            //            //件名.
            //            sprInternet.Cells[_intRow, 9].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeiinternet = _brandSeiSyoukeiinternet + internetSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeiinternet = _dairiSeiSyoukeiinternet + internetSei;
            //            //消費税合計.
            //            double internetSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeiinternet = _SyouhizeiGoukeiinternet + internetSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + internetSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (internetSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprInternet.Rows.Add(sprInternet.RowCount, 1);
            //        sprInternet.Cells[_intRow, 5].Value = "ブランド計";
            //        sprInternet.Cells[_intRow, 8].Value = _brandSeiSyoukeiinternet.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprInternet.Rows.Add(sprInternet.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprInternet.Cells[_intRow, 5].Value = "代理店計";
            //        sprInternet.Cells[_intRow, 8].Value = _dairiSeiSyoukeiinternet.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprInternet.Rows.Add(sprInternet.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprInternet.Cells[_intRow, 5].Value = "消費税計";
            //        //sprInternet.Cells[_intRow, 8].Value = _SyouhizeiGoukeiinternet.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprInternet.Cells[_intRow, 8].Value = Math.Floor(_dairiSeiSyoukeiinternet * _dblShohizei);
            //        //sprInternet.Cells[_intRow, 8].Value = Math.Floor(_SyouhizeiGoukeiinternet);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }
            //        sprInternet.Cells[_intRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprInternet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }
            //        //ブランド名称.
            //        sprInternet.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //局誌コード.
            //        sprInternet.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //局誌名称.
            //        sprInternet.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //作成料.
            //        sprInternet.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprInternet.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.

            //    }
            //}

            //#endregion インターネット.

            //#region BS・CS

            ////BS・CSの場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_BS_CS))
            //{
            //    //シートを表示する.
            //    sprBscs.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        string _strbscsCardNo = string.Empty;                      //カードNo.
            //        string _strbscsProgramCd = string.Empty;                    //プログラムコード.

            //        int _intRow = 0;                                       //行数.
            //        double _cardSeiSyoukeibscs = 0;                           //カード計.
            //        double _dairiSeiSyoukeibscs = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeibscs = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprBscs.Rows.Add(sprBscs.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strbscsCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Code6"].ToString();
            //                _strbscsProgramCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString();
            //            }

            //            //カードNoまたは、プログラムコードが変化した場合計を挿入する.
            //            if (!_strbscsCardNo.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Code6"].ToString()) || !_strbscsProgramCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprBscs.Cells[_intRow, 6].Value = "カード計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //カード請求料計.
            //                sprBscs.Cells[_intRow, 7].Value = _cardSeiSyoukeibscs.ToString("#,0");
            //                sprBscs.Cells[_intRow, 8].Value = _cardSeiSyoukeibscs.ToString("#,0");

            //                //各小計を初期化.
            //                _cardSeiSyoukeibscs = 0;

            //                _strbscsCardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                _strbscsProgramCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprBscs.Rows.Add(sprBscs.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprBscs.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprBscs.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprBscs.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprBscs.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //番組コード.
            //            sprBscs.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString();

            //            //局誌コード.
            //            sprBscs.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

            //            //局誌名称.
            //            sprBscs.Cells[_intRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

            //            //電波料.
            //            double BsCsSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprBscs.Cells[_intRow, 7].Value = BsCsSei.ToString("#,0");

            //            //請求額合計.
            //            sprBscs.Cells[_intRow, 8].Value = BsCsSei.ToString("#,0");

            //            //放送回数.
            //            sprBscs.Cells[_intRow, 9].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["Honsu"].ToString();

            //            //番組名.
            //            sprBscs.Cells[_intRow, 10].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramName"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _cardSeiSyoukeibscs = _cardSeiSyoukeibscs + BsCsSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeibscs = _dairiSeiSyoukeibscs + BsCsSei;
            //            //消費税合計.
            //            double BscsSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            //double BscsSyouhi = double.Parse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeibscs = _SyouhizeiGoukeibscs + BscsSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + BsCsSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (BsCsSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intRow++;
            //        }

            //        //************************************.
            //        //カード計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprBscs.Rows.Add(sprBscs.RowCount, 1);
            //        sprBscs.Cells[_intRow, 6].Value = "カード計";
            //        sprBscs.Cells[_intRow, 7].Value = _cardSeiSyoukeibscs.ToString("#,0");
            //        sprBscs.Cells[_intRow, 8].Value = _cardSeiSyoukeibscs.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprBscs.Rows.Add(sprBscs.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprBscs.Cells[_intRow, 6].Value = "代理店計";
            //        sprBscs.Cells[_intRow, 7].Value = _dairiSeiSyoukeibscs.ToString("#,0");
            //        sprBscs.Cells[_intRow, 8].Value = _dairiSeiSyoukeibscs.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprBscs.Rows.Add(sprBscs.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprBscs.Cells[_intRow, 6].Value = "消費税計";
            //        //sprBscs.Cells[_intRow, 8].Value = _SyouhizeiGoukeibscs.ToString("#,0");
            //        //請求額合計 * 消費税率.

            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprBscs.Cells[_intRow, 8].Value = Math.Floor(_dairiSeiSyoukeibscs * _dblShohizei);
            //        //sprBscs.Cells[_intRow, 8].Value = Math.Floor(_SyouhizeiGoukeibscs);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {

            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);

            //        }
            //        sprBscs.Cells[_intRow, 8].Value = Math.Floor(ckgoukei);
            //        //end

            //        for (int i = 0; i < 6; i++)
            //        {
            //            sprBscs.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //局誌名称.
            //        sprBscs.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //電波料.
            //        sprBscs.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //請求額合計.
            //        sprBscs.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //放送回数.
            //        sprBscs.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //番組名.
            //        sprBscs.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion BS・CS

            //#region その他.

            ////その他の場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_SONOTA))
            //{
            //    //シートを表示する.
            //    sprSonota.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        int _intRow = 0;                                       //行数.
            //        string _strsonotaBrandCd = string.Empty;                      //ブランドコード.
            //        double _brandSeiSyoukeisonota = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeisonota = 0;                           //代理店請求額小計.
            //        double _SyouhizeiGoukeisonota = 0;                           //消費税合計.

            //        #region シートにセット.

            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprSonota.Rows.Add(sprSonota.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strsonotaBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //            }

            //            //ブランドコードが変化した場合計を挿入する.
            //            if (!_strsonotaBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //ブランド計行を作成.
            //                sprSonota.Cells[_intRow, 5].Value = "ブランド計";

            //                //***********************
            //                //各小計をセット.
            //                //***********************
            //                //ブランド請求料計.
            //                sprSonota.Cells[_intRow, 6].Value = _brandSeiSyoukeisonota.ToString("#,0");

            //                //各小計を初期化.
            //                _brandSeiSyoukeisonota = 0;

            //                _strsonotaBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprSonota.Rows.Add(sprSonota.RowCount, 1);

            //                //行数を加算.
            //                _intRow++;
            //            }

            //            //カードNo.
            //            sprSonota.Cells[_intRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprSonota.Cells[_intRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprSonota.Cells[_intRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprSonota.Cells[_intRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //ブランドコード.
            //            sprSonota.Cells[_intRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprSonota.Cells[_intRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //請求額.
            //            double sonotaSei = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //            sprSonota.Cells[_intRow, 6].Value = sonotaSei.ToString("#,0");

            //            //件名.
            //            sprSonota.Cells[_intRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeisonota = _brandSeiSyoukeisonota + sonotaSei;
            //            //代理店請求額.
            //            _dairiSeiSyoukeisonota = _dairiSeiSyoukeisonota + sonotaSei;
            //            //消費税合計.
            //            double sonotaSyouhi = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
            //            _SyouhizeiGoukeisonota = _SyouhizeiGoukeisonota + sonotaSyouhi;

            //            //2014/01/28 hlc sonobe
            //            //消費税リストを作成する.
            //            Boolean blnRate = false;
            //            if (RateGoukei != null)
            //            {
            //                for (int x = 0; x < RateGoukei.Count; x++)
            //                {
            //                    // 対象データテーブル行.
            //                    double ckrate = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                    if (RateGoukei[x].taxRateList == ckrate)
            //                    {
            //                        RateGoukei[x].goukeiList = RateGoukei[x].goukeiList + sonotaSei;
            //                        blnRate = true;
            //                    }
            //                }
            //            }

            //            if (blnRate != true)
            //            {
            //                // 初回データ設定.
            //                GoukeiData data = new GoukeiData();
            //                data.taxRateList = (double)KKHUtility.DecParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiRitu"].ToString());
            //                data.goukeiList = (sonotaSei);
            //                RateGoukei.Add(data);
            //            }
            //            //2014/01/28 hlc sonobe end

            //            _intRow++;
            //        }

            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        sprSonota.Cells[_intRow, 5].Value = "ブランド計";
            //        sprSonota.Cells[_intRow, 6].Value = _brandSeiSyoukeisonota.ToString("#,0");

            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprSonota.Cells[_intRow, 5].Value = "代理店計";
            //        sprSonota.Cells[_intRow, 6].Value = _dairiSeiSyoukeisonota.ToString("#,0");

            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        //行数を加算.
            //        _intRow++;
            //        sprSonota.Cells[_intRow, 5].Value = "消費税計";
            //        //sprSonota.Cells[_intRow, 6].Value = _SyouhizeiGoukeisonota.ToString("#,0");
            //        //請求額合計 * 消費税率.
            //        //消費税対応 2013/12/05 HLC H.Watabe update start
            //        //sprSonota.Cells[_intRow, 6].Value = Math.Floor(_dairiSeiSyoukeisonota * _dblShohizei);
            //        //sprSonota.Cells[_intRow, 6].Value = Math.Floor(_SyouhizeiGoukeisonota);
            //        //消費税対応 2013/12/05 HLC H.Watabe update start

            //        //2014/01/28 hlc sonobe add
            //        double ckgoukei = 0;
            //        for (int y = 0; y < RateGoukei.Count; y++)
            //        {
            //            // 対象データテーブル行.
            //            ckgoukei = ckgoukei + Math.Floor(RateGoukei[y].goukeiList * RateGoukei[y].taxRateList);
            //        }

            //        sprSonota.Cells[_intRow, 6].Value = Math.Floor(ckgoukei);
            //        //end

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        for (int i = 0; i < 5; i++)
            //        {
            //            sprSonota.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }

            //        //ブランド名称.
            //        sprSonota.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //請求額.
            //        sprSonota.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //件名.
            //        sprSonota.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        ////取得結果データをDataSetにセット.
            //        //_dsLion = result.dsRepLionDataSet;

            //        ////Excelボタン押下可能.
            //        //btnXls.Enabled = true;

            //        ////件数をセット.
            //        //statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        ////垂直スクロールバーを表示する.
            //        //sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }

            //    {
            //        //****************************
            //        //全媒体消費税算出.
            //        //****************************
            //        double SyouhizeiGak = 0;        //消費税額1
            //        double SyouhizeiGak2 = 0;       //消費税額2
            //        double SyouhizeiGak3 = 0;       //消費税額3

            //        //消費税対応 2014/1/28 add HLC sonobe start
            //        Decimal befTaxRate;
            //        List<decimal> taxRateList = new List<decimal>();
            //        List<decimal> initList = new List<decimal>();
            //        List<List<decimal>> tvTaxRateList = new List<List<decimal>>();
            //        List<List<decimal>> rdTaxRateList = new List<List<decimal>>();
            //        List<List<decimal>> etcTaxRateList = new List<List<decimal>>();
            //        decimal tvTaxRate = 0;
            //        decimal rdTaxRate = 0;
            //        decimal etcTaxRate = 0;

            //        RepDsLion.RepLionSyohiZeiRow[] sortTaxRows = (RepDsLion.RepLionSyohiZeiRow[])result.dsRepLionDataSet.RepLionSyohiZei.Select("", "ShohizeiRitu");
            //        if (sortTaxRows.Length != 0)
            //        {
            //            taxRateList.Add(KKHUtility.DecParse(sortTaxRows[0].ShohizeiRitu));
            //            initList.Add(0);
            //            befTaxRate = KKHUtility.DecParse(sortTaxRows[0].ShohizeiRitu);
            //            //消費税リストを作成する.
            //            foreach (RepDsLion.RepLionSyohiZeiRow sortTaxRow in sortTaxRows)
            //            {
            //                if (befTaxRate != KKHUtility.DecParse(sortTaxRow.ShohizeiRitu))
            //                {
            //                    taxRateList.Add(KKHUtility.DecParse(sortTaxRow.ShohizeiRitu));
            //                }

            //                befTaxRate = KKHUtility.DecParse(sortTaxRow.ShohizeiRitu);
            //            }

            //            tvTaxRateList.Add(taxRateList);
            //            tvTaxRateList.Add(new List<decimal>());
            //            rdTaxRateList.Add(taxRateList);
            //            rdTaxRateList.Add(new List<decimal>());
            //            etcTaxRateList.Add(taxRateList);
            //            etcTaxRateList.Add(new List<decimal>());
            //            foreach (decimal taxrate in taxRateList)
            //            {
            //                tvTaxRateList[1].Add(0);
            //                rdTaxRateList[1].Add(0);
            //                etcTaxRateList[1].Add(0);
            //            }
            //        }
            //        //消費税対応 2014/1/28 add HLC sonobe end

            //        foreach (RepDsLion.RepLionSyohiZeiRow row in result.dsRepLionDataSet.RepLionSyohiZei.Select("", ""))
            //        {
            //            switch (row.code6.Trim())
            //            {
            //                //テレビ.
            //                case "001":
            //                case "002":
            //                    if (row.code6.Trim().Equals("001"))
            //                    {
            //                        //消費税対応 2014/01/28 Up HLC sonobe start
            //                        //SyouhizeiGak = KKHUtility.DouParse(row.shohizeiGak);

            //                        int index = 0;
            //                        foreach (decimal taxRate in tvTaxRateList[0])
            //                        {
            //                            if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
            //                            {
            //                                tvTaxRateList[1][index] = tvTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
            //                                break;
            //                            }
            //                            index++;
            //                        }


            //                        SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);
            //                        //消費税対応 2014/01/28 Up HLC sonobe end
            //                    }
            //                    else
            //                    {
            //                        //ｶｰﾄﾞNo 001と002の合計で消費税計算.

            //                        //消費税対応 2014/01/28 UpHLC sonobe start
            //                        //SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);

            //                        int index = 0;
            //                        foreach (decimal taxRate in tvTaxRateList[0])
            //                        {
            //                            if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
            //                            {
            //                                tvTaxRateList[1][index] = tvTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
            //                                break;
            //                            }
            //                            index++;
            //                        }

            //                        SyouhizeiGak = SyouhizeiGak + KKHUtility.DouParse(row.shohizeiGak);
            //                        //消費税対応 2014/01/28 Up HLC sonobe end
            //                    }
            //                    break;

            //                //ラジオ.
            //                case "003":
            //                case "004":
            //                    if (row.code6.Trim().Equals("003"))
            //                    {
            //                        //消費税対応 2014/01/28 Up HLC sonobe start
            //                        //SyouhizeiGak2 = KKHUtility.DouParse(row.shohizeiGak);

            //                        int index = 0;
            //                        foreach (decimal taxRate in rdTaxRateList[0])
            //                        {
            //                            if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
            //                            {
            //                                rdTaxRateList[1][index] = rdTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
            //                                break;
            //                            }
            //                            index++;
            //                        }

            //                        SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);
            //                        //消費税対応 2014/01/28 Up HLC sonobe end
            //                    }
            //                    else
            //                    {
            //                        //ｶｰﾄﾞNo 003と004の合計で消費税計算.

            //                        //消費税対応 2014/01/28 Up HLC sonobe start
            //                        //SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);

            //                        int index = 0;
            //                        foreach (decimal taxRate in rdTaxRateList[0])
            //                        {
            //                            if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
            //                            {
            //                                rdTaxRateList[1][index] = rdTaxRateList[1][index] + KKHUtility.DecParse(row.shohizeiGak);
            //                                break;
            //                            }
            //                            index++;
            //                        }

            //                        SyouhizeiGak2 = SyouhizeiGak2 + KKHUtility.DouParse(row.shohizeiGak);
            //                        //消費税対応 2014/01/28 Up HLC sonobe end
            //                    }
            //                    break;

            //                default:

            //                    //SyouhizeiGak3 = SyouhizeiGak3 + Math.Truncate(KKHUtility.DouParse(row.shohizeiGak));
            //                    //消費税対応 2014/01/28 Up HLC sonobe start
            //                    //請求額 * 消費税率.
            //                    //SyouhizeiGak3 = SyouhizeiGak3 + Math.Floor(KKHUtility.DouParse(row.shohizeiGak) * _dblShohizei);

            //                    int index1 = 0;
            //                    foreach (decimal taxRate in etcTaxRateList[0])
            //                    {
            //                        if (taxRate == KKHUtility.DecParse(row.ShohizeiRitu))
            //                        {
            //                            etcTaxRateList[1][index1] = etcTaxRateList[1][index1] + Math.Truncate(KKHUtility.DecParse(row.shohizeiGak) * taxRate);
            //                            break;
            //                        }
            //                        index1++;
            //                    }
            //                    //Csyouhigak_3 = Csyouhigak_3 + Math.Truncate(KKHUtility.DecParse(resultRow.seikyuu) * _taxRate);

            //                    SyouhizeiGak3 = SyouhizeiGak3 + Math.Floor(KKHUtility.DouParse(row.shohizeiGak));
            //                    //消費税対応 2014/01/28 Up HLC sonobe end

            //                    break;
            //            }

            //        }

            //        //SyouhizeiGak = Math.Truncate(SyouhizeiGak);
            //        //SyouhizeiGak2 = Math.Truncate(SyouhizeiGak2);
            //        //請求額 * 消費税率.
            //        //消費税対応 2014/01/28 Up HLC sonobe start
            //        //SyouhizeiGak = Math.Floor(SyouhizeiGak * _dblShohizei);
            //        //SyouhizeiGak2 = Math.Floor(SyouhizeiGak2 * _dblShohizei);
            //        ////消費税合計.
            //        //double SyouhizeiGakSum = SyouhizeiGak + SyouhizeiGak2 + SyouhizeiGak3;

            //        for (int index = 0; index < taxRateList.Count; index++)
            //        {
            //            tvTaxRate = tvTaxRate + Math.Truncate((tvTaxRateList[1][index] * tvTaxRateList[0][index]));
            //            rdTaxRate = rdTaxRate + Math.Truncate((rdTaxRateList[1][index] * rdTaxRateList[0][index]));
            //            etcTaxRate = etcTaxRate + Math.Truncate(etcTaxRateList[1][index]);
            //        }

            //        //消費税合計.
            //        Decimal SyouhizeiGakSum = tvTaxRate + rdTaxRate + etcTaxRate;
            //        //消費税対応 2014/01/28 Up HLC sonobe end

            //        int _intRow = sprSonota.RowCount - 1;

            //        //シートにセット.
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        _intRow++;

            //        //カードNo
            //        sprSonota.Cells[_intRow, 0].Value = "010";
            //        //データ年月.
            //        sprSonota.Cells[_intRow, 1].Value = yyyyMm;
            //        //代理店.
            //        sprSonota.Cells[_intRow, 2].Value = "1001";
            //        //媒体区分.
            //        sprSonota.Cells[_intRow, 3].Value = "50";
            //        //ブランドコード.
            //        sprSonota.Cells[_intRow, 4].Value = "9000";

            //        MastLion.BrandLionRow[] brandName = (MastLion.BrandLionRow[])MastLionDs.BrandLion.Select("Column1 = '" + "9000" + "'", "");

            //        if ((brandName.Length != 0) && (!brandName[0].IsColumn2Null()))
            //        {
            //            sprSonota.Cells[_intRow, 5].Value = brandName[0].Column2;
            //        }
            //        else
            //        {
            //            sprSonota.Cells[_intRow, 5].Value = "";
            //        }

            //        //請求額.
            //        sprSonota.Cells[_intRow, 6].Value = SyouhizeiGakSum.ToString("#,0");
            //        //件名.
            //        sprSonota.Cells[_intRow, 7].Value = "";

            //        //その他の情報をデータセットに追加.
            //        DataRow dtRow;
            //        dtRow = result.dsRepLionDataSet.RepLion.NewRow();
            //        dtRow["code6"] = sprSonota.Cells[_intRow, 0].Value;
            //        dtRow["yymm"] = sprSonota.Cells[_intRow, 1].Value;
            //        dtRow["code4"] = sprSonota.Cells[_intRow, 2].Value;
            //        dtRow["code1"] = sprSonota.Cells[_intRow, 3].Value;
            //        dtRow["brandCd"] = sprSonota.Cells[_intRow, 4].Value;
            //        dtRow["brandMei"] = sprSonota.Cells[_intRow, 5].Value;
            //        dtRow["SeiGak"] = "0";
            //        dtRow["KenMei"] = "";
            //        dtRow["name1"] = "0";
            //        result.dsRepLionDataSet.RepLion.Rows.Add(dtRow);

            //        //****************************
            //        //ブランド計.
            //        //****************************
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        _intRow++;
            //        sprSonota.Cells[_intRow, 5].Value = "ブランド計";
            //        sprSonota.Cells[_intRow, 6].Value = SyouhizeiGakSum.ToString("#,0");

            //        //****************************
            //        //代理店計 
            //        //****************************
            //        //スプレッドシートに行を追加.
            //        sprSonota.Rows.Add(sprSonota.RowCount, 1);
            //        _intRow++;
            //        sprSonota.Cells[_intRow, 5].Value = "代理店計";
            //        sprSonota.Cells[_intRow, 6].Value = SyouhizeiGakSum.ToString("#,0");
            //    }

            //    //取得結果データをDataSetにセット.
            //    _dsLion = result.dsRepLionDataSet;

            //    //Excelボタン押下可能.
            //    btnXls.Enabled = true;

            //    //件数をセット.
            //    statusStrip1.Items["tslval1"].Text = (result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count).ToString() + "件";

            //    //垂直スクロールバーを表示する.
            //    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            //}

            //#endregion その他.

            //#region 制作.

            ////制作の場合.
            //if (_mStrBaitaiMei.Equals(C_BAITAI_SEISAKU))
            //{
            //    //シートを表示する.
            //    sprSeisaku.Visible = true;
            //    if (0 < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count)
            //    {
            //        //垂直スクロールバーを作業中は非表示にする.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            //        int _intseisakuRow = 0;                                       //行数.
            //        string _strseisakuBrandCd = string.Empty;                     //ブランドコード.
            //        string JanleName = string.Empty;                              //ジャンル名.
            //        string JanleCd = string.Empty;                                //ジャンルコード.
            //        string Yymm = yyyyMm;                                        //データ年月.
            //        string CardNo = string.Empty;                                 //カードNo.
            //        string AgentCd = string.Empty;                                //代理店コード.
            //        string BrandName = string.Empty;                              //代理店名.
            //        double SeisakuSyohizeiGak = 0;                                //制作消費税.
            //        double SeisakuSyohizeiGak_Talent = 0;                         //制作消費税(タレント用)
            //        double _brandSeiSyoukeiseisaku = 0;                           //ブランド請求額.
            //        double _dairiSeiSyoukeiseisaku = 0;                           //代理店請求額小計.
            //        double SumSyouhiZeiGak = 0;                                   //消費税合計.
            //        double _JanleSeiSyoukeiseisaku = 0;                           //ジャンル請求額.

            //        #region シートにセット.
            //        for (int i = 0; i < result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
            //        {
            //            //********************************.
            //            //スプレッドシートに行を追加.
            //            //********************************.
            //            sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

            //            //1回目の場合.
            //            if (i == 0)
            //            {
            //                _strseisakuBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //                JanleName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleName"].ToString();
            //                JanleCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleCd"].ToString();
            //                CardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                AgentCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();
            //                BrandName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();
            //            }

            //            //ブランドコードのブレイク.
            //            if (!_strseisakuBrandCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
            //            {
            //                //制作消費税を入力.
            //                if (SeisakuSyohizeiGak != 0)
            //                {
            //                    //ジャンル名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
            //                    //カードNo.
            //                    sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
            //                    //データ年月 .
            //                    sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
            //                    //代理店コード .
            //                    sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
            //                    //媒体区分.
            //                    sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
            //                    //媒体名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(1)";
            //                    //ブランドコード.
            //                    sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
            //                    //ブランド名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
            //                    //消費税.
            //                    //2013/07/01 hlc sonobe 件名追加 Update Start
            //                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
            //                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
            //                    //2013/07/01 hlc sonobe 件名追加 Update End
            //                    //消費税合計を加算.
            //                    SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;
            //                    //スプレッドシートに行を追加.
            //                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

            //                    _intseisakuRow++;
            //                }
            //                //制作消費税(タレント用)を入力.
            //                if (SeisakuSyohizeiGak_Talent != 0)
            //                {
            //                    //ジャンル名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
            //                    //カードNo
            //                    sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
            //                    //データ年月.
            //                    sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
            //                    //代理店コード.
            //                    sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
            //                    //媒体区分.
            //                    sprSeisaku.Cells[_intseisakuRow, 4].Value = "41";
            //                    //媒体名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(2)";
            //                    //ブランドコード.
            //                    sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
            //                    //ブランド名称.
            //                    sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
            //                    //消費税.
            //                    //2013/07/01 hlc sonobe 件名追加 Update Start
            //                    //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //                    sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //                    //2013/07/01 hlc sonobe 件名追加 Update End
            //                    //消費税合計を加算.
            //                    SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;
            //                    //スプレッドシートに行を追加.
            //                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

            //                    _intseisakuRow++;
            //                }

            //                //2013/07/01 hlc sonobe 件名追加 Update Start
            //                ////ブランド名称.
            //                //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ブランド計";
            //                ////請求額.
            //                //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_brandSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent).ToString("#,0");
            //                //ブランド名称.
            //                sprSeisaku.Cells[_intseisakuRow, 8].Value = "ブランド計";
            //                //請求額.
            //                sprSeisaku.Cells[_intseisakuRow, 9].Value = (_brandSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent).ToString("#,0");
            //                //2013/07/01 hlc sonobe 件名追加 Update End

            //                _JanleSeiSyoukeiseisaku = _JanleSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;
            //                _dairiSeiSyoukeiseisaku = _dairiSeiSyoukeiseisaku + SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;

            //                //初期化.
            //                SeisakuSyohizeiGak = 0;
            //                SeisakuSyohizeiGak_Talent = 0;
            //                _brandSeiSyoukeiseisaku = 0;

            //                //データ格納.
            //                _strseisakuBrandCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
            //                JanleName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleName"].ToString();
            //                CardNo = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
            //                AgentCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();
            //                BrandName = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //                _intseisakuRow++;
            //            }

            //            //ジャンルコードのブレイク.
            //            if (!JanleCd.Equals(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleCd"].ToString()))
            //            {
            //                //2013/07/01 hlc sonobe 件名追加 Update Start
            //                ////ジャンル名称.
            //                //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ジャンル計";
            //                ////請求額.
            //                //sprSeisaku.Cells[_intseisakuRow, 8].Value = _JanleSeiSyoukeiseisaku.ToString("#,0");
            //                //ジャンル名称.
            //                sprSeisaku.Cells[_intseisakuRow, 8].Value = "ジャンル計";
            //                //請求額.
            //                sprSeisaku.Cells[_intseisakuRow, 9].Value = _JanleSeiSyoukeiseisaku.ToString("#,0");
            //                //2013/07/01 hlc sonobe 件名追加 Update End

            //                _JanleSeiSyoukeiseisaku = 0;

            //                JanleCd = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleCd"].ToString();

            //                //スプレッドシートに行を追加.
            //                sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //                _intseisakuRow++;
            //            }

            //            //ジャンル名.
            //            sprSeisaku.Cells[_intseisakuRow, 0].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleName"].ToString();

            //            //カードNo
            //            sprSeisaku.Cells[_intseisakuRow, 1].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

            //            //データ年月.
            //            sprSeisaku.Cells[_intseisakuRow, 2].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

            //            //代理店コード.
            //            sprSeisaku.Cells[_intseisakuRow, 3].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

            //            //媒体区分.
            //            sprSeisaku.Cells[_intseisakuRow, 4].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

            //            //媒体名称.
            //            sprSeisaku.Cells[_intseisakuRow, 5].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["BaitaiName"].ToString();

            //            //ブランドコード.
            //            sprSeisaku.Cells[_intseisakuRow, 6].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

            //            //ブランド名称.
            //            sprSeisaku.Cells[_intseisakuRow, 7].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

            //            //2013/07/01 hlc sonobe 件名追加 Start
            //            //件名.
            //            sprSeisaku.Cells[_intseisakuRow, 8].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kenmei"].ToString();
            //            //2013/07/01 hlc sonobe 件名追加 End

            //            //請求額・媒体消費税額を分ける.
            //            double SeikyuGak = 0;
            //            if (result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString().Trim().Equals("012"))
            //            {
            //                switch (result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString().Trim())
            //                {
            //                    case "20":
            //                    case "21":
            //                    case "23":
            //                    case "24":
            //                    case "25":
            //                    case "27":
            //                    case "29":
            //                    case "33":
            //                    case "35":
            //                    case "36":
            //                    case "37":
            //                    case "38":
            //                    case "39":
            //                        //消費税が0またはempty以外の場合.
            //                        if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
            //                        {
            //                            SeisakuSyohizeiGak = SeisakuSyohizeiGak + Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()));
            //                        }
            //                        SeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //                        //2013/07/01 hlc sonobe 件名追加 Update Start
            //                        //sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
            //                        sprSeisaku.Cells[_intseisakuRow, 9].Value = SeikyuGak;
            //                        //2013/07/01 hlc sonobe 件名追加 Update End
            //                        break;
            //                    case "31":
            //                        //消費税が0またはempty以外の場合.
            //                        if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
            //                        {
            //                            SeisakuSyohizeiGak_Talent = SeisakuSyohizeiGak_Talent + Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()));
            //                        }
            //                        SeikyuGak = KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
            //                        //2013/07/01 hlc sonobe 件名追加 Update Start
            //                        //sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
            //                        sprSeisaku.Cells[_intseisakuRow, 9].Value = SeikyuGak;
            //                        //2013/07/01 hlc sonobe 件名追加 Update End
            //                        break;
            //                }
            //            }

            //            //消費税が0またはempty以外の場合.
            //            if (!result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
            //            {
            //                ////2013/07/01 hlc sonobe 件名追加 Update Start
            //                //消費税.
            //                //sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()))).ToString("#,0");
            //                sprSeisaku.Cells[_intseisakuRow, 10].Value = (Math.Truncate(KKHUtility.DouParse(result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()))).ToString("#,0");
            //                ////2013/07/01 hlc sonobe 件名追加 Update End
            //            }

            //            ////2013/07/01 hlc sonobe 件名追加 Start
            //            ////件名.
            //            //sprSeisaku.Cells[_intseisakuRow, 10].Value = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows[i]["kenmei"].ToString();
            //            ////2013/07/01 hlc sonobe 件名追加 End

            //            //**************************.
            //            //各小計額を変数にセット.
            //            //**************************.
            //            //ブランド計請求額.
            //            _brandSeiSyoukeiseisaku = _brandSeiSyoukeiseisaku + SeikyuGak;
            //            //ジャンル計.
            //            _JanleSeiSyoukeiseisaku = _JanleSeiSyoukeiseisaku + SeikyuGak;
            //            //代理店請求額.
            //            _dairiSeiSyoukeiseisaku = _dairiSeiSyoukeiseisaku + SeikyuGak;

            //            _intseisakuRow++;
            //        }

            //        //制作消費税を入力.
            //        if (SeisakuSyohizeiGak != 0)
            //        {
            //            //スプレッドシートに行を追加.
            //            sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

            //            //ジャンル名称.
            //            sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
            //            //カードNo.
            //            sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
            //            //データ年月.
            //            sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
            //            //代理店コード.
            //            sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
            //            //媒体区分.
            //            sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
            //            //媒体名称.
            //            sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(1)";
            //            //ブランドコード.
            //            sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
            //            //ブランド名称.
            //            sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
            //            //消費税.
            //            //2013/07/01 hlc sonobe 件名追加 Update Start
            //            //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
            //            sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak)).ToString("#,0");
            //            //2013/07/01 hlc sonobe 件名追加 Update End
            //            SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;

            //            //加算.
            //            _intseisakuRow++;
            //        }

            //        //制作消費税(タレント用)を入力.
            //        if (SeisakuSyohizeiGak_Talent != 0)
            //        {
            //            //スプレッドシートに行を追加.
            //            sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

            //            //ジャンル名称.
            //            sprSeisaku.Cells[_intseisakuRow, 0].Value = JanleName;
            //            //カードNo
            //            sprSeisaku.Cells[_intseisakuRow, 1].Value = CardNo;
            //            //データ年月.
            //            sprSeisaku.Cells[_intseisakuRow, 2].Value = Yymm;
            //            //代理店コード.
            //            sprSeisaku.Cells[_intseisakuRow, 3].Value = AgentCd;
            //            //媒体区分.
            //            sprSeisaku.Cells[_intseisakuRow, 4].Value = "40";
            //            //媒体名称.
            //            sprSeisaku.Cells[_intseisakuRow, 5].Value = "制作部･制作消費税(2)";
            //            //ブランドコード.
            //            sprSeisaku.Cells[_intseisakuRow, 6].Value = _strseisakuBrandCd;
            //            //ブランド名称.
            //            sprSeisaku.Cells[_intseisakuRow, 7].Value = BrandName;
            //            //消費税.
            //            //2013/07/01 hlc sonobe 件名追加 Update Start
            //            //sprSeisaku.Cells[_intseisakuRow, 8].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //            sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //            //2013/07/01 hlc sonobe 件名追加 Update End
            //            SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;

            //            //加算.
            //            _intseisakuRow++;
            //        }

            //        //消費税合計.
            //        //SumSyouhiZeiGak = SeisakuSyohizeiGak + SeisakuSyohizeiGak_Talent;
            //        //************************************.
            //        //ブランド計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //        //2013/07/01 hlc sonobe 件名追加 Update Start
            //        //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ブランド計";
            //        //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_brandSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        sprSeisaku.Cells[_intseisakuRow, 8].Value = "ブランド計";
            //        sprSeisaku.Cells[_intseisakuRow, 9].Value = (_brandSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        //2013/07/01 hlc sonobe 件名追加 Update End
            //        //************************************.
            //        //ジャンル計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //        _intseisakuRow++;
            //        //2013/07/01 hlc sonobe 件名追加 Update Start
            //        //sprSeisaku.Cells[_intseisakuRow, 7].Value = "ジャンル計";
            //        //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_JanleSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        sprSeisaku.Cells[_intseisakuRow, 8].Value = "ジャンル計";
            //        sprSeisaku.Cells[_intseisakuRow, 9].Value = (_JanleSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + +Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        //2013/07/01 hlc sonobe 件名追加 Update End
            //        //************************************.
            //        //代理店計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //        _intseisakuRow++;
            //        //2013/07/01 hlc sonobe 件名追加 Update Start
            //        //sprSeisaku.Cells[_intseisakuRow, 7].Value = "代理店計";
            //        //sprSeisaku.Cells[_intseisakuRow, 8].Value = (_dairiSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        sprSeisaku.Cells[_intseisakuRow, 8].Value = "代理店計";
            //        sprSeisaku.Cells[_intseisakuRow, 9].Value = (_dairiSeiSyoukeiseisaku + Math.Truncate(SeisakuSyohizeiGak) + Math.Truncate(SeisakuSyohizeiGak_Talent)).ToString("#,0");
            //        //2013/07/01 hlc sonobe 件名追加 Update End
            //        //************************************.
            //        //消費税計行を作成.
            //        //************************************.
            //        //スプレッドシートに行を追加.
            //        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
            //        _intseisakuRow++;
            //        //2013/07/01 hlc sonobe 件名追加 Update Start
            //        //sprSeisaku.Cells[_intseisakuRow, 7].Value = "消費税計";
            //        //sprSeisaku.Cells[_intseisakuRow, 8].Value =  (Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");
            //        sprSeisaku.Cells[_intseisakuRow, 8].Value = "消費税計";
            //        sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");
            //        //2013/07/01 hlc sonobe 件名追加 Update End
            //        //初期化.
            //        SumSyouhiZeiGak = 0;
            //        SeisakuSyohizeiGak = 0;
            //        SeisakuSyohizeiGak_Talent = 0;

            //        //************************************.
            //        //値の位置.
            //        //************************************.
            //        sprSample.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Left;
            //        for (int i = 1; i < 5; i++)
            //        {
            //            sprSeisaku.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
            //        }
            //        //媒体名称.
            //        sprSeisaku.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //ブランドコード.
            //        sprSeisaku.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

            //        //ブランド名称.
            //        sprSeisaku.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

            //        //2013/07/01 hlc sonobe 件名追加 Update Start
            //        ////請求額.
            //        //sprSeisaku.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        ////消費税.
            //        //sprSeisaku.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;
            //        //請求額.
            //        sprSeisaku.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

            //        //消費税.
            //        sprSeisaku.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;
            //        //2013/07/01 hlc sonobe 件名追加 Update End

            //        //取得結果データをDataSetにセット.
            //        _dsLion = result.dsRepLionDataSet;

            //        //Excelボタン押下可能.
            //        btnXls.Enabled = true;

            //        //件数をセット.
            //        statusStrip1.Items["tslval1"].Text = result.dsRepLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

            //        //垂直スクロールバーを表示する.
            //        sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

            //        #endregion シートにセット.
            //    }
            //}

            //#endregion 制作.

            ////ローディング表示終了.
            //base.CloseLoadingDialog();
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto DEL end */

            #endregion ＜未使用＞.

        }

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="pFileMei">ファイル</param>
        private void ExcelOut(string pFileMei)
        {
            string _strWkFolderPath = _mStrRepTempAdrs;
            string _strMacroFile = _strWkFolderPath + REP_MACRO_FILENAME;
            string _strTemplFile = _strWkFolderPath + REP_TEMPLATE_FILENAME;

            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(_strMacroFile , Resources.Lion_Mcr);
                File.WriteAllBytes(_strTemplFile , Resources.Lion_Template);

                if (!System.IO.File.Exists(_strTemplFile))
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (!System.IO.File.Exists(_strMacroFile))
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                _dsLion.WriteXml(Path.Combine(_strWkFolderPath , REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加.
                // PRODUCTSテーブルを作成.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME" , Type.GetType("System.String"));    //ユーザー名.
                dtTable.Columns.Add("SELHDK" , Type.GetType("System.String"));      //検索年月日.
                dtTable.Columns.Add("SAVEDIR" , Type.GetType("System.String"));     //保存場所.
                dtTable.Columns.Add("SHOHIZEI" , Type.GetType("System.String"));    //消費税.
                dtTable.Columns.Add("BAITAIMEI" , Type.GetType("System.String"));   //媒体名.

                //テーブルにデータを追加.
                dtRow = dtTable.NewRow();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = dtpYyyyMmDd.Value.ToString("yyyyMMdd");
                //dtRow["SELHDK"] = udYYYY.Value.ToString() + _strMM + _mStrDD;
                dtRow["SAVEDIR"] = pFileMei;
                dtRow["SHOHIZEI"] = _dblShohizei.ToString();
                dtRow["BAITAIMEI"] = _mStrBaitaiMei;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(_strWkFolderPath , REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel" , _strWkFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _mStrMacroDel = _strWkFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力.
                //okazaki
                //KKHLogUtilityLion.WriteOperationLogToDB(_naviParam,.
                //    APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_Proof, KKHLogUtilityLion.DESC_OPERATION_LOG_Proof);
                KKHLogUtilityLion.WriteOperationLogToDB(_naviParam,
                    APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_Proof, KKHLogUtilityLion.DESC_OPERATION_LOG_PROOF + "＿" + cmbBaitai.Text);
                //okazaki

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        /// <summary>
        /// スプレッドシートの初期化.
        /// </summary>
        private void SprSyokika()
        {
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD start */
            //テレビタイム.
            sprTVTime.Visible = false;
            sprTVTime.RowCount = 0;
            //テレビスポット.
            sprTVSpot.Visible = false;
            sprTVSpot.RowCount = 0;
            //BSCS.
            sprBSCS.Visible = false;
            sprBSCS.RowCount = 0;
            //新聞.            
            sprNP.Visible = false;
            sprNP.RowCount = 0;
            //雑誌.
            sprMZ.Visible = false;
            sprMZ.RowCount = 0;
            //交通.
            sprTraffic.Visible = false;
            sprTraffic.RowCount = 0;
            //インターネット.
            sprInternet.Visible = false;
            sprInternet.RowCount = 0;
            //その他.
            sprOther.Visible = false;
            sprOther.RowCount = 0;
            //制作.
            sprSeisaku.Visible = false;
            sprSeisaku.RowCount = 0;
            //テレビCM.
            sprTVCM.Visible = false;
            sprTVCM.RowCount = 0;
            //ラジオCM.
            sprRDCM.Visible = false;
            sprRDCM.RowCount = 0;

            //sprTV_Time.Visible = false;
            //sprRd_Time.Visible = false;
            //sprTV_Spot.Visible = false;
            //sprRd_Spot.Visible = false;
            //sprShin.Visible = false;
            //sprZashi.Visible = false;
            //sprKoutsuu.Visible = false;
            //sprJigyoubu.Visible = false;
            //sprTirashi.Visible = false;
            //sprMobile.Visible = false;
            //sprSample.Visible = false;
            //sprInternet.Visible = false;
            //sprBscs.Visible = false;
            //sprSonota.Visible = false;
            //sprSeisaku.Visible = false;
            //sprTV_Cm.Visible = false;
            //sprRd_Cm.Visible = false;
            //sprTV_Time.RowCount = 0;
            //sprRd_Time.RowCount = 0;
            //sprTV_Spot.RowCount = 0;
            //sprRd_Spot.RowCount = 0;
            //sprShin.RowCount = 0;
            //sprZashi.RowCount = 0;
            //sprKoutsuu.RowCount = 0;
            //sprJigyoubu.RowCount = 0;
            //sprTirashi.RowCount = 0;
            //sprMobile.RowCount = 0;
            //sprSample.RowCount = 0;
            //sprInternet.RowCount = 0;
            //sprBscs.RowCount = 0;
            //sprSonota.RowCount = 0;
            //sprSeisaku.RowCount = 0;
            //sprTV_Cm.RowCount = 0;
            //sprRd_Cm.RowCount = 0;
            /* 2014/07/31 消費税端数調整対応 HLC fujimoto MOD end */

            //***********************************
            //スプレッドシートのタブを非表示.
            //***********************************
            sprMain.TabStripPolicy = TabStripPolicy.Never;
        }

        #endregion メソッド.
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Lion.Schema;
using System.Collections;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// ライオンFD出力.
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
    public partial class FDLion : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数.

        #region システム環境設定取得用キー.

        /// <summary>
        /// 消費税率取得用キー.
        /// </summary>
        private const String SYSTEM_KEY_TAX_RATE = "ED-I0001";

        /// <summary>
        /// 帳票保存先取得用キー.
        /// </summary>
        private const String SYSTEM_KEY_SAVEFILE_PATH = "003";

        /// <summary>
        /// ファイル出力終了.
        /// </summary>
        private const String FILE_OUTPUT_OK = "完了しました";

        #endregion システム環境設定取得用キー.

        #region エラー区分.

        /// <summary>
        /// エラー区分:存在値エラー.
        /// </summary>
        private const String ErrExist = "S";

        /// <summary>
        /// エラー区分:ニューメリックエラー.
        /// </summary>
        private const String ErrNumneric = "N";

        /// <summary>
        /// エラー区分:ゾーンエラー.
        /// </summary>
        private const String ErrZone = "Z";

        /// <summary>
        /// エラー区分:必須エラー.
        /// </summary>
        private const String ErrEssential = "H";

        /// <summary>
        /// エラー区分:ロジカルエラー.
        /// </summary>
        private const String ErrLogical = "L";

        /// <summary>
        /// エラー区分:ダブリエラー.
        /// </summary>
        private const String ErrDouble = "W";

        #endregion エラー区分.

        #region エラー項目.

        /// <summary>
        /// エラー項目No:カードNo
        /// </summary>
        private const String itmCardNo = "01";

        /// <summary>
        /// エラー項目No:媒体区分.
        /// </summary>
        private const String itmMediaKbn = "02";

        /// <summary>
        /// エラー項目No:データ処理コード.
        /// </summary>
        private const String itmDtTranCd = "03";

        /// <summary>
        /// エラー項目No:データ日付.
        /// </summary>
        private const String itmDtYYYYMM = "04";

        /// <summary>
        /// エラー項目No:代理店コード.
        /// </summary>
        private const String itmAgencyCd = "05";

        /// <summary>
        /// エラー項目No:番組コード.
        /// </summary>
        private const String itmProgramCd = "06";

        /// <summary>
        /// エラー項目No:局誌コード.
        /// </summary>
        private const String itmKyokuCd = "07";

        /// <summary>
        /// エラー項目No:ブランドコード.
        /// </summary>
        private const String itmBrandCd = "08";

        /// <summary>
        /// エラー項目No:府県コード.
        /// </summary>
        private const String itmAreaCd = "09";

        /// <summary>
        /// エラー項目No:総秒数.
        /// </summary>
        private const String itmTtlTimes = "10";

        /// <summary>
        /// エラー項目No:秒数.
        /// </summary>
        private const String itmTimes = "11";

        /// <summary>
        /// エラー項目No:電波料.
        /// </summary>
        private const String itmDenpaPrc = "12";

        /// <summary>
        /// エラー項目No:ネット料.
        /// </summary>
        private const String itmNetPrc = "13";

        /// <summary>
        /// エラー項目No:制作費.
        /// </summary>
        private const String itmProPrc = "14";

        /// <summary>
        /// エラー項目No:請求額.
        /// </summary>
        private const String itmSeikyuPrc = "15";

        /// <summary>
        /// エラー項目No:ネットFC
        /// </summary>
        private const String itmNetFc = "16";

        /// <summary>
        /// エラー項目No:カードNoと媒体区分エラー.
        /// </summary>
        private const String itmCardBtKbn = "AA";

        /// <summary>
        /// エラー項目No:カードNo.001/003のロジカルエラー.
        /// </summary>
        private const String itmTVRDLog_Pro = "CA_P";

        /// <summary>
        /// エラー項目No:カードNo.001/003のロジカルエラー.
        /// </summary>
        private const String itmTVRDLog_FC = "CA_F";

        /// <summary>
        /// エラー項目No:カードNo.006のロジカルエラー.
        /// </summary>
        private const String itmCMTimesLog = "CB";

        /// <summary>
        /// エラー項目No:カードNo.006のロジカルエラー No3①.
        /// </summary>
        private const String itmCMGTimesLog = "CB";

        /// <summary>
        /// エラー項目No:カードNoの組み合わせエラー.
        /// </summary>
        private const String itmCardComb = "CC";

        /// <summary>
        /// エラー項目No:余分にCM秒数が入力された場合のエラー.
        /// </summary>
        private const String itmDblCMTimes = "WA";

        /// <summary>
        /// エラー項目No:ダブリエラー.
        /// </summary>
        private const String itmDouble = "WW";

        #endregion エラー項目.

        #region 広告代理店コード.

        /// <summary>
        /// 広告代理店コード.
        /// </summary>
        private const String AgencyCd = "1001";

        #endregion 広告代理店コード.

        #region スプレッド項目番号.

        /// <summary>
        /// スプレッド項目番号:ステータス.
        /// </summary>
        private const int cKStatus = 0;

        /// <summary>
        /// スプレッド項目番号:カードNO
        /// </summary>
        private const int cKKdNo = 1;

        /// <summary>
        /// スプレッド項目番号:日付.
        /// </summary>
        private const int cKYYMM = 2;

        /// <summary>
        /// スプレッド項目番号:代理店CD
        /// </summary>
        private const int cKDairitencd = 3;

        /// <summary>
        /// スプレッド項目番号:媒体区分.
        /// </summary>
        private const int cKBaitaicd = 4;

        /// <summary>
        /// スプレッド項目番号:番組CD
        /// </summary>
        private const int cKBangumicd = 5;

        /// <summary>
        /// スプレッド項目番号:ブランドCD
        /// </summary>
        private const int cKBrandcd = 6;

        /// <summary>
        /// スプレッド項目番号:ブランド名称.
        /// </summary>
        private const int cKBrandName = 7;

        /// <summary>
        /// スプレッド項目番号:局誌CD
        /// </summary>
        private const int cKKyokusicd = 8;

        /// <summary>
        /// スプレッド項目番号:局誌名称.
        /// </summary>
        private const int cKKyokusiName = 9;

        /// <summary>
        /// スプレッド項目番号:ネットFC
        /// </summary>
        private const int cKNetfc = 10;

        /// <summary>
        /// スプレッド項目番号:府県CD
        /// </summary>
        private const int cKfukencd = 11;

        /// <summary>
        /// スプレッド項目番号:電波料.
        /// </summary>
        private const int cKDenpa = 12;

        /// <summary>
        /// スプレッド項目番号:ネット料.
        /// </summary>
        private const int cKNet = 13;

        /// <summary>
        /// スプレッド項目番号:制作費.
        /// </summary>
        private const int cKSeisaku = 14;

        /// <summary>
        /// スプレッド項目番号:請求額.
        /// </summary>
        private const int cKSeikyu = 15;

        /// <summary>
        /// スプレッド項目番号:合計.
        /// </summary>
        private const int cKGoukei = 16;

        /// <summary>
        /// スプレッド項目番号:総秒数.
        /// </summary>
        private const int cKSoubyousu = 17;

        /// <summary>
        /// スプレッド項目番号:秒数・源泉税区分.
        /// </summary>
        private const int cKByousu_Gensen = 18;

        /// <summary>
        /// スプレッド項目番号:源泉税円.
        /// </summary>
        private const int cKGensenzeien = 19;

        /// <summary>
        /// スプレッド項目番号:雑広告消費税額.
        /// </summary>
        private const int cKZatukoukoku = 20;

        /// <summary>
        /// スプレッド項目番号:オンエア回数.
        /// </summary>
        private const int cKOnea = 21;

        /// <summary>
        /// スプレッド項目番号:データ処理CD
        /// </summary>
        private const int cKDetacd = 22;

        #endregion スプレッド項目番号.

        #region データ検索キー.

        /// <summary>
	    /// テレビタイム.
	    /// </summary>
	    private const String MEDIA_TYPE_TVTIME = "TVTIME";

        /// <summary>
	    /// テレビ･ラジオスポット.
	    /// </summary>
	    private const String MEDIA_TYPE_TVSP = "TVSP";

	    /// <summary>
	    /// ラジオタイム.
	    /// </summary>
	    private const String MEDIA_TYPE_RD_TIME = "RD_TIME";

	    /// <summary>
	    /// 新聞.
	    /// </summary>
	    private const String MEDIA_TYPE_NEWS = "NEWS";

	    /// <summary>
	    /// 雑誌.
	    /// </summary>
	    private const String MEDIA_TYPE_MAG = "MAG";

	    /// <summary>
	    /// 交通広告.
	    /// </summary>
	    private const String MEDIA_TYPE_KOUTUU = "KOUTUU";

	    /// <summary>
	    /// その他.
	    /// </summary>
	    private const String MEDIA_TYPE_ATHER = "ATHER";

	    /// <summary>
	    /// チラシ.
	    /// </summary>
	    private const String MEDIA_TYPE_Leaflet = "Leaflet";

	    /// <summary>
	    /// サンプリング.
	    /// </summary>
	    private const String MEDIA_TYPE_Sampling = "Sampling";

	    /// <summary>
	    /// BS･CS
	    /// </summary>
	    private const String MEDIA_TYPE_BSCS = "BSCS";

	    /// <summary>
	    /// Internet
	    /// </summary>
	    private const String MEDIA_TYPE_Internet = "Internet";

	    /// <summary>
	    /// モバイル.
	    /// </summary>
	    private const String MEDIA_TYPE_Mobile = "Mobile";

	    /// <summary>
	    /// 事業費.
	    /// </summary>
	    private const String MEDIA_TYPE_BusinessExp = "BusinessExp";

        /// <summary>
	    /// 全媒体消費税.
	    /// </summary>
	    private const String MEDIA_TYPE_Syouhi = "Syouhi";

        /// <summary>
	    /// 制作.
	    /// </summary>
	    private const String MEDIA_TYPE_SEISAKU = "SEISAKU";

        #endregion データ検索キー.

        #region エラー処理用定数.

        /// <summary>
        /// 合計行出力数.
        /// </summary>
        private const int TOTAL_AMOUNT_ROWS = 1;

        /// <summary>
        /// エラー区分比較用文字数.
        /// </summary>
        private const int ERROR_CLASSIFICATION_LENGTH = 1;

        /// <summary>
        /// エラーコード比較用文字数.
        /// </summary>
        private const int ERROR_CODE_LENGTH = 2;

        #endregion エラー処理用定数.

        #region 操作ログ出力用定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "FD";

        #endregion 操作ログ出力用定数.

        #endregion 定数.

        #region 構造体.

        /// <summary>
        /// TV/RD番組データ用構造体.
        /// </summary>
        private class LionBangumiData
        {
            public String BangumiCd;    //番組コード.
            public String BangumiNm;    //番組名称.
            public String NetFc;        //ネットFC
        };

        /// <summary>
        /// 局データ用構造体.
        /// </summary>
        private class LionKyokuData
        {
            public String KyokuCd;      //局コード.
            public String KyokuNm;      //局名称.
            public String Keiretu;      //系列.
        };

        /// <summary>
        /// 媒体区分データ用構造体.
        /// </summary>
        private class BaitaiKbnData
        {
            public String BaitaiKbnCd;  //媒体区分コード.
            public String BaitaiKbnNm;  //媒体区分名称.
        };

        /// <summary>
        /// ブランドデータ用構造体.
        /// </summary>
        private class BrandData
        {
            public String BrandCd;      //ブランドコード.
            public String BrandNm;      //ブランド名称.
            public String Genre;        //ジャンル.
            public String BrandSign;    //ブランド記号.
        };

        /// <summary>
        /// 新聞/雑誌データ用構造体.
        /// </summary>
        private class MediaData
        {
            public String MediaCd;      //媒体コード.
            public String MediaNm;      //媒体名称.
        };

        /// <summary>
        /// 府県データ用構造体.
        /// </summary>
        private class AreaData
        {
            public String AreaCd;       //県コード.
            public String AreaNm;       //県名称.
        };

        /// <summary>
        /// CM秒数データチェック用構造体.
        /// </summary>
        private class CMTimeData
        {
            public String CardNo;      //カードNo
            public String BangumiCd;   //番組コード.
            public String KyokusiCd;   //局誌コード.
            public String BrandCd;     //ブランドコード.
            public String TotalTimes;  //総秒数.
            public String Times;       //秒数.
        };

        #endregion 構造体.

        #region メンバ変数.

        /// <summary>
        /// 呼び出しパラメータ(受取)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 消費税率.
        /// </summary>
        private Decimal _taxRate;

        /// <summary>
        /// CM秒数テレビデータ年月チェック用.
        /// true:エラー、false:正常.
        /// </summary>
        private Boolean _errCMTVDateChk;

        /// <summary>
        /// CM秒数ラジオデータ年月チェック用.
        /// true:エラー、false:正常.
        /// </summary>
        private Boolean _errCMRDDateChk;

        /// <summary>
        /// ファイル出力先ディレクトリ.
        /// </summary>
        private string _strDefaultPath = "";

        /// <summary>
        /// ファイル出力名称.
        /// </summary>
        private string _strDefaultFilename = "";

        #region ライオン専用マスタ.

        /// <summary>
        /// ライオンマスタ読み込みモジュール.
        /// </summary>
        KKHLionReadMastFile _lionReadMast;

        /// <summary>
        /// ライオンマスタ保存用.
        /// </summary>
        MastLion _lionMast;

        /// <summary>
        /// ライオン番組マスタ.
        /// </summary>
        private List<LionBangumiData> strLionBangumi;

        /// <summary>
        /// ライオン局マスタ.
        /// </summary>
        private List<LionKyokuData> strLionKyoku;

        #endregion ライオン専用マスタ.

        #region 各マスタ.

        /// <summary>
        /// 媒体区分マスタ.
        /// </summary>
        private List<BaitaiKbnData> strBtKbn;

        /// <summary>
        /// ブランドマスタ.
        /// </summary>
        private List<BrandData> strBrand;

        /// <summary>
        /// 新聞・雑誌媒体マスタ.
        /// </summary>
        private List<MediaData> strMedia;

        /// <summary>
        /// インターネットマスタ.
        /// </summary>
        private List<MediaData> strInterNet;

        /// <summary>
        /// モバイルマスタ.
        /// </summary>
        private List<MediaData> strMobile;

        /// <summary>
        /// 府県マスタ.
        /// </summary>
        private List<AreaData> strArea;

        #endregion 各マスタ.

        #region 履歴保存.

        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */
        /// <summary>
        /// 履歴保存担当者マスタデータテーブル.
        /// </summary>
        DataTable dtTanto = new DataTable("TANTO");
        /// <summary>
        /// 履歴保存フラグ.
        /// </summary>
        Boolean blnTantoFlg = false;
        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD end */

        #endregion 履歴保存.

        #endregion メンバ変数.

        # region イベント.
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

        # endregion

        #region メソッド.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FDLion()
        {
            InitializeComponent();
        }

        private void FDLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            // 初期設定.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

        }

        private void FDLion_Lion_Shown(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            // シートの表示・非表示.
            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet2.Visible = true;

            // コンボボックスリストの初期値設定.
            cmbBaitai.SelectedIndex = 1;

            // ステータスの初期化.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            // 実施年月の初期化.
            initializeYYYYMM();

            // 消費税率の初期化.
            //initializeTaxRate();

            // 帳票出力先の初期化.
            initializeOutputPath();

            // 各マスタの読み込み.
            loadLionMaster();
            loadMediaDivisionMaster();
            loadBrandMaster();
            loadMediaMaster();
            loadInternetMediaMaster();
            loadMobileMediaMaster();
            loadAreaMaster();

            /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */
            //担当者マスタ取得.
            GetTanto();
            /* 2014/07/31 比較帳票対応 HLC fujimoto ADD end */

            //コントロールを未選択状態にする.
            this.ActiveControl = null;

            base.CloseLoadingDialog();
        }

        /// <summary>
        /// ライオン専用マスタを読み込む.
        /// </summary>
        private void loadLionMaster()
        {
            _lionReadMast = new KKHLionReadMastFile();

            _lionMast = _lionReadMast.GetLionMast(_naviParam);

            if (_lionMast.TvBnLion.Count == 0 &&
                _lionMast.RdBnLion.Count == 0 &&
                _lionMast.TvKLion.Count == 0 &&
                _lionMast.RdKLion.Count == 0)
            {
                //MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, Text, MessageBoxButtons.OK);
                base.CloseLoadingDialog();
                Navigator.Backward(this, null, _naviParam, true);
                return;
            }

            loadLionProgramMaster( _lionMast );

            loadLionStationMaster( _lionMast );
        }

        /// <summary>
        /// 番組マスタを読み込む.
        /// </summary>
        private int loadLionProgramMaster( MastLion lionMast )
        {
            strLionBangumi = new List<LionBangumiData>();

            // テレビ番組マスタ.
            for (int i = 0; i < lionMast.TvBnLion.Rows.Count; i++)
            {
                LionBangumiData item = new LionBangumiData();

                item.BangumiCd = lionMast.TvBnLion[i].BANCD;    //番組コード.
                item.BangumiNm = lionMast.TvBnLion[i].BANNAME;  //番組名称.
                item.NetFc     = lionMast.TvBnLion[i].TYPE2;    //ネットFC

                strLionBangumi.Add(item);
            }

            // ラジオ番組マスタ.
            for (int i = 0; i < lionMast.RdBnLion.Rows.Count; i++)
            {
                LionBangumiData item = new LionBangumiData();

                item.BangumiCd = lionMast.RdBnLion[i].BANCD;    //番組コード.
                item.BangumiNm = lionMast.RdBnLion[i].BANNAME;  //番組名称.
                item.NetFc     = lionMast.RdBnLion[i].TYPE2;    //ネットFC

                strLionBangumi.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// 局マスタを読み込む.
        /// </summary>
        private int loadLionStationMaster( MastLion lionMast )
        {
            strLionKyoku = new List<LionKyokuData>();

            // テレビ局マスタ.
            for( int i = 0; i < lionMast.TvKLion.Rows.Count; i++ )
            {
                LionKyokuData item = new LionKyokuData();

                item.KyokuCd    = lionMast.TvKLion[ i ].KYOKUCD;   //局コード.
                item.KyokuNm    = lionMast.TvKLion[ i ].KYOKUNAME; //局名称.
                item.Keiretu    = lionMast.TvKLion[ i ].KEIRETSU;  //系列.

                strLionKyoku.Add(item);
            }

            // ラジオ局マスタ.
            for( int i = 0; i < lionMast.RdKLion.Rows.Count; i++ )
            {
                LionKyokuData item = new LionKyokuData();

                item.KyokuCd    = lionMast.RdKLion[ i ].KYOKUCD;   //局コード.
                item.KyokuNm    = lionMast.RdKLion[ i ].KYOKUNAME; //局名称.
                item.Keiretu    = lionMast.RdKLion[ i ].KEIRETSU;  //系列.

                strLionKyoku.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// 媒体区分マスタを読み込む.
        /// </summary>
        /// <returns></returns>
        private int loadMediaDivisionMaster()
        {
            strBtKbn = new List<BaitaiKbnData>();
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_BAITAI_CD,
                string.Empty
            );

            //エラーの場合.
            if (result.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                BaitaiKbnData item = new BaitaiKbnData();

                item.BaitaiKbnCd = result.MasterDataSet.MasterDataVO[ i ].Column1;  //媒体区分コード.
                item.BaitaiKbnNm = result.MasterDataSet.MasterDataVO[ i ].Column2;  //媒体区分名称.

                strBtKbn.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// ブランドコードマスタの読み込み.
        /// </summary>
        /// <returns></returns>
        private int loadBrandMaster()
        {
            strBrand = new List<BrandData>();

            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_BRAND_CD,
                string.Empty
            );

            //エラーの場合.
            if (result.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                BrandData item = new BrandData();

                item.BrandCd    = result.MasterDataSet.MasterDataVO[ i ].Column1;   //ブランドコード.
                item.BrandNm    = result.MasterDataSet.MasterDataVO[ i ].Column2;   //ブランド名称.
                item.Genre      = result.MasterDataSet.MasterDataVO[ i ].Column3;   //ジャンル.
                item.BrandSign  = result.MasterDataSet.MasterDataVO[ i ].Column4;   //ブランド記号.

                strBrand.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// 媒体（新聞・雑誌）マスタを読み込む.
        /// </summary>
        /// <returns></returns>
        private int loadMediaMaster()
        {
            strMedia = new List<MediaData>();
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result1 = null;
            FindMasterMaintenanceByCondServiceResult result2 = null;

            result1 = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_SHINBUN_CD,
                null
            );

            result2 = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_ZASSI_CD,
                string.Empty
            );

            //エラーの場合.
            if (result1.HasError || result2.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result1.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                MediaData item = new MediaData();

                item.MediaCd = result1.MasterDataSet.MasterDataVO[ i ].Column1;    //媒体コード.
                item.MediaNm = result1.MasterDataSet.MasterDataVO[ i ].Column2;    //媒体名称.

                strMedia.Add(item);
            }

            for( int i = 0; i < result2.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                MediaData item = new MediaData();

                item.MediaCd = result2.MasterDataSet.MasterDataVO[ i ].Column1;    //媒体コード.
                item.MediaNm = result2.MasterDataSet.MasterDataVO[ i ].Column2;    //媒体名称.

                strMedia.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// インターネット媒体コードマスタを読み込む.
        /// </summary>
        /// <returns></returns>
        private int loadInternetMediaMaster()
        {
            strInterNet = new List<MediaData>();

            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_INTERNET_CD,
                string.Empty
            );

            //エラーの場合.
            if (result.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                MediaData item = new MediaData();

                item.MediaCd = result.MasterDataSet.MasterDataVO[ i ].Column1;  //媒体コード.
                item.MediaNm = result.MasterDataSet.MasterDataVO[ i ].Column2;  //媒体名称.

                strInterNet.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// モバイル媒体コードマスタを読み込む.
        /// </summary>
        /// <returns></returns>
        private int loadMobileMediaMaster()
        {
            strMobile = new List<MediaData>();
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_MOBILE_CD,
                string.Empty
            );

            //エラーの場合.
            if (result.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                MediaData item = new MediaData();

                item.MediaCd = result.MasterDataSet.MasterDataVO[ i ].Column1;  //媒体コード.
                item.MediaNm = result.MasterDataSet.MasterDataVO[ i ].Column2;  //媒体名称.

                strMobile.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// 府県コードマスタを読み込む.
        /// </summary>
        /// <returns></returns>
        private int loadAreaMaster()
        {
            strArea = new List<AreaData>();
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                KKHLionConst.C_MAST_KEN_CD,
                string.Empty
            );

            //エラーの場合.
            if (result.HasError)
            {
                return 1;
            }

            for( int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++ )
            {
                AreaData item = new AreaData();

                item.AreaCd = result.MasterDataSet.MasterDataVO[ i ].Column1;   //県コード.
                item.AreaNm = result.MasterDataSet.MasterDataVO[ i ].Column2;   //県名称.

                strArea.Add(item);
            }

            return 0;
        }

        /// <summary>
        /// 実施年月を初期化する.
        /// </summary>
        private void initializeYYYYMM()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();
            String strDate = controller.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
            }

            txtYm.Value = strDate.Substring(0, 6);
        }

        /// <summary>
        /// 消費税率を初期化する.
        /// </summary>
        private void initializeTaxRate()
        {
            ////消費税取得（マスタから）.
            //CommonProcessController controller = CommonProcessController.GetInstance();
            //FindCommonByCondServiceResult result = null;

            //result = controller.FindCommonByCond(
            //                                _naviParam.strEsqId,
            //                                _naviParam.strEgcd,
            //                                _naviParam.strTksKgyCd,
            //                                _naviParam.strTksBmnSeqNo,
            //                                _naviParam.strTksTntSeqNo,
            //                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
            //                                SYSTEM_KEY_TAX_RATE
            //                                );

            //if (result.CommonDataSet.SystemCommon.Count != 0)
            //{
            //    //消費税セット.
            //    _taxRate = KKHUtility.DecParse(result.CommonDataSet.SystemCommon[0].field4.ToString());
            //}

            //消費税率をマスタから取得するように変更(2012/01/18変更 JSE A.Naito) ////////////////////////////////
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            // 商品名取得.
            result = controller.FindMasterByCond(
                                            _naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            Isid.KKH.Lion.Utility.KKHLionConst.C_MAST_TAX_CD,
                                            null
                                            );
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                // 期間Fromと期間Toを取得.
                String yyMm = txtYm.Text.ToString() + "01";
                String from = row.Column2;
                String to = row.Column3;

                // 期間内の消費税率を使用する.
                if (yyMm.CompareTo(from) >= 0 && yyMm.CompareTo(to) <= 0)
                {
                    //_taxRate = Convert.ToDecimal(row.Column1);
                    double rate = KKHUtility.DouParse(row.Column1) * 0.01;
                    _taxRate = KKHUtility.DecParse(rate.ToString());
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// 帳票保存先を初期化する.
        /// </summary>
        private void initializeOutputPath()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = null;

            result = controller.FindCommonByCond(
                                            _naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                            SYSTEM_KEY_SAVEFILE_PATH
                                            );

            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                // 保存先.
                _strDefaultPath = result.CommonDataSet.SystemCommon[0].field2;

                // デフォルトファイル名.
                _strDefaultFilename = result.CommonDataSet.SystemCommon[0].field3;
            }
        }

        /// <summary>
        /// データ読み込みボタンが押された時のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            // 消費税率の初期化.
            initializeTaxRate();

            //ローディング表示開始.
            base.ShowLoadingDialog();

            if (cmbBaitai.SelectedIndex == 0)
            {
                loadFDForProductionData();
            }
            else if (cmbBaitai.SelectedIndex == 1)
            {
                loadFDForMediaData();
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// ファイル出力ボタンが押された時のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.SheetView view = null;

            bool errorStatus = false;

            // 表示されているシートを取得する.
            if (cmbBaitai.SelectedIndex == 0)
            {
                view = dgvMain_Sheet1;
            }
            else
            {
                view = dgvMain_Sheet2;
            }

            // エラーが発生しているかのチェック.
            for (int i = 0; i < view.Rows.Count; i++)
            {
                // ステータス項目がnullの場合はエラーは発生していない.
                if (view.Cells[i, cKStatus].Value == null)
                {
                    continue;
                }

                // ステータス項目が空文字の場合はエラーは発生していない.
                if (String.Equals(view.Cells[i, cKStatus].Value.ToString(), ""))
                {
                    continue;
                }

                // 何かしらのエラーが発生している.
                errorStatus = true;

                break;
            }

            // 警告メッセージを表示する.
            if (errorStatus)
            {
                if (MessageUtility.ShowMessageBox(MessageCode.HB_W0109, null, Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    // YES以外が返された場合はファイル出力を取り消しする.
                    return;
                }
            }

            // ファイルを出力する.
            FileOut(view);

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 終了ボタンが押された時のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 出力媒体が変更された時のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaitai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBaitai.SelectedIndex == 0)
            {
                btnXls.Enabled = false;

                dgvMain_Sheet1.Visible = true;
                dgvMain_Sheet1.Rows.Count = 0;

                dgvMain_Sheet2.Visible = false;
                dgvMain_Sheet2.Rows.Count = 0;
            }
            else if (cmbBaitai.SelectedIndex == 1)
            {
                btnXls.Enabled = false;

                dgvMain_Sheet1.Visible = false;
                dgvMain_Sheet1.Rows.Count = 0;

                dgvMain_Sheet2.Visible = true;
                dgvMain_Sheet2.Rows.Count = 0;
            }

            //件数を0件に初期化.
            statusStrip1.Items["tslval1"].Text = "0件";

            btnXls.Enabled = false;
        }

        /// <summary>
        /// スプレッドのセルがクリックされた時のイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            // 押されたボタンがマウスの左ボタンでない場合は表示しない.
            if( e.Button != MouseButtons.Left )
            {
                return;
            }

            // 列ヘッダーによる選択の場合は表示しない.
            if( e.ColumnHeader )
            {
                return;
            }

            // 行ヘッダーによる選択の場合は表示しない.
            if( e.RowHeader )
            {
                return;
            }

            // クリックされたセルがステータス項目でない場合は表示しない.
            if (e.Column != cKStatus)
            {
                return;
            }

            // ステータスに何も設定されていない場合は表示しない.
            if (e.View.Sheets[e.View.ActiveSheetIndex].Cells[e.Row, e.Column].Value == null)
            {
                return;
            }

            String value = e.View.Sheets[e.View.ActiveSheetIndex].Cells[e.Row, e.Column].Value.ToString();

            // ステータスに設定された文字が空文字の場合は表示しない.
            if (String.Equals(value, ""))
            {
                return;
            }

            // メッセージボックスを表示する.
            putStatusError(value);
        }

        /// <summary>
        /// フォームに入力されている年月を取得する.
        /// </summary>
        /// <returns>フォームに入力されている年月（YYYYMM形式）</returns>
        private String getYYYYMM()
        {
            return txtYm.Value;
        }

        /// <summary>
        /// 制作データの読み込み.
        /// </summary>
        private void loadFDForProductionData()
        {
            // 年月の取得.
            string strYYYYMM = getYYYYMM();

            // プロセスコントローラの取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            FindFDLionByCondServiceResult result = null;

            result = controller.FindFDLionByCond(
                                               _naviParam.strEsqId,
                                               _naviParam.strEgcd,
                                               _naviParam.strTksKgyCd,
                                               _naviParam.strTksBmnSeqNo,
                                               _naviParam.strTksTntSeqNo,
                                               strYYYYMM,
                                               MEDIA_TYPE_SEISAKU
                                               );

            // データが存在しなければ終了.
            if ( result.dsFDLion.FDLionResult.Rows.Count == 0 )
            {
                btnXls.Enabled = false;
                dgvMain_Sheet1.RowCount = 0;
                dgvMain_Sheet2.RowCount = 0;
                statusStrip1.Items["tslval1"].Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, Text, MessageBoxButtons.OK);

                return;
            }

            // 帳票出力用データスキーマの生成.
            FDDSLion view = new FDDSLion();

            Decimal totalAmount = new Decimal();

            //

            putSEISAKU(result, strYYYYMM, view, out totalAmount);

            putTotalAmount(totalAmount, view);

            //

            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet1.DataSource = view.FDLionView;

            statusStrip1.Items["tslval1"].Text = ( view.FDLionView.Rows.Count - TOTAL_AMOUNT_ROWS ).ToString() + "件";

            btnXls.Enabled = true;
        }

        /// <summary>
        /// 媒体データの読み込み.
        /// </summary>
        private void loadFDForMediaData()
        {
            // 年月の取得.
            string strYYYYMM = getYYYYMM();

            // プロセスコントローラの取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            FindFDLionByCondServiceResult resultTVTIME = null;
            FindFDLionByCondServiceResult resultTVSP = null;
            FindFDLionByCondServiceResult resultRD_TIME = null;
            FindFDLionByCondServiceResult resultNEWS = null;
            FindFDLionByCondServiceResult resultMAG = null;
            FindFDLionByCondServiceResult resultKOUTUU = null;
            FindFDLionByCondServiceResult resultATHER = null;
            FindFDLionByCondServiceResult resultLeaflet = null;
            FindFDLionByCondServiceResult resultSampling = null;
            FindFDLionByCondServiceResult resultBSCS = null;
            FindFDLionByCondServiceResult resultInternet = null;
            FindFDLionByCondServiceResult resultMobile = null;
            FindFDLionByCondServiceResult resultBusinessExp = null;
            FindFDLionByCondServiceResult resultSyouhi = null;

            resultTVTIME = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_TVTIME
                                                );

            resultTVSP = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_TVSP
                                                );

            resultRD_TIME = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_RD_TIME
                                                );

            resultNEWS = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_NEWS
                                                );

            resultMAG = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_MAG
                                                );

            resultKOUTUU = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_KOUTUU
                                                );

            resultATHER = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_ATHER
                                                );

            resultLeaflet = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_Leaflet
                                                );

            resultSampling = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_Sampling
                                                );

            resultBSCS = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_BSCS
                                                );

            resultInternet = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_Internet
                                                );

            resultMobile = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_Mobile
                                                );


            resultBusinessExp = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_BusinessExp
                                                );

            resultSyouhi = controller.FindFDLionByCond(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strYYYYMM,
                                                MEDIA_TYPE_Syouhi
                                                );

            // ライオンマスターの読み込み.
            MastLion lionCMMast = _lionReadMast.GetLionTvRdCm( _naviParam, strYYYYMM );

            MastLion.RdCmLionDataTable resultRdCM = lionCMMast.RdCmLion;

            MastLion.TvCmLionDataTable resultTvCM = lionCMMast.TvCmLion;

            // データが存在しなければ終了.
            if (resultTVTIME.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultTVSP.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultRD_TIME.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultNEWS.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultMAG.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultKOUTUU.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultATHER.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultLeaflet.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultSampling.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultBSCS.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultInternet.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultMobile.dsFDLion.FDLionResult.Rows.Count == 0 &&
                resultBusinessExp.dsFDLion.FDLionResult.Rows.Count == 0 &&
//              ( resultSyouhi.dsFDLion.FDLionResult.Rows.Count == 0 ) &&
                resultRdCM.Rows.Count == 0 &&
                resultTvCM.Rows.Count == 0 )
            {
                btnXls.Enabled = false;

                dgvMain_Sheet1.RowCount = 0;

                dgvMain_Sheet2.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0件";

                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, Text, MessageBoxButtons.OK);

                return;
            }

            // CM秒数データの年月チェック.
            //if
            //(
            //    (KKHLionCMDateCheck.checkTVCMDate(strYYYYMM, resultTvCM) != false) ||
            //    (KKHLionCMDateCheck.checkRDCMDate(strYYYYMM, resultRdCM) != false)
            //)
            //{
            //    btnXls.Enabled = false;
            //    dgvMain_Sheet1.RowCount = 0;
            //    dgvMain_Sheet2.RowCount = 0;
            //    statusStrip1.Items["tslval1"].Text = "0件";
            //    MessageUtility.ShowMessageBox(MessageCode.HB_W0110, null, Text, MessageBoxButtons.OK);
            //    return;
            //}

            // チェック用変数初期化.
            _errCMTVDateChk = false;
            _errCMRDDateChk = false;

            if (KKHLionCMDateCheck.checkTVCMDate(strYYYYMM, resultTvCM))
            {
                _errCMTVDateChk = true;
            }

            if (KKHLionCMDateCheck.checkRDCMDate(strYYYYMM, resultRdCM))
            {
                _errCMRDDateChk = true;
            }

            // 帳票出力用データスキーマの生成.
            FDDSLion view = new FDDSLion();
            List<CMTimeData> strCMChk = new List<CMTimeData>();
            Decimal totalAmount = new Decimal();

            putTVTIME(resultTVTIME, strYYYYMM, view);
            putTVSP(resultTVSP, strYYYYMM, view);
            putRD_TIME(resultRD_TIME, strYYYYMM, view);
            putNEWS(resultNEWS, strYYYYMM, view);
            putMAG(resultMAG, strYYYYMM, view);
            putKOUTUU(resultKOUTUU, strYYYYMM, view);
            putATHER(resultATHER, strYYYYMM, view);
            putLeaflet(resultLeaflet, strYYYYMM, view);
            putSampling(resultSampling, strYYYYMM, view);
            putBSCS(resultBSCS, strYYYYMM, view);
            putInternet(resultInternet, strYYYYMM, view);
            putMobile(resultMobile, strYYYYMM, view);
            putBusinessExp(resultBusinessExp, strYYYYMM, view);
            putCMRD(resultRdCM, strYYYYMM, view, strCMChk );
            putCMTV(resultTvCM, strYYYYMM, view, strCMChk );
            putSyouhi(resultSyouhi, strYYYYMM, view, out totalAmount);
            putTotalAmount(totalAmount, view);

            dgvMain_Sheet2.RowCount = 0;
            dgvMain_Sheet2.DataSource = view.FDLionView;
            checkAllData( dgvMain_Sheet2, strCMChk );
            statusStrip1.Items["tslval1"].Text = ( view.FDLionView.Rows.Count - TOTAL_AMOUNT_ROWS ).ToString() + "件";

            // CM秒数データの年月チェック.
            // CM秒数データの年月が検索年月と異なる場合はCSV出力不可とする.
            if (KKHLionCMDateCheck.checkTVCMDate(strYYYYMM, resultTvCM) ||
                KKHLionCMDateCheck.checkRDCMDate(strYYYYMM, resultRdCM))
            {
                btnXls.Enabled = false;
                return;
            }

            btnXls.Enabled = true;
        }

        /// <summary>
        /// テレビ番組をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putTVTIME(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBangumicd;      //番組CD格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //放送局名格納変数.
            Decimal cDenpa;         //電波料格納変数.
            Decimal cNeto;          //ネット料格納変数.
            Decimal cSeisaku;       //制作費格納変数.
            long lOner;             //オンエア回数格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBangumicd = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cDenpa = 0m;
            cNeto = 0m;
            cSeisaku = 0m;
            lOner = 0;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();       //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();         //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim(); //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu) - (KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku));
                    //cDenpa = KKHUtility.DecParse(resultRow.seikyuu) - (KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku));
                    cNeto = KKHUtility.DecParse(resultRow.neto);               //ネット料格納変数.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);         //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);
                }

                //カードNO,局誌コード,番組コードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBangumicd, resultRow.bangumi.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();       //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();         //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim(); //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = cDenpa + ( KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) ) );
                    cNeto = cNeto + KKHUtility.DecParse(resultRow.neto);            //ネット料格納変数.
                    cSeisaku = cSeisaku + KKHUtility.DecParse(resultRow.seisaku);   //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner += KKHUtility.LongParse(resultRow.honsu);
                    //lOner = lOner + long.Parse(resultRow.honsu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD
                    viewRow.cKBangumicd = sBangumicd.ToString();
                    //ブランドCD空白を入れる.
                    viewRow.cKBrandcd = "";
                    //ブランド名称.
                    viewRow.cKBrandName = "";
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //テレビタイム(001,002)
                    if (sKadoNo == "001")
                    {
                        //ネットFC
                        viewRow.cKNetfc = "1".ToString();
                    }
                    else
                    {
                        //ネットFC空白を入れる.
                        viewRow.cKNetfc = "";
                    }
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";

                    //テレビタイム(001ネットテレビ,002ローカルテレビ)
                    if (sKadoNo == "001")
                    {
                        //電波料(値引率込)
                        viewRow.cKDenpa = cDenpa.ToString();
                        //ネット料.
                        viewRow.cKNet = cNeto.ToString();
                        //制作費.
                        viewRow.cKSeisaku = cSeisaku.ToString();
                        //テレビタイム(001ネットテレビ,002ローカルテレビ)
                    }
                    else if (sKadoNo == "002")
                    {
                        //電波料(値引率込)
                        viewRow.cKDenpa = cDenpa.ToString();
                        //ネット料.
                        viewRow.cKNet = "";
                        //制作費.
                        viewRow.cKSeisaku = cSeisaku.ToString();
                    }
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = lOner.ToString();
                    //データ処理CD
                    viewRow.cKDetacd = "21".Trim();
                    //変数にセット.
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();       //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();         //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim(); //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    cNeto = KKHUtility.DecParse(resultRow.neto);        //ネット料格納変数.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);  //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                bflg = true;
            }

            //レコードがあるかフラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD
                viewRow.cKBangumicd = sBangumicd.ToString();
                //ブランドCD空白を入れる.
                viewRow.cKBrandcd = "";
                //ブランド名称.
                viewRow.cKBrandName = "";
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //テレビタイム(001,002)
                if (sKadoNo == "001")
                {
                    //ネットFC
                    viewRow.cKNetfc = "1".ToString();
                }
                else
                {
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                }
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";

                //テレビタイム(001ネットテレビ,002ローカルテレビ)
                if (sKadoNo == "001")
                {
                    //電波料(値引率込)
                    viewRow.cKDenpa = cDenpa.ToString();
                    //ネット料.
                    viewRow.cKNet = cNeto.ToString();
                    //制作費.
                    viewRow.cKSeisaku = cSeisaku.ToString();
                    //テレビタイム(001ネットテレビ,002ローカルテレビ)
                }
                else if (sKadoNo == "002")
                {
                    //電波料(値引率込)
                    viewRow.cKDenpa = cDenpa.ToString();
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = cSeisaku.ToString();
                }
                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = lOner.ToString();
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// スポットをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putTVSP(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBrandCd;        //ブランドCD格納変数.
            String sBrandName;      //ブランド名称格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //放送局名格納変数.
            Decimal cSeikyuu;       //請求額格納変数.
            long lSoubyou;          //総秒数格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cSeikyuu = 0m;
            lSoubyou = 0;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();         //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();     //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();         //局誌CD格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim(); //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    lSoubyou = KKHUtility.LongParse(resultRow.soubyousu.Trim());       //秒数格納.
                }

                //カードNO,局誌コード,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();         //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();     //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();         //局誌CD格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim(); //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    lSoubyou = lSoubyou + KKHUtility.LongParse(resultRow.soubyousu.Trim());      //秒数格納.
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白をセット.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料(値引率込)
                    viewRow.cKDenpa = cSeikyuu.ToString();
                    //ネット料空白.
                    viewRow.cKNet = "";
                    //制作費空白.
                    viewRow.cKSeisaku = "";
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //秒数・源泉税区分.
                    viewRow.cKByousu_Gensen = lSoubyou.ToString();
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    sKadoNo = resultRow.kadoNo.Trim();              //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();            //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();      //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();          //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();            //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();        //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();            //局誌CD格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    lSoubyou = KKHUtility.LongParse(resultRow.soubyousu.Trim());        //秒数格納.

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコードがある.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白をセット.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //電波料(値引率込)
                viewRow.cKDenpa = cSeikyuu.ToString();
                //ネット料空白.
                viewRow.cKNet = "";
                //制作費空白.
                viewRow.cKSeisaku = "";
                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //秒数・源泉税区分.
                viewRow.cKByousu_Gensen = lSoubyou.ToString();
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// ラジオ番組をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putRD_TIME(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBangumicd;      //番組CD格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //放送局名格納変数.
            Decimal cDenpa;         //電波料格納変数.
            Decimal cNeto;          //ネット料格納変数.
            Decimal cSeisaku;       //制作費格納変数.
            long lOner;             //オンエア回数格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBangumicd = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cDenpa = 0m;
            cNeto = 0m;
            cSeisaku = 0m;
            lOner = 0;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();              //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();            //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();      //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();          //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();          //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();            //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    cNeto = KKHUtility.DecParse(resultRow.neto);        //ネット料格納変数.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);  //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);
                }

                //カードNO,局誌コード,番組コードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBangumicd, resultRow.bangumi.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();              //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();            //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();      //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();          //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();          //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();            //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = cDenpa + KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    cNeto = cNeto + KKHUtility.DecParse(resultRow.neto);            //ネット料格納変数.
                    cSeisaku = cSeisaku + KKHUtility.DecParse(resultRow.seisaku);   //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner += KKHUtility.LongParse(resultRow.honsu);
                    //lOner = lOner + long.Parse(resultRow.honsu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo;
                    //年月.
                    viewRow.cKYYMM = sNentuki;
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd;
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd;
                    //番組CD
                    viewRow.cKBangumicd = sBangumicd;
                    //ブランドCD空白を入れる.
                    viewRow.cKBrandcd = "";
                    //ブランド名称.
                    viewRow.cKBrandName = "";
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd;
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR;
                    //ラジオタイム(003)、ラジオタイム(004)
                    if (sKadoNo.Trim() == "003")
                    {
                        //ネットFC
                        viewRow.cKNetfc = "1".ToString();
                    }
                    else
                    {
                        //ネットFC空白を入れる.
                        viewRow.cKNetfc = "";
                    }
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";
                    //テレビタイム(003ネットテレビ)、ラジオタイム(004ネットラジオ)
                    if (sKadoNo.Trim() == "003")
                    {
                        //電波料.
                        viewRow.cKDenpa = cDenpa.ToString();
                        //ネット料.
                        viewRow.cKNet = cNeto.ToString();
                        //制作費.
                        viewRow.cKSeisaku = cSeisaku.ToString();
                        //テレビタイム(002ローカルテレビ)、ラジオタイム(004ローカルラジオ)
                    }
                    else if (sKadoNo.Trim() == "004")
                    {
                        //電波料.
                        viewRow.cKDenpa = cDenpa.ToString();
                        //ネット料.
                        viewRow.cKNet = "";
                        //制作費.
                        viewRow.cKSeisaku = cSeisaku.ToString();
                    }
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数(放送回数－休止回数)→本数.
                    viewRow.cKOnea = lOner.ToString();
                    //データ処理CD.
                    viewRow.cKDetacd = "21".Trim();
                    sKadoNo = resultRow.kadoNo.Trim();              //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();            //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();      //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();          //媒体区分格納変数.
                    sBangumicd = resultRow.bangumi.Trim();          //番組CD格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();            //局誌格納変数.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名格納変数.
                    //電波料格納変数.
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu) - ( KKHUtility.DecParse(resultRow.neto) + KKHUtility.DecParse(resultRow.seisaku) );
                    cNeto = KKHUtility.DecParse(resultRow.neto);        //ネット料格納変数.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);  //制作費格納変数.
                    //オンエア回数格納変数.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコードがあるかフラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo;
                //年月.
                viewRow.cKYYMM = sNentuki;
                //代理店CD
                viewRow.cKDairitencd = sDairitencd;
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd;
                //番組CD
                viewRow.cKBangumicd = sBangumicd;
                //ブランドCD空白を入れる.
                viewRow.cKBrandcd = "";
                //ブランド名称.
                viewRow.cKBrandName = "";
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd;
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR;
                //ラジオタイム(003)、ラジオタイム(004)
                if (sKadoNo.Trim() == "003")
                {
                    //ネットFC
                    viewRow.cKNetfc = "1".ToString();
                }
                else
                {
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                }
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //テレビタイム(003ネットテレビ)、ラジオタイム(004ネットラジオ)
                if (sKadoNo.Trim() == "003")
                {
                    //電波料.
                    viewRow.cKDenpa = cDenpa.ToString();
                    //ネット料.
                    viewRow.cKNet = cNeto.ToString();
                    //制作費.
                    viewRow.cKSeisaku = cSeisaku.ToString();
                    //テレビタイム(002ローカルテレビ)、ラジオタイム(004ローカルラジオ)
                }
                else if (sKadoNo.Trim() == "004")
                {
                    //電波料.
                    viewRow.cKDenpa = cDenpa.ToString();
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = cSeisaku.ToString();
                }
                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数(放送回数－休止回数)→本数.
                viewRow.cKOnea = lOner.ToString();
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// 新聞をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putNEWS(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBrandCd;        //ブランドCD格納変数.
            String sBrandName;      //ブランド名称格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //局誌名格納変数.
            Decimal cSeikyuu;       //請求額格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);  //請求額格納変数.
                }

                //カードNO,局誌コード,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);   //請求額格納変数.
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白をセット.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料(値引率込)
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = cSeikyuu.ToString();
                    //制作費空白.
                    viewRow.cKSeisaku = "";
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //秒数・源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21".Trim();
                    //変数格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);  //請求額格納変数.

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白をセット.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //電波料(値引率込)
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = cSeikyuu.ToString();
                //制作費空白.
                viewRow.cKSeisaku = "";
                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //秒数・源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD.
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// 雑誌をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putMAG(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBrandCd;        //ブランドCD格納変数.
            String sBrandName;      //ブランド名称格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //局誌名格納変数.
            Decimal cSeikyuu;       //請求額格納変数.
            Decimal cSeisaku;       //タイアップ制作費格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cSeikyuu = 0m;
            cSeisaku = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {

                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu) - KKHUtility.DecParse(resultRow.seisaku);
                    //タイアップ制作費格納.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);
                }

                //カードNO,局誌コード,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + ( KKHUtility.DecParse(resultRow.seikyuu) - KKHUtility.DecParse(resultRow.seisaku) );
                    //タイアップ制作費格納.
                    cSeisaku = cSeisaku + KKHUtility.DecParse(resultRow.seisaku);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白をセット.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料(値引率込)
                    viewRow.cKDenpa = "";
                    //ネット料空白.
                    viewRow.cKNet = cSeikyuu.ToString();
                    //タイアップ制作費.
                    viewRow.cKSeisaku = cSeisaku.ToString();
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //秒数・源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD.
                    viewRow.cKDetacd = "21".Trim();
                    //変数に格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌CD格納変数.
                    sKyokuNameTR = resultRow.NewsName.Trim();   //放送局名格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu) - KKHUtility.DecParse(resultRow.seisaku);
                    //タイアップ制作費格納.
                    cSeisaku = KKHUtility.DecParse(resultRow.seisaku);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白をセット.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //電波料(値引率込)
                viewRow.cKDenpa = "";
                //ネット料空白.
                viewRow.cKNet = cSeikyuu.ToString();
                //タイアップ制作費.
                viewRow.cKSeisaku = cSeisaku.ToString();
                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //秒数・源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// 交通広告をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putKOUTUU(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;     //カードナンバー格納変数.
            String sNentuki;    //年月格納変数.
            String sDairitencd; //代理店CD格納変数.
            String sBaitaicd;   //媒体CD格納変数.
            String sBrandCd;    //ブランドCD格納変数.
            String sBrandName;  //ブランド名称格納変数.
            String sFukenCd;    //府県CD格納変数.
            Decimal cSeikyuu;  //請求額格納変数.
            Boolean bflg;       //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            sFukenCd = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sFukenCd = resultRow.fukencd.Trim();        //府県CD格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                }

                //カードNO,ブランドコード,府県コードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && String.Equals(sFukenCd, resultRow.fukencd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sFukenCd = resultRow.fukencd.Trim();        //府県CD格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白をセット.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = "";
                    //局誌名称.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD
                    viewRow.cKfukencd = sFukenCd.Trim();
                    //電波料(値引率込)
                    viewRow.cKDenpa = "";
                    //ネット料空白.
                    viewRow.cKNet = "";
                    //タイアップ制作費.
                    viewRow.cKSeisaku = "";
                    //請求額・予算.
                    viewRow.cKSeikyu = cSeikyuu.ToString();
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //秒数・源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21".Trim();
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    sFukenCd = resultRow.fukencd.Trim();        //府県CD格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);  //請求額格納変数.

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白をセット.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = "";
                //局誌名称.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD
                viewRow.cKfukencd = sFukenCd.Trim();
                //電波料(値引率込)
                viewRow.cKDenpa = "";
                //ネット料空白.
                viewRow.cKNet = "";
                //タイアップ制作費.
                viewRow.cKSeisaku = "";
                //請求額・予算.
                viewRow.cKSeikyu = cSeikyuu.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //秒数・源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// その他をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putATHER(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;     //カードナンバー格納変数.
            String sNentuki;    //年月格納変数.
            String sDairitencd; //代理店CD格納変数.
            String sBaitaicd;   //媒体CD格納変数.
            String sBrandCd;    //ブランドCD格納変数.
            String sBrandName;  //ブランド名称格納変数.
            Decimal cSeikyuu;   //請求額格納変数.
            Boolean bflg;       //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称空白を入れる.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = cSeikyuu.ToString();
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD空白を入れる.
                viewRow.cKKyokusicd = "";
                //局誌名称空白を入れる.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = cSeikyuu.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// チラシをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putLeaflet(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;     //カードナンバー格納変数.
            String sNentuki;    //年月格納変数.
            String sDairitencd; //代理店CD格納変数.
            String sBaitaicd;   //媒体CD格納変数.
            String sBrandCd;    //ブランドCD格納変数.
            String sBrandName;  //ブランド名称格納変数.
            Decimal cSeikyuu;   //請求額格納変数.
            Boolean bflg;       //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {

                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称空白を入れる.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = cSeikyuu.ToString();
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD空白を入れる.
                viewRow.cKKyokusicd = "";
                //局誌名称空白を入れる.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = cSeikyuu.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// サンプリングをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putSampling(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;     //カードナンバー格納変数.
            String sNentuki;    //年月格納変数.
            String sDairitencd; //代理店CD格納変数.
            String sBaitaicd;   //媒体CD格納変数.
            String sBrandCd;    //ブランドCD格納変数.
            String sBrandName;  //ブランド名称格納変数.
            Decimal cSeikyuu;   //請求額格納変数.
            Boolean bflg;       //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称空白を入れる.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = cSeikyuu.ToString();
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD空白を入れる.
                viewRow.cKKyokusicd = "";
                //局誌名称空白を入れる.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = cSeikyuu.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// BS・CSをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putBSCS(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBangumicd;      //番組CD格納変数.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //放送局名格納変数.
            Decimal cDenpa;         //電波料格納変数.
            long lOner;             //オンエア回数格納変数.
            Boolean bflg;           //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBangumicd = null;
            sKyokucd = null;
            sKyokuNameTR = null;
            cDenpa = 0m;
            lOner = 0;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバーを格納.
                    sNentuki = resultRow.nentuki.Trim();        //年月を格納.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CDを格納.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分を格納.
                    sBangumicd = resultRow.bangumi.Trim();      //番組CDを格納.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌を格納.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名を格納.
                    //電波料を格納.
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu);
                    //cDenpa = KKHUtility.DecParse(resultRow.seikyuu);
                    //オンエア回数を格納.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);
                }

                //カードNO,局誌コード,番組コードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBangumicd, resultRow.bangumi.Trim()) && String.Equals(sKyokucd, resultRow.kyokucd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバーを格納.
                    sNentuki = resultRow.nentuki.Trim();        //年月格を納.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CDを格納.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分を格納.
                    sBangumicd = resultRow.bangumi.Trim();      //番組CDを格納.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌を格納.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名を格納.
                    //電波料を格納.
                    cDenpa += KKHUtility.DecParse(resultRow.seikyuu);
                    //cDenpa = cDenpa + KKHUtility.DecParse(resultRow.seikyuu);
                    //オンエア回数を格納.
                    lOner += KKHUtility.LongParse(resultRow.honsu);
                    //lOner = lOner + long.Parse(resultRow.honsu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD
                    viewRow.cKBangumicd = sBangumicd.ToString();
                    //ブランドCD空白を入れる.
                    viewRow.cKBrandcd = "";
                    //ブランド名称.
                    viewRow.cKBrandName = "";
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CDに空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料(値引率込)
                    viewRow.cKDenpa = cDenpa.ToString();
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額・予算.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //空白を入力.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数(放送回数－休止回数)→本数.
                    viewRow.cKOnea = lOner.ToString();
                    //データ処理CD
                    viewRow.cKDetacd = "21".Trim();
                    //変数にセット.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバーを格納.
                    sNentuki = resultRow.nentuki.Trim();        //年月を格納.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CDを格納.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分を格納.
                    sBangumicd = resultRow.bangumi.Trim();      //番組CDを格納.
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格を納.
                    sKyokuNameTR = resultRow.kyokuNameTR.Trim();    //放送局名を格納.
                    //電波料を格納,
                    cDenpa = KKHUtility.DecParse(resultRow.seikyuu);
                    //cDenpa = KKHUtility.DecParse(resultRow.seikyuu);
                    //オンエア回数を格納.
                    lOner = KKHUtility.LongParse(resultRow.honsu);
                    //lOner = long.Parse(resultRow.honsu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                bflg = true;
            }

            //レコードがあるかフラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD
                viewRow.cKBangumicd = sBangumicd.ToString();
                //ブランドCD空白を入れる.
                viewRow.cKBrandcd = "";
                //ブランド名称.
                viewRow.cKBrandName = "";
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //電波料(値引率込)
                viewRow.cKDenpa = cDenpa.ToString();

                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";

                //請求額・予算.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数(放送回数－休止回数)→本数.
                viewRow.cKOnea = lOner.ToString();
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// インターネットをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putInternet(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBrandCd;        //ブランドCD格納変数.
            String sBrandName;      //ブランド名称格納変数.
            Decimal cSeikyuu;       //請求額格納変数.
            Boolean bflg;           //レコード判定フラグ.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //局誌名格納変数.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;
            sKyokucd = null;
            sKyokuNameTR = null;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();    //局誌名格納変数.
                    }
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();  //局誌名格納変数.
                    }
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = cSeikyuu.ToString();
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();    //局誌名格納変数.
                    }

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月,
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = cSeikyuu.ToString();
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// モバイルをビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putMobile(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;         //カードナンバー格納変数.
            String sNentuki;        //年月格納変数.
            String sDairitencd;     //代理店CD格納変数.
            String sBaitaicd;       //媒体CD格納変数.
            String sBrandCd;        //ブランドCD格納変数.
            String sBrandName;      //ブランド名称格納変数.
            Decimal cSeikyuu;       //請求額格納変数.
            Boolean bflg;           //レコード判定フラグ.
            String sKyokucd;        //局誌格納変数.
            String sKyokuNameTR;    //局誌名格納変数.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;
            sKyokucd = null;
            sKyokuNameTR = null;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();    //局誌名格納変数.
                    }
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();           //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();         //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();   //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();       //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();     //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();              //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();      //局誌名格納変数.
                    }
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD
                    viewRow.cKKyokusicd = sKyokucd.Trim();
                    //局誌名称.
                    viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = cSeikyuu.ToString();
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                    sKyokucd = resultRow.kyokucd.Trim();        //局誌格納変数.
                    if (String.IsNullOrEmpty(resultRow.kyokuNm.Trim()))
                    {
                        sKyokuNameTR = "";
                    }
                    else
                    {
                        sKyokuNameTR = resultRow.kyokuNm.Trim();      //局誌名格納変数.
                    }

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD
                viewRow.cKKyokusicd = sKyokucd.Trim();
                //局誌名称.
                viewRow.cKKyokusiName = sKyokuNameTR.Trim();
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = cSeikyuu.ToString();
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = "";
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// 事業費をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        private void putBusinessExp(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view)
        {
            String sKadoNo;     //カードナンバー格納変数.
            String sNentuki;    //年月格納変数.
            String sDairitencd; //代理店CD格納変数.
            String sBaitaicd;   //媒体CD格納変数.
            String sBrandCd;    //ブランドCD格納変数.
            String sBrandName;  //ブランド名称格納変数.
            Decimal cSeikyuu;   //請求額格納変数.
            Boolean bflg;       //レコード判定フラグ.

            sKadoNo = null;
            sNentuki = null;
            sDairitencd = null;
            sBaitaicd = null;
            sBrandCd = null;
            sBrandName = null;
            cSeikyuu = 0m;
            bflg = false;

            //レコード判定フラグ.
            bflg = false;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {

                //最初だけテーブルの項目をセット.
                if (!bflg)
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);
                }

                //カードNO,ブランドコードを比較.
                if (String.Equals(sKadoNo, resultRow.kadoNo.Trim()) && String.Equals(sBrandCd, resultRow.brandcd.Trim()) && ( bflg ))
                {
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = cSeikyuu + KKHUtility.DecParse(resultRow.seikyuu);
                }
                else if (bflg)
                {
                    //カードNo
                    viewRow.cKKdNo = sKadoNo.Trim();
                    //年月.
                    viewRow.cKYYMM = sNentuki.Trim();
                    //代理店CD
                    viewRow.cKDairitencd = sDairitencd.Trim();
                    //媒体区分.
                    viewRow.cKBaitaicd = sBaitaicd.Trim();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd.Trim();
                    //ブランド名称.
                    viewRow.cKBrandName = sBrandName.Trim();
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称空白を入れる.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //請求額.
                    viewRow.cKSeikyu = cSeikyuu.ToString();
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";
                    //変数を格納.
                    sKadoNo = resultRow.kadoNo.Trim();          //カードナンバー格納変数.
                    sNentuki = resultRow.nentuki.Trim();        //年月格納変数.
                    sDairitencd = resultRow.dairitencd.Trim();  //代理店CD格納変数.
                    sBaitaicd = resultRow.baitaicd.Trim();      //媒体区分格納変数.
                    sBrandCd = resultRow.brandcd.Trim();        //ブランドCD格納変数.
                    sBrandName = resultRow.brandName.Trim();    //ブランド名称格納変数.
                    //請求額格納変数.
                    cSeikyuu = KKHUtility.DecParse(resultRow.seikyuu);

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //レコード判定フラグ.
                bflg = true;
            }

            //レコード判定フラグ.
            if (bflg)
            {
                //カードNo
                viewRow.cKKdNo = sKadoNo.Trim();
                //年月.
                viewRow.cKYYMM = sNentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = sDairitencd.Trim();
                //媒体区分.
                viewRow.cKBaitaicd = sBaitaicd.Trim();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = sBrandCd.Trim();
                //ブランド名称.
                viewRow.cKBrandName = sBrandName.Trim();
                //局誌CD空白を入れる.
                viewRow.cKKyokusicd = "";
                //局誌名称空白を入れる.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額.
                viewRow.cKSeikyu = cSeikyuu.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //源泉税円.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
            }
        }

        /// <summary>
        /// 消費税をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        /// <param name="totalAmout"></param>
        private void putSyouhi(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view, out Decimal totalAmout)
        {
            Decimal Csyouhigak;
            //Decimal Csyouhigak_1;
            //Decimal Csyouhigak_2;
            //Decimal Csyouhigak_3;
            //Decimal Cwk_syohigaku;
            String strWK_CODE6;
            //Decimal Cwk_syohigaku_2;
            //消費税対応 2013/10/02 add HLC H.Watabe start
            Decimal befTaxRate;
            List<decimal> taxRateList = new List<decimal>();
            List<decimal> initList = new List<decimal>();
            List<List<decimal>> tvTaxRateList = new List<List<decimal>>();
            List<List<decimal>> rdTaxRateList = new List<List<decimal>>();
            List<List<decimal>> etcTaxRateList = new List<List<decimal>>();
            decimal tvTaxRate = 0;
            decimal rdTaxRate = 0;
            decimal etcTaxRate = 0;
            //消費税対応 2013/10/02 add HLC H.Watabe end

            Decimal Csougak;
            Decimal Csougak_1;
            Decimal Csougak_2;
            Decimal Csougak_3;
            Decimal Cwk_sougaku;
            Decimal Cwk_sougaku_2;

            //消費税合計.
            Csyouhigak = 0;
            //Csyouhigak_1 = 0;
            //Csyouhigak_2 = 0;
            //Csyouhigak_3 = 0;

            //Cwk_syohigaku = 0;
            //Cwk_syohigaku_2 = 0;

            Csougak = 0;
            Csougak_1 = 0;
            Csougak_2 = 0;
            Csougak_3 = 0;

            Cwk_sougaku = 0;
            Cwk_sougaku_2 = 0;

            //消費税対応 2013/10/02 add HLC H.Watabe start
            FDDSLion.FDLionResultRow[] sortTaxRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "syouhizeiritu");
            if (sortTaxRows.Length != 0)
            {
                taxRateList.Add(KKHUtility.DecParse(sortTaxRows[0].syouhizeiritu));
                initList.Add(0);
                befTaxRate = KKHUtility.DecParse(sortTaxRows[0].syouhizeiritu);
                //消費税リストを作成する.
                foreach (FDDSLion.FDLionResultRow sortTaxRow in sortTaxRows)
                {
                    if (befTaxRate != KKHUtility.DecParse(sortTaxRow.syouhizeiritu))
                    {
                        taxRateList.Add(KKHUtility.DecParse(sortTaxRow.syouhizeiritu));
                    }

                    befTaxRate = KKHUtility.DecParse(sortTaxRow.syouhizeiritu);
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
            //消費税対応 2013/10/02 add HLC H.Watabe end

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "kadono");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                strWK_CODE6 = "";
                if (!String.IsNullOrEmpty(resultRow.kadoNo))
                {
                    strWK_CODE6 = resultRow.kadoNo.Trim();
                }

                //テレビ,
                if (String.Equals(strWK_CODE6, "001") || String.Equals(strWK_CODE6, "002"))
                {
                    if (strWK_CODE6.Trim() == "001")
                    {
                        //消費税対応 2013/10/02 add HLC H.Watabe start
                        int index = 0;
                        foreach(decimal taxRate in tvTaxRateList[0])
                        {
                            if (taxRate == KKHUtility.DecParse(resultRow.syouhizeiritu))
                            {
                                tvTaxRateList[1][index] = KKHUtility.DecParse(resultRow.seikyuu);
                                break;
                            }
                            index++;
                        }
                        //Cwk_syohigaku = KKHUtility.DecParse(resultRow.syouhi);

                        //Cwk_sougaku = KKHUtility.DecParse(resultRow.seikyuu);
                        Cwk_sougaku = Cwk_sougaku + KKHUtility.DecParse(resultRow.seikyuu);
                        //消費税対応 2013/10/02 add HLC H.Watabe end
                    }
                    else
                    {
                        //消費税対応 2013/10/02 add HLC H.Watabe start
                        int index = 0;
                        foreach (decimal taxRate in tvTaxRateList[0])
                        {
                            if (taxRate == KKHUtility.DecParse(resultRow.syouhizeiritu))
                            {
                                tvTaxRateList[1][index] = tvTaxRateList[1][index] + KKHUtility.DecParse(resultRow.seikyuu);
                                break;
                            }
                            index++;
                        }
                        //カードNo 001と002の合計で消費税計算.
                        //Cwk_syohigaku = Cwk_syohigaku + KKHUtility.DecParse(resultRow.syouhi);

                        Cwk_sougaku = Cwk_sougaku + KKHUtility.DecParse(resultRow.seikyuu);
                        //消費税対応 2013/10/02 add HLC H.Watabe end
                    }
                }
                //ラジオ.
                else if (String.Equals(strWK_CODE6, "003") || String.Equals(strWK_CODE6, "004"))
                {
                    if (strWK_CODE6.Trim() == "003")
                    {
                        //消費税対応 2013/10/02 add HLC H.Watabe start
                        int index = 0;
                        foreach (decimal taxRate in rdTaxRateList[0])
                        {
                            if (taxRate == KKHUtility.DecParse(resultRow.syouhizeiritu))
                            {
                                rdTaxRateList[1][index] = KKHUtility.DecParse(resultRow.seikyuu);
                                break;
                            }
                            index++;
                        }
                        //Cwk_syohigaku_2 = KKHUtility.DecParse(resultRow.syouhi);

                        Cwk_sougaku_2 = KKHUtility.DecParse(resultRow.seikyuu);
                        //消費税対応 2013/10/02 add HLC H.Watabe end
                    }
                    else
                    {
                        //消費税対応 2013/10/02 add HLC H.Watabe start
                        int index = 0;
                        foreach (decimal taxRate in rdTaxRateList[0])
                        {
                            if (taxRate == KKHUtility.DecParse(resultRow.syouhizeiritu))
                            {
                                rdTaxRateList[1][index] = rdTaxRateList[1][index] + KKHUtility.DecParse(resultRow.seikyuu);
                                break;
                            }
                            index++;
                        }
                        //カードNo 003と004の合計で消費税計算.
                        //Cwk_syohigaku_2 = Cwk_syohigaku_2 + KKHUtility.DecParse(resultRow.syouhi);

                        Cwk_sougaku_2 = Cwk_sougaku_2 + KKHUtility.DecParse(resultRow.seikyuu);
                        //消費税対応 2013/10/02 add HLC H.Watabe end
                    }
                }
                //テレビ、ラジオ以外.
                else
                {
                    //消費税計(ブランド計、代理店計）.
                    //Csyouhigak_3 = Csyouhigak_3 + KKHUtility.DecParse(resultRow.syouhi);
                    //消費税対応 2013/10/02 add HLC H.Watabe start
                    int index = 0;
                    foreach (decimal taxRate in etcTaxRateList[0])
                    {
                        if (taxRate == KKHUtility.DecParse(resultRow.syouhizeiritu))
                        {
                            etcTaxRateList[1][index] = etcTaxRateList[1][index] + Math.Truncate(KKHUtility.DecParse(resultRow.seikyuu) * taxRate);
                            break;
                        }
                        index++;
                    }
                    //Csyouhigak_3 = Csyouhigak_3 + Math.Truncate(KKHUtility.DecParse(resultRow.seikyuu) * _taxRate);

                    Csougak_3 = Csougak_3 + KKHUtility.DecParse(resultRow.seikyuu);
                    //消費税対応 2013/10/02 add HLC H.Watabe end
                }
            }

            //テレビとラジオの消費税計算.
            //Csyouhigak_1 = Math.Truncate(Cwk_syohigaku);
            //Csyouhigak_2 = Math.Truncate(Cwk_syohigaku_2);

            //消費税対応 2013/10/02 add HLC H.Watabe start
            for (int index = 0; index < taxRateList.Count; index++)
            {
                tvTaxRate = tvTaxRate + Math.Truncate((tvTaxRateList[1][index] * tvTaxRateList[0][index]));
                rdTaxRate = rdTaxRate + Math.Truncate((rdTaxRateList[1][index] * rdTaxRateList[0][index]));
                //etcTaxRate = etcTaxRate + Math.Truncate((etcTaxRateList[1][index] * etcTaxRateList[0][index]));
                etcTaxRate = etcTaxRate + Math.Truncate(etcTaxRateList[1][index]);
            }
            //Csyouhigak_1 = Math.Truncate(Cwk_sougaku * _taxRate);
            //Csyouhigak_2 = Math.Truncate(Cwk_sougaku_2 * _taxRate);
            //消費税対応 2013/10/02 add HLC H.Watabe end

            Csougak_1 = Math.Truncate(Cwk_sougaku);
            Csougak_2 = Math.Truncate(Cwk_sougaku_2);

            if (view.FDLionView.Count != 0)
            {
                //消費税合計.
                //消費税対応 2013/10/02 add HLC H.Watabe start
                //Csyouhigak = Csyouhigak_1 + Csyouhigak_2 + Csyouhigak_3;
                Csyouhigak = tvTaxRate + rdTaxRate + etcTaxRate;
                //消費税対応 2013/10/02 add HLC H.Watabe end

                //カードNo
                viewRow.cKKdNo = "010";
                //年月.
                viewRow.cKYYMM = strYYYYMM;
                //代理店CD
                viewRow.cKDairitencd = AgencyCd;
                //媒体区分.
                viewRow.cKBaitaicd = "50";
                //番組CD空白をセット.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = "9000";

                //ブランド名称.
//              viewRow.cKBrandName = "その他";

                MastLion.BrandLionRow[] brandName = (MastLion.BrandLionRow[])_lionMast.BrandLion.Select("Column1 = '" + "9000" + "'", "");

                if (( brandName.Length != 0 ) && ( !brandName[0].IsColumn2Null() ))
                {
                    viewRow.cKBrandName = brandName[0].Column2;
                }
                else
                {
                    viewRow.cKBrandName = "";
                }

                //局誌CD
                viewRow.cKKyokusicd = "";
                //局誌名称.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CDに空白を入れる.
                viewRow.cKfukencd = "";
                //電波料(値引率込)
                viewRow.cKDenpa = "";
                //ネット料空白.
                viewRow.cKNet = "";
                //制作費空白.
                viewRow.cKSeisaku = "";
                //請求額・予算.
                viewRow.cKSeikyu = Csyouhigak.ToString();
                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //秒数・源泉税区分.
                viewRow.cKByousu_Gensen = "";
                //空白を入力.
                viewRow.cKGensenzeien = "";
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21".Trim();

                //スプレッドに表示する.
                view.FDLionView.AddFDLionViewRow(viewRow);

                Csougak = Csougak_1 + Csougak_2 + Csougak_3;
            }

            // 引数の戻りに合計額を設定する.
            totalAmout = Csougak + Csyouhigak;
        }

        /// <summary>
        /// 制作をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        /// <param name="totalAmount"></param>
        private void putSEISAKU(FindFDLionByCondServiceResult result, String strYYYYMM, FDDSLion view, out Decimal totalAmount)
        {
            Decimal lWorksyouhi;    //制作消費税用変数.
            Decimal lWorksyouhiT;   //制作消費税用変数(タレント用)
            String sBrandCd;        //旧ブランドＣＤを保存.
            String sBaitaicd;       //旧媒体ＣＤを保存.
            Decimal cSeikyu;        //制作請求.
            Decimal Csougak;
            Decimal Csyouhigak;

            lWorksyouhi = 0m;
            lWorksyouhiT = 0m;
            sBrandCd = null;
            sBaitaicd = null;
            cSeikyu = 0m;
            Csougak = 0m;
            Csyouhigak = 0m;

            FDDSLion.FDLionResultRow[] resultRows = (FDDSLion.FDLionResultRow[])result.dsFDLion.FDLionResult.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();
            FDDSLion.FDLionViewRow viewRowCopy = view.FDLionView.NewFDLionViewRow();　//旧検索結果を保存.

            foreach (FDDSLion.FDLionResultRow resultRow in resultRows)
            {
                if (sBrandCd != null)
                {
                    if ((String.Equals(resultRow.brandcd.Trim(), sBrandCd))
                        && (String.Equals(sBaitaicd, resultRow.baitaicd.Trim())))
                    {
                        //ブランドコード、媒体コードが旧と同じであれば旧検索結果を削除する.
                        view.FDLionView.RemoveFDLionViewRow(viewRowCopy);
                        viewRow = view.FDLionView.NewFDLionViewRow();
                    }
                }

                //先頭データの時ブランドコード取得.
                if (sBrandCd == null)
                {
                    sBrandCd = resultRow.brandcd.Trim();
                    sBaitaicd = resultRow.baitaicd.Trim();
                }

                //ブランドブレーク.
                if (!String.Equals(resultRow.brandcd.Trim(), sBrandCd))
                {
                    if (lWorksyouhi != 0)
                    {
                        //カードNo
                        viewRow.cKKdNo = "012";
                        //年月.
                        viewRow.cKYYMM = strYYYYMM;
                        //代理店CD
                        viewRow.cKDairitencd = AgencyCd;
                        //媒体区分.
                        viewRow.cKBaitaicd = "40";
                        sBaitaicd = "40";
                        //請求額・予算.
                        viewRow.cKSeikyu = Decimal.ToInt32(lWorksyouhi).ToString();
                        //番組CD空白を入れる.
                        viewRow.cKBangumicd = "";
                        //ブランドCD
                        viewRow.cKBrandcd = sBrandCd;
                        //ブランド名称.
                        viewRow.cKBrandName = "";
                        //局誌CD空白を入れる.
                        viewRow.cKKyokusicd = "";
                        //局誌名称.
                        viewRow.cKKyokusiName = "";
                        //ネットFC空白を入れる.
                        viewRow.cKNetfc = "";
                        //府県CD空白を入れる.
                        viewRow.cKfukencd = "";
                        //電波料.
                        viewRow.cKDenpa = "";
                        //ネット料.
                        viewRow.cKNet = "";
                        //制作費.
                        viewRow.cKSeisaku = "";
                        //合計.
                        viewRow.cKGoukei = "";
                        //総秒数.
                        viewRow.cKSoubyousu = "";
                        //制作費(012)
                        //源泉税区分.
                        viewRow.cKByousu_Gensen = "";
                        //源泉税円.
                        viewRow.cKGensenzeien = "";
                        //雑広告消費税額.
                        viewRow.cKZatukoukoku = "";
                        //オンエア回数.
                        viewRow.cKOnea = "";
                        //データ処理CD
                        viewRow.cKDetacd = "21";

                        // 消費税額の加算.
                        Csyouhigak += lWorksyouhi;

                        view.FDLionView.AddFDLionViewRow(viewRow);
                        viewRow = view.FDLionView.NewFDLionViewRow();
                    }

                    //

                    if (lWorksyouhiT != 0)
                    {
                        //カードNo
                        viewRow.cKKdNo = "012";
                        //年月.
                        viewRow.cKYYMM = strYYYYMM;
                        //代理店CD
                        viewRow.cKDairitencd = AgencyCd;
                        //媒体区分.
                        viewRow.cKBaitaicd = "41";
                        sBaitaicd = "41";
                        //請求額・予算(タレント)
                        viewRow.cKSeikyu = Decimal.ToInt32(lWorksyouhiT).ToString();
                        //番組CD空白を入れる.
                        viewRow.cKBangumicd = "";
                        //ブランドCD
                        viewRow.cKBrandcd = sBrandCd;
                        //ブランド名称.
                        viewRow.cKBrandName = "";
                        //局誌CD空白を入れる.
                        viewRow.cKKyokusicd = "";
                        //局誌名称.
                        viewRow.cKKyokusiName = "";
                        //ネットFC空白を入れる.
                        viewRow.cKNetfc = "";
                        //府県CD空白を入れる.
                        viewRow.cKfukencd = "";
                        //電波料.
                        viewRow.cKDenpa = "";
                        //ネット料.
                        viewRow.cKNet = "";
                        //制作費.
                        viewRow.cKSeisaku = "";
                        //合計.
                        viewRow.cKGoukei = "";
                        //総秒数.
                        viewRow.cKSoubyousu = "";
                        //制作費(012)
                        //源泉税区分.
                        viewRow.cKByousu_Gensen = "";
                        //源泉税円.
                        viewRow.cKGensenzeien = "";
                        //雑広告消費税額.
                        viewRow.cKZatukoukoku = "";
                        //オンエア回数.
                        viewRow.cKOnea = "";
                        //データ処理CD
                        viewRow.cKDetacd = "21";

                        // 消費税額の加算.
                        Csyouhigak += lWorksyouhiT;

                        view.FDLionView.AddFDLionViewRow(viewRow);
                        viewRow = view.FDLionView.NewFDLionViewRow();
                    }

                    lWorksyouhi = 0;
                    lWorksyouhiT = 0;
                    //ブランドをセット.
                    sBrandCd = resultRow.brandcd.Trim();
                    sBaitaicd = null;
                }

                //

                if (!String.Equals(sBaitaicd, resultRow.baitaicd.Trim()))
                {
                    cSeikyu = 0.0m;
                }

                //請求額.
                cSeikyu = cSeikyu + KKHUtility.DecParse(resultRow.seikyuu);

                //カードNo
                viewRow.cKKdNo = resultRow.kadoNo.Trim();
                //年月.
                viewRow.cKYYMM = resultRow.nentuki.Trim();
                //代理店CD
                viewRow.cKDairitencd = resultRow.dairitencd.Trim().ToString();
                //媒体区分.
                viewRow.cKBaitaicd = resultRow.baitaicd.Trim().ToString();
                //番組CD空白を入れる.
                viewRow.cKBangumicd = "";
                //ブランドCD
                viewRow.cKBrandcd = resultRow.brandcd.Trim().ToString();
                //ブランド名称.
                viewRow.cKBrandName = resultRow.brandName.Trim().ToString();
                //局誌CD空白を入れる.
                viewRow.cKKyokusicd = "";
                //局誌名称.
                viewRow.cKKyokusiName = "";
                //ネットFC空白を入れる.
                viewRow.cKNetfc = "";
                //府県CD空白を入れる.
                viewRow.cKfukencd = "";
                //電波料.
                viewRow.cKDenpa = "";
                //ネット料.
                viewRow.cKNet = "";
                //制作費.
                viewRow.cKSeisaku = "";
                //請求額・媒体消費税額を分ける.
                if (String.Equals(resultRow.kadoNo.Trim().ToString(), "012"))
                {
                    if (
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "20") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "21") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "23") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "24") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "25") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "27") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "29") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "33") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "35") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "36") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "37") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "38") ||
                        String.Equals(resultRow.baitaicd.Trim().ToString(), "39")
                    )
                    {
                        //消費税計算用.
                        if (!String.Equals(resultRow.syouhizeigaku.Trim(), ""))
                        {
                            lWorksyouhi = lWorksyouhi + KKHUtility.DecParse(resultRow.syouhizeigaku);
                        }

                        //請求額・予算.
                        viewRow.cKSeikyu = cSeikyu.ToString();

                        // 総額の加算.
                        Csougak += cSeikyu;
                    }
                    //タレント.
                    else if (String.Equals(resultRow.baitaicd.Trim().ToString(), "31"))
                    {
                        //消費税計算用(タレント)
                        if (!String.Equals(resultRow.syouhizeigaku.Trim(), ""))
                        {
                            lWorksyouhiT = lWorksyouhiT + KKHUtility.DecParse(resultRow.syouhizeigaku);
                        }

                        //請求額・予算.
                        viewRow.cKSeikyu = cSeikyu.ToString();

                        // 総額の加算.
                        Csougak += cSeikyu;
                    }
                }

                //合計.
                viewRow.cKGoukei = "";
                //総秒数.
                viewRow.cKSoubyousu = "";
                //源泉税区分.
                viewRow.cKByousu_Gensen = resultRow.gensen.Trim();
                //源泉税円.
                viewRow.cKGensenzeien = Math.Truncate(KKHUtility.DecParse(resultRow.denpa)).ToString();
                //雑広告消費税額.
                viewRow.cKZatukoukoku = "";
                //オンエア回数.
                viewRow.cKOnea = "";
                //データ処理CD
                viewRow.cKDetacd = "21";
                sBaitaicd = resultRow.baitaicd.Trim();

                //検索結果を取得する.
                view.FDLionView.AddFDLionViewRow(viewRow);
                //検索結果をコピーして初期化.
                viewRowCopy = viewRow;
                viewRow = view.FDLionView.NewFDLionViewRow();
            }

            //データが無ければ入らない.
            if (view.FDLionView.Count != 0)
            {
                if (lWorksyouhi != 0)
                {
                    //カードNo
                    viewRow.cKKdNo = "012";
                    //年月.
                    viewRow.cKYYMM = strYYYYMM;
                    //代理店CD
                    viewRow.cKDairitencd = AgencyCd;
                    //媒体区分.
                    viewRow.cKBaitaicd = "40";
                    //請求額・予算.
                    viewRow.cKSeikyu = Decimal.ToInt32(lWorksyouhi).ToString();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd;
                    //ブランド名称.
                    viewRow.cKBrandName = "";
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //制作費(012)
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";

                    // 消費税額の加算.
                    Csyouhigak += lWorksyouhi;

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }

                //

                if (lWorksyouhiT != 0)
                {
                    //カードNo
                    viewRow.cKKdNo = "012";
                    //年月.
                    viewRow.cKYYMM = strYYYYMM;
                    //代理店CD
                    viewRow.cKDairitencd = AgencyCd;
                    //媒体区分.
                    viewRow.cKBaitaicd = "41";
                    //請求額・予算(タレント)
                    viewRow.cKSeikyu = Decimal.ToInt32(lWorksyouhiT).ToString();
                    //番組CD空白を入れる.
                    viewRow.cKBangumicd = "";
                    //ブランドCD
                    viewRow.cKBrandcd = sBrandCd;
                    //ブランド名称.
                    viewRow.cKBrandName = "";
                    //局誌CD空白を入れる.
                    viewRow.cKKyokusicd = "";
                    //局誌名称.
                    viewRow.cKKyokusiName = "";
                    //ネットFC空白を入れる.
                    viewRow.cKNetfc = "";
                    //府県CD空白を入れる.
                    viewRow.cKfukencd = "";
                    //電波料.
                    viewRow.cKDenpa = "";
                    //ネット料.
                    viewRow.cKNet = "";
                    //制作費.
                    viewRow.cKSeisaku = "";
                    //合計.
                    viewRow.cKGoukei = "";
                    //総秒数.
                    viewRow.cKSoubyousu = "";
                    //制作費(012)
                    //源泉税区分.
                    viewRow.cKByousu_Gensen = "";
                    //源泉税円.
                    viewRow.cKGensenzeien = "";
                    //雑広告消費税額.
                    viewRow.cKZatukoukoku = "";
                    //オンエア回数.
                    viewRow.cKOnea = "";
                    //データ処理CD
                    viewRow.cKDetacd = "21";

                    // 消費税額の加算.
                    Csyouhigak += lWorksyouhiT;

                    //検索結果を取得する.
                    view.FDLionView.AddFDLionViewRow(viewRow);
                    viewRow = view.FDLionView.NewFDLionViewRow();
                }
            }

            // 引数の戻りに合計額を設定する.
            totalAmount = Csougak + Csyouhigak;
        }

        /// <summary>
        /// ラジオCM秒数をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        /// <param name="strCMChk"></param>
        private void putCMRD(MastLion.RdCmLionDataTable result, String strYYYYMM, FDDSLion view, List<CMTimeData> strCMChk)
        {
            MastLion.RdCmLionRow[] resultRows = (MastLion.RdCmLionRow[])result.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (MastLion.RdCmLionRow resultRow in result) // ファイルの終端までループを繰り返します。.
            {
                viewRow.cKKdNo = resultRow.CardKbn.Trim();
                viewRow.cKYYMM = resultRow.YearMonth.Trim();
                viewRow.cKDairitencd = resultRow.DairitenCd.Trim();
                viewRow.cKBaitaicd = resultRow.baitaiKbn.Trim();
                viewRow.cKBangumicd = resultRow.BangumiCd.Trim();
                viewRow.cKBrandcd = resultRow.BrandCd.Trim();
                viewRow.cKBrandName = resultRow.BrandName.Trim();
                viewRow.cKKyokusicd = resultRow.KyokusiCd.Trim();
                viewRow.cKKyokusiName = resultRow.KyokusiName.Trim();
                viewRow.cKNetfc = resultRow.NetFc.Trim();
                viewRow.cKfukencd = resultRow.FukenCd.Trim();
                viewRow.cKDenpa = resultRow.Val1.Trim();
                viewRow.cKNet = resultRow.Val2.Trim();
                viewRow.cKSeisaku = resultRow.Val3.Trim();
                viewRow.cKSeikyu = resultRow.Val4.Trim();
                viewRow.cKGoukei = resultRow.Gokei.Trim();

                viewRow.cKSoubyousu = "";

                if (resultRow.Sobyosu != 0)
                {
                    viewRow.cKSoubyousu = resultRow.Sobyosu.ToString().Trim();
                }

                viewRow.cKByousu_Gensen = resultRow.Byosu.ToString().Trim();
                viewRow.cKGensenzeien = resultRow.Val5.Trim();
                viewRow.cKZatukoukoku = resultRow.Val6.Trim();
                viewRow.cKOnea = resultRow.OnAirKaisu.Trim();
                viewRow.cKDetacd = resultRow.DataSyoriCd.Trim();

                CMTimeData strCMChkItem = new CMTimeData();

                //カードNo
                strCMChkItem.CardNo = viewRow.cKKdNo.Trim();
                //番組コード.
                strCMChkItem.BangumiCd = viewRow.cKBangumicd.Trim();
                //ブランドコード.
                strCMChkItem.BrandCd = viewRow.cKBrandcd.Trim();
                //局誌コード.
                strCMChkItem.KyokusiCd = viewRow.cKKyokusicd.Trim();
                //総秒数.
                strCMChkItem.TotalTimes = viewRow.cKSoubyousu.Trim();
                //秒数.
                strCMChkItem.Times = viewRow.cKByousu_Gensen.Trim();

                strCMChk.Add(strCMChkItem);

                //行を1アップする.
                view.FDLionView.AddFDLionViewRow(viewRow);
                viewRow = view.FDLionView.NewFDLionViewRow();
            }
        }

        /// <summary>
        /// テレビCM秒数をビューに出力する.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="strYYYYMM"></param>
        /// <param name="view"></param>
        /// <param name="strCMChk"></param>
        private void putCMTV(MastLion.TvCmLionDataTable result, String strYYYYMM, FDDSLion view, List<CMTimeData> strCMChk)
        {
            MastLion.TvCmLionRow[] resultRows = (MastLion.TvCmLionRow[])result.Select("", "");

            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            foreach (MastLion.TvCmLionRow resultRow in result) // ファイルの終端までループを繰り返します。.
            {
                viewRow.cKKdNo = resultRow.CardKbn.Trim();
                viewRow.cKYYMM = resultRow.YearMonth.Trim();
                viewRow.cKDairitencd = resultRow.DairitenCd.Trim();
                viewRow.cKBaitaicd = resultRow.baitaiKbn.Trim();
                viewRow.cKBangumicd = resultRow.BangumiCd.Trim();
                viewRow.cKBrandcd = resultRow.BrandCd.Trim();
                viewRow.cKBrandName = resultRow.BrandName.Trim();
                viewRow.cKKyokusicd = resultRow.KyokusiCd.Trim();
                viewRow.cKKyokusiName = resultRow.KyokusiName.Trim();
                viewRow.cKNetfc = resultRow.NetFc.Trim();
                viewRow.cKfukencd = resultRow.FukenCd.Trim();
                viewRow.cKDenpa = resultRow.Val1.Trim();
                viewRow.cKNet = resultRow.Val2.Trim();
                viewRow.cKSeisaku = resultRow.Val3.Trim();
                viewRow.cKSeikyu = resultRow.Val4.Trim();
                viewRow.cKGoukei = resultRow.Gokei.Trim();

                viewRow.cKSoubyousu = "";

                if (resultRow.Sobyosu != 0)
                {
                    viewRow.cKSoubyousu = resultRow.Sobyosu.ToString().Trim();
                }

                viewRow.cKByousu_Gensen = resultRow.Byosu.ToString().Trim();
                viewRow.cKGensenzeien = resultRow.Val5.Trim();
                viewRow.cKZatukoukoku = resultRow.Val6.Trim();
                viewRow.cKOnea = resultRow.OnAirKaisu.Trim();
                viewRow.cKDetacd = resultRow.DataSyoriCd.Trim();

                CMTimeData strCMChkItem = new CMTimeData();

                //カードNo
                strCMChkItem.CardNo = viewRow.cKKdNo.Trim();
                //番組コード.
                strCMChkItem.BangumiCd = viewRow.cKBangumicd.Trim();
                //ブランドコード.
                strCMChkItem.BrandCd = viewRow.cKBrandcd.Trim();
                //局誌コード.
                strCMChkItem.KyokusiCd = viewRow.cKKyokusicd.Trim();
                //総秒数.
                strCMChkItem.TotalTimes = viewRow.cKSoubyousu.Trim();
                //秒数.
                strCMChkItem.Times = viewRow.cKByousu_Gensen.Trim();

                strCMChk.Add(strCMChkItem);

                //行を1アップする.
                view.FDLionView.AddFDLionViewRow(viewRow);
                viewRow = view.FDLionView.NewFDLionViewRow();
            }
        }

        /// <summary>
        /// 合計金額をビューに出力する.
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="view"></param>
        private void putTotalAmount(Decimal totalAmount, FDDSLion view)
        {
            FDDSLion.FDLionViewRow viewRow = view.FDLionView.NewFDLionViewRow();

            //カードNo
            viewRow.cKKdNo = "";
            //年月.
            viewRow.cKYYMM = "";
            //代理店CD
            viewRow.cKDairitencd = "";
            //媒体区分.
            viewRow.cKBaitaicd = "";
            //番組CD空白をセット.
            viewRow.cKBangumicd = "";
            //ブランドCD
            viewRow.cKBrandcd = "";
            //ブランド名称.
            viewRow.cKBrandName = "合計（消費税込み）";
            //局誌CD
            viewRow.cKKyokusicd = "";
            //局誌名称.
            viewRow.cKKyokusiName = "";
            //ネットFC空白を入れる.
            viewRow.cKNetfc = "";
            //府県CDに空白を入れる.
            viewRow.cKfukencd = "";
            //電波料(値引率込)
            viewRow.cKDenpa = "";
            //ネット料空白.
            viewRow.cKNet = "";
            //制作費空白.
            viewRow.cKSeisaku = "";
            //請求額・予算.
            viewRow.cKSeikyu = totalAmount.ToString();
            //合計.
            viewRow.cKGoukei = "";
            //総秒数.
            viewRow.cKSoubyousu = "";
            //秒数・源泉税区分.
            viewRow.cKByousu_Gensen = "";
            //空白を入力.
            viewRow.cKGensenzeien = "";
            //雑広告消費税額.
            viewRow.cKZatukoukoku = "";
            //オンエア回数.
            viewRow.cKOnea = "";
            //データ処理CD
            viewRow.cKDetacd = "";

            //スプレッドに表示する.
            view.FDLionView.AddFDLionViewRow(viewRow);
        }

        /// <summary>
        /// エラーチェックを行う.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="strCMChk"></param>
        private void checkAllData( FarPoint.Win.Spread.SheetView view, List<CMTimeData> strCMChk )
        {
            int lRowCnt;            // スプレッド行カウンタ.
            String strWErrflg;      // エラーフラグ.

            // カレント行の各項目.
            String wkKdNo;          // カードNO
            String wkYYMM;          // データ日付.
            String wkDairitencd;    // 代理店CD
            String wkBaitaicd;      // 媒体区分.
            String wkBangumicd;     // 番組CD
            String wkBrandcd;       // ブランドCD
            String wkKyokusicd;     // 局誌CD
            String wkNetfc;         // ネットFC
            Decimal wkDenpa;        // 電波料.
            Decimal wkNet;          // ネット料.
            Decimal wkSeisaku;      // 制作費.
            Decimal wkSeikyu;       // 請求額.
            long wkSoubyousu;       // 総秒数.
            long wkByousu_Gensen;   // 秒数・源泉税区分.
            String wkDetacd;        // データ処理CD
            String wkAreacd;        // 府県CD

            // MISAM用.
            String strKey;          // キー.

            // エラー区分 W チェック用  チェックNo.1①.
            Hashtable cDupChk = new Hashtable();    // ダブリチェック用.

            //  キー         データ    キーは､カードNo+データ日付+ ･･･ +データ処理コード(ダブリチェック対象の項目をすべて連結したもの)
            // ┌─────┬──┐    スプレッドの１行目から順に登録していく。.
            // │連結文字列│行数│    もしダブっていれば cDupChk.Add はエラーを返す。.
            // ├─────┼──┤    ダブった元の行もそのキーで判別できるので、そのキーで行数を得てそこの行もエラー表示できる。.
            // │0010001001│  5 │.
            // ├─────┼──┤(例)スプレッドの8行目のキーが 0010001002 の場合、図中にすでに該当がある。.
            // │0010001002│  3 │    よって、8行目はダブリエラーである。.
            // └─────┴──┘    また、ダブリ元はスプレッドの3行目なので、3行目もダブリエラーとする。.

            // エラー区分 S チェック用  個別存在チェック.
            Hashtable cTblBaitai = new Hashtable();     // 媒体区分.
            Hashtable cTblBangumi = new Hashtable();    // 番組コード.
            Hashtable cTblBrand = new Hashtable();      // ブランドコード.
            Hashtable cTblKyoku = new Hashtable();      // 局誌コード.
            Hashtable cTblMedia = new Hashtable();      // 局誌コード.
            Hashtable cTblNetFC = new Hashtable();      // ネットFCコード.
            Hashtable cTblArea = new Hashtable();       // 府県コード.
            Hashtable cTblInterNet = new Hashtable();   // インターネット局誌コード.
            Hashtable cTblMobile = new Hashtable();     // モバイル局誌コード.

            // キー             キーは､それぞれチェックしたい○○コードとする。データはなしとする。.
            //┌─────┐    DB取得したテーブルからコピーしておく。.
            //│番組コード│    スプレッドの1行目から順に、.Find してエラーなら該当なしである｡.
            //├─────┤    該当がなければその行にエラーを設定する。.
            //│101       │.
            //├─────┤(例)スプレッドの1行目のキーが 710 の場合、図中に該当がない。.
            //│106       │    よって、1行目は未登録エラーである。.
            //└─────┘.

            // エラー区分 L チェック用.
            Hashtable cTblPrCost = new Hashtable(); // 制作費 チェックNo2①②用.
            // キー                  データ    キーは､カードNO+番組コード.
            //┌──────────┬──┐  スプレッドの1行目から順に、制作費のある行について .Add していく。.
            //│カードNO+番組コード │行数│  1回目のループで .Add がエラーになれば②ダブリエラーである。.
            //├──────────┼──┤  ダブリ元も同じく②ダブリエラーとする。.
            //│001101              │ 47 │  1回目のループで番組制作費のあるカードNO+番組コードがすべて登録される。.
            //├──────────┼──┤  2回目のループで、スプレッドの1行目から順に、.
            //│001106              │ 15 │  未登録なら①制作費なしエラーである。.
            //└──────────┴──┘.

            Hashtable cTblFCnot9 = new Hashtable(); // FCコード≠9 チェックNo2③用.
            // キー                     キーは､カードNO+番組コード、データはなしとする。.
            //┌──────────┐  スプレッドの1行目から順に、FCコードが //9//でないものを .Add していく。.
            //│カードNO+番組コード │  すべて //9// ならエラー、言い換えると、//9// 以外があればOKである。.
            //├──────────┤  1回目のループで .Add のエラーは無視する。（1つ登録されていれば良い。）.
            //│001101              │  2回目のループで、スプレッドの1行目から順に、.
            //├──────────┤  未登録なら//9// 以外がなかったことになり、エラーである。.
            //│001106              │.
            //└──────────┘.

            Hashtable cTblCM3 = new Hashtable();    // CM秒数 チェックNo.3①用.

            // キー                     キーは図のように、3種類が混在する。データはなしとする。.
            //┌─────────┐        (1).番組コード .......... 同一番組の初回登録を判断するため.
            //│番組コード        │        (2).番組コード+総秒数 ... 同一番組なのに総秒数が複数ありえる.
            //│番組コード+総秒数 │        (3).番組コード+// err// ... 総秒数の異なるものが存在する目印.
            //│番組コード+' err' │    (2)は複数存在する可能性がある。.
            //├─────────┤    (2)が複数存在した場合はエラーであるが、そのすべてを下記チェックNo.3②でも使用する。.
            //│106            (1)│    そのためエラーであることは(3)で判定し、(2)は下記チェックNo.3②のために保持しておく。.
            //├─────────┤.
            //│106 err        (3)│    1回目のループでスプレッドの1行目から順に上記を .Add していく。.
            //├─────────┤    2回目のループでスプレッドの1行目から順に番組コード+// err//が存在する行をエラーとする。.
            //│1063500        (2)│.
            //├─────────┤    1回目のループが終了したら (1),(2) は不要だが、削除していない。.
            //│1064200        (2)│.
            //└─────────┘.

            Hashtable cTblCM3G = new Hashtable();   // CM秒数 チェックNo.3②用.

            // キー                    データ     キーは図のように、2種類が混在する。.
            //┌─────────────┬──┐      (1).番組コード+ブランドコード ... 同一番組，同一商品の初回登録を判断するため.
            //│番組コード+ブランドコード │なし│      (2).番組コード ... ある番組の複数商品の秒数を合計する。.
            //│番組コード                │秒数│.
            //├─────────────┼──┤  1回目のループでスプレッドの1行目から順に(1)の初回登録時だけ(2)を .Plus していく。.
            //│101                    (2)│ 45 │  2回目のループでスプレッドの1行目から順に、上記 cTblCM3 (2) と.
            //├─────────────┼──┤  1回目のループで集計した cTblCM3G (2) が一致しなければエラーとする。.
            //│1012000                (1)│   0│.
            //└─────────────┴──┘  1回目のループが終了したら (1) は不要だが、削除していない。.

            Hashtable cTblCM4 = new Hashtable();    // CM秒数 チェックNo.4用.

            Hashtable cTblCM4_TvRdBSCS = new Hashtable();

            // キー          データなし   キーは､番組コード+局誌コード、データはなしとする。.
            //┌───────────┐  あらかじめ strCMChk テーブルから、カードNo //006// のものを .Add しておく。.
            //│番組コード+局誌コード │  スプレッドの1行目から順に、カードNoが //001//～//004//、かつ、データ処理コードが//21//の場合.
            //├───────────┤  該当がなければエラーである。.
            //│101128                │.
            //├───────────┤.
            //│106124                │.
            //└───────────┘.

            Hashtable cTblCM9 = new Hashtable();    // CM秒数 チェックNo.9用.

            // キー         データ    キーは､番組コード+局誌コード+ブランドコード+秒数.
            //┌─────┬──┐    スプレッドの1行目から順に .Add し、ダブったらエラーである。.
            //│連結文字列│行数│    ダブリ元も同じくダブリエラーとする。.
            //├─────┼──┤.
            //│1011280012│  1 │.
            //├─────┼──┤.
            //│1061242000│  2 │.
            //└─────┴──┘.

            //***エラー区分、チェック項目は全て「請求データチェック（ライオン）.pdf」参照.

            // エラー区分 S チェック用.

            // 媒体区分.
            foreach (BaitaiKbnData i in strBtKbn)
            {
                if (!cTblBaitai.Contains(i.BaitaiKbnCd))
                {
                    cTblBaitai.Add(i.BaitaiKbnCd, i.BaitaiKbnCd);
                }
            }

            // 番組コード.
            foreach (LionBangumiData i in strLionBangumi)
            {
                if (!cTblBangumi.Contains(i.BangumiCd))
                {
                    cTblBangumi.Add(i.BangumiCd, i.BangumiCd);
                }
            }

            // ブランドコード.
            foreach (BrandData i in strBrand)
            {
                if (!cTblBrand.Contains(i.BrandCd))
                {
                    cTblBrand.Add(i.BrandCd, i.BrandCd);
                }
            }

            // 局誌コード.
            foreach (LionKyokuData i in strLionKyoku)
            {
                if (!cTblKyoku.Contains(i.KyokuCd))
                {
                    cTblKyoku.Add(i.KyokuCd, i.KyokuCd);
                }
            }

            // 局誌コード.
            foreach (MediaData i in strMedia)
            {
                if (!cTblMedia.Contains(i.MediaCd))
                {
                    cTblMedia.Add(i.MediaCd, i.MediaCd);
                }
            }

            // ネットFCコード.
            foreach (LionBangumiData i in strLionBangumi)
            {
                if (!cTblNetFC.Contains(i.BangumiCd + Decimal.ToInt64(KKHUtility.DecParse(i.NetFc)).ToString()))
                {
                    cTblNetFC.Add(i.BangumiCd + Decimal.ToInt64(KKHUtility.DecParse(i.NetFc)).ToString(), i.BangumiCd + Decimal.ToInt64(KKHUtility.DecParse(i.NetFc)).ToString());
                }
            }

            // 府県コード.
            foreach (AreaData i in strArea)
            {
                if (!cTblArea.Contains(i.AreaCd))
                {
                    cTblArea.Add(i.AreaCd, i.AreaCd);
                }
            }

            // インターネット局誌コード.
            foreach (MediaData i in strInterNet)
            {
                if (!cTblInterNet.Contains(i.MediaCd))
                {
                    cTblInterNet.Add(i.MediaCd, i.MediaCd);
                }
            }

            // モバイル局誌コード.
            foreach (MediaData i in strMobile)
            {
                if (!cTblMobile.Contains(i.MediaCd))
                {
                    cTblMobile.Add(i.MediaCd, i.MediaCd);
                }
            }

            // エラー区分 L チェック用.

            // CM秒数.
            foreach (CMTimeData i in strCMChk )
            {
                if (String.Equals(i.CardNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    if( !cTblCM4.Contains( i.BangumiCd + i.KyokusiCd ) )
                    {
                        cTblCM4.Add(i.BangumiCd + i.KyokusiCd, i.BangumiCd + i.KyokusiCd); // 多重エラーは無視(データ不要)
                    }
                }
            }

            // 行ごとにチェック【１週目】.
            for (lRowCnt = 0; lRowCnt < ( view.Rows.Count - TOTAL_AMOUNT_ROWS ); lRowCnt++)
            {
                //エラーフラグ初期化.
                strWErrflg = "";

                // カレント行の各項目を取得.

                // カードNO
                wkKdNo = (String)view.Cells[lRowCnt, cKKdNo].Value;

                // データ日付.
                wkYYMM = (String)view.Cells[lRowCnt, cKYYMM].Value;

                // 代理店CD
                wkDairitencd = (String)view.Cells[lRowCnt, cKDairitencd].Value;

                // 媒体区分.
                wkBaitaicd = (String)view.Cells[lRowCnt, cKBaitaicd].Value;

                // 番組CD
                wkBangumicd = (String)view.Cells[lRowCnt, cKBangumicd].Value;

                // ブランドCD
                wkBrandcd = (String)view.Cells[lRowCnt, cKBrandcd].Value;

                // 局誌CD
                wkKyokusicd = (String)view.Cells[lRowCnt, cKKyokusicd].Value;

                // ネットFC
                wkNetfc = (String)view.Cells[lRowCnt, cKNetfc].Value;

                // 府県CD
                wkAreacd = (String)view.Cells[lRowCnt, cKfukencd].Value;

                // 電波料.
                wkDenpa = 0.0m;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKDenpa].Value))
                {
                    wkDenpa = KKHUtility.DecParse((String)view.Cells[lRowCnt, cKDenpa].Value);
                }

                // ネット料.
                wkNet = 0.0m;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKNet].Value))
                {
                    wkNet = KKHUtility.DecParse((String)view.Cells[lRowCnt, cKNet].Value);
                }

                // 制作費.
                wkSeisaku = 0.0m;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKSeisaku].Value))
                {
                    wkSeisaku = KKHUtility.DecParse((String)view.Cells[lRowCnt, cKSeisaku].Value);
                }

                // 請求額.
                wkSeikyu = 0.0m;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKSeikyu].Value))
                {
                    wkSeikyu = KKHUtility.DecParse((String)view.Cells[lRowCnt, cKSeikyu].Value);
                }

                // 総秒数.
                wkSoubyousu = 0;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKSoubyousu].Value))
                {
                    wkSoubyousu = long.Parse((String)view.Cells[lRowCnt, cKSoubyousu].Value);
                }

                // 秒数・源泉税区分.
                wkByousu_Gensen = 0;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKByousu_Gensen].Value))
                {
                    wkByousu_Gensen = long.Parse((String)view.Cells[lRowCnt, cKByousu_Gensen].Value);
                }

                // データ処理CD
                wkDetacd = (String)view.Cells[lRowCnt, cKDetacd].Value;

                //エラー区分:W
                //ダブリチェック.
                strKey = wkKdNo;                // カードNO
                strKey = strKey + wkYYMM;       // データ日付.
                strKey = strKey + wkDairitencd; // 代理店CD
                strKey = strKey + wkBaitaicd;   // 媒体区分.
                strKey = strKey + wkBangumicd;  // 番組コード.
                strKey = strKey + wkBrandcd;    // ブランドコード.
                strKey = strKey + wkKyokusicd;  // 局誌コード.
                strKey = strKey + wkAreacd;     // 府県コード.
                strKey = strKey + wkDetacd;     // データ処理コード.

                if (!cDupChk.Contains(strKey))
                {
                    cDupChk.Add(strKey, lRowCnt);
                }
                else
                {
                    // 既存ありならダブリ.
                    // エラーフラグ : W-WW
                    Set_Errflg(ref strWErrflg, ErrDouble, itmDouble, view, lRowCnt);

                    // ダブリ元もエラー表示にする.
                    // エラーフラグ : W-WW
                    Set_ErrflgOrg(ErrDouble, itmDouble, view, (int)cDupChk[strKey]);
                }

                //エラー区分:H
                //必須チェック(カードNo～媒体区分までは全カードNo共通チェック)
                // カードNo
                if (checkNullOrEmpty(wkKdNo))
                {
                    // エラーフラグ : H-01
                    Set_Errflg(ref strWErrflg, ErrEssential, itmCardNo, view, lRowCnt);
                }

                // データ日付.
                if (checkNullOrEmpty(wkYYMM))
                {
                    // エラーフラグ : H-04
                    Set_Errflg(ref strWErrflg, ErrEssential, itmDtYYYYMM, view, lRowCnt);
                }

                // 代理店CD
                if (checkNullOrEmpty(wkDairitencd))
                {
                    // エラーフラグ : H-05
                    Set_Errflg(ref strWErrflg, ErrEssential, itmAgencyCd, view, lRowCnt);
                }

                // 媒体区分.
                if (checkNullOrEmpty(wkBaitaicd))
                {
                    // エラーフラグ : H-02
                    Set_Errflg(ref strWErrflg, ErrEssential, itmMediaKbn, view, lRowCnt);
                }

                // データ処理コード.
                if (checkNullOrEmpty(wkDetacd))
                {
                    // エラーフラグ : H-03
                    Set_Errflg(ref strWErrflg, ErrEssential, itmDtTranCd, view, lRowCnt);
                }

                // テレビ(001)、ラジオ番組(ネット)(003)
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) || String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET))
                {
                    // 番組コード.
                    if (checkNullOrEmpty(wkBangumicd))
                    {
                        // エラーフラグ : H-06
                        Set_Errflg(ref strWErrflg, ErrEssential, itmProgramCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // ネットFC
                    if (checkNullOrEmpty(wkNetfc))
                    {
                        // エラーフラグ : H-16
                        Set_Errflg(ref strWErrflg, ErrEssential, itmNetFc, view, lRowCnt);
                    }

                    // 電波料.
                    if (wkDenpa == 0)
                    {
                        // エラーフラグ : H-12
                        Set_Errflg(ref strWErrflg, ErrEssential, itmDenpaPrc, view, lRowCnt);
                    }
                }
                // テレビ(002)、ラジオ番組(ローカル)(004)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL))
                {
                    // 番組コード.
                    if (checkNullOrEmpty(wkBangumicd))
                    {
                        // エラーフラグ : H-06
                        Set_Errflg(ref strWErrflg, ErrEssential, itmProgramCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 電波料.
                    if (wkDenpa == 0)
                    {
                        // エラーフラグ : H-12
                        Set_Errflg(ref strWErrflg, ErrEssential, itmDenpaPrc, view, lRowCnt);
                    }
                }
                // テレビスポット(005)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 電波料.
                    if (wkDenpa == 0)
                    {
                        // エラーフラグ : H-12
                        Set_Errflg(ref strWErrflg, ErrEssential, itmDenpaPrc, view, lRowCnt);
                    }

                    // 秒数.
                    if (wkByousu_Gensen == 0)
                    {
                        // エラーフラグ : H-11
                        Set_Errflg(ref strWErrflg, ErrEssential, itmTimes, view, lRowCnt);
                    }
                }
                // CM秒数表(006)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    // 番組コード.
                    if (checkNullOrEmpty(wkBangumicd))
                    {
                        // エラーフラグ : H-06
                        Set_Errflg(ref strWErrflg, ErrEssential, itmProgramCd, view, lRowCnt);
                    }

                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 秒数.
                    if (wkByousu_Gensen == 0)
                    {
                        // エラーフラグ : H-11
                        Set_Errflg(ref strWErrflg, ErrEssential, itmTimes, view, lRowCnt);
                    }

                    //ロジカルチェック.
                    // データ日付.
                    if (!wkYYMM.Equals(txtYm.Value))
                    {
                        // エラーフラグ : L-04
                        Set_Errflg(ref strWErrflg, ErrLogical, itmDtYYYYMM, view, lRowCnt);
                    }
                }
                // 新聞(007)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SINBN))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 掲載料(ネット料欄)
                    if (wkNet == 0)
                    {
                        // エラーフラグ : H-13
                        Set_Errflg(ref strWErrflg, ErrEssential, itmNetPrc, view, lRowCnt);
                    }
                }
                // 雑誌(008)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 掲載料(ネット料欄)
                    if (wkNet == 0)
                    {
                        // エラーフラグ : H-13
                        Set_Errflg(ref strWErrflg, ErrEssential, itmNetPrc, view, lRowCnt);
                    }
                }
                // 交通広告(009)、宣伝間接費(010)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_KOTU) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SONOTA))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 請求額.
                    if (wkSeikyu == 0)
                    {
                        // エラーフラグ : H-15
                        Set_Errflg(ref strWErrflg, ErrEssential, itmSeikyuPrc, view, lRowCnt);
                    }
                }
                // 制作費(012)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SEISAKU))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 請求額.
                    if (wkSeikyu == 0)
                    {
                        // エラーフラグ : H-15
                        Set_Errflg(ref strWErrflg, ErrEssential, itmSeikyuPrc, view, lRowCnt);
                    }
                }
                // BS･CS(016)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    // 番組コード.
                    if (checkNullOrEmpty(wkBangumicd))
                    {
                        // エラーフラグ : H-06
                        Set_Errflg(ref strWErrflg, ErrEssential, itmProgramCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 電波料.
                    if (wkDenpa == 0)
                    {
                        // エラーフラグ : H-12
                        Set_Errflg(ref strWErrflg, ErrEssential, itmDenpaPrc, view, lRowCnt);
                    }
                }
                // インターネット(017)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_INTERNET))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 作成料(ネット料欄)
                    if (wkNet == 0)
                    {
                        // エラーフラグ : H-13
                        Set_Errflg(ref strWErrflg, ErrEssential, itmNetPrc, view, lRowCnt);
                    }
                }
                // モバイル(018)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 局誌CD
                    if (checkNullOrEmpty(wkKyokusicd))
                    {
                        // エラーフラグ : H-07
                        Set_Errflg(ref strWErrflg, ErrEssential, itmKyokuCd, view, lRowCnt);
                    }

                    // 作成料(ネット料欄)
                    if (wkNet == 0)
                    {
                        // エラーフラグ : H-13
                        Set_Errflg(ref strWErrflg, ErrEssential, itmNetPrc, view, lRowCnt);
                    }
                }
                // チラシ(014)、サンプリング(015)、事業費(019)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CHIRASI) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SAMPLING) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    // ブランドコード.
                    if (checkNullOrEmpty(wkBrandcd))
                    {
                        // エラーフラグ : H-08
                        Set_Errflg(ref strWErrflg, ErrEssential, itmBrandCd, view, lRowCnt);
                    }

                    // 請求額.
                    if (wkSeikyu == 0)
                    {
                        // エラーフラグ : H-15
                        Set_Errflg(ref strWErrflg, ErrEssential, itmSeikyuPrc, view, lRowCnt);
                    }
                }

                // テレビ(ネット)(001)、テレビ(ローカル)(002)
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL))
                {
                    if (_errCMTVDateChk.Equals(true))
                    {
                        // エラーフラグ : L-CC
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardComb, view, lRowCnt);
                    }
                }
                // ラジオ番組(ネット)(003)、ラジオ番組(ローカル)(004)
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                         String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL))
                {
                    if (_errCMRDDateChk.Equals(true))
                    {
                        // エラーフラグ : L-CC
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardComb, view, lRowCnt);
                    }
                }

                //エラー区分:S
                //存在値チェック.
                // 代理店コード.
                if (!String.Equals(wkDairitencd, AgencyCd))
                {
                    // エラーフラグ : S-05
                    Set_Errflg(ref strWErrflg, ErrExist, itmAgencyCd, view, lRowCnt);
                }

                //媒体区分.
                if (checkNotExists(cTblBaitai, wkBaitaicd))
                {
                    // エラーフラグ : S-02
                    Set_Errflg(ref strWErrflg, ErrExist, itmMediaKbn, view, lRowCnt);
                }

                //番組コード.
                //カードNo = 001～004,006,016の場合、番組コード存在値チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    // 番組CD
                    if (checkNotExists(cTblBangumi, wkBangumicd))
                    {
                        // エラーフラグ : S-06
                        Set_Errflg(ref strWErrflg, ErrExist, itmProgramCd, view, lRowCnt);
                    }
                }

                //ブランドコード.
                //カードNo = 005～012,014,015,017,018,019の場合、ブランドコード存在値チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SINBN) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_KOTU) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SONOTA) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SEISAKU) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CHIRASI) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SAMPLING) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_INTERNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_MOBIL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    // ブランドコード.
                    if (checkNotExists(cTblBrand, wkBrandcd))
                    {
                        // エラーフラグ : S-08
                        Set_Errflg(ref strWErrflg, ErrExist, itmBrandCd, view, lRowCnt);
                    }
                }

                //局誌/媒体コード.
                //カードNo = 001～008,016～018の場合、局誌/媒体コード存在値チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    // 局誌コード.
                    if (checkNotExists(cTblKyoku, wkKyokusicd))
                    {
                        // エラーフラグ : S-07
                        Set_Errflg(ref strWErrflg, ErrExist, itmKyokuCd, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SINBN) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI))
                {
                    // 局誌コード.
                    if (checkNotExists(cTblMedia, wkKyokusicd))
                    {
                        // エラーフラグ : S-07
                        Set_Errflg(ref strWErrflg, ErrExist, itmKyokuCd, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    // 局誌コード.
                    if (checkNotExists(cTblMobile, wkKyokusicd))
                    {
                        // エラーフラグ : S-07
                        Set_Errflg(ref strWErrflg, ErrExist, itmKyokuCd, view, lRowCnt);
                    }
                }

                //ネットFCコード.

                //カードNo = 001,003の場合、ネットFCコード存在値チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET))
                {
                    // 番組コード.
                    strKey = wkBangumicd;
                    // ネットFC
                    strKey = strKey + wkNetfc;

                    if (checkNotExists(cTblNetFC, strKey))
                    {
                        // エラーフラグ : S-16
                        Set_Errflg(ref strWErrflg, ErrExist, itmNetFc, view, lRowCnt);
                    }
                }

                //府県コード.

                //カードNo = 009の場合、府県コード存在値チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_KOTU))
                {
                    // 府県コード.
                    if (checkNotExists(cTblArea, wkAreacd))
                    {
                        // エラーフラグ : S-09
                        Set_Errflg(ref strWErrflg, ErrExist, itmAreaCd, view, lRowCnt);
                    }
                }

                //エラー区分:N
                //数値チェック.
                // データ日付.
                if (!KKHUtility.IsNumeric(wkYYMM))
                {
                    // エラーフラグ : N-04
                    Set_Errflg(ref strWErrflg, ErrNumneric, itmDtYYYYMM, view, lRowCnt);
                }

                //エラー区分:Z
                //ゾーンチェック.
                //このチェックについては wk* の数値変換後では判断できないのでスプレッドを直接参照する。.
                if (wkYYMM.Length != 6) // データ日付.
                {
                    // エラーフラグ : Z-04
                    Set_Errflg(ref strWErrflg, ErrZone, itmDtYYYYMM, view, lRowCnt);
                }

                // 電波料.
                if(Decimal.ToInt64( wkDenpa ).ToString().Length > 9)
                {
                    // エラーフラグ : Z-12
                    Set_Errflg(ref strWErrflg, ErrZone, itmDenpaPrc, view, lRowCnt);
                }

                // ネット料.
                if(Decimal.ToInt64( wkNet ).ToString().Length > 9)
                {
                    // エラーフラグ : Z-13
                    Set_Errflg(ref strWErrflg, ErrZone, itmNetPrc, view, lRowCnt);
                }

                // 制作費.
                if(Decimal.ToInt64( wkSeisaku ).ToString().Length > 9)
                {
                    // エラーフラグ : Z-14
                    Set_Errflg(ref strWErrflg, ErrZone, itmProPrc, view, lRowCnt);
                }

                // 請求額.
                if(Decimal.ToInt64( wkSeikyu ).ToString().Length > 9)
                {
                    // エラーフラグ : Z-15
                    Set_Errflg(ref strWErrflg, ErrZone, itmSeikyuPrc, view, lRowCnt);
                }

                //電波料.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    //電波料.
                    if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKDenpa].Value))
                    {
                        // エラーフラグ : N-12
                        Set_Errflg(ref strWErrflg, ErrNumneric, itmDenpaPrc, view, lRowCnt);
                    }
                }

                //ネット料.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SINBN) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_INTERNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    //ネットFC
                    if (!String.Equals(view.Cells[lRowCnt, cKNet].Value, ""))
                    {
                        if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKNet].Value))
                        {
                            // エラーフラグ : N-13
                            Set_Errflg(ref strWErrflg, ErrNumneric, itmNetPrc, view, lRowCnt);
                        }
                    }
                }

                //制作費.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI))
                {
                    //制作費.
                    if (!String.Equals((String)view.Cells[lRowCnt, cKSeisaku].Value, ""))
                    {
                        if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKSeisaku].Value))
                        {
                            // エラーフラグ : N-14
                            Set_Errflg(ref strWErrflg, ErrNumneric, itmProPrc, view, lRowCnt);
                        }
                    }
                }

                //請求額.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_KOTU) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SONOTA) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SEISAKU) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CHIRASI) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SAMPLING) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    //請求額.
                    if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKSeikyu].Value))
                    {
                        // エラーフラグ : N-15
                        Set_Errflg(ref strWErrflg, ErrNumneric, itmSeikyuPrc, view, lRowCnt);
                    }
                }

                //総秒数.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    //総秒数.
                    if (!String.Equals((String)view.Cells[lRowCnt, cKSoubyousu].Value, ""))
                    {
                        if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKSoubyousu].Value))
                        {
                            // エラーフラグ : N-10
                            Set_Errflg(ref strWErrflg, ErrNumneric, itmTtlTimes, view, lRowCnt);
                        }
                    }
                }

                //秒数.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    //秒数.
                    if (!KKHUtility.IsNumeric((String)view.Cells[lRowCnt, cKByousu_Gensen].Value))
                    {
                        // エラーフラグ : N-11
                        Set_Errflg(ref strWErrflg, ErrNumneric, itmTimes, view, lRowCnt);
                    }
                }

                //エラー区分:L
                //ロジカルチェック(No5～No8までのチェックは無し)
                //No1 : カードNoと媒体区分チェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_TV))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_RD))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SPOT))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_TV_SPOT) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_RD_SPOT))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_TV) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_RD) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_BSCS))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SINBN))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_NP))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_ZASSI))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_MZ))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_KOTU))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_OOH))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SONOTA))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_OTHER) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_BAITAI_TAX1))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SEISAKU))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_TVCF) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_SEISAK_TAX1) &&
                        !String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_SEISAK_TAX2))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CHIRASI))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_CHIRASHI))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_SAMPLING))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_SAMPLE))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_BSCS))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_INTERNET))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_INT))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_MOB))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    if (!String.Equals(wkBaitaicd, KKHLionConst.BAITAIKBN_JIGYO))
                    {
                        // エラーフラグ : L-AA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardBtKbn, view, lRowCnt);
                    }
                }

                //No2 : カードNo.001、003のロジカルチェック②、①③の準備.
                // ロジカルチェック② ... 制作費ありがダブればエラー.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET))
                {
                    // 制作費.
                    if (wkSeisaku > 0)
                    {
                        // ①の準備 ... 制作費ありを登録しておく.
                        strKey = wkKdNo;                // カードNO
                        strKey = strKey + wkBangumicd;  // 番組コード.

                        if (!cTblPrCost.Contains(strKey))
                        {
                            cTblPrCost.Add(strKey, lRowCnt);
                        }
                        else
                        {
                            //エラーフラグ : L-CA
                            Set_Errflg(ref strWErrflg, ErrLogical, itmTVRDLog_Pro, view, lRowCnt);

                            // ダブリ元もエラー表示にする.
                            //エラーフラグ : L-CA
                            Set_ErrflgOrg(ErrLogical, itmTVRDLog_Pro, view, (int)cTblPrCost[strKey]);
                        }

                        // ③の準備 ... F/C ≠//9// を登録しておく.
                        if (!String.Equals(wkNetfc, "9"))
                        {
                            //キーが重複していない場合.
                            if (!cTblFCnot9.Contains(strKey))
                            {
                                cTblFCnot9.Add(strKey, lRowCnt);
                            }
                        }
                    }
                }

                //No4 : カードNoの組み合わせのロジカルチェック.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_BSCS))
                {
                    if (String.Equals(wkDetacd, "21"))  // データ処理コード.
                    {
                        strKey = wkBangumicd;          // 番組コード.
                        strKey = strKey + wkKyokusicd; // 局誌コード.

                        if (!cTblCM4.Contains(strKey))
                        {
                            //エラーフラグ : L-CC
                            Set_Errflg(ref strWErrflg, ErrLogical, itmCardComb, view, lRowCnt);
                        }

                        // カードNO.001,002,003,004,016のリストを作る.
                        if (!cTblCM4_TvRdBSCS.Contains(strKey))
                        {
                            cTblCM4_TvRdBSCS.Add(strKey, strKey);
                        }
                    }
                }

                //No3 : カードNo.006のロジカルチェック①準備、②準備.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    if (wkSoubyousu != 0)   // 総秒数である.
                    {
                        // No3 : カードNo.006のロジカルチェック①準備 ... 番組コードを登録（データ不要）.
                        if (!cTblCM3.Contains(wkBangumicd))
                        {
                            cTblCM3.Add(wkBangumicd, 0);

                            // 既存なし...番組コード+総秒数を登録(データ不要)
                            cTblCM3.Add(wkBangumicd + String.Format("{0:0000}", wkSoubyousu), 0);
                        }
                        else
                        {
                            if (!cTblCM3.Contains(wkBangumicd + String.Format("{0:0000}", wkSoubyousu)))
                            {
                                cTblCM3.Add(wkBangumicd + String.Format("{0:0000}", wkSoubyousu), 0);

                                // 登録できた：総秒数の異なるものが存在する...エラー目印をつけて番組コードを登録（データ不要）.
                                if (!cTblCM3.Contains(wkBangumicd + " err"))
                                {
                                    cTblCM3.Add(wkBangumicd + " err", 0);
                                }
                            }
                        }
                    }

                    // No3 : カードNo.006のロジカルチェック②準備 ... 番組ごとに秒数を cTblCM3G へ加算.

                    // 番組コード+ブランドコードを登録(データ不要)
                    if (!cTblCM3G.Contains(wkBangumicd + wkBrandcd))
                    {
                        cTblCM3G.Add(wkBangumicd + wkBrandcd, 0);

                        // 初回登録に限り.

                        // 番組ごとに秒数を加算（データは秒数）.
                        if (!cTblCM3G.Contains(wkBangumicd))
                        {
                            cTblCM3G.Add(wkBangumicd, wkByousu_Gensen);
                        }
                        else
                        {
                            cTblCM3G[wkBangumicd] = (long)cTblCM3G[wkBangumicd] + wkByousu_Gensen;
                        }
                    }

                    //No9 : 余分にCM秒数が入力された場合のエラー.
                    strKey = wkBangumicd;                               // 番組コード.
                    strKey = strKey + wkKyokusicd;                      // 局誌コード.
                    strKey = strKey + wkBrandcd;                        // ブランドコード.
                    strKey = strKey + ( wkByousu_Gensen ).ToString();   // 秒数.

                    if (!cTblCM9.Contains(strKey))
                    {
                        cTblCM9.Add(strKey, lRowCnt);
                    }
                    else
                    {
                        //エラーフラグ : L-WA
                        Set_Errflg(ref strWErrflg, ErrLogical, itmDblCMTimes, view, lRowCnt);

                        // ダブリ元もエラー表示にする.
                        //エラーフラグ : L-WA
                        Set_ErrflgOrg(ErrLogical, itmDblCMTimes, view, (int)cTblCM9[strKey]);
                    }
                }

                //エラーフラグを10個まで表示(11個以降は切り捨て)
                Chk_Errflg(ref strWErrflg);

                view.Cells[lRowCnt, cKStatus].Value = strWErrflg;
            }

            // 行ごとにチェック【２週目】（集計後でないとチェックできないものについて）.
            for (lRowCnt = 0; lRowCnt < ( view.Rows.Count - TOTAL_AMOUNT_ROWS ); lRowCnt++)
            {
                //前回のエラーフラグを取得.

                strWErrflg = (String)view.Cells[lRowCnt, cKStatus].Value;

                // カレント行の各項目を取得.

                // カードNO
                wkKdNo = (String)view.Cells[lRowCnt, cKKdNo].Value;

                // 番組CD
                wkBangumicd = (String)view.Cells[lRowCnt, cKBangumicd].Value;

                // 局誌CD
                wkKyokusicd = (String)view.Cells[lRowCnt, cKKyokusicd].Value;

                // ネットFC
                wkNetfc = (String)view.Cells[lRowCnt, cKNetfc].Value;

                // 制作費.
                wkSeisaku = 0.0m;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKSeisaku].Value))
                {
                    wkSeisaku = KKHUtility.DecParse((String)view.Cells[lRowCnt, cKSeisaku].Value);
                }

                // 総秒数.
                wkSoubyousu = 0;

                if (!String.IsNullOrEmpty((String)view.Cells[lRowCnt, cKSoubyousu].Value))
                {
                    wkSoubyousu = long.Parse((String)view.Cells[lRowCnt, cKSoubyousu].Value);
                }

                //エラー区分:L

                //No2 : カードNo.001、003のロジカルチェック①③.
                if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_RDNET))
                {
                    strKey = wkKdNo;                // カードNO
                    strKey = strKey + wkBangumicd;  // 番組CD

                    // ロジカルチェック① ... 先の処理で番組制作費≠0を cTblPrCost に登録済み.
                    if (wkSeisaku == 0) // 制作費.
                    {
                        if (!cTblPrCost.Contains(strKey))
                        {
                            //エラーフラグ : L-CA
                            Set_Errflg(ref strWErrflg, ErrLogical, itmTVRDLog_Pro, view, lRowCnt);
                        }
                    }

                    // ロジカルチェック③ ... 先の処理で F/C ≠ //9// を cTblFCnot9 に登録済み.
                    if (wkNetfc == "9") // ネットFC
                    {
                        if (!cTblFCnot9.Contains(strKey))
                        {
                            //エラーフラグ : L-CA
                            Set_Errflg(ref strWErrflg, ErrLogical, itmTVRDLog_Pro, view, lRowCnt);
                        }
                    }
                }
                //No3 : カードNo.006のロジカルチェック①.
                else if (String.Equals(wkKdNo, KKHLionConst.COLSTR_CARDNO_CMTIME))
                {
                    if (wkSoubyousu != 0)   // 総秒数である.
                    {
                        //No3 : カードNo.006のロジカルチェック①...先の処理で 番組コード&" err" を cTblCM3 に登録済み.
                        if (cTblCM3.Contains(wkBangumicd + " err"))
                        {
                            //エラーフラグ : L-CB
                            Set_Errflg(ref strWErrflg, ErrLogical, itmCMGTimesLog, view, lRowCnt);
                        }
                    }

                    // No3 : カードNo.006のロジカルチェック② ... 番組ごとに秒数を cTblCM3G へ加算してある（データは秒数）.
                    if (!cTblCM3.Contains(wkBangumicd + String.Format("{0:0000}", (long)cTblCM3G[wkBangumicd])))
                    {
                        // 総秒数が該当しない.
                        //エラーフラグ : L-CB
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCMTimesLog, view, lRowCnt);
                    }

                    // No4 : カードNoの組み合わせの相互チェック.
                    strKey = wkBangumicd + wkKyokusicd;

                    if (!cTblCM4_TvRdBSCS.Contains(strKey))
                    {
                        Set_Errflg(ref strWErrflg, ErrLogical, itmCardComb, view, lRowCnt);
                    }
                }

                //エラーフラグを10個まで表示(11個以降は切り捨て)
                Chk_Errflg(ref strWErrflg);

                view.Cells[lRowCnt, cKStatus].Value = strWErrflg;
            }
        }

        /// <summary>
        /// エラーフラグを切り捨てる.
        /// </summary>
        /// <param name="prmErrflg"></param>
        private void Chk_Errflg(ref String prmErrflg)
        {
            // エラーコードは文字数が固定なので長さで判断する.
            // 4文字 × 10個 ＋ 区切り × 9 = 49
            if (prmErrflg.Length > 49)
            {
                prmErrflg = prmErrflg.Substring(0, 49);
            }
        }

        /// <summary>
        /// ダブリ元のエラーフラグを設定する.
        /// </summary>
        /// <param name="prmErrKbn"></param>
        /// <param name="prmErrItem"></param>
        /// <param name="view"></param>
        /// <param name="prmSpdRow"></param>
        private void Set_ErrflgOrg(String prmErrKbn, String prmErrItem, FarPoint.Win.Spread.SheetView view, int prmSpdRow)
        {
            String strWErrflg;  // エラーフラグ.
            Object strWork;

            // 現在のステータスを得る.
            strWork = view.Cells[prmSpdRow, cKStatus].Value;

            strWErrflg = strWork.ToString().Trim();

            // エラー設定.
            Set_Errflg(ref strWErrflg, prmErrKbn, prmErrItem, view, prmSpdRow);

            // エラーフラグを10個まで表示(11個以降は切り捨て)
            Chk_Errflg(ref strWErrflg);

            // ステータスを戻す.
            view.Cells[prmSpdRow, cKStatus].Value = strWErrflg;
        }

        /// <summary>
        /// エラーフラグを設定する.
        /// </summary>
        /// <param name="prmErrflg"></param>
        /// <param name="prmErrKbn"></param>
        /// <param name="prmErrItem"></param>
        /// <param name="view"></param>
        /// <param name="prmSpdRow"></param>
        private void Set_Errflg(ref String prmErrflg, String prmErrKbn, String prmErrItem, FarPoint.Win.Spread.SheetView view, int prmSpdRow)
        {
            //エラーフラグ.
            String strWErrflg;

            // 同エラー区分が既存なら処理不要.
            if (prmErrflg.IndexOf(prmErrKbn + "-" + prmErrItem) >= 0)
            {
                return;
            }

            //エラー箇所の背景色を赤色に設定.

            //ステータス列.
            view.Cells[prmSpdRow, cKStatus].BackColor = Color.FromArgb(0xFF, 0x80, 0x80);

            int column = 0;

            //カードNo
            if (String.Equals(prmErrItem, itmCardNo))
            {
                column = cKKdNo;
            }
            //媒体区分.
            else if (String.Equals(prmErrItem, itmMediaKbn))
            {
                column = cKBaitaicd;
            }
            //データ処理コード.
            else if (String.Equals(prmErrItem, itmDtTranCd))
            {
                column = cKDetacd;
            }
            //データ日付.
            else if (String.Equals(prmErrItem, itmDtYYYYMM))
            {
                column = cKYYMM;
            }
            //代理店コード.
            else if (String.Equals(prmErrItem, itmAgencyCd))
            {
                column = cKDairitencd;
            }
            //番組コード.
            else if (String.Equals(prmErrItem, itmProgramCd))
            {
                column = cKBangumicd;
            }
            //局誌コード.
            else if (String.Equals(prmErrItem, itmKyokuCd))
            {
                column = cKKyokusicd;
            }
            //ブランドコード.
            else if (String.Equals(prmErrItem, itmBrandCd))
            {
                column = cKBrandcd;
            }
            //府県コード.
            else if (String.Equals(prmErrItem, itmAreaCd))
            {
                column = cKfukencd;
            }
            //総秒数.
            else if (String.Equals(prmErrItem, itmTtlTimes) || String.Equals(prmErrItem, itmCMGTimesLog))
            {
                column = cKSoubyousu;
            }
            //秒数.
            else if (String.Equals(prmErrItem, itmTimes))
            {
                column = cKByousu_Gensen;
            }
            //電波料.
            else if (String.Equals(prmErrItem, itmDenpaPrc))
            {
                column = cKDenpa;
            }
            //ネット費.
            else if (String.Equals(prmErrItem, itmNetPrc))
            {
                column = cKNet;
            }
            //制作費.
            else if (String.Equals(prmErrItem, itmProPrc))
            {
                column = cKSeisaku;
            }
            //請求額.
            else if (String.Equals(prmErrItem, itmSeikyuPrc))
            {
                column = cKSeikyu;
            }
            //ネットFC
            else if (String.Equals(prmErrItem, itmNetFc))
            {
                column = cKNetfc;
            }
            else if (String.Equals(prmErrItem, itmCardBtKbn))
            {
                column = cKKdNo;

                view.Cells[prmSpdRow, column].BackColor = Color.FromArgb(0xFF, 0x80, 0x80);

                column = cKBaitaicd;
            }
            else if (String.Equals(prmErrItem, itmCMTimesLog) || String.Equals(prmErrItem, itmDblCMTimes))
            {
                column = cKByousu_Gensen;
            }
            else if (String.Equals(prmErrItem, itmTVRDLog_Pro))
            {
                column = cKSeisaku;
            }
            else if (String.Equals(prmErrItem, itmTVRDLog_FC))
            {
                column = cKNetfc;
            }
            else if (String.Equals(prmErrItem, itmDouble) || String.Equals(prmErrItem, itmCardComb))
            {
                column = cKStatus;
            }
            //上記以外.
            else
            {
                return;
            }

            view.Cells[prmSpdRow, column].BackColor = Color.FromArgb(0xFF, 0x80, 0x80);

            //エラーフラグ設定.
            if (String.Equals(prmErrItem, itmTVRDLog_Pro) || String.Equals(prmErrItem, itmTVRDLog_FC))
            {
                strWErrflg = prmErrKbn + "-" + prmErrItem.Substring(0, 2);
            }
            else
            {
                strWErrflg = prmErrKbn + "-" + prmErrItem;
            }

            if (String.Equals(prmErrflg, ""))
            {
                prmErrflg = strWErrflg;
            }
            else
            {
                prmErrflg = prmErrflg + "," + strWErrflg;
            }
        }

        /// <summary>
        /// FDを出力する.
        /// </summary>
        private void FileOut( FarPoint.Win.Spread.SheetView view )
        {
            // SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            // 日付とか.
            DateTime now = DateTime.Now;

            // はじめのファイル名を指定する.
            sfd.FileName = _strDefaultFilename + ".csv";

            // はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = _strDefaultPath;

            // [ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter = "CSV(ｶﾝﾏ区切り)(*.csv)|*.csv|すべてのファイル|*.*";

            // [ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 1;

            // タイトルを設定する.
            sfd.Title = "ファイル指定";

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                /* 2014/09/30 比較帳票対応 HLC fujimoto ADD start */
                //履歴作成.
                if (!MakeRrk())
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0163, null, this.Text, MessageBoxButtons.OK);
                    return;
                }
                /* 2014/09/30 比較帳票対応 HLC fujimoto ADD end */

                string filnm = sfd.FileName;

                WriteFile( filnm, view );

                MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { FILE_OUTPUT_OK } , "請求データ出力", MessageBoxButtons.OK);
            }

            sfd.Dispose();
        }

        /* 2014/09/30 比較帳票対応 HLC fujimoto ADD start */
        /// <summary>
        /// 履歴作成.
        /// </summary>
        /// <returns></returns>
        private bool MakeRrk()
        {
            //*************************************
            //履歴保存.
            //*************************************
            //履歴保存権限がある場合.
            if (blnTantoFlg)
            {
                ReportLionProcessController controller = ReportLionProcessController.GetInstance();

                ReportLionProcessController.RegisterLionOrderHistoryParam param = new ReportLionProcessController.RegisterLionOrderHistoryParam();
                param.esqId = _naviParam.strEsqId;
                param.egCd = _naviParam.strEgcd;
                param.tksKgyCd = _naviParam.strTksKgyCd;
                param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                param.yymm = txtYm.Value.ToString();
                param.rrkTimStmp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                param.rrkGetBaitai = cmbBaitai.Text;

                RegisterLionOrderHistoryServiceResult result = controller.registerLionOrderHistory(param);

                if (result.HasError)
                {
                    //コントロールを未選択状態にする.
                    this.ActiveControl = null;
                    return false;
                }

                return true;
            }
            else
            {
                return true;
            }
        }
        /* 2014/09/30 比較帳票対応 HLC fujimoto ADD end */

        /// <summary>
        /// FDを書き込む.
        /// </summary>
        /// <param name="P_FileName"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        private int WriteFile(String P_FileName, FarPoint.Win.Spread.SheetView view)
        {
            String L_Str;   //ファイル出力するデータ.
            String L_Buf;   //スプレッドデータ.

            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(P_FileName, false, enc);

            for (int i = 0; i < ( view.Rows.Count - TOTAL_AMOUNT_ROWS ); i++)
            {
                L_Str = "";
                //カードNo
                L_Buf = view.Cells[i, cKKdNo].Value.ToString();
                if (L_Buf.Length < 3)
                {
                    L_Str = L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Buf.Substring(0, 3) + ",";
                }
                //年月.
                L_Buf = view.Cells[i, cKYYMM].Value.ToString();
                if (L_Buf.Length < 6)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 6) + ",";
                }
                //代理店CD
                L_Buf = view.Cells[i, cKDairitencd].Value.ToString();
                if (L_Buf.Length < 4)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 4) + ",";
                }
                //媒体区分.
                L_Buf = view.Cells[i, cKBaitaicd].Value.ToString();
                if (L_Buf.Length < 2)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                }
                //番組CD
                L_Buf = view.Cells[i, cKBangumicd].Value.ToString();
                if (L_Buf.Length < 3)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                }
                //ブランドCD
                L_Buf = view.Cells[i, cKBrandcd].Value.ToString();
                if (L_Buf.Length < 4)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 4) + ",";
                }
                //ブランド名称.
                L_Str = L_Str + ",";
                //局誌CD
                L_Buf = view.Cells[i, cKKyokusicd].Value.ToString();
                if (L_Buf.Length < 3)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                }
                //局誌名称.
                L_Str = L_Str + ",";
                //ネットFC
                L_Buf = view.Cells[i, cKNetfc].Value.ToString();
                if (L_Buf.Length < 1)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 1) + ",";
                }
                //府県CD
                L_Buf = view.Cells[i, cKfukencd].Value.ToString();
                if (L_Buf.Length < 2)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                }
                //電波料.
                L_Buf = view.Cells[i, cKDenpa].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.DecParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Length < 9)
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Substring(0, 9) + ",";
                    }
                }
                //ネット料.
                L_Buf = view.Cells[i, cKNet].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.DecParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Length < 9)
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Substring(0, 9) + ",";
                    }
                }
                //制作費.
                L_Buf = view.Cells[i, cKSeisaku].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.DecParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Length < 9)
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Substring(0, 9) + ",";
                    }
                }
                //請求額.
                L_Buf = view.Cells[i, cKSeikyu].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.DecParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Length < 9)
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + Decimal.ToInt64(KKHUtility.DecParse(L_Buf)).ToString().Substring(0, 9) + ",";
                    }
                }
                //合計.
                L_Str = L_Str + ",";
                //総秒数.
                L_Buf = view.Cells[i, cKSoubyousu].Value.ToString();
                if (L_Buf.Length < 5)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 5) + ",";
                }
                //秒数・源泉税区分.
                L_Buf = view.Cells[i, cKByousu_Gensen].Value.ToString();
                if (L_Buf.Length < 5)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 5) + ",";
                }
                //源泉税円.
                L_Buf = view.Cells[i, cKGensenzeien].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.LongParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (L_Buf.Length < 9)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 9) + ",";
                    }
                }
                //雑広告消費税額.
                L_Buf = view.Cells[i, cKZatukoukoku].Value.ToString();
                //金額が０円の時空白.
                if (KKHUtility.LongParse(L_Buf) == 0)
                {
                    L_Str = L_Str + "" + ",";
                }
                else
                {
                    if (L_Buf.Length < 9)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 9) + ",";
                    }
                }
                //オンエア回数.
                L_Buf = view.Cells[i, cKOnea].Value.ToString();
                if (L_Buf.Length < 2)
                {
                    L_Str = L_Str + L_Buf.Trim() + ",";
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                }
                //データ処理CD
                L_Buf = view.Cells[i, cKDetacd].Value.ToString();
                if (L_Buf.Length < 2)
                {
                    L_Str = L_Str + L_Buf.Trim();
                }
                else
                {
                    L_Str = L_Str + L_Buf.Substring(0, 2);
                }

                //フィールドを書き込む.
                streamWriter.WriteLine(L_Str);
            }

            //閉じる.
            streamWriter.Close();

            // オペレーションログの出力.
            KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_FD, KKHLogUtilityLion.DESC_OPERATION_LOG_FD);

            return 0;
        }

        /// <summary>
        /// ステータスエラーを表示する.
        /// </summary>
        /// <param name="value"></param>
        private static void putStatusError(String value)
        {
            String message = "";

            int index = 0;

            while (index < value.Length)
            {
                // エラー区分.
                if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrExist.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "存在値エラー：";
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrNumneric.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "ニューメリックエラー：";
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrZone.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "ゾーンエラー：";
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrEssential.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "必須エラー：";
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrLogical.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "ロジカルエラー：";
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrDouble.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    message += "ダブリエラー：";
                }
                else
                {
                    break;
                }

                // ハイフンを飛ばす.
                index += 2;

                // エラー項目.
                if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmCardNo.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNO";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmMediaKbn.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "媒体区分";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmDtTranCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "データ処理コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmDtYYYYMM.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "データ日付";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmAgencyCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "代理店コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmProgramCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "番組コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmKyokuCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "局誌コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmBrandCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "商品コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmAreaCd.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "府県コード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmTtlTimes.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "総秒数";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmTimes.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "秒数";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmDenpaPrc.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "電波料";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmNetPrc.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "ネット費";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmProPrc.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "製作費";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmSeikyuPrc.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "金額";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmNetFc.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "FCコード";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmCardBtKbn.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNOと媒体区分のエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmTVRDLog_Pro.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNO.001・003のロジカルエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmTVRDLog_FC.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNO.001・003のロジカルエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmCMTimesLog.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNO.006のロジカルエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmCMGTimesLog.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNO.006のロジカルエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmCardComb.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "カードNOの組み合わせエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmDblCMTimes.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "余分にCM秒数が入力された場合のエラー";
                }
                else if (String.Equals(value.Substring(index, ERROR_CODE_LENGTH), itmDouble.Substring(0, ERROR_CODE_LENGTH)))
                {
                    message += "ダブリエラー";
                }
                else
                {
                    break;
                }

                // 改行.
                message += "\r\n";

                // カンマを飛ばす.
                index += 3;
            }

            //追加 hlc sonobe 3/01 start
            index = 0;

            String submessage = "";
            while (index < value.Length)
            {
                // エラー区分.
                if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrExist.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    if (submessage.IndexOf("存在値エラー") < 0)
                    {
                        submessage += "\r\n" + "存在値エラー：該当項目の内容をマスタに登録してください"
                                    + "\r\n" + "              　 またはマスタに登録のある内容を選択してください";
                    }
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrNumneric.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    if (submessage.IndexOf("ニューメリックエラー") < 0)
                    {
                        submessage += "\r\n" + "ニューメリックエラー：該当項目を数字で入力してください";
                    }
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrZone.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    if (submessage.IndexOf("ゾーンエラー") < 0)
                    {
                        submessage += "\r\n" + "ゾーンエラー：該当項目の桁数を減らしてください";
                    }
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrEssential.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    if (submessage.IndexOf("必須エラー") < 0)
                    {
                        submessage += "\r\n" + "必須エラー：該当項目を設定してください";
                    }
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrLogical.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    /* 2014/10/22 ライオン要望対応 HLC fujimoto MOD start */
                    //if (submessage.IndexOf("ロジカルエラー") < 0)
                    if (submessage.IndexOf("ロジカルエラー") < 0 && submessage.Trim().Length == 0)
                    {                        
                        //submessage += "\r\n" + "ロジカルエラー：出力条件を確認してください";
                        submessage += "\r\n" + "TVCM予定表のネット局と明細が一致するかを確認してください。";
                        submessage += "\n" + "　①ネット局数と明細数が一致することを確認";
                        submessage += "\n" + "　②ネット局と明細の局誌CDが紐付いていることを確認";
                        submessage += "\n" + "　　⇒ネット局：テレビ局コード変更マスタの電通コード";
                        submessage += "\n" + "　　⇒明細：テレビ局コード変更マスタのLIONコード";
                    }
                    /* 2014/10/22 ライオン要望対応 HLC fujimoto MOD end */
                }
                else if (String.Equals(value.Substring(index, ERROR_CLASSIFICATION_LENGTH), ErrDouble.Substring(0, ERROR_CLASSIFICATION_LENGTH)))
                {
                    if (submessage.IndexOf("ダブリエラー") < 0)
                    {
                        submessage += "\r\n" + "ダブリエラー：該当項目内容に重複しているものがあります。確認してください";
                    }
                }
                else
                {
                    break;
                }

                // ハイフンを飛ばす.
                index += 2;

                // カンマを飛ばす.
                index += 3;
            }
            // 設定.
            message += submessage;
            //追加 hlc sonobe 3/01 end

            MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { message }, "ステータスエラー内容", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 必須チェック.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Boolean checkNullOrEmpty(String value)
        {
            return String.Equals(value, String.Empty);
        }

        /// <summary>
        /// 存在値チェック.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean checkNotExists(Hashtable collection, String key)
        {
            return !collection.Contains(key);
        }

        #region マスタ取得(担当者マスタ).

        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */
        /// <summary>
        /// 担当者マスタデータ取得.
        /// </summary>
        private void GetTanto()
        {
            KKH.Common.KKHUtility.ExcelOutPut excelOutPut = new Isid.KKH.Common.KKHUtility.ExcelOutPut();
            KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController processController =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();

            //データ取得.
            FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(_naviParam.strEsqId
                                                                                                , _naviParam.strEgcd
                                                                                                , _naviParam.strTksKgyCd
                                                                                                , _naviParam.strTksBmnSeqNo
                                                                                                , _naviParam.strTksTntSeqNo
                                                                                                , KKHLionConst.C_MAST_TANTO_CD
                                                                                                , "");

            //履歴保存担当者マスタデータテーブル編集.
            //ESQID.
            dtTanto.Columns.Add("ESQID", Type.GetType("System.String"));

            foreach (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                dtTanto.Rows.Add(row.Column1);

            }

            //ESQ-IDで履歴保存可否確認.
            DataRow[] rowTanto = dtTanto.Select("ESQID = '" + _naviParam.strEsqId + "'");
            if (rowTanto.Length != 0)
            {
                //履歴保存フラグ設定.
                blnTantoFlg = true;
            }
        }
        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD end */

        #endregion マスタ取得(担当者マスタ).

        #endregion メソッド.

    }
}

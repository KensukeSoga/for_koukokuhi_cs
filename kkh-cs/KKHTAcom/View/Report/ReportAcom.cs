using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.ProcessController.Report;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.NJ.View.Widget;
using Isid.KKH.Acom.Utility;

namespace Isid.KKH.Acom.View.Report
{
    public partial class ReportAcom : KKHForm
    {
        # region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "RepAcom";

        /// <summary>
        /// 帳票設定情報取得用キー
        /// </summary>
        private const String SYSTEM_KEY_REPORT_SETTING = "ED-I0001";

        /// <summary>
        /// 帳票保存先取得用キー
        /// </summary>
        private const String SYSTEM_KEY_SAVEFILE_PATH = "001";

        # region カラムインデックス

        # region 新聞
        /// <summary>
        /// 請求書作成順.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_BILL_CREATE_ORDER = 0;

        /// <summary>
        /// 請求原票No.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_BILL_ORIGINAL_NO = 1;

        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_SALES_DETAIL_NO = 2;

        /// <summary>
        /// 発注番号.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ORDER_NO = 3;

        /// <summary>
        /// 発注行番号.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ORDER_ROW_NO = 4;

        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_SUBJECT = 5;

        /// <summary>
        /// 新聞名.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_NEWSPAPER_NAME = 6;
        
        /// <summary>
        /// 掲載日.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_PUBLISHING_DAY = 7;
        
        /// <summary>
        /// スペース.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_SPACE = 8;
        
        /// <summary>
        /// 朝夕.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_MORNING_EVENING = 9;
        
        /// <summary>
        /// 費目名.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ITEMS_EXPENSES_NAME = 10;
        
        /// <summary>
        /// 単価.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_UNIT_PRICE = 11;
        
        /// <summary>
        /// 金額.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_MONEY = 12;
        
        /// <summary>
        /// 掲載版.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_PUBLISHING_VERSION = 13;
        
        /// <summary>
        /// 記雑区分.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_DIVISION = 14;
        
        /// <summary>
        /// 1行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM01 = 15;
        
        /// <summary>
        /// 2行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM02 = 16;
        
        /// <summary>
        /// 3行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM03 = 17;
        
        /// <summary>
        /// 4行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM04 = 18;
        
        /// <summary>
        /// 5行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM05 = 19;

        /// <summary>
        /// 6行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM06 = 20;

        /// <summary>
        /// 7行目.
        /// </summary>
        private const int COLIDX_MLIST_SHIN_ACOM07 = 21;

        /// <summary>
        /// 請求書番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_BILL_NO = 22;

        /// <summary>
        /// 発注番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_ORDER_NO = 23;

        /// <summary>
        /// 発注行番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_ORDER_ROW_NO = 24;

        /// <summary>
        /// 請求原票番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_BILL_ORIGINAL_NO = 25;

        /// <summary>
        /// 行種別（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_ROW_TYPE = 26;

        /// <summary>
        /// 行状態（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_SHIN_CTRL_ROW_STATE = 27;

        # endregion 新聞
        # region 雑誌
        /// <summary>
        /// 請求書作成順.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_BILL_CREATE_ORDER = 0;

        /// <summary>
        /// 請求原票No.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_BILL_ORIGINAL_NO = 1;

        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_SALES_DETAIL_NO = 2;

        /// <summary>
        /// 発注番号.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ORDER_NO = 3;

        /// <summary>
        /// 発注行番号.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ORDER_ROW_NO = 4;

        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_SUBJECT = 5;
        
        /// <summary>
        /// 雑誌名.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_MAGAZINE_NAME = 6;
        
        /// <summary>
        /// 発売日.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_RELEASE_DATE = 7;
        
        /// <summary>
        /// スペース.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_SPACE = 8;
        
        /// <summary>
        /// 掲載種別.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_PUBLISHING_TYPE = 9;
        
        /// <summary>
        /// 費目名.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ITEMS_EXPENSES_NAME = 10;
        
        /// <summary>
        /// 単価.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_UNIT_PRICE = 11;
        
        /// <summary>
        /// 金額.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_MONEY = 12;
        
        /// <summary>
        /// 1行目.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ACOM01 = 13;
        
        /// <summary>
        /// 2行目.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ACOM02 = 14;
        
        /// <summary>
        /// 3行目.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ACOM03 = 15;
        
        /// <summary>
        /// 4行目.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ACOM04 = 16;
        
        /// <summary>
        /// 5行目.
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_ACOM05 = 17;

        /// <summary>
        /// 請求書番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_CTRL_BILL_NO = 18;

        /// <summary>
        /// 発注番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_CTRL_ORDER_NO = 19;

        /// <summary>
        /// 発注行番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_CTRL_ORDER_ROW_NO = 20;

        /// <summary>
        /// 請求原票番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_CTRL_BILL_ORIGINAL_NO = 21;

        /// <summary>
        /// 行種別（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_ZASHI_CTRL_ROW_TYPE = 22;

        # endregion 雑誌
        # region 電波

        /// <summary>
        /// 請求書作成順.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BILL_CREATE_ORDER = 0;

        /// <summary>
        /// 請求原票No.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BILL_ORIGINAL_NO = 1;

        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_SALES_DETAIL_NO = 2;

        /// <summary>
        /// 発注番号.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ORDER_NO = 3;

        /// <summary>
        /// 発注行番号.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ORDER_ROW_NO = 4;

        /// <summary>
        /// 業務区分.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BUSINESS_DIVISION = 5;

        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_SUBJECT = 6;
        
        /// <summary>
        /// 放送局名(略号).
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BROADCASTING_STATION = 7;
        
        /// <summary>
        /// 放送期間.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BROADCASTING_PERIOD = 8;
        
        /// <summary>
        /// 放送時間.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BROADCASTING_TIME = 9;
        
        /// <summary>
        /// 秒数.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_SECOND_NUMBER = 10;
        
        /// <summary>
        /// 回数 or 本数.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_FREQUENCY = 11;
        
        /// <summary>
        /// ネット局数 or 放送局数.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_BROADCASTING_NUMBER = 12;
        
        /// <summary>
        /// 費目名.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ITEMS_EXPENSES_NAME = 13;
        
        /// <summary>
        /// 単価.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_UNIT_PRICE = 14;
        
        /// <summary>
        /// 金額.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_MONEY = 15;

        /// <summary>
        /// 1行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM01 = 16;
        
        /// <summary>
        /// 2行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM02 = 17;
        
        /// <summary>
        /// 3行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM03 = 18;
        
        /// <summary>
        /// 4行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM04 = 19;

        /// <summary>
        /// 5行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM05 = 20;

        /// <summary>
        /// 6行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM06 = 21;

        /// <summary>
        /// 7行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM07 = 22;

        /// <summary>
        /// 8行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM08 = 23;

        /// <summary>
        /// 9行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM09 = 24;

        /// <summary>
        /// 10行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM10 = 25;

        /// <summary>
        /// 11行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM11 = 26;

        /// <summary>
        /// 12行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM12 = 27;

        /// <summary>
        /// 13行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM13 = 28;

        /// <summary>
        /// 14行目.
        /// </summary>
        private const int COLIDX_MLIST_DENPA_ACOM14 = 29;

        /// <summary>
        /// 請求書番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_BILL_NO = 30;

        /// <summary>
        /// 発注番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_ORDER_NO = 31;

        /// <summary>
        /// 発注行番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_ORDER_ROW_NO = 32;

        /// <summary>
        /// 請求原票番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_BILL_ORIGINAL_NO = 33;

        /// <summary>
        /// 行種別（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_ROW_TYPE = 34;

        /// <summary>
        /// 行状態（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_DENPA_CTRL_ROW_STATE = 35;

        # endregion 電波

        # region 交通
        /// <summary>
        /// 請求書作成順.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_BILL_CREATE_ORDER = 0;

        /// <summary>
        /// 請求原票No.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_BILL_ORIGINAL_NO = 1;

        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_SALES_DETAIL_NO = 2;

        /// <summary>
        /// 発注番号.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ORDER_NO = 3;

        /// <summary>
        /// 発注行番号.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ORDER_ROW_NO = 4;

        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_SUBJECT = 5;
        
        /// <summary>
        /// 媒体種類.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_MEDIUM_KIND = 6;
        
        /// <summary>
        /// 期間.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_PERIOD = 7;
        
        /// <summary>
        /// 数量.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_AMOUNT = 8;
        
        /// <summary>
        /// 費目名.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ITEMS_EXPENSES_NAME = 9;
        
        /// <summary>
        /// 単価.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_UNIT_PRICE = 10;
        
        /// <summary>
        /// 金額.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_MONEY = 11;
        
        /// <summary>
        /// 補足内容.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CONTENT_SUPPLEMENTATION = 12;
        
        /// <summary>
        /// 費目補足.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ITEMS_SUPPLEMENTATION = 13;
        
        /// <summary>
        /// 1行目.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ACOM01 = 14;
        
        /// <summary>
        /// 2行目.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ACOM02 = 15;
        
        /// <summary>
        /// 3行目.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ACOM03 = 16;
        
        /// <summary>
        /// 4行目.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ACOM04 = 17;

        /// <summary>
        /// 5行目.
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_ACOM05 = 18;

        /// <summary>
        /// 請求書番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CTRL_BILL_NO = 19;

        /// <summary>
        /// 発注番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CTRL_ORDER_NO = 20;

        /// <summary>
        /// 発注行番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CTRL_ORDER_ROW_NO = 21;

        /// <summary>
        /// 請求原票番号（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CTRL_BILL_ORIGINAL_NO = 22;

        /// <summary>
        /// 行種別（制御用） 
        /// </summary>
        private const int COLIDX_MLIST_KOTSU_CTRL_ROW_TYPE = 23;

        # endregion 交通
        # endregion カラムインデックス

        /// <summary>
        /// 請求回収システムの請求書イメージの1行の最大バイト数
        /// </summary>
        private const int SEIKYUKAISYU_ROWMAXBYTE = 65;

        /// <summary>
        /// 請求書イメージとしてアラートを出すボーダーバイト数
        /// </summary>
        private const int BYTEOVER_BORDERBYTE = 30;

        /// <summary>
        /// 請求回収システムの最大値を超えた場合の背景色
        /// </summary>
        private static readonly Color SEIKAIMAX_COLOR = Color.FromArgb(255, 255, 0, 0);

        /// <summary>
        /// 請求書イメージのアラートボーダーを超えた場合の背景色
        /// </summary>
        private static readonly Color BYTEOVER_COLOR = Color.FromArgb(255, 255, 204, 153);

        /// <summary>
        /// 合計行のタイトル.
        /// </summary>
        private const String NAME_TOTAL = "合計";

        /// <summary>
        /// 値引行のタイトル
        /// </summary>
        private const String NAME_NEBIKI = "値引";

        /// <summary>
        /// 朝刊のタイトル.
        /// </summary>
        private const String NAME_MORNING_NEWSPAPER = "朝刊";

        /// <summary>
        /// 夕刊のタイトル.
        /// </summary>
        private const String NAME_EVENING_NEWSPAPER = "夕刊";

        /// <summary>
        /// 新聞の無効な色刷名称（入ってきた場合に空文字扱いとする）.
        /// </summary>
        private const String SHIN_INVALID_COLOR_NAME = "モノクロ";

        /// <summary>
        /// 新聞.
        /// </summary>
        private const int SHEET_INDEX_SHIN = 0;

        /// <summary>
        /// 雑誌.
        /// </summary>
        private const int SHEET_INDEX_ZASHI = 1;

        /// <summary>
        /// 電波.
        /// </summary>
        private const int SHEET_INDEX_DENPA = 2;

        /// <summary>
        /// 交通.
        /// </summary>
        private const int SHEET_INDEX_KOTSU = 3;

        /// <summary>
        /// 無効なキー値
        /// </summary>
        private const String CTRL_KEY_INVALID_VALUE = "__INVALID_VALUE__";

        /// <summary>
        /// 行種別（通常行）.
        /// </summary>
        private const String CTRL_ROW_TYPE_NORMAL = "0";

        /// <summary>
        /// 行種別（値引行）.
        /// </summary>
        private const String CTRL_ROW_TYPE_NEBIKI = "1";

        /// <summary>
        /// 行種別（合計行）.
        /// </summary>
        private const String CTRL_ROW_TYPE_TOTAL = "2";

        /// <summary>
        /// XMLファイル名.
        /// </summary>
        private const string REP_XML_FILENAME = "Acom_Data.xml";

        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private const string REP_XML2_FILENAME = "Acom_Prop.xml";

        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Acom_Template.xlsx";

        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_MACRO_FILENAME = "Acom_Mcr.xlsm";

        # endregion 定数

        # region メンバ変数

        // 呼び出しパラメータ(受取).
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        // コピーマクロ削除用string.
        private string _macroDel;

        //データセット.
        private RepDsAcom acomDs = new RepDsAcom();

        //件数配列初期化.
        int[] _intArrDataCnt = { 0, 0, 0, 0 };

        /// <summary>
        /// 保存先用(テンプレート)変数
        /// </summary>
        private string strReportTempPath = "";

        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";

        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";

        /// <summary>
        /// 行を追加時のCellType.
        /// </summary>
        private TextCellType _txtType = new TextCellType();

        # endregion メンバ変数

        # region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ReportAcom()
        {
            InitializeComponent();
        }
        
        # endregion コンストラクタ

        # region イベント 
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
        }

        /// <summary>
        /// 戻るボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender , EventArgs e)
        {
            if (_macroDel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_macroDel);

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
        /// 画面起動時処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAcom_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

            //年月取得.
            String _hostdate = getHostDate();
            //txtYm.Value = _hostdate.Substring(0, 6);
            if (_hostdate != "")
            {
                _hostdate = _hostdate.Trim().Replace("/", "");
                if (_hostdate.Trim().Length >= 6)
                {
                    txtYm.Value = _hostdate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = _hostdate;
                }
                txtYm.cmbYM_SetDate();
            }
            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //Excelボタンを非活性化.
            btnXls.Enabled = false;
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

            //はじめのファイル名を指定する.
            sfd.FileName = pStrRepFilNam + txtYm.Value + ".xls";
            //sfd.FileName = pStrRepFilNam + saveSrcYm + ".xls";

            //はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = pStrRepAdrs;

            //[ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter = "Microsoft Excel ﾌﾞｯｸ (*.xls)|*.xls";

            //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            //タイトルを設定する.
            sfd.Title = "保存先のファイルを設定して下さい。";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示する.
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //出力先に同名のExcelファイルが開いているかチェック 
                try
                {
                    //同名でファイルを削除する。 
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }


            sfd.Dispose();
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ReportAcom_Shown(object sender, EventArgs e)
        {
            sprDenpa_Sheet3.ColumnHeader.Cells[0 , 11].Text = "回数"
                                                            + Environment.NewLine
                                                            + "or"
                                                            + Environment.NewLine
                                                            + "放送局数";
            sprDenpa_Sheet3.ColumnHeader.Cells[0 , 12].Text = "ネット局数"
                                                            + Environment.NewLine
                                                            + "or"
                                                            + Environment.NewLine
                                                            + "放送局数";

            {
                // 帳票設定.
                CommonProcessController controller = CommonProcessController.GetInstance();
                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParam.strEsqId,
                                                                                _naviParam.strEgcd,
                                                                                _naviParam.strTksKgyCd,
                                                                                _naviParam.strTksBmnSeqNo,
                                                                                _naviParam.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                SYSTEM_KEY_REPORT_SETTING);
                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    // テンプレート出力パス.
                    strReportTempPath = result.CommonDataSet.SystemCommon[0].field2.ToString();
                }
            }

            {
                // 保存情報＋帳票名.
                CommonProcessController controller = CommonProcessController.GetInstance();
                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParam.strEsqId,
                                                                                _naviParam.strEgcd,
                                                                                _naviParam.strTksKgyCd,
                                                                                _naviParam.strTksBmnSeqNo,
                                                                                _naviParam.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                SYSTEM_KEY_SAVEFILE_PATH);
                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    // 保存先セット.
                    pStrRepAdrs = result.CommonDataSet.SystemCommon[0].field2.ToString();

                    // 名称セット.
                    pStrRepFilNam = result.CommonDataSet.SystemCommon[0].field3.ToString();
                }
            }

            sprMain.ActiveSheetIndex = 0;
        }

        /// <summary>
        /// タブインデックスが変更された場合のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sprMain_ActiveSheetChanged(object sender , EventArgs e)
        {
            if (sprMain.ActiveSheetIndex >= 0)
            {
                statusStrip1.Items["tslval1"].Text = _intArrDataCnt[sprMain.ActiveSheetIndex].ToString() + "件";
            }            
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.SeiSakuSei, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }


        # endregion

        # region メソッド

        /// <summary>
        /// レコード取得メソッド.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            acomDs.Clear();

            # region 変数

            //年月.
            string _yyyyMm = txtYm.Value;

            //媒体配列初期化.
            string[] _baiKbn = { "0", "0", "0", "0" };

            //媒体チェックフラグ
            Boolean _blBaiFlg = false;

            # endregion 変数

            //*****************************************************.
            //チェックボックス=Trueの場合、媒体区分をセットする.
            //*****************************************************.
            //新聞にチェックがある場合.
            if (chkShin.Checked)
            {
                _baiKbn[SHEET_INDEX_SHIN] = KkhConstAcom.MediaKindCode.SYBT_SNBN;
            }
            //雑誌にチェックがある場合.
            if (chkZashi.Checked)
            {
                _baiKbn[SHEET_INDEX_ZASHI] = KkhConstAcom.MediaKindCode.SYBT_ZASI;
            }
            //電波にチェックがある場合.
            if (chkDenpa.Checked)
            {
                _baiKbn[SHEET_INDEX_DENPA] = KkhConstAcom.MediaKindCode.SYBT_DENP;
            }
            //交通にチェックがある場合.
            if (chkKotsu.Checked)
            {
                _baiKbn[SHEET_INDEX_KOTSU] = KkhConstAcom.MediaKindCode.SYBT_KOTU;
            }

            //*******************************************************.
            //チェックボックスがすべてFalseの場合、媒体区分をエラー.
            //*******************************************************.
            foreach (Control item in grpBaitai.Controls)
            {
                if (item.GetType().Equals(typeof(NJCheckBox)))
                {
                    if (( (NJCheckBox)item ).Checked)
                    {
                        _blBaiFlg = true;
                    }
                }
            }

            //媒体チェックフラグがfalseの場合.
            if (!_blBaiFlg)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                //エラーメッセージを出力.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0079, null, "帳票", MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }

            //*******************
            //スプレッド初期化.
            //*******************
            sprShin_Sheet1.RowCount = 0;
            sprZashi_Sheet2.RowCount = 0;
            sprDenpa_Sheet3.RowCount = 0;
            sprKotsu_Sheet4.RowCount = 0;
            sprShin_Sheet1.Visible = false;
            sprZashi_Sheet2.Visible = false;
            sprDenpa_Sheet3.Visible = false;
            sprKotsu_Sheet4.Visible = false;

            //**********************.
            //SQL実行.
            //配列の数分処理する.
            //**********************.
            for (int k = 0; k < _baiKbn.Length; k++)
            {
                //媒体配列の値を取得.
                string _arrBaiKbn = _baiKbn[k];

                //媒体区分が０以外の場合、レコードを取得する.
                if (_arrBaiKbn != "0")
                {
                    //年月.
                    ReportAcomProcessController processController = ReportAcomProcessController.GetInstance();
                    FindReportAcomByCondServiceResult result = processController.FindRepAcomByCond(
                                                                                              _naviParam.strEsqId,
                                                                                              _naviParam.strEgcd,
                                                                                              _naviParam.strTksKgyCd,
                                                                                              _naviParam.strTksBmnSeqNo,
                                                                                              _naviParam.strTksTntSeqNo,
                                                                                              _yyyyMm,
                                                                                              _arrBaiKbn
                                                                                              );
                    if (result.HasError == true)
                    {
                        statusStrip1.Items["tslval1"].Text = "0件";
                        continue;
                    }

                    //スプレッドに表示(件数分表示).
                    //シートを判別.
                    //新聞の場合.
                    if (k == SHEET_INDEX_SHIN)
                    {
                        //取得レコードがある場合 
                        if (result.dsRepAcomDataSet.RepAcom.Rows.Count > 0)
                        {
                            //シートを表示する.
                            sprShin_Sheet1.Visible = true;

                            //垂直スクロールバーを作業中は非表示にする.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                            //スプレッドに値を設定する 
                            SetSheetShin(result.dsRepAcomDataSet, sprShin_Sheet1, acomDs);

                            //垂直スクロールバーを表示する.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                            //件数をセット.
                            _intArrDataCnt[k] = result.dsRepAcomDataSet.RepAcom.Rows.Count;
                        }
                    }
                    //雑誌の場合.
                    else if (k == SHEET_INDEX_ZASHI)
                    {
                        //取得レコードがある場合 
                        if (result.dsRepAcomDataSet.RepAcom.Rows.Count > 0)
                        {
                            //シートを表示する.
                            sprZashi_Sheet2.Visible = true;

                            //垂直スクロールバーを作業中は非表示にする.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                            //スプレッドに値を設定する 
                            SetSheetZashi(result.dsRepAcomDataSet, sprZashi_Sheet2, acomDs);

                            //垂直スクロールバーを表示する.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                            //件数をセット.
                            _intArrDataCnt[k] = result.dsRepAcomDataSet.RepAcom.Rows.Count;
                        }
                    }
                    //電波の場合.
                    else if (k == SHEET_INDEX_DENPA)
                    {
                        //取得レコードがある場合 
                        if (result.dsRepAcomDataSet.RepAcom.Rows.Count > 0)
                        {
                            //シートを表示する.
                            sprDenpa_Sheet3.Visible = true;

                            //垂直スクロールバーを作業中は非表示にする.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                            //スプレッドに値を設定する 
                            SetSheetDenpa(result.dsRepAcomDataSet, sprDenpa_Sheet3, acomDs);

                            //垂直スクロールバーを表示する.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                            //件数をセット.
                            _intArrDataCnt[k] = result.dsRepAcomDataSet.RepAcom.Rows.Count;
                        }
                    }
                    //交通の場合.
                    else if (k == SHEET_INDEX_KOTSU)
                    {
                        //取得レコードがある場合 
                        if (result.dsRepAcomDataSet.RepAcom.Rows.Count > 0)
                        {
                            //シートを表示する.
                            sprKotsu_Sheet4.Visible = true;

                            //垂直スクロールバーを作業中は非表示にする.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                            //スプレッドに値を設定する 
                            SetSheetKotsu(result.dsRepAcomDataSet, sprKotsu_Sheet4, acomDs);

                            //垂直スクロールバーを表示する.
                            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                            //件数をセット.
                            _intArrDataCnt[k] = result.dsRepAcomDataSet.RepAcom.Rows.Count;
                        }
                    }
                }
            }
            //ローディング表示終了 
            base.CloseLoadingDialog();

            //すべてのシートの取得件数が0の場合 
            if (( _intArrDataCnt[0] + _intArrDataCnt[1] + _intArrDataCnt[2] + _intArrDataCnt[3] ) == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
            }
            else
            {
                // 全シートの件数を合算して出力.
                statusStrip1.Items["tslval1"].Text = ( _intArrDataCnt[0] + _intArrDataCnt[1] + _intArrDataCnt[2] + _intArrDataCnt[3] ).ToString() + "件";

                //Excelボタン押下可能.
                btnXls.Enabled = true;
            }

            this.ActiveControl = null;

        }

        /// <summary>
        /// 新聞シートに値を設定する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sheet"></param>
        /// <param name="ods"></param>
        private void SetSheetShin(RepDsAcom ds, SheetView sheet, RepDsAcom ods)
        {
            RepDsAcom.RepAcomShinDataTable dt = new RepDsAcom.RepAcomShinDataTable();

            //変数初期化.
            int i = 0;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strBillOriginalNo = null;            //請求原票番号.
            int seiSakJun = 0;                          //請求書作成順.
            Decimal totalAmount = 0M;                   //合計金額.

            foreach (RepDsAcom.RepAcomRow row in ds.RepAcom.Rows)
            {
                // スプレッドシートに行を追加.
                RepDsAcom.RepAcomShinRow outRow = dt.NewRepAcomShinRow();

                // 請求書番号.
                strBillNo = row.sonota1.ToString();

                // 発注番号.
                strOrderNo = row.code3.ToString();

                // 発注番号.
                strOrderRowNo = row.code4.ToString();

                // 請求原票番号
                strBillOriginalNo = row.name6.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合.
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    if (i != 0)
                    {
                        // 合計行の出力.
                        RepDsAcom.RepAcomShinRow totalRow = dt.NewRepAcomShinRow();

                        // 請求書番号
                        totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注番号
                        totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注行番号
                        totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                        // 請求原票番号
                        totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                        // 行種別
                        totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                        // 行状態
                        totalRow.CTRL_ROW_STATE = "False";

                        // 合計.
                        totalRow.UNIT_PRICE = NAME_TOTAL;

                        // 合計額.
                        totalRow.MONEY = totalAmount.ToString();

                        // 合計額の初期化.
                        totalAmount = 0M;

                        dt.AddRepAcomShinRow(totalRow);

                        i++;
                    }

                    // 請求書作成順をインクリメント.
                    seiSakJun++;

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;
                }

                // 請求書作成順.
                if (seiSakJun == 0)
                {
                    outRow.BILL_CREATE_ORDER = String.Empty;
                }
                else
                {
                    outRow.BILL_CREATE_ORDER = seiSakJun.ToString();
                }

                // 請求書番号
                outRow.CTRL_BILL_NO = strBillNo.ToString();

                // 発注番号
                outRow.CTRL_ORDER_NO = strOrderNo.ToString();

                // 発注行番号
                outRow.CTRL_ORDER_ROW_NO = strOrderRowNo.ToString();

                // 請求原票番号
                outRow.CTRL_BILL_ORIGINAL_NO = strBillOriginalNo.ToString();

                if (row.kbn2 == "0")
                {
                    // 請求原票No.
                    outRow.BILL_ORIGINAL_NO = row.name6.ToString();

                    // 売上明細No.
                    outRow.SALES_DETAIL_NO = row.name3.ToString() + "-" + row.name4.ToString() + "-" + row.name5.ToString();

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 件名.
                    outRow.SUBJECT = row.kknamekj.ToString();

                    // 新聞名.
                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        outRow.NEWSPAPER_NAME = row.field2.ToString();
                    }
                    else
                    {
                        outRow.NEWSPAPER_NAME = row.media.ToString();
                    }

                    String strMMDD;

                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        if (String.IsNullOrEmpty(row.field3.ToString()))
                        {
                            strMMDD = String.Empty;
                        }
                        else
                        {
                            strMMDD = row.field3.ToString();
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row.sonota9.ToString()))
                        {
                            strMMDD = String.Empty;
                        }
                        else
                        {
                            strMMDD = row.sonota9.ToString();
                        }
                    }

                    if (strMMDD.Length == 8)
                    {
                        strMMDD = DateFormat1(strMMDD);
                    }

                    // 掲載日.
                    outRow.PUBLISHING_DAY = strMMDD;

                    // スペース.
                    outRow.SPACE = row.field11.ToString();

                    // 朝夕.
                    if (row.field4.ToString() == "1")
                    {
                        outRow.MORNING_EVENING = NAME_MORNING_NEWSPAPER;
                    }
                    else if (row.field4.ToString() == "2")
                    {
                        outRow.MORNING_EVENING = NAME_EVENING_NEWSPAPER;
                    }

                    // 費目名.
                    outRow.ITEMS_EXPENSES_NAME = row.himknmkj.ToString();

                    // 単価.
                    if (( !String.IsNullOrEmpty(row.sonota7.ToString()) ) && KKHUtility.IsNumeric(row.sonota7.ToString()))
                    {
                        outRow.UNIT_PRICE = KKHUtility.DecParse(row.sonota7.ToString()).ToString();
                    }
                    else
                    {
                        outRow.UNIT_PRICE = row.sonota7.ToString();
                    }

                    // 請求金額.
                    Decimal SEIGAK = KKHUtility.DecParse(row.seigak.ToString());

                    // 値引額.
                    Decimal NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 掲載版.
                    outRow.PUBLISHING_VERSION = row.field6.ToString();

                    // 記雑区分.
                    outRow.DIVISION = row.field8.ToString();

                    int lngKsaicnt;
                    String strKsaibi;
                    String strKsaicnt;
                    String strChoyuNM;
                    String strKizatNM;
                    String strKsaibashoNM;
                    String strKsaiban;
                    String strSizeNM;
                    String strColorNM;
                    String strHimokuNM;
                    String strBiko1;
                    String strBiko2;

                    // 掲載日と掲載回数の取得.
                    getKeisaibi(ds, strBillNo, strOrderNo, row.code4.ToString(), out lngKsaicnt, out strKsaibi);

                    // 朝夕.
                    if (String.IsNullOrEmpty(row.choyu.ToString()))
                    {
                        strChoyuNM = String.Empty;
                    }
                    else
                    {
                        strChoyuNM = row.choyu.ToString() + " ";
                    }

                    // 記雑.
                    if (String.IsNullOrEmpty(row.kizatsu.ToString()))
                    {
                        strKizatNM = String.Empty;
                    }
                    else
                    {
                        strKizatNM = row.kizatsu.ToString() + " ";
                    }

                    // 掲載場所.
                    if (String.IsNullOrEmpty(row.basho.ToString()))
                    {
                        strKsaibashoNM = String.Empty;
                    }
                    else
                    {
                        strKsaibashoNM = row.basho.ToString() + " ";
                    }

                    // 掲載版.
                    if (String.IsNullOrEmpty(row.field6.ToString()))
                    {
                        strKsaiban = String.Empty;
                    }
                    else
                    {
                        strKsaiban = row.field6.ToString() + " ";
                    }

                    // サイズ名称.
                    if (String.IsNullOrEmpty(row.saizu.ToString()))
                    {
                        strSizeNM = String.Empty;
                    }
                    else
                    {
                        strSizeNM = row.saizu.ToString() + " ";
                    }

                    // 色刷名称.
                    if (String.IsNullOrEmpty(row.irozuri.ToString()))
                    {
                        strColorNM = String.Empty;
                    }
                    else
                    {
                        if (row.irozuri.ToString() == SHIN_INVALID_COLOR_NAME)
                        {
                            strColorNM = String.Empty;
                        }
                        else
                        {
                            strColorNM = row.irozuri.ToString();
                        }
                    }

                    // 費目.
                    strHimokuNM = row.himknmkj.ToString();

                    // 掲載回数.
                    strKsaicnt = lngKsaicnt.ToString() + "回" + " ";

                    // 備考1.
                    strBiko1 = row.name16.ToString();

                    // 備考2.
                    strBiko2 = row.name17.ToString();

                    // 1行目.
                    outRow.ACOM01 = row.code2.ToString() + " " + row.media.ToString();

                    // 掲載日が記載可能文字数を超えた場合は2行に分割する.
                    if (strKsaibi.Length > SEIKYUKAISYU_ROWMAXBYTE)
                    {
                        // 分割点の算出
                        int sp = strKsaibi.IndexOf(",", SEIKYUKAISYU_ROWMAXBYTE - 10) + 1;

                        // 2行目.
                        outRow.ACOM02 = strKsaibi.Substring(0, sp);

                        // 3行目.
                        outRow.ACOM03 = "  " + strKsaibi.Substring(sp, strKsaibi.Length - sp);

                        // 4行目.
                        outRow.ACOM04 = strKsaicnt + strChoyuNM + strKizatNM + strKsaibashoNM + strColorNM;

                        // 5行目.
                        outRow.ACOM05 = strKsaiban + strSizeNM + BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strKsaiban + strSizeNM + strHimokuNM)) + strHimokuNM;

                        // 6行目.
                        outRow.ACOM06 = strBiko1;

                        // 7行目.
                        outRow.ACOM07 = strBiko2;

                        // 行種別
                        outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                        // 行状態
                        outRow.CTRL_ROW_STATE = "True";
                    }
                    else
                    {
                        // 2行目.
                        outRow.ACOM02 = strKsaibi;

                        // 3行目.
                        outRow.ACOM03 = strKsaicnt + strChoyuNM + strKizatNM + strKsaibashoNM + strColorNM;

                        // 4行目.
                        outRow.ACOM04 = strKsaiban + strSizeNM + BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strKsaiban + strSizeNM + strHimokuNM)) + strHimokuNM;

                        // 5行目.
                        outRow.ACOM05 = strBiko1;

                        // 6行目.
                        outRow.ACOM06 = strBiko2;

                        // 行種別
                        outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                        // 行状態
                        outRow.CTRL_ROW_STATE = "False";
                    }

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }
                else
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NEBIKI;

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 単価.
                    outRow.UNIT_PRICE = NAME_NEBIKI;

                    // 請求金額.
                    Decimal SEIGAK = KKHUtility.DecParse(row.seigak.ToString());

                    // 値引額.
                    Decimal NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }

                dt.AddRepAcomShinRow(outRow);

                i++;
            }

            {
                // 合計行の出力.
                RepDsAcom.RepAcomShinRow totalRow = dt.NewRepAcomShinRow();

                // 請求書番号
                totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                // 発注番号
                totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                // 発注行番号
                totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                // 請求原票番号
                totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                // 行種別
                totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                // 行状態
                totalRow.CTRL_ROW_STATE = "False";

                // 合計.
                totalRow.UNIT_PRICE = NAME_TOTAL;

                // 合計額.
                totalRow.MONEY = totalAmount.ToString();

                dt.AddRepAcomShinRow(totalRow);
            }

            dt.AcceptChanges();

            sheet.DataSource = dt;

            SetSheetStyleShin(sheet);

            ods.Merge(dt);
        }

        /// <summary>
        /// 新聞シートのスタイルを設定する.
        /// </summary>
        /// <param name="sheet"></param>
        private void SetSheetStyleShin(SheetView sheet)
        {
            Boolean state = false;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strOrderRowNoKey = null;             //発注行番号保持用.
            String strBillOriginalNo = null;            //請求原票番号.
            String strBillOriginalNoKey = null;         //請求原票番号保持用.
            String strRowType = null;
            int StartIndex1 = 0;                        //セルマージ用（発注番号・請求書番号）.
            int StartIndex2 = 0;                        //セルマージ用（発注行番号）.
            int StartIndex3 = 0;                        //セルマージ用（請求原票番号）.

            for (int i = 0; i < sheet.Rows.Count; i++)
            {
                // 請求書番号.
                strBillNo = sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_BILL_NO].Value.ToString();

                // 発注番号.
                strOrderNo = sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_ORDER_NO].Value.ToString();

                // 発注行番号.
                strOrderRowNo = sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_ORDER_ROW_NO].Value.ToString();

                // 請求原票番号.
                strBillOriginalNo = sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_BILL_ORIGINAL_NO].Value.ToString();

                // 行種別.
                strRowType = sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_ROW_TYPE].Value.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    // セルの結合（請求書作成順）.
                    if (( i - StartIndex1 ) >= 2)
                    {
                        MergeSheetCellShinForOrderNoOrBillNo(sheet, StartIndex1, i - StartIndex1);
                    }

                    // セルの結合（発注行番号）.
                    if (( i - StartIndex2 ) >= 2)
                    {
                        MergeSheetCellShinForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                    }

                    // セルの結合（請求原票番号）.
                    if (( i - StartIndex3 ) >= 2)
                    {
                        MergeSheetCellShinForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                    }

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;

                    // 発注行番号を保持する.
                    strOrderRowNoKey = strOrderRowNo;

                    // 請求原票番号を保持する.
                    strBillOriginalNoKey = strBillOriginalNo;

                    // セルマージ開始位置の再設定.
                    StartIndex1 = i;
                    StartIndex2 = i;
                    StartIndex3 = i;
                }
                else
                {
                    // 前レコードと発注行番号が違う場合.
                    if (strOrderRowNo != strOrderRowNoKey)
                    {
                        // セルの結合（発注行番号）.
                        if (( i - StartIndex2 ) >= 2)
                        {
                            MergeSheetCellShinForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                        }

                        // 発注行番号を保持する.
                        strOrderRowNoKey = strOrderRowNo;

                        // セルマージ開始位置の再設定.
                        StartIndex2 = i;
                    }

                    // 前レコードと請求原票番号が違う場合.
                    if (( strBillOriginalNo != strBillOriginalNoKey ) || ( String.IsNullOrEmpty(strBillOriginalNo) ))
                    {
                        // セルの結合（請求原票番号）.
                        if (( i - StartIndex3 ) >= 2)
                        {
                            MergeSheetCellShinForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                        }

                        // 請求原票番号を保持する.
                        strBillOriginalNoKey = strBillOriginalNo;

                        // セルマージ開始位置の再設定.
                        StartIndex3 = i;
                    }
                }

                if (strRowType == CTRL_ROW_TYPE_NORMAL)
                {
                    if (sheet.Cells[i, COLIDX_MLIST_SHIN_CTRL_ROW_STATE].Value.ToString() == "True")
                    {
                        state = true;
                    }

                    // セル色の設定.
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM01]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM02]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM03]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM04]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM05]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM06]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_SHIN_ACOM07]);
                }
                else if(strRowType == CTRL_ROW_TYPE_NEBIKI)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_SHIN_UNIT_PRICE ].CellType = _txtType;
                }
                else if(strRowType == CTRL_ROW_TYPE_TOTAL)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_SHIN_UNIT_PRICE ].CellType = _txtType;
                }
            }

            // 幅の自動調整
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM01);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM02);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM03);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM04);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM05);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM06);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_SHIN_ACOM07);

            // 7行目の表示切替.
            if (state)
            {
                sheet.Columns[COLIDX_MLIST_SHIN_ACOM07].Visible = true;
            }
            else
            {
                sheet.Columns[COLIDX_MLIST_SHIN_ACOM07].Visible = false;
            }
        }

        /// <summary>
        /// 新聞シートのセルを結合する（請求書作成順）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellShinForOrderNoOrBillNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_BILL_CREATE_ORDER, count, 1);

            //// 発注番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ORDER_NO, count, 1);
        }

        /// <summary>
        /// 新聞シートのセルを結合する（発注行番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellShinForOrderRowNo(SheetView sheet, int index, int count)
        {
            //// 発注行番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ORDER_ROW_NO, count, 1);

            //// 1行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM01, count, 1);

            //// 2行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM02, count, 1);

            //// 3行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM03, count, 1);

            //// 4行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM04, count, 1);

            //// 5行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM05, count, 1);

            //// 6行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM06, count, 1);

            //// 7行目
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_ACOM07, count, 1);
        }

        /// <summary>
        /// 新聞シートのセルを結合する（請求原票番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellShinForBillOriginalNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_SHIN_BILL_ORIGINAL_NO, count, 1);
        }

        /// <summary>
        /// 雑誌シートに値を設定する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sheet"></param>
        /// <param name="ods"></param>
        private void SetSheetZashi(RepDsAcom ds, SheetView sheet, RepDsAcom ods)
        {
            RepDsAcom.RepAcomZashiDataTable dt = new RepDsAcom.RepAcomZashiDataTable();

            //変数初期化.
            int i = 0;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strBillOriginalNo = null;            //請求原票番号.
            int seiSakJun = 0;                          //請求書作成順.
            Decimal totalAmount = 0M;                   //合計金額.

            foreach (RepDsAcom.RepAcomRow row in ds.RepAcom.Rows)
            {
                // スプレッドシートに行を追加.
                RepDsAcom.RepAcomZashiRow outRow = dt.NewRepAcomZashiRow();

                // 請求書番号.
                strBillNo = row.sonota1.ToString();

                // 発注番号.
                strOrderNo = row.code3.ToString();

                // 発注行番号.
                strOrderRowNo = row.code4.ToString();

                // 請求原票番号
                strBillOriginalNo = row.name6.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合.
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    if (i != 0)
                    {
                        // 合計行の出力.
                        RepDsAcom.RepAcomZashiRow totalRow = dt.NewRepAcomZashiRow();

                        // 請求書番号
                        totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注番号
                        totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注行番号
                        totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                        // 請求原票番号
                        totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                        // 行種別
                        totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                        // 合計.
                        totalRow.UNIT_PRICE = NAME_TOTAL;

                        // 合計額.
                        totalRow.MONEY = totalAmount.ToString();

                        // 合計額の初期化.
                        totalAmount = 0M;

                        dt.AddRepAcomZashiRow(totalRow);

                        i++;
                    }

                    // 請求書作成順をインクリメント.
                    seiSakJun++;

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;
                }

                // 請求書作成順.
                if (seiSakJun == 0)
                {
                    outRow.BILL_CREATE_ORDER = String.Empty;
                }
                else
                {
                    outRow.BILL_CREATE_ORDER = seiSakJun.ToString();
                }

                // 請求書番号
                outRow.CTRL_BILL_NO = strBillNo.ToString();

                // 発注番号
                outRow.CTRL_ORDER_NO = strOrderNo.ToString();

                // 発注行番号
                outRow.CTRL_ORDER_ROW_NO = strOrderRowNo.ToString();

                // 請求原票番号
                outRow.CTRL_BILL_ORIGINAL_NO = strBillOriginalNo.ToString();

                if (row.kbn2 == "0")
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                    // 請求原票No.
                    outRow.BILL_ORIGINAL_NO = row.name6.ToString();

                    // 売上明細No.
                    outRow.SALES_DETAIL_NO = row.name3.ToString() + "-" + row.name4.ToString() + "-" + row.name5.ToString();

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 件名.
                    outRow.SUBJECT = row.kknamekj.ToString();

                    // 雑誌名.
                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        outRow.MAGAZINE_NAME = row.field2.ToString();
                    }
                    else
                    {
                        outRow.MAGAZINE_NAME = row.media.ToString();
                    }

                    String strMMDD;

                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        if (String.IsNullOrEmpty(row.field3.ToString()))
                        {
                            strMMDD = String.Empty;
                        }
                        else
                        {
                            strMMDD = row.field3.ToString();
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row.sonota9.ToString()))
                        {
                            strMMDD = String.Empty;
                        }
                        else
                        {
                            strMMDD = row.sonota9.ToString();
                        }
                    }

                    if (strMMDD.Length == 8)
                    {
                        strMMDD = DateFormat1(strMMDD);
                    }

                    // 発売日.
                    outRow.RELEASE_DATE = strMMDD;

                    // スペース.
                    outRow.SPACE = row.field9.ToString();

                    // 掲載種別.
                    outRow.PUBLISHING_TYPE = row.field6.ToString();

                    // 費目名.
                    outRow.ITEMS_EXPENSES_NAME = row.himknmkj.ToString();

                    // 単価.
                    if (( !String.IsNullOrEmpty(row.sonota7.ToString()) ) && KKHUtility.IsNumeric(row.sonota7.ToString()))
                    {
                        outRow.UNIT_PRICE = KKHUtility.DecParse(row.sonota7.ToString()).ToString();
                    }
                    else
                    {
                        outRow.UNIT_PRICE = row.sonota7.ToString();
                    }

                    // 請求金額.
                    Decimal SEIGAK = KKHUtility.DecParse(row.seigak.ToString());

                    // 値引額.
                    Decimal NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    int lngKsaicnt;
                    String strKsaibi;
                    String strKsaicnt;
                    String strSizeNM;
                    String strColorNM;
                    String strHimokuNM;
                    String strMediaNM;
                    String strBiko1;
                    String strBiko2;

                    // 掲載回数と掲載日の取得.
                    getKeisaibi(ds, strBillNo, strOrderNo, row.code4.ToString(), out lngKsaicnt, out strKsaibi);

                    // メディア名.
                    strMediaNM = row.code2.ToString() + " " + row.media.ToString();

                    // 費目名.
                    strHimokuNM = row.himknmkj.ToString();

                    // 色刷.
                    if (String.IsNullOrEmpty(row.irozuri.ToString()))
                    {
                        strColorNM = String.Empty;
                    }
                    else
                    {
                        strColorNM = row.irozuri.ToString() + " ";
                    }

                    // サイズ.
                    if (String.IsNullOrEmpty(row.saizu.ToString()))
                    {
                        strSizeNM = String.Empty;
                    }
                    else
                    {
                        strSizeNM = row.saizu.ToString() + " ";
                    }

                    // 備考1.
                    strBiko1 = row.name13.ToString();

                    // 備考2.
                    strBiko2 = row.name14.ToString();

                    // 掲載回数
                    strKsaicnt = lngKsaicnt.ToString() + "回" + " ";

                    // 1行目.
                    outRow.ACOM01 = strMediaNM;

                    // 2行目.
                    outRow.ACOM02 = strKsaibi;

                    // 3行目.
                    outRow.ACOM03 = strKsaicnt + strSizeNM + strColorNM + BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strKsaicnt + strSizeNM + strColorNM + strHimokuNM)) + strHimokuNM;

                    // 4行目.
                    outRow.ACOM04 = strBiko1;

                    // 5行目.
                    outRow.ACOM05 = strBiko2;

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }
                else
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NEBIKI;

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 単価.
                    outRow.UNIT_PRICE = NAME_NEBIKI;

                    // 請求金額.
                    Decimal SEIGAK = KKHUtility.DecParse(row.seigak.ToString());

                    // 値引額.
                    Decimal NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }

                dt.AddRepAcomZashiRow(outRow);

                i++;
            }

            {
                // 合計行の出力.
                RepDsAcom.RepAcomZashiRow totalRow = dt.NewRepAcomZashiRow();

                // 請求書番号.
                totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                // 発注番号.
                totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                // 発注行番号.
                totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                // 請求原票番号.
                totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                // 行種別.
                totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                // 合計.
                totalRow.UNIT_PRICE = NAME_TOTAL;

                // 合計額.
                totalRow.MONEY = totalAmount.ToString();

                dt.AddRepAcomZashiRow(totalRow);
            }

            dt.AcceptChanges();

            sheet.DataSource = dt;

            SetSheetStyleZashi(sheet);

            ods.Merge(dt);
        }

        /// <summary>
        /// 雑誌シートのスタイルを設定する.
        /// </summary>
        /// <param name="sheet"></param>
        private void SetSheetStyleZashi(SheetView sheet)
        {
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strOrderRowNoKey = null;             //発注行番号保持用.
            String strBillOriginalNo = null;            //請求原票番号.
            String strBillOriginalNoKey = null;         //請求原票番号保持用.
            String strRowType = null;
            int StartIndex1 = 0;                        //セルマージ用（発注番号・請求書番号）.
            int StartIndex2 = 0;                        //セルマージ用（発注行番号）.
            int StartIndex3 = 0;                        //セルマージ用（請求原票番号）.

            for (int i = 0; i < sheet.Rows.Count; i++)
            {
                // 請求書番号.
                strBillNo = sheet.Cells[i, COLIDX_MLIST_ZASHI_CTRL_BILL_NO].Value.ToString();

                // 発注番号.
                strOrderNo = sheet.Cells[i, COLIDX_MLIST_ZASHI_CTRL_ORDER_NO].Value.ToString();

                // 発注行番号.
                strOrderRowNo = sheet.Cells[i, COLIDX_MLIST_ZASHI_CTRL_ORDER_ROW_NO].Value.ToString();

                // 請求原票番号.
                strBillOriginalNo = sheet.Cells[i, COLIDX_MLIST_ZASHI_CTRL_BILL_ORIGINAL_NO].Value.ToString();

                // 行種別.
                strRowType = sheet.Cells[i, COLIDX_MLIST_ZASHI_CTRL_ROW_TYPE].Value.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    // セルの結合（請求書作成順）.
                    if (( i - StartIndex1 ) >= 2)
                    {
                        MergeSheetCellZashiForOrderNoOrBillNo(sheet, StartIndex1, i - StartIndex1);
                    }

                    // セルの結合（発注行番号）.
                    if (( i - StartIndex2 ) >= 2)
                    {
                        MergeSheetCellZashiForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                    }

                    // セルの結合（請求原票番号）.
                    if (( i - StartIndex3 ) >= 2)
                    {
                        MergeSheetCellZashiForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                    }

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;

                    // 発注行番号を保持する.
                    strOrderRowNoKey = strOrderRowNo;

                    // 請求原票番号を保持する.
                    strBillOriginalNoKey = strBillOriginalNo;

                    // セルマージ開始位置の再設定.
                    StartIndex1 = i;
                    StartIndex2 = i;
                    StartIndex3 = i;
                }
                else
                {
                    // 前レコードと発注行番号が違う場合.
                    if (strOrderRowNo != strOrderRowNoKey)
                    {
                        // セルの結合（発注行番号）.
                        if (( i - StartIndex2 ) >= 2)
                        {
                            MergeSheetCellZashiForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                        }

                        // 発注行番号を保持する.
                        strOrderRowNoKey = strOrderRowNo;

                        // セルマージ開始位置の再設定.
                        StartIndex2 = i;
                    }

                    // 前レコードと請求原票番号が違う場合.
                    if (( strBillOriginalNo != strBillOriginalNoKey ) || ( String.IsNullOrEmpty(strBillOriginalNo) ))
                    {
                        // セルの結合（請求原票番号）.
                        if (( i - StartIndex3 ) >= 2)
                        {
                            MergeSheetCellZashiForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                        }

                        // 請求原票番号を保持する.
                        strBillOriginalNoKey = strBillOriginalNo;

                        // セルマージ開始位置の再設定.
                        StartIndex3 = i;
                    }
                }

                if (strRowType == CTRL_ROW_TYPE_NORMAL)
                {
                    // セル色の設定.
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_ZASHI_ACOM01]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_ZASHI_ACOM02]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_ZASHI_ACOM03]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_ZASHI_ACOM04]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_ZASHI_ACOM05]);
                }
                else if(strRowType == CTRL_ROW_TYPE_NEBIKI)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_ZASHI_UNIT_PRICE ].CellType = _txtType;
                }
                else if(strRowType == CTRL_ROW_TYPE_TOTAL)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_ZASHI_UNIT_PRICE ].CellType = _txtType;
                }
            }

            // 幅の自動調整
            AutoFitColumnWidth(sheet, COLIDX_MLIST_ZASHI_ACOM01);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_ZASHI_ACOM02);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_ZASHI_ACOM03);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_ZASHI_ACOM04);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_ZASHI_ACOM05);
        }

        /// <summary>
        /// 雑誌シートのセルを結合する（請求書作成順）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellZashiForOrderNoOrBillNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_BILL_CREATE_ORDER, count, 1);

            //// 発注番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ORDER_NO, count, 1);
        }

        /// <summary>
        /// 雑誌シートのセルを結合する（発注行番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellZashiForOrderRowNo(SheetView sheet, int index, int count)
        {
            //// 発注行番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ORDER_ROW_NO, count, 1);

            //// 1行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ACOM01, count, 1);

            //// 2行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ACOM02, count, 1);

            //// 3行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ACOM03, count, 1);

            //// 4行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ACOM04, count, 1);

            //// 5行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_ACOM05, count, 1);
        }

        /// <summary>
        /// 雑誌シートのセルを結合する（請求原票番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellZashiForBillOriginalNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_ZASHI_BILL_ORIGINAL_NO, count, 1);
        }

        /// <summary>
        /// 電波シートに値の設定する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sheet"></param>
        /// <param name="ods"></param>
        private void SetSheetDenpa(RepDsAcom ds, SheetView sheet, RepDsAcom ods)
        {
            RepDsAcom.RepAcomDenpaDataTable dt = new RepDsAcom.RepAcomDenpaDataTable();

            //変数初期化.
            int i = 0;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strBillOriginalNo = null;            //請求原票番号.
            int seiSakJun = 0;                          //請求書作成順.
            Decimal totalAmount = 0M;                   //合計金額.

            foreach (RepDsAcom.RepAcomRow row in ds.RepAcom.Rows)
            {
                // スプレッドシートに行を追加.
                RepDsAcom.RepAcomDenpaRow outRow = dt.NewRepAcomDenpaRow();

                // 請求書番号.
                strBillNo = row.sonota1.ToString();

                // 発注番号.
                strOrderNo = row.code3.ToString();

                // 発注行番号.
                strOrderRowNo = row.code4.ToString();

                // 請求原票番号
                strBillOriginalNo = row.name6.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合.
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    if (i != 0)
                    {
                        // 合計行の出力.
                        RepDsAcom.RepAcomDenpaRow totalRow = dt.NewRepAcomDenpaRow();

                        // 請求書番号.
                        totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注番号.
                        totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注行番号.
                        totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                        // 請求原票番号.
                        totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                        // 行種別.
                        totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                        // 合計.
                        totalRow.UNIT_PRICE = NAME_TOTAL;

                        // 合計額.
                        totalRow.MONEY = totalAmount.ToString();

                        // 合計額の初期化.
                        totalAmount = 0M;

                        dt.AddRepAcomDenpaRow(totalRow);

                        i++;
                    }

                    // 請求書作成順をインクリメント.
                    seiSakJun++;

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;
                }

                // 請求書作成順.
                if (seiSakJun == 0)
                {
                    outRow.BILL_CREATE_ORDER = String.Empty;
                }
                else
                {
                    outRow.BILL_CREATE_ORDER = seiSakJun.ToString();
                }

                // 請求書番号
                outRow.CTRL_BILL_NO = strBillNo.ToString();

                // 発注番号
                outRow.CTRL_ORDER_NO = strOrderNo.ToString();

                // 発注行番号
                outRow.CTRL_ORDER_ROW_NO = strOrderRowNo.ToString();

                // 請求原票番号
                outRow.CTRL_BILL_ORIGINAL_NO = strBillOriginalNo.ToString();

                if (row.kbn2 == "0")
                {
                    //請求原票No.
                    outRow.BILL_ORIGINAL_NO = row.name6.ToString();

                    //売上明細No.
                    outRow.SALES_DETAIL_NO = row.name3.ToString() + "-" + row.name4.ToString() + "-" + row.name5.ToString();

                    //発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    //発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    //業務区分.
                    outRow.BUSINESS_DIVISION = row.gyomkbnmei.ToString();

                    //件名.
                    outRow.SUBJECT = row.kknamekj.ToString();

                    String kyokMei;

                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        kyokMei = row.field2.ToString() + "(" + row.field1.ToString() + ")";
                    }
                    else
                    {
                        kyokMei = row.media.ToString() + "(" + row.mediarya.ToString() + ")";
                    }

                    // 放送局名.
                    outRow.BROADCASTING_STATION = kyokMei;

                    // タイムスポット区分を取得.
                    String _strTmSpKbn = row.tmspkbn.ToString();

                    // 期間
                    String strKikan = String.Empty;

                    //タイムスポット区分が「1:タイム」の場合.
                    if (_strTmSpKbn.Equals("1"))
                    {
                        if (String.IsNullOrEmpty(row.field8.ToString()))
                        {
                            strKikan = String.Empty;
                        }
                        else
                        {
                            strKikan = row.field8.ToString();
                        }
                    }
                    // タイムスポット区分が「2:スポット」の場合.
                    else if (_strTmSpKbn.Equals("2"))
                    {
                        if (String.IsNullOrEmpty(row.field4.ToString()))
                        {
                            strKikan = String.Empty;
                        }
                        else
                        {
                            strKikan = row.field4.ToString();
                        }
                    }

                    if (strKikan.Length == 16)
                    {
                        strKikan = DateFormat2(strKikan);
                    }

                    //放送期間.
                    outRow.BROADCASTING_PERIOD = strKikan;

                    //放送時間.
                    //タイムスポット区分が「1:タイム」の場合.
                    if (_strTmSpKbn.Equals("1"))
                    {
                        //放送時間.
                        outRow.BROADCASTING_TIME = row.field4.ToString();
                    }

                    //秒数.
                    outRow.SECOND_NUMBER = KKHUtility.LongParse(row.field5.ToString()).ToString();

                    //回数or本数.
                    outRow.FREQUENCY = KKHUtility.LongParse(row.field6.ToString()).ToString();

                    //ネット局数or放送局数.
                    outRow.BROADCASTING_NUMBER = KKHUtility.LongParse(row.field3.ToString()).ToString();

                    //費目名.
                    outRow.ITEMS_EXPENSES_NAME = row.himknmkj.ToString();

                    //単価.
                    if (( !String.IsNullOrEmpty(row.sonota7.ToString()) ) && KKHUtility.IsNumeric(row.sonota7.ToString()))
                    {
                        outRow.UNIT_PRICE = KKHUtility.DecParse(row.sonota7.ToString()).ToString("###,###,###,##0");
                    }
                    else
                    {
                        outRow.UNIT_PRICE = row.sonota7.ToString();
                    }

                    Decimal SEIGAK = 0M;
                    Decimal NEBIGAK = 0M;

                    // 請求金額.
                    if (!String.IsNullOrEmpty(row.seigak.ToString()))
                    {
                        SEIGAK = KKHUtility.DecParse(row.seigak.ToString());
                    }

                    // 値引額.
                    if (!String.IsNullOrEmpty(row.nebigak.ToString()))
                    {
                        NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());
                    }

                    //金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    String strMediaNM;
                    String strHimokuNM;

                    // メディア名.
                    strMediaNM = row.code2.ToString() + " " + row.media.ToString();

                    // 費目名.
                    strHimokuNM = row.himknmkj.ToString();

                    // タイムスポット区分がタイムの場合.
                    if (_strTmSpKbn.Equals("1"))
                    {
                        int length;
                        String[] strPeriod = null;
                        String[] strYoubi = null;
                        String[] strKaisu = null;
                        String[] strJikan = null;
                        String[] strCmsec = null;
                        String[] strNaiNM = null;
                        String[] strBangm = null;

                        // 電波データの取得.
                        getTimeDetail(ds, strBillNo, strOrderNo, strOrderRowNo, out length, out strPeriod, out strYoubi, out strKaisu, out strJikan, out strCmsec, out strNaiNM, out strBangm);

                        // 1行目.
                        outRow.ACOM01 = strMediaNM;

                        {
                            int index = 0;

                            // 2行目.
                            outRow.ACOM02 = strPeriod[index] + " " + strYoubi[index] + strKaisu[index];

                            // 3行目.
                            outRow.ACOM03 = strJikan[index] + strCmsec[index] + strNaiNM[index];

                            // 4行目.
                            outRow.ACOM04 = strBangm[index];
                        }

                        // 5行目.
                        outRow.ACOM05 = BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strHimokuNM)) + strHimokuNM;

                        for (int j = 0; j < ( length - 1 ); j++)
                        {
                            int index = ( j + 1 );

                            if (j == 0)
                            {
                                // 6行目.
                                outRow.ACOM06 = strPeriod[index] + " " + strYoubi[index] + strKaisu[index];

                                // 7行目.
                                outRow.ACOM07 = strJikan[index] + strCmsec[index] + strNaiNM[index];

                                // 8行目.
                                outRow.ACOM08 = strBangm[index];
                            }
                            else if (j == 1)
                            {
                                // 9行目.
                                outRow.ACOM09 = strPeriod[index] + " " + strYoubi[index] + strKaisu[index];

                                // 10行目.
                                outRow.ACOM10 = strJikan[index] + strCmsec[index] + strNaiNM[index];

                                // 11行目.
                                outRow.ACOM11 = strBangm[index];
                            }
                            else if (j == 2)
                            {
                                // 12行目.
                                outRow.ACOM12 = strPeriod[index] + " " + strYoubi[index] + strKaisu[index];

                                // 13行目.
                                outRow.ACOM13 = strJikan[index] + strCmsec[index] + strNaiNM[index];

                                // 14行目.
                                outRow.ACOM14 = strBangm[index];
                            }
                        }

                        // 行種別
                        outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                        // 行状態
                        outRow.CTRL_ROW_STATE = length.ToString();
                    }
                    // タイムスポット区分がスポットの場合.
                    else
                    {
                        String strPeriod;
                        String strKaisu;
                        String strBiko1;
                        String strBiko2;

                        // 期間.
                        strPeriod = strKikan;

                        // 回数.
                        if (String.IsNullOrEmpty(row.field6.ToString()))
                        {
                            strKaisu = String.Empty;
                        }
                        else
                        {
                            if (KKHUtility.LongParse(row.field6.ToString()) == 0)
                            {
                                strKaisu = String.Empty;
                            }
                            else
                            {
                                strKaisu = KKHUtility.LongParse(row.field6.ToString()) + "回";
                            }
                        }

                        // 備考1
                        strBiko1 = row.name16.ToString();

                        // 備考2
                        strBiko2 = row.name17.ToString();

                        // 1行目.
                        outRow.ACOM01 = strMediaNM;

                        // 2行目.
                        outRow.ACOM02 = strPeriod + " " + strKaisu + BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strKikan + " " + strKaisu + strHimokuNM)) + strHimokuNM;

                        // 3行目.
                        outRow.ACOM03 = strBiko1;

                        // 4行目.
                        outRow.ACOM04 = strBiko2;

                        // 行種別
                        outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                        // 行状態
                        outRow.CTRL_ROW_STATE = "1";
                    }

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }
                else
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NEBIKI;

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 単価.
                    outRow.UNIT_PRICE = NAME_NEBIKI;

                    Decimal SEIGAK = 0M;
                    Decimal NEBIGAK = 0M;

                    // 請求金額.
                    if (!String.IsNullOrEmpty(row.seigak.ToString()))
                    {
                        SEIGAK = KKHUtility.DecParse(row.seigak.ToString());
                    }

                    // 値引額.
                    if (!String.IsNullOrEmpty(row.nebigak.ToString()))
                    {
                        NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());
                    }

                    //金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }

                dt.AddRepAcomDenpaRow(outRow);

                i++;
            }

            {
                // 合計行の出力.
                RepDsAcom.RepAcomDenpaRow totalRow = dt.NewRepAcomDenpaRow();

                // 請求書番号.
                totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                // 発注番号.
                totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                // 発注行番号.
                totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                // 請求原票番号.
                totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                // 行種別.
                totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                // 合計.
                totalRow.UNIT_PRICE = NAME_TOTAL;

                // 合計額.
                totalRow.MONEY = totalAmount.ToString();

                dt.AddRepAcomDenpaRow(totalRow);
            }

            dt.AcceptChanges();

            sheet.DataSource = dt;

            SetSheetStyleDenpa(sheet);

            ods.Merge(dt);
        }

        /// <summary>
        /// 電波シートのスタイルを設定する.
        /// </summary>
        /// <param name="sheet"></param>
        private void SetSheetStyleDenpa(SheetView sheet)
        {
            int state = 0;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strOrderRowNoKey = null;             //発注行番号保持用.
            String strBillOriginalNo = null;            //請求原票番号.
            String strBillOriginalNoKey = null;         //請求原票番号保持用.
            String strRowType = null;
            int StartIndex1 = 0;                        //セルマージ用（発注番号・請求書番号）.
            int StartIndex2 = 0;                        //セルマージ用（発注行番号）.
            int StartIndex3 = 0;                        //セルマージ用（請求原票番号）.

            for (int i = 0; i < sheet.Rows.Count; i++)
            {
                // 請求書番号.
                strBillNo = sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_BILL_NO].Value.ToString();

                // 発注番号.
                strOrderNo = sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_ORDER_NO].Value.ToString();

                // 発注行番号.
                strOrderRowNo = sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_ORDER_ROW_NO].Value.ToString();

                // 請求原票番号.
                strBillOriginalNo = sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_BILL_ORIGINAL_NO].Value.ToString();

                // 行種別.
                strRowType = sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_ROW_TYPE].Value.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    // セルの結合（請求書作成順）.
                    if (( i - StartIndex1 ) >= 2)
                    {
                        MergeSheetCellDenpaForOrderNoOrBillNo(sheet, StartIndex1, i - StartIndex1);
                    }

                    // セルの結合（発注行番号）.
                    if (( i - StartIndex2 ) >= 2)
                    {
                        MergeSheetCellDenpaForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                    }

                    // セルの結合（請求原票番号）.
                    if (( i - StartIndex3 ) >= 2)
                    {
                        MergeSheetCellDenpaForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                    }

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;

                    // 請求原票番号を保持する.
                    strBillOriginalNoKey = strBillOriginalNo;

                    // セルマージ開始位置の再設定.
                    StartIndex1 = i;
                    StartIndex2 = i;
                    StartIndex3 = i;
                }

                else
                {
                    // 前レコードと発注行番号が違う場合.
                    if (strOrderRowNo != strOrderRowNoKey)
                    {
                        // セルの結合（発注行番号）.
                        if (( i - StartIndex2 ) >= 2)
                        {
                            MergeSheetCellDenpaForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                        }

                        // 発注行番号を保持する.
                        strOrderRowNoKey = strOrderRowNo;

                        // セルマージ開始位置の再設定.
                        StartIndex2 = i;
                    }

                    // 前レコードと請求原票番号が違う場合.
                    if (( strBillOriginalNo != strBillOriginalNoKey ) || ( String.IsNullOrEmpty(strBillOriginalNo) ))
                    {
                        // セルの結合（請求原票番号）.
                        if (( i - StartIndex3 ) >= 2)
                        {
                            MergeSheetCellDenpaForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                        }

                        // 請求原票番号を保持する.
                        strBillOriginalNoKey = strBillOriginalNo;

                        // セルマージ開始位置の再設定.
                        StartIndex3 = i;
                    }
                }

                if (strRowType == CTRL_ROW_TYPE_NORMAL)
                {
                    if (state < KKHUtility.IntParse(sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_ROW_STATE].Value.ToString()))
                    {
                        state = KKHUtility.IntParse(sheet.Cells[i, COLIDX_MLIST_DENPA_CTRL_ROW_STATE].Value.ToString());
                    }

                    // セル色の設定.
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM01]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM02]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM03]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM04]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM05]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM06]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM07]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM08]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM09]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM10]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM11]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM12]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM13]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_DENPA_ACOM14]);
                }
                else if(strRowType == CTRL_ROW_TYPE_NEBIKI)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_DENPA_UNIT_PRICE ].CellType = _txtType;
                }
                else if(strRowType == CTRL_ROW_TYPE_TOTAL)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_DENPA_UNIT_PRICE ].CellType = _txtType;
                }
            }

            // 幅の自動調整
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM01);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM02);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM03);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM04);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM05);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM06);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM07);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM08);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM09);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM10);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM11);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM12);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM13);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_DENPA_ACOM14);

            // 6～8行目の表示切替.
            if (state >= 2)
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM06].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM07].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM08].Visible = true;
            }
            else
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM06].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM07].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM08].Visible = false;
            }

            // 9～11行目の表示切替.
            if (state >= 3)
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM09].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM10].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM11].Visible = true;
            }
            else
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM09].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM10].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM11].Visible = false;
            }

            // 12～14行目の表示切替.
            if (state >= 4)
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM12].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM13].Visible = true;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM14].Visible = true;
            }
            else
            {
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM12].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM13].Visible = false;
                sheet.Columns[COLIDX_MLIST_DENPA_ACOM14].Visible = false;
            }
        }

        /// <summary>
        /// 電波シートのセルを結合する（請求書作成順）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellDenpaForOrderNoOrBillNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_BILL_CREATE_ORDER, count, 1);

            //// 発注番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ORDER_NO, count, 1);
        }

        /// <summary>
        /// 電波シートのセルを結合する（発注行番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellDenpaForOrderRowNo(SheetView sheet, int index, int count)
        {
            //// 発注行番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ORDER_ROW_NO, count, 1);

            //// 1行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM01, count, 1);

            //// 2行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM02, count, 1);

            //// 3行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM03, count, 1);

            //// 4行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM04, count, 1);

            //// 5行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM05, count, 1);

            //// 6行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM06, count, 1);

            //// 7行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM07, count, 1);

            //// 8行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM08, count, 1);

            //// 9行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM09, count, 1);

            //// 10行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM10, count, 1);

            //// 11行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM11, count, 1);

            //// 12行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM12, count, 1);

            //// 13行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM13, count, 1);

            //// 14行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_ACOM14, count, 1);
        }

        /// <summary>
        /// 電波シートのセルを結合する（請求原票番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellDenpaForBillOriginalNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_DENPA_BILL_ORIGINAL_NO, count, 1);
        }

        /// <summary>
        /// 交通シートに値を設定する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sheet"></param>
        /// <param name="ods"></param>
        private void SetSheetKotsu(RepDsAcom ds, SheetView sheet, RepDsAcom ods)
        {
            RepDsAcom.RepAcomKotsuDataTable dt = new RepDsAcom.RepAcomKotsuDataTable();

            //変数初期化.
            int i = 0;
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strBillOriginalNo = null;            //請求原票番号.
            int seiSakJun = 0;                          //請求書作成順.
            Decimal totalAmount = 0M;                   //合計金額.

            foreach (RepDsAcom.RepAcomRow row in ds.RepAcom.Rows)
            {
                // スプレッドシートに行を追加.
                RepDsAcom.RepAcomKotsuRow outRow = dt.NewRepAcomKotsuRow();

                // 請求書番号.
                strBillNo = row.sonota1.ToString();

                // 発注番号.
                strOrderNo = row.code3.ToString();

                // 発注行番号.
                strOrderRowNo = row.code4.ToString();

                // 請求原票番号
                strBillOriginalNo = row.name6.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合.
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    if (i != 0)
                    {
                        // 合計行の出力.
                        RepDsAcom.RepAcomKotsuRow totalRow = dt.NewRepAcomKotsuRow();

                        // 請求書番号
                        totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注番号
                        totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                        // 発注行番号
                        totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                        // 請求原票番号.
                        totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                        // 行種別
                        totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                        // 合計.
                        totalRow.UNIT_PRICE = NAME_TOTAL;

                        // 合計額.
                        totalRow.MONEY = totalAmount.ToString();

                        // 合計額の初期化.
                        totalAmount = 0M;

                        dt.AddRepAcomKotsuRow(totalRow);

                        i++;
                    }

                    // 請求書作成順をインクリメント.
                    seiSakJun++;

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;
                }

                // 請求書作成順.
                if (seiSakJun == 0)
                {
                    outRow.BILL_CREATE_ORDER = String.Empty;
                }
                else
                {
                    outRow.BILL_CREATE_ORDER = seiSakJun.ToString();
                }

                // 請求書番号
                outRow.CTRL_BILL_NO = strBillNo.ToString();

                // 発注番号
                outRow.CTRL_ORDER_NO = strOrderNo.ToString();

                // 発注行番号
                outRow.CTRL_ORDER_ROW_NO = strOrderRowNo.ToString();

                // 請求原票番号
                outRow.CTRL_BILL_ORIGINAL_NO = strBillOriginalNo.ToString();

                if (row.kbn2 == "0")
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NORMAL;

                    // 請求原票No.
                    outRow.BILL_ORIGINAL_NO = row.name6.ToString();

                    // 売上明細No.
                    outRow.SALES_DETAIL_NO = row.name3.ToString() + "-" + row.name4.ToString() + "-" + row.name5.ToString();

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 件名.
                    outRow.SUBJECT = row.kknamekj.ToString();

                    // 媒体種類.
                    if (KKHUtility.IsNumeric(row.name3.ToString()))
                    {
                        outRow.MEDIUM_KIND = row.field2.ToString();
                    }
                    else
                    {
                        outRow.PERIOD = String.Empty;
                    }

                    String kikan;

                    if (String.IsNullOrEmpty(row.field5.ToString()))
                    {
                        kikan = string.Empty;
                    }
                    else
                    {
                        kikan = row.field5.ToString();
                    }

                    if (kikan.Length == 16)
                    {
                        kikan = DateFormat2(kikan);
                    }

                    // 期間.
                    outRow.PERIOD = kikan;

                    // 数量.
                    outRow.AMOUNT = row.field6.ToString().Trim();

                    // 費目名.
                    outRow.ITEMS_EXPENSES_NAME = row.himknmkj.ToString().Trim();

                    // 単価.
                    if (( !String.IsNullOrEmpty(row.sonota7.ToString()) ) && KKHUtility.IsNumeric(row.sonota7.ToString()))
                    {
                        outRow.UNIT_PRICE = KKHUtility.DecParse(row.sonota7.ToString()).ToString("###,###,###,##0");
                    }
                    else
                    {
                        outRow.UNIT_PRICE = row.sonota7.ToString();
                    }

                    Decimal SEIGAK = 0M;
                    Decimal NEBIGAK = 0M;

                    // 請求金額.
                    if (!String.IsNullOrEmpty(row.seigak.ToString()))
                    {
                        SEIGAK = KKHUtility.DecParse(row.seigak.ToString());
                    }

                    // 値引額.
                    if (!String.IsNullOrEmpty(row.nebigak.ToString()))
                    {
                        NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());
                    }

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 補足内容.
                    outRow.CONTENT_SUPPLEMENTATION = row.field4.ToString();

                    // 費目補足.
                    outRow.ITEMS_SUPPLEMENTATION = row.field3.ToString();

                    String strMediaNM;
                    String strKsaikkn;
                    String strKsaicnt;
                    String strKksaiNM;
                    String strHimokuNM;
                    String strBiko1;
                    String strBiko2;

                    // 掲載期間.
                    strKsaikkn = row.name14.ToString();

                    // 掲載回数.
                    if (String.IsNullOrEmpty(row.name15.ToString()))
                    {
                        strKsaicnt = String.Empty;
                    }
                    else
                    {
                        strKsaicnt = KKHUtility.LongParse(row.name15.ToString()).ToString() + "回" + " ";
                    }

                    // 交通掲載名.
                    if (String.IsNullOrEmpty(row.basho.ToString()))
                    {
                        strKksaiNM = String.Empty;
                    }
                    else
                    {
                        strKksaiNM = row.basho.ToString() + " ";
                    }

                    // メディア名.
                    strMediaNM = row.code2.ToString() + " " + row.media.ToString();

                    // 費目名.
                    strHimokuNM = row.himknmkj.ToString();

                    // 備考1
                    strBiko1 = row.name12.ToString();

                    // 備考2
                    strBiko2 = row.name13.ToString();

                    // 1行目.
                    outRow.ACOM01 = strMediaNM;

                    // 2行目.
                    outRow.ACOM02 = strKsaikkn;

                    // 3行目.
                    outRow.ACOM03 = strKsaicnt + strKksaiNM + BrankString(SEIKYUKAISYU_ROWMAXBYTE - KKHUtility.GetByteCount(strKsaicnt + strKksaiNM + strHimokuNM)) + strHimokuNM;

                    // 4行目.
                    outRow.ACOM04 = strBiko1;

                    // 5行目.
                    outRow.ACOM05 = strBiko2;

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }
                else
                {
                    // 行種別
                    outRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_NEBIKI;

                    // 発注番号.
                    outRow.ORDER_NO = row.code3.ToString();

                    // 発注行番号.
                    outRow.ORDER_ROW_NO = row.code4.ToString();

                    // 単価.
                    outRow.UNIT_PRICE = NAME_NEBIKI;

                    Decimal SEIGAK = 0M;
                    Decimal NEBIGAK = 0M;

                    // 請求金額.
                    if (!String.IsNullOrEmpty(row.seigak.ToString()))
                    {
                        SEIGAK = KKHUtility.DecParse(row.seigak.ToString());
                    }

                    // 値引額.
                    if (!String.IsNullOrEmpty(row.nebigak.ToString()))
                    {
                        NEBIGAK = KKHUtility.DecParse(row.nebigak.ToString());
                    }

                    // 金額.
                    outRow.MONEY = ( SEIGAK + NEBIGAK ).ToString();

                    // 合計額の加算.
                    totalAmount += SEIGAK + NEBIGAK;
                }

                dt.AddRepAcomKotsuRow(outRow);

                i++;
            }

            {
                // 合計行の出力.
                RepDsAcom.RepAcomKotsuRow totalRow = dt.NewRepAcomKotsuRow();

                // 請求書番号
                totalRow.CTRL_BILL_NO = CTRL_KEY_INVALID_VALUE;

                // 発注番号
                totalRow.CTRL_ORDER_NO = CTRL_KEY_INVALID_VALUE;

                // 発注行番号
                totalRow.CTRL_ORDER_ROW_NO = CTRL_KEY_INVALID_VALUE;

                // 請求原票番号.
                totalRow.CTRL_BILL_ORIGINAL_NO = CTRL_KEY_INVALID_VALUE;

                // 行種別
                totalRow.CTRL_ROW_TYPE = CTRL_ROW_TYPE_TOTAL;

                // 合計.
                totalRow.UNIT_PRICE = NAME_TOTAL;

                // 合計額.
                totalRow.MONEY = totalAmount.ToString();

                dt.AddRepAcomKotsuRow(totalRow);
            }

            dt.AcceptChanges();

            sheet.DataSource = dt;

            SetSheetStyleKotsu(sheet);

            ods.Merge(dt);
        }

        /// <summary>
        /// 交通シートのスタイルを設定する.
        /// </summary>
        /// <param name="sheet"></param>
        private void SetSheetStyleKotsu(SheetView sheet)
        {
            String strBillNo = null;                    //請求書番号.
            String strBillNoKey = String.Empty;         //請求書番号保持用.
            String strOrderNo = null;                   //発注番号.
            String strOrderNoKey = String.Empty;        //発注番号保持用.
            String strOrderRowNo = null;                //発注行番号.
            String strOrderRowNoKey = null;             //発注行番号保持用.
            String strBillOriginalNo = null;            //請求原票番号.
            String strBillOriginalNoKey = null;         //請求原票番号保持用.
            String strRowType = null;
            int StartIndex1 = 0;                        //セルマージ用（発注番号・請求書番号）.
            int StartIndex2 = 0;                        //セルマージ用（発注行番号）.
            int StartIndex3 = 0;                        //セルマージ用（請求原票番号）.

            for (int i = 0; i < sheet.Rows.Count; i++)
            {
                // 請求書番号.
                strBillNo = sheet.Cells[i, COLIDX_MLIST_KOTSU_CTRL_BILL_NO].Value.ToString();

                // 発注番号.
                strOrderNo = sheet.Cells[i, COLIDX_MLIST_KOTSU_CTRL_ORDER_NO].Value.ToString();

                // 発注行番号.
                strOrderRowNo = sheet.Cells[i, COLIDX_MLIST_KOTSU_CTRL_ORDER_ROW_NO].Value.ToString();

                // 請求原票番号.
                strBillOriginalNo = sheet.Cells[i, COLIDX_MLIST_KOTSU_CTRL_BILL_ORIGINAL_NO].Value.ToString();

                // 行種別.
                strRowType = sheet.Cells[i, COLIDX_MLIST_KOTSU_CTRL_ROW_TYPE].Value.ToString();

                // 前レコードと発注番号・請求番号のどちらかが違う場合
                if (( strBillNo != strBillNoKey ) || ( strOrderNo != strOrderNoKey ))
                {
                    // セルの結合（請求書作成順）.
                    if (( i - StartIndex1 ) >= 2)
                    {
                        MergeSheetCellKotsuForOrderNoOrBillNo(sheet, StartIndex1, i - StartIndex1);
                    }

                    // セルの結合（発注行番号）.
                    if (( i - StartIndex2 ) >= 2)
                    {
                        MergeSheetCellKotsuForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                    }

                    // セルの結合（請求原票番号）.
                    if (( i - StartIndex3 ) >= 2)
                    {
                        MergeSheetCellKotsuForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                    }

                    // 請求書番号を保持する.
                    strBillNoKey = strBillNo;

                    // 発注番号を保持する.
                    strOrderNoKey = strOrderNo;


                    // 請求原票番号を保持する.
                    strBillOriginalNoKey = strBillOriginalNo;

                    // セルマージ開始位置の再設定.
                    StartIndex1 = i;
                    StartIndex2 = i;
                    StartIndex3 = i;
                }
                else
                {
                    // 前レコードと発注行番号が違う場合.
                    if (strOrderRowNo != strOrderRowNoKey)
                    {
                        // セルの結合（発注行番号）.
                        if (( i - StartIndex2 ) >= 2)
                        {
                            MergeSheetCellKotsuForOrderRowNo(sheet, StartIndex2, i - StartIndex2);
                        }

                        // 発注行番号を保持する.
                        strOrderRowNoKey = strOrderRowNo;

                        // セルマージ開始位置の再設定.
                        StartIndex2 = i;
                    }

                    // 前レコードと請求原票番号が違う場合.
                    if (( strBillOriginalNo != strBillOriginalNoKey ) || ( String.IsNullOrEmpty(strBillOriginalNo) ))
                    {
                        // セルの結合（請求原票番号）.
                        if (( i - StartIndex3 ) >= 2)
                        {
                            MergeSheetCellKotsuForBillOriginalNo(sheet, StartIndex3, i - StartIndex3);
                        }

                        // 請求原票番号を保持する.
                        strBillOriginalNoKey = strBillOriginalNo;

                        // セルマージ開始位置の再設定.
                        StartIndex3 = i;
                    }
                }

                if (strRowType == CTRL_ROW_TYPE_NORMAL)
                {
                    // セル色の設定.
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_KOTSU_ACOM01]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_KOTSU_ACOM02]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_KOTSU_ACOM03]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_KOTSU_ACOM04]);
                    SetCellColor(sheet.Cells[i, COLIDX_MLIST_KOTSU_ACOM05]);
                }
                else if(strRowType == CTRL_ROW_TYPE_NEBIKI)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_KOTSU_UNIT_PRICE ].CellType = _txtType;
                }
                else if(strRowType == CTRL_ROW_TYPE_TOTAL)
                {
                    // 書式の変更
                    sheet.Cells[ i, COLIDX_MLIST_KOTSU_UNIT_PRICE ].CellType = _txtType;
                }
            }

            // 幅の自動調整
            AutoFitColumnWidth(sheet, COLIDX_MLIST_KOTSU_ACOM01);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_KOTSU_ACOM02);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_KOTSU_ACOM03);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_KOTSU_ACOM04);
            AutoFitColumnWidth(sheet, COLIDX_MLIST_KOTSU_ACOM05);
        }

        /// <summary>
        /// 交通シートのセルを結合する（請求書作成順）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellKotsuForOrderNoOrBillNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_BILL_CREATE_ORDER, count, 1);

            //// 発注番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ORDER_NO, count, 1);
        }

        /// <summary>
        /// 交通シートのセルを結合する（発注行番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellKotsuForOrderRowNo(SheetView sheet, int index, int count)
        {
            //// 発注行番号.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ORDER_ROW_NO, count, 1);

            //// 1行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ACOM01, count, 1);

            //// 2行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ACOM02, count, 1);

            //// 3行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ACOM03, count, 1);

            //// 4行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ACOM04, count, 1);

            //// 5行目.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_ACOM05, count, 1);
        }

        /// <summary>
        /// 交通シートのセルを結合する（請求原票番号）.
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void MergeSheetCellKotsuForBillOriginalNo(SheetView sheet, int index, int count)
        {
            //// 請求書作成順.
            //sheet.AddSpanCell(index, COLIDX_MLIST_KOTSU_BILL_ORIGINAL_NO, count, 1);
        }

        /// <summary>
        /// セルの色を設定する.
        /// </summary>
        /// <param name="cell"></param>
        private void SetCellColor(FarPoint.Win.Spread.Cell cell)
        {
            if (( cell.Value != null ) && ( KKHUtility.GetByteCount(cell.Value.ToString()) > SEIKYUKAISYU_ROWMAXBYTE ))
            {
                cell.BackColor = SEIKAIMAX_COLOR;
            }
            else if (( cell.Value != null ) && ( KKHUtility.GetByteCount(cell.Value.ToString()) > BYTEOVER_BORDERBYTE ))
            {
                cell.BackColor = BYTEOVER_COLOR;
            }
        }

        /// <summary>
        /// セルの幅を自動調整する
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="index"></param>
        private void AutoFitColumnWidth(FarPoint.Win.Spread.SheetView sheet, int index )
        {
            sheet.SetColumnWidth(index, (int)(sheet.GetPreferredColumnWidth(index)));
        }

        /// <summary>
        /// 掲載回数と掲載日を取得する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strBillNo"></param>
        /// <param name="strOrderNo"></param>
        /// <param name="strOrderRowNo"></param>
        /// <param name="lngKsaicnt"></param>
        /// <param name="strKsaibi"></param>
        private void getKeisaibi(RepDsAcom ds, String strBillNo, String strOrderNo, String strOrderRowNo, out int lngKsaicnt, out String strKsaibi)
        {
            // セル結合対象の抽出.
            RepDsAcom.RepAcomRow[] rows = (RepDsAcom.RepAcomRow[])ds.RepAcom.Select("sonota1 = '" + strBillNo + "' and code3 = '" + strOrderNo + "' and code4 = '" + strOrderRowNo + "'", "kbn2, code2, code4, name6, jyutno, jymeino, jyutno");

            // 掲載回数.
            int Ksaicnt = rows.Length;

            // 掲載日.
            String Ksaibi = String.Empty;

            // 掲載日の日付を連結する.
            foreach (RepDsAcom.RepAcomRow row in rows)
            {
                String yyyymmdd;

                if (KKHUtility.IsNumeric(row.name3.ToString()))
                {
                    if (String.IsNullOrEmpty(row.field3.ToString()))
                    {
                        yyyymmdd = String.Empty;
                    }
                    else
                    {
                        yyyymmdd = row.field3.ToString();
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(row.sonota9.ToString()))
                    {
                        yyyymmdd = String.Empty;
                    }
                    else
                    {
                        yyyymmdd = row.sonota9.ToString();
                    }
                }

                if (yyyymmdd.Length != 8)
                {
                    continue;
                }

                yyyymmdd = yyyymmdd.Substring(0, 4) + "/" + yyyymmdd.Substring(4, 2) + "/" + yyyymmdd.Substring(6, 2);

                if (String.IsNullOrEmpty(Ksaibi))
                {
                    Ksaibi = String.Format("{0:M/d}", KKHUtility.StringCnvDateTime(yyyymmdd));
                }
                else
                {
                    Ksaibi += "," + String.Format("{0:%d}", KKHUtility.StringCnvDateTime(yyyymmdd));
                }
            }

            lngKsaicnt = Ksaicnt;

            strKsaibi = Ksaibi;
        }

        /// <summary>
        /// タイムデータの明細を取得する.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strBillNo"></param>
        /// <param name="strOrderNo"></param>
        /// <param name="strOrderRowNo"></param>
        /// <param name="length"></param>
        /// <param name="strPeriod"></param>
        /// <param name="strYoubi"></param>
        /// <param name="strKaisu"></param>
        /// <param name="strJikan"></param>
        /// <param name="strCmsec"></param>
        /// <param name="strNaiNM"></param>
        /// <param name="strBangm"></param>
        private void getTimeDetail(RepDsAcom ds, String strBillNo, String strOrderNo, String strOrderRowNo, out int length, out String[] strPeriod, out String[] strYoubi, out String[] strKaisu, out  String[] strJikan, out String[] strCmsec, out String[] strNaiNM, out String[] strBangm)
        {
            // セル結合対象の抽出.
            RepDsAcom.RepAcomRow[] rows = (RepDsAcom.RepAcomRow[])ds.RepAcom.Select("sonota1 = '" + strBillNo + "' and code3 = '" + strOrderNo + "' and code4 = '" + strOrderRowNo + "' and tmspkbn = '1'", "kbn2, code2, code4, name6, jyutno, jymeino, jyutno");

            int i = 0;
            String[] Period = new String[rows.Length];
            String[] Youbi = new String[rows.Length];
            String[] Kaisu = new String[rows.Length];
            String[] Jikan = new String[rows.Length];
            String[] Cmsec = new String[rows.Length];
            String[] NaiNM = new String[rows.Length];
            String[] Bangm = new String[rows.Length];

            foreach (RepDsAcom.RepAcomRow row in rows)
            {
                // 期間.
                if (String.IsNullOrEmpty(row.field8.ToString()))
                {
                    Period[i] = String.Empty;
                }
                else
                {
                    Period[i] = row.field8.ToString();
                }

                if (Period[i].Length == 16)
                {
                    Period[i] = DateFormat2(Period[i]);
                }

                // 曜日.
                Youbi[i] = GetYobi(row.field7.ToString(), row.field8.ToString()) + " ";

                // 回数.
                if (String.IsNullOrEmpty(row.field6.ToString()))
                {
                    Kaisu[i] = String.Empty;
                }
                else
                {
                    if (KKHUtility.LongParse(row.field6.ToString()) == 0)
                    {
                        Kaisu[i] = String.Empty;
                    }
                    else
                    {
                        Kaisu[i] = KKHUtility.LongParse(row.field6.ToString()) + "回" + " ";
                    }
                }

                // 時間.
                Jikan[i] = row.field4.ToString() + " ";

                // CM秒数
                if (row.name13.ToString().Trim().Length == 0)
                {
                    Cmsec[i] = String.Empty;
                }
                else
                {
                    Cmsec[i] = KKHUtility.LongParse(KKHStrConv.toNarrow(row.name13.ToString())).ToString() + "秒" + " ";
                }

                // 内容名称
                NaiNM[i] = row.name14.ToString();

                // 番組名
                Bangm[i] = row.name15.ToString();

                i++;
            }

            length = rows.Length;
            strPeriod = Period;
            strYoubi = Youbi;
            strKaisu = Kaisu;
            strJikan = Jikan;
            strCmsec = Cmsec;
            strNaiNM = NaiNM;
            strBangm = Bangm;
        }

        /// <summary>
        /// 営業日を取得 
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="filnm">ファイル</param>
        private void ExcelOut(string filnm)
        {
            string workFolderPath = string.Empty;
            string excelFile = string.Empty;
            workFolderPath = strReportTempPath;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;     //マクロファイル名 
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;  //テンプレートファイル名 

            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macroFile , Isid.KKH.Acom.Properties.Resources.Acom_Mcr);
                File.WriteAllBytes(templFile , Isid.KKH.Acom.Properties.Resources.Acom_Template);

                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                acomDs.WriteXml(Path.Combine(workFolderPath , REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言 
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成する.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME" , Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK" , Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR" , Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();
                dtRow["SAVEDIR"] = filnm;
                dtRow["USERNAME"] = tslName.Text;
                //dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath , REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel" , workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _macroDel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力 
                KKHLogUtilityAcom.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAcom.KINO_ID_OPERATION_LOG_REPORT, KKHLogUtilityAcom.DESC_OPERATION_LOG_REPORT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 放送曜日を取得する.
        /// </summary>
        /// <param name="pBit">放送日ビット調</param>
        /// <param name="pKikan">放送期間</param>
        /// <returns></returns>
        private string GetYobi(string pBit, string pKikan ) 
        {
            string _strRslt = string.Empty;

            if (string.IsNullOrEmpty(pBit) || string.IsNullOrEmpty(pKikan))
            {
                return _strRslt;    
            }

            //放送期間の年月を取得する.
            string _strYyyy = pKikan.Substring(0 , 4);
            string _strMm = pKikan.Substring(4 , 2);
            string[] _arr = new string[7];

            //pBitの数だけ処理.
            for (int i = 0 ; i < pBit.Length ; i++)
            {
                //pBitの値を取得.
                string _strBitWk = pBit.Substring(i , 1);

                //pBitが1の場合、曜日を取得する.
                if (_strBitWk.Equals("1")) 
                {
                    //日にちをセットする.
                    int _intDd = i + 1;
                    string _strDd = _intDd.ToString("D2");
                    //string _strYyyyMmDd = _strYyyyMm + _strDd;

                    //曜日を取得する.
                    DateTime dtVal = new DateTime(int.Parse(_strYyyy) , int.Parse(_strMm) , int.Parse(_strDd));
                    string _strYobi = dtVal.DayOfWeek.ToString("d");

                    # region 曜日

                    switch (int.Parse(_strYobi))
                    {
                        case 0:
                            _arr[0] = ",日";
                            break;
                        case 1:
                            _arr[1] = ",月";
                            break;
                        case 2:
                            _arr[2] = ",火";
                            break;
                        case 3:
                            _arr[3] = ",水";
                            break;
                        case 4:
                            _arr[4] = ",木";
                            break;
                        case 5:
                            _arr[5] = ",金";
                            break;
                        case 6:
                            _arr[6] = ",土";
                            break;
                    }

                    # endregion 曜日
                }
            }

            //配列の要素数だけ処理する.
            for (int i = 0 ; i < _arr.Length ; i++) 
            {
                if (!string.IsNullOrEmpty(_arr[i]))
                {
                    _strRslt += _arr[i];
                }
            }

            //括弧をセット.
            _strRslt = "(" + _strRslt.Substring(1) + ")";
            return _strRslt;
        }

        /// <summary>
        /// 文字列の先頭が"0"の場合、削除する 
        /// </summary>
        /// <param name="pStr"></param>
        private string TrimAtamaZero(string pStr)
        {
            //先頭文字を取得 
            string str = pStr.Substring(0, 1);
            
            //"0"の場合 
            if (pStr.Substring(0, 1) == "0")
            {
                //2文字目を取得 
                str = pStr.Substring(1, 1);
            }
            else
            {
                str = pStr;
            }

            return str;
        }

        /// <summary>
        /// yyyymmdd形式の文字列をM/d形式に変換する
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private String DateFormat1(String date)
        {
            return String.Format("{0:M/d}", KKHUtility.StringCnvDateTime(date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2)));
        }

        /// <summary>
        /// yyyymmddyyyymmdd形式の文字列をM/d-M/d形式に変換する
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private String DateFormat2(String date)
        {
            return String.Format("{0:M/d}", KKHUtility.StringCnvDateTime(date.Substring(0, 4) + "/" + date.Substring( 4, 2) + "/" + date.Substring( 6, 2))) + "-" +
                   String.Format("{0:M/d}", KKHUtility.StringCnvDateTime(date.Substring(8, 4) + "/" + date.Substring(12, 2) + "/" + date.Substring(14, 2)));
        }

        /// <summary>
        /// 引数に渡した数の半角スペース文字列を返す
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private String BrankString(int count)
        {
            return String.Empty.PadRight(count, ' ');
        }

        # endregion メソッド

    }
}
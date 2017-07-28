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
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// 得意先ライオン制作室リスト・追加変更リスト出力.
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
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportAddChangeLion : KKHForm
    {
        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "AddChg";

        #region シート名.

        /// <summary>
        /// AD1.
        /// </summary>
        private const String AD1 = "AD1";
        /// <summary>
        /// AD2.
        /// </summary>
        private const String AD2 = "AD2";

        #endregion シート名.

        #region 検索種別.

        /// <summary>
        /// 履歴タイムスタンプ.
        /// </summary>
        public const String RRKTIMSTMP = "RRKTIMSTMP";
        /// <summary>
        /// 制作室リスト(AD1).
        /// </summary>
        public const String SEISAKUAD1 = "SEISAKUAD1";
        /// <summary>
        /// 制作室リスト(AD2).
        /// </summary>
        public const String SEISAKUAD2 = "SEISAKUAD2";
        /// <summary>
        /// 追加変更リスト.
        /// </summary>
        public const String BAITAI = "BAITAI";

        #endregion 検索種別.

        #region 出力帳票コンボボックス.

        /// <summary>
        /// １次制作室リスト.
        /// </summary>
        private const String AD1_SEISAKU = "１次制作室リスト";
        /// <summary>
        /// ２次制作室リスト.
        /// </summary>
        private const String AD2_SEISAKU = "２次制作室リスト";
        /// <summary>
        /// 追加変更リスト.
        /// </summary>
        private const String ADD_CHANGE = "追加変更リスト";

        #endregion 出力帳票コンボボックス.

        #region データテーブルカラム定数.

        /// <summary>
        /// 履歴作成時選択媒体.
        /// </summary>
        private const String RRKGETBAITAI = "RRKGETBAITAI";
        /// <summary>
        /// 履歴AD1フラグ.
        /// </summary>
        private const String RRKAD1FLG = "RRKAD1FLG";

        /// <summary>
        /// 受注No.
        /// </summary>
        private const String JYUTNO = "JYUTNO";
        /// <summary>
        /// 受注明細No.
        /// </summary>
        private const String JYMEINO = "JYMEINO";
        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const String URMEINO = "URMEINO";
        /// <summary>
        /// 連番.
        /// </summary>
        private const String RENBN = "RENBN";
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const String BAITAIKBN = "BAITAIKBN";
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const String BAITAINM = "BAITAINM";
        /// <summary>
        /// ブランドコード.
        /// </summary>
        private const String BRDCD = "BRDCD";
        /// <summary>
        /// ブランド名称.
        /// </summary>
        private const String BRDNM = "BRDNM";
        /// <summary>
        /// 件名.
        /// </summary>
        private const String KENNM = "KENNM";
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const String SEIGAK = "SEIGAK";
        /// <summary>
        /// 消費税額.
        /// </summary>
        private const String TAXAMT = "TAXAMT";
        /// <summary>
        /// SEQ.
        /// </summary>
        private const String SEQ = "SEQ";

        /// <summary>
        /// CM秒数.
        /// </summary>
        private const String BYOSU = "BYOSU";
        /// <summary>
        /// CM本数.
        /// </summary>
        private const String HONSU = "HONSU";
        /// <summary>
        /// スペース.
        /// </summary>
        private const String SPACE = "SPACE";
        /// <summary>
        /// 期間.
        /// </summary>
        private const String TERM = "TERM";
        /// <summary>
        /// 変更区分.
        /// </summary>
        private const String ADDCHGKBN = "ADDCHGKBN";
        /// <summary>
        /// 局誌コード.
        /// </summary>
        private const String KYKSHCD = "KYKSHCD";
        /// <summary>
        /// 局コード.
        /// </summary>
        private const String KYKCD = "KYKCD";
        /// <summary>
        /// 局名.
        /// </summary>
        private const String KYKNM = "KYKNM";
        /// <summary>
        /// 掲載日・号・等.
        /// </summary>
        private const String KEISAIBI = "KEISAIBI";

        /// <summary>
        /// AD1受注No.
        /// </summary>
        private const String AD1JYUTNO = AD1 + JYUTNO;
        /// <summary>
        /// AD1受注明細No.
        /// </summary>
        private const String AD1JYMEINO = AD1 + JYMEINO;
        /// <summary>
        /// AD1売上明細No.
        /// </summary>
        private const String AD1URMEINO = AD1 + URMEINO;
        /// <summary>
        /// AD1連番.
        /// </summary>
        private const String AD1RENBN = AD1 + RENBN;
        /// <summary>
        /// AD1媒体区分コード.
        /// </summary>
        private const String AD1BAITAIKBN = AD1 + BAITAIKBN;
        /// <summary>
        /// AD1媒体区分名称.
        /// </summary>
        private const String AD1BAITAINM = AD1 + BAITAINM;
        /// <summary>
        /// AD1件名.
        /// </summary>
        private const String AD1KENNM = AD1 + KENNM;
        /// <summary>
        /// AD1請求金額.
        /// </summary>
        private const String AD1SEIGAK = AD1 + SEIGAK;
        /// <summary>
        /// AD1局誌コード.
        /// </summary>
        private const String AD1KYKSHCD = AD1 + KYKSHCD;
        /// <summary>
        /// AD1局コード.
        /// </summary>
        private const String AD1KYKCD = AD1 + KYKCD;
        /// <summary>
        /// AD1局名.
        /// </summary>
        private const String AD1KYKNM = AD1 + KYKNM;
        /// <summary>
        /// AD1CM本数.
        /// </summary>
        private const String AD1HONSU = AD1 + HONSU;
        /// <summary>
        /// AD1CM秒数.
        /// </summary>
        private const String AD1BYOSU = AD1 + BYOSU;
        /// <summary>
        /// AD1スペース.
        /// </summary>
        private const String AD1SPACE = AD1 + SPACE;
        /// <summary>
        /// AD1掲載日・号・等.
        /// </summary>
        private const String AD1KEISAIBI = AD1 + KEISAIBI;
        /// <summary>
        /// AD1期間.
        /// </summary>
        private const String AD1TERM = AD1 + TERM;
        /// <summary>
        /// AD1ブランドコード.
        /// </summary>
        private const String AD1BRDCD = AD1 + BRDCD;
        /// <summary>
        /// AD1ブランド名称.
        /// </summary>
        private const String AD1BRDNM = AD1 + BRDNM;
        /// <summary>
        /// AD1消費税額.
        /// </summary>
        private const String AD1TAXAMT = AD1 + TAXAMT;

        /// <summary>
        /// AD2受注No.
        /// </summary>
        private const String AD2JYUTNO = AD2 + JYUTNO;
        /// <summary>
        /// AD2受注明細No.
        /// </summary>
        private const String AD2JYMEINO = AD2 + JYMEINO;
        /// <summary>
        /// AD2売上明細No.
        /// </summary>
        private const String AD2URMEINO = AD2 + URMEINO;
        /// <summary>
        /// AD2連番.
        /// </summary>
        private const String AD2RENBN = AD2 + RENBN;
        /// <summary>
        /// AD2媒体区分コード.
        /// </summary>
        private const String AD2BAITAIKBN = AD2 + BAITAIKBN;
        /// <summary>
        /// AD2媒体名称.
        /// </summary>
        private const String AD2BAITAINM = AD2 + BAITAINM;
        /// <summary>
        /// AD2件名.
        /// </summary>
        private const String AD2KENNM = AD2 + KENNM;
        /// <summary>
        /// AD2請求金額.
        /// </summary>
        private const String AD2SEIGAK = AD2 + SEIGAK;
        /// <summary>
        /// AD2局誌コード.
        /// </summary>
        private const String AD2KYKSHCD = AD2 + KYKSHCD;
        /// <summary>
        /// AD2局コード.
        /// </summary>
        private const String AD2KYKCD = AD2 + KYKCD;
        /// <summary>
        /// AD2局名.
        /// </summary>
        private const String AD2KYKNM = AD2 + KYKNM;
        /// <summary>
        /// AD2CM本数.
        /// </summary>
        private const String AD2HONSU = AD2 + HONSU;
        /// <summary>
        /// AD2CM秒数.
        /// </summary>
        private const String AD2BYOSU = AD2 + BYOSU;
        /// <summary>
        /// AD2スペース.
        /// </summary>
        private const String AD2SPACE = AD2 + SPACE;
        /// <summary>
        /// AD2掲載日・号・等.
        /// </summary>
        private const String AD2KEISAIBI = AD2 + KEISAIBI;
        /// <summary>
        /// AD2期間.
        /// </summary>
        private const String AD2TERM = AD2 + TERM;
        /// <summary>
        /// AD2ブランドコード.
        /// </summary>
        private const String AD2BRDCD = AD2 + BRDCD;
        /// <summary>
        /// AD2ブランド名称.
        /// </summary>
        private const String AD2BRDNM = AD2 + BRDNM;
        /// <summary>
        /// AD2消費税額.
        /// </summary>
        private const String AD2TAXAMT = AD2 + TAXAMT;

        #endregion データテーブルカラム定数.

        #region SEQ定数.

        /// <summary>
        /// 追加.
        /// </summary>
        private const String SEQ_ADD = "1";
        private const String ADD = "追加";
        /// <summary>
        /// 削除.
        /// </summary>
        private const String SEQ_DEL = "2";
        private const String DEL = "削除";
        /// <summary>
        /// 変更.
        /// </summary>
        private const String SEQ_CHG = "3";
        private const String CHG = "変更";

        #endregion SEQ定数.

        #region スプレッド定数.

        #region 履歴タイムスタンプスプレッド定数.

        /// <summary>
        /// 履歴タイムスタンプ.
        /// </summary>
        private const int COLIDX_RRK_RRKTIMSTMP = 0;

        #endregion 履歴タイムスタンプスプレッド定数.

        #region 制作室(AD1)スプレッド定数.

        /// <summary>
        /// 変更区分.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_ADDCHGDIV = 0;
        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_URMEINO = 1;
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_BAITAIKBN = 2;
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_BAITAINM = 3;
        /// <summary>
        /// ブランドコード.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_BRDCD = 4;
        /// <summary>
        /// ブランド名称.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_BRDNM = 5;
        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_KENNM = 6;
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_SEIGAK = 7;
        /// <summary>
        /// 消費税額.
        /// </summary>
        private const int COLIDX_SEISAKU_AD1_TAXAMT = 8;

        #endregion 制作室(AD1)スプレッド定数.

        #region 制作室(AD2)スプレッド定数.

        /// <summary>
        /// 変更区分.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_ADDCHGDIV = 0;
        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_URMEINO = 1;
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_BAITAIKBN = 2;
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_BAITAINM = 3;
        /// <summary>
        /// ブランドコード.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_BRDCD = 4;
        /// <summary>
        /// ブランド名称.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_BRDNM = 5;
        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_KENNM = 6;
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_SEIGAK = 7;
        /// <summary>
        /// 消費税額.
        /// </summary>
        private const int COLIDX_SEISAKU_AD2_TAXAMT = 8;

        #endregion 制作室(AD2)スプレッド定数.

        #region 追加変更(AD1)スプレッド定数.

        /// <summary>
        /// 変更区分.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_ADDCHGDIV = 0;
        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_URMEINO = 1;
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_BAITAIKBN = 2;
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_BAITAINM = 3;
        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_KENNM = 4;
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_SEIGAK = 5;
        /// <summary>
        /// 局誌コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_KYKSHCD = 6;
        /// <summary>
        /// 局コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_KYKCD = 7;
        /// <summary>
        /// 局名.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_KYKNM = 8;
        /// <summary>
        /// CM秒数.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_BYOSU = 9;
        /// <summary>
        /// CM本数.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_HONSU = 10;
        /// <summary>
        /// CM総秒数.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_SOUBYOSU = 11;
        /// <summary>
        /// スペース.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_SPACE = 12;
        /// <summary>
        /// 掲載日・号・等.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_KEISAIBI = 13;
        /// <summary>
        /// 期間.
        /// </summary>
        private const int COLIDX_BAITAI_AD1_TERM = 14;

        #endregion 追加変更(AD1)スプレッド定数.

        #region 追加変更(AD2)スプレッド定数.

        /// <summary>
        /// 変更区分.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_ADDCHGDIV = 0;
        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_UMEINO = 1;
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_BAITAIKBN = 2;
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_BAITAINM = 3;
        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_KENNM =4;
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_SEIGAK = 5;
        /// <summary>
        /// 局誌コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_KYKSHCD = 6;
        /// <summary>
        /// 局コード.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_KYKCD = 7;
        /// <summary>
        /// 局名.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_KYKNM = 8;
        /// <summary>
        /// CM秒数.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_BYOSU = 9;
        /// <summary>
        /// CM本数.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_HONSU = 10;
        /// <summary>
        /// CM総秒数.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_SOUBYOSU = 11;
        /// <summary>
        /// スペース.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_SPACE = 12;
        /// <summary>
        /// 掲載日・号・等.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_KEISAIBI = 13;
        /// <summary>
        /// 期間.
        /// </summary>
        private const int COLIDX_BAITAI_AD2_TERM = 14;

        #endregion 追加変更(AD2)スプレッド定数.

        #endregion スプレッド定数.

        #region 出力帳票.

        #region 制作室リスト.

        /// <summary>
        /// 制作室リストExcelマクロファイル名.
        /// </summary>
        private static readonly string REP_SEISAKU_MACRO_FILENAME = "Lion_Seisaku_Mcr.xlsm";
        /// <summary>
        /// 制作室リストExcelテンプレートファイル名.
        /// </summary>
        private static readonly string REP_SEISAKU_TEMPLATE_FILENAME = "Lion_Seisaku_Template.xlsx";
        /// <summary>
        /// 制作室リストデータXMLファイル名.
        /// </summary>
        private static readonly string REP_SEISAKU_DATA_XML_FILENAME = "Lion_Seisaku_Data.xml";
        /// <summary>
        /// 制作室リストプロパティXMLファイル名.
        /// </summary>
        private static readonly string REP_SEISAKU_PROP_XML_FILENAME = "Lion_Seisaku_Prop.xml";

        #endregion 制作室リスト.

        #region 追加変更リスト.

        /// <summary>
        /// 追加変更リストExcelマクロファイル名.
        /// </summary>
        private static readonly string REP_BAITAI_MACRO_FILENAME = "Lion_Baitai_Mcr.xlsm";
        /// <summary>
        /// 追加変更リストExcelテンプレートファイル名.
        /// </summary>
        private static readonly string REP_BAITAI_TEMPLATE_FILENAME = "Lion_Baitai_Template.xlsx";
        /// <summary>
        /// 追加変更リスト(内部資料)Excelテンプレートファイル名.
        /// </summary>
        private static readonly string REP_BAITAI_TEMPLATE_FILENAME2 = "Lion_Baitai_Template2.xlsx";
        /// <summary>
        /// 追加変更リストデータXMLファイル名.
        /// </summary>
        private static readonly string REP_BAITAI_DATA_XML_FILENAME = "Lion_Baitai_Data.xml";
        /// <summary>
        /// 追加変更リストプロパティXMLファイル名.
        /// </summary>
        private static readonly string REP_BAITAI_PROP_XML_FILENAME = "Lion_Baitai_Prop.xml";

        #endregion 追加変更リスト.

        #endregion 出力帳票.

        #region メインスプレッド座標.

        /// <summary>
        /// 履歴タイムスタンプスプレッド非表示時のX座標.
        /// </summary>
        private const int MAIN_X1 = 40;
        /// <summary>
        /// 履歴タイムスタンプスプレッド表示時のX座標.
        /// </summary>
        private const int MAIN_X2 = 150;
        /// <summary>
        /// 履歴タイムスタンプスプレッド非表示時の高さ.
        /// </summary>
        private const int MAIN_Y1 = 600;
        /// <summary>
        /// 履歴タイムスタンプスプレッド表示時の高さ.
        /// </summary>
        private const int MAIN_Y2 = 490;

        #endregion メインスプレッド座標.

        #region 媒体区分.

        /// <summary>
        /// 新聞.
        /// </summary>
        private const String BAITAI_NP = "新聞";

        #endregion 媒体区分.

        #region 帳票出力情報.

        /// <summary>
        /// 制作室リスト：005(帳票出力情報抽出用)
        /// </summary>
        private const string REP_KEY_SYBT = "005";

        #endregion 帳票出力情報.

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// Naviパラメータ.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 出力用履歴タイムスタンプ.
        /// </summary>
        private String _rrkTimStmp;

        /// <summary>
        /// マスタ用データセット.
        /// </summary>
        private MastLion MastLionDs = new MastLion();
        /// <summary>
        /// 帳票出力リスト用データセット.
        /// </summary>
        private AddChgDsLion addChgDsLion = new AddChgDsLion();

        /// <summary>
        /// Excelマクロファイル名.
        /// </summary>
        private string _mStrMacroFileNm;
        /// <summary>
        /// Excelテンプレートファイル名.
        /// </summary>
        private string _mStrTemplateFileNm;
        /// <summary>
        /// Excelテンプレートファイル名.
        /// </summary>
        private string _mStrTemplateFileNm2;

        /// <summary>
        /// 帳票出力名.
        /// </summary>
        private string _mStrOutReportNm;
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;
        /// <summary>
        /// １次制作室リスト帳票名変数.
        /// </summary>
        private string _mStrRepFileNm1 = string.Empty;
        /// <summary>
        /// ２次制作室リスト帳票名変数.
        /// </summary>
        private string _mStrRepFileNm2 = string.Empty;
        /// <summary>
        /// 追加変更リスト帳票名変数.
        /// </summary>
        private string _mStrRepFileNm3 = string.Empty;

        /// <summary>
        /// 履歴AD1フラグ対象スプレッド行.
        /// </summary>
        private int _intRrkAD1FlgRow = 0;

        /// <summary>
        /// 履歴保存担当者マスタデータテーブル.
        /// </summary>
        DataTable dtTanto = new DataTable("TANTO");

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportAddChangeLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        #region 画面ロード時.

        /// <summary>
        /// 画面表示時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAddChgLion_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 画面ロード時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAddChgLion_Shown(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            //検索年月取得.
            string hostdate = getHostDate();
            txtYm.Value = hostdate.Substring(0, 6);

            //検索年月コンボボックス設定.
            txtYm.cmbYM_SetDate();

            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //Excelボタンを非活性化.
            btnXls.Enabled = false;

            //スプレッド初期化.
            InitSpread();

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
                //１次制作室リスト帳票名.
                _mStrRepFileNm1 = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
                //２次制作室リスト帳票名.
                _mStrRepFileNm2 = comResult2.CommonDataSet.SystemCommon[0].field4.ToString();
                //追加変更リスト帳票名.
                _mStrRepFileNm3 = comResult2.CommonDataSet.SystemCommon[0].field5.ToString();
            }

            //グリッドの設定.
            statusStrip1.Items["tslval1"].Text = "0件";

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
                base.CloseLoadingDialog();
                Navigator.Backward(this, null, _naviParam, true);
                return;
            }

            //コンボボックスの先頭の項目をセット.
            cboReport.SelectedIndex = 0;

            //履歴タイムスタンプスプレッド非表示.
            sprRrkTimStmp.Visible = false;

            //メインスプレッド位置設定.
            sprMain.Top = MAIN_X1;
            sprMain.Height = MAIN_Y1;
            sprMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _rrkTimStmp = null;

            base.CloseLoadingDialog();
        }

        #endregion 画面ロード時.

        #region 戻るボタン.

        /// <summary>
        /// 戻るボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender , EventArgs e)
        {
            if (_mStrMacroFileNm != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_mStrMacroFileNm);

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

        #endregion 戻るボタン.

        #region 検索ボタン.

        /// <summary>
        /// 検索ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender , EventArgs e)
        {
            //１次制作室リストの場合.
            if (cboReport.SelectedIndex == 0)
            {
                //１次制作室リストデータ取得.
                GetRecord();
            }
            else 
            {
                //履歴タイムスタンプが取得できない場合.
                if (string.IsNullOrEmpty(_rrkTimStmp))
                {
                    //履歴タイムスタンプスプレッド設定.
                    SetRrkTimStmpSpread(cboReport.SelectedIndex);
                }

                //履歴タイムスタンプが取得できない場合は処理終了.
                if (string.IsNullOrEmpty(_rrkTimStmp))
                {
                    //メッセージ：HB-W0023 該当するデータがありません。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                    return;
                }

                //２次制作室リスト・追加変更リストデータ取得.
                GetRecord();
            }
        }

        #endregion 検索ボタン.

        #region 帳票出力ボタン.

        /// <summary>
        /// 帳票出力ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender , EventArgs e)
        {
            //メッセージタイトル.
            String strMsgCaption = String.Empty;

            //SaveFileDialogクラスのインスタンス生成.
            SaveFileDialog sfd = new SaveFileDialog();

            //本日日付.
            DateTime now = DateTime.Now;

            //制作室リストの場合.
            if (cboReport.Text.Equals(AD1_SEISAKU) || cboReport.Text.Equals(AD2_SEISAKU))
            {
                //出力用年月.
                string strOutYymm = string.Empty;
                string strTmpYymm = txtYm.Value;
                int intTmpMm = int.Parse(strTmpYymm.Substring(4, 2));
                strOutYymm = strTmpYymm.Substring(0, 4) + "." + intTmpMm.ToString();
            
                //１次制作室リストの場合.
                if (cboReport.Text.Equals(AD1_SEISAKU))
                {
                    //出力ファイル名.
                    sfd.FileName = _mStrRepFileNm1.Replace("@@@", strOutYymm) + "　" + now.ToString("yyyy.MM.dd") + "d.xls";
                    //メッセージタイトル.
                    strMsgCaption = AD1_SEISAKU;
                }
                //２次制作室リストの場合.
                else if (cboReport.Text.Equals(AD2_SEISAKU))
                {
                    //出力ファイル名.
                    sfd.FileName = _mStrRepFileNm2.Replace("@@@", strOutYymm) + "　" + now.ToString("yyyy.MM.dd") + "d.xls";
                    //メッセージタイトル.
                    strMsgCaption = AD2_SEISAKU;
                }
            }
            //追加変更リストの場合.
            else
            {
                //出力用年月.
                string strMm = int.Parse(txtYm.Value.ToString().Substring(4, 2)).ToString();
                //帳票ファイル名.
                sfd.FileName = _mStrRepFileNm3.Replace("@@@", strMm) + " " + now.ToString("MMdd") + "提出d.xls";
                //メッセージタイトル.
                strMsgCaption = ADD_CHANGE;
            }

            //デフォルト表示するフォルダ名指定.
            sfd.InitialDirectory = _mStrRepAdrs;

            //[ファイルの種類]に表示されるファイル種別指定.
            sfd.Filter = "XLSファイル(*.xls)|*.xls";

            //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            //タイトル設定.
            sfd.Title = "保存先のファイルを設定して下さい。";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログ表示.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名ファイルを削除.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, strMsgCaption, MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName, now);
            }

            sfd.Dispose();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
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
            this.ActiveControl = null;
        }

        #endregion ヘルプボタン.

        #region 年月テキストボックス.

        /// <summary>
        /// 年月テキストボックス入力時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Leave(object sender, EventArgs e)
        {
            //出力帳票に１次制作室リストを設定.
            cboReport.SelectedIndex = 0;
            //１次制作室リストスプレッド初期化.
            spsAD1Seisaku.Rows.Count = 0;
            //変更区分非表示.
            spsAD1Seisaku.Columns[COLIDX_SEISAKU_AD1_ADDCHGDIV].Visible = false;

            //履歴タイムスタンプスプレッド非表示.
            sprRrkTimStmp.Visible = false;

            //メインスプレッド位置設定.
            sprMain.Top = MAIN_X1;
            //sprMain.Height = MAIN_Y1;
            sprMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _rrkTimStmp = null;

            //帳票出力ボタン無効化.
            btnXls.Enabled = false;
        }

        #endregion 年月テキストボックス.

        #region 出力帳票コンボボックス.

        /// <summary>
        /// 出力帳票コンボボックス選択時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReport.Text.Equals(AD1_SEISAKU))
            {
                //１次制作室リストの場合.
                spsAD1Seisaku.Visible = true;
                spsAD2Seisaku.Visible = false;
                spsAD1Baitai.Visible = false;
                spsAD2Baitai.Visible = false;
                spsAD1Seisaku.SheetName = AD1;
                
                //履歴タイムスタンプスプレッド非表示.
                sprRrkTimStmp.Visible = false;

                //メインスプレッド位置設定.
                sprMain.Top = MAIN_X1;
                sprMain.Height = this.Height - 100;
                sprMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                _rrkTimStmp = null;

                //メインスプレッドクリア.
                spsAD1Seisaku.Rows.Count = 0;
                spsAD2Seisaku.Rows.Count = 0;

                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //変更区分非表示.
                spsAD1Seisaku.Columns[COLIDX_SEISAKU_AD1_ADDCHGDIV].Visible = false;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = "0件";
            }
            else if (cboReport.Text.Equals(AD2_SEISAKU))
            {
                //２次制作室リストの場合.
                spsAD1Seisaku.Visible = true;
                spsAD2Seisaku.Visible = true;
                spsAD1Baitai.Visible = false;
                spsAD2Baitai.Visible = false;
                spsAD1Seisaku.SheetName = AD1;
                spsAD2Seisaku.SheetName = AD2;

                //履歴タイムスタンプスプレッド表示.
                sprRrkTimStmp.Visible = true;
                spsRrkTimStmp.Rows.Count = 0;

                //メインスプレッド位置設定.
                sprMain.Top = MAIN_X2;
                sprMain.Height = this.Height - 220;
                sprMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                //メインスプレッドクリア.
                spsAD1Seisaku.Rows.Count = 0;
                spsAD2Seisaku.Rows.Count = 0;

                //垂直スクロールバーを作業中は非表示にする.
                sprRrkTimStmp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //制作AD2シート選択.
                sprMain.ActiveSheetIndex = 1;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = "0件";
            }
            else if (cboReport.Text.Equals(ADD_CHANGE))
            {
                //追加変更リストの場合.
                spsAD1Seisaku.Visible = false;
                spsAD2Seisaku.Visible = false;
                spsAD1Baitai.Visible = true;
                spsAD2Baitai.Visible = true;
                spsAD1Baitai.SheetName = AD1;
                spsAD2Baitai.SheetName = AD2;

                //履歴タイムスタンプスプレッド表示.
                sprRrkTimStmp.Visible = true;
                spsRrkTimStmp.Rows.Count = 0;

                //メインスプレッド位置設定.
                sprMain.Top = MAIN_X2;
                sprMain.Height = this.Height - 220;
                sprMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                //メインスプレッドクリア.
                spsAD1Baitai.Rows.Count = 0;
                spsAD2Baitai.Rows.Count = 0;

                //垂直スクロールバーを作業中は非表示にする.
                sprRrkTimStmp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //媒体AD2シート選択.
                sprMain.ActiveSheetIndex = 3;

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = "0件";
            }
        }

        #endregion 出力帳票コンボボックス.

        #region 履歴タイムスタンプスプレッドセル選択時.

        /// <summary>
        /// 履歴タイムスタンプスプレッドセル選択時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sprRrkTimStmp_CellClick(object sender, CellClickEventArgs e)
        {
            //ヘッダがクリックされた時は何もしない.
            if (e.ColumnHeader)
            {
                return;
            }

            //選択行の履歴タイムスタンプ取得.
            _rrkTimStmp = spsRrkTimStmp.Cells[e.Row, COLIDX_RRK_RRKTIMSTMP].Value.ToString();
            spsRrkTimStmp.AddSelection(e.Row, 0, 1, 1);
        }

        #endregion 履歴タイムスタンプスプレッドセル選択時.
        
        #region メインスプレッドタブ選択.

        /// <summary>
        /// メインスプレッドタブ選択時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sprMain_SheetTabClick(object sender, SheetTabClickEventArgs e)
        {
            //制作室リストAD1シートの場合.
            if (e.SheetTabIndex == 0)
            {
                //件数をセット.
                statusStrip1.Items["tslval1"].Text = spsAD1Seisaku.Rows.Count + "件";
            }
            //制作室リストAD2シートの場合.
            else if (e.SheetTabIndex == 1)
            {
                //件数をセット.
                statusStrip1.Items["tslval1"].Text = spsAD2Seisaku.Rows.Count + "件";
            }
            //追加変更リストAD1シートの場合.
            else if (e.SheetTabIndex == 2)
            {
                //件数をセット.
                statusStrip1.Items["tslval1"].Text = spsAD1Baitai.Rows.Count + "件";
            }
            //追加変更リストAD2シートの場合.
            else if (e.SheetTabIndex == 3)
            {
                //件数をセット.
                statusStrip1.Items["tslval1"].Text = spsAD2Baitai.Rows.Count + "件";
            }

        }

        #endregion メインスプレッドタブ選択.

        #region 帳票出力非活性化.

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

        #endregion 帳票出力非活性化.

        #endregion イベント.

        #region メソッド.

        #region レコード取得.

        /// <summary>
        /// レコード取得.
        /// </summary>
        private void GetRecord()
        {
            int _intRow = 0;

            //ローディング表示開始.
            base.ShowLoadingDialog();

            //年月の取得.
            string yyyyMm = txtYm.Value;

            //出力帳票名を取得.
            _mStrOutReportNm = cboReport.Text;

            //検索種別.
            String strType = String.Empty;
            
            //１次制作室リストの場合.
            if (_mStrOutReportNm.Equals(AD1_SEISAKU))
            {
                //検索種別.
                strType = SEISAKUAD1;

                //*******************
                //データ取得.
                //*******************
                //制作室リスト(AD1).
                addChgDsLion = FindSeisakuAD1(yyyyMm, strType);

                if (addChgDsLion.SeisakuAD1.Rows.Count == 0)
                {
                    //メッセージ：HB-W0023 該当するデータがありません。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                    return;
                }

                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //制作室リスト(AD1)スプレッド設定.
                spsAD1Seisaku.Rows.Count = 0;

                //変更区分非表示.
                spsAD1Seisaku.Columns[COLIDX_SEISAKU_AD1_ADDCHGDIV].Visible = false;

                for (int i = 0; i < addChgDsLion.SeisakuAD1.Rows.Count; i++)
                {
                    //行追加.
                    spsAD1Seisaku.Rows.Add(spsAD1Seisaku.RowCount, 1);

                    //売上明細No.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_URMEINO].Value =
                        addChgDsLion.SeisakuAD1.Rows[i][JYUTNO] + "-" + addChgDsLion.SeisakuAD1.Rows[i][JYMEINO] + "-" + addChgDsLion.SeisakuAD1.Rows[i][URMEINO];
                    //媒体区分コード.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BAITAIKBN].Value = addChgDsLion.SeisakuAD1.Rows[i][BAITAIKBN];
                    //媒体名称.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BAITAINM].Value = addChgDsLion.SeisakuAD1.Rows[i][BAITAINM];
                    //ブランドコード.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BRDCD].Value = addChgDsLion.SeisakuAD1.Rows[i][BRDCD];
                    //ブランド名称.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BRDNM].Value = addChgDsLion.SeisakuAD1.Rows[i][BRDNM];
                    //件名.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_KENNM].Value = addChgDsLion.SeisakuAD1.Rows[i][KENNM];
                    //請求金額.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_SEIGAK].Value = addChgDsLion.SeisakuAD1.Rows[i][SEIGAK];
                    //消費税額.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_TAXAMT].Value = addChgDsLion.SeisakuAD1.Rows[i][TAXAMT];

                    _intRow++;
                }

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = addChgDsLion.SeisakuAD1.Rows.Count + "件";
            }
            //２次制作室リストの場合.
            else if (_mStrOutReportNm.Equals(AD2_SEISAKU))
            {
                //検索種別.
                strType = SEISAKUAD2;

                //履歴タイムスタンプスプレッドが初期状態の場合.
                if (spsRrkTimStmp.Rows.Count == 0)
                {
                    //履歴タイムスタンプスプレッド設定.
                    SetRrkTimStmpSpread(cboReport.SelectedIndex);
                }

                //*******************
                //データ取得.
                //*******************
                //制作室リスト(AD2).
                addChgDsLion = FindSeisakuAD2(yyyyMm, strType);

                if (addChgDsLion.SeisakuAD2.Rows.Count == 0)
                {
                    //メッセージ：HB-W0023 該当するデータがありません。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                    return;
                }
                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //制作室リスト(AD1)スプレッド設定.
                spsAD1Seisaku.Rows.Count = 0;

                //AD1変更区分表示.
                spsAD1Seisaku.Columns[COLIDX_SEISAKU_AD1_ADDCHGDIV].Visible = true;

                //初期化.
                _intRow = 0;

                for (int i = 0; i < addChgDsLion.SeisakuAD1.Rows.Count; i++)
                {
                    //行追加.
                    spsAD1Seisaku.Rows.Add(spsAD1Seisaku.RowCount, 1);

                    //売上明細No.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_URMEINO].Value =
                        addChgDsLion.SeisakuAD1.Rows[i][JYUTNO] + "-" + addChgDsLion.SeisakuAD1.Rows[i][JYMEINO] + "-" + addChgDsLion.SeisakuAD1.Rows[i][URMEINO];
                    //媒体区分コード.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BAITAIKBN].Value = addChgDsLion.SeisakuAD1.Rows[i][BAITAIKBN];
                    //媒体名称.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BAITAINM].Value = addChgDsLion.SeisakuAD1.Rows[i][BAITAINM];
                    //ブランドコード.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BRDCD].Value = addChgDsLion.SeisakuAD1.Rows[i][BRDCD];
                    //ブランド名称.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_BRDNM].Value = addChgDsLion.SeisakuAD1.Rows[i][BRDNM];
                    //件名.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_KENNM].Value = addChgDsLion.SeisakuAD1.Rows[i][KENNM];
                    //請求金額.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_SEIGAK].Value = addChgDsLion.SeisakuAD1.Rows[i][SEIGAK];
                    //消費税額.
                    spsAD1Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD1_TAXAMT].Value = addChgDsLion.SeisakuAD1.Rows[i][TAXAMT];

                    _intRow++;
                }

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = addChgDsLion.SeisakuAD1.Rows.Count + "件";

                //削除・変更分.
                for (int i = 0; i < addChgDsLion.SeisakuDiff.Rows.Count; i++)
                {
                    //売上明細No.
                    String strJyutNo = String.Empty;
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][JYUTNO] + "-";
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][JYMEINO] + "-";
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][URMEINO];

                    for (int j = 0; j < spsAD1Seisaku.Rows.Count; j++)
                    {
                        if (spsAD1Seisaku.Cells[j, COLIDX_SEISAKU_AD1_URMEINO].Value.Equals(strJyutNo))
                        {
                            //削除.
                            if (addChgDsLion.SeisakuDiff.Rows[i][SEQ].ToString().Equals(SEQ_DEL))
                            {
                                spsAD1Seisaku.Cells[j, COLIDX_SEISAKU_AD1_ADDCHGDIV].Value = DEL;
                                spsAD1Seisaku.Rows[j].BackColor = Color.LightPink;
                            }
                            //変更.
                            if (addChgDsLion.SeisakuDiff.Rows[i][SEQ].ToString().Equals(SEQ_CHG))
                            {
                                spsAD1Seisaku.Cells[j, COLIDX_SEISAKU_AD1_ADDCHGDIV].Value = CHG;
                                spsAD1Seisaku.Rows[j].BackColor = Color.LightBlue;
                            }
                        }
                    }
                }

                //制作室リスト(AD2)スプレッド設定.
                spsAD2Seisaku.Rows.Count = 0;

                //初期化.
                _intRow = 0;

                for (int i = 0; i < addChgDsLion.SeisakuAD2.Rows.Count; i++)
                {
                    //行追加.
                    spsAD2Seisaku.Rows.Add(spsAD2Seisaku.RowCount, 1);

                    //売上明細No.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_URMEINO].Value =
                        addChgDsLion.SeisakuAD2.Rows[i][JYUTNO] + "-" + addChgDsLion.SeisakuAD2.Rows[i][JYMEINO] + "-" + addChgDsLion.SeisakuAD2.Rows[i][URMEINO];
                    //媒体区分コード.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_BAITAIKBN].Value = addChgDsLion.SeisakuAD2.Rows[i][BAITAIKBN];
                    //媒体名称.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_BAITAINM].Value = addChgDsLion.SeisakuAD2.Rows[i][BAITAINM];
                    //ブランドコード.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_BRDCD].Value = addChgDsLion.SeisakuAD2.Rows[i][BRDCD];
                    //ブランド名称.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_BRDNM].Value = addChgDsLion.SeisakuAD2.Rows[i][BRDNM];
                    //件名.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_KENNM].Value = addChgDsLion.SeisakuAD2.Rows[i][KENNM];
                    //請求金額.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_SEIGAK].Value = addChgDsLion.SeisakuAD2.Rows[i][SEIGAK];
                    //消費税額.
                    spsAD2Seisaku.Cells[_intRow, COLIDX_SEISAKU_AD2_TAXAMT].Value = addChgDsLion.SeisakuAD2.Rows[i][TAXAMT];

                    _intRow++;
                }

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = addChgDsLion.SeisakuAD2.Rows.Count + "件";

                //追加・変更分.
                for (int i = 0; i < addChgDsLion.SeisakuDiff.Rows.Count; i++)
                {
                    //売上明細No.
                    String strJyutNo = String.Empty;
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][JYUTNO] + "-";
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][JYMEINO] + "-";
                    strJyutNo += addChgDsLion.SeisakuDiff.Rows[i][URMEINO];

                    for (int j = 0; j < spsAD2Seisaku.Rows.Count; j++)
                    {
                        if (spsAD2Seisaku.Cells[j, COLIDX_SEISAKU_AD2_URMEINO].Value.Equals(strJyutNo))
                        {
                            //追加.
                            if (addChgDsLion.SeisakuDiff.Rows[i][SEQ].ToString().Equals(SEQ_ADD))
                            {
                                spsAD2Seisaku.Cells[j, COLIDX_SEISAKU_AD2_ADDCHGDIV].Value = ADD;
                                spsAD2Seisaku.Rows[j].BackColor = Color.LightGreen;
                            }
                            //変更.
                            if (addChgDsLion.SeisakuDiff.Rows[i][SEQ].ToString().Equals(SEQ_CHG))
                            {
                                spsAD2Seisaku.Cells[j, COLIDX_SEISAKU_AD2_ADDCHGDIV].Value = CHG;
                                spsAD2Seisaku.Rows[j].BackColor = Color.LightBlue;
                            }
                        }
                    }
                }

                //垂直スクロールバーを表示する.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
            else
            {
                //追加変更リストの場合.
                spsAD1Seisaku.Visible = false;
                spsAD2Seisaku.Visible = false;
                spsAD1Baitai.Visible = true;
                spsAD2Baitai.Visible = true;
                spsAD1Baitai.SheetName = AD1;
                spsAD2Baitai.SheetName = AD2;
                spsAD1Baitai.Rows.Count = 0;
                spsAD2Baitai.Rows.Count = 0;

                //"AD1"シート有効化.
                sprMain.ActiveSheetIndex = 2;

                //検索種別.
                strType = BAITAI;

                //履歴タイムスタンプスプレッドが初期状態の場合.
                if (spsRrkTimStmp.Rows.Count == 0)
                {
                    //履歴タイムスタンプスプレッド設定.
                    SetRrkTimStmpSpread(cboReport.SelectedIndex);
                }

                //*******************
                //データ取得.
                //*******************
                //追加変更リスト.
                addChgDsLion = FindBaitai(yyyyMm, strType);

                if (addChgDsLion.BaitaiAD2.Rows.Count == 0)
                {
                    //メッセージ：HB-W0023 該当するデータがありません。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                    return;
                }

                //垂直スクロールバーを作業中は非表示にする.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                //追加変更リスト(AD1)スプレッド設定.
                spsAD1Baitai.Rows.Count = 0;

                //AD1変更区分表示.
                spsAD1Baitai.Columns[COLIDX_BAITAI_AD1_ADDCHGDIV].Visible = true;

                //初期化.
                _intRow = 0;

                for (int i = 0; i < addChgDsLion.BaitaiAD1.Rows.Count; i++)
                {
                    //行追加.
                    spsAD1Baitai.Rows.Add(spsAD1Baitai.RowCount, 1);

                    //売上明細No(受注No＋受注明細No＋売上明細No＋連番).
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_URMEINO].Value =
                        addChgDsLion.BaitaiAD1.Rows[i][JYUTNO] + "-" + addChgDsLion.BaitaiAD1.Rows[i][JYMEINO] + "-" + addChgDsLion.BaitaiAD1.Rows[i][URMEINO] + "-" + addChgDsLion.BaitaiAD1.Rows[i][RENBN];
                    //媒体区分コード.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_BAITAIKBN].Value = addChgDsLion.BaitaiAD1.Rows[i][BAITAIKBN];
                    //媒体名称.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_BAITAINM].Value = addChgDsLion.BaitaiAD1.Rows[i][BAITAINM];
                    //件名.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_KENNM].Value = addChgDsLion.BaitaiAD1.Rows[i][KENNM];
                    //請求金額.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_SEIGAK].Value = addChgDsLion.BaitaiAD1.Rows[i][SEIGAK];
                    //局誌コード.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_KYKSHCD].Value = addChgDsLion.BaitaiAD1.Rows[i][KYKSHCD];
                    //局コード.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_KYKCD].Value = addChgDsLion.BaitaiAD1.Rows[i][KYKCD];
                    //局名.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_KYKNM].Value = addChgDsLion.BaitaiAD1.Rows[i][KYKNM];
                    //CM秒数.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_BYOSU].Value = addChgDsLion.BaitaiAD1.Rows[i][BYOSU];
                    //CM本数.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_HONSU].Value = addChgDsLion.BaitaiAD1.Rows[i][HONSU];
                    //CM総秒数.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_SOUBYOSU].Value =
                        KKHUtility.IntParse(addChgDsLion.BaitaiAD1.Rows[i][BYOSU].ToString()) * KKHUtility.IntParse(addChgDsLion.BaitaiAD1.Rows[i][HONSU].ToString());
                    //スペース.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_SPACE].Value = addChgDsLion.BaitaiAD1.Rows[i][SPACE];
                    //掲載日・号・等.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_KEISAIBI].Value = addChgDsLion.BaitaiAD1.Rows[i][KEISAIBI].ToString();
                    //期間.
                    spsAD1Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_TERM].Value = addChgDsLion.BaitaiAD1.Rows[i][TERM];

                    _intRow++;
                }

                //件数をセット.
                statusStrip1.Items["tslval1"].Text = addChgDsLion.BaitaiAD1.Rows.Count + "件";

                //削除・変更分.
                for (int i = 0; i < addChgDsLion.BaitaiDiff.Rows.Count; i++)
                {
                    //売上明細No.
                    String strJyutNo = String.Empty;
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][JYUTNO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][JYMEINO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][URMEINO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][RENBN];

                    for (int j = 0; j < spsAD1Baitai.Rows.Count; j++)
                    {
                        if (spsAD1Baitai.Cells[j, COLIDX_BAITAI_AD1_URMEINO].Value.Equals(strJyutNo))
                        {
                            //削除.
                            if (addChgDsLion.BaitaiDiff.Rows[i][SEQ].ToString().Equals(SEQ_DEL))
                            {
                                addChgDsLion.BaitaiAD1.Rows[j][ADDCHGKBN] = DEL;
                                spsAD1Baitai.Cells[j, COLIDX_BAITAI_AD1_ADDCHGDIV].Value = DEL;
                                spsAD1Baitai.Rows[j].BackColor = Color.LightPink;
                                break;
                            }
                            //変更.
                            if (addChgDsLion.BaitaiDiff.Rows[i][SEQ].ToString().Equals(SEQ_CHG))
                            {
                                addChgDsLion.BaitaiAD1.Rows[j][ADDCHGKBN] = CHG;
                                spsAD1Baitai.Cells[j, COLIDX_BAITAI_AD1_ADDCHGDIV].Value = CHG;
                                spsAD1Baitai.Rows[j].BackColor = Color.LightBlue;
                                break;
                            }
                        }
                    }
                }

                //追加変更リスト(AD2)スプレッド設定.
                spsAD2Baitai.Rows.Count = 0;

                //初期化.
                _intRow = 0;

                for (int i = 0; i < addChgDsLion.BaitaiAD2.Rows.Count; i++)
                {
                    //行追加.
                    spsAD2Baitai.Rows.Add(spsAD2Baitai.RowCount, 1);

                    //売上明細No.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD1_URMEINO].Value =
                        addChgDsLion.BaitaiAD2.Rows[i][JYUTNO] + "-" + addChgDsLion.BaitaiAD2.Rows[i][JYMEINO] + "-" + addChgDsLion.BaitaiAD2.Rows[i][URMEINO] + "-" + addChgDsLion.BaitaiAD2.Rows[i][RENBN];
                    //媒体区分コード.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_BAITAIKBN].Value = addChgDsLion.BaitaiAD2.Rows[i][BAITAIKBN];
                    //媒体名称.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_BAITAINM].Value = addChgDsLion.BaitaiAD2.Rows[i][BAITAINM];
                    //件名.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_KENNM].Value = addChgDsLion.BaitaiAD2.Rows[i][KENNM];
                    //請求金額.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_SEIGAK].Value = addChgDsLion.BaitaiAD2.Rows[i][SEIGAK];
                    //局誌コード.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_KYKSHCD].Value = addChgDsLion.BaitaiAD2.Rows[i][KYKSHCD];
                    //局コード.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_KYKCD].Value = addChgDsLion.BaitaiAD2.Rows[i][KYKCD];
                    //局名.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_KYKNM].Value = addChgDsLion.BaitaiAD2.Rows[i][KYKNM];
                    //CM秒数.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_BYOSU].Value = addChgDsLion.BaitaiAD2.Rows[i][BYOSU];
                    //CM本数.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_HONSU].Value = addChgDsLion.BaitaiAD2.Rows[i][HONSU];
                    //CM総秒数.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_SOUBYOSU].Value =
                        KKHUtility.IntParse(addChgDsLion.BaitaiAD2.Rows[i][BYOSU].ToString()) * KKHUtility.IntParse(addChgDsLion.BaitaiAD2.Rows[i][HONSU].ToString());
                    //スペース.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_SPACE].Value = addChgDsLion.BaitaiAD2.Rows[i][SPACE];
                    //掲載日・号・等.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_KEISAIBI].Value = addChgDsLion.BaitaiAD2.Rows[i][KEISAIBI].ToString();
                    //期間.
                    spsAD2Baitai.Cells[_intRow, COLIDX_BAITAI_AD2_TERM].Value = addChgDsLion.BaitaiAD2.Rows[i][TERM];

                    _intRow++;
                }

                //追加・変更分.
                for (int i = 0; i < addChgDsLion.BaitaiDiff.Rows.Count; i++)
                {
                    //売上明細No.
                    String strJyutNo = String.Empty;
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][JYUTNO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][JYMEINO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][URMEINO] + "-";
                    strJyutNo += addChgDsLion.BaitaiDiff.Rows[i][RENBN];

                    for (int j = 0; j < spsAD2Baitai.Rows.Count; j++)
                    {
                        if (spsAD2Baitai.Cells[j, COLIDX_BAITAI_AD2_UMEINO].Value.Equals(strJyutNo))
                        {
                            //追加.
                            if (addChgDsLion.BaitaiDiff.Rows[i][SEQ].ToString().Equals(SEQ_ADD))
                            {
                                addChgDsLion.BaitaiAD2.Rows[j][ADDCHGKBN] = ADD;
                                spsAD2Baitai.Cells[j, COLIDX_BAITAI_AD2_ADDCHGDIV].Value = ADD;
                                spsAD2Baitai.Rows[j].BackColor = Color.LightGreen;
                                break;
                            }
                            //変更.
                            if (addChgDsLion.BaitaiDiff.Rows[i][SEQ].ToString().Equals(SEQ_CHG))
                            {
                                addChgDsLion.BaitaiAD2.Rows[j][ADDCHGKBN] = CHG;
                                spsAD2Baitai.Cells[j, COLIDX_BAITAI_AD2_ADDCHGDIV].Value = CHG;
                                spsAD2Baitai.Rows[j].BackColor = Color.LightBlue;
                                break;
                            }
                        }
                    }
                }

                //垂直スクロールバーを表示する.
                sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }

            //Excelボタン押下可能.
            btnXls.Enabled = true;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        #endregion レコード取得.

        #region Excel出力.

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="strFileNm">出力ファイル名</param>
        private void ExcelOut(string strFileNm, DateTime dt)
        {
            DataRow dtRow;

            //制作室リストの場合.
            if (cboReport.Text.Equals(AD1_SEISAKU) || cboReport.Text.Equals(AD2_SEISAKU))
            {
                //マクロファイル名設定.
                _mStrMacroFileNm = _mStrRepTempAdrs + REP_SEISAKU_MACRO_FILENAME;
                //テンプレートファイル名設定.
                _mStrTemplateFileNm = _mStrRepTempAdrs + REP_SEISAKU_TEMPLATE_FILENAME;

                try
                {
                    //Excel開始処理.
                    //リソースからExcelファイルを作成.
                    //マクロファイル.
                    File.WriteAllBytes(_mStrMacroFileNm, Resources.Lion_Seisaku_Mcr);
                    //テンプレートファイル.
                    File.WriteAllBytes(_mStrTemplateFileNm, Resources.Lion_Seisaku_Template);

                    //マクロファイル・テンプレートファイル存在確認(出力フォルダ内).
                    if (!System.IO.File.Exists(_mStrMacroFileNm))
                    {
                        throw new Exception("マクロExcelファイルがありません。");
                    }
                    if (!System.IO.File.Exists(_mStrTemplateFileNm))
                    {
                        throw new Exception("テンプレートExcelファイルがありません。");
                    }

                    // データセットXML出力.
                    addChgDsLion.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_SEISAKU_DATA_XML_FILENAME));
                    
                    // パラメータXML作成.
                    // 変数の宣言.
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // データセットにテーブルを追加.
                    // PRODUCTSテーブルを作成.
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("USERNAME", Type.GetType("System.String")); //ユーザー名.
                    dtTable.Columns.Add("YYMM", Type.GetType("System.String"));     //検索年月.
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));  //保存場所.
                    dtTable.Columns.Add("TYPE", Type.GetType("System.String"));     //期間(AD1:"1"/AD2:"2")

                    //テーブルにデータを追加.
                    dtRow = dtTable.NewRow();
                    dtRow["USERNAME"] = tslName.Text;
                    dtRow["YYMM"] = txtYm.Value;
                    dtRow["SAVEDIR"] = strFileNm;
                    if (cboReport.Text.Equals(AD1_SEISAKU))
                    {
                        dtRow["TYPE"] = "1";
                    }
                    else
                    {
                        dtRow["TYPE"] = "2";
                    }
                    dtTable.Rows.Add(dtRow);

                    //パラメータをXML出力.
                    dtSet.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_SEISAKU_PROP_XML_FILENAME));

                    //エクセル起動.
                    System.Diagnostics.Process.Start("excel", _mStrRepTempAdrs + REP_SEISAKU_MACRO_FILENAME);

                    //オペレーションログの出力.
                    //追加変更リストの場合.
                    KKHLogUtility.WriteOperationLogToDB(_naviParam,
                                                        APLID,
                                                        KKHLogUtilityLion.KIND_ID_OPERATION_LOG_SEISAKULIST,
                                                        KKHLogUtilityLion.DESC_OPERATION_LOG_SEISAKULIST + "＿" + cboReport.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            //追加変更リストの場合.
            else
            {
                //マクロファイル名設定.
                _mStrMacroFileNm = _mStrRepTempAdrs + REP_BAITAI_MACRO_FILENAME;
                _mStrTemplateFileNm = _mStrRepTempAdrs + REP_BAITAI_TEMPLATE_FILENAME;
                _mStrTemplateFileNm2 = _mStrRepTempAdrs + REP_BAITAI_TEMPLATE_FILENAME2;

                try
                {
                    //Excel開始処理.
                    //リソースからExcelファイルを作成(テンプレートとマクロ).
                    File.WriteAllBytes(_mStrMacroFileNm, Resources.Lion_Baitai_Mcr);
                    File.WriteAllBytes(_mStrTemplateFileNm, Resources.Lion_Baitai_Template);
                    File.WriteAllBytes(_mStrTemplateFileNm2, Resources.Lion_Baitai_Template2);

                    if (!System.IO.File.Exists(_mStrTemplateFileNm) || !System.IO.File.Exists(_mStrTemplateFileNm2))
                    {
                        throw new Exception("テンプレートExcelファイルがありません。");
                    }
                    if (!System.IO.File.Exists(_mStrMacroFileNm))
                    {
                        throw new Exception("マクロExcelファイルがありません。");
                    }

                    ////BaitaiDiffTempデータテーブル→BaitaiDiffデータテーブル作成.
                    //addChgDsLion.BaitaiDiff.Rows.Clear();
                    //AddChgDsLion.BaitaiDiffDataTable diffTable = addChgDsLion.BaitaiDiff;

                    //for (int i = 0; i < addChgDsLion.BaitaiDiff.Rows.Count; i++)
                    //{
                    //    AddChgDsLion.BaitaiDiffRow rows = (AddChgDsLion.BaitaiDiffRow)addChgDsLion.BaitaiDiff[i];

                    //    //追加.
                    //    if (rows.SEQ.Equals(SEQ_ADD))
                    //    {                            
                    //        AddChgDsLion.BaitaiDiffRow newRow = (AddChgDsLion.BaitaiDiffRow)diffTable.NewRow();

                    //        newRow.ADDCHGKBN = ADD;
                    //        newRow.ADX = AD2;
                    //        newRow.JYUTNO = rows.AD2JYUTNO;
                    //        newRow.JYMEINO = rows.AD2JYMEINO;
                    //        newRow.URMEINO = rows.AD2URMEINO;
                    //        newRow.RENBN = rows.AD2RENBN;
                    //        newRow.BAITAIKBN = rows.AD2BAITAIKBN;
                    //        newRow.BAITAINM = rows.AD2BAITAINM;
                    //        newRow.KENNM = rows.AD2KENNM;
                    //        newRow.SEIGAK = rows.AD2SEIGAK;
                    //        newRow.KYKSHCD = rows.AD2KYKSHCD;
                    //        newRow.KYKCD = rows.AD2KYKCD;
                    //        newRow.KYKNM = rows.AD2KYKNM;
                    //        newRow.BYOSU = rows.AD2BYOSU;
                    //        newRow.HONSU = rows.AD2HONSU;
                    //        newRow.SPACE = rows.AD2SPACE;
                    //        newRow.KEISAIBI = rows.AD2KEISAIBI;
                    //        newRow.TERM = rows.AD2TERM;

                    //        diffTable.Rows.Add(newRow);
                    //    }
                    //    //削除.
                    //    else if (rows.SEQ.Equals(SEQ_DEL))
                    //    {

                    //        AddChgDsLion.BaitaiDiffRow newRow = (AddChgDsLion.BaitaiDiffRow)diffTable.NewRow();

                    //        newRow.ADDCHGKBN = DEL;
                    //        newRow.ADX = AD1;
                    //        newRow.JYUTNO = rows.AD1JYUTNO;
                    //        newRow.JYMEINO = rows.AD1JYMEINO;
                    //        newRow.URMEINO = rows.AD1URMEINO;
                    //        newRow.RENBN = rows.AD1RENBN;
                    //        newRow.BAITAIKBN = rows.AD1BAITAIKBN;
                    //        newRow.BAITAINM = rows.AD1BAITAINM;
                    //        newRow.KENNM = rows.AD1KENNM;
                    //        newRow.SEIGAK = rows.AD1SEIGAK;
                    //        newRow.KYKSHCD = rows.AD1KYKSHCD;
                    //        newRow.KYKCD = rows.AD1KYKCD;
                    //        newRow.KYKNM = rows.AD1KYKNM;
                    //        newRow.BYOSU = rows.AD1BYOSU;
                    //        newRow.HONSU = rows.AD1HONSU;
                    //        newRow.SPACE = rows.AD1SPACE;
                    //        newRow.KEISAIBI = rows.AD1KEISAIBI;
                    //        newRow.TERM = rows.AD1TERM;

                    //        diffTable.Rows.Add(newRow);
                    //    }
                    //    //変更.
                    //    else
                    //    {
                    //        AddChgDsLion.BaitaiDiffRow newRow = (AddChgDsLion.BaitaiDiffRow)diffTable.NewRow();

                    //        newRow.ADDCHGKBN = CHG;
                    //        newRow.ADX = AD1;
                    //        newRow.JYUTNO = rows.AD1JYUTNO;
                    //        newRow.JYMEINO = rows.AD1JYMEINO;
                    //        newRow.URMEINO = rows.AD1URMEINO;
                    //        newRow.RENBN = rows.AD1RENBN;
                    //        newRow.BAITAIKBN = rows.AD1BAITAIKBN;
                    //        newRow.BAITAINM = rows.AD1BAITAINM;
                    //        newRow.KENNM = rows.AD1KENNM;
                    //        newRow.SEIGAK = rows.AD1SEIGAK;
                    //        newRow.KYKSHCD = rows.AD1KYKSHCD;
                    //        newRow.KYKCD = rows.AD1KYKCD;
                    //        newRow.KYKNM = rows.AD1KYKNM;
                    //        newRow.BYOSU = rows.AD1BYOSU;
                    //        newRow.HONSU = rows.AD1HONSU;
                    //        newRow.SPACE = rows.AD1SPACE;
                    //        newRow.KEISAIBI = rows.AD1KEISAIBI;
                    //        newRow.TERM = rows.AD1TERM;

                    //        diffTable.Rows.Add(newRow);

                    //        newRow = (AddChgDsLion.BaitaiDiffRow)diffTable.NewRow();

                    //        newRow.ADDCHGKBN = CHG;
                    //        newRow.ADX = AD2;
                    //        newRow.JYUTNO = rows.AD2JYUTNO;
                    //        newRow.JYMEINO = rows.AD2JYMEINO;
                    //        newRow.URMEINO = rows.AD2URMEINO;
                    //        newRow.RENBN = rows.AD2RENBN;
                    //        newRow.BAITAIKBN = rows.AD2BAITAIKBN;
                    //        newRow.BAITAINM = rows.AD2BAITAINM;
                    //        newRow.KENNM = rows.AD2KENNM;
                    //        newRow.SEIGAK = rows.AD2SEIGAK;
                    //        newRow.KYKSHCD = rows.AD2KYKSHCD;
                    //        newRow.KYKCD = rows.AD2KYKCD;
                    //        newRow.KYKNM = rows.AD2KYKNM;
                    //        newRow.BYOSU = rows.AD2BYOSU;
                    //        newRow.HONSU = rows.AD2HONSU;
                    //        newRow.SPACE = rows.AD2SPACE;
                    //        newRow.KEISAIBI = rows.AD2KEISAIBI;
                    //        newRow.TERM = rows.AD2TERM;

                    //        diffTable.Rows.Add(newRow);
                    //    }
                    //}

                    //データセットXML出力.
                    addChgDsLion.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_BAITAI_DATA_XML_FILENAME));

                    //パラメータXML作成、出力.
                    //変数の宣言.
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    //データセットにテーブルを追加.
                    //PRODUCTSテーブルを作成.
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("USERNM", Type.GetType("System.String"));       //ユーザー名.
                    dtTable.Columns.Add("YYMM", Type.GetType("System.String"));         //検索年月日.
                    dtTable.Columns.Add("SAVEFILENM", Type.GetType("System.String"));   //保存ファイル名.
                    dtTable.Columns.Add("RRKTIMSTMP", Type.GetType("System.String"));   //履歴タイムスタンプ.
                    dtTable.Columns.Add("SYSTIMSTMP", Type.GetType("System.String"));   //システム日付.

                    //テーブルにデータを追加.
                    dtRow = dtTable.NewRow();
                    dtRow["USERNM"] = tslName.Text;
                    dtRow["YYMM"] = txtYm.Value;
                    dtRow["SAVEFILENM"] = strFileNm;
                    dtRow["RRKTIMSTMP"] = _rrkTimStmp;
                    dtRow["SYSTIMSTMP"] = dt.ToString();

                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_BAITAI_PROP_XML_FILENAME));

                    //エクセル起動.
                    System.Diagnostics.Process.Start("excel", _mStrRepTempAdrs + REP_BAITAI_MACRO_FILENAME);

                    //オペレーションログの出力.
                    KKHLogUtilityLion.WriteOperationLogToDB(_naviParam,
                                                            APLID,
                                                            KKHLogUtilityLion.KIND_ID_OPERATION_LOG_ADDCHANGELIST,
                                                            KKHLogUtilityLion.DESC_OPERATION_LOG_ADDCHANGELIST);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Excel出力.

        #region 営業日取得.

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

        #endregion 営業日取得.

        #region スプレッド初期化.

        /// <summary>
        /// スプレッドシートの初期化.
        /// </summary>
        private void InitSpread()
        {
            spsAD1Seisaku.Visible = false;
            spsAD2Seisaku.Visible = false;
            spsAD1Baitai.Visible = false;
            spsAD2Baitai.Visible = false;

            spsAD1Seisaku.RowCount = 0;
            spsAD2Seisaku.RowCount = 0;
            spsAD1Baitai.RowCount = 0;
            spsAD2Baitai.RowCount = 0;

            //変更区分非表示.
            spsAD1Seisaku.Columns[COLIDX_SEISAKU_AD1_ADDCHGDIV].Visible = false;

            //***********************************
            //スプレッドシートのタブを表示.
            //***********************************
            sprMain.TabStripPolicy = TabStripPolicy.Always;
        }

        #endregion スプレッド初期化.

        #region 履歴タイムスタンプスプレッド設定.

        /// <summary>
        /// 履歴タイムスタンプスプレッド設定.
        /// </summary>
        /// <param name="intType">出力帳票種別</param>
        private void SetRrkTimStmpSpread(int intType)
        {
            int _intRow = 0;

            //履歴タイムスタンプスプレッド設定.
            spsRrkTimStmp.RowCount = 0;
            _intRrkAD1FlgRow = 0;

            //履歴タイムスタンプ取得.
            addChgDsLion = FindRrkTimStmp(txtYm.Value, intType);

            //垂直スクロールバーを作業中は非表示にする.
            sprRrkTimStmp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            for (int i = 0; i < addChgDsLion.RrkTimStmp.Rows.Count; i++)
            {
                AddChgDsLion.RrkTimStmpBaseRow newRow = (AddChgDsLion.RrkTimStmpBaseRow)addChgDsLion.RrkTimStmpBase.NewRow();

                AddChgDsLion.RrkTimStmpRow row = (AddChgDsLion.RrkTimStmpRow)addChgDsLion.RrkTimStmp.Rows[i];
                //履歴タイムスタンプ.
                newRow.RRKTIMSTMP = row.RRKTIMSTMP;
                _rrkTimStmp = row.RRKTIMSTMP;
                addChgDsLion.RrkTimStmpBase.Rows.Add(newRow);

                //履歴タイムスタンプスプレッド設定.
                //行追加.
                spsRrkTimStmp.Rows.Add(spsRrkTimStmp.RowCount, 1);

                //履歴タイムスタンプ.
                spsRrkTimStmp.Cells[_intRow, COLIDX_RRK_RRKTIMSTMP].Value = newRow.RRKTIMSTMP;

                _intRow++;
            }

            if (spsRrkTimStmp.RowCount != 0)
            {
                _rrkTimStmp = spsRrkTimStmp.Cells[0, COLIDX_RRK_RRKTIMSTMP].Value.ToString();
                spsRrkTimStmp.AddSelection(0, 0, 1, 1);

                //垂直スクロールバーを表示する.
                sprRrkTimStmp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
            }
        }

        #endregion 履歴タイムスタンプスプレッド設定.

        #region 履歴タイムスタンプ取得.

        /// <summary>
        /// 履歴タイムスタンプ取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <param name="intType">出力帳票種別</param>
        /// <returns>制作室リスト・追加変更リストDataSet</returns>
        private AddChgDsLion FindRrkTimStmp(String yymm, int intType)
        {
            //履歴タイムスタンプ取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindAddChangeReportParam param = new ReportLionProcessController.FindAddChangeReportParam();
            param.esqId = _naviParam.strEgcd;               //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.
            param.findType = RRKTIMSTMP;                    //検索種別.

            FindAddChangeReportByCondServiceResult result = controller.findLionRrkTimStmp(param, intType);

            return result.dsAddChgLionDataSet;
        }

        #endregion 履歴タイムスタンプ取得.

        #region 制作室リスト(AD1)取得.

        /// <summary>
        /// 制作室リスト(AD1)取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <param name="type">検索種別</param>
        /// <returns>制作室リスト・追加変更リストDataSet</returns>
        private AddChgDsLion FindSeisakuAD1(String yymm, String type)
        {
            //制作室リスト(AD1)取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindAddChangeReportParam param = new ReportLionProcessController.FindAddChangeReportParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.
            param.findType = type;                          //検索種別.

            FindAddChangeReportByCondServiceResult result = controller.findLionSeisakuAD1(param);

            return result.dsAddChgLionDataSet;
        }

        #endregion 制作室リスト(AD1)取得.

        #region 制作室リスト(AD2)取得.

        /// <summary>
        /// 制作室リスト(AD2)取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <param name="type">検索種別</param>
        /// <returns>制作室リスト・追加変更リストDataSet</returns>
        private AddChgDsLion FindSeisakuAD2(String yymm, String type)
        {
            //制作室リスト(AD2)取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindAddChangeReportParam param = new ReportLionProcessController.FindAddChangeReportParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.
            param.findType = type;                          //検索種別.
            param.rrkTimStmp = _rrkTimStmp;                 //履歴タイムスタンプ.

            FindAddChangeReportByCondServiceResult result = controller.findLionSeisakuAD2(param);

            return result.dsAddChgLionDataSet;
        }

        #endregion 制作室リスト(AD2)取得.

        #region 追加変更リスト取得.

        /// <summary>
        /// 追加変更リスト取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <param name="type">検索種別</param>
        /// <returns>制作室リスト・追加変更リストDataSet</returns>
        private AddChgDsLion FindBaitai(String yymm, String type)
        {
            //追加変更リスト取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindAddChangeReportParam param = new ReportLionProcessController.FindAddChangeReportParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.
            param.findType = type;                          //検索種別.
            param.rrkTimStmp = _rrkTimStmp;                 //履歴タイムスタンプ.

            FindAddChangeReportByCondServiceResult result = controller.findLionBaitai(param);

            return result.dsAddChgLionDataSet;
        }

        #endregion 追加変更リスト取得.

        #endregion メソッド.

    }

}

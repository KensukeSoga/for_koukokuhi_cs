using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHView.Common
{
    /// <summary>
    /// ナビパラメータ.
    /// </summary>
    /// <remarks>
    /// 修正管理.
    /// <list type="table">
    ///   <listheader>
    ///     <description>日付</description>
    ///     <description>修正者</description>
    ///     <description>内容</description>
    ///   </listheader>
    ///   <item>
    ///     <description>2011/11/22</description>
    ///     <description>IP H.Shimizu</description>
    ///     <description>新規作成</description>
    ///   </item>
    /// </list>
    /// </remarks>
    public class KKHNaviParameter : INaviParameter
    {
        #region プロパティ.

        #region 共通.

        /// <summary>
        /// 遷移元の機能定数です.
        /// </summary>
        private Function _function;

        /// <summary>
        /// 遷移元の機能定数を取得または設定します.
        /// </summary>
        public Function Function
        {
            get { return _function; }
            set { _function = value; }
        }

        /// <summary>
        /// ユーザータイプ.
        /// </summary>
        private string _StrSystemAdministerFlg;

        /// <summary>
        /// ユーザータイプの取得または設定します。.
        /// </summary>
        public string StrSystemAdministerFlg
        {
            get { return _StrSystemAdministerFlg; }
            set { _StrSystemAdministerFlg = value; }
        }

        /// <summary>
        /// ログインユーザESQID.
        /// </summary>
        private string _strEsqId;
        /// <summary>
        /// ログインユーザESQIDを取得または設定します.
        /// </summary>
        public string strEsqId
        {
            get { return _strEsqId; }
            set { _strEsqId = value; }
        }

        /// <summary>
        /// ログインユーザ名.
        /// </summary>
        private string _strName;
        /// <summary>
        /// ログインユーザ名を取得または設定します.
        /// </summary>
        public string strName
        {
            get { return _strName; }
            set { _strName = value; }
        }

        /// <summary>
        /// 営業所コード.
        /// </summary>
        private string _strEgcd;
        /// <summary>
        /// 営業所コードを取得または設定します.
        /// </summary>
        public string strEgcd
        {
            get { return _strEgcd; }
            set { _strEgcd = value; }
        }

        /// <summary>
        /// 得意先企業名.
        /// </summary>
        private string _strTksKgyName;
        /// <summary>
        /// 得意先企業名を取得または設定します.
        /// </summary>
        public string strTksKgyName
        {
            get { return _strTksKgyName; }
            set { _strTksKgyName = value; }
        }

        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        private string _strTksKgyCd;
        /// <summary>
        /// 得意先企業コードを取得または設定します.
        /// </summary>
        public string strTksKgyCd
        {
            get { return _strTksKgyCd; }
            set { _strTksKgyCd = value; }
        }

        /// <summary>
        /// 得意先部門コード.
        /// </summary>
        private string _strTksBmnSeqNo;
        /// <summary>
        /// 得意先部門コードを取得または設定します.
        /// </summary>
        public string strTksBmnSeqNo
        {
            get { return _strTksBmnSeqNo; }
            set { _strTksBmnSeqNo = value; }
        }

        /// <summary>
        /// 得意先担当者コード.
        /// </summary>
        private string _strTksTntSeqNo;
        /// <summary>
        /// 得意先担当者コードを取得または設定します.
        /// </summary>
        public string strTksTntSeqNo
        {
            get { return _strTksTntSeqNo; }
            set { _strTksTntSeqNo = value; }
        }

        /// <summary>
        /// 日付.
        /// </summary>
        private string _strDate;
        /// <summary>
        /// 日付を取得または設定します.
        /// </summary>
        public string strDate
        {
            get { return _strDate; }
            set { _strDate = value; }
        }

        /// <summary>
        /// 日付.
        /// </summary>
        private string _strDate2;
        /// <summary>
        /// 日付を取得または設定します.
        /// </summary>
        public string strDate2
        {
            get { return _strDate2; }
            set { _strDate2 = value; }
        }

        /// <summary>
        /// トップメニュー画面名(遷移時).
        /// </summary>
        private string _strFrmTopMenuNM;
        /// <summary>
        /// トップメニュー画面名(遷移時)を取得または設定します.
        /// </summary>
        public string strFrmTopMenuNM
        {
            get { return _strFrmTopMenuNM; }
            set { _strFrmTopMenuNM = value; }
        }

        /// <summary>
        /// マスタメンテナンス画面名(遷移時).
        /// </summary>
        private string _strFrmMastNm;
        /// <summary>
        /// マスタメンテナンス画面名(遷移時)を取得または設定します.
        /// </summary>
        public string strFrmMastNm
        {
            get { return _strFrmMastNm; }
            set { _strFrmMastNm = value; }
        }

        /// <summary>
        /// 明細画面名(遷移時).
        /// </summary>
        private string _strFrmDetailNm;
        /// <summary>
        /// 明細画面名(遷移時)を取得または設定します.
        /// </summary>
        public string strFrmDetailNm
        {
            get { return _strFrmDetailNm; }
            set { _strFrmDetailNm = value; }
        }

        /// <summary>
        /// 帳票画面名(遷移時).
        /// </summary>
        private string _strFrmInputNm;
        /// <summary>
        /// 帳票画面名(遷移時)を取得または設定します.
        /// </summary>
        public string strFrmInputNm
        {
            get { return _strFrmInputNm; }
            set { _strFrmInputNm = value; }
        }

        //↓汎用-----------------------------------------------------------------------------------------------
        private Int32 _intValue1;
        /// <summary>
        /// Int型の値を取得、または設定します。.
        /// </summary>
        public Int32 IntValue1
        {
            get { return _intValue1; }
            set { _intValue1 = value; }
        }

        private String _strValue1 = "";
        /// <summary>
        /// String型の値を取得、または設定します。.
        /// </summary>
        public String StrValue1
        {
            get { return _strValue1; }
            set { _strValue1 = value; }
        }

        private DataTable _dataTable1;
        /// <summary>
        /// DataTable型の値を取得、または設定します。.
        /// </summary>
        public DataTable DataTable1
        {
            get { return _dataTable1; }
            set { _dataTable1 = value; }
        }

        private DataTable _dataTable2;
        /// <summary>
        /// DataTable型の値を取得、または設定します。.
        /// </summary>
        public DataTable DataTable2
        {
            get { return _dataTable2; }
            set { _dataTable2 = value; }
        }

        private string _aplId = "";
        /// <summary>
        /// 機能IDを取得、または設定します.
        /// </summary>
        public string AplId
        {
            get { return _aplId; }
            set { _aplId = value; }
        }

        #endregion 共通.

        #region マスタ.

        // TODO 2012/02/14
        // 使用する機能毎に個々で記載する。.
        // 得意先機能（画面）単位、仮に一得意に定義した物を別得意でも使えるとしても個別定義する事。.
        // ****** 改修時、以下をコメントとし参照を新規定義した物に変更する。 ******

        /// <summary>
        /// マスタID.
        /// </summary>
        private string _strMasterKey;
        /// <summary>
        /// マスタIDを取得または設定します.
        /// </summary>
        public string strMasterKey
        {
            get { return _strMasterKey; }
            set { _strMasterKey = value; }
        }

        /// <summary>
        /// フィルターバリュー.
        /// </summary>
        private string _strfilterValue;

        /// <summary>
        /// フィルターバリューの取得または設定します.
        /// </summary>
        public string strFilterValue
        {
            get { return _strfilterValue; }
            set { _strfilterValue = value; }
        }

        #endregion マスタ.

        #region 明細.

        // TODO 2012/02/14
        // 使用する機能毎に個々で記載する。.
        // 得意先機能（画面）単位、仮に一得意に定義した物を別得意でも使えるとしても個別定義する事。.
        // ****** 改修時、以下をコメントとし参照を新規定義した物に変更する。 ******
        /// <summary>
        /// マスタID.
        /// </summary>
        /// <summary>
        /// 請求年月.
        /// </summary>
        private string _strYymm;

        /// <summary>
        /// 請求年月を取得、または設定します.
        /// </summary>
        public string StrYymm
        {
            get { return _strYymm; }
            set { _strYymm = value; }
        }

        //受注登録内容行データ.
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow;
        /// <summary>
        /// 受注登録内容行データを取得、または設定します。.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow DataRow
        {
            set { dataRow = value; }
            get { return dataRow; }
        }

        /// <summary>
        /// 統合済み受注登録内容行データ.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] _mergeDataRow;
        /// <summary>
        /// 統合済み受注登録内容行データを取得、または設定します。.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] MergeDataRow
        {
            set { _mergeDataRow = value; }
            get { return _mergeDataRow; }
        }

        //明細を追加する行.
        private int rowDetailIndex;
        /// <summary>
        /// 明細を追加する行を取得、または設定します。.
        /// </summary>
        public int RowDetailIndex
        {
            set { rowDetailIndex = value; }
            get { return rowDetailIndex; }
        }

        /// <summary>
        /// 請求金額合計.
        /// </summary>
        private decimal _seigakSum;
        /// <summary>
        /// 請求金額合計を取得、または設定します。.
        /// </summary>
        public decimal SeigakSum
        {
            set { _seigakSum = value; }
            get { return _seigakSum; }
        }

        //広告費明細スプレッドシート(広告費明細入力).
        private FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1;
        /// <summary>
        /// 広告費明細スプレッドシート(広告費明細入力)を取得、または設定します。.
        /// </summary>
        public FarPoint.Win.Spread.SheetView SpdKkhDetail_Sheet1
        {
            set { spdKkhDetail_Sheet1 = value; }
            get { return spdKkhDetail_Sheet1; }
        }

        //広告費明細入力データセット.
        private Isid.KKH.Common.KKHSchema.Detail _dsDetail;
        /// <summary>
        /// 広告費明細入力データセットを取得、または設定します。.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail DsDetail
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        //業務区分.
        private string _gyomKbn = string.Empty;
        /// <summary>
        /// 業務区分を取得、または設定します。.
        /// </summary>
        public string GyomKbn
        {
            get { return _gyomKbn; }
            set { _gyomKbn = value; }
        }

        //媒体コード.
        private string _baitaiCd = string.Empty;
        /// <summary>
        /// 媒体コードを取得、または設定します。.
        /// </summary>
        public string BaitaiCd
        {
            get { return _baitaiCd; }
            set { _baitaiCd = value; }
        }

        //明細入力スプレッドシート(明細入力画面).
        private FarPoint.Win.Spread.SheetView spdDetailInput_Sheet1;
        /// <summary>
        /// 明細入力スプレッドシート(明細入力画面)を取得、または設定します。.
        /// </summary>
        public FarPoint.Win.Spread.SheetView SpdDetailInput_Sheet1
        {
            set { spdDetailInput_Sheet1 = value; }
            get { return spdDetailInput_Sheet1; }
        }

        #endregion 明細.

        #endregion プロパティ.
    }
}

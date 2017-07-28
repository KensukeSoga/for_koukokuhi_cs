using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Lion.ProcessController.Report.Parser;

namespace Isid.KKH.Lion.ProcessController.Report
{
    /// <summary>
    /// 得意先ライオン帳票プロセスコントローラ.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付.</description>
    ///       <description>修正者.</description>
    ///       <description>内容.</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/11.</description>
    ///       <description>JSE KT.</description>
    ///       <description>新規作成.</description>
    ///     </item>
    ///     <item>
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>比較帳票対応・請求予定表対応</description>
    ///     </item>
    ///     <item>
    ///       <description>2014/11/10</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>比較帳票対応</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class ReportLionProcessController:Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region 構造体.

        #region ライオン帳票パラメータ構造体.

        /// <summary>
        /// ライオン帳票パラメータ構造体.
        /// </summary>
        public struct FindNewReportLionParam
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 媒体コード.
            /// </summary>
            public String baitaiCd;
        }

        #endregion ライオン帳票パラメータ構造体.

        #region ライオン受注履歴作成パラメータ.

        /// <summary>
        /// ライオン受注履歴作成パラメータ.
        /// </summary>
        public struct RegisterLionOrderHistoryParam
        {
            /// <summary>
            /// ESQ-ID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 履歴タイムスタンプ.
            /// </summary>
            public String rrkTimStmp;
            /// <summary>
            /// 履歴作成時選択媒体.
            /// </summary>
            public String rrkGetBaitai;
        }

        #endregion ライオン受注履歴作成パラメータ.

        #region ライオン制作室リスト・追加変更リスト帳票パラメータ.

        /// <summary>
        /// ライオン制作室リスト・追加変更リスト帳票パラメータ.
        /// </summary>
        public struct FindAddChangeReportParam
        {
            /// <summary>
            /// ESQ-ID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 検索種別.
            /// </summary>
            public String findType;
            /// <summary>
            /// 履歴タイムスタンプ.
            /// </summary>
            public String rrkTimStmp;
        }

        #endregion ライオン制作室リスト・追加変更リスト帳票パラメータ.

        #region ライオン履歴AD1フラグ更新パラメータ.

        /// <summary>
        /// ライオン履歴AD1フラグ更新パラメータ.
        /// </summary>
        public struct UpdateLionRrkAD1FlgParam
        {
            /// <summary>
            /// 営業所コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yyMm;
            /// <summary>
            /// 履歴タイムスタンプ.
            /// </summary>
            public String rrkTimStmp;
        }

        #endregion ライオン履歴AD1フラグ更新パラメータ.

        #region ライオン請求予定表検索パラメータ.

        /// <summary>
        /// ライオン請求予定表パラメータ.
        /// </summary>
        public struct FindInvoicePlanParam
        {
            /// <summary>
            /// ESQ-ID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 事業部.
            /// </summary>
            public String division;
        }

        #endregion ライオン請求予定表パラメータ.

        #region ライオン受注差異一覧帳票パラメータ.

        /// <summary>
        /// ライオン受注比較一覧帳票パラメータ.
        /// </summary>
        public struct FindOrderDiffListParam
        {
            /// <summary>
            /// ESQ-ID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 事業部.
            /// </summary>
            public String division;
        }

        #endregion ライオン受注比較一覧帳票パラメータ.

        #endregion 構造体.

        #region インスタンス変数.

        /// <summary>
        /// マスタプロセスコントローラ.
        /// </summary>
        private static ReportLionProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター.
        /// </summary>
        private lionReportServiceAdapter _adapter;

        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.RepDsLion _dsRep;

        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.FDDSLion _dsFDLion;

        //2012/02/04 add start okazaki
        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.RepDsLion _dsDetailListLion;
        //2012/02/04 add end okazaki

        /* 2014/07/31 比較帳票対応・請求予定表対応 HLC fujimoto ADD start */
        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.AddChgDsLion _dsAddChgLion;
        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.InvoicePlanLion _dsInvPlnLion;
        /* 2014/07/31 比較帳票対応・請求予定表対応 HLC fujimoto ADD end */

        /* 2014/11/10 比較帳票対応 HLC fujimoto ADD start */
        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Lion.Schema.OrderDiffLion _dsOrdDiffListLion;
        /* 2014/11/10 比較帳票対応 HLC fujimoto ADD end */

        #endregion インスタンス変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタです.
        /// </summary>
        private ReportLionProcessController()
        {
            _adapter = CreateAdapter<lionReportServiceAdapter>();
        }

        #endregion コンストラクタ.

        #region メソッド.

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します.
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス.</returns>
        public static ReportLionProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportLionProcessController();
            }
            return _processController;
        }

        #region プルーフリスト.

        /// <summary>
        /// ライオンプルーフリスト表示データ取得.
        /// </summary>
        /// <param name="esqId">ESQ-ID</param>
        /// <param name="egCd">営業所コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="bmn">得意先部門SEQNO</param>
        /// <param name="tnt">得意先担当SEQNO</param>
        /// <param name="ymd">年月日</param>
        /// <param name="baitai">媒体区分コード</param>
        /// <returns></returns>
        public FindReportLionByCondServiceResult FindRepLionByCond(
            String esqId,
            String egCd,
            String tksKgyCd,
            String bmn,
            String tnt,
            String ymd,
            String baitai)
        {
            // サービス結果.
            FindReportLionByCondServiceResult serviceResult = new FindReportLionByCondServiceResult();

            reportLionCondition condition = new reportLionCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ymd;
            condition.baitai = baitai;

            // サービスの呼び出し.
            reportLionResult result = _adapter.findReportLionByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportLionByCondParseResult parseResult = ReportLionParser.ParseForFindReportLionByCond(result);
            _dsRep = parseResult.RepLionDataSet;

            // サービス結果の生成.
            serviceResult.dsRepLionDataSet = parseResult.RepLionDataSet;

            return serviceResult;
        }

        #endregion プルーフリスト.

        #region 見積書.

        /// <summary>
        /// ライオン見積帳票データ取得.
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>レポート(Lion)検索サービス結果</returns>
        public FindReportLionByCondServiceResult FindReportNewLionByCond(FindNewReportLionParam param)
        {
            // サービス結果.
            FindReportLionByCondServiceResult serviceResult = new FindReportLionByCondServiceResult();

            newReportLionCondition cond = new newReportLionCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.yymm = param.yymm;
            cond.baitaiCd = param.baitaiCd;

            // サービスの呼び出し.
            newReportLionResult result = _adapter.findNewReportLionByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportLionByCondParseResult parseResult = ReportLionParser.ParseForFindNewReportLionByCond(result);
            _dsRep = parseResult.RepLionDataSet;

            // サービス結果の生成.
            serviceResult.dsRepLionDataSet = parseResult.RepLionDataSet;

            return serviceResult;
        }

        #endregion 見積書.

        #region 請求データ.

        /// <summary>
        /// ライオン請求データ取得.
        /// </summary>
        /// <param name="esqId">ESQ-ID</param>
        /// <param name="egCd">営業所コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="bmn">得意先部門SEQNO</param>
        /// <param name="tnt">得意先担当SEQNO</param>
        /// <param name="ym">年月</param>
        /// <param name="kbn">区分</param>
        /// <returns></returns>
        public FindFDLionByCondServiceResult FindFDLionByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ym, String kbn)
        {
            // サービス結果.
            FindFDLionByCondServiceResult serviceResult = new FindFDLionByCondServiceResult();

            fdLionCondition condition = new fdLionCondition();

            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.bmncd = bmn;
            condition.tntcd = tnt;
            condition.YM = ym;
            condition.kbn = kbn;

            // サービスの呼び出し.
            fdLionResult result = _adapter.findFDLionByCond(condition);

            errorInfo info = result.errorInfo;

            if (( info != null ) && ( info.error ))
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;

                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindFDLionByCondParseResult parseResult = FDLionParser.ParseForFindFDLionByCond(result);

            _dsFDLion = parseResult.dsFDLion;

            // サービス結果の生成.
            serviceResult.dsFDLion = parseResult.dsFDLion;

            return serviceResult;
        }

        #endregion 請求データ.

        #region 明細一覧.

        //2012/02/04 add start okazaki
        /// <summary>
        /// 明細一覧帳票データ取得.
        /// </summary>
        /// <param name="esqId">ESQ-ID</param>
        /// <param name="egCd">営業所コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="bmn">得意先部門SEQNO</param>
        /// <param name="tnt">得意先担当SEQNO</param>
        /// <param name="ymFrom">開始年月</param>
        /// <param name="ymTo">終了年月</param>
        /// <param name="baitaiKbn">媒体区分</param>
        /// <returns>明細一覧帳票(Lion)検索サービス結果</returns>
        public FindDetailListLionByCondServiceResult FindDetailListLionByCond(
            String esqId,
            String egCd,
            String tksKgyCd,
            String bmn,
            String tnt,
            String ymFrom,
            String ymTo,
            String baitaiKbn)
        {
            // サービス結果.
            FindDetailListLionByCondServiceResult serviceResult = new FindDetailListLionByCondServiceResult();

            detailListLionCondition condition = new detailListLionCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ymFrom;
            condition.ymfrom = ymFrom;
            condition.ymto = ymTo;
            condition.baitaikbn = baitaiKbn;

            // サービスの呼び出し.
            detailListLionResult result = _adapter.findDetailListLionByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindDetailListLionByCondParseResult parseResult = DetailListLionParser.ParseForFindDetailListLionByCond(result);
            _dsDetailListLion = parseResult.DetailListLionDataSet;

            // サービス結果の生成.
            serviceResult.dsDetailListLionDataSet = parseResult.DetailListLionDataSet;

            return serviceResult;
        }
        //2012/02/04 add end okazaki

        #endregion 明細一覧.

        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */

        #region 制作室リスト(履歴タイムスタンプ).

        /// <summary>
        /// 制作室リスト用履歴タイムスタンプ取得.
        /// </summary>
        /// <param name="param">制作室リスト帳票パラメータ</param>
        /// <param name="intType">出力帳票種別</param>
        /// <returns>制作室リスト検索サービス結果</returns>
        public FindAddChangeReportByCondServiceResult findLionRrkTimStmp(FindAddChangeReportParam param, int intType)
        {
            //サービス結果.
            FindAddChangeReportByCondServiceResult serviceResult = new FindAddChangeReportByCondServiceResult();

            //２次制作室リストの場合.
            if (intType == 1)
            {
                addChangeReportLionSeisakuCondition condition = new addChangeReportLionSeisakuCondition();
                condition.esqId = param.esqId;              //ESQ-ID.
                condition.egCd = param.egCd;                //営業所コード.
                condition.tksKgyCd = param.tksKgyCd;        //得意先企業コード.
                condition.tksBmnSeqNo = param.tksBmnSeqNo;  //得意先部門SEQNO.
                condition.tksTntSeqNo = param.tksTntSeqNo;  //得意先担当SEQNO.
                condition.yymm = param.yymm;                //年月.
                condition.findType = param.findType;        //検索種別.

                //サービスの呼び出し.
                addChangeReportLionSeisakuResult result = _adapter.findAddChangeReportSeisakuByCond(condition);

                errorInfo err = result.errorInfo;
                if (err != null && err.error)
                {
                    //サービスの呼び出しエラー.
                    serviceResult.MessageCode = err.errorCode;
                    serviceResult.Note = err.note;

                    return serviceResult;
                }

                //パース.
                FindAddChangeReportByCondParserResult parseResult
                    = AddChangeReportParser.ParseForFindAddChangeReportSeisakuByCond(result, param.findType);

                _dsAddChgLion = parseResult.AddChgLionDataSet;

                // サービス結果の生成.
                serviceResult.dsAddChgLionDataSet = parseResult.AddChgLionDataSet;
            }
            //追加変更リストの場合.
            else
            {
                addChangeReportLionBaitaiCondition condition = new addChangeReportLionBaitaiCondition();
                condition.esqId = param.esqId;              //ESQ-ID.
                condition.egCd = param.egCd;                //営業所コード.
                condition.tksKgyCd = param.tksKgyCd;        //得意先企業コード.
                condition.tksBmnSeqNo = param.tksBmnSeqNo;  //得意先部門SEQNO.
                condition.tksTntSeqNo = param.tksTntSeqNo;  //得意先担当SEQNO.
                condition.yymm = param.yymm;                //年月.
                condition.findType = param.findType;        //検索種別.

                //サービスの呼び出し.
                addChangeReportLionBaitaiResult result = _adapter.findAddChangeReportBaitaiByCond(condition);

                errorInfo err = result.errorInfo;
                if (err != null && err.error)
                {
                    //サービスの呼び出しエラー.
                    serviceResult.MessageCode = err.errorCode;
                    serviceResult.Note = err.note;

                    return serviceResult;
                }

                //パース.
                FindAddChangeReportByCondParserResult parseResult
                    = AddChangeReportParser.ParseForFindAddChangeReportBaitaiByCond(result, param.findType);

                _dsAddChgLion = parseResult.AddChgLionDataSet;

                // サービス結果の生成.
                serviceResult.dsAddChgLionDataSet = parseResult.AddChgLionDataSet;
            }

            return serviceResult;
        }

        #endregion 制作室リスト(履歴タイムスタンプ).

        #region 履歴作成.

        /// <summary>
        /// ライオン受注履歴作成.
        /// </summary>
        /// <param name="param">ライオン受注履歴作成パラメータ</param>
        /// <returns>ライオン受注履歴作成サービス結果</returns>
        public RegisterLionOrderHistoryServiceResult registerLionOrderHistory(RegisterLionOrderHistoryParam param)
        {
            //サービス結果.
            RegisterLionOrderHistoryServiceResult serviceResult = new RegisterLionOrderHistoryServiceResult();

            lionHistoryCondition condition = new lionHistoryCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.rrkTimStmp = param.rrkTimStmp;
            condition.rrkGetBaitai = param.rrkGetBaitai;

            //サービスの呼び出し.
            lionHistoryResult result = _adapter.registerLionOrderHistory(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            return serviceResult;
        }

        #endregion 履歴作成.

        #region 制作室リスト(AD1).

        /// <summary>
        /// 制作室リスト(AD1)取得.
        /// </summary>
        /// <param name="param">制作室リスト帳票パラメータ</param>
        /// <returns>制作室リスト検索サービス結果</returns>
        public FindAddChangeReportByCondServiceResult findLionSeisakuAD1(FindAddChangeReportParam param)
        {
            //サービス結果.
            FindAddChangeReportByCondServiceResult serviceResult = new FindAddChangeReportByCondServiceResult();

            addChangeReportLionSeisakuCondition condition = new addChangeReportLionSeisakuCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.findType = param.findType;

            //サービスの呼び出し.
            addChangeReportLionSeisakuResult result = _adapter.findAddChangeReportSeisakuByCond(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            // パース.
            FindAddChangeReportByCondParserResult parseResult
                = AddChangeReportParser.ParseForFindAddChangeReportSeisakuByCond(result, param.findType);

            _dsAddChgLion = parseResult.AddChgLionDataSet;

            // サービス結果の生成.
            serviceResult.dsAddChgLionDataSet = parseResult.AddChgLionDataSet;

            return serviceResult;
        }

        #endregion 制作室リスト(AD1).

        #region 制作室リスト(AD2).

        /// <summary>
        /// 制作室リスト(AD2)取得.
        /// </summary>
        /// <param name="param">制作室リスト帳票パラメータ</param>
        /// <returns>制作室リスト検索サービス結果</returns>
        public FindAddChangeReportByCondServiceResult findLionSeisakuAD2(FindAddChangeReportParam param)
        {
            //サービス結果.
            FindAddChangeReportByCondServiceResult serviceResult = new FindAddChangeReportByCondServiceResult();

            addChangeReportLionSeisakuCondition condition = new addChangeReportLionSeisakuCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.findType = param.findType;
            condition.rrkTimStmp = param.rrkTimStmp;

            //サービスの呼び出し.
            addChangeReportLionSeisakuResult result = _adapter.findAddChangeReportSeisakuByCond(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            // パース.
            FindAddChangeReportByCondParserResult parseResult
                = AddChangeReportParser.ParseForFindAddChangeReportSeisakuByCond(result, param.findType);

            _dsAddChgLion = parseResult.AddChgLionDataSet;

            // サービス結果の生成.
            serviceResult.dsAddChgLionDataSet = parseResult.AddChgLionDataSet;

            return serviceResult;
        }

        #endregion 制作室リスト(AD2).

        #region 追加変更リスト.

        /// <summary>
        /// 追加変更リスト取得.
        /// </summary>
        /// <param name="param">制作室リスト・追加変更リスト帳票パラメータ</param>
        /// <returns>制作室リスト・追加変更リスト検索サービス結果</returns>
        public FindAddChangeReportByCondServiceResult findLionBaitai(FindAddChangeReportParam param)
        {
            //サービス結果.
            FindAddChangeReportByCondServiceResult serviceResult = new FindAddChangeReportByCondServiceResult();

            addChangeReportLionBaitaiCondition condition = new addChangeReportLionBaitaiCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.findType = param.findType;
            condition.rrkTimStmp = param.rrkTimStmp;

            //サービスの呼び出し.
            addChangeReportLionBaitaiResult result = _adapter.findAddChangeReportBaitaiByCond(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            // パース.
            FindAddChangeReportByCondParserResult parseResult
                = AddChangeReportParser.ParseForFindAddChangeReportBaitaiByCond(result, param.findType);

            _dsAddChgLion = parseResult.AddChgLionDataSet;

            // サービス結果の生成.
            serviceResult.dsAddChgLionDataSet = parseResult.AddChgLionDataSet;

            return serviceResult;
        }

        #endregion 追加変更リスト.

        #region 制作室請求予定表.

        /// <summary>
        /// 請求予定表取得.
        /// </summary>
        /// <param name="param">ライオン請求予定表検索パラメータ</param>
        /// <returns>ライオン請求予定表検索サービス結果</returns>
        public FindInvoicePlanByCondServiceResult findLionInvoicePlan(FindInvoicePlanParam param)
        {
            //サービス結果.
            FindInvoicePlanByCondServiceResult serviceResult = new FindInvoicePlanByCondServiceResult();

            invoicePlanLionCondition condition = new invoicePlanLionCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.division = param.division;

            //サービスの呼び出し.
            invoicePlanLionResult result = _adapter.findInvoicePlanByCond(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            // パース.
            FindInvoicePlanByCondParserResult parseResult
                = InvoicePlanParser.ParseForFindInvoicePlanByCond(result);
            _dsInvPlnLion = parseResult.InvPlnLionDataSet;

            // サービス結果の生成.
            serviceResult.dsInvPlnLionDataSet = parseResult.InvPlnLionDataSet;

            return serviceResult;
        }

        #endregion 制作室請求予定表.

        /* 2014/07/31 比較帳票対応・請求予定表対応 HLC fujimoto ADD end */

        /* 2014/11/10 比較帳票対応 HLC fujimoto ADD start */

        #region 受注比較一覧.

        /// <summary>
        /// 受注比較一覧取得.
        /// </summary>
        /// <param name="param">ライオン受注比較一覧帳票パラメータ</param>
        /// <returns>ライオン受注比較一覧検索サービス結果</returns>
        public FindOrderDiffListByCondServiceResult findOrderDiffList(FindOrderDiffListParam param)
        {
            //サービス結果.
            FindOrderDiffListByCondServiceResult serviceResult = new FindOrderDiffListByCondServiceResult();

            orderDiffListLionCondition condition = new orderDiffListLionCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;

            //サービスの呼び出し.
            orderDiffListLionResult result = _adapter.findOrderDiffListByCond(condition);

            errorInfo err = result.errorInfo;
            if (err != null && err.error)
            {
                //サービスの呼び出しエラー.
                serviceResult.MessageCode = err.errorCode;
                serviceResult.Note = err.note;

                return serviceResult;
            }

            // パース.
            FindOrderDiffListByCondParserResult parseResult = OrderDiffListParser.ParseForFindOrderDiffListByCond(result);
            _dsOrdDiffListLion = parseResult.OrdDiffListLionDataSet;

            // サービス結果の生成.
            serviceResult.dsOrdDiffListLionDataSet = parseResult.OrdDiffListLionDataSet;

            return serviceResult;
        }

        #endregion 受注比較一覧.

        /* 2014/11/10 比較帳票対応 HLC fujimoto ADD end */

        #endregion メソッド.
    }
}

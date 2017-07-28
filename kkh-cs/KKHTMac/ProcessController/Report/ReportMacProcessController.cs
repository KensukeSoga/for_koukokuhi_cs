using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Mac.ProcessController.Report.Parser;
using Isid.KKH.Common.KKHProcessController.Report.Converter;

namespace Isid.KKH.Mac.ProcessController.Report
{
    /// <summary>
    /// 帳票（Mac）プロセスコントローラ.
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
    ///       <description>2011/12/15</description>
    ///       <description>JSE KT</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class ReportMacProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義.

        /// <summary>
        /// ライセンシー向けデータ検索パラメータ構造体.
        /// </summary>
        public struct FindReportMacLicenseeByCondParam
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
            /// 伝票番号From.
            /// </summary>
            public String denFr;
            /// <summary>
            /// 伝票番号To.
            /// </summary>
            public String denTo;
        }

        /// <summary>
        /// 購入伝票データ検索パラメータ構造体.
        /// </summary>
        public struct FindReportMacPurchaseByCondParam
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
            /// 明細行フラグ.
            /// </summary>
            public String splitflg;
            /// <summary>
            /// 再印刷フラグ.
            /// </summary>
            public String reflg;
            /// <summary>
            /// テリトリー.
            /// </summary>
            public String territory;
            /// <summary>
            /// 店舗コード.
            /// </summary>
            public String tenpoCd;
            /// <summary>
            /// 伝票番号From.
            /// </summary>
            public String denFr;
            /// <summary>
            /// 伝票番号To.
            /// </summary>
            public String denTo;
        }

        /// <summary>
        /// 伝票番号採番データパラメータ構造体.
        /// </summary>
        public struct FindReportMacGetDenNumByCondParam
        {
            /// <summary>
            /// ESQID.
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
        }

        /// <summary>
        /// 購入伝票更新データパラメータ構造体.
        /// </summary>
        public struct UpdateReportMacPurParam
        {
            /// <summary>
            /// APLID.
            /// </summary>
            public String aplId;
            /// <summary>
            /// ESQID.
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
            /// 伝票NO.
            /// </summary>
            public String DenNum;
            /// <summary>
            /// 営業日.
            /// </summary>
            public String hostDate;
            /// <summary>
            /// 更新日.
            /// </summary>
            public DateTime maxUpDate;
            /// <summary>
            /// 更新データ.
            /// </summary>
            public Isid.KKH.Mac.Schema.RepDsMac.RepmacUpdPurchaseDataTable DataVO;
        }

        /// <summary>
        /// 請求書データ検索パラメータ構造体.
        /// </summary>
        public struct FindReportMacRequestByCondParam
        {
            /// <summary>
            /// ESQID.
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
            /// 再印刷フラグ.
            /// </summary>
            public String reflg;
            /// <summary>
            /// 店舗区分.
            /// </summary>
            public String tenpoKbn;
            /// <summary>
            /// 店舗コード.
            /// </summary>
            public String tenpoCd;
            /// <summary>
            /// 伝票番号From.
            /// </summary>
            public String denFr;
            /// <summary>
            /// 伝票番号To.
            /// </summary>
            public String denTo;
        }

        /// <summary>
        /// 購入伝票更新データパラメータ構造体.
        /// </summary>
        public struct UpdateReportMacReqParam
        {
            /// <summary>
            /// APLID.
            /// </summary>
            public String aplId;
            /// <summary>
            /// ESQID.
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
            /// 営業日.
            /// </summary>
            public String hostDate;
            /// <summary>
            /// 更新データ.
            /// </summary>
            public Isid.KKH.Mac.Schema.RepDsMac.RepmacUpdRequestDataTable DataVO;
        }

        #endregion パラメータ構造体定義.

        #region インスタンス変数.

        /// <summary>
        /// マスタプロセスコントローラ.
        /// </summary>
        private static ReportMacProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター.
        /// </summary>
        private macReportServiceAdapter _adapter;

        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Mac.Schema.RepDsMac _dsRep;

        #endregion インスタンス変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタです。.
        /// </summary>
        private ReportMacProcessController()
        {
            _adapter = CreateAdapter<macReportServiceAdapter>();
        }

        #endregion コンストラクタ.

        #region メソッド.

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。.
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static ReportMacProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportMacProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票データ検索.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindReportMacByCondServiceResult FindRepMacByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ymd, String denfr, String dento)
        {
            // サービス結果.
            FindReportMacByCondServiceResult serviceResult = new FindReportMacByCondServiceResult();

            reportMacCondition condition = new reportMacCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ymd;
            condition.denfr = denfr;
            condition.dento = dento;

            // サービスの呼び出し.
            reportMacResult result = _adapter.findReportMacByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportMacByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacByCond(result);
            _dsRep = parseResult.ReoMacDataSet;

            // サービス結果の生成.
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 帳票データ検索（購入伝票）.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindReportMacPurchaseByCondServiceResult FindRepMacPurchaseByCond(FindReportMacPurchaseByCondParam prm)
        {
            // サービス結果.
            FindReportMacPurchaseByCondServiceResult serviceResult = new FindReportMacPurchaseByCondServiceResult();

            reportMacPurchaseCondition condition = new reportMacPurchaseCondition();
            condition.esqId = prm.esqId;
            condition.egCd = prm.egCd;
            condition.tksKgyCd = prm.tksKgyCd;
            condition.tksBmnSeqNo = prm.tksBmnSeqNo;
            condition.tksTntSeqNo = prm.tksTntSeqNo;
            condition.ym = prm.yymm;
            condition.splitflg = prm.splitflg;
            condition.reflg = prm.reflg;
            condition.territory = prm.territory;
            condition.tenpocd = prm.tenpoCd;
            condition.denfr = prm.denFr;
            condition.dento = prm.denTo;

            // サービスの呼び出し.
            reportMacPurchaseResult result = _adapter.findReportMacPurchaseByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportMacPurchaseByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacPurchaseByCond(result);
            _dsRep = parseResult.ReoMacDataSet;

            // サービス結果の生成.
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

        /// <summary>
        /// ライセンシー向け帳票データの検索.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportMacLicenseeByCondServiceResult FindRepMacLicenseeByCond(FindReportMacLicenseeByCondParam param)
        {
            // サービス結果.
            FindReportMacLicenseeByCondServiceResult serviceResult = new FindReportMacLicenseeByCondServiceResult();
            reportMacCondition cond = new reportMacCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;
            cond.denfr = param.denFr;
            cond.dento = param.denTo;

            //サービスの呼び出し.
            reportMacLicenseeResult result = _adapter.findReportMacLicenseeByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            // パース.
            FindReportMacPurchaseByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacLicenseeByCond(result);
            _dsRep = parseResult.ReoMacDataSet;
            // サービス結果の生成.
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

        /// <summary>
        /// システムマスタのデータ検索.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindReportMacGetDenNumByCondServiceResult FindRepMacGetDenNumByCond(FindReportMacGetDenNumByCondParam prm)
        {
            // サービス結果.
            FindReportMacGetDenNumByCondServiceResult serviceResult = new FindReportMacGetDenNumByCondServiceResult();

            reportMacGetDenNumCondition condition = new reportMacGetDenNumCondition();
            condition.esqId = prm.esqId;
            condition.egCd = prm.egCd;
            condition.tksKgyCd = prm.tksKgyCd;
            condition.bmncd = prm.tksBmnSeqNo;
            condition.tntcd = prm.tksTntSeqNo;

            // サービスの呼び出し.
            reportMacGetDenNumResult result = _adapter.findReportMacGetDenNumByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportMacGetDenNumByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacGetDenNumByCond(result);
            _dsRep = parseResult.ReoMacDataSet;

            // サービス結果の生成.
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 購入伝票データ更新.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public UpdateReportMacPurServiceResult UpdateReportMacPur(UpdateReportMacPurParam prm)
        {
            // サービス結果.
            UpdateReportMacPurServiceResult serviceResult = new UpdateReportMacPurServiceResult();

            updateReportMacPurCondition vo = new updateReportMacPurCondition();
            vo.aplId = prm.aplId;
            vo.esqId = prm.esqId;
            vo.tksKgyCd = prm.tksKgyCd;
            vo.tksBmnSeqNo = prm.tksBmnSeqNo;
            vo.tksTntSeqNo = prm.tksTntSeqNo;
            vo.egCd = prm.egCd;
            vo.denNum = prm.DenNum;
            vo.reportData = ReportMacConverter.ConvertForPurchaseUpd(prm.DataVO);
            vo.hostDate = prm.hostDate;
            vo.maxUpDate = prm.maxUpDate;

            // サービスの呼び出し.
            updateReportMacPurResult result = _adapter.updateReportMacPur(vo);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            return serviceResult;
        }

        /// <summary>
        /// 帳票データ検索（請求書）.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindReportMacRequestByCondServiceResult FindRepMacRequestByCond(FindReportMacRequestByCondParam prm)
        {
            // サービス結果.
            FindReportMacRequestByCondServiceResult serviceResult = new FindReportMacRequestByCondServiceResult();

            reportMacRequestCondition condition = new reportMacRequestCondition();
            condition.esqId = prm.esqId;
            condition.egCd = prm.egCd;
            condition.tksKgyCd = prm.tksKgyCd;
            condition.tksBmnSeqNo = prm.tksBmnSeqNo;
            condition.tksTntSeqNo = prm.tksTntSeqNo;
            condition.ym = prm.yymm;
            condition.reflg = prm.reflg;
            condition.tenpoKbn = prm.tenpoKbn;
            condition.tenpocd = prm.tenpoCd;
            condition.denfr = prm.denFr;
            condition.dento = prm.denTo;

            // サービスの呼び出し.
            reportMacRequestResult result = _adapter.findReportMacRequestByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportMacRequestByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacRequestByCond(result);
            _dsRep = parseResult.ReoMacDataSet;

            // サービス結果の生成.
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 請求書データ更新.
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public UpdateReportMacReqServiceResult UpdateReportMacReq(UpdateReportMacReqParam prm)
        {
            // サービス結果.
            UpdateReportMacReqServiceResult serviceResult = new UpdateReportMacReqServiceResult();

            updateReportMacReqCondition vo = new updateReportMacReqCondition();
            vo.aplId = prm.aplId;
            vo.esqId = prm.esqId;
            vo.tksKgyCd = prm.tksKgyCd;
            vo.tksBmnSeqNo = prm.tksBmnSeqNo;
            vo.tksTntSeqNo = prm.tksTntSeqNo;
            vo.egCd = prm.egCd;
            vo.reportData = ReportMacConverter.ConvertForRequestUpd(prm.DataVO);
            vo.hostDate = prm.hostDate;

            // サービスの呼び出し.
            updateReportMacReqResult result = _adapter.updateReportMacReq(vo);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            return serviceResult;
        }

        #endregion
    }
}

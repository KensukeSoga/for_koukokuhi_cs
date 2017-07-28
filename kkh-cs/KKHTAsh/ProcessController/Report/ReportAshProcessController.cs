using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Common.KKHProcessController.Report;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Ash.ProcessController.Report.Parser;
using Isid.KKH.Ash.Schema;
namespace Isid.KKH.Ash.ProcessController.Report
{
    /// <summary>
    /// 帳票（Ash）プロセスコントローラ
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/1/19</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportAshProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体

        public struct FindReportAshByMedium
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            public String yymm;
        }
        #endregion パラメータ構造体

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        private ReportAshProcessController()
        {
            _adapter = CreateAdapter<ashReportServiceAdapter>();
        }
        #endregion コンストラクタ

        #region インスタンス変数
        /// <summary>
        /// アサヒプロセスコントローラ 
        /// </summary>
        private static ReportAshProcessController _processController;
        /// <summary>
        /// アサヒサービスアダプター 
        /// </summary>
        private ashReportServiceAdapter _adapter;
        /// <summary>
        /// アサヒデータセット 
        /// </summary>
        private static RepDsAsh _dsRep;

        #endregion インスタンス変数


        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static ReportAshProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportAshProcessController();
            }
            return _processController;
        }


        /// <summary>
        /// 媒体種別データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportAshMediaByCondServiceResult findReportMedia(FindReportAshByMedium param)
        {
            FindReportAshMediaByCondServiceResult serviceResult = new FindReportAshMediaByCondServiceResult();
            reportAshMediaCondition cond = new reportAshMediaCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;

            reportAshMediaResult result = _adapter.findReportAshMediaByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            FindReportAshMediaByCondServiceResult parseResult = ReportAshParser.ParseForFindReportAshMediaByCond(result);
            _dsRep = parseResult.dsAshDataSet;

            // サービス結果の生成 
            serviceResult.dsAshDataSet = parseResult.dsAshDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 媒体マスタ名取得 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportAshMediaByCondServiceResult findReportMediaCode(FindReportAshByMedium param)
        {
            FindReportAshMediaByCondServiceResult serviceResult = new FindReportAshMediaByCondServiceResult();
            reportAshMediaCondition cond = new reportAshMediaCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;

            reportAshMediaCodeResult result = _adapter.findReportAshMediaCodeByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            FindReportAshMediaByCondServiceResult parseResult = ReportAshParser.ParseForFindReportAshMediaCodeByCond(result);
            _dsRep = parseResult.dsAshDataSet;

            // サービス結果の生成 
            serviceResult.dsAshDataSet = parseResult.dsAshDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 媒体種別データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportAshMediaByCondServiceResult findReportMediaChklst(FindReportAshByMedium param)
        {
            FindReportAshMediaByCondServiceResult serviceResult = new FindReportAshMediaByCondServiceResult();
            reportAshMediaCondition cond = new reportAshMediaCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;

            reportAshMediaChklstResult result = _adapter.findReportAshMediaChklstByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            FindReportAshMediaByCondServiceResult parseResult = ReportAshParser.ParseForFindReportAshMediaChklstByCond(result);
            _dsRep = parseResult.dsAshDataSet;

            // サービス結果の生成 
            serviceResult.dsAshDataSet = parseResult.dsAshDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 広告費データ一覧を検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportAshMediaByCondServiceResult findReportKoukokuHi(FindReportAshByMedium param)
        {
            FindReportAshMediaByCondServiceResult serviceResult = new FindReportAshMediaByCondServiceResult();
            reportAshMediaCondition cond = new reportAshMediaCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;

            reportAshKoukokuHiResult result = _adapter.findReportAshKoukokuHiByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            FindReportAshMediaByCondServiceResult parseResult = ReportAshParser.ParseForFindReportAshKoukokuHiByCond(result);
            _dsRep = parseResult.dsAshDataSet;
            // サービス結果の生成 
            serviceResult.dsAshDataSet = parseResult.dsAshDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 請求データ一覧を検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindReportAshMediaByCondServiceResult findFD(FindReportAshByMedium param)
        {
            FindReportAshMediaByCondServiceResult serviceResult = new FindReportAshMediaByCondServiceResult();
            reportAshMediaCondition cond = new reportAshMediaCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.ym = param.yymm;

            fdAshResult result = _adapter.findFDAshByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            FindReportAshMediaByCondServiceResult parseResult = ReportAshParser.ParseForFindFDByCond(result);
            _dsRep = parseResult.dsAshDataSet;
            // サービス結果の生成 
            serviceResult.dsAshDataSet = parseResult.dsAshDataSet;

            return serviceResult;
        }


        #endregion メソッド

    }
}

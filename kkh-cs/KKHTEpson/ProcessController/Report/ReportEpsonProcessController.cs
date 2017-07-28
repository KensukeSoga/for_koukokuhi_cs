using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Epson.ProcessController.Report.Parser;

namespace Isid.KKH.Epson.ProcessController.Report
{
    /// <summary>
    /// 帳票プロセスコントローラ(エプソン) 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>2012/03/12</description>
    ///       <description>IP J.Kamiyama</description>
    ///       <description>修正</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/3/5</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportEpsonProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 帳票（エプソン_提出帳票）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportEpsonSubMissionByCondParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            internal string esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            internal string egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            internal string tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            internal string tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            internal string tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            internal string yymm;
        }

        /// <summary>
        /// 帳票（エプソン_請求予定一覧）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportEpsonSeikyuPlanByCondParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            internal string esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            internal string egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            internal string tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            internal string tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            internal string tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            internal string yymm;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// 帳票プロセスコントローラ(エプソン) 
        /// </summary>
        private static ReportEpsonProcessController _processController;

        /// <summary>
        /// 帳票サービスアダプター(エプソン) 
        /// </summary>
        private epsonReportServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Epson.Schema.RepDsEpson _dsEpson;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private ReportEpsonProcessController()
        {
            _adapter = CreateAdapter<epsonReportServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 帳票プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>帳票プロセスコントローラのインスタンス</returns>
        internal static ReportEpsonProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportEpsonProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票（エプソン_提出帳票）データ検索 
        /// </summary>
        /// <param name="param">帳票（エプソン_提出帳票）データ検索パラメータ構造体</param>
        /// <returns>帳票（エプソン_提出帳票）検索サービス結果</returns>
        internal FindReportEpsonSubMissionByCondServiceResult FindReportEpsonSubMissionByCond(FindReportEpsonSubMissionByCondParam param)
        {
            // 帳票（エプソン_提出帳票）データ検索サービス結果 
            FindReportEpsonSubMissionByCondServiceResult serviceResult =
                new FindReportEpsonSubMissionByCondServiceResult();

            reportEpsonSubMissionCondition condition = new reportEpsonSubMissionCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;

            // サービスの呼び出し 
            reportEpsonSubMissionResult result = _adapter.findReportEpsonSubMissionByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportEpsonSubMissionByCondParseResult parseResult =
                ReportEpsonParser.ParseForFindReportEpsonSubMissionByCond(result);

            _dsEpson = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        /// <summary>
        /** 2012/03/13 UPDATE START */
        /// 帳票（エプソン_請求予定一覧）データ検索 
        /// </summary>
        /// <param name="param">帳票（エプソン_請求予定一覧）データ検索パラメータ構造体</param>
        /// <returns>帳票（エプソン_請求予定一覧）検索サービス結果</returns>
        internal FindReportEpsonSeikyuPlanByCondServiceResult FindReportEpsonSeikyuPlanByCond(FindReportEpsonSeikyuPlanByCondParam param)
        {
            // 帳票（エプソン_請求予定一覧）データ検索サービス結果 
            FindReportEpsonSeikyuPlanByCondServiceResult serviceResult =
                new FindReportEpsonSeikyuPlanByCondServiceResult();

            reportEpsonSeikyuPlanCondition condition = new reportEpsonSeikyuPlanCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;

            // サービスの呼び出し 
            reportEpsonSeikyuPlanResult result = _adapter.findReportEpsonSeikyuPlanByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportEpsonSeikyuPlanByCondParseResult parseResult =
                ReportEpsonParser.ParseForFindReportEpsonSeikyuPlanByCond(result);

            _dsEpson = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }
        /** 2012/03/13 UPDATE END */

        #endregion メソッド 
    }
}

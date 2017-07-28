using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Uni.ProcessController.Report.Parser;

namespace Isid.KKH.Uni.ProcessController.Report
{
    /// <summary>
    /// 帳票プロセスコントローラ(ユニチャーム) 
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
    ///       <description>2012/1/24</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportUniProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 帳票（ユニチャーム_広告費明細表）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportUniByCondParam
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
            /// <summary>
            /// 部署 
            /// </summary>
            internal string busho;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// 帳票プロセスコントローラ(ユニチャーム) 
        /// </summary>
        private static ReportUniProcessController _processController;

        /// <summary>
        /// 帳票サービスアダプター(ユニチャーム) 
        /// </summary>
        private uniReportServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Uni.Schema.RepDsUni _dsUni;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private ReportUniProcessController()
        {
            _adapter = CreateAdapter<uniReportServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 帳票プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>帳票プロセスコントローラのインスタンス</returns>
        internal static ReportUniProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportUniProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票（ユニチャーム_広告費明細表）データ検索 
        /// </summary>
        /// <param name="param">帳票（ユニチャーム_広告費明細表）データ検索パラメータ構造体</param>
        /// <returns>帳票（ユニチャーム_広告費明細表）データ検索サービス結果</returns>
        internal FindReportUniByCondServiceResult FindReportUniByCond(FindReportUniByCondParam param)
        {
            // 帳票（ユニチャーム_広告費明細表）データ検索サービス結果 
            FindReportUniByCondServiceResult serviceResult = new FindReportUniByCondServiceResult();

            reportUniCondition condition = new reportUniCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.busho = param.busho;
            

            // サービスの呼び出し 
            reportUniResult result = _adapter.findReportUniByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportUniByCondParseResult parseResult = ReportParser.ParseForFindReportUniByCond(result);
            _dsUni = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        #endregion メソッド 
    }
}

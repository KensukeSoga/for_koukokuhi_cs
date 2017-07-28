using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Kmn.ProcessController.Report.Parser;

namespace Isid.KKH.Kmn.ProcessController.Report
{
    /// <summary>
    /// 帳票(伝票)プロセスコントローラ(公文) 
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
    ///       <description>2013/1/31</description>
    ///       <description>JSE M.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportKmnProcessController : KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 帳票（伝票）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportKmnByCondParam
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
            /// 部門コード 
            /// </summary>
            internal string bumonCd;
            /// <summary>
            /// 出力No
            /// </summary>
            internal string outputNo;
        }

        #endregion パラメータ構造体定義

        #region インスタンス変数

        /// <summary>
        /// 帳票(伝票)プロセスコントローラ(公文) 
        /// </summary>
        private static ReportKmnProcessController _processController;

        /// <summary>
        /// 帳票(伝票)サービスアダプター(公文) 
        /// </summary>
        private kmnReportServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Kmn.Schema.RepDSKmn _dsKmn;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private ReportKmnProcessController()
        {
            _adapter = CreateAdapter<kmnReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// 帳票(伝票)プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>帳票プロセスコントローラのインスタンス</returns>
        internal static ReportKmnProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportKmnProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票(公文_伝票)データ検索 
        /// </summary>
        /// <param name="param">帳票(公文_伝票)データ検索パラメータ構造体</param>
        /// <returns>帳票(公文_伝票)データ検索サービス結果</returns>
        internal FindReportKmnByCondServiceResult FindReportKmnByCond(FindReportKmnByCondParam param)
        {
            // 帳票(公文_伝票)データ検索サービス結果 
            FindReportKmnByCondServiceResult serviceResult = new FindReportKmnByCondServiceResult();

            reportKmnCondition condition = new reportKmnCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.bumon = param.bumonCd;
            condition.outputNo = param.outputNo;

            // サービスの呼び出し 
            reportKmnResult result = _adapter.findReportKmnByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportKmnByCondParseResult parseResult = ReportKmnParser.ParseForFindReportKmnByCond(result);
            _dsKmn = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        #endregion メソッド
    }
}

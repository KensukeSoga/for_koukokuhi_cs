using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Skyp.ProcessController.Report.Parser;

namespace Isid.KKH.Skyp.ProcessController.Report
{
    /// <summary>
    /// 帳票プロセスコントローラ(スカパー) 
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
    ///       <description>2012/1/16</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportSkypProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 帳票（スカパー_納品／請求書）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportSkypByCondParam
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
        /// 帳票プロセスコントローラ(スカパー) 
        /// </summary>
        private static ReportSkypProcessController _processController;

        /// <summary>
        /// 帳票サービスアダプター(スカパー) 
        /// </summary>
        private reportSkypServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Skyp.Schema.RepDSSkyp _dsSkyp;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private ReportSkypProcessController()
        {
            _adapter = CreateAdapter<reportSkypServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 帳票プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>帳票プロセスコントローラのインスタンス</returns>
        internal static ReportSkypProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportSkypProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票（スカパー_納品／請求書）データ検索 
        /// </summary>
        /// <param name="param">帳票（スカパー_納品／請求書）データ検索パラメータ構造体</param>
        /// <returns>並び順データ検索サービス結果</returns>
        internal FindReportSkypByCondServiceResult FindReportSkypByCond(FindReportSkypByCondParam param)
        {
            // 帳票（スカパー_納品／請求書）データ検索サービス結果 
            FindReportSkypByCondServiceResult serviceResult = new FindReportSkypByCondServiceResult();

            reportSkypCondition condition = new reportSkypCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;

            // サービスの呼び出し 
            reportSkypResult result = _adapter.findReportSkypByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportSkypByCondParseResult parseResult = ReportParser.ParseForFindReportSkypByCond(result);
            _dsSkyp = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        #endregion メソッド 
    }
}

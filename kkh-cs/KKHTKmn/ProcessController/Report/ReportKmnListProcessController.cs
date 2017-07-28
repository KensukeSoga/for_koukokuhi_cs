using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Kmn.ProcessController.Report.Parser;
using Isid.KKH.Kmn.ProcessController.Converter;

namespace Isid.KKH.Kmn.ProcessController.Report
{
    /// <summary>
    /// 帳票(請求一覧)プロセスコントローラ(公文) 
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
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportKmnListProcessController : KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 帳票（請求明細一覧）データ検索パラメータ構造体 
        /// </summary>
        internal struct FindReportKmnListByCondParam
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
            /// 出力単位
            /// </summary>
            internal string output;
        }

        /// <summary>
        /// 帳票（請求明細一覧）データ登録パラメータ構造体 
        /// </summary>
        internal struct UpdateSeqNoByCondParam
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
            /// 請求明細一覧データセット(登録データ) 
            /// </summary>
            public Schema.RepDSKmn dsRepKmn;
        }
        #endregion パラメータ構造体定義

        #region インスタンス変数

        /// <summary>
        /// 帳票(請求明細一覧)プロセスコントローラ(公文) 
        /// </summary>
        private static ReportKmnListProcessController _processController;

        /// <summary>
        /// 帳票(請求明細一覧)サービスアダプター(公文) 
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
        private ReportKmnListProcessController()
        {
            _adapter = CreateAdapter<kmnReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// 帳票(請求明細一覧)プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>帳票プロセスコントローラのインスタンス</returns>
        internal static ReportKmnListProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportKmnListProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票(公文_請求明細一覧)データ検索 
        /// </summary>
        /// <param name="param">帳票(公文_請求明細一覧)データ検索パラメータ構造体</param>
        /// <returns>帳票(公文_請求明細一覧)データ検索サービス結果</returns>
        internal FindReportKmnListByCondServiceResult FindReportKmnByCond(FindReportKmnListByCondParam param)
        {
            // 帳票(公文_請求明細一覧)データ検索サービス結果 
            FindReportKmnListByCondServiceResult serviceResult = new FindReportKmnListByCondServiceResult();

            reportKmnListCondition condition = new reportKmnListCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.bumonCd = param.bumonCd;
            condition.output = param.output;


            // サービスの呼び出し 
            reportKmnListResult result = _adapter.findReportKmnListByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportKmnListByCondParseResult parseResult = ReportParser.ParseForFindReportKmnListByCond(result);
            _dsKmn = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        /// <summary>
        /// シークエンスNo最大値取得 
        /// </summary>
        /// <param name="param">帳票(公文_請求一覧)データ検索パラメータ構造体</param>
        /// <returns>帳票(公文_請求一覧)データ検索サービス結果</returns>
        internal FindReportKmnListByCondServiceResult FindMaxSeqNoByCond(FindReportKmnListByCondParam param)
        {
            // 帳票(公文_請求一覧)データ検索サービス結果 
            FindReportKmnListByCondServiceResult serviceResult = new FindReportKmnListByCondServiceResult();

            maxSeqNoCondition condition = new maxSeqNoCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            //請求年月 
            condition.yyMm = param.yymm;


            // サービスの呼び出し 
            maxSeqNoResult result = _adapter.getMaxSeqNoByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindReportKmnListByCondParseResult parseResult = ReportParser.ParseForGetMaxSeqNoByCond(result);
            _dsKmn = parseResult.ReportDataSet;

            // サービス結果の生成 
            serviceResult.ReportDataSet = parseResult.ReportDataSet;

            return serviceResult;
        }

        /// <summary>
        /// シークエンスNo登録・更新 
        /// </summary>
        /// <param name="param">帳票(公文_請求一覧)データ検索パラメータ構造体</param>
        /// <returns>帳票(公文_請求一覧)データ検索サービス結果</returns>
        internal UpdateSeqNoByCondServiceResult UpdateSeqNoByCond(UpdateSeqNoByCondParam param, Schema.RepDSKmn dsRepKmn)
        {
            // 帳票(公文_請求一覧)データ検索サービス結果 
            UpdateSeqNoByCondServiceResult serviceResult = new UpdateSeqNoByCondServiceResult();
            
            

            updateSeqNoCondition condition = new updateSeqNoCondition();
            //condition.esqId = param.esqId;
            //condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            //param.dsRepKmn = dsRepKmn;
            condition.repKmnList = RepKmnListDataSetConverter.ConvertForRepKmnList(dsRepKmn);
            //請求年月 
            condition.ym = param.yymm;

            // サービスの呼び出し 
            updateSeqNoResult result = _adapter.updateSeqNoByCond(condition);

            if (result != null)
            {
                errorInfo info = result.errorInfo;
                if (info != null && info.error)
                {
                    // サービスの呼び出しエラー 
                    serviceResult.MessageCode = info.errorCode;
                    serviceResult.Note = info.note;

                    return serviceResult;
                }
            }

            return serviceResult;
        }

        #endregion メソッド
    }
}

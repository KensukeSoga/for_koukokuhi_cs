using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Common.KKHProcessController.Report.Parser;

namespace Isid.KKH.Common.KKHProcessController.Report
{
    /// <summary>
    /// 帳票（Mac）プロセスコントローラ
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
    ///       <description>2011/12/15</description>
    ///       <description>JSE KT</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class ReportMacProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static ReportMacProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private macReportServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.RepDsMac _dsRep;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        private ReportMacProcessController()
        {
            _adapter = CreateAdapter<macReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。

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
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportMacByCondServiceResult FindRepMacByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ymd, String denfr, String dento)
        {
            // サービス結果
            FindReportMacByCondServiceResult serviceResult = new FindReportMacByCondServiceResult();

            reportMacCondition condition = new reportMacCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.bmncd = bmn;
            condition.tntcd = tnt;
            condition.ymd = ymd;
            condition.denfr = denfr;
            condition.dento = dento;

            // サービスの呼び出し
            reportMacResult result = _adapter.findReportMacByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportMacByCondParseResult parseResult = ReportMacParser.ParseForFindReportMacByCond(result);
            _dsRep = parseResult.ReoMacDataSet;

            // サービス結果の生成
            serviceResult.dsRepMacDataSet = parseResult.ReoMacDataSet;

            return serviceResult;
        }

      

        #endregion
    }
}

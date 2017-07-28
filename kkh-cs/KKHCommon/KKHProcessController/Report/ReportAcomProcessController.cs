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
    /// 帳票（Acom）プロセスコントローラ.
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
    ///   </list>
    /// </remarks>
    public class ReportAcomProcessController:Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数
        /// <summary>
        /// マスタプロセスコントローラ.
        /// </summary>
        private static ReportAcomProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター.
        /// </summary>
        private acomReportServiceAdapter _adapter;

        /// <summary>
        /// データセット.
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.RepDsAcom _dsRep;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです.
        /// </summary>
        private ReportAcomProcessController()
        {
            _adapter = CreateAdapter<acomReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します.
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス.</returns>
        public static ReportAcomProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportAcomProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票データ検索.
        /// </summary>
        /// <returns>検索サービス結果.</returns>
        /// ログイン担当者ESQID.
        /// 営業所（取）コード.
        /// 得意先企業コード.
        /// 得意先部門コード.
        /// 得意先担当コード.
        /// 年月. 
        /// 媒体.
        public FindReportAcomByCondServiceResult FindRepAcomByCond(
            String esqId,
            String egCd, 
            String tksKgyCd, 
            String bmn, 
            String tnt, 
            String ymd, 
            String baitai)
        {
            // サービス結果.
            FindReportAcomByCondServiceResult serviceResult = new FindReportAcomByCondServiceResult();

            reportAcomCondition condition = new reportAcomCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ymd;
            condition.baitai = baitai;

            // サービスの呼び出し.
            reportAcomResult result = _adapter.findReportAcomByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindReportAcomByCondParseResult parseResult = ReportAcomParser.ParseForFindReportAcomByCond(result);
            _dsRep = parseResult.RepAcomDataSet;

            // サービス結果の生成.
            serviceResult.dsRepAcomDataSet = parseResult.RepAcomDataSet;

            return serviceResult;
        }
        #endregion
    }
}

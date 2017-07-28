using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Lion.ProcessController.Report.Parser;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Report
{
    //TODO FD出力の名称は廃止となるため、名称が確定し次第修正する事

    /// <summary>
    /// ライオンFD出力プロセスコントローラ 
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
    ///       <description>2012/02/13</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FDLionProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static FDLionProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private lionReportServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static FDDSLion _dsFDLion;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private FDLionProcessController()
        {
            _adapter = CreateAdapter<lionReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static FDLionProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new FDLionProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 媒体データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindFDLionByCondServiceResult FindFDLionByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ym, String kbn)
        {
            // サービス結果
            FindFDLionByCondServiceResult serviceResult = new FindFDLionByCondServiceResult();

            fdLionCondition condition = new fdLionCondition();

            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.bmncd = bmn;
            condition.tntcd = tnt;
            condition.YM = ym;
            condition.kbn = kbn;

            // サービスの呼び出し
            fdLionResult result = _adapter.findFDLionByCond(condition);

            errorInfo info = result.errorInfo;

            if (( info != null ) && ( info.error ))
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;

                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindFDLionByCondParseResult parseResult = FDLionParser.ParseForFindFDLionByCond(result);

            _dsFDLion = parseResult.dsFDLion;

            // サービス結果の生成
            serviceResult.dsFDLion = parseResult.dsFDLion;

            return serviceResult;
        }

        #endregion
    }
}

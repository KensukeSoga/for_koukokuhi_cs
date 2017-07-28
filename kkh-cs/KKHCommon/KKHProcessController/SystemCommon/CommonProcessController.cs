using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.SystemCommon.Parser;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.SystemCommon
{
    /// <summary>
    /// プランプロセスコントローラ 
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
    ///       <description>2011/02/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class CommonProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ 
        /// </summary>
        private static CommonProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター 
        /// </summary>
        private commonServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.Common _dsMaster;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private CommonProcessController()
        {
            _adapter = CreateAdapter<commonServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static CommonProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new CommonProcessController();
            }
            return _processController;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <param name="sybt"></param>
        /// <param name="systemKeyNo"></param>
        /// <returns></returns>
        public FindCommonByCondServiceResult FindCommonByCond(String esqId,
                                                                String egCd, 
                                                                String tksKgyCd, 
                                                                String tksBmnSeqNo, 
                                                                String tksTntSeqNo,
                                                                String sybt,
                                                                String systemKeyNo)
        {
            //サービス結果 
            FindCommonByCondServiceResult serviceResult = new FindCommonByCondServiceResult();

            commonCondition condition = new commonCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = tksBmnSeqNo;
            condition.tksTntSeqNo = tksTntSeqNo;
            condition.sybt = sybt;
            condition.field1 = systemKeyNo;
            //サービスの呼び出し 
            commonResult result = _adapter.findCommonByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindCommonByCondParseResult parseResult = CommonParser.ParseForFindCommonByCond(result);
            _dsMaster = parseResult.CommonDataSet;

            // サービス結果の生成 
            serviceResult.CommonDataSet = parseResult.CommonDataSet;

            return serviceResult;
        }


        /// <summary>
        /// 共通コードマスタ(rcmn_MEU29CC)の条件指定検索を行う 
        /// </summary>
        /// <param name="esqId">ログイン者ESQ-ID</param>
        /// <param name="kyCdKnd"></param>
        /// <param name="kijyunYmd"></param>
        /// <returns></returns>
        public FindCommonCodeMasterByCondServiceResult FindCommonCodeMasterByCond(String esqId,
                                                                String kyCdKnd,
                                                                String kijyunYmd)
        {
            //サービス結果 
            FindCommonCodeMasterByCondServiceResult serviceResult = new FindCommonCodeMasterByCondServiceResult();

            commonCodeMasterCondition condition = new commonCodeMasterCondition();
            condition.esqId = esqId;
            condition.kyCdKnd = kyCdKnd;
            condition.kijyunYmd = kijyunYmd;
            //サービスの呼び出し 
            commonCodeMasterResult result = _adapter.findCommonCodeMasterByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindCommonCodeMasterByCondParseResult parseResult = CommonParser.ParseForFindCommonCodeMasterByCond(result);
            _dsMaster = parseResult.CommonDataSet;

            // サービス結果の生成 
            serviceResult.CommonDataSet = parseResult.CommonDataSet;

            return serviceResult;
        }

        /// <summary>
        /// システム管理マスタ(TKJ99KNR)より営業日を取得する 
        /// </summary>
        /// <param name="esqId"></param>
        /// <returns></returns>
        public string GetEigyoBi(String esqId)
        {
            //サービス結果 
            string eigyoBi = "";

            eigyoBiCondition condition = new eigyoBiCondition();
            condition.esqId = esqId;
            //サービスの呼び出し 
            eigyoBiResult result = _adapter.getEigyoBi(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                //// サービスの呼び出しエラー 
                //serviceResult.MessageCode = info.errorCode;
                //serviceResult.Note = info.note;

                return eigyoBi;
            }

            // サービス結果の生成 
            eigyoBi = result.eigyoBi;

            return eigyoBi;
        }

        /// <summary>
        /// 業務会計稼働状況チェック 
        /// </summary>
        /// <param name="esqId"></param>
        /// <returns></returns>
        public accountOperationStatusResult CheckAccountOperationStatus(String esqId)
        {
            accountOperationStatusCondition condition = new accountOperationStatusCondition();
            condition.esqId = esqId;
            //サービスの呼び出し 
            return _adapter.checkAccountOperationStatus(condition);
        }

        #endregion メソッド
    }
}
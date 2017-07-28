using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance.Parser;
using Isid.NJ.ProcessController;
using Isid.KKH.Mac.ProcessController.MasterMaintenance.Converter;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Mac.ProcessController.MasterMaintenance.Parser;


namespace Isid.KKH.Mac.ProcessController.MasterMaintenance
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
    ///       <description>2012/01/04</description>
    ///       <description>IP Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class MasterMaintenanceMacProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static MasterMaintenanceMacProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private masterMacServiceAdapter _adapter;

        ///// <summary>
        ///// データセット
        ///// </summary>
        //private static Isid.KKH.Common.KKHSchema.MasterMaintenance _dsMaster;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。

        /// </summary>
        private MasterMaintenanceMacProcessController()
        {
            _adapter = CreateAdapter<masterMacServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。

        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static MasterMaintenanceMacProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new MasterMaintenanceMacProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <returns></returns>
        public RegisterMacMasterServiceResult RegisterMasterResult(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo, String TksTntSeqNo, String MasterKey, String FilterValue,  Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DataVO, DateTime maxupdate)
          {

            //サービス結果 
            RegisterMacMasterServiceResult serviceResult = new RegisterMacMasterServiceResult();

            masterMacRegisterVO register = new masterMacRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.masterData = MacMasterDataSetConverter.ConvertForMacMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            masterMacRegisterResult result = _adapter.registerMacMaster(register);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }


            return serviceResult;
            
        }


        // 2012/02/01 add start H.Okazaki
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <returns></returns>
        public String[] FindUpdMstKeyTenpoRirekiResult(String EsqId, String Egcd, String TksKgyCd, String TksBmnSeqNo, String TksTntSeqNo)
        {
            // サービス結果
            String[] serviceResult = new String[0];

            findMasterMacTnpRByCondCondition condition = new findMasterMacTnpRByCondCondition();
            condition.esqId = EsqId;
            condition.egCd = Egcd;
            condition.tksKgyCd = TksKgyCd;
            condition.tksBmnSeqNo = TksBmnSeqNo;
            condition.tksTntSeqNo = TksTntSeqNo;

            // サービスの呼び出し
            findMasterMacTnpRKeyByCondResult result = _adapter.findMacMasterTnpRKey(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                //serviceResult.MessageCode = info.errorCode;
                //serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            String[] parseResult = MasterMaintenanceParser.ParseForFindUpdMstKeyByCond(result);

            // サービス結果の生成
            serviceResult = parseResult;

            return serviceResult;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <returns></returns>
        public FindMasterTenpoRirekiByCondServiceResult FindMasterTenpoRirekiResult(String EsqId, String Egcd, String TksKgyCd, String TksBmnSeqNo, String TksTntSeqNo, String TenpoCd, String UpdRrkTimstmp, String RrkSybt, String TorikomiFlg)
        {
            // サービス結果
            FindMasterTenpoRirekiByCondServiceResult serviceResult = new FindMasterTenpoRirekiByCondServiceResult();

            findMasterMacTnpRByCondCondition condition = new findMasterMacTnpRByCondCondition();
            condition.esqId = EsqId;
            condition.egCd = Egcd;
            condition.tksKgyCd = TksKgyCd;
            condition.tksBmnSeqNo = TksBmnSeqNo;
            condition.tksTntSeqNo = TksTntSeqNo;
            condition.tenpoCd = TenpoCd;
            condition.updRrkTimstmp = UpdRrkTimstmp;
            condition.rrkSybt = RrkSybt;
            condition.torikomiFlg = TorikomiFlg;

            // サービスの呼び出し
            findMasterMacTnpRByCondResult result = _adapter.findMacMasterTnpR(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                //serviceResult.MessageCode = info.errorCode;
                //serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindMasterTenpoRirekiByCondServiceResult parseResult = MasterMaintenanceParser.ParseForFindMasterByCond(result);

            // サービス結果の生成
            serviceResult.TenpoRrkMasterDataSet = parseResult.TenpoRrkMasterDataSet;

            return serviceResult;

        }
        // 2012/02/01 add end H.Okazaki


        #endregion メソッド
    }
}
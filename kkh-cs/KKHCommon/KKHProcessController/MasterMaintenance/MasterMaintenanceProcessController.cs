using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance.Parser;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance.Converter;
using Isid.KKH.Common.KKHSchema;


namespace Isid.KKH.Common.KKHProcessController.MasterMaintenance
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
    public class MasterMaintenanceProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ 
        /// </summary>
        private static MasterMaintenanceProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター 
        /// </summary>
        private masterServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.MasterMaintenance _dsMaster;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private MasterMaintenanceProcessController()
        {
            _adapter = CreateAdapter<masterServiceAdapter>();
        }

        #endregion コンストラクタ

        #region 構造体
        /// <summary>
        /// 
        /// </summary>
        public struct FindMastItemVOParam
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 種別
            /// </summary>
            public String Sybt;
            /// <summary>
            /// フィルターバリュー
            /// </summary>
            public String filterValue;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct RegisterKindItemMasterResultParam
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// アプリID
            /// </summary>
            public String AplId;
            /// <summary>
            /// 営業所（取）コード  
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード  
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 種別 
            /// </summary>
            public String Sybt;
            /// <summary>
            /// フィルターバリュー 
            /// </summary>
            public String filterValue;
            /// <summary>
            /// マスターキー 
            /// </summary>
            public String masterkey;
            /// <summary>
            /// マスターデータVO
            /// </summary>
            public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterdatavo;
            /// <summary>
            /// 最大更新日時 
            /// </summary>
            public DateTime maxupdate;
        }


        #endregion 構造体

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static MasterMaintenanceProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new MasterMaintenanceProcessController();
            }
            return _processController;
        }

      

        /// <summary>
        /// マスタデータ検索 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <param name="masterKey"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        public FindMasterMaintenanceByCondServiceResult FindMasterByCond(String esqId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo, String masterKey, String filterValue)
        {      
            //サービス結果  
            FindMasterMaintenanceByCondServiceResult serviceResult = new FindMasterMaintenanceByCondServiceResult();
            
            masterCondition condition = new masterCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = tksBmnSeqNo;
            condition.tksTntSeqNo = tksTntSeqNo;
            condition.masterKey = masterKey;
            //condition.filterKey = filterKey;
            condition.filterValue = filterValue;

            //サービスの呼び出し 
            masterResult result = _adapter.findMasterByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindMasterByCondParseResult parseResult = MasterMaintenanceParser.ParseForFindMasterByCond(result);
            _dsMaster = parseResult.MasterDataSet;

            // サービス結果の生成 
            serviceResult.MasterDataSet = parseResult.MasterDataSet;

            return serviceResult;
        }

        /// <summary>
        /// マスタ定義検索 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <returns></returns>
        public FindMasterMaintenanceByCondServiceResult FindMasterDefineByCond(String esqId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo)
        {
            //サービス結果 
            FindMasterMaintenanceByCondServiceResult serviceResult = new FindMasterMaintenanceByCondServiceResult();

            masterCondition condition = new masterCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = tksBmnSeqNo;
            condition.tksTntSeqNo = tksTntSeqNo;

            //サービスの呼び出し 
            masterResult result = _adapter.findMasterDefineByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindMasterByCondParseResult parseResult = MasterMaintenanceParser.ParseForFindMasterDefineByCond(result);
            _dsMaster = parseResult.MasterDataSet;

            // サービス結果の生成 
            serviceResult.MasterDataSet = parseResult.MasterDataSet;

            return serviceResult;
        }


        /// <summary>
        /// 更新 
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
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public RegisterMasterServiceResult RegisterMasterResult(
            String EsqId, 
            String AplId, 
            String Egcd, 
            String TksKgyCd, 
            String TksBmnSeqNo, 
            String TksTntSeqNo, 
            String MasterKey, 
            String FilterValue,  
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DataVO, 
            DateTime maxupdate)
          {

            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            masterRegisterVO register = new masterRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.masterData = MasterDataSetConverter.ConvertForMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            masterRegisterResult result = _adapter.registerMaster(register);

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

        /// <summary>
        /// マスタItem絞り込み 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindMasterMaintenanceByCondServiceResult FindMastItemVO(FindMastItemVOParam param)
        {
            FindMasterMaintenanceByCondServiceResult serviceResult = new FindMasterMaintenanceByCondServiceResult();
            masterCondition cond = new masterCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.sybt = param.Sybt;
            cond._Itemfiltervalue = param.filterValue;

            //masterItemResult result = _adapter.findMasterItemByCond(cond);
            masterResult result = _adapter.findMasterDefineByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            //FindMasterByCondParseResult parseResult = MasterMaintenanceParser.ParseForFindMasterItemByCond(result);
            FindMasterByCondParseResult parseResult = MasterMaintenanceParser.ParseForFindMasterDefineByCond(result);
            _dsMaster = parseResult.MasterDataSet;

            // サービス結果の生成 
            serviceResult.MasterDataSet = parseResult.MasterDataSet;

            return serviceResult;
            
        }



        /// <summary>
        /// KindItem用更新 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RegisterMasterServiceResult RegisterKindItemMasterResult(RegisterKindItemMasterResultParam param)
        {

            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            masterRegisterVO register = new masterRegisterVO();
            register.esqId = param.esqId;
            register.aplId = param.AplId;
            register.egCd = param.egCd;
            register.tksKgyCd = param.tksKgyCd;
            register.tksBmnSeqNo = param.tksBmnSeqNo;
            register.tksTntSeqNo = param.tksTntSeqNo;
            register.masterKey = param.masterkey;
            register.filterValue = param.filterValue;
            register.masterData = MasterDataSetConverter.ConvertForMasterInsert(param.masterdatavo);
            register._maxupdate = param.maxupdate;
            register._sybt = param.Sybt;

            //サービスの呼び出し 
            masterRegisterResult result = _adapter.registerMaster(register);

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

        /// <summary>
        /// 複数更新 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey1"></param>
        /// <param name="MasterKey2"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO1"></param>
        /// <param name="DataVO2"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public RegisterMasterServiceResult RegisterMasterTablesResult(
            String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo, String TksTntSeqNo, String MasterKey1, String MasterKey2, String FilterValue, 
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DataVO1, 
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DataVO2,
            DateTime maxupdate)
        {

            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            masterRegisterVO register1 = new masterRegisterVO();
            register1.esqId = EsqId;
            register1.aplId = AplId;
            register1.egCd = Egcd;
            register1.tksKgyCd = TksKgyCd;
            register1.tksBmnSeqNo = TksBmnSeqNo;
            register1.tksTntSeqNo = TksTntSeqNo;
            register1.masterKey = MasterKey1;
            register1.filterValue = FilterValue;
            register1.masterData = MasterDataSetConverter.ConvertForMasterInsert(DataVO1);
            register1._maxupdate = maxupdate;

            masterRegisterVO register2 = new masterRegisterVO();
            register2.esqId = EsqId;
            register2.aplId = AplId;
            register2.egCd = Egcd;
            register2.tksKgyCd = TksKgyCd;
            register2.tksBmnSeqNo = TksBmnSeqNo;
            register2.tksTntSeqNo = TksTntSeqNo;
            register2.masterKey = MasterKey2;
            register2.filterValue = FilterValue;
            register2.masterData = MasterDataSetConverter.ConvertForMasterInsert(DataVO2);
            register2._maxupdate = maxupdate;

            //サービスの呼び出し 
            masterRegisterResult result = _adapter.registerMasterTables(register1, register2);

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


        #endregion メソッド
    }
}
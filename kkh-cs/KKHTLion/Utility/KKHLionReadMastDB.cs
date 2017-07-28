using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class KKHLionReadMastDB
    {
        //***************************************************
        //検索データ保持用Hashtable 
        //　再利用する汎用マスタのデータを保持 
        //***************************************************
        private Hashtable htMasterData = new Hashtable();

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public KKHLionReadMastDB()
        {
        }
        #endregion コンストラクタ

        #region 汎用マスタ

        /// <summary>
        /// 汎用マスタの検索を行う 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <param name="masterKey"></param>
        /// <returns></returns>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string esqId
                                                                                                , string egCd
                                                                                                , string tksKgyCd
                                                                                                , string tksBmnSeqNo
                                                                                                , string tksTntSeqNo
                                                                                                , string masterKey)
        {
            return FindMasterData(esqId, egCd, tksKgyCd, tksBmnSeqNo, tksTntSeqNo, masterKey, true);
        }

        /// <summary>
        /// 汎用マスタの検索を行う 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <param name="masterKey"></param>
        /// <param name="reLoadFlag"></param>
        /// <returns></returns>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string esqId
                                                                                                , string egCd
                                                                                                , string tksKgyCd
                                                                                                , string tksBmnSeqNo
                                                                                                , string tksTntSeqNo
                                                                                                , string masterKey
                                                                                                , bool reLoadFlag)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;

            if (reLoadFlag == true || htMasterData[masterKey] == null)
            {

                MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(esqId
                                                                                                    , egCd
                                                                                                    , tksKgyCd
                                                                                                    , tksBmnSeqNo
                                                                                                    , tksTntSeqNo
                                                                                                    , masterKey
                                                                                                    , ""
                                                                                                );
                rv = result.MasterDataSet.MasterDataVO;
                
                //参照渡しによる想定外のデータ変更を防止------------------------------------------------------------------------------------------------------------------ 
                //htMasterData[masterKey] = rv;
                htMasterData[masterKey] = rv.Copy();
                //--------------------------------------------------------------------------------------------------------------------------------------------------------
            }
            else
            {
                //参照渡しによる想定外のデータ変更を防止------------------------------------------------------------------------------------------------------------------ 
                //rv = ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey]);
                rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey]).Copy();
                //--------------------------------------------------------------------------------------------------------------------------------------------------------
            }

            return rv;
        }
        #endregion 汎用マスタ
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using MasterDataSet = Isid.KKH.Common.KKHSchema.MasterMaintenance;
using System.Collections;
using System.Data;

namespace Isid.KKH.Ash.Utility
{
    /// <summary>
    /// 得意先媒体コード－内部媒体コードの変換処理クラス.
    /// </summary>
    public class AshBaitaiUtility
    {
        #region メンバ変数.
        private String _esqId = "";
        private String _egCd = "";
        private String _tksKgyCd = "";
        private String _tksBmnSeqNo = "";
        private String _tksTntSeqNo = "";

        //マスタデータ 
        private Hashtable htMasterData = new Hashtable();
        private Dictionary<String, BaitaiResult> oldCdToNewBaitaiDict = null;
        private Dictionary<String, BaitaiResult> newCdToOldBaitaiDict = null;
        private Dictionary<String, String> nmToCdDict = null;
        private List<BaitaiResult> baitaiList = new List<BaitaiResult>();
        private List<BaitaiOrderResult> baitaiOrderList = new List<BaitaiOrderResult>();
        #endregion

        #region 構造体.
        /// <summary>
        /// 媒体コードの変換結果.
        /// </summary>
        public struct BaitaiResult
        {
            /// <summary>
            /// 変換後媒体コード.
            /// </summary>
            public String baitaiCd;
            /// <summary>
            /// 変換後媒体名称.
            /// </summary>
            public String baitaiNm;

        }

        /// <summary>
        /// 媒体コードの表示順結果.
        /// </summary>
        public struct BaitaiOrderResult
        {
            /// <summary>
            /// 変換後媒体コード.
            /// </summary>
            public String baitaiCord;
            /// <summary>
            /// 媒体コード表示順.
            /// </summary>
            public double baitaiOrder;

        }

        #endregion

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        public AshBaitaiUtility(String esqId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo)
        {
            _esqId = esqId;
            _egCd = egCd;
            _tksKgyCd = tksKgyCd;
            _tksBmnSeqNo = tksBmnSeqNo;
            _tksTntSeqNo = tksTntSeqNo;

            //データの初期化.
            //DBを検索して3つのディクショナリーと新のリストを初期化する
            //要はDictを作成する

            MasterDataSet.MasterDataVODataTable dtTBHenkan = FindMasterData(KkhConstAsh.MasterKey.TOKUI_BAITAI_HENNKAN);
            MasterDataSet.MasterDataVODataTable dtBaitai = FindMasterData(KkhConstAsh.MasterKey.BAITAI);
            BaitaiResult result = new BaitaiResult();
            BaitaiOrderResult res = new BaitaiOrderResult();

            //Dictionary KEY:旧コード VALUE:新媒体情報.
            oldCdToNewBaitaiDict = new Dictionary<String, BaitaiResult>();
            foreach (MasterDataSet.MasterDataVORow henkanRow in dtTBHenkan.Rows)
            {
                if (!oldCdToNewBaitaiDict.ContainsKey(henkanRow.Column2))
                {
                    result.baitaiCd = henkanRow.Column1;

                    foreach (MasterDataSet.MasterDataVORow baitaiRow in dtBaitai.Rows)
                    {
                        if (henkanRow.Column2 == baitaiRow.Column1)
                        {
                            result.baitaiNm = baitaiRow.Column2;
                            break;
                        }
                    }

                    oldCdToNewBaitaiDict.Add(henkanRow.Column2, result);
                }

            }
 
            //Dictionary KEY:新コード VALUE:旧媒体情報.
            newCdToOldBaitaiDict = new Dictionary<String, BaitaiResult>();
            foreach (MasterDataSet.MasterDataVORow henkanRow in dtTBHenkan.Rows)
            {
                if (!newCdToOldBaitaiDict.ContainsKey(henkanRow.Column1))
                {
                    result.baitaiCd = henkanRow.Column2;

                    foreach (MasterDataSet.MasterDataVORow baitaiRow in dtBaitai.Rows)
                    {
                        if (henkanRow.Column2 == baitaiRow.Column1)
                        {
                            result.baitaiNm = baitaiRow.Column2;
                            break;
                        }
                    }

                    newCdToOldBaitaiDict.Add(henkanRow.Column1, result);
                }

            }

            //Dictionary KEY:名称 VALUE:コード.
            nmToCdDict = new Dictionary<string, string>();
            foreach (MasterDataSet.MasterDataVORow row in dtBaitai.Rows)
            {
                if (!nmToCdDict.ContainsKey(row.Column2))
                {
                    nmToCdDict.Add(row.Column2, row.Column1);
                }

            }

            //List:媒体コード、媒体名称.
            baitaiList = new List<BaitaiResult>();
            foreach (MasterDataSet.MasterDataVORow baitaiRow in dtBaitai.Rows)
            {
                result.baitaiCd = baitaiRow.Column1;
                result.baitaiNm = baitaiRow.Column2;

                baitaiList.Add(result);            
            }

            //List:媒体コード、表示順.
            baitaiOrderList = new List<BaitaiOrderResult>();
            foreach (MasterDataSet.MasterDataVORow baitaiRow in dtTBHenkan.Rows)
            {
                res.baitaiCord = baitaiRow.Column1;
                res.baitaiOrder = double.Parse(baitaiRow.Column3);

                baitaiOrderList.Add(res);
            }


        }
        #endregion

        #region メソッド.

        /// <summary>
        /// 旧媒体コードから新媒体コード、媒体名称を取得する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        public BaitaiResult ConvertOldCdToNewCd(String baitaiCd)
        {
            BaitaiResult result = new BaitaiResult();
            if (oldCdToNewBaitaiDict.ContainsKey(baitaiCd))
            {
                result = oldCdToNewBaitaiDict[baitaiCd];
            }
            //見つからない場合はエラーを返却
            else
            {
                result.baitaiCd = baitaiCd;
                result.baitaiNm = "";
            }

            return result;
        }

        /// <summary>
        /// 新媒体コードから旧媒体コード、媒体名称を取得する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        public BaitaiResult ConvertNewCdToOldCd(String baitaiCd)
        {
            BaitaiResult result = new BaitaiResult();
            if (newCdToOldBaitaiDict.ContainsKey(baitaiCd))
            {
                result = newCdToOldBaitaiDict[baitaiCd];
            }
            //見つからない場合はエラーを返却
            else
            {
                result.baitaiCd = baitaiCd;
                result.baitaiNm = "";
            }

            return result;
        }

        /// <summary>
        /// 媒体名称から媒体コードを取得する.
        /// </summary>
        /// <param name="baitaiNm"></param>
        /// <returns></returns>
        public BaitaiResult SearchNmToCd(String baitaiNm)
        {
            BaitaiResult result = new BaitaiResult();
            if (nmToCdDict.ContainsKey(baitaiNm))
            {
                result.baitaiCd = nmToCdDict[baitaiNm];
            }
            //見つからない場合はエラーを返却
            else
            {
                result.baitaiCd = "";
                result.baitaiNm = baitaiNm;
            }

            return result;
        }

        /// <summary>
        /// 媒体コード、媒体名称のリストを返却
        /// </summary>
        /// <returns></returns>
        public List<BaitaiResult> GetNewBaitaiList()
        {
            List<BaitaiResult> resultList = new List<BaitaiResult>();

            resultList = baitaiList;

            return resultList;
        }

        /// <summary>
        /// 媒体コード、表示順のリストを返却
        /// </summary>
        /// <returns></returns>
        public List<BaitaiOrderResult> GetBaitaiOrderList()
        {
            List<BaitaiOrderResult> resultList = new List<BaitaiOrderResult>();

            resultList = baitaiOrderList;

            return resultList;
        }

        /// <summary>
        /// 汎用マスタの検索を行う.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <returns></returns>
        private MasterDataSet.MasterDataVODataTable FindMasterData(string masterKey)
        {
            return FindMasterData(masterKey, false);
        }

        /// <summary>
        /// 汎用マスタの検索を行う.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <param name="reFlag">True:常にDB検索を行う、False:検索済みのマスタは保持しているデータを使用する</param>
        /// <returns></returns>
        private MasterDataSet.MasterDataVODataTable FindMasterData(string masterKey, bool reFlag)
        {
            MasterDataSet.MasterDataVODataTable rv;

            if (htMasterData[masterKey] == null || reFlag == true)
            {

                MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                        _esqId
                                                                        , _egCd
                                                                        , _tksKgyCd
                                                                        , _tksBmnSeqNo
                                                                        , _tksTntSeqNo
                                                                        , masterKey
                                                                        , ""
                                                                    );
                rv = result.MasterDataSet.MasterDataVO;
                htMasterData[masterKey] = result.MasterDataSet.MasterDataVO;
            }
            else
            {
                rv = (MasterDataSet.MasterDataVODataTable)htMasterData[masterKey];
            }

            return rv;
        }
        #endregion
    }
}

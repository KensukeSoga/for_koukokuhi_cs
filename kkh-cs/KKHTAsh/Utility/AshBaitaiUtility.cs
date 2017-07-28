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
    /// ���Ӑ�}�̃R�[�h�|�����}�̃R�[�h�̕ϊ������N���X.
    /// </summary>
    public class AshBaitaiUtility
    {
        #region �����o�ϐ�.
        private String _esqId = "";
        private String _egCd = "";
        private String _tksKgyCd = "";
        private String _tksBmnSeqNo = "";
        private String _tksTntSeqNo = "";

        //�}�X�^�f�[�^ 
        private Hashtable htMasterData = new Hashtable();
        private Dictionary<String, BaitaiResult> oldCdToNewBaitaiDict = null;
        private Dictionary<String, BaitaiResult> newCdToOldBaitaiDict = null;
        private Dictionary<String, String> nmToCdDict = null;
        private List<BaitaiResult> baitaiList = new List<BaitaiResult>();
        private List<BaitaiOrderResult> baitaiOrderList = new List<BaitaiOrderResult>();
        #endregion

        #region �\����.
        /// <summary>
        /// �}�̃R�[�h�̕ϊ�����.
        /// </summary>
        public struct BaitaiResult
        {
            /// <summary>
            /// �ϊ���}�̃R�[�h.
            /// </summary>
            public String baitaiCd;
            /// <summary>
            /// �ϊ���}�̖���.
            /// </summary>
            public String baitaiNm;

        }

        /// <summary>
        /// �}�̃R�[�h�̕\��������.
        /// </summary>
        public struct BaitaiOrderResult
        {
            /// <summary>
            /// �ϊ���}�̃R�[�h.
            /// </summary>
            public String baitaiCord;
            /// <summary>
            /// �}�̃R�[�h�\����.
            /// </summary>
            public double baitaiOrder;

        }

        #endregion

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
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

            //�f�[�^�̏�����.
            //DB����������3�̃f�B�N�V���i���[�ƐV�̃��X�g������������
            //�v��Dict���쐬����

            MasterDataSet.MasterDataVODataTable dtTBHenkan = FindMasterData(KkhConstAsh.MasterKey.TOKUI_BAITAI_HENNKAN);
            MasterDataSet.MasterDataVODataTable dtBaitai = FindMasterData(KkhConstAsh.MasterKey.BAITAI);
            BaitaiResult result = new BaitaiResult();
            BaitaiOrderResult res = new BaitaiOrderResult();

            //Dictionary KEY:���R�[�h VALUE:�V�}�̏��.
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
 
            //Dictionary KEY:�V�R�[�h VALUE:���}�̏��.
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

            //Dictionary KEY:���� VALUE:�R�[�h.
            nmToCdDict = new Dictionary<string, string>();
            foreach (MasterDataSet.MasterDataVORow row in dtBaitai.Rows)
            {
                if (!nmToCdDict.ContainsKey(row.Column2))
                {
                    nmToCdDict.Add(row.Column2, row.Column1);
                }

            }

            //List:�}�̃R�[�h�A�}�̖���.
            baitaiList = new List<BaitaiResult>();
            foreach (MasterDataSet.MasterDataVORow baitaiRow in dtBaitai.Rows)
            {
                result.baitaiCd = baitaiRow.Column1;
                result.baitaiNm = baitaiRow.Column2;

                baitaiList.Add(result);            
            }

            //List:�}�̃R�[�h�A�\����.
            baitaiOrderList = new List<BaitaiOrderResult>();
            foreach (MasterDataSet.MasterDataVORow baitaiRow in dtTBHenkan.Rows)
            {
                res.baitaiCord = baitaiRow.Column1;
                res.baitaiOrder = double.Parse(baitaiRow.Column3);

                baitaiOrderList.Add(res);
            }


        }
        #endregion

        #region ���\�b�h.

        /// <summary>
        /// ���}�̃R�[�h����V�}�̃R�[�h�A�}�̖��̂��擾����.
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
            //������Ȃ��ꍇ�̓G���[��ԋp
            else
            {
                result.baitaiCd = baitaiCd;
                result.baitaiNm = "";
            }

            return result;
        }

        /// <summary>
        /// �V�}�̃R�[�h���狌�}�̃R�[�h�A�}�̖��̂��擾����.
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
            //������Ȃ��ꍇ�̓G���[��ԋp
            else
            {
                result.baitaiCd = baitaiCd;
                result.baitaiNm = "";
            }

            return result;
        }

        /// <summary>
        /// �}�̖��̂���}�̃R�[�h���擾����.
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
            //������Ȃ��ꍇ�̓G���[��ԋp
            else
            {
                result.baitaiCd = "";
                result.baitaiNm = baitaiNm;
            }

            return result;
        }

        /// <summary>
        /// �}�̃R�[�h�A�}�̖��̂̃��X�g��ԋp
        /// </summary>
        /// <returns></returns>
        public List<BaitaiResult> GetNewBaitaiList()
        {
            List<BaitaiResult> resultList = new List<BaitaiResult>();

            resultList = baitaiList;

            return resultList;
        }

        /// <summary>
        /// �}�̃R�[�h�A�\�����̃��X�g��ԋp
        /// </summary>
        /// <returns></returns>
        public List<BaitaiOrderResult> GetBaitaiOrderList()
        {
            List<BaitaiOrderResult> resultList = new List<BaitaiOrderResult>();

            resultList = baitaiOrderList;

            return resultList;
        }

        /// <summary>
        /// �ėp�}�X�^�̌������s��.
        /// </summary>
        /// <param name="masterKey">�擾����}�X�^�̃}�X�^�L�[</param>
        /// <returns></returns>
        private MasterDataSet.MasterDataVODataTable FindMasterData(string masterKey)
        {
            return FindMasterData(masterKey, false);
        }

        /// <summary>
        /// �ėp�}�X�^�̌������s��.
        /// </summary>
        /// <param name="masterKey">�擾����}�X�^�̃}�X�^�L�[</param>
        /// <param name="reFlag">True:���DB�������s���AFalse:�����ς݂̃}�X�^�͕ێ����Ă���f�[�^���g�p����</param>
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

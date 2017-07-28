using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.KKHUtility;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.ProcessController.MasterMaintenance;
using Isid.KKH.Mac.ProcessController.MasterMaintenance.Parser;
using FarPoint.Win.Spread;

namespace Isid.KKH.Mac.View.Mast
{
    public partial class frmMastTnpRrk : KKHForm
    {

        #region "�萔"

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "TnpRrkS";

        /// <summary>
        /// �}�X�^�����e�i���X�Ăяo������ʖ��i�X�܃}�X�^�[(�P�ꌟ��)�j
        /// </summary>
        private const String MACMSTNAME_SINGLE = "�X�܃}�X�^�[(�P�ꌟ��)";

        /// <summary>
        /// �}�X�^�����e�i���X�Ăяo������ʖ��i�X�܃}�X�^�[(�ꗗ)�j
        /// </summary>
        private const String MACMSTNAME_ALL = "�X�܃}�X�^(�ꗗ)";

        #region �X�v���b�h���ڔԍ�

        /// <summary>
        /// �X�v���b�h���ڔԍ�:���f�Ώ�
        /// </summary>
        private const int cKTarget = 0;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�V���{�L�[
        /// </summary>
        private const int cKUpdRrkTimstmp = 1;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�V���
        /// </summary>
        private const int cKRrkSybt = 2;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�V��ʃR�[�h
        /// </summary>
        private const int cKRrkSybtCD = 3;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�V�^�C�v
        /// </summary>
        private const int cKTorikomiFlg = 4;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�V�^�C�v�R�[�h
        /// </summary>
        private const int cKTorikomiFlgCD = 5;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�܃R�[�h
        /// </summary>
        private const int cKTenpoCd = 6;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�ܖ�
        /// </summary>
        private const int cKTenpoNm = 7;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�e���g���[
        /// </summary>
        private const int cKTerritory = 8;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�e���g���[�R�[�h
        /// </summary>
        private const int cKTerritoryCD = 9;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�܋敪
        /// </summary>
        private const int cKTenpoKbn = 10;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�܋敪�R�[�h
        /// </summary>
        private const int cKTenpoKbnCD = 11;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:����ۖ�
        /// </summary>
        private const int cKKamoku = 12;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�֔ԍ�
        /// </summary>
        private const int cKYubinNo = 13;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�Z���P
        /// </summary>
        private const int cKAddress1 = 14;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�Z���Q
        /// </summary>
        private const int cKAddress2 = 15;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�d�b�ԍ�
        /// </summary>
        private const int cKTelNo = 16;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:���׍s�t���O
        /// </summary>
        private const int cKSplitFlg = 17;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:���׍s�t���O�R�[�h
        /// </summary>
        private const int cKSplitFlgCD = 18;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:���C�Z���V�[�Ж�
        /// </summary>
        private const int cKCompanyNm = 19;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:��\�Җ�
        /// </summary>
        private const int cKName = 20;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�����R�[�h
        /// </summary>
        private const int cKTorihikiCd = 21;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:�X�e�[�^�X
        /// </summary>
        private const int cKInStatus = 22;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:����G.OPEN�N����
        /// </summary>
        private const int cKSGOpen = 23;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:G.OPEN�N����
        /// </summary>
        private const int cKGOpen = 24;

        /// <summary>
        /// �X�v���b�h���ڔԍ�:G.CLOSE�N����
        /// </summary>
        private const int cKGClose = 25;

        #endregion �X�v���b�h���ڔԍ�

        #endregion "�萔"

        #region "�����o�ϐ�"
        /// <summary>
        /// �i�r�p�����[�^�[
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        // �������
        Hashtable htRrkType = new Hashtable();    // ������ʕ\���p�i1:�V�K�A2:�ύX�A3:�폜�j

        // �X�V�^�C�v
        Hashtable htUpdType = new Hashtable();    // �X�V�^�C�v�\���p�i1:�捞�A2:�P��X�V�A3:�ꗗ�X�V�j

        // �X�܋敪
        Hashtable htTenpoKbn = new Hashtable();   // �X�܋敪�\���p�i0:�n��{���A1:MC���c�X�A2:���C�Z���V�[�A3:���̑��j

        // �e���g���[
        Hashtable htTerritory = new Hashtable();  // �e���g���[�\���p�i1:�֓��A2:�֐��A3:�����A4:���̑��j

        // ���׍s�t���O
        Hashtable htSplitFlg = new Hashtable();   // ���׍s�t���O�\���p�i0:��������A1:�P��X�V�j


        #endregion "�����o�ϐ�"

        #region "�R���X�g���N�^"

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public frmMastTnpRrk()
        {
            InitializeComponent();
        }
        #endregion "�R���X�g���N�^"

        #region "�C�x���g"

        /// <summary>
        /// ��ʑJ�ڎ��ɔ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastTnpRrk_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastTnpRrk_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��  
            base.ShowLoadingDialog();

            // �c�Ɠ��ݒ� 
            tslDate.Text = _naviParam.strDate;

            // �S���Җ��ݒ� 
            tslName.Text = _naviParam.strName;

            // ������ʐݒ�
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD1, KKHMacConst.C_RRKTYPE_NM1);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD2, KKHMacConst.C_RRKTYPE_NM2);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD3, KKHMacConst.C_RRKTYPE_NM3);

            // �X�V�^�C�v�ݒ�
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD1, KKHMacConst.C_UPDTYPE_NM1);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD2, KKHMacConst.C_UPDTYPE_NM2);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD3, KKHMacConst.C_UPDTYPE_NM3);

            // �X�܋敪�ݒ�
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD1, KKHMacConst.C_TENPO_KBN_NM1);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD2, KKHMacConst.C_TENPO_KBN_NM2);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD3, KKHMacConst.C_TENPO_KBN_NM3);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD4, KKHMacConst.C_TENPO_KBN_NM4);

            // �e���g���[�ݒ�
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD1, KKHMacConst.C_TERRITORY_NM1);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD2, KKHMacConst.C_TERRITORY_NM2);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD3, KKHMacConst.C_TERRITORY_NM3);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD4, KKHMacConst.C_TERRITORY_NM4);

            // ���׍s�t���O�ݒ�
            htSplitFlg.Add(KKHMacConst.C_SPLIT_FLG_CD1, KKHMacConst.C_SPLIT_FLG_NM1);
            htSplitFlg.Add(KKHMacConst.C_SPLIT_FLG_CD2, KKHMacConst.C_SPLIT_FLG_NM2);

            //�\��
            DisplayView();

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

            //���[�f�B���O��\�� 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// ���f�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd_Click(object sender, EventArgs e)
        {
            String strUpdRrkTimstmp = String.Empty;
            int count = 0;
            // �p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            naviParam = _naviParam;

            //***************************************************************
            //�K�v�ȏ�����͂��Ă��Ȃ��ꍇ�͋�̃f�[�^�e�[�u����Ԃ�
            //***************************************************************
            MastDSMac.DisplayTenpoRrkDataTable dtTenpoRrk = new MastDSMac.DisplayTenpoRrkDataTable();

            for (int i = 0; i < medMain_Sheet1.RowCount; i++)
            {

                //��������̏ꍇ�Ԃ��Ȃ�
                if (medMain_Sheet1.Cells[i, cKTarget].Text.Equals("False") )
                {
                    continue;
                }

                if (count > 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0161, null, "�X�܃}�X�^�[�X�V����", MessageBoxButtons.OK);
                    return;
                }
                count++;

                MastDSMac.DisplayTenpoRrkRow addrow = dtTenpoRrk.NewDisplayTenpoRrkRow();

                addrow.check = medMain_Sheet1.Cells[i, cKTarget].Value.ToString();
                strUpdRrkTimstmp = medMain_Sheet1.Cells[i, cKUpdRrkTimstmp].Text.Replace("/", "");
                strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(":", "");
                strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(" ", "");
                addrow.updRrkTimstmp = strUpdRrkTimstmp;
                addrow.rrkSybt = medMain_Sheet1.Cells[i, cKRrkSybtCD].Text;
                addrow.torikomiFlg = medMain_Sheet1.Cells[i, cKTorikomiFlgCD].Text;
                addrow.tenpoCd = medMain_Sheet1.Cells[i, cKTenpoCd].Text;
                addrow.tenpoNm = medMain_Sheet1.Cells[i, cKTenpoNm].Text;
                addrow.territory = medMain_Sheet1.Cells[i, cKTerritoryCD].Text;
                addrow.tenpoKbn = medMain_Sheet1.Cells[i, cKTenpoKbnCD].Text;
                addrow.kamoku = medMain_Sheet1.Cells[i, cKKamoku].Text;
                addrow.yubinNo = medMain_Sheet1.Cells[i, cKYubinNo].Text;
                addrow.address1 = medMain_Sheet1.Cells[i, cKAddress1].Text;
                addrow.address2 = medMain_Sheet1.Cells[i, cKAddress2].Text;
                addrow.telNo = medMain_Sheet1.Cells[i, cKTelNo].Text;
                addrow.splitFlg = medMain_Sheet1.Cells[i, cKSplitFlgCD].Text;
                addrow.companyNm = medMain_Sheet1.Cells[i, cKCompanyNm].Text;
                addrow.name = medMain_Sheet1.Cells[i, cKName].Text;
                addrow.torihikiCd = medMain_Sheet1.Cells[i, cKTorihikiCd].Text;
                addrow.inStatus = medMain_Sheet1.Cells[i, cKInStatus].Text;
                addrow.sGOpen = medMain_Sheet1.Cells[i, cKSGOpen].Text;
                addrow.gOpen = medMain_Sheet1.Cells[i, cKGOpen].Text;
                addrow.gClose = medMain_Sheet1.Cells[i, cKGClose].Text;

                dtTenpoRrk.AddDisplayTenpoRrkRow(addrow);
            }

            if (count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0160, null, "�X�܃}�X�^�[�X�V����", MessageBoxButtons.OK);
                return;
            }

            // �I�������f�[�^���Z�b�g
            naviParam.DataTable1 = dtTenpoRrk;
            
            // �}�X�^�����e�i���X�̉�ʖ����Z�b�g
            naviParam.StrValue1 = MACMSTNAME_SINGLE;

            Navigator.Forward(this, "tofrmMastMac", naviParam);
        }

        /// <summary>
        /// �߂�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // �}�X�^�����e�i���X��ʂɑJ��
            // �p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            naviParam = _naviParam;

            if (!String.IsNullOrEmpty(naviParam.strFilterValue))
            {
                // �X�܈ꗗ��ʂɑJ��
                Navigator.Backward(this, null, naviParam, true);
            }
            else
            {
                // �}�X�^�����e�i���X�̉�ʖ����Z�b�g
                naviParam.StrValue1 = MACMSTNAME_SINGLE;

                Navigator.Forward(this, "tofrmMastMac", naviParam);
            }            
        }

        /// <summary>
        /// �w���v�{�^���N���b�N���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h 
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        #endregion "�C�x���g"

        #region "���\�b�h"

        /// <summary>
        /// �e�R���g���[���ҏW
        /// </summary>
        private void EditControl()
        {
            ////�N���̎擾
            //String hostDate = "";
            //hostDate = getHostDate();
            //if (hostDate != "")
            //{
            //    hostDate = hostDate.Trim().Replace("/", "");
            //    if (hostDate.Trim().Length >= 6)
            //    {
            //        txtYm.Value = hostDate.Substring(0, 6);
            //    }
            //    else
            //    {
            //        txtYm.Value = hostDate;
            //    }
            //    txtYm.cmbYM_SetDate();
            //}

            ////�X�e�[�^�X�̐ݒ�
            //txtYm.Value = hostDate.Substring(0, 6);

            //tslName.Text = _naviParam.strName;
            //tslDate.Text = _naviParam.strDate;
        }

        /// <summary>
        /// �f�[�^�\��
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            MastDSMac dsMac = new MastDSMac();

            // �X�܃}�X�^�[�擾�i�P��j
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult resultNow = processController.FindMasterByCond(_naviParam.strEsqId,
                                                                                                 _naviParam.strEgcd,
                                                                                                 _naviParam.strTksKgyCd,
                                                                                                 _naviParam.strTksBmnSeqNo,
                                                                                                 _naviParam.strTksTntSeqNo,
                                                                                                 KKHMacConst.C_MAST_TENPO_CD,
                                                                                                 _naviParam.StrValue1);

            // �Y���f�[�^�����݂���ꍇ
            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count != 0)
            {
                // �Y���f�[�^�擾
                MasterMaintenance.MasterDataVORow rowTenpoMaster = (MasterMaintenance.MasterDataVORow)resultNow.MasterDataSet.MasterDataVO.Rows[0];

                //�\���p�f�[�^Row
                MastDSMac.DisplayTenpoRrkRow addrowNow = dsMac.DisplayTenpoRrk.NewDisplayTenpoRrkRow();

                //�\���p�f�[�^Row������
                addrowNow = syokirowSet(addrowNow);

                //�`�F�b�N
                addrowNow.check = "0";

                //�X�V�����L�[
                addrowNow.updRrkTimstmp = String.Empty;

                //�X�V���
                addrowNow.rrkSybt = "����";
                addrowNow.rrkSybtCd = "";

                //�X�V�^�C�v
                addrowNow.torikomiFlg = String.Empty;
                addrowNow.torikomiFlgCd = String.Empty;

                //�X�܃R�[�h
                addrowNow.tenpoCd = _naviParam.StrValue1;

                //�X�ܖ�
                addrowNow.tenpoNm = rowTenpoMaster.Column2;

                //�e���g���[
                addrowNow.territory = htTerritory[rowTenpoMaster.Column3].ToString();
                addrowNow.territoryCd = rowTenpoMaster.Column3;

                //�X�܋敪
                addrowNow.tenpoKbn = htTenpoKbn[rowTenpoMaster.Column4].ToString();
                addrowNow.tenpoKbnCd = rowTenpoMaster.Column4;

                //����Ȗ�
                addrowNow.kamoku = rowTenpoMaster.Column5;

                //�X�֔ԍ�
                addrowNow.yubinNo = rowTenpoMaster.Column6;

                //�Z���P
                addrowNow.address1 = rowTenpoMaster.Column7;

                //�Z���Q
                addrowNow.address2 = rowTenpoMaster.Column8;

                //�d�b�ԍ�
                addrowNow.telNo = rowTenpoMaster.Column9;

                //���׍s�t���O
                addrowNow.splitFlg = htSplitFlg[rowTenpoMaster.Column10].ToString();
                addrowNow.splitFlgCd = rowTenpoMaster.Column10;

                //���C�Z���V�[�Ж�
                addrowNow.companyNm = rowTenpoMaster.Column11;

                //��\�Җ�
                addrowNow.name = rowTenpoMaster.Column12;

                //�����R�[�h
                addrowNow.torihikiCd = rowTenpoMaster.Column13;

                //�X�e�[�^�X
                addrowNow.inStatus = rowTenpoMaster.Column14;

                //����G.OPEN�N����
                addrowNow.sGOpen = rowTenpoMaster.Column15;

                //G.OPEN�N����
                addrowNow.gOpen = rowTenpoMaster.Column16;

                //G.CLOSE�N����
                addrowNow.gClose = rowTenpoMaster.Column17;

                //�ǉ�
                dsMac.DisplayTenpoRrk.AddDisplayTenpoRrkRow(addrowNow);

            }

            //����
            MasterMaintenanceMacProcessController processControllerMac = MasterMaintenanceMacProcessController.GetInstance();
            FindMasterTenpoRirekiByCondServiceResult result = processControllerMac.FindMasterTenpoRirekiResult(_naviParam.strEsqId,
                                                                                                            _naviParam.strEgcd,
                                                                                                            _naviParam.strTksKgyCd,
                                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                                            _naviParam.strTksTntSeqNo,
                                                                                                            _naviParam.StrValue1,
                                                                                                            "",
                                                                                                            "",
                                                                                                            "");


            //�G���[�̏ꍇ
            if (result.HasError)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }

            MastDSMac.TenpoRrkRow[] resultRow = (MastDSMac.TenpoRrkRow[])result.TenpoRrkMasterDataSet.TenpoRrk.Select("", "");

            foreach (MastDSMac.TenpoRrkRow row in resultRow)
            {
                //�\���p�f�[�^Row
                MastDSMac.DisplayTenpoRrkRow addrow = dsMac.DisplayTenpoRrk.NewDisplayTenpoRrkRow();

                //�\���p�f�[�^Row������
                addrow = syokirowSet(addrow);

                //�`�F�b�N
                addrow.check = "0";

                //�X�V�����L�[
                addrow.updRrkTimstmp = row.updRrkTimstmp.Insert(14," ").Insert(12,":").Insert(10,":").Insert(8," ").Insert(6,"/").Insert(4,"/"); 

                //�X�V���
                addrow.rrkSybt = htRrkType[row.rrkSybt].ToString();
                addrow.rrkSybtCd = row.rrkSybt;

                //�X�V�^�C�v
                addrow.torikomiFlg = htUpdType[row.torikomiFlg].ToString();
                addrow.torikomiFlgCd = row.torikomiFlg;

                //�X�܃R�[�h
                addrow.tenpoCd = row.tenpoCd;

                //�X�ܖ�
                addrow.tenpoNm = row.tenpoNm;

                //�e���g���[
                addrow.territory = htTerritory[row.territory].ToString();
                addrow.territoryCd = row.territory;

                //�X�܋敪
                addrow.tenpoKbn = htTenpoKbn[row.tenpoKbn].ToString();
                addrow.tenpoKbnCd = row.tenpoKbn;

                //����Ȗ�
                addrow.kamoku = row.kamoku;

                //�X�֔ԍ�
                addrow.yubinNo = row.yubinNo;

                //�Z���P
                addrow.address1 = row.address1;

                //�Z���Q
                addrow.address2 = row.address2;

                //�d�b�ԍ�
                addrow.telNo = row.telNo;

                //���׍s�t���O
                addrow.splitFlg = htSplitFlg[row.splitFlg].ToString();
                addrow.splitFlgCd = row.splitFlg;

                //���C�Z���V�[�Ж�
                addrow.companyNm = row.companyNm;

                //��\�Җ�
                addrow.name = row.name;

                //�����R�[�h
                addrow.torihikiCd = row.torihikiCd;

                //�X�e�[�^�X
                addrow.inStatus = row.inStatus;

                //����G.OPEN�N����
                addrow.sGOpen = row.sGOpen;

                //G.OPEN�N����
                addrow.gOpen = row.gOpen;

                //G.CLOSE�N����
                addrow.gClose = row.gClose;

                //�ǉ�
                dsMac.DisplayTenpoRrk.AddDisplayTenpoRrkRow(addrow);

            }

            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count == 0 &&
                result.TenpoRrkMasterDataSet.TenpoRrk.Rows.Count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "�X�܃}�X�^�[�X�V����", MessageBoxButtons.OK);
                btnUpd.Enabled = false;
                return;
            }

            //�X�v���b�h�f�[�^�\�[�X�֓����
            medMain_Sheet1.DataSource = dsMac.DisplayTenpoRrk;

            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count != 0)
            {
                //�X�V��ʂ�1�s����Ɉړ�
                for (int i = 0; i < dsMac.DisplayTenpoRrk.Rows.Count - 1; i++)
                {
                    medMain_Sheet1.Cells[i, cKTorikomiFlg].Value = medMain_Sheet1.Cells[i + 1, cKTorikomiFlg].Value;
                    medMain_Sheet1.Cells[i, cKTorikomiFlgCD].Value = medMain_Sheet1.Cells[i + 1, cKTorikomiFlgCD].Value;
                }
                medMain_Sheet1.Cells[dsMac.DisplayTenpoRrk.Rows.Count - 1, cKTorikomiFlg].Value = "";
                medMain_Sheet1.Cells[dsMac.DisplayTenpoRrk.Rows.Count - 1, cKTorikomiFlgCD].Value = "";
            }
          
            //�����̕\��
            lblKensu.Text = dsMac.DisplayTenpoRrk.Rows.Count.ToString() + "��";

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// �f�[�^Row�����Z�b�g
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private MastDSMac.DisplayTenpoRrkRow syokirowSet(MastDSMac.DisplayTenpoRrkRow addrow)
        {

            addrow.check = string.Empty;
            addrow.updRrkTimstmp  = string.Empty;
            addrow.rrkSybt = string.Empty;
            addrow.rrkSybtCd = string.Empty;
            addrow.torikomiFlg = string.Empty;
            addrow.torikomiFlgCd = string.Empty;
            addrow.tenpoCd = string.Empty;
            addrow.tenpoNm = string.Empty;
            addrow.territory = string.Empty;
            addrow.territoryCd = string.Empty;
            addrow.tenpoKbn = string.Empty;
            addrow.tenpoKbnCd = string.Empty;            
            addrow.kamoku = string.Empty;
            addrow.yubinNo = string.Empty;
            addrow.address1 = string.Empty;
            addrow.address2 = string.Empty;
            addrow.telNo = string.Empty;
            addrow.splitFlg = string.Empty;
            addrow.splitFlgCd = string.Empty;            
            addrow.companyNm = string.Empty;
            addrow.name = string.Empty;
            addrow.torihikiCd = string.Empty;
            addrow.inStatus = string.Empty;
            addrow.sGOpen = string.Empty;
            addrow.gOpen = string.Empty;
            addrow.gClose = string.Empty;

            return addrow;
        }

        #endregion  "���\�b�h"
    }
}

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
    public partial class frmMastTnpRrkAll : KKHForm
    {

        #region "�萔"

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "TnpRrkA";

        /// <summary>
        /// �}�X�^�����e�i���X�Ăяo������ʖ�
        /// </summary>
        private const String MACMSTNAME = "�X�܃}�X�^(�ꗗ)";

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
        Hashtable htRrkType = new Hashtable();    // �����^�C�v�\���p�i1:�V�K�A2:�ύX�A3:�폜�j

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
        public frmMastTnpRrkAll()
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
        private void frmMastTnpRrkAll_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        private void frmMastTnpRrkAll_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��  
            base.ShowLoadingDialog();

            // �c�Ɠ��ݒ� 
            tslDate.Text = _naviParam.strDate;

            // �S���Җ��ݒ� 
            tslName.Text = _naviParam.strName;

            //�R���g���[���ݒ�
            EditControl(); 
            
            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

            //���[�f�B���O��\�� 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// �����{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //��ʕ\��
            DisplayView();
        }

        /// <summary>
        /// �X�ܗ����{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTnpRrkS_Click(object sender, EventArgs e)
        {
            int count = 0;

            // �p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            for (int i = 0; i < medMain_Sheet1.RowCount; i++)
            {
                //��������̏ꍇ�Ԃ��Ȃ�
                if (medMain_Sheet1.Cells[i, cKTarget].Text == "False")
                {
                    continue;
                }

                if (count > 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0161, null, "�X�V�X�܈ꗗ����", MessageBoxButtons.OK);
                    return;
                }
                count++;

                naviParam = _naviParam;

                naviParam.StrValue1 = medMain_Sheet1.Cells[i, cKTenpoCd].Text;
                naviParam.strFilterValue = medMain_Sheet1.Cells[i, cKTenpoCd].Text; 
            }

            if (count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0160, null, "�X�V�X�܈ꗗ����", MessageBoxButtons.OK);
                return;
            }

            // �X�ܗ�����ʂɑJ�� 
            Navigator.Forward(this, "tofrmMastTnpRrk", naviParam);
        }

        /// <summary>
        /// �߂�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // �p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            naviParam = _naviParam;

            // �}�X�^�����e�i���X�̉�ʖ����Z�b�g
            naviParam.StrValue1 = MACMSTNAME;
 
            Navigator.Forward(this, "tofrmMastMac", naviParam);
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
            String strCmbItemKey = String.Empty;
            String strCmbItemType = String.Empty;

            // ������ʐݒ�
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD1, KKHMacConst.C_RRKTYPE_NM1);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD2, KKHMacConst.C_RRKTYPE_NM2);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD3, KKHMacConst.C_RRKTYPE_NM3);

            // �X�V�^�C�v�ݒ�
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD1, KKHMacConst.C_UPDTYPE_NM1);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD2, KKHMacConst.C_UPDTYPE_NM2);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD3, KKHMacConst.C_UPDTYPE_NM3);

            // �X�V���ԃR���{�{�b�N�X�ݒ�
            cmbUpdKey.Items.Clear();
            // ����
            MasterMaintenanceMacProcessController processController = MasterMaintenanceMacProcessController.GetInstance();
            string[] result = processController.FindUpdMstKeyTenpoRirekiResult(_naviParam.strEsqId,
                                                                               _naviParam.strEgcd,
                                                                               _naviParam.strTksKgyCd,
                                                                               _naviParam.strTksBmnSeqNo,
                                                                               _naviParam.strTksTntSeqNo
                                                                              );

            if (result.Length.Equals(0))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "�X�V�X�܈ꗗ����", MessageBoxButtons.OK);
                cmbUpdKey.Enabled = false;
                cmbRrkType.Enabled = false;
                btnSrc.Enabled = false;
                btnTnpRrkS.Enabled = false;

                return; 
            }

            for (int i = 0; i < result.Length; i++)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                strCmbItemKey = result[i].Substring(0, 17).Insert(14, " ").Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/");
                strCmbItemType = htUpdType[result[i].Substring(17, 1)].ToString();
                sb.Append(strCmbItemKey);
                sb.Append(" (");
                sb.Append(strCmbItemType);
                sb.Append(")");

                cmbUpdKey.Items.Add(sb.ToString());
            }

            cmbUpdKey.SelectedIndex = 0;

            // ������ʃR���{�{�b�N�X�ݒ�
            cmbRrkType.Items.Add("");
            cmbRrkType.Items.Add(KKHMacConst.C_RRKTYPE_NM1);
            cmbRrkType.Items.Add(KKHMacConst.C_RRKTYPE_NM2);
            cmbRrkType.Items.Add(KKHMacConst.C_RRKTYPE_NM3);
           
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
        }

        /// <summary>
        /// �f�[�^�\��
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            String strUpdRrkTimstmp = String.Empty;
            String strRrkType = String.Empty;

            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            strUpdRrkTimstmp = cmbUpdKey.Text.Replace("/", "");
            strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(":", "");
            strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(" ", "");
            strUpdRrkTimstmp = strUpdRrkTimstmp.Substring(0,17);

            if (!cmbRrkType.SelectedIndex.Equals(0) && !cmbRrkType.SelectedIndex.Equals(-1))
            {
                strRrkType = cmbRrkType.SelectedIndex.ToString();
            }

            //����
            MasterMaintenanceMacProcessController processController = MasterMaintenanceMacProcessController.GetInstance();
            FindMasterTenpoRirekiByCondServiceResult result = processController.FindMasterTenpoRirekiResult(_naviParam.strEsqId,
                                                                                                            _naviParam.strEgcd,
                                                                                                            _naviParam.strTksKgyCd,
                                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                                            _naviParam.strTksTntSeqNo,
                                                                                                            "",
                                                                                                            strUpdRrkTimstmp,
                                                                                                            strRrkType,
                                                                                                            "");


            //�G���[�̏ꍇ
            if (result.HasError)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }

            int count = 0;

            MastDSMac.TenpoRrkRow[] resultRow = (MastDSMac.TenpoRrkRow[])result.TenpoRrkMasterDataSet.TenpoRrk.Select("", "");

            MastDSMac dsMac = new MastDSMac();

            foreach (MastDSMac.TenpoRrkRow row in resultRow)
            {
                //�\���p�f�[�^Row
                MastDSMac.DisplayTenpoRrkRow addrow = dsMac.DisplayTenpoRrk.NewDisplayTenpoRrkRow();
                //�\���p�f�[�^Row������
                addrow = syokirowSet(addrow);

                //�`�F�b�N
                addrow.check = "0";

                //�X�V�����L�[
                addrow.updRrkTimstmp = row.updRrkTimstmp.Insert(14, " ").Insert(12, ":").Insert(10, ":").Insert(8, " ").Insert(6, "/").Insert(4, "/"); 

                //�X�V���
                addrow.rrkSybt = htRrkType[row.rrkSybt].ToString();

                //�X�V�^�C�v
                addrow.torikomiFlg = htUpdType[row.torikomiFlg].ToString();

                //�X�܃R�[�h
                addrow.tenpoCd = row.tenpoCd;

                //�X�ܖ�
                addrow.tenpoNm = row.tenpoNm;

                //�e���g���[
                addrow.territory = htTerritory[row.territory].ToString();

                //�X�܋敪
                addrow.tenpoKbn = htTenpoKbn[row.tenpoKbn].ToString();

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

                count++;
            }


            //�X�v���b�h�f�[�^�\�[�X�֓����
            medMain_Sheet1.DataSource = dsMac.DisplayTenpoRrk;

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
            addrow.updRrkTimstmp = string.Empty;
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

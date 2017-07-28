using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.KKH.Mac.KKHUtility;
using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.Schema;
using System.Collections;
namespace Isid.KKH.Mac.View.Mast
{
    /// <summary>
    /// �}�X�^�[�����e�i���X��ʁimac�j 
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ� 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/18</description>
    ///       <description>IP H.shimizu</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmMastMac : MastForm, INaviParameter
    {
        #region "�����o�萔"
                
        /// <summary>
        /// �A�v��ID 
        /// ���捞�����Ǝ蓮�X�V�����̔��f�Ŏg�p
        /// </summary>
        private const string C_APL_ID = "00";

        /// <summary>
        /// �A�v������ 
        /// </summary>
        private const string C_APL_NM = "�}�X�^�[�����e�i���X";
        
        /// <summary>
        /// �捞�Ώۃt�@�C�����i�f�t�H���g�j 
        /// </summary>
        private const string C_DEFAULT_FILE_NM = "�X�܃f�[�^.xls";

        //private const string C_DEFAULT_FILE_NM = "�X�܃f�[�^.xlsx";
        
        /// <summary>
        /// �捞�Ώۃt�@�C���t�B���^ 
        /// </summary>
        private const string C_FILE_FILTER = "Excel �u�b�N (*.xls)|*.xls|Excel �u�b�N (*.xlsx)|*.xlsx|Excel �u�b�N (*.xlsm)|*.xlsm|���ׂẴt�@�C��(*.*)|*.*";

        /// <summary>
        /// �_�C�A���O�^�C�g���i�t�@�C���捞�j 
        /// </summary>
        private const string C_INPUT_TITLE_NM = "�捞�Ώۂ�I�����Ă�������";

        /// <summary>
        /// �p�^�[���A�N�e�B�u�s
        /// </summary>
        private int activeRow = 0;

        /// <summary>
        /// �p�^�[���A�N�e�B�u��
        /// </summary>
        private int activeCol = 0;

        /// <summary>
        /// �p�^�[���ҏW���t���O(�ҏW��:True���ҏW:false)
        /// </summary>
        private bool PtnReNameFlg = false;

        /// <summary>
        /// �^�u�y�[�W���� 
        /// </summary>
        private KKHTabPageManager _tabPageManager = null;

        /// <summary>
        /// �X�܃p�^�[���}�X�^�[�ő�s��
        /// </summary>
        private const int C_MAXROW_TENPO_PATTERN_MASTER = 999;

        /// <summary>
        /// �t�B���^�[��ԍ�
        /// </summary>
        private const int C_FILTER_COLINDEX = 14;

        #endregion

        #region "�����o�ϐ�"

        /// <summary>
        /// �i�r�p�����[�^ 
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        /// <summary>
        /// �ҏW���X�܃}�X�^�[�s
        /// </summary>
        MasterMaintenance.MasterDataVORow rowTenpoMaster = null;

        /// <summary>
        /// �X�܃R�[�h�ύX���[�h
        /// </summary>
        private bool IsChangeCodeMode = false;

        /// <summary>
        /// �ύX�O�X�܃R�[�h 
        /// </summary>
        private string beforeTenpoCd = string.Empty;

        /// <summary>
        /// �ύX�O�폜�{�^���g�p��
        /// </summary>
        private bool beforeDeleteButtonEnabled = false;

        /// <summary>
        /// �X�܃}�X�^�[
        /// </summary>
        MasterMaintenance.MasterDataVODataTable TenpoMasterVODataTable = new MasterMaintenance.MasterDataVODataTable();

        /// <summary>
        /// �_�C�A���O�p�i�r�p�����[�^�̃C���X�^���X����
        /// </summary>
         MastNarrowDownNaviParameter DialogParameter = new MastNarrowDownNaviParameter();

        /// <summary>
        /// �ύX�O�X�܃p�^�[������
        /// </summary>
        private string beforeTenpoPatternName = string.Empty;

        /// <summary>
        /// ���������t���O  
        /// </summary>
        private bool initFlg = false;

        #endregion

        #region "�R���X�g���N�^"

        /// <summary>
        /// �����C�x���g 
        /// </summary>
        public frmMastMac()
        {
            InitializeComponent();
            tbcMasterMainte.Visible = false;
            Cursor.Current = Cursors.WaitCursor;
        }
        
        #endregion

        #region "�I�[�o�[���C�h"

        /// <summary>
        /// �X�v���b�h�ĕ`�� 
        /// </summary>
        protected override void reDisplay()
            {
                // �X�܃R�[�h��empty�� 
                txtTenpoCd.Text = string.Empty;

                // �t�B���^�[��null�� 
                mstNavPrm.strFilterValue = null;

                int selectItemValue = 0;
                if (Itemcmb.Visible == true)
                {
                    selectItemValue = Itemcmb.SelectedIndex;
                }

                // �e�t�H�[���̍ĕ`����Ăяo�� 
                base.reDisplay();

                if (Itemcmb.Visible == true)
                {
                    Itemcmb.SelectedIndex = selectItemValue;
                }

                MasterMaintenance.MasterKindVORow rw = null;
                int Count = 0;
                for (int i = 0; i < base.mstDtSet.MasterDataSet.MasterKindVO.Rows.Count; i++)
                {
                    if (base.mstDtSet.MasterDataSet.MasterKindVO[i].field1.Equals(KKHMacConst.C_MAST_TENPO_PTN_NM))
                    {
                        rw = base.mstDtSet.MasterDataSet.MasterKindVO[i];
                        Count++;
                    }
                }
                if (Count == 2)
                {
                    base.mstDtSet.MasterDataSet.MasterKindVO.RemoveMasterKindVORow(rw);
                }

                // �}�X�^�[��(�R���{�{�b�N�X)�Łu�X�܃p�^�[���}�X�^�[�v���I������Ă���ꍇ
                if (cmbMasterName1.Text == KKHMacConst.C_MAST_TENPO_PTN_NM && upchk == false)
                {
                    //���[�f�B���O�\���J�n 
                    base.ShowLoadingDialog();

                    // �X�܃p�^�[���}�X�^�[�����\��
                    this.InitTenpoPatternMaster();

                    //���[�f�B���O�\���I��   
                    base.CloseLoadingDialog();
                }
            }

        /// <summary>
        /// �}�X�^�[���R���{�{�b�N�X�Ƀ��j���[��ʂŉ������ꂽ�}�X�^�[�{�^�������Z�b�g 
        /// </summary>
        protected override void CombSetFromMenue()
        {
        }

        #endregion

        #region "�C�x���g"

        #region ��ʏ����\����

        /// <summary>
        /// ��ʏ����\��  
        /// </summary>
        private void frmMastMac_Shown(object sender, EventArgs e)
        {
            // �J�[�\���ݒ�
            Cursor.Current = Cursors.Default;

            // Tab�I�u�W�F�N�g��SizeMode��ݒ� 
            tbcMasterMainte.SizeMode = TabSizeMode.Fixed;

            // Tab�I�u�W�F�N�g��Size��ݒ� 
            tbcMasterMainte.ItemSize = new Size(290, 20);

            // ���͍��ڏ�����
            this.InitInputItemTenpoMaster_FirstTab(true);

            MasterMaintenance.MasterKindVORow rw = null;
            int Count = 0;
            for (int i = 0; i < base.mstDtSet.MasterDataSet.MasterKindVO.Rows.Count; i++)
            {
                // �u�X�܃p�^�[���}�X�^�[�v���J�E���g
                if (base.mstDtSet.MasterDataSet.MasterKindVO[i].field1.Equals(KKHMacConst.C_MAST_TENPO_PTN_NM))
                {
                    rw = base.mstDtSet.MasterDataSet.MasterKindVO[i];
                    Count++;
                }
            }

            // �u�X�܃p�^�[���}�X�^�[�v���d�����Ă���ꍇ�A�d���s���폜����B
            if (Count == 2)
            {
                base.mstDtSet.MasterDataSet.MasterKindVO.RemoveMasterKindVORow(rw);
            }


            //�}�X�^�[���R���{�{�b�N�X�Ƀ��j���[��ʂŉ������ꂽ�}�X�^�[�{�^�������Z�b�g 
            cmbMasterName1.Text = mstNavPrm.StrValue1;
            MastCmbClick();

            //���j���[��ʂŉ������ꂽ�}�X�^�[�{�^������[�}�X�^�[�X��(�P�ꌟ��)]�̏ꍇ 
            if (mstNavPrm.StrValue1 == "�X�܃}�X�^�[(�P�ꌟ��)")
            {
                // �X�܃}�X�^�[(�P�ꌟ��)�^�u��I��
                tbcMasterMainte.SelectedIndex = 0;

                SelectedTempMstSnglSrchTab();

            }
            else
            {
                // �X�܃}�X�^�[(�ꗗ)�^�u��I��
                tbcMasterMainte.SelectedIndex = 1;

                SelectedTempMstListTab();

                MastCmbClick();
                //mstCmbChange();
            }

            // �ϐ�������
            beforeTenpoCd = string.Empty;
            beforeDeleteButtonEnabled = false;
            IsChangeCodeMode = false;

            // Tab�I�u�W�F�N�g��\�� 
            tbcMasterMainte.Visible = true;

        }

        #endregion

        #region ��ʑJ�ڎ��C�x���g

        /// <summary>
        /// ��ʑJ�ڎ��C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            // TabPageManager�I�u�W�F�N�g�̑��݊m�F 
            if (_tabPageManager == null)
            {
                //Tab PageManager�I�u�W�F�N�g�̍쐬 
                _tabPageManager = new KKHTabPageManager(tbcMasterMainte);
            }

            // NaviParameter�̑��݊m�F 
            if (arg.NaviParameter == null)
            {
                // Spread�ĕ`�� 
                //this.reDisplay();
                return;
            }
            else
            {
                // NabiParameter�擾
                mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
                if (mstNavPrm.StrValue1 == "�X�܃}�X�^�[(�P�ꌟ��)")
                {
                    // �X�܃}�X�^�[(�P�ꌟ��)�^�u��I��
                    tbcMasterMainte.SelectedIndex = 0;
                    this.Show();
                    if (mstNavPrm.DataTable1 != null)
                    {
                        AfterSelectTenpoRrk(mstNavPrm.DataTable1);
                    }
                }
                else if(mstNavPrm.StrValue1 == "�X�܃}�X�^(�ꗗ)")
                {
                    // �X�܃}�X�^�[(�ꗗ)�^�u��I��
                    tbcMasterMainte.SelectedIndex = 1;
                    this.Show();
                }
            }
        }

        #endregion

        #region �I���^�u�ύX

        /// <summary>
        /// �I���^�u�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcMasterMainte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �^�u��2�\������Ă��Ȃ��ꍇ�A�����I��
            if (tbcMasterMainte.TabPages.Count != 2)
            {
                return;
            }

            // �X�܃}�X�^�[(�P�ꌟ��)�^�u�I�������ꍇ 
            if (tbcMasterMainte.SelectedIndex == 0)
            {
                SelectedTempMstSnglSrchTab();
            }
            // �X�܃}�X�^�[(�ꗗ�\��)�^�u�I�������ꍇ 
            else
            {
                SelectedTempMstListTab();
            }
        }

        #endregion 

        #region �X�܃R�[�h����

        /// <summary>
        /// �X�܃R�[�h����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenpoCd_TextChanged(object sender, EventArgs e)
        {
            // �X�܃R�[�h�X�V���[�h�̏ꍇ�A�����I��
            if (IsChangeCodeMode == true)
            {
                return;
            }

            if (txtTenpoCd.TextLength == txtTenpoCd.MaxLength)
            {
                mstNavPrm.strFilterValue = txtTenpoCd.Text;

                // �X�܃}�X�^�[�擾�i�P��j
                MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                     mstNavPrm.strEgcd,
                                                                                                     mstNavPrm.strTksKgyCd,
                                                                                                     mstNavPrm.strTksBmnSeqNo,
                                                                                                     mstNavPrm.strTksTntSeqNo,
                                                                                                     KKHMacConst.C_MAST_TENPO_CD,
                                                                                                     txtTenpoCd.Text);

                // �Y���f�[�^�����݂��Ȃ��ꍇ
                if (result.MasterDataSet.MasterDataVO.Rows.Count == 0)
                {
                    // ������\���ݒ�i�f�t�H���g�l�j
                    this.AfterSearchTenpoMaster();

                    return;
                }

                // �Y���f�[�^�擾
                rowTenpoMaster = (MasterMaintenance.MasterDataVORow)result.MasterDataSet.MasterDataVO.Rows[0];

                // ������\���ݒ�i�f�[�^����j
                this.AfterSearchTenpoMaster(rowTenpoMaster);
            }
            else
            {
                // �R�[�h�ϊ��{�^���g�p�s��
                btnChgCode.Enabled = false;

                // �폜�{�^���g�p�s��
                btnClr.Enabled = false;

                // ���͍��ڏ����� 
                this.InitInputItemTenpoMaster_FirstTab(false);
            }
        }

        #endregion

        #region �}�X�^�[���R���{�{�b�N�X�I���s�ύX
        
        /// <summary>
        /// �}�X�^�[���R���{�{�b�N�X�I���s�ύX 
        /// </summary>
        protected override void MastCmbClick()
        //private void mstCmbChange()
        {
            // �}�X�^�[���R���{�{�b�N�X�ɑI�����ڂ��ݒ肳��Ă��Ȃ��ꍇ�A�����I��
            if (cmbMasterName1.Items.Count == 0) { return; }

            // �}�X�^�[���R���{�{�b�N�X����I���s�̏�񂪑��݂��Ȃ��ꍇ
            if (cmbMasterName1.SelectedItem == null) { return; }

            //�}�X�^�[���R���{�{�b�N�X�̑I�����ڂ��擾���� 
            //beforeMsterNm = cmbMasterName1.Text;
            if (initFlg)
            {
                base.MastCmbClick();
            }
            else
            {
                initFlg = true;
            }

            if (upchk)
            {
                return;
            }

            // �}�X�^�[�R���{�{�b�N�X�őI�����ꂽ�����擾
            DataRowView dataRowViewMasterName = (DataRowView)cmbMasterName1.SelectedItem;
            MasterMaintenance.MasterKindVORow rowMasterNamse 
                = (MasterMaintenance.MasterKindVORow)dataRowViewMasterName.Row;

            // �I������Ă���}�X�^�[�����Ɉȍ~�̏������s��
            switch (rowMasterNamse.field1)
            {
                // �X�܃}�X�^�[ 
                case KKHMacConst.C_MAST_TENPO_NM:

                    // �{�^���ݒ�
                    this.SetButtonPropertyTenpoMaster_SecondTab();

                    // �X�܃p�^�[���}�X�^�[�p�O���[�v�{�b�N�X���\��
                    grbTenpoPtn.Visible = false;

                    // �X�܃}�X�^�[(�P�ꌟ��)�^�u��\��
                    _tabPageManager.ChangeTabPageVisible(0, true);

                    // �X�܃}�X�^�[(�ꗗ�\��)�^�u��I��
                    tbcMasterMainte.SelectedIndex = 1;

                    // �ꗗ�̕\���ݒ�
                    SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

                    break;

                // �X�܃p�^�[���}�X�^�[ 
                case KKHMacConst.C_MAST_TENPO_PTN_NM:

                    // ���[�f�B���O�\���J�n
                    base.ShowLoadingDialog();

                    // �{�^���ݒ�
                    this.SetButtonPropertySelectTenpoPatternMaster();

                    // ��������
                    this.InitTenpoPatternMaster();

                    // �X�܃}�X�^�[(�P�ꌟ��)�^�u���\��
                    _tabPageManager.ChangeTabPageVisible(0, false);

                    // �ύX�t���OOFF
                    //base.upchk = false;

                    // �X�܃p�^�[���}�X�^�[�p�O���[�v�{�b�N�X��\��
                    grbTenpoPtn.Visible = true;

                    //�Z���N�g�C�x���g
                    this.ChangeFilterValue();                  

                    // ���[�f�B���O�\���I��
                    base.CloseLoadingDialog();

                    break;

                // ���̑��}�X�^�[ 
                default:

                    // �{�^���ݒ�
                    this.SetButtonPropertySelectOtherMaster();

                    // �X�܃p�^�[���}�X�^�[�p�O���[�v�{�b�N�X���\��
                    grbTenpoPtn.Visible = false;

                    // �X�܃}�X�^�[(�P�ꌟ��)�^�u���\��
                    _tabPageManager.ChangeTabPageVisible(0, false);

                    break;
            }
        }

        #endregion

        #region �R�[�h�ϊ��{�^���N���b�N

        /// <summary>
        /// �R�[�h�ϊ��{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChgCode_Click(object sender, EventArgs e)
        {
            // �X�܃R�[�h�ϊ����[�h�ɐݒ肳��Ă���ꍇ
            if (IsChangeCodeMode == true)
            {
                // �X�܃R�[�h�����ɖ߂�
                txtTenpoCd.Text = beforeTenpoCd;

                // �폜�{�^���̎g�p�ۂ�߂�
                btnClr.Enabled = beforeDeleteButtonEnabled;

                // �R�[�h�ϊ���\���ݒ�i�����j
                this.AfterCodeChange(true);
            }
            else
            {
                // �X�܃R�[�h����������ɕێ�
                beforeTenpoCd = txtTenpoCd.Text;

                // �폜�{�^���̎g�p�ۂ���������ɕێ�
                beforeDeleteButtonEnabled = btnClr.Enabled;

                // �폜�{�^�����g�p�s��
                btnClr.Enabled = false;

                // �R�[�h�ϊ���\���ݒ�i�ݒ�j
                this.AfterCodeChange(false);
            }

            this.ActiveControl = null;

        }

        #endregion

        #region �V�K�{�^���N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j

        /// <summary>
        /// �V�K�{�^���N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // �{�^���ݒ�
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // ���͍��ڏ�����
            this.InitInputItemTenpoMaster_FirstTab(true);

            this.ActiveControl = null;

        }

        #endregion

        #region �X�V�{�^���N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j

        /// <summary>
        /// �X�V�{�^���N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd2_Click(object sender, EventArgs e)
        {
            // ���̓`�F�b�N
            if (this.InputCheck() == false)
            {
                this.ActiveControl = null;

                return;
            }

            // �o�^�m�F���b�Z�[�W�\��
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, C_APL_NM, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            // �e���g���[�̒l�擾
            string strTrritory = string.Empty;
            if (rdbTerritory1.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD1;
            }
            if (rdbTerritory2.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD2;
            }
            if (rdbTerritory3.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD3;
            }
            if (rdbTerritory4.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD4;
            }

            // �X�܋敪�̒l�擾
            string strTenpo = string.Empty;
            if (rdbTenpo1.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD1;
            }
            if (rdbTenpo2.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD2;
            }
            if (rdbTenpo3.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD3;
            }
            if (rdbTenpo4.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD4;
            }

            // ���׍s�t���O�̒l�擾
            string strSplit = string.Empty;
            if (rdbSplitFlg1.Checked)
            {
                strSplit = KKHMacConst.C_SPLIT_FLG_CD1;
            }
            if (rdbSplitFlg2.Checked)
            {
                strSplit = KKHMacConst.C_SPLIT_FLG_CD2;
            }

            // DB�A�N�Z�X�pController�̃C���X�^���X�擾
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
        
            // �X�܃R�[�h�X�V���[�h�̏ꍇ 
            if (IsChangeCodeMode == true)
            {
                // �X�܃}�X�^�[����X�܃R�[�h�ɊY�����郌�R�[�h���擾����
                FindMasterMaintenanceByCondServiceResult selectResult = processController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                           mstNavPrm.strEgcd,
                                                                                                           mstNavPrm.strTksKgyCd,
                                                                                                           mstNavPrm.strTksBmnSeqNo,
                                                                                                           mstNavPrm.strTksTntSeqNo,
                                                                                                           KKHMacConst.C_MAST_TENPO_CD,
                                                                                                           txtTenpoCd.Text);
                
                // �X�܃R�[�h�ɊY�����郌�R�[�h�����݂��Ȃ��ꍇ 
                if (selectResult.MasterDataSet.MasterDataVO.Rows.Count > 0)
                {
                    // ���b�Z�[�W�\��
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0025, null, C_APL_NM, MessageBoxButtons.OK);
                    this.ActiveControl = null;

                    return;
                }
            }

            // �X�V�pDataTable�̃C���X�^���X����
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();

            // �X�V�pDataRow����
            MasterMaintenance.MasterDataVORow updateRow = tenpoMasterDataTable.NewMasterDataVORow();

            // ��ʍ��ڂ��X�V�pDataRow�ɐݒ�
            updateRow.Column1 = txtTenpoCd.Text;
            updateRow.Column2 = txtTenpoNm.Text;
            updateRow.Column3 = strTrritory;
            updateRow.Column4 = strTenpo;
            updateRow.Column5 = txtKamoku.Text;
            updateRow.Column6 = txtYubinNo.Text;
            updateRow.Column7 = txtAddress1.Text;
            updateRow.Column8 = txtAddress2.Text;
            updateRow.Column9 = txtTelNo.Text;
            updateRow.Column10 = strSplit;
            updateRow.Column11 = txtCompanyNm.Text;
            updateRow.Column12 = txtName.Text;
            updateRow.Column13 = txtTorihikisakiCd.Text;
            updateRow.Column15 = SGOpen.Text.Trim();
            updateRow.Column16 = GOpen.Text.Trim();
            updateRow.Column17 = GClose.Text.Trim();

            // �ҏW���X�܃}�X�^�[�s�̃^�C���X�X�^���v�����݂���ꍇ
            DateTime updateDateTime = new DateTime();
            if (rowTenpoMaster.IsupdTimStmpNull() == false)
            {
                // �ҏW���X�܃}�X�^�[�s���X�V�pDataRow�ɐݒ�
                updateRow.trkTimStmp = rowTenpoMaster.trkTimStmp;
                updateRow.trkPl = rowTenpoMaster.trkPl;
                updateRow.trkTnt = rowTenpoMaster.trkTnt;
                updateRow.updTimStmp = rowTenpoMaster.updTimStmp;
                updateRow.updaPl = rowTenpoMaster.updaPl;
                updateRow.updTnt = rowTenpoMaster.updTnt;
                updateRow.tksKgyCd = rowTenpoMaster.tksKgyCd;
                updateRow.tksBmnSeqNo = rowTenpoMaster.tksBmnSeqNo;
                updateRow.tksTntSeqNo = rowTenpoMaster.tksTntSeqNo;
                updateRow.sybt = rowTenpoMaster.sybt;

                // �^�C���X�^���v��ݒ�
                updateDateTime = rowTenpoMaster.updTimStmp;
            }
              
            // �X�V�pDataTable��DataRow��ǉ�
            tenpoMasterDataTable.AddMasterDataVORow(updateRow);

            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �X�V����
            RegisterMasterServiceResult result = processController.RegisterMasterResult(mstNavPrm.strEsqId,
                                                                                        C_APL_ID,
                                                                                        mstNavPrm.strEgcd,
                                                                                        mstNavPrm.strTksKgyCd,
                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                        mstNavPrm.strMasterKey,
                                                                                        mstNavPrm.strFilterValue,
                                                                                        tenpoMasterDataTable,
                                                                                        updateDateTime);

            //���[�f�B���O�\���I��   
            base.CloseLoadingDialog();

            // ��ʂ��ĕ\��
            this.reDisplay();

            // �{�^���ݒ�
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // ���͍��ڏ�����
            this.InitInputItemTenpoMaster_FirstTab(true);

            // ���b�Z�[�W�\��
            MessageUtility.ShowMessageBox(MessageCode.HB_I0002, null, C_APL_NM, MessageBoxButtons.OK);

            this.ActiveControl = null;

        }

        #endregion

        #region �폜�{�^�����N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j

        /// <summary>
        /// �폜�{�^�����N���b�N�i�X�܃}�X�^�[(�P�ꌟ��)�^�u�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClr_Click(object sender, EventArgs e)
        {
            // �폜�m�F���b�Z�[�W�\��
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0006, null, C_APL_NM, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            // DB�A�N�Z�X�pController�̃C���X�^���X�擾
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            // �폜����
            RegisterMasterServiceResult result = processController.RegisterMasterResult(mstNavPrm.strEsqId,
                                                                                        C_APL_ID,
                                                                                        mstNavPrm.strEgcd,
                                                                                        mstNavPrm.strTksKgyCd,
                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                        mstNavPrm.strMasterKey,
                                                                                        mstNavPrm.strFilterValue,
                                                                                        new MasterMaintenance.MasterDataVODataTable(),
                                                                                        rowTenpoMaster.updTimStmp);

            // ��ʂ��ĕ\��
            this.reDisplay();

            // �{�^���ݒ�
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // ���͍��ڏ�����
            this.InitInputItemTenpoMaster_FirstTab(true);

            // �폜�������b�Z�[�W�\��
            MessageUtility.ShowMessageBox(MessageCode.HB_I0003, null, C_APL_NM, MessageBoxButtons.OK);

            this.ActiveControl = null;

        }

        #endregion

        /// <summary>
        /// �X�܃}�X�^�[������ʑJ�� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTnpRrkS_Click(object sender, EventArgs e)
        {
            // �X�܃R�[�h����̏ꍇ�͉������Ȃ�
            if (this.txtTenpoCd.Text.Equals(String.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, C_APL_NM, MessageBoxButtons.OK);
                    return;
            }

            // �p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = mstNavPrm;

            naviParam.StrValue1 = txtTenpoCd.Text;
            naviParam.DataTable1 = null;

            // �X�ܗ�����ʂɑJ��
            object result = Navigator.Forward(this, "tofrmMastTnpRrk", naviParam);
            this.Hide();
            
            if (result == null)
            {
                // �f�[�^�����݂��Ȃ������珈���𔲂���B 
                return;
            }

            // �R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �X�܃}�X�^�[������ʑJ�� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTnpRrkA_Click(object sender, EventArgs e)
        {
            //�p�����[�^�Z�b�g 
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = mstNavPrm;

            naviParam.StrValue1 = "";
            naviParam.DataTable1 = null;

            // �ꗗ������ʂɑJ��
            object result = Navigator.Forward(this, "tofrmMastTnpRrkAll", naviParam);
            this.Hide();
            if (result == null)
            {
                // �f�[�^�����݂��Ȃ������珈���𔲂���B 
                return;
            }

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

        }

        #region �捞�{�^���N���b�N

        /// <summary>
        /// �t�@�C���捞�{�^������ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputData_Click(object sender, EventArgs e)
        {
            // �t�@�C���捞�m�F���b�Z�[�W 
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0003, null, C_APL_NM, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0005, null, C_APL_NM, MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }

            // Excel�I�u�W�F�N�g���� 
            Excel.Application oXls =�@new Excel.Application();

            // Workbook�I�u�W�F�N�g���� 
            Excel.Workbook oWBook = null;
            oXls.DisplayAlerts = false;
            
            try
            {
                // �捞�Ώۃt�@�C����`�N���X 
                KKHMacInputDataDefi inputDefi = KKHMacInputDataDefi.GetInstance();

                // �t�@�C���捞�_�C�A���O���� 
                OpenFileDialog ofd = new OpenFileDialog();

                // �f�t�H���g�t�@�C���� 
                ofd.FileName = C_DEFAULT_FILE_NM;

                // �Ώۃf�B���N�g���p�X 
                ofd.InitialDirectory = @inputDefi.InputDataWorkFolderPath;

                // �Ώۃt�@�C���t�B���^ 
                ofd.Filter = C_FILE_FILTER;
                ofd.FilterIndex = 1;

                // �^�C�g�� 
                ofd.Title = C_INPUT_TITLE_NM;
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                // �t�@�C���捞�_�C�A���O�\�� 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Excel�E�B���h�E�\���� 
                    oXls.Visible = false;
                    // Excel�t�@�C���I�[�v�� 
                    oWBook = (Excel.Workbook)(oXls.Workbooks.Open(
                      ofd.FileName,  // �I�[�v������Excel�t�@�C���� 
                      Type.Missing, // �i�ȗ��\�jUpdateLinks (0 / 1 / 2 / 3) 
                      Type.Missing, // �i�ȗ��\�jReadOnly (True / False ) 
                      Type.Missing, // �i�ȗ��\�jFormat 
                        // 1:�^�u / 2:�J���} (,) / 3:�X�y�[�X / 4:�Z�~�R���� (;)
                        // 5:�Ȃ� / 6:���� Delimiter�Ŏw�肳�ꂽ����
                      Type.Missing, // �i�ȗ��\�jPassword 
                      Type.Missing, // �i�ȗ��\�jWriteResPassword 
                      Type.Missing, // �i�ȗ��\�jIgnoreReadOnlyRecommended 
                      Type.Missing, // �i�ȗ��\�jOrigin 
                      Type.Missing, // �i�ȗ��\�jDelimiter 
                      Type.Missing, // �i�ȗ��\�jEditable 
                      Type.Missing, // �i�ȗ��\�jNotify 
                      Type.Missing, // �i�ȗ��\�jConverter 
                      Type.Missing, // �i�ȗ��\�jAddToMru 
                      Type.Missing, // �i�ȗ��\�jLocal 
                      Type.Missing  // �i�ȗ��\�jCorruptLoad 
                    ));


                    // ���[�N�V�[�g��
                    //string sheetName = "Sheet1";
                    // Worksheet�I�u�W�F�N�g�擾 
                    int trgShtIndex = 0;
                    trgShtIndex = getSheetIndex(inputDefi, oWBook.Sheets);
                    if (trgShtIndex.Equals(0))
                    {
                        // workbook�I�u�W�F�N�g����� 
                        oWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                        // Excel�J�� 
                        oXls.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0083,
                         null,
                         C_APL_NM,
                         MessageBoxButtons.OK);

                        this.ActiveControl = null;

                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    Excel.Worksheet oSheet;
                    oSheet = (Excel.Worksheet)oWBook.Sheets[trgShtIndex];

                    // �}�X�^�[�����e�i���X�v���Z�X�R���g���[������ 
                    MasterMaintenanceProcessController masterMaintenanceProcessController
                        = MasterMaintenanceProcessController.GetInstance();
                    // api����̕ԋp�l(�}�X�^�[�����e�i���X) 
                    FindMasterMaintenanceByCondServiceResult result
                        = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                        mstNavPrm.strEgcd,
                                                                        mstNavPrm.strTksKgyCd,
                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                        mstNavPrm.strTksTntSeqNo,
                                                                        KKHMacConst.C_MAST_TENPO_CD,
                                                                        null);

                    // �}�X�^�[�ێ��f�[�^�e�[�u�� 
                    MasterMaintenance.MasterDataVODataTable mstDataTbl
                        = (MasterMaintenance.MasterDataVODataTable)result.MasterDataSet.MasterDataVO;

                    // �`�F�b�N���ʕێ��f�[�^�e�[�u�� 
                    MasterMaintenance.MasterDataVODataTable chkDataTbl
                        = new MasterMaintenance.MasterDataVODataTable();

                    // �`�F�b�N���ʕێ��f�[�^�e�[�u��(�F) 
                    MasterMaintenance.MasterDataVODataTable colDataTbl
                        = new MasterMaintenance.MasterDataVODataTable();

                    // Excel�`�F�b�N�Ώی��o
                    int intRow = 1; // RowIndex 
                    int intClm = 1; // ColumnIndex 
                    int intTenpoCd = 0,        // �X��CD Index�i�[ 
                        intTenpoNm = 0,        // �X�ܖ� Index�i�[ 
                        intTerritory = 0,      // �e���g�� Index�i�[ 
                        intTenpoKbn = 0,       // �X�܋敪 Index�i�[ 
                        intKamokuCd = 0,       // ����Ȗ� Index�i�[ 
                        intYubinNo = 0,        // �X�֔ԍ� Index�i�[ 
                        intTodofukenNm = 0,      // �s���{�� Index�i�[ 
                        intAddress1 = 0,       // �Z���P Index�i�[ 
                        intAddress2 = 0,       // �Z���Q Index�i�[ 
                        intTelNo = 0,          // �d�b�ԍ� Index�i�[ 
                        intSplitFlg = 0,       // ���׍s�t���O Index�i�[ 
                        intCompanyNm = 0,      // ���C�Z���V�[�Ж� Index�i�[ 
                        intName = 0,           // ��\�Җ� Index�i�[ 
                        intTorihikisakiCd = 0, // �����R�[�h Index�i�[ 
                        //intCloseDate = 0,      // �I���� Index�i�[   
                        intShokiGOpenNgp = 0,  // ����G.OPEN�N����Index�i�[  
                        intGOpenNgp = 0,       // G.OPEN�N����Index�i�[  
                        intGCloseNgp = 0;      // G.CLOSE�N����Index�i�[  

                    //���[�f�B���O�\���J�n  
                    base.ShowLoadingDialog();

                    # region �G�N�Z���捞 ��

                    // ��荞��Excel��Column��empty�ɂȂ�܂� 
                    while (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString() != string.Empty)
                    {
                        // Column���u�X�܃R�[�h�v�����݂���΁A���Y�t�@�C�����index���擾 
                        if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoCd = intClm;
                        }
                        // Column���u�X�ܖ��v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoNm = intClm;
                        }
                        // Column���u�e���g���v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTerritory))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTerritory = intClm;
                        }
                        // Column���u�X�܋敪�v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoKbn))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoKbn = intClm;
                        }
                        // Column���u����Ȗځv�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strKamokuCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intKamokuCd = intClm;
                        }
                        // Column���u�X�֔ԍ��v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strYubinNo))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intYubinNo = intClm;
                        }
                        // Column���u�s���{���v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTodofukenNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTodofukenNm = intClm;
                        }
                        // Column���u�Z���P�v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strAddress1))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intAddress1 = intClm;
                        }
                        // Column���u�Z���Q�v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strAddress2))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intAddress2 = intClm;
                        }
                        // Column���u�d�b�ԍ��v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTelNo))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTelNo = intClm;
                        }
                        // Column���u���׍s�t���O�v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strSplitFlg))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intSplitFlg = intClm;
                        }
                        // Column���u���C�Z���V�[�Ж��v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strCompanyNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intCompanyNm = intClm;
                        }
                        // Column���u��\�Җ��v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strName))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intName = intClm;
                        }
                        // Column���u�����R�[�h�v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTorihikisakiCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTorihikisakiCd = intClm;
                        }
                        // Column���u����G.OPEN�N�����v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.shokiGOpenNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intShokiGOpenNgp = intClm;
                        }
                        // Column���uG.OPEN�N�����v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.gOpenNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intGOpenNgp = intClm;
                        }
                        // Column���uG.CLOSE�N�����v�����݂���΁A���Y�t�@�C�����index���擾 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.gCloseNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intGCloseNgp = intClm;
                        }
                        // ColumnIndex�̃C���N�������g 
                        intClm++;
                    }

                    # endregion �G�N�Z���捞 ��

                    // ExcelRowIndex �������� 
                    intRow = 2;

                    // CheckTbl�pRowIndex 
                    int intInsTblRow = 0;

                    # region �G�N�Z���捞 �s

                    // Excel �X��Cd Row��empty�ɂȂ�܂ŁB 
                    while (((Excel.Range)oSheet.Cells[intRow, intTenpoCd]).Text.ToString() != string.Empty)
                    {

                        bool blnEnableFalse = false;
                        // �`�F�b�N���ʊi�[�ϐ�(string)
                        string strTenpoCd = string.Empty,       // �X�܃R�[�h �i�[�p
                            strTenpoNm = string.Empty,          // �X�ܖ��� �i�[�p
                            strTerritory = string.Empty,        // �e���g�� �i�[�p
                            strTenpoKbn = string.Empty,         // �X�܋敪 �i�[�p
                            strKamokuCd = string.Empty,         // ����Ȗ� �i�[�p
                            strYubinNo = string.Empty,          // �X�֔ԍ� �i�[�p
                            strTodofukenNm = string.Empty,        // �s���{�� �i�[�p 
                            strAddress1 = string.Empty,         // �Z���P �i�[�p
                            strAddress2 = string.Empty,         // �Z���Q �i�[�p
                            strTelNo = string.Empty,            // �d�b�ԍ� �i�[�p
                            strSplitFlg = string.Empty,         // ���׍s�t���O �i�[�p
                            strCompanyNm = string.Empty,        // ���C�Z���V�[�Ж� �i�[�p
                            strName = string.Empty,             // ��\�Җ� �i�[�p
                            strTorihikisakiCd = string.Empty,   // �����R�[�h �i�[�p
                            //strCloseDate = string.Empty,        // �I���� �i�[�p
                            strShokiGOpenNgp = "",              // ����G.OPEN�N���� 
                            strGOpenNgp = "",                   // G.OPEN�N���� 
                            strGCloseNgp = "";                  // G.CLOSE�N���� 

                        // ���Y�t�@�C���Ɂu�X�܃R�[�h�v���݂��鎞
                        if (intTenpoCd != 0)
                        {
                            strTenpoCd = String.Format("{0:000000}", int.Parse(((Excel.Range)oSheet.Cells[intRow, intTenpoCd]).Text.ToString().Trim()));
                        }
                        // ���Y�t�@�C���Ɂu�X�ܖ��́v���݂��鎞
                        if (intTenpoNm != 0)
                        {
                            strTenpoNm = ((Excel.Range)oSheet.Cells[intRow, intTenpoNm]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�e���g���[�v���݂��鎞
                        if (intTerritory != 0)
                        {
                            // ���̂���敪�ɕϊ�
                            switch (((Excel.Range)oSheet.Cells[intRow, intTerritory]).Text.ToString().Trim())
                            {
                                // �֓�
                                case KKHMacConst.C_TERRITORY_NM1:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD1;
                                    break;
                                // �֐�
                                case KKHMacConst.C_TERRITORY_NM2:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD2;
                                    break;
                                // ����
                                case KKHMacConst.C_TERRITORY_NM3:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD3;
                                    break;
                                // ���̑�
                                case KKHMacConst.C_TERRITORY_NM4:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD4;
                                    break;
                            }
                        }
                        // ���Y�t�@�C���Ɂu�X�܋敪�v���݂��鎞
                        if (intTenpoKbn != 0)
                        {
                            // ���̂���敪�ɕϊ�
                            switch (((Excel.Range)oSheet.Cells[intRow, intTenpoKbn]).Text.ToString().Trim())
                            {
                                // *****************************************************************
                                //             ���̓t�@�C���̃f�[�^�����...�ł���Γ��ꂵ���� 
                                // *****************************************************************
                                // �n��{�� 
                                case "�n��{��":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD1;
                                    break;
                                // MC���c 
                                case "���c":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD2;
                                    break;
                                // ���C�Z���V�[ 
                                case "�e�b":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD3;
                                    break;
                                // ���̑�
                                case "���̑�":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD4;
                                    break;
                            }
                        }
                        // ���Y�t�@�C���Ɂu����Ȗځv���݂��鎞 
                        if (intKamokuCd != 0)
                        {
                            strKamokuCd = ((Excel.Range)oSheet.Cells[intRow, intKamokuCd]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�X�֔ԍ��v���݂��鎞 
                        if (intYubinNo != 0)
                        {
                            strYubinNo = ((Excel.Range)oSheet.Cells[intRow, intYubinNo]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�s���{���v���݂��鎞 
                        if (intTodofukenNm != 0)
                        {
                            strTodofukenNm = ((Excel.Range)oSheet.Cells[intRow, intTodofukenNm]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�Z���P�v���݂��鎞 
                        if (intAddress1 != 0)
                        {
                            strAddress1 = ((Excel.Range)oSheet.Cells[intRow, intAddress1]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�Z���Q�v���݂��鎞 
                        if (intAddress2 != 0)
                        {
                            strAddress2 = ((Excel.Range)oSheet.Cells[intRow, intAddress2]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�d�b�ԍ��v���݂��鎞 
                        if (intTelNo != 0)
                        {
                            strTelNo = ((Excel.Range)oSheet.Cells[intRow, intTelNo]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu���׍s�t���O�v���݂��鎞 
                        if (intSplitFlg != 0)
                        {
                            // ���̂��敪�ɕϊ� 
                            switch (((Excel.Range)oSheet.Cells[intRow, intSplitFlg]).Text.ToString().Trim())
                            {
                                // ���� 
                                case KKHMacConst.C_SPLIT_FLG_NM1:
                                    strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD1;
                                    break;
                                // �񕪊� 
                                case KKHMacConst.C_SPLIT_FLG_NM2:
                                    strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD2;
                                    break;
                            }
                        }
                        else
                        {
                            // ���݂��Ȃ����͌Œ�Łh�������Ȃ� = 1�h��ݒ肷�� 
                            strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD2;
                        }
                        // ���Y�t�@�C���Ɂu���C�Z���V�[�Ж��v���݂��鎞 
                        if (intCompanyNm != 0)
                        {
                            strCompanyNm = ((Excel.Range)oSheet.Cells[intRow, intCompanyNm]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu��\�Җ��v���݂��鎞 
                        if (intName != 0)
                        {
                            strName = ((Excel.Range)oSheet.Cells[intRow, intName]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu�����R�[�h�v���݂��鎞 
                        if (intTorihikisakiCd != 0)
                        {
                            strTorihikisakiCd = ((Excel.Range)oSheet.Cells[intRow, intTorihikisakiCd]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���Ɂu����G.OPEN�N�����v�����݂��鎞 
                        if (intShokiGOpenNgp != 0)
                        {
                            strShokiGOpenNgp = ((Excel.Range)oSheet.Cells[intRow, intShokiGOpenNgp]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���ɁuG.OPEN�N�����v�����݂��鎞 
                        if (intGOpenNgp != 0)
                        {
                            strGOpenNgp = ((Excel.Range)oSheet.Cells[intRow, intGOpenNgp]).Text.ToString().Trim();
                        }
                        // ���Y�t�@�C���ɁuG.CLOSE�N�����v�����݂��鎞 
                        if (intGCloseNgp != 0)
                        {
                            strGCloseNgp = ((Excel.Range)oSheet.Cells[intRow, intGCloseNgp]).Text.ToString().Trim();
                            if (strGCloseNgp.Equals(String.Empty))
                            {
                                base.CloseLoadingDialog();
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0157, new string[] { "G.CLOSE�N����" }, "�G���[", MessageBoxButtons.OK);
                                // *** Excel �I�u�W�F�N�g��� ***
                                // workbook�I�u�W�F�N�g�����
                                oWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                                // Excel�J�� 
                                oXls.Quit();
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                                return; 
                            }
                        }

                        // �L���������� 
                        //if (DateTime.Compare(DateTime.Parse(strGCloseNgp),
                        if (DateTime.Compare(Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(strGCloseNgp),
                            Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(tslDate.Text)) < 0)
                        {
                            blnEnableFalse = true;
                        }
                        // DB�ێ��̒l����Excel�̓X�܃R�[�h�ɂči�荞�� 
                        MasterMaintenance.MasterDataVORow[] mstDataRow = (MasterMaintenance.MasterDataVORow[])mstDataTbl.Select("Column1 = '" + strTenpoCd + "'");

                        // �Y���f�[�^�� 
                        // ###############################################################
                        // #                         �V�K�f�[�^                          #
                        // ###############################################################
                        if (mstDataRow.Length.Equals(0))
                        {
                            // �L����������i�؂�Ă�����捞�ΏۊO�j 
                            if (!blnEnableFalse)
                            {
                                // �s�ǉ� 
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // �s�ǉ� 
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                                // �X�e�[�^�X"�V�K" 
                                chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NEW;
                                colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NEW;

                                // �X�܃R�[�h 
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // �X�ܖ� 
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // �e���g�� 
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // �X�܋敪 
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // ����Ȗ� 
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // �X�֔ԍ� 
                                if (strYubinNo.Length != 0)
                                {
                                    //7�������̏ꍇ 
                                    if (strYubinNo.Length < 7)
                                    {
                                        //����0�𖄂߂� 
                                        strYubinNo = strYubinNo.PadLeft(7, '0');
                                    }

                                    //"-"��}�� 
                                    strYubinNo = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);
                                    //chkDataTbl[intInsTblRow].Column6 = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);
                                }

                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;

                                // �s���{��  
                                chkDataTbl[intInsTblRow].Column19 = strTodofukenNm;
                                //�s���{�����Z���P�Ɋ܂܂�Ă���ꍇ 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // �Z���P 
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // �Z���Q 
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // �d�b�ԍ� 
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // ���׍s�t���O 
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ���C�Z���V�[�Ж� 
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // ��\�Җ� 
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // �����R�[�h 
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // ����G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE�N���� 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // �X�܃R�[�h 
                                colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                // �X�ܖ� 
                                colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                // �e���g�� 
                                colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                // �X�܋敪 
                                colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                // ����Ȗ� 
                                colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                // �X�֔ԍ� 
                                colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                // �Z���P 
                                colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                // �Z���Q 
                                colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                // �d�b�ԍ� 
                                colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                // ���׍s�t���O 
                                colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                // ���C�Z���V�[�Ж� 
                                colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                // ��\�Җ� 
                                colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                // �����R�[�h 
                                colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                // �X�܃R�[�h�i�L�[�j 
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;
                                // ����G.OPEN�N���� 
                                colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                // G.OPEN�N���� 
                                colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                // G.CLOSE�N���� 
                                colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;
                                // �C���N�������g 
                                intInsTblRow++;
                            }
                        }
                        // �Y���f�[�^�L 
                        else
                        {

                            bool blnTenpoCd = false,         // �X�܃R�[�h �i�[�p 
                                blnTenpoNm = false,          // �X�ܖ��� �i�[�p 
                                blnTerritory = false,        // �e���g�� �i�[�p 
                                blnTenpoKbn = false,         // �X�܋敪 �i�[�p 
                                blnKamokuCd = false,         // ����Ȗ� �i�[�p 
                                blnYubinNo = false,          // �X�֔ԍ� �i�[�p 
                                blnAddress1 = false,         // �Z���P �i�[�p 
                                blnAddress2 = false,         // �Z���Q �i�[�p 
                                blnTelNo = false,            // �d�b�ԍ� �i�[�p 
                                blnSplitFlg = false,         // ���׍s�t���O �i�[�p 
                                blnCompanyNm = false,        // ���C�Z���V�[�Ж� �i�[�p 
                                blnName = false,             // ��\�Җ� �i�[�p 
                                blnTorihikisakiCd = false,   // �����R�[�h �i�[�p 
                                blnShokiGOpenNgp = false,    // ����G.OPEN�N���� 
                                blnGOpenNgp = false,         // G.OPEN�N���� 
                                blnGCloseNgp = false;        // G.CLOSE�N���� 
                            // Column���u�X�܃R�[�h�v�����݂���ꍇ 
                            if (intTenpoCd != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column1.ToString() != strTenpoCd)
                                {
                                    // �`�F�b�N�t���O��"true" 
                                    blnTenpoCd = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strTenpoCd = mstDataRow[0].Column1.ToString();
                            }
                            // Column���u�X�ܖ��v�����݂���ꍇ 
                            if (intTenpoNm != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column2.ToString() != strTenpoNm)
                                {
                                    // �`�F�b�N�t���O��"true" 
                                    blnTenpoNm = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strTenpoNm = mstDataRow[0].Column2.ToString();
                            }
                            // Column���u�e���g���v�����݂���ꍇ 
                            if (intTerritory != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column3.ToString() != strTerritory)
                                {
                                    // �`�F�b�N�t���O��"true" 
                                    blnTerritory = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strTerritory = mstDataRow[0].Column3.ToString();
                            }
                            // Column���u�X�܋敪�v�����݂���ꍇ 
                            if (intTenpoKbn != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column4.ToString() != strTenpoKbn)
                                {
                                    // �`�F�b�N�t���O��"true" 
                                    blnTenpoKbn = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strTenpoKbn = mstDataRow[0].Column4.ToString();
                            }
                            // Column���u����Ȗځv�����݂���ꍇ
                            if (intKamokuCd != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column5.ToString() != strKamokuCd)
                                {
                                    // �`�F�b�N�t���O��"true" 
                                    blnKamokuCd = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strKamokuCd = mstDataRow[0].Column5.ToString();
                            }
                            // Column���u�X�֔ԍ��v�����݂���ꍇ 
                            if (intYubinNo != 0)
                            {
                                //7�������̏ꍇ 
                                if (strYubinNo.Length < 7)
                                {
                                    //����0�𖄂߂� 
                                    strYubinNo = strYubinNo.PadLeft(7, '0');
                                }

                                //"-"��}�� 
                                strYubinNo = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);

                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (mstDataRow[0].Column6.ToString() != strYubinNo)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnYubinNo = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ� 
                            else
                            {
                                strYubinNo = mstDataRow[0].Column6.ToString();
                            }


                            // Column���u�Z���P�v�����݂���ꍇ 
                            if (intAddress1 != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                //if (mstDataRow[0].Column7.ToString() != strAddress1)
                                if (mstDataRow[0].Column7.ToString() != strTodofukenNm + strAddress1)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnAddress1 = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strAddress1 = mstDataRow[0].Column7.ToString();
                            }

                            // Column���u�Z���Q�v�����݂���ꍇ
                            if (intAddress2 != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column8.ToString() != strAddress2)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnAddress2 = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strAddress2 = mstDataRow[0].Column8.ToString();
                            }
                            // Column���u�d�b�ԍ��v�����݂���ꍇ
                            if (intTelNo != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column9.ToString() != strTelNo)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnTelNo = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strTelNo = mstDataRow[0].Column9.ToString();
                            }
                            // Column���u���׍s�t���O�v�����݂���ꍇ
                            if (intSplitFlg != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column10.ToString() != strSplitFlg)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnSplitFlg = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strSplitFlg = mstDataRow[0].Column10.ToString();
                            }
                            // Column���u���C�Z���V�[�Ж��v�����݂���ꍇ
                            if (intCompanyNm != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column11.ToString().Replace("\n", "") != strCompanyNm)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnCompanyNm = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strCompanyNm = mstDataRow[0].Column11.ToString();
                            }
                            // Column���u��\�Җ��v�����݂���ꍇ
                            if (intName != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column12.ToString().Replace("\n", "") != strName)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnName = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strName = mstDataRow[0].Column12.ToString();
                            }
                            // Column���u�����R�[�h�v�����݂���ꍇ
                            if (intTorihikisakiCd != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (mstDataRow[0].Column13.ToString() != strTorihikisakiCd)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnTorihikisakiCd = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strTorihikisakiCd = mstDataRow[0].Column13.ToString();
                            }

                            // Column���u����G.OPEN�N�����v�����݂���ꍇ
                            if (intShokiGOpenNgp != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column15.ToString()).ToString("yyyy/M/d")
                                    != strShokiGOpenNgp)
                                //if (mstDataRow[0].Column16.ToString() != strGOpenNgp)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnShokiGOpenNgp = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strShokiGOpenNgp = mstDataRow[0].Column15.ToString();
                            }

                            // Column���uG.OPEN�N�����v�����݂���ꍇ
                            if (intGOpenNgp != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column16.ToString()).ToString("yyyy/M/d")
                                    != strGOpenNgp)
                                //if (mstDataRow[0].Column16.ToString() != strGOpenNgp)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnGOpenNgp = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strGOpenNgp = mstDataRow[0].Column16.ToString();
                            }

                            // Column���uG.CLOSE�N�����v�����݂���ꍇ
                            if (intGCloseNgp != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r���� 
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column17.ToString()).ToString("yyyy/M/d")
                                    != strGCloseNgp)
                                //if (mstDataRow[0].Column17.ToString() != strGCloseNgp)
                                {
                                    // �`�F�b�N�t���O��"true"
                                    blnGCloseNgp = true;
                                }
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strGCloseNgp = mstDataRow[0].Column17.ToString();
                            }


                            // Column���u�s���{���v�����݂���ꍇ 
                            if (intTodofukenNm != 0)
                            {
                                // �������R�[�h�̒l�ƁAExcel�̒l���r����
                                //if (mstDataRow[0].Column19.ToString() != strTodofukenNm)
                                //{
                                //    // �`�F�b�N�t���O��"true"
                                //    blnTodofukenNm = true;
                                //}
                            }
                            // ���݂��Ȃ��ꍇ�A�������R�[�h�̒l��ݒ�
                            else
                            {
                                strTodofukenNm = mstDataRow[0].Column19.ToString();
                            }
                            # region �ύX�f�[�^�`�F�b�N

                            // ###############################################################
                            // #                         �ύX�f�[�^                          #
                            // ###############################################################
                            // �`�F�b�N�t���O��"true = �ύX�L"
                            if ((blnTenpoCd) ||
                                (blnTenpoNm) ||
                                (blnTerritory) ||
                                (blnTenpoKbn) ||
                                (blnKamokuCd) ||
                                (blnYubinNo) ||
                                (blnAddress1) ||
                                (blnAddress2) ||
                                (blnTelNo) ||
                                (blnSplitFlg) ||
                                (blnCompanyNm) ||
                                (blnName) ||
                                (blnTorihikisakiCd) ||
                                (blnTenpoNm) ||
                                (blnShokiGOpenNgp) ||
                                (blnGOpenNgp) ||
                                (blnGCloseNgp))
                            {
                                // ��������
                                // �s�ǉ�
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // �s�ǉ�
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());

                                // �L����������
                                if (!blnEnableFalse)
                                {
                                    // �������؂�Ă��Ȃ��A�X�e�[�^�X"�ύX"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_EDIT;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_EDIT;
                                }
                                else
                                {
                                    // �����؂�A�X�e�[�^�X"�폜"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                }
                                // *** �f�[�^ ***
                                // �X�܃R�[�h
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // �X�ܖ�
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // �e���g��
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // �X�܋敪
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // ����Ȗ�
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // �X�֔ԍ�
                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;
                                //�s���{�����Z���P�Ɋ܂܂�Ă���ꍇ 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // �Z���P 
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // �Z���Q 
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // �d�b�ԍ�
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // ���׍s�t���O
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ���C�Z���V�[�Ж�
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // ��\�Җ�
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // �����R�[�h
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // ����G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE�N���� 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // *** �F ***
                                // �X�܃R�[�h
                                if (blnTenpoCd)
                                {
                                    colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �X�ܖ�
                                if (blnTenpoNm)
                                {
                                    colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �e���g��
                                if (blnTerritory)
                                {
                                    colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �X�܋敪
                                if (blnTenpoKbn)
                                {
                                    colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // ����Ȗ�
                                if (blnKamokuCd)
                                {
                                    colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �X�֔ԍ�
                                if (blnYubinNo)
                                {
                                    colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �Z���P
                                if (blnAddress1)
                                {
                                    colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �Z���Q
                                if (blnAddress2)
                                {
                                    colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �d�b�ԍ�
                                if (blnTelNo)
                                {
                                    colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // ���׍s�t���O
                                if (blnSplitFlg)
                                {
                                    colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // ���C�Z���V�[�Ж�
                                if (blnCompanyNm)
                                {
                                    colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // ��\�Җ�
                                if (blnName)
                                {
                                    colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // �����R�[�h
                                if (blnTorihikisakiCd)
                                {
                                    colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                }

                                // �X�܃R�[�h�i�L�[�j
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;

                                // ����G.OPEN�N���� 
                                if (blnShokiGOpenNgp)
                                {
                                    colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // G.OPEN�N���� 
                                if (blnGOpenNgp)
                                {
                                    colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // G.CLOSE�N���� 
                                if (blnGCloseNgp)
                                {
                                    colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;
                                }

                                // �C���N�������g
                                intInsTblRow++;
                            }
                            // ###############################################################
                            // #                       ���������f�[�^                        #
                            // ###############################################################
                            else
                            {
                                // �s�ǉ�
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // �s�ǉ�
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                                // �L����������i�؂�Ă�����捞�ΏۊO�j
                                if (!blnEnableFalse)
                                {
                                    // �L���������؂�Ă��Ȃ��A�X�e�[�^�X"�����Ȃ�"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NONE;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NONE;
                                }
                                else
                                {
                                    // �����؂�A�X�e�[�^�X"�폜"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                }
                                // *** �f�[�^ ***
                                // �X�܃R�[�h
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // �X�ܖ�
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // �e���g��
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // �X�܋敪
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // ����Ȗ�
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // �X�֔ԍ�
                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;
                                //�s���{�����Z���P�Ɋ܂܂�Ă���ꍇ 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // �Z���P 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // �Z���P
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // �Z���Q
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // �d�b�ԍ�
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // ���׍s�t���O
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ���C�Z���V�[�Ж�
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // ��\�Җ�
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // �����R�[�h
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // ����G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN�N���� 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE�N���� 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // *** �F ***
                                // �X�܃R�[�h
                                colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                // �X�ܖ�
                                colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                // �e���g��
                                colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                // �X�܋敪
                                colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                // ����Ȗ�
                                colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                // �X�֔ԍ�
                                colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                // �Z���P
                                colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                // �Z���Q
                                colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                // �d�b�ԍ�
                                colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                // ���׍s�t���O
                                colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                // ���C�Z���V�[�Ж�
                                colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                // ��\�Җ�
                                colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                // �����R�[�h
                                colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                // �X�܃R�[�h�i�L�[�j
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;

                                // ����G.OPEN�N���� 
                                colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                // G.OPEN�N���� 
                                colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                // G.CLOSE�N���� 
                                colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;

                                // �C���N�������g
                                intInsTblRow++;
                            }

                            # endregion �ύX�f�[�^�`�F�b�N

                        }
                        // Excel Row �C���N�������g
                        intRow++;
                    }

                    # endregion �G�N�Z���捞 �s

                    // *** Excel �I�u�W�F�N�g��� ***
                    // workbook�I�u�W�F�N�g�����
                    oWBook.Close(Type.Missing, Type.Missing, Type.Missing);

                    // Excel�J�� 
                    oXls.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);


                    # region �폜�f�[�^

                    // ###############################################################
                    // #                         �폜�f�[�^                          #
                    // ###############################################################
                    // �����f�[�^���폜�f�[�^�m�F 
                    foreach (MasterMaintenance.MasterDataVORow dtRow in mstDataTbl.Rows)
                    {
                        //����"9"�̏ꍇ�A�������Ȃ� 
                        if(dtRow.Column1.StartsWith("9"))
                        {
                            continue;
                        }

                        // Excel��萶������dTbl����X�܃R�[�h�ɂči�荞�� 
                        MasterMaintenance.MasterDataVORow[] mstDataRow = (MasterMaintenance.MasterDataVORow[])chkDataTbl.Select("Column1 = '" + dtRow.Column1 + "'");

                        // �Y�����R�[�h�������ꍇ�A�폜���R�[�h�ƌ��Ȃ��ϗ����s��
                        if (mstDataRow.Length.Equals(0))
                        {
                            // �폜�s�ǉ�
                            chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                            // �X�e�[�^�X
                            chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                            // �X�܃R�[�h
                            chkDataTbl[intInsTblRow].Column1 = dtRow.Column1;
                            // �X�ܖ�
                            chkDataTbl[intInsTblRow].Column2 = dtRow.Column2;
                            // �e���g��
                            chkDataTbl[intInsTblRow].Column3 = dtRow.Column3;
                            // �X�܋敪
                            chkDataTbl[intInsTblRow].Column4 = dtRow.Column4;
                            // ����Ȗ�
                            chkDataTbl[intInsTblRow].Column5 = dtRow.Column5;
                            // �X�֔ԍ�
                            chkDataTbl[intInsTblRow].Column6 = dtRow.Column6;
                            ////�s���{�����Z���P�Ɋ܂܂�Ă���ꍇ 
                            //if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                            //{
                            //    // �Z���P 
                            //    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                            //}
                            //else
                            //{
                            //    // �Z���P 
                            //    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                            //}
                            // �Z���P
                            chkDataTbl[intInsTblRow].Column7 = dtRow.Column7;
                            // �Z���Q
                            chkDataTbl[intInsTblRow].Column8 = dtRow.Column8;
                            // �d�b�ԍ�
                            chkDataTbl[intInsTblRow].Column9 = dtRow.Column9;
                            // ���׍s�t���O
                            chkDataTbl[intInsTblRow].Column10 = dtRow.Column10;
                            // ���C�Z���V�[�Ж�
                            chkDataTbl[intInsTblRow].Column11 = dtRow.Column11;
                            // ��\�Җ�
                            chkDataTbl[intInsTblRow].Column12 = dtRow.Column12;
                            // �����R�[�h
                            chkDataTbl[intInsTblRow].Column13 = dtRow.Column13;
                            // ����G.OPEN�N���� 
                            chkDataTbl[intInsTblRow].Column16 = dtRow.Column16;
                            // G.OPEN�N���� 
                            chkDataTbl[intInsTblRow].Column17 = dtRow.Column17;
                            // G.CLOSE�N���� 
                            chkDataTbl[intInsTblRow].Column18 = dtRow.Column18;

                            // **********************************************************************
                            // ************************* �b��ŐF�Ή� *******************************
                            // **********************************************************************
                            // �V�K�f�[�^�s�ǉ�
                            colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                            // �X�e�[�^�X"�폜"
                            colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                            // �X�܃R�[�h
                            colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                            // �X�ܖ�
                            colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                            // �e���g��
                            colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                            // �X�܋敪
                            colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                            // ����Ȗ�
                            colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                            // �X�֔ԍ�
                            colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                            // �Z���P
                            colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                            // �Z���Q
                            colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                            // �d�b�ԍ�
                            colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                            // ���׍s�t���O
                            colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                            // ���C�Z���V�[�Ж�
                            colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                            // ��\�Җ�
                            colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                            // �����R�[�h
                            colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                            // �X�܃R�[�h�i�L�[�j
                            colDataTbl[intInsTblRow].Column15 = dtRow.Column1;
                            // ����G.OPEN�N���� 
                            chkDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                            // G.OPEN�N���� 
                            chkDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                            // G.CLOSE�N���� 
                            chkDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;

                            // **********************************************************************
                            // **********************************************************************

                            // �C���N�������g
                            intInsTblRow++;
                        }
                    }

                    # endregion �폜�f�[�^


                    //���[�f�B���O�\���I�� 
                    base.CloseLoadingDialog();

                    bool notChgFlg = false;
                    foreach (MasterMaintenance.MasterDataVORow row in chkDataTbl.Rows)
                    {
                        if (row.Column14 != KKHMacConst.C_INPUT_STAT_NONE)
                        {
                            notChgFlg = true;
                            break;
                        }
                    }

                    if (!notChgFlg)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0023,
                        null,
                        C_APL_NM,
                        MessageBoxButtons.OK);

                        this.ActiveControl = null;

                        return;
                    }
                    // �`�F�b�N�ꗗ��ʑJ�ڗp�p�����[�^����
                    MastInputNaviParameter mstInNavi = new MastInputNaviParameter();
                    // ���Ӑ��ƃR�[�h
                    mstInNavi.strTksKgyCd = mstNavPrm.strTksKgyCd;
                    // ���Ӑ敔��R�[�h
                    mstInNavi.strTksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
                    // ���Ӑ�S���҃R�[�h
                    mstInNavi.strTksTntSeqNo = mstNavPrm.strTksTntSeqNo;
                    // EsqId
                    mstInNavi.strEsqId = mstNavPrm.strEsqId;
                    // Egcd
                    mstInNavi.strEgcd = mstNavPrm.strEgcd;
                    // ���t
                    mstInNavi.strDate = mstNavPrm.strDate;
                    // �S���Җ�
                    mstInNavi.strName = mstNavPrm.strName;
                    // �ϗ�Dtbl
                    mstInNavi.dsMerge = chkDataTbl;
                    // �ϗ��i�F�jDtbl
                    mstInNavi.dsMergeColor = colDataTbl;
                    // ���Ӑ��Ɩ���
                    mstInNavi.strTksKgyName = mstNavPrm.strTksKgyName;
                    // �}�X�^�[�L�[
                    mstInNavi.strMasterKey = KKHMacConst.C_MAST_TENPO_CD;
                    // �`�F�b�N�ꗗ��ʕ\��
                    Navigator.ShowModalForm(this, "tofrmMastMergeMac", mstInNavi);

                    this.ActiveControl = null;
                }
                else
                {
                    this.ActiveControl = null;

                    return;
                }
            }
            catch (COMException ComEx)
            {

                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                MessageUtility.ShowMessageBox(MessageCode.HB_W0020
                                ,new string[]{System.Environment.NewLine, System.Environment.NewLine + ComEx.InnerException}
                                , C_APL_NM
                                ,MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }
            catch (Exception ex)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                MessageUtility.ShowMessageBox(MessageCode.HB_E0002,
                    new string[] { System.Environment.NewLine, System.Environment.NewLine + ex.InnerException },
                    C_APL_NM,
                    MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }
        }

        #endregion

        #region �ǉ��{�^���N���b�N(�X�܃p�^�[��)

        /// <summary>
        /// �ǉ��{�^���N���b�N(�X�܃p�^�[��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnAdd_Click(object sender, EventArgs e)
        {
            // �p�^�[���R�[�h
            int ptnCd = 0;

            // ���̖��ݒ�̍s��
            int UntitledCnt = 1;

            // �X�v���b�h����p�^�[�������擾
            MasterMaintenance.MasterDataVODataTable ptnDt = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;

            // �p�^�[���̍s���`�F�b�N
            if (ptnDt.Rows.Count >= C_MAXROW_TENPO_PATTERN_MASTER)
            {
                MessageBox.Show("�p�^�[���͍ő�999���܂ł����o�^�ł��܂���","�x��",MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }

            foreach (MasterMaintenance.MasterDataVORow dr in ptnDt.Rows)
            {
                // ���̖��ݒ�̍s�����J�E���g
                if (dr.Column2.Contains(KKHMacConst.C_DEFAULT_PTN_NM))
                {
                    UntitledCnt++;
                }

                // �p�^�[���R�[�h�̍ő�l���擾
                if (ptnCd < int.Parse(dr.Column1))
                {
                   ptnCd = int.Parse(dr.Column1);
                }
            }

            // �p�^�[���R�[�h���ő�s���܂ō̔Ԃ���Ă���ꍇ
            if (ptnCd == C_MAXROW_TENPO_PATTERN_MASTER)
            {
                // �󂢂Ă���p�^�[���R�[�h���擾
                ptnCd = GetPatternCode(ptnDt);
            }
            else
            {
                // �p�^�[���R�[�h���C���N�������g
                ptnCd = ptnCd + 1;
            }

            // �p�^�[�����֐V�K�s��ǉ�
            ptnDt.AddMasterDataVORow(DateTime.Now,
                C_APL_ID,
                mstNavPrm.strEsqId,
                DateTime.Now,
                C_APL_ID,
                mstNavPrm.strEsqId,
                mstNavPrm.strEgcd,
                mstNavPrm.strTksKgyCd,
                mstNavPrm.strTksBmnSeqNo,
                mstNavPrm.strTksTntSeqNo,
                "103",
                ptnCd.ToString("000"),
                KKHMacConst.C_DEFAULT_PTN_NM + UntitledCnt,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

            // �p�^�[�������X�v���b�h�ɐݒ�
            spdPtn.DataSource = ptnDt;

            // �X�V�t���OON
            base.upchk = true;

            this.ActiveControl = null;

        }

        #endregion

        #region �폜�{�^���N���b�N(�X�܃p�^�[��)

        /// <summary>
        /// �폜�{�^���N���b�N(�X�܃p�^�[��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnDel_Click(object sender, EventArgs e)
        {
            // �X�܃p�^�[���ꗗ�ɍs�����݂��Ȃ��ꍇ�A�����I��
            if (spdPtn_Sheet1.Rows.Count == 0)
            {
                this.ActiveControl = null;

                return;
            }

            // �X�v���b�h����X�܃p�^�[���}�X�^�[���擾
            MasterMaintenance.MasterDataVODataTable ptnDt = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;
            
            // �p�^�[���R�[�h�擾
            string patternCode = ptnDt.Rows[spdPtn_Sheet1.ActiveRowIndex][11].ToString();

            // �X�܃p�^�[���}�X�^�[����A�N�e�B�u�s���폜
            ptnDt.Rows.RemoveAt(spdPtn.Sheets[0].ActiveRowIndex);

            // �X�܃p�^�[���}�X�^�[���X�v���b�h�ɐݒ�
            spdPtn.DataSource = ptnDt;

            for (int rowIndex = spdTenpoPtn_Sheet1.Rows.Count - 1; rowIndex >= 0; rowIndex--)
            {
                if (spdTenpoPtn_Sheet1.Cells[rowIndex, 14].Value.ToString() == patternCode)
                {
                    spdTenpoPtn_Sheet1.Rows.Remove(rowIndex, 1);
                }
            }

            // �X�V�t���OON
            base.upchk = true;

            this.ActiveControl = null;
        }

        #endregion

        #region �ύX�{�^���N���b�N(�X�܃p�^�[��)

        /// <summary>
        /// �ύX�{�^���N���b�N(�X�܃p�^�[��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnEdt_Click(object sender, EventArgs e)
        {
            // �X�܃p�^�[���ꗗ�ɍs�����݂��Ȃ��ꍇ�A�����I��
            if (spdPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // �A�N�e�B�u�Z���̏����擾
            activeRow = spdPtn_Sheet1.ActiveRowIndex;
            activeCol = spdPtn_Sheet1.ActiveColumnIndex;

            // �X�܃p�^�[�����̂���������ɕێ�
            beforeTenpoPatternName = spdPtn_Sheet1.ActiveCell.Text;

            // �Z����ҏW�\�ɂ���
            spdPtn_Sheet1.ActiveCell.Locked = false;
            spdPtn.EditModeReplace = true;
            spdPtn.StartCellEditing(e, false);

            // �ҏW�t���O��true�ɐݒ�
            PtnReNameFlg = true;

            // �X�V�t���OON
            base.upchk = true;

            this.ActiveControl = null;

        }

        #endregion

        #region �Z���ړ�(�X�܃p�^�[��)

        /// <summary>
        /// �Z���ړ��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdPtn_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            // �ҏW���̏ꍇ�A�Z����ҏW�s�ɐݒ肷��B
            if (PtnReNameFlg)
            {
                // �󗓂̏ꍇ
                if (string.IsNullOrEmpty(spdPtn_Sheet1.Cells[activeRow, activeCol].Text.Trim()) == true)
                {
                    // �X�܃p�^�[�����̂�߂�
                    spdPtn_Sheet1.Cells[activeRow, activeCol].Text = beforeTenpoPatternName;
                }

                spdPtn_Sheet1.Cells[activeRow, activeCol].Locked = true;
                PtnReNameFlg = false;
            }
        }

        #endregion

        #region �I���s�ύX(�X�܃p�^�[��)

        /// <summary>
        /// �I���s�ύX(�X�܃p�^�[��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdPtn_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (spdTenpoPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            this.ChangeFilterValue();
        }

        #endregion

        #region ���{�^���N���b�N(�X�܃p�^�[�����ǉ�)

        /// <summary>
        /// ���{�^���N���b�N(�X�܃p�^�[�����ǉ�)
        /// �F�X�܃}�X�^�[�ꗗ�őI���������e�œX�܃p�^�[������ǉ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // �X�܃p�^�[���ꗗ����p�^�[���R�[�h���擾
            string patternCode = spdPtn_Sheet1.Cells[spdPtn_Sheet1.ActiveRowIndex, 11].Value.ToString();

            // �X�܃p�^�[�����}�X�^�[�擾
            MasterMaintenance.MasterDataVODataTable tmpPtnDt = (MasterMaintenance.MasterDataVODataTable)spdTenpoPtn.DataSource;

            // �X�܃}�X�^�[�̍s�����J��Ԃ�
            for (int i = 0; i < spdTenpoMas_Sheet1.Rows.Count; i++)
            {
                // �X�܃}�X�^�[�ꗗ�ōs�Ƀ`�F�b�N�������Ă���ꍇ
                if (spdTenpoMas_Sheet1.Cells[i, 0].Value.Equals(true))
                {
                    // �X�܃}�X�^�[�ꗗ����X�܃R�[�h�A�X�ܖ����擾
                    string tenpoCode = spdTenpoMas_Sheet1.Cells[i, 12].Value.ToString();
                    string tenpoName = spdTenpoMas_Sheet1.Cells[i, 13].Value.ToString();

                    // �X�܃p�^�[�����}�X�^�[�ɒǉ��Ώۂ̓X�܃R�[�h�����݂��Ȃ��ꍇ
                    if (tmpPtnDt.Select("Column2 = '" + tenpoCode + "' And Column3 = '" + patternCode + "'").Length == 0)
                    {
                        // �X�܃p�^�[�����}�X�^�[�ɒǉ�
                        tmpPtnDt.AddMasterDataVORow(
                            DateTime.Now,
                            C_APL_ID,
                            mstNavPrm.strEsqId,
                            DateTime.Now,
                            C_APL_ID,
                            mstNavPrm.strEsqId,
                            mstNavPrm.strEgcd,
                            mstNavPrm.strTksKgyCd,
                            mstNavPrm.strTksBmnSeqNo,
                            mstNavPrm.strTksTntSeqNo,
                            "105",
                            patternCode + tenpoCode,
                            tenpoCode,
                            patternCode,
                            tenpoName,
                            "0",
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            "True");

                        // �X�V�t���OON
                        base.upchk = true;
                    }
                }

                // �X�܃}�X�^�[�̃`�F�b�N���O��
                spdTenpoMas_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value = false;
            }

            // �ꗗ�ɓX�܃p�^�[�����}�X�^�[��ݒ�
            spdTenpoPtn.DataSource = tmpPtnDt;

            this.ChangeFilterValue();

            this.ActiveControl = null;
        }

        #endregion

        #region �X�܍i���{�^���N���b�N

        /// <summary>
        /// �X�܍i���{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNarrow_Click(object sender, EventArgs e)
        {
            // �X�܃}�X�^�[�Ƀ��R�[�h�����݂��Ȃ��ꍇ�A�����I��
            if (TenpoMasterVODataTable.Rows.Count == 0)
            {
                this.ActiveControl = null;

                return;
            }

            // �_�C�A���O�\��
            object result = Navigator.ShowModalForm(this, "tofrmMastMacNarrowDown", DialogParameter);

            // �߂�l���i�r�p�����[�^�̏ꍇ
            if (result is MastNarrowDownNaviParameter)
            {
                // �p�����[�^�擾
                DialogParameter = (MastNarrowDownNaviParameter)result;
            }
            else
            {
                this.ActiveControl = null;
                // �����I��
                return;
            }

            // �i�荞�ݏ����pStringBuilder�̃C���X�^���X����
            StringBuilder selectCondition = new StringBuilder();

            #region �X�܃R�[�h������ǉ�

            // �i�荞�ݏ����ɓX�܃R�[�h������ǉ�
            switch (DialogParameter.tenCdCmb)
            {
                case 0:
                    break;
                case 1:
                    // ���S��v
                    selectCondition.Append("Column1 = '" + DialogParameter.tenCd + "'");
                    break;
                case 2:
                    // �ȏ�
                    selectCondition.Append("Column1 >= '" + DialogParameter.tenCd + "'");
                    break;
                case 3:
                    // �ȉ�
                    selectCondition.Append("Column1 <= '" + DialogParameter.tenCd + "'");
                    break;
                case 4:
                    // �`
                    selectCondition.Append("Column1 >= '" + DialogParameter.tenCd + "' AND Column1 <= '" + DialogParameter.tenCd2 + "'");
                    break;
            }

            #endregion

            #region �e���g���[������ǉ�

            // �e���g���[�pStringBuilder�̃C���X�^���X����
            StringBuilder territoryCondition = new StringBuilder();

            // �֓����I������Ă���ꍇ
            if (DialogParameter.terKanto)
            {
                territoryCondition.Append("'1',");
                territoryCondition.Append("'�֓�',");
            }

            // �֐����I������Ă���ꍇ
            if (DialogParameter.terKansai)
            {
                territoryCondition.Append("'2',");
                territoryCondition.Append("'�֐�',");
            }

            // �������I������Ă���ꍇ
            if (DialogParameter.terTyuou)
            {
                territoryCondition.Append("'3',");
                territoryCondition.Append("'����',");
            }

            // ���̑����I������Ă���ꍇ
            if (DialogParameter.terSonota)
            {
                territoryCondition.Append("'4',");
                territoryCondition.Append("'���̑�',");
            }

            // ���̍i�荞�ݏ��������ɒǉ�����Ă���ꍇ
            if (selectCondition.Length != 0)
            {
                selectCondition.Append(" And ");
            }

            // �i�荞�ݏ����Ƀe���g���[������ǉ�
            selectCondition.Append("Column3 IN (" + territoryCondition.ToString(0, territoryCondition.Length - 1) + ")");

            #endregion

            #region �X�܋敪������ǉ�

            // �X�܋敪�pStringBuilder�̃C���X�^���X����
            StringBuilder tenpoKbnCondition = new StringBuilder();

            // �n��{�����I������Ă���ꍇ
            if (DialogParameter.kbnTikuhonbu)
            {
                tenpoKbnCondition.Append("'0',");
                tenpoKbnCondition.Append("'�n��{��',");
            }

            // MC���c�X���I������Ă���ꍇ
            if (DialogParameter.kbnMc)
            {
                tenpoKbnCondition.Append("'1',");
                tenpoKbnCondition.Append("'MC���c�X',");
            }

            // ���C�Z���V�[���I������Ă���ꍇ
            if (DialogParameter.kbnLicensee)
            {
                tenpoKbnCondition.Append("'2',");
                tenpoKbnCondition.Append("'���C�Z���V�[',");
            }

            // ���̑����I������Ă���ꍇ
            if (DialogParameter.kbnSonota)
            {
                tenpoKbnCondition.Append("'3',");
                tenpoKbnCondition.Append("'���̑�',");
            }

            // ���̍i�荞�ݏ��������ɒǉ�����Ă���ꍇ
            if (selectCondition.Length != 0)
            {
                selectCondition.Append(" And ");
            }

            // �i�荞�ݏ����ɓX�܋敪������ǉ�
            selectCondition.Append("Column4 IN (" + tenpoKbnCondition.ToString(0, tenpoKbnCondition.Length - 1) + ")");

            #endregion

            #region �X�ܖ�������ǉ�

            // �X�ܖ������݂���ꍇ
            if (string.IsNullOrEmpty(DialogParameter.tenName) == false)
            {
                // ���̍i�荞�ݏ��������ɒǉ�����Ă���ꍇ
                if (selectCondition.Length != 0)
                {
                    selectCondition.Append(" And ");
                }

                // �i�荞�ݏ����ɓX�܋敪������ǉ�
                selectCondition.Append("Column2 like '%" + DialogParameter.tenName + "%'");
            }

            #endregion

            // �X�܃}�X�^�[�pDataTable�̃C���X�^���X����
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();

            // �X�܃}�X�^�[�pDataTable�ɍi�荞�񂾃��R�[�h��ǉ�
            foreach (MasterMaintenance.MasterDataVORow arow in TenpoMasterVODataTable.Select(selectCondition.ToString()))
            {
                tenpoMasterDataTable.ImportRow(arow);
            }

            // �ꗗ�ɓX�܃}�X�^�[��ݒ�
            spdTenpoMas.DataSource = tenpoMasterDataTable;

            // �ꗗ�̕\���ݒ�
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);
            
            // �i�������{�^����\��
            btnLeave.Visible = true;

            this.ActiveControl = null;

        }

        #endregion

        #region �i�������{�^���N���b�N

        /// <summary>
        /// �i�������{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnLeave_Click(object sender, EventArgs e)
        {
            // �ꗗ�ɓX�܃}�X�^�[��ݒ�
            spdTenpoMas.DataSource = TenpoMasterVODataTable;

            // �ꗗ�̕\���ݒ�
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

            // �i�������{�^�����\��
            btnLeave.Visible = false;

            this.ActiveControl = null;

        }

        #endregion

        #region �X�V�{�^���N���b�N(�X�܃p�^�[���}�X�^�[)

        /// <summary>
        /// �X�V�{�^���N���b�N(�X�܃p�^�[���}�X�^�[)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateTenpoPattern_Click(object sender, EventArgs e)
        {
            // �m�F���b�Z�[�W�\�� 
            DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_C0005, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.YesNo);
            if (check == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            //�}�X�^�[�f�[�^�X�V 
            this.UpdateMasterTables();
            
            //�X�V�ς݃t���O
            base.upchk = false;

            this.ActiveControl = null;

        }

        #endregion

        #endregion

        #region "���\�b�h"

        #region �{�^���ݒ�(�X�܃}�X�^�[(�P�ꌟ��)�^�u)

        /// <summary>
        /// �{�^���ݒ�(�X�܃}�X�^�[(�P�ꌟ��)�^�u)
        /// �F�X�܃}�X�^�[(�P�ꌟ��)�^�u�I�����̃{�^���ݒ���s���B
        /// </summary>
        private void SetButtonPropertyTenpoMaster_FirstTab()
        {
            // �捞�{�^�����\��
            btnInputData.Visible = false;

            // �ĕ\���{�^�����\��
            btnRev.Visible = false;

            // �V�K�{�^��(�p��)���\��
            btnCrt.Visible = false;

            // �V�K�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)��\���E�g�p��
            btnNew.Visible = true;
            btnNew.Enabled = true;

            // �폜�{�^��(�p��)���\��
            btnDel.Visible = false;

            // �폜�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)��\���E�g�p�s��
            btnClr.Visible = true;
            btnClr.Enabled = false;

            // �X�V�{�^��(�p��)���\�� 
            btnUpd.Visible = false;

            // �X�V�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)��\���E�g�p��
            btnUpd2.Visible = true;
            btnUpd2.Enabled = true;

            // �X�V�{�^��(�X�܃p�^�[���}�X�^�[)���\��
            btnUpdateTenpoPattern.Visible = false;

            // �R�[�h�ϊ��{�^�����g�p�s��
            btnChgCode.Enabled = false;

            // 2012/02/01 add start H.Okazaki
            // �����{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)��\���E�g�p��
            btnTnpRrkS.Visible = true;
            btnTnpRrkS.Enabled = true;

            // �����{�^��(�X�܃}�X�^�[(�ꗗ����)�^�u)���\��
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki

        }

        #endregion

        #region �{�^���ݒ�(�X�܃}�X�^�[(�ꗗ�\��)�^�u)

        /// <summary>
        /// �{�^���ݒ�(�X�܃}�X�^�[(�ꗗ�\��)�^�u)
        /// �F�X�܃}�X�^�[(�ꗗ�\��)�^�u�I�����̃{�^���ݒ���s���B
        /// </summary>
        private void SetButtonPropertyTenpoMaster_SecondTab()
        {
            // �捞�{�^����\��
            btnInputData.Visible = true;
            btnInputData.Enabled = true;

            // �ĕ\���{�^����\��
            btnRev.Visible = true;
            btnRev.Enabled = true;

            // �V�K�{�^��(�p��)��\��
            btnCrt.Visible = true;
            btnCrt.Enabled = true;

            // �V�K�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnNew.Visible = false;

            // �폜�{�^��(�p��)��\��
            btnDel.Visible = true;
            btnDel.Enabled = true;

            // �폜�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnClr.Visible = false;

            // �X�V�{�^��(�p��)��\�� 
            btnUpd.Visible = true;
            btnUpd.Enabled = true;

            // �X�V�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnUpd2.Visible = false;

            // �X�V�{�^��(�X�܃p�^�[���}�X�^�[)���\��
            btnUpdateTenpoPattern.Visible = false;

            // 2012/02/01 add start H.Okazaki
            // �����{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnTnpRrkS.Visible = false;

            // �����{�^��(�X�܃}�X�^�[(�ꗗ����)�^�u)��\���E�g�p��
            btnTnpRrkA.Visible = true;
            btnTnpRrkA.Enabled = true;
            // 2012/02/01 add end H.Okazaki
        }

        #endregion

        #region �{�^���ݒ�(�X�܃p�^�[���}�X�^�[�I��)

        /// <summary>
        /// �{�^���ݒ�(�X�܃p�^�[���}�X�^�[�I��)
        /// �F�}�X�^�[���R���{�{�b�N�X�œX�܃p�^�[���}�X�^�[��I���������̃{�^���ݒ���s���B
        /// </summary>
        private void SetButtonPropertySelectTenpoPatternMaster()
        {
            // �捞�{�^�����\��
            btnInputData.Visible = false;

            // �ĕ\���{�^����\��
            btnRev.Visible = true;

            // �V�K�{�^��(�p��)��\���E�g�p�s��
            btnCrt.Visible = true;
            btnCrt.Enabled = false;

            // �V�K�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\�� 
            btnNew.Visible = false;

            // �폜�{�^��(�p��)��\���E�g�p�s�� 
            btnDel.Visible = true;
            btnDel.Enabled = false;

            // �폜�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\�� 
            btnClr.Visible = false;

            // �X�V�{�^��(�p��)���\�� 
            btnUpd.Visible = false;

            // �X�V�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\�� 
            btnUpd2.Visible = false;

            // �X�V�{�^��(�X�܃p�^�[���}�X�^�[)��\��
            btnUpdateTenpoPattern.Visible = true;

            // 2012/02/01 add start H.Okazaki
            // �����{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnTnpRrkS.Visible = false;

            // �����{�^��(�X�܃}�X�^�[(�ꗗ����)�^�u)���\��
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki
        }

        #endregion

        #region �{�^���ݒ�(���̑��}�X�^�[�I��)

        /// <summary>
        /// �{�^���ݒ�(���̑��}�X�^�[�I��)
        /// �F�}�X�^�[���R���{�{�b�N�X�œX�܃}�X�^�[�E�X�܃p�^�[���}�X�^�[�ȊO��I���������̃{�^���ݒ���s���B
        /// </summary>
        private void SetButtonPropertySelectOtherMaster()
        {
            // �捞�{�^�����\��
            btnInputData.Visible = false;

            // �ĕ\���{�^����\��
            btnRev.Visible = true;

            // �V�K�{�^��(�p��)��\���E�g�p��
            btnCrt.Visible = true;
            btnCrt.Enabled = true;

            // �V�K�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnNew.Visible = false;

            // �폜�{�^��(�p��)��\���E�g�p��
            btnDel.Visible = true;
            btnDel.Enabled = true;

            // �폜�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnClr.Visible = false;

            // �X�V�{�^��(�p��)��\�� 
            btnUpd.Visible = true;

            // �X�V�{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnUpd2.Visible = false;

            // �X�V�{�^��(�X�܃p�^�[���}�X�^�[)���\��
            btnUpdateTenpoPattern.Visible = false;

            // 2012/02/01 add start H.Okazaki
            // �����{�^��(�X�܃}�X�^�[(�P�ꌟ��)�^�u)���\��
            btnTnpRrkS.Visible = false;

            // �����{�^��(�X�܃}�X�^�[(�ꗗ����)�^�u)���\��
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki

        }

        #endregion

        #region ���͍��ڏ�����(�X�܃}�X�^�[(�P�ꌟ��)�^�u)

        /// <summary>
        /// ���͍��ڏ�����(�X�܃}�X�^�[(�P�ꌟ��)�^�u)
        /// �F�X�܃}�X�^�[(�P�ꌟ��)�^�u�̓��͍��ڂ�����������B
        /// </summary>
        /// <param name="isInitTenpoCode">�X�܃R�[�h�����������邩���ʂ���t���O</param>
        private void InitInputItemTenpoMaster_FirstTab(bool isInitTenpoCode)
        {
            // �R�[�h�ϊ����[�h�̏ꍇ
            if (IsChangeCodeMode == true)
            {
                // �R�[�h�ϊ���\���ݒ�i�����j
                this.AfterCodeChange(true);
            }

            // �X�܃R�[�h
            if (isInitTenpoCode == true)
            {
                txtTenpoCd.Text = string.Empty;
            }

            // �X�ܖ� 
            txtTenpoNm.Text = string.Empty;

            // �d�b�ԍ� 
            txtTelNo.Text = string.Empty;

            // �X�֔ԍ� 
            txtYubinNo.Text = string.Empty;

            // �Z���P 
            txtAddress1.Text = string.Empty;

            // �Z���Q 
            txtAddress2.Text = string.Empty;

            // ����Ȗ� 
            txtKamoku.Text = string.Empty;

            // ����G.OPEN�N����
            SGOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            SGOpen.Value = null;

            // G.OPEN�N����
            GOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GOpen.Value = null;

            // G.CLOSE�N����
            GClose.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GClose.Value = null;

            // ���C�Z���V�[�Ж� 
            txtCompanyNm.Text = string.Empty;

            // ��\�Җ� 
            txtName.Text = string.Empty;

            // �����R�[�h 
            txtTorihikisakiCd.Text = string.Empty;

            // �e���g���[ 
            rdbTerritory1.Checked = false;
            rdbTerritory2.Checked = false;
            rdbTerritory3.Checked = false;
            rdbTerritory4.Checked = false;

            // �X�܋敪 
            rdbTenpo1.Checked = false;
            rdbTenpo2.Checked = false;
            rdbTenpo3.Checked = false;
            rdbTenpo4.Checked = false;

            // ���׍s�t���O 
            rdbSplitFlg1.Checked = false;
            rdbSplitFlg2.Checked = false;

            // �ҏW���X�܃}�X�^�[�s������
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();
            rowTenpoMaster = tenpoMasterDataTable.NewMasterDataVORow();

            // �ύX�O�X�܃R�[�h
            beforeTenpoCd = string.Empty;

            // �ύX�O�폜�{�^���g�p��
            beforeDeleteButtonEnabled = false;

        }

        #endregion

        #region �X�܃}�X�^�[������\���ݒ�i�f�t�H���g�l�j

        /// <summary>
        /// �X�܃}�X�^�[������\���ݒ�i�f�t�H���g�l�j
        /// �F�X�܃}�X�^�[�P�ꌟ����̕\���ݒ���s���B
        /// </summary>
        private void AfterSearchTenpoMaster()
        {
            // �X�ܖ� 
            txtTenpoNm.Text = string.Empty;

            // �d�b�ԍ� 
            txtTelNo.Text = string.Empty;

            // �X�֔ԍ� 
            txtYubinNo.Text = string.Empty;

            // �Z���P 
            txtAddress1.Text = string.Empty;

            // �Z���Q 
            txtAddress2.Text = string.Empty;

            // ����Ȗ� 
            txtKamoku.Text = string.Empty;

            // ���C�Z���V�[�Ж� 
            txtCompanyNm.Text = string.Empty;

            // ��\�Җ� 
            txtName.Text = string.Empty;

            // �����R�[�h 
            txtTorihikisakiCd.Text = string.Empty;

            // �e���g���[�i�h�֓��h�I����ԁj 
            rdbTerritory1.Checked = true;

            // �X�܋敪�i�hMC���c�X�h�I����ԁj
            rdbTenpo2.Checked = true;

            // ���׍s�t���O�i�h�񕪊��h�I����ԁj 
            rdbSplitFlg2.Checked = true;

            // ����G.OPEN�N����
            SGOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            SGOpen.Value = null;

            // G.OPEN�N����
            GOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GOpen.Value = null;

            // G.CLOSE�N����
            GClose.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GClose.Value = null;

            // �R�[�h�ϊ��{�^���g�p�s�� 
            btnChgCode.Enabled = false;

            // �폜�{�^���g�p�s��
            btnClr.Enabled = false;
        }

        #endregion

        #region �X�܃}�X�^�[������\���ݒ�i�Y���f�[�^����j

        /// <summary>
        /// �X�܃}�X�^�[������\���ݒ�i�Y���f�[�^����j
        /// �F�X�܃}�X�^�[�P�ꌟ����̕\���ݒ���s���B
        /// </summary>
        /// <param name="rowData">�X�܃}�X�^�[�̃��R�[�h</param>
        private void AfterSearchTenpoMaster(MasterMaintenance.MasterDataVORow rowData)
        {
            // �X�ܖ� 
            txtTenpoNm.Text = rowData.Column2;

            // �d�b�ԍ� 
            txtTelNo.Text = rowData.Column9;

            // �X�֔ԍ� 
            txtYubinNo.Text = rowData.Column6;

            // �Z���P 
            txtAddress1.Text = rowData.Column7;

            // �Z���Q 
            txtAddress2.Text = rowData.Column8;

            // ����Ȗ� 
            txtKamoku.Text = rowData.Column5;

            // ���C�Z���V�[�Ж� 
            txtCompanyNm.Text = rowData.Column11;

            // ��\�Җ� 
            txtName.Text = rowData.Column12;

            // �����R�[�h 
            txtTorihikisakiCd.Text = rowData.Column13;

            // ����G.OPEN�N����
            if (rowData.Column15.Trim() != "")
            {
                SGOpen.Value = System.DateTime.Now;
                SGOpen.Text = rowData.Column15;
            }

            // G.OPEN�N����
            if (rowData.Column16.Trim() != "")
            {
                GOpen.Value = System.DateTime.Now;
                GOpen.Text = rowData.Column16;
            }

            // G.CLOSE�N����
            if (rowData.Column17.Trim() != "")
            {
                GClose.Value = System.DateTime.Now;
                GClose.Text = rowData.Column17;
            }
            // �e���g���[ 
            switch (rowData.Column3)
            {
                // �֓�
                case KKHMacConst.C_TERRITORY_CD1:
                    rdbTerritory1.Checked = true;
                    break;
                // �֐�
                case KKHMacConst.C_TERRITORY_CD2:
                    rdbTerritory2.Checked = true;
                    break;
                // ����
                case KKHMacConst.C_TERRITORY_CD3:
                    rdbTerritory3.Checked = true;
                    break;
                // ���̑�
                case KKHMacConst.C_TERRITORY_CD4:
                    rdbTerritory4.Checked = true;
                    break;
            }

            // �X�܋敪 
            switch (rowData.Column4)
            {
                // �n��{��
                case KKHMacConst.C_TENPO_KBN_CD1:
                    rdbTenpo1.Checked = true;
                    break;
                // MC���c�X
                case KKHMacConst.C_TENPO_KBN_CD2:
                    rdbTenpo2.Checked = true;
                    break;
                // ���C�Z���V�[
                case KKHMacConst.C_TENPO_KBN_CD3:
                    rdbTenpo3.Checked = true;
                    break;
                // ���̑�
                case KKHMacConst.C_TENPO_KBN_CD4:
                    rdbTenpo4.Checked = true;
                    break;
            }

            // ���׍s�t���O 
            switch (rowData.Column10)
            {
                // ��������
                case KKHMacConst.C_SPLIT_FLG_CD1:
                    rdbSplitFlg1.Checked = true;
                    break;
                // �������Ȃ�
                case KKHMacConst.C_SPLIT_FLG_CD2:
                    rdbSplitFlg2.Checked = true;
                    break;
            }

            // �R�[�h�ϊ��{�^���g�p�� 
            btnChgCode.Enabled = true;

            // �폜�{�^���g�p��
            btnClr.Enabled = true;
        }

        #endregion

        #region �X�܃}�X�^�[������\���ݒ�i�Y���f�[�^����j

        /// <summary>
        /// �X�ܗ���I����\���ݒ�
        /// �F�X�ܗ���I����̕\���ݒ���s���B
        /// </summary>
        /// <param name="rowData">�X�܃}�X�^�[�̃��R�[�h</param>
        private void AfterSelectTenpoRrk(DataTable dt)
        {
            MastDSMac.DisplayTenpoRrkRow rowData = (MastDSMac.DisplayTenpoRrkRow)dt.Rows[0];

            // �X�܃R�[�h��TextChanged�C�x���g�𖳌��ɂ���
            txtTenpoCd.TextChanged -= new System.EventHandler(this.txtTenpoCd_TextChanged);

            // �X�܃R�[�h
            txtTenpoCd.Text = rowData.tenpoCd;

            // �X�ܖ� 
            txtTenpoNm.Text = rowData.tenpoNm;

            // �d�b�ԍ� 
            txtTelNo.Text = rowData.telNo;

            // �X�֔ԍ� 
            txtYubinNo.Text = rowData.yubinNo;

            // �Z���P 
            txtAddress1.Text = rowData.address1;

            // �Z���Q 
            txtAddress2.Text = rowData.address2;

            // ����Ȗ� 
            txtKamoku.Text = rowData.kamoku;

            // ���C�Z���V�[�Ж� 
            txtCompanyNm.Text = rowData.companyNm;

            // ��\�Җ� 
            txtName.Text = rowData.name;

            // �����R�[�h 
            txtTorihikisakiCd.Text = rowData.torihikiCd;

            // ����G.OPEN�N����
            if (rowData.sGOpen.Trim() != "")
            {
                SGOpen.Value = System.DateTime.Now;
                SGOpen.Text = rowData.sGOpen;
            }

            // G.OPEN�N����
            if (rowData.gOpen.Trim() != "")
            {
                GOpen.Value = System.DateTime.Now;
                GOpen.Text = rowData.gOpen;
            }

            // G.CLOSE�N����
            if (rowData.gClose.Trim() != "")
            {
                GClose.Value = System.DateTime.Now;
                GClose.Text = rowData.gClose;
            }
            // �e���g���[ 
            switch (rowData.territory)
            {
                // �֓�
                case KKHMacConst.C_TERRITORY_CD1:
                    rdbTerritory1.Checked = true;
                    break;
                // �֐�
                case KKHMacConst.C_TERRITORY_CD2:
                    rdbTerritory2.Checked = true;
                    break;
                // ����
                case KKHMacConst.C_TERRITORY_CD3:
                    rdbTerritory3.Checked = true;
                    break;
                // ���̑�
                case KKHMacConst.C_TERRITORY_CD4:
                    rdbTerritory4.Checked = true;
                    break;
            }

            // �X�܋敪 
            switch (rowData.tenpoKbn)
            {
                // �n��{��
                case KKHMacConst.C_TENPO_KBN_CD1:
                    rdbTenpo1.Checked = true;
                    break;
                // MC���c�X
                case KKHMacConst.C_TENPO_KBN_CD2:
                    rdbTenpo2.Checked = true;
                    break;
                // ���C�Z���V�[
                case KKHMacConst.C_TENPO_KBN_CD3:
                    rdbTenpo3.Checked = true;
                    break;
                // ���̑�
                case KKHMacConst.C_TENPO_KBN_CD4:
                    rdbTenpo4.Checked = true;
                    break;
            }

            // ���׍s�t���O 
            switch (rowData.splitFlg)
            {
                // ��������
                case KKHMacConst.C_SPLIT_FLG_CD1:
                    rdbSplitFlg1.Checked = true;
                    break;
                // �������Ȃ�
                case KKHMacConst.C_SPLIT_FLG_CD2:
                    rdbSplitFlg2.Checked = true;
                    break;
            }

            // �R�[�h�ϊ��{�^���g�p�� 
            btnChgCode.Enabled = true;

            // �폜�{�^���g�p��
            btnClr.Enabled = true;

            // �X�܃R�[�h��TextChanged�C�x���g��L���ɂ���
            txtTenpoCd.TextChanged += new System.EventHandler(this.txtTenpoCd_TextChanged);

        #endregion
        }

        #region �R�[�h�ϊ��{�^���N���b�N��\���ݒ�

        /// <summary>
        /// �R�[�h�ϊ��{�^���N���b�N��\���ݒ�
        /// �F�R�[�h�ϊ��{�^�����N���b�N���ꂽ��̕\���ݒ���s���B
        /// </summary>
        /// <param name="enabledValue">��ʍ��ڂ֐ݒ肷��l</param>
        private void AfterCodeChange(bool enabledValue)
        {
            // ��ʍ��ڂւ̐ݒ�l��true�̏ꍇ
            if (enabledValue == true)
            {
                // �X�܃R�[�h�̔w�i�F�𔒂ɐݒ�
                txtTenpoCd.BackColor = Color.White;

                // �X�܃R�[�h�ύX���[�h������ 
                IsChangeCodeMode = false;
            }
            else
            {
                // �X�܃R�[�h�̔w�i�F��Ԃɐݒ�
                txtTenpoCd.BackColor = Color.Red;

                // �X�܃R�[�h�ύX���[�h�֐ݒ�
                IsChangeCodeMode = true;
            }

            // �X�ܖ� 
            lblTenpoNm.Enabled = enabledValue;
            txtTenpoNm.Enabled = enabledValue;

            // �d�b�ԍ� 
            lblTelNo.Enabled = enabledValue;
            txtTelNo.Enabled = enabledValue;

            // �X�֔ԍ� 
            lblYubinNo.Enabled = enabledValue;
            txtYubinNo.Enabled = enabledValue;

            // �Z���P 
            lblAddress1.Enabled = enabledValue;
            txtAddress1.Enabled = enabledValue;

            // �Z���Q 
            lblAddress2.Enabled = enabledValue;
            txtAddress2.Enabled = enabledValue;

            // ����Ȗ� 
            lblKamoku.Enabled = enabledValue;
            txtKamoku.Enabled = enabledValue;

            // ���C�Z���V�[ 
            grbLisence.Enabled = enabledValue;

            // �e���g���[ 
            grbTerritory.Enabled = enabledValue;

            // ����G.OPEN�N����
            SGOpen.Enabled = enabledValue;

            // G.OPEN�N����
            GOpen.Enabled = enabledValue;

            // G.CLOSE�N����
            GClose.Enabled = enabledValue;

            // �X�܋敪 
            grbTenpo.Enabled = enabledValue;

            // ���׍s�t���O 
            grbSplit.Enabled = enabledValue;

            // �P��V�K�{�^�� 
            btnNew.Enabled = enabledValue;
        }

        #endregion

        #region ���̓`�F�b�N�i�X�V�{�^���N���b�N���j

        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns>
        /// true    : ���̓`�F�b�NOK
        /// false   : ���̓`�F�b�NNG
        /// </returns>
        private bool InputCheck()
        {
            // �X�܃R�[�h�ϊ����[�h�łȂ��ꍇ
            if (IsChangeCodeMode == false)
            {
                // �X�܃R�[�h�A�X�ܖ��̕K�{�`�F�b�N
                if ((string.IsNullOrEmpty(txtTenpoCd.Text)) || (string.IsNullOrEmpty(txtTenpoNm.Text)))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0009, null, C_APL_NM, MessageBoxButtons.OK);
                    return false;
                }
            }

            // �X�܃R�[�h���U�������̏ꍇ
            if (txtTenpoCd.TextLength < 6)
            {
                // �G���[���b�Z�[�W��\��
                MessageUtility.ShowMessageBox(MessageCode.HB_W0010, null, C_APL_NM, MessageBoxButtons.OK);
                return false;
            }

            // G.CLOSE�N�����������͂̏ꍇ
            if (GClose.Value�@== null)
            {
                // �G���[���b�Z�[�W��\��
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "G.CLOSE�N����" }, C_APL_NM, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        #endregion

        #region �ΏۃV�[�g����

        /// <summary>
        /// �ΏۃV�[�g���� 
        /// </summary>
        /// <param name="inputDefi"></param>
        /// <param name="shs"></param>
        /// <returns></returns>
        private int getSheetIndex(KKHMacInputDataDefi inputDefi, Excel.Sheets shs)
        {
            int i = 0;
            foreach (Excel.Worksheet sh in shs)
            {
                // �V�[�g�̃Z��(1,1)��"�X��No"�̋L�ڂ����邩�ۂ� 
                if (((Excel.Range)sh.Cells[1, 1]).Text.ToString().Equals(inputDefi.strTenpoCd))
                {
                    // sheet�I�u�W�F�N�g��� 
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(shs);
                    // �L�ڂ�����ꍇ�A���Y�V�[�g��index��ԋp����B 
                    return i + 1;

                }
                i += 1;
            }
            // sheet�I�u�W�F�N�g��� 
            System.Runtime.InteropServices.Marshal.ReleaseComObject(shs);
            // �ΏۃV�[�g��������Ȃ��ꍇ�A0��ԋp 
            return 0;
        }

        #endregion

        #region �X�v���b�h�̐ݒ�

        /// <summary>
        /// �X�v���b�h�̐ݒ� 
        /// </summary>
        private void SpreadSetting(FarPoint.Win.Spread.FpSpread trgSpread, string trgMasterKey)
        {
            //�J���X�X�^�[�g�C���f�b�N�X 
            int ColIndex = 11;
            //�s�J�E���g 
            int RowCount = trgSpread.Sheets[0].Rows.Count;
            //�X�v���b�h������ 
            for (int j = 0; j < SpColNum; j++)
            {
                trgSpread.Sheets[0].Columns[j].Visible = false;
                trgSpread.Sheets[0].Columns[j].Label = null;
                trgSpread.Sheets[0].Columns[j].BackColor = Color.White;
            }

            MasterMaintenance.MasterItemVORow[] resultrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + trgMasterKey + "'");
            foreach (MasterMaintenance.MasterItemVORow row in resultrow)
            {
                //�� 
                trgSpread.Sheets[0].Columns[ColIndex].Label = row.field3;
                //�\�� 
                trgSpread.Sheets[0].Columns[ColIndex].Visible = true;
                //�� 
                trgSpread.Sheets[0].Columns[ColIndex].Width = float.Parse(row.field9);

                //******************
                //�Z�����̕����ʒu 
                //******************
                //�������� 
                trgSpread.Sheets[0].Columns[ColIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                //�������� 
                switch (row.field11)
                {
                    case "0"://�E�� 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        break;
                    case "1"://���� 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        break;
                    case "2"://������ 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        break;
                }

                //*************
                //�Z��Type 
                //*************
                switch (row.field5)
                {
                    //**********************
                    //     �e�L�X�g�^�C�v 
                    //**********************
                    case "0":
                        FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = txtyp;
                        //�ő啶���� 
                        if (!string.IsNullOrEmpty(row.field6))
                        {
                            txtyp.MaxLength = Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.field6);
                        }
                        //txtyp.MaxLength = int.Parse(row.field6);

                        //���p 
                        if (!string.IsNullOrEmpty(row.field15))
                        {
                            switch (row.field15)
                            {
                                case "1"://�p�����̂� 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    break;
                                case "2"://�����̂� 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    break;
                            }
                        }
                        break;

                    //**********************
                    //     ���l�^�C�v 
                    //********************** 
                    case "1":
                        FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = numtyp;

                        numtyp.DecimalPlaces = 0;

                        //�ő�l�A�ŏ��l�̐ݒ� 
                        if (!string.IsNullOrEmpty(row.field13))
                        {
                            numtyp.MaximumValue = long.Parse(row.field13);
                        }
                        if (!string.IsNullOrEmpty(row.field14))
                        {
                            numtyp.MinimumValue = long.Parse(row.field14);
                        }
                        break;

                    //**********************
                    //     �R���{�^�C�v 
                    //********************** 
                    case "2":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbtyp.Items = row.field20.Split(',');
                        cmbtyp.ItemData = row.field19.Split(',');
                        string[] nykfk = row.field18.Split(',');
                        bool flg = false;

                        for (int i = 0; i < RowCount; i++)
                        {
                            flg = false;
                            for (int k = 0; k < cmbtyp.Items.Length; k++)
                            {
                                //���̂̏ꍇ 
                                if (trgSpread.Sheets[0].Cells[i, ColIndex].Value.ToString() == cmbtyp.Items[k])
                                {
                                    //�R�[�h�ɕϊ����� 
                                    trgSpread.Sheets[0].Cells[i, ColIndex].Value = cmbtyp.ItemData[k];
                                }
                            }
                            for (int k = 0; k < cmbtyp.ItemData.Length; k++)
                            {
                                if (trgSpread.Sheets[0].Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[k]))
                                {
                                    trgSpread.Sheets[0].Cells[i, ColIndex].Text = cmbtyp.Items[k];
                                    //trgSpread.Sheets[0].Cells[i, ColIndex].Value = cmbtyp.Items[k];
                                    flg = true;
                                }
                            }

                            if (!flg) { trgSpread.Sheets[0].Cells[i, ColIndex].Value = '0'; }
                        }

                        //���͕s�Ώۂ����b�N���� 
                        if (row.field12.Equals("1"))
                        {
                            trgSpread.Sheets[0].Columns[ColIndex].BackColor = Color.Black;
                            trgSpread.Sheets[0].Columns[ColIndex].Locked = true;

                            //���͕s�ΏۊO���g�p�\�ɂ��� 
                            for (int n = 0; n < nykfk.Length; n++)
                            {
                                for (int j = 0; j < RowCount; j++)
                                {
                                    if (trgSpread.Sheets[0].Cells[j, (int)Math.Truncate(double.Parse(row.intValue1))].Value.Equals(nykfk[n]))
                                    {
                                        trgSpread.Sheets[0].Cells[j, ColIndex].BackColor = Color.White;
                                        trgSpread.Sheets[0].Cells[j, ColIndex].Locked = false;
                                    }
                                }
                            }

                        }

                        //�X�܃}�X�^�[���̂Ƃ���̓R���{�{�b�N�X�Ƀ^�C�v�ɂ��Ȃ� 
                        if (!trgSpread.Name.Trim().Equals("spdTenpoMas"))
                        {
                            //type�̕ϊ� 
                            trgSpread.Sheets[0].Columns[ColIndex].CellType = cmbtyp;
                        }
                        break;

                    //**************************
                    //  �`�F�b�N�{�b�N�X�^�C�v 
                    //**************************
                    case "3":
                        FarPoint.Win.Spread.CellType.CheckBoxCellType chktyp = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = chktyp;


                        for (int j = 0; j < RowCount; j++)
                        {
                            if (trgSpread.Sheets[0].Cells[j, ColIndex].Value.Equals("true"))
                            {
                                trgSpread.Sheets[0].Cells[j, ColIndex].Value = true;
                            }
                            else if (trgSpread.Sheets[0].Cells[j, ColIndex].Value.Equals("false"))
                            {
                                trgSpread.Sheets[0].Cells[j, ColIndex].Value = false;
                            }
                        }
                        break;

                    //**************************
                    //       ���t�^�C�v  
                    //**************************
                    case "4":
                        FarPoint.Win.Spread.CellType.DateTimeCellType datetyp = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                        for (int j = 0; j < RowCount; j++)
                        {
                            //�����񂩂�DateTime�^�֕ϊ�(YYYY/MM/DD�`��)  
                            trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Value
                                = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            //trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            trgSpread.Sheets[0].Columns[ColIndex].CellType = datetyp;
                        }
                        break;
                }

                //�\����\���̐؂�ւ� 
                double enableFlg = Math.Truncate(double.Parse(row.intValue2));
                switch (enableFlg.ToString())
                {
                    case "0":
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = false;
                        break;
                    case "1":
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = true;
                        break;
                    default:
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = false;
                        break;
                }
                if (KKHMacConst.C_MAST_TENPO_CD.Equals(trgMasterKey))
                {
                    trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                }
                if (KKHMacConst.C_MAST_TENPO_PTN_CD.Equals(trgMasterKey))
                {
                    trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                }
                if (KKHMacConst.C_MAST_TENPO_PTN_DT_CD.Equals(trgMasterKey))
                {
                    if (row.field3.Equals("����"))
                    {
                        trgSpread.Sheets[0].Columns[ColIndex].Locked = false;
                    }
                    else
                    {
                        trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                    }
                }
                ColIndex++;
            }

            if (KKHMacConst.C_MAST_TENPO_CD.Equals(trgMasterKey))
            {
                trgSpread.Sheets[0].Columns.Add(0, 1);
                trgSpread.Sheets[0].Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                trgSpread.Sheets[0].Columns[0].Label = " ";
                trgSpread.Sheets[0].Columns[0].Width = 20;
                trgSpread.Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                for (int x = 0; x < trgSpread.Sheets[0].Rows.Count; x++)
                {
                    trgSpread.Sheets[0].Cells[x, 0].Value = false;
                }
            }

            // �X�܃p�^�[�����}�X�^�[�̏ꍇ
            if (KKHMacConst.C_MAST_TENPO_PTN_DT_CD.Equals(trgMasterKey))
            {
                // �ŏI��Column30�̏ꍇ
                if (trgSpread.Sheets[0].Columns[40].Label == "Column30")
                {
                    // �`�F�b�N�{�b�N�X�Ƃ��ĕ\������ׁA��̐擪�Ɉړ�
                    trgSpread.Sheets[0].MoveColumn(40, 0, false);

                    // �Z���^�C�v���`�F�b�N�{�b�N�X�ɕύX
                    trgSpread.Sheets[0].Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                    // �w�b�_�[���x����ύX�iColumn30 �� " "�j
                    trgSpread.Sheets[0].Columns[0].Label = " ";

                    // �Z���̕��ݒ�
                    trgSpread.Sheets[0].Columns[0].Width = 20;

                    // �\���ʒu�ݒ�
                    trgSpread.Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                    // �Z����\��
                    trgSpread.Sheets[0].Columns[0].Visible = true;

                    // �X�܃p�^�[�����}�X�^�[�̃t�B���^�[��ݒ�
                    trgSpread.Sheets[0].Columns[C_FILTER_COLINDEX].AllowAutoFilter = true;
                }
            }
        }

        #endregion

        #region �p�^�[���R�[�h�擾����

        /// <summary>
        /// �p�^�[���R�[�h�擾����
        /// �F�X�܃p�^�[���ŋ󂢂Ă���p�^�[���R�[�h���擾����
        /// </summary>
        /// <param name="patternData">�X�܃p�^�[�����</param>
        /// <returns></returns>
        private int GetPatternCode(MasterMaintenance.MasterDataVODataTable patternData)
        {
            int rowCounter = 1;         // �s�J�E���^�[
            int returnValue = 0;        // �߂�l

            foreach (MasterMaintenance.MasterDataVORow patternDataRow in patternData.Rows)
            {
                // �s�J�E���^�[���p�^�[���R�[�h�̕����傫���ꍇ
                if (rowCounter < int.Parse(patternDataRow.Column1))
                {
                    // �߂�l�ɍs�J�E���^�[�̒l��ݒ�
                    returnValue = rowCounter;
                    break;
                }
                rowCounter++;
            }

            return returnValue;
        }

        #endregion

        #region �X�܃p�^�[���}�X�^�[�����\��

        /// <summary>
        /// �X�܃p�^�[���}�X�^�[�����\��
        /// </summary>
        private void InitTenpoPatternMaster()
        {
            // DB�A�N�Z�X�pController�̃C���X�^���X�擾
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();

            #region �X�܃p�^�[�����ꗗ�̏�����

            // �擪�񂪃`�F�b�N�{�b�N�X�iColumn30�j�̏ꍇ
            if (spdTenpoPtn_Sheet1.Columns[0].Label == " ")
            {
                // �t�B���^�[���Z�b�g
                spdTenpoPtn_Sheet1.AutoFilterReset(C_FILTER_COLINDEX);

                // �I�[�g�t�B���^�[����
                spdTenpoPtn_Sheet1.Columns[C_FILTER_COLINDEX].AllowAutoFilter = false;

                // �w�b�_�[���ύX�i" " �� Column30�j
                spdTenpoPtn_Sheet1.Columns[0].Label = "Column30";

                // �ŏI��ֈړ�
                spdTenpoPtn_Sheet1.MoveColumn(0, 40, false);
            }

            #endregion

            #region �X�܃}�X�^�[�擾�E�ꗗ�\��

            // �X�܃}�X�^�[�擾
            FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                  mstNavPrm.strEgcd,
                                                                                                                  mstNavPrm.strTksKgyCd,
                                                                                                                  mstNavPrm.strTksBmnSeqNo,
                                                                                                                  mstNavPrm.strTksTntSeqNo,
                                                                                                                  KKHMacConst.C_MAST_TENPO_CD,
                                                                                                                  null);
            // �ꗗ�ɓX�܃}�X�^�[��ݒ�
            spdTenpoMas.DataSource = result.MasterDataSet.MasterDataVO;

            // �����o�ϐ��Ɋi�[
            TenpoMasterVODataTable.Clear();
            foreach (MasterMaintenance.MasterDataVORow addRow in result.MasterDataSet.MasterDataVO.Rows)
            {
                TenpoMasterVODataTable.ImportRow(addRow);
            }

            // �ꗗ�̕\���ݒ�
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

            #endregion

            #region �X�܃p�^�[�����}�X�^�[�擾�E�ꗗ�\��

            // �X�܃p�^�[�����}�X�^�[�擾
            result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                         mstNavPrm.strEgcd,
                                                                         mstNavPrm.strTksKgyCd,
                                                                         mstNavPrm.strTksBmnSeqNo,
                                                                         mstNavPrm.strTksTntSeqNo,
                                                                         KKHMacConst.C_MAST_TENPO_PTN_DT_CD,
                                                                         null);

            // �X�܃p�^�[�����ꗗ�ݒ�pDataTable�̃C���X�^���X����
            MasterMaintenance.MasterDataVODataTable TenpoPatternInfoVODataTable = new MasterMaintenance.MasterDataVODataTable();

            // �X�܃}�X�^�[����X�ܖ��̂��擾�A�ꗗ�ݒ�pDataTable�֊i�[����
            foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                // �X�܃p�^�[�����}�X�^�[�̓X�܃R�[�h�ɊY�����郌�R�[�h��X�܃}�X�^�[����擾
                MasterMaintenance.MasterDataVORow[] TenpoMasterVORows = (MasterMaintenance.MasterDataVORow[])(TenpoMasterVODataTable.Select("Column1 = '" + row.Column2 + "'"));

                // �X�ܖ��́A�s�`�F�b�N�l�ݒ�
                string tenpoName = string.Empty;
                bool checkRow = false;
                if (TenpoMasterVORows.Length > 0)
                {
                    tenpoName = TenpoMasterVORows[0].Column2;
                    checkRow = true;
                }

                // �ꗗ�ݒ�pDataTable�֊i�[����
                // �� ������Column30�ɍs�`�F�b�N�l��ݒ肷�邪�A�\���p�Ƃ��ė��p���邾���BDB�X�V���ɂ�Null�ōX�V����B
                TenpoPatternInfoVODataTable.AddMasterDataVORow(row.trkTimStmp,
                                                               row.trkPl,
                                                               row.trkTnt,
                                                               row.updTimStmp,
                                                               row.updaPl,
                                                               row.updTnt,
                                                               row.egCd,
                                                               row.tksKgyCd,
                                                               row.tksBmnSeqNo,
                                                               row.tksTntSeqNo,
                                                               row.sybt,
                                                               row.Column1,
                                                               row.Column2,
                                                               row.Column3,
                                                               tenpoName,
                                                               row.Column5,
                                                               row.Column6,
                                                               row.Column7,
                                                               row.Column8,
                                                               row.Column9,
                                                               row.Column10,
                                                               row.Column11,
                                                               row.Column12,
                                                               row.Column13,
                                                               row.Column14,
                                                               row.Column15,
                                                               row.Column16,
                                                               row.Column17,
                                                               row.Column18,
                                                               row.Column19,
                                                               row.Column20,
                                                               row.Column21,
                                                               row.Column22,
                                                               row.Column23,
                                                               row.Column24,
                                                               row.Column25,
                                                               row.Column26,
                                                               row.Column27,
                                                               row.Column28,
                                                               row.Column29,
                                                               checkRow.ToString());
            }

            // �ꗗ�ɓX�܃p�^�[�����}�X�^�[��ݒ�
            spdTenpoPtn.DataSource = TenpoPatternInfoVODataTable;

            // �ꗗ�̕\���ݒ�
            SpreadSetting(spdTenpoPtn, KKHMacConst.C_MAST_TENPO_PTN_DT_CD);

            #endregion

            #region �X�܃p�^�[���}�X�^�[�擾�E�ꗗ�\��

            // �X�܃p�^�[���}�X�^�[�擾
            result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                         mstNavPrm.strEgcd,
                                                                         mstNavPrm.strTksKgyCd,
                                                                         mstNavPrm.strTksBmnSeqNo,
                                                                         mstNavPrm.strTksTntSeqNo,
                                                                         KKHMacConst.C_MAST_TENPO_PTN_CD,
                                                                         null);
            // �ꗗ�ɓX�܃p�^�[���}�X�^�[��ݒ�
            spdPtn.DataSource = result.MasterDataSet.MasterDataVO;

            // �ꗗ�̕\���ݒ�
            SpreadSetting(spdPtn, KKHMacConst.C_MAST_TENPO_PTN_CD);

            // �^�C���X�^���v�擾
            base.updateMaxfind(result);

            #endregion

            // �X�܃p�^�[���ꗗ�ɍs����΁A�擪�s�̃p�^�[�������A�N�e�B�u�ɂ���
            if (spdPtn_Sheet1.Rows.Count > 0)
            {
                spdPtn_Sheet1.SetActiveCell(0, 12);
            }

            // �X�܃p�^�[�����ꗗ�ɍs���Ȃ��ꍇ�A�����I��
            if (spdTenpoPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // �t�B���^�[�l�ݒ�
            if (spdTenpoPtn_Sheet1.Columns[C_FILTER_COLINDEX].AllowAutoFilter == true)
            {
                this.ChangeFilterValue();
            }
        }

        #endregion

        #region �t�B���^�[�l�ݒ�

        /// <summary>
        /// �X�܃p�^�[�����}�X�^�[�Ƀt�B���^�[�l��ݒ肷��
        /// </summary>
        private void ChangeFilterValue()
        {
            // �X�܃p�^�[���}�X�^�[�̃A�N�e�B�u�s���擾
            MasterMaintenance.MasterDataVODataTable tenpoPatternVODataTable = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;
            MasterMaintenance.MasterDataVORow tenpoPatternActiveRow = (MasterMaintenance.MasterDataVORow)tenpoPatternVODataTable.Rows[spdPtn_Sheet1.ActiveRowIndex];

            if (this.IsFilterItem(tenpoPatternActiveRow.Column1) == false)
            {
                for (int rowIndex = 0; rowIndex < spdTenpoPtn_Sheet1.Rows.Count; rowIndex++)
                {
                    spdTenpoPtn_Sheet1.SetRowHeight(rowIndex, 0);
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < spdTenpoPtn_Sheet1.Rows.Count; rowIndex++)
                {
                    spdTenpoPtn_Sheet1.SetRowHeight(rowIndex, 20);
                }

            }

            try
            {
                // �X�܃p�^�[�����}�X�^�[�̃t�B���^�[�ɓX�܃p�^�[���}�X�^�[�̃p�^�[���R�[�h��ݒ�
                spdTenpoPtn_Sheet1.AutoFilterColumn(C_FILTER_COLINDEX, tenpoPatternActiveRow.Column1, 0);

            }
            catch //(NullReferenceException ex)
            {
                return;
            }
        }

        #endregion

        #region �}�X�^�[�f�[�^�X�V

        /// <summary>
        /// �}�X�^�[�f�[�^�X�V 
        /// </summary>
        private void UpdateMasterTables()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �X�V�Ώۂ̓X�܃p�^�[���}�X�^�[���ꗗ����擾
            MasterMaintenance.MasterDataVODataTable patternMasterTable = (MasterMaintenance.MasterDataVODataTable)spdPtn_Sheet1.DataSource;

            // �ꗗ����X�܃p�^�[�����}�X�^�[�擾
            MasterMaintenance.MasterDataVODataTable spreadPatternInfoTable = (MasterMaintenance.MasterDataVODataTable)spdTenpoPtn_Sheet1.DataSource;

            // �X�V�Ώۂ̓X�܃p�^�[�����}�X�^�[���i�[����DataTable�̃C���X�^���X����
            MasterMaintenance.MasterDataVODataTable patternInfoTable = new MasterMaintenance.MasterDataVODataTable();

            // �ꗗ�̍s�����J��Ԃ�
            foreach (MasterMaintenance.MasterDataVORow dataRow in spreadPatternInfoTable.Rows)
            {
                // �ꗗ�Ń`�F�b�N����Ă���ꍇ
                if (dataRow.Column30 == "True")
                {
                    // �X�V�ΏۂƂ���DataTable�ɒǉ�
                    MasterMaintenance.MasterDataVORow addRow = patternInfoTable.NewMasterDataVORow();

                    addRow.trkTimStmp = dataRow.trkTimStmp;
                    addRow.trkPl = dataRow.trkPl;
                    addRow.trkTnt = dataRow.trkTnt;
                    addRow.updTimStmp = dataRow.updTimStmp;
                    addRow.updaPl = dataRow.updaPl;
                    addRow.updTnt = dataRow.updTnt;
                    addRow.egCd = dataRow.egCd;
                    addRow.tksKgyCd = dataRow.tksKgyCd;
                    addRow.tksBmnSeqNo = dataRow.tksBmnSeqNo;
                    addRow.tksTntSeqNo = dataRow.tksTntSeqNo;
                    addRow.sybt = dataRow.sybt;
                    addRow.Column1 = dataRow.Column1;
                    addRow.Column2 = dataRow.Column2;
                    addRow.Column3 = dataRow.Column3;
                    addRow.Column4 = string.Empty;
                    addRow.Column5 = dataRow.Column5;
                    addRow.Column6 = null;
                    addRow.Column7 = null;
                    addRow.Column8 = null;
                    addRow.Column9 = null;
                    addRow.Column10 = null;
                    addRow.Column11 = null;
                    addRow.Column12 = null;
                    addRow.Column13 = null;
                    addRow.Column14 = null;
                    addRow.Column15 = null;
                    addRow.Column16 = null;
                    addRow.Column17 = null;
                    addRow.Column18 = null;
                    addRow.Column19 = null;
                    addRow.Column20 = null;
                    addRow.Column21 = null;
                    addRow.Column22 = null;
                    addRow.Column23 = null;
                    addRow.Column24 = null;
                    addRow.Column25 = null;
                    addRow.Column26 = null;
                    addRow.Column27 = null;
                    addRow.Column28 = null;
                    addRow.Column29 = null;
                    addRow.Column30 = null;

                    patternInfoTable.AddMasterDataVORow(addRow);
                }
            }

            // �K�{�`�F�b�N
            if (this.CheckDataPattern(patternMasterTable) == false)
            {
                //���[�f�B���O�\���I��   
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "�G���[", MessageBoxButtons.OK);
                return;
            }
            if (this.CheckDataPatternInfo(patternInfoTable) == false)
            {
                //���[�f�B���O�\���I��   
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "�G���[", MessageBoxButtons.OK);
                return;
            }


            // DB�A�N�Z�X�pController�̃C���X�^���X�擾
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            // �X�V����
            RegisterMasterServiceResult result = processController.RegisterMasterTablesResult(mstNavPrm.strEsqId,
                                                                                                          mstNavPrm.AplId,
                                                                                                          mstNavPrm.strEgcd,
                                                                                                          mstNavPrm.strTksKgyCd,
                                                                                                          mstNavPrm.strTksBmnSeqNo,
                                                                                                          mstNavPrm.strTksTntSeqNo,
                                                                                                          mstNavPrm.strMasterKey,
                                                                                                          KKHMacConst.C_MAST_TENPO_PTN_DT_CD,
                                                                                                          mstNavPrm.strFilterValue,
                                                                                                          patternMasterTable,
                                                                                                          patternInfoTable,
                                                                                                          maxupdate);

            // �X�V�����ŃG���[�����������ꍇ
            if (result.HasError)
            {
                //���[�f�B���O�\���I��   
                base.CloseLoadingDialog();

                String[] message = result.Note;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0095, message, "�X�V", MessageBoxButtons.OK);

                return;
            }

            // �X�܃}�X�^�[���������i�ēǂݍ��݁j
            this.InitTenpoPatternMaster();

            //���[�f�B���O�\���I��   
            base.CloseLoadingDialog();

            // �������b�Z�[�W�\��
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "����", MessageBoxButtons.OK);
        }

        #endregion

        #region �t�B���^�[���ڃ`�F�b�N

        /// <summary>
        /// �t�B���^�[���ڃ`�F�b�N
        /// �F�p�����[�^���ꗗ�̃t�B���^�[���ڂ��m�F����
        /// </summary>
        /// <param name="filterString">�Ώە�����</param>
        /// <returns>
        /// true    : �t�B���^�[����
        /// false   : �t�B���^�[���ڂłȂ�
        /// </returns>
        private bool IsFilterItem(string filterString)
        {
            ArrayList filter = spdTenpoPtn_Sheet1.GetDropDownFilterItems(C_FILTER_COLINDEX);

            if (filter == null)
            {
                return false;
            }

            foreach (string filterItem in spdTenpoPtn_Sheet1.GetDropDownFilterItems(C_FILTER_COLINDEX))
            {
                if (filterItem == filterString)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region �K�{�`�F�b�N

        /// <summary>
        /// �K�{�`�F�b�N(�X�܃p�^�[���}�X�^�[)
        /// </summary>
        /// <param name="dataTable">�X�܃p�^�[���}�X�^�[</param>
        /// <returns>
        /// true    : �`�F�b�NOK
        /// false   : �`�F�b�NNG
        /// </returns>
        private bool CheckDataPattern(MasterMaintenance.MasterDataVODataTable dataTable)
        {
            // �s�����J��Ԃ�
            foreach (MasterMaintenance.MasterDataVORow dataRow in dataTable.Rows)
            {
                // Column1(�p�^�[���R�[�h)
                if (string.IsNullOrEmpty(dataRow.Column1) == true)
                {
                    return false;
                }
                // Column2(�p�^�[����)
                if (string.IsNullOrEmpty(dataRow.Column2) == true)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �K�{�`�F�b�N(�X�܃p�^�[�����}�X�^�[)
        /// </summary>
        /// <param name="dataTable">�X�܃p�^�[�����}�X�^�[</param>
        /// <returns>
        /// true    : �`�F�b�NOK
        /// false   : �`�F�b�NNG
        /// </returns>
        private bool CheckDataPatternInfo(MasterMaintenance.MasterDataVODataTable dataTable)
        {
            // �s�����J��Ԃ�
            foreach (MasterMaintenance.MasterDataVORow dataRow in dataTable.Rows)
            {
                // Column1(�X�܃p�^�[���R�[�h)
                if (string.IsNullOrEmpty(dataRow.Column1) == true)
                {
                    return false;
                }
                // Column2(�X�܃R�[�h)
                if (string.IsNullOrEmpty(dataRow.Column2) == true)
                {
                    return false;
                }
                // Column3(�p�^�[���R�[�h)
                if (string.IsNullOrEmpty(dataRow.Column3) == true)
                {
                    return false;
                }
                // Column5(����)
                if (string.IsNullOrEmpty(dataRow.Column5) == true)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// �K�{���ړ��̓`�F�b�N 
        /// </summary>
        /// <returns></returns>
        protected override bool NrChk(ref string col)
        {           
            // �^�u��2�\������Ă��Ȃ��ꍇ�A�����I��
            if (tbcMasterMainte.TabPages.Count != 2)
            {
                MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");
                foreach (MasterMaintenance.MasterItemVORow row in itemrow)
                {
                    if (row.field8.Equals("1"))
                    {
                        for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                        {
                            if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text))
                            {
                                col = row.field3.Trim();
                                return false;
                            }


                        }
                    }
                }
            }
            else
            {
                // �X�܃}�X�^�[(�P�ꌟ��) 
                if (tbcMasterMainte.SelectedIndex == 0)
                {
                }
                // �X�܃}�X�^�[(�ꗗ�\��)
                else
                {
                    MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");
                    foreach (MasterMaintenance.MasterItemVORow row in itemrow)
                    {
                        if (row.field8.Equals("1"))
                        {
                            if (int.Parse(row.field2) < 26)
                            {
                                //����G.OPEN�N�����܂ł̗��field2�̗���Q��
                                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                                {
                                    if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text))
                                    {
                                        col = row.field3.Trim();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                //����G.OPEN�N�����ȍ~�̗��field2+1�̗���Q��
                                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                                {
                                    if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2) - 1].Text))
                                    {
                                        col = row.field3.Trim();
                                        return false;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            //upchk = false;
            return true;

        }
        #endregion

        /// <summary>
        /// �X�܃}�X�^�[(�P�ꌟ��)�^�u��I�������ꍇ�̏��� 
        /// </summary>
        public void SelectedTempMstSnglSrchTab()
        {
            // �{�^���ݒ�
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // ���͍��ڏ�����
            this.InitInputItemTenpoMaster_FirstTab(true);

            // �}�X�^�[���R���{�{�b�N�X���\��
            cmbMasterName1.Visible = false;

            // �}�X�^�[�����x�����\��
            label2.Visible = false;

            // �ϐ�������
            beforeTenpoCd = string.Empty;
            beforeDeleteButtonEnabled = false;
            IsChangeCodeMode = false;
        }

        /// <summary>
        /// �X�܃}�X�^�[(�ꗗ)�^�u��I�������ꍇ�̏��� 
        /// </summary>
        public void SelectedTempMstListTab()
        {
            // �{�^���ݒ�
            this.SetButtonPropertyTenpoMaster_SecondTab();

            // �}�X�^�[���R���{�{�b�N�X��\��
            cmbMasterName1.Visible = true;

            // �}�X�^�[�����x����\��
            label2.Visible = true;

            // �X�܃p�^�[���}�X�^�[�p�O���[�v�{�b�N�X���\��
            grbTenpoPtn.Visible = false;

            // api�i��Filter��null��ݒ�
            mstNavPrm.strFilterValue = null;
        }

        #endregion
    }
}


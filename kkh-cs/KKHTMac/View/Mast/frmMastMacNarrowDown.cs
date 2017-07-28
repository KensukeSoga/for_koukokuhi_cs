using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Mac.View.Mast
{
    public partial class frmMastMacNarrowDown : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region "�����o�ϐ�"
        /// <summary>
        /// �i�r�p�����[�^�[
        /// </summary>
        private MastNarrowDownNaviParameter _naviParam = new MastNarrowDownNaviParameter();
        #endregion "�����o�ϐ�"

        #region "�R���X�g���N�^"
        public frmMastMacNarrowDown()
        {
            InitializeComponent();
        }
        #endregion "�R���X�g���N�^"

        #region "�C�x���g"

        /// <summary>
        /// ��ʑJ�ڎ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastMacNarrowDown_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is MastNarrowDownNaviParameter)
            {
                _naviParam = (MastNarrowDownNaviParameter)arg.NaviParameter;
            }

            //�����\����"���S�Ɉ�v"
            cmbCd.SelectedIndex = 0;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastMacNarrowDown_Load(object sender, EventArgs e)
        {
            //�X�܃R�[�h�����݂����ꍇ�ȑO���̉�ʂɑJ�ڂ����Ɣ��f����
            if (!string.IsNullOrEmpty(_naviParam.tenCd) || !string.IsNullOrEmpty(_naviParam.tenName))
            {
                tenCdTxt.Text = _naviParam.tenCd;
                tenNmTxt.Text = _naviParam.tenName;
                cmbCd.SelectedIndex = _naviParam.tenCdCmb;
                chkKanto.Checked = _naviParam.terKanto;
                chkKansai.Checked = _naviParam.terKansai;
                chkTyuo.Checked = _naviParam.terTyuou;
                chkTerSonota.Checked = _naviParam.terSonota;
                chkTikuhonbu.Checked = _naviParam.kbnTikuhonbu;
                chkMc.Checked = _naviParam.kbnMc;
                chkLicensee.Checked = _naviParam.kbnLicensee;
                chkKbnSonota.Checked = _naviParam.kbnSonota;
                tenCd2Txt.Text = _naviParam.tenCd2;

            }
        }

        /// <summary>
        /// OK�{�^��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Okbtn_Click(object sender, EventArgs e)
        {
            //���̓`�F�b�N 
            if (!oKBtnCheck())
            {
                this.ActiveControl = null;
                return;
            }

            // �i�r�p�����[�^�̃C���X�^���X����
            MastNarrowDownNaviParameter naviparam = new MastNarrowDownNaviParameter();

            naviparam.tenCd = this.tenCdTxt.Text;           //�X�܃R�[�h
            naviparam.tenCd2 = tenCd2Txt.Text;              //�X�܃R�[�h2   
            naviparam.tenCdCmb = cmbCd.SelectedIndex;       //�X�܃R�[�h�̃R���{
            naviparam.tenName = tenNmTxt.Text;              //�X�ܖ�
            naviparam.terKanto = chkKanto.Checked;          //�֓�
            naviparam.terKansai = chkKansai.Checked;        //�֐�
            naviparam.terTyuou = chkTyuo.Checked;           //����
            naviparam.terSonota = chkTerSonota.Checked;     //�e���g���[���̑�
            naviparam.kbnTikuhonbu = chkTikuhonbu.Checked;  //�n��敪
            naviparam.kbnMc = chkMc.Checked;                //MC���c�X
            naviparam.kbnLicensee = chkLicensee.Checked;    //���C�Z���V�[
            naviparam.kbnSonota = chkKbnSonota.Checked;     //�n��敪���̑�

            Navigator.Backward(this, naviparam, null, true);
            this.Close();
        }

        /// <summary>
        /// �L�����Z���{�^��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// �e���g���[�`�F���W�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkteri_CheckedChanged(object sender, EventArgs e)
        {
            //�`�F�b�N�����邩�̃t���O
            bool ChckFlg = false;
            
            if (chkKanto.Checked)//�֓�
            {
                ChckFlg = true;
            }
            else if (chkKansai.Checked)//�֐�
            {
                ChckFlg = true;
            }
            else if (chkTyuo.Checked)//����
            {
                ChckFlg = true;
            }
            else if (chkTerSonota.Checked)//���̑�
            {
                ChckFlg = true;
            }

            if (ChckFlg)
            {
                return;
            }
            //�I������Ă���e���g���[���̂��擾
            string tiku = ((System.Windows.Forms.ButtonBase)(sender)).Text;

            switch (tiku)
            {
                case "�֓�":
                    chkKanto.Checked = true;
                    break;
                case "�֐�":
                    chkKansai.Checked = true;
                    break;
                case "����":
                    chkTyuo.Checked = true;
                    break;
                case "���̑�":
                    chkTerSonota.Checked = true;
                    break;
            }

        }
     
        /// <summary>
        /// �X�܋敪�`�F���W�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTenKbn_CheckedChanged(object sender, EventArgs e)
        {
            //�`�F�b�N�����邩�̃t���O
            bool ChckFlg = false;

            if (chkTikuhonbu.Checked)
            {
                ChckFlg = true;
            }
            else if (chkMc.Checked)
            {
                ChckFlg = true;
            }
            else if (chkLicensee.Checked)
            {
                ChckFlg = true;
            }
            else if (chkKbnSonota.Checked)
            {
                ChckFlg = true;
            }

            if (ChckFlg)
            {
                //�`�F�b�N������ꍇreturn
                return;
            }
            //�I������Ă���敪���̂��擾
            string Kbn = ((System.Windows.Forms.ButtonBase)(sender)).Text;

            switch (Kbn)
            {
                case "�n��{��":
                    chkTikuhonbu.Checked = true;
                    break;
                case "MC���c�X":
                    chkMc.Checked = true;
                    break;
                case "���C�Z���V�[":
                    chkLicensee.Checked = true;
                    break;
                case "���̑�":
                    chkKbnSonota.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// �X�܃R�[�h�R���{�{�b�N�X�`�F���W�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCd.SelectedIndex != 4)
            {
                tenCd2Txt.Visible = false;
                betweenLabel.Visible = false;
                return;
            }

            tenCd2Txt.Visible = true;
            betweenLabel.Visible = true;
            
        }

        #endregion "�C�x���g"

        # region ���\�b�h

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean oKBtnCheck()
        {
            // �i�荞�ݏ������I������Ă��Ȃ��ꍇ
            if (cmbCd.SelectedIndex == 0)
            {
                // �X�܃R�[�h�����͂���Ă���ꍇ
                if (!string.IsNullOrEmpty(this.tenCdTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0130, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                    return false;
                }

                // �X�ܖ������͂���Ă��Ȃ��ꍇ
                if (string.IsNullOrEmpty(tenNmTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0131, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                // �X�܃R�[�h�����͂���Ă��Ȃ��ꍇ
                if (string.IsNullOrEmpty(this.tenCdTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                    return false;
                }
                else if (this.tenCdTxt.Text.Length != 6)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0129, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                    return false;
                }

                // �i�荞�ݏ����Łu�`�v���I������Ă���ꍇ
                if (cmbCd.SelectedIndex == 4)
                {
                    // �X�܃R�[�h
                    if (string.IsNullOrEmpty(tenCd2Txt.Text))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                        return false;
                    }                    
                    else if (this.tenCd2Txt.Text.Length != 6)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0129, null, "�}�X�^�[�����e�i���X", MessageBoxButtons.OK);
                        return false;
                    }

                }
            }

            return true;
        }

        # endregion ���\�b�h

    }
}


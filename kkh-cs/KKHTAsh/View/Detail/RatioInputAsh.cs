using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility;
using System.Collections.Specialized;
using System.Collections;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// �䗦���͉��.
    /// </summary>
    public partial class RatioInputAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �萔.
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �󒍃f�[�^.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// ���͖��׃X�v���b�h.
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �ꊇ�����t���O.
        /// </summary>
        private System.Boolean _blnAll = false;
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public RatioInputAsh()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^.

        #region �C�x���g.
        #region ��ʑJ�ڎ��ɔ���.
        /// <summary>
        /// ��ʑJ�ڎ��ɔ���.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void RatioInputAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRow;
                _spdDetailInput_Sheet1 = _naviParam.SpdDetailInput_Sheet1;
                if (_naviParam.IntValue1 == 1)
                {
                    //�ꊇ����.
                    _blnAll = true;
                }
                else
                {
                    //�䗦����.
                    _blnAll = false;
                }
                _naviParam.IntValue1 = 0;
            }
        }
        #endregion ��ʑJ�ڎ��ɔ���.

        #region �t�H�[�����[�h�C�x���g.
        /// <summary>
        /// �t�H�[�����[�h�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RatioInputAsh_Load(object sender, EventArgs e)
        {
            // �e�R���g���[���̏�����.
            InitializeControl();
        }
        #endregion �t�H�[�����[�h�C�x���g.

        #region OK�{�^���N���b�N�C�x���g.
        /// <summary>
        /// OK�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //���ӓ��̓`�F�b�N.
            if (decimal.Parse(txtRateLeft.Text.Trim()) <= 0)
            {
                //�G���[���b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0036, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                txtRateLeft.Focus();
                return;
            }

            //�E�ӓ��̓`�F�b�N.
            if (decimal.Parse(txtRateRight.Text.Trim()) <= 0)
            {
                //�G���[���b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0022, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                txtRateRight.Focus();
                return;
            }

            //���ד��̓X�v���b�h�̃A�N�e�B�u�s�̉���1�s�ǉ�����.
            CellRange[] cellRanges = _spdDetailInput_Sheet1.GetSelections();
            Hashtable htSelectCell = new Hashtable();
            ArrayList alRow = new ArrayList();

            //�ꊇ�����̏ꍇ.
            if (_blnAll)
            {
                htSelectCell.Add(0, _spdDetailInput_Sheet1.RowCount);
                alRow.Add(0);
            }
            //�䗦�����̏ꍇ.
            else
            {
                //�I�𒆂̃Z�������[�v����.
                foreach (CellRange cellRange in cellRanges)
                {
                    htSelectCell.Add(cellRange.Row, cellRange.RowCount);
                    alRow.Add(cellRange.Row);
                }

                //�~���ɕ��ёւ�.
                alRow.Sort();
                alRow.Reverse();
            }

            //�s�������[�v����.
            for (int j = 0; j < alRow.Count; j++)
            {
                //�I������Ă��閾�ׂ̍s�����̏������J��Ԃ�.
                for (int i = 0; i < KKHUtility.IntParse(htSelectCell[alRow[j]].ToString()); i++)
                {
                    //�����ݒ�.
                    int intRowIndex = KKHUtility.IntParse(alRow[j].ToString()) + i * 2;
                    _spdDetailInput_Sheet1.AddRows(intRowIndex + 1, 1);

                    //�f�[�^�̃R�s�[.
                    DefaultSheetDataModel DataModel = new DefaultSheetDataModel();
                    DataModel = (DefaultSheetDataModel)_spdDetailInput_Sheet1.Models.Data;
                    DataModel.Copy(intRowIndex, 1, intRowIndex + 1, 1, 1, _spdDetailInput_Sheet1.Columns.Count - 1);

                    //���ד��̓X�v���b�h�̃A�N�e�B�u�s�A�ǉ��s�ɔ䗦���͉�ʂ̓��e�𔽉f����.
                    decimal delRateLeft = decimal.Parse(txtRateLeft.Text.Trim());
                    decimal delRateRight = decimal.Parse(txtRateRight.Text.Trim());
                    decimal delMitumoriGaku = 0;
                    decimal delNebikiRitu = 0;
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                    decimal delNebikiGaku = 0;
                    decimal delZeiGaku = 0;
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

                    //���ϋ��zEmpty�`�F�b�N.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Text))
                    {
                        delMitumoriGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value.ToString().Trim());
                    }
                    //�l����Empty�`�F�b�N.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Text))
                    {
                        delNebikiRitu = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Text.Trim());
                    }
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                    //�l���zEmpty�`�F�b�N.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Text))
                    {
                        delNebikiGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value.ToString().Trim());
                    }
                    //����ŊzEmpty�`�F�b�N.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Text))
                    {
                        delZeiGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value.ToString().Trim());
                    }
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

                    /*
                     * �I�����R�[�h.
                     */
                    //���ϋ��z��[�A�N�e�B�u�s�̌��ϋ��z * ���� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value = delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight);

                    //�l�����Ɂu�A�N�e�B�u�s�̒l�����v��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Value = delNebikiRitu.ToString();

                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD Start */
                    ////�������z��[�A�N�e�B�u�s�̌��ϋ��z * ���� / (���� + �E��) - (�A�N�e�B�u�s�̌��ϋ��z * ���� / (���� + �E��) * (�A�N�e�B�u�s�̒l���� / 100))]��ݒ�.
                    //_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) - ((delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) * (delNebikiRitu / 100));

                    //�l���z��[�A�N�e�B�u�s�̒l���z * ���� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value = delNebikiGaku * delRateLeft / (delRateLeft + delRateRight);

                    //����Ŋz��[�A�N�e�B�u�s�̏���Ŋz * ���� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value = delZeiGaku * delRateLeft / (delRateLeft + delRateRight);

                    //�������z��[�A�N�e�B�u�s�̌��ϋ��z * ���� / (���� + �E��) - �A�N�e�B�u�s�̒l���z)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) - (delNebikiGaku * delRateLeft / (delRateLeft + delRateRight));
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD End */

                    /*
                     * �ǉ����R�[�h.
                     */
                    //���ϋ��z��[�A�N�e�B�u�s�̌��ϋ��z * �E�� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value = delMitumoriGaku * delRateRight / (delRateLeft + delRateRight);

                    //�l������[�A�N�e�B�u�s�̒l����]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_HNNERT].Value = delNebikiRitu.ToString();

                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD Start */
                    ////�������z��[�A�N�e�B�u�s�̌��ϋ��z * �E�� / (���� + �E��) - (�A�N�e�B�u�s�̌��ϋ��z * �E�� / (���� + �E��) * (�A�N�e�B�u�s�̒l���� / 100))]��ݒ�.
                    //_spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) - ((delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) * (delNebikiRitu / 100));

                    //�l���z��[�A�N�e�B�u�s�̒l���z * �E�� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value = delNebikiGaku * delRateRight / (delRateLeft + delRateRight);

                    //����Ŋz��[�A�N�e�B�u�s�̏���Ŋz * �E�� / (���� + �E��)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value = delZeiGaku * delRateRight / (delRateLeft + delRateRight);

                    //�������z��[�A�N�e�B�u�s�̌��ϋ��z * �E�� / (���� + �E��) - �A�N�e�B�u�s�̒l���z)]��ݒ�.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) - (delNebikiGaku * delRateRight / (delRateLeft + delRateRight));
                    /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD End */
                }
            }

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }
        #endregion OK�{�^���N���b�N�C�x���g.

        #region �L�����Z���{�^���N���b�N�C�x���g.
        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }
        #endregion �L�����Z���{�^���N���b�N�C�x���g.

        #region �䗦(��)KeyDown�C�x���g.
        /// <summary>
        /// �䗦(��)KeyDown�C�x���g.
        /// </summary>
        private void txtRateLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }
        #endregion �䗦(��)KeyDown�C�x���g.

        #region �䗦(�E)KeyDown�C�x���g.
        /// <summary>
        /// �䗦(�E)KeyDown�C�x���g.
        /// </summary>
        private void txtRateRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }
        #endregion �䗦(�E)KeyDown�C�x���g.
        #endregion �C�x���g.

        #region ���\�b�h.
        #region �e�R���g���[���̏����\������.
        /// <summary>
        /// �e�R���g���[���̏����\������.
        /// </summary>
        private void InitializeControl()
        {
            //�e�L�X�g�{�b�N�X������.
            txtRateLeft.Text = "1";
            txtRateRight.Text = "1";
        }
        #endregion �e�R���g���[���̏����\������.
        #endregion ���\�b�h.
    }
}
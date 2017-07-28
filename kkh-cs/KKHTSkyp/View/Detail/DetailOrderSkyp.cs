using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// ���я���ʁi�X�J�p�[�j 
    /// </summary>
    public partial class DetailOrderSkyp : Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �萔 

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "OderSkyp";
        /// <summary>
        /// �}�̋敪��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_BAITAI_KUBUN = 0;
        /// <summary>
        /// �}�̖��̗�C���f�b�N�X 
        /// </summary>
        private const int COLIDX_BAITAI_MEISYO = 1;
        /// <summary>
        /// ���s�^���ԗ�C���f�b�N�X 
        /// </summary>
        private const int COLIDX_HAKKO_KIKAN = 2;
        /// <summary>
        /// ���z��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_KINGAKU = 3;
        /// <summary>
        /// ����Ŋz��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_SYOHIZEIGAKU = 4;
        /// <summary>
        /// �������z��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_SEIKYU_KINGAKU = 5;
        /// <summary>
        /// ���я���C���f�b�N�X 
        /// </summary>
        private const int COLIDX_NARABI_JUN = 6;

        #endregion �萔 

        #region �����o�ϐ� 
        
        /// <summary>
        /// ���я���ʁi�X�J�p�[�j�p�����[�^ 
        /// </summary>
        private DetailOrderSkypNaviParameter _naviParameter = new DetailOrderSkypNaviParameter();

        /// <summary>
        /// �����G���R�[�f�B���O 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// �f�[�^���f�� 
        /// </summary>
        private DefaultSheetDataModel _dataModel;

        /// <summary>
        /// ���[�U�[�ɂ�����v�����iNavigator.Backward�̒��O��true�ɐݒ肷�鎖�j.
        /// </summary>
        private Boolean _userCloseRequest = false;

        #endregion �����o�ϐ� 

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public DetailOrderSkyp()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdOrder_Sheet1.Models.Data;
        }

        #endregion �R���X�g���N�^ 

        #region �C�x���g 

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailOrderSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is DetailOrderSkypNaviParameter)
            {
                _naviParameter = (DetailOrderSkypNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOrderSkyp_Load(object sender, EventArgs e)
        {
            InitializeControl();
            InitializeDisplayKkhDetail();
        }

        /// <summary>
        /// �t�H�[��Shown�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOrderSkyp_Shown(object sender, EventArgs e)
        {
            _dataModel.Changed += new SheetDataModelEventHandler(dataModel_Changed);
        }

        /// <summary>
        /// �o�^�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // �m�F���b�Z�[�W�\�� 
            DialogResult ret = MessageUtility.ShowMessageBox(MessageCode.HB_C0002
                                                , null
                                                , "���דo�^"
                                                , MessageBoxButtons.YesNo);
            if (ret == DialogResult.No) 
            {
                //�I����Ԃ����� 
                this.ActiveControl = null;

                return; 
            }

            // ���я��d���`�F�b�N 
            if (!CheckOrderData()) { return; }

            // ���я��f�[�^�X�V 
            if (UpdateOrderData())
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0011
                                ,null
                                , "���דo�^"
                                , MessageBoxButtons.OK);
            }
            else
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0008
                                ,null
                                , "���דo�^"
                                , MessageBoxButtons.OK);
            }

            // �I�y���[�V�������O�̏o��.
            KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_ORDER, KKHLogUtilitySkyp.DESC_OPERATION_LOG_ORDER);

            // ���[�U�[�ɂ�����v���ł���
            _userCloseRequest = true;

            Navigator.Backward(this, true, null, true);
        }

        /// <summary>
        /// �߂�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // ���[�U�[�ɂ�����v���ł���
            _userCloseRequest = true;

            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// ���я��X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
            if (_spdOrder_Sheet1.Columns[e.Column].CellType is TextCellType)
            {
                TextCellType tc = (TextCellType)_spdOrder_Sheet1.Columns[e.Column].CellType;
                e.EditingControl.Text = e.EditingControl.Text.Trim('.');
                e.EditingControl.Text = e.EditingControl.Text.Trim('-');
                //"5-5"�̂悤�ȏꍇ�ɑΉ� 
                e.EditingControl.Text = e.EditingControl.Text.Replace(".", "");
                e.EditingControl.Text = e.EditingControl.Text.Replace("-", "");
                string s = e.EditingControl.Text;
                if (_enc.GetByteCount(s) > tc.MaxLength)
                {
                    e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                    ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                }
            }
        }

        /// <summary>
        /// �f�[�^���f��Changed�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            // ��ҏW��ԂŃN���b�v�{�[�h����\��t�������ꍇ 
            if (e.Type == SheetDataModelEventType.CellsUpdated)
            {
                try
                {
                    // TextCellType�̏ꍇ�̂ݏ������s�� 
                    if (_spdOrder_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdOrder_Sheet1.Columns[e.Column].CellType;
                        string s = _dataModel.GetValue(e.Row, e.Column).ToString();
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            s = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            _dataModel.SetValue(e.Row, e.Column, s);
                        }
                    }
                }
                catch
                {
                    // �������Ȃ� 
                }
            }
        }

        private void DetailOrderSkyp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_userCloseRequest)
            {
                // ����{�^���ɂ��v���Ȃ̂ŃL�����Z������.
                e.Cancel = true;

                // ����v���t���O��ݒ�.
                _userCloseRequest = true;

                // ���߂ăt���[�����[�N�ɂ�����v�����o��.
                Navigator.Backward(this, null, null, true);
            }
        }


        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControl()
        {
            InputMap im = new InputMap();

            // ��ҏW�Z���ł�[F2]�L�[�𖳌� 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // �ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // ��ҏW�Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // �ҏW���Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // ��ҏW�Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // �ҏW���Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);
        }

        /// <summary>
        /// ���я��X�v���b�h�Ƀf�[�^��\������ 
        /// </summary>
        private void InitializeDisplayKkhDetail()
        {
            DetailSkypProcessController.FindOrderDataByCondParam param =
                new DetailSkypProcessController.FindOrderDataByCondParam();

            // �p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;
            param.baitaikbn = string.Empty;
            // ���я��f�[�^���� 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            FindOrderByCondServiceResult result = processController.FindOrderDataByCond(param);

            if (result.HasError == true)
            {
                return;
            }

            _dsDetailSkyp.OrderData.Clear();
            _dsDetailSkyp.OrderData.Merge(result.DetailDataSet.OrderData);
            _dsDetailSkyp.OrderData.AcceptChanges();
        }

        /// <summary>
        /// ���я��d���`�F�b�N 
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckOrderData()
        {
            // ����}�̂̕��я��`�F�b�N 
            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                string baitaiKbn = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text;
                string narabiJun = _spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text;

                for (int jRow = iRow + 1; jRow < _spdOrder_Sheet1.Rows.Count; jRow++)
                {
                    string baitaiKbn2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_BAITAI_KUBUN].Text;
                    string narabiJun2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_NARABI_JUN].Text;


                    // ����}�̋敪�ł���ꍇ 
                    if (baitaiKbn.Equals(baitaiKbn2))
                    {
                        // ������я��łȂ��ꍇ�G���[ 
                        if (!narabiJun.Equals(narabiJun2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0069
                                            , null
                                            , "���דo�^"
                                            , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            // ����}�̂łȂ����я��`�F�b�N 
            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                string baitaiKbn = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text;
                string narabiJun = _spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text;

                for (int jRow = iRow + 1; jRow < _spdOrder_Sheet1.Rows.Count; jRow++)
                {
                    string baitaiKbn2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_BAITAI_KUBUN].Text;
                    string narabiJun2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_NARABI_JUN].Text;

                    // ���я����ݒ肳��Ă��Ȃ��ꍇ�͓ǂݔ�΂� 
                    if (string.IsNullOrEmpty(narabiJun2))
                    {
                        continue;
                    }

                    // ����}�̋敪�łȂ��ꍇ 
                    if (!baitaiKbn.Equals(baitaiKbn2))
                    {
                        // ������я��̏ꍇ�G���[ 
                        if (narabiJun.Equals(narabiJun2)
                            && !string.IsNullOrEmpty(narabiJun)
                            && !string.IsNullOrEmpty(narabiJun2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0085
                                            , null
                                            , "���דo�^"
                                            , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���я��f�[�^�X�V 
        /// </summary>
        /// <returns>��������</returns>
        private bool UpdateOrderData()
        {
            DetailSkypProcessController.UpdateOrderDataParam param =
                new DetailSkypProcessController.UpdateOrderDataParam();

            // ���я��f�[�^�X�V�p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;

            string[] baitaiNm = new string[_spdOrder_Sheet1.Rows.Count];
            string[] baitaiKbn = new string[_spdOrder_Sheet1.Rows.Count];
            string[] narabiJun = new string[_spdOrder_Sheet1.Rows.Count];
            int narabijyun = 0;

            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                if (!string.IsNullOrEmpty(_spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text.Trim()))
                {
                    narabijyun = KKHUtility.IntParse(_spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text.Trim());
                    narabiJun[iRow] = narabijyun.ToString("000");
                }
                else
                {
                    narabiJun[iRow] = " ";
                }
                // �V���O���N�H�[�e�[�V�����̃G�X�P�[�v 
                // �u'(�V���O���N�H�[�e�[�V����)�v���u''(�V���O���N�H�[�e�[�V�������)�v�ɒu�������l��ݒ肷�� 
                baitaiNm[iRow] = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_MEISYO].Text.Trim().Replace("\'", "\'\'");
                baitaiKbn[iRow] = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text.Trim().Replace("\'", "\'\'");
            }
            param.order = narabiJun;
            param.baitaiNm = baitaiNm;
            param.baitaiKbn = baitaiKbn;

            // ���я��f�[�^�X�V 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            UpdateOrderServiceResult result = processController.UpdateOrderData(param);

            if (result.HasError == true)
            {
                return false;
            }
            return true;
        }
        
        #endregion ���\�b�h 

    }
}
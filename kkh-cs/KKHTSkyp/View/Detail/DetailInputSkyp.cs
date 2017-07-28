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

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Schema;
namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// ���ד��͉�ʁi�X�J�p�[�j 
    /// </summary>
    public partial class DetailInputSkyp : Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �萔

        /// <summary>
        /// �e���v���[�g���X�g���́F""�i�󔒁j 
        /// </summary>
        private const string TEMPLATE_NAME_00 = "";
        /// <summary>
        /// �e���v���[�g���X�g���́F�V�� 
        /// </summary>
        private const string TEMPLATE_NAME_01 = "�V��";
        /// <summary>
        /// �e���v���[�g���X�g���́F�X�|�[�c�� 
        /// </summary>
        private const string TEMPLATE_NAME_02 = "�X�|�[�c��";
        /// <summary>
        /// �e���v���[�g���X�g���́F�G�� 
        /// </summary>
        private const string TEMPLATE_NAME_03 = "�G��";
        /// <summary>
        /// �e���v���[�g���X�g���́F���W�I 
        /// </summary>
        private const string TEMPLATE_NAME_04 = "���W�I";
        /// <summary>
        /// �e���v���[�g���X�g���́F�e���r�^�C�� 
        /// </summary>
        private const string TEMPLATE_NAME_05 = "�e���r�^�C��";
        /// <summary>
        /// �e���v���[�g���X�g���́F�e���r�X�|�b�g 
        /// </summary>
        private const string TEMPLATE_NAME_06 = "�e���r�X�|�b�g";
        /// <summary>
        /// �e���v���[�g���X�g���́F�a�r 
        /// </summary>
        private const string TEMPLATE_NAME_07 = "�a�r";
        /// <summary>
        /// �e���v���[�g���X�g���́F�v�d�a 
        /// </summary>
        private const string TEMPLATE_NAME_08 = "�v�d�a";

        /// <summary>
        /// �e���v���[�g���X�gID�F0:""�i�󔒁j 
        /// </summary>
        private const string TEMPLATE_ID_00 = "0";
        /// <summary>
        /// �e���v���[�g���X�gID�F1:�V�� 
        /// </summary>
        private const string TEMPLATE_ID_01 = "1";
        /// <summary>
        /// �e���v���[�g���X�gID�F2:�X�|�[�c�� 
        /// </summary>
        private const string TEMPLATE_ID_02 = "2";
        /// <summary>
        /// �e���v���[�g���X�gID�F3:�G�� 
        /// </summary>
        private const string TEMPLATE_ID_03 = "3";
        /// <summary>
        /// �e���v���[�g���X�gID�F4:���W�I 
        /// </summary>
        private const string TEMPLATE_ID_04 = "4";
        /// <summary>
        /// �e���v���[�g���X�gID�F5:�e���r�^�C�� 
        /// </summary>
        private const string TEMPLATE_ID_05 = "5";
        /// <summary>
        /// �e���v���[�g���X�gID�F6:�e���r�X�|�b�g 
        /// </summary>
        private const string TEMPLATE_ID_06 = "6";
        /// <summary>
        /// �e���v���[�g���X�gID�F7:�a�r 
        /// </summary>
        private const string TEMPLATE_ID_07 = "7";
        /// <summary>
        /// �e���v���[�g���X�gID�F8:�v�d�a 
        /// </summary>
        private const string TEMPLATE_ID_08 = "8";

        /// <summary>
        /// �ǂݎ���p��̔w�i�F 
        /// </summary>
        private static readonly Color COL_BACKCOLOR_LOCKED = Color.FromArgb(192, 192, 192);

        /// <summary>
        /// ���ރ}�X�^�擾�L�[�F0001 
        /// </summary>
        private const string MST_BUNRUI = "0001";

        /// <summary>
        /// ���׃X�v���b�h�Q���z�̍ő�l 
        /// </summary>
        private const double MAX_VALUE_KINGAK = 999999999999D;
        /// <summary>
        /// ���׃X�v���b�h�Q���z�̍ŏ��l 
        /// </summary>
        private const double MIN_VALUE_KINGAK = -999999999999D;

        /// <summary>
        /// �������[�h�񋓑� 
        /// </summary>
        private enum Mode
        {
            /// <summary>
            /// �s�}��:0 
            /// </summary>
            Insert = 0,
            /// <summary>
            /// ���̑�:99 
            /// </summary>
            Other = 99,
        }

        #endregion �萔

        #region �����o�ϐ�

        /// <summary>
        /// ���ד��͉�ʁi�X�J�p�[�j�p�����[�^ 
        /// </summary>
        private DetailInputSkypNaviParameter _naviParameter = new DetailInputSkypNaviParameter();

        /// <summary>
        /// �󒍃_�E�����[�h�f�[�^ 
        /// </summary>
        private Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;

        /// <summary>
        /// �󒍃_�E�����[�h�f�[�^�i�����ς݁j 
        /// </summary>
        private Common.KKHSchema.Detail.JyutyuDataRow[] _mergeDataRow = null;

        /// <summary>
        /// �L����׃f�[�^ 
        /// </summary>
        private SheetView _fpSpread1_Sheet1 = null;

        /// <summary>
        /// �@�\ID 
        /// </summary>
        private string _aplId = string.Empty;

        /// <summary>
        /// �������z�i���ד��͉�ʂ̒l�j 
        /// </summary>
        private decimal _seigak = 0M;

        /// <summary>
        /// �������z���v�i�e��ʁi�L����ד��͉�ʁj�̒l�j 
        /// </summary>
        private decimal _seigakSum = 0M;

        /// <summary>
        /// ���ރ}�X�^���i�L�[�j 
        /// </summary>
        private string[] _itemBunruiCd = null;

        /// <summary>
        /// ���ރ}�X�^���i���́j 
        /// </summary>
        private string[] _itemBunruiNm = null;

        /// <summary>
        /// �����G���R�[�f�B���O 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// �f�[�^���f�� 
        /// </summary>
        private DefaultSheetDataModel _dataModel;

        /// <summary>
        /// �I��� 
        /// </summary>
        private int _col = 0;

        /// <summary>
        /// �I���s 
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// ���[�U�[�ɂ�����v�����iNavigator.Backward�̒��O��true�ɐݒ肷�鎖�j.
        /// </summary>
        private Boolean _userCloseRequest = false;

        private bool msgcheck = false;
        #endregion �����o�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public DetailInputSkyp()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdKkhDetail_Sheet1.Models.Data;
        }

        #endregion �R���X�g���N�^

        #region �C�x���g

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailInputSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is DetailInputSkypNaviParameter)
            {
                _naviParameter = (DetailInputSkypNaviParameter)arg.NaviParameter;
                _dataRow = _naviParameter.DataRow;
                _mergeDataRow = _naviParameter.MergeDataRow;
                _fpSpread1_Sheet1 = _naviParameter.SpdKkhDetail_Sheet1;
                _aplId = _naviParameter.AplId;
                _seigakSum = _naviParameter.SeigakSum;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_Load(object sender, EventArgs e)
        {
            InitializeControl();
        }

        /// <summary>
        /// �t�H�[��Shown�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_Shown(object sender, EventArgs e)
        {
            InitializeDesignForSpdKkhDetail();
            EditControl();
        }

        /// <summary>
        /// �폜�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            // �I���s�̎擾 
            CellRange[] cellRanges = _spdKkhDetail_Sheet1.GetSelections();

            if (cellRanges.Length == 0)
            {
                if (0 < _spdKkhDetail_Sheet1.Rows.Count)
                {
                    // ����(�ꗗ)����擪�s���폜���� 
                    _spdKkhDetail_Sheet1.RemoveRows(0, 1);
                }
            }
            else
            {
                int delCnt = 0;
                // �폜�����s�𖾍�(�ꗗ)����폜 
                foreach (CellRange cellRange in cellRanges)
                {
                    //�I������Ă��閾�ד��e�̍s�����̏������J��Ԃ� 
                    _spdKkhDetail_Sheet1.RemoveRows(cellRange.Row - delCnt, cellRange.RowCount);
                    delCnt = delCnt + cellRange.RowCount;
                }
            }

            // ���v�i�������z/�l���z/�旿���j�̌v�Z 
            CalcShokei();

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �s�}���{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIns_Click(object sender, EventArgs e)
        {
            if (_spdKkhDetail_Sheet1.Rows.Count == 0)
            {
                // �󒍃_�E�����[�h�f�[�^����ɁA���׃f�[�^�̐ݒ肷�� 
                SetDetailData(new Common.KKHSchema.Detail.JyutyuDataRow[] { _dataRow }, Mode.Insert);
            }
            else
            {
                // �A�N�e�B�u�s�̃R�s�[��}�� 
                int row = _spdKkhDetail_Sheet1.ActiveRowIndex;
                _spdKkhDetail_Sheet1.AddRows(row + 1, 1);

                for (int iCol = 0; iCol < _spdKkhDetail_Sheet1.Columns.Count; iCol++)
                {
                    if (iCol == DetailSkyp.COLIDX_MLIST_SEQ1)
                    {
                        decimal val = 0M;
                        object obj = null;
                        for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
                        {
                            obj = _spdKkhDetail_Sheet1.Cells[iRow, iCol].Value;

                            if (obj == null)
                            {
                                obj = 0;
                            }
                            if (val < KKHUtility.DecParse(obj.ToString()))
                            {
                                val = KKHUtility.DecParse(obj.ToString());
                            }
                        }
                        //_spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = val + 10;
                        ////1000�𖢖��̏ꍇ 
                        //if (val + 10 < 1000)
                        //10000�����̏ꍇ 
                        if (val + 10 < 10000)
                        {
                            //10�����Z���ăZ�b�g
                            _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = val + 10;
                        }
                        //1000�𒴂���ꍇ 
                        else
                        {
                            //��Ƃ��� 
                            _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = "";
                        }
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = _spdKkhDetail_Sheet1.Cells[row, iCol].Value;
                    }
                }
            }

            // ���v�i�������z/�l���z/�旿���j�̌v�Z 
            CalcShokei();

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �o�^�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // ���ׂ����݂���ꍇ 
            if (0 < _spdKkhDetail_Sheet1.Rows.Count)
            {
                // ���׃`�F�b�N���� 
                if (!CheckDetailData()) { return; }
            }

            // �m�F���b�Z�[�W�\�� 
            DialogResult ret = MessageUtility.ShowMessageBox(MessageCode.HB_C0002
                                                , null
                                                , "���דo�^"
                                                , MessageBoxButtons.YesNo);
            if (ret == DialogResult.No) { return; }

            // ���דo�^���� 
            UpdateDisplayDataServiceResult result;

            if (RegistDetailData(out result))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "���דo�^", MessageBoxButtons.OK);

                // ���[�U�[�ɂ�����v���ł���
                _userCloseRequest = true;

                Navigator.Backward(this, result, null, true);
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

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
        /// �}�̖��̈ꊇ�e�L�X�g�{�b�N�XChanged�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBaitaiNm_TextChanged(object sender, EventArgs e)
        {
            string str = txtBaitaiNm.Text;
            int len = txtBaitaiNm.MaxLength;
            if (_enc.GetByteCount(str) > len)
            {
                str = _enc.GetString(_enc.GetBytes(str), 0, len);
                txtBaitaiNm.Text = str;
            }
        }

        /// <summary>
        /// �}�̖��̈ꊇ�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaitai_Click(object sender, EventArgs e)
        {
            // �}�̖��̂��ꊇ�ݒ肷�� 
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value = txtBaitaiNm.Text;
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���׃X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            switch (e.Column)
            {
                case DetailSkyp.COLIDX_MLIST_BAITAIKBN:         // �}�̋敪 
                case DetailSkyp.COLIDX_MLIST_BAITAIMEI:         // �}�̖��� 

                    // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // ���я� 

                    // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
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
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// ���׃X�v���b�h�̃Z���Ƀt�H�[�J�X���ړ�����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EnterCell(object sender, EnterCellEventArgs e)
        {
            _col = e.Column;
            _row = e.Row;

            switch (e.Column)
            {
                case DetailSkyp.COLIDX_MLIST_SEQ1:              // ���я� 
                    _dataModel.Changed += new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// ���׃X�v���b�h�̕ҏW���[�h���I������Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditModeOff(object sender, EventArgs e)
        {
            switch (_col)
            {
                case DetailSkyp.COLIDX_MLIST_TORIGAK:           // ����z 
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:          // �l���� 
                case DetailSkyp.COLIDX_MLIST_KINGAK:            // ����z�i�������z�j 
                case DetailSkyp.COLIDX_MLIST_SYOHIRITU:         // ����ŗ� 
                case DetailSkyp.COLIDX_MLIST_SYOHI:             // ����Ŋz 
                case DetailSkyp.COLIDX_MLIST_NEBIGAK:           // �l���z 

                    // �l���󕶎��ANull�̏ꍇ�A�f�t�H���g�l��ݒ肷�� 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = 0;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = "0";
                    }

                    // �����v�Z 
                    CalcAuto(_row, _col);

                    // ���v�i�������z/�l���z/�旿���j�̌v�Z 
                    CalcShokei();
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUCODE:        // ���ڃR�[�h 
                    _spdKkhDetail_Sheet1.Cells[_row, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value =
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text;
                    if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0151
                                        , null
                                        , "���דo�^(�X�J�p�[)"
                                        , MessageBoxButtons.OK
                                        );
                    }
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUMEI:         // ���ږ��� 
                    _spdKkhDetail_Sheet1.Cells[_row, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value =
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value;
                    break;

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // ���я� 
                    _dataModel.Changed -= new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
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
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
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

        /// <summary>
        /// �X�v���b�h�`�F���W�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_Change(object sender, ChangeEventArgs e)
        {
            //switch (e.Column)
            switch (e.Column)
            {
                case DetailSkyp.COLIDX_MLIST_TORIGAK:           // ����z 
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:          // �l���� 
                case DetailSkyp.COLIDX_MLIST_KINGAK:            // ����z�i�������z�j 
                case DetailSkyp.COLIDX_MLIST_SYOHIRITU:         // ����ŗ� 
                case DetailSkyp.COLIDX_MLIST_SYOHI:             // ����Ŋz 
                case DetailSkyp.COLIDX_MLIST_NEBIGAK:           // �l���z 

                    // �l���󕶎��ANull�̏ꍇ�A�f�t�H���g�l��ݒ肷�� 
                    if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value = 0;
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text = "0";
                    }

                    // �����v�Z 
                    CalcAuto(e.Row, e.Column);

                    // ���v�i�������z/�l���z/�旿���j�̌v�Z 
                    CalcShokei();
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUCODE:        // ���ڃR�[�h 
                    _spdKkhDetail_Sheet1.Cells[e.Row, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value =
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text;
                    if (msgcheck)
                    {
                        if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0151
                                            , null
                                            , "���דo�^(�X�J�p�[)"
                                            , MessageBoxButtons.OK
                                            );

                        }
                    }
                    msgcheck = false;
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUMEI:         // ���ږ��� 
                    _spdKkhDetail_Sheet1.Cells[e.Row, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value =
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value;
                    break;

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // ���я� 
                    _dataModel.Changed -= new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// �X�v���b�h�L�[�_�E���C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                //Ctrl+V���������ꂽ�ꍇ�A�N���b�v�{�[�h�̓��e��\��t��
                FpSpread fpSpread = sender as FpSpread;
                CellRange[] range = fpSpread.ActiveSheet.GetSelections();

                // �N���b�v�{�[�h�̒l���Z���ɓ��Ă͂߂�
                string clipVal = Clipboard.GetText();

                // �I�������Z���͈͏��𑖍�����
                foreach (CellRange rn in range)
                {
                    // �� 
                    int col = rn.Column;
                    // �s 
                    int row = rn.Row;
                    // �I��͈͏I����
                    int colEnd = (rn.Column + rn.ColumnCount - 1);
                    // �I��͈͏I���s 
                    int rowEnd = (rn.Row + rn.RowCount - 1);
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        // �s�����[�v 
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(this.spdKkhDetail.GetRootWorkbook(), clipVal, rowCnt, colCnt);

                            if (multiCopyFlg)
                            {
                                // �����R�s�[�ׁ̈A�\��t���I�� 
                                break;
                            }
                        }
                        if (multiCopyFlg)
                        {
                            // �����R�s�[�ׁ̈A�\��t���I�� 
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_FormClosing(object sender, FormClosingEventArgs e)
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
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // �ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // ��ҏW�Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // �ҏW���Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // ��ҏW�Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // �ҏW���Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // �e���z�e�L�X�g�{�b�N�X 
            txtTorigak.Text = "0";
            txtSyohigak.Text = "0";
            txtNebigak.Text = "0";
            txtSeigak.Text = "0";
            txtSeigakSum.Text = "0";
            txtJyutSeigak.Text = "0";

            // �}�̖��̃e�L�X�g�{�b�N�X
            txtBaitaiNm.Text = string.Empty;

            // �e���v���[�g�R���{�{�b�N�X 
            Common.KKHSchema.Detail.ComboDataTable dtCombo =
                new Common.KKHSchema.Detail.ComboDataTable();
            dtCombo.AddComboRow(TEMPLATE_NAME_00, TEMPLATE_ID_00);
            dtCombo.AddComboRow(TEMPLATE_NAME_01, TEMPLATE_ID_01);
            dtCombo.AddComboRow(TEMPLATE_NAME_02, TEMPLATE_ID_02);
            dtCombo.AddComboRow(TEMPLATE_NAME_03, TEMPLATE_ID_03);
            dtCombo.AddComboRow(TEMPLATE_NAME_04, TEMPLATE_ID_04);
            dtCombo.AddComboRow(TEMPLATE_NAME_05, TEMPLATE_ID_05);
            dtCombo.AddComboRow(TEMPLATE_NAME_06, TEMPLATE_ID_06);
            dtCombo.AddComboRow(TEMPLATE_NAME_07, TEMPLATE_ID_07);
            dtCombo.AddComboRow(TEMPLATE_NAME_08, TEMPLATE_ID_08);

            cmbTempCode.DisplayMember = dtCombo.textColumn.ColumnName;
            cmbTempCode.ValueMember = dtCombo.valueColumn.ColumnName;
            cmbTempCode.DataSource = dtCombo;

            //�}�X�^�����擾���� 
            GetMasterData();
        }

        /// <summary>
        /// �e�R���g���[���̕ҏW���� 
        /// </summary>
        private void EditControl()
        {
            // �󒍐������z 
            decimal seigak = _dataRow.hb1SeiGak + _dataRow.hb1SzeiGak;
            txtJyutSeigak.Text = seigak.ToString("###,###,###,##0");

            // �L����׉�ʂőI�����ꂽ���e��\������ 
            if (0 < _fpSpread1_Sheet1.Rows.Count)
            {
                #region �ǉ��E�X�V�E�폜

                // �e���v���[�g 
                cmbTempCode.SelectedValue = _fpSpread1_Sheet1.Cells[_fpSpread1_Sheet1.Rows.Count - 1, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value;

                for (int iRow = 0; iRow < _fpSpread1_Sheet1.Rows.Count; iRow++)
                {
                    // �s�ǉ� 
                    _spdKkhDetail_Sheet1.AddRows(iRow, 1);

                    // ���������׃X�v���b�h�ɓ��͓��e��ݒ� 
                    // �Ɩ��敪 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value;

                    // �^�C���X�|�b�g 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value;

                    // ���� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value;

                    // �d�ʁE�}�̖��� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value;

                    // �d�ʁE���� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value;

                    // �d�ʁE���e 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value;

                    // �旿�� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value;

                    // �l���� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value;

                    // �l���z 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value;

                    // �������z 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value;

                    // ����ŗ� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value;

                    // ����Ŋz 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value;

                    // �}�̋敪 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                    // �}�̖��� 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value;

                    // ���ڃR�[�h�i�e�L�X�g��ݒ肷��j 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text;

                    // ���ږ��́i�e�L�X�g��ݒ肷��j 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text;

                    // ���я��i�}�̋敪�j 
                    decimal seq1 = GetDecimalValue(_fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value);
                    if (seq1 == 0)
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = string.Empty;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = seq1;
                    }

                    // ���я� 
                    decimal seq2 = GetDecimalValue(_fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value);
                    if (seq2 == 0)
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = string.Empty;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = seq2;
                    }

                    // ��NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value;

                    // �󒍖���NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value;

                    // ���㖾��NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value;

                    // �������[NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value;

                    // �}�̋敪 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value;

                    // �^�C���X�^���v 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value;

                    // �e���v���[�g�R�[�h 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value;
                }

                #endregion �ǉ��E�X�V�E�폜
            }
            else
            {
                #region �V�K

                if (!"1".Equals(_dataRow.hb1TouFlg))
                {
                    // �e���v���[�g 
                    cmbTempCode.SelectedValue = SetTempCodeValue(_dataRow.hb1GyomKbn);

                    // �������������݂��Ȃ��ꍇ 
                    // �󒍃_�E�����[�h�f�[�^����ɁA���׃f�[�^�̐ݒ肷�� 
                    SetDetailData(new Common.KKHSchema.Detail.JyutyuDataRow[] { _dataRow }, Mode.Other);
                }
                else
                {
                    // �e���v���[�g 
                    cmbTempCode.SelectedValue = SetTempCodeValue(_mergeDataRow[0].hb1GyomKbn);

                    // �������������݂���ꍇ 
                    // �󒍃_�E�����[�h�f�[�^�i�����ς݁j����ɁA���׃f�[�^�̐ݒ肷�� 
                    SetDetailData(_mergeDataRow, Mode.Other);
                }

                #endregion �V�K
            }

            // ���v�i�������z/�l���z/�旿���j�̌v�Z 
            CalcShokei();
        }

        /// <summary>
        /// ���׃X�v���b�h�̃f�U�C�����������s�� 
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //�X�v���b�h�S�̂̐ݒ� 
            //********************************

            //********************************
            //�񖈂̐ݒ� ���f�U�C�i�����ɑ΂���ݒ���s���ƕύX�����f����Ȃ����Ƃ�����悤�Ȃ̂Ŏb��I�ɂ����ōs�� 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //���ʐݒ� 
                col.AllowAutoFilter = true;//�t�B���^�@�\��L�� 
                col.AllowAutoSort = true;  //�\�[�g�@�\��L�� 

                //�񖈂ɈقȂ�ݒ� 
                if (col.Index == DetailSkyp.COLIDX_MLIST_GYOMUKBN)
                {
                    col.Label = "�Ɩ��敪";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TIMESPOTKBN)
                {
                    col.Label = "�^�C���X�|�b�g�敪";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KENMEI)
                {
                    col.Label = "����";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DMEISYO)
                {
                    col.Label = "�d�ʁE�}�̖���";
                    col.Width = 200;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DKIKAN)
                {
                    col.Label = "�d�ʁE����";
                    col.Width = 120;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DNAIYO)
                {
                    col.Label = "�d�ʁE���e";
                    col.Width = 150;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TORIGAK)
                {
                    col.Label = "�旿��";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_NEBIRITU)
                {
                    col.Label = "�l����";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.MaximumValue = 100D;
                    cellType.MinimumValue = -100D;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_NEBIGAK)
                {
                    col.Label = "�l���z";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KINGAK)
                {
                    col.Label = "�������z";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SYOHIRITU)
                {
                    col.Label = "����ŗ�";
                    col.Width = 65;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.MaximumValue = 100D;
                    cellType.MinimumValue = 0D;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SYOHI)
                {
                    col.Label = "����Ŋz";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIKBN)
                {
                    col.Label = "�}�̋敪";
                    col.Width = 250;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 60;
                    cellType.CharacterSet = CharacterSet.AllIME;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIMEI)
                {
                    col.Label = "�}�̖���";
                    col.Width = 200;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 40;
                    cellType.CharacterSet = CharacterSet.AllIME;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KOMOKUCODE)
                {
                    col.Label = "���ڃR�[�h";
                    col.Width = 80;
                    ComboBoxCellType cellType = new ComboBoxCellType();
                    //cellType.ItemData = _itemBunruiNm;
                    cellType.ItemData = _itemBunruiCd;
                    cellType.Items = _itemBunruiCd;
                    cellType.EditorValue = EditorValue.ItemData;
                    cellType.Editable = true;
                    cellType.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KOMOKUMEI)
                {
                    col.Label = "���ږ���";
                    col.Width = 250;
                    ComboBoxCellType cellType = new ComboBoxCellType();
                    cellType.ItemData = _itemBunruiCd;
                    cellType.Items = _itemBunruiNm;
                    cellType.EditorValue = EditorValue.ItemData;
                    cellType.Editable = false;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SEQ2)
                {
                    col.Label = "���я��Q";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SEQ1)
                {
                    col.Label = "���я�";
                    col.Width = 60;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    //cellType.MaxLength = 3;
                    cellType.MaxLength = 4;
                    cellType.CharacterSet = CharacterSet.Numeric;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "��NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "�󒍖���NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_URMEINO)
                {
                    col.Label = "���㖾��NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_GPYNO)
                {
                    col.Label = "�������[NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIKBN2)
                {
                    col.Label = "�}�̋敪";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TIMESTMP)
                {
                    col.Label = "�^�C���X�^���v";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TEMPCODE)
                {
                    col.Label = "�e���v���[�g�R�[�h";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
            }
        }

        /// <summary>
        /// �}�X�^�����擾���� 
        /// </summary>
        private void GetMasterData()
        {
            MasterMaintenanceProcessController processController =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance.MasterDataVORow[] rows;
            string filter;

            // ���ރ}�X�^���擾 
            result = processController.FindMasterByCond(_naviParameter.strEsqId,
                                                        _naviParameter.strEgcd,
                                                        _naviParameter.strTksKgyCd,
                                                        _naviParameter.strTksBmnSeqNo,
                                                        _naviParameter.strTksTntSeqNo,
                                                        MST_BUNRUI,
                                                        null);

            List<string> lstKeys = new List<string>();
            List<string> lstValues = new List<string>();

            // �L����ד��͉�ʂőI�����ꂽ�Ɩ��敪�̃��X�g��擪�ɕ\�������邽�߁A 
            // �L����ד��͉�ʂőI�����ꂽ�Ɩ��敪�̃f�[�^���擾�����X�g�ɕێ�����B 
            filter = "Column3 = \'" + _dataRow.hb1GyomKbn + "\'";
            rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select(filter);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // �L����ד��͉�ʂőI�����ꂽ�Ɩ��敪�ȊO�f�[�^���擾�����X�g�ɕێ�����B 
            filter = "Column3 <> \'" + _dataRow.hb1GyomKbn + "\'";
            rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select(filter);
            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // ���X�g��z�񉻂��ϐ��ɕێ����� 
            _itemBunruiCd = lstKeys.ToArray();
            _itemBunruiNm = lstValues.ToArray();
        }

        /// <summary>
        /// �e���v���[�g�R���{�{�b�N�X�̏����l��ݒ肷�� 
        /// </summary>
        /// <param name="gyomKbn">�Ɩ��敪�R�[�h</param>
        /// <returns>�e���v���[�g�R�[�h</returns>
        private string SetTempCodeValue(string gyomKbn)
        {
            string ret = string.Empty;

            switch (gyomKbn)
            {
                case KKHSystemConst.GyomKbn.Shinbun:        // �V�� 
                    ret = TEMPLATE_ID_01;
                    break;
                case KKHSystemConst.GyomKbn.Zashi:          // �G�� 
                    ret = TEMPLATE_ID_03;
                    break;
                case KKHSystemConst.GyomKbn.Radio:          // ���W�I 
                    ret = TEMPLATE_ID_04;
                    break;
                case KKHSystemConst.GyomKbn.TVTime:         // �e���r�^�C�� 
                    ret = TEMPLATE_ID_05;
                    break;
                case KKHSystemConst.GyomKbn.TVSpot:         // �e���r�X�|�b�g 
                    ret = TEMPLATE_ID_06;
                    break;
                case KKHSystemConst.GyomKbn.EiseiM:         // �q�����f�B�A�iBS�j 
                    ret = TEMPLATE_ID_07;
                    break;
                case KKHSystemConst.GyomKbn.InteractiveM:   // �C���^���N�e�B�u���f�B�A �iWEB�j 
                    ret = TEMPLATE_ID_08;
                    break;
                default:
                    break;
            }

            return ret;
        }

        /// <summary>
        /// ���׃f�[�^�̐ݒ� 
        /// </summary>
        /// <param name="dataRow">�󒍃_�E�����[�h�f�[�^</param>
        /// <param name="mode">�������[�h</param>
        private void SetDetailData(Common.KKHSchema.Detail.JyutyuDataRow[] dataRow, Mode mode)
        {
            for (int iRow = 0; iRow < dataRow.Length; iRow++)
            {
                // �s�ǉ� 
                _spdKkhDetail_Sheet1.AddRows(iRow, 1);

                // �Ɩ��敪 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value = dataRow[iRow].hb1GyomKbn.Trim();

                // �^�C���X�|�b�g 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value = dataRow[iRow].hb1TmspKbn.Trim();

                // ���� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value = dataRow[iRow].hb1KKNameKJ.Trim();

                // �旿�� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value = dataRow[iRow].hb1ToriGak;

                // �l���� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value = dataRow[iRow].hb1NeviRitu;

                // �l���z 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value = dataRow[iRow].hb1NeviGak;

                // �������z 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value = dataRow[iRow].hb1SeiGak;

                // ����ŗ� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value = dataRow[iRow].hb1SzeiRitu;

                // ����Ŋz 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value = dataRow[iRow].hb1SzeiGak;

                // �}�̋敪 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value = dataRow[iRow].hb1KKNameKJ;

                // �}�̖��� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value = string.Empty;

                // ���ڃR�[�h 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value = string.Empty;

                // ���ږ��� 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value = string.Empty;

                // ���я��i�}�̋敪�j 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = string.Empty;

                // ���я� 
                if (mode == Mode.Insert)
                {
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = "10";
                }
                else
                {
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = string.Empty;
                }

                // ��NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value = dataRow[iRow].hb1JyutNo.Trim();

                // �󒍖���NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value = dataRow[iRow].hb1JyMeiNo.Trim();

                // ���㖾��NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value = dataRow[iRow].hb1UrMeiNo.Trim();

                // �������[NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value = dataRow[iRow].hb1GpyNo.Trim();

                // �}�̋敪 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value = dataRow[iRow].hb1KKNameKJ.Trim();

                // �^�C���X�^���v 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value = string.Empty;

                // �e���v���[�g�R�[�h 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value = string.Empty;


                // �����敪�ɂ��A�d�ʁE�}�̖��́A���ԁA���e��ݒ肷�� 
                switch (dataRow[iRow].hb1SeiKbn)
                {
                    case KKHSystemConst.SeiKbn.NewsPaper:   // �V�� 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE����                         
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // �d�ʁE���e 
                        if (dataRow[iRow].hb1Field4 == "1")
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "�� " + dataRow[iRow].hb1Field11.Trim();
                        }
                        else if (dataRow[iRow].hb1Field4 == "2")
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "�[ " + dataRow[iRow].hb1Field11.Trim();
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field11.Trim();
                        }
                        break;

                    case KKHSystemConst.SeiKbn.Magazine:    // �G�� 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field9.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Time:        // �^�C�� 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field8.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "�b��:" + dataRow[iRow].hb1Field5.Trim() + " �ǐ��F" + dataRow[iRow].hb1Field3.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Spot:        // �X�|�b�g 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field4.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "�b��:" + dataRow[iRow].hb1Field5.Trim() + " �{���F" + dataRow[iRow].hb1Field6.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.IC:          // IC 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "����:" + dataRow[iRow].hb1Field6.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Ooh:         // ��ʍL�� 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "����:" + dataRow[iRow].hb1Field6.Trim() + " " + dataRow[iRow].hb1Field8.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Works:       // ����� 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field4.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "��:" + dataRow[iRow].hb1Field6.Trim() + " " + dataRow[iRow].hb1Field3.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.KMas:        // ���ۃ}�X 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field11.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.KWorks:      // ����(����Ɓj 
                        // �d�ʁE�}�̖��� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field3.Trim();

                        // �d�ʁE���� 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field4.Trim());

                        // �d�ʁE���e 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field12.Trim();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// ���t�̕ҏW���s�� 
        /// </summary>
        /// <param name="value">�ҏW����</param>
        /// <returns>�ҏW��̒l</returns>
        private string EditFromTo(string value)
        {
            string ret = string.Empty;
            if (value.Length == 8)
            {
                ret = value.Substring(4, 2) + "/" + value.Substring(6, 2);
            }
            else if (value.Length < 16)
            {
                ret = value;
            }
            else
            {
                ret = value.Substring(4, 2) + "/" + value.Substring(6, 2);
                ret += " - " + value.Substring(12, 2) + "/" + value.Substring(14, 2);
            }
            return ret;
        }

        /// <summary>
        /// ���v�i�������z/�l���z/�旿���j�̌v�Z 
        /// </summary>
        private void CalcShokei()
        {
            decimal torigak = 0M;
            decimal nebigak = 0M;
            decimal syohi = 0M;
            decimal kingak = 0M;

            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                // �旿�������Z 
                torigak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);

                // �l���z�����Z 
                nebigak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);

                // ����Ŋz�����Z 
                syohi += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Text);

                // �����z�����Z 
                kingak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text);
            }

            // �������z���v 
            txtSeigakSum.Text = kingak.ToString("###,###,###,##0");

            // �l���z���v 
            txtNebigak.Text = nebigak.ToString("###,###,###,##0");

            // �旿�����v 
            txtTorigak.Text = torigak.ToString("###,###,###,##0");

            // ����Ŋz 
            txtSyohigak.Text = syohi.ToString("###,###,###,##0");

            //�������z 
            decimal seigak = kingak + syohi;
            txtSeigak.Text = seigak.ToString("###,###,###,##0");
        }

        /// <summary>
        /// �����v�Z 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        /// <param name="colmun">��C���f�b�N�X</param>
        private void CalcAuto(int row, int colmun)
        {
            switch (colmun)
            {
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:  // �l���� 
                case DetailSkyp.COLIDX_MLIST_TORIGAK:   // ����z 
                    // �l���z�������v�Z 
                    CalcAutoNebigak(row, colmun);

                    // �������z�������v�Z 
                    CalcAutoKingak(row, colmun);

                    // ����Ŋz�������v�Z 
                    CalcAutoSyohi(row, colmun);
                    break;

                case DetailSkyp.COLIDX_MLIST_SYOHIRITU: // ����ŗ� 
                case DetailSkyp.COLIDX_MLIST_KINGAK:    // ����z�i�������z�j 
                    // ����Ŋz�������v�Z 
                    CalcAutoSyohi(row, colmun);
                    break;

                case DetailSkyp.COLIDX_MLIST_NEBIGAK:   // ����z 
                    // �������z�������v�Z 
                    CalcAutoKingak(row, colmun);

                    // ����Ŋz�������v�Z 
                    CalcAutoSyohi(row, colmun);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// �l���z�������v�Z 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        /// <param name="colmun">��C���f�b�N�X</param>
        private void CalcAutoNebigak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
            decimal nebiritu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIRITU].Text);
            decimal nebigak = torigak * nebiritu / 100;

            if (nebigak != Math.Truncate(nebigak))
            {
                if (0 < nebigak)
                {
                    // �v���X�֐؂�グ�� 
                    nebigak += 1;
                }
                else if (nebigak < 0)
                {
                    // �}�C�i�X�֐؂�グ�� 
                    nebigak -= 1;
                }
            }
            else
            {
                // �␳�Ȃ� 
            }

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value = Math.Truncate(nebigak);
        }

        /// <summary>
        /// �������z�������v�Z 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        /// <param name="colmun">��C���f�b�N�X</param>
        private void CalcAutoKingak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
            decimal nebigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);
            decimal kingak = torigak - nebigak;

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_KINGAK].Value = kingak;
        }

        /// <summary>
        /// ����Ŋz�������v�Z 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        /// <param name="colmun">��C���f�b�N�X</param>
        private void CalcAutoSyohi(int row, int colmun)
        {
            decimal kingak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_KINGAK].Text);
            decimal syohiritu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Text);
            decimal syohi = kingak * (syohiritu * 0.01M);

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_SYOHI].Value = Math.Round(syohi, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// ���׃`�F�b�N���� 
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckDetailData()
        {
            bool sinseiFlg = false;
            bool komokuFlg = false;
            decimal seikyu = 0M;
            decimal nebiki = 0M;
            decimal tori = 0M;
            bool kinChkFlg1 = false;
            bool kinChkFlg2 = false;

            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                // �����`�F�b�N 
                if (!_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Text.Trim().Equals(
                     _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Text.Trim()))
                {
                    sinseiFlg = true;
                }

                // ���ڃR�[�h�`�F�b�N 
                if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text.Trim()))
                {
                    komokuFlg = true;
                }

                // ���z�̐������`�F�b�N�i�������z�j 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text))
                {
                    seikyu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text.Trim());
                }
                else
                {
                    seikyu = 0M;
                }

                // ���z�̐������`�F�b�N�i�l���z�j 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text))
                {
                    nebiki = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);
                }
                else
                {
                    nebiki = 0M;
                }

                // ���z�̐������`�F�b�N�i�旿���j 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text))
                {
                    tori = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
                }
                else
                {
                    tori = 0M;
                }

                // ���z�������`�F�b�N�P 
                if (seikyu > 0 && tori == 0)
                {
                    kinChkFlg1 = true;
                }

                // ���z�������`�F�b�N�Q 
                if (tori != (seikyu + nebiki))
                {
                    kinChkFlg2 = true;
                }
            }

            DialogResult result;

            bool tempErrFlg = false;
            if (cmbTempCode.SelectedValue == null)
            {
                tempErrFlg = true;
            }
            else
            {
                if (TEMPLATE_ID_00.Equals(cmbTempCode.SelectedValue.ToString()))
                {
                    tempErrFlg = true;
                }
            }
            if (tempErrFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0019
                                        , null
                                        , "�o�^�O�m�F"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            decimal txtKingak = KKHUtility.DecParse(txtSeigak.Text);
            decimal seigak = _dataRow.hb1SeiGak + _dataRow.hb1SzeiGak;
            if (txtKingak != seigak)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0044
                                , null
                                , "���דo�^"
                                , MessageBoxButtons.OK);
                return false;
            }

            if (komokuFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0034
                                        , null
                                        , "�o�^�O�m�F"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (kinChkFlg1)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0043
                                        , null
                                        , "�o�^�O�m�F"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (kinChkFlg2)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0042
                                        , null
                                        , "�o�^�O�m�F"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (sinseiFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_C0004
                                        , null
                                        , "�o�^�O�m�F"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���דo�^���� 
        /// </summary>
        /// <param name="result">�\���f�[�^�o�^�T�[�r�X����</param>
        /// <returns>��������</returns>
        private bool RegistDetailData(out UpdateDisplayDataServiceResult result)
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            //�T�[�r�X�p�����[�^�p�ϐ� 
            Common.KKHSchema.Detail dsDetail = new Common.KKHSchema.Detail();
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dataRow;
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();



            //*********************************************
            //THB2KMEI�̓o�^�f�[�^�ҏW 
            //*********************************************            
            Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //���я��̎擾 
                string _sonota1 = string.Empty;
                DetailSkypProcessController.FindOrderDataByCondParam parameter = new DetailSkypProcessController.FindOrderDataByCondParam();
                parameter.esqId = esqId;
                parameter.egCd = _naviParameter.strEgcd;
                parameter.tksKgyCd = _naviParameter.strTksKgyCd;
                parameter.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                parameter.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
                parameter.yymm = dataRow.hb1Yymm;
                parameter.baitaikbn = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                DetailSkypProcessController process = DetailSkypProcessController.GetInstance();
                FindOrderByCondServiceResult resultNum = process.FindOrderDataByCond(parameter);

                if (resultNum.HasError)
                {
                    throw new Exception();
                }
                if (resultNum.DetailDataSet.OrderData.Rows.Count == 0)
                {
                    _sonota1 = " ";
                }
                else
                {
                    DetailDSSkyp.OrderDataRow row = (DetailDSSkyp.OrderDataRow)resultNum.DetailDataSet.OrderData.Rows[0];
                    _sonota1 = row.narabiJun.ToString();
                }



                Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = _aplId;
                addRow.hb2UpdTnt = _naviParameter.strEsqId;
                addRow.hb2EgCd = _naviParameter.strEgcd;
                addRow.hb2TksKgyCd = _naviParameter.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2Renbn = (i + 1).ToString("000");�@���דo�^�����g���Ή�
                addRow.hb2Renbn = (i + 1).ToString("0000");�@
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KINGAK].Value);
                _seigak += addRow.hb2SeiGak;
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value);

                addRow.hb2Date1 = " ";
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value);
                addRow.hb2Kbn2 = " ";
                addRow.hb2Kbn3 = " ";

                //addRow.hb2Code1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value);
                addRow.hb2Code1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value);
                addRow.hb2Code2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value);
                addRow.hb2Code3 = GetStringValue2(cmbTempCode.SelectedValue);
                //addRow.hb2Code3 = GetStringValue(cmbTempCode.SelectedValue);
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";

                addRow.hb2Name1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DKIKAN].Value);
                addRow.hb2Name2 = " ";
                addRow.hb2Name3 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_JYUTNO].Value);
                addRow.hb2Name4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_JYMEINO].Value);
                addRow.hb2Name5 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_URMEINO].Value);
                addRow.hb2Name6 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_GPYNO].Value); ;
                addRow.hb2Name7 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value);
                //addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value);
                addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text);
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DNAIYO].Value);
                addRow.hb2Name11 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KENMEI].Value;
                addRow.hb2Name12 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DMEISYO].Value;
                addRow.hb2Name13 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                addRow.hb2Kngk1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SYOHI].Value);
                addRow.hb2Kngk2 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TORIGAK].Value);
                addRow.hb2Kngk3 = 0M;

                addRow.hb2Ritu1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value);
                addRow.hb2Ritu2 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value);

                decimal seq2 = GetDecimalValue(_sonota1);
                decimal seq1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SEQ1].Value);



                if (seq2 == 0)
                {
                    addRow.hb2Sonota1 = " ";
                }
                else
                {
                    addRow.hb2Sonota1 = seq2.ToString("000");
                }
                if (seq1 == 0)
                {
                    addRow.hb2Sonota2 = " ";
                }
                else
                {
                    //addRow.hb2Sonota2 = seq1.ToString("000");
                    addRow.hb2Sonota2 = seq1.ToString("0000");
                }

                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";

                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }
                addRow.hb2MeihnFlg = " ";
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);

            //*********************************************
            //THB1DOWN�̓o�^�f�[�^�ҏW 
            //*********************************************
            Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Common.KKHSchema.Detail.THB1DOWNDataTable();
            Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            thb1DownRow.hb1UpdApl = _aplId;
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            thb1DownRow.hb1EgCd = _naviParameter.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;

            //���z�̍��z��������Ɠo�^�ł��Ȃ�����
            thb1DownRow.hb1MSeiFlg = "0";
            //���׍s�����݂���ꍇ 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            //if (_seigak == _seigakSum)
            {
                thb1DownRow.hb1MeisaiFlg = "1";
            }
            else
            {
                thb1DownRow.hb1MeisaiFlg = "0";
            }

            //***************************************
            //�o�^�ҁA�X�V�҂̓o�^
            //***************************************
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;
            //���ׂ��Ȃ��ꍇ
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //�o�^�ҁA�X�V�҂���̏ꍇ
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�
                }
                //�o�^�҂�����ŁA�X�V�҂������Ă���ꍇ
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�
                }
                else
                {
                    //�X�V�҂�o�^
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }
            //���ׂ�����ꍇ
            else
            {
                //�o�^�S���҂��󂩂X�V�҂���łȂ��ꍇ
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�o�^�ҁA�X�V�җ��������
                    //�o�^��
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //�o�^�Җ�
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                //�o�^�҂���̏ꍇ
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //�o�^�҂݂̂�����
                    //�o�^��
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //�o�^�Җ�
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                else
                {
                    //�X�V�҂݂̂�����
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);
            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            //�f�[�^����������Ă���ꍇ�A�q�̌��ƂȂ����f�[�^�ɓo�^�S���ҁA�X�V�҂�o�^����B
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                tokoaddrow.hb1UpdApl = _aplId;
                tokoaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                tokoaddrow.hb1EgCd = _naviParameter.strEgcd;
                tokoaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                tokoaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                tokoaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                tokoaddrow.hb1Yymm = dataRow.hb1Yymm;
                tokoaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                tokoaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                tokoaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                tokoaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                tokoaddrow.hb1MeisaiFlg = thb1DownRow.hb1MeisaiFlg;
                if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                {
                    tokoaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                    tokoaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                }
                else
                {
                    tokoaddrow.hb1TrkTnt = null;
                    tokoaddrow.hb1TrkTntNm = null;
                }
                if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                {
                    tokoaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                    tokoaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                }
                else
                {
                    tokoaddrow.hb1KsnTnt = null;
                    tokoaddrow.hb1KsnTntNm = null;
                }
                TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(tokoaddrow);
            }


            //�X�V���t�ő�l�̔��� 
            if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
            {
                maxUpdDate = dataRow.hb1TimStmp;
            }

            for (int i = 0; i < _fpSpread1_Sheet1.RowCount; i++)
            {
                DateTime dt;
                if (DateTime.TryParse(_fpSpread1_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TIMESTMP].Text, out dt))
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(dt) < 0)
                    {
                        maxUpdDate = dt;
                    }
                }
            }

            Common.KKHProcessController.Detail.DetailProcessController processController =
                Common.KKHProcessController.Detail.DetailProcessController.GetInstance();

            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            //result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            result = processController.UpdateDisplayData(param);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "���דo�^", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "���דo�^", MessageBoxButtons.OK);
                }

                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                return false;
            }
            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

            return true;
        }

        /// <summary>
        /// �����̒l�𕶎���ɕϊ����ԋp���� 
        /// </summary>
        /// <param name="obj">�ϊ��Ώۂ̃I�u�W�F�N�g</param>
        /// <returns>�ϊ���̒l</returns>
        private string GetStringValue(object obj)
        {
            string ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = obj.ToString();
            }
            else
            {
                ret = " ";
            }
            return ret;
        }

        /// <summary>
        /// �����̒l�𕶎���ɕϊ����ԋp����(�e���v���[�g�p) 
        /// </summary>
        /// <param name="obj">�ϊ��Ώۂ̃I�u�W�F�N�g</param>
        /// <returns>�ϊ���̒l</returns>
        private string GetStringValue2(object obj)
        {
            string ret;
            if (obj != null)
            {
                ret = obj.ToString();
            }
            else
            {
                //null�̏ꍇ�A-1��Ԃ� 
                ret = "-1";
            }
            return ret;
        }

        /// <summary>
        /// �����̒l�𐔒l�ɕϊ����ԋp���� 
        /// </summary>
        /// <param name="obj">�ϊ��Ώۂ̃I�u�W�F�N�g</param>
        /// <returns>�ϊ���̒l</returns>
        private decimal GetDecimalValue(object obj)
        {
            decimal ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = KKHUtility.DecParse(obj.ToString());
            }
            else
            {
                ret = 0M;
            }
            return ret;
        }


        /// <summary>
        /// �y�[�X�g���� 
        /// </summary>
        /// <param name="spView"></param>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>
        /// true = �\��t���p�� 
        /// false = �\��t���I�� 
        /// </returns>
        private bool isSetContinuePast(FarPoint.Win.Spread.SpreadView spView, string val, int row, int col)
        {
            SheetView shView = spView.GetSheetView(); ;

            bool multiCopyFlg = true;
            // �R�s�[��O������Try�`Catch�ŋz������ 

            // �L�[=�u��,�s�v�l=�u�\��t���l�v 
            //Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);
            Dictionary<string, string> pastDic = getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // �����R�s�[�łȂ��ꍇ 
                multiCopyFlg = false;
            }

            // �R�s�[���̃Z������
            foreach (string pastKey in pastDic.Keys)
            {
                // �L�[�u��,�s�v�𕪊�
                string[] keySplitArr = pastKey.Split(KKHSystemConst.SPLIT_VAL.ToCharArray());

                // �� 
                int addCol = int.Parse(keySplitArr[0]);
                // �s 
                int addRow = int.Parse(keySplitArr[1]);
                try
                {
                    // �y�[�X�g�Ώۗ� 
                    int colNum = col + addCol;
                    // �y�[�X�g�Ώۍs 
                    int rowNum = row + addRow;

                    // �R�s�[�\�ȗ񂩊m�F���� 
                    if (!isCopyOKColumn(shView, colNum, rowNum))
                    {
                        continue;
                    }

                    // �y�[�X�g 
                    shView.Cells[rowNum, colNum].Text = pastDic[pastKey];

                    // �R�s�[��̃J�����ύX�ɂ�錟�؏��� 
                    ChangeEventArgs changeEvent = new ChangeEventArgs(spView, rowNum, colNum);
                    msgcheck = true;
                    // �Z���ύX�������s 
                    spdKkhDetail_Change(this.spdKkhDetail, changeEvent);
                }
                // �Z���^�C�v�̈Ⴂ���ł̃G���[���p
                catch { }
            }

            return multiCopyFlg;
        }


        /// <summary>
        /// �R�s�[�\��m�F 
        /// </summary>
        /// <param name="shView"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isCopyOKColumn(SheetView shView, int col, int row)
        {
            Column actColumn = shView.Columns[col];
            if (actColumn.Locked)
            {
                // ���b�N����Ă���ꍇ 
                return false;
            }

            //��\����ւ͓\��t���s�Ƃ���
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType ||
                actColumn.CellType is NumberCellType)
            {
                // �Z���^�C�v���e�L�X�g�̏ꍇ 
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }
            //���ڃR�[�h�͋����� 
            if (actColumn.Index == DetailSkyp.COLIDX_MLIST_KOMOKUCODE)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// ���s�A�^�u�ŋ�؂����l���擾 
        /// </summary>
        /// <param name="val"></param>
        /// <returns>pastDic</returns>
        public static Dictionary<string, string> getPastValueDic(string val)
        {
            Dictionary<string, string> pastDic = new Dictionary<string, string>();

            string[] rowPastArr = val.Split('\n');

            for (int rowCnt = 0; rowCnt < rowPastArr.Length; rowCnt++)
            {
                string rowVal = rowPastArr[rowCnt].Replace("\r", string.Empty);

                if (string.IsNullOrEmpty(rowVal))
                {
                    continue;
                }

                string[] colPastArr = rowVal.Split('\t');
                for (int colCnt = 0; colCnt < colPastArr.Length; colCnt++)
                {
                    string key = string.Join(",", new string[] { colCnt.ToString(), rowCnt.ToString() });
                    pastDic.Add(key, colPastArr[colCnt]);
                }
            }

            return pastDic;
        }


        #endregion ���\�b�h

    }
}
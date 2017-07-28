using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Ash.Utility;

namespace Isid.KKH.Ash.View.Detail
{
    public partial class DetailSetTimeAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        # region �萔
        /// <summary>
        /// �j��
        /// </summary>
        private const int C_WEEK_ROW = 0;
        /// <summary>
        /// �J�n�s
        /// </summary>
        private const int C_DAY_ROW = 1;
        /// <summary>
        ///  DataGridView�̑I�������w�i�F
        /// </summary>
        private static readonly Color C_DGV_SELECT_BACKCOLOR = Color.SkyBlue;
        /// <summary>
        /// DataGridView�̃f�t�H���g�̔w�i�F
        /// </summary>
        private static readonly Color C_DGV_DEFAULT_BACKCOLOR = Color.White;
        #endregion �萔

        #region �����o�ϐ�
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable dtDetail = null;
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        DataGridViewCell sCell; //�N���b�N�����Z��.
        DataGridViewCell eCell; //�N���b�N�𗣂����Z��.
        string _mHosoBi = string.Empty;
        #endregion �����o�ϐ�

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public DetailSetTimeAsh()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^

        # region �C�x���g 

        /// <summary>
        /// �n�j�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //���׌������A�J��Ԃ� 
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //����  
                string kikan = dtpKikanFrom.Value.ToShortDateString().Replace("/", "") +
                                  dtpKikanTo.Value.ToShortDateString().Replace("/", "");
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = keisaiDt;
                //DataTable�̕��������H 
                //dtDetail[i].kikan = keisaiDt;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = kikan;
                //�������ԁA�H������ TODO ���ݒ�ɂ͂ł��Ȃ� 
                string hosouJikan = dtpHosouJikanFrom.Value.ToString("HH:mm") + "-" +
                                    dtpHosouJikanTo.Value.ToString("HH:mm");
                //dtDetail[i].housouZikan = hosouJikan;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = hosouJikan;
                //�j�� 
                //�}�̃R�[�h���e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ 
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.
                    )
                {
                    //dtDetail[i].youbi = setYoubi();
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = setYoubi();
                }
                //�}�̃R�[�h���e���r�^�C���ȊO�̏ꍇ 
                else
                {
                    //dtDetail[i].youbi = " ";
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = " ";
                }
                //�ǃl�b�g�� 
                //dtDetail[i].kyokuNetSuu = txtKyokuNetSu.Text.PadLeft(3, '0');
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Value = txtKyokuNetSu.Text.PadLeft(3, '0');
                //�L�[��
                //dtDetail[i].keyKyokuCd = cmbKeyKyokuCd.Text;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Value = cmbKeyKyokuCd.Text;
                //�X�y�[�X 
                //dtDetail[i].space = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_SPACE].Value = " ";
                //���[�敪 
                //dtDetail[i].asaYuuKbn = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = " ";
                //�f�ڔ� 
                //dtDetail[i].keisaiBan = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = " ";
                //�L�G�敪 
                //dtDetail[i].kizatsuKbn = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = " ";
            }
            //_naviParam.DataTable1 = dtDetail;

            //Navigator.Backward(this, _naviParam, null, true);
            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSetTimeAsh_Load(object sender, EventArgs e)
        {
            // �e�R���g���[���̏����� 
            InitializeControl();
            // �e�R���g���[���̕ҏW 
            editControl();
        }

        /// <summary>
        /// DataGridViewCellPainting�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex.Equals(0))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        /// <summary>
        /// DataGridViewMouseClick�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //�w�_�[�͏������Ȃ� 
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                dgbYoubi.ClearSelection();
                return;
            }
            //������ 
            sCell = null;
            eCell = null;

            //���݃Z���̈ʒu���擾����B 
            sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
            eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////�Z����BackColor���Z�b�g����B 
            if (e.Button == MouseButtons.Left)
            {
                //���݃Z���̈ʒu���擾����B 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                //���ɂ��������ꍇ�͏������Ȃ� 
                if (dgbYoubi[e.ColumnIndex, e.RowIndex].Value == null
                    || dgbYoubi[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    return;
                }
                //���I���Ȃ�F��t���� 
                if (!dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                {
                    dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                }
                else
                {
                    dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                }
                return;
            }
        }

        /// <summary>
        /// DataGridViewMouseDown�C�x���g. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //�w�_�[�͏������Ȃ� 
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                dgbYoubi.ClearSelection();
                return;
            }
            //������ 
            sCell = null;
            eCell = null;

            //���݃Z���̈ʒu���擾����B 
            sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
            eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////�Z����BackColor���Z�b�g����B 
            if (e.Button == MouseButtons.Right)
            {
                //���݃Z���̈ʒu���擾����B 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                dgbYoubi[e.ColumnIndex, e.RowIndex].Selected = true;
                return;
            }
        }

        /// <summary>
        /// DataGridViewMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgbYoubi.ClearSelection();
        }

        /// <summary>
        /// DataGridViewDoubleClick�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //������ 
            sCell = null;
            eCell = null;

            //�w�_�[�̏ꍇ 
            if (e.RowIndex == 0)
            {
                //���݃Z���̈ʒu���擾���� 
                sCell = dgbYoubi[e.ColumnIndex, 0];
                eCell = dgbYoubi[e.ColumnIndex, 0];

                //��̔w�i�F�ɐF��t���� 
                //���I���Ȃ�F��t���� 
                for (int row = 1; row < dgbYoubi.RowCount; row++)
                {
                    //���ɂ��������ꍇ�͏������Ȃ� 
                    if (dgbYoubi[e.ColumnIndex, row].Value == null
                        || dgbYoubi[e.ColumnIndex, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        if (!dgbYoubi[e.ColumnIndex, row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            dgbYoubi[e.ColumnIndex, row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            dgbYoubi[e.ColumnIndex, row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;
            }
            else
            {
                //���݃Z���̈ʒu���擾���� 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                //�s�̔w�i�F�ɐF��t���� 
                //���I���Ȃ�F��t���� 
                for (int col = e.ColumnIndex + 1; col < dgbYoubi.ColumnCount; col++)
                {
                    //���ɂ��������ꍇ�͏������Ȃ� 
                    if (dgbYoubi[col, e.RowIndex].Value == null
                        || dgbYoubi[col, e.RowIndex].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //�w�i�F���I��F�ȊO�̏ꍇ 
                        if (!dgbYoubi[col, e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //�w�i�F��I��F�ɂ��� 
                            dgbYoubi[col, e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            //�w�i�F�����ɖ߂� 
                            dgbYoubi[col, e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;

            }

        }

        /// <summary>
        /// �N���A�{�^���C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            //�I���N���A 
            clearSelection();
        }

        /// <summary>
        /// ���ԁiFrom�j�t�H�[�J�X�A�E�g 
        /// </summary>
        private void dtpKikanFrom_Leave(object sender, EventArgs e)
        {
            //���ԁiFrom�j�����ԁiTo�j�̏ꍇ 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // ���ԁiTo�j�Ɋ��ԁiFrom�j�̒l��ݒ� 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }

            String strKikanFrom = dtpKikanFrom.Value.ToShortDateString().Replace("/", "");
            strKikanFrom = strKikanFrom.Substring(0, 6);
            String strYoubi = lblYoubi.Text.Replace("/", "");
            strYoubi = strYoubi.Replace(" ", "");
            //���ԁiFrom�j�Ɨj���̔N�����قȂ�ꍇ 
            if (strKikanFrom.Equals(strYoubi) == false)
            {
                //�J�����_�[�̑I����Ԃ��N���A 
                clearSelection();
                //�j���̔N���Ɋ��ԁiFrom�j�̃J�����_�[��\�� 
                String strKikanFromYear = strKikanFrom.Substring(0, 4);
                String strKikanFromMonth = strKikanFrom.Substring(4, 2);
                //���x���ɕ�������\������
                lblYoubi.Text = strKikanFromYear + " / " + strKikanFromMonth;
                //�\������N��.
                DateTime[] days = GetGeshi(int.Parse(strKikanFromYear), int.Parse(strKikanFromMonth));
                makeCalendar(days);
            }

        }

        /// <summary>
        /// ���ԁiTo�j�t�H�[�J�X�A�E�g 
        /// </summary>
        private void dtpKikanTo_Leave(object sender, EventArgs e)
        {
            //���ԁiFrom�j�����ԁiTo�j�̏ꍇ 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // ���ԁiTo�j�Ɋ��ԁiFrom�j�̒l��ݒ� 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailSetTimeAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
                dtDetail = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)_naviParam.DataTable1;
            }
        }


        # endregion �C�x���g

        # region ���\�b�h

        /// <summary>
        /// �e�R���g���[���̏����\������  
        /// </summary>
        private void InitializeControl()
        {
            //�e�L�X�g�{�b�N�X������ 
            txtKyokuNetSu.Text = "0";
        }

        /// <summary>
        /// �e�R���g���[���̕ҏW���� 
        /// </summary>
        private void editControl()
        {

            /*
             * ���ԁiFrom�ATo�j 
             */
            String strKikan = null;
            strKikan =
            _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KEISAIDT].Text.Replace("/", "").Trim();
            //_spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KIKAN].Text.Replace("�N", "").Replace("��", "").Replace("��", "").Replace(" - ", "").Trim();
            if (!String.IsNullOrEmpty(strKikan) && (strKikan.Length == 8 || strKikan.Length == 16))
            {
                String strKikanFrom = strKikan.Substring(0, 8);
                if (KKHUtility.IsDate(strKikanFrom, "yyyyMMdd") == true)
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(strKikanFrom);
                }
                else
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }

                String strKikanTo = null;
                if (strKikan.Length == 8)
                {
                    strKikanTo = strKikan.Substring(0, 8);
                }
                else
                {
                    strKikanTo = strKikan.Substring(8, 8);
                }

                if (KKHUtility.IsDate(strKikanTo, "yyyyMMdd") == true)
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(strKikanTo);
                }
                else
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }
            }
            else
            {
                dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
            }

            /*
             * �������ԁiFrom�ATo�j 
             */
            String strHosouJikan = null;
            strHosouJikan = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Text.Trim();
            int delimiter = strHosouJikan.IndexOf("-");
            if (!String.IsNullOrEmpty(strHosouJikan))
            {
                String strHosouJikanFrom = strHosouJikan.Substring(0, delimiter);
                DateTime dateHosouJikanFrom;
                if (DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + strHosouJikanFrom + ":00", out dateHosouJikanFrom) == true)
                {
                    dtpHosouJikanFrom.Value = dateHosouJikanFrom;
                }
                else
                {
                    //TODO DateTimePicker�͏����l��NULL��ݒ�s�� 
                    dtpHosouJikanFrom.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                }
                String strHosouJikanTo = strHosouJikan.Substring(delimiter + 1);
                DateTime dateHosouJikanTo;
                if (DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + strHosouJikanTo + ":00", out dateHosouJikanTo) == true)
                {
                    dtpHosouJikanTo.Value = dateHosouJikanTo;
                }
                else
                {
                    //TODO DateTimePicker�͏����l��NULL��ݒ�s�� 
                    dtpHosouJikanTo.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                }
            }
            else
            {
                //TODO DateTimePicker�͏����l��NULL��ݒ�s�� 
                dtpHosouJikanFrom.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                dtpHosouJikanTo.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
            }

            /*
             * �ǃl�b�g�� 
             */
            int intKyokuNetSu = 0;
            //���ד��̓X�v���b�h�D�ǃl�b�g�������l�̏ꍇ 
            if (int.TryParse(_spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Text.Trim(), out intKyokuNetSu) == true)
            {
                //���ד��̓X�v���b�h�D�ǃl�b�g�� 
                txtKyokuNetSu.Text = intKyokuNetSu.ToString();
            }
            //���ד��̓X�v���b�h�D�ǃl�b�g�������l�ȊO�̏ꍇ 
            else
            {
                //0��ݒ� 
                txtKyokuNetSu.Text = "0";
            }

            /*
             * �L�[�ǃR�[�h 
             */
            //�R���{�{�b�N�X�̏�����  
            cmbKeyKyokuCd.Items.Clear();
            List<string> kyokuRyakusyoList = new List<string>();
            //���ד��̓X�v���b�h�̌������A�J��Ԃ� 
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                String kyokuCd = _spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUCD].Text.Trim();
                int firstSpaceIndex = kyokuCd.IndexOf(" ", 0);
                int secondSpaceIndex = 0;
                if (firstSpaceIndex > 0)
                {
                    secondSpaceIndex = kyokuCd.IndexOf(" ", firstSpaceIndex + 1);
                }
                if (firstSpaceIndex > 0 && secondSpaceIndex > 0)
                {
                    //���ד��̓X�v���b�h�D�ǃR�[�h�̋Ǘ��́i�ǃR�[�h��2�u���b�N�j��ݒ� 
                    String kyokuRyakusyo = kyokuCd.Substring(firstSpaceIndex + 1, secondSpaceIndex - firstSpaceIndex - 1);
                    //�d�����Ă��Ȃ��ꍇ 
                    if (kyokuRyakusyoList.Contains(kyokuRyakusyo) == false)
                    {
                        kyokuRyakusyoList.Add(kyokuRyakusyo);
                    }
                }
            }

            /*
             * �ǃR�[�h�ϊ��}�X�^�擾 
             */
            //�Ǘ��̂��P���R�[�h�����݂��Ȃ��ꍇ 
            if (kyokuRyakusyoList.Count == 0)
            {
                //�}�̃R�[�h���e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ 
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true  // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.
                    )
                {
                    //�e���r�ǃR�[�h�ϊ��}�X�^�擾 
                    MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                    FindMasterMaintenanceByCondServiceResult result;
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                    _naviParam.strEgcd,
                                                    _naviParam.strTksKgyCd,
                                                    _naviParam.strTksBmnSeqNo,
                                                    _naviParam.strTksTntSeqNo,
                                                    Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU_HENNKAN,
                                                    "");
                    MasterMaintenance.MasterDataVODataTable dsKeyKyokuCd = new MasterMaintenance.MasterDataVODataTable();
                    dsKeyKyokuCd.Merge(result.MasterDataSet.MasterDataVO);
                    dsKeyKyokuCd.AcceptChanges();
                    cmbKeyKyokuCd.DisplayMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.ValueMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.DataSource = dsKeyKyokuCd;
                }
                //�}�̃R�[�h����L�ȊO�̏ꍇ 
                else
                {
                    //���W�I�ǃR�[�h�ϊ��}�X�^�擾 
                    MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                    FindMasterMaintenanceByCondServiceResult result;
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                    _naviParam.strEgcd,
                                                    _naviParam.strTksKgyCd,
                                                    _naviParam.strTksBmnSeqNo,
                                                    _naviParam.strTksTntSeqNo,
                                                    Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU_HENNKAN,
                                                    "");
                    MasterMaintenance.MasterDataVODataTable dsKeyKyokuCd = new MasterMaintenance.MasterDataVODataTable();
                    dsKeyKyokuCd.Merge(result.MasterDataSet.MasterDataVO);
                    dsKeyKyokuCd.AcceptChanges();
                    cmbKeyKyokuCd.DisplayMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.ValueMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.DataSource = dsKeyKyokuCd;
                }
            }
            //�Ǘ��̂����݂���ꍇ 
            else
            {
                List<AshComboBoxItem> items = new List<AshComboBoxItem>();
                for (int i = 0; i < kyokuRyakusyoList.Count; i++)
                {
                    items.Add(new AshComboBoxItem(kyokuRyakusyoList[i], kyokuRyakusyoList[i]));
                }
                cmbKeyKyokuCd.DisplayMember = "NAME";
                cmbKeyKyokuCd.ValueMember = "CODE";
                cmbKeyKyokuCd.DataSource = items;
            }
            //�����l��ݒ� 
            cmbKeyKyokuCd.SelectedValue = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Text.Trim();

            /*
             * �J�����_�[ 
             */
            int _iNen = int.Parse(dtpKikanFrom.Value.Year.ToString());
            int _iGetsu = int.Parse(dtpKikanFrom.Value.Month.ToString());
            //�N���̃��x����ݒ� 
            lblYoubi.Text = _iNen.ToString() + " / " + String.Format("{0:00}", _iGetsu);
            //�J�����_�[�ɕ\������N�� 
            DateTime[] days = GetGeshi(_iNen, _iGetsu);
            //2015/03/10 miyanoue �A�T�q�Ή� Start
            //_mHosoBi = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_YOUBI].Text.Trim();
            _mHosoBi = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_YOUBI].Text.Trim();
            //2015/03/10 miyanoue �A�T�q�Ή� End
            //�J�����_�[�쐬 
            makeCalendar(days);
            //�}�̃R�[�h���e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ 
            if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd)  // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.
                )
            {
                //�������ݒ� 
                serHousouBi();
            }
            //�}�̃R�[�h����L�ȊO�̏ꍇ 
            else
            {
                //�J�����_�[������ 
                dgbYoubi.Enabled = false;
            }
            //�j�����ڂ̖�����
            if (!KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                && !KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd)  // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.
                )
            {
                grpYoubi.Enabled = false;
                dispDisabledCalendar();
            }
        }

        /// <summary>
        /// �N�����擾����.
        /// </summary>
        /// <param name="y">�NYYYY</param>
        /// <param name="m">��MM</param>
        /// <returns></returns>
        static DateTime[] GetGeshi(int y, int m)
        {
            List<DateTime> days = new List<DateTime>();

            //for (DateTime d = new DateTime(y, m, 1); d.Month == m; d = d.AddDays(1))
            //{
            //    days.Add(d);
            //}

            int dayMax = DateTime.DaysInMonth(y, m);

            for (int day = 1; day <= dayMax; day++)
            {
                days.Add(new DateTime(y, m, day));
            }

            return days.ToArray();
        }

        /// <summary>
        /// �J�����_�[�쐬 
        /// </summary>
        private void makeCalendar(DateTime[] days)
        {
            int cnt = 1;
            int intsta = 0;
            int introw = C_DAY_ROW;

            //�s���쐬 
            dgbYoubi.RowCount = 7;

            //��ʕ\�����I�������Ȃ� 
            dgbYoubi.CurrentCell = null;

            //�I���N���A 
            clearSelection();

            //���t�N���A 
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    dgbYoubi[j, i].ReadOnly = true;
                    dgbYoubi[j, i].Value = "";
                }
            }

            //�Ώی��̓���  
            int currentMonthDays = days.Length;

            # region ���t�Z�b�g
            for (int daysIndex = 0; daysIndex < currentMonthDays; daysIndex++)
            {
                DateTime d = days[daysIndex];
                //�J�n�ʒu�����߂� 
                if (cnt == 1)
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgbYoubi[0, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 0;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Monday)
                    {
                        dgbYoubi[1, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 1;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        dgbYoubi[2, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 2;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        dgbYoubi[3, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 3;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Thursday)
                    {
                        dgbYoubi[4, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 4;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Friday)
                    {
                        dgbYoubi[5, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 5;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dgbYoubi[6, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 6;
                    }
                }
                else
                {
                    //7�Ŋ���؂ꂽ�ꍇ�A�܂�1�T�ԕ��쐬��������s 
                    if (intsta % 7 == 0)
                    {
                        introw++;
                        intsta = 0;
                    }
                    dgbYoubi[intsta, introw].Value = cnt.ToString();
                }
                cnt++;
                intsta++;
            }
            # endregion ���t�Z�b�g

            # region �j���Z�b�g
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 1:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 2:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 3:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 4:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 5:
                        dgbYoubi[i, C_WEEK_ROW].Value = "��";
                        break;
                    case 6:
                        dgbYoubi[i, C_WEEK_ROW].Value = "�y";
                        break;
                }
            }

            # endregion �j���Z�b�g

            # region �Z���ݒ�.
            //�f�U�C�i�[�ŋL�q�����̂ŕs�v 
            for (int i = 0; i < 7; i++)
            {
                //��̕��𑵂��� 
                dgbYoubi.Columns[i].Width = 35;
                //�E�񂹂ɂ��� 
                dgbYoubi.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            # endregion �Z���ݒ�.

        }

        /// <summary>
        /// �������ݒ� 
        /// </summary>
        private void serHousouBi()
        {
            if (_mHosoBi == "")
            {
                return;
            }
            int _iDayCnt = 0;
            string _hosoBi = string.Empty;
            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //���ɂ��������ꍇ�͏������Ȃ� 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //�p�����[�^�̕��������Z�b�g 
                        if (_iDayCnt < 31)
                        {
                            //�ꕶ�����擾���� 
                            _hosoBi = _mHosoBi.Substring(_iDayCnt, 1);

                            //0��1�����肷��B  
                            if (_hosoBi.Equals("1"))
                            {
                                //1�̏ꍇ�A�w�i�F��I��F�ɂ��� 
                                dgbYoubi[col, row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                            }
                            //���� 
                            _iDayCnt++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �I���N���A 
        /// </summary>
        private void clearSelection()
        {
            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //���ɂ��������ꍇ�͏������Ȃ� 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        dgbYoubi[col, row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                    }
                }
            }
        }

        /// <summary>
        /// �J�����_�[�������\�� 
        /// </summary>
        private void dispDisabledCalendar()
        {
            dgbYoubi.BorderStyle = BorderStyle.Fixed3D;

            for (int row = 0; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    dgbYoubi[col, row].Style.ForeColor = Color.Gray;
                }
            }
        }

        /// <summary>
        /// �j���̐ݒ� 
        /// </summary>
        private String setYoubi()
        {
            string _dayCnt = string.Empty;

            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //���ɂ��������ꍇ�͏������Ȃ� 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //�w�i�F���I�����Ă���ꍇ 
                        if (dgbYoubi[col, row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //�I�����Ă���ꍇ 
                            _dayCnt += "1";
                            //_sb.Append("0");
                        }
                        else
                        {
                            //�I�����Ă��Ȃ��ꍇ 
                            _dayCnt += "0";
                            //_sb.Append("0");
                        }
                    }
                }
            }

            while (_dayCnt.Length < 31)
            {
                _dayCnt += "0";
            }
            return _dayCnt;
        }

        # endregion ���\�b�h
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
namespace Isid.KKH.Toh.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailInputToh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �����o�ϐ�.

        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIndex = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private String _currentKenNm = "";

        // ����A�h�Ή� 2015/06/12 add HLC K.Soga start
        /// <summary>
        /// �[�i�敪��ʁF006
        /// </summary>
        private const string NOUHINKBN_SYBT = "006";

        /// <summary>
        /// �[�i�敪�i1�F�f��A2�F�����j�FNOUHINKBN
        /// </summary>
        private const string NOUHINKBN_FIELD1 = "NOUHINKBN";
        // ����A�h�Ή� 2015/06/12 add HLC K.Soga end
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public DetailInputToh()

        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        /// <summary>
        /// �n�j�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // �f�ړ��`�F�b�N.
            if (this.IsDateTime(txtKeisaiDt.Text.Trim()) == false)
            {
                string[] paramString ={ "�f�ړ�" };
                MessageUtility.ShowMessageBox(MessageCode.HB_W0003, paramString, "�f�ړ�", MessageBoxButtons.OK);

                txtKeisaiDt.Focus();
                return;
            }

            // �X�y�[�X�Q�`�F�b�N����.
            if (txtSpace2.Text.Trim() != "")
            {
                if (this.IsSpace2Check(txtSpace2.Text.Trim()) == false)
                {
                    // �`�F�b�N�G���[��.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0014, null, "�X�y�[�X2", MessageBoxButtons.OK);

                    txtSpace2.Focus();
                    return;
                }
            }

            // ���ׂ��Ȃ��ꍇ.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                // �P�s�ǉ�.
                _spdKkhDetail_Sheet1.AddRows(_rowDetailIndex, 1);
                _spdKkhDetail_Sheet1.AddSelection(_rowDetailIndex, -1, 1, -1);
            }
            // ���׃X�v���b�h�ɓ��͓��e��ݒ�.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Value = txtKenNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAINM].Value = txtBaitaiNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAICD].Value = txtBaitaiCd.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KBN].Value = cmbKbn.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KEISAIDT].Value = txtKeisaiDt.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_TANKA].Value = txtTanka.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Value = txtSpace.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE2].Value = txtSpace2.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_RYOUKIN].Value = txtRyoukin.Text.Trim();

            // ����őΉ� 2013/10/08 add HLC H.watabe start
            if (txtShohizei.Text.Trim() == string.Empty)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Value = 0;
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Value = txtShohizei.Text.Trim();
            }
            // ����őΉ� 2013/10/08 add HLC H.watabe end
            
            if (chkWak.Checked)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Value = "1";
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Value = "";
            }
            // �������ύX����Ă���ꍇ.
            if (_currentKenNm.Equals(txtKenNm.Text.Trim()) == false)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEICHGFLG].Value = "1";
            }
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_NOUHINKBN].Value = txtNouhinKbn.Text.Trim();

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

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

        /// <summary>
        /// �t�H�[�����[�h�C�x���g,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputToh_Load(object sender, EventArgs e)
        {
            // �e�R���g���[���̏�����,
            InitializeControl();
            // �e�R���g���[���̕ҏW,
            editControl();
        }

        /// <summary>
        /// �e�R���g���[���̏����\������,
        /// </summary>
        private void InitializeControl()
        {
            // �e�L�X�g�{�b�N�X,
            txtKenNm.Text = "";
            txtBaitaiNm.Text = "";
            txtBaitaiCd.Text = "";
            txtKeisaiDt.Text = "";
            txtTanka.Text = "";
            txtSpace.Text = "";
            txtSpace2.Text = "";
            txtRyoukin.Text = "";
            txtNouhinKbn.Text = "";
            // �R���{�{�b�N�X,
            cmbKbn.Items.Clear();
            cmbKbn.Items.Add("M");
            cmbKbn.Items.Add("E");
            // �`�F�b�N�{�b�N�X.
            chkWak.Checked = false;

            // 2014/02/05 add JSE K.Tamura start
            // �e�R���g���[���̃^�u�C���f�b�N�X���C�������̂ŁA�����t�H�[�J�X��ݒ肵�Ă���.
            // �����t�H�[�J�X.
            this.ActiveControl = cmbKbn;
            // 2014/02/05 add JSE K.Tamura end
        }

        /// <summary>
        /// �e�R���g���[���̕ҏW����.
        /// </summary>
        private void editControl()
        {
            // ���ׂ��Ȃ��ꍇ.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //�X�y�[�X2�}�X�^����.
                MasterMaintenanceProcessController mastProcessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = mastProcessController.FindMasterByCond(_naviParam.strEsqId,
                                                                                                                        _naviParam.strEgcd,
                                                                                                                        _naviParam.strTksKgyCd,
                                                                                                                        _naviParam.strTksBmnSeqNo,
                                                                                                                        _naviParam.strTksTntSeqNo,
                                                                                                                        "0002",
                                                                                                                        null);
                // ����A�h�Ή� 2015/06/12 add HLC K.Soga start
                // �ėp�V�X�e���}�X�^����.
                CommonProcessController commonProcessController = CommonProcessController.GetInstance();
                FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(_naviParam.strEsqId,
                                                                                                                    _naviParam.strEgcd,
                                                                                                                    _naviParam.strTksKgyCd,
                                                                                                                    _naviParam.strTksBmnSeqNo,
                                                                                                                    _naviParam.strTksTntSeqNo,
                                                                                                                    NOUHINKBN_SYBT,
                                                                                                                    NOUHINKBN_FIELD1);
                // ����A�h�Ή� 2015/06/12 add HLC K.Soga end

                if (result.HasError)
                {
                    throw new Exception();
                    return;
                }

                _currentKenNm = _dataRow.hb1KKNameKJ.ToString().Trim();
                txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                txtBaitaiNm.Text = _dataRow.hb1Field2.ToString().Trim();
                txtBaitaiCd.Text = _dataRow.hb1Field1.ToString().Trim();

                // �����̏ꍇ.
                if ("1".Equals(_dataRow.hb1Field4.ToString().Trim()))
                {
                    cmbKbn.SelectedIndex = 0;
                }
                // �[���̏ꍇ.
                else
                {
                    cmbKbn.SelectedIndex = 1;
                }
                // �f�ړ����Ȃ��ꍇ.
                if ("".Equals(_dataRow.hb1Field3.ToString().Trim())) {
                    txtKeisaiDt.Text = "";

                }
                // �f�ړ�������ꍇ.
                else
                {
                    String keisaiDt = _dataRow.hb1Field3.ToString().Trim();
                    keisaiDt = keisaiDt.Substring(0, 4) + "/" + keisaiDt.Substring(4, 2) + "/" + keisaiDt.Substring(6,2);
                    txtKeisaiDt.Text = keisaiDt;
                }
                txtTanka.Text = _dataRow.hb1SeiTnka.ToString("###,###,###,##0");

                /*
                 * �X�y�[�X.
                 */
                String space = _dataRow.hb1Field11.ToString().Trim();
                //10���ȏ゠��ꍇ.
                if (space.Length > 10)
                {
                    //10���܂ł��擾.
                    space = space.Substring(0, 10);
                }
                // �X�y�[�X��"D"���܂܂�Ă���A����"X"���܂܂�Ă��Ȃ��ꍇ.
                if (space.IndexOf("D") >= 0 && space.IndexOf("X") < 0)
                {
                    // �X�y�[�X�̍Ōオ"D"�̏ꍇ.
                    if (space.IndexOf("D") == space.Length - 1)
                    {
                        // �Ō��"D"���폜.
                        space = space.Substring(0, space.Length - 1);
                    }
                    // ��L�ȊO�̏ꍇ.
                    else
                    {
                        int index = space.IndexOf("D");
                        // �ŏ���"D"��"*"�ɕϊ�.
                        space = space.Substring(0, space.IndexOf("D")) + "*" + space.Substring(space.IndexOf("D") + 1);
                    }
                }

                txtSpace.Text = space;

                /*
                 * �X�y�[�X�Q.
                 */
                //�X�y�[�X�Q�ꗗ�̒l���擾����.
                if (result.MasterDataSet.MasterDataVO.Select("Column1 = '" + _dataRow.hb1Field11.Trim() + "'").Length > 0)
                {
                    MasterMaintenance.MasterDataVORow mstRow = (MasterMaintenance.MasterDataVORow)result.MasterDataSet.MasterDataVO.Select("Column1 = '" + _dataRow.hb1Field11.Trim() + "'")[0];
                    txtSpace2.Text = mstRow.Column2.Trim();
                }

                txtRyoukin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                // ����őΉ� 2013/10/08 add HLC H.Watabe start
                txtShohizei.Text = Math.Truncate(_dataRow.hb1SzeiRitu).ToString();
                // ����őΉ� 2013/10/08 add HLC H.Watabe end

                // ����A�h�Ή� 2015/06/12 mod HLC K.Soga start
                //txtNouhinKbn.Text = "1";

                // �ėp�V�X�e���}�X�^�ɔ[�i�敪�f�[�^��1���ȏ㑶�݂���ꍇ.
                if (comResult.CommonDataSet.SystemCommon.Count != 0)
                {
                    // �[�i�敪���ɐ��l�����(1:�f��, 2:����).
                    txtNouhinKbn.Text = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
                }
                else
                {
                    // �f�[�^���ꌏ���Ȃ��ꍇ�A�����\�����Ȃ�.
                    txtNouhinKbn.Text = string.Empty;
                }
                // ����A�h�Ή� 2015/06/12 mod HLC K.Soga end

                // �g�t���O.
                chkWak.Checked = false;
            }
            // ���ׂ�����ꍇ.
            else
            {
                _currentKenNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Text.Trim();
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Text.Trim();
                txtBaitaiNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAINM].Text.Trim();
                txtBaitaiCd.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAICD].Text.Trim();
                // �[���̏ꍇ.
                if ("E".Equals(_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KBN].Text.Trim()))
                {
                    cmbKbn.SelectedIndex = 1;
                }
                // �����̏ꍇ.
                else
                {
                    cmbKbn.SelectedIndex = 0;
                }
                txtKeisaiDt.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KEISAIDT].Text.Trim();
                txtTanka.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_TANKA].Text.Trim();
                if (_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim().Length > 10)
                {
                    txtSpace.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim().Substring(0, 10);
                }
                else
                {
                    txtSpace.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim();
                }
                txtSpace2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE2].Text.Trim();
                txtRyoukin.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_RYOUKIN].Text.Trim();
                // ����őΉ� 2013/10/08 add HLC H.Watabe start
                txtShohizei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Text.Trim();
                // ����őΉ� 2013/10/08 add HLC H.Watabe end
                txtNouhinKbn.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_NOUHINKBN].Text.Trim();
                if (_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Text.Trim().Equals("1"))
                {
                    chkWak.Checked = true;
                }
                else
                {
                    chkWak.Checked = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRow;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
            }
        }

        #region �X�y�[�X�Q�ϊ�����.

        /// <summary>
        /// �X�y�[�X�Q�ϊ�����.
        /// 
        /// �@�X�y�[�X�̓��e���ȉ��̒ʂ�ϊ�.
        /// �E�S�p�˔��p�A�啶���ˏ������ɕϊ�.
        /// �E0�`9�Adx/*.�~���ȊO�̕����E�L�����폜.
        /// 
        /// �A*�A/ �̗L���ɂ��A�ȉ��̒ʂ�v�Z����.
        /// �E*�A/ ����.
        ///     �ˌv�Z�p�^�[���F(X * Y / Z).
        /// �E* ����.
        ///     �ˌv�Z�p�^�[���F(X * Y).
        /// �E/ ����.
        ///     �ˌv�Z�p�^�[���F(Y / Z).
        /// �E*�A/ �Ȃ�.
        ///     �ˌv�Z�p�^�[���Ȃ� ���� ���l.
        ///         �˃X�y�[�X�̓��e��ԋp.
        ///     �ː��l�ȊO.
        ///         �˃u�����N.
        /// </summary>
        /// <param name="space">�X�y�[�X�Q�ϊ���������</param>
        /// <returns>�X�y�[�X�Q�ϊ��㕶����</returns>
        public String space2ConversionMethod(String space)
        //private String space2ConversionMethod(String space)
        {
            //********************
            // �S�p�˔��p�ϊ�.
            //********************
            //String space2Conversion = Strings.StrConv(space, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
            String space2Conversion = KKHStrConv.toNarrow(space);

            //********************
            // �啶���ˏ������ϊ�.
            //********************
            //space2Conversion = Strings.StrConv(space2Conversion, Microsoft.VisualBasic.VbStrConv.Lowercase, 0);
            space2Conversion = KKHStrConv.toLower(space2Conversion);

            //********************
            // ���K�\���ݒ�.
            //********************
            String matchPattern = "[^0-9d/*.]";
            String regularExpressionPattern = "[0-9dx/*.�~��]";

            //"[0-9d/*.]"�ȊO�̕���������ꍇ�Atrue
            bool chk = Regex.IsMatch(space2Conversion, matchPattern);

            //"[0-9d/*.]"�ȊO�̕���������ꍇ.
            if (chk)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            MatchCollection mc = Regex.Matches(space2Conversion, regularExpressionPattern);

            // ���K�\���Őݒ肵�������̂ݎ擾.
            foreach (Match m in mc)
            {
                sb.Append(m.Value);
            }

            space2Conversion = sb.ToString();

            //********************
            // x�~ �� * �ɕϊ�.
            //********************
            String multiplicationConversionPattern = "[x�~]";
            Regex reg = new Regex(multiplicationConversionPattern);
            space2Conversion = reg.Replace(space2Conversion, "*");

            //********************
            // �� �� / �ɕϊ�.
            //********************
            String divisionConversionPattern = "[��]";
            reg = new Regex(divisionConversionPattern);
            space2Conversion = reg.Replace(space2Conversion, "/");

            //********************************************
            // �X�y�[�X��"d"���܂܂�Ă���ꍇ�̏���.
            //********************************************
            if (space2Conversion.IndexOf("d") >= 0)
            {
                // �X�y�[�X��"d"���܂܂�Ă���ꍇ.
                String etcConversionPattern = "[d]";
                reg = new Regex(etcConversionPattern);

                if (space2Conversion.IndexOf("*") < 0)
                {
                    // �X�y�[�X��"*"���܂܂�Ă��Ȃ��ꍇ.
                    if (space2Conversion.IndexOf("d") == space2Conversion.Length - 1)
                    {
                        // �X�y�[�X�̍Ōオ"d"�̏ꍇ.
                        // �Ō��"d"���폜.
                        space2Conversion = reg.Replace(space2Conversion, "");
                    }
                    else
                    {
                        // ��L�ȊO�̏ꍇ.
                        space2Conversion = reg.Replace(space2Conversion, "*");
                    }
                }
                else
                {
                    // �X�y�[�X��"*"���܂܂�Ă���ꍇ.
                    // "d"���폜.
                    space2Conversion = reg.Replace(space2Conversion, "");
                }
            }

            //********************************
            // �|���Z�A����Z�L���ʒu�擾.
            //********************************
            int multiplicationIndex = space2Conversion.IndexOf("*");
            int divisionIndex = space2Conversion.IndexOf("/");

            double valueX = 0;                  // �l1
            double valueY = 0;                  // �l2
            double valueZ = 0;                  // �l3
            double calculationResult = 0;       // �v�Z����.
            String strCalculationResult = "";   // �v�Z����(String)

            //********************
            // �v�Z����.
            //********************
            try
            {
                if (multiplicationIndex >= 0)
                {
                    // �|���Z�L������.
                    valueX = double.Parse(space2Conversion.Substring(0, multiplicationIndex));

                    if (divisionIndex >= 0)
                    {
                        // ����Z�L������.
                        valueY = double.Parse(space2Conversion.Substring(multiplicationIndex + 1, divisionIndex - multiplicationIndex - 1));
                        valueZ = double.Parse(space2Conversion.Substring(divisionIndex + 1));

                        //==============================
                        // �v�Z�p�^�[���F(X * Y / Z)
                        //==============================
                        calculationResult = valueX * valueY / valueZ;
                        strCalculationResult = calculationResult.ToString();
                    }
                    else
                    {
                        valueY = double.Parse(space2Conversion.Substring(multiplicationIndex + 1));

                        //==============================
                        // �v�Z�p�^�[���F(X * Y)
                        //==============================
                        calculationResult = valueX * valueY;
                        strCalculationResult = calculationResult.ToString();
                    }
                }
                else
                {
                    // �|���Z�L���Ȃ�.
                    if (divisionIndex >= 0)
                    {
                        // ����Z�L������.
                        valueY = double.Parse(space2Conversion.Substring(0, divisionIndex));
                        valueZ = double.Parse(space2Conversion.Substring(divisionIndex + 1));

                        //==============================
                        // �v�Z�p�^�[���F(Y / Z)
                        //==============================
                        calculationResult = valueY / valueZ;
                        strCalculationResult = calculationResult.ToString();
                    }
                    else
                    {
                        double parseResult; // ���l�`�F�b�N�p�ϐ�.

                        if (double.TryParse(space2Conversion, out parseResult))
                        {
                            //==============================
                            // �v�Z�p�^�[���Ȃ� ���� ���l.
                            //==============================
                            strCalculationResult = space2Conversion;
                        }
                        else
                        {
                            //==============================
                            // ���l�ȊO.
                            //==============================
                            strCalculationResult = "";
                        }
                    }
                }
            }
            catch
            {
                // �ϊ��㕶����ԋp.
                return strCalculationResult = "";
            }
            // �ϊ��㕶����ԋp.
            return strCalculationResult;
        }

        #endregion �X�y�[�X�Q�ϊ�����.

        #region �X�y�[�X�Q���l�`�F�b�N����.

        /// <summary>
        /// �X�y�[�X�Q���l�`�F�b�N����.
        /// 
        /// �@�ȉ��̃`�F�b�N�����{.
        /// �E�X�y�[�X�Q�ɓ��͂��� ����.
        /// �@�X�y�[�X�Q�����l.
        /// �@��true
        /// �E��L�ȊO.
        /// �@��false
        /// </summary>
        /// <param name="space2">�X�y�[�X�Q</param>
        /// <returns>�`�F�b�N����</returns>
        private bool IsSpace2Check(String space2)
        {
            bool isCheckResult = false;

            if (space2 != "")
            {
                // �X�y�[�X�Q���u�����N�ȊO.
                double parseResult; // ���l�`�F�b�N�p�ϐ�.

                if (double.TryParse(space2, out parseResult))
                {
                    // �X�y�[�X�Q�����l.
                    isCheckResult = true;
                }
            }

            return isCheckResult;
        }

        #endregion �X�y�[�X�Q�ϊ�����.

        #region ���t�`�F�b�N����.

        /// <summary>
        /// �p�����[�^�̒l�����t���`�F�b�N����.
        /// </summary>
        /// <param name="paramString">�`�F�b�N�Ώۂ̕�����</param>
        /// <returns>
        /// ture    : ���t.
        /// false   : ���t�ȊO.
        /// </returns>
        private bool IsDateTime(string paramString)
        {
            // �߂�l��������.
            bool returnValue = true;

            // �p�����[�^��Null�܂���""�łȂ��ꍇ.
            if (string.IsNullOrEmpty(paramString) == false)
            {
                // ���t�ϊ����A�ϊ��ł��Ȃ���Ζ߂�l��false��ݒ肷��.
                DateTime parseResult = new DateTime();
                if (DateTime.TryParse(paramString, out parseResult) == false)
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }

        #endregion
    }
}

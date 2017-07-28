using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// �󒍓������ 
    /// </summary>
    public partial class JyutyuMerge : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �����o�ϐ�
        KKHNaviParameter _naviParameterIn = new KKHNaviParameter();
        KKHNaviParameter _naviParameterOut = new KKHNaviParameter();
        #endregion �����o�ϐ�

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public JyutyuMerge()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^

        #region �C�x���g
        private void JyutyuMerge_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameterIn = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        private void JyutyuMerge_Shown(object sender, EventArgs e)
        {
            InitializeControl();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (OkClick() == false)
            //{
            //    return;
            //}
            _naviParameterOut.IntValue1 = int.Parse(KKHUtility.KKHUtility.ToString(cmbTouData.SelectedValue));
            Navigator.Backward(this, _naviParameterOut, null, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }
        #endregion �C�x���g

        private void InitializeControl()
        {
            //������I���R���{�{�b�N�X 
            Isid.KKH.Common.KKHSchema.Detail.ComboDataTable dtCombo = new Isid.KKH.Common.KKHSchema.Detail.ComboDataTable();
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviParameterIn.DsDetail.JyutyuData.Rows)
            {
                Isid.KKH.Common.KKHSchema.Detail.ComboRow addRow = dtCombo.NewComboRow();
                string kenmei = row.hb1KKNameKJ;
                string kingaku = row.hb1SeiGak.ToString("#,0");
                addRow.text = kenmei + kingaku.PadLeft(15 - kingaku.Length, ' ');
                addRow.value = row.rowNum;

                dtCombo.AddComboRow(addRow);
            }

            cmbTouData.DisplayMember = dtCombo.textColumn.ColumnName;
            cmbTouData.ValueMember = dtCombo.valueColumn.ColumnName;
            cmbTouData.DataSource = dtCombo;
        }

        /// <summary>
        /// OK�{�^���N���b�N���̏��� 
        /// </summary>
        /// <returns></returns>
        protected virtual bool OkClick()
        {
            //�T�[�r�X�p�����[�^(�������f�[�^���X�g) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouMoto = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouMoto = dsTougouMoto.THB1DOWN;
            //�T�[�r�X�p�����[�^(������f�[�^) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouSaki = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouSaki = dsTougouSaki.THB1DOWN;
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouSaki = dtTougouSaki.NewTHB1DOWNRow(true);
            //�T�[�r�X�p�����[�^(�X�V���t�ő�l�|�r���`�F�b�N�p) 
            DateTime maxUpdDate = new DateTime();

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviParameterIn.DsDetail.JyutyuData.Rows)
            {
                //�������f�[�^�̕ҏW 
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouMoto = dtTougouMoto.NewTHB1DOWNRow();
                rowTougouMoto.hb1UpdTnt = _naviParameterIn.strEsqId;
                rowTougouMoto.hb1UpdApl = _naviParameterIn.AplId;
                rowTougouMoto.hb1EgCd = row.hb1EgCd;
                rowTougouMoto.hb1TksKgyCd = row.hb1TksKgyCd;
                rowTougouMoto.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                rowTougouMoto.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                rowTougouMoto.hb1Yymm = row.hb1Yymm;
                rowTougouMoto.hb1JyutNo = row.hb1JyutNo;
                rowTougouMoto.hb1JyMeiNo = row.hb1JyMeiNo;
                rowTougouMoto.hb1UrMeiNo = row.hb1UrMeiNo;
                rowTougouMoto.hb1TouFlg = row.hb1TouFlg.PadRight(1, ' ');

                dtTougouMoto.AddTHB1DOWNRow(rowTougouMoto);

                //������f�[�^�̕ҏW 
                if (row.rowNum == int.Parse(KKHUtility.KKHUtility.ToString(cmbTouData.SelectedValue)))
                {

                    //row.hb1TimStmp = new DateTime();
                    //�X�V�v���O���� 
                    rowTougouSaki.hb1UpdApl = _naviParameterIn.AplId; 
                    //�X�V�S���� 
                    rowTougouSaki.hb1UpdTnt = _naviParameterIn.strEsqId;
                    //�c�Ə��i���j�R�[�h 
                    rowTougouSaki.hb1AtuEgCd = row.hb1EgCd;
                    //�c�Ə��i��j�R�[�h 
                    rowTougouSaki.hb1EgCd = row.hb1EgCd;
                    //���Ӑ��ƃR�[�h 
                    rowTougouSaki.hb1TksKgyCd = row.hb1TksKgyCd;
                    //���Ӑ敔��SEQNO 
                    rowTougouSaki.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                    //���Ӑ�S��SEQNO 
                    rowTougouSaki.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                    //��No 
                    rowTougouSaki.hb1JyutNo = row.hb1JyutNo;
                    //�󒍖���No 
                    rowTougouSaki.hb1JyMeiNo = row.hb1JyMeiNo;
                    //���㖾��No 
                    rowTougouSaki.hb1UrMeiNo = row.hb1UrMeiNo;
                    //�������[No 
                    rowTougouSaki.hb1GpyNo = " ";
                    //�y�[�WNo 
                    rowTougouSaki.hb1GpyoPag = " ";
                    //����No 
                    rowTougouSaki.hb1SeiNo = " ";
                    //��ڃR�[�h 
                    rowTougouSaki.hb1HimkCd = row.hb1HimkCd;
                    //�����t���O 
                    rowTougouSaki.hb1TouFlg = "1";
                    //�N�� 
                    rowTougouSaki.hb1Yymm = row.hb1Yymm;
                    //�Ɩ��敪 
                    rowTougouSaki.hb1GyomKbn = row.hb1GyomKbn;
                    //�}�X�����敪 
                    rowTougouSaki.hb1MsKbn = row.hb1MsKbn;
                    //�^�C���X�|�b�g�敪 
                    rowTougouSaki.hb1TmspKbn = row.hb1TmspKbn;
                    //���ۋ敪 
                    rowTougouSaki.hb1KokKbn = row.hb1KokKbn;
                    //�����敪 
                    rowTougouSaki.hb1SeiKbn = row.hb1SeiKbn;
                    //���iNo 
                    rowTougouSaki.hb1SyoNo = row.hb1SyoNo;
                    //����(����) 
                    rowTougouSaki.hb1KKNameKJ = row.hb1KKNameKJ;
                    //�c�Ɖ�ʃ^�C�v 
                    rowTougouSaki.hb1EgGamenType = row.hb1EgGamenType;
                    //���E���ŋ敪
                    rowTougouSaki.hb1KkakShanKbn = row.hb1KkakShanKbn;
                    //�旿�� 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //�����P�� 
                    rowTougouSaki.hb1SeiTnka = 0.0M;
                    //�������z 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //�l���� 
                    rowTougouSaki.hb1NeviRitu = row.hb1NeviRitu;
                    //�l���z 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //����ŋ敪 
                    rowTougouSaki.hb1SzeiKbn = row.hb1SzeiKbn;
                    //����ŗ� 
                    rowTougouSaki.hb1SzeiRitu = row.hb1SzeiRitu;
                    //����Ŋz 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                    //��ږ�(����) 
                    rowTougouSaki.hb1HimkNmKJ = row.hb1HimkNmKJ;
                    //��ږ�(�J�i) 
                    rowTougouSaki.hb1HimkNmKN = " ";
                    //�������No 
                    rowTougouSaki.hb1TJyutNo = " ";
                    //������󒍖���No 
                    rowTougouSaki.hb1TJyMeiNo = " ";
                    //�����攄�㖾��No 
                    rowTougouSaki.hb1TUrMeiNo = " ";
                    //�������t���O 
                    rowTougouSaki.hb1MSeiFlg = " ";
                    //�ύX�O�N�� 
                    rowTougouSaki.hb1YymmOld = " ";
                    //�t�B�[���h�P 
                    rowTougouSaki.hb1Field1 = row.hb1Field1;
                    //�t�B�[���h�Q 
                    rowTougouSaki.hb1Field2 = row.hb1Field2;
                    //�t�B�[���h�R 
                    rowTougouSaki.hb1Field3 = row.hb1Field3;
                    //�t�B�[���h�S 
                    rowTougouSaki.hb1Field4 = row.hb1Field4;
                    //�t�B�[���h�T 
                    rowTougouSaki.hb1Field5 = row.hb1Field5;
                    //�t�B�[���h�U 
                    rowTougouSaki.hb1Field6 = row.hb1Field6;
                    //�t�B�[���h�V 
                    rowTougouSaki.hb1Field7 = row.hb1Field7;
                    //�t�B�[���h�W 
                    rowTougouSaki.hb1Field8 = row.hb1Field8;
                    //�t�B�[���h�X 
                    rowTougouSaki.hb1Field9 = row.hb1Field9;
                    //�t�B�[���h�P�O 
                    rowTougouSaki.hb1Field10 = row.hb1Field10;
                    //�t�B�[���h�P�P 
                    rowTougouSaki.hb1Field11 = row.hb1Field11;
                    //�t�B�[���h�P�Q 
                    rowTougouSaki.hb1Field12 = row.hb1Field12;

                }
                else
                {
                    //�旿�� 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //�������z 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //�l���z 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //����Ŋz 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                }


                //�X�V���t�ő�l�̔��� 
                if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                {
                    maxUpdDate = row.hb1TimStmp;
                }
            }

            dtTougouSaki.AddTHB1DOWNRow(rowTougouSaki);
            dsTougouSaki.THB1DOWN.Merge(dtTougouSaki);

            dsTougouMoto.THB1DOWN.Merge(dtTougouMoto);

            DetailProcessController.MergeJyutyuDataParam param = new DetailProcessController.MergeJyutyuDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsTougouSaki = dsTougouSaki;
            param.dsTougouMoto = dsTougouMoto;
            param.maxUpdDate = maxUpdDate;

            DetailProcessController processController = DetailProcessController.GetInstance();
            MergeJyutyuDataServiceResult result = processController.MergeJyutyuData(param);
            if (result.HasError == true)
            {
                //MessageBox.Show("�����Ɏ��s���܂����B", "���דo�^", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "���דo�^", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}


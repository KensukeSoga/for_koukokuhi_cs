using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// �V�K�o�^�_�C�A���O(�x�[�X) 
    /// </summary>
    public partial class JyutyuRegister : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region �萔
        /// <summary>
        /// �����ő啶����
        /// </summary>
        protected const int SUBJECT_MAX_LENGTH = 60;
        #endregion �萔

        #region �����o�ϐ�
        //In�p�����[�^�pNaviParameter 
        private KKHNaviParameter _naviParameterIn = new KKHNaviParameter();
        //Out�p�����[�^�pNaviParameter 
        private KKHNaviParameter _naviParameterOut = new KKHNaviParameter();


        #endregion �����o�ϐ�

  
        #region �v���p�e�B

        /// <summary>
        /// In�p�����[�^�pNaviParameter ���擾���܂��B 
        /// </summary>
        public KKHNaviParameter NaviParameterIn
        {
            get { return _naviParameterIn; }
        }

        #endregion �v���p�e�B

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public JyutyuRegister()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^

        #region �C�x���g

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JyutyuRegister_Shown(object sender, EventArgs e)
        {
            if (DesignMode == true) { return; }

            InitializeControl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenmei_KeyPress(object sender, KeyPressEventArgs e)
        {
            //���͋֎~�����̔��� 
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGymKbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void JyutyuRegister_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameterIn = (KKHNaviParameter)arg.NaviParameter;
            }

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeRegisterJyutyu())
            {
                return;
            }

            if (RegisterJyutyuData() == false)
            {
                return;
            }

            //MessageBox.Show("�������I�����܂����B", "�V�K�o�^", MessageBoxButtons.OK);//TODO
            //MessageUtility.ShowMessageBox(MessageCode.HB_I0007, null, "�V�K�o�^", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0015, null, "�V�K�o�^", MessageBoxButtons.OK);
            Navigator.Backward(this, _naviParameterOut, null, true);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoJpn_CheckedChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenmei_TextChanged(object sender, EventArgs e)
        {
            // �����̃o�C�g����60���傫���ꍇ�̓G���[
            if (KKHUtility.KKHUtility.GetByteCount(txtKenmei.Text) > SUBJECT_MAX_LENGTH)
            {
                txtKenmei.Text = txtKenmei.Text.Substring(0, txtKenmei.Text.Length - 1);
                //MessageUtility.ShowMessageBox(MessageCode.HB_W0135, new String[] { SUBJECT_MAX_LENGTH.ToString() }, "�V�K�o�^", MessageBoxButtons.OK);
                //this.txtKenmei.Focus();
                txtKenmei.Select(txtKenmei.Text.Length, 0);
                return;
            }
        }

        #endregion �C�x���g

        #region ���Ӑ斈�̎���

        /// <summary>
        /// �V�K�o�^�T�[�r�X�p�����[�^��ҏW���� 
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            DetailProcessController.RegisterJyutyuDataParam param = new DetailProcessController.RegisterJyutyuDataParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row = dtThb1Down.NewTHB1DOWNRow();

            //row.hb1TimStmp = new DateTime();
            //�X�V�v���O���� 
            row.hb1UpdApl = _naviParameterIn.AplId;
            //�X�V�S���� 
            row.hb1UpdTnt = _naviParameterIn.strEsqId;
            //�c�Ə��i���j�R�[�h 
            row.hb1AtuEgCd = _naviParameterIn.strEgcd;
            //�c�Ə��i��j�R�[�h 
            row.hb1EgCd = _naviParameterIn.strEgcd;
            //���Ӑ��ƃR�[�h 
            row.hb1TksKgyCd = _naviParameterIn.strTksKgyCd;
            //���Ӑ敔��SEQNO 
            row.hb1TksBmnSeqNo = _naviParameterIn.strTksBmnSeqNo;
            //���Ӑ�S��SEQNO 
            row.hb1TksTntSeqNo = _naviParameterIn.strTksTntSeqNo;
            //��No 
            row.hb1JyutNo = "";//�̔Ԃ�JAVA�Ŏ��� 
            //�󒍖���No 
            row.hb1JyMeiNo = "001";
            //���㖾��No 
            row.hb1UrMeiNo = "001";
            //�������[No 
            row.hb1GpyNo = " ";
            //�y�[�WNo 
            row.hb1GpyoPag = " ";
            //����No 
            row.hb1SeiNo = " ";
            //��ڃR�[�h 
            row.hb1HimkCd = " ";
            //�����t���O 
            row.hb1TouFlg = " ";
            //�N�� 
            row.hb1Yymm = txtYymm.Text;
            //�Ɩ��敪 
            string gymKbn = (string)cmbGymKbn.SelectedValue;
            row.hb1GyomKbn = gymKbn;
            //�}�X�����敪 
            row.hb1MsKbn = " ";
            //�^�C���X�|�b�g�敪 
            string tsKbn = " ";
            if (gymKbn == KKHSystemConst.GyomKbn.TVTime)
            {
                tsKbn = "1";
            }
            else if (gymKbn == KKHSystemConst.GyomKbn.TVSpot)
            {
                tsKbn = "2";
            }
            else if (pnlTmSp.Visible == true)
            {
                if (rdoTime.Checked == true)
                {
                    tsKbn = "1";
                }
                else if (rdoSpot.Checked == true)
                {
                    tsKbn = "2";
                }
            }
            else
            {
                tsKbn = " ";
            }
            row.hb1TmspKbn = tsKbn;
            //���ۋ敪 
            string koksaiKbn = " ";
            if (rdoJpn.Checked == true)
            {
                koksaiKbn = "0";
            }
            else if (rdoKgi.Checked == true)
            {
                koksaiKbn = "1";
            }
            row.hb1KokKbn = koksaiKbn;
            //�����敪 
            row.hb1SeiKbn = GetSeiKbn(gymKbn, tsKbn, koksaiKbn);
            //���iNo 
            row.hb1SyoNo = " ";
            //����(����) 
            row.hb1KKNameKJ = txtKenmei.Text;
            //�c�Ɖ�ʃ^�C�v 
            row.hb1EgGamenType = " ";
            //���E���ŋ敪
            row.hb1KkakShanKbn = " ";
            //�旿�� 
            row.hb1ToriGak = 0.0M;
            //�����P�� 
            row.hb1SeiTnka = 0.0M;
            //�������z 
            row.hb1SeiGak = 0.0M;
            //�l���� 
            row.hb1NeviRitu = 0.0M;
            //�l���z 
            row.hb1NeviGak = 0.0M;
            //����ŋ敪 
            row.hb1SzeiKbn = " ";
            //����ŗ� 
            row.hb1SzeiRitu = 0.0M;
            //����Ŋz 
            row.hb1SzeiGak = 0.0M;
            //��ږ�(����) 
            row.hb1HimkNmKJ = " ";
            //��ږ�(�J�i) 
            row.hb1HimkNmKN = " ";
            //�������No 
            row.hb1TJyutNo = " ";
            //������󒍖���No 
            row.hb1TJyMeiNo = " ";
            //�����攄�㖾��No 
            row.hb1TUrMeiNo = " ";
            //�������t���O 
            row.hb1MSeiFlg = " ";
            //�ύX�O�N�� 
            row.hb1YymmOld = " ";
            //�t�B�[���h�P 
            row.hb1Field1 = " ";
            //�t�B�[���h�Q 
            row.hb1Field2 = " ";
            //�t�B�[���h�R 
            row.hb1Field3 = " ";
            //�t�B�[���h�S 
            row.hb1Field4 = " ";
            //�t�B�[���h�T 
            row.hb1Field5 = " ";
            //�t�B�[���h�U 
            row.hb1Field6 = " ";
            //�t�B�[���h�V 
            row.hb1Field7 = " ";
            //�t�B�[���h�W 
            row.hb1Field8 = " ";
            //�t�B�[���h�X 
            row.hb1Field9 = " ";
            //�t�B�[���h�P�O 
            row.hb1Field10 = " ";
            //�t�B�[���h�P�P 
            row.hb1Field11 = " ";
            //�t�B�[���h�P�Q 
            row.hb1Field12 = " ";

            dtThb1Down.AddTHB1DOWNRow(row);
            dsDetail.THB1DOWN.Merge(dtThb1Down);
            param.dsDetail = dsDetail;

            return param;
        }

        /// <summary>
        /// �󒍐V�K�o�^�O�̃`�F�b�N���� 
        /// </summary>
        /// <returns>�`�F�b�N����(True�FOK�AFalse�FNG)</returns>
        protected virtual bool CheckBeforeRegisterJyutyu()
        {
            //���ʃ`�F�b�N��ǉ� 
            if (KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0026, null, "�V�K�o�^", MessageBoxButtons.OK);
                cmbGymKbn.Focus();
                return false;
            }

            if (txtKenmei.Text == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0029, null,  "�V�K�o�^", MessageBoxButtons.OK);
                txtKenmei.Focus();
                return false;
            }
            return true;
        }

        #endregion ���Ӑ斈�̎���

        /// <summary>
        /// �R���g���[���̏����\�� 
        /// </summary>
        private void InitializeControl()
        {
            //*********************************
            //�N�� 
            //*********************************
            txtYymm.Text = _naviParameterIn.StrYymm;

            //*********************************
            //�Ɩ��敪�R���{�{�b�N�X 
            //*********************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult result = processController.FindCommonCodeMasterByCond(KKHSecurityInfo.GetInstance().UserEsqId, "87", _naviParameterIn.strDate);

            KKHSchema.Common.RcmnMeu29CCDataTable dsGyomKbn = new KKHSchema.Common.RcmnMeu29CCDataTable();
            dsGyomKbn.Merge(result.CommonDataSet.RcmnMeu29CC);
            dsGyomKbn.AcceptChanges();

            cmbGymKbn.DisplayMember = dsGyomKbn.naiyJColumn.ColumnName;
            cmbGymKbn.ValueMember = dsGyomKbn.kyCdColumn.ColumnName;
            cmbGymKbn.DataSource = dsGyomKbn;

            cmbGymKbn.SelectedValue = _naviParameterIn.GyomKbn;

        }

        /// <summary>
        /// �R���g���[���̕\���^��\���ύX 
        /// </summary>
        private void ChangeVisible()
        {
            if ((KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "11030" 
                || KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "11050")
                && rdoJpn.Checked == true)
            {
                pnlTmSp.Visible = true;
            }
            else
            {
                pnlTmSp.Visible = false;
            }
        }

        /// <summary>
        /// �V�K�o�^���� 
        /// </summary>
        /// <returns></returns>
        private bool RegisterJyutyuData()
        {
            //�V�K�o�^�����̃p�����[�^�ҏW 
            DetailProcessController.RegisterJyutyuDataParam param = EditRegisterJyutyuDataParam();

            DetailProcessController processController = DetailProcessController.GetInstance();
            RegisterJyutyuDataServiceResult result = processController.RegisterJyutyuData(param);

            if (result.HasError == true)
            {
                if (result.MessageCode == "UNIQUE-E0002")//TODO
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0054, null, "�V�K�o�^", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "�V�K�o�^", MessageBoxButtons.OK);
                }
                return false;
            }

            //�o�^�����󒍃_�E�����[�h�f�[�^��ԋp���� 
            _naviParameterOut.DsDetail = result.DsDetail;
            return true;
        }

        /// <summary>
        /// �����敪�����肷�� 
        /// </summary>
        /// <param name="gyomKbn">�Ɩ��敪</param>
        /// <param name="tsKbn">�^�C���^�X�|�b�g�敪</param>
        /// <param name="koksaiKbn">���ۋ敪</param>
        /// <returns></returns>
        public string GetSeiKbn(string gyomKbn, string tsKbn, string koksaiKbn)
        {
            string seiKbn = "";

            if (koksaiKbn == KKHSystemConst.KoksaiKbn.Kokusai)
            {
                if (gyomKbn == KKHSystemConst.GyomKbn.Shinbun
                    || gyomKbn == KKHSystemConst.GyomKbn.Zashi
                    || gyomKbn == KKHSystemConst.GyomKbn.Radio
                    || gyomKbn == KKHSystemConst.GyomKbn.TVTime
                    || gyomKbn == KKHSystemConst.GyomKbn.TVSpot
                    || gyomKbn == KKHSystemConst.GyomKbn.EiseiM
                    || gyomKbn == KKHSystemConst.GyomKbn.InteractiveM
                    )
                {
                    //���ۃ}�X 
                    seiKbn = KKHSystemConst.SeiKbn.KMas;
                }
                else
                {
                    //����(�����) 
                    seiKbn = KKHSystemConst.SeiKbn.KWorks;
                }
            }
            else
            {
                if (gyomKbn == KKHSystemConst.GyomKbn.Shinbun)
                {
                    //�V�� 
                    seiKbn = KKHSystemConst.SeiKbn.NewsPaper;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.Zashi)
                {
                    //�G�� 
                    seiKbn = KKHSystemConst.SeiKbn.Magazine;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.TVSpot
                    || (gyomKbn == KKHSystemConst.GyomKbn.Radio && tsKbn == KKHSystemConst.TimeSpotKbn.Spot)
                    || (gyomKbn == KKHSystemConst.GyomKbn.EiseiM && tsKbn == KKHSystemConst.TimeSpotKbn.Spot)
                )
                {
                    //�X�|�b�g 
                    seiKbn = KKHSystemConst.SeiKbn.Spot;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.TVTime
                    || (gyomKbn == KKHSystemConst.GyomKbn.Radio && tsKbn == KKHSystemConst.TimeSpotKbn.Time)
                    || (gyomKbn == KKHSystemConst.GyomKbn.EiseiM && tsKbn == KKHSystemConst.TimeSpotKbn.Time)
                )
                {
                    //�^�C�� 
                    seiKbn = KKHSystemConst.SeiKbn.Time;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.InteractiveM)
                {
                    //�C���^���N�e�B�u���f�B�A 
                    seiKbn = KKHSystemConst.SeiKbn.IC;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.OohM)
                {
                    //��ʍL�� 
                    seiKbn = KKHSystemConst.SeiKbn.Ooh;
                }
                else
                {
                    //����� 
                    seiKbn = KKHSystemConst.SeiKbn.Works;
                }
            }

            return seiKbn;
        }
    }
}


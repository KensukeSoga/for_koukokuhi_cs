using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.History;
using Isid.KKH.Common.KKHSchema;
namespace Isid.KKH.Lion.View.History
{
    public partial class HisDownlodData : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region "�����o�ϐ�"
        /// <summary>
        /// �i�r�p�����[�^�[
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �Ɩ��敪
        /// </summary>
        //private KKHSystemConst.GyomKbn gyomkbn = new KKHSystemConst.GyomKbn();

        #endregion "�����o�ϐ�"

        #region "�R���X�g���N�^"
        public HisDownlodData()
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
        private void HisDownlodData_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// �t�H�[�����[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HisDownlodData_Load(object sender, EventArgs e)
        {
            //�����f�[�^�ҏW
            EditControl();
        }

        /// <summary>
        /// �\���{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {

            string stry = txtYyyy.Value.ToString();
            string strm = "";
            if (txtMm.Value.ToString().Length == 1)
            {
                strm = "0" + txtMm.Value.ToString();
            }
            else
            {
                strm = txtMm.Value.ToString();
            }

            //�N���̃Z�b�g
            string yearmon = stry + strm;

            HistoryProcessController.findHisJyutDownparam param = new HistoryProcessController.findHisJyutDownparam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;
            HistoryProcessController processController = HistoryProcessController.GetInstance();
            FindHisByCondServiceResult result = processController.findHisJyutDown(param);

            //�G���[�̏ꍇ
            if (result.HasError)
            {

            }
            //�������ʂ�0���̏ꍇ
            if (result.dsDataSet.jyutyuDownLoad.Rows.Count == 0)
            {
                // MessageBox.Show("���̌��̐������[����荞��ł��܂���B");
                MessageUtility.ShowMessageBox(MessageCode.HB_W0096, null, "�󒍗���", MessageBoxButtons.OK);
            }

            HisDs.jyutyuDownLoadRow[] resultRow = (HisDs.jyutyuDownLoadRow[])result.dsDataSet.jyutyuDownLoad.Select("", "");

            //�f�[�^�Z�b�g
            HisDs ds = new HisDs();


            foreach (HisDs.jyutyuDownLoadRow row in resultRow)
            {
                HisDs.jyutyuDownLoadRow addrow = ds.jyutyuDownLoad.NewjyutyuDownLoadRow();

                //�o�͋敪
                if (row.SyuKbn.Equals("1"))
                {
                    addrow.SyuKbn = "�V�K";
                }
                else if (row.SyuKbn.Equals("2"))
                {
                    addrow.SyuKbn = "�ďo��";
                }

                //���[�o�͓���
                addrow.GpsyuTimStmp = YymmddSet(row.GpsyuTimStmp.Trim());
                //�Ɩ��敪
                addrow.GyomKbn = gyomkbn(row.GyomKbn.Trim());
                //�����N��
                if (row.Yymm.Trim().Length == 6)
                {
                    addrow.Yymm = row.Yymm.Trim().Substring(0, 4) + "/" + row.Yymm.Trim().Substring(4, 2);
                }
                //�S���҃R�[�h
                addrow.TntCd = row.TntCd;
                //�S���Җ�
                addrow.TntNm = row.TntNm;


                ds.jyutyuDownLoad.AddjyutyuDownLoadRow(addrow);
            }

            //�f�[�^�\��
            hisMain_Sheet1.DataSource = ds.jyutyuDownLoad;

        }

        /// <summary>
        /// �߂�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void njButton2_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }


        #endregion "�C�x���g"

        #region "���\�b�h"

        /// <summary>
        /// �c�Ɠ��擾
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// �e�R���g���[���ҏW
        /// </summary>
        private void EditControl()
        {
            //�N���̎擾
            string strDate = getHostDate();
            //�X�e�[�^�X�̐ݒ�
            txtYyyy.Text = strDate.Substring(0, 4);
            txtMm.Text = strDate.Substring(4, 2);
            tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslDate.Text = _naviParam.strDate;
        }

        /// <summary>
        /// �N���A���Ԃ̃Z�b�g
        /// </summary>
        /// <param name="yymmdd"></param>
        /// <returns></returns>
        private string YymmddSet(string yymmdd)
        {
            if (yymmdd.Length != 14) { return string.Empty; }

            string afterYymmdd = yymmdd.Substring(0, 4) + "/" +
                                 yymmdd.Substring(4, 2) + "/" +
                                 yymmdd.Substring(6, 2) + " " +
                                 yymmdd.Substring(8, 2) + ":" +
                                 yymmdd.Substring(10, 2) + ":" +
                                 yymmdd.Substring(12, 2);

            return afterYymmdd;
        }

        /// <summary>
        /// �Ɩ��敪���̊���U��
        /// </summary>
        /// <param name="gycd"></param>
        /// <returns></returns>
        private string gyomkbn(string gycd)
        {

            string[] gyomNm = gycd.Split(',');
            //�}�̖�
            string gyCdName = string.Empty;

            for (int i = 0; i < gyomNm.Length; i++)
            {
                switch (gyomNm[i])
                {
                    case KKHSystemConst.GyomKbn.Shinbun:
                        gyCdName = gyCdName + "�V��";
                        break;
                    case KKHSystemConst.GyomKbn.Zashi:
                        gyCdName = gyCdName + "�G��";
                        break;
                    case KKHSystemConst.GyomKbn.Radio:
                        gyCdName = gyCdName + "���W�I";
                        break;
                    case KKHSystemConst.GyomKbn.TVTime:
                        gyCdName = gyCdName + "�e���r�^�C��";
                        break;
                    case KKHSystemConst.GyomKbn.TVSpot:
                        gyCdName = gyCdName + "�e���r�X�|�b�g";
                        break;
                    case KKHSystemConst.GyomKbn.EiseiM:
                        gyCdName = gyCdName + "�q�����f�B�A";
                        break;
                    case KKHSystemConst.GyomKbn.InteractiveM:
                        gyCdName = gyCdName + "�C���^���N�e�B�u���f�B�A";
                        break;
                    case KKHSystemConst.GyomKbn.OohM:
                        gyCdName = gyCdName + "OOH���f�B�A ";
                        break;
                    case KKHSystemConst.GyomKbn.SonotaM:
                        gyCdName = gyCdName + "���̑����f�B�A";
                        break;
                    case KKHSystemConst.GyomKbn.MPlan:
                        gyCdName = gyCdName + "���f�B�A�v�����j���O";
                        break;
                    case KKHSystemConst.GyomKbn.Creative:
                        gyCdName = gyCdName + "�N���G�[�e�B�u";
                        break;
                    case KKHSystemConst.GyomKbn.MarkePromo:
                        gyCdName = gyCdName + "�}�[�P�e�B���O/�v�����[�V����";
                        break;
                    case KKHSystemConst.GyomKbn.Sports:
                        gyCdName = gyCdName + "�X�|�[�c";
                        break;
                    case KKHSystemConst.GyomKbn.Entertainment:
                        gyCdName = gyCdName + "�G���^�e�C�����g";
                        break;
                    case KKHSystemConst.GyomKbn.SonotaC:
                        gyCdName = gyCdName + "���̑��R���e���c";
                        break;
                }
                if (i != gyomNm.Length - 1)
                {
                    gyCdName = gyCdName + ",";
                }
            }

            return gyCdName;
        }

        #endregion "���\�b�h"

    }
}


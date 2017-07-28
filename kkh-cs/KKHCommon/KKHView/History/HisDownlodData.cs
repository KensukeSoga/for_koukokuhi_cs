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
//using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.History;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox;

namespace Isid.KKH.Common.KKHView.History
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
        KKHSchema.Common.RcmnMeu29CCDataTable GyoumKbn = new Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable();

        #endregion "�����o�ϐ�"

        #region "�R���X�g���N�^"

        /// <summary>
        /// 
        /// </summary>
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

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �\���{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {

            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �N���̎擾 
            string yyyyMm = orgYyyyMm.Value;

            HistoryProcessController.findHisJyutDownparam param = new HistoryProcessController.findHisJyutDownparam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yyyyMm;
            HistoryProcessController processController = HistoryProcessController.GetInstance();
            FindHisByCondServiceResult result = processController.findHisJyutDown(param);

            //�G���[�̏ꍇ
            if (result.HasError)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();
                return;
            }
            //�������ʂ�0���̏ꍇ 
            if (result.dsDataSet.jyutyuDownLoad.Rows.Count == 0)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                // MessageBox.Show("���̌��̐������[����荞��ł��܂���B");
                MessageUtility.ShowMessageBox(MessageCode.HB_W0096, null, "�󒍗���", MessageBoxButtons.OK);
            }

            HisDs.jyutyuDownLoadRow[] resultRow = (HisDs.jyutyuDownLoadRow[])result.dsDataSet.jyutyuDownLoad.Select("", "");

            //�f�[�^�Z�b�g 
            //HisDs ds = new HisDs();

            String baseDate = "";    //�����Ώ� 
            String wk = "";         //�����Ώۂ��甲���o��������  
            String wk2 = "";        //������ 
            String wk3 = "";     //�������� 

            //���������� 
            ds.Clear();

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
                baseDate = row.Yymm.ToString().Trim();
                wk3 = "";

                for (int i = 0; i < baseDate.Length; i++) 
                {
                    //�����N�����P�������擾���� 
                    wk = baseDate.Substring(i, 1);
                    //[�����Ώ�]��","����""����" "����6�����ł͂Ȃ��ꍇ�A���̒l��[������]�ɃZ�b�g 
                    if (wk != "," && wk != "" && wk != " " && wk2.Length != 6)
                    {
                        wk2 += wk;
                    }
                    
                    //[������]��6�����̏ꍇ 
                    if (wk2.Length == 6)
                    {
                        //[��������]���󔒂̏ꍇ  
                        if (wk3 == "")
                        {
                            wk3 = wk2.Substring(0, 4) + "/" + wk2.Substring(4, 2);
                        }
                        else
                        {
                            wk3 += "," + wk2.Substring(0, 4) + "/" + wk2.Substring(4, 2);
                        }
                        //[������]�������� 
                        wk2 = "";
                    }
                }

                //�������ʂ𐿋��N���ɃZ�b�g 
                addrow.Yymm = wk3;

                //�S���҃R�[�h
                addrow.TntCd = row.TntCd;
                //�S���Җ�
                addrow.TntNm = row.TntNm;

                ds.jyutyuDownLoad.AddjyutyuDownLoadRow(addrow);
            }

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

            //�f�[�^�\��
            //hisMain_Sheet1.DataSource = ds.jyutyuDownLoad;
            ds.jyutyuDownLoad.AcceptChanges();
            //�����N���܂ł��Œ��ɂ���
            //hisMain_Sheet1.FrozenColumnCount = 3;

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;


        }

        /// <summary>
        /// �߂�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtn_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// �w���v�{�^���N���b�N���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.HisDownLoad, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
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
            string hostDt = getHostDate();
            
            string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;

                if (hostDt != "")
                {
                    hostDt = hostDt.Trim().Replace("/", "");
                    if (hostDt.Trim().Length >= 6)
                    {
                        orgYyyyMm.Value = hostDt.Substring(0, 6);
                    }
                    else
                    {
                        orgYyyyMm.Value = hostDt;
                    }
                    orgYyyyMm.cmbYM_SetDate();
                }

            tslName.Text = _naviParam.strName;
            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslDate.Text = _naviParam.strDate;

            //**************************
            //�Ɩ��敪�擾
            //**************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult result
                = processController.FindCommonCodeMasterByCond(KKHSecurityInfo.GetInstance().UserEsqId, "87", hostDt);

            if (result.HasError)
            {
                return;
            }
            
            GyoumKbn.Merge(result.CommonDataSet.RcmnMeu29CC);

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
            //�Ɩ��敪�R�[�h
            string[] gyomNm = gycd.Split(',');
            //�Ɩ��敪��
            string gyCdName = string.Empty;

            for (int i = 0; i < gyomNm.Length; i++)
            {
                foreach (KKHSchema.Common.RcmnMeu29CCRow row in GyoumKbn)
                {
                    //�Ɩ��敪�R�[�h����v������Ɩ���������B
                    if (gyomNm[i].Equals(row.kyCd.Trim()))
                    {
                        gyCdName = gyCdName + row.naiyJ ;
                        if (i != gyomNm.Length - 1)
                        {
                            gyCdName = gyCdName + ",";
                        }

                        break;
                    }
                }
            }
            return gyCdName;
        }

        #endregion "���\�b�h"
    }
}


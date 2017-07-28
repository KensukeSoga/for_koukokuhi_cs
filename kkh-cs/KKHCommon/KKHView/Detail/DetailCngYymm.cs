using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailCngYymm : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        private DetailCngYymmNaviParameter _naviParam = new DetailCngYymmNaviParameter();

        /// <summary>
        /// 
        /// </summary>
        public DetailCngYymm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailCngYymm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailCngYymmNaviParameter)
            {
                _naviParam = (DetailCngYymmNaviParameter)arg.NaviParameter;
            }

            //string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            //if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Ash)
            //    || Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear)
            //    || Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Lion))
            //{
            //    txtYymm.DisplayMode = DisplayMode.COMBO;
            //}
            //else 
            //{
            //    txtYymm.DisplayMode = DisplayMode.TEXT_BUTTON;
            //}

            if (_naviParam.Mode == 0)
            {
                txtYymm.DisplayMode = DisplayMode.COMBO;
            }
            else
            {
                txtYymm.DisplayMode = DisplayMode.TEXT_BUTTON;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailCngYymm_Shown(object sender, EventArgs e)
        {
            //txtYymm.Value = _naviParam.StrYymm;
            //string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            //if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Ash)
            //    || Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear)
            //    || Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Lion))
            //{
            //    String hostDate = _naviParam.StrYymm;
            //
            //    hostDate = hostDate.Trim().Replace("/", "");
            //
            //    if (hostDate.Trim().Length >= 6)
            //    {
            //        txtYymm.Value = hostDate.Substring(0, 6);
            //    }
            //    else
            //    {
            //        txtYymm.Value = hostDate;
            //    }
            //    txtYymm.cmbYM_SetDate();
            //}
            //else
            //{
            //    txtYymm.Value = _naviParam.StrYymm;
            //}

            if (_naviParam.Mode == 0)
            {
                String hostDate = _naviParam.StrYymm;

                hostDate = hostDate.Trim().Replace("/", "");

                if (hostDate.Trim().Length >= 6)
                {
                    txtYymm.Value = hostDate.Substring(0, 6);
                }
                else
                {
                    txtYymm.Value = hostDate;
                }
                txtYymm.cmbYM_SetDate();
            }
            else
            {
                txtYymm.Value = _naviParam.StrYymm;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
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
            //
            DateTime dtSeikyuYymm;
            string strSeikyuYymm = txtYymm.Value;
            if (strSeikyuYymm.Length != 6 || DateTime.TryParse(strSeikyuYymm.Insert(4, "/") + "/01", out dtSeikyuYymm) == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0072, null, "ñæç◊ìoò^", MessageBoxButtons.OK);
                txtYymm.Focus();
                return;
            }

            _naviParam.StrYymm = txtYymm.Value;
            Navigator.Backward(this, _naviParam, null, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYymm_Leave(object sender, EventArgs e)
        {
            // ñﬂÇÈÉ{É^ÉìÇ™âüÇ≥ÇÍÇΩéûÇÕåüèÿÇàÍìxÇæÇØñ≥å¯Ç…Ç∑ÇÈ 
            if( ActiveControl == BtnCancel )
            {
                txtYymm.ValidateDisableOnce = true;
            }
        }
    }
}


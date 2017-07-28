using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Acom.Utility;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Acom.View.Mast
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMastAcom : MastForm, INaviParameter
    {
      
        /// <summary>
        /// 
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        
        /// <summary>
        /// 
        /// </summary>
        public frmMastAcom()
        {
           InitializeComponent();
       }

       # region イベント

       /// <summary>
        ///  画面遷移するたびに発生します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastAcom_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastAcom_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMasterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 2 || cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 1)
            {
                RowUpBtn.Enabled = false;
                RowUpBtn.Visible = false;
                RowDownBtn.Enabled = false;
                RowDownBtn.Visible = false;
            }
            else
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
            }
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = mstNavPrm.strTksKgyCd + mstNavPrm.strTksBmnSeqNo + mstNavPrm.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.TopicId);
        }

       # endregion イベント

    }
}


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

namespace Isid.KKH.Kmn.View.Mast
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMastKmn : MastForm, INaviParameter
    {
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        /// <summary>
        /// 
        /// </summary>
        public frmMastKmn()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastKmn_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }


    }
}


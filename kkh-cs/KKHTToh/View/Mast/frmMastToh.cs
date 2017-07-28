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

namespace Isid.KKH.Toh.View.Mast
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMastToh : MastForm, INaviParameter
    {
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        /// <summary>
        /// 
        /// </summary>
        public frmMastToh()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }


    }
}


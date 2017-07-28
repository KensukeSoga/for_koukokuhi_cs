using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Common.KKHView.Mast.Common
{
    public partial class CrdMstForm : KKHDialogBase
    {
        /// <summary>
        /// 
        /// </summary>
        public CrdMstForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrdMstForm_Load(object sender, EventArgs e)
        {
            //コントロールを未選択状態にする 
            this.ActiveControl = null;
        }

        
    }
}
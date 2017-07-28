using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Mast.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Tkd.View.Detail;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.UserManual;


namespace Isid.KKH.Tkd.View.Top
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmTopMenuTkd : TopMenuForm, INaviParameter
    {
        # region メンバ変数
        /// <summary>
        /// 
        /// </summary>
        private KKHNaviParameter topNaviParameter;
        # endregion

        # region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public frmTopMenuTkd()
        {
            InitializeComponent();
        }
        # endregion

        # region イベント

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuTkd_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }


        /// <summary>
        /// Loadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuTkd_Load(object sender, EventArgs e)
        {
            //親[帳票]ボタンを非表示 
            this.btnAccount.Visible = false;
        }

        /// <summary>
        /// 帳票ボタンClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChohyo_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, "toReportTkd", topNaviParameter);
        }

        /// <summary>
        /// [マスター]ボタンPopupButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnMasterMaintenance_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            //ボタン名(画面名)を取得 
            topNaviParameter.StrValue1 = value.Value.ToString();
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        # endregion

    }
}
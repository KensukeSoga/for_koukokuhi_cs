using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Common.KKHView.Mast.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Top;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Kmn.Utility;
using Isid.KKH.UserManual;
namespace Isid.KKH.Kmn.View.Top
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmTopMenuKmn : TopMenuForm, INaviParameter
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
        public frmTopMenuKmn()
        {
            InitializeComponent();
        }
        # endregion

        # region イベント

        /// <summary>
        /// 画面ProcessAffterNavigating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuKmn_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }
        
        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuKmn_Load(object sender, EventArgs e)
        {
            //btnMast.Visible = false;
            btnHistoryDownLoad.Visible = false;
        }

        /// <summary>
        /// [帳票]ボタンPopupButtonClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1") // 請求一覧 
            {
                topNaviParameter.strFrmInputNm = "toReportKmnList";
            }
            else if (value.Value == "2") // 伝票帳票 
            {
                topNaviParameter.strFrmInputNm = "toReportKmn";
            }
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// [マスタ]ボタンPopupButtonClickイベント 
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
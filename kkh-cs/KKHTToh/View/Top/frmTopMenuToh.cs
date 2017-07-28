using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Isid.KKH.Toh.View.Detail;
using Isid.KKH.Toh.ProcessController;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Common.KKHView.Top;
using Isid.NJ.View.Base;
using Isid.KKH.UserManual;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Toh.View.Top
{
    /// <summary>
    /// トップメニュー画面（toh)
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description></description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmTopMenuToh : TopMenuForm
    {
        # region メンバ変数

        KKHNaviParameter topNaviParameter = new KKHNaviParameter();

        # endregion メンバ変数

        # region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public frmTopMenuToh()
        {
            InitializeComponent();
        }

        # endregion コンストラクタ

        # region イベント

        /// <summary>
        /// 画面ProcessAffterNavigating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuToh_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 帳票PopupButtonClick 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1") // 東宝・請求明細一覧
            {
                topNaviParameter.strFrmInputNm = "toReportToh";
            }
            else if (value.Value == "2") // 年月別媒体別集計
            {
                topNaviParameter.strFrmInputNm = "toReportTohTotal";
            }
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// [マスター]ボタンPopupButtonClickイベント  
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
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuToh_Load(object sender, EventArgs e)
        {
            btnMast.Visible = false;
            btnHistoryDownLoad.Visible = false;
        }


        /// <summary>
        /// マスターボタンClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMast_Click(object sender, EventArgs e)
        {
            //マスターメンテンス画面に遷移 
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

        # endregion イベント

    }
}


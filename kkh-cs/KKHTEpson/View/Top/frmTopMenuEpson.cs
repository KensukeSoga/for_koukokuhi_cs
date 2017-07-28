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
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.UserManual;
namespace Isid.KKH.Epson.View.Top
{
    /// <summary>
    /// トップメニュー画面（Epson)
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
    ///       <description>2012/03/06</description>
    ///       <description>IP Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmTopMenuEpson : Isid.KKH.Common.KKHView.Top.TopMenuForm
    {
        
        #region メンバ変数
        /// <summary>
        /// トップメニュナビパラメータ
        /// </summary>
        KKHNaviParameter topNaviParameter = new KKHNaviParameter();
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public frmTopMenuEpson()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント

        /// <summary>
        /// 画面起動時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuEpson_Load(object sender, EventArgs e)
        {        
        }

        /// <summary>
        /// 画面遷移時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuEpson_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            // トップナビパラメータ生成
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }


        /// <summary>
        /// [帳票]ボタンPopupButtonClick 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {

            if (value.Value == "1") // 請求予定一覧 
            {
                topNaviParameter.strFrmInputNm = "toReportEpsonSeikyuPlan";
            }
            else if (value.Value == "2") // 提出帳票 
            {
                topNaviParameter.strFrmInputNm = "toReportEpsonSubMission";
            }

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);

        }

        /// <summary>
        /// [マスタ]PopupButtonClick
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
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
        }

        #endregion イベント

    }
}
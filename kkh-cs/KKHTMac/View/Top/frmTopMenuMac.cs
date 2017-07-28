using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Mast.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.NJSecurity.Core;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Mac.View.Detail;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Top
{
    /// <summary>
    /// トップメニュー画面（mac)
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
    ///       <description>2012/01/18</description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmTopMenuMac : Isid.KKH.Common.KKHView.Top.TopMenuForm
    {
        # region メンバ変数
        /// <summary>
        /// 
        /// </summary>
        KKHNaviParameter topNaviParameter = new KKHNaviParameter();

        # endregion

        # region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public frmTopMenuMac()
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
        private void frmTopMenuMac_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// [帳票]ボタンPopupButtonClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1")//購入伝票
            {
                //topNaviParameter.strFrmInputNm = "toReportMac";
                topNaviParameter.strFrmInputNm = "toReportMacPurchase";
            }
            else if (value.Value == "2") // 請求書
            {
                //topNaviParameter.strFrmInputNm = "toReportMacSchklst";
                topNaviParameter.strFrmInputNm = "toReportMacRequest";
            }
            else if (value.Value == "3") // ライセンシー
            {
                //topNaviParameter.strFrmInputNm = "toReportMacPurchase";
                topNaviParameter.strFrmInputNm = "toReportMacLicensee";
            }
            else if (value.Value == "4") // 購入伝票一覧
            {
                //topNaviParameter.strFrmInputNm = "toReportMacRequest";
                topNaviParameter.strFrmInputNm = "toReportMac";
            }
            else if (value.Value == "5") // 請求チェックリスト
            {
                //topNaviParameter.strFrmInputNm = "toReportMacLicensee";
                topNaviParameter.strFrmInputNm = "toReportMacSchklst";
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

        # endregion イベント

    }
}
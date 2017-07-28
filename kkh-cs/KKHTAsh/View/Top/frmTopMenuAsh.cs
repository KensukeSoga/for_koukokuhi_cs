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
using Isid.KKH.Ash.Utility;
using Isid.KKH.UserManual;
namespace Isid.KKH.Ash.View.Top
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmTopMenuAsh : TopMenuForm, INaviParameter
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
        public frmTopMenuAsh()
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
        private void frmTopMenuAsh_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// FormLoadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuAsh_Load(object sender, EventArgs e)
        {
            //ローディング表示  
            base.ShowLoadingDialog();

            ////帳票ボタンを制御 
            ////アサヒビールの場合、[広告費アップロードシート]を非表示にする 
            //if (topNaviParameter.strTksKgyCd.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6)))
            //{
            //    this.btnAccount.ButtonCount = 2;
            //}
            //アサヒビールの場合、[広告費アップロードシート]を非表示にする 
            if (topNaviParameter.strTksKgyCd.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6)))
            {
                this.btnAccount.ChildButtonText = new string[] {
                    "広告費明細書",
                    "媒体別帳票",
                    "請求データ作成"};
            }
            else
            {
                this.btnAccount.ChildButtonText = new string[] {
                    "広告費明細書",
                    "媒体別帳票",
                    "広告費アップロードシート"};
            }
            //2013/02/22 jse okazaki PR媒体追加対応　Start
            //マスターボタンを制御 
            //アサヒ飲料の場合、[PRマスター]を非表示にする 
            if (topNaviParameter.strTksKgyCd.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Ash.Substring(0, 6)))
            {
                this.btnMasterMaintenance.ButtonCount = 17;
            }
            //2013/02/22 jse okazaki PR媒体追加対応　End

            //ローディング非表示 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// [帳票]ボタンPopupButtonClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1")
            {
                //媒体別帳票 
                topNaviParameter.strFrmInputNm = "toReportAshByMedium";
            }
            else if (value.Value == "2")
            {
                //広告費明細書 
                topNaviParameter.strFrmInputNm = "toReportAshKoukokuHi";
            }
            else if (value.Value == "3")
            {
                if (topNaviParameter.strTksKgyCd.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6)))
                {
                    //請求データ作成
                    topNaviParameter.strFrmInputNm = "toFDAsh";
                }
                else
                {
                    //広告費アップロードシート 
                    topNaviParameter.strFrmInputNm = "toReportAshByMediumChklst";
                }
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

        # endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Isid.KKH.Uni.View.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.NJ.View.Base;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Uni.View.Top
{
    public partial class frmTopMenuUni : TopMenuForm
    {
        #region メンバ変数 

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private Isid.KKH.Common.KKHView.Common.KKHNaviParameter topNaviParameter;

        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public frmTopMenuUni()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void frmTopMenuUni_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }


        /// <summary>
        /// 帳票ボタンClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChohyo_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
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

        #endregion イベント 

    }
}
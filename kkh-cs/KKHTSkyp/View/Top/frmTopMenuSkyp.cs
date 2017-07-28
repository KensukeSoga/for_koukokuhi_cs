using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.NJSecurity.Core;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.UserManual;
namespace Isid.KKH.Skyp.View.Top
{
    public partial class frmTopMenuSkyp : TopMenuForm, INaviParameter
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
        public frmTopMenuSkyp()
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
        private void frmTopMenuSkyp_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 画面表示時の処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuSkyp_Load(object sender, EventArgs e)
        {
            //継承した帳票ボタンとマスターメンテナンスボタンは非表示にする
            this.btnAccountVisble = false;
            this.btnMasterMaintenanceVisble = false;
        }

        /// <summary>
        /// 帳票ボタンClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChohyo_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toReportSkyp";

            //帳票画面に遷移 
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
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

        #endregion イベント 


    }
}
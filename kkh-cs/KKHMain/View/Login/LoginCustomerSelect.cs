using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Main.ProcessController.Login;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Main.Utility;

namespace Isid.KKH.Main.View.Login
{
    /// <summary>
    /// ログイン得意先選択面面用クラス
    /// </summary>
    public partial class LoginCustomerSelect : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region メンバ変数
        private LoginNaviParameter _naviParam = null;
        private Schema.Login.LoginCustomerDataDataTable _loginCustomerDataDataTable = null;
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public LoginCustomerSelect()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        /// <summary>
        /// ＯＫボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            _naviParam.loginCustomerDataIndex = _spdLoginCustomerList_Sheet1.ActiveRowIndex;
            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginCustomerSelect_Load(object sender, EventArgs e)
        {
            //// 各コントロールの編集
            editControl();
        }

        /// <summary>
        /// 各コントロールの編集処理 
        /// </summary>
        private void editControl()
        {
            //列の非表示
            for (int i = KkhConstMain.CustomerSelectCol.TKSKGYCD; i <= KkhConstMain.CustomerSelectCol.TKSTNTSEQNO; i++)
            {
                _spdLoginCustomerList_Sheet1.Columns[i].Visible = false;
            }
			//データソースの設定
            _spdLoginCustomerList_Sheet1.DataSource = _loginCustomerDataDataTable;
            //1行目を選択
            _spdLoginCustomerList_Sheet1.AddSelection(0, 0, 1, 1);
        }

        private void LoginCustomerSelect_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (LoginNaviParameter)arg.NaviParameter;
                _loginCustomerDataDataTable = _naviParam.loginCustomerDataDataTable;
            }
        }

    }
}
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
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.NJ.View.Navigator;

namespace Isid.KKH.Common.KKHView.Top
{
    public partial class LoginForm : KKHDialogBase, INaviParameter
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 「OK」ボタンコントロールがクリックされたときに発生します
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            setLoginData();
            TopMenuNaviParameter inNaviParameter = new TopMenuNaviParameter();
            inNaviParameter.Function = Function.TOP;
            inNaviParameter.strEsqId = txtTan.Text;
            inNaviParameter.strEgcd = "10";
            inNaviParameter.strTksKgyCd = (txtTkicd.Text).Substring(0,6);
            inNaviParameter.strTksBmnSeqNo = (txtTkicd.Text).Substring(6, 2);
            inNaviParameter.strTksTntSeqNo = (txtTkicd.Text).Substring(8, 2);

            Navigator.Forward(this, "tofrmTopMenuAcom", inNaviParameter);

        }

        /// <summary>
        /// 「CANCEL」ボタンコントロールがクリックされたときに発生します
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }


         /// <summary>
        /// 画面上の入力値・選択値をデータセットに設定します。
        /// </summary>
        private void setLoginData()
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;

using Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog;

namespace Isid.KKH.Common.KKHView.Common.Form
{
    /// <summary>
    /// ダイアログ基底クラス
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
    ///       <description>2011/01/25</description>
    ///       <description>ISID-IT T.Kamidai</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KKHDialogBase : BaseForm,  INaviParameter
    {
        #region メンバ変数

        #endregion メンバ変数


        #region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public KKHDialogBase()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ


        #region イベント

        /// <summary>
        /// KeyDownイベントを処理します。 
        /// </summary>
        /// <param name="e">キー情報</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Alt+F4は無効にします。 
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;

            base.OnKeyDown(e);
        }

        #endregion イベント

        #region 処理中関連1
        /// <summary>
        /// 
        /// </summary>
        protected void ShowLoadingDialog()
        {
            this.Enabled = false;
            this.Refresh();

            LoadingDialogUtilty loadingUtil = LoadingDialogUtilty.GetInstance();
            loadingUtil.ShowLoadingDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void CloseLoadingDialog()
        {
            LoadingDialogUtilty loadingUtil = LoadingDialogUtilty.GetInstance();
            loadingUtil.CloseLoadingDialog();

            this.Enabled = true;
            this.Refresh();
        }
        #endregion 処理中関連1

    }
}
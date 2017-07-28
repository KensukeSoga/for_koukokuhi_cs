using System;
using System.Collections;
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
    /// 画面基底クラス.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2011/01/06</description>
    ///       <description>ISID-IT Y.Sanuki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KKHForm : BaseForm, INaviParameter
    {
        #region インスタンス変数.

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        private const UInt32 SC_CLOSE = 0x0000F060;

        private const UInt32 MF_BYCOMMAND = 0x00000000;

        #endregion インスタンス変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタです。.
        /// </summary>
        public KKHForm()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面表示時処理です。.
        /// 閉じるボタンを無効にします。.
        /// </summary>
        private void KKHForm_Shown(object sender, EventArgs e)
        {
            // コントロールボックスの［閉じる］ボタンの無効化.
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
        }

        /// <summary>
        /// KeyDownイベントを処理します。.
        /// </summary>
        /// <param name="e">キー情報</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Alt+F4は無効にします。.
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;

            base.OnKeyDown(e);
        }

        #endregion イベント.

        #region プロテクトメソッド.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="components">コンポーネント</param>
        protected void DisposeBindingSource(System.ComponentModel.IContainer components)
        {
            foreach (Component component in components.Components)
            {
                if (component is BindingSource)
                {
                    BindingSource bindingSource = (BindingSource)component;
                    bindingSource.Sort = null;
                    bindingSource.Filter = null;
                }
            }
        }

        #region 処理中関連.

        //protected const int WM_MOUSEACTIVATE = 0x0021;
        //
        //protected const int MA_NOACTIVATEANDEAT = 4;
        //
        //protected Boolean _loadingState = false;

        /// <summary>
        /// 
        /// </summary>
        protected void ShowLoadingDialog()
        {
            //_loadingState = true;

            //this.Enabled = false;
            //this.Refresh();

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

            //this.Enabled = true;
            //this.Refresh();

            //_loadingState = false;
        }

        ///// <summary>
        ///// ウィンドウプロシージャーのオーバーライド.

        ///// </summary>
        ///// <param name="m"></param>
        //protected override void WndProc(ref Message m)
        //{
        //    // ShowLoadingDialog～CloseLoadingDialogの間はマウスクリックによるアクティブ化を禁止する.
        //
        //    if (_loadingState)
        //    {
        //        if (m.Msg == WM_MOUSEACTIVATE)
        //        {
        //            m.Result = new IntPtr(MA_NOACTIVATEANDEAT);
        //            return;
        //        }
        //    }
        //
        //    base.WndProc(ref m);
        //}

        #endregion 処理中関連.

        #endregion プロテクトメソッド.
    }
}
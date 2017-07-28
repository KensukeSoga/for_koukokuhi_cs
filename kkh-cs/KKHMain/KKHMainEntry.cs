using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJ;
using Isid.NJ.Exp;
using Isid.NJ.Checker;
using Isid.NJ.Exp.Handler;
using System.Net;
using Isid.KKH.Common.KKHView.Common;
using Isid.Soa.Framework.Client.Exception;
using Isid.KKH.Common.KKHUtility.Constants;
using System.Windows.Forms;

namespace Isid.KKH.Main
{
    /// <summary>
    /// 本システム用にカスタマイズされたNJMainEntryです。 
    /// ※カスタマイズの必要が無い場合、何も実装する必要はありません 
    /// </summary>
    public class KKHMainEntry : NJMainEntry
    {
        #region プロテクトメソッド

        /// <summary>
        /// 共通例外処理ハンドラの設定をカスタマイズします。 
        /// 追加の処理を行う場合やダイアログの表示を変更したい場合にオーバーライドしてください。 
        /// </summary>
        protected override void InstallExceptionHandler()
        {
            // base.InstallExceptionHandlerは呼び出しません。 
            // 呼び出すと既定の例外処理がすべて行われてしまいます。 
            // base.InstallExceptionHandler(); 
            // CheckFailurHandlerの登録 
            ExceptionDispatcher.getInstance().ExceptionHandler += new CheckFailureHandler().HandleException;

            // LogHandlerの登録 
            ExceptionDispatcher.getInstance().ExceptionHandler += new LogHandler().HandleException;

            // 独自の例外処理の追加 
            ExceptionDispatcher.getInstance().ExceptionHandler += new NJExceptionEventHandler(KKHMainEntry_ExceptionHandler);
        }

        #endregion プロテクトメソッド

        #region プライベートメソッド

        /// <summary>
        /// 独自の例外処理です。 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KKHMainEntry_ExceptionHandler(object sender, NJExceptionEventArgs e)
        {
            //エラー発生時に処理中ダイアログが表示されている場合はダイアログを閉じる 
            Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog.LoadingDialogUtilty loadingUtil = Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog.LoadingDialogUtilty.GetInstance();
            if (loadingUtil.IsShow)
            {
                Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog.LoadingDialogUtilty.GetInstance().CloseLoadingDialog();
            }

            if (e.Cancel)
            {
                return;
            }

            if (e.Exception.GetBaseException() is ServiceTimeoutException)
            {
                //MessageUtility.ShowMessageBoxByXML("BD-E0006");
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "システム", MessageBoxButtons.OK);
            }
            else
            {
                //MessageUtility.ShowMessageBoxByXML("BD-E0007");
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "システム", MessageBoxButtons.OK);
            }
        }

        #endregion プライベートメソッド
    }
}

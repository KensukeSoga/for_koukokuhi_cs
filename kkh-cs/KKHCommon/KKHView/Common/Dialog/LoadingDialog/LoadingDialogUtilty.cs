using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog
{
    /// <summary>
    /// ローディングダイアログ.
    /// </summary>
    public class LoadingDialogUtilty
    {
        #region コンストラクタ(非公開)

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private LoadingDialogUtilty()
        {

        }

        #endregion コンストラクタ(非公開)

        #region インスタンス変数.

        /// <summary>
        /// インスタンス変数.
        /// </summary>
        private static LoadingDialogUtilty _this;

        #endregion インスタンス変数.

        #region プロパティ.

        /// <summary>
        /// ローディングダイアログを表示中かどうかを取得します。.
        /// </summary>
        public bool IsShow
        {
            get
            {
                //ダイアログ表示用のスレッドがNullでなければ表示中と判断する.
                return (_thread != null);
            }
        }

        #endregion プロパティ.

        /// <summary>
        /// インスタンスを取得します。.
        /// </summary>
        /// <returns></returns>
        public static LoadingDialogUtilty GetInstance()
        {
            if (_this == null)
            {
                _this = new LoadingDialogUtilty();
            }
            return _this;
        }

        #region ダイアログ呼び出し.

        System.Threading.Thread _thread;   //ダイアログ表示用のスレッド.
        System.Windows.Forms.Form _parent; //ダイアログ表示を実行したフォームを保持する変数.
        LoadingDialog _dialog;

        /// <summary>
        /// ローディング表示開始.
        /// </summary>
        public void ShowLoadingDialog()
        {
            ShowLoadingDialog(null);
        }
        /// <summary>
        /// ローディング(タイプ1)表示開始.
        /// </summary>
        /// <param name="parent"></param>
        public void ShowLoadingDialog(System.Windows.Forms.Form parent)
        {
            ShowLoadingDialog1(parent);
        }
        /// <summary>
        /// ローディング(タイプ1)表示終了.
        /// </summary>
        public void CloseLoadingDialog()
        {
            CloseLoadingDialog1();
        }

        #region タイプ1
        /// <summary>
        /// ローディングダイアログの表示をします。.
        /// </summary>
        /// <param name="parent">ダイアログ表示を実行したフォーム</param>
        private void ShowLoadingDialog1(System.Windows.Forms.Form parent)
        {
            if (_thread != null)
            {
                //_threadがNullでない場合は既に表示中のはずなので処理を中止する.
                return;
            }

            _parent = parent;

            //*******************************************
            //ダイアログ表示.
            //*******************************************
            LoadingDialog dialog = new LoadingDialog();
            if (_parent != null)
            {
                //呼び出し元の画面情報がある場合は呼び出し元画面に被せるような表示にする.
                dialog.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                //dialog.Location = _parent.Location;
                //dialog.Size = _parent.Size;
                int a = int.Parse(Decimal.Round(parent.Width * 0.1M).ToString());
                int b = int.Parse(Decimal.Round(parent.Height * 0.1M).ToString());
                dialog.Location = new System.Drawing.Point(_parent.Location.X + (a / 2),_parent.Location.Y + (b / 2));
                dialog.Size = new System.Drawing.Size(_parent.Size.Width - a, _parent.Size.Height - b);
                //_parent.Visible = false;

                ////呼び出し元の画面情報がある場合は呼び出し元画面に被せるような表示にする.
                //dialog.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                //const int w = 640;
                //const int h = 160;
                //dialog.Location = new System.Drawing.Point(_parent.Location.X + ( ( _parent.Size.Width - w ) / 2 ), _parent.Location.Y + ( ( _parent.Size.Height - h ) / 2 ));
                //dialog.Size = new System.Drawing.Size(w, h);
            }
            else
            {
                //呼び出し元の画面情報がない場合は画面中央にデフォルトサイズで表示.
                dialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            }
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(dialog.StartPicture));//画像を表示.
            //_thread = new System.Threading.Thread(new System.Threading.ThreadStart(dialog.StartProgressBar));//プログレスバーを表示.
            _thread.IsBackground = true;
            _thread.Start();

            //呼び出し元の画面を操作するのはやめる.
            ////呼び出し元フォームを前面表示.
            //_parent.BringToFront();

            _dialog = dialog;
        }

        /// <summary>
        /// ローディングダイアログをクローズします。.
        /// </summary>
        private void CloseLoadingDialog1()
        {
            if (_thread == null)
            {
                return;
            }
//          _thread.Abort();//強制終了.

            // ローディングダイアログの終了フラグをON
            _dialog.CloseFlag = true;

            // スレッドが終了するまで待機.
            _thread.Join();

            // ローディングダイアログを解放.
            _dialog = null;

            //呼び出し元の画面を操作するのはやめる.
            //if (_parent != null)
            //{
            //    _parent.Enabled = true;
            //    _parent.Refresh();
            //}
            if (_parent != null)
            {
                _parent.Visible = true;
            }
            _parent = null;
            _thread = null;
        }

        #endregion タイプ1

        #region タイプ2

        /// <summary>
        /// ローディングダイアログの表示をします。.
        /// </summary>
        /// <param name="parent">ダイアログ表示を実行したフォーム</param>
        private void ShowLoadingDialog2(System.Windows.Forms.Form parent)
        {
            if (_thread != null)
            {
                //_threadがNullでない場合は既に表示中のはずなので処理を中止する.
                return;
            }

            _parent = parent;

            //*******************************************
            //ダイアログ表示.
            //*******************************************
            LoadingDialog2 dialog = new LoadingDialog2();
            if (_parent != null)
            {
                //呼び出し元の画面情報がある場合は呼び出し元画面に被せるような表示にする.
                dialog.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                dialog.Location = _parent.Location;
                dialog.Size = _parent.Size;
                dialog.ParentForm = _parent;
            }
            else
            {
                //呼び出し元の画面情報がない場合は画面中央にデフォルトサイズで表示.
                dialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            }
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(dialog.StartPicture));//画像を表示.
            //_thread = new System.Threading.Thread(new System.Threading.ThreadStart(dialog.StartProgressBar));//プログレスバーを表示.
            _thread.IsBackground = true;
            _thread.Start();

            if (_parent != null)
            {
                System.Threading.Thread.Sleep(100);
                //呼び出し元画面を非表示にする.
                _parent.Visible = false;
                _parent.Update();
            }
        }

        /// <summary>
        /// ローディングダイアログをクローズします。.
        /// </summary>
        private void CloseLoadingDialog2()
        {
            if (_thread == null)
            {
                return;
            }

            if (_parent != null)
            {
                _parent.Visible = true;
                _parent.Update();
            }
            _thread.Abort();//強制終了.

            _parent = null;
            _thread = null;
        }

        #endregion タイプ2

        #endregion ダイアログ呼び出し.

    }
}

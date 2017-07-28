using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHView.Common.Control.MenuButton
{
    /// <summary>
    /// ポップアップ内のボタンクリックイベントを処理.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="value"></param>
    public delegate void PopupButtonClickEventHandler(object sender, PopupButtonClickEventArgs value);

    /// <summary>
    /// .
    /// </summary>
    public class PopupButtonClickEventArgs : EventArgs
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PopupButtonClickEventArgs()
        {
        }
        #endregion コンストラクタ

        private string _value;
        /// <summary>
        /// クリックしたボタンの値.
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}

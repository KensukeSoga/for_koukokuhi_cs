using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Isid.NJ.View.Widget;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control
{

    /// <summary>
    /// Kkhテキストボックスコントロール 
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
    ///       <description>2012/02/20</description>
    ///       <description>IP Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KkhNumericTextBox : NJTextBox
    {
        #region メンバ
        /// <summary>
        /// メッセージID（貼り付け）        /// </summary>
        private const int MESSAGE_ID_PASTE = 0x0302;

        /// <summary>
        /// メッセージID（マウス左ボタンダウン）        /// </summary>
        private const int MESSAGE_ID_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// メッセージID（マウス左ボタンアップ）        /// </summary>
        private const int MESSAGE_ID_LBUTTONUP = 0x0202;

        /// <summary>
        /// メッセージID（マウス左ボタンダブルクリック）        /// </summary>
        private const int MESSAGE_ID_LBUTTONDBLCLK = 0x0203;

        /// <summary>
        /// メッセージID（マウス右ボタンダウン）        /// </summary>
        private const int MESSAGE_ID_RBUTTONDOWN = 0x0204;

        /// <summary>
        /// メッセージID（マウス右ボタンアップ）        /// </summary>
        private const int MESSAGE_ID_RBUTTONUP = 0x0205;

        /// <summary>
        /// メッセージID（マウス右ボタンダブルクリック）        /// </summary>
        private const int MESSAGE_ID_RBUTTONDBLCLK = 0x0206;

        /// <summary>
        /// ASCII文字（桁区切り）        /// </summary>
        private const char ASCII_COMMA = ',';

        /// <summary>
        /// ASCII文字（小数点） 
        /// </summary>
        private const char ASCII_DECIMAL_POINT = '.';

        /// <summary>
        /// ASCII文字（BS） 
        /// </summary>
        private const char ASCII_BACKSPACE = '\b';

        /// <summary>
        /// ASCII文字（0） 
        /// </summary>
        private const char ASCII_NUMERIC_START = '0';

        /// <summary>
        /// ASCII文字（9） 
        /// </summary>
        private const char ASCII_NUMERIC_END = '9';

        /// <summary>
        /// フォーマット済みテキスト 
        /// </summary>
        private string _originalTextFormat;

        #endregion メンバ

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        public KkhNumericTextBox()
            : base()
        {
            InitializeComponent();
        }

        #endregion

        #region メソッド
        #endregion

        #region プロテクトメソッド

        /// <summary>
        /// Windowsメッセージを処理します。 
        /// </summary>
        /// <param name="m">処理対象のWindowsMessage</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (MESSAGE_ID_PASTE == m.Msg)
            {
                // メッセージIDが「貼り付け」の場合 
                return;
            }
            else if
            (
                ( m.Msg == MESSAGE_ID_LBUTTONDOWN   ) ||
                ( m.Msg == MESSAGE_ID_LBUTTONUP     ) ||
                ( m.Msg == MESSAGE_ID_LBUTTONDBLCLK ) ||
                ( m.Msg == MESSAGE_ID_RBUTTONDOWN   ) ||
                ( m.Msg == MESSAGE_ID_RBUTTONUP     ) ||
                ( m.Msg == MESSAGE_ID_RBUTTONDBLCLK )
            )
            {
                if( ReadOnly != false )
                {
                    // 読み取り専用の場合はマウス左右ボタンイベントを無視する 
                    return;
                }
            }

            base.WndProc(ref m);
        }

        #endregion プロテクトメソッド

        #region プライベートメソッド

        /// <summary>
        /// マスクでフォーマットしたTextプロパティの値を元に戻します。 
        /// </summary>
        private void UnFormat()
        {
            this.Text = this.Text.Replace(ASCII_COMMA.ToString(), string.Empty);
        }

        /// <summary>
        /// Textプロパティの値を指定したマスクでフォーマットします。 
        /// </summary>
        private void Format()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = "0.0";
            }

            if (string.IsNullOrEmpty(this.Mask))
            {
                return;
            }

            // 小数点が入力済みかどうかのフラグ 
            bool hasDecimalPoint = this.Text.Contains(ASCII_DECIMAL_POINT.ToString());

            if (hasDecimalPoint)
            {
                this.Text = double.Parse(this.Text).ToString(this.Mask);
            }
            else
            {
                this.Text = long.Parse(this.Text).ToString(this.Mask);
            }
        }

        /// <summary>
        /// バックスペースが押されたときの処理です。 
        /// </summary>
        /// <returns>イベントが処理されたかどうかを示す値</returns>
        private bool KeyPressByBackspace()
        {
            return false;
        }

        /// <summary>
        /// 小数点が押されたときの処理です。 
        /// </summary>
        /// <returns>イベントが処理されたかどうかを示す値</returns>
        private bool KeyPressByDecimalPoint()
        {
            if (this.DecimalPlaces <= 0)
            {
                // 「小数点桁数」が0の場合はイベントをキャンセル 
                return true;
            }

            if (this.SelectionStart <= 0)
            {
                // 「小数点」が先頭文字の場合はイベントをキャンセル 
                return true;
            }

            if (this.Text.Contains(ASCII_DECIMAL_POINT.ToString()))
            {
                // 「小数点」が入力済みの場合はイベントをキャンセル 
                return true;
            }

            string integerPlaces = this.Text.Substring(0, this.SelectionStart);
            if ((this.SignificantFigure - this.DecimalPlaces) < integerPlaces.Length)
            {
                // 指定値の整数桁数を超える場合はイベントをキャンセル 
                return true;
            }

            string decimalPlaces = this.Text.Substring(this.SelectionStart, this.Text.Length - this.SelectionStart);
            if (this.DecimalPlaces < decimalPlaces.Length)
            {
                // 指定値の少数点以下桁数を超える場合はイベントをキャンセル 
                return true;
            }

            return false;
        }

        /// <summary>
        /// 数字以外が押されたときの処理です。 
        /// </summary>
        /// <returns>イベントが処理されたかどうかを示す値</returns>
        private bool KeyPressByChar()
        {
            // イベントをキャンセル 
            return true;
        }

        /// <summary>
        /// 数字が押されたときの処理です。 
        /// </summary>
        /// <returns>イベントが処理されたかどうかを示す値</returns>
        private bool KeyPressByNumeric()
        {
            // 小数点のインデックス 
            int index = this.Text.IndexOf(ASCII_DECIMAL_POINT);

            if (this.Text.Contains(ASCII_DECIMAL_POINT.ToString()))
            {
                // 「小数点」が入力済みの場合 
                if (this.SelectionStart <= index)
                {
                    // 「整数部」の場合 
                    string integerPlaces = this.Text.Substring(0, index);
                    if ((this.SignificantFigure - this.DecimalPlaces) <= integerPlaces.Length)
                    {
                        // 入力値の整数桁数が指定値を超える場合はイベントをキャンセル 
                        return true;
                    }

                    return false;
                }

                if (index + 1 <= this.SelectionStart)
                {
                    // 「少数部」の場合 
                    string decimalPlaces = this.Text.Substring(index + 1, this.Text.Length - (index + 1));
                    if (this.DecimalPlaces <= decimalPlaces.Length)
                    {
                        // 入力値の小数点以下桁数が指定値を超える場合はイベントをキャンセル 
                        return true;
                    }

                    return false;
                }

                return false;
            }

            // 「小数点」が未入力の場合 
            if (this.SignificantFigure <= 0)
            {
                // 「有効桁数」が無効の場合はイベントをキャンセル 
                return true;
            }

            if (this.DecimalPlaces <= 0)
            {
                // 「小数点以下桁数」が無効の場合 
                if (this.SignificantFigure <= this.Text.Length)
                {
                    // 入力値の整数桁数が指定値を超える場合 
                    return true;
                }

                return false;
            }

            if (0 < this.DecimalPlaces)
            {
                // 「小数点以下桁数」が有効の場合 
                if (this.SelectionStart == this.Text.Length)
                {
                    // 末尾の場合 
                    if (this.Text.Length < (this.SignificantFigure - this.DecimalPlaces))
                    {
                        // 整数部の場合 
                        return false;
                    }

                    if ((this.SignificantFigure - this.DecimalPlaces) == this.Text.Length)
                    {
                        // 小数点の場合 
                        this.Text = string.Concat(this.Text, ASCII_DECIMAL_POINT);
                        this.SelectionStart = this.Text.IndexOf(ASCII_DECIMAL_POINT) + 1;

                        return false;
                    }

                    if ((this.SignificantFigure - this.DecimalPlaces) < this.Text.Length)
                    {
                        // 入力値の整数桁数が指定値を超える場合はイベントをキャンセル 
                        return true;
                    }

                    return false;
                }

                // 途中の場合 
                if ((this.SignificantFigure - this.DecimalPlaces) <= this.Text.Length)
                {
                    // 入力値の整数桁数が指定値を超える場合はイベントをキャンセル 
                    return true;
                }

                return false;
            }

            return false;
        }

        #endregion プライベートメソッド

        #region プロパティ

        /// <summary>
        /// 実行時に使用する入力マスク 
        /// </summary>
        private string _mask;

        /// <summary>
        /// 実行時に使用する入力マスクを取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Browsable(true)]
        public string Mask
        {
            get
            {
                return _mask;
            }
            set
            {
                _mask = value;
            }
        }

        /// <summary>
        /// 有効桁数 
        /// </summary>
        private int _significantFigure;

        /// <summary>
        /// 有効桁数を取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Browsable(true)]
        public int SignificantFigure
        {
            get
            {
                return _significantFigure;
            }
            set
            {
                _significantFigure = value;
            }
        }

        /// <summary>
        /// 小数点桁数 
        /// </summary>
        private int _decimalPlaces;

        /// <summary>
        /// 小数点桁数を取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Browsable(true)]
        public int DecimalPlaces
        {
            get
            {
                return _decimalPlaces;
            }
            set
            {
                _decimalPlaces = value;
            }
        }

        /// <summary>
        /// マスクでフォーマットしたテキストを取得または設定します。 
        /// </summary>
        [Category("Rg")]
        [Browsable(true)]
        public string TextFormat
        {
            set
            {
                this.Text = value;

                Format();
            }
        }

        #endregion プロパティ

        #region イベント

        /// <summary>
        /// KeyPressイベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // 文字列 
            string originalText = this.Text;
            int originalSelectionStart = this.SelectionStart;

            this.Text = this.Text.Remove(this.SelectionStart, this.SelectionLength);
            this.SelectionStart = originalSelectionStart;

            // 読み込み専用指定の場合はイベントをキャンセル 
            if( ReadOnly != false )
            {
                e.Handled = true;
            }
            else if (e.KeyChar == ASCII_BACKSPACE)
            {
                // 入力が「Backspace」の場合 
                e.Handled = KeyPressByBackspace();
            }
            else if (e.KeyChar == ASCII_DECIMAL_POINT)
            {
                // 入力が「小数点」の場合 
                e.Handled = KeyPressByDecimalPoint();
            }
            else if (e.KeyChar < ASCII_NUMERIC_START || ASCII_NUMERIC_END < e.KeyChar)
            {
                // 入力が「数字」以外の場合はイベントをキャンセル 
                e.Handled = KeyPressByChar();
            }
            else
            {
                // 入力が「数字」の場合 
                e.Handled = KeyPressByNumeric();
            }

            if (e.Handled)
            {
                this.Text = originalText;
                this.SelectionStart = originalSelectionStart;
            }

            base.OnKeyPress(e);
        }

        /// <summary>
        /// Leaveイベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnLeave(EventArgs e)
        {
            Format();

            if (this.Text.Equals(_originalTextFormat))
            {
                return;
            }

            base.OnLeave(e);
        }

        /// <summary>
        /// Enterイベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnEnter(EventArgs e)
        {
            _originalTextFormat = this.Text;

            UnFormat();

            base.OnEnter(e);
        }

        #endregion イベント
    }
}

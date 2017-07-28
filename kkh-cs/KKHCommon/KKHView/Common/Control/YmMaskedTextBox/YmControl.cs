using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    /// <summary>
    /// 年月入力用ユーザーコントロール.
    /// </summary>
    public partial class YmControl : UserControl
    {
        #region 子コントロールのEventHandler

        //*********************************************************
        //公開する子コントロールのイベントを定義する.
        //*********************************************************

        //Value取得時に無限ループに陥る可能性がある為削除.
        ///// <summary>
        ///// Textプロパティが変更された場合に発生します。.
        ///// </summary>
        //public event EventHandler TxtYmTextChanged
        //{
        //    add { txtYM.TextChanged += value; }
        //    remove { txtYM.TextChanged -= value; }
        //}

        /// <summary>
        /// コントロールが検証を行っているときに発生します。.
        /// </summary>
        public event CancelEventHandler TxtYmValidating
        {
            add { txtYM.Validating += value; }
            remove { txtYM.Validating -= value; }
        }

        /// <summary>
        /// テキストのキーが押されたとき.
        /// </summary>
        public event KeyEventHandler TxtKeyDown
        {
            add { txtYM.KeyDown += value; }
            remove { txtYM.KeyDown -= value; }
        }

        /// <summary>
        /// コントロールが検証を終了すると発生します。.
        /// </summary>
        public event EventHandler TxtYmValidated
        {
            add { txtYM.Validated += value; }
            remove { txtYM.Validated -= value; }
        }

        /// <summary>
        /// 検証メソッドを一度だけ無効にするフラグ（キャンセル用）.
        /// </summary>
        public Boolean ValidateDisableOnce
        {
            set{ txtYM.ValidateDisableOnce = value; }
            get{ return txtYM.ValidateDisableOnce; }
        }

        #endregion 子コントロールのEventHandler

        #region プロパティ.
        /// <summary>
        /// 現在ユーザーに表示されているテキストを取得または設定します。.
        /// </summary>
        [Browsable(false)]                              //プロパティウィンドウ非表示.
        [DefaultValue("")]                              //既定値.
        public new string Text
        {
            get { return txtYM.Text; }
            //set { txtYM.Text = value; }
        }

        /// <summary>
        /// マスクを行わない状態のテキストを取得または設定します。.
        /// </summary>
        [Browsable(true)]                               //プロパティウィンドウ表示.
        [DefaultValue("")]                              //既定値.
        public string Value
        {
            get { return txtYM.Value; }
            set
            { txtYM.Value = value;
              cmbYM.Text = txtYM.Text;//コンボボックスにも値をセット.
            }
        }

        /// <summary>
        /// 現在ユーザーに表示されているテキストの年部分を取得または設定します。.
        /// </summary>
        [Browsable(false)]                              //プロパティウィンドウ非表示.
        public string Year
        {
            get { return txtYM.Year; }
        }

        /// <summary>
        /// 現在ユーザーに表示されているテキストの月部分を取得または設定します。.
        /// </summary>
        [Browsable(false)]                              //プロパティウィンドウ非表示.
        public string Month
        {
            get { return txtYM.Month; }
        }

        /// <summary>
        /// 実行時に使用する入力マスクを取得または設定します。.
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [DefaultValue(MaskText.SLASH)]                 //既定値.
        //public new MaskText Mask                     //とりあえず既定値で固定.
        private new MaskText Mask
        {
            get { return txtYM.Mask; }
            set { txtYM.Mask = value; }
        }

        /// <summary>
        /// フォーカス取得時文字全選択.
        /// </summary>
        /// <remarks>
        /// Trueに設定するとフォーカス取得時に入力文字列を全選択します。.
        /// </remarks>
        //[Category("NJTextBox")]
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [Description("True=フォーカスを取得したときに、表示文字を全選択します。")]
        [DefaultValue(true)]
        public bool AutoSelect
        {
            get { return txtYM.AutoSelect; }
            set { txtYM.AutoSelect = value; }
        }

        /// <summary>
        /// 入力可能な最大値を取得または設定します。.
        /// </summary>
        /// <remarks>
        /// YYYYMM形式.
        /// </remarks>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [Description("入力可能な最大値です。")]
        [DefaultValue(YmControlConst.INPUT_MAXVALUE)]
        public string MaxValue
        {
            get { return txtYM.MaxValue; }
            set { txtYM.MaxValue = value; }
        }

        /// <summary>
        /// 入力可能な最小値を取得または設定します。.
        /// </summary>
        /// <remarks>
        /// YYYYMM形式.
        /// </remarks>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [Description("入力可能な最小値です。")]
        [DefaultValue(YmControlConst.INPUT_MINVALUE)]
        public string MinValue
        {
            get { return txtYM.MinValue; }
            set { txtYM.MinValue = value; }
        }

        /// <summary>
        /// 表示モード.
        /// </summary>
        private DisplayMode _displayMode = DisplayMode.TEXT_BUTTON;

        /// <summary>
        /// 表示するコントロールのモードを取得または設定します。.
        /// YYYYMM形式.
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [Description("表示するコントロールのモードを指定します。")]
        [DefaultValue(DisplayMode.TEXT_BUTTON)]
        public DisplayMode DisplayMode
        {
            get { return _displayMode; }
            set {
                _displayMode = value;
                if (_displayMode == DisplayMode.TEXT_BUTTON)
                {
                    txtYM.Visible = true;
                    btnCalendar.Visible = true;
                    cmbYM.Visible = false;
                }
                else if (_displayMode == DisplayMode.COMBO)
                {
                    txtYM.Visible = false;
                    btnCalendar.Visible = false;
                    cmbYM.Visible = true;
                }
            }
        }

        #endregion プロパティ.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public YmControl()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region オーバーライド.

        #endregion オーバーライド.

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            txtYM.ShowCalender();
        }

        #region イベント(年月選択コンボボックス).

        /// <summary>
        /// ？.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbYM_Validating(object sender, CancelEventArgs e)
        {
            string text = cmbYM.Text.Replace("/", "");

            //これいる？.
            //if (text.Equals(string.Empty))
            //{
            //    //未入力時は何もしない.
            //    return;
            //}

            //日付妥当性チェック.
            DateTime date = new DateTime();
            if (DateTime.TryParseExact(text, "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date) == false)
            {
                //エラーメッセージ(入力形式が正しくありません。)を表示.
                //MessageBox.Show("入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0072, null, "入力エラー", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            if ((IsDate(Value, "yyyyMM") == true) && (int.Parse(Value) >= int.Parse(txtYM.MaxValue)))
            {
                // 1950年01月以前は1950年01月に設定.
                Value = txtYM.MaxValue;
            }
            else if ((IsDate(Value, "yyyyMM") == true) && (int.Parse(Value) <= int.Parse(txtYM.MinValue)))
            {
                // 2049年12月以後は2049年12月に設定.
                Value = txtYM.MinValue;
            }
        }

        private void cmbYM_TextChanged(object sender, EventArgs e)
        {
            int point = cmbYM.SelectionStart;
            txtYM.Value = cmbYM.Text.Replace("/", "");
            cmbYM.Text = cmbYM.Text.Replace("/", "");
            cmbYM.SelectionStart = point;
        }

        #endregion イベント(年月選択コンボボックス)

        #region イベント.

        private void cmbYM_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void cmbYM_Leave(object sender, EventArgs e)
        {
            if (cmbYM.Text.Length == 6)
            {
                this.cmbYM.TextChanged -= new System.EventHandler(this.cmbYM_TextChanged);
                cmbYM.Text = cmbYM.Text.Substring(0, 4) + "/" + cmbYM.Text.Substring(4, 2);
                this.cmbYM.TextChanged += new System.EventHandler(this.cmbYM_TextChanged);
            }
        }

        private void cmbYM_Enter(object sender, EventArgs e)
        {
            this.cmbYM.TextChanged -= new System.EventHandler(this.cmbYM_TextChanged);
            cmbYM.Text = cmbYM.Text.Replace("/", string.Empty);
            this.cmbYM.TextChanged += new System.EventHandler(this.cmbYM_TextChanged);
        }

        #endregion イベント.

        # region メソッド.
        /// <summary>
        /// 年月コンボボックス日付設定.
        /// </summary>
        public void cmbYM_SetDate()
        {
            string text = cmbYM.Text.Replace("/", "");
            if (IsDate(text, "yyyyMM") == false)
            {
                text = DateTime.Now.ToString("yyyyMM");
            }

            DateTime date = DateTimeParseExact(text, "yyyyMM");
            cmbYM.Items.Clear();
            //過去年月の設定.
            //2013/02/01 HLC sonobe 過去年月の設定値を２→４に変更（ｱｻﾋD）.

            //int minYear = 2;//現在値より2か月前までを表示.
            //int minYear = 1;//現在値より１か月前までを表示.
            int minYear = 4;//現在値より4か月前までを表示.
            for (int i = minYear; i > 0; i--)
            {
                string addItem = date.AddMonths(i * -1).ToString("yyyy/MM");
                cmbYM.Items.Add(addItem);
            }
            //当月の設定.
            cmbYM.Items.Add(date.ToString("yyyy/MM"));
            //未来年月の設定.
            int maxYear = 4;//現在値より４か月後までを表示.
            for (int i = 1; i <= maxYear; i++)
            {
                string addItem = date.AddMonths(i).ToString("yyyy/MM");
                cmbYM.Items.Add(addItem);
            }

            //2013/02/01 HLC sonobe プルダウンの表示数を設定（ｱｻﾋD）.

            cmbYM.MaxDropDownItems = minYear + maxYear + 1;
        }

        # endregion メソッド.

        #region ユーティリティ.

        /// <summary>
        /// stringをDateTimeに変換.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private DateTime DateTimeParse(string str)
        {
            DateTime date = DateTime.MaxValue;

            DateTime.TryParse(str, out date);

            return date;
        }

        /// <summary>
        /// stringをDateTimeに変換(フォーマットの指定あり).
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private DateTime DateTimeParseExact(string str, string format)
        {
            DateTime date = DateTime.MaxValue;

            DateTime.TryParseExact(str, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date);

            return date;
        }

        /// <summary>
        /// DateTimeとして正しい文字列か判定.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsDate(string str)
        {
            DateTime date = new DateTime();
            return DateTime.TryParse(str, out date);
        }

        /// <summary>
        /// DateTimeとして正しい文字列か判定(フォーマットの指定あり).
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private bool IsDate(string str, string format)
        {
            DateTime date = new DateTime();
            return DateTime.TryParseExact(str, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date);
        }

        #endregion ユーティリティ.
    }
}

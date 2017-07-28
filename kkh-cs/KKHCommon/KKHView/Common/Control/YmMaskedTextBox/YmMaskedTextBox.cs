using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.NJ.View.Widget;

namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    internal partial class YmMaskedTextBox : NJMaskedTextBox
    {
        #region 定数.

        /// <summary>
        /// プロパティMaskにNOMASKが指定されている場合のMask文字列.
        /// </summary>
        private const string MaskText_NOMASK = "";
        /// <summary>
        /// プロパティMaskにSLASHが指定されている場合のMask文字列.
        /// </summary>
        private const string MaskText_SLASH = "0000/00";

        #endregion 定数.

        #region プロパティ.

        MaskText _mask = MaskText.SLASH;
        /// <summary>
        /// 実行時に使用する入力マスクを取得または設定します。.
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [DefaultValue(MaskText.SLASH)]                 //既定値.
        public new MaskText Mask
        {
            get
            {
                return _mask;
            }
            set
            {
                _mask = value;
                if (value == MaskText.NO_MASK)
                {
                    base.Mask = MaskText_NOMASK;
                }
                else if (value == MaskText.SLASH)
                {
                    base.Mask = MaskText_SLASH;
                }
                else
                {
                    base.Mask = MaskText_SLASH;
                }
            }
        }

        /// <summary>
        /// 現在ユーザーに表示されているテキストを取得または設定します。.
        /// </summary>
        [Browsable(false)]                             //プロパティウィンドウ非表示.
        public new string Text
        {
            get { return base.Text; }
            set
            {
                DateTime date = new DateTime();
                if (DateTime.TryParseExact(value, "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date))
                {
                    base.Text = value;
                }
                else
                {
                    //TODO:フォーマットエラー処理.
                    base.Text = "";
                }
            }
        }

        /// <summary>
        /// マスクを行わない状態のテキストを取得または設定します。.
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        [DefaultValue("")]                             //既定値.
        public new string Value
        {
            get
            {
                MaskFormat maskFormatNow = this.TextMaskFormat;
                this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string val = this.Text;
                this.TextMaskFormat = maskFormatNow;
                return val;
            }
            set
            {
                this.Text = value;
            }
        }

        /// <summary>
        /// 現在ユーザーに表示されているテキストの年部分を取得または設定します。.
        /// </summary>
        [Browsable(false)]                             //プロパティウィンドウ非表示.
        public new string Year
        {
            get
            {
                string year = "";

                DateTime date = DateTimeParseExact(this.Value, "yyyyMM");
                if (date.CompareTo(DateTime.MaxValue) < 0)
                {
                    year = date.Year.ToString().PadLeft(4, '0');
                }

                return year;
            }
        }

        /// <summary>
        /// 現在ユーザーに表示されているテキストの月部分を取得または設定します。.
        /// </summary>
        [Browsable(false)]                             //プロパティウィンドウ非表示.
        public new string Month
        {
            get
            {
                string month = "";

                DateTime date = DateTimeParseExact(this.Value, "yyyyMM");
                if (date.CompareTo(DateTime.MaxValue) < 0)
                {
                    month = date.Month.ToString().PadLeft(2, '0');
                }

                return month;
            }
        }

        private string _maxValue = YmControlConst.INPUT_MAXVALUE;
        /// <summary>
        /// 入力可能な最大値を取得または設定します。.
        /// </summary>
        /// <remarks>
        /// YYYYMM形式.
        /// </remarks>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        //[Description("")]
        [DefaultValue(YmControlConst.INPUT_MAXVALUE)]
        public string MaxValue
        {
            get { return _maxValue; }
            set
            {
                if (IsDate(value, "yyyyMM") == true && int.Parse(value) >= int.Parse(_minValue))
                {
                    //年月として不正か、設定されている最小値より小さい値は無視.
                    _maxValue = value;
                }
                else
                {
                    //エラー表示処理.
                }
            }
        }

        private string _minValue = YmControlConst.INPUT_MINVALUE;
        /// <summary>
        /// 入力可能な最小値を取得または設定します。.
        /// </summary>
        /// <remarks>
        /// YYYYMM形式.
        /// </remarks>
        [Browsable(true)]                              //プロパティウィンドウ表示.
        //[Description("")]
        [DefaultValue(YmControlConst.INPUT_MINVALUE)]
        public string MinValue
        {
            get { return _minValue; }
            set
            {
                if (IsDate(value, "yyyyMM") == true && int.Parse(value) <= int.Parse(_maxValue))
                {
                    //年月として不正か、設定されている最大値より大きい値は無視.
                    _minValue = value;
                }
                else
                {
                    //エラー表示処理.
                }
            }
        }

        /// <summary>
        /// 検証メソッドを一度だけ無効にするフラグ（キャンセル用）.
        /// </summary>
        private Boolean validateDisableOnce = false;

        public Boolean ValidateDisableOnce
        {
            set{ validateDisableOnce = value; }
            get{ return validateDisableOnce; }
        }

        #endregion プロパティ.

        #region コンストラクタ／初期設定.

        public YmMaskedTextBox()
        {
            InitializeComponent();

            InitializeProperty();
        }

        private void InitializeProperty()
        {
            Mask = Mask;
            //base.Mask = "0000/00";
        }

        #endregion コンストラクタ／初期設定.

        #region イベントのオーバーライド.

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: カスタム ペイント コードをここに追加します.
            // 基本クラス OnPaint を呼び出しています.
            base.OnPaint(pe);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValidating(CancelEventArgs e)
        {
            // 一度だけチェックを無効化する.
            if( validateDisableOnce )
            {
                validateDisableOnce = false;
                return;
            }

            string text = this.Value;

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

            if (( IsDate(Value, "yyyyMM") == true ) && ( int.Parse(Value) >= int.Parse(_maxValue) ))
            {
                // 1950年01月以前は1950年01月に設定.
                Value = _maxValue;
            }
            else if (( IsDate(Value, "yyyyMM") == true ) && ( int.Parse(Value) <= int.Parse(_minValue) ))
            {
                // 2049年12月以後は2049年12月に設定.
                Value = _minValue;
            }

            base.OnValidating(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            //TODO:とりあえずダブルクリックで表示.
            ShowCalender();
        }

        #endregion イベントのオーバーライド.

        #region ポップアップ.

        /// <summary>
        /// カレンダーを表示する.
        /// </summary>
        public void ShowCalender()
        {
            //ポップアップ作成用のコントロール.
            ToolStripDropDown popup = new ToolStripDropDown();
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;

            //TopLevelプロパティをFalseにしないとAddできない。.
            YmCalenderForm frm2 = new YmCalenderForm();
            frm2.TopLevel = false;
            //パラメータの設定.
            frm2.CallCtrl = this;
            frm2.MaxValue = DateTimeParseExact(_maxValue, "yyyyMM");
            frm2.MinValue = DateTimeParseExact(_minValue, "yyyyMM");

            //通常のコントロールをToolStrip派生コントロールとして動作させるためのホストする。.
            ToolStripControlHost host = new ToolStripControlHost(frm2);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;

            //ホストされたコントロールをToolStripoDropDownへ登録する。.
            popup.Items.Add(host);

            //マウスの位置にポップアップ表示.
            //popup.Show(new Point(MousePosition.X, MousePosition.Y));
            int posX = this.Location.X;
            int posY = this.Location.Y;
            System.Windows.Forms.Control parentControl = this.Parent;
            while (parentControl.Parent != null)
            {
                posX = posX + parentControl.Location.X;
                posY = posY + parentControl.Location.Y;
                parentControl = parentControl.Parent;
            }

            posY = posY + this.Height;
            //popup.Show(new Point(posX, posY));
            popup.Show(this, 0, Height);
        }

        #endregion ポップアップ.

        #region Utility

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

        #endregion Utility
    }
}

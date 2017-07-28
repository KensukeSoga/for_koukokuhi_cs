using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Isid.NJ.View.Widget;
using System.Drawing;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control
{
    /// <summary>
    /// Kkhボタンコントロール２ 
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
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KkhButton2 : NJButton
    {
        # region コンストラクタ 

        /// <summary>
        /// 
        /// </summary>
        public KkhButton2():base()
        {
            //InitializeComponent();

        }
        # endregion コンストラクタ 

        #region パブリックプロパティ

        /// <summary>
        /// マウスポインタがコントロールの表示領域から離れたときのボタンイメージです。 
        /// </summary>
        private Image _mouseLeaveImage;

        /// <summary>
        /// マウスポインタがコントロールの表示領域から離れたときのボタンイメージを取得または設定します。 
        /// </summary>
        [Category("Kkh")]
        public Image MouseLeaveImage
        {
            get { return _mouseLeaveImage; }
            set
            {
                _mouseLeaveImage = value;

                if (_mouseLeaveImage == null)
                {
                    return;
                }

                SetImage(_mouseLeaveImage);
            }
        }

        /// <summary>
        /// マウスポインタがコンポーネントに移動したときのボタンイメージです。 
        /// </summary>
        private Image _mouseMoveImage;

        /// <summary>
        /// マウスポインタがコンポーネントに移動したときのボタンイメージを取得または設定します。 
        /// </summary>
        [Category("Kkh")]
        public Image MouseMoveImage
        {
            get { return _mouseMoveImage; }
            set { _mouseMoveImage = value; }
        }

        /// <summary>
        /// マウスポインタがコンポーネント上にあり、マウスボタンが押されたときのボタンイメージです。 
        /// </summary>
        private Image _mouseDownImage;

        /// <summary>
        /// マウスポインタがコンポーネント上にあり、マウスボタンが押されたときのボタンイメージを取得または設定します。 
        /// </summary>
        [Category("Kkh")]
        public Image MouseDownImage
        {
            get { return _mouseDownImage; }
            set { _mouseDownImage = value; }
        }

        #endregion パブリックプロパティ

        #region プロテクトプロパティ

        /// <summary>
        /// コントロールがフォーカスを示す四角形を表示する必要があるかどうかを示す値を取得します。 
        /// </summary>
        protected override bool ShowFocusCues
        {
            get { return false; }
        }

        #endregion プロテクトプロパティ

        #region プロテクトメソッド

        /// <summary>
        /// MouseLeave イベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (_mouseLeaveImage == null)
            {
                return;
            }

            if (this.Focused)
            {
                SetImage(_mouseMoveImage);
            }
            else
            {
                SetImage(_mouseLeaveImage);
            }
        }

        /// <summary>
        /// MouseEnterイベントを発生させる。 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (_mouseMoveImage == null)
            {
                return;
            }

            SetImage(_mouseMoveImage);
        }

        /// <summary>
        /// MouseDown イベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_mouseDownImage == null)
            {
                return;
            }

            SetImage(_mouseDownImage);
        }

        /// <summary>
        /// GotFocus イベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (_mouseMoveImage == null)
            {
                return;
            }

            SetImage(_mouseMoveImage);
        }

        /// <summary>
        /// LostFocus イベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (_mouseLeaveImage == null)
            {
                return;
            }

            SetImage(_mouseLeaveImage);
        }

        /// <summary>
        /// OnClick イベントを発生させます。 
        /// </summary>
        /// <param name="e">イベントデータ</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        #endregion プロテクトメソッド

        #region プライベートメソッド

        /// <summary>
        /// ボタンイメージを設定します。 
        /// </summary>
        /// <param name="image">ボタンイメージ</param>
        private void SetImage(Image image)
        {
            this.Image = image;
            this.Size = new System.Drawing.Size(image.Width + 2, image.Height + 2);
            this.BackColor = Color.Transparent;
            this.FlatAppearance.BorderColor = Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent; ;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Invalidate();
        }

        #endregion プライベートメソッド


    }
}

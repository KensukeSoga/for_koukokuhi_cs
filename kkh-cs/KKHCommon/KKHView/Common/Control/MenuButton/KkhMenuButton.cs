using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control.MenuButton
{
    /// <summary>
    /// 
    /// </summary>
    public partial class KkhMenuButton : UserControl
    {
        #region メンバ変数
        //ポップアップ作成用のコントロール 
        private ToolStripDropDown popup = new ToolStripDropDown();
        private ChildButtonForm frm2 = new ChildButtonForm();
        #endregion メンバ変数

        #region イベントハンドラ
        //public delegate void PopupButtonClickEventHandler(object sender, PopupButtonClickEventArgs value);
        //public delegate void PopupButtonClickEventHandler(string value);
        /// <summary>
        /// ポップアップウィンドウのボタンを押下した時のイベント 
        /// </summary>
        public event PopupButtonClickEventHandler PopupButtonClick;
        #endregion イベントハンドラ

        #region プロパティ
        private int _buttonCount = 0;
        /// <summary>
        /// 表示するボタンの個数を取得または設定する。 
        /// </summary>
        [Category("KKH")]
        [Description("表示するボタンの個数を取得または設定する。")]
        [Browsable(true)]
        public int ButtonCount
        {
            get { return _buttonCount; }
            set { _buttonCount = value; }
        }

        private int _columnCount = 0;
        [Category("KKH")]
        [Description("表示するボタンの列数を取得または設定する。")]
        [Browsable(true)]
        public int ColumnCount
        {
            get { return _columnCount; }
            set { _columnCount = value; }
        }

        private string[] _buttonText;
        /// <summary>
        /// ボタンに表示するテキスト 
        /// </summary>
        [Category("KKH")]
        [Description("ボタンに表示するテキスト。ButtonCountに設定した値分の設定をする。")]
        [Browsable(true)]
        public string[] ChildButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }

        private string[] _buttonValue;
        /// <summary>
        /// ボタンがクリックされた際に返却される値 
        /// </summary>
        [Category("KKH")]
        [Description("ボタンがクリックされた際に返却される値。ButtonCountに設定した値分の設定をする。")]
        [Browsable(true)]
        public string[] ButtonValue
        {
            get { return _buttonValue; }
            set { _buttonValue = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DropDownAlignValue : int
        {
            /// <summary>
            /// 
            /// </summary>
            Left = 0,
            /// <summary>
            /// 
            /// </summary>
            Center = 1,
            /// <summary>
            /// 
            /// </summary>
            Right = 2
        }

        private DropDownAlignValue _dropDownAlign = DropDownAlignValue.Left;
        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public DropDownAlignValue DropDownAlign
        {
            get { return _dropDownAlign; }
            set { _dropDownAlign = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(false)]
        public KkhButton Button
        {
            get { return this.button; }
            //set { button = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public Color ButtonBackColor
        {
            get { return this.button.BackColor; }
            set { button.BackColor = value; }
        }

        Image downImg;
        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public Image ButtonMouseDownImage
        {
            get { return downImg; }
            set
            {
                downImg = value;
                button.MouseDownImage = downImg;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public Image ButtonMouseLeaveImage
        {
            get { return this.button.MouseLeaveImage; }
            set { button.MouseLeaveImage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public Image ButtonMouseMoveImage
        {
            get { return this.button.MouseMoveImage; }
            set { button.MouseMoveImage = value; }
        }

        string btnText = "";
        /// <summary>
        /// テキスト 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public string ButtonText
        {
            get { return btnText; }
            set 
            {
                btnText = value;
                this.button.Text = btnText; 
            }
        }

        /// <summary>
        /// TextAlign 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public ContentAlignment ButtonTextAlign
        {
            get { return this.button.TextAlign; }
            set { button.TextAlign = value; }
        }

        string toolTipText = "";
        /// <summary>
        /// テキスト 
        /// </summary>
        [Category("KKH")]
        [Browsable(true)]
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        #endregion プロパティ

        #region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public KkhMenuButton()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popup_Disposed(object sender, EventArgs e)
        {
            popupDisposeTimer.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ShowPopupForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseHover(object sender, EventArgs e)
        {
            ShowPopupForm();
        }

        #endregion イベント

        #region ポップアップ表示
        /// <summary>
        /// 
        /// </summary>
        public void ShowPopupForm()
        {

            popup = new ToolStripDropDown();
            popup.Disposed += new EventHandler(popup_Disposed);
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            popup.DropShadowEnabled = false;
            popup.BackColor = Color.Transparent;

            frm2 = new ChildButtonForm();
            //TopLevelプロパティをFalseにしないとAddできない。 
            frm2.TopLevel = false;

            //パラメータの設定 
            frm2.ButtonCount = _buttonCount;
            frm2.ColumnCount = _columnCount;
            frm2.ButtonText = _buttonText;
            frm2.ButtonValue = _buttonValue;
            frm2.PopupButtonClick += PopupButtonClick;
            frm2.FormGenerate();

            //通常のコントロールをToolStrip派生コントロールとして動作させるためのホストする。 
            ToolStripControlHost host = new ToolStripControlHost(frm2);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            

            //ホストされたコントロールをToolStripoDropDownへ登録する。 
            popup.Region = frm2.Region;
            popup.Items.Clear();
            popup.Items.Add(host);

            //マウスの位置にポップアップ表示 
            //popup.Show(new Point(MousePosition.X, MousePosition.Y));
            int posX = 0;
            int posY = 0;
            //ドロップダウンリストの寄せの設定値によって表示位置の調整を行う.
            if (_dropDownAlign == DropDownAlignValue.Right)
            {
                posX = posX - frm2.Width + this.Width;
            }
            else if (_dropDownAlign == DropDownAlignValue.Center)
            {
                posX = posX - (frm2.Width - this.Width) / 2;
            }
            else
            {
            }

            posY = posY + this.Height;
            popup.Show(this, new Point(posX, posY));
            //popup.Show(this, 0, Height);
            popupDisposeTimer.Start();

            //ボタンの画像をMoveにする 
            this.button.MouseLeaveImage = this.button.MouseMoveImage;
        }
        #endregion ポップアップ表示

        /// <summary>
        /// 
        /// </summary>
        public void popDispose()
        {
            if (popup.IsDisposed == false)
            {
                popup.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private bool CheckMousePos(System.Windows.Forms.Control control)
        {
            Rectangle rect = control.ClientRectangle;

            // マウス座標（スクリーン座標系）の取得 
            Point mouseScreenPos = System.Windows.Forms.Control.MousePosition;
            // マウス座標をクライアント座標系へ変換 
            Point mouseClientPos = control.PointToClient(mouseScreenPos);
            // マウス座標（クライアント座標系）が領域内かどうか 
            bool inside = rect.Contains(mouseClientPos);

            return inside;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popupDisposeTimer_Tick(object sender, EventArgs e)
        {
            if (CheckMousePos(this) == false && CheckMousePos(popup) == false)
            {
                //ボタンの画像をDownにする 
                this.button.MouseLeaveImage = downImg;

                popDispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseEnter(object sender, EventArgs e)
        {
            ShowPopupForm();
        }
    }

}

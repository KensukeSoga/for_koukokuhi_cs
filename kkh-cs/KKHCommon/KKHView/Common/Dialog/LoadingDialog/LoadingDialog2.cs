using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LoadingDialog2 : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadingDialog2()
        {
            InitializeComponent();

            _opacity = 0.5;
        }

        //呼び出し元画面の画像を保持 
        private Bitmap _bmp;
        //呼び出し元画面 
        private System.Windows.Forms.Form _parentForm;

        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Form ParentForm
        {
            get { return _parentForm; }
            set
            {
                _parentForm = value;

                if (_parentForm != null)
                {
                    //呼び出し元画面の画像を保持する 
                    _bmp = new Bitmap(_parentForm.Width, _parentForm.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //_bmp = new Bitmap(_parentForm.Width, _parentForm.Height);
                    _parentForm.DrawToBitmap(_bmp, new Rectangle(0, 0, this.Width, this.Height));
                }
                else
                {
                    _bmp = null;
                }
            }
        }

        double _opacity = 1.00;
        //
        // 概要:
        //     フォームの不透明度を取得または設定します。
        //
        // 戻り値:
        //     フォームの不透明度。既定値は 1.00 です。

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(1)]
        [TypeConverter(typeof(OpacityConverter))]
        public new double Opacity 
        {
            get { return _opacity; }
            set { _opacity = value; }
        }

        #region アクティブ化制御
        ///******************************************************************************
        // * この画面がアクティブ化すると呼び出し元の画面で表示したメッセージボックスが 
        // * この画面に隠れてしまうので以下の対応を行っている  
        // * １．初期表示時にアクティブにしない(ShowWithoutActivationをオーバーライド) 
        // * ２．マウスクリックによるアクティブ化を防止(WndProcをオーバーライド) 
        // * ３．タスクバーに表示しない(ShowInTaskbar = false) 
        //******************************************************************************/

        //protected override bool ShowWithoutActivation
        //{
        //    get
        //    {
        //        //return base.ShowWithoutActivation;
        //        return true;
        //    }
        //}

        //const int WM_MOUSEACTIVATE = 0x0021;
        //const int MA_NOACTIVATE = 3;
        //const int MA_NOACTIVATEANDEAT = 4;

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case WM_MOUSEACTIVATE:
        //            //マウスクリックでアクティブにされるのを防止 
        //            //m.Result = new IntPtr(WA_NOACTIVATE);
        //            m.Result = new IntPtr(MA_NOACTIVATEANDEAT);
        //            return;
        //    }
        //    base.WndProc(ref m);
        //}
        #endregion アクティブ化制御

        #region 公開メソッド
        private bool _closeFlag = false;

        /// <summary>
        /// 画像表示パターン 
        /// </summary>
        public void StartPicture()
        {
            this.njProgressBar1.Enabled = false;
            this.njProgressBar1.Visible = false;
            this.njPictureBox1.Enabled = true;
            this.njPictureBox1.Visible = true;
            this.Show();//自分を表示させる 
            //this.Refresh();
            //呼び出し元で終了させるまで無限ループ 
            while (!_closeFlag)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// プログレスバー表示パターン 
        /// </summary>
        public void StartProgressBar()
        {
            this.njProgressBar1.Enabled = true;
            this.njProgressBar1.Visible = true;
            this.njPictureBox1.Enabled = false;
            this.njPictureBox1.Visible = false;

            this.Enabled = false;
            this.Show();//自分を表示させる 
            this.Refresh();
            //呼び出し元で終了させるまで無限ループ 
            while (!_closeFlag)
            {
                njProgressBar1.Maximum = 200000;
                // プログレスバーの表示
                for (int n = 0; n < njProgressBar1.Maximum; n++)
                {
                    njProgressBar1.Value = n;
                }
            }
        }
        #endregion 公開メソッド

        #region 角を丸くする対応関連
        private int arcWidth = 0;
        /// <summary>
        /// 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(0)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 0;
        /// <summary>
        /// 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(0)]
        public int ArcHeight
        {
            get { return arcHeight; }
            set { arcHeight = value; }
        }

        /// <summary>
        /// フォームの形を変更する 
        /// </summary>
        private void UpdateFormFormat()
        {
            if (arcWidth > 0 && arcHeight > 0)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    Rectangle r = this.ClientRectangle;
                    gp.StartFigure();
                    gp.AddArc(r.Right - arcWidth, r.Top, arcWidth, arcHeight, 270, 90);              // 右上
                    gp.AddArc(r.Right - arcWidth, r.Bottom - arcHeight, arcWidth, arcHeight, 0, 90); // 右下
                    gp.AddArc(r.Left, r.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);            // 左下
                    gp.AddArc(r.Left, r.Top, arcWidth, arcHeight, 180, 90);                          // 左上
                    gp.CloseFigure();

                    //形を変更
                    this.Region = new Region(gp);
                }
            }
        }
        #endregion 角を丸くする対応関連

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_parentForm != null)
            {
                //呼び出し元画面の画像を背景として描画 
                e.Graphics.DrawImage(_bmp, this.ClientRectangle, new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height), GraphicsUnit.Pixel);

                //Rectangle r = this.ClientRectangle;
                //using (SolidBrush sb = new SolidBrush(Color.FromArgb(decimal.ToInt32((decimal)Math.Floor(255 * this.Opacity)), this.BackColor)))
                ////using (SolidBrush sb = new SolidBrush(Color.FromArgb(decimal.ToInt32((decimal)Math.Floor(200M)), this.BackColor)))
                //{
                //    e.Graphics.FillRectangle(sb, r);
                //}
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Load(object sender, EventArgs e)
        {
            //フォームの形を変更 
            UpdateFormFormat();
            //前面表示 
            this.BringToFront();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Activated(object sender, EventArgs e)
        {
            //this.Refresh();
        }


    }
}


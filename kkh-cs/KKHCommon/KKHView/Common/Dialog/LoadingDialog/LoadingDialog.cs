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
    public partial class LoadingDialog : System.Windows.Forms.Form
    {
        # region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public LoadingDialog()
        {
            InitializeComponent();
        }

        # endregion コンストラクタ 

        # region イベント

        /// <summary>
        /// ロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Load(object sender, EventArgs e)
        {
            //フォームの形を変更 
            UpdateFormFormat();
        }

        /// <summary>
        /// Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }


        # endregion イベント

        #region 公開メソッド
        private bool _closeFlag = false;

        /// <summary>
        /// 
        /// </summary>
        public bool CloseFlag
        {
            get { return _closeFlag; }
            set { _closeFlag = value; }
        }

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
            this.Refresh();
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
        private int arcWidth = 45;
        /// <summary>
        /// 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(45)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 45;
        /// <summary>
        /// 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(45)]
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

        #region アクティブ化制御
        /******************************************************************************
         * この画面がアクティブ化すると呼び出し元の画面で表示したメッセージボックスが 
         * この画面に隠れてしまうので以下の対応を行っている  
         * １．初期表示時にアクティブにしない(ShowWithoutActivationをオーバーライド) 
         * ２．マウスクリックによるアクティブ化を防止(WndProcをオーバーライド) 
         * ３．タスクバーに表示しない(ShowInTaskbar = false) 
        ******************************************************************************/
        /// <summary>
        /// 
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get
            {
                //return base.ShowWithoutActivation;
                return true;
            }
        }

        const int WM_MOUSEACTIVATE = 0x0021;
        const int MA_NOACTIVATE = 3;
        const int MA_NOACTIVATEANDEAT = 4;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    //マウスクリックでアクティブにされるのを防止 
                    //m.Result = new IntPtr(WA_NOACTIVATE);
                    m.Result = new IntPtr(MA_NOACTIVATEANDEAT);
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion アクティブ化制御
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control
{
    /// <summary>
    /// OOH進行管理タブコントロール 
    /// </summary>
    public partial class KkhTabControl : System.Windows.Forms.TabControl
    {
        // members to hold our color settings
        private Color selectionBackColor;
        private Color noSelectionBackColor;
        private Color selectionForeColor;
        private Color noSelectionForeColor;
        private Color outOfRangeBackColor;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KkhTabControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public Color SelectionBackColor
        {
            get
            {
                return this.selectionBackColor;
            }
            set
            {
                this.selectionBackColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color NoSelectionBackColor
        {
            get
            {
                return this.noSelectionBackColor;
            }
            set
            {
                this.noSelectionBackColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color SelectionForeColor
        {
            get
            {
                return this.selectionForeColor;
            }
            set
            {
                this.selectionForeColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color NoSelectionForeColor
        {
            get
            {
                return this.noSelectionForeColor;
            }
            set
            {
                this.noSelectionForeColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color OutOfRangeBackColor
        {
            get
            {
                return this.outOfRangeBackColor;
            }
            set
            {
                this.outOfRangeBackColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// DrawItem イベント 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // 背景用のブラシを作成、フォント色を設定 
            Brush brBack;
            Color fontColor;
            if (e.Index == this.SelectedIndex)
            {
                // イベントが選択ページに対しての場合 
                brBack = new SolidBrush(selectionBackColor);
                fontColor = selectionForeColor;
            }
            else
            {
                // イベントがその他のページの場合 
                brBack = new SolidBrush(noSelectionBackColor);
                fontColor = noSelectionForeColor;
            }

            // 背景色を塗りつぶし 
            e.Graphics.FillRectangle(brBack, this.GetTabRect(e.Index));

            // 前景用のブラシを作成してテキストを描画 
            Brush brText = new SolidBrush(fontColor);
            StringFormat fmtText = new StringFormat();
            fmtText.Alignment = StringAlignment.Center;
            fmtText.LineAlignment = StringAlignment.Center;

            RectangleF rctTab = new RectangleF(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height);

            e.Graphics.DrawString(this.TabPages[e.Index].Text, this.TabPages[e.Index].Font, brText, rctTab, fmtText);

             //最終タブの背景色 
            if (e.Index == this.TabCount - 1)
            {
                // 最後のタブの場合、タブ領域の隣からタブコントロール全体の右端まで色を塗る 
                brBack = new SolidBrush(outOfRangeBackColor);
                Rectangle r = this.GetTabRect(e.Index);

                e.Graphics.FillRectangle(brBack, r.Right, r.Top, this.Width - r.Right, r.Height);
            }
        }

    }
}

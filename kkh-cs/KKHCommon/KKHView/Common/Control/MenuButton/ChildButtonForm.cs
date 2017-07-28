using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control.MenuButton
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ChildButtonForm : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase//System.Windows.Forms.Form
    {

        /// <summary>
        /// ポップアップウィンドウのボタンを押下した時のイベント 
        /// </summary>
        public event PopupButtonClickEventHandler PopupButtonClick;

        private double _buttonCount = 0;
        /// <summary>
        /// 表示するボタンの個数を取得または設定する。 
        /// </summary>
        public int ButtonCount
        {
            get { return (int)_buttonCount; }
            set { _buttonCount = (double)value; }
        }

        private int _columnCount = 0;
        /// <summary>
        /// 表示するボタンの列数を取得または設定する。 
        /// </summary>
        public int ColumnCount
        {
            get { return (int)_columnCount; }
            set { _columnCount = (int)value; }
        }

        private string[] _buttonText;
        /// <summary>
        /// 
        /// </summary>
        public string[] ButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }

        private string[] _buttonValue;
        /// <summary>
        /// 
        /// </summary>
        public string[] ButtonValue
        {
            get { return _buttonValue; }
            set { _buttonValue = value; }
        }

        private string _retValue;
        /// <summary>
        /// 
        /// </summary>
        public string RetValue
        {
            get { return _retValue; }
            set { _retValue = value; }
        }

        private Image moveImage;
        /// <summary>
        /// 
        /// </summary>
        public Image MoveImage
        {
            get { return moveImage; }
            set { moveImage = value; }
        }

        private Image leaveImage;
        /// <summary>
        /// 
        /// </summary>
        public Image LeaveImage
        {
            get { return leaveImage; }
            set { leaveImage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ChildButtonForm()
        {
            InitializeComponent();
        }

        private bool isGenerated = false;
        /// <summary>
        /// 
        /// </summary>
        public void FormGenerate()
        {
            if (isGenerated == true)
            {
                return;
            }
            double buttonCount = _buttonCount;
            ////int colCount = this.tableLayoutPanel1.ColumnCount;
            ////int rowCount = this.tableLayoutPanel1.RowCount;
            //int colCount = (int)Math.Ceiling(Math.Sqrt(buttonCount));
            //int rowCount = colCount;
            //if (colCount * colCount == buttonCount)
            //{
            //}
            //else if (colCount * (colCount - 1) >= buttonCount)
            //{
            //    rowCount = rowCount - 1;
            //}
            ////colCount = 4;
            ////rowCount = 6;

            int colCount = _columnCount;

            if (buttonCount == 0 || colCount == 0)
            {
                return;
            }

            int rowCount = 0;
            if ((int)buttonCount%colCount == 0)
            {
                rowCount = (int)buttonCount/colCount;
            }
            else
            {
                rowCount = ((int)buttonCount/colCount)+1;
            }

            //*************************************************
            //パネルのサイズを決定する.
            //*************************************************
            this.tableLayoutPanel1.ColumnCount = 0;
            this.tableLayoutPanel1.ColumnCount = colCount;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < colCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, button01.Size.Width));
            }
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.RowCount = rowCount;
            this.tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, button01.Size.Height));
            }

            tableLayoutPanel1.Width = (colCount * (button01.Size.Width)) + ((colCount + 1) * 1);
            tableLayoutPanel1.Height = (rowCount * (button01.Size.Height)) + ((rowCount + 1) * 1);

            //*************************************************
            //ボタンを配置する.
            //*************************************************
            int col = 0;
            int row = 0;
            for (int i = 1; i <= buttonCount; i++)
            {
                this.tableLayoutPanel1.Controls.Add(Controls["button" + i.ToString("00")], col, row);
                this.tableLayoutPanel1.Controls["button" + i.ToString("00")].Visible = true;
                this.tableLayoutPanel1.Controls["button" + i.ToString("00")].Text = _buttonText[i - 1];
                this.tableLayoutPanel1.Controls["button" + i.ToString("00")].Tag = _buttonValue[i - 1];

                if (col >= colCount - 1)
                {
                    col = 0;
                    row = row + 1;
                }
                else
                {
                    col = col + 1;
                }
            }


            //*************************************************
            //パネルのサイズを決定する.
            //*************************************************
            this.Width = this.tableLayoutPanel1.Width;
            this.Height = this.tableLayoutPanel1.Height;

            ////フォームのサイズを変更
            //this.SetBounds(this.Left, this.Top, this.tableLayoutPanel1.Width, this.tableLayoutPanel1.Height);

            int widthLong = this.Width;
            int widthShort = widthLong;
            if ((buttonCount % colCount) > 0)
            {
                widthShort = ((int)(buttonCount % colCount)) * button01.Size.Width + ((int)(buttonCount % colCount)+1) * 1;
            }
            int heightLong = this.Height;
            int heightShort = heightLong;
            if ((buttonCount % colCount) > 0)
            {
                heightShort = heightLong - button01.Size.Height -1;
            }

            //多角形の頂点の位置を設定
            Point[] points =
                {new Point(0, 0), 
                new Point(widthLong, 0),
                new Point(widthLong, heightShort),
                new Point(widthShort, heightShort),
                new Point(widthShort, heightLong),
                new Point(0, heightLong)};
            byte[] types =
                {(byte) System.Drawing.Drawing2D.PathPointType.Line,
                (byte) System.Drawing.Drawing2D.PathPointType.Line,
                (byte) System.Drawing.Drawing2D.PathPointType.Line,
                (byte) System.Drawing.Drawing2D.PathPointType.Line,
                (byte) System.Drawing.Drawing2D.PathPointType.Line,
                (byte) System.Drawing.Drawing2D.PathPointType.Line};
            //GraphicsPathの作成
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(points, types);
            //形を変更
            this.Region = new Region(path);


            isGenerated = true;
        }

        private void updateRegion()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildButtonForm_Load(object sender, EventArgs e)
        {
            FormGenerate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            _retValue = (string)((Button)sender).Tag;

            if (this.Parent != null)
            {
                //親コントロールがあれば破棄(ToolStripの子になっているはずなので) 
                this.Parent.Dispose();
            }
            PopupButtonClickEventArgs _e = new PopupButtonClickEventArgs();//new PopupButtonClickEventArgs();
            _e.Value = _retValue;
            this.Close();
            this.Dispose();
            if (PopupButtonClick != null)
            {
                PopupButtonClick(this, _e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button01_MouseMove(object sender, MouseEventArgs e)
        {
            this.MoveImage = moveImage;
        }

        private void button01_MouseEnter(object sender, EventArgs e)
        {
            this.MoveImage = moveImage;
        }

    }
}
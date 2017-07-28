using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    internal partial class YmCalenderForm : System.Windows.Forms.Form
    {
        #region プロパティ

        private System.Windows.Forms.Control callCtrl;
        /// <summary>
        /// 呼び出し元コントロール 
        /// </summary>
        public System.Windows.Forms.Control CallCtrl
        {
            set { callCtrl = value; }
            get { return callCtrl; }
        }

        private DateTime maxValue = DateTime.MaxValue;
        public DateTime MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        private DateTime minValue = DateTime.MinValue;
        public DateTime MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        #endregion プロパティ

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public YmCalenderForm()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント

        #region フォーム

        /// <summary>
        /// フォームを読み込むときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUpWindow_Load(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            //現在の値が年月として正しければ初期値として使用 
            if (DateTime.TryParseExact(CallCtrl.Text.Replace("/", ""), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date) == false
                || date.CompareTo(maxValue) > 0
                || date.CompareTo(minValue) < 0 )
            {
                //年月として不正な場合はシステム日付 
                date = DateTime.Now;
            }
            //年部分の編集 
            lblYYYY.Text = date.Year.ToString("0000");

            //月部分の編集 
            dgvMM.RowCount = 4;
            dgvMM.Columns[dgvMM.Columns.Count - 1].Frozen = true;
            dgvMM.Rows[dgvMM.Rows.Count - 1].Frozen = true;
            foreach (DataGridViewRow row in dgvMM.Rows)
            {
                row.Height = dgvMM.Height / dgvMM.Rows.Count;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    int mm = ((row.Index) * dgvMM.Columns.Count) + (cell.ColumnIndex + 1);
                    cell.Value = mm;
                    if (mm == date.Month)
                    {
                        //初期値となる月を選択状態にする 
                        cell.Selected = true;
                    }
                }
            }
        }

        #endregion フォーム

        #region 年＋ボタン
        /// <summary>
        /// 翌年表示ボタン 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int yyyy = (int.Parse(lblYYYY.Text) + 1);
            if (yyyy > maxValue.Year)
            {
                yyyy = maxValue.Year;
            }
            lblYYYY.Text = yyyy.ToString("0000");
            //[年月]コントロールにセット 
            MaskedTextBox maskText = (MaskedTextBox)CallCtrl;
            maskText.Text = lblYYYY.Text.PadLeft(4, '0') + dgvMM.CurrentCell.Value.ToString().PadLeft(2, '0');
            //maskText.Text = lblYYYY.Text.PadLeft(4, '0') + maskText.Text.Substring(5,2);
        }
        #endregion 年＋ボタン

        #region 年－ボタン
        /// <summary>
        /// 昨年表示ボタン 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int yyyy = (int.Parse(lblYYYY.Text) - 1);
            if (yyyy < minValue.Year)
            {
                yyyy = minValue.Year;
            }
            lblYYYY.Text = yyyy.ToString("0000");
            //[年月]コントロールにセット 
            MaskedTextBox maskText = (MaskedTextBox)CallCtrl;
            maskText.Text = lblYYYY.Text.PadLeft(4, '0') + dgvMM.CurrentCell.Value.ToString().PadLeft(2, '0');
            //maskText.Text = lblYYYY.Text.PadLeft(4, '0') + maskText.Text.Substring(5,2);
        }
        #endregion 年－ボタン

        #region 月表示グリッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CallCtrl is MaskedTextBox)
            {
                //コントロールがMaskedTextBoxならフォーマットはしない 
                MaskedTextBox maskText = (MaskedTextBox)CallCtrl;
                maskText.Text = lblYYYY.Text.PadLeft(4, '0') + dgvMM[e.ColumnIndex, e.RowIndex].Value.ToString().PadLeft(2, '0');
            }
            else
            {
                //コントロールがMaskedTextBox以外なら"yyyy/MM"形式 
                CallCtrl.Text = lblYYYY.Text.PadLeft(4, '0') + "/" + dgvMM[e.ColumnIndex, e.RowIndex].Value.ToString().PadLeft(2, '0');
            }
            callCtrl.Focus();
            
            if (this.Parent != null)
            {
                //TODO:いる？
                //親コントロールがあれば破棄(ToolStripの子になっているはずなので) 
                //this.Parent.Dispose();
            }

            //TODO:いる？
            //自身をクローズ・破棄 
            //this.Close();
            //this.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //EnterKeyが押下された場合はクリックされた時と同様の処理を行う 
                DataGridViewCellEventArgs ea = new DataGridViewCellEventArgs(dgvMM.CurrentCell.ColumnIndex, dgvMM.CurrentCell.RowIndex);
                dgvMM_CellClick(sender, ea);
            }
        }

        #endregion 月表示グリッド

        #endregion イベント
    }
}
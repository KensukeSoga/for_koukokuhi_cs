namespace Isid.KKH.Common.KKHView.Mast.Common
{
    /// <summary>
    /// 
    /// </summary>
    partial class CrdMstForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。 
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。 
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrdMstForm));
            this.listBox1 = new Isid.NJ.View.Widget.NJListBox();
            this.listBox2 = new Isid.NJ.View.Widget.NJListBox();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(9, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 256);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 18;
            this.listBox2.Location = new System.Drawing.Point(181, 16);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(164, 256);
            this.listBox2.TabIndex = 1;
            // 
            // btnHlp
            // 
            this.btnHlp.BackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHlp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(132, 280);
            this.btnHlp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(92, 22);
            this.btnHlp.TabIndex = 17;
            this.btnHlp.TabStop = false;
            this.btnHlp.Text = "ＯＫ";
            this.btnHlp.UseVisualStyleBackColor = false;
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(245, 280);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(92, 22);
            this.btnEnd.TabIndex = 16;
            this.btnEnd.TabStop = false;
            this.btnEnd.Text = "キャンセル";
            this.btnEnd.UseVisualStyleBackColor = false;
            // 
            // CrdMstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 321);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CrdMstForm";
            this.Text = "カードNo";
            this.Load += new System.EventHandler(this.CrdMstForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJListBox listBox1;
        private Isid.NJ.View.Widget.NJListBox listBox2;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
    }
}
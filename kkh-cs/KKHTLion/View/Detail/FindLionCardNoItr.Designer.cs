namespace Isid.KKH.Lion.View.Detail
{
    partial class FindLionCardNoItr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindLionCardNoItr));
            this.btnCan = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOk = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.listCard = new Isid.NJ.View.Widget.NJListBox();
            this.listBaitai = new Isid.NJ.View.Widget.NJListBox();
            this.label1 = new Isid.NJ.View.Widget.NJLabel();
            this.label2 = new Isid.NJ.View.Widget.NJLabel();
            this.SuspendLayout();
            // 
            // btnCan
            // 
            this.btnCan.BackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCan.FlatAppearance.BorderSize = 0;
            this.btnCan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCan.Image = ((System.Drawing.Image)(resources.GetObject("btnCan.Image")));
            this.btnCan.Location = new System.Drawing.Point(268, 280);
            this.btnCan.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseDownImage")));
            this.btnCan.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseLeaveImage")));
            this.btnCan.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseMoveImage")));
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(113, 22);
            this.btnCan.TabIndex = 1;
            this.btnCan.TabStop = false;
            this.btnCan.Text = "   キャンセル";
            this.btnCan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(149, 280);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseLeaveImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // listCard
            // 
            this.listCard.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listCard.FormattingEnabled = true;
            this.listCard.ItemHeight = 12;
            this.listCard.Items.AddRange(new object[] {
            "001　テレビタイム（ネット）",
            "002　テレビタイム（ローカル）",
            "003　ラジオタイム（ネット）",
            "004　ラジオタイム（ローカル）",
            "005　スポット",
            "007　新聞",
            "008　雑誌",
            "009　交通",
            "010　その他",
            "012　制作",
            "014　チラシ",
            "015　サンプリング",
            "016　BS・CS",
            "017　インターネット",
            "018　モバイル",
            "019　事業費"});
            this.listCard.Location = new System.Drawing.Point(14, 30);
            this.listCard.Name = "listCard";
            this.listCard.Size = new System.Drawing.Size(175, 244);
            this.listCard.TabIndex = 3;
            this.listCard.SelectedIndexChanged += new System.EventHandler(this.listCard_SelectedIndexChanged);
            this.listCard.DoubleClick += new System.EventHandler(this.listCard_DoubleClick);
            // 
            // listBaitai
            // 
            this.listBaitai.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBaitai.FormattingEnabled = true;
            this.listBaitai.ItemHeight = 12;
            this.listBaitai.Location = new System.Drawing.Point(206, 30);
            this.listBaitai.Name = "listBaitai";
            this.listBaitai.Size = new System.Drawing.Size(175, 244);
            this.listBaitai.TabIndex = 4;
            this.listBaitai.DoubleClick += new System.EventHandler(this.listBaitai_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "カードNO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "媒体区分";
            // 
            // FindLionCardNoItr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 312);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBaitai);
            this.Controls.Add(this.listCard);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCan);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FindLionCardNoItr";
            this.Text = "カードNO一覧";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.FindLionCardNoItr_ProcessAffterNavigating);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCan;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOk;
        private Isid.NJ.View.Widget.NJListBox listCard;
        private Isid.NJ.View.Widget.NJListBox listBaitai;
        private Isid.NJ.View.Widget.NJLabel label1;
        private Isid.NJ.View.Widget.NJLabel label2;

    }
}
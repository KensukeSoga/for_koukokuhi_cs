namespace Isid.KKH.Common.KKHView.Common.Form
{
    partial class KKHForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KKHForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslval1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMsg,
            this.tslCnt,
            this.toolStripStatusLabel,
            this.tslval1,
            this.tslName,
            this.tslDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(986, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslMsg
            // 
            this.tslMsg.Name = "tslMsg";
            this.tslMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // tslCnt
            // 
            this.tslCnt.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tslCnt.Name = "tslCnt";
            this.tslCnt.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(811, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.Text = "　　　　　";
            // 
            // tslval1
            // 
            this.tslval1.Name = "tslval1";
            this.tslval1.Size = new System.Drawing.Size(0, 17);
            // 
            // tslName
            // 
            this.tslName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tslName.Name = "tslName";
            this.tslName.Size = new System.Drawing.Size(89, 17);
            this.tslName.Text = "システム管理者";
            // 
            // tslDate
            // 
            this.tslDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tslDate.Name = "tslDate";
            this.tslDate.Size = new System.Drawing.Size(65, 17);
            this.tslDate.Text = "2011/01/01";
            // 
            // KKHForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(986, 677);
            this.Controls.Add(this.statusStrip1);
            this.EnterKeyFocusEnabled = false;
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(8, 34);
            this.Name = "KKHForm";
            this.Text = "KHHForm";
            this.Shown += new System.EventHandler(this.KKHForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripStatusLabel tslName;
        protected System.Windows.Forms.ToolStripStatusLabel tslDate;
        public System.Windows.Forms.ToolStripStatusLabel tslCnt;
        private System.Windows.Forms.ToolStripStatusLabel tslval1;
        private System.Windows.Forms.ToolStripStatusLabel tslMsg;
    }
}
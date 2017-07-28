namespace Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog
{
    partial class LoadingDialog2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingDialog2));
            this.njPictureBox1 = new Isid.NJ.View.Widget.NJPictureBox();
            this.njProgressBar1 = new Isid.NJ.View.Widget.NJProgressBar();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.panel1 = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            ((System.ComponentModel.ISupportInitialize)(this.njPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // njPictureBox1
            // 
            this.njPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.njPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("njPictureBox1.Image")));
            this.njPictureBox1.Location = new System.Drawing.Point(265, 104);
            this.njPictureBox1.Name = "njPictureBox1";
            this.njPictureBox1.Size = new System.Drawing.Size(52, 52);
            this.njPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.njPictureBox1.TabIndex = 0;
            this.njPictureBox1.TabStop = false;
            // 
            // njProgressBar1
            // 
            this.njProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njProgressBar1.Location = new System.Drawing.Point(180, 122);
            this.njProgressBar1.Name = "njProgressBar1";
            this.njProgressBar1.Size = new System.Drawing.Size(222, 23);
            this.njProgressBar1.TabIndex = 1;
            // 
            // njLabel1
            // 
            this.njLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njLabel1.BackColor = System.Drawing.Color.Transparent;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.Location = new System.Drawing.Point(-3, 172);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(589, 25);
            this.njLabel1.TabIndex = 2;
            this.njLabel1.Text = "実行中．．．";
            this.njLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.njLabel1);
            this.panel1.Controls.Add(this.njPictureBox1);
            this.panel1.Controls.Add(this.njProgressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 263);
            this.panel1.TabIndex = 3;
            // 
            // LoadingDialog2
            // 
            this.ClientSize = new System.Drawing.Size(589, 263);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingDialog2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "実行中";
            this.Load += new System.EventHandler(this.LoadingDialog_Load);
            this.Activated += new System.EventHandler(this.LoadingDialog_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.njPictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJPictureBox njPictureBox1;
        private Isid.NJ.View.Widget.NJProgressBar njProgressBar1;
        private Isid.NJ.View.Widget.NJLabel njLabel1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel panel1;
    }
}

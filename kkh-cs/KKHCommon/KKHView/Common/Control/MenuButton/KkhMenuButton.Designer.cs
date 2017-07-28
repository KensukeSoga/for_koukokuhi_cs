namespace Isid.KKH.Common.KKHView.Common.Control.MenuButton
{
    partial class KkhMenuButton
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を  
        /// コード エディタで変更しないでください。 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupDisposeTimer = new System.Windows.Forms.Timer(this.components);
            this.button = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.SuspendLayout();
            // 
            // popupDisposeTimer
            // 
            this.popupDisposeTimer.Interval = 1000;
            this.popupDisposeTimer.Tick += new System.EventHandler(this.popupDisposeTimer_Tick);
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Margin = new System.Windows.Forms.Padding(0);
            this.button.MouseDownImage = null;
            this.button.MouseLeaveImage = null;
            this.button.MouseMoveImage = null;
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(145, 47);
            this.button.TabIndex = 0;
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button1_Click);
            this.button.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            // 
            // KkhMenuButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.button);
            this.Name = "KkhMenuButton";
            this.Size = new System.Drawing.Size(145, 47);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer popupDisposeTimer;
        public KkhButton button;


    }
}

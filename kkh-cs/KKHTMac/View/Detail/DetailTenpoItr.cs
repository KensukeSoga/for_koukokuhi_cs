using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Mac.View.Detail
{
    public partial class DetailTenpoItr : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region "定数"

        /// <summary>
        /// 店舗ＣＤインデックス 
        /// </summary>
        private const int COLIDX_1 = 11;
        /// <summary>
        /// 店舗名インデックス 
        /// </summary>
        private const int COLIDX_2 = 12;
        /// <summary>
        /// 店舗区分 
        /// </summary>
        private const int COLIDX_3 = 14;
        /// <summary>
        /// 勘定ＣＤインデックス 
        /// </summary>
        private const int COLIDX_4 = 15;

        #endregion "定数"

        #region "メンバ変数"
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdMasten;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCan;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOk;
        private FarPoint.Win.Spread.SheetView spdMasten_Sheet1;
        private DetailTenpoItrNaviParameter _naviParam = new DetailTenpoItrNaviParameter();
        #endregion "メンバ変数"

        #region "コンストラクタ"

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailTenpoItr()

        {
            InitializeComponent();
        }

        #endregion "コンストラクタ"

        #region "イベント"

        /// <summary>
        /// 画面遷移時に発生 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailTenpoItr_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //フラグ 
            string StrAllorFlg;

            spdMasten.Sheets[0].RowHeaderVisible = false;

            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailTenpoItrNaviParameter)
            {
                _naviParam = (DetailTenpoItrNaviParameter)arg.NaviParameter;
                StrAllorFlg = _naviParam.AllorFlg;

                //１：全て　２：一部 
                if (StrAllorFlg == "2")
                {
                    spdMasten.DataSource = _naviParam.ItrTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 Like '9%'");
                }
                else
                {
                    spdMasten.DataSource = _naviParam.ItrTenpoMastrslt.MasterDataSet.MasterDataVO.Select("");
                }


                //スプレッド初期化 
                for (int j = 0; j < spdMasten.Sheets[0].ColumnCount; j++)
                {

                    spdMasten.Sheets[0].Columns[j].Visible = false;
                    spdMasten.Sheets[0].Columns[j].Label = null;
                    spdMasten.Sheets[0].Columns[j].Locked = true;
                }


                for (int i = 0; i < spdMasten.Sheets[0].ColumnCount; i++)
                {
                    if (i == COLIDX_1)
                    {
                        //列名 
                        spdMasten.Sheets[0].Columns[i].Label = "店舗コード";
                        //表示 
                        spdMasten.Sheets[0].Columns[i].Visible = true;
                    }
                    else if (i == COLIDX_2)
                    {
                        //列名 
                        spdMasten.Sheets[0].Columns[i].Label = "店舗名";
                        //表示 
                        spdMasten.Sheets[0].Columns[i].Visible = true;
                    }
                    else if (i == COLIDX_3)
                    {
                        //列名 
                        spdMasten.Sheets[0].Columns[i].Label = "店舗区分";
                        //表示 
                        spdMasten.Sheets[0].Columns[i].Visible = true;
                    }
                    else if (i == COLIDX_4)
                    {
                        //列名 
                        spdMasten.Sheets[0].Columns[i].Label = "勘定科目";
                        //表示 
                        spdMasten.Sheets[0].Columns[i].Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// キャンセルボタン押下時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            _naviParam.TenpoCd = "";
            _naviParam.TenpoNm = "";
            _naviParam.TenpoKbn = "";
            _naviParam.KanjyoKmk = "";
            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

        /// <summary>
        /// ＯＫボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SetTenpoDataAndClose();
        }

        /// <summary>
        /// スプレッドをマウスで選んだ時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasten_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeColors();
        }

        /// <summary>
        /// スプレッドをキーで選択した時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasten_KeyUp(object sender, KeyEventArgs e)
        {
            ChangeColors();
        }

        /// <summary>
        /// セルダブルクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasten_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.SetTenpoDataAndClose();
        }

        #endregion "イベント"

        #region "メソッド"
        /// <summary>
        /// 画面編集 
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailTenpoItr));
            this.spdMasten = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spdMasten_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnCan = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOk = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasten_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdMasten
            // 
            this.spdMasten.AccessibleDescription = "";
            this.spdMasten.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMasten.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMasten.Location = new System.Drawing.Point(0, -1);
            this.spdMasten.Name = "spdMasten";
            this.spdMasten.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdMasten.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMasten_Sheet1});
            this.spdMasten.Size = new System.Drawing.Size(550, 439);
            this.spdMasten.TabIndex = 0;
            this.spdMasten.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMasten.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdMasten_CellDoubleClick);
            this.spdMasten.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdMasten_MouseUp);
            this.spdMasten.KeyUp += new System.Windows.Forms.KeyEventHandler(this.spdMasten_KeyUp);
            // 
            // spdMasten_Sheet1
            // 
            this.spdMasten_Sheet1.Reset();
            this.spdMasten_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMasten_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdMasten_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spdMasten_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasten_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMasten_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMasten_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasten_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMasten_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasten_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMasten_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasten_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnCan
            // 
            this.btnCan.BackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCan.FlatAppearance.BorderSize = 0;
            this.btnCan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCan.Image = ((System.Drawing.Image)(resources.GetObject("btnCan.Image")));
            this.btnCan.Location = new System.Drawing.Point(426, 444);
            this.btnCan.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseDownImage")));
            this.btnCan.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseLeaveImage")));
            this.btnCan.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseMoveImage")));
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(113, 22);
            this.btnCan.TabIndex = 1;
            this.btnCan.Text = "   キャンセル";
            this.btnCan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(307, 444);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseLeaveImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DetailTenpoItr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(551, 478);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.spdMasten);
            this.Name = "DetailTenpoItr";
            this.Text = "コード一覧";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailTenpoItr_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.spdMasten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasten_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// セルの色付け処理を行う 
        /// </summary>
        private void ChangeColors()
        {
            //親クラスの行っている共通処理を実行 
            for (int i = 0; i < spdMasten.Sheets[0].Rows.Count; i++)
            {

                if (spdMasten.Sheets[0].ActiveRowIndex == i)
                {
                    spdMasten.Sheets[0].Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                else
                {
                    spdMasten.Sheets[0].Rows[i].BackColor = Color.FromArgb(255, 255, 255);
                }

            }
        }

        /// <summary>
        /// 店舗情報を受け渡し用パラメータへセットし、画面を閉じる。 
        /// </summary>
        private void SetTenpoDataAndClose()
        {
            // 一覧で選択されている店舗情報を受け渡し用パラメータへセット 
            _naviParam.TenpoCd = spdMasten.Sheets[0].Cells[spdMasten.Sheets[0].ActiveRowIndex, COLIDX_1].Value.ToString();
            _naviParam.TenpoNm = spdMasten.Sheets[0].Cells[spdMasten.Sheets[0].ActiveRowIndex, COLIDX_2].Value.ToString();
            _naviParam.TenpoKbn = spdMasten.Sheets[0].Cells[spdMasten.Sheets[0].ActiveRowIndex, COLIDX_3].Value.ToString();
            _naviParam.KanjyoKmk = spdMasten.Sheets[0].Cells[spdMasten.Sheets[0].ActiveRowIndex, COLIDX_4].Value.ToString();
            Navigator.Backward(this, _naviParam, null, true);

            // 画面を閉じる 
            this.Close();
        }

        #endregion "メソッド"
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Tkd.View.Detail
{
    public partial class JyutyuRegisterTkd : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
        #region 定数 

        /// <summary>
        /// 消費税率マスタ取得キー：0003 
        /// </summary>
        private const string MST_TAX = "0003";

        /// <summary>
        /// 消費税率 
        /// </summary>
        private const string DEF_TAX = "5.00";

        #endregion 定数

        #region メンバ変数

        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion メンバ変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public JyutyuRegisterTkd()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region オーバーライド 

        /// <summary>
        /// 新規登録前のチェック処理 
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        protected override bool CheckBeforeRegisterJyutyu()
        {
            // 共通チェック 
            if (!base.CheckBeforeRegisterJyutyu())
            {
                return false;
            }

            // 得意先別チェック 
            if (!this.CheckBeforeRegisterJyutyuTkd())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新規登録APIの実行パラメータの編集を行う 
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            // 共通機能で登録データの初期設定を行う 
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //****************************************
            // 得意先別の設定項目を編集 
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                // 業務区分 
                row.hb1GyomKbn = (string)this.cmbGymKbn.SelectedValue;

                // 件名 
                row.hb1KKNameKJ = this.txtKenmei.Text;

                // 請求金額 
                row.hb1SeiGak = KKHUtility.DecParse(this.txtKngk.Text);

                // 消費税率 
                row.hb1SzeiRitu = KKHUtility.DecParse(this.txtTax.Text);
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }

        #endregion オーバーライド 

        #region イベント 

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JyutyuRegisterTkd_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// 請求金額Enterイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKngk_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()))
            {
                this.txtKngk.Text = "0";
            }
            this.txtKngk.SelectionStart = 0;
            this.txtKngk.SelectionLength = this.txtKngk.Text.Length;
        }

        /// <summary>
        /// 消費税率Enterイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Enter(object sender, EventArgs e)
        {
            this.txtTax.SelectionStart = 0;
            this.txtTax.SelectionLength = this.txtTax.Text.Length;
        }

        /// <summary>
        /// 請求金額Leaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKngk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()))
            {
                this.txtKngk.Text = "0";
            }
        }

        /// <summary>
        /// 消費税率Leaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTax.Text.Trim()))
            {
                this.txtTax.Text = "0.00";
            }
        }

        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            _naviParameter = base.NaviParameterIn;

            this.cmbGymKbn.Text = string.Empty;
            this.txtKenmei.Text = string.Empty;
            this.txtKngk.Text = "0";
            this.txtTax.Text = this.GetTax();
        }

        /// <summary>
        /// 消費税率を取得する 
        /// </summary>
        /// <returns>消費税率</returns>
        private string GetTax()
        {
            string ret = DEF_TAX;

            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            // 商品名取得 
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TAX,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                // 期間Fromと期間Toを取得 
                //DateTime now = DateTime.Now;
                //DateTime from = KKHUtility.StringCnvDateTime(row.Column1);
                //DateTime to = KKHUtility.StringCnvDateTime(row.Column2);

                //// 期間内の消費税率を使用する 
                //if (now.CompareTo(from) > 0 && now.CompareTo(to) < 0)
                //{
                //    ret = row.Column3;
                //    break;
                //}

                // 期間Fromと期間Toを取得 
                String yymm = _naviParameter.StrYymm + "01";
                String from = row.Column1;
                String to = row.Column2;

                // 期間内の消費税率を使用する 
                if (yymm.CompareTo(from) >= 0 && yymm.CompareTo(to) <= 0)
                {
                    ret = row.Column3;
                    break;
                }
            }

            return KKHUtility.DecParse(ret).ToString("0.00");
        }

        /// <summary>
        /// 新規登録前のチェック処理 
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        private bool CheckBeforeRegisterJyutyuTkd()
        {
            // 請求金額（必須チェック） 
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()) ||
                this.txtKngk.Text == "0")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0053, null, "新規登録", MessageBoxButtons.OK);
                this.txtKngk.Focus();
                return false;
            }

            // 請求金額（数値チェック） 
            if (!KKHUtility.IsNumeric(this.txtKngk.Text.Trim(',')))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0052, null, "新規登録", MessageBoxButtons.OK);
                this.txtKngk.Focus();
                return false;
            }

            // 消費税率（数値チェック） 
            if (!KKHUtility.IsNumeric(this.txtTax.Text.Trim()))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            // 消費税率（整合性チェック） 
            double tax = double.Parse(this.txtTax.Text.Trim());
            if (tax < 0 || tax > 999.99)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            return true;
        }

        #endregion メソッド 
    }
}

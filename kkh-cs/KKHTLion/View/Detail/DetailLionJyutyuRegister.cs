using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.SystemCommon;

namespace Isid.KKH.Lion.View.Detail
{
    /// <summary>
    /// ライオン明細新規登録ダイアログ.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/03/05</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class DetailLionJyutyuRegister : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
        #region 定数.

        /// <summary>
        /// 消費税率取得用キー.
        /// </summary>
        //private static readonly String TAX_RATE_FIND_KEY = "ED-I0001";
        /// <summary>
        /// デフォルト設定秒数.
        /// </summary>
        private static readonly long DEFAULT_SETTING_SECOND = 15;

        #endregion 定数.

        #region メンバ変数.

        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailLionJyutyuRegister()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region オーバーライド.

        /// <summary>
        /// 新規登録前のチェック処理.
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        protected override bool CheckBeforeRegisterJyutyu()
        {
            // 共通チェック.
            if (!base.CheckBeforeRegisterJyutyu())
            {
                return false;
            }

            // 得意先別チェック.
            if (!this.CheckBeforeRegisterJyutyuLion())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新規登録APIの実行パラメータの編集を行う.
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            // 共通機能で登録データの初期設定を行う.
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //****************************************
            // 得意先別の設定項目を編集.
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                // 業務区分.
                row.hb1GyomKbn = (string)this.cmbGymKbn.SelectedValue;

                // 件名.
                row.hb1KKNameKJ = this.txtKenmei.Text;

                // TVSpotの場合のみ拡張項目を設定する.
                //if (TaxAndSecondExtensionIsEnabled())
                //{
                //    // 消費税率.
                //    row.hb1SzeiRitu = KKHUtility.DecParse(this.txtTax.Text);

                //    // 秒数.
                //    row.hb1Field5 = KKHUtility.DecParse(this.txtSecond.Text).ToString();
                //}

                // 消費税率.
                row.hb1SzeiRitu = (Decimal)KKHUtility.DecParse(this.txtTax.Text);

                // TVSpotの場合のみ秒数を設定する.
                if (SecondExtensionIsEnabled())
                {
                    // 秒数.
                    row.hb1Field5 = KKHUtility.DecParse(this.txtSecond.Text).ToString();
                }
            }

            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }

        #endregion オーバーライド.

        #region イベント.

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailLionJyutyuRegister_Load(object sender, EventArgs e)
        {
            this.InitializeControl();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 業務区分変更イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGymKbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// 消費税率Enterイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Enter(object sender, EventArgs e)
        {
            this.txtTax.SelectionStart = 0;
            this.txtTax.SelectionLength = this.txtTax.Text.Length;
        }

        /// <summary>
        /// 秒数Enterイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSecond_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSecond.Text.Trim()))
            {
                this.txtSecond.Text = "0";
            }
            this.txtSecond.SelectionStart = 0;
            this.txtSecond.SelectionLength = this.txtSecond.Text.Length;
        }

        /// <summary>
        /// 消費税率Leaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTax.Text.Trim()))
            {
                // 2014/02/05 mod JSE K.Tamura start
                // 基本的に整数のみなので、デフォルト値を変更する
                //this.txtTax.Text = "0.00";
                this.txtTax.Text = "0";
                // 2014/02/05 mod JSE K.Tamura end
            }
        }

        /// <summary>
        /// 秒数Leaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSecond_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSecond.Text.Trim()))
            {
                this.txtSecond.Text = "0";
            }
        }

        #endregion イベント.

        #region メソッド.

        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControl()
        {
            _naviParameter = base.NaviParameterIn;

            this.cmbGymKbn.Text = string.Empty;
            this.txtKenmei.Text = string.Empty;
            this.txtTax.Text = this.GetTax();
            this.txtSecond.Text = DEFAULT_SETTING_SECOND.ToString();
        }

        /// <summary>
        /// 消費税率を取得する.
        /// </summary>
        /// <returns>消費税率</returns>
        private string GetTax()
        {
            //String retval = null;

            ////消費税取得（マスタから）.
            //CommonProcessController controller = CommonProcessController.GetInstance();
            //FindCommonByCondServiceResult result = null;

            //result = controller.FindCommonByCond(
            //                                _naviParameter.strEsqId,
            //                                _naviParameter.strEgcd,
            //                                _naviParameter.strTksKgyCd,
            //                                _naviParameter.strTksBmnSeqNo,
            //                                _naviParameter.strTksTntSeqNo,
            //                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
            //                                TAX_RATE_FIND_KEY
            //                                );

            //if (result.CommonDataSet.SystemCommon.Count != 0)
            //{
            //    //消費税セット.
            //    retval = (Decimal.Parse(result.CommonDataSet.SystemCommon[0].field1.ToString()) * 100).ToString();
            //}

            //return retval;

            String retval = null;

            //消費税取得（マスタから）.
            MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            // 商品名取得.
            result = controller.FindMasterByCond(
                                            _naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            Isid.KKH.Lion.Utility.KKHLionConst.C_MAST_TAX_CD,
                                            null
                                            );
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                // 期間Fromと期間Toを取得.
                String yyMm = _naviParameter.StrYymm + "01";
                String from = row.Column2;
                String to = row.Column3;

                // 期間内の消費税率を使用する.
                if (yyMm.CompareTo(from) >= 0 && yyMm.CompareTo(to) <= 0)
                {
                    retval = row.Column1;
                    break;
                }
            }

            return retval;
        }

        /// <summary>
        /// 新規登録前のチェック処理.
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        private bool CheckBeforeRegisterJyutyuLion()
        {
            //テレビスポットのみ消費税･秒数を格納.
            //if (TaxAndSecondExtensionIsEnabled())
            //{
            //    // 消費税率（数値チェック）.
            //    if (!KKHUtility.IsNumeric(this.txtTax.Text.Trim()))
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
            //        this.txtTax.Focus();
            //        return false;
            //    }

            //    // 消費税率（整合性チェック）.
            //    double tax = double.Parse(this.txtTax.Text.Trim());
            //    if (( tax < 0 ) || ( tax > 999.99 ))
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
            //        this.txtTax.Focus();
            //        return false;
            //    }

            //    // 秒数（数値チェック）.
            //    if (!KKHUtility.IsNumeric(this.txtSecond.Text.Trim(',')))
            //    {
            //        MessageUtility.ShowMessageBox(MessageCode.HB_W0082, null, "新規登録", MessageBoxButtons.OK);
            //        this.txtSecond.Focus();
            //        return false;
            //    }
            //}

            //return true;

            // 消費税率（数値チェック）.
            if (!KKHUtility.IsNumeric(this.txtTax.Text.Trim()))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            // 消費税率（整合性チェック）.
            double tax = double.Parse(this.txtTax.Text.Trim());
            if ((tax < 0) || (tax > 999.99))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "新規登録", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            //テレビスポットのみ秒数を格納.
            if (SecondExtensionIsEnabled())
            {
                // 秒数（数値チェック）.
                if (!KKHUtility.IsNumeric(this.txtSecond.Text.Trim(',')))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0082, null, "新規登録", MessageBoxButtons.OK);
                    this.txtSecond.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// コントロールの表示／非表示変更.
        /// </summary>
        private void ChangeVisible()
        {
            // タイム・スポット区分の表示切替.
            if (TimeSpotExtensionIsEnabled())
            {
                pnlTmSp.Visible = true;
            }
            else
            {
                pnlTmSp.Visible = false;
            }

            //消費税･秒数の表示切り替え.
            if (String.Equals(KKHUtility.ToString(cmbGymKbn.SelectedValue), KKHSystemConst.GyomKbn.TVSpot))
            {
                //panelExt.Visible = true;
                lblSecond.Visible = true;
                txtSecond.Visible = true;
            }
            else
            {
                //panelExt.Visible = false;
                lblSecond.Visible = false;
                txtSecond.Visible = false;
            }
        }

        /// <summary>
        /// タイム・スポット区分の拡張が有効であるかを返す.
        /// </summary>
        /// <returns></returns>
        private bool TimeSpotExtensionIsEnabled()
        {
            return
            (
                (
                    String.Equals(KKHUtility.ToString(cmbGymKbn.SelectedValue), KKHSystemConst.GyomKbn.Radio) ||
                    String.Equals(KKHUtility.ToString(cmbGymKbn.SelectedValue), KKHSystemConst.GyomKbn.EiseiM)
                ) &&
                (
                    rdoJpn.Checked == true
                )
            );
        }

        /// <summary>
        /// 消費税率・秒数の拡張が有効であるかを返す.
        /// </summary>
        /// <returns></returns>
        //private bool TaxAndSecondExtensionIsEnabled()
        //{
        //    return String.Equals(KKHUtility.ToString(cmbGymKbn.SelectedValue), KKHSystemConst.GyomKbn.TVSpot);
        //}

        /// <summary>
        /// 秒数の拡張が有効であるかを返す.
        /// </summary>
        /// <returns></returns>
        private bool SecondExtensionIsEnabled()
        {
            return String.Equals(KKHUtility.ToString(cmbGymKbn.SelectedValue), KKHSystemConst.GyomKbn.TVSpot);
        }

        #endregion メソッド.
    }
}

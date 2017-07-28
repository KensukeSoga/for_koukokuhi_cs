using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Uni.View.Detail
{
    public partial class JyutyuRegisterUni : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
        #region 定数.

        /// <summary>
        /// 消費税率取得用キー.
        /// </summary>
        private const String SYSTEM_KEY_TAX_RATE = "ED-I0001";

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// 消費税率.
        /// </summary>
        private Decimal _taxRate;

        #endregion メンバ変数.

        # region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public JyutyuRegisterUni()
        {
            InitializeComponent();
        }

        # endregion コンストラクタ.

        # region オーバーライド.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void JyutyuRegisterUni_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            initializeTaxRate();
        }

        // 2014/02/05 add JSE K.Tamura start
        // 消費税額に対するチェックを追加するため、チェックメソッドのオーバーライドを実装.

        // <summary>
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

            // 消費税額が請求金額を超えた場合.
            if (KKHUtility.DecParse(txtShohizeiGaku.Text.ToString()) > KKHUtility.DecParse(txtSeiKinGaku.Text.ToString()))
            {
                // 消費税額が請求金額を超えています.
                //MessageBox.Show("消費税額が請求金額を超えています");

                MessageUtility.ShowMessageBox(MessageCode.HB_W0162, null, "新規登録", MessageBoxButtons.OK);
                txtShohizeiGaku.Focus();

                return false;
            }

            return true;
        }

        // 2014/02/05 add JSE K.Tamura end

        /// <summary>
        /// 新規登録APIの実行パラメータの編集を行う.
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            //共通機能で登録データの初期設定を行う.
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            Decimal taxRate = 0M;

            //****************************************
            //得意先別の設定項目を編集.
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                //更新プログラム.
                row.hb1UpdApl = "DtlUni";
                //受注明細No.
                if (!string.IsNullOrEmpty(txtJuChuNo.Text))
                {
                    row.hb1JyutNo = txtJuChuNo.Text;
                }
                //受注明細No.
                if (!string.IsNullOrEmpty(txtJuChuMei.Text))
                {
                    row.hb1JyMeiNo = txtJuChuMei.Text;
                }
                //売上明細No.
                if (!string.IsNullOrEmpty(txtUriMei.Text))
                {
                    row.hb1UrMeiNo = txtUriMei.Text;
                }
                //請求金額.
                if (!string.IsNullOrEmpty(txtSeiKinGaku.Text))
                {
                    row.hb1ToriGak = KKHUtility.DecParse(txtSeiKinGaku.Text.ToString());

                    row.hb1SeiGak = KKHUtility.DecParse(txtSeiKinGaku.Text.ToString());
                }

                // 消費税対応 2013/10/10 update HLC H.Watabe start
                //消費税率.
                //row.hb1SzeiRitu = _taxRate * 100.0M;

                //請求金額、消費税額のどちらかが0の時は、消費税率は0.
                if (KKHUtility.DecParse(txtShohizeiGaku.Text.ToString()) == 0 || KKHUtility.DecParse(txtSeiKinGaku.Text.ToString()) == 0)
                {
                    row.hb1SzeiRitu = 0M;
                }
                else
                {
                    taxRate = KKHUtility.DecParse(txtShohizeiGaku.Text.ToString()) / KKHUtility.DecParse(txtSeiKinGaku.Text.ToString());
                    row.hb1SzeiRitu = taxRate * 100.0M;
                }

                //消費税額.
                //if (!string.IsNullOrEmpty(txtSeiKinGaku.Text))
                //{
                //    row.hb1SzeiGak = Decimal.Truncate(KKHUtility.DecParse(txtSeiKinGaku.Text.ToString()) * _taxRate);
                //}
                if (!string.IsNullOrEmpty(txtShohizeiGaku.Text))
                {
                    row.hb1SzeiGak = KKHUtility.DecParse(txtShohizeiGaku.Text.ToString());
                }
                // 消費税対応 2013/10/10 update HLC H.Watabe end
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }

        # endregion オーバーライド.

        # region イベント.
        /// <summary>
        /// 受注Noキープレスイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JuChuNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //入力禁止文字の判定.
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        # endregion イベント.

        # region メソッド.

        /// <summary>
        /// 消費税率を初期化する.
        /// </summary>
        private void initializeTaxRate()
        {
            //消費税取得（マスタから）.
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = null;

            result = controller.FindCommonByCond(
                                            NaviParameterIn.strEsqId,
                                            NaviParameterIn.strEgcd,
                                            NaviParameterIn.strTksKgyCd,
                                            NaviParameterIn.strTksBmnSeqNo,
                                            NaviParameterIn.strTksTntSeqNo,
                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                            SYSTEM_KEY_TAX_RATE
                                            );

            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                //消費税セット.
                _taxRate = Decimal.Parse(result.CommonDataSet.SystemCommon[0].field4.ToString());
            }
        }

        # endregion メソッド.
    }
}
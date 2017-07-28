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

namespace Isid.KKH.Kmn.View.Detail
{
    public partial class JyutyuRegisterKmn : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
        #region 定数

        /// <summary>
        /// 消費税率取得用キー
        /// </summary>
        private const String SYSTEM_KEY_TAX_RATE = "ED-I0001";

        #endregion 定数

        #region メンバ変数

        /// <summary>
        /// 消費税率
        /// </summary>
        private Decimal _taxRate;

        #endregion メンバ変数

        # region コンストラクタ 
        public JyutyuRegisterKmn()
        {
            InitializeComponent();
        }
        # endregion コンストラクタ 

        # region オーバーライド 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void JyutyuRegisterKmn_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            initializeTaxRate();
        }

        /// <summary>
        /// 新規登録APIの実行パラメータの編集を行う 
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            //共通機能で登録データの初期設定を行う 
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //**************************************** 
            //得意先別の設定項目を編集 
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                //更新プログラム 
                row.hb1UpdApl = "DtlKmn";
                //受注明細No 
                if (!string.IsNullOrEmpty(txtJuChuNo.Text))
                {
                    row.hb1JyutNo = txtJuChuNo.Text;
                }
                //受注明細No 
                if (!string.IsNullOrEmpty(txtJuChuMei.Text))
                {
                    row.hb1JyMeiNo = txtJuChuMei.Text;
                }
                //売上明細No 
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

                //消費税率 
                row.hb1SzeiRitu = _taxRate * 100.0M;

                //消費税額
                if (!string.IsNullOrEmpty(txtSeiKinGaku.Text))
                {
                    row.hb1SzeiGak = Decimal.Truncate(KKHUtility.DecParse(txtSeiKinGaku.Text.ToString()) * _taxRate);
                }
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }
        # endregion オーバーライド 

        # region イベント 
        /// <summary>
        /// 受注Noキープレスイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JuChuNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //入力禁止文字の判定 
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        # endregion イベント

        # region メソッド

        /// <summary>
        /// 消費税率を初期化する
        /// </summary>
        private void initializeTaxRate()
        {
            //消費税取得（マスタから） 
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
                //消費税セット
                _taxRate = Decimal.Parse(result.CommonDataSet.SystemCommon[0].field4.ToString());
            }
        }

        # endregion メソッド

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Tkd.ProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Tkd.Utility;

namespace Isid.KKH.Tkd.View.Detail
{
    /// <summary>
    /// 実施No自動UP/DOWN 
    /// </summary>
    public partial class DatailAutoUpDown : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "NoUDTkd";

        #endregion 定数

        #region メンバ変数

        //ナビパラメーター

        /// <summary>
        /// ナビパラメーター
        /// </summary>
        DatailAutoUpDownNaviParameter _naviParameter = new DatailAutoUpDownNaviParameter();

        /// <summary>
        /// No変動値 
        /// </summary>
        private string atnum;

        #endregion

        #region コンストラクタ
        public DatailAutoUpDown()
        {
            InitializeComponent();
            
        }
        #endregion

        # region イベント
        /// <summary>
        ///+1ボタン押下時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhButton1_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_C0007,
                new string[] { rgNumericTextBox1.Text, "+1" },
                "明細登録",
                MessageBoxButtons.OKCancel);

            //OKボタン押下時
            if (check == DialogResult.OK)
            {
                atnum = "+," + rgNumericTextBox1.Text;

                DetailTkdProcessController detailprocesscontroller = DetailTkdProcessController.GetInstance();
                UpdateJissiNoFuyoServiceResult result = detailprocesscontroller.UpdateJissiNo(
                                                                       _naviParameter.strEsqId,
                                                                       "00",
                                                                        _naviParameter.strEgcd,
                                                                        _naviParameter.strTksKgyCd,
                                                                        _naviParameter.strTksBmnSeqNo,
                                                                        _naviParameter.strTksTntSeqNo,
                                                                        _naviParameter.StrYymm,
                                                                        null,
                                                                        null,
                                                                        null,
                                                                        null,
                                                                        null,
                                                                        atnum,
                                                                        null,
                                                                        null);

                // オペレーションログの出力 
                KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_AUTOUPDOWN, KKHLogUtilityTkd.DESC_OPERATION_LOG_AUTOUPDOWN);

                Navigator.Backward(this, true, null, true);
                this.Close();
            }
        }

        /// <summary>
        /// -1ボタン押下時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhButton2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_C0007,
                new string[] { rgNumericTextBox1.Text, "-1" },
                "明細登録",
                MessageBoxButtons.OKCancel);

            //OKボタン押下時
            if (check == DialogResult.OK)
            {
                atnum = "-," + rgNumericTextBox1.Text;

                DetailTkdProcessController detailprocesscontroller = DetailTkdProcessController.GetInstance();
                UpdateJissiNoFuyoServiceResult result = detailprocesscontroller.UpdateJissiNo(
                                                                         _naviParameter.strEsqId,
                                                                         "00",
                                                                          _naviParameter.strEgcd,
                                                                          _naviParameter.strTksKgyCd,
                                                                          _naviParameter.strTksBmnSeqNo,
                                                                          _naviParameter.strTksTntSeqNo,
                                                                         _naviParameter.StrYymm,
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          null,
                                                                          atnum,
                                                                          null,
                                                                          null);

                // オペレーションログの出力 
                KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_AUTOUPDOWN, KKHLogUtilityTkd.DESC_OPERATION_LOG_AUTOUPDOWN);

                Navigator.Backward(this, true, null, true);
                this.Close();
            }
        }

        /// <summary>
        /// キャンセルボタン押下時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhButton3_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// 画面遷移時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DatailAutoUpDown_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is DatailAutoUpDownNaviParameter)
            {
                _naviParameter = (DatailAutoUpDownNaviParameter)arg.NaviParameter;
            }
        }

        # endregion イベント


    }
}
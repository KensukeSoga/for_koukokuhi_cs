using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Mast.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Top;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Acom.Utility;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.UserManual;
namespace Isid.KKH.Acom.View.Top
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmTopMenuAcom : TopMenuForm, INaviParameter
    {
        # region メンバ変数
        private KKHNaviParameter topNaviParameter;
        private Common.KKHSchema.Log _log = new Common.KKHSchema.Log();

        # endregion

        # region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public frmTopMenuAcom()
        {
            InitializeComponent();
        }

        # endregion

        # region イベント
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuAcom_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;

            ShowLog();
        }

        /// <summary>
        /// 帳票ボタンClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChohyo_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, "toReportAcom", topNaviParameter);
            //Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileImport_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, "toHikAcom", topNaviParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClaim_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, "toClaimAcom", topNaviParameter);
        }

        /// <summary>
        /// フォームLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuAcom_Load(object sender, EventArgs e)
        {
            //親[帳票]ボタンを非表示
            btnAccount.Visible = false;
        }

        /// <summary>
        /// [マスター]ボタンPopupButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnMasterMaintenance_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            //ボタン名(画面名)を取得 
            topNaviParameter.StrValue1 = value.Value.ToString();
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }


        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }


        # endregion イベント
        # region メソッド
        /// <summary>
        /// 履歴表示 
        /// </summary>
        private void ShowLog()
        {

            FindLogByCondServiceResult logResult = KKHLogUtility.ReadLogFromDB(topNaviParameter, KKHLogUtility.SYBT_LOG_SHOW);

            if (spdLogCaption_Sheet1.Rows.Count != 0)
            {
                spdLogCaption_Sheet1.RemoveRows(0, spdLogCaption_Sheet1.Rows.Count);
            }
            int rowCount = 0;
            foreach (Common.KKHSchema.Log.LogDataRow row in logResult.LogDataSet.LogData.Rows)
            {
                // １行追加 
                spdLogCaption_Sheet1.AddRows(rowCount, 1);

                // 区分 
                spdLogCaption_Sheet1.Cells[rowCount, 0].Value = row.kbn;

                // 内容 
                spdLogCaption_Sheet1.Cells[rowCount, 1].Value = row.desc;

                // 送信完了日時 
                if ("002".Equals(row.kinoId))
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 2].Value = DateTime.Parse(row.updDate).ToString("yyyy/MM/dd HH:mm:ss");
                }
                else
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 2].Value = string.Empty;
                }
                
                // 受信完了日時 
                if ("001".Equals(row.kinoId))
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 3].Value = DateTime.Parse(row.updDate).ToString("yyyy/MM/dd HH:mm:ss");
                }
                else
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 3].Value = string.Empty;
                }

                // 担当者 
                spdLogCaption_Sheet1.Cells[rowCount, 4].Value = row.tanName;

                // 送受信種別 
                spdLogCaption_Sheet1.Cells[rowCount, 5].Value = row.receptionKind;

                // ステータス 
                if ("0".Equals(row.status))
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 6].Value = "正常";
                }
                else
                {
                    spdLogCaption_Sheet1.Cells[rowCount, 6].Value = "異常";

                    // 異常の場合は背景を赤くする 
                    spdLogCaption_Sheet1.Rows[rowCount].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;
                }

                rowCount += 1;
            }
        }

        # endregion メソッド

    }
}
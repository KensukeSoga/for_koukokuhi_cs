using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Lion.Utility;


namespace Isid.KKH.Lion.View.Detail
{

    /// <summary>
    /// 
    /// </summary>
    public partial class FindLionCardNoItr : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        private FindLionCardNoItrNaviParameter _naviParameter = new FindLionCardNoItrNaviParameter();

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public FindLionCardNoItr()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        /// <summary>
        /// ProcessAffterNavigating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void FindLionCardNoItr_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //ナビパラメータがnullの場合 
            if (arg.NaviParameter == null)
            {
                return;
            }


            if (arg.NaviParameter is FindLionCardNoItrNaviParameter)
            {
                //ナビパラメータを設定する 
                _naviParameter = (FindLionCardNoItrNaviParameter)arg.NaviParameter;
            }

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// カードNoSelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCard.SelectedItem == null)
            {
                return;
            }

            DetailLionProcessController.FindLionCardNoItrParam param = new DetailLionProcessController.FindLionCardNoItrParam();
            param.esqId = _naviParameter.strEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;

            String strcdno = listCard.SelectedItem.ToString();
            String[] arystr = strcdno.Split('　');
            String cdno = arystr[0];

            //実行 
            DetailLionProcessController processController = DetailLionProcessController.GetInstance();
            FindLionCardNoItrServiceResult result = processController.FindLionCardNoItrService(cdno, param);

            //データセット取り出し 
            listBaitai.Items.Clear();
            for( int i = 0 ; i < result.CNILionDataSet.KkhCardNoItr.Count ; i++ )
            {
                listBaitai.Items.Add(result.CNILionDataSet.KkhCardNoItr[i].Field1 + "　" + result.CNILionDataSet.KkhCardNoItr[i].Field2);
            }           

            //スポット、その他、制作以外は媒体リストの一番上を初期選択状態にする 
            if (cdno.Equals(KKHLionConst.COLSTR_CARDNO_SPOT)
                || cdno.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU)
                || cdno.Equals(KKHLionConst.COLSTR_CARDNO_SONOTA))
            {}
            else
            {
                listBaitai.SelectedIndex = 0;
            }
           
        }

        /// <summary>
        /// キャンセルボタンClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// OKボタンClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //選択状態でなかったらキャンセルと同義
            if (listCard.SelectedIndex == -1)
            {
                Navigator.Backward(this, null, null, true);
                this.Close();
                return;
            }

            String strcdno = listCard.SelectedItem.ToString();
            String[] arycd = strcdno.Split('　');
            if (listBaitai.SelectedItem == null)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0111, null, "カードNO一覧", MessageBoxButtons.OK);
                this.listCard.Focus();
            }
            else
            {
                //Navigator.Backward(this, true, null, true);
                String strbtno = listBaitai.SelectedItem.ToString();
                String[] arybt = strbtno.Split('　');

                _naviParameter.CdNoItrCd = arycd[0] + "," + arycd[1] + "," + arybt[0] + "," + arybt[1];
                Navigator.Backward(this, _naviParameter, null, true);
                this.Close();
            }

        }

        /// <summary>
        /// カードNoDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listCard_DoubleClick(object sender, EventArgs e)
        {
            if (listCard.SelectedItem == null)
            {
                return;
            }

            String strcdno = listCard.SelectedItem.ToString();
            String[] arycd = strcdno.Split('　');
            if (listBaitai.SelectedItem == null)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0111, null, "カードNO一覧", MessageBoxButtons.OK);
                this.listCard.Focus();
            }
            else
            {
                //Navigator.Backward(this, true, null, true);
                String strbtno = listBaitai.SelectedItem.ToString();
                String[] arybt = strbtno.Split('　');

                _naviParameter.CdNoItrCd = arycd[0] + "," + arycd[1] + "," + arybt[0] + "," + arybt[1];
                Navigator.Backward(this, _naviParameter, null, true);
                this.Close();
            }
        }

        /// <summary>
        /// 媒体DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBaitai_DoubleClick(object sender, EventArgs e)
        {
            if (listBaitai.SelectedItem == null)
            {
                return;
            }

            String strcdno = listCard.SelectedItem.ToString();
            String[] arycd = strcdno.Split('　');
            //Navigator.Backward(this, true, null, true);
            String strbtno = listBaitai.SelectedItem.ToString();
            String[] arybt = strbtno.Split('　');

            _naviParameter.CdNoItrCd = arycd[0] + "," + arycd[1] + "," + arybt[0] + "," + arybt[1];
            Navigator.Backward(this, _naviParameter, null, true);
            this.Close();
        }
    }
}
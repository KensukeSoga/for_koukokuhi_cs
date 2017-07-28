using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.SystemCommon;

namespace Isid.KKH.Common.KKHView.Common.Control
{
    public partial class btnMenuCho : UserControl
    {
        #region メンバ変数

 

        /// <summary>
        /// REP_KEY_SYBT：003
        /// </summary>
        private const string REP_KEY_SYBT = "003";

        private string btnNm = "";
        public string BtnNm
        {
            get { return btnNm; }
            set { btnNm = value; }
        }
        private string btnId = "";
        public string BtnId
        {
            get { return btnId; }
            set { btnId = value; }
        }

        private int btnCnt = 0;
        public int BtnCnt
        {
            get { return btnCnt; }
            set { btnCnt = value; }
        }

        #endregion メンバ変数 


        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public btnMenuCho()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Loadイベントでボタン数を制御する 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KkhMenuButton_Load(object sender, EventArgs e)
        {

            //this.ActiveControl = null;

            # region 画面表示 

            //ボタンの表示数を取得 
            int hyojiCnt = int.Parse(this.Tag.ToString());

            //表示 
            for (int i = 0; i < hyojiCnt; i++)
            {
                if (i == 0) { this.menuBtn1.Visible = true; }
                else if (i == 1) { this.menuBtn2.Visible = true; }
                else if (i == 2) { this.menuBtn3.Visible = true; }
                else if (i == 3) { this.menuBtn4.Visible = true; }
                else if (i == 4) { this.menuBtn5.Visible = true; }
                else if (i == 5) { this.menuBtn6.Visible = true; }
                else if (i == 6) { this.menuBtn7.Visible = true; }
                else if (i == 7) { this.menuBtn8.Visible = true; }
                else if (i == 8) { this.menuBtn9.Visible = true; }
                else if (i == 9) { this.menuBtn10.Visible = true; }
                else if (i == 10) { this.menuBtn11.Visible = true; }
                else if (i == 11) { this.menuBtn12.Visible = true; }
                else if (i == 12) { this.menuBtn13.Visible = true; }
                else if (i == 13) { this.menuBtn14.Visible = true; }
                else if (i == 14) { this.menuBtn15.Visible = true; }
                else if (i == 15) { this.menuBtn16.Visible = true; }
                else if (i == 16) { this.menuBtn17.Visible = true; }
                else if (i == 17) { this.menuBtn18.Visible = true; }
            }

            //非表示 
            for (int i = hyojiCnt; i < 19; i++)
            {
                if (i == 0) { this.menuBtn1.Visible = false; }
                else if (i == 1) { this.menuBtn2.Visible = false; }
                else if (i == 2) { this.menuBtn3.Visible = false; }
                else if (i == 3) { this.menuBtn4.Visible = false; }
                else if (i == 4) { this.menuBtn5.Visible = false; }
                else if (i == 5) { this.menuBtn6.Visible = false; }
                else if (i == 6) { this.menuBtn7.Visible = false; }
                else if (i == 7) { this.menuBtn8.Visible = false; }
                else if (i == 8) { this.menuBtn9.Visible = false; }
                else if (i == 9) { this.menuBtn10.Visible = false; }
                else if (i == 10) { this.menuBtn11.Visible = false; }
                else if (i == 11) { this.menuBtn12.Visible = false; }
                else if (i == 12) { this.menuBtn13.Visible = false; }
                else if (i == 13) { this.menuBtn14.Visible = false; }
                else if (i == 14) { this.menuBtn15.Visible = false; }
                else if (i == 15) { this.menuBtn16.Visible = false; }
                else if (i == 16) { this.menuBtn17.Visible = false; }
                else if (i == 17) { this.menuBtn18.Visible = false; }
            }

            # endregion 画面表示 

        }
    }
}

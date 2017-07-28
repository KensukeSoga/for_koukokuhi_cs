using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Mac.View.Mast
{
    public partial class frmMastMacNarrowDown : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region "メンバ変数"
        /// <summary>
        /// ナビパラメーター
        /// </summary>
        private MastNarrowDownNaviParameter _naviParam = new MastNarrowDownNaviParameter();
        #endregion "メンバ変数"

        #region "コンストラクタ"
        public frmMastMacNarrowDown()
        {
            InitializeComponent();
        }
        #endregion "コンストラクタ"

        #region "イベント"

        /// <summary>
        /// 画面遷移時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastMacNarrowDown_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is MastNarrowDownNaviParameter)
            {
                _naviParam = (MastNarrowDownNaviParameter)arg.NaviParameter;
            }

            //初期表示は"完全に一致"
            cmbCd.SelectedIndex = 0;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastMacNarrowDown_Load(object sender, EventArgs e)
        {
            //店舗コードが存在した場合以前この画面に遷移したと判断する
            if (!string.IsNullOrEmpty(_naviParam.tenCd) || !string.IsNullOrEmpty(_naviParam.tenName))
            {
                tenCdTxt.Text = _naviParam.tenCd;
                tenNmTxt.Text = _naviParam.tenName;
                cmbCd.SelectedIndex = _naviParam.tenCdCmb;
                chkKanto.Checked = _naviParam.terKanto;
                chkKansai.Checked = _naviParam.terKansai;
                chkTyuo.Checked = _naviParam.terTyuou;
                chkTerSonota.Checked = _naviParam.terSonota;
                chkTikuhonbu.Checked = _naviParam.kbnTikuhonbu;
                chkMc.Checked = _naviParam.kbnMc;
                chkLicensee.Checked = _naviParam.kbnLicensee;
                chkKbnSonota.Checked = _naviParam.kbnSonota;
                tenCd2Txt.Text = _naviParam.tenCd2;

            }
        }

        /// <summary>
        /// OKボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Okbtn_Click(object sender, EventArgs e)
        {
            //入力チェック 
            if (!oKBtnCheck())
            {
                this.ActiveControl = null;
                return;
            }

            // ナビパラメータのインスタンス生成
            MastNarrowDownNaviParameter naviparam = new MastNarrowDownNaviParameter();

            naviparam.tenCd = this.tenCdTxt.Text;           //店舗コード
            naviparam.tenCd2 = tenCd2Txt.Text;              //店舗コード2   
            naviparam.tenCdCmb = cmbCd.SelectedIndex;       //店舗コードのコンボ
            naviparam.tenName = tenNmTxt.Text;              //店舗名
            naviparam.terKanto = chkKanto.Checked;          //関東
            naviparam.terKansai = chkKansai.Checked;        //関西
            naviparam.terTyuou = chkTyuo.Checked;           //中央
            naviparam.terSonota = chkTerSonota.Checked;     //テリトリーその他
            naviparam.kbnTikuhonbu = chkTikuhonbu.Checked;  //地区区分
            naviparam.kbnMc = chkMc.Checked;                //MC直営店
            naviparam.kbnLicensee = chkLicensee.Checked;    //ライセンシー
            naviparam.kbnSonota = chkKbnSonota.Checked;     //地区区分その他

            Navigator.Backward(this, naviparam, null, true);
            this.Close();
        }

        /// <summary>
        /// キャンセルボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// テリトリーチェンジイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkteri_CheckedChanged(object sender, EventArgs e)
        {
            //チェックがあるかのフラグ
            bool ChckFlg = false;
            
            if (chkKanto.Checked)//関東
            {
                ChckFlg = true;
            }
            else if (chkKansai.Checked)//関西
            {
                ChckFlg = true;
            }
            else if (chkTyuo.Checked)//中央
            {
                ChckFlg = true;
            }
            else if (chkTerSonota.Checked)//その他
            {
                ChckFlg = true;
            }

            if (ChckFlg)
            {
                return;
            }
            //選択されているテリトリー名称を取得
            string tiku = ((System.Windows.Forms.ButtonBase)(sender)).Text;

            switch (tiku)
            {
                case "関東":
                    chkKanto.Checked = true;
                    break;
                case "関西":
                    chkKansai.Checked = true;
                    break;
                case "中央":
                    chkTyuo.Checked = true;
                    break;
                case "その他":
                    chkTerSonota.Checked = true;
                    break;
            }

        }
     
        /// <summary>
        /// 店舗区分チェンジイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTenKbn_CheckedChanged(object sender, EventArgs e)
        {
            //チェックがあるかのフラグ
            bool ChckFlg = false;

            if (chkTikuhonbu.Checked)
            {
                ChckFlg = true;
            }
            else if (chkMc.Checked)
            {
                ChckFlg = true;
            }
            else if (chkLicensee.Checked)
            {
                ChckFlg = true;
            }
            else if (chkKbnSonota.Checked)
            {
                ChckFlg = true;
            }

            if (ChckFlg)
            {
                //チェックがある場合return
                return;
            }
            //選択されている区分名称を取得
            string Kbn = ((System.Windows.Forms.ButtonBase)(sender)).Text;

            switch (Kbn)
            {
                case "地区本部":
                    chkTikuhonbu.Checked = true;
                    break;
                case "MC直営店":
                    chkMc.Checked = true;
                    break;
                case "ライセンシー":
                    chkLicensee.Checked = true;
                    break;
                case "その他":
                    chkKbnSonota.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 店舗コードコンボボックスチェンジイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCd.SelectedIndex != 4)
            {
                tenCd2Txt.Visible = false;
                betweenLabel.Visible = false;
                return;
            }

            tenCd2Txt.Visible = true;
            betweenLabel.Visible = true;
            
        }

        #endregion "イベント"

        # region メソッド

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean oKBtnCheck()
        {
            // 絞り込み条件が選択されていない場合
            if (cmbCd.SelectedIndex == 0)
            {
                // 店舗コードが入力されている場合
                if (!string.IsNullOrEmpty(this.tenCdTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0130, null, "マスターメンテナンス", MessageBoxButtons.OK);
                    return false;
                }

                // 店舗名が入力されていない場合
                if (string.IsNullOrEmpty(tenNmTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0131, null, "マスターメンテナンス", MessageBoxButtons.OK);
                    return false;
                }
            }
            else
            {
                // 店舗コードが入力されていない場合
                if (string.IsNullOrEmpty(this.tenCdTxt.Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, "マスターメンテナンス", MessageBoxButtons.OK);
                    return false;
                }
                else if (this.tenCdTxt.Text.Length != 6)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0129, null, "マスターメンテナンス", MessageBoxButtons.OK);
                    return false;
                }

                // 絞り込み条件で「～」が選択されている場合
                if (cmbCd.SelectedIndex == 4)
                {
                    // 店舗コード
                    if (string.IsNullOrEmpty(tenCd2Txt.Text))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, "マスターメンテナンス", MessageBoxButtons.OK);
                        return false;
                    }                    
                    else if (this.tenCd2Txt.Text.Length != 6)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0129, null, "マスターメンテナンス", MessageBoxButtons.OK);
                        return false;
                    }

                }
            }

            return true;
        }

        # endregion メソッド

    }
}


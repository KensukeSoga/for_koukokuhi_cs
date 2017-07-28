using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHUtility.Security;

namespace Isid.KKH.Lion.View.Mast
{
    /// <summary>
    /// ライオンマスタ管理.
    /// </summary>
    public partial class frmMastLion : MastForm, INaviParameter
    {

        #region メンバ変数.

        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        #endregion メンバ変数.

        #region 定数.

        #region カラムインデックス.

        /// <summary>
        /// コード.
        /// </summary>
        private const int COLIDX_1 = 0;
        /// <summary>
        /// 名称.
        /// </summary>
        private const int COLIDX_2 = 1;

        #endregion カラムインデックス.

        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */
        #region マスターキー.

        private const string MST_KEY_CATEGORY = "0031";

        #endregion マスターキー.
        /* 2014/07/31 比較帳票対応 HLC fujimoto ADD end */

        #endregion 定数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public frmMastLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// フォームProcessAffterNavigatingイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロード時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastLion_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;
            btnKinHen.Visible = false;
        }

        /// <summary>
        /// マスター名コンボボックス選択時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMasterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 2 
                || cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 1)
            {
                RowUpBtn.Enabled = false;
                RowUpBtn.Visible = false;
                RowDownBtn.Enabled = false;
                RowDownBtn.Visible = false;
                btnKinHen.Visible = false; 
            }
            //雑誌スペース料金マスタ用のボタンを表示 
            else if (base.mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 
                == KKHLionConst.C_MAST_ZASSI_CD)
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
                btnKinHen.Visible = true;
            }
            else
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
                btnKinHen.Visible = false; 
            }
        }

        /// <summary>
        /// 金額編集(雑誌)画面へ遷移.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKinHen_Click(object sender, EventArgs e)
        {
            frmMastLionNaviParameter naviParam = new frmMastLionNaviParameter(mstNavPrm);
            int row = spdMasMainte.ActiveSheet.ActiveRowIndex;
            naviParam.Cd = spdMasMainte.ActiveSheet.Cells[row, 11].Text;
            naviParam.Name = spdMasMainte.ActiveSheet.Cells[row, 12].Text;
            naviParam.strName = mstNavPrm.strName;
            naviParam.strDate = mstNavPrm.strDate;
            Navigator.Forward(this, "tofrmMastLionZashiRyoSpc", naviParam);
        }

        /// <summary>
        /// 更新ボタンクリック時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnUpd_Click(object sender, EventArgs e)
        {
            if (base.mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3
                == KKHLionConst.C_MAST_SEITIKU_CD)
            {
                MasterMaintenance.MasterDataVODataTable mstDataVo = new MasterMaintenance.MasterDataVODataTable();
                foreach (MasterMaintenance.MasterDataVORow row in (MasterMaintenance.MasterDataVODataTable)spdMasMainte_Sheet1.DataSource)
                {
                    row.Column1 = cmdMasterName2.Text.Substring(0, 2);
                    mstDataVo.ImportRow(row);
                }

                spdMasMainte_Sheet1.DataSource = mstDataVo;
            }

            base.btnUpd_Click(sender, e);
        }

        #endregion イベント.

        #region メソッド.

        /// <summary>
        /// コンボボックス設定.
        /// </summary>
        /// <param name="row">マスター項目VODataRow</param>
        /// <param name="cmbtyp">コンボボックスセルタイプ</param>
        /// <param name="ColIndex">列インデックス</param>
        /// <param name="RowCount">行インデックス</param>
        /// <param name="kokuKbnArr">国際区分用文字列配列</param>
        protected override void SpreadSettingCombo(MasterMaintenance.MasterItemVORow row,
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp, int ColIndex, int RowCount, string[] kokuKbnArr)
        {
            /* 2014/07/31 比較帳票対応 HLC fujimoto ADD start */
            //0031 カテゴリマスタの場合.
            //※0005 ADブランドマスタ(カテゴリ)で使用.
            if (row.field19.Equals(MST_KEY_CATEGORY))
            {
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    KKHSecurityInfo.GetInstance().UserEsqId,
                    mstNavPrm.strEgcd,
                    mstNavPrm.strTksKgyCd,
                    mstNavPrm.strTksBmnSeqNo,
                    mstNavPrm.strTksTntSeqNo,
                    row.field19,
                    null
                );

                if (result.HasError)
                {
                    return;
                }

                MasterMaintenance mstds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] mstrows
                    = (MasterMaintenance.MasterDataVORow[])mstds.MasterDataVO.Select("", "");

                String[] subMasterCd = new String[mstrows.Length];
                String[] subMasterNm = new String[mstrows.Length];

                for (int i = 0; i < mstrows.Length; i++)
                {
                    subMasterCd[i] = mstrows[i].Column1;
                    subMasterNm[i] = mstrows[i].Column2;
                }

                cmbtyp.Items = subMasterNm;
                cmbtyp.ItemData = subMasterCd;
                Boolean flg = false;

                for (int i = 0; i < RowCount; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value == null)
                    {
                        continue;
                    }

                    //フラグ初期化.
                    flg = false;

                    for (int j = 0; j < cmbtyp.Items.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.Items[j]))
                        {
                            flg = true;
                            break;
                        }
                    }

                    if (flg) 
                    { 
                        continue;
                    }

                    //フラグ初期化.
                    flg = false;
                    
                    for (int j = 0; j < cmbtyp.ItemData.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[j]))
                        {
                            spdMasMainte_Sheet1.Cells[i, ColIndex].Value = cmbtyp.Items[j];
                            flg = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                base.SpreadSettingCombo(row, cmbtyp, ColIndex, RowCount, kokuKbnArr);
            }
            /* 2014/07/31 比較帳票対応 HLC fujimoto ADD end */
        }

        #endregion メソッド.
    }
}


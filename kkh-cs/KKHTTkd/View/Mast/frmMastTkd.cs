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
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Tkd.View.Mast
{
    public partial class frmMastTkd : MastForm, INaviParameter
    {
        #region メンバ変数
        /// <summary>
        /// ナビパラメーター
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        
        /// <summary>
        /// 中分類コード
        /// </summary>
        string[] buruiCd;

        /// <summary>
        /// 中分類名
        /// </summary>
        string[] bunruiNM;

        /// <summary>
        /// 
        /// </summary>
        private const int TYUCOLINDEX = 11;

        /// <summary>
        /// dataModelChangeイベント 
        /// </summary>
        DefaultSheetDataModel dataModel;

        #endregion メンバ変数

        #region コンストラクタ

        public frmMastTkd()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ

        #region イベント

        /// <summary>
       /// 画面遷移するたびに発生
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="arg"></param>
        private void frmMastAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;

        }

        /// <summary>
        /// 新規ボタンクリック(一時対応)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrt_Click(object sender, EventArgs e)
        {
            //TODO
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field2.Equals("203"))
            {
                //新規追加した行。
                int Acrow = spdMasMainte_Sheet1.ActiveRowIndex;
                //現在選択されているフィルターのインデックス
                int SelectFileterRow = cmdMasterName2.SelectedIndex;
                ComboBoxCellType cm 
                    = new ComboBoxCellType((ComboBoxCellType)spdMasMainte_Sheet1.Columns[TYUCOLINDEX].CellType);
                //string tex = cm.Items[SelectFileterRow].ToString();
                spdMasMainte_Sheet1.Cells[Acrow, TYUCOLINDEX].Text = cm.Items[SelectFileterRow].ToString();
            }
        }

        /// <summary>
        /// Loadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastTkd_Load(object sender, EventArgs e)
        {
            dataModel = (DefaultSheetDataModel)spdMasMainte.ActiveSheet.Models.Data;
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }
       
        /// <summary>
        /// 更新ボタンクリック時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnUpd_Click(object sender, EventArgs e)
        {
            dataModel.Changed -= new SheetDataModelEventHandler(this.dataModel_Changed);
            base.btnUpd_Click(sender, e);
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }

        #endregion イベント

        #region メソッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cmbtyp"></param>
        /// <param name="ColIndex"></param>
        /// <param name="RowCount"></param>
        /// <param name="kokuKbnArr"></param>
        protected override void SpreadSettingCombo(MasterMaintenance.MasterItemVORow row, 
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp, int ColIndex, int RowCount, string[] kokuKbnArr)
        {
            if (row.field19.Equals("0004"))
            {
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    KKHSecurityInfo.GetInstance().UserEsqId,
                    mstNavPrm.strEgcd,
                    mstNavPrm.strTksKgyCd,
                    mstNavPrm.strTksBmnSeqNo,
                    mstNavPrm.strTksTntSeqNo,
                    "0004",
                    null
                );

                if (result.HasError)
                {
                    return;
                }

                MasterMaintenance mstds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] mstrows
                    = (MasterMaintenance.MasterDataVORow[])mstds.MasterDataVO.Select("", "");

                String[] tybunruiCd = new String[mstrows.Length];
                String[] tybunruiNM = new String[mstrows.Length];

                for (int i = 0; i < mstrows.Length; i++)
                {
                    tybunruiNM[i] = mstrows[i].Column2;
                    tybunruiCd[i] = mstrows[i].Column1;
                }

                bunruiNM = tybunruiNM;
                buruiCd = tybunruiCd;
                cmbtyp.Items = tybunruiNM;
                cmbtyp.ItemData = tybunruiCd;

                for (int i = 0; i < RowCount; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value == null)
                    {
                        //これいる？ 
                        //spdMasMainte_Sheet1.Cells[i, ColIndex].Value = "新聞";
                        continue;
                    }
                    Boolean flg = false;

                    for (int j = 0; j < cmbtyp.Items.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.Items[j]))
                        {
                            flg = true;
                            break;
                        }
                    }

                    if (flg) { continue; }

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

                    //これいる？ 
                    //if (!flg) { spdMasMainte_Sheet1.Cells[i, ColIndex].Value = "新聞"; }
                }
            }
            else
            {
                base.SpreadSettingCombo(row, cmbtyp, ColIndex, RowCount, kokuKbnArr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="Count"></param>
        protected override void MstDataUpdateCombo(MasterMaintenance.MasterItemVORow row, int Count)
        {
            if (row.field19.Equals("0004"))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < buruiCd.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value.Equals(bunruiNM[j]))
                        {
                            spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value = buruiCd[j];
                            break;
                        }
                    }
                }
            }
            else
            {
                base.MstDataUpdateCombo(row, Count);
            }
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // 消費税マスターの時のみチェックを行う
            if( String.Equals(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3, "0003") )
            {
                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {
                    if ((spdMasMainte_Sheet1.Cells[i, 11].Text.Length != 8)
                        || (!KKHUtility.IsDate(spdMasMainte_Sheet1.Cells[i, 11].Text, "yyyyMMdd")))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0039, null, "マスタメンテナンス",
                            MessageBoxButtons.OK);
                        return false;
                    }

                    if ((spdMasMainte_Sheet1.Cells[i, 12].Text.Length != 8)
                        || (!KKHUtility.IsDate(spdMasMainte_Sheet1.Cells[i, 12].Text, "yyyyMMdd")))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0039, null, "マスタメンテナンス",
                            MessageBoxButtons.OK);
                        return false;
                    }


                    //開始日付＞終了日付の場合、エラーとする 
                    if (KKHUtility.StringCnvDateTime(spdMasMainte_Sheet1.Cells[i, 11].Text).CompareTo(KKHUtility.StringCnvDateTime(spdMasMainte_Sheet1.Cells[i, 12].Text)) == 1)
                    {
                        //エラー 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0156, null, "マスタメンテナンス",
                            MessageBoxButtons.OK);
                        return false;
                    }
                }

            }

            // 中分類紐付けマスターの時のみチェックを行う
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3.Trim() == "0005")
            {
                //[業務区分]列Index
                int gyomColIdx = -1;
                //[タイムスポット]列Index
                int tsColIdx = -1;

                //[業務区分][タイムスポット区分]列のIndexを取得する 
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "業務区分")
                    {
                        gyomColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "タイムスポット区分")
                    {
                        tsColIdx = i;
                    }
                }

                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {

                    //ラジオ・衛星メディアの場合はエラーメッセージ（更新不可） 
                    if (spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "ラジオ"
                        || spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "衛星メディア")
                    {
                        //タイムスポット区分が空の場合 
                        if (spdMasMainte_Sheet1.Cells[i, tsColIdx].Text.ToString() == "")
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0136, null,
                                "マスタメンテナンス", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        /// <summary>
        /// dataModel_Changed(ペースト対策) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            int gyomColIdx = -1; //[業務区分]列Index
            int kokuColIdx = -1; //[国際区分]列Index
            int tsColIdx = -1;   //[タイムスポット]列Index

            // 中分類紐付けマスターの場合、処理を行う
            if (cmbMasterName1.Text == "中分類紐付けマスター")
            {
                //[業務区分][国際区分][タイムスポット区分][コード]列のIndexを取得する 
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "業務区分")
                    {
                        gyomColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "国際区分")
                    {
                        kokuColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "タイムスポット区分")
                    {
                        tsColIdx = i;
                    }
                }
                //[業務区分]列の場合、処理する 
                if (e.Column == gyomColIdx && gyomColIdx > -1)
                {
                    if (kokuColIdx > -1)
                    {
                        //[国際区分]を[国内]にする 
                        spdMasMainte_Sheet1.Cells[e.Row, kokuColIdx].Value = "国内";
                    }

                    //業務区分がラジオ、または衛星メディアの場合 
                    if (spdMasMainte_Sheet1.Cells[e.Row, gyomColIdx].Text.ToString() == "ラジオ"
                        || spdMasMainte_Sheet1.Cells[e.Row, gyomColIdx].Text.ToString() == "衛星メディア")
                    {
                        if (tsColIdx > -1)
                        {
                            //タイムスポット区分初期化 
                            //編集可  
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Locked = false;
                            //背景色を白 
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].BackColor = Color.White;
                            //フォーカス可 
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].CanFocus = true;
                            //値を空にする  
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Value = "";
                        }
                    }
                    else
                    {
                        if (tsColIdx > -1)
                        {
                            //タイムスポット区分初期化 
                            //編集可  
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Locked = true;
                            //背景色を白 
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].BackColor = Color.Black;
                            //フォーカス可 
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].CanFocus = false;
                            //値を空にする  
                            spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Value = "";
                        }
                    }
                }
            }
        }

        #endregion メソッド
    }
}

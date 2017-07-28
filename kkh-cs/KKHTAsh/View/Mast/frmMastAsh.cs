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
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Ash.View.Mast
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMastAsh : MastForm, INaviParameter
    {
        # region メンバ変数

        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        //string[] msg = new string[1];

        /// <summary>
        /// dataModelChangeイベント 
        /// </summary>
        DefaultSheetDataModel dataModel;

        # endregion

        # region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public frmMastAsh()
        {
            InitializeComponent();
        }
        # endregion

        # region イベント
        /// <summary>
       /// 画面遷移時
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="arg"></param>
        private void frmMastAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastAsh_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;

            //マスタ名コンボボックスにメニュー画面で押下されたマスタボタン名をセット 
            cmbMasterName1.Text = mstNavPrm.StrValue1;

            dataModel = (DefaultSheetDataModel)spdMasMainte.ActiveSheet.Models.Data;
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }

        /// <summary>
        /// 
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
            }
            else
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            //スプレッド初期化後に色を付けるため 
            this.CfukuCheck();
        }


        # endregion

        # region メソッド

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

            // 媒体コード変換マスターの場合、処理を行う
            if (cmbMasterName1.Text == "媒体コード変換マスター")
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

        # endregion

        # region オーバーライド

        /// <summary>
        /// CfukuCheckをアサヒ用に修正 
        /// </summary>
        /// <returns></returns>
        protected override bool CfukuCheck()
        {
            // 媒体コード変換マスターの時のみチェックを行う
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 !=
                KkhConstAsh.MasterKey.BAITAI_HENNKAN)
            {
                //return true;
                return base.CfukuCheck();
            }
            int gyomColIdx = -1; //[業務区分]列Index
            int kokuColIdx = -1; //[国際区分]列Index
            int tsColIdx = -1;   //[タイムスポット]列Index
            int cdColIdx = -1;   //[コード]列Index
            string gyomKbn;  //[業務区分]
            string kokuKbn;  //[国際区分]
            string tsKbn;    //[タイムスポット]
            string cd;       //[コード]
            string[] errRowIdx = new string[spdMasMainte_Sheet1.RowCount];    //重複した行 
            bool errFlg = false;

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
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "コード")
                {
                    cdColIdx = i;
                }
            }

            //背景を初期化 
            //業務区分 
            if (gyomColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, gyomColIdx].BackColor = Color.White;
                }
            }
            //国際区分 
            if (kokuColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, kokuColIdx].BackColor = Color.White;
                }
            }
            //タイムスポット区分 
            if (tsColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    //空の場合 
                    if (spdMasMainte_Sheet1.Cells[i, tsColIdx].Text == "")
                    {
                        spdMasMainte_Sheet1.Cells[i, tsColIdx].BackColor = Color.Black;
                    }
                    else
                    {
                        spdMasMainte_Sheet1.Cells[i, tsColIdx].BackColor = Color.White;
                    }

                }
            }
            //コード 
            if (cdColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, cdColIdx].BackColor = Color.White;
                }
            }

            for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
            {
                //値を取得する 
                if (gyomColIdx > -1)
                {
                    gyomKbn = spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text;
                }
                else
                {
                    break;
                }

                if (kokuColIdx > -1)
                {
                    kokuKbn = spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text;
                }
                else
                {
                    break;
                }

                if (tsColIdx > -1)
                {
                    tsKbn = spdMasMainte_Sheet1.Cells[i, tsColIdx].Text;
                }
                else
                {
                    break;
                }

                if (cdColIdx > -1)
                {
                    cd = spdMasMainte_Sheet1.Cells[i, cdColIdx].Text;
                }
                else
                {
                    break;
                }


                //gyomKbn = gyomColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text : "";   //業務区分 
                //kokuKbn = kokuColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text : "";   //国際区分  
                //tsKbn = tsColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, tsColIdx].Text : "";   //タイムスポット区分  
                //cd = cdColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, cdColIdx].Text : "";  //コード 

                //同一の業務区分を調べる 
                for (int j = 0; j < spdMasMainte_Sheet1.RowCount; j++)
                {
                    //他の行の場合 
                    if (i != j)
                    {
                        //[業務区分]が同一の値の場合 
                        if (gyomKbn == spdMasMainte_Sheet1.Cells[j, gyomColIdx].Text)
                        {
                            //[国際区分]が同一の値の場合 
                            if (kokuKbn == spdMasMainte_Sheet1.Cells[j, kokuColIdx].Text)
                            {
                                //[タイムスポット区分]が同一の値の場合 
                                if (tsKbn == spdMasMainte_Sheet1.Cells[j, tsColIdx].Text)
                                {
                                    //[コード]が同一の値の場合 
                                    if (cd == spdMasMainte_Sheet1.Cells[j, cdColIdx].Text)
                                    {
                                        //重複した行Indexを取得する 
                                        errRowIdx[i] = i.ToString();
                                        errRowIdx[j] = j.ToString();

                                        errFlg = true;

                                    }
                                }
                            }
                        }
                    }
                }

                //重複している行がある場合 
                if (errFlg)
                {
                    for (int k = 0; k < spdMasMainte_Sheet1.RowCount; k++)
                    {
                        if (!string.IsNullOrEmpty(errRowIdx[k]))
                        {
                            //重複した行の取得 
                            int errRow = KKHUtility.IntParse(errRowIdx[k]);
                            
                            //重複した行の[媒体コード]列以外の背景色を変更する 
                            spdMasMainte_Sheet1.Cells[errRow, gyomColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, kokuColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, tsColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, cdColIdx].BackColor = Color.LightPink;

                        }
                    }

                    //重複した元の行をセット 
                    string[] msg = new string[1] { (i + 1).ToString() };

                    //エラーメッセージを表示する 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0154, msg,
                        "マスタメンテナンス", MessageBoxButtons.OK);
                    return false;

                }
            }

            return true;
            
        }

        /// <summary>
        /// タイムスポット区分チェック  
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // 媒体コード変換マスターの時のみチェックを行う
            if( mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3.Trim() == 
                KkhConstAsh.MasterKey.BAITAI_HENNKAN) 
            {
                int gyomColIdx = -1; //[業務区分]列Index
                int kokuColIdx = -1; //[国際区分]列Index
                int tsColIdx = -1;   //[タイムスポット]列Index

                //[業務区分][国際区分][タイムスポット区分]列のIndexを取得する 
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


                for (int i = 0; i < spdMasMainte.Sheets[0].Rows.Count; i++)
                {
                    //ラジオ・衛星メディアの場合はエラーメッセージ（更新不可） 
                    if (spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "ラジオ"
                        || spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "衛星メディア")
                    {
                        //国際区分が国内の場合 
                        if (spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text.ToString() == "国内")
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
            }

            return true;
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
        # endregion

    }
}


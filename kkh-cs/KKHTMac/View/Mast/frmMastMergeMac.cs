using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.KKHUtility;
using Isid.KKH.Mac.ProcessController.MasterMaintenance;
using FarPoint.Win.Spread;

namespace Isid.KKH.Mac.View.Mast
{
    /// <summary>
    /// マスタメンテナンス画面（macデータ取込時一覧表示画面) 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/18</description>
    ///       <description>IP H.shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmMastMergeMac : KKHForm
    {
        #region "定数"

        /// <summary>
        /// アプリID 
        /// ※取込処理と手動更新処理の判断で使用
        /// </summary>
        private const string C_APL_ID = "10";

        /// <summary>
        /// アプリ名称 
        /// </summary>
        private const string C_APL_NM = "マスタメンテナンス";

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "MergeMac";

        #endregion

        #region "変数"
        /// <summary>
        /// ナビパラメータ格納用（受け口） 
        /// </summary>
        private MastInputNaviParameter mstInNaviPrm = new MastInputNaviParameter();

        ///// <summary>
        ///// master項目設定情報保持 
        ///// </summary>
        private FindMasterMaintenanceByCondServiceResult mstDtSet = new FindMasterMaintenanceByCondServiceResult();

        ///// <summary>
        ///// 更新日時の最大値(初期値: 1000/01/01 01:01:01) 
        ///// </summary>
        DateTime maxupdate = DateTime.Parse("1000/01/01 01:01:01");

        /// <summary>
        /// スプレッドカラム数 
        /// </summary>
        private const int SpColNum = 41;

        /// <summary>
        /// 全選択否 
        /// </summary>
        bool blnAllChk = false;

        /// <summary>
        /// 変更箇所色 
        /// </summary>
        private Color ChkOutColor = Color.Red;
        #endregion

        #region "コンストラクタ"
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public frmMastMergeMac()
        {
            InitializeComponent();
        }
        #endregion

        #region "イベント"

        /// <summary>
        /// 画面初期表示 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastMergeMac_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            // マスタメンテナンス項目定義取得 
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterDefineByCond(mstInNaviPrm.strEsqId,
                                                                                                        mstInNaviPrm.strEgcd,
                                                                                                        mstInNaviPrm.strTksKgyCd,
                                                                                                        mstInNaviPrm.strTksBmnSeqNo,
                                                                                                        mstInNaviPrm.strTksTntSeqNo);
            // メンバ変数に設定 
            mstDtSet = result;

            // 営業日設定 
            tslDate.Text = mstInNaviPrm.strDate;

            // 担当者名設定 
            tslName.Text = mstInNaviPrm.strName;

            // フォームタイトル 
            this.Text = mstInNaviPrm.strTksKgyName.ToString() + C_APL_NM;
            
            // DBからデータを取得 
            result = masterMaintenanceProcessController.FindMasterByCond(mstInNaviPrm.strEsqId,
                                                                        mstInNaviPrm.strEgcd,
                                                                        mstInNaviPrm.strTksKgyCd,
                                                                        mstInNaviPrm.strTksBmnSeqNo,
                                                                        mstInNaviPrm.strTksTntSeqNo,
                                                                        KKHMacConst.C_MAST_TENPO_CD,
                                                                        null);
            // データの中から最終更新日を取得 
            this.updateMaxfind(result);

            // スプレッドにファイルとのマージ情報を表示 
            spdMasMainte.DataSource = mstInNaviPrm.dsMerge;

            // 取り込んだ件数を表示 
            tslCnt.Text = spdMasMainte.Sheets[0].Rows.Count.ToString() + "件";

           

            // スプレッド調整 
            this.SpreadSettingByMac();

            MoveColumn(true);

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 戻るボタン押下 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// 更新ボタン押下 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd_Click(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            bool blnChkEnable = false;

            MoveColumn(false);
            
            // キー重複チェック             
            // 店舗情報シート RowCount 
            for (int intRow = 0; intRow < spdMasMainte.Sheets[0].Rows.Count; intRow++)
            {
                // 変更対象否 
                if (spdMasMainte.Sheets[0].Cells[intRow, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value.Equals(true))
                {   
                    string strTenpoCd = string.Empty;
                    strTenpoCd = spdMasMainte.Sheets[0].Cells[intRow, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value.ToString();
                    blnChkEnable = true;
                    for (int intChkRow = intRow+1; intChkRow < spdMasMainte.Sheets[0].Rows.Count; intChkRow++)
                    {
                        if (spdMasMainte.Sheets[0].Cells[intChkRow, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value.Equals(true))
                        {
                            if (strTenpoCd.Equals(spdMasMainte.Sheets[0].Cells[intChkRow, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value.ToString()))
                            {
                                MoveColumn(true);
                                base.CloseLoadingDialog();
                                //MessageBox.Show("キーが重複しているレコードが存在します" + System.Environment.NewLine + "処理を中止します", C_APL_NM, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0008, null, C_APL_NM, MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }
                }
            }

            // 項目選択チェック 
            if (blnChkEnable == false)
            {
                MoveColumn(true);
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0033,
                null,
                C_APL_NM,
                MessageBoxButtons.OK);
                return;
            }

            ////ステータス妥当性チェック
            //if (!StatusChk())
            //{
            //    MoveColumn(true);
            //    base.CloseLoadingDialog();
            //    MessageUtility.ShowMessageBox(MessageCode.HB_E0014, null, "エラー", MessageBoxButtons.OK);
            //    return;
            //}

            //必須項目のチェック 
            if (!NrChk())
            {
                MoveColumn(true);
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "エラー", MessageBoxButtons.OK);
                return;
            }
            //最低最大文字数チェック 
            if (!MaxMinInputCheck())
            {
                //MoveColumn(true);
                return;
            }
            MoveColumn(true);
            base.CloseLoadingDialog();
            // 更新確認 
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0005,
                null,
                C_APL_NM,
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //MoveColumn(true);
                return;
            }

            base.ShowLoadingDialog();

            //表示ステータスの値をステータスに設定する
            for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
            {
                //削除、新規、変更の場合のみ
                switch(spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value.ToString())
                {
                    case KKHMacConst.C_INPUT_STAT_DEL:
                    case KKHMacConst.C_INPUT_STAT_NEW:
                    case KKHMacConst.C_INPUT_STAT_EDIT:
                        spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE].Value =
                            spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value;
                        break; 
                    default:
                        break; 
                }
            }            

            MoveColumn(false);
            Cursor.Current = Cursors.WaitCursor;
            // 更新用レコード 
            MasterMaintenance.MasterDataVORow[] updRow;

            //// 削除用レコード 
            //MasterMaintenance.MasterDataVORow[] delRow;

            // 更新用データテーブル 
            MasterMaintenance.MasterDataVODataTable updTbl = new MasterMaintenance.MasterDataVODataTable();

            // 店舗情報シート RowCount 
            for (int j = 0; j < spdMasMainte.Sheets[0].Rows.Count; j++)
            {
                // 変更対象否 
                if (spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value.Equals(true))
                {

                    //updRow = (MasterMaintenance.MasterDataVORow[])mstInNaviPrm.dsMerge.Select("Column1 = '" + spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value + "'");
                    //updTbl.AddMasterDataVORow(updTbl.NewMasterDataVORow());

                    //// ステータス 
                    //updTbl[updTbl.Rows.Count - 1].Column14 = updRow[0].Column14;
                    //// 店舗コード 
                    //updTbl[updTbl.Rows.Count - 1].Column1 = updRow[0].Column1;
                    //// 店舗名称 
                    //updTbl[updTbl.Rows.Count - 1].Column2 = updRow[0].Column2;
                    //// テリトリ 
                    //switch (updRow[0].Column3)
                    //{
                    //    // 関東 
                    //    case KKHMacConst.C_TERRITORY_NM1:
                    //        updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD1;
                    //        break;
                    //    // 関西 
                    //    case KKHMacConst.C_TERRITORY_NM2:
                    //        updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD2;
                    //        break;
                    //    // 中央 
                    //    case KKHMacConst.C_TERRITORY_NM3:
                    //        updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD3;
                    //        break;
                    //    // その他 
                    //    case KKHMacConst.C_TERRITORY_NM4:
                    //        updTbl[updTbl.Rows.Count - 1].Column3    = KKHMacConst.C_TERRITORY_CD4;
                    //        break;
                    //}
                    //// 店舗区分 
                    //switch (updRow[0].Column4)
                    //{
                    //    // 地区本部 
                    //    case KKHMacConst.C_TENPO_KBN_NM1:
                    //        updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD1;
                    //        break;
                    //    // MC直営 
                    //    case KKHMacConst.C_TENPO_KBN_NM2:
                    //        updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD2;
                    //        break;
                    //    // ライセンシー 
                    //    case KKHMacConst.C_TENPO_KBN_NM3:
                    //        updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD3;
                    //        break;
                    //    // その他 
                    //    case KKHMacConst.C_TENPO_KBN_NM4:
                    //        updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD4;
                    //        break;
                    //}
                    //// 勘定科目 
                    //updTbl[updTbl.Rows.Count - 1].Column5 = updRow[0].Column5;
                    //// 郵便番号 
                    //updTbl[updTbl.Rows.Count - 1].Column6 = updRow[0].Column6;
                    //// 住所１ 
                    //updTbl[updTbl.Rows.Count - 1].Column7 = updRow[0].Column7;
                    //// 住所２ 
                    //updTbl[updTbl.Rows.Count - 1].Column8 = updRow[0].Column8;
                    //// 電話番号 
                    //updTbl[updTbl.Rows.Count - 1].Column9 = updRow[0].Column9;
                    //// 明細行フラグ 
                    //switch (updRow[0].Column10)
                    //{
                    //    // 分割する 
                    //    case KKHMacConst.C_SPLIT_FLG_NM1:
                    //        updTbl[updTbl.Rows.Count - 1].Column10 = KKHMacConst.C_SPLIT_FLG_CD1;
                    //        break;
                    //    // 分割しない 
                    //    case KKHMacConst.C_SPLIT_FLG_NM2:
                    //        updTbl[updTbl.Rows.Count - 1].Column10 = KKHMacConst.C_SPLIT_FLG_CD2;
                    //        break;
                    //}
                    //// ライセンシー 
                    //updTbl[updTbl.Rows.Count - 1].Column11 = updRow[0].Column11;
                    //// 代表者名 
                    //updTbl[updTbl.Rows.Count - 1].Column12 = updRow[0].Column12;
                    //// 取引先コード 
                    //updTbl[updTbl.Rows.Count - 1].Column13 = updRow[0].Column13;
                    ////初期G.OPEN年月日
                    //updTbl[updTbl.Rows.Count - 1].Column15 = updRow[0].Column15;
                    ////G.OPEN年月日
                    //updTbl[updTbl.Rows.Count - 1].Column16 = updRow[0].Column16;
                    ////G.CLOSE年月日
                    //updTbl[updTbl.Rows.Count - 1].Column17 = updRow[0].Column17;

                    updTbl.AddMasterDataVORow(updTbl.NewMasterDataVORow());

                    // ステータス 
                    updTbl[updTbl.Rows.Count - 1].Column14 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Value);
                    // 店舗コード 
                    updTbl[updTbl.Rows.Count - 1].Column1 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value);
                    // 店舗名称 
                    updTbl[updTbl.Rows.Count - 1].Column2 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TENPO_NM].Value);
                    // テリトリ 
                    switch (System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TERRITORY].Value))
                    {
                        // 関東 
                        case KKHMacConst.C_TERRITORY_NM1:
                            updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD1;
                            break;
                        // 関西 
                        case KKHMacConst.C_TERRITORY_NM2:
                            updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD2;
                            break;
                        // 中央 
                        case KKHMacConst.C_TERRITORY_NM3:
                            updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD3;
                            break;
                        // その他 
                        case KKHMacConst.C_TERRITORY_NM4:
                            updTbl[updTbl.Rows.Count - 1].Column3 = KKHMacConst.C_TERRITORY_CD4;
                            break;
                    }
                    // 店舗区分 
                    switch (System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TENPO_KBN].Value))
                    {
                        // 地区本部 
                        case KKHMacConst.C_TENPO_KBN_NM1:
                            updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD1;
                            break;
                        // MC直営 
                        case KKHMacConst.C_TENPO_KBN_NM2:
                            updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD2;
                            break;
                        // ライセンシー 
                        case KKHMacConst.C_TENPO_KBN_NM3:
                            updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD3;
                            break;
                        // その他 
                        case KKHMacConst.C_TENPO_KBN_NM4:
                            updTbl[updTbl.Rows.Count - 1].Column4 = KKHMacConst.C_TENPO_KBN_CD4;
                            break;
                    }
                    // 勘定科目 
                    updTbl[updTbl.Rows.Count - 1].Column5 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_KAMOKU_CD].Value);
                    // 郵便番号 
                    updTbl[updTbl.Rows.Count - 1].Column6 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_YUBIN_NO].Value);
                    // 住所１ 
                    updTbl[updTbl.Rows.Count - 1].Column7 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_ADDRESS1].Value);
                    // 住所２ 
                    updTbl[updTbl.Rows.Count - 1].Column8 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_ADDRESS2].Value);
                    // 電話番号 
                    updTbl[updTbl.Rows.Count - 1].Column9 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TEL_NO].Value);
                    // 明細行フラグ 
                    switch (System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_SPLIT_FLG].Value))
                    {
                        // 分割する 
                        case KKHMacConst.C_SPLIT_FLG_NM1:
                            updTbl[updTbl.Rows.Count - 1].Column10 = KKHMacConst.C_SPLIT_FLG_CD1;
                            break;
                        // 分割しない 
                        case KKHMacConst.C_SPLIT_FLG_NM2:
                            updTbl[updTbl.Rows.Count - 1].Column10 = KKHMacConst.C_SPLIT_FLG_CD2;
                            break;
                    }
                    // ライセンシー 
                    updTbl[updTbl.Rows.Count - 1].Column11 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_COMPANY_NM].Value);
                    // 代表者名 
                    updTbl[updTbl.Rows.Count - 1].Column12 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_NAME].Value);
                    // 取引先コード 
                    updTbl[updTbl.Rows.Count - 1].Column13 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_TORIHIKISAKI_CD].Value);
                    //初期G.OPEN年月日
                    updTbl[updTbl.Rows.Count - 1].Column15 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_SHOKIGOPEN].Value);
                    //G.OPEN年月日
                    updTbl[updTbl.Rows.Count - 1].Column16 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_GOPEN].Value);
                    //G.CLOSE年月日
                    updTbl[updTbl.Rows.Count - 1].Column17 = System.Convert.ToString(spdMasMainte.Sheets[0].Cells[j, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE].Value);

                }
            }

            // 更新 
            MasterMaintenanceMacProcessController masterMaintenanceMacProcessController 
                = MasterMaintenanceMacProcessController.GetInstance();
            Isid.KKH.Mac.ProcessController.MasterMaintenance.RegisterMacMasterServiceResult result 
                = masterMaintenanceMacProcessController.RegisterMasterResult(mstInNaviPrm.strEsqId,
                                                                              C_APL_ID,
                                                                              mstInNaviPrm.strEgcd,
                                                                              mstInNaviPrm.strTksKgyCd,
                                                                              mstInNaviPrm.strTksBmnSeqNo,
                                                                              mstInNaviPrm.strTksTntSeqNo,
                                                                              mstInNaviPrm.strMasterKey,
                                                                              mstInNaviPrm.strFilterValue,
                                                                              updTbl,
                                                                              maxupdate);

            // オペレーションログの出力.
            KKHLogUtilityMac.WriteOperationLogToDB(mstInNaviPrm, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_MastMerge, KKHLogUtilityMac.DESC_OPERATION_LOG_MastMerge);

            base.CloseLoadingDialog();
            // マスタメンテナンス画面に戻る 
            Navigator.Backward(this, true, null, true);
            this.Close();
            Cursor.Current = Cursors.Default;
            MessageUtility.ShowMessageBox(MessageCode.HB_I0006, null, C_APL_NM, MessageBoxButtons.OK);
            //MoveColumn(true);
        }

        /// <summary>
        /// 画面遷移時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastMergeMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                mstInNaviPrm = (MastInputNaviParameter)arg.NaviParameter;
            }

        }

        /// <summary>
        /// セルクリック時イベント（全選択否） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column.Equals(0)  && e.RowHeader.Equals(false))
            {
                // 変更対象否 
                if (blnAllChk.Equals(false))
                {
                    blnAllChk = true;
                }
                else
                {
                    blnAllChk = false;
                }
                for (int intRow = 0; intRow < spdMasMainte.Sheets[0].Rows.Count; intRow++)
                {
                    spdMasMainte.Sheets[0].Cells[intRow, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value = blnAllChk;
                }
            }
        }

        /// <summary>
        /// ヘルプボタンクリック時イベント  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = mstInNaviPrm.strTksKgyCd + mstInNaviPrm.strTksBmnSeqNo + mstInNaviPrm.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }

        #endregion 

        #region "メソッド"

        /// <summary>
        /// 最終更新日取得 
        /// </summary>
        /// <param name="result"></param>
        private void updateMaxfind(FindMasterMaintenanceByCondServiceResult result)
        {
            if (result.MasterDataSet.MasterDataVO.Rows.Count == 0)
            {
                //初期値の設定 
                maxupdate = DateTime.Parse("1000/01/01 01:01:01");
            }
            for (int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++)
            {

                if (maxupdate == DateTime.Parse("1000/01/01 01:01:01"))
                {
                    maxupdate = result.MasterDataSet.MasterDataVO[i].updTimStmp;
                }


                if (DateTime.Compare(result.MasterDataSet.MasterDataVO[i].updTimStmp, maxupdate) > 0)
                {
                    maxupdate = result.MasterDataSet.MasterDataVO[i].updTimStmp;
                }
            }
        }

        /// <summary>
        /// ステータス妥当性チェック 
        /// </summary>
        /// <returns></returns>
        protected bool StatusChk()
        {
            for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
            {
                //取込時のステータスから変更していない場合はOK
                if (!spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value.Equals(spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Value))
                {
                    //変更→削除のみOK
                    if (spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value.Equals(KKHMacConst.C_INPUT_STAT_DEL))
                    {
                        if (!spdMasMainte_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Value.Equals(KKHMacConst.C_INPUT_STAT_EDIT)) { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        /// <summary>
        /// 必須項目入力チェック 
        /// </summary>
        /// <returns></returns>
        protected bool NrChk()
        {
            MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + KKHMacConst.C_MAST_TENPO_CD + "'");
            foreach (MasterMaintenance.MasterItemVORow row in itemrow)
            {
                //if (row.field18.Equals("1"))
                if (row.field8.Equals("1"))
                {
                    for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                    {
                        //チェックが入っている行のみ入力チェック
                        if (spdMasMainte_Sheet1.Cells[i, 0].Value.ToString().Equals("True"))
                        {
                            //if (string.IsNullOrEmpty(Isid.KKH.Common.KKHUtility.KKHUtility.ToString(spdMasMainte_Sheet1.Cells[i, Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.field2) + 2].Value))) { return false; }
                            if (int.Parse(row.field2) < 26)
                            {
                                //初期G.OPEN年月日までの列はfield2+2の列を参照
                                if (string.IsNullOrEmpty(Isid.KKH.Common.KKHUtility.KKHUtility.ToString(spdMasMainte_Sheet1.Cells[i, Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.field2) + 2].Value)))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                //初期G.OPEN年月日以降の列はfield2+1の列を参照
                                if (string.IsNullOrEmpty(Isid.KKH.Common.KKHUtility.KKHUtility.ToString(spdMasMainte_Sheet1.Cells[i, Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.field2) + 1].Value)))
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// 最大最低入力文字チェック 
        /// </summary>
        /// <returns></returns>
        protected bool MaxMinInputCheck()
        {
            //スプレッド最終行 
            int Count = spdMasMainte_Sheet1.Rows.Count;
            MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + KKHMacConst.C_MAST_TENPO_CD + "'");
            foreach (MasterMaintenance.MasterItemVORow row in itemrow)
            {
                //最大文字数 
                if (!string.IsNullOrEmpty(row.field6))
                {
                    for (int j = 0; j < Count; j++)
                    {
                        if (!spdMasMainte_Sheet1.Cells[j, 26].Text.Equals(KKHMacConst.C_INPUT_STAT_DEL))
                        {
                            if (spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2) + 2].Text.ToString().Length > long.Parse(row.field6))
                            {
                                int jnum = j + 1;
                                MoveColumn(true);
                                base.CloseLoadingDialog();
                                string[] comment1 = new string[] { row.field3, jnum.ToString(), row.field6 };
                                //MessageBox.Show(row.field3 + "の" + (j+1) + "行目の値は" + row.field6 + "文字以内です。");
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0092, 
                                    comment1, "マスタメンテナンス", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                    }
                }

                //最低文字数 
                if (!string.IsNullOrEmpty(row.field7))
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (!spdMasMainte_Sheet1.Cells[i, 26].Text.Equals(KKHMacConst.C_INPUT_STAT_DEL))
                        {
                            if (spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2) + 2].Text.ToString().Length < long.Parse(row.field7))
                            {
                                int inum = i + 1;
                                MoveColumn(true);
                                base.CloseLoadingDialog();
                                string[] comment2 = new string[] { row.field3, inum.ToString(), row.field7 };
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0093, 
                                    comment2, "マスタメンテナンス", MessageBoxButtons.OK);
                                //MessageBox.Show(row.field3 + "の" + (i+1) + "行目の値は" + row.field7 + "文字以上必要です");
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// マック用にスプレッドを設定する。 
        /// </summary>
        private void SpreadSettingByMac()
        {
            // **************************************************
            // **************** スプレッド設定 ******************
            // **************************************************
            this.SpreadSetting();
            // チェックボックス欄生成 
            spdMasMainte.Sheets[0].Columns.Add(KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX, 1);
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Label = " ";
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Width = 50;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].AllowAutoFilter = true;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].AllowAutoSort = true;
            for (int x = 0; x < spdMasMainte.Sheets[0].Rows.Count; x++)
            {
                spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value = false;
            }
            //// 表示用ステータス欄生成
            //List<string> lstValues = new List<string>();
            //lstValues.Add(KKHMacConst.C_INPUT_STAT_DEL);
            //lstValues.Add(KKHMacConst.C_INPUT_STAT_NEW);
            //lstValues.Add(KKHMacConst.C_INPUT_STAT_EDIT);
            //lstValues.Add(KKHMacConst.C_INPUT_STAT_OVER);
            //lstValues.Add(KKHMacConst.C_INPUT_STAT_NONE);
            //string[] iteminputstatus = lstValues.ToArray();

            spdMasMainte.Sheets[0].Columns.Add(KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS, 1);
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            //FarPoint.Win.Spread.CellType.ComboBoxCellType type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            //type.ItemData = iteminputstatus;
            //type.Items = iteminputstatus;
            //type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            //type.Editable = false;
            //spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].CellType = type;

            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Label = "ステータス";
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Width = 60;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Locked = true;
            //spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Locked = false;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].AllowAutoFilter = true;
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].AllowAutoSort = true;
            for (int x = 0; x < spdMasMainte.Sheets[0].Rows.Count; x++)
            {
                // ステータスが"重複"以外 
                //if (!spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Text.ToString().Equals(KKHMacConst.C_INPUT_STAT_OVER)
                //    && !spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Text.ToString().Equals(KKHMacConst.C_INPUT_STAT_DEL))
                if (!spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Text.ToString().Equals(KKHMacConst.C_INPUT_STAT_OVER))
                {
                    string strTenpoCd = string.Empty;
                    int chkCnt = 1;
                    strTenpoCd = spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value.ToString();
                    MasterMaintenance.MasterDataVORow[] mstDataRow = (MasterMaintenance.MasterDataVORow[])mstInNaviPrm.dsMerge.Select("Column1 = '" + strTenpoCd + "'");
                    // レコードが2行以上有る場合 
                    if (mstDataRow.Length >= 2)
                    {
                        spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value = KKHMacConst.C_INPUT_STAT_OVER;

                        for (int intRow = x+1; intRow < spdMasMainte.Sheets[0].Rows.Count; intRow++)
                        {
                            if (spdMasMainte.Sheets[0].Cells[intRow, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value.ToString() == strTenpoCd)
                            {
                                // ステータス設定 
                                spdMasMainte.Sheets[0].Cells[intRow, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value = KKHMacConst.C_INPUT_STAT_OVER;
                                chkCnt++;
                                if (chkCnt == mstDataRow.Length)
                                {
                                    break;
                                }
                            }
                            intRow++;
                        }
                    }
                    else
                    {
                        spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value = spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Value;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value.ToString()))
                    {
                        spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Value = spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_IN_STATUS].Value;
                    }
                }
            }
            // 差分なしデータ確認 
            for (int x = 0; x < spdMasMainte.Sheets[0].Rows.Count; x++)
            {
                if (spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Text.ToString().Equals(KKHMacConst.C_INPUT_STAT_NONE))
                {
                    MasterMaintenance.MasterDataVORow dtRow = (MasterMaintenance.MasterDataVORow)mstInNaviPrm.dsMerge.Rows[x];
                    MasterMaintenance.MasterDataVORow dtColRow = (MasterMaintenance.MasterDataVORow)mstInNaviPrm.dsMergeColor.Rows[x];
                    mstInNaviPrm.dsMerge.RemoveMasterDataVORow(dtRow);
                    mstInNaviPrm.dsMergeColor.RemoveMasterDataVORow(dtColRow);
                    x = x - 1;
                }
            }

            this.CheckSpreadColor();
            spdMasMainte.Sheets[0].Columns[KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Locked = true;
            spdMasMainte_Sheet1.ColumnHeader.Rows[0].Height = 30;


            // 表示用ステータス欄再設定
            List<string> lstValues = new List<string>();
            lstValues.Add(KKHMacConst.C_INPUT_STAT_EDIT);
            lstValues.Add(KKHMacConst.C_INPUT_STAT_DEL);
            string[] iteminputstatus = lstValues.ToArray();

            for (int x = 0; x < spdMasMainte.Sheets[0].Rows.Count; x++)
            {
                if (spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Text.ToString().Equals(KKHMacConst.C_INPUT_STAT_EDIT))
                {
                    FarPoint.Win.Spread.CellType.ComboBoxCellType type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    type.ItemData = iteminputstatus;
                    type.Items = iteminputstatus;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;
                    spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].CellType = type;
                    spdMasMainte.Sheets[0].Cells[x, KKHMacConst.C_INDEX_INPUTDATA_DISPLAY_STATUS].Locked = false;
                }
            }



        }

        /// <summary>
        /// スプレッド設定（色） 
        /// </summary>
        private void CheckSpreadColor()
        {
            for (int i = 0; i < spdMasMainte.Sheets[0].Rows.Count; i++)
            {

                MasterMaintenance.MasterDataVORow[] dtRows;
                dtRows = (MasterMaintenance.MasterDataVORow[])mstInNaviPrm.dsMergeColor.Select("Column15 = '" + spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].Value + "'");

                if (dtRows[0].Column14.Equals(KKHMacConst.C_INPUT_STAT_EDIT))
                {
                    if (dtRows[0].Column1.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TENPO_CD].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column2.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TENPO_NM].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column3.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TERRITORY].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column4.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TENPO_KBN].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column5.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_KAMOKU_CD].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column6.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_YUBIN_NO].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column7.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_ADDRESS1].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column8.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_ADDRESS2].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column9.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TEL_NO].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column10.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_SPLIT_FLG].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column11.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_COMPANY_NM].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column12.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_NAME].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column13.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_TORIHIKISAKI_CD].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column16.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_SHOKIGOPEN].BackColor = ChkOutColor;
                    } 
                    if (dtRows[0].Column17.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_GOPEN].BackColor = ChkOutColor;
                    }
                    if (dtRows[0].Column18.Equals(KKHMacConst.C_CHECK_TRUE))
                    {
                        spdMasMainte.Sheets[0].Cells[i, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE].BackColor = ChkOutColor;
                    }
                }
            }           
        }

        /// <summary>
        /// スプレッドの設定 
        /// </summary>
        protected virtual void SpreadSetting()
        {
            //カラススタートインデックス 
            int ColIndex = 11;
            //行カウント 
            int RowCount = spdMasMainte_Sheet1.Rows.Count;
            //スプレッド初期化 
            for (int j = 0; j < SpColNum; j++)
            {
                spdMasMainte.Sheets[0].Columns[j].Visible = false;
                spdMasMainte.Sheets[0].Columns[j].Label = null;
                spdMasMainte.Sheets[0].Columns[j].BackColor = Color.White;
            }

            MasterMaintenance.MasterItemVORow[] resultrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + KKHMacConst.C_MAST_TENPO_CD + "'");
            foreach (MasterMaintenance.MasterItemVORow row in resultrow)
            {
                //列名 
                spdMasMainte_Sheet1.Columns[ColIndex].Label = row.field3;
                //表示 
                spdMasMainte_Sheet1.Columns[ColIndex].Visible = true;
                //列幅 
                spdMasMainte_Sheet1.Columns[ColIndex].Width = float.Parse(row.field9);

                //******************
                //セル内の文字位置 
                //******************
                //垂直方向 
                spdMasMainte_Sheet1.Columns[ColIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                //水平方向 
                switch (row.field1)
                {
                    case "0"://右寄せ 
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        break;
                    case "1"://左寄せ 
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        break;
                    case "2"://中央寄せ 
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        break;
                }

                //*************
                //セルType 
                //*************
                switch (row.field5)
                {
                    //**********************
                    //     テキストタイプ 
                    //**********************
                    case "0":
                        FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = txtyp;
                        //最大文字数 
                        txtyp.MaxLength = int.Parse(row.field6);

                        //半角 
                        if (!string.IsNullOrEmpty(row.field15))
                        {
                            switch (row.field15)
                            {
                                case "1"://英数字のみ 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    break;
                                case "2"://数字のみ 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    break;
                            }
                        }

                        //一時処理
                        for (int j = 0; j < RowCount; j++)
                        {
                            if (int.Parse(row.field2) == 26 || int.Parse(row.field2) == 27 || int.Parse(row.field2) == 28)
                            {
                                spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2) - 1].Value = spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Value.ToString();
                            }
                        }
                        //一時処理
                        
                        break;

                    //**********************
                    //     数値タイプ 
                    //********************** 
                    case "1":
                        FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = numtyp;

                        numtyp.DecimalPlaces = 0;

                        //最大値、最小値の設定 
                        if (!string.IsNullOrEmpty(row.field13))
                        {
                            numtyp.MaximumValue = long.Parse(row.field13);
                        }
                        if (!string.IsNullOrEmpty(row.field14))
                        {
                            numtyp.MinimumValue = long.Parse(row.field14);
                        }
                        break;

                    //**********************
                    //     コンボタイプ 
                    //********************** 
                    case "2":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbtyp.Items = row.field20.Split(',');
                        cmbtyp.ItemData = row.field19.Split(',');
                        string[] nykfk = row.field18.Split(',');
                        bool flg = false;

                        for (int i = 0; i < RowCount; i++)
                        {
                            flg = false;
                            for (int k = 0; k < cmbtyp.ItemData.Length; k++)
                            {
                                if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[k]))
                                {
                                    spdMasMainte_Sheet1.Cells[i, ColIndex].Value = cmbtyp.Items[k];
                                    flg = true;
                                }
                            }

                            if (!flg) { spdMasMainte_Sheet1.Cells[i, ColIndex].Value = '0'; }
                        }

                        //入力不可対象をロックする 
                        if (row.field12.Equals("1"))
                        {
                            spdMasMainte_Sheet1.Columns[ColIndex].BackColor = Color.Black;
                            spdMasMainte_Sheet1.Columns[ColIndex].Locked = true;

                            //入力不可対象外を使用可能にする 
                            for (int n = 0; n < nykfk.Length; n++)
                            {
                                for (int j = 0; j < RowCount; j++)
                                {
                                    if (spdMasMainte_Sheet1.Cells[j, (int)Math.Truncate(double.Parse(row.intValue1))].Value.Equals(nykfk[n]))
                                    {
                                        spdMasMainte_Sheet1.Cells[j, ColIndex].BackColor = Color.White;
                                        spdMasMainte_Sheet1.Cells[j, ColIndex].Locked = false;
                                    }
                                }
                            }

                        }


                        //typeの変換 
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = cmbtyp;
                        break;

                    //**************************
                    //  チェックボックスタイプ 
                    //**************************
                    case "3":
                        FarPoint.Win.Spread.CellType.CheckBoxCellType chktyp = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = chktyp;


                        for (int j = 0; j < RowCount; j++)
                        {
                            if (spdMasMainte_Sheet1.Cells[j, ColIndex].Value.Equals("true"))
                            {
                                spdMasMainte_Sheet1.Cells[j, ColIndex].Value = true;
                            }
                            else if (spdMasMainte_Sheet1.Cells[j, ColIndex].Value.Equals("false"))
                            {
                                spdMasMainte_Sheet1.Cells[j, ColIndex].Value = false;
                            }
                        }
                        break;

                    //**************************
                    //       日付タイプ  
                    //**************************
                    case "4":
                        FarPoint.Win.Spread.CellType.DateTimeCellType datetyp = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                        for (int j = 0; j < RowCount; j++)
                        {
                            //文字列からDateTime型へ変換(YYYY/MM/DD形式)  
                            spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2)-1].Value
                                = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Text).ToString("yyyy/M/d");
                            //spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2)].Value
                            //    = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            spdMasMainte_Sheet1.Columns[ColIndex].CellType = datetyp;
                        }
                        break;
                }

                //表示非表示の切り替え 
                double enableFlg = Math.Truncate(double.Parse(row.intValue2));
                switch (enableFlg.ToString())
                {
                    case "0":
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = false;
                        break;
                    case "1":
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = true;
                        break;
                    default:
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = false;
                        break;
                }
                ColIndex++;
            }
        }

        /// <summary>
        /// スプレッド移動 
        /// </summary>
        /// <param name="Flg">True:前へFalse:後ろへ</param>
        private void MoveColumn(bool Flg)
        {
            if (Flg)
            {
                //[初期G.OPEN年月日][G.OPEN年月日][G.CLOSE年月日]列を[ステータス]列の後ろに移動する 
                spdMasMainte_Sheet1.MoveColumn(KKHMacConst.C_INDEX_INPUTDATA_SHOKIGOPEN, 2, true);
                spdMasMainte_Sheet1.MoveColumn(KKHMacConst.C_INDEX_INPUTDATA_GOPEN, 3, true);
                spdMasMainte_Sheet1.MoveColumn(KKHMacConst.C_INDEX_INPUTDATA_GCLOSE, 4, true);
            }
            else
            {
                //[初期G.OPEN年月日][G.OPEN年月日][G.CLOSE年月日]列を[ステータス]列の後ろに移動する 
                //spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE, true);
                //spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_GOPEN, true);
                //spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_SHOKIGOPEN, true);
                spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE, true);
                spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE, true);
                spdMasMainte_Sheet1.MoveColumn(2, KKHMacConst.C_INDEX_INPUTDATA_GCLOSE, true);
            }
        }

        #endregion

    }
}
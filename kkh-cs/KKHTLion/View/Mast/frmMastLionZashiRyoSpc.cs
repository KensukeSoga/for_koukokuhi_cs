using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.View.Mast
{
    /// <summary>
    /// 系列局金額マスターメンテナンス画面.
    /// </summary>
    public partial class frmMastLionZashiRyoSpc : KKHForm
    {

        # region メンバ変数.

        /// <summary>
        /// ライオンマスタNaviパラメータ.
        /// </summary>
        private frmMastLionNaviParameter _naviParameter = new frmMastLionNaviParameter();

        /// <summary>
        /// 汎用コードマスタ検索サービス結果.
        /// </summary>
        private FindMasterMaintenanceByCondServiceResult mstDtSet = new FindMasterMaintenanceByCondServiceResult();

        # endregion

        #region メンバ定数.

        /* カラムインデックス(定数) */

        /// <summary>
        /// スペース.
        /// </summary>
        private const int COLIDX_1 = 0;
        /// <summary>
        /// チェックボックス.
        /// </summary>
        private const int COLIDX_2 = 1;
        /// <summary>
        /// 実施料.
        /// </summary>
        private const int COLIDX_3 = 2;
        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>
        private const int COLIDX_4 = 3;
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        private const int COLIDX_5 = 4;
        /// <summary>
        /// 登録担当者.
        /// </summary>
        private const int COLIDX_6 = 5;
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        private const int COLIDX_7 = 6;
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        private const int COLIDX_8 = 7;
        /// <summary>
        /// 更新担当者.
        /// </summary>
        private const int COLIDX_9 = 8;
        /// <summary>
        /// 営業所（取）コード.
        /// </summary>
        private const int COLIDX_10 = 9;
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        private const int COLIDX_11 = 10;
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        private const int COLIDX_12 = 11;
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        private const int COLIDX_13 = 12;

        /// <summary>
        /// フィルタをかける値.
        /// </summary>
        protected string _filterValue = string.Empty;

        //現在日付時刻セット.
        DateTime dtNow = DateTime.Now;

        /// <summary>
        /// 編集した後更新したかを判断するフラグ(True:更新していない、False:更新した).
        /// </summary>
        protected bool upchk = false;

        #endregion

        # region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public frmMastLionZashiRyoSpc()
        {
            InitializeComponent();
        }

        # endregion

        # region イベント.

        /// <summary>
        /// フォームProcessAffterNavigatingイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void MastLionZashiRyoSpc_ProcessAfterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is frmMastLionNaviParameter)
            {
                _naviParameter = (frmMastLionNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>1
        private void frmMastLionZashiRyoSpc_Load(object sender, EventArgs e)
        {
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.MastLionZashiRyoSpcParam param = new Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.MastLionZashiRyoSpcParam();
            param.esqId = _naviParameter.strEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;

            // ステータスの初期化.
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            String cd = _naviParameter.Cd;
            String name = _naviParameter.Name;

            //実行.
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController processController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            MastLionZashiRyoSpcServiceResult result = processController.MastLionZashiRyoSpcService(cd, name, param);

            this.label4.Text = cd;
            this.label5.Text = "： " + name;
            this.kkhSpread1_Sheet1.RowCount = result.MZLionDataSet.MastZashi.Count;
            for (int i = 0; i < result.MZLionDataSet.MastZashi.Count; i++)
            {
                kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = result.MZLionDataSet.MastZashi[i].Val1;
                if (result.MZLionDataSet.MastZashi[i].Val2 == "1")
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = "True";
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Value = result.MZLionDataSet.MastZashi[i].Val3;
                }
                else
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = "0";
                }
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 削除ボタン押下時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            // 削除確認.
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0006,
                null,
                "マスターメンテナンス",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.ActiveControl = null;
                return;
            }

            int row = kkhSpread1_Sheet1.ActiveRowIndex;
            for (int i = row + 1 ; i < kkhSpread1_Sheet1.RowCount ; i++)
            {
                kkhSpread1_Sheet1.Cells[i - 1, COLIDX_1].Text = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
                kkhSpread1_Sheet1.Cells[i - 1, COLIDX_2].Text = kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text;
                kkhSpread1_Sheet1.Cells[i - 1, COLIDX_3].Text = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;                
            }

            this.kkhSpread1_Sheet1.RowCount = kkhSpread1_Sheet1.RowCount - 1;
        }

        /// <summary>
        /// 更新ボタン押下時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDate_Click(object sender, EventArgs e)
        {
            // 更新確認.
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0005,
                null,
                "マスターメンテナンス",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 更新用データテーブル.
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            MasterMaintenance.MasterDataVODataTable mstdatavo = new MasterMaintenance.MasterDataVODataTable();
            
            int cnt = 0;
            String Sybt = "703";

            for (int i = 0; i < kkhSpread1_Sheet1.RowCount; i++)
            {
                if (kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text == "True")
                {
                    String strrykn = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;
                    String[] aryrykn = strrykn.Split(',');
                    String rykn = "";
                    for (int j = 0 ; j < aryrykn.Length ; j++)
                    {
                        rykn = rykn + aryrykn[j];
                    }

                    //データVOを生成. 
                    mstdatavo.AddMasterDataVORow(mstdatavo.NewMasterDataVORow());

                    //データセット.
                    mstdatavo.Rows[cnt][mstdatavo.trkTimStmpColumn] = dtNow;
                    mstdatavo.Rows[cnt][mstdatavo.trkPlColumn] = KKHLionConst.C_TRKPL;
                    mstdatavo.Rows[cnt][mstdatavo.trkTntColumn] = _naviParameter.strEsqId;
                    mstdatavo.Rows[cnt][mstdatavo.updTimStmpColumn] = dtNow;
                    mstdatavo.Rows[cnt][mstdatavo.updaPlColumn] = KKHLionConst.C_TRKPL;
                    mstdatavo.Rows[cnt][mstdatavo.updTntColumn] = _naviParameter.strEsqId;
                    mstdatavo.Rows[cnt][mstdatavo.egCdColumn] = _naviParameter.strEgcd;
                    mstdatavo.Rows[cnt][mstdatavo.tksKgyCdColumn] = _naviParameter.strTksKgyCd;
                    mstdatavo.Rows[cnt][mstdatavo.tksBmnSeqNoColumn] = _naviParameter.strTksBmnSeqNo;
                    mstdatavo.Rows[cnt][mstdatavo.tksTntSeqNoColumn] = _naviParameter.strTksTntSeqNo;
                    mstdatavo.Rows[cnt][mstdatavo.sybtColumn] = "703";
                    mstdatavo.Rows[cnt][mstdatavo.Column1Column] = _naviParameter.Cd;
                    mstdatavo.Rows[cnt][mstdatavo.Column2Column] = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
                    mstdatavo.Rows[cnt][mstdatavo.Column3Column] = "1";
                    mstdatavo.Rows[cnt][mstdatavo.Column4Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column5Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column6Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column7Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column8Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column9Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column10Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column11Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column12Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column13Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column14Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column15Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column16Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column17Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column18Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column19Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column20Column] = "";
                    mstdatavo.Rows[cnt][mstdatavo.Column21Column] = rykn;
                    mstdatavo.Rows[cnt][mstdatavo.Column22Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column23Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column24Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column25Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column26Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column27Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column28Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column29Column] = "0";
                    mstdatavo.Rows[cnt][mstdatavo.Column30Column] = "0";
                    cnt++;
                }
            }

            // 更新処理.
            MastLionZashiRyoSpcServiceResult result = masterMaintenanceProcessController.InsertMastLionZashiRyoSpcService(_naviParameter.strEsqId,
                                                                                                                          _naviParameter.AplId,
                                                                                                                          _naviParameter.strEgcd,
                                                                                                                          _naviParameter.strTksKgyCd,
                                                                                                                          _naviParameter.strTksBmnSeqNo,
                                                                                                                          _naviParameter.strTksTntSeqNo,
                                                                                                                          Sybt,
                                                                                                                          _naviParameter.Cd,
                                                                                                                          _naviParameter.strMasterKey,
                                                                                                                          _naviParameter.strFilterValue,
                                                                                                                          mstdatavo,
                                                                                                                          dtNow);
            upchk = false;

            // 登録完了.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0002, null, "マスターメンテナンス", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 再表示ボタン押下時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void S_Hyoji_Click(object sender, EventArgs e)
        {
            if (upchk)
            {
                //未更新の場合.
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, 
                    null, "マスターメンテナンス", MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                {
                    this.ActiveControl = null;
                    return;
                }
            }

            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.MastLionZashiRyoSpcParam param = new Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.MastLionZashiRyoSpcParam();
            param.esqId = _naviParameter.strEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;

            String cd = _naviParameter.Cd;
            String name = _naviParameter.Name;

            //実行.
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController processController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            MastLionZashiRyoSpcServiceResult result = processController.MastLionZashiRyoSpcService(cd, name, param);

            this.label4.Text = cd;
            this.label5.Text = "： " + name;
            this.kkhSpread1_Sheet1.RowCount = result.MZLionDataSet.MastZashi.Count;
            for (int i = 0; i < result.MZLionDataSet.MastZashi.Count; i++)
            {
                //this.Refresh();
                kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = result.MZLionDataSet.MastZashi[i].Val1;
                if (result.MZLionDataSet.MastZashi[i].Val2 == "1")
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = "True";
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Value = result.MZLionDataSet.MastZashi[i].Val3;
                }
                else
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = "false";
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = "0";
                }
            }

            upchk = false;

            //コントロールを未選択状態に設定.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 戻るボタン押下時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (upchk)
            {
                //未更新の場合.
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032,
                    null, "マスターメンテナンス", MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                {
                    this.ActiveControl = null;
                    return;
                }
            }
            //KKHNaviParameter naviParam = new KKHNaviParameter();
            //naviParam.strEsqId = _naviParameter.strEsqId;
            //naviParam.AplId = _naviParameter.AplId;
            //naviParam.strEgcd = _naviParameter.strEgcd;
            //naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            //naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            //naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            //naviParam.strMasterKey = _naviParameter.strMasterKey;
            //naviParam.strFilterValue = _naviParameter.strFilterValue;

            Navigator.Backward(this, null, null, true);
            //Navigator.Backward(this, null, naviParam, true);
            this.Close();
        }
        
        /// <summary>
        /// スプレッド変更時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            for (int i = 0 ; i < kkhSpread1_Sheet1.RowCount ; i++)
            {
                if (kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text == "")
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = "0";
                }
            }

            // [実施料]列の場合.
            if (e.Column == COLIDX_3)
            {
                upchk = true;
            }
        }

        /// <summary>
        /// ヘルプボタンクリック処理時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            // ヘルプ実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
            //HlpClick();
            //KKHHelpLion.ShowHelpLion(this, this.Name);
        }

        # endregion
        
        # region メソッド.

        /// <summary>
        /// ヘルプ実行処理.
        /// </summary>
        private void HlpClick()
        {
         
            //exeファイルのフォルダパスを取得.
            //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ////ヘルプファイルを表示.
            ////Help.ShowHelp(this, System.IO.Path.Combine(path, "KKH_Help_Sample3.chm"));
            //System.Windows.Forms.Help.ShowHelp(this, System.IO.Path.Combine(path, "KKH_Help_Lion.chm"), HelpNavigator.Topic, @"_RESOURCE\広告費明細登録画面_選択統合.htm");
        }

        # endregion
    }
}

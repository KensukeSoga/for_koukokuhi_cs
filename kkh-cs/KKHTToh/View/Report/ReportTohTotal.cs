using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Toh.Utility;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using System.Collections;
using Isid.KKH.Toh.Schema;
using Isid.KKH.Toh.ProcessController;

namespace Isid.KKH.Toh.View.Report
{
    public partial class ReportTohTotal : KKHForm
    {
        # region メンバ変数

        /// <summary>
        /// 呼び出しパラメータ(受取) 
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// コピーマクロ削除用string 
        /// </summary>
        private string _strmacrodel;

        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// 保持用データセット.
        /// </summary>
        private DataSet tohds = null;

        # endregion

        # region 定数

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "TohTotal_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "TohTotal_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "TohTotal_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "TohTotal_Mcr.xlsm";
        /// <summary>
        /// テーブル名.
        /// </summary>
        private static readonly string TABLENAME = "ReptohTotal";
        /// <summary>
        /// 媒体列位置 
        /// </summary>
        private static readonly int BAITAI_ROW = 0;
        /// <summary>
        /// 項目列位置 
        /// </summary>
        private static readonly int KOUMOKU_ROW = 1;
        /// <summary>
        /// 月列位置（１月） 
        /// </summary>
        private static readonly int MONTH_JAN_ROW = 2;
        /// <summary>
        /// 総計列位置 
        /// </summary>
        private static readonly int SUM_ROW = MONTH_JAN_ROW + 12;
        /// <summary>
        /// 金額フォーマット 
        /// </summary>
        private static readonly string KIN_FORMAT = "{0:C}";
        /// <summary>
        /// 段数フォーマット 
        /// </summary>
        private static readonly string DAN_FORMAT = "{0:0.00}";
        /// <summary>
        /// 枠数フォーマット 
        /// </summary>
        private static readonly string WAK_FORMAT = "{0:0.00}";
        /// <summary>
        /// 金額最低幅 
        /// </summary>
        private static readonly int KIN_MIN_WIDTH = 40;
        /// <summary>
        /// REP_KEY_SYBT：002
        /// </summary>
        private const string REP_KEY_SYBT = "002";
        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "Total";
        # endregion

        # region コンストラクタ
        
        /// <summary>
        /// 初期処理 
        /// </summary>
        public ReportTohTotal()
        {
            InitializeComponent();
        }

        # endregion

        # region イベント
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //*************************************
            // レコード取得.
            //*************************************
            this.GetRecord();

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();
            //日付とか 
            DateTime now = DateTime.Now;
            //はじめのファイル名を指定する 
            //sfd.FileName = pStrRepFilNam + "(" + txtYyyy.Value + "年度)" + "_" + now.ToString("yyyyMMdd") + ".xls";
            ////sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            sfd.FileName = pStrRepFilNam + "(" + txtYyyy.Value + "年度)" + "_" + now.ToString("yyyyMMdd") + ".xlsx";
            //はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = pStrRepAdrs;
            //[ファイルの種類]に表示される選択肢を指定する 
            //sfd.Filter = "XLSファイル(*.xls)|*.xls";
            ////sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            //[ファイルの種類]ではじめに 
            //「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;
            //タイトルを設定する 
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            //ダイアログを表示する 
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //出力先に同名のExcelファイルが開いているかチェック 
                try
                {
                    //同名でファイルを削除する。 
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);

                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

            //選択状態を解除 
            this.ActiveControl = null;

            sfd.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {

            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);


                // マクロファイルの削除（VBA側では削除できない為） 
                // ファイルが存在しているか判断する 
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する 
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // ファイルを削除する 
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 初期処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //初期設定 
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
            //年月取得 
            String strDate = getHostDate();
            txtYyyy.Text = strDate.Substring(0, 4);

            //ステータス設定 
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //消費税取得（マスタから） 
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //テンプレートアドレス 
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //保存情報＋帳票名 
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            REP_KEY_SYBT);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット 
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット 
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //シート表示・非表示設定 
            dgvMain_Sheet1.Visible = true;
            //件数設定 
            statusStrip1.Items["tslval1"].Text = "0件";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード 
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;
        }
        # endregion

        # region メソッド
        /// <summary>
        /// CSVファイル作成メソッド.
        /// </summary>
        private void GetRecord()
        {

            //ローディング表示開始 
            base.ShowLoadingDialog();

            //納品区分 
            string nohinKbn;

            //********************
            //年月入力チェック 
            //********************
            //必須チェック 
            if (string.IsNullOrEmpty(txtYyyy.Text))
            {
                //エラーメッセージ(対象年月は必ず入力してください。)を表示 
                base.CloseLoadingDialog();//仮 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0056, null, "入力エラー", MessageBoxButtons.OK);
                txtYyyy.Focus();

                //ローディング表示終了 
                base.CloseLoadingDialog();
                
                return;
            }

            if (txtKbn.Text == "" 
                || txtKbn.Text == "1" 
                || txtKbn.Text == "2")
            {
                nohinKbn = txtKbn.Text.ToString();
            }
            else
            {
                //エラーとする 
                //ローディング表示終了 
                base.CloseLoadingDialog();

                // 件数表示を初期化 
                statusStrip1.Items["tslval1"].Text = "0件";

                //シートを0件にする 
                dgvMain_Sheet1.RowCount = 0;

                //[帳票出力]ボタン非活性  
                btnXls.Enabled = false;

                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //年度 
            string strYear = txtYyyy.Value.ToString();

            //実行 
            ReportTohProcessController processController = ReportTohProcessController.GetInstance();
            FindReportTohByCondServiceResult result = processController.FindRepTohTotalByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYear,
                                                                                      nohinKbn
                                                                                      );
            //データが存在しなければ終了 
            //if (result.dsRepTohDataSet.Tables[TABLENAME].Rows.Count == 0)
            if (result.dsRepTohDataSet.Tables[1].Rows.Count == 0)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                // 件数表示を初期化 
                statusStrip1.Items["tslval1"].Text = "0件";

                dgvMain_Sheet1.RowCount = 0;
                btnXls.Enabled = false;
                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            //データグリッド初期化 
            dgvMain_Sheet1.RowCount = 0;

            //データグリッド用変数
            int baitaiCnt = 0;          // 媒体カウント 
            int dataSetCnt = 0;         // データセットカウント 
            int setCol = 0;             // セルへの設定行位置 
            String codeNow = "";        // 現在データセットの媒体コード 
            String codeNext = "";       // 次データセットの媒体コード 
            double baitaiKinSum = 0;    // 媒体毎金額総計 
            double baitaiDanSum = 0;    // 媒体毎段数総計 
            double baitaiWakSum = 0;    // 媒体毎枠数総計 
            double[] monthKinSum = new double[13];  // 月毎金額総計 
            double[] monthDanSum = new double[13];  // 月毎段数総計 
            double[] monthWakSum = new double[13];  // 月毎枠数総計 
            //double tryCode = 0;             // 判定用コード 
            bool isChuoFlg = false;         // 中央紙フラグ 
            bool isMonthSumSetFlg = false;  // 月毎総計設定フラグ 

            //******************************
            // カウント取得処理 
            //******************************
            dataSetCnt = result.dsRepTohDataSet.Tables[TABLENAME].Rows.Count;

            // データセットから重複する媒体コードの件数を取得 
            for (int i = 0; i < dataSetCnt; i++)
            {
                // 現在媒体コード取得 
                codeNow = result.dsRepTohDataSet.ReptohTotal[i].code2.ToString();

                // 媒体コードがブランクの場合、半角スペースを入れる 
                if (codeNow == "")
                {
                    codeNow = " ";
                }

                // 現在と次の媒体コードが異なる場合、媒体カウントを増やす 
                if (codeNow != codeNext)
                {
                    //媒体コードを保持する 
                    codeNext = codeNow;
                    baitaiCnt++;
                }
            }

            codeNow = "";
            codeNext = "";

            for (int k = 0; k < 2; k++)
            {
                //****************************************
                // データグリッドに表示(件数分表示)  
                //****************************************
                for (int i = 0; i < dataSetCnt; i++)
                {
                    // 現在媒体コード取得 
                    codeNow = result.dsRepTohDataSet.ReptohTotal[i].code2.ToString();

                    // 媒体コードがブランクの場合、半角スペースを入れる 
                    if (codeNow == "")
                    {
                        codeNow = " ";
                    }
                    //****************************** 
                    // 次の媒体コードが異なる場合 
                    //******************************
                    if (codeNow != codeNext)
                    {
                        //if (i != 0)
                        //{
                        //    // データセットの読み込みが初回以外の場合、セルへの設定行位置をカウント 
                        //    setCol++;
                        //}

                        // 媒体コードが中央紙か判定 
                        //if (double.TryParse(codeNow, out tryCode))
                        //{

                        ////TODO:中央紙と地方紙の判定は仮のもの（とりあえずの条件として100000未満なら中央紙にしている） 
                        //// 媒体コードが数値 
                        //if (double.Parse(codeNow) < 100000)
                        //{
                        //    // 中央紙 
                        //    isChuoFlg = true;
                        //}
                        //先頭が0、かつ後尾が00または01の場合 
                        if (codeNow.Substring(0, 1) == "0"
                            && (codeNow.Substring(4, 2) == "00"
                               || codeNow.Substring(4, 2) == "01"))
                        {
                            // 中央紙 
                            isChuoFlg = true;
                        }
                        else if(codeNow == " ")
                        {
                            // 中央紙 
                            isChuoFlg = true;
                        }
                        else
                        {
                            // 地方紙 
                            isChuoFlg = false;

                            if (k == 1)
                            {
                                if (i == 0)
                                {
                                    //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                                    //　データの１件目が地方紙の場合、 
                                    //　月毎総計を表示しないよう、 
                                    //　月毎総計設定フラグを立てる 
                                    //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                                    isMonthSumSetFlg = true;
                                }

                                if (!isMonthSumSetFlg)
                                {
                                    //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                                    //　中央紙と地方紙の境目に１度だけ月毎の 
                                    //　総計を設定する 
                                    //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                                    isMonthSumSetFlg = this.setMonthSum(ref setCol, 
                                        ref monthKinSum, 
                                        ref monthDanSum, 
                                        ref monthWakSum);

                                    // 中央紙と地方紙の間の間隔を空ける 
                                    dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 3);
                                    // 行を加算(金額・段数・枠数文分カウント) 
                                    setCol += 2;
                                    //setCol = setCol + 2;
                                }
                            }
                            //}
                        }


                        // 総計初期化
                        baitaiKinSum = 0;
                        baitaiDanSum = 0;
                        baitaiWakSum = 0;

                        if ((isChuoFlg && k == 0) || (!isChuoFlg && k == 1))
                        {
                            if (i != 0)
                            {
                                // データセットの読み込みが初回以外の場合、セルへの設定行位置をカウント 
                                setCol++;
                            }

                            // 行を加算(金額・段数・枠数分カウント) 
                            dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 3);

                            //********************
                            // 媒体 
                            //********************
                            dgvMain_Sheet1.Cells[setCol * 3 , BAITAI_ROW].Value =
                                result.dsRepTohDataSet.ReptohTotal[i].name2.ToString();
                            dgvMain_Sheet1.Cells[setCol * 3 + 1, BAITAI_ROW].Value = "";

                            //********************
                            // 項目（金額・段数・枠数） 
                            //********************
                            dgvMain_Sheet1.Cells[setCol * 3, KOUMOKU_ROW].Value = "金額";
                            dgvMain_Sheet1.Cells[setCol * 3 + 1 , KOUMOKU_ROW].Value = "段数";
                            dgvMain_Sheet1.Cells[setCol * 3 + 2, KOUMOKU_ROW].Value = "枠数";

                            //********************
                            // 金額・段数・枠数（月毎） 
                            //********************
                            for (int j = MONTH_JAN_ROW; j < SUM_ROW; j++)
                            {
                                // 初期値：金額・段数・枠数に"-"を設定 
                                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, j].Value = "-";
                                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, j].Value = "-";
                                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 1, j].Value = "-";

                            }

                            // 媒体毎データ設定処理 
                            this.setBaitaiData(result, i, setCol, isChuoFlg,
                                ref baitaiKinSum, 
                                ref baitaiDanSum, 
                                ref baitaiWakSum, 
                                ref monthKinSum, 
                                ref monthDanSum, 
                                ref monthWakSum);
                        }
                    }
                    else
                    {
                        if ((isChuoFlg == true && k == 0) || (isChuoFlg == false && k == 1))
                        {
                            //******************************
                            // 次の媒体コードが同じ場合 
                            //******************************
                            //********************
                            // 金額・段数・枠数（月毎） 
                            //********************
                            this.setBaitaiData(result, i, setCol, isChuoFlg,
                                ref baitaiKinSum, 
                                ref baitaiDanSum, 
                                ref baitaiWakSum, 
                                ref monthKinSum, 
                                ref monthDanSum, 
                                ref monthWakSum);
                        }
                    }

                    //********************
                    // 媒体コード更新 
                    //********************
                    codeNext = codeNow;

                    if ((isChuoFlg == true && k == 0) || (isChuoFlg == false && k == 1))
                    {
                        //********************
                        // 総計更新(媒体毎) 
                        //********************
                        // 総計フォーマット 
                        dgvMain_Sheet1.Cells[setCol * 3, SUM_ROW].Value = string.Format(KIN_FORMAT, baitaiKinSum);
                        dgvMain_Sheet1.Cells[setCol * 3 + 1, SUM_ROW].Value = string.Format(DAN_FORMAT, baitaiDanSum);
                        dgvMain_Sheet1.Cells[setCol * 3 + 2, SUM_ROW].Value = string.Format(WAK_FORMAT, baitaiWakSum);
                    }
                }
            }

            if (!(isMonthSumSetFlg))
            {
                //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                //　地方紙のデータがない場合、 
                //　最後の行に月毎の総計を設定する 
                //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                isMonthSumSetFlg = this.setMonthSum(
                    ref setCol, 
                    ref monthKinSum, 
                    ref monthDanSum, 
                    ref monthWakSum);
            }

            //********************
            // 金額幅自動設定処理 
            //********************
            this.setAutoSize();

            // 保持用データセット 
            tohds = result.dsRepTohDataSet;

            btnXls.Enabled = true;
            //件数表示 
            statusStrip1.Items["tslval1"].Text = baitaiCnt + "件";

            //選択状態を解除 
            this.ActiveControl = null;

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// 媒体毎データ設定処理 
        /// </summary>
        /// <param name="result">データセット</param>
        /// <param name="i">データセットカウント</param>
        /// <param name="setCol">セルへの設定行位置</param>
        /// <param name="isChuoFlg">中央紙フラグ</param>
        /// <param name="baitaiKinSum">媒体毎金額合計</param>
        /// <param name="baitaiDanSum">媒体毎段数合計</param>
        /// <param name="baitaiWakSum">媒体毎枠数合計</param>
        /// <param name="monthKinSum">月毎金額総計</param>
        /// <param name="monthDanSum">月毎段数総計</param>
        /// <param name="monthWakSum">月毎枠数総計</param>
        private void setBaitaiData(FindReportTohByCondServiceResult result,
            int i, 
            int setCol, 
            bool isChuoFlg,
            ref double baitaiKinSum, 
            ref double baitaiDanSum,
            ref double baitaiWakSum,
            ref double[] monthKinSum, 
            ref double[] monthDanSum,
            ref double[] monthWakSum)
        {
            String sMonth = "";     // 月 
            int nMonthRow = 0;      // 月の列 
            double dKin = 0;        // 金額 
            String sDan = "";       // 段数(文字列) 
            double dDan = 0;        // 段数(数値) 
            String sWak = "";       // 枠数(文字列) 
            double dWak = 0;        // 枠数(数値) 
            //********************
            // 金額・段数・枠数（月毎） 
            //********************
            // 月取得 
            sMonth = result.dsRepTohDataSet.ReptohTotal[i].yymm.ToString().Substring(4);
            nMonthRow = MONTH_JAN_ROW + int.Parse(sMonth) - 1;

            // 金額取得 
            dKin = double.Parse(result.dsRepTohDataSet.ReptohTotal[i].seiGak);

            // 金額フォーマット 
            dgvMain_Sheet1.Cells[setCol * 3, nMonthRow].Value = string.Format(KIN_FORMAT, dKin);

            // 水平位置を右詰め 
            dgvMain_Sheet1.Cells[setCol * 3, nMonthRow].HorizontalAlignment =
                FarPoint.Win.Spread.CellHorizontalAlignment.Right;

            // 段数取得 
            sDan = result.dsRepTohDataSet.ReptohTotal[i].name11;
            if (sDan == "")
            {
                // ブランクの場合、"0"
                sDan = "0";
            }

            // 段数フォーマット 
            dDan = double.Parse(sDan);
            dgvMain_Sheet1.Cells[setCol * 3 + 1, nMonthRow].Value = string.Format(DAN_FORMAT, dDan);

            // 水平位置を右詰め 
            dgvMain_Sheet1.Cells[setCol * 3 + 1, nMonthRow].HorizontalAlignment =
                FarPoint.Win.Spread.CellHorizontalAlignment.Right;

            // 枠数取得 
            sWak = result.dsRepTohDataSet.ReptohTotal[i].name11wak;
            if (sWak == "")
            {
                // ブランクの場合、"0"
                sWak = "0";
            }

            // 枠数フォーマット 
            dWak = double.Parse(sWak);
            dgvMain_Sheet1.Cells[setCol * 3 + 2, nMonthRow].Value = string.Format(WAK_FORMAT, dWak);

            // 水平位置を右詰め 
            dgvMain_Sheet1.Cells[setCol * 3 + 2, nMonthRow].HorizontalAlignment =
                FarPoint.Win.Spread.CellHorizontalAlignment.Right;

            //********************
            // 総計更新
            //********************
            baitaiKinSum = baitaiKinSum + dKin;
            baitaiDanSum = baitaiDanSum + dDan;
            baitaiWakSum += dWak;

            if (isChuoFlg)
            {
                // 中央紙の場合、月毎総計を更新
                monthKinSum[int.Parse(sMonth) - 1] = monthKinSum[int.Parse(sMonth) - 1] + dKin;
                monthDanSum[int.Parse(sMonth) - 1] = monthDanSum[int.Parse(sMonth) - 1] + dDan;
                monthWakSum[int.Parse(sMonth) - 1] += dWak;
            }
        }

        /// <summary>
        /// 月毎総計設定 
        /// </summary>
        /// <param name="setCol">セルへの設定行位置</param>
        /// <param name="monthKinSum">媒体毎金額合計</param>
        /// <param name="monthDanSum">媒体毎段数合計</param>
        /// <param name="monthWakSum">媒体毎枠数合計</param>
        /// <returns>true</returns>
        private bool setMonthSum(ref int setCol,
            ref double[] monthKinSum, 
            ref double[] monthDanSum, 
            ref double[] monthWakSum)
        {
            double allKinSum = 0;                   // 金額総計 
            double allDanSum = 0;                   // 段数総計 
            double allWakSum = 0;                   // 枠数総計 

            //********************
            // 総計更新(月毎) 
            //********************
            // 行を加算(金額・段数・枠数分カウント) 
            dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 3);

            //********************
            // 媒体 
            //********************
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, BAITAI_ROW].Value = "総計";
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, BAITAI_ROW].Value = "";

            //********************
            // 項目（金額・段数・枠数） 
            //********************
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, KOUMOKU_ROW].Value = "金額";
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, KOUMOKU_ROW].Value = "段数";
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 1, KOUMOKU_ROW].Value = "枠数";


            // 総計フォーマット 
            for (int j = MONTH_JAN_ROW; j < SUM_ROW; j++)
            {
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, j].Value =
                    string.Format(KIN_FORMAT, monthKinSum[j - MONTH_JAN_ROW]);
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, j].Value =
                    string.Format(DAN_FORMAT, monthDanSum[j - MONTH_JAN_ROW]);
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 1, j].Value =
                    string.Format(WAK_FORMAT, monthWakSum[j - MONTH_JAN_ROW]);

                allKinSum = allKinSum + monthKinSum[j - MONTH_JAN_ROW];
                allDanSum = allDanSum + monthDanSum[j - MONTH_JAN_ROW];
                allWakSum += monthWakSum[j - MONTH_JAN_ROW];

                // 水平位置を右詰め 
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, j].HorizontalAlignment =
                    FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, j].HorizontalAlignment =
                    FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 1, j].HorizontalAlignment =
                    FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }

            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 3, SUM_ROW].Value =
                string.Format(KIN_FORMAT, allKinSum);
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 2, SUM_ROW].Value =
                string.Format(DAN_FORMAT, allDanSum);
            dgvMain_Sheet1.Cells[dgvMain_Sheet1.RowCount - 1, SUM_ROW].Value =
                string.Format(WAK_FORMAT, allWakSum);

            return true;
        }

        /// <summary>
        /// 金額幅自動設定処理 
        /// </summary>
        private void setAutoSize()
        {
            float width = 0;  // 列幅 
            for (int i = MONTH_JAN_ROW; i < SUM_ROW + 1; i++)
            {
                // 自動調整された列幅取得 
                width = dgvMain_Sheet1.Columns[i].GetPreferredWidth();

                if (width < KIN_MIN_WIDTH)
                {
                    // 定義した最低幅より小さければ列幅に設定 
                    width = KIN_MIN_WIDTH;
                }
                dgvMain_Sheet1.Columns[i].Width = width;
            }
        }

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="filnm">ファイル</param>
        private void ExcelOut(string filnm)
        {
            string workFolderPath = string.Empty;
            string excelFile = string.Empty;
            workFolderPath = pStrRepTempAdrs;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macroFile, Properties.Resources.TohTotal_Mcr);
                File.WriteAllBytes(templFile, Properties.Resources.TohTotal_Template);

                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力 
                tohds.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力 
                // 変数の宣言 
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する 
                // PRODUCTSというテーブルを作成します 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));

                //テーブルにデータを追加する 
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力 
                KKHLogUtilityToh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityToh.KINO_ID_OPERATION_LOG_Total, KKHLogUtilityToh.DESC_OPERATION_LOG_Total);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 営業日を取得 
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }


        # endregion


    }
}
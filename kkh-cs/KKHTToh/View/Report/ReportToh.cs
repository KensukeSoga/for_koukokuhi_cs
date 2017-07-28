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

namespace Isid.KKH.Toh.View.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReportToh : KKHForm
    {
        #region メンバ変数.

        /// <summary>
        /// 呼び出しパラメータ(受取).
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 消費税.
        /// </summary>
        private double _dbSyohizei;

        /// <summary>
        /// コピーマクロ削除用string.
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

        #endregion

        #region 定数.

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Toh_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Toh_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Toh_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Toh_Mcr.xlsm";
        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "Report";

        #endregion

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportToh()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント.

        /// <summary>
        /// 検索ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //*************************************
            // レコード取得.
            //*************************************
            this.GetRecord();

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoKenmei_CheckedChanged(object sender, EventArgs e)
        {
            //取得レコードがある場合.
            if (dgvMain_Sheet1.RowCount > 0)
            {
                btnXls.Enabled = true;
            }
            else
            {
                statusStrip1.Items["tslval1"].Text = "0件";
                //btnXls.Enabled = false;
            }

            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet2.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoBaitai_CheckedChanged(object sender, EventArgs e)
        {
            //取得レコードがある場合.
            if (dgvMain_Sheet2.RowCount > 0)
            {
                btnXls.Enabled = true;
            }
            else
            {
                statusStrip1.Items["tslval1"].Text = "0件";
                //btnXls.Enabled = false;
            }
            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet2.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //初期設定.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
            //年月取得.
            String hostdate = getHostDate();
            dtpYyyyMmDd.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(hostdate);
            //件名（初期）.
            rdoKenmei.Checked = true;

            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //消費税取得（マスタから）.
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
                //消費税セット.
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //保存情報＋帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "001");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //シート表示・非表示設定.
            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet2.Visible = false;

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();
            //日付とか.
            DateTime now = DateTime.Now;
            //はじめのファイル名を指定する.
            //sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + ".xls";
            ////sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + ".xlsx";
            //はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = pStrRepAdrs;
            //[ファイルの種類]に表示される選択肢を指定する.
            //sfd.Filter = "XLSファイル(*.xls)|*.xls";
            ////sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            //[ファイルの種類]ではじめに.
            //「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;
            //タイトルを設定する.
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示する.
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する。.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);

                    //選択状態を解除.
                    this.ActiveControl = null;
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

            //選択状態を解除.
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


                // マクロファイルの削除（VBA側では削除できない為）.
                // ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // ファイルを削除する.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード.
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行.
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
            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;
        }

        #endregion

        #region メソッド.

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// レコード取得.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            string yearmon = dtpYyyyMmDd.Value.ToString("yyyyMM");

            //納品区分.
            string kbn = "";
            if (txtKbn.Text == "" || txtKbn.Text == "1" || txtKbn.Text == "2")
            {
                kbn = txtKbn.Text.ToString();
            }
            else
            {
                //エラーとする.
                //ローディング表示終了.
                base.CloseLoadingDialog();

                // 件数表示を初期化.
                statusStrip1.Items["tslval1"].Text = "0件";

                //シートを0件にする.
                dgvMain_Sheet1.RowCount = 0;
                dgvMain_Sheet2.RowCount = 0;

                //[帳票出力]ボタン非活性.
                btnXls.Enabled = false;

                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //件名媒体区分.
            string kenbaikbn = "";

            if (rdoKenmei.Checked)
            {
                kenbaikbn = "1";//件名別.
            }
            else if(rdoBaitai.Checked)
            {
                kenbaikbn = "2";//媒体別.
            }

            //実行.
            Isid.KKH.Toh.Schema.RepDsToh jyuListdt = new Isid.KKH.Toh.Schema.RepDsToh();
            Isid.KKH.Toh.ProcessController.ReportTohProcessController processController = Isid.KKH.Toh.ProcessController.ReportTohProcessController.GetInstance();
            Isid.KKH.Toh.ProcessController.FindReportTohByCondServiceResult result = processController.FindRepTohByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      yearmon,
                                                                                      kbn,
                                                                                      kenbaikbn
                                                                                      );

            //dgvMain_Sheet1.DataSource = result.dsRepTohDataSet.Tables[0];

            //データが存在しなければ終了.
            if (result.dsRepTohDataSet.Tables[0].Rows.Count == 0)
            {
                // 件数表示を初期化.
                statusStrip1.Items["tslval1"].Text = "0件";

                //ローディング表示終了.
                base.CloseLoadingDialog();

                dgvMain_Sheet1.RowCount = 0;
                dgvMain_Sheet2.RowCount = 0;
                btnXls.Enabled = false;
                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //データグリッド初期化.
            dgvMain_Sheet1.RowCount = 0;
            dgvMain_Sheet2.RowCount = 0;

            //データグリッド用変数.
            int GYO = 0;
            double IngSyokei = 0;//小計.
            double IngSyohi = 0;//消費税.
            double IngGokei = 0;//合計.
            double IngSGokei = 0;//総合計.
            string strZen = "";//前件名（または媒体名）.
            string strhdk = "";

            //消費税対応 2013/12/05 HLC H.Watabe add start
            List<double> listTaxRate = new List<double>();
            List<double> listSum = new List<double>();
            double taxSum = 0;
            //消費税対応 2013/12/05 HLC H.Watabe add end

            //件名///////////////////////////////////////////////////////////////////////////////////////
            if (rdoKenmei.Checked)
            {

                //データグリッドに表示(件数分表示).
                for (int i = 0; i < result.dsRepTohDataSet.Tables[0].Rows.Count; i++)
                {
                    // 行を加算.
                    //件名が変わっていない場合.
                    if (result.dsRepTohDataSet.Reptoh[i].name8.ToString().Equals(strZen))
                    {
                        dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                        GYO++;
                        //2～7行目に表示.
                        //媒体名.
                        dgvMain_Sheet1.Cells[GYO, 1].Value = result.dsRepTohDataSet.Reptoh[i].name2.ToString();
                        //朝･夕.
                        dgvMain_Sheet1.Cells[GYO, 2].Value = result.dsRepTohDataSet.Reptoh[i].kbn1.ToString();
                        //掲載日.
                        strhdk = result.dsRepTohDataSet.Reptoh[i].Date1.ToString();
                        if (strhdk.Equals(""))
                        {
                            dgvMain_Sheet1.Cells[GYO, 3].Value = "";
                        }
                        else
                        {
                            dgvMain_Sheet1.Cells[GYO, 3].Value = strhdk.Substring(0, 4) + "/" + strhdk.Substring(4, 2) + "/" + strhdk.Substring(6, 2);
                        }
                        //スペース.
                        dgvMain_Sheet1.Cells[GYO, 4].Value = result.dsRepTohDataSet.Reptoh[i].code1.ToString();
                        //単価.
                        dgvMain_Sheet1.Cells[GYO, 5].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].kngk1.ToString()).ToString("###,###,###,##0");
                        //料金.
                        dgvMain_Sheet1.Cells[GYO, 6].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()).ToString("###,###,###,##0");

                        //消費税対応 2013/12/05 HLC H.Watabe add start
                        if (listTaxRate.Count != 0)
                        {
                            bool taxGetFlg = false;
                            for (int index = 0; index < listTaxRate.Count; index++)
                            {
                                if (listTaxRate[index] == (double)result.dsRepTohDataSet.Reptoh[i].ritu1)
                                {
                                    taxGetFlg = true;
                                    listSum[index] += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                                    break;
                                }
                            }
                            if (taxGetFlg == false)
                            {
                                listTaxRate.Add((double)result.dsRepTohDataSet.Reptoh[i].ritu1);
                                listSum.Add(double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()));

                            }
                        }
                        else
                        {
                            listTaxRate.Add((double)result.dsRepTohDataSet.Reptoh[i].ritu1);
                            listSum.Add(double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()));
                        }
                        //消費税対応 2013/12/05 HLC H.Watabe add end
                    }
                    //件名が変わった場合.
                    else
                    {
                        dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                        //◆小計、消費税、合計表示.
                        //※１レコドー目は小計表示対象外.

                        if (GYO == 0)
                        {
                            //何もしない.
                        }
                        else
                        {
                            GYO++;
                            //小計表示.
                            dgvMain_Sheet1.Cells[GYO, 0].Value = "小計";
                            dgvMain_Sheet1.Cells[GYO, 6].Value = IngSyokei.ToString("###,###,###,##0");
                            // 行を加算.
                            dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                            GYO++;
                            //消費税表示.

                            //消費税対応 2013/12/05 HLC H.Watabe update start
                            dgvMain_Sheet1.Cells[GYO, 0].Value = "消費税";
                            IngSyohi = 0;
                            for (int index = 0; index < listTaxRate.Count; index++)
                            {
                                IngSyohi += listTaxRate[index] * listSum[index];
                            }

                            //IngSyohi = Math.Floor((IngSyokei * _dbSyohizei));
                            dgvMain_Sheet1.Cells[GYO, 6].Value = IngSyohi.ToString("###,###,###,##0");

                            listSum.Clear();
                            listTaxRate.Clear();
                            //消費税対応 2013/12/05 HLC H.Watabe update end

                            // 行を加算.
                            dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                            GYO++;
                            //合計表示.
                            dgvMain_Sheet1.Cells[GYO, 0].Value = "合計";
                            IngGokei = Math.Floor((IngSyokei + (IngSyokei * _dbSyohizei)));
                            dgvMain_Sheet1.Cells[GYO, 6].Value = IngGokei.ToString("###,###,###,##0");
                            // 行を加算.
                            dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                            GYO++;

                            //合計を加算.
                            IngSGokei += IngGokei;

                            //初期化.
                            IngSyokei = 0;
                            IngGokei = 0;
                        }

                        //前回変数にINS.
                        strZen = result.dsRepTohDataSet.Reptoh[i].name8.ToString();
                        //件名のみ表示.
                        dgvMain_Sheet1.Cells[GYO, 0].Value = result.dsRepTohDataSet.Reptoh[i].name8.ToString();
                        //行を加算.
                        dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                        GYO++;
                        //2～7行目に表示.
                        //媒体名.
                        dgvMain_Sheet1.Cells[GYO, 1].Value = result.dsRepTohDataSet.Reptoh[i].name2.ToString();
                        //朝･夕.
                        dgvMain_Sheet1.Cells[GYO, 2].Value = result.dsRepTohDataSet.Reptoh[i].kbn1.ToString();
                        //掲載日.
                        strhdk = result.dsRepTohDataSet.Reptoh[i].Date1.ToString();
                        if (strhdk.Equals(""))
                        {
                            dgvMain_Sheet1.Cells[GYO, 3].Value = "";
                        }
                        else
                        {
                            dgvMain_Sheet1.Cells[GYO, 3].Value = strhdk.Substring(0, 4) + "/" + strhdk.Substring(4, 2) + "/" + strhdk.Substring(6, 2);
                        }
                        //dgvMain_Sheet1.Cells[GYO,3].Value = result.dsRepTohDataSet.Reptoh[i].date1.ToString();
                        //スペース.
                        dgvMain_Sheet1.Cells[GYO, 4].Value = result.dsRepTohDataSet.Reptoh[i].code1.ToString();
                        //単価.
                        dgvMain_Sheet1.Cells[GYO, 5].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].kngk1.ToString()).ToString("###,###,###,##0");
                        //料金.
                        dgvMain_Sheet1.Cells[GYO, 6].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()).ToString("###,###,###,##0");

                        //消費税対応 2013/12/05 HLC H.Watabe add start
                        if (listTaxRate.Count != 0)
                        {
                            bool taxGetFlg = false;
                            for (int index = 0; index < listTaxRate.Count; index++)
                            {
                                if (listTaxRate[index] == (double)result.dsRepTohDataSet.Reptoh[i].ritu1)
                                {
                                    taxGetFlg = true;
                                    listSum[index] += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                                    break;
                                }
                            }
                            if (taxGetFlg == false)
                            {
                                listTaxRate.Add((double)result.dsRepTohDataSet.Reptoh[i].ritu1);
                                listSum.Add(double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()));
                            }
                        }
                        else
                        {
                            listTaxRate.Add((double)result.dsRepTohDataSet.Reptoh[i].ritu1);
                            listSum.Add(double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()));
                        }
                        //消費税対応 2013/12/05 HLC H.Watabe add end
                    }

                    //小計加算.
                    IngSyokei += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                    //合計加算.
                    IngGokei += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                }

                //行を加算.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                GYO++;
                //最後に小計と合計を出す.
                //小計表示.
                dgvMain_Sheet1.Cells[GYO, 0].Value = "小計";
                dgvMain_Sheet1.Cells[GYO, 6].Value = IngSyokei.ToString("###,###,###,##0");
                //行を加算.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                GYO++;

                //消費税表示.
                //消費税対応 2013/12/05 HLC H.Watabe update start
                dgvMain_Sheet1.Cells[GYO, 0].Value = "消費税";
                IngSyohi = 0;
                for (int index = 0; index < listTaxRate.Count; index++)
                {
                    IngSyohi += listTaxRate[index] * listSum[index];
                }
                //IngSyohi = Math.Floor((IngSyokei * _dbSyohizei));
                dgvMain_Sheet1.Cells[GYO, 6].Value = IngSyohi.ToString("###,###,###,##0");
                //消費税対応 2013/12/05 HLC H.Watabe update end

                dgvMain_Sheet1.Cells[GYO, 6].Value = IngSyohi.ToString("###,###,###,##0");
                //行を加算.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                GYO++;
                //合計表示.
                dgvMain_Sheet1.Cells[GYO, 0].Value = "合計";
                //消費税を加算.
                IngGokei += Math.Floor(IngSyokei * _dbSyohizei);
                //IngGokei = Math.Floor((IngSyokei + (IngSyokei * _dbSyohizei)));
                dgvMain_Sheet1.Cells[GYO, 6].Value = IngGokei.ToString("###,###,###,##0");
                //行を加算.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                GYO++;
                //総合計表示.
                dgvMain_Sheet1.Cells[GYO, 0].Value = "総合計";
                IngSGokei += IngGokei;
                //IngSGokei += Math.Floor(IngSyokei * (1.00 + _dbSyohizei));
                dgvMain_Sheet1.Cells[GYO, 6].Value = IngSGokei.ToString("###,###,###,##0");

            }
            //媒体名///////////////////////////////////////////////////////////////////////////////////////
            else
            {
                //データグリッドに表示(件数分表示).
                for (int i = 0; i < result.dsRepTohDataSet.Tables[0].Rows.Count; i++)
                {
                    // 行を加算.
                    //媒体名が変わっていない場合.
                    if (result.dsRepTohDataSet.Reptoh[i].name2.ToString().Equals(strZen))
                    {
                        dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                        GYO++;
                        //2～7行目に表示.
                        //件名.
                        dgvMain_Sheet2.Cells[GYO, 1].Value = result.dsRepTohDataSet.Reptoh[i].name8.ToString();
                        //朝･夕.
                        dgvMain_Sheet2.Cells[GYO, 2].Value = result.dsRepTohDataSet.Reptoh[i].kbn1.ToString();
                        //掲載日.
                        strhdk = result.dsRepTohDataSet.Reptoh[i].Date1.ToString();
                        if (strhdk.Equals(""))
                        {
                            dgvMain_Sheet2.Cells[GYO, 3].Value = "";
                        }
                        else
                        {
                            dgvMain_Sheet2.Cells[GYO, 3].Value = strhdk.Substring(0, 4) + "/" + strhdk.Substring(4, 2) + "/" + strhdk.Substring(6, 2);
                        }
                        //dgvMain_Sheet2.Cells[GYO,3].Value = result.dsRepTohDataSet.Reptoh[i].date1.ToString();
                        //スペース.
                        dgvMain_Sheet2.Cells[GYO, 4].Value = result.dsRepTohDataSet.Reptoh[i].code1.ToString();
                        //単価.
                        dgvMain_Sheet2.Cells[GYO, 5].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].kngk1.ToString()).ToString("###,###,###,##0");
                        //料金.
                        dgvMain_Sheet2.Cells[GYO, 6].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()).ToString("###,###,###,##0");
                    }
                    //件名が変わった場合.
                    else
                    {
                        dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                        //◆小計、消費税、合計表示.
                        //※１レコドー目は小計表示対象外.

                        if (GYO == 0)
                        {
                            //何もしない.
                        }
                        else
                        {
                            GYO++;
                            //小計表示.
                            dgvMain_Sheet2.Cells[GYO, 0].Value = "小計";
                            dgvMain_Sheet2.Cells[GYO, 6].Value = IngSyokei.ToString("###,###,###,##0");
                            // 行を加算.
                            dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                            GYO++;
                            //初期化.
                            IngSyokei = 0;
                        }

                        //前回変数にINS.
                        strZen = result.dsRepTohDataSet.Reptoh[i].name2.ToString();
                        //媒体名のみ表示.
                        dgvMain_Sheet2.Cells[GYO, 0].Value = result.dsRepTohDataSet.Reptoh[i].name2.ToString();
                        //行を加算.
                        dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                        GYO++;
                        //2～7行目に表示.
                        //件名.
                        dgvMain_Sheet2.Cells[GYO, 1].Value = result.dsRepTohDataSet.Reptoh[i].name8.ToString();
                        //朝･夕.
                        dgvMain_Sheet2.Cells[GYO, 2].Value = result.dsRepTohDataSet.Reptoh[i].kbn1.ToString();
                        //掲載日.
                        strhdk = result.dsRepTohDataSet.Reptoh[i].Date1.ToString();
                        if (strhdk.Equals(""))
                        {
                            dgvMain_Sheet2.Cells[GYO, 3].Value = "";
                        }
                        else
                        {
                            dgvMain_Sheet2.Cells[GYO, 3].Value = strhdk.Substring(0, 4) + "/" + strhdk.Substring(4, 2) + "/" + strhdk.Substring(6, 2);
                        }
                        //dgvMain_Sheet2.Cells[GYO,3].Value = result.dsRepTohDataSet.Reptoh[i].date1.ToString();
                        //スペース.
                        dgvMain_Sheet2.Cells[GYO, 4].Value = result.dsRepTohDataSet.Reptoh[i].code1.ToString();
                        //単価.
                        dgvMain_Sheet2.Cells[GYO, 5].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].kngk1.ToString()).ToString("###,###,###,##0");
                        //料金.
                        dgvMain_Sheet2.Cells[GYO, 6].Value = double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString()).ToString("###,###,###,##0");
                    }

                    //小計加算.
                    IngSyokei += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                    //合計加算.
                    IngGokei += double.Parse(result.dsRepTohDataSet.Reptoh[i].seiGak.ToString());
                }

                //行を加算.
                dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                GYO++;
                //最後に小計と合計を出す.
                //小計表示.
                dgvMain_Sheet2.Cells[GYO, 0].Value = "小計";
                dgvMain_Sheet2.Cells[GYO, 6].Value = IngSyokei.ToString("###,###,###,##0");
                //行を加算.
                dgvMain_Sheet2.Rows.Add(dgvMain_Sheet2.RowCount, 1);
                GYO++;
                //合計表示.
                dgvMain_Sheet2.Cells[GYO, 0].Value = "合計";
                dgvMain_Sheet2.Cells[GYO, 6].Value = IngGokei.ToString("###,###,###,##0");
            }

            tohds = result.dsRepTohDataSet;
            btnXls.Enabled = true;

            //件数表示.
            statusStrip1.Items["tslval1"].Text = result.dsRepTohDataSet.Tables[0].Rows.Count.ToString() + "件";

            //ローディング表示終了.
            base.CloseLoadingDialog();
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
                File.WriteAllBytes(macroFile, Properties.Resources.Toh_Mcr1);
                File.WriteAllBytes(templFile, Properties.Resources.Toh_Template);

                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                tohds.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("FLG", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                //件名or媒体.
                if (rdoKenmei.Checked)
                {
                    dtRow["FLG"] = "1";
                }
                else
                {
                    dtRow["FLG"] = "2";
                }

                dtRow["SAVEDIR"] = filnm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["SELHDK"] = dtpYyyyMmDd.Value.ToString("yyyyMMdd");
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力.
                KKHLogUtilityToh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityToh.KINO_ID_OPERATION_LOG_Report, KKHLogUtilityToh.DESC_OPERATION_LOG_Report);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
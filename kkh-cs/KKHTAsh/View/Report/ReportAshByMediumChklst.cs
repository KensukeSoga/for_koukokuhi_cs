using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// 広告費アップロードシート.
    /// </summary>
    public partial class ReportAshByMediumChklst : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数.
        #region 固定文言.
        /// <summary>
        /// 対象データなしの場合の文言.
        /// </summary>
        private const string MSG_NOTHING = "対象がありません";
        /// <summary>
        /// アプリID.
        /// </summary>
        private const string APLID = "Chklst";
        /// <summary>
        /// テレビ愛媛放送変換用.
        /// </summary>
        private const string EHIMEBefor = "愛媛放送";
        /// <summary>
        /// テレビ愛媛放送変換用.
        /// </summary>
        private const string EHIMEAfter = "テレビ愛媛";
        /// <summary>
        /// 0.
        /// </summary>
        private const string ZERO = "0";
        #endregion 固定文言.

        #region 帳票.
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_MediumChklst.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロテンプレート)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_MediumChklst_Template.xls";
        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_MediumChklst_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_MediumChklst_Prop.xml";
        #endregion 帳票.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 年月.
        /// </summary>
        string yearmon = string.Empty;
        /// <summary>
        /// 出力用データセット.
        /// </summary>
        private RepDsAsh repDsMedia = null;
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 消費税.
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// コピーマクロ削除用string
        /// </summary>
        private string _strmacrodel;
        /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD Start */
        /// <summary>
        /// 部署.
        /// </summary>
        private string _busyo;
        /// <summary>
        /// 支払先.
        /// </summary>
        private string _shiharaisaki;
        /// <summary>
        /// 相手先.
        /// </summary>
        private string _aitesaki;
        /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD End */
        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportAshByMediumChklst()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.
        #region 画面遷移時に発生.
        /// <summary>
        /// 画面遷移時に発生.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAshByMedium_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }
        #endregion 画面遷移時に発生.

        #region フォームロード.
        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshByMediumChklst_Shown(object sender, EventArgs e)
        {
            //ローディング表示.
            base.ShowLoadingDialog();

            //編集.
            EditControl();

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
                                                                                            "002");

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) fukuda ADD start */
                _busyo = comResult2.CommonDataSet.SystemCommon[0].field5.ToString();
                _shiharaisaki = comResult2.CommonDataSet.SystemCommon[0].field6.ToString();
                _aitesaki = comResult2.CommonDataSet.SystemCommon[0].field7.ToString();
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) fukuda ADD end   */
            }

            //ローディング非表示.
            base.CloseLoadingDialog();
        }
        #endregion フォームロード.

        #region 戻るボタンクリック.
        /// <summary>
        /// 戻るボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                //マクロファイルの削除(VBA側では削除できない為).
                //ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    //読み取り専用属性がある場合は、読み取り専用属性を解除する.
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
        #endregion 戻るボタンクリック.

        #region 表示ボタンクリック.
        /// <summary>
        /// 表示ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //表示.
            DisplayView();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion 表示ボタンクリック.

        #region 媒体選択コンボチェンジイベント.
        /// <summary>
        /// 媒体選択コンボチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (repDsMedia == null)
            {
                return;
            }
            else
            {
                //[合計]の場合.
                if (mediaCmb.SelectedValue.ToString() == KkhConstAsh.BaitaiCd.GOKEI)
                {
                    MakeSum();
                    ////検索ボタンを非活性.
                    //btnSrc.Enabled = false;
                    btnSrc.Enabled = true;
                }
                else
                {
                    BindingSource(mediaCmb.SelectedValue.ToString());
                    //検索ボタンを活性.
                    btnSrc.Enabled = true;
                }
            }
        }
        #endregion 媒体選択コンボチェンジイベント.

        #region Excelボタンクリック.
        /// <summary>
        /// Excelボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // ファイル生成.
            excelFileSet();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion Excelボタンクリック.

        #region ヘルプボタンクリック処理.
        /// <summary>
        /// ヘルプボタンクリック処理.
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
        #endregion ヘルプボタンクリック処理.

        #region 年月コンボボックスアクティブ.
        /// <summary>
        /// 年月コンボボックスアクティブ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }
        #endregion 年月コンボボックスアクティブ.
        #endregion イベント.

        #region メソッド.
        #region コンボボックスの設定.
        /// <summary>
        /// コンボボックスの設定.
        /// </summary>
        private void cmbSet()
        {
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD Start */
            //コンボボックスの生成.
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiNm, resultList[i].baitaiCd);
            }
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.GOKEI, KkhConstAsh.BaitaiCd.GOKEI);

            mediaCmb.DataSource = SybtNameTable;
            mediaCmb.DisplayMember = "Display";
            mediaCmb.ValueMember = "Value";
            mediaCmb.SelectedValue = KkhConstAsh.BaitaiCd.TV_TIME;
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD End */
        }
        #endregion コンボボックスの設定.

        #region 各コントロール編集.
        /// <summary>
        /// 各コントロール編集.
        /// </summary>
        private void EditControl()
        {
            //年月の取得.
            String hostDate = "";
            hostDate = getHostDate();

            if (hostDate != "")
            {
                hostDate = hostDate.Trim().Replace("/", "");
                if (hostDate.Trim().Length >= 6)
                {
                    txtYm.Value = hostDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = hostDate;
                }
                txtYm.cmbYM_SetDate();
            }

            //ステータスの設定.
            txtYm.Value = hostDate.Substring(0, 6);
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //コンボ設定.
            cmbSet();
        }
        #endregion 各コントロール編集.

        #region 営業日取得.
        /// <summary>
        /// 営業日取得.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }
        #endregion 営業日取得.

        #region データ表示.
        /// <summary>
        /// データ表示.
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //初期設定.
            txtSeiGak.Text = ZERO;
            btnXls.Enabled = false;
            mediaCmb.Enabled = false;
            //小計用.
            double syoukei = 0;
            double syoukeiKomi = 0;
            double tyouseiGaku = 0;
            //非課税.
            double hikazei = 0;
            //媒体区分格納.
            string baitaiKbn = string.Empty;
            //媒体コード.
            string baitaiCd = string.Empty;
            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD Start */
            //媒体コードから名称を取得.
            //baitaiCd = baitaiNmOfCode(mediaCmb.SelectedItem.ToString());
            baitaiCd = mediaCmb.SelectedValue.ToString();
            //表示順
            double order = 0;
            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD End */
            //消費税率.
            double lngComTax = 0;
            //消費税率保持用.
            double lngComTaxSave = 0;
            repDsMedia = new RepDsAsh();
            //媒体別合計金額.
            double baitaigokei = 0;

            /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
            List<double> listTaxRate = new List<double>();
            List<double> listAmount = new List<double>();
            int listIndex = 0;
            double mediaTaxSumFromRows = 0;
            /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */

            //年月のセット.
            yearmon = txtYm.Value;

            //パラメーターのセット.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;

            //検索.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMediaChklst(param);
            //エラーの場合.
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }

            RepDsAsh.RepAshMediaChklstRow[] resultRow = (RepDsAsh.RepAshMediaChklstRow[])result.dsAshDataSet.RepAshMediaChklst.Select("", "");

            if (resultRow.Length == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                txtSeiGak.Text = "0";
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            RepDsAsh.SeigakByMediaRow mediaRow = repDsMedia.SeigakByMedia.NewSeigakByMediaRow();
            mediaRow = seigakSyokirowSet(mediaRow);
            
            /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD Start */
            AshBaitaiUtility baitaiUtil = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD End */

            //行数カウント.
            int count = 0;
            foreach (RepDsAsh.RepAshMediaChklstRow hrow in resultRow)
            {
                //消費税.
                if (hrow.ritu1.Trim().Equals("0"))
                {
                    lngComTax = 1;
                }
                else
                {
                    lngComTax = 1 + (double.Parse(hrow.ritu1.Trim()) * 0.01);
                }
                
                //処理件数が0件の場合.
                if (count == 0)
                {
                    //媒体毎の調整値を格納する.
                    syoukei = double.Parse(hrow.seikyukin);
                    syoukeiKomi = double.Parse(hrow.seikyukinkomi);
                    tyouseiGaku = ToHalfAdjust(syoukei * lngComTax, 0) - syoukeiKomi;
                }
                else
                {
                    //1つ前の媒体コードと異なる場合.
                    if (baitaiKbn == hrow.baitaicd)
                    {
                        syoukei += double.Parse(hrow.seikyukin);
                        syoukeiKomi += double.Parse(hrow.seikyukinkomi);
                        tyouseiGaku += ToHalfAdjust(double.Parse(hrow.seikyukin) * lngComTax, 0)
                            - double.Parse(hrow.seikyukinkomi);
                        if (double.Parse(hrow.ritu1.ToString()) == 0)
                        {
                            hikazei = hikazei + double.Parse(hrow.seikyukin.ToString());
                        }
                    }
                    else
                    {
                        if (baitaiKbn == repDsMedia.displayMediaChklst[count - 1].baitaicd)
                        {
                            /* 2016/11/24 アサヒ消費税対応 HLC K.Soga DEL Start */
                            ///* 2013/12/04 消費税対応 HLC H.Watabe MOD Start */
                            ////媒体合計.
                            ////baitaigokei -= double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);
                            ////比較前の媒体データの最終列に、差額分を足した税込み金額を入れる.
                            ////※シート毎に差額修正していた手作業の処理※.
                            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + (((syoukei - hikazei) * lngComTax) + hikazei) - syoukeiKomi);
                            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + (((syoukei - hikazei) * lngComTaxSave) + hikazei) - syoukeiKomi);
                            ////媒体合計.
                            ////baitaigokei += double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);

                            //double sumTax = 0;
                            //for (int index = 0; index < listTaxRate.Count; index++)
                            //{
                            //    sumTax += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);  
                            //}
                            //double newTaxAmount = double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + sumTax - baitaigokei;
                            //repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", newTaxAmount);
                            //baitaigokei = sumTax;
                            ///* 2013/12/04 消費税対応 HLC H.Watabe MOD End */
                            /* 2016/11/24 アサヒ消費税対応 HLC K.Soga DEL End */

                            //金額設定.
                            seigakRowSet(baitaiKbn, String.Format("{0}", baitaigokei), ref mediaRow);
                            baitaigokei = 0;

                            /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                            listAmount.Clear();
                            listTaxRate.Clear();
                            /* 消費税対応 2013/12/04 HLC H.Watabe ADD End */
                        }

                        syoukei += double.Parse(hrow.seikyukin);
                        syoukeiKomi += double.Parse(hrow.seikyukinkomi);
                        tyouseiGaku += ToHalfAdjust(double.Parse(hrow.seikyukin) * lngComTax, 0) - double.Parse(hrow.seikyukinkomi);
                        if (double.Parse(hrow.ritu1.ToString()) == 0)
                        {
                            hikazei = hikazei + double.Parse(hrow.seikyukin.ToString());
                        }

                        //初期化.
                        syoukei = 0;
                        syoukeiKomi = 0;
                        tyouseiGaku = 0;
                        hikazei = 0;
                    }

                    /* 2015/03/19 アサヒ対応 Miyanoue ADD Start */
                    //表示順の設定.
                    String newBaitaiCd = baitaiUtil.ConvertOldCdToNewCd(hrow.baitaicd).baitaiCd;
                    List<AshBaitaiUtility.BaitaiOrderResult> resOrderList = baitaiUtil.GetBaitaiOrderList();
                    for (int i = 0; i < resOrderList.Count; i++)
                    {
                        if (newBaitaiCd == resOrderList[i].baitaiCord)
                        {
                            order = resOrderList[i].baitaiOrder;
                            break;
                        }
                        else
                        {
                            order = 999;
                        }
                    }
                    /* 2015/03/19 アサヒ対応 Miyanoue ADD Start */
                }

                //媒体合計.
                baitaigokei += double.Parse(hrow.seikyukinkomi);

                RepDsAsh.displayMediaChklstRow addrow = repDsMedia.displayMediaChklst.NewdisplayMediaChklstRow();
                addrow = dispSyokirowSet(addrow);
                addrow.seikyuno = string.Empty;
                addrow.baitaikbn = hrow.baitaikbn;
                addrow.baitaicd = hrow.baitaicd;
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD Start */
                addrow.tokuisakibaitaicd = baitaiUtil.ConvertOldCdToNewCd(addrow.baitaicd).baitaiCd;
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD End   */
                addrow.seikyukinkomi = string.Format("{0:N0}", Math.Truncate(double.Parse(hrow.seikyukinkomi)));
                addrow.seikyukin = string.Format("{0:N0}", double.Parse(hrow.seikyukin));
                addrow.kyokucd = hrow.kyokucd;
                addrow.kyokubaitaicd = hrow.kyokubaitaicd;
                addrow.hinsyunm = hrow.hinsyunm;
                addrow.hinsyucd = hrow.hinsyucd;
                addrow.hinsyubaitaicd = hrow.hinsyubaitaicd;
                addrow.kenmei = hrow.kenmei;
                /* 2015/03/19 アサヒ対応 Miyanoue ADD Start */
                addrow.order = order;
                /* 2015/03/19 アサヒ対応 Miyanoue ADD End */
                
                //愛媛放送対応.
                if (!string.IsNullOrEmpty(hrow.Field6.Trim()))
                {
                    addrow.kyokunm = hrow.Field6.Trim();
                }
                else
                {
                    addrow.kyokunm = hrow.kyokunm;
                }

                if (string.IsNullOrEmpty(addrow.kyokubaitaicd.Trim()))
                {
                    addrow.baitaikbn = "";
                    addrow.kyokubaitaicd = MSG_NOTHING;
                }

                //「品種CD」が空白の場合は「品種CD」に対象無し表示.
                if (string.IsNullOrEmpty(addrow.hinsyubaitaicd.Trim()))
                {
                    addrow.hinsyubaitaicd = MSG_NOTHING;
                }
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD Start */
                addrow.busyo = _busyo;
                addrow.shiharaisaki = _shiharaisaki;
                addrow.aitesaki = _aitesaki;
                /* 2015/03/13 アサヒ対応(アップロードシート最新化) Fukuda ADD End   */
                repDsMedia.displayMediaChklst.AdddisplayMediaChklstRow(addrow);

                //媒体コードを保持する.
                baitaiKbn = hrow.baitaicd;

                //消費税率を保持する.
                if (string.Format("{0:N0}", double.Parse(hrow.seikyukin)) != ("0"))
                {
                    if (lngComTax != 1.0)
                    {
                        lngComTaxSave = lngComTax;
                    }
                }

                //加算する.
                count++;
                /* 2013/12/04 消費税対応 HLC H.Watabe ADD Start */
                if (listTaxRate.Count != 0)
                {
                    bool taxGetFlg = false;
                    for (int index = 0; index < listTaxRate.Count; index++)
                    {
                        if (listTaxRate[index] == double.Parse(hrow.ritu1.Trim()))
                        {
                            listAmount[index] += double.Parse(hrow.seikyukin.Trim());
                            taxGetFlg = true;
                            break;
                        }
                    }

                    if (!taxGetFlg)
                    {
                        listTaxRate.Add(double.Parse(hrow.ritu1.Trim()));
                        listAmount.Add(double.Parse(hrow.seikyukin.Trim()));
                    }
                }
                else
                {
                    listTaxRate.Add(double.Parse(hrow.ritu1.Trim()));
                    listAmount.Add(double.Parse(hrow.seikyukin.Trim()));
                }
                /* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
            }

            /* 2016/11/24 アサヒ消費税対応 HLC K.Soga DEL Start */
            ///* 2013/12/04 消費税対応 HLC H.Watabe MOD Start */
            ////最終行の調整額当て込み.
            //double sum = 0;
            ////媒体合計.
            //double temp = baitaigokei;
            //baitaigokei -= double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);
            //for (int index = 0; index < listTaxRate.Count; index++)
            //{
            //    sum += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //}
            //double newAmount = double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + sum - temp;
            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + tyouseiGaku);
            //repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", newAmount);
            ///* 2013/12/04 消費税対応 HLC H.Watabe ADD End */
            /* 2016/11/24 アサヒ消費税対応 HLC K.Soga DEL End */

            //媒体合計.
            baitaigokei += double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);

            //金額設定.
            seigakRowSet(baitaiKbn, String.Format("{0}", baitaigokei), ref mediaRow);

            //合計金額設定.
            totalRowSet(ref mediaRow);
            repDsMedia.SeigakByMedia.AddSeigakByMediaRow(mediaRow);

            //[合計]の場合.
            if (baitaiCd == KkhConstAsh.BaitaiCd.GOKEI)
            {
                MakeSum();
            }
            else
            {
                //スプレッドにデータをバインドする.
                BindingSource(baitaiCd);
            }

            //エクセルボタン.
            btnXls.Enabled = true;

            //コンボボックス.
            mediaCmb.Enabled = true;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion データ表示.

        #region 媒体毎に合計値を格納する.
        /// <summary>
        /// 媒体毎に合計値を格納する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <param name="kingaku"></param>
        /// <param name="drow"></param>
        private void seigakRowSet(string baitaiCd, string kingaku, ref RepDsAsh.SeigakByMediaRow drow)
        {
            switch (baitaiCd)
            {
                //テレビタイム.
                case KkhConstAsh.BaitaiCd.TV_TIME:
                    drow.TVTIME = kingaku;
                    break;
                //ラジオタイム.
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    drow.RADIOTIME = kingaku;
                    break;
                //ラジオスポット.
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    drow.RADIOSPOT = kingaku;
                    break;
                //テレビスポット.
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                    drow.TVSPOT = kingaku;
                    break;
                //新聞.
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    drow.SHINBUN = kingaku;
                    break;
                //雑誌.
                case KkhConstAsh.BaitaiCd.ZASHI:
                    drow.ZASSHI = kingaku;
                    break;
                //交通.
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    drow.OOH = kingaku;
                    break;
                //制作.
                case KkhConstAsh.BaitaiCd.SEISAKU:
                    drow.SEISAKU = kingaku;
                    break;
                //その他.
                case KkhConstAsh.BaitaiCd.SONOTA:
                    drow.SONOTA = kingaku;
                    break;
                //ニューメディア.
                case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                    drow.NEWMEDIA = kingaku;
                    break;
                //インターネット.
                case KkhConstAsh.BaitaiCd.INTERNET:
                    drow.INTERNET = kingaku;
                    break;
                //BS.
                case KkhConstAsh.BaitaiCd.BS:
                    drow.BS = kingaku;
                    break;
                //CS.
                case KkhConstAsh.BaitaiCd.CS:
                    drow.CS = kingaku;
                    break;
                //屋外広告.
                case KkhConstAsh.BaitaiCd.OKUGAI:
                    drow.YAGAIKOKOKU = kingaku;
                    break;
                //ｲﾍﾞﾝﾄ.
                case KkhConstAsh.BaitaiCd.EVENT:
                    drow.EVENT = kingaku;
                    break;
                //調査.
                case KkhConstAsh.BaitaiCd.TYOUSA:
                    drow.TYOUSA = kingaku;
                    break;
                //メディアフィー.
                case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    drow.MEDIAFEE = kingaku;
                    break;
                //ブランド管理フィー.
                case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    drow.BLANDFEE = kingaku;
                    break;
            }
        }
        #endregion 媒体毎に合計値を格納する.

        #region 全媒体の合計値を格納する.
        /// <summary>
        /// 全媒体の合計値を格納する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <param name="kingaku"></param>
        /// <param name="drow"></param>
        private void totalRowSet(ref RepDsAsh.SeigakByMediaRow drow)
        {
            double total = 0;
            if (drow.TVTIME != "0") { total = total + double.Parse(drow.TVTIME); }
            if (drow.RADIOTIME != "0") { total = total + double.Parse(drow.RADIOTIME); }
            if (drow.RADIOSPOT != "0") { total = total + double.Parse(drow.RADIOSPOT); }
            if (drow.TVSPOT != "0") { total = total + double.Parse(drow.TVSPOT); }
            if (drow.SHINBUN != "0") { total = total + double.Parse(drow.SHINBUN); }
            if (drow.ZASSHI != "0") { total = total + double.Parse(drow.ZASSHI); }
            if (drow.OOH != "0") { total = total + double.Parse(drow.OOH); }
            if (drow.SEISAKU != "0") { total = total + double.Parse(drow.SEISAKU); }
            if (drow.SONOTA != "0") { total = total + double.Parse(drow.SONOTA); }
            if (drow.NEWMEDIA != "0") { total = total + double.Parse(drow.NEWMEDIA); }
            if (drow.INTERNET != "0") { total = total + double.Parse(drow.INTERNET); }
            if (drow.BS != "0") { total = total + double.Parse(drow.BS); }
            if (drow.CS != "0") { total = total + double.Parse(drow.CS); }
            if (drow.YAGAIKOKOKU != "0") { total = total + double.Parse(drow.YAGAIKOKOKU); }
            if (drow.EVENT != "0") { total = total + double.Parse(drow.EVENT); }
            if (drow.TYOUSA != "0") { total = total + double.Parse(drow.TYOUSA); }
            if (drow.MEDIAFEE != "0") { total = total + double.Parse(drow.MEDIAFEE); }
            if (drow.BLANDFEE != "0") { total = total + double.Parse(drow.BLANDFEE); }
            drow.TOTAL = String.Format("{0}", total);
        }
        #endregion 全媒体の合計値を格納する.

        #region データRow初期セット.
        /// <summary>
        /// データRow初期セット.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayMediaChklstRow dispSyokirowSet(RepDsAsh.displayMediaChklstRow addrow)
        {
            addrow.seikyuno = string.Empty;
            addrow.baitaikbn = string.Empty;
            addrow.baitaicd = string.Empty;
            addrow.seikyukinkomi = string.Empty;
            addrow.seikyukin = string.Empty;
            addrow.kyokunm = string.Empty;
            addrow.kyokucd = string.Empty;
            addrow.kyokubaitaicd = string.Empty;
            addrow.hinsyunm = string.Empty;
            addrow.hinsyucd = string.Empty;
            addrow.hinsyubaitaicd = string.Empty;
            addrow.kenmei = string.Empty;
            addrow.kenmei2 = "";
            return addrow;
        }
        #endregion データRow初期セット.

        #region 合計データRow初期セット.
        /// <summary>
        /// 合計データRow初期セット.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.SeigakByMediaRow seigakSyokirowSet(RepDsAsh.SeigakByMediaRow addrow)
        {
            addrow.TVTIME = "0";
            addrow.TVSPOT = "0";
            addrow.RADIOTIME = "0";
            addrow.RADIOSPOT = "0";
            addrow.SHINBUN = "0";
            addrow.ZASSHI = "0";
            addrow.OOH = "0";
            addrow.YAGAIKOKOKU = "0";
            addrow.SEISAKU = "0";
            addrow.EVENT = "0";
            addrow.SONOTA = "0";
            addrow.NEWMEDIA = "0";
            addrow.INTERNET = "0";
            addrow.BS = "0";
            addrow.CS = "0";
            addrow.TYOUSA = "0";
            addrow.MEDIAFEE = "0";
            addrow.BLANDFEE = "0";
            return addrow;
        }
        #endregion 合計データRow初期セット.

        #region エクセル出力のファイル設定.
        /// <summary>
        /// エクセル出力のファイル設定.
        /// </summary>
        private void excelFileSet()
        {
            //ファイル保存場所設定クラスのインスタンス化.
            SaveFileDialog sfd = new SaveFileDialog();
            //現在日時.
            DateTime nowdate = DateTime.Now;
            //初期ファイル名.
            sfd.FileName = pStrRepFilNam + txtYm.Year + "年" + txtYm.Month + "月";
            //初期ファイル保存先.
            sfd.InitialDirectory = pStrRepAdrs;
            //ファイル種類の選択肢を設定.
            sfd.Filter = "XLSファイル(*.xls)|*.xls";
            //初期ファイル種類の設定.
            //[すべてのファイル]を設定.
            sfd.FilterIndex = 0;
            //タイトルの設定.
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示し、Okボタンが押下されたら.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                // 出力実行.
                this.ExcelOut(sfd.FileName);
            }
        }
        #endregion エクセル出力のファイル設定.

        #region エクセル出力.
        /// <summary>
        /// エクセル出力.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            //作業用フォルダパス.
            string workFolderPath = pStrRepTempAdrs;
            string macrofile = workFolderPath + REP_MACRO_FILENAME;
            string tempfile = workFolderPath + REP_TEMPLATE_FILENAME;

            //テーブル追加用データRow.
            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_MediumChklst);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_MediumChklst_Template);

                if (!System.IO.File.Exists(tempfile)) 
                { 
                    throw new Exception("テンプレートExcelファイルがありません。"); 
                }
                if (!System.IO.File.Exists(macrofile)) 
                { 
                    throw new Exception("マクロExcelファイルがありません。"); 
                }

                //データセットXML出力.
                //2015/03/19 miyanoue アサヒ対応 Start
                //DataSet ds = new DataSet();
                RepDsAsh ds = new RepDsAsh();
                //ds = repDsMedia;
                DataRow[] row = repDsMedia.displayMediaChklst.Select("", "order, tokuisakibaitaicd");
                for (int i = 0; i < row.Length; i++)
                {
                    ds.displayMediaChklst.ImportRow(row[i]);
                }
                ds.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                //2015/03/19 miyanoue アサヒ対応 End

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                //dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                //dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";

                dtTable.Rows.Add(dtRow);

                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_MediumChklst, KKHLogUtilityAsh.DESC_OPERATION_LOG_MediumChklst);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion エクセル出力.

        #region インデックスから媒体コード取得.
        /// <summary>
        /// インデックスから媒体コード取得.
        /// </summary>
        /// <param name="baitaiNm"></param>
        /// <returns></returns>
        private string baitaiNmOfCode(string baitaiNm)
        {
            switch (baitaiNm)
            {
                //テレビタイム.
                case KkhConstAsh.BaitaiNm.TV_TIME:
                    return KkhConstAsh.BaitaiCd.TV_TIME;
                //ラジオタイム.
                case KkhConstAsh.BaitaiNm.RADIO_TIME:
                    return KkhConstAsh.BaitaiCd.RADIO_TIME;
                //ラジオスポット.
                case KkhConstAsh.BaitaiNm.RADIO_SPOT:
                    return KkhConstAsh.BaitaiCd.RADIO_SPOT;
                //テレビスポット.
                case KkhConstAsh.BaitaiNm.TV_SPOT:
                    return KkhConstAsh.BaitaiCd.TV_SPOT;
                //新聞.
                case KkhConstAsh.BaitaiNm.SHINBUN:
                    return KkhConstAsh.BaitaiCd.SHINBUN;
                //雑誌.
                case KkhConstAsh.BaitaiNm.ZASHI:
                    return KkhConstAsh.BaitaiCd.ZASHI;
                //交通.
                case KkhConstAsh.BaitaiNm.KOUTSU:
                    return KkhConstAsh.BaitaiCd.KOUTSU;
                //制作.
                case KkhConstAsh.BaitaiNm.SEISAKU:
                    return KkhConstAsh.BaitaiCd.SEISAKU;
                //その他.
                case KkhConstAsh.BaitaiNm.SONOTA:
                    return KkhConstAsh.BaitaiCd.SONOTA;
                //ニューメディア.
                case KkhConstAsh.BaitaiNm.NEW_MEDIA:
                    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                //インターネット.
                case KkhConstAsh.BaitaiNm.INTERNET:
                    return KkhConstAsh.BaitaiCd.INTERNET;
                //BS.
                case KkhConstAsh.BaitaiNm.BS:
                    return KkhConstAsh.BaitaiCd.BS;
                //CS.
                case KkhConstAsh.BaitaiNm.CS:
                    return KkhConstAsh.BaitaiCd.CS;
                //屋外広告.
                case KkhConstAsh.BaitaiNm.OKUGAI:
                    return KkhConstAsh.BaitaiCd.OKUGAI;
                //ｲﾍﾞﾝﾄ.
                case KkhConstAsh.BaitaiNm.EVENT:
                    return KkhConstAsh.BaitaiCd.EVENT;
                //調査.
                case KkhConstAsh.BaitaiNm.TYOUSA:
                    return KkhConstAsh.BaitaiCd.TYOUSA;
                //メディアフィー.
                case KkhConstAsh.BaitaiNm.MEDIA_FEE:
                    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                //ブランド管理フィー.
                case KkhConstAsh.BaitaiNm.BRAND_FEE:
                    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                //合計.
                case KkhConstAsh.BaitaiNm.GOKEI:
                    return KkhConstAsh.BaitaiCd.GOKEI;
            }

            return string.Empty;
        }
        #endregion インデックスから媒体コード取得.

        #region 小数点を指定の位置で四捨五入する.
        /// <summary>
        /// 小数点を指定の位置で四捨五入する.
        /// </summary>
        /// <param name="dValue">四捨五入する値</param>
        /// <param name="iDigits">小数点以下の桁数</param>
        /// <returns></returns>
        public static double ToHalfAdjust(double dValue, int iDigits)
        {
            double dv = dValue % 1.0;
            if (dv.ToString().Length <= 1) 
            {
                return dValue; 
            }

            double dCoef = System.Math.Pow(10, iDigits);

            return dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
                                System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
        }
        #endregion 小数点を指定の位置で四捨五入する.

        #region データバインド.
        /// <summary>
        /// データバインド.
        /// </summary>
        /// <param name="baitaiCd"></param>
        private void BindingSource(string baitaiCd)
        {
            //請求額計算用.
            double syoukeiKomi = 0;
            RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + baitaiCd);

            //該当媒体のデータがない.
            if (rows.Length == 0)
            {
                txtSeiGak.Text = "0";
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //表示用テーブル.
            RepDsAsh.displayMediaChklstDataTable dispTable = new RepDsAsh.displayMediaChklstDataTable();
            foreach (RepDsAsh.displayMediaChklstRow dispDr in rows)
            {
                //請求額計算.
                syoukeiKomi += double.Parse(dispDr.seikyukinkomi);
                dispTable.ImportRow(dispDr);
            }

            //請求額表示.
            txtSeiGak.Text = string.Format("{0:N0}", syoukeiKomi);

            //[請求金]列を表示.
            medMain_Sheet1.Columns[9].Visible = true;

            //件数.
            lblKensu.Text = rows.Length.ToString() + "件";

            //スプレッドデータソースへ入れる.
            medMain_Sheet1.DataSource = dispTable;
        }
        #endregion データバインド.

        #region 合計作成.
        /// <summary>
        /// 合計作成.
        /// </summary>
        private void MakeSum()
        {
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD Start */
            //媒体コード、媒体名称.
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();
            /* 2015/02/23 アサヒ対応 JSE Miyanoue ADD End */

            int count = 0;
            decimal gokei = 0M;

            //表示用テーブル.
            RepDsAsh.displayMediaChklstDataTable dispTable = new RepDsAsh.displayMediaChklstDataTable();

            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD Start */
            //for (int i = 0; i < baitaiCdArr.Length; i++)
            for (int i = 0; i < resultList.Count; i++)
            {
                double syoukeiKomi = 0;
                //RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + baitaiCdArr[i]);
                RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + resultList[i].baitaiCd);

                RepDsAsh.displayMediaChklstRow rows2 = (RepDsAsh.displayMediaChklstRow)dispTable.NewRow();

                //DataSet初期化.
                rows2 = dispSyokirowSet(rows2);
                //媒体名.
                //rows2.kenmei = baitaiNameArr[i];
                rows2.kenmei = resultList[i].baitaiNm;
                /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD End */

                //税込.
                rows2.seikyukinkomi = "0";

                //レコードがある媒体は税込の合計を算出.
                if (rows.Length > 0)
                {
                    // 請求額計算.
                    foreach (RepDsAsh.displayMediaChklstRow dispDr in rows)
                    {
                        syoukeiKomi += double.Parse(dispDr.seikyukinkomi);
                        //dispTable.ImportRow(dispDr);
                    }

                    //請求金額税込をセット.
                    rows2.seikyukinkomi = string.Format("{0:N0}", syoukeiKomi);
                    //合計.
                    gokei += decimal.Parse(rows2.seikyukinkomi);
                }

                //DataTableに追加.
                dispTable.Rows.Add(rows2);
                count++;
            }

            //合計金額.
            txtSeiGak.Text = string.Format("{0:N0}", gokei);

            //件数.
            lblKensu.Text = count + "件";

            //[請求金]列を表示.
            medMain_Sheet1.Columns[9].Visible = false;

            //スプレッドデータソースへ入れる.
            medMain_Sheet1.DataSource = dispTable;
        }
        #endregion 合計作成.
        #endregion メソッド.
    }
}
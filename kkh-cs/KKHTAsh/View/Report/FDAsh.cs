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
using Isid.KKH.Common.KKHUtility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// 請求データ作成画面.
    /// </summary>
    public partial class FDAsh : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数.
        #region スプレッド項目番号.
        /// <summary>
        /// スプレッド項目番号:番号.
        /// </summary>
        private const int cKNo = 0;
        /// <summary>
        /// スプレッド項目番号:請求書番号.
        /// </summary>
        private const int cKSeikyuNo = 1;
        /// <summary>
        /// スプレッド項目番号:媒体コード(システム用).
        /// </summary>
        private const int cKBaitaiCd = 2;
        /* 2015/02/24 表示用媒体コードを追加 A.Hisada ADD Start */
        /// <summary>
        /// スプレッド項目番号:媒体コード.
        /// </summary>
        private const int cKNewBaitaiCd = 3;
        /* 2015/02/24 表示用媒体コードを追加 A.Hisada ADD End */
        /// <summary>
        /// スプレッド項目番号:請求金額.
        /// </summary>
        private const int cKSeikyuKin = 4;
        /// <summary>
        /// スプレッド項目番号:局コード.
        /// </summary>
        private const int cKKyokuCd = 5;
        /// <summary>
        /// スプレッド項目番号:品種コード.
        /// </summary>
        private const int cKHinshuCd = 6;
        /// <summary>
        /// スプレッド項目番号:代理店コード.
        /// </summary>
        private const int cKDairitenCd = 7;
        /// <summary>
        /// スプレッド項目番号:番組コード.
        /// </summary>
        private const int cKBangumiCd = 8;
        /// <summary>
        /// スプレッド項目番号:件名.
        /// </summary>
        private const int cKKenmei = 9;
        /// <summary>
        /// スプレッド項目番号:請求日.
        /// </summary>
        private const int cKSeikyuBi = 10;
        #endregion スプレッド項目番号.

        #region 帳票.
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD Start */
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_Fd.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロテンプレート)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_Fd_Template.xls";
        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_Fd_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_Fd_Prop.xml";
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD End */
        #endregion 帳票.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 保存先.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名用.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// 消費税率.
        /// </summary>
        private double pSyohizeiritu;
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD Start */
        /// <summary>
        /// 保存先(アップロード出力).
        /// </summary>
        private string pStrRepAdrs2 = "";
        /// <summary>
        /// 帳票名用(アップロード出力).
        /// </summary>
        private string pStrRepFilNam2 = "";
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// コピーマクロ削除用string
        /// </summary>
        private string _strmacrodel;
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD End */
        /* 2015/02/24 A.Hisada ADD Start */
        /// <summary>
        /// 媒体コード-得意先媒体コード変換クラス.
        /// </summary>      
        private AshBaitaiUtility baitaiHenkanUtil;
        /* 2015/02/24 A.Hisada ADD End */
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FDAsh()
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
        private void FDAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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

        #region フォームロード時.
        /// <summary>
        /// フォームロード時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FDAsh_Shown(object sender, EventArgs e)
        {
            //ローディング表示.
            base.ShowLoadingDialog();

            //編集.
            EditControl();

            //消費税.
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
                //消費税率セット.
                pSyohizeiritu = 1 + KKHUtility.DouParse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());

                //テンプレートアドレス.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }
            else
            {
                pSyohizeiritu = 1;
            }

            //保存情報 + 帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "004");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();

                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //保存情報 + 帳票名.
            FindCommonByCondServiceResult comResult3 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "005");
            if (comResult3.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs2 = comResult3.CommonDataSet.SystemCommon[0].field2.ToString();

                //名称セット.
                pStrRepFilNam2 = comResult3.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            /* 2015/02/19 得意先媒体コードへの変換処理対応 Fukuda ADD Start */
            ////媒体コード-得意先媒体コード変換クラスのインスタンス生成.
            baitaiHenkanUtil = new AshBaitaiUtility(_naviParam.strEsqId
                                                                      , _naviParam.strEgcd
                                                                      , _naviParam.strTksKgyCd
                                                                      , _naviParam.strTksBmnSeqNo
                                                                      , _naviParam.strTksTntSeqNo);
            /* 2015/02/19 得意先媒体コードへの変換処理対応 Fukuda ADD End */

            //ローディング非表示.
            base.CloseLoadingDialog();
        }
        #endregion フォームロード時.

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

                //マクロファイルの削除(VBA側では削除できない為)
                //ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    //読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    //ファイルを削除する.
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
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //表示.
            DisplayView();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion 表示ボタンクリック.

        #region Excelボタンクリック.
        /// <summary>
        /// Excelボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            FileOut(medMain_Sheet1);
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

        #region 年月コンボボックスアクティブ処理.
        /// <summary>
        /// 年月コンボボックスアクティブ処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
            btnUpload.Enabled = false;
        }
        #endregion 年月コンボボックスアクティブ処理.

        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) JSE K.Fukuda ADD Start */
        #region アップロード出力ボタンクリック処理.
        /// <summary>
        /// アップロード出力ボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //Excel出力のファイル設定.
            excelFileSet();
            this.ActiveControl = null;
        }
        #endregion アップロード出力ボタンクリック処理.
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) JSE K.Fukuda ADD End */
        #endregion イベント.

        #region メソッド.
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
            
            //媒体コード用.
            string strBaiCd = string.Empty;      
            //番号.
            int intDispNo = 0;
            //金額(消費税あり).
            double dblKingakuZeiAri = 0;
            //金額(消費税なし).
            double dblKingakuZeiNashi = 0;
            //非課税金額.
            double dblKingakuHikazei = 0;
            //消費税率.
            double dblShohizeiRitu = 0;
            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga DEL Start */
            ////差額.
            //double dblSagaku = 0;
            ////端数調整用金額.
            //double choseikin = 0;
            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga DEL End */
            //総合計.
            double dblSogoukei = 0;
            /* 2013/12/05 消費税対応 HLC H.Watabe Add Start */
            List<double> listTaxRate = new List<double>();
            List<double> listAmount = new List<double>();
            /* 2013/12/05 消費税対応 HLC H.Watabe Add End */

            /*
             * パラメーターのセット.
             */
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = txtYm.Value;

            /*
             * 検索.
             */
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findFD(param);
            //エラーの場合.
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }
            //検索した結果が0件の場合.
            RepDsAsh.FDAshRow[] resultRow = (RepDsAsh.FDAshRow[])result.dsAshDataSet.FDAsh.Select("", "");
            if (resultRow.Length == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = resultRow.Length.ToString() + "件";
                btnXls.Enabled = false;
                btnUpload.Enabled = false;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "請求データ作成", MessageBoxButtons.OK);
                return;
            }

            /*
             * データセットのインスタンス生成.
             */
            RepDsAsh dsash = new RepDsAsh();
            RepDsAsh.displayFDRow addSyokeiout = dsash.displayFD.NewdisplayFDRow();
            addSyokeiout = syokirowSet(addSyokeiout);
            int count = 0;

            //請求データ件数分ループ処理.
            foreach (RepDsAsh.FDAshRow row in resultRow)
            {
                //表示用データRow
                RepDsAsh.displayFDRow addrow = dsash.displayFD.NewdisplayFDRow();
                //表示用(小計用)データRow
                RepDsAsh.displayFDRow addSyokei = dsash.displayFD.NewdisplayFDRow();

                //表示用データRow初期化.
                addrow = syokirowSet(addrow);

                //媒体コード保持.
                if (count == 0)
                {
                    strBaiCd = row.baitaicd;
                }

                //金額が0でなければ番号カウントアップ.
                if (!row.seikyukin.Equals("0"))
                {
                    intDispNo++;
                }

                //前回の媒体コードと違う場合は小計を出す.
                if (strBaiCd != row.baitaicd.Trim())
                {
                    //表示用データRow初期化.
                    addrow = syokirowSet(addrow);
                    //表示用(媒体合計用)データRow初期化.
                    addSyokei = syokirowSet(addSyokei);

                    /* 2013/12/05 消費税対応 HLC H.Watabe MOD Start */
                    //差額計算.
                    //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
                    //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;
                    //媒体の最終データで端数調整.
                    //choseikin = KKHUtility.DouParse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + dblSagaku;
                    //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = choseikin.ToString();

                    //媒体合計.
                    double baitaigokei = 0;

                    /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD Start */
                    //for (int index = 0; index < listTaxRate.Count; index++)
                    //{
                    //    // 2015/06/08 K.F Cng Start 新広告費明細　アサヒ消費税対応.
                    //    //baitaigokei += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
                    //    baitaigokei += Math.Round((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
                    //    // 2015/06/08 K.F Cng End 新広告費明細　アサヒ消費税対応.
                    //}
                    //dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + baitaigokei - dblKingakuZeiAri;
                    //if (listAmount.Count == 1 && listTaxRate[0] == 0)
                    //{
                    //    dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin);
                    //    baitaigokei = dblSagaku;
                    //}
                    //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = dblSagaku.ToString();

                    //各媒体の明細件数分ループ処理.
                    for (int index = 0; index < listAmount.Count; index++)
                    {
                        //各媒体の合計を取得.
                        baitaigokei += listAmount[index];
                    }
                    /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD End */

                    //媒体合計.
                    addSyokei.newbaitaicd = KKHSystemConst.KoteiMongon.BAITAI_GOUKEI;

                    //媒体合計金額.
                    //double baitaigokei = dblKingakuZeiAri + dblSagaku;
                    addSyokei.seikyukin = baitaigokei.ToString();
                    /* 2013/12/05 消費税対応 HLC H.Watabe MOD End */

                    //追加.
                    dsash.displayFD.AdddisplayFDRow(addSyokei);

                    //総合計計算.
                    dblSogoukei = dblSogoukei + baitaigokei;

                    //媒体変更のため、変数初期化.
                    dblKingakuZeiAri = 0;
                    dblKingakuZeiNashi = 0;
                    dblKingakuHikazei = 0;

                    /* 2013/12/05 消費税対応 HLC H.Watabe ADD Start */
                    listAmount.Clear();
                    listTaxRate.Clear();
                    /* 2013/12/05 消費税対応 HLC H.Watabe ADD End */
                }

                //媒体合計金額用に金額をセット.
                dblKingakuZeiAri = dblKingakuZeiAri + KKHUtility.DouParse(row.seikyukinzeiari);
                dblKingakuZeiNashi = dblKingakuZeiNashi + KKHUtility.DouParse(row.seikyukinzeinashi);
                
                //非課税金額.
                if(row.shohizeiritu.Equals("0"))
                {
                    dblKingakuHikazei = dblKingakuHikazei + KKHUtility.DouParse(row.seikyukin); 
                }

                //消費税率.
                if (!row.shohizeiritu.Equals("0"))
                {
                    dblShohizeiRitu = 1 + (KKHUtility.DouParse(row.shohizeiritu) * 0.01);
                }
                else
                {
                    dblShohizeiRitu = 1;
                }

                /* 2013/12/05 消費税対応 HLC H.Watabe ADD Start */
                if (listTaxRate.Count != 0)
                {
                    bool taxGetFlg = false;
                    for (int index = 0; index < listTaxRate.Count; index++)
                    {
                        if (listTaxRate[index] == double.Parse(row.shohizeiritu.Trim()))
                        {
                            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD Start */
                            //listAmount[index] += double.Parse(row.seikyukinzeinashi.Trim());
                            //媒体合計.
                            listAmount[index] += double.Parse(row.seikyukinzeiari);
                            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD End */
                            taxGetFlg = true;
                            break;
                        }
                    }
                    if (!taxGetFlg)
                    {
                        listTaxRate.Add(double.Parse(row.shohizeiritu.Trim()));
                        /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD Start */
                        //listAmount.Add(double.Parse(row.seikyukinzeinashi.Trim()));
                        //媒体合計.
                        listAmount.Add(double.Parse(row.seikyukinzeiari));
                        /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD End */
                    }
                }
                else
                {
                    listTaxRate.Add(double.Parse(row.shohizeiritu.Trim()));
                    /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD Start */
                    //listAmount.Add(double.Parse(row.seikyukinzeinashi.Trim()));
                    //媒体合計.
                    listAmount.Add(double.Parse(row.seikyukinzeiari));
                    /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD End */
                }
                /* 2013/12/05 消費税対応 HLC H.Watabe ADD End */

                //データ番号.
                addrow.no = intDispNo.ToString();

                //請求書番号.
                addrow.seikyuno = row.seikyuno;

                /* 2014/09/11 アサヒビールラジオスポット対応 HLC fujimoto MOD start */
                //媒体コード.
                //addrow.baitaicd = row.baitaicd;
                //媒体コードがラジオスポットの場合.
                if (row.baitaicd.ToString().Equals(KkhConstAsh.BaitaiCd.RADIO_SPOT))
                {
                    //得意先がアサヒビールの場合.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        addrow.baitaicd = KkhConstAsh.BaitaiCd.RADIO_TIME;
                    }
                    else
                    {
                        addrow.baitaicd = row.baitaicd;
                    }
                }
                else
                {
                    addrow.baitaicd = row.baitaicd;
                }
                /* 2014/09/11 アサヒビールラジオスポット対応 HLC fujimoto MOD end */

                ///* 2015/02/19 得意先媒体コードへの変換処理対応 fukuda ADD start */
                AshBaitaiUtility.BaitaiResult cnvBaitaiRes = baitaiHenkanUtil.ConvertOldCdToNewCd(addrow.baitaicd);
                addrow.newbaitaicd = cnvBaitaiRes.baitaiCd;
                ///* 2015/02/19 得意先媒体コードへの変換処理対応 fukuda ADD end */

                //請求金額.
                addrow.seikyukin = row.seikyukinzeiari;

                //局コード.
                addrow.kyokucd = row.kyokucd;

                //品種コード.
                addrow.hinsyucd = row.hinsyucd;

                //代理店コード.
                addrow.dairitencd = row.dairitencd;

                //番組コード.
                addrow.bangumicd = row.bangumicd;

                //件名.
                addrow.kenmei = row.kenmei;

                //請求日.
                //表示月の最終日.
                string lastday = DateTime.DaysInMonth(KKHUtility.IntParse(txtYm.Year), KKHUtility.IntParse(txtYm.Month)).ToString();
                if (lastday.Equals(String.Empty))
                {
                    addrow.seikyubi = String.Empty;
                }
                else
                {
                    addrow.seikyubi = txtYm.Year + "/" + txtYm.Month + "/" + lastday;   
                }

                //追加.
                dsash.displayFD.AdddisplayFDRow(addrow);

                //次用に媒体コードセット.
                strBaiCd = row.baitaicd.Trim();

                count++;
            }

            //表示用(媒体合計用)データRow初期化.
            addSyokeiout = syokirowSet(addSyokeiout);

            /* 2013/12/05 消費税対応 HLC H.Watabe MOD Start */
            //差額計算.
            //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
            //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;

            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD Start */
            ////媒体の最終データで端数調整.            
            //double baitaigokeiout = 0;
            //for (int index = 0; index < listTaxRate.Count; index++)
            //{
            //    // 2015/06/08 K.F Cng Start 新広告費明細　アサヒ消費税対応.
            //    //baitaigokeiout += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //    baitaigokeiout += Math.Round((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //    // 2015/06/08 K.F Cng End 新広告費明細　アサヒ消費税対応.
            //}
            //dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + baitaigokeiout - dblKingakuZeiAri;
            //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = dblSagaku.ToString();

            //媒体合計.         
            double baitaigokeiout = 0;

            //各媒体の明細件数分ループ処理.
            for (int index = 0; index < listAmount.Count; index++)
            {
                //各媒体の合計を取得.
                baitaigokeiout += listAmount[index];
            }
            /* 2016/11/24 アサヒ消費税対応 HLC H.Soga MOD End */

            //媒体合計.
            addSyokeiout.newbaitaicd = KKHSystemConst.KoteiMongon.BAITAI_GOUKEI;

            //媒体合計金額.
            //double baitaigokei = dblKingakuZeiAri + dblSagaku;
            addSyokeiout.seikyukin = baitaigokeiout.ToString();

            //差額計算.
            //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
            //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;
            //媒体の最終データで端数調整.
            //choseikin = KKHUtility.DouParse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + dblSagaku;
            //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = choseikin.ToString();
            //媒体合計.
            //addSyokeiout.baitaicd = "媒体合計";
            //媒体合計金額.
            //double baitaigokeiout = dblKingakuZeiAri + dblSagaku;
            //addSyokeiout.seikyukin = baitaigokeiout.ToString();
            /* 2013/12/05 消費税対応 HLC H.Watabe MOD End */

            //追加.
            dsash.displayFD.AdddisplayFDRow(addSyokeiout);

            //総合計計算.
            dblSogoukei = dblSogoukei + baitaigokeiout;

            //表示用(総合計用)データRow初期化.
            addSyokeiout = dsash.displayFD.NewdisplayFDRow();
            addSyokeiout = syokirowSet(addSyokeiout);

            //総合計.
            addSyokeiout.newbaitaicd = KKHSystemConst.KoteiMongon.SOUGOUKEI;

            //総合計金額.
            addSyokeiout.seikyukin = dblSogoukei.ToString();

            //追加.
            dsash.displayFD.AdddisplayFDRow(addSyokeiout);

            //カンマを付ける.
            for (int i = 0; i < dsash.displayFD.Rows.Count; i++)
            {
                double kanma = 0;
                //請求金額.
                if (!string.IsNullOrEmpty(dsash.displayFD[i].seikyukin))
                {
                    kanma = double.Parse(dsash.displayFD[i].seikyukin);
                    dsash.displayFD[i].seikyukin = kanma.ToString("#,0");
                }
            }

            //スプレッドデータソースへ入れる.
            medMain_Sheet1.DataSource = dsash.displayFD;

            //エクセルボタン.
            btnXls.Enabled = true;
            btnUpload.Enabled = true;

            //件数の表示.
            lblKensu.Text = dsash.displayFD.Rows.Count.ToString() + "件";

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion データ表示.

        #region データRow初期セット.
        /// <summary>
        /// データRow初期セット.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayFDRow syokirowSet(RepDsAsh.displayFDRow addrow)
        {
            addrow.no = string.Empty;
            addrow.seikyuno = string.Empty;
            addrow.baitaicd = string.Empty;
            addrow.seikyukin = string.Empty;
            addrow.kyokucd = string.Empty;
            addrow.hinsyucd = string.Empty;
            addrow.dairitencd = string.Empty;
            addrow.bangumicd = string.Empty;
            addrow.kenmei = string.Empty;
            addrow.seikyubi = string.Empty;
            /* 2015/02/24 新媒体コード追加 A.Hisada ADD Start */
            addrow.newbaitaicd = string.Empty;
            return addrow;
        }
        #endregion データRow初期セット.

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

        #region ファイル出力.
        /// <summary>
        /// ファイル出力.
        /// </summary>
        /// <param name="view"></param>
        private void FileOut(FarPoint.Win.Spread.SheetView view)
        {
            //SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            //日付.
            DateTime now = DateTime.Now;

            //はじめのファイル名を指定する.
            if (pStrRepFilNam.Equals(String.Empty))
            {
                sfd.FileName = "ASAHICM" + ".csv";
            }
            else
            {
                sfd.FileName = pStrRepFilNam + ".csv";
            }

            //はじめに表示されるフォルダを指定する.
            if (pStrRepAdrs.Equals(String.Empty))
            {
                sfd.InitialDirectory = "C:\\TMP\\";
            }
            else
            {
                sfd.InitialDirectory = pStrRepAdrs;
            }

            //[ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter = "CSV(ｶﾝﾏ区切り)(*.csv)|*.csv|すべてのファイル|*.*";

            //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 1;

            //タイトルを設定する.
            sfd.Title = "ファイル指定";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;

                WriteFile(filnm, view);

                MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { "完了しました" } , "ファイル出力", MessageBoxButtons.OK);
            }

            sfd.Dispose();
        }
        #endregion ファイル出力.

        #region FDを書き込む.
        /// <summary>
        /// FDを書き込む.
        /// </summary>
        /// <param name="P_FileName"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        private int WriteFile(String P_FileName, FarPoint.Win.Spread.SheetView view)
        {
            //ファイル出力するデータ.
            String L_Str;
            //スプレッドデータ.
            String L_Buf;

            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(P_FileName, false, enc);

            for (int i = 0; i < view.Rows.Count; i++)
            {
                if (!view.Cells[i, cKNo].Value.ToString().Equals(String.Empty))
                {
                    L_Str = "";

                    //番号.
                    L_Buf = view.Cells[i, cKNo].Value.ToString();
                    if (L_Buf.Length < 4)
                    {
                        L_Str = L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Buf.Substring(0, 4) + ",";
                    }

                    //請求書番号.
                    L_Buf = view.Cells[i, cKSeikyuNo].Value.ToString();
                    if (L_Buf.Length < 20)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 20) + ",";
                    }

                    /* 2015/02/24 新媒体コードを表示 A.Hisada ADD Start */
                    //媒体コード.
                    L_Buf = view.Cells[i, cKNewBaitaiCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }
                    /* 2015/02/24 新媒体コードを表示 A.Hisada ADD End */

                    //局コード.
                    L_Buf = view.Cells[i, cKKyokuCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }

                    //品種コード.
                    L_Buf = view.Cells[i, cKHinshuCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }

                    //代理店コード.
                    L_Buf = view.Cells[i, cKDairitenCd].Value.ToString();
                    if (L_Buf.Length < 2)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                    }

                    //番組コード.
                    L_Buf = view.Cells[i, cKBangumiCd].Value.ToString();
                    if (L_Buf.Length < 2)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                    }

                    //請求金額.
                    L_Buf = view.Cells[i, cKSeikyuKin].Value.ToString().Replace(",","") ;
                    if (L_Buf.Length < 13)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 13) + ",";
                    }

                    //請求日.
                    L_Buf = view.Cells[i, cKSeikyuBi].Value.ToString();
                    if (L_Buf.Length < 10)
                    {
                        L_Str = L_Str + L_Buf.Trim().PadRight(10)  + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 10) + ",";
                    }

                    //件名.
                    L_Buf = view.Cells[i, cKKenmei].Value.ToString();
                    if (L_Buf.Length < 40)
                    {
                        L_Str = L_Str + L_Buf.Trim();
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 40);
                    }

                    //フィールドを書き込む.
                    streamWriter.WriteLine(L_Str);
                }
            }

            //閉じる.
            streamWriter.Close();

            // オペレーションログの出力.
            KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_FD_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_FD, KKHLogUtilityAsh.DESC_OPERATION_LOG_FD);
            return 0;
        }
        #endregion FDを書き込む.

        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD Start */
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
            sfd.FileName = pStrRepFilNam2 + "_" + nowdate.ToString("yyyyMMddHHmmss") + ".xls";
            //初期ファイル保存先.
            sfd.InitialDirectory = pStrRepAdrs2;
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
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                /*
                 * 出力実行.
                 */
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
            //テーブル追加用データRow
            DataRow dtRow;

            try
            {
                /*
                 * Excel開始処理.
                 */
                //リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Fd);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Fd_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("テンプレートExcelファイルがありません。"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("マクロExcelファイルがありません。"); }

                //データセットXML出力.
                RepDsAsh dtRepDsAsh = new RepDsAsh();
                dtRepDsAsh.displayFD.Merge((RepDsAsh.displayFDDataTable)medMain_Sheet1.DataSource);
                for (int i = dtRepDsAsh.displayFD.Count - 1; i >= 0 ; i--)
                {
                    //Noが入っていないレコードは小計、合計行なので削除.
                    if (dtRepDsAsh.displayFD[i].no == null || dtRepDsAsh.displayFD[i].no.Trim() == "")
                    {
                        dtRepDsAsh.displayFD.Rows.RemoveAt(i);
                    }
                }
                dtRepDsAsh.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成する.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["USERNAME"] = tslName.Text;
                dtRow["SAVEDIR"] = filenm;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持(戻るボタン押下時に削除する為).
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力 .
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_FD_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_FD, KKHLogUtilityAsh.DESC_OPERATION_LOG_FD);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion エクセル出力.
        /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) Fukuda ADD End */
        #endregion メソッド.
    }
}
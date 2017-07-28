using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReportAshKoukokuHi : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数.

        #region 帳票.

        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_KoukokuHi.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロテンプレート)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_KoukokuHi_Template.xlsx";
        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_KoukokuHi_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_KoukokuHi_Prop.xml";
        /// <summary>
        /// 空白時の媒体.
        /// </summary>
        private const String BLANK_SELECTED_VALUE = "ALL";

        #endregion 帳票.

        /// <summary>
        /// アプリID.
        /// </summary>
        private const string APLID = "Koukoku";

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 消費税.
        /// </summary>
        private double _dbSyohizei;
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
        /// 年月.
        /// </summary>
        string yearmon = string.Empty;
        /// <summary>
        /// データセット.
        /// </summary>
        RepDsAsh AshDs = new RepDsAsh();
        /// <summary>
        /// Xml用データセット.
        /// </summary>
        RepDsAsh XmlDs = new RepDsAsh();
        /// <summary>
        /// 削除用データセット.
        /// </summary>
        RepDsAsh delDs = new RepDsAsh();
        /// <summary>
        /// コピーマクロ削除用string.
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// 営業日.
        /// </summary>
        string strDate = string.Empty;
        /// <summary>
        /// 合計データ数.
        /// </summary>
        string Datagoukei = string.Empty;
        /// <summary>
        /// 合計金額.
        /// </summary>
        string goukeikingak = string.Empty;

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// 
        /// </summary>
        public ReportAshKoukokuHi()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面遷移時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAshKoukokuHi_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshKoukokuHi_Shown(object sender, EventArgs e)
        {
            //ローディング表示.
            base.ShowLoadingDialog();

            //編集.
            EditControl();

            //マスタデータの取得.
            MstDataGet();

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
                                                                                            "003");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //ローディング非表示.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 表示ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            DisplayView();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

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
        /// エクセルボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {

            btnSrc_Click(new object(), new EventArgs());

            if (this.btnXls.Enabled == true)
            {
                excelDataSet();
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

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

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpYyyyMmDd_ValueChanged(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }

        #endregion イベント.

        #region メソッド.

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

        /// <summary>
        /// 各コントロール編集.
        /// </summary>
        private void EditControl()
        {
            //年月の取得.
            strDate = getHostDate();
            //ステータスの設定.
            //txtYyyy.Text = strDate.Substring(0, 4);
            //txtMm.Text = strDate.Substring(4, 2);
            //txtDay.Text = strDate.Substring(6, 2);
            string hostdate = getHostDate();
            dtpYyyyMmDd.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(hostdate);

            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //コンボボックスの設定.
            CombSet();

        }

        /// <summary>
        /// スプレッド表示.
        /// </summary>
        private void DisplayView()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //年月の取得.
            yearmon = dtpYyyyMmDd.Value.ToString("yyyyMMdd").Substring(0, 6);
            //yearmon = stry + strm;

            //パラメータの設定.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;

            //検索.
            ReportAshProcessController processcontroller = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processcontroller.findReportKoukokuHi(param);
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                return;
            }
            RepDsAsh.RepAshKoukokuHiRow[] resultRow = (RepDsAsh.RepAshKoukokuHiRow[])result.dsAshDataSet.RepAshKoukokuHi.Select("", "");
            //          tslCnt.Text = resultRow.Length.ToString() + " 件";
            lblKensu.Text = resultRow.Length.ToString() + " 件";
            if (resultRow.Length == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                //MessageBox.Show("該当データがありません");.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                btnXls.Enabled = false;
                koukokuMain_Sheet1.Rows.Count = 0;
                return;
            }

            AshDs.displayKoukokuHi.Clear();
            AshDs.TvRadioTimeKingak.Clear();

            XmlDs.displayKoukokuHi.Clear();
            XmlDs.allbaitai.Clear();
            //メンバ変数へ格納.
            AshDs.RepAshKoukokuHi.Merge(result.dsAshDataSet.RepAshKoukokuHi);
            AshDs.TvRadioTimeKingak.Merge(result.dsAshDataSet.TvRadioTimeKingak);

            //カウント用.
            int count = 0;
            //NOの振り分け用.
            int SaiNo = 0;
            //媒体別カウント.
            int BaitaiCount = 0;
            //小計金額.
            double SyoukeiKingak = 0;
            //合計金額.
            double SumKingaku = 0;
            //前回の媒体コード.
            string beforeBaitaiCd = string.Empty;

            foreach (RepDsAsh.RepAshKoukokuHiRow row in resultRow)
            {
                //データ追加用Rowの生成.
                RepDsAsh.displayKoukokuHiRow addrow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                addrow = RowSyokika(addrow);
                if (count == 0)
                {
                    beforeBaitaiCd = row.BaitaiCD.Trim();
                }

                //前回と媒体コードが違ったら小計を挿入.
                if (!beforeBaitaiCd.Equals(row.BaitaiCD.Trim()))
                {
                    //小計Add.
                    RepDsAsh.displayKoukokuHiRow SyoukeiRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                    SyoukeiRow = RowSyokika(SyoukeiRow);
                    SyoukeiRow.SeiKyuNumber = "データ数小計";
                    SyoukeiRow.Baitai = BaitaiCount.ToString();
                    SyoukeiRow.BaitaiCd = "小計";
                    SyoukeiRow.Kingak = SyoukeiKingak.ToString();
                    AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(SyoukeiRow);
                    //空白用データRowをAdd.
                    RepDsAsh.displayKoukokuHiRow BlankRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                    BlankRow = RowSyokika(BlankRow);
                    AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(BlankRow);

                    //Xml用に媒体単位で小計を格納.
                    RepDsAsh.allbaitaiRow XmlSyoukei = XmlDs.allbaitai.NewallbaitaiRow();
                    XmlSyoukei.baitaicd = beforeBaitaiCd;
                    XmlSyoukei.zeinasi = string.Empty;
                    XmlSyoukei.goukei = SyoukeiKingak.ToString();
                    XmlDs.allbaitai.AddallbaitaiRow(XmlSyoukei);

                    BaitaiCount = 0;
                    SyoukeiKingak = 0;
                    beforeBaitaiCd = row.BaitaiCD.Trim();
                }
                //No格納.
                if (double.Parse(row.Seikyukin.Trim()) > 0 || count == 0) { SaiNo = SaiNo + 1; }
                int cnt = ++count;
                //addrow.No = cnt.ToString();
                addrow.No = SaiNo.ToString();

                //請求書番号.
                addrow.SeiKyuNumber = row.SeikyuNo;
                //媒体名.
                addrow.Baitai = BaitaiCdForBaitaiNm(row.BaitaiCD.Trim());

                /* 2014/09/11 アサヒビールラジオスポット対応 HLC fujimoto MOD start */
                //媒体コード.
                //addrow.BaitaiCd = row.BaitaiCD.Trim();

                //媒体コードがラジオスポットの場合.
                if (row.BaitaiCD.Trim().ToString().Equals(KkhConstAsh.BaitaiCd.RADIO_SPOT))
                {
                    //得意先がアサヒビールの場合.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        addrow.BaitaiCd = KkhConstAsh.BaitaiCd.RADIO_TIME;
                    }
                    else
                    {
                        addrow.BaitaiCd = row.BaitaiCD.Trim();
                    }
                }
                else
                {
                    addrow.BaitaiCd = row.BaitaiCD.Trim();
                }
                /* 2014/09/11 アサヒビールラジオスポット対応 HLC fujimoto MOD end */

                //請求金額.
                switch (row.BaitaiCD.Trim())
                {
                    //テレビタイム、ラジオタイム、テレビネットスポット.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:   // 2015/06/08 K.F 新広告費明細　アサヒ対応.

                        //                      RepDsAsh.OldKyokuCdRow[] oldDatarow = (RepDsAsh.OldKyokuCdRow[])AshDs.OldKyokuCd.Select("", "");
                        //                      foreach (RepDsAsh.OldKyokuCdRow oldrow in oldDatarow)
                        //                      {
                        //                          //キー局コードと旧局情報の局コードが一致したら、料金を表示.
                        //                          if (row.Keykyoku.Trim().Equals(oldrow.Field1))
                        //                          {
                        //                              addrow.Kingak = SeiGakVisible(row.JYUTNO.Trim(), row.JYMEINO.Trim(), row.URMEINO.Trim(), row.HinsyuCD.Trim());
                        //
                        //                              break;
                        //                          }
                        //                          else
                        //                          {
                        if (row.Keykyoku.Trim().Equals(row.KyokuRyaku.Trim()))
                        {
                            addrow.Kingak = SeiGakVisible(row.JYUTNO.Trim(), row.JYMEINO.Trim(), row.URMEINO.Trim(), row.HinsyuCD.Trim());
                        }
                        //                          }
                        //                      }
                        break;

                    default:
                        addrow.Kingak = row.Seikyukin;
                        break;
                }

                //局.
                addrow.Kyoku = row.KyokuNM.Trim();
                //局コード.
                addrow.KyokuCd = row.KyokuCD.Trim();
                //品種名.
                if (!string.IsNullOrEmpty(row.HinsyuNM.Trim()))
                {
                    addrow.HinSyu = row.HinsyuNM.Trim();
                }
                //品種コード.
                addrow.HinSyuCd = row.HinsyuCD.Trim();
                //代理店名("電通"で固定).
                addrow.DairiTen = "電通";
                //代理店コード.
                addrow.DairiTenCd = row.DairitenCD.Trim();
                //番組コード.
                addrow.BangumiCd = row.BangumiCD.Trim();
                //件名.
                addrow.KenMei = row.Kenmei.Trim();

                //番組.
                RepDsAsh.BangumiDataRow[] BangumiTVDataRow = (RepDsAsh.BangumiDataRow[])AshDs.BangumiData.Select(" SYBT = '129'");
                RepDsAsh.BangumiDataRow[] BangumiRadioDataRow = (RepDsAsh.BangumiDataRow[])AshDs.BangumiData.Select("SYBT = '130'");
                switch (row.BaitaiCD.Trim())
                {

                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:  // 2015/06/08 K.F 新広告費明細　アサヒ対応.

                        foreach (RepDsAsh.BangumiDataRow bangumirow in BangumiTVDataRow)
                        {
                            if (bangumirow.BangumiCD.Trim().Equals(row.BangumiCD.Trim()))
                            {
                                addrow.Bangumi = bangumirow.BangumiNM.Trim();
                            }
                        }
                        break;


                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                        foreach (RepDsAsh.BangumiDataRow bangumiRaidorow in BangumiRadioDataRow)
                        {
                            if (bangumiRaidorow.BangumiCD.Trim().Equals(row.BangumiCD.Trim()))
                            {
                                addrow.Bangumi = bangumiRaidorow.BangumiNM.Trim();
                            }
                        }
                        break;

                    case KkhConstAsh.BaitaiCd.TV_SPOT:
                    case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                        addrow.Bangumi = "スポット";

                        break;

                    default:
                        addrow.Bangumi = BaitaiCdForBaitaiNm(row.BaitaiCD.Trim());
                        break;
                }

                //小計用に値を加算.
                SyoukeiKingak = SyoukeiKingak + double.Parse(row.Seikyukin.Trim());
                //合計用に値を加算.
                SumKingaku = SumKingaku + double.Parse(row.Seikyukin.Trim());


                AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(addrow);
                XmlDs.displayKoukokuHi.ImportRow(addrow);

                //count++;
                BaitaiCount++;
            }
            //最後の小計 挿入.
            RepDsAsh.displayKoukokuHiRow FinalSyoukeiRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
            FinalSyoukeiRow = RowSyokika(FinalSyoukeiRow);
            FinalSyoukeiRow.SeiKyuNumber = "データ数小計";
            FinalSyoukeiRow.Baitai = BaitaiCount.ToString();
            FinalSyoukeiRow.BaitaiCd = "小計";
            FinalSyoukeiRow.Kingak = SyoukeiKingak.ToString();
            AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(FinalSyoukeiRow);
            //最終行　合計　挿入.
            RepDsAsh.displayKoukokuHiRow FinalSumRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
            FinalSumRow = RowSyokika(FinalSumRow);
            FinalSumRow.SeiKyuNumber = "データ数合計";
            FinalSumRow.Baitai = count.ToString();
            FinalSumRow.BaitaiCd = "合計";
            FinalSumRow.Kingak = SumKingaku.ToString();

            //その他用にデータを保持（マクロで使用する）.
            goukeikingak = SumKingaku.ToString();
            Datagoukei = count.ToString();

            AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(FinalSumRow);

            //Xml用に媒体単位で小計を格納.
            RepDsAsh.allbaitaiRow XmlFinalSyoukei = XmlDs.allbaitai.NewallbaitaiRow();
            XmlFinalSyoukei.baitaicd = beforeBaitaiCd;
            XmlFinalSyoukei.zeinasi = string.Empty;
            XmlFinalSyoukei.goukei = SyoukeiKingak.ToString();
            XmlDs.allbaitai.AddallbaitaiRow(XmlFinalSyoukei);
            //Xml用に合計を格納.
            RepDsAsh.allbaitaiRow XmlFinalSum = XmlDs.allbaitai.NewallbaitaiRow();
            XmlFinalSum.baitaicd = KkhConstAsh.BaitaiCd.ALL_BAITAI;
            XmlFinalSum.zeinasi = string.Empty;
            XmlFinalSum.goukei = SumKingaku.ToString();
            XmlDs.allbaitai.AddallbaitaiRow(XmlFinalSum);

            //カンマを付けていく.
            for (int i = 0; i < AshDs.displayKoukokuHi.Rows.Count; i++)
            {
                double kanma = 0;
                //金額.
                if (!string.IsNullOrEmpty(AshDs.displayKoukokuHi[i].Kingak))
                {
                    kanma = double.Parse(AshDs.displayKoukokuHi[i].Kingak);
                    AshDs.displayKoukokuHi[i].Kingak = kanma.ToString("#,0");
                }
            }
            koukokuMain_Sheet1.DataSource = AshDs.displayKoukokuHi;
            btnXls.Enabled = true;

            //HorizontalAlignment処理.
            for (int i = 0; i < koukokuMain_Sheet1.RowCount; i++)
            {
                if (koukokuMain_Sheet1.Cells[i, 1].Text == "データ数小計"
                    || koukokuMain_Sheet1.Cells[i, 1].Text == "データ数合計")
                {
                    koukokuMain_Sheet1.Cells[i, 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                }
            }

            //2015/02/23 miyanoue 新広告費明細　アサヒ対応　Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //旧媒体コードから新媒体名称、新媒体コードを取得する.
            for (int i = 0; i < AshDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = AshDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                AshDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                AshDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }

            for (int i = 0; i < XmlDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = XmlDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                XmlDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                XmlDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }
            //2015/02/23 miyanoue 新広告費明細　アサヒ対応　End


            //ローディング表示終了.
            base.CloseLoadingDialog();

            //請求書番号までを固定列にする.
            koukokuMain_Sheet1.FrozenColumnCount = 2;
        }

        /// <summary>
        /// コンボボックス初期値設定.
        /// </summary>
        private void CombSet()
        {
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TV_TIME, KkhConstAsh.BaitaiCd.TV_TIME);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TV_SPOT, KkhConstAsh.BaitaiCd.TV_SPOT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.RADIO_TIME, KkhConstAsh.BaitaiCd.RADIO_TIME);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.RADIO_SPOT, KkhConstAsh.BaitaiCd.RADIO_SPOT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SHINBUN, KkhConstAsh.BaitaiCd.SHINBUN);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ZASHI, KkhConstAsh.BaitaiCd.ZASHI);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.KOUTSU, KkhConstAsh.BaitaiCd.KOUTSU);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SEISAKU, KkhConstAsh.BaitaiCd.SEISAKU);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.EVENT, KkhConstAsh.BaitaiCd.EVENT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.NEW_MEDIA, KkhConstAsh.BaitaiCd.NEW_MEDIA);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.INTERNET, KkhConstAsh.BaitaiCd.INTERNET);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.BS, KkhConstAsh.BaitaiCd.BS);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.CS, KkhConstAsh.BaitaiCd.CS);
            ////SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU, KkhConstAsh.BaitaiCd.OKUGAI);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TYOUSA, KkhConstAsh.BaitaiCd.TYOUSA);
            ////2013/02/22 jse okazaki PR媒体追加対応　Start
            ////得意先がアサヒビールの場合.
            //if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
            //{
            //    SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.PR, KkhConstAsh.BaitaiCd.PR);
            //}
            ////2013/02/22 jse okazaki PR媒体追加対応　End
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SONOTA, KkhConstAsh.BaitaiCd.SONOTA);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.MEDIA_FEE, KkhConstAsh.BaitaiCd.MEDIA_FEE);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.BRAND_FEE, KkhConstAsh.BaitaiCd.BRAND_FEE);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            //2015/02/23 miyanoue 新広告費明細　アサヒ対応　Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //旧媒体名称から新媒体名称へ変換する.

            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            //コンボボックスの生成.
            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiNm, resultList[i].baitaiCd);
            }
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            mediaCmb.DataSource = SybtNameTable;
            mediaCmb.DisplayMember = "Display";
            mediaCmb.ValueMember = "Value";
            mediaCmb.SelectedValue = KkhConstAsh.BaitaiCd.ALL_BAITAI;
        }

        /// <summary>
        /// 媒体コードから媒体名.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string BaitaiCdForBaitaiNm(string baitaiCd)
        {
            //媒体名.
            string baitaiNm = string.Empty;

            switch (baitaiCd)
            {
                case KkhConstAsh.BaitaiCd.TV_TIME:
                    baitaiNm = KkhConstAsh.BaitaiNm.TV_TIME;
                    break;
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                    baitaiNm = KkhConstAsh.BaitaiNm.TV_SPOT;
                    break;
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    baitaiNm = KkhConstAsh.BaitaiNm.RADIO_TIME;
                    break;
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    baitaiNm = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                    break;
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    baitaiNm = KkhConstAsh.BaitaiNm.SHINBUN;
                    break;
                case KkhConstAsh.BaitaiCd.ZASHI:
                    baitaiNm = KkhConstAsh.BaitaiNm.ZASHI;
                    break;
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    baitaiNm = KkhConstAsh.BaitaiNm.KOUTSU;
                    break;
                case KkhConstAsh.BaitaiCd.OKUGAI:
                    baitaiNm = KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU;
                    break;
                case KkhConstAsh.BaitaiCd.SEISAKU:
                    baitaiNm = KkhConstAsh.BaitaiNm.SEISAKU;
                    break;
                case KkhConstAsh.BaitaiCd.EVENT:
                    baitaiNm = KkhConstAsh.BaitaiNm.EVENT;
                    break;
                //2013/02/22 jse okazaki PR媒体追加対応　Start
                case KkhConstAsh.BaitaiCd.PR:
                    baitaiNm = KkhConstAsh.BaitaiNm.PR;
                    break;
                //2013/02/22 jse okazaki PR媒体追加対応　End
                case KkhConstAsh.BaitaiCd.SONOTA:
                    baitaiNm = KkhConstAsh.BaitaiNm.SONOTA;
                    break;
                case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                    baitaiNm = KkhConstAsh.BaitaiNm.NEW_MEDIA;
                    break;
                case KkhConstAsh.BaitaiCd.INTERNET:
                    baitaiNm = KkhConstAsh.BaitaiNm.INTERNET;
                    break;
                case KkhConstAsh.BaitaiCd.BS:
                    baitaiNm = KkhConstAsh.BaitaiNm.BS;
                    break;
                case KkhConstAsh.BaitaiCd.CS:
                    baitaiNm = KkhConstAsh.BaitaiNm.CS;
                    break;
                case KkhConstAsh.BaitaiCd.TYOUSA:
                    baitaiNm = KkhConstAsh.BaitaiNm.TYOUSA;
                    break;
                case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    baitaiNm = KkhConstAsh.BaitaiNm.MEDIA_FEE;
                    break;
                case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    baitaiNm = KkhConstAsh.BaitaiNm.BRAND_FEE;
                    break;
            }
            return baitaiNm;
        }

        /// <summary>
        /// マスタ情報の取得.
        /// </summary>
        private void MstDataGet()
        {
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            ReportAshProcessController processcontroller = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processcontroller.findReportMediaCode(param);
            if (result.HasError)
            {
                return;
            }
            //          if (result.dsAshDataSet.OldKyokuCd.Rows.Count == 0)
            //          {
            //             // MessageBox.Show("マスタデータがありません。システム管理者に連絡して下さい。");
            //              MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "マスタ情報取得", MessageBoxButtons.OK);
            //              return;
            //          }
            AshDs.Merge(result.dsAshDataSet);
        }

        /// <summary>
        /// 請求金額の表示、非表示.
        /// </summary>
        /// <param name="JyutNo"></param>
        /// <param name="JyMeiNo"></param>
        /// <param name="UriMeiNo"></param>
        /// <param name="HinSyuCd"></param>
        /// <returns></returns>
        private string SeiGakVisible(string JyutNo, string JyMeiNo, string UriMeiNo, string HinSyuCd)
        {
            RepDsAsh.TvRadioTimeKingakRow[] KingakRow = (RepDsAsh.TvRadioTimeKingakRow[])AshDs.TvRadioTimeKingak.Select("", "");
            foreach (RepDsAsh.TvRadioTimeKingakRow row in KingakRow)
            {
                //受注Ｎｏ、受注明細Ｎｏ、売上明細Ｎｏ、品種コードが一致する場合.
                if (JyutNo.Equals(row.JyutNo.Trim()) && JyMeiNo.Equals(row.JyMeiNo.Trim())
                   && UriMeiNo.Equals(row.UrMeiNo.Trim()) && HinSyuCd.Equals(row.HinsyuCD.Trim()))
                {
                    return row.SeiGak.Trim();
                }
            }
            return "0";
        }

        /// <summary>
        /// 行データの初期化.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayKoukokuHiRow RowSyokika(RepDsAsh.displayKoukokuHiRow addrow)
        {

            addrow.No = string.Empty;
            addrow.SeiKyuNumber = string.Empty;
            addrow.Baitai = string.Empty;
            addrow.BaitaiCd = string.Empty;
            addrow.Kingak = string.Empty;
            addrow.Kyoku = string.Empty;
            addrow.KyokuCd = string.Empty;
            addrow.HinSyu = string.Empty;
            addrow.HinSyuCd = string.Empty;
            addrow.DairiTen = string.Empty;
            addrow.DairiTenCd = string.Empty;
            addrow.Bangumi = string.Empty;
            addrow.BangumiCd = string.Empty;
            addrow.KenMei = string.Empty;

            return addrow;

        }

        /// <summary>
        /// Excel作成用データ格納.
        /// </summary>
        private void excelDataSet()
        {
            delDs.Clear();
            delDs.Merge(XmlDs);

            string selectBaitai = String.Empty;
            string selectBaitaiText = String.Empty;

            //2015/03/31 miyanoue アサヒ対応 Stret
            //if (mediaCmb.SelectedValue.Equals(KkhConstAsh.BaitaiCd.EVENT))
            //{
            //    selectBaitai = KkhConstAsh.BaitaiCd.OKUGAI + "','" + KkhConstAsh.BaitaiCd.EVENT;
            //}
            //else
            //{
            //    selectBaitai = mediaCmb.SelectedValue.ToString();
            //    selectBaitaiText = mediaCmb.Text.ToString();
            //}

            if (mediaCmb.SelectedValue.Equals(KkhConstAsh.BaitaiCd.EVENT))
            {
                selectBaitai = KkhConstAsh.BaitaiCd.OKUGAI + "','" + KkhConstAsh.BaitaiCd.EVENT;
                selectBaitaiText = mediaCmb.Text.ToString();
            }
            else
            {
                selectBaitai = mediaCmb.SelectedValue.ToString();
                selectBaitaiText = mediaCmb.Text.ToString();
            }


            //2015/03/31 miyanoue アサヒ対応 End

            //全媒体の場合.
            if ((mediaCmb.SelectedValue == null) || (mediaCmb.SelectedValue.ToString().Equals(KkhConstAsh.BaitaiCd.ALL_BAITAI)))
            {

            }
            else
            {
                /* 2014/10/09 アサヒビールラジオスポット対応 HLC fujimoto MOD start */
                //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])
                //RepDsAsh.displayKoukokuHiRow[] CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd IN ('" + selectBaitai + "') ");

                RepDsAsh.displayKoukokuHiRow[] CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select();

                //得意先がアサヒビールの場合.
                if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                {
                    //媒体名称で検索.
                    //2015/03/31 miyanoue アサヒ対応 Start
                    //CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("Baitai = '" + selectBaitaiText + "'");
                    CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("tokuisakiBaitai = '" + selectBaitaiText + "'");
                    //2015/03/31 miyanoue アサヒ対応 End
                }
                //得意先がアサヒ飲料の場合.
                else
                {
                    CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("BaitaiCd IN ('" + selectBaitai + "')");
                }
                /* 2014/10/09 アサヒビールラジオスポット対応 HLC fujimoto MOD end */

                //選択された媒体が無い場合.
                if (CheckRow.Length == 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0038, null, "帳票", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    /* 2014/10/09 アサヒビールラジオスポット対応 HLC fujimoto MOD start */
                    //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                    //foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                    //{
                    //    delDs.displayKoukokuHi.Rows.Remove(del);
                    //}
                    //RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                    //foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                    //{
                    //    delDs.allbaitai.Rows.Remove(delall);
                    //}

                    //得意先がアサヒビールの場合.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        //2015/03/31 miyanoue アサヒ対応 Start
                        //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" Baitai NOT IN ('" + selectBaitaiText + "') ");
                        RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" tokuisakiBaitai NOT IN ('" + selectBaitaiText + "') ");
                        //2015/03/31 miyanoue アサヒ対応 End
                        foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                        {
                            delDs.displayKoukokuHi.Rows.Remove(del);
                        }
                        RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select("BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                        {
                            delDs.allbaitai.Rows.Remove(delall);
                        }
                    }
                    //得意先がアサヒ飲料の場合.
                    else
                    {
                        RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                        {
                            delDs.displayKoukokuHi.Rows.Remove(del);
                        }
                        RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                        {
                            delDs.allbaitai.Rows.Remove(delall);
                        }
                    }
                    /* 2014/10/09 アサヒビールラジオスポット対応 HLC fujimoto MOD end */
                }
            }
            //2015/02/23 miyanoue 新広告費明細　アサヒ対応　Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //旧媒体コードから新媒体名称、新媒体コードを取得する.
            for (int i = 0; i < delDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = delDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                delDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                delDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }
            //2015/02/23 miyanoue 新広告費明細　アサヒ対応　End

            //エクセル出力ファイルの設定.
            excelFileSet();
        }

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
            sfd.FileName = pStrRepFilNam + "_" + nowdate.ToString("yyyyMMdd") + ".xlsx";
            //sfd.FileName = nowdate.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            //初期ファイル保存先.
            sfd.InitialDirectory = pStrRepAdrs;
            //ファイル種類の選択肢を設定.
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
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
                    //同名でファイルを削除する。.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

        }

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
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_KoukokuHi);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_KoukokuHi_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("テンプレートExcelファイルがありません。"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("マクロExcelファイルがありません。"); }


                //データセットXML出力.
                delDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                //MacLicenseeDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAICD", Type.GetType("System.String"));
                dtTable.Columns.Add("DATAGOUKEI", Type.GetType("System.String"));
                dtTable.Columns.Add("GOUKEIKINGAK", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = dtpYyyyMmDd.Value.ToString("yyyyMMdd");
                //dtRow["SELHDK"] = txtYyyy.Value.ToString() + "/" + txtMm.Value.ToString() + "/" + txtDay.Text.ToString();
                //dtRow["SELHDK"] = YymmDdSet();

                if (mediaCmb.SelectedValue != null)
                {
                    dtRow["BAITAICD"] = mediaCmb.SelectedValue.ToString();
                    //選択されたのがその他の場合.
                    if (mediaCmb.SelectedValue.ToString().Equals(KkhConstAsh.BaitaiCd.SONOTA))
                    {
                        dtRow["DATAGOUKEI"] = Datagoukei;
                        dtRow["GOUKEIKINGAK"] = goukeikingak;
                    }
                }
                else
                {
                    dtRow["BAITAICD"] = BLANK_SELECTED_VALUE;
                }

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // オペレーションログの出力.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_Koukokuhi, KKHLogUtilityAsh.DESC_OPERATION_LOG_Koukokuhi);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion メソッド.
    }

}


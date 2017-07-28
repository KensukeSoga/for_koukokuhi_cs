using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Lion.Properties;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.Utility;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailListLion : KKHForm
    {
        
        # region 定数
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_TV_TIME = "テレビタイム";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_RD_TIME = "ラジオタイム";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_TV_SPOT = "テレビスポット";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_RD_SPOT = "ラジオスポット";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_SHINBUN = "新聞";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_ZASHI = "雑誌";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_KOTSU = "交通";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_SONOTA = "その他";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_SEISAKU = "制作";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_TV_CM = "ＴＶＣＭ秒数";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_RD_CM = "ラジオＣＭ秒数";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_CHIRASHI = "チラシ";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_SAMPLING = "サンプリング";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_BS_CS = "ＢＳ・ＣＳ";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_INTERNET = "インターネット";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_MOBILE = "モバイル";
        /// <summary>
        /// 媒体： 
        /// </summary>
        private const string C_BAITAI_JIGYOUBU = "事業費";


        /// <summary>
        /// レポートライオンデータテーブル名 
        /// </summary>
        //private const string LION_TBLNM = "RepLion";
        private const string LION_TBLNM = "DetailListLion";

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtList";

        # endregion 定数

        # region メンバ変数

        /// <summary>
        /// 
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        // 媒体区分
        Hashtable htBaitaiKbn = new Hashtable();    // 媒体区分
        
        /// <summary>
        /// ライオンのデータセット.
        /// </summary>
        DataSet _dsLion = null;

        /// <summary>
        /// 保存用データセット(全体用)
        /// </summary>
        private MastLion MastLionDs = new MastLion();

        // 消費税.
        private double _dblShohizei;

        /// <summary>
        /// 検索日.
        /// </summary>
        private string _mStrDD;

        /// <summary>
        /// 媒体名.
        /// </summary>
        private string _mStrBaitaiMei;

        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;

        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;

        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string _mStrRepFileMei = string.Empty;

        /// <summary>
        /// REP_KEY_SYBT：001
        /// </summary>
        private const string REP_KEY_SYBT = "001";

        # endregion メンバ変数

        # region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public DetailListLion()
        {
            InitializeComponent();
        }
        # endregion コンストラクタ

        # region イベント
        /// <summary>
        /// 画面表示時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailListLion_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

        }

        /// <summary>
        /// 戻るボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender , EventArgs e)
        {
            Navigator.Backward(this , null , _naviParam , true);
        }

        /// <summary>
        /// 検索ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender , EventArgs e)
        {
            //期間入力チェック
            if (dtpYyyyMmDdFrom.Value > dtpYyyyMmDdTo.Value)
            {
                //Excelボタン押下不可能.
                btnXls.Enabled = false;

                _dsLion = null;

                MessageUtility.ShowMessageBox(MessageCode.HB_W0159, null, "明細一覧帳票", MessageBoxButtons.OK);
               
                return;
            }

            //*************************************.
            // DBよりレコードを取得.
            //*************************************.
            //レコード取得メソッド.
            this.GetRecord();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 出力ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender , EventArgs e)
        {
            //*************************************
            // 出力実行.
            //*************************************
            this.ExcelOut();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 画面表示時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailListLion_Shown(object sender , EventArgs e)
        {
            base.ShowLoadingDialog();

            //検索年月日取得.
            string hostdate = getHostDate();

            dtpYyyyMmDdFrom.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(hostdate.Substring(0, 6) + "01");
            dtpYyyyMmDdTo.Value = dtpYyyyMmDdFrom.Value.AddMonths(1).AddDays(-1);

            _mStrDD = hostdate.Substring(6, 2);

            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //Excelボタンを非活性化.
            btnXls.Enabled = false;

            //スプレッド初期化 
            SprSyokika();

            //消費税取得（マスタから）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {

                //消費税セット.
                _dblShohizei = KKHUtility.DouParse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス.
                _mStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //保存情報＋帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.ReportType,
                                                                                            REP_KEY_SYBT);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                _mStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                _mStrRepFileMei = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }


            //媒体区分取得（マスタから）
            Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController proccessController =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
            Isid.KKH.Common.KKHProcessController.MasterMaintenance.FindMasterMaintenanceByCondServiceResult MastResult = 
                proccessController.FindMasterByCond(
                                                    _naviParam.strEsqId
                                                    , _naviParam.strEgcd
                                                    , _naviParam.strTksKgyCd
                                                    , _naviParam.strTksBmnSeqNo
                                                    , _naviParam.strTksTntSeqNo
                                                    , KKHLionConst.C_MAST_BAITAI_CD
                                                    , string.Empty
                                                    );

            if (MastResult.MasterDataSet.MasterDataVO.Rows.Count != 0)
            {
                for (int i = 0; i < MastResult.MasterDataSet.MasterDataVO.Rows.Count; i++)
                {
                    //媒体区分コンボボックスにセット
                    if (MastResult.MasterDataSet.MasterDataVO[i].Column3.Equals("1"))
                    {
                        //出力対象の媒体区分のみコンボボックスに表示
                        cmbBaitaiKbn.Items.Add(MastResult.MasterDataSet.MasterDataVO[i].Column2);

                        //媒体区分のコードと名称をハッシュテーブルにセット
                        htBaitaiKbn.Add(MastResult.MasterDataSet.MasterDataVO[i].Column2, MastResult.MasterDataSet.MasterDataVO[i].Column1);
                    }
                }
            }


            //グリッドの設定.
            statusStrip1.Items["tslval1"].Text = "0件";
            btnXls.Enabled = false;

            //*************************
            //ライオンマスタの取得 
            //*************************
            KKHLionReadMastFile mast = new KKHLionReadMastFile();
            MastLionDs = mast.GetLionMast(_naviParam);

            if (MastLionDs.TvBnLion.Count == 0 &&
                MastLionDs.RdBnLion.Count == 0 &&
                MastLionDs.TvKLion.Count == 0 &&
                MastLionDs.RdKLion.Count == 0)
            {
                base.CloseLoadingDialog();
                Navigator.Backward(this , null , _naviParam , true);
                return;
            }

            //コンボボックスの先頭の項目をセット.
            cmbBaitaiKbn.SelectedIndex = 0;

            base.CloseLoadingDialog();
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
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
            //帳票出力を非活性化にする 
            btnXls.Enabled = false;
        }


        # endregion イベント
        # region メソッド
        
        /// <summary>
        /// レコード取得メソッド.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            # region 共通処理
            //媒体名を取得.
            _mStrBaitaiMei = cmbBaitaiKbn.Text;

            // 期間の取得 
            string yyyyMmFrom = dtpYyyyMmDdFrom.Value.ToString("yyyyMM");
            string yyyyMmTo = dtpYyyyMmDdTo.Value.ToString("yyyyMM");

            FindDetailListLionByCondServiceResult result = new FindDetailListLionByCondServiceResult();
            KKHLionReadMastFile readMastFile = new KKHLionReadMastFile();

            //*******************.
            //サービスの呼び出し.
            //*******************.
            ReportLionProcessController processController = ReportLionProcessController.GetInstance();
            result = processController.FindDetailListLionByCond(
                                                                _naviParam.strEsqId ,
                                                                _naviParam.strEgcd ,
                                                                _naviParam.strTksKgyCd ,
                                                                _naviParam.strTksBmnSeqNo ,
                                                                _naviParam.strTksTntSeqNo ,
                                                                yyyyMmFrom ,
                                                                yyyyMmTo,
                                                                htBaitaiKbn[_mStrBaitaiMei].ToString() 
                                                                );
            //エラーの場合 
            if (result.HasError)
            {
                statusStrip1.Items["tslval1"].Text = "0件";

                //ローディング表示終了 
                base.CloseLoadingDialog();
                
                return;
            }
            //取得結果が0件の場合 
            if ((result.dsDetailListLionDataSet.DetailListLion.Rows.Count == 0) 
                && ( _mStrBaitaiMei != C_BAITAI_SONOTA ))
            {

                //スプレッド初期化 
                SprSyokika();

                //Excelボタン押下不可能.
                btnXls.Enabled = false;

                _dsLion = null;

                statusStrip1.Items["tslval1"].Text = "0件";

                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "明細一覧帳票", MessageBoxButtons.OK);
                
            }

         　//スプレッドシートの初期化 
            SprSyokika();

            # endregion 共通処理
            //****************************************.
            //スプレッドに表示(件数分表示).
            //****************************************.
            //シートを判別.
            //テレビ番組の場合.
            # region テレビ番組
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals (KKHLionConst.BAITAIKBN_TV)) 
            {

                //シートを表示する.
                sprTV_Time.Visible = true;

                if (sprTV_Time.Columns[0].Label.Equals("データ年月"))
                {
                    //データ年月を2列目に移動
                    sprTV_Time.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    //************
                    //変数初期化.
                    //************
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblDenpaRyoShoKei = 0;             //電波料小計.
                    double _dblNetRyoShoKei = 0;               //ネット料小計.
                    double _dblSeisakuHiShoKei = 0;            //制作費小計.
                    double _dblSeikyuGakShoKei = 0;            //請求額小計.

                    double _dblDenpaRyoGoKei = 0;           //電波料合計.
                    double _dblNetRyoGoKei = 0;             //ネット料合計.
                    double _dblSeisakuHiGoKei = 0;          //制作費合計.
                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _dblShohizeiGakGokei = 0;        //消費税額合計.

                    # region シートにセット.
                    for (int i = 0 ; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count ; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTV_Time.Rows.Add(sprTV_Time.RowCount ,1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //カードNo、番組コードを保持.
                            _strCardNo = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
                            _strBangumiCD = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();
                        }

                        //カードNo.
                        sprTV_Time.Cells[_intRow , 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprTV_Time.Cells[_intRow , 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprTV_Time.Cells[_intRow , 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprTV_Time.Cells[_intRow , 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();
                        
                        //番組コード.
                        sprTV_Time.Cells[_intRow , 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

                        //局誌コード.
                        sprTV_Time.Cells[_intRow , 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();
                        
                        //局誌名称.
                        sprTV_Time.Cells[_intRow , 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();
                        
                        //電波料 = 請求額 - ネット料 - 制作費.
                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        //double _dblSeikyuGak = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        //ネット料.
                        double _dblNetRyo = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
                        //double _dblNetRyo = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
                        //制作費.
                        double _dblSeisakuHi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
                        //double _dblSeisakuHi = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
                        //電波料.
                        double _dblDenpaRyo = _dblSeikyuGak - _dblNetRyo - _dblSeisakuHi;

                        sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyo.ToString("#,0");

                        //ネット料.
                        sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyo.ToString("#,0");
                        
                        //制作費.
                        sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHi.ToString("#,0");
                        
                        //請求額.
                        sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGak.ToString("#,0");

                        //放送回数.
                        sprTV_Time.Cells[_intRow , 11].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString();
                    
                        //番組名.
                        sprTV_Time.Cells[_intRow , 12].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiMei"].ToString();

                        //******************.
                        //各小計額をセット.
                        //******************.
                        //電波料小計.
                        _dblDenpaRyoShoKei += _dblDenpaRyo;

                        //ネット料小計.
                        _dblNetRyoShoKei += _dblNetRyo;

                        //制作費小計.
                        _dblSeisakuHiShoKei += _dblSeisakuHi;

                        //請求金額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //******************.
                        //各合計額をセット.
                        //******************.
                        //電波料合計.
                        _dblDenpaRyoGoKei += _dblDenpaRyo;

                        //ネット料合計.
                        _dblNetRyoGoKei += _dblNetRyo;

                        //制作費合計.
                        _dblSeisakuHiGoKei += _dblSeisakuHi;

                        //請求金額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //消費税額合計.
                        _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
                        //_dblShohizeiGakGokei += double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTV_Time.Rows.Add(sprTV_Time.RowCount , 1);

                    sprTV_Time.Cells[_intRow , 6].Value = "代理店計";
                    
                    //電波料合計.
                    sprTV_Time.Cells[_intRow, 7].Value = _dblDenpaRyoGoKei.ToString("#,0");
                    
                    //ネット料合計.
                    sprTV_Time.Cells[_intRow, 8].Value = _dblNetRyoGoKei.ToString("#,0");
                    
                    //制作費合計.
                    sprTV_Time.Cells[_intRow, 9].Value = _dblSeisakuHiGoKei.ToString("#,0");
                    
                    //請求額合計.
                    sprTV_Time.Cells[_intRow, 10].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTV_Time.Rows.Add(sprTV_Time.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprTV_Time.Cells[_intRow , 6].Value = "消費税計";

                    //sprTV_Time.Cells[_intRow, 10].Value = _dblShohizeiGakGokei.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprTV_Time.Cells[_intRow, 10].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0 ; i < 6 ; i++)
                    {
                        sprTV_Time.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    //放送回数.
                    sprTV_Time.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                }
                # endregion シートにセット.

                //カードNoと代理店コードを非表示にする
                sprTV_Time.Columns[0].Visible = false;
                sprTV_Time.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprTV_Time.MoveColumn(1, 0, true); 
            }
            # endregion テレビ番組

            //テレビスポットの場合.
            # region テレビスポット

            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_TV_SPOT)) 
            {
                //シートを表示する.
                sprTV_Spot.Visible = true;

                if (sprTV_Spot.Columns[0].Label.Equals("データ年月"))
                {
                    //データ年月を2列目に移動
                    sprTV_Spot.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;


                    //************
                    //変数初期化.
                    //************
                    string _strBrandCd = string.Empty;      //ブランドコード.
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblSeikyuGakShoKei = 0;         //請求額小計.
                    double _dblHonsuShokei = 0;             //本数小計.
                    double _dblByosuShoKei = 0;             //CM秒数小計.

                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _dblHonsuGokei = 0;              //CM本数合計.
                    double _dblByosuGoKei = 0;              //CM秒数合計.

                    double _dblShohizeiGakGokei = 0;        //消費税額合計.

                    # region シートにセット.
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを保持.
                            _strBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprTV_Spot.Cells[_intRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprTV_Spot.Cells[_intRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprTV_Spot.Cells[_intRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprTV_Spot.Cells[_intRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprTV_Spot.Cells[_intRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprTV_Spot.Cells[_intRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //局誌コード.
                        sprTV_Spot.Cells[_intRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

                        //局誌名称.
                        sprTV_Spot.Cells[_intRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        //double _dblSeikyuGak = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGak.ToString("#,0");

                        //CM1本の秒数.
                        sprTV_Spot.Cells[_intRow, 9].Value = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());
                        //sprTV_Spot.Cells[_intRow, 9].Value = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());

                        //本数.
                        double _dblHonsu = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
                        //double _dblHonsu = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
                        sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsu;

                        //秒数.
                        double _dblByosu = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
                        //double _dblByosu = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
                        sprTV_Spot.Cells[_intRow, 11].Value = _dblByosu;

                        //期間.
                        sprTV_Spot.Cells[_intRow, 12].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name7"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //請求額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //本数小計.
                        _dblHonsuShokei += _dblHonsu;

                        //秒数小計.
                        _dblByosuShoKei += _dblByosu;

                        //**************************.
                        //各合計額を変数にセット.
                        //**************************.
                        //請求額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //消費税額合計.
                        _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

                        //本数合計.
                        _dblHonsuGokei += _dblHonsu;

                        //秒数合計.
                        _dblByosuGoKei += _dblByosu;

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

                    sprTV_Spot.Cells[_intRow, 7].Value = "代理店計";

                    //請求額合計.
                    sprTV_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //本数合計.
                    sprTV_Spot.Cells[_intRow, 10].Value = _dblHonsuGokei;

                    //秒数小計.
                    sprTV_Spot.Cells[_intRow, 11].Value = _dblByosuGoKei;

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTV_Spot.Rows.Add(sprTV_Spot.RowCount, 1);

                    //行数を加算.
                    _intRow++;

                    sprTV_Spot.Cells[_intRow, 7].Value = "消費税計";

                    //sprTV_Spot.Cells[_intRow, 8].Value = _dblShohizeiGakGokei.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprTV_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprTV_Spot.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    //ブランド名称.
                    sprTV_Spot.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //局コード.
                    sprTV_Spot.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //局名称.
                    sprTV_Spot.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                }
                    # endregion シートにセット.

                //カードNoと代理店コードを非表示にする
                sprTV_Spot.Columns[0].Visible = false;
                sprTV_Spot.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprTV_Spot.MoveColumn(1, 0, true); 

            }
            # endregion テレビスポット

            //ラジオ番組の場合.
            # region ラジオ番組
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_RD)) 
            {

                //シートを表示する.
                sprRd_Time.Visible = true;

                if (sprRd_Time.Columns[0].Label.Equals("データ年月"))
                {
                    //データ年月を2列目に移動
                    sprRd_Time.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    //************
                    //変数初期化.
                    //************
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblDenpaRyoShoKei = 0;             //電波料小計.
                    double _dblNetRyoShoKei = 0;               //ネット料小計.
                    double _dblSeisakuHiShoKei = 0;            //制作費小計.
                    double _dblSeikyuGakShoKei = 0;            //請求額小計.

                    double _dblDenpaRyoGoKei = 0;           //電波料合計.
                    double _dblNetRyoGoKei = 0;             //ネット料合計.
                    double _dblSeisakuHiGoKei = 0;          //制作費合計.
                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _dblShohizeiGakGokei = 0;        //消費税額合計.

                    # region シートにセット.
                    for (int i = 0 ; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count ; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprRd_Time.Rows.Add(sprRd_Time.RowCount , 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //カードNo、番組コードを保持.
                            _strCardNo = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
                            _strBangumiCD = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();
                        }

                        //カードNo.
                        sprRd_Time.Cells[_intRow , 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprRd_Time.Cells[_intRow , 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprRd_Time.Cells[_intRow , 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprRd_Time.Cells[_intRow , 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //番組コード.
                        sprRd_Time.Cells[_intRow , 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiCd"].ToString();

                        //局誌コード.
                        sprRd_Time.Cells[_intRow , 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

                        //局誌名称.
                        sprRd_Time.Cells[_intRow , 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

                        //電波料 = 請求額 - ネット料 - 制作費.
                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        //ネット料.
                        double _dblNetRyo = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk2"].ToString());
                        //制作費.
                        double _dblSeisakuHi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kngk3"].ToString());
                        //電波料.
                        double _dblDenpaRyo = _dblSeikyuGak - _dblNetRyo - _dblSeisakuHi;

                        sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyo.ToString("#,0");

                        //ネット料.
                        sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyo.ToString("#,0");

                        //制作費.
                        sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHi.ToString("#,0");

                        //請求額.
                        sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGak.ToString("#,0");

                        //放送回数.
                        sprRd_Time.Cells[_intRow , 11].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString();

                        //番組名.
                        sprRd_Time.Cells[_intRow , 12].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["bangumiMei"].ToString();

                        //******************.
                        //各小計額をセット.
                        //******************.
                        //電波料小計.
                        _dblDenpaRyoShoKei += _dblDenpaRyo;

                        //ネット料小計.
                        _dblNetRyoShoKei += _dblNetRyo;

                        //制作費小計.
                        _dblSeisakuHiShoKei += _dblSeisakuHi;

                        //請求金額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //******************.
                        //各合計額をセット.
                        //******************.
                        //電波料合計.
                        _dblDenpaRyoGoKei += _dblDenpaRyo;

                        //ネット料合計.
                        _dblNetRyoGoKei += _dblNetRyo;

                        //制作費合計.
                        _dblSeisakuHiGoKei += _dblSeisakuHi;

                        //請求金額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //消費税額合計.
                        _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
                        //_dblShohizeiGakGokei += double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprRd_Time.Rows.Add(sprRd_Time.RowCount , 1);

                    sprRd_Time.Cells[_intRow , 6].Value = "代理店計";

                    //電波料合計.
                    sprRd_Time.Cells[_intRow, 7].Value = _dblDenpaRyoGoKei.ToString("#,0");

                    //ネット料合計.
                    sprRd_Time.Cells[_intRow, 8].Value = _dblNetRyoGoKei.ToString("#,0");

                    //制作費合計.
                    sprRd_Time.Cells[_intRow, 9].Value = _dblSeisakuHiGoKei.ToString("#,0");

                    //請求額合計.
                    sprRd_Time.Cells[_intRow, 10].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprRd_Time.Rows.Add(sprRd_Time.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprRd_Time.Cells[_intRow , 6].Value = "消費税計";

                    //sprRd_Time.Cells[_intRow, 10].Value = _dblShohizeiGakGokei.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprRd_Time.Cells[_intRow, 10].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0 ; i < 6 ; i++)
                    {
                        sprRd_Time.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    //放送回数.
                    sprRd_Time.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";
                    
                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                }
                    # endregion シートにセット.

                //カードNoと代理店コードを非表示にする
                sprRd_Time.Columns[0].Visible = false;
                sprRd_Time.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprRd_Time.MoveColumn(1, 0, true); 

            }
            # endregion ラジオ番組

            //ラジオスポットの場合.
            # region ラジオスポット

            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_RD_SPOT)) 
            {
                //シートを表示する.
                sprRd_Spot.Visible = true;

                if (sprRd_Spot.Columns[0].Label.Equals("データ年月"))
                {
                    //データ年月を2列目に移動
                    sprRd_Spot.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    //************
                    //変数初期化.
                    //************
                    string _strBrandCd = string.Empty;      //ブランドコード.
                    string _strCardNo = string.Empty;       //カードNo.
                    string _strBangumiCD = string.Empty;    //番組コード.
                    int _intRow = 0;                        //行数.

                    double _dblSeikyuGakShoKei = 0;         //請求額小計.
                    double _dblHonsuShokei = 0;             //本数小計.
                    double _dblByosuShoKei = 0;             //CM秒数小計.

                    double _dblSeikyuGakGoKei = 0;          //請求額合計.
                    double _dblHonsuGokei = 0;              //CM本数合計.
                    double _dblByosuGoKei = 0;              //CM秒数合計.

                    double _dblShohizeiGakGokei = 0;        //消費税額合計.

                    # region シートにセット.
                    for (int i = 0 ; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count ; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprRd_Spot.Rows.Add(sprRd_Spot.RowCount , 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            //ブランドコードを保持.
                            _strBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprRd_Spot.Cells[_intRow , 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprRd_Spot.Cells[_intRow , 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprRd_Spot.Cells[_intRow , 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprRd_Spot.Cells[_intRow , 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprRd_Spot.Cells[_intRow , 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprRd_Spot.Cells[_intRow , 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //局誌コード.
                        sprRd_Spot.Cells[_intRow , 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

                        //局誌名称.
                        sprRd_Spot.Cells[_intRow , 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

                        //請求額.
                        double _dblSeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGak.ToString("#,0");

                        //CM1本の秒数.
                        sprRd_Spot.Cells[_intRow , 9].Value = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota7"].ToString());

                        //本数.
                        double _dblHonsu = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["sonota5"].ToString());
                        sprRd_Spot.Cells[_intRow , 10].Value = _dblHonsu;

                        //秒数.
                        double _dblByosu = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["byosuGokei"].ToString());
                        sprRd_Spot.Cells[_intRow , 11].Value = _dblByosu;

                        //期間.
                        sprRd_Spot.Cells[_intRow , 12].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name7"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //請求額小計.
                        _dblSeikyuGakShoKei += _dblSeikyuGak;

                        //本数小計.
                        _dblHonsuShokei += _dblHonsu;

                        //秒数小計.
                        _dblByosuShoKei += _dblByosu;

                        //**************************.
                        //各合計額を変数にセット.
                        //**************************.
                        //請求額合計.
                        _dblSeikyuGakGoKei += _dblSeikyuGak;

                        //消費税額合計.
                        _dblShohizeiGakGokei += KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());

                        //本数合計.
                        _dblHonsuGokei += _dblHonsu;

                        //秒数合計.
                        _dblByosuGoKei += _dblByosu;

                        //行数を加算.
                        _intRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprRd_Spot.Rows.Add(sprRd_Spot.RowCount , 1);

                    sprRd_Spot.Cells[_intRow , 7].Value = "代理店計";

                    //請求額合計.
                    sprRd_Spot.Cells[_intRow, 8].Value = _dblSeikyuGakGoKei.ToString("#,0");

                    //本数合計.
                    sprRd_Spot.Cells[_intRow , 10].Value = _dblHonsuGokei;

                    //秒数小計.
                    sprRd_Spot.Cells[_intRow , 11].Value = _dblByosuGoKei;

                    //************************************.
                    //消費税行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprRd_Spot.Rows.Add(sprRd_Spot.RowCount , 1);

                    //行数を加算.
                    _intRow++;

                    sprRd_Spot.Cells[_intRow , 7].Value = "消費税計";

                    //sprRd_Spot.Cells[_intRow, 8].Value = _dblShohizeiGakGokei.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprRd_Spot.Cells[_intRow, 8].Value = Math.Floor(_dblSeikyuGakGoKei * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0 ; i < 5 ; i++)
                    {
                        sprRd_Spot.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    //ブランド名称.
                    sprRd_Spot.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //局コード.
                    sprRd_Spot.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //局名称.
                    sprRd_Spot.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                }
                    # endregion シートにセット.

                //カードNoと代理店コードを非表示にする
                sprRd_Spot.Columns[0].Visible = false;
                sprRd_Spot.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprRd_Spot.MoveColumn(1, 0, true); 

            }
            # endregion ラジオスポット
            //新聞の場合.
            #region "新聞"

            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_NP)) 
            {
                //シートを表示する
                sprShin.Visible = true;

                if (sprShin.Columns[0].Label.Equals("データ年月"))
                {
                    //データ年月を2列目に移動
                    sprShin.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    
                    string _strShiBrandCd = string.Empty;                     //ブランドコード.
                    double _brandJissiSyoukei = 0;                            //ブランド実施料小計.
                    double _brandSeiSyoukei = 0;                              //ブランド請求額小計.
                    double _dairiJissiSyoukei = 0;                            //代理店実施料小計.
                    double _dairiSeiSyoukei = 0;                              //代理店請求額小計.
                    double _SyouhizeiGoukei = 0;                              //消費税合計.
                    int _intShinRow = 0;                                      //行数.

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprShin.Rows.Add(sprShin.RowCount, 1);
                        //1回目の場合.
                        if (i == 0)
                        {
                            _strShiBrandCd =  result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprShin.Cells[_intShinRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprShin.Cells[_intShinRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprShin.Cells[_intShinRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprShin.Cells[_intShinRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprShin.Cells[_intShinRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprShin.Cells[_intShinRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                       //新聞コード.
                        sprShin.Cells[_intShinRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shinCd"].ToString();

                        //新聞名称.
                        sprShin.Cells[_intShinRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shinMei"].ToString();

                        //実施料.
                        double ShinJissi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name4"].ToString());
                        sprShin.Cells[_intShinRow, 8].Value = ShinJissi.ToString("#,0");

                        //請求金額.
                        double ShinSeigak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["seigak"].ToString());
                        sprShin.Cells[_intShinRow, 9].Value = ShinSeigak.ToString("#,0");

                        //備考.
                        sprShin.Cells[_intShinRow, 10].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();


                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計実施料.
                        _brandJissiSyoukei = _brandJissiSyoukei + ShinJissi;
                        //ブランド計請求額.
                        _brandSeiSyoukei = _brandSeiSyoukei + ShinSeigak;
                        //代理店実施料.
                        _dairiJissiSyoukei = _dairiJissiSyoukei + ShinJissi;
                        //代理店請求額.
                        _dairiSeiSyoukei = _dairiSeiSyoukei + ShinSeigak;
                        //消費税合計.
                        double ShinSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["shohizeiGak"].ToString());
                        _SyouhizeiGoukei = _SyouhizeiGoukei + ShinSyouhi;

                        //行数を加算.
                        _intShinRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprShin.Rows.Add(sprShin.RowCount, 1);
                    sprShin.Cells[_intShinRow, 7].Value = "代理店計";
                    sprShin.Cells[_intShinRow, 8].Value = _dairiJissiSyoukei.ToString("#,0");
                    sprShin.Cells[_intShinRow, 9].Value = _dairiSeiSyoukei.ToString("#,0");


                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprShin.Rows.Add(sprShin.RowCount, 1);
                    //行数を加算.
                    _intShinRow++;
                    sprShin.Cells[_intShinRow, 7].Value = "消費税計";
                    //sprShin.Cells[_intShinRow, 8].Value = _SyouhizeiGoukei.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprShin.Cells[_intShinRow, 8].Value = Math.Floor(_dairiSeiSyoukei * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprShin.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprShin.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //新聞コード.
                    sprShin.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //新聞名称.
                    sprShin.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;
                    
                    //実施料.
                    sprShin.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;
                    
                    //請求額.
                    sprShin.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //備考.
                    sprShin.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

               
                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprShin.Columns[0].Visible = false;
                sprShin.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprShin.MoveColumn(1, 0, true); 

            }
            #endregion "新聞"

            //雑誌の場合.
            #region "雑誌"

            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_MZ)) 
            {
                //シートを表示する.
                sprZashi.Visible = true;

                if (sprZashi.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprZashi.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strMzBrandCd = string.Empty;                     //ブランドコード.
                    double _brandJissiSyoukeiMZ = 0;                         //ブランド実施料.
                    double _brandSeiSyoukeiMZ = 0;                           //ブランド請求額.
                    double _dairiJissiSyoukeiMZ = 0;                         //代理店実施料小計.
                    double _dairiSeiSyoukeiMZ = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeiMZ = 0;                           //消費税合計.
                    int _intMzRow = 0;                                       //行数.

                    
                    
                    #region シートにセット

                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprZashi.Rows.Add(sprZashi.RowCount, 1);
                       
                        //1回目の場合.
                        if (i == 0)
                        {
                            _strMzBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprZashi.Cells[_intMzRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprZashi.Cells[_intMzRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprZashi.Cells[_intMzRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprZashi.Cells[_intMzRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprZashi.Cells[_intMzRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprZashi.Cells[_intMzRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //雑誌コード 
                        sprZashi.Cells[_intMzRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiCd"].ToString();

                        //雑誌名称 
                        sprZashi.Cells[_intMzRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["ZashiName"].ToString();
                        
                        //スペース 
                        sprZashi.Cells[_intMzRow, 8].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Space"].ToString();

                        //実施料 
                        double MzJissi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name4"].ToString()) + KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Kngk3"].ToString());
                        sprZashi.Cells[_intMzRow, 9].Value = MzJissi.ToString("#,0");
                        
                        //請求額 
                        double MzSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprZashi.Cells[_intMzRow, 10].Value = MzSei.ToString("#,0");

                        //備考 
                        sprZashi.Cells[_intMzRow, 11].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計実施料.
                        _brandJissiSyoukeiMZ = _brandJissiSyoukeiMZ + MzJissi;
                        //ブランド計請求額.
                        _brandSeiSyoukeiMZ = _brandSeiSyoukeiMZ + MzSei;
                        //代理店実施料.
                        _dairiJissiSyoukeiMZ = _dairiJissiSyoukeiMZ + MzJissi;
                        //代理店請求額.
                        _dairiSeiSyoukeiMZ = _dairiSeiSyoukeiMZ + MzSei;
                        //消費税合計.
                        double MagSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeiMZ = _SyouhizeiGoukeiMZ + MagSyouhi;

                        _intMzRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprZashi.Rows.Add(sprZashi.RowCount, 1);
                    sprZashi.Cells[_intMzRow, 7].Value = "代理店計";
                    sprZashi.Cells[_intMzRow, 9].Value = _dairiJissiSyoukeiMZ.ToString("#,0");
                    sprZashi.Cells[_intMzRow, 10].Value = _dairiSeiSyoukeiMZ.ToString("#,0");


                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprZashi.Rows.Add(sprZashi.RowCount, 1);
                    //行数を加算.
                    _intMzRow++;
                    sprZashi.Cells[_intMzRow, 7].Value = "消費税計";
                    //sprZashi.Cells[_intMzRow, 9].Value = _SyouhizeiGoukeiMZ.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprZashi.Cells[_intMzRow, 9].Value = Math.Floor(_dairiSeiSyoukeiMZ * _dblShohizei);


                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprZashi.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprZashi.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //雑誌コード.
                    sprZashi.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //雑誌名称.
                    sprZashi.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //スペース.
                    sprZashi.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //実施料.
                    sprZashi.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //請求額.
                    sprZashi.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //備考 
                    sprZashi.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                    #endregion シートにセット


                }

                //カードNoと代理店コードを非表示にする
                sprZashi.Columns[0].Visible = false;
                sprZashi.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprZashi.MoveColumn(1, 0, true); 

            }

            #endregion "雑誌"

            //交通の場合.
            #region "交通"

            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_OOH)) 
            {
                //シートを表示する
                sprKoutsuu.Visible = true;

                if (sprKoutsuu.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprKoutsuu.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

                    string _strOohBrandCd = string.Empty;                       //ブランドコード.
                    int _intOohRow = 0;                                       //行数.
                    double _brandSeiSyoukeiOoh = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeiOoh = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeiOoh = 0;                           //消費税合計.

                    #region シートにセット
                    
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strOohBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprKoutsuu.Cells[_intOohRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprKoutsuu.Cells[_intOohRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprKoutsuu.Cells[_intOohRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprKoutsuu.Cells[_intOohRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprKoutsuu.Cells[_intOohRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprKoutsuu.Cells[_intOohRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //県コード 
                        sprKoutsuu.Cells[_intOohRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenCd"].ToString();

                        //県名 
                        sprKoutsuu.Cells[_intOohRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenName"].ToString();

                        //請求額 
                        double OohSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprKoutsuu.Cells[_intOohRow, 8].Value = OohSei.ToString("#,0");

                        //路線名 
                        sprKoutsuu.Cells[_intOohRow, 9].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["RosenName"].ToString();

                        //期間 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString()))
                        {
                            result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"] = "";
                        }
                        else
                        {
                            sprKoutsuu.Cells[_intOohRow, 10].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Kikan"].ToString();
                        }
                        //備考 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString()))
                        {
                            result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"] = "";
                        }
                        else
                        {
                            sprKoutsuu.Cells[_intOohRow, 11].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name8"].ToString();
                        }

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiOoh = _brandSeiSyoukeiOoh + OohSei;
                        //代理店請求額.
                        _dairiSeiSyoukeiOoh = _dairiSeiSyoukeiOoh + OohSei;
                        //消費税合計.
                        double KoutsuSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeiOoh = _SyouhizeiGoukeiOoh + KoutsuSyouhi;

                        _intOohRow++;

                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);
                    sprKoutsuu.Cells[_intOohRow, 7].Value = "代理店計";
                    sprKoutsuu.Cells[_intOohRow, 8].Value = _dairiSeiSyoukeiOoh.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprKoutsuu.Rows.Add(sprKoutsuu.RowCount, 1);
                    //行数を加算.
                    _intOohRow++;
                    sprKoutsuu.Cells[_intOohRow, 7].Value = "消費税計";
                    //sprKoutsuu.Cells[_intOohRow, 8].Value = _SyouhizeiGoukeiOoh.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprKoutsuu.Cells[_intOohRow, 8].Value = Math.Floor(_dairiSeiSyoukeiOoh * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    //カードNO
                    sprKoutsuu.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Center;
                    //データ年月 
                    sprKoutsuu.Columns[1].HorizontalAlignment = CellHorizontalAlignment.Center;
                    //代理店コード 
                    sprKoutsuu.Columns[2].HorizontalAlignment = CellHorizontalAlignment.Left;
                    //媒体区分 
                    sprKoutsuu.Columns[3].HorizontalAlignment = CellHorizontalAlignment.Center;
                    //ブランドコード                    sprKoutsuu.Columns[4].HorizontalAlignment = CellHorizontalAlignment.Center;
                    //ブランド名称.
                    sprKoutsuu.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;
                    //県コード.
                    sprKoutsuu.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;
                    //県名称.
                    sprKoutsuu.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;
                    //請求金額.
                    sprKoutsuu.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;
                    //路線名.
                    sprKoutsuu.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;
                    //期間.
                    sprKoutsuu.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;
                    //備考 
                    sprKoutsuu.Columns[11].HorizontalAlignment = CellHorizontalAlignment.Right;
                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;
                    //Excelボタン押下可能.
                    btnXls.Enabled = true;
                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";
                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprKoutsuu.Columns[0].Visible = false;
                sprKoutsuu.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprKoutsuu.MoveColumn(1, 0, true); 

            }
            #endregion "事業部"

            //宣伝間接費の場合 
            #region "宣伝間接費"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_OTHER))
            {
                //シートを表示する
                sprSonota.Visible = true;

                if (sprSonota.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprSonota.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    int _intsonotaRow = 0;                                       //行数.
                    string _strsonotaBrandCd = string.Empty;                      //ブランドコード.
                    double _brandSeiSyoukeisonota = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeisonota = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeisonota = 0;                           //消費税合計.

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprSonota.Rows.Add(sprSonota.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strsonotaBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprSonota.Cells[_intsonotaRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprSonota.Cells[_intsonotaRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprSonota.Cells[_intsonotaRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprSonota.Cells[_intsonotaRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprSonota.Cells[_intsonotaRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprSonota.Cells[_intsonotaRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //請求額

                        double sonotaSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprSonota.Cells[_intsonotaRow, 6].Value = sonotaSei.ToString("#,0");

                        //件名

                        sprSonota.Cells[_intsonotaRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeisonota = _brandSeiSyoukeisonota + sonotaSei;
                        //代理店請求額.
                        _dairiSeiSyoukeisonota = _dairiSeiSyoukeisonota + sonotaSei;
                        //消費税合計.
                        double sonotaSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeisonota = _SyouhizeiGoukeisonota + sonotaSyouhi;

                        _intsonotaRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSonota.Rows.Add(sprSonota.RowCount, 1);
                    sprSonota.Cells[_intsonotaRow, 5].Value = "代理店計";
                    sprSonota.Cells[_intsonotaRow, 6].Value = _dairiSeiSyoukeisonota.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSonota.Rows.Add(sprSonota.RowCount, 1);
                    //行数を加算.
                    _intsonotaRow++;
                    sprSonota.Cells[_intsonotaRow, 5].Value = "消費税計";
                    //sprSonota.Cells[_intsonotaRow, 6].Value = _SyouhizeiGoukeisonota.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprSonota.Cells[_intsonotaRow, 6].Value = Math.Floor(_dairiSeiSyoukeisonota * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprSonota.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprSonota.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //請求額.
                    sprSonota.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprSonota.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = (result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count).ToString() + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprSonota.Columns[0].Visible = false;
                sprSonota.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprSonota.MoveColumn(1, 0, true);

            }

            #endregion "宣伝間接費"

            //チラシの場合 
            #region "チラシ"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_CHIRASHI)) 
            {
                //シートを表示する 
                sprTirashi.Visible = true;

                if (sprTirashi.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprTirashi.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strtirashiBrandCd = string.Empty;                      //ブランドコード.
                    int _inttirashiRow = 0;                                       //行数.
                    double _brandSeiSyoukeitirashi = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeitirashi = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeitirashi = 0;                           //消費税合計.

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprTirashi.Rows.Add(sprTirashi.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strtirashiBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprTirashi.Cells[_inttirashiRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprTirashi.Cells[_inttirashiRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprTirashi.Cells[_inttirashiRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprTirashi.Cells[_inttirashiRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprTirashi.Cells[_inttirashiRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprTirashi.Cells[_inttirashiRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //請求額 
                        double tirashiSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprTirashi.Cells[_inttirashiRow, 6].Value = tirashiSei.ToString("#,0");

                        //件名 
                        sprTirashi.Cells[_inttirashiRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeitirashi = _brandSeiSyoukeitirashi + tirashiSei;
                        //代理店請求額.
                        _dairiSeiSyoukeitirashi = _dairiSeiSyoukeitirashi + tirashiSei;
                        //消費税合計.
                        double tirashiSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeitirashi = _SyouhizeiGoukeitirashi + tirashiSyouhi;

                        _inttirashiRow++;

                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTirashi.Rows.Add(sprTirashi.RowCount, 1);
                    sprTirashi.Cells[_inttirashiRow, 5].Value = "代理店計";
                    sprTirashi.Cells[_inttirashiRow, 6].Value = _dairiSeiSyoukeitirashi.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprTirashi.Rows.Add(sprTirashi.RowCount, 1);
                    //行数を加算.
                    _inttirashiRow++;
                    sprTirashi.Cells[_inttirashiRow, 5].Value = "消費税計";
                    //sprTirashi.Cells[_inttirashiRow, 6].Value = _SyouhizeiGoukeitirashi.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprTirashi.Cells[_inttirashiRow, 6].Value = Math.Floor(_dairiSeiSyoukeitirashi * _dblShohizei);


                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprTirashi.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprTirashi.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //請求額.
                    sprTirashi.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprTirashi.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;


                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprTirashi.Columns[0].Visible = false;
                sprTirashi.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprTirashi.MoveColumn(1, 0, true); 

            }
            #endregion "チラシ"

            //サンプリングの場合 
            #region "サンプリング"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SAMPLE))
            {
                //シートを表示する
                sprSample.Visible = true;

                if (sprSample.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprSample.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strsampleBrandCd = string.Empty;                      //ブランドコード.
                    int _intsampleRow = 0;                                       //行数.
                    double _brandSeiSyoukeisample = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeisample = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeisample = 0;                           //消費税合計.

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprSample.Rows.Add(sprSample.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strsampleBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprSample.Cells[_intsampleRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprSample.Cells[_intsampleRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprSample.Cells[_intsampleRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprSample.Cells[_intsampleRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprSample.Cells[_intsampleRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprSample.Cells[_intsampleRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //請求額 
                        double sampleSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprSample.Cells[_intsampleRow, 6].Value = sampleSei.ToString("#,0");

                        //件名 
                        sprSample.Cells[_intsampleRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeisample = _brandSeiSyoukeisample + sampleSei;
                        //代理店請求額.
                        _dairiSeiSyoukeisample = _dairiSeiSyoukeisample + sampleSei;
                        //消費税合計.
                        double sampleSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeisample = _SyouhizeiGoukeisample + sampleSyouhi;

                        _intsampleRow++;
                    }


                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSample.Rows.Add(sprSample.RowCount, 1);
                    sprSample.Cells[_intsampleRow, 5].Value = "代理店計";
                    sprSample.Cells[_intsampleRow, 6].Value = _dairiSeiSyoukeisample.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSample.Rows.Add(sprSample.RowCount, 1);
                    //行数を加算.
                    _intsampleRow++;
                    sprSample.Cells[_intsampleRow, 5].Value = "消費税計";
                    //sprSample.Cells[_intsampleRow, 6].Value = _SyouhizeiGoukeisample.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprSample.Cells[_intsampleRow, 6].Value = Math.Floor(_dairiSeiSyoukeisample * _dblShohizei);


                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprSample.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprSample.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //請求額.
                    sprSample.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprSample.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprSample.Columns[0].Visible = false;
                sprSample.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprSample.MoveColumn(1, 0, true);

            }
            #endregion "サンプリング"

            //BS・CSの場合 
            #region "BS・CS"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_BSCS))
            {
                //シートを表示する
                sprBscs.Visible = true;

                if (sprBscs.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprBscs.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strbscsCardNo = string.Empty;                      //カードNo.
                    string _strbscsProgramCd = string.Empty;                    //プログラムコード

                    int _intbscsRow = 0;                                       //行数.
                    double _cardSeiSyoukeibscs = 0;                           //カード計.
                    double _dairiSeiSyoukeibscs = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeibscs = 0;                           //消費税合計. 


                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprBscs.Rows.Add(sprBscs.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strbscsCardNo = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Code6"].ToString();
                            _strbscsProgramCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString();
                        }

                        //カードNo.
                        sprBscs.Cells[_intbscsRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprBscs.Cells[_intbscsRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprBscs.Cells[_intbscsRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprBscs.Cells[_intbscsRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //番組コード 
                        sprBscs.Cells[_intbscsRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramCd"].ToString();

                        //局誌コード 
                        sprBscs.Cells[_intbscsRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuCd"].ToString();

                        //局誌名称
                        sprBscs.Cells[_intbscsRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["kyokuMei"].ToString();

                        //電波料 
                        double BsCsSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprBscs.Cells[_intbscsRow, 7].Value = BsCsSei.ToString("#,0");

                        //請求額合計 
                        sprBscs.Cells[_intbscsRow, 8].Value = BsCsSei.ToString("#,0");

                        //放送回数 
                        sprBscs.Cells[_intbscsRow, 9].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["Honsu"].ToString();

                        //番組名 
                        sprBscs.Cells[_intbscsRow, 10].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["ProgramName"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _cardSeiSyoukeibscs = _cardSeiSyoukeibscs + BsCsSei;
                        //代理店請求額.
                        _dairiSeiSyoukeibscs = _dairiSeiSyoukeibscs + BsCsSei;
                        //消費税合計.
                        double BscsSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        //double BscsSyouhi = double.Parse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeibscs = _SyouhizeiGoukeibscs + BscsSyouhi;

                        _intbscsRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprBscs.Rows.Add(sprBscs.RowCount, 1);
                    sprBscs.Cells[_intbscsRow, 6].Value = "代理店計";
                    sprBscs.Cells[_intbscsRow, 7].Value = _dairiSeiSyoukeibscs.ToString("#,0");
                    sprBscs.Cells[_intbscsRow, 8].Value = _dairiSeiSyoukeibscs.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprBscs.Rows.Add(sprBscs.RowCount, 1);
                    //行数を加算.
                    _intbscsRow++;
                    sprBscs.Cells[_intbscsRow, 6].Value = "消費税計";
                    //sprBscs.Cells[_intbscsRow, 8].Value = _SyouhizeiGoukeibscs.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprBscs.Cells[_intbscsRow, 8].Value = Math.Floor(_dairiSeiSyoukeibscs * _dblShohizei);

                    for (int i = 0; i < 6; i++)
                    {
                        sprBscs.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }

                    //局誌名称
                    sprBscs.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //電波料

                    sprBscs.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //請求額合計

                    sprBscs.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //放送回数
                    sprBscs.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //番組名
                    sprBscs.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;


                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;


                    #endregion　シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprBscs.Columns[0].Visible = false;
                sprBscs.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprBscs.MoveColumn(1, 0, true);
            }
            #endregion "BS・CS"

            //インターネットの場合 
            #region "インターネット"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_INT))
            {
                //シートを表示する
                sprInternet.Visible = true;

                if (sprInternet.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprInternet.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strinternetBrandCd = string.Empty;                      //ブランドコード.
                    int _intinternetRow = 0;                                       //行数.
                    double _brandSeiSyoukeiinternet = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeiinternet = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeiinternet = 0;                           //消費税合計.

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprInternet.Rows.Add(sprInternet.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strinternetBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprInternet.Cells[_intinternetRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprInternet.Cells[_intinternetRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprInternet.Cells[_intinternetRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprInternet.Cells[_intinternetRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprInternet.Cells[_intinternetRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprInternet.Cells[_intinternetRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //局誌コード 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString()))
                        {
                            sprInternet.Cells[_intinternetRow, 6].Value = "";
                        }
                        else
                        {
                            sprInternet.Cells[_intinternetRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString();
                        }

                        //局誌名称 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString()))
                        {
                            sprInternet.Cells[_intinternetRow, 7].Value = "";
                        }
                        else
                        {
                            sprInternet.Cells[_intinternetRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString();
                        }

                        //作成料 
                        double internetSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprInternet.Cells[_intinternetRow, 8].Value = internetSei.ToString("#,0");

                        //件名

                        sprInternet.Cells[_intinternetRow, 9].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiinternet = _brandSeiSyoukeiinternet + internetSei;
                        //代理店請求額.
                        _dairiSeiSyoukeiinternet = _dairiSeiSyoukeiinternet + internetSei;
                        //消費税合計.
                        double internetSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeiinternet = _SyouhizeiGoukeiinternet + internetSyouhi;

                        _intinternetRow++;

                    }


                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprInternet.Rows.Add(sprInternet.RowCount, 1);
                    sprInternet.Cells[_intinternetRow, 5].Value = "代理店計";
                    sprInternet.Cells[_intinternetRow, 8].Value = _dairiSeiSyoukeiinternet.ToString("#,0");


                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprInternet.Rows.Add(sprInternet.RowCount, 1);
                    //行数を加算.
                    _intinternetRow++;
                    sprInternet.Cells[_intinternetRow, 5].Value = "消費税計";
                    //sprInternet.Cells[_intinternetRow, 8].Value = _SyouhizeiGoukeiinternet.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprInternet.Cells[_intinternetRow, 8].Value = Math.Floor(_dairiSeiSyoukeiinternet * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprInternet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprInternet.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //局誌コード.
                    sprInternet.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //局誌名称.
                    sprInternet.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //作成料.
                    sprInternet.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprInternet.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;
                    #endregion シートにセット

                }

                //カードNoと代理店コードを非表示にする
                sprInternet.Columns[0].Visible = false;
                sprInternet.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprInternet.MoveColumn(1, 0, true);

            }
            #endregion "インターネット"

            //モバイルの場合 
            #region "モバイル"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_MOB)) 
            {
                //シートを表示する
                sprMobile.Visible = true;

                if (sprMobile.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprMobile.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strmobileBrandCd = string.Empty;                      //ブランドコード.
                    int _intmobileRow = 0;                                       //行数.
                    double _brandSeiSyoukeimobile = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeimobile = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeimobile = 0;                           //消費税合計.

                    #region "シートにセット"
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprMobile.Rows.Add(sprMobile.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strmobileBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprMobile.Cells[_intmobileRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprMobile.Cells[_intmobileRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprMobile.Cells[_intmobileRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprMobile.Cells[_intmobileRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprMobile.Cells[_intmobileRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprMobile.Cells[_intmobileRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //局誌コード 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString()))
                        {
                            sprMobile.Cells[_intmobileRow, 6].Value = "";
                        }
                        else
                        {
                            sprMobile.Cells[_intmobileRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiCd"].ToString();
                        }

                        //局誌名称 
                        if (string.IsNullOrEmpty(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString()))
                        {
                            sprMobile.Cells[_intmobileRow, 7].Value = "";
                        }
                        else
                        {
                            sprMobile.Cells[_intmobileRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KyokushiName"].ToString();
                        }

                        //作成料 
                        double mobileSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprMobile.Cells[_intmobileRow, 8].Value = mobileSei.ToString("#,0");

                        //件名 
                        sprMobile.Cells[_intmobileRow, 9].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeimobile = _brandSeiSyoukeimobile + mobileSei;
                        //代理店請求額.
                        _dairiSeiSyoukeimobile = _dairiSeiSyoukeimobile + mobileSei;
                        //消費税合計.
                        double mobileSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeimobile = _SyouhizeiGoukeimobile + mobileSyouhi;

                        _intmobileRow++;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprMobile.Rows.Add(sprMobile.RowCount, 1);
                    sprMobile.Cells[_intmobileRow, 5].Value = "代理店計";
                    sprMobile.Cells[_intmobileRow, 8].Value = _dairiSeiSyoukeimobile.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprMobile.Rows.Add(sprMobile.RowCount, 1);
                    //行数を加算.
                    _intmobileRow++;
                    sprMobile.Cells[_intmobileRow, 5].Value = "消費税計";
                    //sprMobile.Cells[_intmobileRow, 8].Value = _SyouhizeiGoukeimobile.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprMobile.Cells[_intmobileRow, 8].Value = Math.Floor(_dairiSeiSyoukeimobile * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprMobile.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprMobile.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //局誌コード.
                    sprMobile.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //局誌名称.
                    sprMobile.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //作成料.
                    sprMobile.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprMobile.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion "シートにセット"
                }

                //カードNoと代理店コードを非表示にする
                sprMobile.Columns[0].Visible = false;
                sprMobile.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprMobile.MoveColumn(1, 0, true);

            }

            #endregion "モバイル"

            //事業費の場合.
            #region "事業費"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_JIGYO))
            {
                //シートを表示する 
                sprJigyoubu.Visible = true;

                if (sprJigyoubu.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprJigyoubu.MoveColumn(0, 1, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                {
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    string _strJigyouBrandCd = string.Empty;                       //ブランドコード.
                    int _intJigyouRow = 0;                                       //行数.
                    double _brandSeiSyoukeiJigyou = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeiJigyou = 0;                           //代理店請求額小計.
                    double _SyouhizeiGoukeiJigyou = 0;                           //消費税合計.

                    #region シートにセット

                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strJigyouBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                        }

                        //カードNo.
                        sprJigyoubu.Cells[_intJigyouRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月.
                        sprJigyoubu.Cells[_intJigyouRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード.
                        sprJigyoubu.Cells[_intJigyouRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分.
                        sprJigyoubu.Cells[_intJigyouRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //ブランドコード.
                        sprJigyoubu.Cells[_intJigyouRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称.
                        sprJigyoubu.Cells[_intJigyouRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //請求額 
                        double JigyouSei = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                        sprJigyoubu.Cells[_intJigyouRow, 6].Value = JigyouSei.ToString("#,0");

                        //件名 
                        sprJigyoubu.Cells[_intJigyouRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiJigyou = _brandSeiSyoukeiJigyou + JigyouSei;
                        //代理店請求額.
                        _dairiSeiSyoukeiJigyou = _dairiSeiSyoukeiJigyou + JigyouSei;
                        //消費税合計.
                        double JigyouSyouhi = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString());
                        _SyouhizeiGoukeiJigyou = _SyouhizeiGoukeiJigyou + JigyouSyouhi;

                        _intJigyouRow++;
                    }


                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);
                    sprJigyoubu.Cells[_intJigyouRow, 5].Value = "代理店計";
                    sprJigyoubu.Cells[_intJigyouRow, 6].Value = _dairiSeiSyoukeiJigyou.ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprJigyoubu.Rows.Add(sprJigyoubu.RowCount, 1);
                    //行数を加算.
                    _intJigyouRow++;
                    sprJigyoubu.Cells[_intJigyouRow, 5].Value = "消費税計";
                    //sprJigyoubu.Cells[_intJigyouRow, 6].Value = _SyouhizeiGoukeiJigyou.ToString("#,0");
                    //請求額合計 * 消費税率.
                    sprJigyoubu.Cells[_intJigyouRow, 6].Value = Math.Floor(_dairiSeiSyoukeiJigyou * _dblShohizei);

                    //************************************.
                    //値の位置.
                    //************************************.
                    for (int i = 0; i < 5; i++)
                    {
                        sprJigyoubu.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //ブランド名称.
                    sprJigyoubu.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //請求額.
                    sprJigyoubu.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //件名.
                    sprJigyoubu.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;

                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";

                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット
                }

                //カードNoと代理店コードを非表示にする
                sprJigyoubu.Columns[0].Visible = false;
                sprJigyoubu.Columns[2].Visible = false;

                //データ年月を1列目に移動
                sprJigyoubu.MoveColumn(1, 0, true);

            }

            #endregion "事業費" 

            //制作の場合 
            #region "制作"
            if (htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_TVCF) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_TVCFPRINT) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_CM) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_CHOSA) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_RD) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_NP) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_MZ) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_TALENT) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_WEB) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_KOKOKU) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_OOH) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_KANSETSU) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_KAIHATSU) ||
                htBaitaiKbn[_mStrBaitaiMei].ToString().Equals(KKHLionConst.BAITAIKBN_SEISAK_PACKAGE) 
                ) 
            {
                //シートを表示する 
                sprSeisaku.Visible = true;

                if (sprSeisaku.Columns[0].Label.Equals("ﾃﾞｰﾀ年月"))
                {
                    //データ年月を2列目に移動
                    sprSeisaku.MoveColumn(0, 2, true);
                }

                if (0 < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count)
                { 
                    //垂直スクロールバーを作業中は非表示にする.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
                    int _intseisakuRow = 0;                                       //行数.
                    string _strseisakuBrandCd = string.Empty;                     //ブランドコード.
                    string JanleName = string.Empty;                              //ジャンル名 
                    string JanleCd = string.Empty;                                //ジャンルコード 
                    string Yymm = yyyyMmFrom;                                     //データ年月 
                    string CardNo = string.Empty;                                 //カードNo 
                    string AgentCd = string.Empty;                                //代理店コード 
                    string BrandName = string.Empty;                              //代理店名
                    double SeisakuSyohizeiGak = 0;                                //制作消費税 
                    double SeisakuSyohizeiGak_Talent = 0;                         //制作消費税(タレント用)
                    double _brandSeiSyoukeiseisaku = 0;                           //ブランド請求額.
                    double _dairiSeiSyoukeiseisaku = 0;                           //代理店請求額小計.
                    double SumSyouhiZeiGak = 0;                                   //消費税合計.
                    double _JanleSeiSyoukeiseisaku = 0;                           //ジャンル請求額 

                    #region シートにセット
                    for (int i = 0; i < result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count; i++)
                    {
                        //********************************.
                        //スプレッドシートに行を追加.
                        //********************************.
                        sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);

                        //1回目の場合.
                        if (i == 0)
                        {
                            _strseisakuBrandCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();
                            JanleName = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleName"].ToString();
                            JanleCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleCd"].ToString();
                            CardNo = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();
                            AgentCd = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();
                            BrandName = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();
                        }

                        //ブランドコードのブレイク 
                        if (!_strseisakuBrandCd.Equals(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString()))
                        {
                            //制作消費税を入力 
                            if (SeisakuSyohizeiGak != 0)
                            {
                                SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;
                            }
                            //制作消費税(タレント用)を入力 
                            if (SeisakuSyohizeiGak_Talent != 0)
                            {
                                SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;
                            }

                            //初期化 
                            SeisakuSyohizeiGak = 0;
                            SeisakuSyohizeiGak_Talent = 0;
                            _brandSeiSyoukeiseisaku = 0;

                        }

                        //ジャンル名.
                        sprSeisaku.Cells[_intseisakuRow, 0].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["JanleName"].ToString();

                        //カードNo
                        sprSeisaku.Cells[_intseisakuRow, 1].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString();

                        //データ年月 
                        sprSeisaku.Cells[_intseisakuRow, 2].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["yymm"].ToString();

                        //代理店コード 
                        sprSeisaku.Cells[_intseisakuRow, 3].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code4"].ToString();

                        //媒体区分 
                        sprSeisaku.Cells[_intseisakuRow, 4].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString();

                        //媒体名称 
                        sprSeisaku.Cells[_intseisakuRow, 5].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["BaitaiName"].ToString();

                        //ブランドコード 
                        sprSeisaku.Cells[_intseisakuRow, 6].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandCd"].ToString();

                        //ブランド名称 
                        sprSeisaku.Cells[_intseisakuRow, 7].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["brandMei"].ToString();

                        //件名 
                        sprSeisaku.Cells[_intseisakuRow, 10].Value = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["KenMei"].ToString();

                        //請求額・媒体消費税額を分ける 
                        double SeikyuGak = 0;
                        if (result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code6"].ToString().Trim().Equals("012"))
                        {
                            switch (result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["code1"].ToString().Trim())
                            {
                                case "20":
                                case "21":
                                case "23":
                                case "24":
                                case "25":
                                case "27":
                                case "29":
                                case "33":
                                case "35":
                                case "36":
                                case "37":
                                case "38":
                                case "39":
                                    //消費税が0またはempty以外の場合 
                                    if (!result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
                                    {
                                        SeisakuSyohizeiGak = SeisakuSyohizeiGak + Math.Truncate(KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()));
                                    }
                                    SeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                                    sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
                                    break;
                                case "31":
                                    //消費税が0またはempty以外の場合 
                                    if (!result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
                                    {
                                        SeisakuSyohizeiGak_Talent = SeisakuSyohizeiGak_Talent + Math.Truncate(KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()));
                                    }
                                    SeikyuGak = KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["SeiGak"].ToString());
                                    sprSeisaku.Cells[_intseisakuRow, 8].Value = SeikyuGak;
                                    break;
                            }
                        }

                        //消費税が0またはempty以外の場合 
                        if (!result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals("0") || !result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString().Trim().Equals(""))
                        {
                            //消費税 
                            sprSeisaku.Cells[_intseisakuRow, 9].Value = (Math.Truncate(KKHUtility.DouParse(result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows[i]["name1"].ToString()))).ToString("#,0");
                        }

                        //**************************.
                        //各小計額を変数にセット.
                        //**************************.
                        //ブランド計請求額.
                        _brandSeiSyoukeiseisaku = _brandSeiSyoukeiseisaku + SeikyuGak;
                        //ジャンル計 
                        _JanleSeiSyoukeiseisaku = _JanleSeiSyoukeiseisaku + SeikyuGak;
                        //代理店請求額.
                        _dairiSeiSyoukeiseisaku = _dairiSeiSyoukeiseisaku + SeikyuGak;

                        _intseisakuRow++;
                    }

                    //制作消費税を入力 
                    if (SeisakuSyohizeiGak != 0)
                    {
                        SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak;
                    }

                    //制作消費税(タレント用)を入力 
                    if (SeisakuSyohizeiGak_Talent != 0)
                    {
                        SumSyouhiZeiGak = SumSyouhiZeiGak + SeisakuSyohizeiGak_Talent;
                    }

                    //************************************.
                    //代理店計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    
                    sprSeisaku.Cells[_intseisakuRow, 7].Value = "代理店計";
                    sprSeisaku.Cells[_intseisakuRow, 8].Value = (_dairiSeiSyoukeiseisaku + Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");

                    //************************************.
                    //消費税計行を作成.
                    //************************************.
                    //スプレッドシートに行を追加.
                    sprSeisaku.Rows.Add(sprSeisaku.RowCount, 1);
                    _intseisakuRow++;
                    sprSeisaku.Cells[_intseisakuRow, 7].Value = "消費税計";
                    sprSeisaku.Cells[_intseisakuRow, 8].Value =  (Math.Truncate(SumSyouhiZeiGak)).ToString("#,0");

                    //初期化 
                    SumSyouhiZeiGak = 0;
                    SeisakuSyohizeiGak = 0;
                    SeisakuSyohizeiGak_Talent = 0;

                    //************************************.
                    //値の位置.
                    //************************************.
                    sprSample.Columns[0].HorizontalAlignment = CellHorizontalAlignment.Left;
                    for (int i = 1; i < 5; i++)
                    {
                        sprSeisaku.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    }
                    //媒体名称.
                    sprSeisaku.Columns[5].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //ブランドコード.
                    sprSeisaku.Columns[6].HorizontalAlignment = CellHorizontalAlignment.Center;

                    //ブランド名称.
                    sprSeisaku.Columns[7].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //請求額 
                    sprSeisaku.Columns[8].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //消費税 
                    sprSeisaku.Columns[9].HorizontalAlignment = CellHorizontalAlignment.Right;

                    //消費税 
                    sprSeisaku.Columns[10].HorizontalAlignment = CellHorizontalAlignment.Left;

                    //取得結果データをDataSetにセット.
                    _dsLion = result.dsDetailListLionDataSet;
                  
                    //Excelボタン押下可能.
                    btnXls.Enabled = true;

                    //件数をセット.
                    statusStrip1.Items["tslval1"].Text = result.dsDetailListLionDataSet.Tables[LION_TBLNM].Rows.Count + "件";
                    
                    //垂直スクロールバーを表示する.
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always;

                    #endregion シートにセット

                }

                //カードNoと代理店コードを非表示にする
                sprSeisaku.Columns[1].Visible = false;
                sprSeisaku.Columns[3].Visible = false;

                //データ年月を1列目に移動
                sprSeisaku.MoveColumn(2, 0, true); 

            }
            #endregion "制作"

            //ローディング表示終了 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param></param>
        private void ExcelOut()
        {
            if (this.sprMain.ActiveSheet.Rows.Count == 0)
            {
                //帳票出力不可メッセージ表示 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0061, null, "作成対象なし", MessageBoxButtons.OK);
                return;
            }

            // 出力パス 
            string excelOutPut = string.Empty;

            //SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();
            string _excelFileName = "";
            string _initialDirectory = "";
            string[] _outPutExcelInfo = null;

            //ファイル名を指定 
            if (KKHUtility.ToString(_excelFileName) == "")
            {
                sfd.FileName = this.Name + "_" + DateTime.Now.ToString("yyyyMMdd") + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;
            }
            else
            {
                sfd.FileName = _excelFileName + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;
            }

            //初期表示フォルダを指定 
            if (_initialDirectory == "")
            {
                sfd.InitialDirectory = @"C:\work\";
            }
            else
            {
                sfd.InitialDirectory = _initialDirectory;
            }

            //[ファイルの種類]を指定 
            sfd.Filter = "EXCELﾌｧｲﾙ|*" + KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT;

            //「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 2;

            //タイトルを設定 
            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に復元するようにする 
            sfd.RestoreDirectory = true;

            //ダイアログを表示する 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //文字列末の".xls"を削除する 
                sfd.FileName = sfd.FileName.Substring(0, sfd.FileName.Length - KKHSpreadOutPutExcelHandler.OUTPUT_EXCEL_EXT.Length);

                //OKボタンがクリックされたとき 　
                excelOutPut = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            else
            {
                return;
            }

            using (KKHSpreadOutPutExcelHandler spreadOutPutExcelHandler
                = new KKHSpreadOutPutExcelHandler(this.sprMain, sfd.FileName))
            {
                //spreadOutPutExcelHandler.OutPutExcel();
                List<string> outPutExcelInfo = new List<string>();
                if (_outPutExcelInfo != null)
                {
                    foreach (string str in _outPutExcelInfo)
                    {
                        outPutExcelInfo.Add(str);
                    }
                }
                spreadOutPutExcelHandler.OutPutExcel(outPutExcelInfo);
                spreadOutPutExcelHandler.ProcessStart();
            }

            // オペレーションログの出力 
            KKHLogUtilityLion.WriteOperationLogToDB(_naviParam,
                APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_DETAILLIST, KKHLogUtilityLion.DESC_OPERATION_LOG_DETAILLIST + "＿" + cmbBaitaiKbn.Text);
        }

        /// <summary>
        /// 営業日を取得 
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        /// <summary>
        /// スプレッドシートの初期化 
        /// </summary>
        private void SprSyokika()
        {
            sprTV_Time.Visible = false;
            sprRd_Time.Visible = false;
            sprTV_Spot.Visible = false;
            sprRd_Spot.Visible = false;
            sprShin.Visible = false;
            sprZashi.Visible = false;
            sprKoutsuu.Visible = false;
            sprJigyoubu.Visible = false;
            sprTirashi.Visible = false;
            sprMobile.Visible = false;
            sprSample.Visible = false;
            sprInternet.Visible = false;
            sprBscs.Visible = false;
            sprSonota.Visible = false;
            sprSeisaku.Visible = false;
            sprTV_Cm.Visible = false;
            sprRd_Cm.Visible = false;
            sprTV_Time.RowCount = 0;
            sprRd_Time.RowCount = 0;
            sprTV_Spot.RowCount = 0;
            sprRd_Spot.RowCount = 0;
            sprShin.RowCount = 0;
            sprZashi.RowCount = 0;
            sprKoutsuu.RowCount = 0;
            sprJigyoubu.RowCount = 0;
            sprTirashi.RowCount = 0;
            sprMobile.RowCount = 0;
            sprSample.RowCount = 0;
            sprInternet.RowCount = 0;
            sprBscs.RowCount = 0;
            sprSonota.RowCount = 0;
            sprSeisaku.RowCount = 0;
            sprTV_Cm.RowCount = 0;
            sprRd_Cm.RowCount = 0;


            //***********************************
            //スプレッドシートのタブを非表示 
            //***********************************
            sprMain.TabStripPolicy = TabStripPolicy.Never;
        }

        # endregion メソッド
    }
}
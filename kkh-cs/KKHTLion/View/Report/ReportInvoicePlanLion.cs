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
using Isid.KKH.Common.KKHSchema;
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
    /// 得意先ライオン制作費請求予定表.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportInvoicePlanLion : KKHForm
    {

        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "InvPln";

        #region データテーブルカラム定数.

        /// <summary>
        /// ブランドコード.
        /// </summary>
        private const String BRDCD = "BRDCD";
        /// <summary>
        /// ブランド名称.
        /// </summary>
        private const String BRDNM = "BRDNM";
        /// <summary>
        /// 件名.
        /// </summary>
        private const String KENNM = "KENNM";
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const String SEIGAK = "SEIGAK";
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const String BAITAIKBN = "BAITAIKBN";
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const String BAITAINM = "BAITAINM";

        #endregion データテーブルカラム定数.

        #region スプレッド定数.

        /// <summary>
        /// ブランドコード.
        /// </summary>
        private const int COLIDX_BRDCD = 0;
        /// <summary>
        /// ブランド名称.
        /// </summary>
        private const int COLIDX_BRDNM = 1;
        /// <summary>
        /// 件名.
        /// </summary>
        private const int COLIDX_KENNM = 2;
        /// <summary>
        /// 請求金額.
        /// </summary>
        private const int COLIDX_SEIGAK = 3;
        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        private const int COLIDX_BAITAIKBN = 4;
        /// <summary>
        /// 媒体名称.
        /// </summary>
        private const int COLIDX_BAITAINM = 5;

        /// <summary>
        /// 検索キーワード.
        /// </summary>
        private const String SEARCH_WORD = "制作部．";
        /// <summary>
        /// 小計.
        /// </summary>
        private const String SUB_TOTAL = "小計";
        /// <summary>
        /// 総計.
        /// </summary>
        private const String TOTAL = "総計";

        #endregion スプレッド定数.

        #region 事業部コンボボックス定数.

        /// <summary>
        /// 生コマ.
        /// </summary>
        private const String DIV_ONAIR_CM = "生コマ";
        /// <summary>
        /// ライオン商事.
        /// </summary>
        private const String DIV_LION_AFFAIRS = "ライオン商事";
        /// <summary>
        /// プリント費.
        /// </summary>
        private const String DIV_PRINT_COST = "プリント費";

        #endregion 事業部コンボボックス定数.

        #endregion 定数.

        #region メンバ変数.

        /// <summary>
        /// Naviパラメータ.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// マスタ用データセット.
        /// </summary>
        private MastLion MastLionDs = new MastLion();
        /// <summary>
        /// 請求予定表データセット.
        /// </summary>
        private InvoicePlanLion invPlnDsLion = new InvoicePlanLion();
        /// <summary>
        /// 事業部マスタデータテーブル.
        /// </summary>
        MastLion.DivisionDataTable dtDiv = new MastLion.DivisionDataTable();

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportInvoicePlanLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        #region 画面ロード時.

        /// <summary>
        /// 画面表示時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAddChgLion_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //パラメータ取得.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 画面ロード時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAddChgLion_Shown(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            //検索年月取得.
            string hostdate = getHostDate();
            txtYm.Value = hostdate.Substring(0, 6);

            //検索年月コンボボックス設定.
            txtYm.cmbYM_SetDate();

            //ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            ////スプレッド初期化.
            //InitSpread();

            //グリッドの設定.
            statusStrip1.Items["tslval1"].Text = "0件";

            //*************************
            //ライオンマスタの取得.
            //*************************
            KKHLionReadMastFile mast = new KKHLionReadMastFile();
            MastLionDs = mast.GetLionMast(_naviParam);

            if (MastLionDs.TvBnLion.Count == 0 &&
                MastLionDs.RdBnLion.Count == 0 &&
                MastLionDs.TvKLion.Count == 0 &&
                MastLionDs.RdKLion.Count == 0)
            {
                base.CloseLoadingDialog();
                Navigator.Backward(this, null, _naviParam, true);
                return;
            }

            //事業部マスタ取得、コンボボックス設定.
            GetDiv();

            //事業部コンボボックスの先頭の項目をセット.
            cmbDiv.SelectedIndex = 0;

            base.CloseLoadingDialog();
        }

        #endregion 画面ロード時.

        #region 戻るボタン.

        /// <summary>
        /// 戻るボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender , EventArgs e)
        {
            Navigator.Backward(this , null , _naviParam , true);
        }

        #endregion 戻るボタン.

        #region 検索ボタン.

        /// <summary>
        /// 検索ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //レコード検索.
            this.GetRecord();
        }

        #endregion 検索ボタン.

        #region ヘルプボタン.

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

        #endregion ヘルプボタン.

        #region 年月テキストボックス.

        /// <summary>
        /// 年月テキストボックス入力時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Leave(object sender, EventArgs e)
        {
            //事業部にファブリックを設定.
            cmbDiv.SelectedIndex = 0;
            //スプレッド初期化.
            spsMain.Rows.Count = 0;
        }

        #endregion 年月テキストボックス.

        #region 出力帳票コンボボックス.

        /// <summary>
        /// 事業部コンボボックス選択時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDiv_SelectedIndexChanged(object sender, EventArgs e)        
        {
            //スプレッド初期化.
            spsMain.Rows.Count = 0;
        }

        #endregion 出力帳票コンボボックス.

        #endregion イベント.

        #region メソッド.

        #region レコード取得.

        /// <summary>
        /// レコード取得.
        /// </summary>
        private void GetRecord()
        {
            //スプレッドインデックス.
            int _intRow = 0;
            //ブランドコード.
            String strBrdCd = String.Empty;
            //請求金額.
            double _dblSeigak = 0;
            //小計.
            double dblSubTotal = 0;
            //総計.
            double dblTotal = 0;

            //ローディング表示開始.
            base.ShowLoadingDialog();

            //年月の取得.
            string yyyyMm = txtYm.Value;

            //*******************
            //データ取得.
            //*******************
            //請求予定表.
            invPlnDsLion = FindInvoicePlan(yyyyMm);            

            //取得結果が0件の場合.
            if (invPlnDsLion.InvoicePlan.Rows.Count == 0)
            {
                statusStrip1.Items["tslval1"].Text = "0件";

                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                
                //スプレッド初期化.
                spsMain.RowCount = 0;

                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            //請求予定表スプレッド設定.
            spsMain.Rows.Count = 0;

            //垂直スクロールバーを作業中は非表示にする.
            sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

            //ブランドコード(初期値).
            strBrdCd = invPlnDsLion.InvoicePlan.Rows[0][BRDCD].ToString();

            for (int i = 0; i < invPlnDsLion.InvoicePlan.Rows.Count; i++)
            {
                //行追加.
                spsMain.Rows.Add(spsMain.RowCount, 1);

                //ブランドコードが変わったら小計を出力.
                if (!strBrdCd.Equals(invPlnDsLion.InvoicePlan.Rows[i][BRDCD]))
                {
                    //ブランドコード.
                    strBrdCd = invPlnDsLion.InvoicePlan.Rows[i][BRDCD].ToString();
                    
                    //小計.
                    spsMain.Cells[_intRow, COLIDX_KENNM].HorizontalAlignment = CellHorizontalAlignment.Right;   //右寄せ.
                    spsMain.Cells[_intRow, COLIDX_KENNM].Value = SUB_TOTAL;
                    spsMain.Cells[_intRow, COLIDX_SEIGAK].Value = dblSubTotal;

                    //行追加.
                    spsMain.Rows.Add(spsMain.RowCount, 1);

                    //初期化.
                    dblSubTotal = 0;

                    //行数に加算.
                    _intRow++;
                }

                //ブランドコード.
                spsMain.Cells[_intRow, COLIDX_BRDCD].Value = invPlnDsLion.InvoicePlan.Rows[i][BRDCD];
                //ブランド名称.
                spsMain.Cells[_intRow, COLIDX_BRDNM].Value = invPlnDsLion.InvoicePlan.Rows[i][BRDNM];
                //件名.
                spsMain.Cells[_intRow, COLIDX_KENNM].Value = invPlnDsLion.InvoicePlan.Rows[i][KENNM];
                //請求金額.
                _dblSeigak = KKHUtility.DouParse(invPlnDsLion.InvoicePlan.Rows[i][SEIGAK].ToString());
                spsMain.Cells[_intRow, COLIDX_SEIGAK].Value = _dblSeigak;
                //媒体区分コード.
                spsMain.Cells[_intRow, COLIDX_BAITAIKBN].Value = invPlnDsLion.InvoicePlan.Rows[i][BAITAIKBN];
                //媒体名称.
                spsMain.Cells[_intRow, COLIDX_BAITAINM].Value = invPlnDsLion.InvoicePlan.Rows[i][BAITAINM].ToString().Replace(SEARCH_WORD, "");

                //小計に加算.
                dblSubTotal += _dblSeigak;
                //総計に加算.
                dblTotal += _dblSeigak;

                //行数に加算.
                _intRow++;
            }

            //行追加.
            spsMain.Rows.Add(spsMain.RowCount, 1);

            //小計.
            spsMain.Cells[_intRow, COLIDX_KENNM].HorizontalAlignment = CellHorizontalAlignment.Right;   //右寄せ.
            spsMain.Cells[_intRow, COLIDX_KENNM].Value = SUB_TOTAL;
            spsMain.Cells[_intRow, COLIDX_SEIGAK].Value = dblSubTotal;

            //行追加.
            spsMain.Rows.Add(spsMain.RowCount, 1);

            //行数に加算.
            _intRow++;

            //総計.
            spsMain.Cells[_intRow, COLIDX_KENNM].HorizontalAlignment = CellHorizontalAlignment.Right;   //右寄せ.
            spsMain.Cells[_intRow, COLIDX_KENNM].Value = TOTAL;
            spsMain.Cells[_intRow, COLIDX_SEIGAK].Value = dblTotal;

            //件数をセット.
            statusStrip1.Items["tslval1"].Text = invPlnDsLion.InvoicePlan.Rows.Count + "件";

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        #endregion レコード取得.

        #region 営業日取得.

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        #endregion 営業日取得.

        #region スプレッド初期化.

        /// <summary>
        /// スプレッドシートの初期化.
        /// </summary>
        private void InitSpread()
        {
            //初期化.
            spsMain.RowCount = 0;
            
            //スプレッドシートのタブを表示.
            sprMain.TabStripPolicy = TabStripPolicy.Always;
        }

        #endregion スプレッド初期化.

        #region マスタ取得(事業部マスタ).

        /// <summary>
        /// 事業部マスタデータ取得.
        /// </summary>
        private void GetDiv()
        {
            KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController processController =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();

            //データ取得.
            FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(_naviParam.strEsqId
                                                                                                , _naviParam.strEgcd
                                                                                                , _naviParam.strTksKgyCd
                                                                                                , _naviParam.strTksBmnSeqNo
                                                                                                , _naviParam.strTksTntSeqNo
                                                                                                , KKHLionConst.C_MAST_DIV_CD
                                                                                                , "");

            if (result.HasError)
            {
                //メッセージ表示
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                return;
            }

            //結果が0件の時  
            if (result.MasterDataSet.MasterDataVO.Rows.Count == 0)
            {
                //メッセージ表示
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                return;
            }

            //事業部コンボボックス設定.
            List<LionComboBoxItem> items = new List<LionComboBoxItem>();
            MasterMaintenance ds = result.MasterDataSet;
            MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                items.Add(new LionComboBoxItem(row.Column1, row.Column2));
            }

            int voCnt = rows.Length;

            //生コマ.
            voCnt++;
            items.Add(new LionComboBoxItem(voCnt.ToString("000"), DIV_ONAIR_CM));
            //プリント費.
            voCnt++;
            items.Add(new LionComboBoxItem(voCnt.ToString("000"), DIV_PRINT_COST));

            cmbDiv.DisplayMember = "NAME";
            cmbDiv.ValueMember = "CODE";
            cmbDiv.DataSource = items;
        }

        #endregion マスタ取得(事業部マスタ).

        #region 請求予定表取得.

        /// <summary>
        /// 請求予定表取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <returns>制作室リスト・追加変更リストDataSet</returns>
        private InvoicePlanLion FindInvoicePlan(String yymm)
        {
            //請求予定表取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindInvoicePlanParam param = new ReportLionProcessController.FindInvoicePlanParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.
            param.division = cmbDiv.Text;                   //事業部.

            FindInvoicePlanByCondServiceResult result = controller.findLionInvoicePlan(param);

            return result.dsInvPlnLionDataSet;
        }

        #endregion 請求予定表取得.

        #endregion メソッド.

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox;
using Isid.KKH.Common.KKHView.Common.Form;

using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Lion.Properties;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// 得意先ライオン受注比較一覧帳票出力.
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
    ///       <description>2014/11/10</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportOrderDiffLion : KKHForm
    {
        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "OrdDif";

        /// <summary>
        /// 受注比較一覧帳票Excelマクロファイル名.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_MACRO_FILENAME = "Lion_OrderDiff_Mcr.xlsm";
        /// <summary>
        /// 受注比較一覧帳票Excelテンプレートファイル名.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_TEMPLATE_FILENAME = "Lion_OrderDiff_Template.xlsx";
        /// <summary>
        /// 受注比較一覧帳票データXMLファイル名.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_DATA_XML_FILENAME = "Lion_OrderDiff_Data.xml";
        /// <summary>
        /// 受注比較一覧帳票プロパティXMLファイル名.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_PROP_XML_FILENAME = "Lion_OrderDiff_Prop.xml";

        /// <summary>
        /// 受注比較一覧帳票：006(帳票出力情報抽出用)
        /// </summary>
        private const string REP_KEY_SYBT = "006";

        #region 出力帳票名.

        /// <summary>
        /// １次制作室リスト.
        /// </summary>
        private const String ORDER_DIFF = "受注比較一覧";

        #endregion 出力帳票名.

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
        /// 帳票出力リスト用データセット.
        /// </summary>
        private OrderDiffLion orderDiffDsLion = new OrderDiffLion();
        /// <summary>
        /// Excelマクロファイル名.
        /// </summary>
        private string _mStrMacroFileNm;
        /// <summary>
        /// Excelテンプレートファイル名.
        /// </summary>
        private string _mStrTemplateFileNm;

        /// <summary>
        /// 帳票出力名.
        /// </summary>
        private string _mStrOutReportNm;
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;
        /// <summary>
        /// 受注比較帳票名変数.
        /// </summary>
        private string _mStrRepFileNm = string.Empty;

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportOrderDiffLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面表示時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportOrderDiffLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        private void ReportOrderDiffLion_Shown(object sender, EventArgs e)
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
                //受注比較一覧帳票名.
                _mStrRepFileNm = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

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

            base.CloseLoadingDialog();
        }

        #region 帳票出力ボタン.

        /// <summary>
        /// 帳票出力.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //メッセージタイトル.
            String strMsgCaption = String.Empty;

            //SaveFileDialogクラスのインスタンス生成.
            SaveFileDialog sfd = new SaveFileDialog();

            //本日日付.
            DateTime now = DateTime.Now;

            //出力用年月.
            string strOutYymm = string.Empty;
            string strTmpYymm = txtYm.Value;
            int intTmpMm = int.Parse(strTmpYymm.Substring(4, 2));
            strOutYymm = strTmpYymm.Substring(0, 4) + "." + intTmpMm.ToString();

            //出力ファイル名.
            sfd.FileName = _mStrRepFileNm.Replace("@@@", strOutYymm) + "　" + now.ToString("yyyy.MM.dd") + ".xls";
            //メッセージタイトル.
            strMsgCaption = ORDER_DIFF;

            //デフォルト表示するフォルダ名指定.
            sfd.InitialDirectory = _mStrRepAdrs;

            //[ファイルの種類]に表示されるファイル種別指定.
            sfd.Filter = "XLSファイル(*.xls)|*.xls";

            //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            //タイトル設定.
            sfd.Title = "保存先のファイルを設定して下さい。";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログ表示.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名ファイルを削除.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, strMsgCaption, MessageBoxButtons.OK);
                    return;
                }

                //データ取得.
                if (!GetRecord())
                {
                    //処理終了.
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName, now);
            }

            sfd.Dispose();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        #endregion 帳票出力ボタン.

        #region 戻るボタン.

        /// <summary>
        /// 戻るボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender, EventArgs e)
        {
            if (_mStrMacroFileNm != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_mStrMacroFileNm);

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

        #endregion 戻るボタン.

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

        #endregion イベント.

        #region メソッド.

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

        #region レコード取得.

        /// <summary>
        /// レコード取得.
        /// </summary>
        private bool GetRecord()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //年月の取得.
            string yyyyMm = txtYm.Value;

            //*******************
            //データ取得.
            //*******************
            //受注比較一覧取得.
            orderDiffDsLion = FindOrderDiffList(yyyyMm);

            if (orderDiffDsLion.OrderDiffList.Rows.Count == 0 &&
                orderDiffDsLion.OrderNewList.Rows.Count == 0 &&
                orderDiffDsLion.OrderAmountDiffList.Rows.Count == 0)
            {
                 //メッセージ：HB-W0023 該当するデータがありません。.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                return false;
            }

            //ローディング表示終了.
            base.CloseLoadingDialog();
            return true;
        }

        #endregion レコード取得.

        #region Excel出力.

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="strFileNm">出力ファイル名</param>
        private void ExcelOut(string strFileNm, DateTime dt)
        {
            DataRow dtRow;

            //マクロファイル名設定.
            _mStrMacroFileNm = _mStrRepTempAdrs + REP_ORDER_DIFF_MACRO_FILENAME;
            //テンプレートファイル名設定.
            _mStrTemplateFileNm = _mStrRepTempAdrs + REP_ORDER_DIFF_TEMPLATE_FILENAME;

            try
            {
                //Excel開始処理.
                //リソースからExcelファイルを作成.
                //マクロファイル.
                File.WriteAllBytes(_mStrMacroFileNm, Resources.Lion_OrderDiff_Mcr);
                //テンプレートファイル.
                File.WriteAllBytes(_mStrTemplateFileNm, Resources.Lion_OrderDiff_Template);

                //マクロファイル・テンプレートファイル存在確認(出力フォルダ内).
                if (!System.IO.File.Exists(_mStrMacroFileNm))
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }
                if (!System.IO.File.Exists(_mStrTemplateFileNm))
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }

                // データセットXML出力.
                orderDiffDsLion.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_ORDER_DIFF_DATA_XML_FILENAME));

                // パラメータXML作成.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加.
                // PRODUCTSテーブルを作成.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String")); //ユーザー名.
                dtTable.Columns.Add("YYMM", Type.GetType("System.String"));     //検索年月.
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));  //保存場所.

                //テーブルにデータを追加.
                dtRow = dtTable.NewRow();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["YYMM"] = txtYm.Value;
                dtRow["SAVEDIR"] = strFileNm;
                dtTable.Rows.Add(dtRow);

                //パラメータをXML出力.
                dtSet.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_ORDER_DIFF_PROP_XML_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", _mStrRepTempAdrs + REP_ORDER_DIFF_MACRO_FILENAME);

                //オペレーションログの出力.
                //追加変更リストの場合.
                KKHLogUtility.WriteOperationLogToDB(_naviParam,
                                                    APLID,
                                                    KKHLogUtilityLion.KIND_ID_OPERATION_LOG_ORDERDIFFLIST,
                                                    KKHLogUtilityLion.DESC_OPERATION_LOG_ORDERDIFFLIST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Excel出力.

        #region 受注比較一覧取得.

        /// <summary>
        /// 受注比較一覧取得.
        /// </summary>
        /// <param name="yymm">年月</param>
        /// <returns>受注比較一覧DataSet</returns>
        private OrderDiffLion FindOrderDiffList(String yymm)
        {
            //受注比較一覧取得.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindOrderDiffListParam param = new ReportLionProcessController.FindOrderDiffListParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //営業所コード.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //得意先企業コード.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //得意先部門SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //得意先担当SEQNO.
            param.yymm = yymm;                              //年月.

            FindOrderDiffListByCondServiceResult result = controller.findOrderDiffList(param);

            return result.dsOrdDiffListLionDataSet;
        }

        #endregion 受注比較一覧取得.

        #endregion メソッド.
    }
}


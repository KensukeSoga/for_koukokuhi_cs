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
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Tkd.ProcessController.Report;
using Isid.KKH.Tkd.Schema;
using Isid.KKH.Tkd.Utility;
using Isid.KKH.UserManual;

namespace Isid.KKH.Tkd.View.Report
{
    public partial class ReportTkdBilling : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region 定数

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private const String REPORT_DATA_XML_FILENAME = "Tkd_Data.xml";

        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private const String REPORT_PROPERTY_XML_FILENAME = "Tkd_Prop.xml";

        /// <summary>
        /// 請求明細（中分類別）帳票出力テンプレートExcelファイル名.
        /// </summary>
        private const String REPORT_BY_MIDDLE_CLASSIFICATION_TEMPLATE_FILENAME = "TkdReportByMiddleClassification_Template.xlsx";

        /// <summary>
        /// 請求明細（中分類別）帳票出力マクロ実装Excelファイル名.
        /// </summary>
        private const String REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME = "TkdReportByMiddleClassification_Mcr.xlsm";

        /// <summary>
        /// 請求明細（品目別）帳票出力テンプレートExcelファイル名.
        /// </summary>
        private const String REPORT_BY_ITEM_TEMPLATE_FILENAME = "TkdReportByItem_Template.xlsx";

        /// <summary>
        /// 請求明細（品目別）帳票出力マクロ実装Excelファイル名.
        /// </summary>
        private const String REPORT_BY_ITEM_MACRO_FILENAME = "TkdReportByItem_Mcr.xlsm";

        /// <summary>
        /// 請求明細（企画費）帳票出力テンプレートExcelファイル名.
        /// </summary>
        private const String REPORT_FOR_PLANNING_COST_TEMPLATE_FILENAME = "TkdReportForPlanningCost_Template.xlsx";

        /// <summary>
        /// 請求明細（企画費）帳票出力マクロ実装Excelファイル名.
        /// </summary>
        private const String REPORT_FOR_PLANNING_COST_MACRO_FILENAME = "TkdReportForPlanningCost_Mcr.xlsm";

        /// <summary>
        /// サイト120 or サイト30
        /// </summary>
        private const int SITE_TYPE_120_OR_30 = 0;

        /// <summary>
        /// サイトその他
        /// </summary>
        private const int SITE_TYPE_OTHER = 1;

        /// <summary>
        /// テレビ番組媒体フィー
        /// </summary>
        private const String gstrTVFee = "FEE01";

        /// <summary>
        /// テレビスポット媒体フィー
        /// </summary>
        private const String gstrTVSpotFee = "FEE02";

        /// <summary>
        /// 制作プロジェクトフィー
        /// </summary>
        private const String gstrSeisakuFee = "FEE16";

        /// <summary>
        /// Web制作プロジェクトフィー
        /// </summary>
        private const String gstrWebFee = "FEE18";

        /// <summary>
        /// リテーナフィー
        /// </summary>
        private const String gstrRTFee = "FEE19";

        /// <summary>
        /// プロジェクトフィー計
        /// </summary>
        private const String gstrPJFee = "PJFEE";

        /// <summary>
        /// 原価
        /// </summary>
        private const String gstrGenka = "1";

        /// <summary>
        /// フィー
        /// </summary>
        private const String gstrFee = "2";

        /// <summary>
        /// サイトNo120
        /// </summary>
        private const String gstrSite120 = "120";

        /// <summary>
        /// サイトNo30
        /// </summary>
        private const String gstrSite30 = "30";

        /// <summary>
        /// 小計タイトル
        /// </summary>
        private const String gstrOutSyoukei = "小 計";

        /// <summary>
        /// 消費税込タイトル
        /// </summary>
        private const String gstrOutZeikomi = "(消費税込み)";

        /// <summary>
        /// 合計タイトル
        /// </summary>
        private const String gstrOutGoukei = "合 計";

        /// <summary>
        /// 消費税タイトル
        /// </summary>
        private const String gstrOutSyohizei = "消 費 税";

        #endregion 定数

        #region 構造体

        /// <summary>
        /// 中分類別用クラス
        /// </summary>
        private class MiddleClassificationWorkData
        {
            public List<MiddleClassificationWorkSiteData> siteArray;

            public MiddleClassificationWorkData()
            {
                siteArray = new List<MiddleClassificationWorkSiteData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkSiteData i in siteArray )
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// 中分類別－サイトクラス
        /// </summary>
        private class MiddleClassificationWorkSiteData
        {
            /// <summary>
            /// 代理店コード
            /// </summary>
            public String strDairitenCD;

            /// <summary>
            /// 実施年月
            /// </summary>
            public String strYM;

            /// <summary>
            /// サイト
            /// </summary>
            public String strSite;

            /// <summary>
            /// 中分類詳細データクラス
            /// </summary>
            public List<MiddleClassificationWorkCYBNData> CYBNArray;

            public MiddleClassificationWorkSiteData()
            {
                CYBNArray = new List<MiddleClassificationWorkCYBNData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkCYBNData i in CYBNArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// 中分類別－中分類クラス
        /// </summary>
        private class MiddleClassificationWorkCYBNData
        {
            /// <summary>
            /// 媒体中分類コード
            /// </summary>
            public String strCYBNCD;

            /// <summary>
            /// 媒体中分類名
            /// </summary>
            public String strCYBNNM;

            /// <summary>
            /// 中分類個別媒体データクラス
            /// </summary>
            public List<MiddleClassificationWorkKBTData> KBTArray;

            public MiddleClassificationWorkCYBNData()
            {
                KBTArray = new List<MiddleClassificationWorkKBTData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkKBTData i in KBTArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// 中分類別－個別媒体クラス
        /// </summary>
        private class MiddleClassificationWorkKBTData
        {
            /// <summary>
            /// 個別媒体名
            /// </summary>
            public String strKBTNM;

            /// <summary>
            /// 個別媒体コード
            /// </summary>
            public String strKBTCD;

            /// <summary>
            /// 一連番号
            /// </summary>
            public String strRenNo;

            /// <summary>
            /// 個別媒体品目データクラス
            /// </summary>
            public List<MiddleClassificationWorkHinmokuData> hinmokuArray;

            public MiddleClassificationWorkKBTData()
            {
                hinmokuArray = new List<MiddleClassificationWorkHinmokuData>();
            }

            public int getHierarchicalCount()
            {
                return hinmokuArray.Count;
            }
        };

        /// <summary>
        /// 中分類別－品目クラス
        /// </summary>
        private class MiddleClassificationWorkHinmokuData
        {
            /// <summary>
            /// 品目名
            /// </summary>
            public String strHinmokuNM;

            /// <summary>
            /// 品目コード
            /// </summary>
            public String strHinmokuCD;

            /// <summary>
            /// 管理区分
            /// </summary>
            public String strKanriKBN;

            /// <summary>
            /// 配分比率
            /// </summary>
            public int intHaibunHiritsu;

            /// <summary>
            /// 配付額
            /// </summary>
            public Decimal curHaifugaku;

            /// <summary>
            /// サイト
            /// </summary>
            public String strSite;

            /// <summary>
            /// 備考
            /// </summary>
            public String strBiko;
        };

        /// <summary>
        /// 品目別用クラス
        /// </summary>
        private class ItemWorkData
        {
            public List<ItemWorkSiteData> siteArray;

            public ItemWorkData()
            {
                siteArray = new List<ItemWorkSiteData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (ItemWorkSiteData i in siteArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// 品目別－サイトクラス
        /// </summary>
        private class ItemWorkSiteData
        {
            /// <summary>
            /// 代理店コード
            /// </summary>
            public String strDairitenCD;

            /// <summary>
            /// 実施年月
            /// </summary>
            public String strYM;

            /// <summary>
            /// サイト
            /// </summary>
            public String strSite;

            /// <summary>
            /// 中分類詳細データクラス
            /// </summary>
            public List<ItemWorkCYBNData> CYBNArray;

            public ItemWorkSiteData()
            {
                CYBNArray = new List<ItemWorkCYBNData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (ItemWorkCYBNData i in CYBNArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// 品目別－中分類クラス
        /// </summary>
        private class ItemWorkCYBNData
        {
            /// <summary>
            /// 媒体中分類コード
            /// </summary>
            public String strCYBNCD;

            /// <summary>
            /// 媒体中分類名
            /// </summary>
            public String strCYBNNM;

            /// <summary>
            /// 個別媒体品目データ構造体
            /// </summary>
            public List<ItemWorkHinmokuData> hinmokuArray;

            public ItemWorkCYBNData()
            {
                hinmokuArray = new List<ItemWorkHinmokuData>();
            }

            public int getHierarchicalCount()
            {
                return hinmokuArray.Count;
            }
        };

        /// <summary>
        /// 品目別－品目クラス
        /// </summary>
        private class ItemWorkHinmokuData
        {
            /// <summary>
            /// 品目名
            /// </summary>
            public String strHinmokuNM;

            /// <summary>
            /// 品目コード
            /// </summary>
            public String strHinmokuCD;

            /// <summary>
            /// 管理区分
            /// </summary>
            public String strKanriKBN;

            /// <summary>
            /// 金額
            /// </summary>
            public Decimal curKingaku;

            /// <summary>
            /// 税込み金額
            /// </summary>
            public Decimal curZeikomi;


            public String strFEECD;
        };

        /// <summary>
        /// 企画費－集計用クラス
        /// </summary>
        private class mtypHinmoku
        {
            public String Cd;
            public String Name;
            public Decimal Kingaku;
        };

        #endregion 構造体

        #region メンバ変数

        /// <summary>
        /// 呼び出しパラメータ(受取)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 消費税率
        /// </summary>
        private Decimal _taxRate;

        /// <summary>
        /// 請求明細（中分類別）コピーマクロ削除用string
        /// </summary>
        private String _strReportByMiddleClassificationMacroPath = null;

        /// <summary>
        /// 請求明細（品目別）コピーマクロ削除用string
        /// </summary>
        private String _strReportByItemMacroPath = null;

        /// <summary>
        /// 請求明細（企画費）コピーマクロ削除用string
        /// </summary>
        private String _strReportForPlanningCostMacroPath = null;

        /// <summary>
        /// 保存先用(テンプレート)変数
        /// </summary>
        private string strReportTempPath = "";

        /// <summary>
        /// 保存先用変数
        /// </summary>
        private string strReportDefaultPath = "";

        /// <summary>
        /// 請求明細（中分類別）帳票名（保存で使用）用変数
        /// </summary>
        private string strReportByMiddleClassificationFilename = "";

        /// <summary>
        /// 請求明細（品目）帳票名（保存で使用）用変数
        /// </summary>
        private string strReportByItemFilename = "";

        /// <summary>
        /// 請求明細（企画費）帳票名（保存で使用）用変数
        /// </summary>
        private string strReportForPlanningCostFilename = "";

        /// <summary>
        /// 保持用データセット
        /// </summary>
        private DataSet putDataSet = null;

        /// <summary>
        /// 保持用消費税率
        /// </summary>
        private String putTaxRate = null;

        /// <summary>
        /// 保持用営業店コード
        /// </summary>
        private String putEGCD = null;

        /// <summary>
        /// アプリID
        /// </summary>
        private string APLID = string.Empty;

        #endregion メンバ変数

        # region イベント
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
        /// 画面が呼び出された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportTkdBilling_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            // 初期設定
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

            // シート表示・非表示設定 
            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet3.Visible = false;

            // ラジオボタンの初期化
            groupBox2.Enabled = true;
            radioButton3.Checked = true;
            radioButton1.Checked = true;

            // ステータスの初期化
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            // 実施年月の初期化
            initializeYYYYMM();

            // 消費税率の初期化
            initializeTaxRate();

            // テンプレートパスの初期化
            initializeTempPath();

            // 帳票出力先の初期化
            initializeOutputPath();
        }

        /// <summary>
        /// 表示ボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && radioButton3.Checked)
            {
                loadReportByMiddleClassificationData();
            }
            else if (radioButton1.Checked && radioButton4.Checked)
            {
                loadReportByItemData();
            }
            else if (radioButton2.Checked)
            {
                loadReportForPlanningCostData();
            }

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// エクセルボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            APLID = string.Empty;
 
            if (radioButton1.Checked && radioButton3.Checked)
            {
                APLID = "RepMid";
                putReportByMiddleClassificationData();
            }
            else if (radioButton1.Checked && radioButton4.Checked)
            {
                APLID = "RepItm";
                putReportByItemData();
            }
            else if (radioButton2.Checked)
            {
                APLID = "RepPln";
                putReportForPlanningCostData();
            }

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 終了ボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            String[] stringArray = new String[]
            {
                _strReportByMiddleClassificationMacroPath,
                _strReportByItemMacroPath,
                _strReportForPlanningCostMacroPath
            };

            foreach (String i in stringArray)
            {
                // 請求明細（中分類別）コピーマクロの削除
                if (i != null)
                {
                    System.IO.FileInfo cFileInfo = new System.IO.FileInfo(i);

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
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 請求明細のラジオボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;

            if (radioButton3.Checked == true)
            {
                activateReportByMiddleClassificationSheet();
            }
            else
            {
                activateReportByItemSheet();
            }
        }

        /// <summary>
        /// 請求明細（企画費）のラジオボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;

            activateReportForPlanningCostSheet();
        }

        /// <summary>
        /// 中分類別のラジオボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;

            activateReportByMiddleClassificationSheet();
        }

        /// <summary>
        /// 品目別別のラジオボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;

            activateReportByItemSheet();
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

        #region メソッド

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ReportTkdBilling()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 実施年月を初期化する
        /// </summary>
        private void initializeYYYYMM()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            String strDate = controller.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            //txtYm.Value = strDate.Substring(0, 6);
            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
            }

        }

        /// <summary>
        /// 消費税率を初期化する
        /// </summary>
        private void initializeTaxRate()
        {
            String taxString = KKHTkdUtility.GetTax(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo
                                                );

            _taxRate = Decimal.Parse(taxString) / 100m;
        }

        /// <summary>
        /// テンプレートアドレスを初期化する
        /// </summary>
        private void initializeTempPath()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            _naviParam.strEsqId,
                                                                            _naviParam.strEgcd,
                                                                            _naviParam.strTksKgyCd,
                                                                            _naviParam.strTksBmnSeqNo,
                                                                            _naviParam.strTksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                            "ED-I0001"
                                                                            );
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                // テンプレートアドレス
                strReportTempPath = result.CommonDataSet.SystemCommon[0].field2;
            }
        }

        /// <summary>
        /// 帳票保存先を初期化する
        /// </summary>
        private void initializeOutputPath()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            _naviParam.strEsqId,
                                                                            _naviParam.strEgcd,
                                                                            _naviParam.strTksKgyCd,
                                                                            _naviParam.strTksBmnSeqNo,
                                                                            _naviParam.strTksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                            "001"
                                                                            );
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                // 保存先
                strReportDefaultPath = result.CommonDataSet.SystemCommon[0].field2;

                // 請求明細（中分類別）名称セット
                strReportByMiddleClassificationFilename = result.CommonDataSet.SystemCommon[0].field3;

                // 請求明細（品目別）名称セット
                strReportByItemFilename = result.CommonDataSet.SystemCommon[0].field4;

                // 請求明細（企画費）名称セット
                strReportForPlanningCostFilename = result.CommonDataSet.SystemCommon[0].field5;
            }
        }

        /// <summary>
        /// 請求明細（中分類別）のスプレッドシートをアクティブにする
        /// </summary>
        private void activateReportByMiddleClassificationSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = false;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0件";
        }

        /// <summary>
        /// 請求明細（品目別）のスプレッドシートをアクティブにする
        /// </summary>
        private void activateReportByItemSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = true;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = false;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0件";
        }

        /// <summary>
        /// 請求明細（企画費）のスプレッドシートをアクティブにする
        /// </summary>
        private void activateReportForPlanningCostSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = true;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0件";
        }


        /// <summary>
        /// 請求明細（中分類別）データの読み込み処理 
        /// </summary>
        private void loadReportByMiddleClassificationData()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 年月の取得 
            string strYYYYMM = txtYm.Value;

            // プロセスコントローラの取得 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // 本データの取得 
            FindReportTkdBillingByMiddleClassificationByCondServiceResult resultMain = controller.FindReportTkdBillingByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_120_OR_30.ToString()
                                                                                      );

            // その他データの取得 
            FindReportTkdBillingByMiddleClassificationByCondServiceResult resultOther = controller.FindReportTkdBillingByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_OTHER.ToString()
                                                                                      );

            // データが存在しなければ終了 
            if ((resultMain.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Rows.Count == 0) && (resultOther.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Rows.Count == 0))
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet1.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0件";

                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);

                return;
            }

            // ワーク用データの生成 
            MiddleClassificationWorkData work = new MiddleClassificationWorkData();

            // 本データの編集 
            putReportByMiddleClassificationWorkData(resultMain, work, SITE_TYPE_120_OR_30);

            // その他データの編集 
            putReportByMiddleClassificationWorkData(resultOther, work, SITE_TYPE_OTHER);

            // 画面への出力 
            putReportByMiddleClassificationView(work);

            // 帳票データセットへの出力 
            putReportByMiddleClassificationMacroData(work);

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// 請求明細（中分類別）集計用データの編集
        /// </summary>
        /// <param name="resultMain"></param>
        /// <param name="work">請求明細（中分類別）集計対象ワーク</param>
        /// <param name="siteType">集計するサイトのパターン</param>
        private static void putReportByMiddleClassificationWorkData(FindReportTkdBillingByMiddleClassificationByCondServiceResult resultMain, MiddleClassificationWorkData work, int siteType )
        {
            String strWorkSite;     // 前レコード比較:用サイト
            Boolean blnKYTFlg;      // 共通情報フラグ
            String strWorkCYBNCD;   // 前レコード比較:用媒体中分類コード
            String strWorkKBTCD;    // 前レコード比較:用個別媒体コード
            String strWorkJSSNO;    // 前レコード比較:実施No

            // カウンタの初期化
            strWorkSite = null;
            blnKYTFlg = false;
            strWorkCYBNCD = null;
            strWorkKBTCD = null;
            strWorkJSSNO = null;

            MiddleClassificationWorkSiteData siteItem = null;
            MiddleClassificationWorkCYBNData CYBNItem = null;
            MiddleClassificationWorkKBTData KBTItem = null;
            MiddleClassificationWorkHinmokuData hinmokuItem = null;

            ReportDSTkdBilling.ReportByMiddleClassificationResultRow[] resultRows = (ReportDSTkdBilling.ReportByMiddleClassificationResultRow[])resultMain.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportByMiddleClassificationResultRow resultRow in resultRows)
            {
                // 出力中分類データ構造体初期化& データの格納
                if (siteType == SITE_TYPE_120_OR_30)
                {
                    // サイトが120か30の場合
                    if (!String.Equals(strWorkSite, resultRow.strSite.Trim()))
                    {
                        siteItem = new MiddleClassificationWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // 代理店コード
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // 実施年月
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        // サイト
                        siteItem.strSite = "";

                        if (resultRow.IsstrSiteNull() == false)
                        {
                            siteItem.strSite = resultRow.strSite.Trim();
                        }

                        // カウンタリセット
                        strWorkSite = siteItem.strSite;
                        strWorkCYBNCD = null;
                        strWorkKBTCD = null;
                        strWorkJSSNO = null;
                    }
                }
                else
                {
                    // サイトが120でも30でもない場合
                    if (blnKYTFlg == false)
                    {
                        siteItem = new MiddleClassificationWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // 代理店コード
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // 実施年月
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        // サイト
                        siteItem.strSite = "その他";

                        // カウンタリセット
                        blnKYTFlg = true;
                        strWorkCYBNCD = null;
                        strWorkKBTCD = null;
                        strWorkJSSNO = null;
                    }
                }

                // 出力中分類詳細データ構造体初期化& データの格納
                if (!String.Equals(strWorkCYBNCD, resultRow.strCYBNCD.Trim()))
                {
                    CYBNItem = new MiddleClassificationWorkCYBNData();
                    siteItem.CYBNArray.Add(CYBNItem);

                    // 媒体中分類コード
                    CYBNItem.strCYBNCD = "";

                    if (resultRow.IsstrCYBNCDNull() == false)
                    {
                        CYBNItem.strCYBNCD = resultRow.strCYBNCD.Trim();
                    }

                    // 媒体中分類名
                    CYBNItem.strCYBNNM = "";

                    if (resultRow.IsstrCYBNNMNull() == false)
                    {
                        CYBNItem.strCYBNNM = resultRow.strCYBNNM.Trim();
                    }

                    strWorkCYBNCD = CYBNItem.strCYBNCD;
                    strWorkKBTCD = null;
                    strWorkJSSNO = null;
                }

                // 個別媒体データ構造体初期化& データの格納
                if ((!String.Equals(strWorkKBTCD, resultRow.strKBTCD.Trim())) || (!String.Equals(strWorkJSSNO, resultRow.RENNO.Trim())))
                {
                    // 媒体レコードが、制作プロジェクトフィー/Web制作プロジェクトフィーの場合
                    KBTItem = new MiddleClassificationWorkKBTData();
                    CYBNItem.KBTArray.Add(KBTItem);

                    // 個別媒体名
                    KBTItem.strKBTNM = "";

                    if (resultRow.IsstrKBTNMNull() == false)
                    {
                        KBTItem.strKBTNM = resultRow.strKBTNM.Trim();
                    }

                    // 個別媒体コード
                    KBTItem.strKBTCD = "";

                    if (resultRow.IsstrKBTCDNull() == false)
                    {
                        KBTItem.strKBTCD = resultRow.strKBTCD.Trim();
                    }

                    // 一連番号
                    KBTItem.strRenNo = "";

                    if (resultRow.IsRENNONull() == false)
                    {
                        KBTItem.strRenNo = resultRow.RENNO.Trim();
                    }

                    strWorkKBTCD = KBTItem.strKBTCD;
                    strWorkJSSNO = KBTItem.strRenNo;
                }

                // 品目データ構造体初期化& データの格納
                hinmokuItem = new MiddleClassificationWorkHinmokuData();
                KBTItem.hinmokuArray.Add(hinmokuItem);

                // 品目名
                hinmokuItem.strHinmokuNM = "";

                if (resultRow.IsstrHinmokuNMNull() == false)
                {
                    hinmokuItem.strHinmokuNM = resultRow.strHinmokuNM.Trim();
                }

                // 品目コード
                hinmokuItem.strHinmokuCD = "";

                if (resultRow.IsstrHinmokuCDNull() == false)
                {
                    hinmokuItem.strHinmokuCD = resultRow.strHinmokuCD.Trim();
                }

                // 管理区分
                hinmokuItem.strKanriKBN = "";

                if (resultRow.IsstrKanriKBNNull() == false)
                {
                    hinmokuItem.strKanriKBN = resultRow.strKanriKBN.Trim();
                }

                // 配分比率
                hinmokuItem.intHaibunHiritsu = 0;

                if (resultRow.IsintHaibunHiritsuNull() == false)
                {
                    hinmokuItem.intHaibunHiritsu = (int)( Decimal.Parse(resultRow.intHaibunHiritsu.Trim()) * 10m );
                }

                // 配付額
                hinmokuItem.curHaifugaku = 0.0m;

                if (resultRow.IscurHaifugakuNull() == false)
                {
                    hinmokuItem.curHaifugaku = Decimal.Parse(resultRow.curHaifugaku.Trim());
                }

                // サイト
                hinmokuItem.strSite = "";

                if (resultRow.IsstrSiteNull() == false)
                {
                    hinmokuItem.strSite = String.Format("{0:00}", resultRow.strSite.Trim());
                }

                // 備考
                hinmokuItem.strBiko = "";

                if (resultRow.IsstrBikoNull() == false)
                {
                    hinmokuItem.strBiko = resultRow.strBiko.Trim();
                }
            }
        }

        /// <summary>
        /// 請求明細（中分類別）画面出力用データの編集
        /// </summary>
        /// <param name="work">請求明細（中分類別）集計済みワーク</param>
        private void putReportByMiddleClassificationView(MiddleClassificationWorkData work)
        {
            // 画面出力用データスキーマの生成 
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            Decimal lcurSougaku;    // 総額 
            Decimal lcurSyoukei;    // 小計 
            Decimal lcurGoukei;     // 合計 
            Decimal lcurPrjFee;     // プロジェクトフィー 
            Boolean blnWEBSSFlg;    // Web制作/制作出力フラグ 

            lcurSougaku = 0;
            lcurSyoukei = 0;
            lcurGoukei = 0;
            lcurPrjFee = 0;

            // 明細行出力用 
            ReportDSTkdBilling.ReportByMiddleClassificationViewRow viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

            foreach (MiddleClassificationWorkSiteData siteItem in work.siteArray)
            {
                //  サイト
                viewRow.cCHSite = siteItem.strSite;
                //  代理店名
                viewRow.cCDairinm = "電通";
                //  代理店コード
                viewRow.cCDairicd = siteItem.strDairitenCD;
                //  実施年月
                viewRow.cCym = siteItem.strYM;

                foreach (MiddleClassificationWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    //  ★出力中分類詳細データ
                    //  媒体中分類コード
                    viewRow.cCBtccd = CYBNItem.strCYBNCD;
                    //  媒体中分類名
                    viewRow.cCBtcnm = CYBNItem.strCYBNNM;

                    //  出力フラグの初期化
                    lcurPrjFee = 0;
                    blnWEBSSFlg = false;

                    foreach (MiddleClassificationWorkKBTData KBTItem in CYBNItem.KBTArray)
                    {
                        // 総額用
                        ReportDSTkdBilling.ReportByMiddleClassificationViewRow itemTotalRow = viewRow;

                        //  ★個別媒体データ
                        if (!String.Equals(KBTItem.strKBTCD, gstrRTFee))
                        {
                            //  ※リテーナフィーは、個別媒体名、個別媒体コード、一連番号は出力しない※
                            //  個別媒体名
                            viewRow.cCBtkbtnm = KBTItem.strKBTNM;
                            //  各媒体アクション
                            if (String.Equals(KBTItem.strKBTCD, gstrSeisakuFee) || String.Equals(KBTItem.strKBTCD, gstrWebFee))
                            {
                                //  ※制作/Web制作のフィーの場合
                                //  一連番号
                                viewRow.cCIchirenno = KBTItem.strRenNo;
                            }
                            else if ((!String.Equals(KBTItem.strKBTCD, gstrTVFee)) && (!String.Equals(KBTItem.strKBTCD, gstrTVSpotFee)))
                            {
                                //  ※テレビ系フィー以外の場合
                                //  個別媒体コード
                                viewRow.cCBtkbtcd = KBTItem.strKBTCD;
                                //  一連番号
                                viewRow.cCIchirenno = KBTItem.strRenNo;
                            }
                        }

                        foreach (MiddleClassificationWorkHinmokuData hinmokuItem in KBTItem.hinmokuArray)
                        {
                            //  ★個別媒体品目データ構造体
                            if ((!String.Equals(hinmokuItem.strKanriKBN, gstrFee)))
                            {
                                //  ※管理区分が1(原価)の場合※
                                //  品目名
                                viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                //  品目コード
                                viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                //  管理区分
                                viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;

                                if ((KBTItem.hinmokuArray.Count > 1) && (hinmokuItem.intHaibunHiritsu < 1000))
                                {
                                    //  品目が1情報しかないなら、配分比率、配付額は表示しない
                                    //  配分比率
                                    viewRow.cCHaibun = (hinmokuItem.intHaibunHiritsu).ToString();
                                    //  配付額
                                    viewRow.cCHaifugaku = (hinmokuItem.curHaifugaku).ToString();
                                }

                                //  サイト
                                viewRow.cCSite = hinmokuItem.strSite;
                                //  備考
                                viewRow.cCBiko = hinmokuItem.strBiko;
                                //  ※総額計算※
                                lcurSougaku = lcurSougaku + hinmokuItem.curHaifugaku;
                            }
                            else
                            {
                                //  ※管理区分が2(フィー)の場合※
                                if (String.Equals(KBTItem.strKBTCD, gstrSeisakuFee) || String.Equals(KBTItem.strKBTCD, gstrWebFee))
                                {
                                    //  中分類が制作/Web制作の場合の、フィー情報処理

                                    //  管理区分
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  品目名
                                    viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                    //  品目コード
                                    viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                    //  フィーコード
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                    //  ※プロジェクトフィーの総額計算
                                    lcurPrjFee = lcurPrjFee + hinmokuItem.curHaifugaku;
                                    //  Web制作/制作の出力フラグ
                                    blnWEBSSFlg = true;
                                }
                                else if (((String.Equals(KBTItem.strKBTCD, gstrTVFee))) || ((String.Equals(KBTItem.strKBTCD, gstrTVSpotFee))))
                                {
                                    //  中分類がテレビ番組/テレビスポットの場合の、フィー情報処理

                                    //  管理区分
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  フィーコード
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                }
                                else if (String.Equals(KBTItem.strKBTCD, gstrRTFee))
                                {
                                    //  総額 
                                    viewRow.cCSougaku = (hinmokuItem.curHaifugaku).ToString();
                                    //  品目名 
                                    viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                    //  品目コード 
                                    viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                    //  管理区分 
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  備考 
                                    viewRow.cCBiko = hinmokuItem.strBiko;
                                    //  フィーコード 
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                }

                                //  ※総額計算※ 
                                lcurSougaku = lcurSougaku + hinmokuItem.curHaifugaku;
                            }

                            // 明細行の追加 
                            view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                            viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
                        }

                        if (!String.Equals(KBTItem.strKBTCD, gstrRTFee))
                        {
                            // 個別レコード部分に品目別の合計を出力するイレギュラーな処理のためこの場所に記載する
                            itemTotalRow.cCSougaku = (lcurSougaku).ToString();
                        }

                        //  ※小計計算※ 
                        lcurSyoukei = lcurSyoukei + lcurSougaku;

                        //  総額初期化 
                        lcurSougaku = 0;
                    }

                    if ((lcurPrjFee != 0) && (blnWEBSSFlg == true))
                    {
                        //  ※制作/Web制作のプロジェクトフィー計
                        viewRow.cCBtkbtnm = "プロジェクトフィー計";
                        viewRow.cCSougaku = (lcurPrjFee).ToString();
                        viewRow.cCFee = gstrPJFee;

                        // 明細行の追加 
                        view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                        viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
                    }

                    //  小計 
                    viewRow.cCBtcnm = gstrOutSyoukei;
                    viewRow.cCSougaku = (lcurSyoukei).ToString();

                    //  小計行の追加 
                    view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                    viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                    //  小計(消費税込み)
                    viewRow.cCBtcnm = gstrOutZeikomi;
                    viewRow.cCSougaku = (lcurSyoukei + (lcurSyoukei * _taxRate)).ToString();

                    //  小計(消費税込み)行の追加
                    view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                    viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                    //  ※合計計算※
                    lcurGoukei = lcurGoukei + lcurSyoukei;

                    //  小計初期化
                    lcurSyoukei = 0;
                }

                //  合計 
                viewRow.cCBtccd = gstrOutGoukei;
                viewRow.cCSougaku = (lcurGoukei).ToString();

                //  合計行の追加 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                //  合計(消費税込み) 
                viewRow.cCBtccd = gstrOutZeikomi;
                viewRow.cCSougaku = (lcurGoukei + (lcurGoukei * _taxRate)).ToString();

                //  合計(消費税込み)行の追加 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                lcurGoukei = 0;

                // 空白行の追加 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
            }

            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet1.DataSource = view.ReportByMiddleClassificationView;

            statusStrip1.Items["tslval1"].Text = work.getHierarchicalCount().ToString() + "件";
        }

        /// <summary>
        /// 請求明細（中分類別）帳票出力用データの編集 
        /// </summary>
        /// <param name="work">請求明細（中分類別）集計済みワーク</param>
        private void putReportByMiddleClassificationMacroData(MiddleClassificationWorkData work)
        {
            // 帳票出力用データスキーマの生成 
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            foreach (MiddleClassificationWorkSiteData siteItem in work.siteArray)
            {
                foreach (MiddleClassificationWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    foreach (MiddleClassificationWorkKBTData KBTItem in CYBNItem.KBTArray)
                    {
                        foreach (MiddleClassificationWorkHinmokuData hinmokuItem in KBTItem.hinmokuArray)
                        {
                            ReportDSTkdBilling.ReportByMiddleClassificationMacroRow macroRow = macro.ReportByMiddleClassificationMacro.NewReportByMiddleClassificationMacroRow();

                            // サイト別データ
                            macroRow.strDairitenCD = siteItem.strDairitenCD;                        // 代理店コード
                            macroRow.strYM = siteItem.strYM;			                            // 実施年月
                            macroRow.strSite = siteItem.strSite;			                        // サイト

                            // 中分類別データ
                            macroRow.strCYBNCD = CYBNItem.strCYBNCD;			                    // 媒体中分類コード
                            macroRow.strCYBNNM = CYBNItem.strCYBNNM;			                    // 媒体中分類名

                            // 個別媒体別データ
                            macroRow.strKBTNM = KBTItem.strKBTNM;			                        // 個別媒体名
                            macroRow.strKBTCD = KBTItem.strKBTCD;			                        // 個別媒体コード
                            macroRow.strRenNo = KBTItem.strRenNo;			                        // 一連番号

                            // 品目別データ
                            macroRow.strHinmokuNM = hinmokuItem.strHinmokuNM;		            	// 品目名
                            macroRow.strHinmokuCD = hinmokuItem.strHinmokuCD;		            	// 品目コード
                            macroRow.strKanriKBN = hinmokuItem.strKanriKBN;		            	    // 管理区分
                            macroRow.intHaibunHiritsu = hinmokuItem.intHaibunHiritsu.ToString();    // 配分比率
                            macroRow.curHaifugaku = hinmokuItem.curHaifugaku.ToString();			// 配付額
                            macroRow.strSite = hinmokuItem.strSite;			                        // サイト
                            macroRow.strBiko = hinmokuItem.strBiko;			                        // 備考

                            // サイト別キー件数
                            if (work.siteArray.IndexOf(siteItem) == 0)
                            {
                                macroRow.keyCountSite = work.siteArray.Count.ToString();
                            }

                            // 中分類別キー件数
                            if (siteItem.CYBNArray.IndexOf(CYBNItem) == 0)
                            {
                                macroRow.keyCountCYBN = siteItem.CYBNArray.Count.ToString();
                            }

                            // 個別媒体別キー件数
                            if (CYBNItem.KBTArray.IndexOf(KBTItem) == 0)
                            {
                                macroRow.keyCountKBT = CYBNItem.KBTArray.Count.ToString();
                            }

                            // 品目別キー件数
                            if (KBTItem.hinmokuArray.IndexOf(hinmokuItem) == 0)
                            {
                                macroRow.keyCountHinmoku = KBTItem.hinmokuArray.Count.ToString();
                            }

                            macro.ReportByMiddleClassificationMacro.AddReportByMiddleClassificationMacroRow(macroRow);
                        }
                    }
                }
            }

            putDataSet = macro;
            putTaxRate = _taxRate.ToString();
            btnXls.Enabled = true;
        }

        /// <summary>
        /// 請求明細（品目別）データの読み込み処理 
        /// </summary>
        private void loadReportByItemData()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 年月の取得 
            string strYYYYMM = txtYm.Value;

            // プロセスコントローラの取得 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // 本データの取得 
            FindReportTkdBillingByItemByCondServiceResult resultMain = controller.FindReportTkdBillingByItemByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_120_OR_30.ToString()
                                                                                      );

            // その他データの取得 
            FindReportTkdBillingByItemByCondServiceResult resultOther = controller.FindReportTkdBillingByItemByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_OTHER.ToString()
                                                                                      );

            // データが存在しなければ終了 
            if ((resultMain.dsReportTkdBillingDataSet.ReportByItemResult.Rows.Count == 0) && (resultOther.dsReportTkdBillingDataSet.ReportByItemResult.Rows.Count == 0))
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet2.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0件";

                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);

                return;
            }

            // ワーク用データの生成 
            ItemWorkData work = new ItemWorkData();

            // 本データのマッピング 
            putReportByItemWorkData(resultMain, work, SITE_TYPE_120_OR_30);

            // その他データのマッピング 
            putReportByItemWorkData(resultOther, work, SITE_TYPE_OTHER);

            // 画面への出力 
            putReportByItemView(work);

            // 帳票出力用データの編集 
            putReportByItemMacroData(work);

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// 請求明細（品目別）集計用データの編集 
        /// </summary>
        /// <param name="resultMain"></param>
        /// <param name="work">請求明細（品目別）集計対象ワーク</param>
        /// <param name="siteType">集計するサイトのパターン</param>
        private void putReportByItemWorkData(FindReportTkdBillingByItemByCondServiceResult resultMain, ItemWorkData work, int siteType)
        {
            String strWorkSite;     // サイト退避 
            Boolean blnKYTFlg;      // 共通情報フラグ 
            String strWorkCYBNCD;   // 中分類コード退避 

            // カウンタ初期化 
            strWorkSite = null;
            blnKYTFlg = false;
            strWorkCYBNCD = null;

            ItemWorkSiteData siteItem = null;
            ItemWorkCYBNData CYBNItem = null;
            ItemWorkHinmokuData hinmokuItem = null;

            ReportDSTkdBilling.ReportByItemResultRow[] resultRows = (ReportDSTkdBilling.ReportByItemResultRow[])resultMain.dsReportTkdBillingDataSet.ReportByItemResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportByItemResultRow resultRow in resultRows)
            {
                // サイトデータ構造体初期化& データの格納 
                if (siteType == SITE_TYPE_120_OR_30)
                {
                    // サイトが120か30の場合 
                    if (!String.Equals(strWorkSite, resultRow.SITE.Trim()))
                    {
                        // 出力中分類データ構造体初期化& データの格納 
                        siteItem = new ItemWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // サイト 
                        siteItem.strSite = "";

                        if (resultRow.IsSITENull() == false)
                        {
                            siteItem.strSite = resultRow.SITE.Trim();
                        }

                        // 代理店コード 
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // 実施年月 
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        strWorkSite = siteItem.strSite;
                        strWorkCYBNCD = null;
                    }
                }
                else
                {
                    // サイトが120でも30でもない場合
                    if (blnKYTFlg == false)
                    {
                        // 出力中分類データ構造体初期化& データの格納
                        siteItem = new ItemWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // サイト
                        siteItem.strSite = "その他";

                        // 代理店コード
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // 実施年月
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        blnKYTFlg = true;
                        strWorkCYBNCD = null;
                    }
                }

                // 中分類詳細データ構造体初期化& データの格納
                if (!String.Equals(strWorkCYBNCD, resultRow.strCYBNCD.Trim()))
                {
                    CYBNItem = new ItemWorkCYBNData();
                    siteItem.CYBNArray.Add(CYBNItem);

                    // 媒体中分類コード
                    CYBNItem.strCYBNCD = "";

                    if (resultRow.IsstrCYBNCDNull() == false)
                    {
                        CYBNItem.strCYBNCD = resultRow.strCYBNCD.Trim();
                    }

                    // 媒体中分類名
                    CYBNItem.strCYBNNM = "";

                    if (resultRow.IsstrCYBNNMNull() == false)
                    {
                        CYBNItem.strCYBNNM = resultRow.strCYBNNM.Trim();
                    }

                    strWorkCYBNCD = CYBNItem.strCYBNCD;
                }

                // 品目データ構造体初期化& データの格納
                hinmokuItem = new ItemWorkHinmokuData();
                CYBNItem.hinmokuArray.Add(hinmokuItem);

                // 品目名
                hinmokuItem.strHinmokuNM = "";

                if (resultRow.IsstrHinmokuNMNull() == false)
                {
                    hinmokuItem.strHinmokuNM = resultRow.strHinmokuNM.Trim();
                }

                // 品目コード
                hinmokuItem.strHinmokuCD = "";

                if (resultRow.IsstrHinmokuCDNull() == false)
                {
                    hinmokuItem.strHinmokuCD = resultRow.strHinmokuCD.Trim();
                }

                // 管理区分
                hinmokuItem.strKanriKBN = "";

                if (resultRow.IsKNRKBNNull() == false)
                {
                    hinmokuItem.strKanriKBN = resultRow.KNRKBN.Trim();
                }

                // 金額
                hinmokuItem.curKingaku = 0.0m;

                if (resultRow.IscurKingakuNull() == false)
                {
                    hinmokuItem.curKingaku = Decimal.Parse(resultRow.curKingaku.Trim());
                }

                // 税込み金額
                hinmokuItem.curZeikomi = 0.0m;

                if (resultRow.IscurKingakuNull() == false)
                {
                    hinmokuItem.curZeikomi = Decimal.Parse(resultRow.curKingaku.Trim()) + ( Decimal.Parse(resultRow.curKingaku.Trim()) * _taxRate );
                }

                // フィーCD
                hinmokuItem.strFEECD = "";

                if (resultRow.IsFEECDNull() == false)
                {
                    hinmokuItem.strFEECD = resultRow.FEECD.Trim();
                }
            }
        }

        /// <summary>
        /// 請求明細（品目別）画面出力用データの編集 
        /// </summary>
        /// <param name="work">請求明細（品目別）集計済みワーク</param>
        private void putReportByItemView(ItemWorkData work )
        {
            // 画面出力用データスキーマの生成 
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            Decimal cruZei;     // 消費税額 
            Decimal cruGoukei;  // 合計 

            cruGoukei = 0;
            cruZei = 0;

            // 個別行用 
            ReportDSTkdBilling.ReportByItemViewRow viewRow = view.ReportByItemView.NewReportByItemViewRow();

            foreach (ItemWorkSiteData siteItem in work.siteArray)
            {
                // サイト 
                viewRow.cHHSite = siteItem.strSite;

                // 代理店名 
                viewRow.cHDairinm = "電通";

                // 代理店コード
                viewRow.cHDairicd = siteItem.strDairitenCD;

                // 実施年月 
                viewRow.cHym = siteItem.strYM;

                foreach (ItemWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    // 媒体中分類コード 
                    viewRow.cHBtccd = CYBNItem.strCYBNCD;

                    // 媒体中分類名 
                    viewRow.cHBtcnm = CYBNItem.strCYBNNM;

                    foreach (ItemWorkHinmokuData hinmokuItem in CYBNItem.hinmokuArray)
                    {
                        // 品目名 
                        viewRow.cHHinmoku = hinmokuItem.strHinmokuNM;

                        // 品目コード 
                        if (!String.Equals(hinmokuItem.strHinmokuCD, ""))
                        {
                            viewRow.cHHinmokucd = hinmokuItem.strHinmokuCD;
                        }

                        // 管理区分
                        viewRow.cHKanricbn = hinmokuItem.strKanriKBN;

                        // 金額
                        viewRow.cHKingaku = (hinmokuItem.curKingaku).ToString();

                        // 合計金額の取得
                        cruGoukei = cruGoukei + hinmokuItem.curKingaku;

                        // 金額(消費税込み)
                        viewRow.cHZeikomi = (hinmokuItem.curZeikomi).ToString();

                        // フィーコード退避列
                        viewRow.cHFeeCd = hinmokuItem.strFEECD;

                        // 行のカウントアップ 
                        view.ReportByItemView.AddReportByItemViewRow(viewRow);
                        viewRow = view.ReportByItemView.NewReportByItemViewRow();
                    }
                }

                // 消費税額の表示
                cruZei = cruGoukei * _taxRate;
                viewRow.cHHinmoku = gstrOutSyohizei;
                viewRow.cHKingaku = (cruZei).ToString();

                // 行のカウントアップ
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();

                // 合計の表示
                cruGoukei = cruZei + cruGoukei;
                viewRow.cHHinmoku = gstrOutGoukei;
                viewRow.cHKingaku = (cruGoukei).ToString();

                // 行のカウントアップ
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();

                cruZei = 0;
                cruGoukei = 0;

                // 空白行の追加 
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();
            }

            dgvMain_Sheet2.RowCount = 0;
            dgvMain_Sheet2.DataSource = view.ReportByItemView;
            statusStrip1.Items["tslval1"].Text = work.getHierarchicalCount().ToString() + "件";
        }

        /// <summary>
        /// 請求明細（品目別）帳票出力用データの編集
        /// </summary>
        /// <param name="work">請求明細（品目別）集計済みワーク</param>
        private void putReportByItemMacroData(ItemWorkData work)
        {
            // 帳票出力用データスキーマの生成
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            foreach (ItemWorkSiteData siteItem in work.siteArray)
            {
                foreach (ItemWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    foreach (ItemWorkHinmokuData hinmokuItem in CYBNItem.hinmokuArray)
                    {
                        ReportDSTkdBilling.ReportByItemMacroRow macroRow = macro.ReportByItemMacro.NewReportByItemMacroRow();

                        // サイト別データ
                        macroRow.strDairitenCD = siteItem.strDairitenCD;            // 代理店コード
                        macroRow.strYM = siteItem.strYM;                            // 実施年月
                        macroRow.strSite = siteItem.strSite;                        // サイト

                        // 中分類別データ
                        macroRow.strCYBNCD = CYBNItem.strCYBNCD;                    // 媒体中分類コード
                        macroRow.strCYBNNM = CYBNItem.strCYBNNM;                    // 媒体中分類名

                        // 品目別データ
                        macroRow.strHinmokuNM = hinmokuItem.strHinmokuNM;           // 品目名
                        macroRow.strHinmokuCD = hinmokuItem.strHinmokuCD;           // 品目コード
                        macroRow.strKanriKBN = hinmokuItem.strKanriKBN;             // 管理区分
                        macroRow.curKingaku = hinmokuItem.curKingaku.ToString();    // 金額
                        macroRow.curZeikomi = hinmokuItem.curZeikomi.ToString();    // 税込み金額
                        macroRow.strFEECD = hinmokuItem.strFEECD;

                        // サイト別キー件数
                        if (work.siteArray.IndexOf(siteItem) == 0)
                        {
                            macroRow.keyCountSite = work.siteArray.Count.ToString();
                        }

                        // 中分類別キー件数
                        if (siteItem.CYBNArray.IndexOf(CYBNItem) == 0)
                        {
                            macroRow.keyCountCYBN = siteItem.CYBNArray.Count.ToString();
                        }

                        // 品目別キー件数
                        if (CYBNItem.hinmokuArray.IndexOf(hinmokuItem) == 0)
                        {
                            macroRow.keyCountHinmoku = CYBNItem.hinmokuArray.Count.ToString();
                        }

                        macro.ReportByItemMacro.AddReportByItemMacroRow(macroRow);
                    }
                }
            }

            putDataSet = macro;
            putTaxRate = _taxRate.ToString();
            btnXls.Enabled = true;
        }

        /// <summary>
        /// 請求明細（企画費）データの読み込み処理 
        /// </summary>
        private void loadReportForPlanningCostData()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 年月の取得 
            string strYYYYMM = txtYm.Value;

            // プロセスコントローラの取得 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // データの取得 
            FindReportTkdBillingForPlanningCostByCondServiceResult result = controller.FindReportTkdBillingForPlanningCostByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM
                                                                                      );
            // データが存在しなければ終了 
            if (result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Rows.Count == 0)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet3.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0件";

                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);

                return;
            }

            // 画面への出力 
            putReportForPlanningCostView(result);

            // 帳票用データセットへの出力 
            putReportForPlanningCostMacroData(result);

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// 請求明細（企画費）画面出力用データの編集 
        /// </summary>
        /// <param name="result">SQL取得結果</param>
        private void putReportForPlanningCostView(FindReportTkdBillingForPlanningCostByCondServiceResult result)
        {
            // 画面出力用データスキーマの生成
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            String lstrSvNo;        // 前行の内容を保存 
            String lstrSvTekiyo;    // 前行の内容を保存 
            Decimal lcurKingaku;
            Boolean lbolFnd;
            Decimal lcurTotal;
            Boolean putState;
            List<mtypHinmoku> usrHinmokuArray = new List<mtypHinmoku>();
            lstrSvNo = null;
            lstrSvTekiyo = null;
            lcurTotal = 0;
            putState = false;

            ReportDSTkdBilling.ReportForPlanningCostViewRow viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
            ReportDSTkdBilling.ReportForPlanningCostResultRow[] resultRows = (ReportDSTkdBilling.ReportForPlanningCostResultRow[])result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportForPlanningCostResultRow resultRow in resultRows)
            {
                // 入力された検索条件の下に 
                // SQLを発行し、検索結果をSpreadに貼りつける 
                //スプレッドをクリア 
                if (putState == false)
                {
                    usrHinmokuArray.Clear();
                    mtypHinmoku usrHinmoku = new mtypHinmoku();
                    usrHinmokuArray.Add(usrHinmoku);

                    //キーセーブ
                    usrHinmoku.Cd = resultRow.SCD;
                    usrHinmoku.Name = resultRow.SNM;
                }
                else
                {
                    if (!String.Equals(resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO, lstrSvNo))
                    {
                        //明細最終行にフラグセット 
                        viewRow.cKKLineFlg = "1";

                        //品目毎合計 
                        {
                            foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                            {
                                viewRow.cKKTekiyo = usrHinmoku.Name;
                                viewRow.cKKSuryo = "合計";
                                viewRow.cKKKingaku = (usrHinmoku.Kingaku).ToString();

                                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
                            }
                        }

                        {
                            //キャンペーン最終行にフラグセット 
                            viewRow.cKKLineFlg = "2";

                            usrHinmokuArray.Clear();
                            mtypHinmoku usrHinmoku = new mtypHinmoku();
                            usrHinmokuArray.Add(usrHinmoku);
                            usrHinmoku.Cd = resultRow.SCD;
                            usrHinmoku.Name = resultRow.SNM;
                        }
                    }
                }

                //品目名 
                viewRow.cKKHinmoku = resultRow.SNM;

                //ツール内容 
                //数量 
                if ((!String.Equals(resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO, lstrSvNo)) || (!String.Equals(resultRow.TEKIYO, lstrSvTekiyo)))
                {
                    viewRow.cKKTekiyo = resultRow.TEKIYO;
                    viewRow.cKKSuryo = "１式";
                }
                else
                {
                    viewRow.cKKTekiyo = "　〃";
                }

                // 本体額 
                viewRow.cKKHongaku = (resultRow.SEIGAK).ToString();

                // 消費税額 
                viewRow.cKKZeigaku = (Decimal.Floor(Decimal.Parse(resultRow.SEIGAK) * (Decimal.Parse(resultRow.SZEIRITU) / 100m))).ToString();

                // 請求金額 
                lcurKingaku = Decimal.Floor(Decimal.Parse(resultRow.SEIGAK) * ((Decimal.Parse(resultRow.SZEIRITU) / 100m) + 1));

                // 合計金額の加算 
                lbolFnd = false;

                foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                {
                    if (String.Equals(usrHinmoku.Cd, resultRow.SCD))
                    {
                        usrHinmoku.Kingaku = usrHinmoku.Kingaku + lcurKingaku;
                        lbolFnd = true;
                        break;
                    }
                }

                if (lbolFnd == false)
                {
                    mtypHinmoku usrHinmoku = new mtypHinmoku();
                    usrHinmokuArray.Add(usrHinmoku);

                    usrHinmoku.Cd = resultRow.SCD;
                    usrHinmoku.Name = resultRow.SNM;
                    usrHinmoku.Kingaku = lcurKingaku;
                }

                viewRow.cKKKingaku = (lcurKingaku).ToString();

                lcurTotal = lcurTotal + lcurKingaku;

                //区分 
                viewRow.cKKKbn = resultRow.KBN;

                //キーセーブ 
                lstrSvNo = resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO;

                lstrSvTekiyo = "";

                if (resultRow.IsTEKIYONull() == false)
                {
                    lstrSvTekiyo = resultRow.TEKIYO;
                }

                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();

                putState = true;
            }

            if (putState == true)
            {
                //明細最終行にフラグセット 
                viewRow.cKKLineFlg = "1";

                //品目毎合計 
                foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                {
                    viewRow.cKKTekiyo = usrHinmoku.Name;
                    viewRow.cKKSuryo = "合計";
                    viewRow.cKKKingaku = (usrHinmoku.Kingaku).ToString();

                    view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                    viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
                }

                //キャンペーン最終行にフラグセット 
                viewRow.cKKLineFlg = "2";

                //総合計 
                viewRow.cKKTekiyo = "総合計";
                viewRow.cKKKingaku = (lcurTotal).ToString();
                viewRow.cKKLineFlg = "9"; //総合計行にフラグセット 

                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();

                // 空白行の追加 
                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
            }

            dgvMain_Sheet3.RowCount = 0;

            dgvMain_Sheet3.DataSource = view.ReportForPlanningCostView;

            statusStrip1.Items["tslval1"].Text = result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Rows.Count.ToString() + "件";
        }

        /// <summary>
        /// 請求明細（企画費）帳票出力用データの編集 
        /// </summary>
        /// <param name="result">SQL取得結果</param>
        private void putReportForPlanningCostMacroData(FindReportTkdBillingForPlanningCostByCondServiceResult result)
        {
            // 帳票出力用データスキーマの生成 
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            ReportDSTkdBilling.ReportForPlanningCostResultRow[] resultRows = (ReportDSTkdBilling.ReportForPlanningCostResultRow[])result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportForPlanningCostResultRow resultRow in resultRows)
            {
                ReportDSTkdBilling.ReportForPlanningCostMacroRow macroRow = macro.ReportForPlanningCostMacro.NewReportForPlanningCostMacroRow();

                macroRow.JYUTNO = resultRow.JYUTNO;
                macroRow.JYMEINO = resultRow.JYMEINO;
                macroRow.URMEINO = resultRow.URMEINO;
                macroRow.KNGK1 = resultRow.KNGK1;
                macroRow.SCD = resultRow.SCD;
                macroRow.SNM = resultRow.SNM;
                macroRow.TEKIYO = resultRow.TEKIYO;
                macroRow.KBN = resultRow.KBN;
                macroRow.SEIGAK = resultRow.SEIGAK;
                macroRow.SZEIRITU = resultRow.SZEIRITU;

                macro.ReportForPlanningCostMacro.AddReportForPlanningCostMacroRow(macroRow);
            }

            putDataSet = macro;
            putEGCD = _naviParam.strEgcd;
            btnXls.Enabled = true;
        }

        /// <summary>
        /// 請求明細（中分類別）帳票を出力する 
        /// </summary>
        private void putReportByMiddleClassificationData()
        {
            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            // 日付とか 
            DateTime now = DateTime.Now;

            // はじめのファイル名を指定する 
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportByMiddleClassificationFilename + ".xlsx";
            sfd.FileName = strReportByMiddleClassificationFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = strReportDefaultPath;

            // [ファイルの種類]に表示される選択肢を指定する 
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";

            // [ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;

            // タイトルを設定する 
            sfd.Title = "保存先のファイルを設定して下さい。";

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel開始処理.
                    // リソースからExcelファイルを作成(テンプレートとマクロ).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportByMiddleClassification_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportByMiddleClassification_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("テンプレートExcelファイルがありません。");
                    }

                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("マクロExcelファイルがありません。");
                    }

                    // データセットXML出力 
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // パラメータXML作成、出力 
                    // 変数の宣言
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // データセットにテーブルを追加する 
                    // PRODUCTSというテーブルを作成します 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("taxRate", Type.GetType("System.String"));

                    //テーブルにデータを追加する
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["taxRate"] = putTaxRate;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //エクセル起動.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME);

                    //削除用に保持（戻るボタン押下時に削除する為）
                    _strReportByMiddleClassificationMacroPath = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME;

                    // オペレーションログの出力 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION);
                
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        /// <summary>
        /// 請求明細（品目別）帳票を出力する
        /// </summary>
        private void putReportByItemData()
        {
            // SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            // 日付とか
            DateTime now = DateTime.Now;

            // はじめのファイル名を指定する
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportByItemFilename + ".xlsx";
            sfd.FileName = strReportByItemFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = strReportDefaultPath;

            // [ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";

            // [ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 0;

            // タイトルを設定する
            sfd.Title = "保存先のファイルを設定して下さい。";

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_BY_ITEM_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel開始処理.
                    // リソースからExcelファイルを作成(テンプレートとマクロ).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportByItem_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportByItem_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("テンプレートExcelファイルがありません。");
                    }
                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("マクロExcelファイルがありません。");
                    }

                    // データセットXML出力
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // パラメータXML作成、出力

                    // 変数の宣言
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // データセットにテーブルを追加する 
                    // PRODUCTSというテーブルを作成します 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("taxRate", Type.GetType("System.String"));

                    //テーブルにデータを追加する 
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["taxRate"] = putTaxRate;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //エクセル起動.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME);

                    //削除用に保持（戻るボタン押下時に削除する為）
                    _strReportByItemMacroPath = workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME;

                    // オペレーションログの出力 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_ITEM, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_ITEM);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        /// <summary>
        /// 請求明細（企画費）帳票を出力する 
        /// </summary>
        private void putReportForPlanningCostData()
        {
            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            // 日付とか 
            DateTime now = DateTime.Now;

            // はじめのファイル名を指定する 
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportForPlanningCostFilename + ".xlsx";
            sfd.FileName = strReportForPlanningCostFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = strReportDefaultPath;

            // [ファイルの種類]に表示される選択肢を指定する 
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";

            // [ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;

            // タイトルを設定する 
            sfd.Title = "保存先のファイルを設定して下さい。";

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_FOR_PLANNING_COST_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel開始処理.
                    // リソースからExcelファイルを作成(テンプレートとマクロ).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportForPlanningCost_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportForPlanningCost_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("テンプレートExcelファイルがありません。");
                    }

                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("マクロExcelファイルがありません。");
                    }

                    // データセットXML出力 
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // パラメータXML作成、出力 
                    // 変数の宣言 
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // データセットにテーブルを追加する 
                    // PRODUCTSというテーブルを作成します 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("YYYYMM", Type.GetType("System.String"));
                    dtTable.Columns.Add("EGCD", Type.GetType("System.String"));

                    //テーブルにデータを追加する 
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["YYYYMM"] = txtYm.Value;
                    dtRow["EGCD"] = putEGCD;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //エクセル起動.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME);

                    //削除用に保持（戻るボタン押下時に削除する為）
                    _strReportForPlanningCostMacroPath = workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME;

                    // オペレーションログの出力 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_PLANNINGCOST, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_SUB_PLANNINGCOST);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        #endregion メソッド
    }
}


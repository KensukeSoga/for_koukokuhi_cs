using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Lion.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FindLionTVSpot : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "FindTVSP";

        private FindLionTVSpotNaviParameter _naviParam = null;

        private DetailDSLion _view = new DetailDSLion();

        #region スプレッドインデックス番号

        private const int COLUMN_INDEX_TIKU = 3;

        private const int COLUMN_INDEX_KYOKUCD = 4;

        private const int COLUMN_INDEX_KYOKUNAME = 5;

        private const int COLUMN_INDEX_K_HKGAK_HAT = 6;

        private const int COLUMN_INDEX_COUNT = 7;

        private const int COLUMN_INDEX_CM_SEC = 8;

        private const int COLUMN_INDEX_TOTAL_CM_SEC = 9;

        private const int COLUMN_INDEX_CHECK = 10;

        #endregion スプレッドインデックス番号

        #region 子スプレッドインデックス番号

        private const int CHILD_COLUMN_INDEX_SHK_NO = 0;

        private const int CHILD_COLUMN_INDEX_TIKU = 1;

        private const int CHILD_COLUMN_INDEX_KYK_CD = 2;

        private const int CHILD_COLUMN_INDEX_KYKAN_NO = 3;
        
        private const int CHILD_COLUMN_INDEX_ONA_DT = 4;
        
        private const int CHILD_COLUMN_INDEX_YOUBI = 5;
        
        private const int CHILD_COLUMN_INDEX_KYKAN_STM = 6;
        
        private const int CHILD_COLUMN_INDEX_KYKAN_ETM = 7;
        
        private const int CHILD_COLUMN_INDEX_CM_SEC = 8;

        #endregion 子スプレッドインデックス番号

        //

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FindLionTVSpot()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strYMD"></param>
        /// <returns></returns>
        protected String calculateDayOfWeek( String strYMD )
        {
            String retval = null;

            DateTime dt = KKHUtility.StringCnvDateTime( strYMD );

            if( dt.DayOfWeek == DayOfWeek.Monday )
            {
                retval = "月";
            }
            else if( dt.DayOfWeek == DayOfWeek.Tuesday )
            {
                retval = "火";
            }
            else if( dt.DayOfWeek == DayOfWeek.Wednesday )
            {
                retval = "水";
            }
            else if( dt.DayOfWeek == DayOfWeek.Thursday )
            {
                retval = "木";
            }
            else if( dt.DayOfWeek == DayOfWeek.Friday )
            {
                retval = "金";
            }
            else if( dt.DayOfWeek == DayOfWeek.Saturday )
            {
                retval = "土";
            }
            else if( dt.DayOfWeek == DayOfWeek.Sunday )
            {
                retval = "日";
            }

            return retval;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindLionTVSpot_Load(object sender, EventArgs e)
        {
            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void FindLionTVSpot_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter != null)
            {
                if (arg.NaviParameter is FindLionTVSpotNaviParameter)
                {
                    _naviParam = (FindLionTVSpotNaviParameter)arg.NaviParameter;

                    textYYYYMM.Text = _naviParam.StrYM;

                    textContractName.Text = null;

                    textPeriodFrom.Text = null;

                    textPeriodTo.Text = null;

                    btnDecision.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの子ビューのデザイン初期化 
        /// </summary>
        private void InitDesignForSpdJyutyuListChild()
        {
            for (int i = 0; i < dgvMain1_Sheet1.RowCount; i++)
            {
                FarPoint.Win.Spread.SheetView sheet = dgvMain1_Sheet1.GetChildView(i, 0);

                sheet.ActiveSkin = dgvMain1_Sheet1.ActiveSkin;
                sheet.DefaultStyle.BackColor = dgvMain1_Sheet1.DefaultStyle.BackColor;

                sheet.Columns[ CHILD_COLUMN_INDEX_SHK_NO ].Visible = false;
                sheet.Columns[ CHILD_COLUMN_INDEX_SHK_NO ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_SHK_NO ].VerticalAlignment = CellVerticalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_TIKU ].Label = "地区";
                sheet.Columns[ CHILD_COLUMN_INDEX_TIKU ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_TIKU ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_TIKU ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_KYK_CD ].Label = "放送局";
                sheet.Columns[ CHILD_COLUMN_INDEX_KYK_CD ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYK_CD ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYK_CD ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_NO ].Visible = false;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_NO ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_NO ].VerticalAlignment = CellVerticalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_ONA_DT ].Label = "放送日";
                sheet.Columns[ CHILD_COLUMN_INDEX_ONA_DT ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_ONA_DT ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_ONA_DT ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_YOUBI ].Label = "曜日";
                sheet.Columns[ CHILD_COLUMN_INDEX_YOUBI ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_YOUBI ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_YOUBI ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_STM ].Label = "開始時間";
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_STM ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_STM ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_STM ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_ETM ].Label = "終了時間";
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_ETM ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_ETM ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_KYKAN_ETM ].HorizontalAlignment = CellHorizontalAlignment.Center;

                sheet.Columns[ CHILD_COLUMN_INDEX_CM_SEC ].Label = "秒数";
                sheet.Columns[ CHILD_COLUMN_INDEX_CM_SEC ].Locked = true;
                sheet.Columns[ CHILD_COLUMN_INDEX_CM_SEC ].VerticalAlignment = CellVerticalAlignment.Center;
                sheet.Columns[ CHILD_COLUMN_INDEX_CM_SEC ].HorizontalAlignment = CellHorizontalAlignment.Right;
            }
        }

        /// <summary>
        /// データ読み込みボタンが押された時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String strJobNo = KKHUtility.RemoveProhibitionChar( textJobNo.Text );

            String strYYYYMM = textYYYYMM.Text.Replace( "/", "" );

            // プロセスコントローラの取得
            DetailLionProcessController controller = DetailLionProcessController.GetInstance();

            FindLionTVSpotServiceResult result = null;

            result = controller.FindLionTVSpotService(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo,
                                                strJobNo,
                                                strYYYYMM
                                                );

            // データが存在しなければ終了
            if( result.dsDetailLion.KkhTVSpotResult.Rows.Count == 0 )
            {
                textContractName.Text = null;

                textPeriodFrom.Text = null;

                textPeriodTo.Text = null;

                btnDecision.Enabled = false;

                dgvMain1_Sheet1.RowCount = 0;

                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "TVSpot検索", MessageBoxButtons.OK);

                return;
            }

            // 帳票出力用データスキーマの生成
            DetailDSLion view = new DetailDSLion();

            DetailDSLion.KkhTVSpotResultRow[] resultRows = (DetailDSLion.KkhTVSpotResultRow[])result.dsDetailLion.KkhTVSpotResult.Select("", "");

            DetailDSLion.KkhTVSpotDetailListViewRow viewRow = view.KkhTVSpotDetailListView.NewKkhTVSpotDetailListViewRow();

            DetailDSLion.KkhTVSpotDetailListChildViewRow childViewRow = view.KkhTVSpotDetailListChildView.NewKkhTVSpotDetailListChildViewRow();

            DetailDSLion.KkhTVSpotMaterialListViewRow materialViewRow = view.KkhTVSpotMaterialListView.NewKkhTVSpotMaterialListViewRow();

            bool initState = false;

            String strCONTRA_NAM = null;
            String strHK_SDT = null;
            String strHK_EDT = null;
            String keySHK_NO = null;
            String keyKYK_CD = null;
            String keyKYKAN_NO = null;
            String keyTIKU = null;
            String keyKYOKUCD = null;
            String keyKYOKUNAME = null;
            Decimal keyK_HKGAK_HAT = 0.0m;
            Decimal keyCOUNT = 0.0m;
            Decimal keyCM_SEC = 0.0m;
            Decimal keyTOTAL_CM_SEC = 0.0m;

            String materialKeySHK_NO = null;
            String materialKeyKYK_CD = null;
            String materialKeyKYKAN_NO = null;
            String materialKeyAC_CD = null;
            //String materialKeySZIKYTU_KB = null;
            String materialKeySZIKYTU_CD = null;
            String materialKeyK_SZI_RYKG = null;
            Decimal materialKeyCM_SEC = 0.0m;

            foreach (DetailDSLion.KkhTVSpotResultRow resultRow in resultRows)
            {
                if( initState == false )
                {
                    strCONTRA_NAM = resultRow.CONTRA_NAM;
                    strHK_SDT = resultRow.HK_SDT;
                    strHK_EDT = resultRow.HK_EDT;
                    keySHK_NO = resultRow.SHK_NO;
                    keyKYK_CD = resultRow.KYK_CD;
                    keyKYKAN_NO = resultRow.KYKAN_NO;
                    keyTIKU = resultRow.IsTIKUNull() ? "" : resultRow.TIKU;
                    keyKYOKUCD = resultRow.IsKYOKUCDNull() ? "" : resultRow.KYOKUCD;
                    keyKYOKUNAME = resultRow.IsKYOKUNAMENull() ? "" : resultRow.KYOKUNAME;
                    keyK_HKGAK_HAT = KKHUtility.DecParse( resultRow.K_HKGAK_HAT );
                    keyCOUNT = 0.0m;
                    keyCM_SEC = KKHUtility.DecParse( resultRow.CM_SEC );
                    keyTOTAL_CM_SEC = 0.0m;

                    //

                    materialKeySHK_NO = resultRow.SHK_NO;
                    materialKeyKYK_CD = resultRow.KYK_CD;
                    materialKeyKYKAN_NO = resultRow.KYKAN_NO;
                    materialKeyAC_CD = resultRow.AC_CD;
                    //materialKeySZIKYTU_KB = resultRow.SZIKYTU_KB;
                    materialKeySZIKYTU_CD = resultRow.SZIKYTU_CD;
                    materialKeyK_SZI_RYKG = resultRow.K_SZI_RYKG;
                    materialKeyCM_SEC = 0.0m;

                    //

                    initState = true;
                }

                //

                childViewRow.SHK_NO = resultRow.SHK_NO;

                childViewRow.TIKU = resultRow.IsTIKUNull() ? "" : resultRow.TIKU;

                childViewRow.KYK_CD = resultRow.KYK_CD;

                childViewRow.KYKAN_NO = resultRow.KYKAN_NO;

                childViewRow.ONA_DT = resultRow.ONA_DT;

                childViewRow.YOUBI = calculateDayOfWeek( resultRow.ONA_DT );

                childViewRow.KYKAN_STM = resultRow.KYKAN_STM;

                childViewRow.KYKAN_ETM = resultRow.KYKAN_ETM;

                childViewRow.CM_SEC = Decimal.ToInt64( KKHUtility.DecParse( resultRow.CM_SEC.ToString() ) ).ToString();

                view.KkhTVSpotDetailListChildView.AddKkhTVSpotDetailListChildViewRow( childViewRow );

                childViewRow = view.KkhTVSpotDetailListChildView.NewKkhTVSpotDetailListChildViewRow();

                //

                if( ! ( String.Equals( resultRow.SHK_NO, keySHK_NO ) && String.Equals( resultRow.KYK_CD, keyKYK_CD ) && String.Equals( resultRow.KYKAN_NO, keyKYKAN_NO ) ))
                {
                    viewRow.SHK_NO = keySHK_NO;

                    viewRow.KYK_CD = keyKYK_CD;

                    viewRow.KYKAN_NO = keyKYKAN_NO;

                    viewRow.TIKU = keyTIKU;

                    viewRow.KYOKUCD = keyKYOKUCD;

                    viewRow.KYOKUNAME = keyKYOKUNAME;

                    viewRow.K_HKGAK_HAT = keyK_HKGAK_HAT.ToString();

                    viewRow.COUNT = keyCOUNT.ToString();

                    viewRow.CM_SEC = keyCM_SEC.ToString();

                    viewRow.TOTAL_CM_SEC = keyTOTAL_CM_SEC.ToString();

                    if (!String.IsNullOrEmpty(viewRow.KYOKUCD))
                    {
                        viewRow.CHECK = true.ToString();
                    }
                    else
                    {
                        viewRow.CHECK = false.ToString();
                    }

                    view.KkhTVSpotDetailListView.AddKkhTVSpotDetailListViewRow( viewRow );

                    viewRow = view.KkhTVSpotDetailListView.NewKkhTVSpotDetailListViewRow();

                    //

                    keySHK_NO = resultRow.SHK_NO;
                    keyKYK_CD = resultRow.KYK_CD;
                    keyKYKAN_NO = resultRow.KYKAN_NO;
                    keyTIKU = resultRow.IsTIKUNull() ? "" : resultRow.TIKU;
                    keyKYOKUCD = resultRow.IsKYOKUCDNull() ? "" : resultRow.KYOKUCD;
                    keyKYOKUNAME = resultRow.IsKYOKUNAMENull() ? "" : resultRow.KYOKUNAME;
                    keyK_HKGAK_HAT = KKHUtility.DecParse( resultRow.K_HKGAK_HAT );
                    keyCOUNT = 0.0m;
                    keyCM_SEC = KKHUtility.DecParse( resultRow.CM_SEC );
                    keyTOTAL_CM_SEC = 0.0m;
                }

                keyCOUNT++;

                keyTOTAL_CM_SEC = keyTOTAL_CM_SEC + KKHUtility.DecParse( resultRow.CM_SEC );

                //

                //materialKeyCM_SEC = materialKeyCM_SEC + KKHUtility.DecParse( resultRow.CM_SEC );
                materialKeyCM_SEC = KKHUtility.DecParse(resultRow.CM_SEC);

                if
                ( !
                    (
                        String.Equals( resultRow.SHK_NO, materialKeySHK_NO ) &&
                        String.Equals( resultRow.KYK_CD, materialKeyKYK_CD ) &&
                        String.Equals( resultRow.KYKAN_NO, materialKeyKYKAN_NO ) &&
                        String.Equals(resultRow.AC_CD, materialKeyAC_CD) &&
                        //String.Equals( resultRow.SZIKYTU_KB, materialKeySZIKYTU_KB ) &&
                        String.Equals( resultRow.SZIKYTU_CD, materialKeySZIKYTU_CD ) &&
                        String.Equals( resultRow.K_SZI_RYKG, materialKeyK_SZI_RYKG )
                    )
                )
                {
                    materialViewRow.SHK_NO = materialKeySHK_NO;

                    materialViewRow.KYK_CD = materialKeyKYK_CD;

                    materialViewRow.KYKAN_NO = materialKeyKYKAN_NO;

                    materialViewRow.SZIKYTU = materialKeyAC_CD + "-" + materialKeySZIKYTU_CD;
                    //materialViewRow.SZIKYTU = materialKeySZIKYTU_KB + "-" + materialKeySZIKYTU_CD;

                    materialViewRow.K_SZI_RYKG = materialKeyK_SZI_RYKG;

                    materialViewRow.CM_SEC = materialKeyCM_SEC.ToString();

                    view.KkhTVSpotMaterialListView.AddKkhTVSpotMaterialListViewRow( materialViewRow );

                    materialViewRow = view.KkhTVSpotMaterialListView.NewKkhTVSpotMaterialListViewRow();

                    //

                    materialKeySHK_NO = resultRow.SHK_NO;
                    materialKeyKYK_CD = resultRow.KYK_CD;
                    materialKeyKYKAN_NO = resultRow.KYKAN_NO;
                    materialKeyAC_CD = resultRow.AC_CD;
                    //materialKeySZIKYTU_KB = resultRow.SZIKYTU_KB;
                    materialKeySZIKYTU_CD = resultRow.SZIKYTU_CD;
                    materialKeyK_SZI_RYKG = resultRow.K_SZI_RYKG;
                    materialKeyCM_SEC = 0.0m;
                }
            }

            //

            viewRow.SHK_NO = keySHK_NO;

            viewRow.KYK_CD = keyKYK_CD;

            viewRow.KYKAN_NO = keyKYKAN_NO;

            viewRow.TIKU = keyTIKU;

            viewRow.KYOKUCD = keyKYOKUCD;

            viewRow.KYOKUNAME = keyKYOKUNAME;

            viewRow.K_HKGAK_HAT = keyK_HKGAK_HAT.ToString();

            viewRow.COUNT = keyCOUNT.ToString();

            viewRow.CM_SEC = keyCM_SEC.ToString();

            viewRow.TOTAL_CM_SEC = keyTOTAL_CM_SEC.ToString();

            if (!String.IsNullOrEmpty(viewRow.KYOKUCD))
            {
                viewRow.CHECK = true.ToString();
            }
            else
            {
                viewRow.CHECK = false.ToString();
            }

            view.KkhTVSpotDetailListView.AddKkhTVSpotDetailListViewRow( viewRow );

            //

            materialViewRow.SHK_NO = materialKeySHK_NO;

            materialViewRow.KYK_CD = materialKeyKYK_CD;

            materialViewRow.KYKAN_NO = materialKeyKYKAN_NO;

            materialViewRow.SZIKYTU = materialKeyAC_CD + "-" + materialKeyAC_CD;
            //materialViewRow.SZIKYTU = materialKeySZIKYTU_KB + "-" + materialKeySZIKYTU_CD;

            materialViewRow.K_SZI_RYKG = materialKeyK_SZI_RYKG;

            materialViewRow.CM_SEC = materialKeyCM_SEC.ToString();

            view.KkhTVSpotMaterialListView.AddKkhTVSpotMaterialListViewRow( materialViewRow );

            //

            textContractName.Text = strCONTRA_NAM;

            textPeriodFrom.Text = strHK_SDT;

            textPeriodTo.Text = strHK_EDT;

            _view = view;

            btnDecision.Enabled = true;

            dgvMain1_Sheet1.RowCount = 0;

            dgvMain1_Sheet1.DataSource = view.KkhTVSpotDetailListView;

            InitDesignForSpdJyutyuListChild();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }

        private void btnDecision_Click(object sender, EventArgs e)
        {
            FindLionTVSpotNaviParameter naviParameterOut = new FindLionTVSpotNaviParameter();

            DetailDSLion output = new DetailDSLion();

            DetailDSLion.KkhTVSpotDetailListViewRow outputRow = output.KkhTVSpotDetailListView.NewKkhTVSpotDetailListViewRow();

            for( int i = 0; i < dgvMain1_Sheet1.RowCount; i++ )
            {
                if( String.Equals( dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_CHECK ].Value.ToString(), false.ToString() ) )
                {
                    continue;
                }

                outputRow.TIKU = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_TIKU ].Value.ToString();

                outputRow.KYOKUCD = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_KYOKUCD ].Value.ToString();

                outputRow.KYOKUNAME = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_KYOKUNAME ].Value.ToString();

                outputRow.K_HKGAK_HAT = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_K_HKGAK_HAT ].Value.ToString();

                outputRow.COUNT = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_COUNT ].Value.ToString();

                outputRow.CM_SEC = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_CM_SEC ].Value.ToString();

                outputRow.TOTAL_CM_SEC = dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_TOTAL_CM_SEC ].Value.ToString();

                output.KkhTVSpotDetailListView.AddKkhTVSpotDetailListViewRow( outputRow );

                outputRow = output.KkhTVSpotDetailListView.NewKkhTVSpotDetailListViewRow();
            }

            naviParameterOut.DetailListRow = (DetailDSLion.KkhTVSpotDetailListViewRow[])output.KkhTVSpotDetailListView.Select("", "");

            // オペレーションログの出力 
            KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_FINDTVSPOT, KKHLogUtilityLion.DESC_OPERATION_LOG_FINDTVSPOT);

            Navigator.Backward(this, naviParameterOut, null, true);
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for( int i = 0; i < dgvMain1_Sheet1.RowCount; i++ )
            {
                dgvMain1_Sheet1.Cells[ i, COLUMN_INDEX_CHECK ].Value = true;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                //表示データがない場合はタブページ変更をキャンセル 
                if (dgvMain1_Sheet1.Rows.Count <= 0)
                {
                    e.Cancel = true;
                }
                else
                {
                    DetailDSLion view = new DetailDSLion();

                    DetailDSLion.KkhTVSpotMaterialListViewRow[] sourceRows = (DetailDSLion.KkhTVSpotMaterialListViewRow[])_view.KkhTVSpotMaterialListView.Select("", "");

                    DetailDSLion.KkhTVSpotMaterialListViewRow viewRow = view.KkhTVSpotMaterialListView.NewKkhTVSpotMaterialListViewRow();

                    String keySHK_NO = dgvMain1_Sheet1.Cells[ dgvMain1_Sheet1.ActiveRowIndex, 0 ].Value.ToString();
                    String keyKYK_CD = dgvMain1_Sheet1.Cells[ dgvMain1_Sheet1.ActiveRowIndex, 1 ].Value.ToString();
                    String keyKYKAN_NO = dgvMain1_Sheet1.Cells[ dgvMain1_Sheet1.ActiveRowIndex, 2 ].Value.ToString();

                    foreach (DetailDSLion.KkhTVSpotMaterialListViewRow sourceRow in sourceRows)
                    {
                        if
                        ( !
                            (
                                String.Equals( sourceRow.SHK_NO, keySHK_NO ) &&
                                String.Equals( sourceRow.KYK_CD, keyKYK_CD ) &&
                                String.Equals( sourceRow.KYKAN_NO, keyKYKAN_NO )
                            )
                        )
                        {
                            continue;
                        }

                        viewRow.SHK_NO = sourceRow.SHK_NO;

                        viewRow.KYK_CD = sourceRow.KYK_CD;

                        viewRow.KYKAN_NO = sourceRow.KYKAN_NO;

                        viewRow.SZIKYTU = sourceRow.SZIKYTU;

                        viewRow.K_SZI_RYKG = sourceRow.K_SZI_RYKG;

                        viewRow.CM_SEC = sourceRow.CM_SEC;

                        view.KkhTVSpotMaterialListView.AddKkhTVSpotMaterialListViewRow( viewRow );

                        viewRow = view.KkhTVSpotMaterialListView.NewKkhTVSpotMaterialListViewRow();
                    }

                    dgvMain2_Sheet1.DataSource = view.KkhTVSpotMaterialListView;
                }
            }
        }
    }
}

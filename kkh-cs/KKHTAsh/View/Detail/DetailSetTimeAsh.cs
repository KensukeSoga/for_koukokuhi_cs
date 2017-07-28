using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Ash.Utility;

namespace Isid.KKH.Ash.View.Detail
{
    public partial class DetailSetTimeAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        # region 定数
        /// <summary>
        /// 曜日
        /// </summary>
        private const int C_WEEK_ROW = 0;
        /// <summary>
        /// 開始行
        /// </summary>
        private const int C_DAY_ROW = 1;
        /// <summary>
        ///  DataGridViewの選択した背景色
        /// </summary>
        private static readonly Color C_DGV_SELECT_BACKCOLOR = Color.SkyBlue;
        /// <summary>
        /// DataGridViewのデフォルトの背景色
        /// </summary>
        private static readonly Color C_DGV_DEFAULT_BACKCOLOR = Color.White;
        #endregion 定数

        #region メンバ変数
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable dtDetail = null;
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        DataGridViewCell sCell; //クリックしたセル.
        DataGridViewCell eCell; //クリックを離したセル.
        string _mHosoBi = string.Empty;
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailSetTimeAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        # region イベント 

        /// <summary>
        /// ＯＫボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //明細件数分、繰り返す 
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //期間  
                string kikan = dtpKikanFrom.Value.ToShortDateString().Replace("/", "") +
                                  dtpKikanTo.Value.ToShortDateString().Replace("/", "");
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = keisaiDt;
                //DataTableの方がいい？ 
                //dtDetail[i].kikan = keisaiDt;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = kikan;
                //放送時間、路線名称 TODO 未設定にはできない 
                string hosouJikan = dtpHosouJikanFrom.Value.ToString("HH:mm") + "-" +
                                    dtpHosouJikanTo.Value.ToString("HH:mm");
                //dtDetail[i].housouZikan = hosouJikan;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = hosouJikan;
                //曜日 
                //媒体コードがテレビタイム、テレビネットスポットの場合 
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) // 2015/06/08 K.F 新広告費明細　アサヒ対応.
                    )
                {
                    //dtDetail[i].youbi = setYoubi();
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = setYoubi();
                }
                //媒体コードがテレビタイム以外の場合 
                else
                {
                    //dtDetail[i].youbi = " ";
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = " ";
                }
                //局ネット数 
                //dtDetail[i].kyokuNetSuu = txtKyokuNetSu.Text.PadLeft(3, '0');
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Value = txtKyokuNetSu.Text.PadLeft(3, '0');
                //キー局
                //dtDetail[i].keyKyokuCd = cmbKeyKyokuCd.Text;
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Value = cmbKeyKyokuCd.Text;
                //スペース 
                //dtDetail[i].space = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_SPACE].Value = " ";
                //朝夕区分 
                //dtDetail[i].asaYuuKbn = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = " ";
                //掲載版 
                //dtDetail[i].keisaiBan = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = " ";
                //記雑区分 
                //dtDetail[i].kizatsuKbn = " ";
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = " ";
            }
            //_naviParam.DataTable1 = dtDetail;

            //Navigator.Backward(this, _naviParam, null, true);
            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

        /// <summary>
        /// キャンセルボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSetTimeAsh_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化 
            InitializeControl();
            // 各コントロールの編集 
            editControl();
        }

        /// <summary>
        /// DataGridViewCellPaintingイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex.Equals(0))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        /// <summary>
        /// DataGridViewMouseClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ヘダーは処理しない 
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                dgbYoubi.ClearSelection();
                return;
            }
            //初期化 
            sCell = null;
            eCell = null;

            //現在セルの位置を取得する。 
            sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
            eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////セルのBackColorをセットする。 
            if (e.Button == MouseButtons.Left)
            {
                //現在セルの位置を取得する。 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                //日にちが無い場合は処理しない 
                if (dgbYoubi[e.ColumnIndex, e.RowIndex].Value == null
                    || dgbYoubi[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty)
                {
                    return;
                }
                //未選択なら色を付ける 
                if (!dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                {
                    dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                }
                else
                {
                    dgbYoubi[e.ColumnIndex, e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                }
                return;
            }
        }

        /// <summary>
        /// DataGridViewMouseDownイベント. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ヘダーは処理しない 
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                dgbYoubi.ClearSelection();
                return;
            }
            //初期化 
            sCell = null;
            eCell = null;

            //現在セルの位置を取得する。 
            sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
            eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////セルのBackColorをセットする。 
            if (e.Button == MouseButtons.Right)
            {
                //現在セルの位置を取得する。 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                dgbYoubi[e.ColumnIndex, e.RowIndex].Selected = true;
                return;
            }
        }

        /// <summary>
        /// DataGridViewMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgbYoubi.ClearSelection();
        }

        /// <summary>
        /// DataGridViewDoubleClickイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbYoubi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //初期化 
            sCell = null;
            eCell = null;

            //ヘダーの場合 
            if (e.RowIndex == 0)
            {
                //現在セルの位置を取得する 
                sCell = dgbYoubi[e.ColumnIndex, 0];
                eCell = dgbYoubi[e.ColumnIndex, 0];

                //列の背景色に色を付ける 
                //未選択なら色を付ける 
                for (int row = 1; row < dgbYoubi.RowCount; row++)
                {
                    //日にちが無い場合は処理しない 
                    if (dgbYoubi[e.ColumnIndex, row].Value == null
                        || dgbYoubi[e.ColumnIndex, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        if (!dgbYoubi[e.ColumnIndex, row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            dgbYoubi[e.ColumnIndex, row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            dgbYoubi[e.ColumnIndex, row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;
            }
            else
            {
                //現在セルの位置を取得する 
                sCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                eCell = dgbYoubi[e.ColumnIndex, e.RowIndex];
                //行の背景色に色を付ける 
                //未選択なら色を付ける 
                for (int col = e.ColumnIndex + 1; col < dgbYoubi.ColumnCount; col++)
                {
                    //日にちが無い場合は処理しない 
                    if (dgbYoubi[col, e.RowIndex].Value == null
                        || dgbYoubi[col, e.RowIndex].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //背景色が選択色以外の場合 
                        if (!dgbYoubi[col, e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //背景色を選択色にする 
                            dgbYoubi[col, e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            //背景色を元に戻す 
                            dgbYoubi[col, e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;

            }

        }

        /// <summary>
        /// クリアボタンイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            //選択クリア 
            clearSelection();
        }

        /// <summary>
        /// 期間（From）フォーカスアウト 
        /// </summary>
        private void dtpKikanFrom_Leave(object sender, EventArgs e)
        {
            //期間（From）＞期間（To）の場合 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // 期間（To）に期間（From）の値を設定 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }

            String strKikanFrom = dtpKikanFrom.Value.ToShortDateString().Replace("/", "");
            strKikanFrom = strKikanFrom.Substring(0, 6);
            String strYoubi = lblYoubi.Text.Replace("/", "");
            strYoubi = strYoubi.Replace(" ", "");
            //期間（From）と曜日の年月が異なる場合 
            if (strKikanFrom.Equals(strYoubi) == false)
            {
                //カレンダーの選択状態をクリア 
                clearSelection();
                //曜日の年月に期間（From）のカレンダーを表示 
                String strKikanFromYear = strKikanFrom.Substring(0, 4);
                String strKikanFromMonth = strKikanFrom.Substring(4, 2);
                //ラベルに放送月を表示する
                lblYoubi.Text = strKikanFromYear + " / " + strKikanFromMonth;
                //表示する年月.
                DateTime[] days = GetGeshi(int.Parse(strKikanFromYear), int.Parse(strKikanFromMonth));
                makeCalendar(days);
            }

        }

        /// <summary>
        /// 期間（To）フォーカスアウト 
        /// </summary>
        private void dtpKikanTo_Leave(object sender, EventArgs e)
        {
            //期間（From）＞期間（To）の場合 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // 期間（To）に期間（From）の値を設定 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailSetTimeAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRow;
                _spdDetailInput_Sheet1 = _naviParam.SpdDetailInput_Sheet1;
                dtDetail = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)_naviParam.DataTable1;
            }
        }


        # endregion イベント

        # region メソッド

        /// <summary>
        /// 各コントロールの初期表示処理  
        /// </summary>
        private void InitializeControl()
        {
            //テキストボックス初期化 
            txtKyokuNetSu.Text = "0";
        }

        /// <summary>
        /// 各コントロールの編集処理 
        /// </summary>
        private void editControl()
        {

            /*
             * 期間（From、To） 
             */
            String strKikan = null;
            strKikan =
            _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KEISAIDT].Text.Replace("/", "").Trim();
            //_spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KIKAN].Text.Replace("年", "").Replace("月", "").Replace("日", "").Replace(" - ", "").Trim();
            if (!String.IsNullOrEmpty(strKikan) && (strKikan.Length == 8 || strKikan.Length == 16))
            {
                String strKikanFrom = strKikan.Substring(0, 8);
                if (KKHUtility.IsDate(strKikanFrom, "yyyyMMdd") == true)
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(strKikanFrom);
                }
                else
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }

                String strKikanTo = null;
                if (strKikan.Length == 8)
                {
                    strKikanTo = strKikan.Substring(0, 8);
                }
                else
                {
                    strKikanTo = strKikan.Substring(8, 8);
                }

                if (KKHUtility.IsDate(strKikanTo, "yyyyMMdd") == true)
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(strKikanTo);
                }
                else
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }
            }
            else
            {
                dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
            }

            /*
             * 放送時間（From、To） 
             */
            String strHosouJikan = null;
            strHosouJikan = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Text.Trim();
            int delimiter = strHosouJikan.IndexOf("-");
            if (!String.IsNullOrEmpty(strHosouJikan))
            {
                String strHosouJikanFrom = strHosouJikan.Substring(0, delimiter);
                DateTime dateHosouJikanFrom;
                if (DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + strHosouJikanFrom + ":00", out dateHosouJikanFrom) == true)
                {
                    dtpHosouJikanFrom.Value = dateHosouJikanFrom;
                }
                else
                {
                    //TODO DateTimePickerは初期値にNULLを設定不可 
                    dtpHosouJikanFrom.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                }
                String strHosouJikanTo = strHosouJikan.Substring(delimiter + 1);
                DateTime dateHosouJikanTo;
                if (DateTime.TryParse(DateTime.Now.ToShortDateString() + " " + strHosouJikanTo + ":00", out dateHosouJikanTo) == true)
                {
                    dtpHosouJikanTo.Value = dateHosouJikanTo;
                }
                else
                {
                    //TODO DateTimePickerは初期値にNULLを設定不可 
                    dtpHosouJikanTo.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                }
            }
            else
            {
                //TODO DateTimePickerは初期値にNULLを設定不可 
                dtpHosouJikanFrom.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
                dtpHosouJikanTo.Text = DateTime.Now.ToShortDateString() + " " + "00:00";
            }

            /*
             * 局ネット数 
             */
            int intKyokuNetSu = 0;
            //明細入力スプレッド．局ネット数が数値の場合 
            if (int.TryParse(_spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Text.Trim(), out intKyokuNetSu) == true)
            {
                //明細入力スプレッド．局ネット数 
                txtKyokuNetSu.Text = intKyokuNetSu.ToString();
            }
            //明細入力スプレッド．局ネット数が数値以外の場合 
            else
            {
                //0を設定 
                txtKyokuNetSu.Text = "0";
            }

            /*
             * キー局コード 
             */
            //コンボボックスの初期化  
            cmbKeyKyokuCd.Items.Clear();
            List<string> kyokuRyakusyoList = new List<string>();
            //明細入力スプレッドの件数分、繰り返す 
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                String kyokuCd = _spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUCD].Text.Trim();
                int firstSpaceIndex = kyokuCd.IndexOf(" ", 0);
                int secondSpaceIndex = 0;
                if (firstSpaceIndex > 0)
                {
                    secondSpaceIndex = kyokuCd.IndexOf(" ", firstSpaceIndex + 1);
                }
                if (firstSpaceIndex > 0 && secondSpaceIndex > 0)
                {
                    //明細入力スプレッド．局コードの局略称（局コードの2ブロック）を設定 
                    String kyokuRyakusyo = kyokuCd.Substring(firstSpaceIndex + 1, secondSpaceIndex - firstSpaceIndex - 1);
                    //重複していない場合 
                    if (kyokuRyakusyoList.Contains(kyokuRyakusyo) == false)
                    {
                        kyokuRyakusyoList.Add(kyokuRyakusyo);
                    }
                }
            }

            /*
             * 局コード変換マスタ取得 
             */
            //局略称が１レコードも存在しない場合 
            if (kyokuRyakusyoList.Count == 0)
            {
                //媒体コードがテレビタイム、テレビネットスポットの場合 
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true  // 2015/06/08 K.F 新広告費明細　アサヒ対応.
                    )
                {
                    //テレビ局コード変換マスタ取得 
                    MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                    FindMasterMaintenanceByCondServiceResult result;
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                    _naviParam.strEgcd,
                                                    _naviParam.strTksKgyCd,
                                                    _naviParam.strTksBmnSeqNo,
                                                    _naviParam.strTksTntSeqNo,
                                                    Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU_HENNKAN,
                                                    "");
                    MasterMaintenance.MasterDataVODataTable dsKeyKyokuCd = new MasterMaintenance.MasterDataVODataTable();
                    dsKeyKyokuCd.Merge(result.MasterDataSet.MasterDataVO);
                    dsKeyKyokuCd.AcceptChanges();
                    cmbKeyKyokuCd.DisplayMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.ValueMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.DataSource = dsKeyKyokuCd;
                }
                //媒体コードが上記以外の場合 
                else
                {
                    //ラジオ局コード変換マスタ取得 
                    MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                    FindMasterMaintenanceByCondServiceResult result;
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                    _naviParam.strEgcd,
                                                    _naviParam.strTksKgyCd,
                                                    _naviParam.strTksBmnSeqNo,
                                                    _naviParam.strTksTntSeqNo,
                                                    Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU_HENNKAN,
                                                    "");
                    MasterMaintenance.MasterDataVODataTable dsKeyKyokuCd = new MasterMaintenance.MasterDataVODataTable();
                    dsKeyKyokuCd.Merge(result.MasterDataSet.MasterDataVO);
                    dsKeyKyokuCd.AcceptChanges();
                    cmbKeyKyokuCd.DisplayMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.ValueMember = dsKeyKyokuCd.Column1Column.ColumnName;
                    cmbKeyKyokuCd.DataSource = dsKeyKyokuCd;
                }
            }
            //局略称が存在する場合 
            else
            {
                List<AshComboBoxItem> items = new List<AshComboBoxItem>();
                for (int i = 0; i < kyokuRyakusyoList.Count; i++)
                {
                    items.Add(new AshComboBoxItem(kyokuRyakusyoList[i], kyokuRyakusyoList[i]));
                }
                cmbKeyKyokuCd.DisplayMember = "NAME";
                cmbKeyKyokuCd.ValueMember = "CODE";
                cmbKeyKyokuCd.DataSource = items;
            }
            //初期値を設定 
            cmbKeyKyokuCd.SelectedValue = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Text.Trim();

            /*
             * カレンダー 
             */
            int _iNen = int.Parse(dtpKikanFrom.Value.Year.ToString());
            int _iGetsu = int.Parse(dtpKikanFrom.Value.Month.ToString());
            //年月のラベルを設定 
            lblYoubi.Text = _iNen.ToString() + " / " + String.Format("{0:00}", _iGetsu);
            //カレンダーに表示する年月 
            DateTime[] days = GetGeshi(_iNen, _iGetsu);
            //2015/03/10 miyanoue アサヒ対応 Start
            //_mHosoBi = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_YOUBI].Text.Trim();
            _mHosoBi = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_YOUBI].Text.Trim();
            //2015/03/10 miyanoue アサヒ対応 End
            //カレンダー作成 
            makeCalendar(days);
            //媒体コードがテレビタイム、テレビネットスポットの場合 
            if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd)  // 2015/06/08 K.F 新広告費明細　アサヒ対応.
                )
            {
                //放送日設定 
                serHousouBi();
            }
            //媒体コードが上記以外の場合 
            else
            {
                //カレンダー無効化 
                dgbYoubi.Enabled = false;
            }
            //曜日項目の無効化
            if (!KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)
                && !KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd)  // 2015/06/08 K.F 新広告費明細　アサヒ対応.
                )
            {
                grpYoubi.Enabled = false;
                dispDisabledCalendar();
            }
        }

        /// <summary>
        /// 年月を取得する.
        /// </summary>
        /// <param name="y">年YYYY</param>
        /// <param name="m">月MM</param>
        /// <returns></returns>
        static DateTime[] GetGeshi(int y, int m)
        {
            List<DateTime> days = new List<DateTime>();

            //for (DateTime d = new DateTime(y, m, 1); d.Month == m; d = d.AddDays(1))
            //{
            //    days.Add(d);
            //}

            int dayMax = DateTime.DaysInMonth(y, m);

            for (int day = 1; day <= dayMax; day++)
            {
                days.Add(new DateTime(y, m, day));
            }

            return days.ToArray();
        }

        /// <summary>
        /// カレンダー作成 
        /// </summary>
        private void makeCalendar(DateTime[] days)
        {
            int cnt = 1;
            int intsta = 0;
            int introw = C_DAY_ROW;

            //行を作成 
            dgbYoubi.RowCount = 7;

            //画面表示時選択をしない 
            dgbYoubi.CurrentCell = null;

            //選択クリア 
            clearSelection();

            //日付クリア 
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    dgbYoubi[j, i].ReadOnly = true;
                    dgbYoubi[j, i].Value = "";
                }
            }

            //対象月の日数  
            int currentMonthDays = days.Length;

            # region 日付セット
            for (int daysIndex = 0; daysIndex < currentMonthDays; daysIndex++)
            {
                DateTime d = days[daysIndex];
                //開始位置を決める 
                if (cnt == 1)
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgbYoubi[0, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 0;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Monday)
                    {
                        dgbYoubi[1, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 1;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        dgbYoubi[2, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 2;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        dgbYoubi[3, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 3;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Thursday)
                    {
                        dgbYoubi[4, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 4;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Friday)
                    {
                        dgbYoubi[5, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 5;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dgbYoubi[6, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 6;
                    }
                }
                else
                {
                    //7で割り切れた場合、つまり1週間分作成したら改行 
                    if (intsta % 7 == 0)
                    {
                        introw++;
                        intsta = 0;
                    }
                    dgbYoubi[intsta, introw].Value = cnt.ToString();
                }
                cnt++;
                intsta++;
            }
            # endregion 日付セット

            # region 曜日セット
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        dgbYoubi[i, C_WEEK_ROW].Value = "日";
                        break;
                    case 1:
                        dgbYoubi[i, C_WEEK_ROW].Value = "月";
                        break;
                    case 2:
                        dgbYoubi[i, C_WEEK_ROW].Value = "火";
                        break;
                    case 3:
                        dgbYoubi[i, C_WEEK_ROW].Value = "水";
                        break;
                    case 4:
                        dgbYoubi[i, C_WEEK_ROW].Value = "木";
                        break;
                    case 5:
                        dgbYoubi[i, C_WEEK_ROW].Value = "金";
                        break;
                    case 6:
                        dgbYoubi[i, C_WEEK_ROW].Value = "土";
                        break;
                }
            }

            # endregion 曜日セット

            # region セル設定.
            //デザイナーで記述したので不要 
            for (int i = 0; i < 7; i++)
            {
                //列の幅を揃える 
                dgbYoubi.Columns[i].Width = 35;
                //右寄せにする 
                dgbYoubi.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            # endregion セル設定.

        }

        /// <summary>
        /// 放送日設定 
        /// </summary>
        private void serHousouBi()
        {
            if (_mHosoBi == "")
            {
                return;
            }
            int _iDayCnt = 0;
            string _hosoBi = string.Empty;
            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //日にちが無い場合は処理しない 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //パラメータの放送日をセット 
                        if (_iDayCnt < 31)
                        {
                            //一文字ずつ取得する 
                            _hosoBi = _mHosoBi.Substring(_iDayCnt, 1);

                            //0か1か判定する。  
                            if (_hosoBi.Equals("1"))
                            {
                                //1の場合、背景色を選択色にする 
                                dgbYoubi[col, row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                            }
                            //翌日 
                            _iDayCnt++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 選択クリア 
        /// </summary>
        private void clearSelection()
        {
            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //日にちが無い場合は処理しない 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        dgbYoubi[col, row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                    }
                }
            }
        }

        /// <summary>
        /// カレンダー無効化表示 
        /// </summary>
        private void dispDisabledCalendar()
        {
            dgbYoubi.BorderStyle = BorderStyle.Fixed3D;

            for (int row = 0; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    dgbYoubi[col, row].Style.ForeColor = Color.Gray;
                }
            }
        }

        /// <summary>
        /// 曜日の設定 
        /// </summary>
        private String setYoubi()
        {
            string _dayCnt = string.Empty;

            for (int row = 1; row < dgbYoubi.RowCount; row++)
            {
                for (int col = 0; col < dgbYoubi.ColumnCount; col++)
                {
                    //日にちが無い場合は処理しない 
                    if (dgbYoubi[col, row].Value == null
                            || dgbYoubi[col, row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //背景色が選択している場合 
                        if (dgbYoubi[col, row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //選択している場合 
                            _dayCnt += "1";
                            //_sb.Append("0");
                        }
                        else
                        {
                            //選択していない場合 
                            _dayCnt += "0";
                            //_sb.Append("0");
                        }
                    }
                }
            }

            while (_dayCnt.Length < 31)
            {
                _dayCnt += "0";
            }
            return _dayCnt;
        }

        # endregion メソッド
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Uni.View.Detail;

namespace Isid.KKH.Uni.View.Detail
{
    public partial class DetailHosoBiUni : KKHDialogBase
    {
        # region 定数
        /// <summary>
        /// 曜日.
        /// </summary>
        private const int C_WEEK_ROW = 0;
        /// <summary>
        /// 開始行.
        /// </summary>
        private const int C_DAY_ROW = 1;
        /// <summary>
        ///  DataGridViewの選択した背景色.
        /// </summary>
        private static readonly Color C_DGV_SELECT_BACKCOLOR = Color.SkyBlue;
        /// <summary>
        /// DataGridViewのデフォルトの背景色.
        /// </summary>
        private static readonly Color C_DGV_DEFAULT_BACKCOLOR = Color.White;


        # endregion 定数

        # region メンバ変数
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = null;
        private int rowDetailIdx = -1;
        private FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1 = null;
        private DetailHosoBiUniNaviParameter naviParam = new DetailHosoBiUniNaviParameter();

        DataGridViewCell sCell; //クリックしたセル.
        DataGridViewCell eCell; //クリックを離したセル.
        string _mHosoBi = string.Empty; //呼び出し元の放送日.
        # endregion メンバ変数

        # region コンストラクタ
        public DetailHosoBiUni()
        {
            InitializeComponent();
        }
        # endregion コンストラクタ

        # region イベント

        private void DetailHosoBiUni_Load(object sender , EventArgs e)
        {
            //行を作成.
            dataGridView1.RowCount = 7;

            //画面表示時選択をしない.
            dataGridView1.CurrentCell = null;

            int cnt = 1;
            int intsta = 0;
            int introw = C_DAY_ROW;
            //現在日付を取得.
            DateTime dt = DateTime.Now;
            int iNen = int.Parse(dt.Year.ToString());
            int iGetsu = int.Parse(dt.Month.ToString());

            //放送年月.
            if (!string.IsNullOrEmpty(naviParam.DateUni))
            {
                string nengetsu = naviParam.DateUni;
                iNen = int.Parse(nengetsu.Substring(0 , 4));
                iGetsu = int.Parse(nengetsu.Substring(4 , 2));
                //lblHosoBi.Text = iNen.ToString() + " / " + iGetsu.ToString();
            }

            //ラベルに放送月を表示する.
            lblHosoBi.Text = iNen.ToString() + " / " + iGetsu.ToString();

            //表示する年月.
            DateTime[] days = GetGeshi(iNen , iGetsu);
            # region 日付セット

            foreach (DateTime d in days)
            {
                //開始位置を決める.
                if (cnt == 1)
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dataGridView1[0 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 0;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Monday)
                    {
                        dataGridView1[1, C_DAY_ROW].Value = cnt.ToString();
                        intsta = 1;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        dataGridView1[2 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 2;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        dataGridView1[3 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 3;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Thursday)
                    {
                        dataGridView1[4 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 4;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Friday)
                    {
                        dataGridView1[5 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 5;
                    }
                    else if (d.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dataGridView1[6 , C_DAY_ROW].Value = cnt.ToString();
                        intsta = 6;
                    }
                }
                else
                {
                    //7で割り切れた場合、つまり1週間分作成したら改行.
                    if (intsta % 7 == 0)
                    {
                        introw++;
                        intsta = 0;
                    }
                    dataGridView1[intsta , introw].Value = cnt.ToString();
                }
                cnt++;
                intsta++;
            }
            # endregion 日付セット

            # region 曜日セット
            for (int i = 0 ; i < 7 ; i++)
            {
                switch (i)
                {
                    case 0:
                        dataGridView1[i , C_WEEK_ROW].Value = "日";
                        break;
                    case 1:
                        dataGridView1[i , C_WEEK_ROW].Value = "月";
                        break;
                    case 2:
                        dataGridView1[i , C_WEEK_ROW].Value = "火";
                        break;
                    case 3:
                        dataGridView1[i , C_WEEK_ROW].Value = "水";
                        break;
                    case 4:
                        dataGridView1[i , C_WEEK_ROW].Value = "木";
                        break;
                    case 5:
                        dataGridView1[i , C_WEEK_ROW].Value = "金";
                        break;
                    case 6:
                        dataGridView1[i , C_WEEK_ROW].Value = "土";
                        break;
                }
            }

            # endregion 曜日セット

            # region セル設定.
            //デザイナーで記述したので不要.
            for (int i = 0 ; i < 7 ; i++)
            {
                //列の幅を揃える.
                dataGridView1.Columns[i].Width = 35;
                //右寄せにする.
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            # endregion セル設定.

            # region パラメータの放送日をセット.
            int _iDayCnt = 0;
            string _hosoBi = string.Empty;
            for (int row = 1 ; row < dataGridView1.RowCount ; row++)
            {
                for (int col = 0 ; col < dataGridView1.ColumnCount ; col++)
                {
                    //日にちが無い場合は処理しない.
                    if (dataGridView1[col , row].Value == null
                            || dataGridView1[col , row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //パラメータの放送日をセット.
                        if (_iDayCnt < 31)
                        {
                            //一文字ずつ取得する.
                            _hosoBi = _mHosoBi.Substring(_iDayCnt, 1);

                            //0か1か判定する。 
                            if (_hosoBi.Equals("1"))
                            {
                                //1の場合、背景色を選択色にする.
                                dataGridView1[col , row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                            }

                            //翌日.
                            _iDayCnt++;
                        }
                    }
                }

            }
            # endregion パラメータの放送日をセット.
        }

        /// <summary>
        /// DataGridViewCellPaintingイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellPainting(object sender , DataGridViewCellPaintingEventArgs e)
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
        private void dataGridView1_CellMouseClick(object sender , DataGridViewCellMouseEventArgs e)
        {
            //ヘダーは処理しない.
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                //dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();
                return;
            }

            //空白(日にちが無い)の場合は処理理しない 
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value == null) 
            {
                return; 
            }
            
            //初期化.
            sCell = null;
            eCell = null;

            //現在セルの位置を取得する。.
            sCell = dataGridView1[e.ColumnIndex , e.RowIndex];
            eCell = dataGridView1[e.ColumnIndex , e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////セルのBackColorをセットする。 
            if (e.Button == MouseButtons.Left)
            {
                //現在セルの位置を取得する。.
                sCell = dataGridView1[e.ColumnIndex , e.RowIndex];
                eCell = dataGridView1[e.ColumnIndex , e.RowIndex];
                //dataGridView1[e.ColumnIndex , e.RowIndex].Selected = true;
                //未選択なら色を付ける.
                if (!dataGridView1[e.ColumnIndex , e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                {
                    dataGridView1[e.ColumnIndex , e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                }
                else
                {
                    dataGridView1[e.ColumnIndex , e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                }
                return;
            }
        }

        /// <summary>
        /// DataGridViewMouseDownイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDown(object sender , DataGridViewCellMouseEventArgs e)
        {
            //ヘダーは処理しない.
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {
                dataGridView1.ClearSelection();
                return;
            }
            //初期化.
            sCell = null;
            eCell = null;

            //現在セルの位置を取得する。
            sCell = dataGridView1[e.ColumnIndex , e.RowIndex];
            eCell = dataGridView1[e.ColumnIndex , e.RowIndex];

            DataGridView dgv = (DataGridView)sender;

            ////セルのBackColorをセットする。 
            if (e.Button == MouseButtons.Right)
            {
                //現在セルの位置を取得する。 
                sCell = dataGridView1[e.ColumnIndex , e.RowIndex];
                eCell = dataGridView1[e.ColumnIndex , e.RowIndex];
                dataGridView1[e.ColumnIndex , e.RowIndex].Selected = true;
                return;
            }
        }

        /// <summary>
        /// DataGridViewMoveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseMove(object sender , DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        /// <summary>
        /// DataGridViewDoubleClickイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender , DataGridViewCellMouseEventArgs e)
        {
            //初期化.
            sCell = null;
            eCell = null;

            //ヘダーの場合.
            if (e.RowIndex == 0)
            {
                //現在セルの位置を取得する.
                sCell = dataGridView1[e.ColumnIndex , 0];
                eCell = dataGridView1[e.ColumnIndex , 0];

                //列の背景色に色を付ける.
                //未選択なら色を付ける.
                for (int row = 1 ; row < dataGridView1.RowCount ; row++)
                {
                    //日にちが無い場合は処理しない.
                    if (dataGridView1[e.ColumnIndex , row].Value == null
                        || dataGridView1[e.ColumnIndex , row].Value.ToString() == string.Empty)
                    {
                        //dataGridView1[e.ColumnIndex , row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        continue;
                    }
                    else
                    {
                        if (!dataGridView1[e.ColumnIndex , row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            dataGridView1[e.ColumnIndex , row].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            dataGridView1[e.ColumnIndex , row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;
            }
            else
            {
                //現在セルの位置を取得する.
                sCell = dataGridView1[e.ColumnIndex , e.RowIndex];
                eCell = dataGridView1[e.ColumnIndex , e.RowIndex];

                //行の背景色に色を付ける.
                //未選択なら色を付ける.
                for (int col = e.ColumnIndex + 1 ; col < dataGridView1.ColumnCount ; col++)
                {
                    //日にちが無い場合は処理しない.
                    if (dataGridView1[col , e.RowIndex].Value == null
                        || dataGridView1[col , e.RowIndex].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //背景色が選択色以外の場合 
                        if (!dataGridView1[col , e.RowIndex].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //背景色を選択色にする.
                            dataGridView1[col , e.RowIndex].Style.BackColor = C_DGV_SELECT_BACKCOLOR;
                        }
                        else
                        {
                            //背景色を元に戻す.
                            dataGridView1[col , e.RowIndex].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                        }
                    }
                }
                return;
            }
        }

        /// <summary>
        /// クリアボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender , EventArgs e)
        {
            for (int row = 1 ; row < dataGridView1.RowCount ; row++)
            {
                for (int col = 0 ; col < dataGridView1.ColumnCount ; col++)
                {
                    //日にちが無い場合は処理しない.
                    if (dataGridView1[col , row].Value == null
                            || dataGridView1[col , row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        dataGridView1[col , row].Style.BackColor = C_DGV_DEFAULT_BACKCOLOR;
                    }
                }
            }
        }

        /// <summary>
        /// キャンセルボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender , EventArgs e)
        {
            Navigator.Backward(this , null , null , true);
            this.Close();
        }

        /// <summary>
        /// OKボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender , EventArgs e)
        {
            string dayCnt = string.Empty;
            //StringBuilder _sb; 

            for (int row = 1 ; row < dataGridView1.RowCount ; row++)
            {
                for (int col = 0 ; col < dataGridView1.ColumnCount ; col++)
                {
                    //日にちが無い場合は処理しない.
                    if (dataGridView1[col , row].Value == null
                            || dataGridView1[col , row].Value.ToString() == string.Empty)
                    {
                        continue;
                    }
                    else
                    {
                        //背景色が選択している場合 
                        if (dataGridView1[col , row].Style.BackColor.Equals(C_DGV_SELECT_BACKCOLOR))
                        {
                            //選択している場合.
                            dayCnt += "1";
                            //_sb.Append("0");
                        }
                        else
                        {
                            //選択していない場合.
                            dayCnt += "0";
                            //_sb.Append("0");
                        }
                    }
                }
            }

            while (dayCnt.Length < 31)
            {
                dayCnt += "0";
            }

            naviParam.HosoBi = dayCnt;
            Navigator.Backward(this , naviParam , naviParam , true);
            this.Close();
        }

        /// <summary>
        /// プロセスアフターイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailHosoBiUni_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailHosoBiUniNaviParameter)
            {
                naviParam = (DetailHosoBiUniNaviParameter)arg.NaviParameter;
                dataRow = naviParam.DataRowUni;
                rowDetailIdx = naviParam.RowDetailIndexUni;
                spdKkhDetail_Sheet1 = naviParam.SpdKkhDetailUni_Sheet1;
                _mHosoBi = naviParam.HosoBi;
            }
        }
        # endregion イベント 

        # region メソッド 
        /// <summary>
        /// 年月を取得する.
        /// </summary>
        /// <param name="y">年YYYY</param>
        /// <param name="m">月MM</param>
        /// <returns></returns>
        static DateTime[] GetGeshi(int y , int m)
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
        # endregion メソッド 
    }
}
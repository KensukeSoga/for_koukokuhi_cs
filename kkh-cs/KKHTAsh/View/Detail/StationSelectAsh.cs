using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.Utility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.ProcessController.Detail;
using KKHUserManual.Helper;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// 局選択.
    /// </summary>
    public partial class StationSelectAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.
        #region 商品列数.
        /// <summary>
        /// 商品列数.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_CNT = 10;
        #endregion 商品列数.

        #region 局選択一覧列インデックス.
        /// <summary>
        /// 局コード列インデックス.
        /// </summary>
        public const int COLIDX_KLIST_KYOKUCD = 0;
        /// <summary>
        /// 商品列(先頭)インデックス.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_FIRST = 1;
        /// <summary>
        /// 商品列(最終)インデックス.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_END = 10;
        #endregion 局選択一覧列インデックス.

        #region 局選択一覧行インデックス.
        /// <summary>
        /// 商品コード行インデックス.
        /// </summary>
        public const int ROWIDX_KLIST_SHOUHINCD = 0;
        /// <summary>   
        /// 配分率行インデックス.
        /// </summary>
        public const int ROWIDX_KLIST_HAIBUNRITU = 1;
        /// <summary>
        /// 端数区分行インデックス.
        /// </summary>
        public const int ROWIDX_KLIST_HASUKBN = 2;
        /// <summary>
        /// 局コード行(先頭)インデックス.
        /// </summary>
        public const int ROWIDX_KLIST_KYOKUCD_FIRST = 3;
        #endregion 局選択一覧行インデックス.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// 受注データ.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// 明細入力シート.
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 商品情報(キー). 
        /// </summary>
        private string[] _itemShouhinCd = null;
        /// <summary>
        /// 商品情報(名称).
        /// </summary>
        private string[] _itemShouhinNm = null;
        /// <summary>
        /// 商品情報データセット.
        /// </summary>
        private MasterMaintenance _dsShouhinInfo = null;
        /// <summary>
        /// 局情報(キー).
        /// </summary>
        private string[] _itemKyokuCd = null;
        /// <summary>
        /// 局情報(名称).
        /// </summary>
        private string[] _itemKyokuNm = null;
        /// <summary>
        /// 局情報データセット.
        /// </summary>
        private MasterMaintenance _dsKyokuInfo = null;
        /// <summary>
        /// 端数区分(キー).
        /// </summary>
        private string[] _itemHasuKbnCd = null;
        /// <summary>
        /// 端数区分(名称).
        /// </summary>
        private string[] _itemHasuKbnNm = null;
        /// <summary>
        /// 商品コード件数.
        /// </summary>
        private int _shouhinCdCnt = 0;
        /// <summary>
        /// 配分率分母.
        /// </summary>
        private decimal _bunbo = 0;
        /// <summary>
        /// 配分率(配列).
        /// </summary>
        private decimal[] _haibunrituArray;
        /// <summary>
        /// 端数区分(配列).
        /// </summary>
        private String[] _hasuKbn;
        /// <summary>
        /// チェックボックス設定値(配列)※初期値は設定なし.
        /// </summary>
        private bool[] _checkBoxValue = new bool[COLIDX_KLIST_SHOUHINCD_CNT];
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public StationSelectAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region OKボタンクリックイベント.
        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //入力チェック.
            if (!checkInput())
            {
                return;
            }

            //明細入力画面編集.
            editDetailInput();

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }
        #endregion OKボタンクリックイベント.

        #region キャンセルボタンクリックイベント.
        /// <summary>
        /// キャンセルボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }
        #endregion キャンセルボタンクリックイベント.

        #region 削除ボタンクリックイベント.
        /// <summary>
        /// 削除ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //初期設定.
            int rowIndex = spdKyokuSentakuList_Sheet1.ActiveRowIndex;

            //選択行が端数区分行インデックスよりも大きい場合.
            if (rowIndex > ROWIDX_KLIST_HASUKBN)
            {
                //指定した行の削除.
                spdKyokuSentakuList_Sheet1.RemoveRows(rowIndex, 1);
            }

            //フォーカス設定.
            spdKyokuSentakuList.Focus();
        }
        #endregion 削除ボタンクリックイベント.

        #region 行挿入ボタンクリックイベント.
        /// <summary>
        /// 行挿入ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //最終行に追加.
            int activeRowIndex = spdKyokuSentakuList_Sheet1.ActiveRowIndex;
            spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);

            //局コードコンボボックス.
            setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);

            //ヘッダー行の場合.
            if (activeRowIndex < ROWIDX_KLIST_KYOKUCD_FIRST)
            {
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = "";
            }
            //局コード表示行の場合.
            else
            {
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = spdKyokuSentakuList_Sheet1.Cells[activeRowIndex, COLIDX_KLIST_KYOKUCD].Value.ToString().Trim();
            }

            //商品(先頭行)インデックスから商品(最終行)インデックスまでループ処理.
            for (int i = COLIDX_KLIST_SHOUHINCD_FIRST; i <= COLIDX_KLIST_SHOUHINCD_END; i++)
            {
                //チェックボックス.
                setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, i);
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, i].Value = true;
            }

            //フォーカス設定.
            spdKyokuSentakuList.Focus();
        }
        #endregion 行挿入ボタンクリックイベント.

        #region スプレッドダブルクリックイベント.
        /// <summary>
        /// スプレッドダブルクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKyokuSentakuList_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            //ヘッダーの場合.
            if (e.ColumnHeader)
            {
                //商品コード列の場合.
                if (e.Column >= COLIDX_KLIST_SHOUHINCD_FIRST)
                {
                    //局コードの件数分、繰り返す.
                    for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                    {
                        //チェックボックスの設定.
                        spdKyokuSentakuList_Sheet1.Cells[rowIndex, e.Column].Value = _checkBoxValue[e.Column - 1];
                    }

                    //次回用にチェックボックスの値を更新.
                    _checkBoxValue[e.Column - 1] = !(_checkBoxValue[e.Column - 1]);
                }
            }
        }
        #endregion スプレッドダブルクリックイベント.

        #region フォームロードイベント.
        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationSelectAsh_Load(object sender, EventArgs e)
        {
            //各コントロールの編集.
            editControl();
        }
        #endregion フォームロードイベント.

        #region ナビパラメーター情報の設定.
        /// <summary>
        /// ナビパラメーター情報の設定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void StationSelectAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //ナビパラが存在しない場合.
            if (arg.NaviParameter == null)
            {
                return;
            }

            //ナビパラ情報の設定.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRow;
                _spdDetailInput_Sheet1 = _naviParam.SpdDetailInput_Sheet1;
            }
        }
        #endregion ナビパラメーター情報の設定.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの編集処理.
        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            //媒体コードがテレビタイムの場合.
            if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true)
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
            {
                //テレビ局マスタ取得.
                setKyokuInfo(Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU);
            }
            //媒体コードが上記以外の場合.
            else
            {
                //ラジオ局マスタ取得.
                setKyokuInfo(Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU);
            }

            //商品マスタ取得.
            setShouhinInfo();

            //端数区分.
            setHasuKbn();

            //品種コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //商品コードコンボボックス作成.
                setComboBox(ROWIDX_KLIST_SHOUHINCD, colIndex, _itemShouhinCd, _itemShouhinNm);

                //端数区分コンボボックス作成.
                setComboBox(ROWIDX_KLIST_HASUKBN, colIndex, _itemHasuKbnCd, _itemHasuKbnNm);
            }

            //見積金額合計.
            decimal hnmaeGakGoukei = 0;
            /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
            //string firstKyokuCd = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
            string firstKyokuCd = string.Empty;

            //局コードが空でない場合.
            if (_spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value != null)
            {
                //明細1行目に局コードを設定.
                firstKyokuCd = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
            }
            /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */

            //局コードの件数分、繰り返す(リストの先頭は空白なので対象外なので、２レコード目からが対象).
            for (int i = 1; i < _itemKyokuCd.Length; i++)
            {
                //テレビタイム、テレビネットスポットの場合かつ、局コードの先頭1文字が一致しない場合は表示しない.
                if (KkhConstAsh.BaitaiCd.TV_TIME == _naviParam.BaitaiCd
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT == _naviParam.BaitaiCd)
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                {
                    //局コードに値がある場合.
                    if (!string.IsNullOrEmpty(firstKyokuCd))
                    {
                        //明細1業務の局コードが局情報(キー)に存在しない場合.
                        if (firstKyokuCd.Substring(0, 1) != _itemKyokuCd[i].Trim().Substring(0, 1))
                        {
                            continue;
                        }
                    }
                }

                //1行追加する.
                spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);

                //局コードコンボボックス作成.
                setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);

                //局コードコンボボックス初期値設定.
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = _itemKyokuCd[i].Trim();

                //品種コード列数分、繰り返す.
                for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                {
                    //チェックボックス生成.
                    setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                }
            }

            /* 2013/01/29 JSE A.Naito MOD Start*/
            //明細入力画面の行数分の商品コードを格納できる配列.
            String[] aryKyokuCd = new String[_spdDetailInput_Sheet1.RowCount];
            aryKyokuCd[0] = firstKyokuCd;
            int countKyokuCd = 1;
            bool flg = true;
            /* 2013/01/29 JSE A.Naito MOD End*/

            //明細入力の件数分、繰り返す.
            for (int detailInputRowIndex = 0; detailInputRowIndex < _spdDetailInput_Sheet1.RowCount; detailInputRowIndex++)
            {
                //テレビタイム、テレビネットスポットの場合かつ、局コードの先頭1文字が一致しない場合は表示しない.
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true)
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                {
                    //局コードに値がある場合.
                    if (!string.IsNullOrEmpty(firstKyokuCd))
                    {
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                        /* 2013/01/29 JSE A.Naito MOD Start */
                        //if (firstKyokuCd.Substring(0, 1) != _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                        //{
                        //    //配列の要素数分繰り返す.
                        //    for (int i = 0; i < countKyokuCd; i++)
                        //    {
                        //        if (aryKyokuCd[i].Equals(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim()))
                        //        {
                        //            flg = false;
                        //            break;
                        //        }
                        //    }
                        //    if (flg)
                        //    {
                        //        //1行追加する.
                        //        spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                        //        //局コードコンボボックス作成.
                        //        setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                        //        //局コードコンボボックス初期値設定.
                        //        spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                        //            = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        //        //チェックボックス生成.
                        //        for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                        //        {
                        //            setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                        //        }
                        //        //配列の最後に局コードを追加.
                        //        aryKyokuCd[countKyokuCd] = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        //        countKyokuCd += 1;
                        //    }
                        //}
                        /* 2013/01/29 JSE A.Naito MOD End */
                        ////if (firstKyokuCd.Substring(0, 1) !=_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                        ////{
                        ////    //1行追加する.
                        ////    spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                        ////    //局コードコンボボックス作成.
                        ////    setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                        ////    //局コードコンボボックス初期値設定.
                        ////    spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                        ////        = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        ////    //チェックボックス生成.
                        ////    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                        ////    {
                        ////        setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                        ////    }
                        ////}
                        //局コードが存在する、2文字以上の場合.
                        if ((_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value != null) && (_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Length >2))
                        {
                            //明細1行目の局コードと明細入力シートの局コードが異なる場合.
                            if (firstKyokuCd.Substring(0, 1) != _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                            {
                                //配列の要素数分繰り返す.
                                for (int i = 0; i < countKyokuCd; i++)
                                {
                                    //局コードが同一の場合.
                                    if (aryKyokuCd[i].Equals(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim()))
                                    {
                                        flg = false;
                                        break;
                                    }
                                }
                                if (flg)
                                {
                                    //1行追加する.
                                    spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                                    //局コードコンボボックス作成.
                                    setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                                    //局コードコンボボックス初期値設定.
                                    spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                                        = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                                    //チェックボックス生成.
                                    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                                    {
                                        setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                                    }
                                    //配列の最後に局コードを追加.
                                    aryKyokuCd[countKyokuCd] = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                                    countKyokuCd += 1;
                                }
                            }
                        }
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                    }
                }

                /* 2013/01/29 JSE A.Naito ADD Start */ 
                //フラグをtrueに戻す.
                flg = true;

                //金額が空の場合は、"0"を入れる.
                if (_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text.Equals(""))
                {
                    _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text = "0"; 
                }
                /* 2013/01/29 JSE A.Naito ADD End */

                //見積金額の合計を加算.
                hnmaeGakGoukei += int.Parse(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
            }

            //初期設定.
            int shouhinColIndex = COLIDX_KLIST_SHOUHINCD_FIRST;
            decimal seiSoGokei = 0M;
            decimal seiShokei = 0M;
            int shohIdx = 1;
            int snziIdx = 0;
            bool bln = false;
            String hnshCd = String.Empty;
            //明細入力画面の行数分の商品コードを格納できる配列.
            String[] hnshCd2 = new String[_spdDetailInput_Sheet1.RowCount];

            //明細入力画面の見積額合計を算出する.
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //見積金額の合計を加算.
                seiSoGokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
            }

            //明細入力画面の件数分処理する.
            for (int j = 0; j < _spdDetailInput_Sheet1.RowCount; j++)
            {
                bln = false;

                /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                //明細入力画面の商品コードを取得.
                //hnshCd = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                if (_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                {
                    hnshCd = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                }else
                {
                    hnshCd = string.Empty;
                }

                //処理対象商品コードがすでに処理済みかチェック.
                if (hnshCd2.Length > 0)
                {
                    for (int i = 0; i < hnshCd2.Length; i++)
                    {
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                        //if (!String.IsNullOrEmpty(hnshCd2[i]))
                        //{
                        //    if (hnshCd2[i].Equals(hnshCd))
                        //    {
                        //        bln = true;
                        //    }
                        //}
                        if(hnshCd2[i] != null)
                        {
                            if (hnshCd2[i].Equals(hnshCd))
                            {
                                bln = true;
                            }
                        }
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                    }
                }

                //処理対象品種コード.
                if (!bln && j < _spdDetailInput_Sheet1.RowCount)
                {
                    //明細入力画面の件数分処理する.
                    for (int row = 0; row < _spdDetailInput_Sheet1.RowCount; row++)
                    {
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                        //object val = _spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value;
                        ////明細入力画面で同一の商品コードがある場合.
                        //if (hnshCd == val.ToString().Trim())
                        //{
                        //    //請求金額を合算する.
                        //    seiShokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
                        //}

                        object val = "";
                        if (_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                        {
                            val = _spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value;
                        }
                        if (hnshCd == val.ToString().Trim())
                        {
                            //請求金額を合算する.
                            seiShokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
                        }
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                    }
                }

                //初回.
                if (j == 0)
                {
                    //品種コード初期値設定.
                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, shohIdx].Value = hnshCd;

                    //明細入力．端数処理が"切上げ"の場合.
                    if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                    {
                        //配分率.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                        //端数区分.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                    }
                    //明細入力．端数処理が"切捨て"の場合.
                    else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                    {
                        //配分率.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                        //端数区分.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                    }
                    //上記以外の場合、配分率を算出する.
                    else
                    {
                        //明細入力．見積金額、明細入力．見積金額の合計が0以外の場合.
                        if (seiShokei != 0 && seiSoGokei != 0)
                        {
                            /*
                             * 配分率.
                             * 見積金額 / 見積金額の合計) * 100.
                             * ※小数部分がちょうど 0.5 の場合、最も近い偶数に値を丸める.
                             * 0.5→ 0、1.5 → 2
                             */
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                        }
                    }
                }
                else if (j > 0)
                {
                    //品種存在フラグ.
                    bool hnshFlg = false;
                    //存在インデックス.
                    snziIdx = 0;
                    for (int kCol = 1; kCol <= shohIdx; kCol++)
                    {
                        //すでに系列シートに同一の品種コードがすでにある場合.
                        if (hnshCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, kCol].Value))
                        {
                            hnshFlg = true;
                            snziIdx = kCol;
                        }
                    }

                    //品種存在フラグがtrueの場合.
                    if (hnshFlg)
                    {
                        //品種コード初期値設定.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, snziIdx].Value = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value;

                        //明細入力．端数処理が"切上げ"の場合.
                        if (KkhConstAsh.HasuKbn.ROUNDUP == _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim())
                        {
                            //配分率.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                            //端数区分.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, snziIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                        }
                        //明細入力．端数処理が"切捨て"の場合.
                        else if (KkhConstAsh.HasuKbn.ROUNDDOWN == _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim())
                        {
                            //配分率.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                            //端数区分.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, snziIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                        }
                        //上記以外の場合、配分率を算出する.
                        else
                        {
                            //明細入力．見積金額、明細入力．見積金額の合計が0以外の場合.
                            if (seiShokei != 0 && seiSoGokei != 0)
                            {
                                /*
                                 * 配分率.
                                 * 見積金額 / 見積金額の合計) * 100.
                                 * ※小数部分がちょうど 0.5 の場合、最も近い偶数に値を丸める.
                                 * 0.5→ 0、1.5 → 2
                                 */
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                            }
                        }
                    }
                    //まだ系列シートに無い品種コードの場合.
                    else
                    {
                        //品種(商品)コード列が1超過10以下の場合.
                        if (shohIdx >= 1 && shohIdx < 10)
                        {
                            //品種(商品)コード列インデックスを加算.
                            shohIdx++;

                            //品種コード初期値設定.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, shohIdx].Value = hnshCd;

                            //明細入力．端数処理が"切上げ"の場合.
                            if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //配分率.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value =
                                    Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //端数区分.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                            }
                            //明細入力．端数処理が"切捨て"の場合.
                            else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //配分率.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //端数区分.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                            }
                            //上記以外の場合、配分率を算出する.
                            else
                            {
                                //明細入力．見積金額、明細入力．見積金額の合計が0以外の場合.
                                if (seiShokei != 0 && seiSoGokei != 0)
                                {
                                    /*
                                     * 配分率.
                                     * 見積金額 / 見積金額の合計) * 100.
                                     * ※小数部分がちょうど 0.5 の場合、最も近い偶数に値を丸める.
                                     * 0.5→ 0、1.5 → 2.
                                     */
                                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                                }
                            }
                        }
                        //品種(商品)コード列が10以上の場合.
                        else if (shohIdx >= 10)
                        {
                            //品種コード初期値設定.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, COLIDX_KLIST_SHOUHINCD_END].Value = hnshCd;

                            //明細入力．端数処理が"切上げ"の場合.
                            if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //配分率.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //端数区分.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                            }
                            //明細入力．端数処理が"切捨て"の場合.
                            else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //配分率.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //端数区分.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                            }
                            //上記以外の場合、配分率を算出する.
                            else
                            {
                                //int hnmaeGak = int.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));

                                // 明細入力．見積金額、明細入力．見積金額の合計が0以外の場合.
                                if (seiShokei != 0 && seiSoGokei != 0)
                                {
                                    //配分率.
                                    //   見積金額 / 見積金額の合計) * 100.
                                    //   ※小数部分がちょうど 0.5 の場合、最も近い偶数に値を丸める.
                                    //      0.5→ 0、1.5 → 2
                                    //spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shouhinColIndex].Value = Math.Round((hnmaeGak  / hnmaeGakGoukei) * 100);
                                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                                }
                                //端数区分.
                                //spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = string.Empty;
                            }

                        }

                    }

                }

                //小計を初期化.
                seiShokei = 0M;

                //商品コードを保持しておく.
                hnshCd2[j] = hnshCd;
            }

            //チェックボックスの設定.
            //明細入力シートの行数分繰り返す.
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //系列シートの行数分繰り返す.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    int count = 0;
                    string dtlShohinCd = string.Empty;
                    //系列シートの商品コードに入力値がある列分繰り返す.
                    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= shohIdx; colIndex++)
                    {
                        //局コード行.
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                        //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value))
                        //{
                                /* 2013/01/29 JSE A.Naito MOD Start */
                                //明細行が9行以上の場合.
                                //if (colIndex > 9)
                                ////if (i > 9)
                                //{
                                    //品種(商品)コード列の最終列に入力値がある場合.
                                    //if (shohIdx == COLIDX_KLIST_SHOUHINCD_END)
                                    //{
                                    //    //局コードにチェックする.
                                    //    spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_END].Value = true;
                                    //}
                                    //else
                                    //{
                                    //明細と系列の品種(商品)列コードが同一の場合.
                                    //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //{
                                    //    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                    //}
                                    ////}
                        //局コードが設定がある場合.
                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value != null)
                        {
                            //局コードが一致.
                            if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value))
                            {
                                //明細行が9行以上の場合.
                                if (colIndex > 9)
                                {
                                    //明細と系列の品種(商品)列コードが同一の場合.
                                    if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                                    {
                                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                        {
                                            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                        }
                                    }
                                    else
                                    {
                                        if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value) == "")
                                        {
                                            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;

                                        }
                                    }
                                }
                                /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                                /* 2013/01/29 JSE A.Naito MOD End */
                                else
                                {
                                    //明細と系列の品種(商品)列コードが同一の場合.
                                    /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                                    //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //{
                                    //    //初回.
                                    //    if (count == 0)
                                    //    {
                                    //        spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                    //    }
                                    //    //初回以降.
                                    //    else if (count > 0)
                                    //    {
                                    //        if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //        {
                                    //            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                    //        }
                                    //    }
                                    //}
                                    if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                                    {
                                        //明細と系列の品種(商品)列コードが同一の場合.
                                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                        {
                                            //初回.
                                            if (count == 0)
                                            {
                                                spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                            }
                                            //初回以降.
                                            else if (count > 0)
                                            {
                                                if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                                {
                                                    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //明細と系列の品種(商品)列コードが同一の場合(空文字).
                                        if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value) == "")
                                        {
                                            //初回.
                                            if (count == 0)
                                            {
                                                spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                            }
                                            //初回以降.
                                            else if (count > 0)
                                            {
                                                if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                                {
                                                    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                                }
                                            }
                                        }
                                    }
                                    /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                                }
                            }
                        }
                        count++;
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD Start */
                        //dtlShohinCd = _spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                        {
                            dtlShohinCd = _spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                        }
                        /* 2013/02/01 明細1行目NUll対応 HLC T.Sonobe MOD End */
                    }
                }
            }
        }
        #endregion 各コントロールの編集処理.

        #region 局マスタ情報を設定する.
        /// <summary>
        /// 局マスタ情報を設定する.
        /// </summary>
        private void setKyokuInfo(string key)
        {
            //初期設定.
            MasterMaintenance.MasterDataVORow[] rows;
            List<string> lstKeys;
            List<string> lstValues;

            //局マスタ情報取得.
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            result = process.FindMasterByCond(_naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            key,
                                            "");
            MasterMaintenance.MasterDataVODataTable dt = result.MasterDataSet.MasterDataVO;
            //データテーブルのコピーを作成.
            MasterMaintenance.MasterDataVODataTable dt2 = (MasterMaintenance.MasterDataVODataTable)dt.Clone();
            DataView dv = new DataView(dt);
            dv.Sort = "Column1";
            foreach (DataRowView drv in dv)
            {
                dt2.ImportRow(drv.Row);
            }
            rows = (MasterMaintenance.MasterDataVORow[])dt2.Select();
            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column1 + " " + row.Column4 + " " + row.Column2);
            }

            //局マスタ情報設定.
            _itemKyokuCd = lstKeys.ToArray();
            _itemKyokuNm = lstValues.ToArray();
        }
        #endregion 局マスタ情報を設定する.

        #region 商品マスタ情報を設定する.
        /// <summary>
        /// 商品マスタ情報を設定する.
        /// </summary>
        private void setShouhinInfo()
        {
            //初期設定.
            MasterMaintenance.MasterDataVORow[] rows;
            List<string> lstKeys;
            List<string> lstValues;

            //商品マスタ情報取得.
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            result = process.FindMasterByCond(_naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SYOHIN,
                                            "");
            _dsShouhinInfo = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])_dsShouhinInfo.MasterDataVO.Select();
            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column1 + " " + row.Column2);
            }

            //商品マスタソート.
            lstKeys.Sort(); 
            lstValues.Sort(); 

            //商品マスタ情報設定.
            _itemShouhinCd = lstKeys.ToArray();
            _itemShouhinNm = lstValues.ToArray();
        }
        #endregion 商品マスタ情報を設定する.

        #region 端数区分情報を設定する.
        /// <summary>
        /// 端数区分情報を設定する.
        /// </summary>
        private void setHasuKbn()
        {
            //初期設定.
            List<string> lstKeys;
            List<string> lstValues;
            lstKeys = new List<string>();
            lstValues = new List<string>();

            lstKeys.Add(string.Empty);
            lstKeys.Add(KkhConstAsh.HasuKbn.ROUNDUP);
            lstKeys.Add(KkhConstAsh.HasuKbn.ROUNDDOWN);

            lstValues.Add(string.Empty);
            lstValues.Add(KkhConstAsh.HasuNm.ROUNDUP);
            lstValues.Add(KkhConstAsh.HasuNm.ROUNDDOWN);

            //テレビ局マスタ情報設定.
            _itemHasuKbnCd = lstKeys.ToArray();
            _itemHasuKbnNm = lstValues.ToArray();
        }
        #endregion 端数区分情報を設定する.

        #region コンボボックス設定.
        /// <summary>
        /// コンボボックス設定.
        /// </summary>
        private void setComboBox(int rowIndex, int colIndex, string[] keyArray, string[] nameArray)
        {
            ComboBoxCellType type = new ComboBoxCellType();
            type.ItemData = keyArray;
            type.Items = nameArray;
            type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            type.Editable = false;
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].CellType = type;
        }
        #endregion コンボボックス設定.

        #region チェックボックス設定.
        /// <summary>
        /// チェックボックス設定.
        /// </summary>
        private void setCheckBox(int rowIndex, int colIndex)
        {
            CheckBoxCellType type = new CheckBoxCellType();
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].CellType = type;
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].HorizontalAlignment = CellHorizontalAlignment.Center;
        }
        #endregion チェックボックス設定.

        #region 入力チェック.
        /// <summary>
        /// 入力チェック.
        /// </summary>
        private Boolean checkInput()
        {
            //初期設定.
            _shouhinCdCnt = 0;
            decimal delHaibunRituSum = 0;

            //商品コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //商品コード.
                String strShouhinCd = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim();

                //商品コードが未設定の場合.
                if (strShouhinCd.Equals(string.Empty))
                {
                    continue;
                }

                //商品コード件数をカウントアップ.
                _shouhinCdCnt++;

                //配分率を加算.
                if (spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value != null)
                {
                    delHaibunRituSum = delHaibunRituSum + decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                }
                //局コードの行数分、繰り返す.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //チェックなしの場合.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value == null || spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "False")
                    {
                        continue;
                    }
                    /* 2015/06/08 追加対応 HLC K.Fujisaki MOD Start */
                    //テレビタイム、テレビネットスポットの場合.
                    //if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd))
                    if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)|| KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd))
                    /* 2015/06/08 追加対応 HLC K.Fujisaki MOD End */
                    {
                        //重複チェック.
                        String strKyokuCode = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value).Trim();
                        if (!checkDuplication(colIndex, rowIndex, strShouhinCd, strKyokuCode))
                        {
                            //エラーメッセージを表示.
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0068, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            //商品が1件も選択されていない場合.
            if (_shouhinCdCnt == 0)
            {
                return false;
            }

            //配分率の合計が100以外の場合.
            if (delHaibunRituSum != 100)
            {
                //エラーメッセージを表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0074, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                return false;
            }

            _bunbo = 0;
            _haibunrituArray = new decimal[_shouhinCdCnt];
            //商品コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                if (spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value == null || decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim()) == 0)
                {
                    //エラーメッセージを表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0076, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    return false;
                }

                //配分率を配列に格納.
                _haibunrituArray[colIndex - 1] = decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                //分母を加算.
                _bunbo = _bunbo + decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
            }

            _hasuKbn = new String[_shouhinCdCnt];
            //商品コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                //初期設定.
                decimal delHaibunRitu = decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                decimal delHaibunRituRoundDown = Math.Floor(delHaibunRitu);
                _hasuKbn[colIndex - 1] = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim();

                //小数点以下の入力ありで、かつ端数区分を設定していない場合.
                if (delHaibunRitu != delHaibunRituRoundDown && KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim().Equals(string.Empty))
                {
                    //エラーメッセージを表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0057, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    return false;
                }

                //端数区分を設定していない商品コード列より前に、端数区分を設定している商品コード列がある場合.
                for (int i = COLIDX_KLIST_SHOUHINCD_FIRST; i <= colIndex - 1; i++)
                {
                    if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim().Equals(string.Empty) && !KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, i].Value).Trim().Equals(string.Empty)){
                        //エラーメッセージを表示.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0057, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion 入力チェック.

        #region 重複チェック.
        /// <summary>
        /// 重複チェック.
        /// </summary>
        private Boolean checkDuplication(int intSubjectColIndex, int intSubjectRowIndex, String strShouhinCd, String strKyokuCode)
        {
            //商品コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //商品コードが未設定の場合.
                if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim().Equals(string.Empty))
                {
                    continue;
                }
                //局コードの行数分、繰り返す.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //チェックなしの場合.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value == null || spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "False")
                    {
                        continue;
                    }
                    //重複チェック対象のセルの場合.
                    if (colIndex == intSubjectColIndex && rowIndex == intSubjectRowIndex)
                    {
                        continue;
                    }
                    if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim().Equals(strShouhinCd) && KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value).Trim().Equals(strKyokuCode))
                    {
                        //重複あり.
                        return false;
                    }
                }
            }

            //重複なし.
            return true;
        }
        #endregion 重複チェック.

        #region 明細入力画面編集.
        /// <summary>
        /// 明細入力画面編集.
        /// </summary>
        private void editDetailInput()
        {
            /* 2014/08/15 HLC 張(JANG) ADD Start */
            DetailDSAsh.KeyKyokuBangumiCdDataTable dtKKBC = null;
            //アサヒビールでテレビタイム、またはテレビネットスポットの場合、使うマスターの情報を取得.
            if (_naviParam.strTksKgyCd == UserManualHelper.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6) 
                && (_naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                || _naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT))
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
            {
                // マスターからキー局の番組コードを取得.
                DetailAshProcessController processController = DetailAshProcessController.GetInstance();
                DetailAshProcessController.KeyKyokuBangumiCdParam param = new DetailAshProcessController.KeyKyokuBangumiCdParam();
                param.egCd = _naviParam.strEgcd;
                param.tksKgyCd = _naviParam.strTksKgyCd;
                param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                param.baitaiCd = Isid.KKH.Ash.View.Report.ReportAshByMedium.KYKCD_TV;

                FindKeyKyokuBangumiCdServiceResult result = processController.FindKeyKyokuBangumiCd(param);
                dtKKBC = result.DetailAshDataSet.KeyKyokuBangumiCd;
            }
            /* 2014/08/15 HLC 張(JANG) ADD End */
            
            //複数行ある場合.
            if (_spdDetailInput_Sheet1.RowCount > 1)
            {
                //先頭行以外を削除.
                _spdDetailInput_Sheet1.RemoveRows(1, _spdDetailInput_Sheet1.RowCount - 1);
            }
            //局コード件数カウンタ.
            int kyokuCdCnt = 0;

            //商品コード列数分、繰り返す.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                //局コードの行数分、繰り返す.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //チェックありの場合.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value != null && spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "True")
                    {
                        //明細入力画面の行追加(1行追加する).
                        _spdDetailInput_Sheet1.AddRows(_spdDetailInput_Sheet1.RowCount, 1);

                        //明細入力スプレッドの列数分、繰り返す.
                        for (int detailInputColIndex = 0; detailInputColIndex <= DetailInputAsh.COLIDX_KEYKYOKUCD; detailInputColIndex++)
                        {
                            //数値項目の場合.
                            if (detailInputColIndex == DetailInputAsh.COLIDX_HNMAEGAK ||
                                detailInputColIndex == DetailInputAsh.COLIDX_HNNERT ||
                                detailInputColIndex == DetailInputAsh.COLIDX_SEIGAK ||
                                detailInputColIndex == DetailInputAsh.COLIDX_ZEIRITSU ||
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD Start */
                                detailInputColIndex == DetailInputAsh.COLIDX_NEBIKIGAKU ||
                                detailInputColIndex == DetailInputAsh.COLIDX_ZEIGAKU ||
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD End */
                                detailInputColIndex == DetailInputAsh.COLIDX_HASUUSYORIKBN ||
                                detailInputColIndex == DetailInputAsh.COLIDX_NYUURYOKUHIRITSU)
                            {
                                //Oで初期化.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, detailInputColIndex].Value = 0;
                            }

                            /* 2014/08/15 HLC 張(JANG) ADD Start */
                            // アサヒビールのテレビタイム、テレビネットスポットの場合、番組コードを設定.
                            else if (detailInputColIndex == DetailInputAsh.COLIDX_BANGUMICD &&
                                _naviParam.strTksKgyCd == UserManualHelper.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6) 
                                && (_naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                                || _naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT))
                                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                            {
                                // 受注データにキー局が設定されてない場合の番組コードは各行の放送局のキー局のコードを設定.
                                if (_dataRow.hb1Field1 == "")
                                {
                                    DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                                        Select("KYOKUCD = '" + spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value + "'");
                                    _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                }
                                // 受注データにキー局が設定されている場合はすべての行の番組コードにそのキー局のコードを設定.
                                else
                                {
                                    DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                                        Select("KYOKURYAKUSYOU = '" + _dataRow.hb1Field1.Trim() + "'");
                                    /* 2015/06/08 HLC K.Fujisaki MOD Start */
                                    //_spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                    if (rowKKBC.Length == 0)
                                    {
                                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = "";
                                    }
                                    else
                                    {
                                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                    }
                                    /* 2015/06/08 HLC K.Fujisaki MOD End */
                                }
                            }
                            /* 2014/08/15 HLC 張(JANG) ADD End */

                            //上記以外の場合.
                            else
                            {
                                //明細入力画面の先頭行の値を設定.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, detailInputColIndex].Value = _spdDetailInput_Sheet1.Cells[0, detailInputColIndex].Value;
                            }
                        }

                        //局コード設定.
                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_KYOKUCD].Value = spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value;

                        //商品コード設定.
                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HINSYUCD].Value = spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value;

                        if (kyokuCdCnt == 0)
                        {
                            //見積金額.
                            decimal delSeikyu = _dataRow.hb1ToriGak;
                            decimal delCurResult = delSeikyu * _haibunrituArray[colIndex - 1] / _bunbo;

                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD Start */
                            //値引額.
                            decimal delNebikiGaku = _dataRow.hb1NeviGak * _haibunrituArray[colIndex - 1] / _bunbo;
                            //消費税額.
                            decimal delZeiGaku = _dataRow.hb1SzeiGak * _haibunrituArray[colIndex - 1] / _bunbo;
                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD End */

                            //切り上げ.
                            if (_hasuKbn[colIndex - 1].Equals(KkhConstAsh.HasuKbn.ROUNDUP))
                            {
                                //見積金額.
                                delCurResult = Math.Truncate(delCurResult + new decimal(0.9));
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD Start */
                                //値引額.
                                delNebikiGaku = Math.Truncate(delNebikiGaku + new decimal(0.9));
                                //消費税額.
                                delZeiGaku = Math.Truncate(delZeiGaku + new decimal(0.9));
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD End */
                            }
                            //切り捨て.
                            else if (_hasuKbn[colIndex - 1].Equals(KkhConstAsh.HasuKbn.ROUNDDOWN))
                            {
                                //見積金額.
                                delCurResult = Math.Truncate(delCurResult);
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD Start */
                                //値引額.
                                delNebikiGaku = Math.Truncate(delNebikiGaku);
                                //消費税額.
                                delZeiGaku = Math.Truncate(delZeiGaku);
                                /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD End */
                            }
                            //設定なし.
                            else
                            {
                            }

                            //見積金額.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HNMAEGAK].Value = delCurResult;
                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD Start */
                            //値引額.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_NEBIKIGAKU].Value = delNebikiGaku;
                            //消費税額.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_ZEIGAKU].Value = delZeiGaku;
                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga ADD End */

                            //端数区分が空でない場合.
                            if (_hasuKbn[colIndex - 1] != "") 
                            {
                                //端数処理区分.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HASUUSYORIKBN].Value = _hasuKbn[colIndex - 1];
                                //入力比率.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Value = _haibunrituArray[colIndex - 1];
                            }

                            //値引率.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HNNERT].Value = _dataRow.hb1NeviRitu.ToString().Trim();
                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga MOD Start */
                            //請求金額(見積金額 - 値引額).
                            //_spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_SEIGAK].Value = Math.Truncate(delCurResult - (delCurResult * (_dataRow.hb1NeviRitu / 100)));
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_SEIGAK].Value = Math.Truncate(delCurResult - delNebikiGaku);
                            /* 2016/12/19 アサヒ消費税対応 HLC K.Soga MOD End */
                            //消費税率.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_ZEIRITSU].Value = _dataRow.hb1SzeiRitu.ToString().Trim();
                        }

                        //局コード件数カウンタの更新.
                        kyokuCdCnt++;
                    }
                }

                //局コード件数カウンタの初期化.
                kyokuCdCnt = 0;
            }

            //先頭行を削除(編集用に使用).
            _spdDetailInput_Sheet1.RemoveRows(0, 1);
        }
        #endregion 明細入力画面編集.
        #endregion メソッド.
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// 並び順画面（スカパー） 
    /// </summary>
    public partial class DetailOrderSkyp : Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "OderSkyp";
        /// <summary>
        /// 媒体区分列インデックス 
        /// </summary>
        private const int COLIDX_BAITAI_KUBUN = 0;
        /// <summary>
        /// 媒体名称列インデックス 
        /// </summary>
        private const int COLIDX_BAITAI_MEISYO = 1;
        /// <summary>
        /// 発行／期間列インデックス 
        /// </summary>
        private const int COLIDX_HAKKO_KIKAN = 2;
        /// <summary>
        /// 金額列インデックス 
        /// </summary>
        private const int COLIDX_KINGAKU = 3;
        /// <summary>
        /// 消費税額列インデックス 
        /// </summary>
        private const int COLIDX_SYOHIZEIGAKU = 4;
        /// <summary>
        /// 請求金額列インデックス 
        /// </summary>
        private const int COLIDX_SEIKYU_KINGAKU = 5;
        /// <summary>
        /// 並び順列インデックス 
        /// </summary>
        private const int COLIDX_NARABI_JUN = 6;

        #endregion 定数 

        #region メンバ変数 
        
        /// <summary>
        /// 並び順画面（スカパー）パラメータ 
        /// </summary>
        private DetailOrderSkypNaviParameter _naviParameter = new DetailOrderSkypNaviParameter();

        /// <summary>
        /// 文字エンコーディング 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// データモデル 
        /// </summary>
        private DefaultSheetDataModel _dataModel;

        /// <summary>
        /// ユーザーによる閉じる要求か（Navigator.Backwardの直前でtrueに設定する事）.
        /// </summary>
        private Boolean _userCloseRequest = false;

        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailOrderSkyp()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdOrder_Sheet1.Models.Data;
        }

        #endregion コンストラクタ 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailOrderSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is DetailOrderSkypNaviParameter)
            {
                _naviParameter = (DetailOrderSkypNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOrderSkyp_Load(object sender, EventArgs e)
        {
            InitializeControl();
            InitializeDisplayKkhDetail();
        }

        /// <summary>
        /// フォームShownイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOrderSkyp_Shown(object sender, EventArgs e)
        {
            _dataModel.Changed += new SheetDataModelEventHandler(dataModel_Changed);
        }

        /// <summary>
        /// 登録ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 確認メッセージ表示 
            DialogResult ret = MessageUtility.ShowMessageBox(MessageCode.HB_C0002
                                                , null
                                                , "明細登録"
                                                , MessageBoxButtons.YesNo);
            if (ret == DialogResult.No) 
            {
                //選択状態を解除 
                this.ActiveControl = null;

                return; 
            }

            // 並び順重複チェック 
            if (!CheckOrderData()) { return; }

            // 並び順データ更新 
            if (UpdateOrderData())
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0011
                                ,null
                                , "明細登録"
                                , MessageBoxButtons.OK);
            }
            else
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0008
                                ,null
                                , "明細登録"
                                , MessageBoxButtons.OK);
            }

            // オペレーションログの出力.
            KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_ORDER, KKHLogUtilitySkyp.DESC_OPERATION_LOG_ORDER);

            // ユーザーによる閉じる要求である
            _userCloseRequest = true;

            Navigator.Backward(this, true, null, true);
        }

        /// <summary>
        /// 戻るボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // ユーザーによる閉じる要求である
            _userCloseRequest = true;

            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 並び順スプレッド内のセルでテキストを変更するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            // TextCellTypeの場合は最大バイト数の編集処理を行う 
            if (_spdOrder_Sheet1.Columns[e.Column].CellType is TextCellType)
            {
                TextCellType tc = (TextCellType)_spdOrder_Sheet1.Columns[e.Column].CellType;
                e.EditingControl.Text = e.EditingControl.Text.Trim('.');
                e.EditingControl.Text = e.EditingControl.Text.Trim('-');
                //"5-5"のような場合に対応 
                e.EditingControl.Text = e.EditingControl.Text.Replace(".", "");
                e.EditingControl.Text = e.EditingControl.Text.Replace("-", "");
                string s = e.EditingControl.Text;
                if (_enc.GetByteCount(s) > tc.MaxLength)
                {
                    e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                    ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                }
            }
        }

        /// <summary>
        /// データモデルChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            // 非編集状態でクリップボードから貼り付けした場合 
            if (e.Type == SheetDataModelEventType.CellsUpdated)
            {
                try
                {
                    // TextCellTypeの場合のみ処理を行う 
                    if (_spdOrder_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdOrder_Sheet1.Columns[e.Column].CellType;
                        string s = _dataModel.GetValue(e.Row, e.Column).ToString();
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            s = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            _dataModel.SetValue(e.Row, e.Column, s);
                        }
                    }
                }
                catch
                {
                    // 何もしない 
                }
            }
        }

        private void DetailOrderSkyp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_userCloseRequest)
            {
                // 閉じるボタンによる要求なのでキャンセルする.
                e.Cancel = true;

                // 閉じる要求フラグを設定.
                _userCloseRequest = true;

                // 改めてフレームワークによる閉じる要求を出す.
                Navigator.Backward(this, null, null, true);
            }
        }


        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            InputMap im = new InputMap();

            // 非編集セルでの[F2]キーを無効 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // 編集中セルでの[F2]キーを無効 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // 非編集セルでの[Enter]キーを「次行へ移動」 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // 編集中セルでの[Enter]キーを「次行へ移動」 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // 非編集セルでの[Z]キー+[Control]キーを無効 
            im = spdOrder.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // 編集中セルでの[Z]キー+[Control]キーを無効 
            im = spdOrder.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);
        }

        /// <summary>
        /// 並び順スプレッドにデータを表示する 
        /// </summary>
        private void InitializeDisplayKkhDetail()
        {
            DetailSkypProcessController.FindOrderDataByCondParam param =
                new DetailSkypProcessController.FindOrderDataByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;
            param.baitaikbn = string.Empty;
            // 並び順データ検索 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            FindOrderByCondServiceResult result = processController.FindOrderDataByCond(param);

            if (result.HasError == true)
            {
                return;
            }

            _dsDetailSkyp.OrderData.Clear();
            _dsDetailSkyp.OrderData.Merge(result.DetailDataSet.OrderData);
            _dsDetailSkyp.OrderData.AcceptChanges();
        }

        /// <summary>
        /// 並び順重複チェック 
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckOrderData()
        {
            // 同一媒体の並び順チェック 
            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                string baitaiKbn = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text;
                string narabiJun = _spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text;

                for (int jRow = iRow + 1; jRow < _spdOrder_Sheet1.Rows.Count; jRow++)
                {
                    string baitaiKbn2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_BAITAI_KUBUN].Text;
                    string narabiJun2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_NARABI_JUN].Text;


                    // 同一媒体区分である場合 
                    if (baitaiKbn.Equals(baitaiKbn2))
                    {
                        // 同一並び順でない場合エラー 
                        if (!narabiJun.Equals(narabiJun2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0069
                                            , null
                                            , "明細登録"
                                            , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            // 同一媒体でない並び順チェック 
            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                string baitaiKbn = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text;
                string narabiJun = _spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text;

                for (int jRow = iRow + 1; jRow < _spdOrder_Sheet1.Rows.Count; jRow++)
                {
                    string baitaiKbn2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_BAITAI_KUBUN].Text;
                    string narabiJun2 = _spdOrder_Sheet1.Cells[jRow, COLIDX_NARABI_JUN].Text;

                    // 並び順が設定されていない場合は読み飛ばす 
                    if (string.IsNullOrEmpty(narabiJun2))
                    {
                        continue;
                    }

                    // 同一媒体区分でない場合 
                    if (!baitaiKbn.Equals(baitaiKbn2))
                    {
                        // 同一並び順の場合エラー 
                        if (narabiJun.Equals(narabiJun2)
                            && !string.IsNullOrEmpty(narabiJun)
                            && !string.IsNullOrEmpty(narabiJun2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0085
                                            , null
                                            , "明細登録"
                                            , MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 並び順データ更新 
        /// </summary>
        /// <returns>処理結果</returns>
        private bool UpdateOrderData()
        {
            DetailSkypProcessController.UpdateOrderDataParam param =
                new DetailSkypProcessController.UpdateOrderDataParam();

            // 並び順データ更新パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;

            string[] baitaiNm = new string[_spdOrder_Sheet1.Rows.Count];
            string[] baitaiKbn = new string[_spdOrder_Sheet1.Rows.Count];
            string[] narabiJun = new string[_spdOrder_Sheet1.Rows.Count];
            int narabijyun = 0;

            for (int iRow = 0; iRow < _spdOrder_Sheet1.Rows.Count; iRow++)
            {
                if (!string.IsNullOrEmpty(_spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text.Trim()))
                {
                    narabijyun = KKHUtility.IntParse(_spdOrder_Sheet1.Cells[iRow, COLIDX_NARABI_JUN].Text.Trim());
                    narabiJun[iRow] = narabijyun.ToString("000");
                }
                else
                {
                    narabiJun[iRow] = " ";
                }
                // シングルクォーテーションのエスケープ 
                // 「'(シングルクォーテーション)」を「''(シングルクォーテーション二つ)」に置換した値を設定する 
                baitaiNm[iRow] = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_MEISYO].Text.Trim().Replace("\'", "\'\'");
                baitaiKbn[iRow] = _spdOrder_Sheet1.Cells[iRow, COLIDX_BAITAI_KUBUN].Text.Trim().Replace("\'", "\'\'");
            }
            param.order = narabiJun;
            param.baitaiNm = baitaiNm;
            param.baitaiKbn = baitaiKbn;

            // 並び順データ更新 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            UpdateOrderServiceResult result = processController.UpdateOrderData(param);

            if (result.HasError == true)
            {
                return false;
            }
            return true;
        }
        
        #endregion メソッド 

    }
}
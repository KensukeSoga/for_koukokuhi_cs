using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.ProcessController.Detail;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.Utility;
using KKHUserManual.Helper;
using drJyutyuData = Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow;
using dtKkhDetailInput = Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputDataTable;
using drKkhDetailInput = Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow;
using dtMasterDataVO = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable;
using drMasterDataVORow = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow;
using drKkhDetail = Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailRow;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// 明細入力画面.
    /// </summary>
    public partial class DetailInputAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.
        #region 入力明細スプレッド列インデックス.
        /// <summary>
        ///  請求書番号.
        /// </summary>
        public const int COLIDX_SEINO = 0;
        /// <summary>
        ///  件名.
        /// </summary>
        public const int COLIDX_KENMEI = 1;
        /// <summary>
        ///  局コード.
        /// </summary>
        public const int COLIDX_KYOKUCD = 2;
        /// <summary>
        ///  品種コード.
        /// </summary>
        public const int COLIDX_HINSYUCD = 3;
        /// <summary>
        ///  費目名称.
        /// </summary>
        public const int COLIDX_HIMOKUNM = 4;
        /// <summary>
        ///  見積金額.
        /// </summary>
        public const int COLIDX_HNMAEGAK = 5;
        /// <summary>
        ///  値引率.
        /// </summary>
        public const int COLIDX_HNNERT = 6;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        /// <summary>
        ///  値引額.
        /// </summary>
        public const int COLIDX_NEBIKIGAKU = 7;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        /// <summary>
        ///  請求金額.
        /// </summary>
        public const int COLIDX_SEIGAK = 8;
        /// <summary>
        ///  消費税率.
        /// </summary>
        public const int COLIDX_ZEIRITSU = 9;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        /// <summary>
        ///  消費税額.
        /// </summary>
        public const int COLIDX_ZEIGAKU = 10;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        /// <summary>
        ///  期間.
        /// </summary>
        public const int COLIDX_KIKAN = 11;
        /// <summary>
        ///  媒体コード.
        /// </summary>
        public const int COLIDX_BAITAICD = 12;
        /// <summary>
        ///  得意先媒体コード.
        /// </summary>
        public const int COLIDX_TOKUIBAITAICD = 13;
        /// <summary>
        ///  代理店コード.
        /// </summary>
        public const int COLIDX_DAIRITENCD = 14;
        /// <summary>
        ///  番組コード.
        /// </summary>
        public const int COLIDX_BANGUMICD = 15;
        /// <summary>
        ///  売上明細No.
        /// </summary>
        public const int COLIDX_URIMEINO = 16;
        /// <summary>
        ///  秒数.
        /// </summary>
        public const int COLIDX_BYOUSUU = 17;
        /// <summary>
        ///  本数.
        /// </summary>
        public const int COLIDX_HONSUU = 18;
        /// <summary>
        ///  表示順.
        /// </summary>
        public const int COLIDX_HYOUZIJUN = 19;
        /// <summary>
        ///  掲載・発売日.
        /// </summary>
        public const int COLIDX_KEISAIHATSUBAIBI = 20;
        /// <summary>
        ///  朝夕区分.
        /// </summary>
        public const int COLIDX_ASAYUUKBN = 21;
        /// <summary>
        ///  記雑区分.
        /// </summary>
        public const int COLIDX_KIZATSUKBN = 22;
        /// <summary>
        ///  掲載版.
        /// </summary>
        public const int COLIDX_KEISAIBAN = 23;
        /// <summary>
        ///  端数処理区分.
        /// </summary>
        public const int COLIDX_HASUUSYORIKBN = 24;
        /// <summary>
        ///  入力比率.
        /// </summary>
        public const int COLIDX_NYUURYOKUHIRITSU = 25;
        /// <summary>
        ///  スペース.
        /// </summary>
        public const int COLIDX_SPACE = 26;
        /// <summary>
        ///  放送時間.
        /// </summary>
        public const int COLIDX_HOUSOUZIKAN = 27;
        /// <summary>
        ///  曜日.
        /// </summary>
        public const int COLIDX_YOUBI = 28;
        /// <summary>
        ///  局ネット数.
        /// </summary>
        public const int COLIDX_KYOKUNETSUU = 29;
        /// <summary>
        ///  キー局コード.
        /// </summary>
        public const int COLIDX_KEYKYOKUCD = 30;
        /// <summary>
        ///  FD明細.
        /// </summary>
        public const int COLIDX_FD = 31;
        #endregion 入力明細スプレッド列インデックス.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// 引数.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 選択受注ダウンロード行データ.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// 表示受注ダウンロードデータテーブル.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable _dtJyutyuData = null;
        /// <summary>
        /// 明細データ.
        /// </summary>
        private FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1 = null;
        /// <summary>
        /// 広告費明細データ.
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable _dtKkhDetail = null;
        /// <summary>
        /// 対象媒体コード.
        /// </summary>
        private string _targetBaitaiCd = null;
        /// <summary>
        /// マスタメンテナンスデータセット.
        /// </summary>
        MasterMaintenance MstDS = new MasterMaintenance();
        /// <summary>
        /// マスタデータ.
        /// </summary>
        Hashtable htMasterData = new Hashtable();
        /// <summary>
        /// コードマスタデータ.
        /// </summary>
        Hashtable htCommonCodeMasterData = new Hashtable();
        /// <summary>
        /// ユーザーによる閉じる要求か(Navigator.Backwardの直前でtrueに設定する事).
        /// </summary>
        private Boolean _userCloseRequest = false;
        /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start */
        /// <summary>
        /// 得意先媒体コード－内部媒体コードの変換処理クラス.
        /// </summary>
        private AshBaitaiUtility _baitaiUtil;
        /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End */
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region フォームロードイベント.
        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputAsh_Load(object sender, EventArgs e)
        {
            //各コントロールの初期化.
            InitializeControl();

            //各コントロールの編集.
            editControl();
        }
        #endregion フォームロードイベント.

        #region 画面遷移時に実行される.
        /// <summary>
        /// 画面遷移時に実行される.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //ナビパラが空の場合.
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRow;
                _dtJyutyuData = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable)_naviParam.DataTable2;
                _dtKkhDetail = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)_naviParam.DataTable1;
                _targetBaitaiCd = _naviParam.StrValue1;
                spdKkhDetail_Sheet1 = _naviParam.SpdDetailInput_Sheet1;

                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start */
                _baitaiUtil = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End */
            }
        }
        #endregion 画面遷移時に実行される.

        #region OKボタンクリックイベント.
        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //OKボタンクリック時の入力チェックがfalseの場合、何もしない.
            bool CheckBaitaiFlag = false;
            if (!CheckBtnOK(out CheckBaitaiFlag))
            {
                return;
            }

            //ナビパラメーターの取得.
            KKHNaviParameter outNaviParam = new KKHNaviParameter();

            //必要な情報を入力していない場合は空のデータテーブルを返す.
            DetailDSAsh.KkhDetailDataTable dtKkhDetail = new DetailDSAsh.KkhDetailDataTable();

            //初期設定.
            string bfUriMeiNo = String.Empty;
            int fdSeq = -1;
            object cellValue = null;

            //入力明細件数分ループ処理.
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                //件名が空の場合返さない.
                if (string.IsNullOrEmpty(spdDetailInput_Sheet1.Cells[i, COLIDX_KENMEI].Text.Trim()))
                {
                    continue;
                }

                DetailDSAsh.KkhDetailRow addRow = dtKkhDetail.NewKkhDetailRow();
                //請求書番号.
                addRow.seiNo = spdDetailInput_Sheet1.Cells[i, COLIDX_SEINO].Text;
                //件名.
                addRow.kenmei = spdDetailInput_Sheet1.Cells[i, COLIDX_KENMEI].Text;
                //局コード.
                addRow.kyokuCd = spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUCD].Text;
                //品種コード.
                addRow.hinsyuCd = spdDetailInput_Sheet1.Cells[i, COLIDX_HINSYUCD].Text;
                //費目名称.
                addRow.himokuNm = spdDetailInput_Sheet1.Cells[i, COLIDX_HIMOKUNM].Text;
                //見積金額.
                /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD Start */
                //見積金額が空の場合.
                if (string.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value).Trim()))
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value = 0M;
                }
                /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD End */
                addRow.hnmaeGak = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value.ToString());
                //値引率.
                addRow.hnNeRt = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_HNNERT].Text);
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //値引額.
                addRow.nebikiGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_NEBIKIGAKU].Text);
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //請求金額.
                addRow.seiGak = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_SEIGAK].Text);
                //消費税率.
                addRow.zeiRitsu = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_ZEIRITSU].Text);
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //消費税額.
                addRow.zeiGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_ZEIGAKU].Text);
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //期間.
                addRow.kikan = spdDetailInput_Sheet1.Cells[i, COLIDX_KIKAN].Text;
                //媒体コード.
                addRow.baitaiCd = spdDetailInput_Sheet1.Cells[i, COLIDX_BAITAICD].Text;
                //代理店コード.
                addRow.dairitenCd = spdDetailInput_Sheet1.Cells[i, COLIDX_DAIRITENCD].Text;
                //番組コード.
                addRow.bangumiCd = spdDetailInput_Sheet1.Cells[i, COLIDX_BANGUMICD].Text;
                //売上明細No.
                addRow.uriMeiNo = spdDetailInput_Sheet1.Cells[i, COLIDX_URIMEINO].Text;
                //秒数.
                addRow.byouSuu = spdDetailInput_Sheet1.Cells[i, COLIDX_BYOUSUU].Text;
                //本数.
                addRow.honSuu = spdDetailInput_Sheet1.Cells[i, COLIDX_HONSUU].Text;
                //表示順.
                addRow.hyouziJun = spdDetailInput_Sheet1.Cells[i, COLIDX_HYOUZIJUN].Text;
                //掲載発売日.
                addRow.keisaiHatsubaiBi = spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIHATSUBAIBI].Text;
                //朝夕区分.
                cellValue = spdDetailInput_Sheet1.Cells[i, COLIDX_ASAYUUKBN].Value;
                if (!string.IsNullOrEmpty(KKHUtility.ToString(cellValue).Trim()))
                {
                    addRow.asaYuuKbn = cellValue.ToString();
                }
                else
                {
                    addRow.asaYuuKbn = string.Empty;
                }
                //記雑区分.
                cellValue = spdDetailInput_Sheet1.Cells[i, COLIDX_KIZATSUKBN].Value;
                if (!string.IsNullOrEmpty(KKHUtility.ToString(cellValue).Trim()))
                {
                    addRow.kizatsuKbn = cellValue.ToString();
                }
                else
                {
                    addRow.kizatsuKbn = string.Empty;
                }
                //掲載版.
                cellValue = spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIBAN].Value;
                if (!string.IsNullOrEmpty(KKHUtility.ToString(cellValue).Trim()))
                {
                    addRow.keisaiBan = cellValue.ToString();
                }
                else
                {
                    addRow.keisaiBan = string.Empty;
                }
                //端数処理区分.
                addRow.hasuuSyoriKbn = spdDetailInput_Sheet1.Cells[i, COLIDX_HASUUSYORIKBN].Text;
                //入力比率.
                addRow.nyuuryokuHiritsu = spdDetailInput_Sheet1.Cells[i, COLIDX_NYUURYOKUHIRITSU].Text;
                //スペース.
                addRow.space = spdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Text;
                //放送時間.
                addRow.housouZikan = spdDetailInput_Sheet1.Cells[i, COLIDX_HOUSOUZIKAN].Text;
                //曜日.
                addRow.youbi = spdDetailInput_Sheet1.Cells[i, COLIDX_YOUBI].Text;
                //局ネット数.
                addRow.kyokuNetSuu = spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUNETSUU].Text;
                //キー局コード.
                addRow.keyKyokuCd = spdDetailInput_Sheet1.Cells[i, COLIDX_KEYKYOKUCD].Text;
                //FD明細.
                addRow.fd = String.Empty;
                if (chkFDDetailOutput.Visible && chkFDDetailOutput.Checked)
                {
                    //売上明細No.
                    string uriMeiNo = spdDetailInput_Sheet1.Cells[i, COLIDX_URIMEINO].Text.Substring(0, 14);
                    if (bfUriMeiNo != uriMeiNo)
                    {
                        bfUriMeiNo = uriMeiNo;
                        fdSeq = GetFdSeq(uriMeiNo);
                        fdSeq++;
                    }
                    else
                    {
                        fdSeq++;
                    }
                    addRow.fd = fdSeq.ToString("0000000000");
                }
                else
                {
                    addRow.fd = string.Empty;
                }

                dtKkhDetail.AddKkhDetailRow(addRow);
             }

            outNaviParam.DataTable1 = dtKkhDetail;
            _userCloseRequest = true;
            Navigator.Backward(this, outNaviParam, null, true);
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

        #region 行挿入ボタンクリックイベント.
        /// <summary>
        /// 行挿入ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowInsert_Click(object sender, EventArgs e)
        {
            if (spdDetailInput_Sheet1.RowCount > 0)
            {
                int rowDetailIndex = spdDetailInput_Sheet1.ActiveRowIndex;
                spdDetailInput_Sheet1.AddRows(rowDetailIndex, 1);
                for (int i = 0; i < spdDetailInput_Sheet1.ColumnCount; i++)
                {
                    spdDetailInput_Sheet1.Cells[rowDetailIndex, i].Value = spdDetailInput_Sheet1.Cells[rowDetailIndex + 1, i].Value;
                }
            }
            else
            {
                spdDetailInput_Sheet1.AddRows(0, 1);
                spdDetailInput_Sheet1.Cells[0, COLIDX_BAITAICD].Value = cmbBaitai.SelectedValue.ToString();
                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start */
                spdDetailInput_Sheet1.Cells[0, COLIDX_TOKUIBAITAICD].Value = _baitaiUtil.ConvertOldCdToNewCd(cmbBaitai.SelectedValue.ToString()).baitaiCd;
                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End */
            }
        }
        #endregion 行挿入ボタンクリックイベント.

        #region 行削除ボタンクリックイベント.
        /// <summary>
        /// 行削除ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0)
            {
                return;
            }

            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, "明細登録", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            int rowIndex = spdDetailInput_Sheet1.ActiveRowIndex;
            spdDetailInput_Sheet1.RemoveRows(rowIndex, 1);
            _dsDetailAsh.KkhDetailInput.AcceptChanges();
        }
        #endregion 行削除ボタンクリックイベント.

        #region 系列展開ボタンクリックイベント.
        /// <summary>
        /// 系列展開ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupExpand_Click(object sender, EventArgs e)
        {
            //初期設定.
            string kyokuCd = string.Empty;
            string kyokuCd2 = string.Empty;
            string sozaiCd = string.Empty;
            string sozaiCd2 = string.Empty;
            string btCd = string.Empty;
            int i = 0;
            int j = 0;

            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0) {
                return;
            }

            //媒体コードを取得.
            String baitaiCd = cmbBaitai.SelectedValue.ToString();
            for (i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                //媒体コードを取得.
                kyokuCd = spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUCD].Text.ToString().Trim();
                if (kyokuCd == "")
                {
                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0145, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo);
                    if (check == DialogResult.Yes)
                    {
                        break;
                    }
                    else
                    {
                        return;
                    } 
                }

                btCd = spdDetailInput_Sheet1.Cells[i, COLIDX_BAITAICD].Text;
                /* 2015/06/08 HLC K.Fujisaki ADD Start */
                //テレビとラジオとテレビネットスポットの場合チェックを行う.
                if (btCd == KkhConstAsh.BaitaiCd.TV_TIME || btCd == KkhConstAsh.BaitaiCd.RADIO_TIME || btCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                {
                    kyokuCd = spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUCD].Text;
                    sozaiCd = spdDetailInput_Sheet1.Cells[i, COLIDX_HINSYUCD].Text;

                    //局・素材で１行ずつチェックを行う.
                    for (j = 0; j < spdDetailInput_Sheet1.RowCount; j++)
                    {
                        kyokuCd2 = spdDetailInput_Sheet1.Cells[j, COLIDX_KYOKUCD].Text;
                        sozaiCd2 = spdDetailInput_Sheet1.Cells[j, COLIDX_HINSYUCD].Text;

                        //同じ行でないときチェック.
                        if (i != j)
                        {
                            //同じ局、素材のデータがないかチェック.
                            if (kyokuCd.Equals(kyokuCd2) & (sozaiCd.Equals(sozaiCd2)))
                            {
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0068, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }
                }
                /* 2015/06/08 HLC K.Fujisaki ADD End */
            }         
            
            //ナビパラメータ設定.
            KKHNaviParameter naviParam = _naviParam;
            naviParam.BaitaiCd = baitaiCd;
            naviParam.SpdDetailInput_Sheet1 = spdDetailInput_Sheet1;
            //局選択画面表示.
            object result = Navigator.ShowModalForm(this, "toStationSelectAsh", naviParam);
            if (result == null)
            {
                return;
            }
        }
        #endregion 系列展開ボタンクリックイベント.

        #region 比率分割ボタンクリックイベント.
        /// <summary>
        /// 比率分割ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRateDivide_Click(object sender, EventArgs e)
        {
            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0)
            {
                return;
            }

            //フィルタによって表示されていない行が存在する場合は削除不可.
            ArrayList filteroutlist = spdDetailInput_Sheet1.RowFilter.GetFilteredOutRowList();

            if (!filteroutlist.Count.Equals(0))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0158, null, KKHSystemConst.KoteiMongon.DETAIL_INPUT, MessageBoxButtons.OK);
                return;
            }

            //ナビパラメータ設定.
            KKHNaviParameter naviParam = _naviParam;
            naviParam.SpdDetailInput_Sheet1 = spdDetailInput_Sheet1;
            naviParam.IntValue1 = 0;

            //比率入力画面表示.
            object result = Navigator.ShowModalForm(this, "toRatioInputAsh", naviParam);
            if (result == null)
            {
                return;
            }
        }
        #endregion 比率分割ボタンクリックイベント.

        #region 一括分割ボタンクリックイベント.
        /// <summary>
        /// 一括分割ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDivideAll_Click(object sender, EventArgs e)
        {
            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0)
            {
                return;
            }

            //フィルタによって表示されていない行が存在する場合は削除不可.
            ArrayList filteroutlist = spdDetailInput_Sheet1.RowFilter.GetFilteredOutRowList();

            if (!filteroutlist.Count.Equals(0))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0158, null, KKHSystemConst.KoteiMongon.DETAIL_INPUT, MessageBoxButtons.OK);
                return;
            }

            //ナビパラメータ設定.
            KKHNaviParameter naviParam = _naviParam;
            naviParam.SpdDetailInput_Sheet1 = spdDetailInput_Sheet1;
            naviParam.IntValue1 = 1;

            //比率入力画面表示.
            object result = Navigator.ShowModalForm(this, "toRatioInputAsh", naviParam);
            if (result == null)
            {
                return;
            }
        }
        #endregion 一括分割ボタンクリックイベント.

        #region 並べ替えボタンクリックイベント.
        /// <summary>
        /// 並べ替えボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            spdDetailInput_Sheet1.SortRows(DetailAsh.COLIDX_MLIST_HYOUJIJYUN, true, false);
        }
        #endregion 並べ替えボタンクリックイベント.

        #region 品種コード一括ボタンクリックイベント.
        /// <summary>
        /// 品種コード一括ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHinsyuCdIkkatsu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HINSYUCD].Value = cmbHinsyu.SelectedValue;
            }
        }
        #endregion 品種コード一括ボタンクリックイベント.

        #region 請求書番号一括ボタンクリックイベント.
        /// <summary>
        /// 請求書番号一括ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeikyusyoNoIkkatsu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_SEINO].Value = txtSeikyusyoNo.Text;
            }
        }
        #endregion 請求書番号一括ボタンクリックイベント.

        #region 設定ボタンクリックイベント.
        /// <summary>
        /// 設定ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailSet_Click(object sender, EventArgs e)
        {
            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0)
            {
                return;
            }

            //媒体コードを取得.
            String baitaiCd = string.Empty;
            if (cmbBaitai.SelectedValue == null)
            {
                return;
            }
            else
            {
                baitaiCd = cmbBaitai.SelectedValue.ToString();
            }

            //ナビパラメータ設定 
            KKHNaviParameter naviParam = _naviParam;
            naviParam.BaitaiCd = baitaiCd;
            naviParam.SpdDetailInput_Sheet1 = spdDetailInput_Sheet1;
            naviParam.DataTable1 = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)_dtKkhDetail;
            object result = null;

            //媒体コードがテレビタイム、ラジオタイム、テレビネットスポットの場合.
            if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(baitaiCd)
                || KkhConstAsh.BaitaiCd.RADIO_TIME.Equals(baitaiCd)
                /* 2015/06/08 HLC K.Fujisaki ADD Start */
                || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(baitaiCd))
                /* 2015/06/08 HLC K.Fujisaki ADD End */
            {
                //詳細設定(タイム)画面表示.
                result = Navigator.ShowModalForm(this, "toDetailSetTimeAsh", naviParam);
            }
            //媒体コードが新聞、雑誌の場合.
            else if (KkhConstAsh.BaitaiCd.SHINBUN.Equals(baitaiCd) || KkhConstAsh.BaitaiCd.ZASHI.Equals(baitaiCd))
            {
                //詳細設定(新聞・雑誌)画面表示.
                result = Navigator.ShowModalForm(this, "toDetailSetNpMzAsh", naviParam);
            }
            //媒体コードが上記以外の場合.
            else
            {
                //詳細設定(その他)画面表示.
                result = Navigator.ShowModalForm(this, "toDetailSetOthersAsh", naviParam);
            }

            if (result == null)
            {
                return;
            }

            //画面にセットする.
            for(int i = 0;i < naviParam.SpdDetailInput_Sheet1.RowCount;i++)
            {
                /*
                 * 媒体コードが[新聞][雑誌]の場合.
                 */
                //期間 
                if (KkhConstAsh.BaitaiCd.SHINBUN.Equals(baitaiCd) || KkhConstAsh.BaitaiCd.ZASHI.Equals(baitaiCd))
                {
                    //掲載日.
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIHATSUBAIBI].Text = FormatPeriod(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIHATSUBAIBI].Value.ToString());
                }
                else
                {
                    //期間.
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KIKAN].Text = FormatPeriod(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIHATSUBAIBI].Value.ToString());
                }
                //放送時間 
                if (string.IsNullOrEmpty(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_HOUSOUZIKAN].Value.ToString()))
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_HOUSOUZIKAN].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_HOUSOUZIKAN].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_HOUSOUZIKAN].Value.ToString();
                }
                //曜日 
                if (string.IsNullOrEmpty(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_YOUBI].Value.ToString()))
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_YOUBI].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_YOUBI].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_YOUBI].Value.ToString();
                }
                //局ネット数 
                if (string.IsNullOrEmpty(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUNETSUU].Value.ToString()))
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUNETSUU].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUNETSUU].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUNETSUU].Value.ToString();
                }
                //キー局.
                if (naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEYKYOKUCD].Value == null)
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KEYKYOKUCD].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KEYKYOKUCD].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEYKYOKUCD].Value.ToString();
                }
                //スペース 
                if (string.IsNullOrEmpty(naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Value.ToString()))
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Value.ToString();
                }
                //朝夕区分 
                if (naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_ASAYUUKBN].Value == null)
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_ASAYUUKBN].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_ASAYUUKBN].Text = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_ASAYUUKBN].Text.ToString();
                }
                //掲載版 
                if (naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIBAN].Value == null)
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIBAN].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIBAN].Value = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIBAN].Value.ToString();
                }
                //記雑区分 
                if (naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KIZATSUKBN].Value == null)
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KIZATSUKBN].Text = string.Empty;
                }
                else
                {
                    spdDetailInput_Sheet1.Cells[i, COLIDX_KIZATSUKBN].Value = naviParam.SpdDetailInput_Sheet1.Cells[i, COLIDX_KIZATSUKBN].Value.ToString();
                }
            }
        }
        #endregion 設定ボタンクリックイベント.

        #region ▲ボタンクリックイベント.
        /// <summary>
        /// ▲ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhButton7_Click(object sender, EventArgs e)
        {
            if (spdDetailInput_Sheet1.RowCount < 0 || spdDetailInput_Sheet1.ActiveRowIndex <= 0)
            {
                return;
            }

            int oldRow = spdDetailInput_Sheet1.ActiveRowIndex;

            spdDetailInput_Sheet1.MoveRow(oldRow, oldRow - 1, true);
            spdDetailInput_Sheet1.SetActiveCell(oldRow - 1,spdDetailInput_Sheet1.ActiveColumnIndex);
            spdDetailInput.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
        }
        #endregion ▲ボタンクリックイベント.

        #region ▼ボタンクリックイベント.
        /// <summary>
        /// ▼ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhButton8_Click(object sender, EventArgs e)
        {
            if (spdDetailInput_Sheet1.RowCount < 0 || spdDetailInput_Sheet1.ActiveRowIndex + 1 >= spdDetailInput_Sheet1.RowCount)
            {
                return;
            }

            int oldRow = spdDetailInput_Sheet1.ActiveRowIndex;

            spdDetailInput_Sheet1.MoveRow(oldRow, oldRow + 1, true);
            spdDetailInput_Sheet1.SetActiveCell(oldRow + 1, spdDetailInput_Sheet1.ActiveColumnIndex);
            spdDetailInput.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
        }
        #endregion ▼ボタンクリックイベント.

        #region 明細入力一覧変更処理.
        /// <summary>
        /// 明細入力一覧変更処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_EditChange(object sender, EditorNotifyEventArgs e)
        {
            //入力桁数制御 
            SheetView sheet = e.View.GetSheetView();
            Column col = sheet.Columns[e.Column];
            object cellType = col.CellType;

            if (cellType is TextCellType)
            {
                TextCellType textCellType = (TextCellType)cellType;
                e.EditingControl.Text = KKHUtility.GetByteString(e.EditingControl.Text, textCellType.MaxLength);
                ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
            }
        }
        #endregion 明細入力一覧変更処理.

        #region 編集モードが終了するときに発生します.
        /// <summary>
        /// 編集モードが終了するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_EditModeOff(object sender, EventArgs e)
        {
            //局コード.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_KYOKUCD)
            {
                //コンボボックスの処理はComboSelChangeで行う.
            }
            //見積金額・値引率.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_HNMAEGAK || spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_HNNERT)
            {
                //見積金額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNMAEGAK].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNMAEGAK].Value = 0M;
                }
                //値引率が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNNERT].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNNERT].Value = 0M;
                }

                //見積金額.
                decimal delHnMaeGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNMAEGAK].Value.ToString());
                //値引率.
                decimal delHnNebikiRitu = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNNERT].Value.ToString());
                //請求金額.
                decimal delSeiGaku = Math.Truncate(delHnMaeGaku - (delHnMaeGaku * (delHnNebikiRitu / 100M)));
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_SEIGAK].Value = delSeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //値引額.
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_NEBIKIGAKU].Value = Math.Truncate(delHnMaeGaku * (delHnNebikiRitu / 100M));
                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(delSeiGaku * KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIRITSU].Value.ToString()) / 100M);
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //値引額.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_NEBIKIGAKU)
            {
                //値引額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_NEBIKIGAKU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_NEBIKIGAKU].Value = 0M;
                }

                //請求金額(見積金額 - 値引額).
                decimal delSeikyuGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HNMAEGAK].Value.ToString()) - KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_NEBIKIGAKU].Value.ToString());
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_SEIGAK].Value = delSeikyuGaku;
                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(delSeikyuGaku * KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIRITSU].Value.ToString()) / 100M);
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            //請求金額.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_SEIGAK)
            {
                //請求金額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_SEIGAK].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_SEIGAK].Value = 0M;
                }
            }
            //消費税率.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_ZEIRITSU)
            {
                //消費税率が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIRITSU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIRITSU].Value = 0M;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_SEIGAK].Value.ToString()) * (KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIRITSU].Value.ToString()) / 100M));
                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //消費税額.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_ZEIGAKU)
            {
                //消費税額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIGAKU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_ZEIGAKU].Value = 0M;
                }
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

            //秒数と本数を0埋めする.
            PadLeftByosuHonsu();
        }
        #endregion 編集モードが終了するときに発生します.

        #region ユーザーがセルのコンボボックスの選択項目を変更するときに発生します.
        /// <summary>
        /// ユーザーがセルのコンボボックスの選択項目を変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_ComboSelChange(object sender, EditorNotifyEventArgs e)
        {
            //局コード.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_KYOKUCD)
            {
                string selBaitaiCd = cmbBaitai.SelectedValue.ToString();

                //テレビタイム・ラジオタイム・テレビネットスポット.
                if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME 
                    || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || selBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    /* 2014/08/15 アサヒ対応 HLC 張(JANG) ADD Start */
                    // アサヒビールでテレビタイム、テレビネットスポットの場合.
                    if (_naviParam.strTksKgyCd == UserManualHelper.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6) 
                        &&(selBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                        || selBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT))
                        /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
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
                        DetailDSAsh.KeyKyokuBangumiCdDataTable dtKKBC = result.DetailAshDataSet.KeyKyokuBangumiCd;

                        // 受注データにキー局が設定いない場合.
                        // すべての行の番組コードに当行のキー局のコードを設定.
                        if (_dataRow.hb1Field1 == "")
                        {
                            DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                            Select("KYOKUCD = '" + spdDetailInput_Sheet1.ActiveCell.Value.ToString() + "'");

                            if (rowKKBC.Length > 0)
                            {
                                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = rowKKBC[0].KEYBANGUMICD;
                            }
                            else
                            {
                                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = "";
                            }
                            
                        }
                        // 受注データにキー局が設定いる場合.
                        // すべての行の番組コードにそのキー局のコードを設定.
                        else
                        {
                            DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                            Select("KYOKURYAKUSYOU = '" + _dataRow.hb1Field1.Trim() + "'");
                            /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD Start */
                            //spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = rowKKBC[0].KEYBANGUMICD;

                            if (rowKKBC.Length > 0)
                            {
                                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = rowKKBC[0].KEYBANGUMICD;
                            }
                            else
                            {
                                spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = "";
                            }
                            /* 2015/06/08 アサヒ対応 HLC K.Fujisaki MOD End */
                        }
                    }
                    // アサヒビールではないかラジオタイムの場合.
                    else
                    {
                        /* 2015/06/08 アサヒ対応 HLC 張(JANG) ADD END */
                        Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = GetKyokuMasterData(selBaitaiCd);
                        DataRow[] rows = dt.Select(dt.Column1Column.ColumnName + "='" + spdDetailInput_Sheet1.ActiveCell.Value.ToString() + "'");
                        if (rows.Length > 0)
                        {
                            spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column3;
                        }
                        else
                        {
                            spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = "";
                        }
                    }
                }
                //メディアフィー・ブランド管理フィー.
                else if (selBaitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE || selBaitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE)
                {
                    if (spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_KYOKUCD].Value.ToString() != "")
                    {
                        spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = "00";
                    }
                    else
                    {
                        spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_BANGUMICD].Text = "";
                    }
                }
                //テレビスポット・ラジオスポット.
                else if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
                {
                    Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = GetKyokuMasterData(selBaitaiCd);
                    DataRow[] rows = dt.Select(dt.Column1Column.ColumnName + "='" + spdDetailInput_Sheet1.ActiveCell.Value.ToString() + "'");
                    if (rows.Length > 0)
                    {
                        if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 6)
                        {
                            spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HYOUZIJUN].Text = "00" + ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                        else if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 7)
                        {
                            spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HYOUZIJUN].Text = "0" + ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                        else if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 8)
                        {
                            spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HYOUZIJUN].Text = ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                    }
                    else
                    {
                        spdDetailInput_Sheet1.Cells[spdDetailInput_Sheet1.ActiveRowIndex, COLIDX_HYOUZIJUN].Text = "000.0000";
                    }  
                }
            }
        }
        #endregion ユーザーがセルのコンボボックスの選択項目を変更するときに発生します.

        #region 媒体コード変更時に発生します.
        /// <summary>
        /// 媒体コード変更時に発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaitai_SelectedIndexChanged(object sender, EventArgs e)
        {
            //明細入力スプレッド.
            if (cmbBaitai.SelectedValue == null)
            {
                InitializeSpdDetailInput("");
            }
            else
            {
                InitializeSpdDetailInput(cmbBaitai.SelectedValue.ToString());
            }
            InitSpdDetailInput();

            //ボタン.
            setButtonVisible();
        }
        #endregion 媒体コード変更時に発生します.

        #region サブエディタが表示される直前に発生します.
        /// <summary>
        /// サブエディタが表示される直前に発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_SubEditorOpening(object sender, SubEditorOpeningEventArgs e)
        {
            //サブエディターのポップアップをキャンセル.
            e.Cancel = true;
        }
        #endregion サブエディタが表示される直前に発生します.

        #region データモデルChangedイベント.
        /// <summary>
        /// データモデルChangedイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            //非編集状態でクリップボードから貼り付けした場合.
            if (e.Type == SheetDataModelEventType.CellsUpdated)
            {
                try
                {
                    if (sender is DefaultSheetDataModel)
                    {
                        DefaultSheetDataModel dataModel = (DefaultSheetDataModel)sender;

                        // TextCellTypeの場合のみ処理を行う.
                        if (spdDetailInput_Sheet1.Columns[e.Column].CellType is TextCellType)
                        {
                            TextCellType tc = (TextCellType)spdDetailInput_Sheet1.Columns[e.Column].CellType;
                            string s = dataModel.GetValue(e.Row, e.Column).ToString();
                            if (KKHUtility.GetByteCount(s) > tc.MaxLength)
                            {
                                s = KKHUtility.GetByteString(s, tc.MaxLength);
                                dataModel.SetValue(e.Row, e.Column, s);
                            }
                        }
                    }

                    //秒数と本数を0埋めする.
                    PadLeftByosuHonsu();
                }
                catch
                {
                    // 何もしない.
                }
            }
        }
        #endregion データモデルChangedイベント.

        #region スプレッドキーダウンイベント.
        /// <summary>
        /// スプレッドキーダウンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                //Ctrl+Vが押下された場合、クリップボードの内容を貼り付け.
                FpSpread fpSpread = sender as FpSpread;
                CellRange[] range = fpSpread.ActiveSheet.GetSelections();

                //クリップボードの値をセルに当てはめる.
                string clipVal = Clipboard.GetText();

                //選択したセル範囲情報を走査する.
                foreach (CellRange rn in range)
                {
                    //列.
                    int col = rn.Column;
                    //行.
                    int row = rn.Row;
                    //選択範囲終了列.
                    int colEnd = (rn.Column + rn.ColumnCount - 1);
                    //選択範囲終了行 .
                    int rowEnd = (rn.Row + rn.RowCount - 1);

                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;

                        //行分ループ.
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(this.spdDetailInput.GetRootWorkbook(), clipVal, rowCnt, colCnt);

                            if (multiCopyFlg)
                            {
                                //複数コピーの為、貼り付け終了.
                                break;
                            }
                        }
                        if (multiCopyFlg)
                        {
                            //複数コピーの為、貼り付け終了.
                            break;
                        }
                    }
                }
            }
        }
        #endregion スプレッドキーダウンイベント.

        #region スプレッドチェンジイベント.
        /// <summary>
        /// スプレッドチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_Change(object sender, ChangeEventArgs e)
        {
            //局コード.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_KYOKUCD)
            {
                //コンボボックスの処理はComboSelChangeで行う.
            }
            //見積金額・値引率.
            else if (e.Column == COLIDX_HNMAEGAK || e.Column == COLIDX_HNNERT)
            {
                //見積金額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNMAEGAK].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNMAEGAK].Value = 0M;
                }
                //値引率が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNNERT].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNNERT].Value = 0M;
                }

                //見積金額.
                decimal delHnMaeGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNMAEGAK].Value.ToString());
                //値引率.
                decimal delHnNebikiRitu = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNNERT].Value.ToString());
                //請求金額.
                decimal delSeiGaku = Math.Truncate(delHnMaeGaku - (delHnMaeGaku * (delHnNebikiRitu / 100M)));
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_SEIGAK].Value = delSeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //値引額.
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_NEBIKIGAKU].Value = Math.Truncate(delHnMaeGaku * (delHnNebikiRitu / 100M));
                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(delSeiGaku * KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIRITSU].Value.ToString()) / 100M);
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //値引額.
            else if (e.Column == COLIDX_NEBIKIGAKU)
            {
                //値引額が空の場合.
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_NEBIKIGAKU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_NEBIKIGAKU].Value = 0M;
                }

                //請求金額(見積金額 - 値引額).
                decimal delSeikyuGaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_HNMAEGAK].Value.ToString()) - KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_NEBIKIGAKU].Value.ToString());
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_SEIGAK].Value = delSeikyuGaku;

                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(delSeikyuGaku * KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIRITSU].Value.ToString()) / 100M);
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            //請求金額.
            else if (e.Column == COLIDX_SEIGAK)
            {
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_SEIGAK].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_SEIGAK].Value = 0M;
                }
            }
            //消費税.
            else if (e.Column == COLIDX_ZEIRITSU)
            {
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIRITSU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIRITSU].Value = 0M;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //消費税額(請求金額 * (消費税率 * 0.01)).
                decimal delShouhizeiGaku = Math.Truncate(KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_SEIGAK].Value.ToString()) * (KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIRITSU].Value.ToString()) / 100M));
                spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIGAKU].Value = delShouhizeiGaku;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //消費税額.
            else if (e.Column == COLIDX_ZEIGAKU)
            {
                if (String.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIGAKU].Value)))
                {
                    spdDetailInput_Sheet1.Cells[e.Row, COLIDX_ZEIGAKU].Value = 0M;
                }
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

            //秒数と本数を0埋めする.
            PadLeftByosuHonsu();
        }
        #endregion スプレッドチェンジイベント.

        #region 明細入力画面を閉じる処理.
        /// <summary>
        /// 明細入力画面を閉じる処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputAsh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_userCloseRequest)
            {
                //閉じるボタンによる要求なのでキャンセルする.
                e.Cancel = true;

                //閉じる要求フラグを設定.
                _userCloseRequest = true;

                //改めてフレームワークによる閉じる要求を出す.
                Navigator.Backward(this, null, null, true);
            }
        }
        #endregion 明細入力画面を閉じる処理.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの初期表示処理.
        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            ((DefaultSheetDataModel)spdDetailInput_Sheet1.Models.Data).Changed += new SheetDataModelEventHandler(dataModel_Changed);
            InitializeSpdDetailInput(GetDefaultBaitaiCd());
        }
        #endregion 各コントロールの初期表示処理.

        #region スプレッドの初期設定.
        /// <summary>
        /// スプレッドの初期設定.
        /// </summary>
        private void InitializeSpdDetailInput(string baitaiCd)
        {
            /*
             * スプレッド全体に対する設定.
             */
            InputMap im = new InputMap();

            //非編集セルでのInputMap.
            im = spdDetailInput.GetInputMap(InputMapMode.WhenFocused);
            //非編集セルでの[F2]キーを無効.
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //非編集セルでの[F4]キーを無効.
            im.Put(new Keystroke(Keys.F4, Keys.None), SpreadActions.None);
            //非編集セルでの[Enter]キーを[次行へ移動].
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            //編集中セルでのInputMap.
            im = spdDetailInput.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //編集中セルでの[F2]キーを無効.
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //編集中セルでの[F4]キーを無効.
            im.Put(new Keystroke(Keys.F4, Keys.None), SpreadActions.None);
            //編集中セルでの[Enter]キーを[次行へ移動].
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            /*
             * 列毎に対する設定. 
             */
            foreach (Column col in spdDetailInput_Sheet1.Columns)
            {
                //請求書番号.
                if (col.Index == COLIDX_SEINO) { }
                //件名.
                else if (col.Index == COLIDX_KENMEI) { }
                //局コード.
                else if (col.Index == COLIDX_KYOKUCD)
                {
                    MasterMaintenance.MasterDataVODataTable dt = GetKyokuMasterData(baitaiCd);

                    //データテーブルのコピーを作成.
                    MasterMaintenance.MasterDataVODataTable dt2 = (MasterMaintenance.MasterDataVODataTable)dt.Clone();
                    DataView dv = new DataView(dt);
                    dv.Sort = "Column1";

                    foreach (DataRowView drv in dv)
                    {
                        dt2.ImportRow(drv.Row);
                    }
                    List<string> code = new List<string>();
                    List<string> name = new List<string>();

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        /* 2015/02/24 その他マスタ拡張 JSE Fukuda MOD Start */
                        //code.Add(dt2[i].Column1);
                        //if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME || baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT
                        //    || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                        //    || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
                        //{
                        //    name.Add(dt2[i].Column1 + " " + dt2[i].Column4 + " " + dt2[i].Column2);
                        //}
                        //else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                        //{
                        //    name.Add(dt2[i].Column3 + " " + dt2[i].Column2 + " " + dt2[i].Column1);
                        //}
                        //else
                        //{
                        //    name.Add(dt2[i].Column1 + " " + dt2[i].Column2);
                        //}

                        //その他マスタから取得した場合.
                        if (dt2[i].sybt == "218")
                        {
                            code.Add(dt2[i].Column2);
                            name.Add(dt2[i].Column2 + " " + dt2[i].Column3);
                        }
                        else
                        {
                            code.Add(dt2[i].Column1);
                            if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                                || baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT
                                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                                || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT
                                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                                || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                                || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
                            {
                                //テレビタイム、テレビスポット、テレビネットスポット、ラジオタイム、ラジオスポットの場合.
                                name.Add(dt2[i].Column1 + " " + dt2[i].Column4 + " " + dt2[i].Column2);
                            }
                            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                            {
                                //雑誌の場合.
                                name.Add(dt2[i].Column3 + " " + dt2[i].Column2 + " " + dt2[i].Column1);
                            }
                            else
                            {
                                //上記以外の場合.
                                name.Add(dt2[i].Column1 + " " + dt2[i].Column2);
                            }
                        }
                        /* 2015/02/24 その他マスタ拡張 fukuda MOD End */
                    }

                    code.Insert(0, "");
                    name.Insert(0, "");

                    ComboBoxCellType cellType = (ComboBoxCellType)col.CellType;
                    cellType.Items = name.ToArray();
                    cellType.ItemData = code.ToArray();
                    col.CellType = cellType;
                }
                //品種コード.
                else if (col.Index == COLIDX_HINSYUCD) 
                {
                    //商品マスタ検索.
                    string masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SYOHIN;
                    Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = FindMasterData(masterKey);

                    //データテーブルのコピーを作成.
                    MasterMaintenance.MasterDataVODataTable dt2 = (MasterMaintenance.MasterDataVODataTable)dt.Clone();
                    DataView dv = new DataView(dt);
                    dv.Sort = "Column1";

                    foreach (DataRowView drv in dv)
                    {
                        dt2.ImportRow(drv.Row);
                    }

                    List<string> code = new List<string>();
                    List<string> name = new List<string>();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        code.Add(dt2[i].Column1);
                        name.Add(dt2[i].Column1 + " " + dt2[i].Column2);
                    }

                    code.Insert(0, "");
                    name.Insert(0, "");

                    ComboBoxCellType cellType = (ComboBoxCellType)col.CellType;
                    cellType.ItemData = code.ToArray();
                    cellType.Items = name.ToArray();
                    col.CellType = cellType;
                }
                //費目名称.
                else if (col.Index == COLIDX_HIMOKUNM) { }
                //見積金額.
                else if (col.Index == COLIDX_HNMAEGAK) { }
                //値引率.
                else if (col.Index == COLIDX_HNNERT) { }
                //請求金額.
                else if (col.Index == COLIDX_SEIGAK) { }
                //消費税.
                else if (col.Index == COLIDX_ZEIRITSU) { }
                //期間.
                else if (col.Index == COLIDX_KIKAN) { }
                //媒体コード.
                else if (col.Index == COLIDX_BAITAICD) 
                {
                    col.Locked = true;
                }
                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start */
                //(得意先)媒体コード 
                else if (col.Index == COLIDX_TOKUIBAITAICD)
                {
                    col.Locked = true;
                }
                /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End */
                //代理店コード.
                else if (col.Index == COLIDX_DAIRITENCD)
                {
                    col.Locked = true;
                }
                //番組コード.
                else if (col.Index == COLIDX_BANGUMICD) { }
                //売上明細No.
                else if (col.Index == COLIDX_URIMEINO) { }
                //秒数.
                else if (col.Index == COLIDX_BYOUSUU) { }
                //本数.
                else if (col.Index == COLIDX_HONSUU) { }
                //表示順.
                else if (col.Index == COLIDX_HYOUZIJUN) { }
                //掲載日("新聞発売日" / "雑誌掲載日").
                else if (col.Index == COLIDX_KEISAIHATSUBAIBI) 
                {
                    if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN)
                    {
                        col.Label = "新聞発売日";
                    }
                    else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                    {
                        col.Label = "雑誌掲載日";
                    }
                }
                //朝夕区分.
                else if (col.Index == COLIDX_ASAYUUKBN) { }
                //記雑区分.
                else if (col.Index == COLIDX_KIZATSUKBN) 
                {
                    Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable dt = FindCommonCodeMaster("WC", false);
                    List<string> code = new List<string>();
                    List<string> name = new List<string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        code.Add(dt[i].kyCd);
                        name.Add(dt[i].naiyJ);
                    }

                    ComboBoxCellType cellType = (ComboBoxCellType)col.CellType;
                    cellType.ItemData = code.ToArray();
                    cellType.Items = name.ToArray();
                    col.CellType = cellType;
                }
                //掲載版.
                else if (col.Index == COLIDX_KEISAIBAN)
                {
                    Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable dt = FindCommonCodeMaster("WB", false);
                    List<string> code = new List<string>();
                    List<string> name = new List<string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        code.Add(dt[i].kyCd);
                        name.Add(dt[i].naiyJ);
                    }

                    ComboBoxCellType cellType = (ComboBoxCellType)col.CellType;
                    cellType.ItemData = code.ToArray();
                    cellType.Items = name.ToArray();
                    col.CellType = cellType;
                }
                //端数処理.
                else if (col.Index == COLIDX_HASUUSYORIKBN) { }
                //入力比率.
                else if (col.Index == COLIDX_NYUURYOKUHIRITSU) { }
                //スペース.
                else if (col.Index == COLIDX_SPACE) { }
                //放送時間.
                else if (col.Index == COLIDX_HOUSOUZIKAN) { }
                //曜日.
                else if (col.Index == COLIDX_YOUBI) { }
                //局ネット数.
                else if (col.Index == COLIDX_KYOKUNETSUU) { }
                //キー局.
                else if (col.Index == COLIDX_KEYKYOKUCD) { }
                else if (col.Index == COLIDX_FD) { }
                else { }
            }

            //列の表示/非表示の設定.
            VisibleSpdDetailInputColumns(baitaiCd);
        }
        #endregion スプレッドの初期設定.

        #region スプレッドの列表示設定.
        /// <summary>
        /// スプレッドの列表示設定.
        /// </summary>
        /// <param name="baitaiCd"></param>
        private void VisibleSpdDetailInputColumns(string baitaiCd)
        {
            if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN)
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = false;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = false;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME 
                || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU)
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
            else
            {
                spdDetailInput_Sheet1.Columns[COLIDX_SEINO].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KENMEI].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HINSYUCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HIMOKUNM].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNMAEGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_HNNERT].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_SEIGAK].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_KIKAN].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD Start */
                //spdDetailInput_Sheet1.Columns[COLIDX_BAITAICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_TOKUIBAITAICD].Visible = true;
                /* 2015/03/04 アサヒ対応 K.Fujisaki MOD End */
                spdDetailInput_Sheet1.Columns[COLIDX_DAIRITENCD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_BANGUMICD].Visible = true;
                spdDetailInput_Sheet1.Columns[COLIDX_URIMEINO].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HYOUZIJUN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_ASAYUUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KIZATSUKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEISAIBAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HASUUSYORIKBN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_NYUURYOKUHIRITSU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_HOUSOUZIKAN].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_YOUBI].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KYOKUNETSUU].Visible = false;
                spdDetailInput_Sheet1.Columns[COLIDX_KEYKYOKUCD].Visible = false;
            }
        }
        #endregion スプレッドの列表示設定.

        #region 各コントロールの編集処理.
        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            //受注データ参照情報設定.
            setSpdJyutyuDetail();

            //品種コンボボックス設定.
            setCmbHinsyu();

            //媒体コンボボックス設定.
            setCmbBaitai();

            //明細入力スプレッド初期設定.
            InitSpdDetailInput();
        }
        #endregion 各コントロールの編集処理.

        #region 品種コンボボックス設定.
        /// <summary>
        /// 品種コンボボックス設定.
        /// </summary>
        private void setCmbHinsyu()
        {
            MasterMaintenance.MasterDataVORow[] rows;
            List<AshComboBoxItem> items;

            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = FindMasterData(Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SYOHIN);
            rows = (MasterMaintenance.MasterDataVORow[])dt.Select();
            items = new List<AshComboBoxItem>();
            items.Add(new AshComboBoxItem(string.Empty, string.Empty));

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                items.Add(new AshComboBoxItem(row.Column1, row.Column1 + " " + row.Column2));
            }

            cmbHinsyu.Items.Clear();
            cmbHinsyu.DisplayMember = "NAME";
            cmbHinsyu.ValueMember = "CODE";
            cmbHinsyu.DataSource = items;
        }
        #endregion 品種コンボボックス設定.

        #region 媒体コンボボックス設定.
        /// <summary>
        /// 媒体コンボボックス設定.
        /// </summary>
        private void setCmbBaitai()
        {
            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD Start */
            //コンボボックスの生成.
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("CODE", typeof(string));
            SybtNameTable.Columns.Add("NAME", typeof(string));
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            
            //旧媒体名称から新媒体名称へ変換する.
            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiCd, resultList[i].baitaiNm);
            }

            cmbBaitai.Items.Clear();
            cmbBaitai.DisplayMember = "NAME";
            cmbBaitai.ValueMember = "CODE";
            cmbBaitai.DataSource = SybtNameTable;
            cmbBaitai.SelectedValue = GetDefaultBaitaiCd();
            //String defaultBaitaiCd = GetDefaultBaitaiCd();
            //AshBaitaiUtility.BaitaiResult result = ashBaitaiUtility.ConvertNewCdToOldCd(defaultBaitaiCd);
            //cmbBaitai.SelectedValue = result.baitaiCd;
            /* 2015/02/23 アサヒ対応 JSE Miyanoue MOD End */
        }
        #endregion 媒体コンボボックス設定.

        #region FD明細出力設定.
        /// <summary>
        /// FD明細出力設定.
        /// </summary>
        private void setFDDetailOutput()
        {
            //得意先がアサヒビール、かつ媒体コードが"130"(新聞)の場合.
            if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo) && KkhConstAsh.BaitaiCd.SHINBUN.Equals(cmbBaitai.SelectedValue))
            {
                chkFDDetailOutput.Visible = true;

                //明細が存在する場合.
                if (_dtKkhDetail.Rows.Count > 0)
                {
                    foreach (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailRow row in _dtKkhDetail.Rows)
                    {
                        //明細にFDSEQが設定されている場合.
                        if (row.fd.Trim() != "")
                        {
                            chkFDDetailOutput.Checked = true;
                            return;
                        }
                    }
                    chkFDDetailOutput.Checked = false;
                    return;
                }

                //件名に"題字"が含まれる場合.
                if (_dataRow.hb1KKNameKJ.IndexOf("題字") > -1)
                {
                    chkFDDetailOutput.Checked = true;
                }
                //その他の場合.
                else
                {
                    chkFDDetailOutput.Checked = false;
                    foreach (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailRow row in _dtKkhDetail.Rows)
                    {
                        //明細にFDSEQが設定されている場合.
                        if (row.fd.Trim() != "")
                        {
                            chkFDDetailOutput.Checked = true;
                            break;
                        }
                    }
                }
            }
            //得意先がアサヒビール以外場合.
            else
            {
                chkFDDetailOutput.Checked = false;
                chkFDDetailOutput.Visible = false;
            }
        }
        #endregion FD明細出力設定.

        #region ボタン表示/非表示.
        /// <summary>
        /// ボタン表示/非表示.
        /// </summary>
        private void setButtonVisible()
        {
            string selBaitaiCd = string.Empty;

            if (cmbBaitai.SelectedValue == null)
            {
                selBaitaiCd = string.Empty;
            }
            else
            {
                selBaitaiCd = cmbBaitai.SelectedValue.ToString();
            }

            switch (selBaitaiCd)
            {
                case KkhConstAsh.BaitaiCd.TV_TIME:
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                /* 2015/06/08 アサヒ対応 K.Fujisaki ADD Start */
                case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                    btnGroupExpand.Visible = true;
                    btnSort.Visible = false;
                    break;
                /* 2015/06/08 アサヒ対応 K.Fujisaki ADD End */
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    btnGroupExpand.Visible = false;
                    btnSort.Visible = true;
                    break;
                default:
                    btnGroupExpand.Visible = false;
                    btnSort.Visible = false;
                    break;
            }
        }
        #endregion ボタン表示/非表示.

        #region 受注データ参照情報設定.
        /// <summary>
        /// 受注データ参照情報設定.
        /// </summary>
        private void setSpdJyutyuDetail()
        {
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow datarow = _naviParam.DataRow;

            /*
             * 表示ラベル,データの設定.
            */
            switch (datarow.hb1SeiKbn.ToString())
            {
                //新聞.
                case KKHSystemConst.SeiKbn.NewsPaper:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "掲載日";
                    spdJyutyuDetail.Sheets[0].Cells[0,0].Value =datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "朝夕区分";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = datarow.hb1Field4.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "掲載版";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field6.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[3].Label = "記雑区分";
                    spdJyutyuDetail.Sheets[0].Cells[3, 0].Value = datarow.hb1Field8.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[4].Label = "掲載面";
                    spdJyutyuDetail.Sheets[0].Cells[4, 0].Value = datarow.hb1Field10.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[5].Label = "スペース";
                    spdJyutyuDetail.Sheets[0].Cells[5, 0].Value = datarow.hb1Field11.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[6].Label = "掲載期間";
                    spdJyutyuDetail.Sheets[0].Cells[6, 0].Value = kiKanFormat(datarow.hb1Field12.Trim());
                    break;
                //雑誌.
                case KKHSystemConst.SeiKbn.Magazine:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "発売日";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "掲載号";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = datarow.hb1Field4.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "掲載種別";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field6.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[3].Label = "掲載条件";
                    spdJyutyuDetail.Sheets[0].Cells[3, 0].Value = datarow.hb1Field8.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[4].Label = "スペース";
                    spdJyutyuDetail.Sheets[0].Cells[4, 0].Value = datarow.hb1Field9.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[5].Label = "掲載期間";
                    spdJyutyuDetail.Sheets[0].Cells[5, 0].Value = kiKanFormat(datarow.hb1Field10).Trim();
                    break;
                //タイム.
                case KKHSystemConst.SeiKbn.Time:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "ネット局数";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "放送時間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = datarow.hb1Field4.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "秒数";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field5.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[3].Label = "回数";
                    spdJyutyuDetail.Sheets[0].Cells[3, 0].Value = datarow.hb1Field6.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[4].Label = "放送日";
                    spdJyutyuDetail.Sheets[0].Cells[4, 0].Value = datarow.hb1Field7.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[5].Label = "放送期間";
                    spdJyutyuDetail.Sheets[0].Cells[5, 0].Value = kiKanFormat(datarow.hb1Field8.Trim());
                    break;
                //スポット. 
                case KKHSystemConst.SeiKbn.Spot:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "ネット局数";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "放送時間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field4.Trim());
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "秒数";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field5.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[3].Label = "本数";
                    spdJyutyuDetail.Sheets[0].Cells[3, 0].Value = datarow.hb1Field6.Trim();
                    break;
                //諸作業.
                case KKHSystemConst.SeiKbn.Works:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "費目補足";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "納品日期間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field5.Trim().Trim());
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "回数数量";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field6.Trim();
                    break;
                //交通広告.
                case KKHSystemConst.SeiKbn.Ooh:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "費目補足";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "掲載期間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field5).Trim();
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "数量";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field6.Trim();
                    break;
                //国際マス.
                case KKHSystemConst.SeiKbn.KMas:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "費目補足";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field4.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "期間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field3.Trim());
                    break;
                //国際諸作業.
                case KKHSystemConst.SeiKbn.KWorks:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "費目補足";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field1.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "期間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field4.Trim());
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "数量";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field5.Trim();
                    break;
                //IC(インタラクティブメディア).
                case KKHSystemConst.SeiKbn.IC:
                    spdJyutyuDetail.Sheets[0].Rows[0].Label = "費目補足";
                    spdJyutyuDetail.Sheets[0].Cells[0, 0].Value = datarow.hb1Field3.Trim();
                    spdJyutyuDetail.Sheets[0].Rows[1].Label = "掲載期間";
                    spdJyutyuDetail.Sheets[0].Cells[1, 0].Value = kiKanFormat(datarow.hb1Field5).Trim();
                    spdJyutyuDetail.Sheets[0].Rows[2].Label = "数量";
                    spdJyutyuDetail.Sheets[0].Cells[2, 0].Value = datarow.hb1Field6.Trim();
                    break;
            }
        }
        #endregion 受注データ参照情報設定.

        #region DBの値のフォーマットを設定.
        /// <summary>
        /// DBの値のフォーマットを設定.
        /// </summary>
        /// <param name="kikan"></param>
        /// <returns>(yyyy/mm/dd-yyyy/mm/dd)</returns>
        private string kiKanFormat(string kikan)
        {
            if (kikan.Length != 16) { return string.Empty; }
            string Skikan = kikan.Substring(0, 4) + "/"
                            + kikan.Substring(4, 2) + "/"
                            + kikan.Substring(6, 2) + " - "
                            + kikan.Substring(8, 4) + "/"
                            + kikan.Substring(12, 2) + "/"
                            + kikan.Substring(14, 2);
            return Skikan;
        }
        #endregion DBの値のフォーマットを設定.

        #region 汎用マスタの検索を行う(一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する).
        /// <summary>
        /// 汎用マスタの検索を行う.
        /// 一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey)
        {
            return FindMasterData(masterKey, false);
        }
        #endregion 汎用マスタの検索を行う(一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する).

        #region 汎用マスタの検索を行う.
        /// <summary>
        /// 汎用マスタの検索を行う.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <param name="reFlag">True:常にDB検索を行う、False:検索済みのマスタは保持しているデータを使用する</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey, bool reFlag)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;

            if (htMasterData[masterKey] == null || reFlag == true)
            {

                MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                        _naviParam.strEsqId
                                                                        , _naviParam.strEgcd
                                                                        , _naviParam.strTksKgyCd
                                                                        , _naviParam.strTksBmnSeqNo
                                                                        , _naviParam.strTksTntSeqNo
                                                                        , masterKey
                                                                        , ""
                                                                    );
                rv = result.MasterDataSet.MasterDataVO;
                htMasterData[masterKey] = result.MasterDataSet.MasterDataVO;
            }
            else
            {
                rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey];
            }

            return rv;
        }

        private Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable FindCommonCodeMaster(string kyCdKnd)
        {
            return FindCommonCodeMaster(kyCdKnd, false);
        }

        private Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable FindCommonCodeMaster(string kyCdKnd, bool reFlag)
        {
            Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable rv;
            if (htCommonCodeMasterData[kyCdKnd] == null || reFlag == true)
            {
                CommonProcessController processController = CommonProcessController.GetInstance();
                FindCommonCodeMasterByCondServiceResult result = processController.FindCommonCodeMasterByCond(_naviParam.strEsqId, kyCdKnd, _naviParam.strDate);

                rv = result.CommonDataSet.RcmnMeu29CC;
                htCommonCodeMasterData[kyCdKnd] = result.CommonDataSet.RcmnMeu29CC;
            }
            else
            {
                rv = (Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable)htCommonCodeMasterData[kyCdKnd];
            }

            return rv;
        }
        #endregion 汎用マスタの検索を行う.

        #region 指定した媒体コードに対応するマスタデータを取得する.
        /// <summary>
        /// 指定した媒体コードに対応するマスタデータを取得する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable GetKyokuMasterData(string baitaiCd)
        {
            string masterKey = "";

            /* 2015/03/09 アサヒ対応 JSE Miyanoue DEL Start */
            //AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            ////媒体コードを変換する.
            //AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertNewCdToOldCd(baitaiCd);
            //baitaiCd =res.baitaiCd;
            /* 2015/03/09 アサヒ対応 JSE Miyanoue DEL End */

            if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU; }
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU; }
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SHINBUN; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.ZASSHI; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.OOH; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.OKUGAI) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.OKUGAI_EVENT; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SEISAKU) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SEISAKU; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.EVENT) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.OKUGAI_EVENT; }
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe ADD Start */
            else if (baitaiCd == KkhConstAsh.BaitaiCd.PR) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.PR; }
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe ADD End */
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SONOTA) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.NEW_MEDIA) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.INTERNET) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BS) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.CS) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TYOUSA) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.MEDIA_FEE; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE) { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.BRAND_MANEGE_FEE; }
            /* 2015/02/24 その他マスタ拡張 JSE Fukuda ADD Start */
            else { masterKey = Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SONOTA; }
            /* 2015/02/24 その他マスタ拡張 JSE Fukuda ADD End   */
            /* 2015/02/24 その他マスタ拡張 Fukuda MOD start */
            //return FindMasterData(masterKey);
            MasterMaintenance.MasterDataVODataTable dtMaster = FindMasterData(masterKey);
            if (masterKey == KkhConstAsh.MasterKey.SONOTA)
            {
                //その他マスタから取得している場合は媒体コードでフィルタをかける.
                MasterMaintenance.MasterDataVODataTable dtTmp = new MasterMaintenance.MasterDataVODataTable();
                DataRow[] drMasterRows = dtMaster.Select(dtMaster.Column1Column.ColumnName + " = '" + baitaiCd + "'");
                foreach (MasterMaintenance.MasterDataVORow row in drMasterRows)
                {
                    dtTmp.ImportRow(row);
                }
                dtMaster = dtTmp;
            }
            return dtMaster;
            /* 2015/02/24 その他マスタ拡張 JSE Fukuda MOD End */
        }
        #endregion 指定した媒体コードに対応するマスタデータを取得する.

        #region 明細初期表示.
        #region 明細初期表示.
        /// <summary>
        /// 明細初期表示.
        /// </summary>
        private void InitSpdDetailInput()
        {
            //初期設定.
            String selBaitaiCd = "";

            //選択中の媒体が空の場合.
            if (cmbBaitai.SelectedValue == null)
            {
                selBaitaiCd = "";
            }
            //選択中の媒体が空でない場合.
            else
            {
                selBaitaiCd = cmbBaitai.SelectedValue.ToString();
            }

            //明細がない場合.
            if (_dtKkhDetail.Rows.Count == 0 || GetDefaultBaitaiCd() != selBaitaiCd)
            {
                //初期設定.
                drJyutyuData[] dataRows = new drJyutyuData[] { };
                dtKkhDetailInput dtDetailInput = new dtKkhDetailInput();

                //統合フラグが[1]の場合.
                if (_dataRow.hb1TouFlg == "1")
                {
                    //統合済みデータの場合は統合前データを基にして明細を作成する.
                    //営業所(取)コード.
                    string filterEx = _dtJyutyuData.hb1EgCdColumn.ColumnName + "='" + _dataRow.hb1EgCd + "'";
                    //得意先企業コード.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksKgyCdColumn.ColumnName + "='" + _dataRow.hb1TksKgyCd + "'";
                    //得意先部門SEQNO.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksBmnSeqNoColumn.ColumnName + "='" + _dataRow.hb1TksBmnSeqNo + "'";
                    //得意先担当SEQNO.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksTntSeqNoColumn.ColumnName + "='" + _dataRow.hb1TksTntSeqNo + "'";
                    //受注No.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TJyutNoColumn.ColumnName + "='" + _dataRow.hb1JyutNo + "'";
                    //受注明細No.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TJyMeiNoColumn.ColumnName + "='" + _dataRow.hb1JyMeiNo + "'";
                    //売上明細No.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TUrMeiNoColumn.ColumnName + "='" + _dataRow.hb1UrMeiNo + "'";
                    //統合フラグ.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TouFlgColumn.ColumnName + "=''";
                    //年月.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1YymmColumn.ColumnName + "='" + _dataRow.hb1Yymm + "'";
                    //業務区分.
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1GyomKbnColumn.ColumnName + "='" + _dataRow.hb1GyomKbn + "'";
                    dataRows = (drJyutyuData[])_dtJyutyuData.Select(filterEx);
                }
                else
                {
                    //未統合データの場合は選択データを基にして明細を作成する.
                    dataRows = new drJyutyuData[] { _dataRow };
                }

                //受注データ分ループ処理.
                foreach (drJyutyuData row in dataRows)
                {
                    //初期設定.
                    bool checkRes = false;

                    //媒体、業務区分、請求区分等をチェックし、明細に受注ダウンロードデータの内容を反映するかを決定する.
                    if (CheckDefGyomkbn(selBaitaiCd, row) == true && _targetBaitaiCd == selBaitaiCd && (row.hb1SeiKbn == _dataRow.hb1SeiKbn && row.hb1GyomKbn == _dataRow.hb1GyomKbn && row.hb1KokKbn == _dataRow.hb1KokKbn))
                    {
                        checkRes = true;
                    }
                    // 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start.
                    //TVネットスポットの場合は、媒体コードテレビタイムも対象とする.
                    else if (CheckDefGyomkbn(selBaitaiCd, row) == true && (row.hb1SeiKbn == _dataRow.hb1SeiKbn && row.hb1GyomKbn == _dataRow.hb1GyomKbn && row.hb1KokKbn == _dataRow.hb1KokKbn))
                    {
                        //媒体コードがテレビネットスポット、且つターゲット媒体コードがテレビタイムの場合.
                        if (KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(selBaitaiCd) && KkhConstAsh.BaitaiCd.TV_TIME.Equals(_targetBaitaiCd))
                        {
                            checkRes = true;
                        }
                    }
                    // 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End.
                    drKkhDetailInput addRow = dtDetailInput.NewKkhDetailInputRow();
                    //新聞データ.
                    if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
                    {
                        EditInitRowForNewsPaper(addRow, row, checkRes);
                    }
                    //雑誌データ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
                    {
                        EditInitRowForMagazine(addRow, row, checkRes);
                    }
                    //タイムデータ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                    {
                        EditInitRowForTime(addRow, row, checkRes);
                    }
                    //スポットデータ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                    {
                        EditInitRowForSpot(addRow, row, checkRes);
                    }
                    //諸作業データ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
                    { 
                        EditInitRowForWorks(addRow, row, checkRes);
                    }
                    //交通広告データ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
                    {
                        EditInitRowForOOH(addRow, row, checkRes);
                    }
                    //国際/マスデータ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
                    {
                        EditInitRowForKmas(addRow, row, checkRes);
                    }
                    //国際/諸作業データ.
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                    {
                        EditInitRowForKWorks(addRow, row, checkRes);
                    }
                    //IC(インタラクティブメディア).
                    else if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
                    {
                        EditInitRowForIC(addRow, row, checkRes);
                    }
                    dtDetailInput.AddKkhDetailInputRow(addRow);
                }

                _dsDetailAsh.KkhDetailInput.Clear();
                _dsDetailAsh.KkhDetailInput.Merge(dtDetailInput);
                _dsDetailAsh.KkhDetailInput.AcceptChanges();

                //請求データ明細出力設定.
                //得意先がアサヒビール、かつ媒体コードが"130"（新聞）の場合.
                if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo) && KkhConstAsh.BaitaiCd.SHINBUN.Equals(selBaitaiCd))
                {
                    chkFDDetailOutput.Visible = true;

                    // 2016/06/08 請求データ明細チェック対応 HLC K.Fujisaki MOD Start.
                    // ユーザ要望により、新聞の場合は初期チェックは常に有とする.
                    chkFDDetailOutput.Checked = true;

                    ////件名に"題字"が含まれる場合.
                    //if (_dataRow.hb1KKNameKJ.IndexOf("題字") > -1)
                    //{
                    //    chkFDDetailOutput.Checked = true;
                    //}
                    ////その他の場合.
                    //else
                    //{
                    //    chkFDDetailOutput.Checked = false;
                    //}
                    // 2016/06/08 請求データ明細チェック対応 HLC K.Fujisaki MOD End.
                }
                //得意先がアサヒビール以外場合.
                else
                {
                    chkFDDetailOutput.Checked = false;
                    chkFDDetailOutput.Visible = false;
                }
            }
            //明細がある場合.
            else
            {
                //入力明細設定.
                dtKkhDetailInput dtDetailInput = new dtKkhDetailInput();

                //明細件数分ループ処理.
                for (int i = 0; i < _dtKkhDetail.Rows.Count; i++)
                {
                    //入力明細行を取得.
                    drKkhDetailInput addRow = dtDetailInput.NewKkhDetailInputRow();
                    //請求書番号.
                    addRow.seiNo = _dtKkhDetail[i].seiNo;
                    //件名.
                    addRow.kenmei = _dtKkhDetail[i].kenmei;
                    //局コード.
                    string[] arrString = _dtKkhDetail[i].kyokuCd.Split(' ');
                    //媒体コードが雑誌の場合.
                    if (_dtKkhDetail[i].baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                    {
                        addRow.kyokuCd = arrString[arrString.Length - 1];
                    }
                    //媒体コードが雑誌以外の場合.
                    else
                    {
                        addRow.kyokuCd = arrString[0];
                    } 
                    //品種コード.
                    addRow.hinsyuCd = _dtKkhDetail[i].hinsyuCd.Split(' ')[0];
                    //費目名称.
                    addRow.himokuNm = _dtKkhDetail[i].himokuNm;
                    //見積金額.
                    addRow.hnmaeGak = _dtKkhDetail[i].hnmaeGak;
                    //値引率.
                    addRow.hnNeRt = _dtKkhDetail[i].hnNeRt;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                    //値引額.
                    addRow.nebikiGaku = _dtKkhDetail[i].nebikiGaku;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                    //請求金額.
                    addRow.seiGak = _dtKkhDetail[i].seiGak;
                    //消費税率.
                    addRow.zeiRitsu = _dtKkhDetail[i].zeiRitsu;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                    //消費税額.
                    addRow.zeiGaku = _dtKkhDetail[i].zeiGaku;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                    //期間.
                    addRow.kikan = _dtKkhDetail[i].kikan;
                    //媒体コード.
                    addRow.baitaiCd = _dtKkhDetail[i].baitaiCd;
                    // 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start.
                    //得意先媒体コード.
                    addRow.tokuiBaitaiCd = _baitaiUtil.ConvertOldCdToNewCd(addRow.baitaiCd).baitaiCd;
                    // 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End.
                    //代理店コード.
                    addRow.dairitenCd = _dtKkhDetail[i].dairitenCd;
                    //番組コード.
                    addRow.bangumiCd = _dtKkhDetail[i].bangumiCd;
                    //売上明細No.
                    addRow.uriMeiNo = _dtKkhDetail[i].uriMeiNo;
                    //秒数.
                    addRow.byouSuu = _dtKkhDetail[i].byouSuu;
                    //本数.
                    addRow.honSuu = _dtKkhDetail[i].honSuu;
                    //表示順.
                    //媒体コードがテレビスポット、またはラジオスポットの場合.
                    if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
                    {
                        //指定した媒体コードに対応するマスタデータを取得する.
                        dtMasterDataVO dt = GetKyokuMasterData(selBaitaiCd);
                        DataRow[] rows = dt.Select(dt.Column1Column.ColumnName + "='" + addRow.kyokuCd + "'");

                        //対象のマスタデータが1件以上存在する場合.
                        if (rows.Length > 0)
                        {
                            if (((drMasterDataVORow)rows[0]).Column5.Length == 6)
                            {
                                addRow.hyouziJun = "00" + ((drMasterDataVORow)rows[0]).Column5;
                            }
                            else if (((drMasterDataVORow)rows[0]).Column5.Length == 7)
                            {
                                addRow.hyouziJun = "0" + ((drMasterDataVORow)rows[0]).Column5;
                            }
                            else if (((drMasterDataVORow)rows[0]).Column5.Length == 8)
                            {
                                addRow.hyouziJun = ((drMasterDataVORow)rows[0]).Column5;
                            }                         
                        }
                        else
                        {
                            addRow.hyouziJun = "000.0000";
                        }
                    }
                    else
                    {
                        addRow.hyouziJun = "";
                    }
                    //掲載発売日.
                    addRow.keisaiHatsubaiBi = _dtKkhDetail[i].keisaiHatsubaiBi;
                    //朝夕区分.
                    addRow.asaYuuKbn = _dtKkhDetail[i].asaYuuKbn;
                    //記雑区分.
                    addRow.kizatsuKbn = _dtKkhDetail[i].kizatsuKbn;
                    //掲載版.
                    addRow.keisaiBan = _dtKkhDetail[i].keisaiBan;
                    //版数処理区分.
                    addRow.hasuuSyoriKbn = _dtKkhDetail[i].hasuuSyoriKbn;
                    //入力比率.
                    addRow.nyuuryokuHiritsu = _dtKkhDetail[i].nyuuryokuHiritsu;
                    //スペース.
                    addRow.space = _dtKkhDetail[i].space;
                    //放送時間.
                    addRow.housouZikan = _dtKkhDetail[i].housouZikan;
                    //曜日.
                    addRow.youbi = _dtKkhDetail[i].youbi;
                    //局ネット数.
                    addRow.kyokuNetSuu = _dtKkhDetail[i].kyokuNetSuu;
                    //キー局コード.
                    addRow.keyKyokuCd = _dtKkhDetail[i].keyKyokuCd;

                    dtDetailInput.AddKkhDetailInputRow(addRow);
                }

                //入力明細データ設定.
                _dsDetailAsh.KkhDetailInput.Clear();
                _dsDetailAsh.KkhDetailInput.Merge(dtDetailInput);
                _dsDetailAsh.KkhDetailInput.AcceptChanges();

                //請求データ明細出力設定.
                //得意先がアサヒビール、かつ媒体コードが"130"(新聞)の場合.
                if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo) && KkhConstAsh.BaitaiCd.SHINBUN.Equals(selBaitaiCd))
                {
                    chkFDDetailOutput.Visible = true;
                    foreach (drKkhDetail row in _dtKkhDetail.Rows)
                    {
                        //明細にFDSEQが設定されている場合.
                        if (row.fd.Trim() != "")
                        {
                            chkFDDetailOutput.Checked = true;
                            return;
                        }
                    }
                    chkFDDetailOutput.Checked = false;
                    return;
                }
                //得意先がアサヒビール以外場合.
                else
                {
                    chkFDDetailOutput.Checked = false;
                    chkFDDetailOutput.Visible = false;
                }
            }
        }
        #endregion 明細初期表示.

        #region 共通.
        /// <summary>
        /// 共通.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForCommon(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //件名.
            addRow.kenmei = dataRow.hb1KKNameKJ;
            //品種コード.
            addRow.hinsyuCd = "";
            //費目名称.
            addRow.himokuNm = dataRow.hb1HimkNmKJ;
            //見積金額.
            addRow.hnmaeGak = dataRow.hb1ToriGak;
            //値引率.
            addRow.hnNeRt = dataRow.hb1NeviRitu;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //値引額.
            addRow.nebikiGaku = dataRow.hb1NeviGak;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            //請求金額.
            addRow.seiGak = dataRow.hb1SeiGak;
            //消費税率.
            addRow.zeiRitsu = dataRow.hb1SzeiRitu;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //消費税額.
            addRow.zeiGaku = dataRow.hb1SzeiGak;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            //媒体コード.
            addRow.baitaiCd = Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cmbBaitai.SelectedValue);
            /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD Start */
            //得意先媒体コード.
            addRow.tokuiBaitaiCd = _baitaiUtil.ConvertOldCdToNewCd(addRow.baitaiCd).baitaiCd;
            /* 2015/03/04 アサヒ対応 HLC K.Fujisaki ADD End */
            //代理店コード.
            addRow.dairitenCd = "01";

            //媒体コード.
            string selBaitaiCd = Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cmbBaitai.SelectedValue);
            //媒体コードがテレビタイム、ラジオタイム、またはテレビネットスポットの場合.
            if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                /* 2015/06/08 HLC K.Fujisaki ADD Start */
                || selBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT
                /* 2015/06/08 HLC K.Fujisaki ADD End */
                )
            {
                addRow.bangumiCd = " ";
            }
            //媒体コードがテレビスポットの場合.
            else if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT)
            {
                addRow.bangumiCd = "07";
            }
            //媒体コードがラジオスポットの場合.
            else if (selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
            {
                addRow.bangumiCd = "03";
            }
            else
            {
                addRow.bangumiCd = "00";
            }
            //売上明細No.
            addRow.uriMeiNo = dataRow.hb1JyutNo + "-" + dataRow.hb1JyMeiNo + "-" + dataRow.hb1UrMeiNo;
            //端数処理区分.
            addRow.hasuuSyoriKbn = "";
            //入力比率.
            addRow.nyuuryokuHiritsu = "";
        }
        #endregion 共通.

        #region 新聞データ.
        /// <summary>
        /// 新聞データ.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForNewsPaper(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field12);

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = dataRow.hb1SeiNo;
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = dataRow.hb1Field4;
                addRow.kizatsuKbn = dataRow.hb1Field7;
                addRow.keisaiBan = dataRow.hb1Field5;
                addRow.space = dataRow.hb1Field11;
                addRow.housouZikan = "";
                addRow.keisaiHatsubaiBi = dataRow.hb1Field3;
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.keisaiHatsubaiBi = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion 新聞データ.

        #region 雑誌.
        /// <summary>
        /// 雑誌.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForMagazine(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field10);

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes)
            {
                addRow.seiNo = dataRow.hb1SeiNo;
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = dataRow.hb1Field4;
                addRow.kizatsuKbn = dataRow.hb1Field8;
                addRow.keisaiBan = dataRow.hb1Field6;
                addRow.space = dataRow.hb1Field9;
                addRow.housouZikan = "";
                addRow.keisaiHatsubaiBi = dataRow.hb1Field3;
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.keisaiHatsubaiBi = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion 雑誌.

        #region テレビタイム ラジオタイム.
        /// <summary>
        /// テレビタイム ラジオタイム.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForTime(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field8);
            string selBaitaiCd = Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cmbBaitai.SelectedValue);
            if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime
                || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM
                || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
            {
                if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || selBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = GetKyokuMasterData(selBaitaiCd);
                    DataRow[] rows = dt.Select(dt.Column4Column.ColumnName + "='" + dataRow.hb1Field1 + "'");

                    if (rows.Length > 0)
                    {
                        MasterMaintenance.MasterDataVORow row = (MasterMaintenance.MasterDataVORow)rows[0];
                        addRow.bangumiCd = row.Column3;
                    }
                }
            }

            addRow.keisaiHatsubaiBi = dataRow.hb1Field8;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                else if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                else
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.housouZikan = dataRow.hb1Field4;
                    addRow.youbi = dataRow.hb1Field7;
                    addRow.kyokuNetSuu = dataRow.hb1Field3;
                    addRow.keyKyokuCd = _naviParam.DataRow.hb1Field1;
                }
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion テレビタイム ラジオタイム.

        #region テレビスポット 衛星メディア.
        /// <summary>
        /// テレビスポット 衛星メディア.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForSpot(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field4);
            addRow.keisaiHatsubaiBi = dataRow.hb1Field4;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                else if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                else
                {
                    addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                }
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.byouSuu = dataRow.hb1Field5;
                    addRow.honSuu = dataRow.hb1Field6.Trim();
                }

                string selBaitaiCd = Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cmbBaitai.SelectedValue);
                if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
                {
                    Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = GetKyokuMasterData(selBaitaiCd);
                    DataRow[] rows = dt.Select(dt.Column1Column.ColumnName + "='" + addRow.kyokuCd + "'");

                    if (rows.Length > 0)
                    {
                        if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 6)
                        {
                            addRow.hyouziJun = "00" + ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                        else if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 7)
                        {
                            addRow.hyouziJun = "0" + ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                        else if (((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5.Length == 8)
                        {
                            addRow.hyouziJun = ((Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)rows[0]).Column5;
                        }
                    }
                    else
                    {
                        addRow.hyouziJun = "000.0000";
                    }
                }
                else
                {
                    addRow.hyouziJun = "";
                }
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.housouZikan = dataRow.hb1Field4;
                    addRow.youbi = dataRow.hb1Field7;
                    addRow.kyokuNetSuu = dataRow.hb1Field3;
                    addRow.keyKyokuCd = dataRow.hb1Field1;
                }
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion テレビスポット 衛星メディア.

        #region 諸作業.
        /// <summary>
        /// 諸作業.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForWorks(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field5);
            addRow.keisaiHatsubaiBi = dataRow.hb1Field5;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                addRow.kyokuCd = GetKyokuCd("");
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion 諸作業.

        #region OOH.
        /// <summary>
        /// OOH.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForOOH(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field5);
            addRow.keisaiHatsubaiBi = dataRow.hb1Field5;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = dataRow.hb1Field2;
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion OOH.

        #region IC.
        /// <summary>
        /// IC.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForIC(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field5);
            addRow.keisaiHatsubaiBi = dataRow.hb1Field5;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion IC.

        #region 国際マス/データ.
        /// <summary>
        /// 国際マス/データ.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForKmas(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //業務区分が[新聞][雑誌]の場合.
            if (dataRow.hb1GyomKbn.Equals(KKHSystemConst.GyomKbn.Shinbun) || dataRow.hb1GyomKbn.Equals(KKHSystemConst.GyomKbn.Zashi))
            {
                //掲載日が8桁以上の場合.
                if (dataRow.hb1Field3.Length >= 8)
                {
                    //掲載発売日に設定.
                    addRow.keisaiHatsubaiBi = dataRow.hb1Field3.Substring(0, 8);
                }
                else
                {
                    //期間に設定.
                    addRow.keisaiHatsubaiBi = dataRow.hb1Field3;
                }
            }
            else
            {
                addRow.kikan = FormatPeriod(dataRow.hb1Field3);
            }

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes)
            {
                addRow.seiNo = "";
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field1);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion 国際マス/データ.

        #region 国際/諸作業データ.
        /// <summary>
        /// 国際/諸作業データ.
        /// </summary>
        /// <param name="addRow"></param>
        /// <param name="dataRow"></param>
        /// <param name="checkRes"></param>
        private void EditInitRowForKWorks(Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailInputRow addRow, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow, bool checkRes)
        {
            //共通設定項目の編集.
            EditInitRowForCommon(addRow, dataRow, checkRes);

            //媒体コードデフォルトチェックの結果で設定値を変更しない項目.
            addRow.kikan = FormatPeriod(dataRow.hb1Field4);
            addRow.keisaiHatsubaiBi = dataRow.hb1Field4;

            //媒体コードデフォルトチェックの結果で設定値を変更する項目.
            if (checkRes == true)
            {
                addRow.seiNo = "";
                addRow.kyokuCd = GetKyokuCd(dataRow.hb1Field2);
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
            else
            {
                addRow.seiNo = "";
                addRow.kyokuCd = "";
                addRow.byouSuu = "";
                addRow.honSuu = "";
                addRow.hyouziJun = "";
                addRow.asaYuuKbn = "";
                addRow.kizatsuKbn = "";
                addRow.keisaiBan = "";
                addRow.space = "";
                addRow.housouZikan = "";
                addRow.youbi = "";
                addRow.kyokuNetSuu = "";
                addRow.keyKyokuCd = "";
            }
        }
        #endregion 国際/諸作業データ.

        #region 媒体、業務区分、請求区分チェック.
        /// <summary>
        /// 媒体、業務区分、請求区分チェック.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private bool CheckDefGyomkbn(string baitaiCd, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            //媒体 = 新聞. 
            if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN)
            {
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
                {
                    return true;
                }
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
            {
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Zashi)
                {
                    return true;
                }
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || baitaiCd == KkhConstAsh.BaitaiCd.BS
                    || baitaiCd == KkhConstAsh.BaitaiCd.CS
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
            {
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime
                    || (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio && dataRow.hb1TmspKbn == KKHSystemConst.TimeSpotKbn.Time)
                    || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                {
                    return true;
                }
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT)
            {
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio && dataRow.hb1TmspKbn == KKHSystemConst.TimeSpotKbn.Spot))
                {
                    return true;
                }
            }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU)
            {
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.OohM)
                {
                    return true;
                }
            }
            else
            {
                if (dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.Shinbun
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.Zashi
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.TVTime
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.TVSpot
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.Radio
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.EiseiM
                    && dataRow.hb1GyomKbn != KKHSystemConst.GyomKbn.OohM)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion 媒体、業務区分、請求区分チェック.

        #region [期間]を表示用のフォーマットに変換します.
        /// <summary>
        /// [期間]を表示用のフォーマットに変換します.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = "";

            if (str.Length >= 16)
            {
                ret = str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日" + " - " + str.Substring(8, 4) + "年" + str.Substring(12, 2) + "月" + str.Substring(14, 2) + "日";
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日";
            }
            else
            {
                return str;
            }

            return ret;
        }
        #endregion [期間]を表示用のフォーマットに変換します.

        #region 受注ダウンロードの媒体コードから変換マスタで変換後の媒体コードを取得します.
        /// <summary>
        /// 受注ダウンロードの媒体コードから変換マスタで変換後の媒体コードを取得します.
        /// </summary>
        /// <param name="bfKyokuCd"></param>
        /// <returns></returns>
        private string GetKyokuCd(string bfKyokuCd)
        {
            string baitaiCd = cmbBaitai.SelectedValue.ToString();
            string afKyokuCd = "";

            MasterMaintenance.MasterDataVODataTable dt;
            MasterMaintenance.MasterDataVORow[] rows;

            switch (baitaiCd)
            {
                case KkhConstAsh.BaitaiCd.TV_TIME:
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                    dt = FindMasterData(KkhConstAsh.MasterKey.TV_KYOKU_HENNKAN);
                    rows = ((MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column + "='" + bfKyokuCd + "'"));
                    if (rows.Length > 0)
                    {
                        afKyokuCd = rows[0].Column2;
                    }
                    break;
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    dt = FindMasterData(KkhConstAsh.MasterKey.RADIO_KYOKU_HENNKAN);
                    rows = ((MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column + "='" + bfKyokuCd + "'"));
                    if (rows.Length > 0)
                    {
                        afKyokuCd = rows[0].Column2;
                    }
                    break;
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    dt = FindMasterData(KkhConstAsh.MasterKey.SHINBUN_HENNKAN);
                    rows = ((MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column + "='" + bfKyokuCd + "'"));
                    if (rows.Length > 0)
                    {
                        afKyokuCd = rows[0].Column2;
                    }
                    break;
                case KkhConstAsh.BaitaiCd.ZASHI:
                    dt = FindMasterData(KkhConstAsh.MasterKey.ZASSHI_HENNKAN);
                    rows = ((MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column + "='" + bfKyokuCd + "'"));
                    if (rows.Length > 0)
                    {
                        afKyokuCd = rows[0].Column2;
                    }
                    break;
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    dt = FindMasterData(KkhConstAsh.MasterKey.OOH_HENNKAN);
                    rows = ((MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column + "='" + bfKyokuCd + "'"));
                    if (rows.Length > 0)
                    {
                        afKyokuCd = rows[0].Column2;
                    }
                    break;
                default:
                    afKyokuCd = bfKyokuCd;
                    break;
            }

            return afKyokuCd;
        }
        #endregion 受注ダウンロードの媒体コードから変換マスタで変換後の媒体コードを取得します.
        #endregion 明細初期表示.

        #region FD SEQを取得する.
        /// <summary>
        /// FD SEQを取得する.
        /// </summary>
        /// <param name="urMeiNo"></param>
        /// <returns></returns>
        private int GetFdSeq(string urMeiNo)
        {
            DetailAshProcessController processController = DetailAshProcessController.GetInstance();
            DetailAshProcessController.GetFDSeqParam param = new DetailAshProcessController.GetFDSeqParam();
            param.esqId = _naviParam.strEsqId;
            param.egCd = _dataRow.hb1EgCd;
            param.tksKgyCd = _dataRow.hb1TksKgyCd;
            param.tksBmnSeqNo = _dataRow.hb1TksBmnSeqNo;
            param.tksTntSeqNo = _dataRow.hb1TksTntSeqNo;
            param.yymm = _dataRow.hb1Yymm;
            param.urMeiNo = urMeiNo;
            String FDSeq = processController.GetFDSeq(param);

            return KKHUtility.IntParse(FDSeq);
        }
        #endregion FD SEQを取得する.

        #region OKボタンクリック時の入力チェック.
        /// <summary>
        /// OKボタンクリック時の入力チェック.
        /// </summary>
        /// <returns></returns>
        private bool CheckBtnOK(out bool CheckBaitaiFlag)
        {
            //初期設定.
            CheckBaitaiFlag = false;
            string selBaitaiCd = cmbBaitai.SelectedValue.ToString();

            //タイムデータの場合に行うチェック.
            if (selBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME 
                || selBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                || selBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
            {
                //局と品種の組み合わせで重複チェック.
                for (int i = 0; i < spdDetailInput_Sheet1.RowCount - 1; i++)
                {
                    string kyokuCd = KKHUtility.ToString(spdDetailInput_Sheet1.Cells[i, COLIDX_KYOKUCD].Value);
                    string hinsyuCd = KKHUtility.ToString(spdDetailInput_Sheet1.Cells[i, COLIDX_HINSYUCD].Value);

                    //明細件数分ループ処理.
                    for (int j = i + 1; j < spdDetailInput_Sheet1.RowCount; j++)
                    {
                        string kyokuCd2 = KKHUtility.ToString(spdDetailInput_Sheet1.Cells[j, COLIDX_KYOKUCD].Value);
                        string hinsyuCd2 = KKHUtility.ToString(spdDetailInput_Sheet1.Cells[j, COLIDX_HINSYUCD].Value);


                        if (kyokuCd == kyokuCd2 && hinsyuCd == hinsyuCd2)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0068, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            /* 2015/03/11 アサヒ対応 JSE Miyanoue ADD Start */
            List<String> baitaiCdList = new List<String>();
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            //媒体コード、媒体名称のリスト分ループ処理.
            for (int j = 0; j < resultList.Count; j++)
            {
                baitaiCdList.Add(resultList[j].baitaiCd);
            }
            /* 2015/03/11 アサヒ対応 JSE Miyanoue ADD End */

            //明細件数分ループ処理.
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                string chkVal = string.Empty;
                chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_BAITAICD].Text;
                /* 2015/03/11 アサヒ対応 JSE Miyanoue DEL Start */
                //if (chkVal == KkhConstAsh.BaitaiCd.TV_TIME
                //    || chkVal == KkhConstAsh.BaitaiCd.TV_SPOT
                //    || chkVal == KkhConstAsh.BaitaiCd.RADIO_TIME
                //    || chkVal == KkhConstAsh.BaitaiCd.RADIO_SPOT
                //    || chkVal == KkhConstAsh.BaitaiCd.SHINBUN
                //    || chkVal == KkhConstAsh.BaitaiCd.ZASHI
                //    || chkVal == KkhConstAsh.BaitaiCd.KOUTSU
                //    || chkVal == KkhConstAsh.BaitaiCd.OKUGAI
                //    || chkVal == KkhConstAsh.BaitaiCd.SEISAKU
                //    || chkVal == KkhConstAsh.BaitaiCd.EVENT
                //    //2013/02/22 hlc sonobe PR媒体追加対応　Start
                //    || chkVal == KkhConstAsh.BaitaiCd.PR
                //    //2013/02/22 hlc sonobe PR媒体追加対応　End
                //    || chkVal == KkhConstAsh.BaitaiCd.SONOTA
                //    || chkVal == KkhConstAsh.BaitaiCd.NEW_MEDIA
                //    || chkVal == KkhConstAsh.BaitaiCd.INTERNET
                //    || chkVal == KkhConstAsh.BaitaiCd.BS
                //    || chkVal == KkhConstAsh.BaitaiCd.CS
                //    || chkVal == KkhConstAsh.BaitaiCd.TYOUSA
                //    || chkVal == KkhConstAsh.BaitaiCd.MEDIA_FEE
                //    || chkVal == KkhConstAsh.BaitaiCd.BRAND_FEE)
                if (baitaiCdList.Contains(chkVal))
                /* 2015/03/11 アサヒ対応 JSE Miyanoue DEL End */
                {
                    //チェック後のメッセージで「はい」を選択した場合、以降の詳細情報の設定状況チェックは行わない.
                    if (CheckBaitaiFlag == false)
                    {
                        //指定媒体毎の詳細情報項目が設定されているかをチェック.
                        if (CheckBaitaiData(i, chkVal) == false)
                        {
                            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_W0040, null, KKHSystemConst.KoteiMongon.ERR_SET_DETAIL_INFO, MessageBoxButtons.OKCancel))
                            {
                                return false;
                            }
                            CheckBaitaiFlag = true;
                        }
                    }
                }
                else
                {
                    if (chkVal == "")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0078, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0004, new string[] { chkVal }, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    }
                    return false;
                }

                //スペース.
                if (spdDetailInput_Sheet1.Columns[COLIDX_SPACE].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_SPACE].Text;

                    if (KKHUtility.GetByteCount(chkVal) > 12)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0016, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }

                //掲載日.
                if (spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_KEISAIHATSUBAIBI].Text.Replace("年","").Replace("月","").Replace("日","");

                    if (chkVal != "" && KKHUtility.IsDate(chkVal, "yyyyMMdd") == false)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0003, new string[] { spdDetailInput_Sheet1.Columns[COLIDX_KEISAIHATSUBAIBI].Label }, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }

                //秒数.
                if (spdDetailInput_Sheet1.Columns[COLIDX_BYOUSUU].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_BYOUSUU].Text;
                    if (chkVal != "" && (KKHUtility.GetByteCount(chkVal) > 3 || KKHUtility.IsNumeric(chkVal) == false))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0082, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }

                //本数.
                if (spdDetailInput_Sheet1.Columns[COLIDX_HONSUU].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_HONSUU].Text;

                    if (chkVal != "" && (KKHUtility.GetByteCount(chkVal) > 3 || KKHUtility.IsNumeric(chkVal) == false))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0088, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }
                /* 2013/04/04 消費税チェック追加 HLC T.Sonobe ADD Start */
                //消費税率.
                if (spdDetailInput_Sheet1.Columns[COLIDX_ZEIRITSU].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_ZEIRITSU].Text;

                    /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD Start */
                    //見積金額が空の場合.
                    if (string.IsNullOrEmpty(KKHUtility.ToString(spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value).Trim()))
                    {
                        spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value = 0M;
                    }
                    /* 2016/12/05 アサヒ消費税対応 HLC K.Soga ADD End */

                    //見積金額の取得.
                    decimal seiGak = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_HNMAEGAK].Value.ToString());

                    if (seiGak > 0 && chkVal == "0.0" || KKHUtility.IsNumeric(chkVal) == false )
                    {
                        DialogResult dr = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { "消費税率が｢0.0｣の明細がありますが登録してもよろしいでしょうか" }, KKHSystemConst.KoteiMongon.DETAIL_INPUT, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                /* 2013/04/04 消費税チェック追加 HLC T.Sonobe ADD End */
            }

            return true;
        }
        #endregion OKボタンクリック時の入力チェック.

        #region 指定媒体毎の詳細情報項目が設定されているかをチェック.
        /// <summary>
        /// 指定媒体毎の詳細情報項目が設定されているかをチェック.
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private bool CheckBaitaiData(int rowIdx, string baitaiCd)
        {
            //掲載日.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_KEISAIHATSUBAIBI].Text.Trim() == "")
            {
                return false;
            }

            //スペース.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_SPACE].Text.Trim() == "")
            {
                //新聞・雑誌の場合.
                if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN || baitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    return false;
                }
            }

            //放送時間/路線・駅名称.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_HOUSOUZIKAN].Text.Trim() == "")
            {
                //タイム・交通の場合.
                if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD Start */
                    || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD End */
                {
                    return false;
                }
            }

            //曜日.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_YOUBI].Text.Trim() == "")
            {
                //テレビタイム、テレビネットタイムの場合.
                if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD Start */
                    || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD End */
                {
                    return false;
                }
            }

            //局ネット数.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_KYOKUNETSUU].Text.Trim() == "")
            {
                //タイムの場合.
                if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME)
                {
                    return false;
                }
            }

            //キー局.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_KEYKYOKUCD].Text.Trim() == "")
            {
                //タイム、ネットスポットの場合.
                if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    || baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD Start */
                    || baitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 K.Fujisaki ADD End */
                {
                    return false;
                }
            }

            return true;
        }
        #endregion 指定媒体毎の詳細情報項目が設定されているかをチェック.

        #region デフォルト媒体コードを取得する.
        /// <summary>
        /// デフォルト媒体コードを取得する.
        /// </summary>
        /// <returns></returns>
        private string GetDefaultBaitaiCd()
        {
            string defaultBaitaiCd = "";

            if (_dtKkhDetail.Rows.Count > 0)
            {
                //明細がある場合、パラメータとして渡された明細の媒体コードを使用する.
                defaultBaitaiCd = _dtKkhDetail[0].baitaiCd;
            }
            else
            {
                //明細がない場合はパラメータとして渡された対象媒体コードを使用する.
                defaultBaitaiCd = _targetBaitaiCd;
            }

            return defaultBaitaiCd;
        }
        #endregion デフォルト媒体コードを取得する.

        #region ペースト処理.
        /// <summary>
        /// ペースト処理.
        /// </summary>
        /// <param name="spView"></param>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>
        /// true = 貼り付け継続.
        /// false = 貼り付け終了.
        /// </returns>
        private bool isSetContinuePast(FarPoint.Win.Spread.SpreadView spView, string val, int row, int col)
        {
            SheetView shView = spView.GetSheetView(); ;

            bool multiCopyFlg = true;

            //コピー例外発生をTry～Catchで吸収する.
            //キー = [列,行] 値 = [貼り付け値].
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            //複数コピーでない場合.
            if (pastDic.Count == 1)
            {
                multiCopyFlg = false;
            }

            //コピー分のセル走査.
            foreach (string pastKey in pastDic.Keys)
            {
                //キー[列, 行]を分割.
                string[] keySplitArr = pastKey.Split(KKHSystemConst.SPLIT_VAL.ToCharArray());

                //列.
                int addCol = int.Parse(keySplitArr[0]);
                //行. 
                int addRow = int.Parse(keySplitArr[1]);
                try
                {
                    //ペースト対象列.
                    int colNum = col + addCol;
                    //ペースト対象行.
                    int rowNum = row + addRow;

                    //コピー可能な列か確認する.
                    if (!isCopyOKColumn(shView, colNum, rowNum))
                    {
                        continue;
                    }

                    //ペースト.
                    shView.Cells[rowNum, colNum].Text = pastDic[pastKey];

                    //コピー後のカラム変更による検証処理.
                    ChangeEventArgs changeEvent = new ChangeEventArgs(spView, rowNum, colNum);

                    //セル変更処理実行.
                    spdDetailInput_Change(this.spdDetailInput, changeEvent);
                }
                //セルタイプの違い等でのエラー回避用.
                catch { }
            }

            return multiCopyFlg;
        }
        #endregion ペースト処理.

        #region コピー可能列確認.
        /// <summary>
        /// コピー可能列確認.
        /// </summary>
        /// <param name="shView"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isCopyOKColumn(SheetView shView, int col, int row)
        {
            Column actColumn = shView.Columns[col];

            // ロックされている場合.
            if (actColumn.Locked)
            {
                return false;
            }

            //非表示列へは貼り付け不可とする.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType || actColumn.CellType is NumberCellType)
            {
                // セルタイプがテキストの場合.
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion コピー可能列確認.

        #region 表示順をマスタから取得し、設定する.
        /// <summary>
        /// 表示順をマスタから取得し、設定する.
        /// </summary>
        /// <param name="baitaicd">媒体コード </param>
        /// <param name="keycode">局コード </param>
        /// <returns></returns>
        private string hyoujiJunSet(string baitaicd,string keycode)
        {
            string MasterKey = string.Empty;

            switch (baitaicd)
            {
                //新聞.
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    MasterKey = "0002";
                    break;
                //雑誌.
                case KkhConstAsh.BaitaiCd.ZASHI:
                    MasterKey = "0003";
                    break;
                //テレビタイム、テレビスポット、テレビネットスポット.
                case KkhConstAsh.BaitaiCd.TV_TIME:
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                    MasterKey = "0004";
                    break;
                //ラジオタイム,ラジオスポット.
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    MasterKey = "0005";
                    break;
                //交通.
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    MasterKey = "0006";
                    break;
                //制作.
                case KkhConstAsh.BaitaiCd.SEISAKU:
                    MasterKey = "0013";
                    break;
                //メディアフィー.
                case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    MasterKey = "0016";
                    break;
                //ブランド管理フィー.
                case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    MasterKey = "0017";
                    break;
                //屋外マスタ.
                case KkhConstAsh.BaitaiCd.OKUGAI:
                    MasterKey = "0014";
                    break;
                //その他.
                case KkhConstAsh.BaitaiCd.SONOTA:
                    MasterKey = "0015";
                    break;
            }

            if (string.IsNullOrEmpty(MasterKey))
            {
                return string.Empty;
            }

            //メンバ変数にマスタデータが入っていない場合は取得する.
            if (MstDS.MasterDataVO.Rows.Count == 0)
            {
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond(_naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            MasterKey,
                                                                                            null);
                //エラーの場合.
                if (result.HasError)
                {
                    throw new Exception();
                }

                MstDS.Clear();
                MstDS.Merge(result.MasterDataSet);
            }

            //キーコードが一致する表示順をセットする.
            foreach (MasterMaintenance.MasterDataVORow row in MstDS.MasterDataVO.Select("Column1 = '" + keycode + "'"))
            {
                //現時点の対策.マスタが左詰めで値を取得しているため、Columnを直打ちしている.
                switch (baitaicd)
                {
                    //新聞.
                    case KkhConstAsh.BaitaiCd.SHINBUN:
                        return row.Column4.Trim();
                    //雑誌.
                    case KkhConstAsh.BaitaiCd.ZASHI:
                        return row.Column6.Trim();
                    //テレビタイム、テレビスポット、テレビネットスポット.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.TV_SPOT:
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                    /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
                        return row.Column5.Trim();
                        break;
                    //ラジオタイム,ラジオスポット.
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                        return row.Column5.Trim();
                    //交通.
                    case KkhConstAsh.BaitaiCd.KOUTSU:
                        return row.Column4.Trim();
                    //制作.
                    case KkhConstAsh.BaitaiCd.SEISAKU:
                        return row.Column4.Trim();
                    //メディアフィー.
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                        return row.Column3.Trim();
                    //ブランド管理フィー.
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                        return row.Column3.Trim();
                    //屋外マスタ.
                    case KkhConstAsh.BaitaiCd.OKUGAI:
                        return row.Column4.Trim();
                    //その他.
                    case KkhConstAsh.BaitaiCd.SONOTA:
                        return row.Column4.Trim();
                }
            }

            //一致しなかったら空を返す.
            return string.Empty;
        }
        #endregion 表示順をマスタから取得し、設定する.

        #region 秒数と本数を0埋めする.
        /// <summary>
        /// 秒数と本数を0埋めする.
        /// </summary>
        private void PadLeftByosuHonsu()
        {
            //秒数.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_BYOUSUU)
            {
                if (!string.IsNullOrEmpty(spdDetailInput_Sheet1.ActiveCell.Text))
                {
                    spdDetailInput_Sheet1.ActiveCell.Text = spdDetailInput_Sheet1.ActiveCell.Text.PadLeft(3, '0');
                }
            }
            //本数.
            else if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_HONSUU)
            {
                if (!string.IsNullOrEmpty(spdDetailInput_Sheet1.ActiveCell.Text))
                {
                    spdDetailInput_Sheet1.ActiveCell.Text = spdDetailInput_Sheet1.ActiveCell.Text.PadLeft(3, '0');
                }
            }
        }
        #endregion 秒数と本数を0埋めする.
        #endregion メソッド.
    }
}
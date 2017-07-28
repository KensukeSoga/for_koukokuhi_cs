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
using Isid.KKH.Epson.ProcessController.Detail;
using Isid.KKH.Epson.Schema;
using Isid.KKH.Epson.Utility;
using Isid.KKH.Epson.View.Detail;
using drMasterData = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow;

namespace Isid.KKH.Epson.View.Detail
{
    /// <summary>
    /// 明細入力画面(エプソン). 
    /// </summary>
    public partial class DetailInputEpson : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.
        #region 明細(一覧)カラムインデックス.
        /// <summary>
        /// 請求書対象外列フラグインデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEIFLG = 0;
        /// <summary>
        /// 請求書番号列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEINO = 1;
        /// <summary>
        /// 売上明細NO列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_URIMEINO = 2;
        /// <summary>
        /// 広告件名列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_KOUKOKUKENMEI = 3;
        /// <summary>
        /// 取引担当者コード列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_TRITNTCD = 4;
        /// <summary>
        /// 件名列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 5;
        /// <summary>
        /// 請求件名列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEI_KENMEI = 6;
        /// <summary>
        /// 取引識別名列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_TRISIKIKEYCD = 7;
        /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
        /// <summary>
        /// 起票部門コードインデックス.
        /// </summary>
        public const int COLIDX_MLIST_KIHYOUBMNCD = 8;
        /// <summary>
        /// 原価センタインデックス.
        /// </summary>
        public const int COLIDX_MLIST_GENKACENTER = 9;
        /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */
        /// <summary>
        /// 事前金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BFKNGK = 10;
        /// <summary>
        /// 事後金額列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_AFKNGK = 11;
        /// <summary>
        /// 業務区分列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_GYMKBN = 12;
        /// <summary>
        /// 請求区分列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEIKBN = 13;
        /// <summary>
        /// 取引担当者名称列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_TRITNTNM = 14;
        /// <summary>
        /// 取引識別情報コード列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_TRISIKICD = 15;
        /// <summary>
        /// 取引識別情報キーコード列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_TRISIKINM = 16;
        /// <summary>
        /// 指図No列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SSNO = 17;
        /// <summary>
        /// セグメントNo列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEGNO = 18;
        /// <summary>
        /// ソートキー列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SORT_KEY = 19;
        /// <summary>
        /// 金額(税込み)列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_SEI_KINGAKU = 20;
        /// <summary>
        /// 消費税列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_ZEI_GAKU = 21;
        /// <summary>
        /// 税抜き金額列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_ZEI_NKINGAKU = 22;
        /// <summary>
        /// 計上日列インデックス. 
        /// </summary>
        public const int COLIDX_MLIST_KEIZYOUBI = 23;
        #endregion 明細(一覧)カラムインデックス.

        #region マスタ取得キー.
        /// <summary>
        /// 取引識別情報マスタ取得キー：0001.
        /// </summary>
        internal const string MST_TRISIKI = "0001";
        /// <summary>
        /// 取引担当者マスタ取得キー：0002. 
        /// </summary>
        internal const string MST_TRITNT = "0002";
        #endregion マスタ取得キー.
        /* 2017/04/14　エプソン仕入先情報変更対応 A.Nakamura ADD Start */
        #region 固定文言.
        /// <summary>
        /// CODE.
        /// </summary>
        internal const string HIDEVALUE = "CODE";
        /// <summary>
        /// NAME.
        /// </summary>
        internal const string DISPLAYVALUE = "NAME";
        #endregion 固定文言.
        /* 2017/04/14　エプソン仕入先情報変更対応 A.Nakamura ADD End */
        #endregion 定数.

        #region メンバ変数
        /// <summary>
        /// 明細入力画面ナビパラメータ 
        /// </summary>
        private DetailInputEpsonNaviParameter _naviParam = new DetailInputEpsonNaviParameter();
        /// <summary>
        /// 明細種別
        /// </summary>
        private String _kbn;
        /// <summary>
        /// 選択中明細行インデックス 
        /// </summary>
        private int _rowDetailIndex = -1;
        /// <summary>
        /// 明細シート 
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        /// <summary>
        /// 文字エンコーディング 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        /// <summary>
        /// マスタデータ
        /// </summary>
        KkhMasterUtilityEpson _master;

        #region ワーク領域
        /// <summary>
        /// 取引担当者名
        /// </summary>
        private String _triTntNm;
        /// <summary>
        /// 取引識別コード
        /// </summary>
        private String _triSikiCd;
        /// <summary>
        /// 取引識別名 
        /// </summary>
        private String _triSikiNm;
        /// <summary>
        /// 指図No
        /// </summary>
        private String _ssNo;
        /// <summary>
        /// セグメントNo
        /// </summary>
        private String _segNo;
        /// <summary>
        /// ソートキー
        /// </summary>
        private String _sortKey;
        #endregion ワーク領域.
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailInputEpson()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント.
        #region フォームロードイベント.
        /// <summary>
        /// フォームロードイベント. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputEpson_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化 .
            InitializeControl();
            // 各コントロールの編集. 
            editControl();
        }
        #endregion フォームロードイベント.

        #region 画面遷移時に実行される.
        /// <summary>
        /// 画面遷移時に実行される. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputEpson_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (DetailInputEpsonNaviParameter)arg.NaviParameter;
                _kbn = _naviParam.Kbn;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
            }
        }
        #endregion 画面遷移時に実行される.

        #region OKボタンクリックイベント
        ///<summary>
        ///OKボタンクリックイベント 
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            detailDataSet();
            DetailInputEpsonNaviParameter outNaviParam = new DetailInputEpsonNaviParameter();

            outNaviParam = _naviParam;
            outNaviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;

            Navigator.Backward(this, outNaviParam, null, true);
            this.Close();
        }
        #endregion OKボタンクリックイベント

        #region キャンセルボタンクリックイベント.
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
        #endregion キャンセルボタンクリックイベント.

        #region 取引担当者チェンジイベント.
        /// <summary>
        /// 取引担当者チェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTriTnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTriTnt.Text))
            {
                _triTntNm = "";
            }
            else
            {
                // 取引担当者マスタ情報取得.
                KkhMasterUtilityEpson.TRITNT_DATA triTnt = _master.GetTRITNT(cmbTriTnt.SelectedValue.ToString());

                if (triTnt != null)
                {
                    _triTntNm = triTnt.name;
                }
                else
                {
                    _triTntNm = "";
                }
            }
        }
        #endregion 取引担当者チェンジイベント.

        #region 取引識別名チェンジイベント.
        /// <summary>
        /// 取引識別名チェンジイベント  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTriSiki_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTriSiki.Text))
            {
                _triSikiCd = "";
                _triSikiNm = "";
                _ssNo = "";
                _segNo = "";
                _sortKey = "";
            }
            else
            {
                // 取引識別情報マスタ情報取得.
                KkhMasterUtilityEpson.TRISIKI_DATA triSiki = _master.GetTRISIKI(cmbTriSiki.SelectedValue.ToString());

                if (triSiki != null)
                {
                    _triSikiCd = triSiki.code;
                    _triSikiNm = triSiki.name;
                    _ssNo = triSiki.ssNo;
                    _segNo = triSiki.segNo;
                    _sortKey = triSiki.sortKey;
                }
                else
                {
                    _triSikiCd = "";
                    _triSikiNm = "";
                    _ssNo = "";
                    _segNo = "";
                    _sortKey = "";
                }
            }
        }
        #endregion 取引識別名チェンジイベント.

        #region 広告件名テキストチェンジイベント.
        /// <summary>
        /// 広告件名テキストチェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKoukokuKenmei_TextChanged(object sender, EventArgs e)
        {
            if (_enc.GetByteCount(txtKoukokuKenmei.Text) > txtKoukokuKenmei.MaxLength)
            {
                txtKoukokuKenmei.Text = _enc.GetString(_enc.GetBytes(txtKoukokuKenmei.Text), 0, txtKoukokuKenmei.MaxLength);
            }
        }
        #endregion 広告件名テキストチェンジイベント.

        #region 件名テキストチェンジイベント.
        /// <summary>
        /// 件名テキストチェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenmei_TextChanged(object sender, EventArgs e)
        {
            if (_enc.GetByteCount(txtKenmei.Text) > txtKenmei.MaxLength)
            {
                txtKenmei.Text = _enc.GetString(_enc.GetBytes(txtKenmei.Text), 0, txtKenmei.MaxLength);
            }
        }
        #endregion 件名テキストチェンジイベント.

        #region 請求金額変更時イベント.
        /// <summary>
        /// 請求金額変更時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSeiKingaku_TextChanged(object sender, EventArgs e)
        {
            txtZeiNKingaku.Text = (KKHUtility.DecParse(txtSeiKingaku.Text) - KKHUtility.DecParse(txtSyouhizei.Text)).ToString("###,###,###,##0");
        }
        #endregion 請求金額変更時イベント.

        #region 消費税額変更時イベント.
        /// <summary>
        /// 消費税額変更時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSyouhizei_TextChanged(object sender, EventArgs e)
        {
            txtZeiNKingaku.Text = (KKHUtility.DecParse(txtSeiKingaku.Text) - KKHUtility.DecParse(txtSyouhizei.Text)).ToString("###,###,###,##0");
        }
        #endregion 消費税額変更時イベント.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの初期表示処理.
        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
        }
        #endregion 各コントロールの初期表示処理.

        #region 明細データ設定.
        /// <summary>
        /// 明細データ設定. 
        /// </summary>
        private void detailDataSet()
        {
            // 広告件名. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KOUKOKUKENMEI].Text = txtKoukokuKenmei.Text;

            // 件名. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KENMEI].Text = txtKenmei.Text;

            // 請求件名. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEI_KENMEI].Text = txtSeiKenmei.Text;

            /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
            //起票部門CD 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KIHYOUBMNCD].Text = cmbKihyouBmnCd.Text;

            // 原価センタ. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_GENKACENTER].Text = cmbGenkaCenter.Text;
            /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */

            // 事前金額. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_BFKNGK].Text = txtBfKngk.Text;

            // 事後金額. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_AFKNGK].Text = txtAfKngk.Text;

            // 金額（税込み）.

            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEI_KINGAKU].Text = txtSeiKingaku.Text;

            // 消費税. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_ZEI_GAKU].Text = txtSyouhizei.Text;

            // 税抜き金額. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_ZEI_NKINGAKU].Text = txtZeiNKingaku.Text;

            // 計上日. 
            String date = KKHUtility.DateToStr(dtpKeizyouBi.Text);

            if (date.Length == 8)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KEIZYOUBI].Text = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KEIZYOUBI].Text = date;
            }

            // 請求対象外フラグ. 
            if (chkSeikyuFlg.Checked)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEIFLG].Text = "True";
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEIFLG].Text = "False";
            }

            // 取引担当者名（キーコード）. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRITNTCD].Text = cmbTriTnt.Text;

            // 取引担当者名.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRITNTNM].Text = _triTntNm;

            // 取引識別名（キーコード）.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKIKEYCD].Text = cmbTriSiki.Text;

            // 取引識別コード. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKICD].Text = _triSikiCd;

            // 取引識別名. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKINM].Text = _triSikiNm;

            // 指図No 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SSNO].Text = _ssNo;

            // セグメントNo
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEGNO].Text = _segNo;

            // ソートキー. 
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SORT_KEY].Text = _sortKey;
        }
        #endregion 明細データ設定.

        #region 各コントロールの編集処理.
        /// <summary>
        /// 各コントロールの編集処理. 
        /// </summary>
        private void editControl()
        {
            GetMasterData();

            _master = new KkhMasterUtilityEpson();

            _master.GetMasterData(_naviParam);

            //請求番号.
            String seikyuNo = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEINO].Text.Trim();

            if (string.IsNullOrEmpty(seikyuNo))
            {
                txtSeikyuNo1.Text = "";
                txtSeikyuNo2.Text = "";
            }
            else
            {
                String[] s = seikyuNo.Split('-');

                if (s.Length == 2)
                {
                    txtSeikyuNo1.Text = s[0];
                    txtSeikyuNo2.Text = s[1];
                }
                else
                {
                    txtSeikyuNo1.Text = seikyuNo;
                    txtSeikyuNo2.Text = "";
                }
            }

            // 売上明細NO 
            txtUriMeiNo.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_URIMEINO].Text;

            // 広告件名. 
            txtKoukokuKenmei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KOUKOKUKENMEI].Text;

            // 件名. 
            txtKenmei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KENMEI].Text;

            // 請求件名. 
            txtSeiKenmei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEI_KENMEI].Text;

            // 取引識別名（キーコード）.
            cmbTriSiki.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKIKEYCD].Text;

            /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura  ADD Start */
            ////起票部門CD 
            cmbKihyouBmnCd.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KIHYOUBMNCD].Text;

            //// 原価センタ. 
            cmbGenkaCenter.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_GENKACENTER].Text;
            /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura  ADD End */

            // 事前金額. 
            txtBfKngk.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_BFKNGK].Text;

            // 事後金額. 
            txtAfKngk.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_AFKNGK].Text;

            // 金額（税込み） 
            txtSeiKingaku.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEI_KINGAKU].Text;

            // 消費税 
            txtSyouhizei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_ZEI_GAKU].Text;

            // 税抜き金額 
            txtZeiNKingaku.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_ZEI_NKINGAKU].Text;

            // 計上日 //TODO 
            if (KKHUtility.StringCnvDateTime(_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KEIZYOUBI].Text) == DateTime.MinValue)
            { }
            else
            {
                dtpKeizyouBi.Text = KKHUtility.StringCnvDateTime(_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_KEIZYOUBI].Text).ToString();
            }

            // 請求対象外フラグ 
            if (bool.Parse(_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEIFLG].Text))
            {
                chkSeikyuFlg.Checked = true;
            }
            else
            {
                chkSeikyuFlg.Checked = false;
            }


            // 取引担当者名（キーコード） 
            cmbTriTnt.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRITNTCD].Text;

            // 取引担当者名.
            _triTntNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRITNTNM].Text;

            // 取引識別コード.
            _triSikiCd = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKICD].Text;

            // 取引識別名.
            _triSikiNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_TRISIKINM].Text;

            // 指図No
            _ssNo = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SSNO].Text;

            // セグメントNo
            _segNo = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SEGNO].Text;

            // ソートキー. 
            _sortKey = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, COLIDX_MLIST_SORT_KEY].Text;

            //明細入力一覧.

            if (String.Equals(_kbn, "1"))
            {
                lblSeikyuNo.Visible = false;    // 請求番号.
                lblSeikyuNoHyphen.Visible = false;    // 
                txtSeikyuNo1.Visible = false;    // 
                txtSeikyuNo2.Visible = false;    // 

                lblUriMeiNo.Visible = true;     // 売上明細番号.
                txtUriMeiNo.Visible = true;     //
                txtUriMeiNo.Enabled = true;     //

                lblKoukokuKenmei.Visible = true;     // 広告件名.
                txtKoukokuKenmei.Visible = true;     // 
                txtKoukokuKenmei.Enabled = true;     // 

                lblTriTnt.Visible = true;     // 担当者. 
                cmbTriTnt.Visible = true;     // 
                cmbTriTnt.Enabled = true;     // 

                lblKenmei.Visible = true;     // 件名. 
                txtKenmei.Visible = true;     // 
                txtKenmei.Enabled = true;     // 

                lblSeiKenmei.Visible = false;    // 請求件名. 
                txtSeiKenmei.Visible = false;    // 
                txtSeiKenmei.Enabled = false;    // 

                /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
                //false:表示されない
                lblKihyouBmnCd.Visible = false;    //起票部門コード.
                cmbKihyouBmnCd.Visible = false;    // 
                cmbKihyouBmnCd.Enabled = false;    // 

                lblGenkaCenter.Visible = false;    // 原価センタ.  
                cmbGenkaCenter.Visible = false;    // 
                cmbGenkaCenter.Enabled = false;    //
                /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */

                lblBfKngk.Visible = true;     // 事前金額. 
                txtBfKngk.Visible = true;     // 
                txtBfKngk.Enabled = true;     // 


                lblAfKngk.Visible = true;     // 事後金額. 
                txtAfKngk.Visible = true;     // 
                txtAfKngk.Enabled = true;     // 

                lblSeiKingaku.Visible = false;    // 金額（税込み）. 
                txtSeiKingaku.Visible = false;    // 
                txtSeiKingaku.Enabled = false;    // 
                txtSeiKingaku.BackColor = SystemColors.Control;

                lblSyouhizei.Visible = false;    // 消費税. 
                txtSyouhizei.Visible = false;    // 
                txtSyouhizei.Enabled = false;    // 
                txtSyouhizei.BackColor = SystemColors.Control;

                lblZeiNKingaku.Visible = false;    // 税抜き金額 .
                txtZeiNKingaku.Visible = false;    // 
                txtZeiNKingaku.Enabled = false;    //  
                txtZeiNKingaku.BackColor = SystemColors.Control;

                lblKeizyouBi.Visible = false;    // 計上日. 
                dtpKeizyouBi.Visible = false;    // 
                dtpKeizyouBi.Enabled = false;    // 
            }
            //明細入力　請求回収.

            else if (String.Equals(_kbn, "2"))
            {
                lblSeikyuNo.Visible = true;     // 請求番号. 
                lblSeikyuNoHyphen.Visible = true;     // 
                txtSeikyuNo1.Visible = true;     // 
                txtSeikyuNo2.Visible = true;     // 

                lblUriMeiNo.Visible = false;    // 売上明細番号. 
                txtUriMeiNo.Visible = false;    //
                txtUriMeiNo.Enabled = false;    //

                lblKoukokuKenmei.Visible = false;    // 広告件名.
                txtKoukokuKenmei.Visible = false;    // 
                txtKoukokuKenmei.Enabled = false;    // 

                lblTriTnt.Visible = false;    // 担当者. 
                cmbTriTnt.Visible = false;    // 
                cmbTriTnt.Enabled = false;    // 

                lblKenmei.Visible = false;    // 件名.  
                txtKenmei.Visible = false;    // 
                txtKenmei.Enabled = false;    // 

                lblSeiKenmei.Visible = true;     // 請求件名. 
                txtSeiKenmei.Visible = true;     // 
                txtSeiKenmei.Enabled = true;     // 

                /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
                lblKihyouBmnCd.Visible = true;     //起票部門コード.  
                cmbKihyouBmnCd.Visible = true;     // 
                cmbKihyouBmnCd.Enabled = true;     // 

                lblGenkaCenter.Visible = true;     // 原価センタ.   
                cmbGenkaCenter.Visible = true;     // 
                cmbGenkaCenter.Enabled = true;     // 
                /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */

                lblBfKngk.Visible = false;    // 事前金額. 
                txtBfKngk.Visible = false;    // 
                txtBfKngk.Enabled = false;    // 

                lblAfKngk.Visible = false;    // 事後金額. 
                txtAfKngk.Visible = false;    // 
                txtAfKngk.Enabled = false;    // 

                lblSeiKingaku.Visible = true;     // 金額（税込み）. 
                txtSeiKingaku.Visible = true;     // 
                txtSeiKingaku.Enabled = true;     // 
                txtSeiKingaku.Editable = true;     // 
                txtSeiKingaku.BackColor = Color.White;

                lblSyouhizei.Visible = true;     // 消費税.
                txtSyouhizei.Visible = true;     // 
                txtSyouhizei.Enabled = true;     // 
                txtSyouhizei.Editable = true;     // 
                txtSyouhizei.BackColor = Color.White;

                lblZeiNKingaku.Visible = true;     // 税抜き金額. 
                txtZeiNKingaku.Visible = true;     // 
                txtZeiNKingaku.Editable = false;    // 
                txtZeiNKingaku.Enabled = true;     //  
                txtZeiNKingaku.BackColor = Color.LightGray;

                lblKeizyouBi.Visible = true;     // 計上日. 
                dtpKeizyouBi.Visible = true;     // 
                dtpKeizyouBi.Enabled = true;     // 
            }
        }
        #endregion 各コントロールの編集処理.

        #region マスタ情報を取得する.
        /// <summary>
        /// マスタ情報を取得する 
        /// </summary>
        private void GetMasterData()
        {
            #region 取引識別情報コンボボックスの値取得.
            {
            // 取引識別情報マスタ情報取得. 
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                MST_TRISIKI,
                null
            );

            MasterMaintenance ds = result.MasterDataSet;
            MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();
            List<EpsonComboBoxItem> items = new List<EpsonComboBoxItem>();
            items.Add(new EpsonComboBoxItem(string.Empty, string.Empty));

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                items.Add(new EpsonComboBoxItem(row.Column1, row.Column2 + " " + row.Column3));
            }

            cmbTriSiki.Items.Clear();
            cmbTriSiki.DisplayMember = "NAME";
            cmbTriSiki.ValueMember = "CODE";
            cmbTriSiki.DataSource = items;

             }
            #endregion 取引識別情報コンボボックスの値取得.

            #region 取引担当者コンボボックスの値取得.
            {
                // 取引担当者マスタ情報取得. 
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    MST_TRITNT,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();
                List<EpsonComboBoxItem> items = new List<EpsonComboBoxItem>();
                items.Add(new EpsonComboBoxItem(string.Empty, string.Empty));

                foreach (drMasterData row in rows)
                {
                    items.Add(new EpsonComboBoxItem(row.Column1, row.Column2));
                }

                cmbTriTnt.Items.Clear();
                cmbTriTnt.DisplayMember = "NAME";
                cmbTriTnt.ValueMember = "CODE";
                cmbTriTnt.DataSource = items;
            }
            #endregion 取引担当者コンボボックスの値取得.

            /* 2017/04/13 エプソン仕入先情報変更対応　ITCOM A.Nakamura ADD Start */
            #region 起票部門CDコンボボックスの値取得.
            {
                // 起票部門コード情報マスタ情報取得. 
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_KIHYOUBMNCD,
                    null
                );
                //VOから選択した列を呼び、コンボボックスに入れている.
                MasterMaintenance ds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();
                List<EpsonComboBoxItem> items = new List<EpsonComboBoxItem>();
                items.Add(new EpsonComboBoxItem(string.Empty, string.Empty));

                //起票部門CDの重複を表示しないための処理
                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    //Boolean値を用意⇒要素を追加するか判定するフラグ.
                    Boolean blnAddFlg = true;
                        // itemリストの中身がある場合、重複チェック.
                        foreach (EpsonComboBoxItem item in items)
                        {
                            if (item.CODE.Equals(row.Column2))
                            {
                                // フラグをfalseにする.
                                blnAddFlg = false;
                                // 重複チェック終了.
                                break;
                            }   
                         }
                        // 重複が無い場合、itemリストに格納.
                        if (blnAddFlg)
                        {
                            items.Add(new EpsonComboBoxItem(row.Column2, row.Column2));
                        }
                  }
                cmbKihyouBmnCd.Items.Clear();
                cmbKihyouBmnCd.DisplayMember = DISPLAYVALUE;
                cmbKihyouBmnCd.ValueMember = HIDEVALUE;
                cmbKihyouBmnCd.DataSource = items;
            }
            #endregion 起票部門CDコンボボックスの値取得.

            #region 原価センタコンボボックスの値取得.
            {
                //原価センタマスタ情報取得. 
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_GENKACENTER,
                    null
                );
                //VOから選択した列を呼び、コンボボックスに入れている.
                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();
                List<EpsonComboBoxItem> items = new List<EpsonComboBoxItem>();
                items.Add(new EpsonComboBoxItem(string.Empty, string.Empty));

                //原価センタの重複を表示しないための処理.
                foreach (drMasterData row in rows)
                {
                    //要素を追加するか判定するフラグ.
                    Boolean blnAddFlg = true;
                    //itemリストの中身がある場合、重複チェック.
                        foreach (EpsonComboBoxItem item in items)
                        {
                            //List<EpsonComboBoxItem>itemsのCODEとNAMEの1セット分がitem。そのうちCODEとColumn2が同値であった場合.
                            if (item.CODE.Equals(row.Column2))
                            {
                                // フラグをfalseにする.
                                blnAddFlg = false;
                                // 重複チェック終了.
                                break;
                            }
                        }
                         // 重複が無い場合、itemリストに格納.
                         if (blnAddFlg)
                         {
                            items.Add(new EpsonComboBoxItem(row.Column2, row.Column2));
                         }
                }
                //表示する値としてNAME、実際の値としてCODE.
                cmbGenkaCenter.Items.Clear();
                cmbGenkaCenter.DisplayMember = DISPLAYVALUE;
                cmbGenkaCenter.ValueMember = HIDEVALUE;
                cmbGenkaCenter.DataSource = items;
            }
            #endregion 原価センタコンボボックスの値取得.
            /* 2017/04/13 エプソン仕入先情報変更対応　ITCOM A.Nakamura ADD End */
        }
        #endregion マスタ情報を取得する.
        #endregion メソッド.
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Uni.View.Detail;
using Isid.KKH.Uni.Utility;
using Isid.KKH.Uni.View;

namespace Isid.KKH.Uni.View.Detail
{
    public partial class DetailInputUni : KKHDialogBase
    {
        # region 定数 

        # region 業務区分 

        /// <summary>
        /// 新聞 
        /// </summary>
        public const string C_GYOM_SHINBUN = KKHSystemConst.GyomKbn.Shinbun;
        /// <summary>
        /// 雑誌 
        /// </summary>
        public const string C_GYOM_ZASHI = KKHSystemConst.GyomKbn.Zashi;
        /// <summary>
        /// ラジオ 
        /// </summary>
        public const string C_GYOM_RADIO = KKHSystemConst.GyomKbn.Radio;
        /// <summary>
        /// テレビタイム 
        /// </summary>
        public const string C_GYOM_TVT = KKHSystemConst.GyomKbn.TVTime;
        /// <summary>
        /// テレビスポット 
        /// </summary>
        public const string C_GYOM_TVS = KKHSystemConst.GyomKbn.TVSpot;
        /// <summary>
        /// 衛星メディア 
        /// </summary>
        public const string C_GYOM_EISEIM = KKHSystemConst.GyomKbn.EiseiM;
        /// <summary>
        /// OOHメディア 
        /// </summary>
        public const string C_GYOM_OOHM = KKHSystemConst.GyomKbn.OohM;
        /// <summary>
        /// インタラクティブメディア 
        /// </summary>
        public const string C_GYOM_INTEM = KKHSystemConst.GyomKbn.InteractiveM;
        /// <summary>
        /// その他メディア 
        /// </summary>
        public const string C_GYOM_SONOM = KKHSystemConst.GyomKbn.SonotaM;
        /// <summary>
        /// メディアプランニング 
        /// </summary>
        public const string C_GYOM_MPLAN = KKHSystemConst.GyomKbn.MPlan;
        /// <summary>
        /// クリエーティブ 
        /// </summary>
        public const string C_GYOM_CREAT = KKHSystemConst.GyomKbn.Creative;
        /// <summary>
        /// マーケティング/プロモーション 
        /// </summary>
        public const string C_GYOM_MARPRO = KKHSystemConst.GyomKbn.MarkePromo;
        /// <summary>
        /// スポーツ 
        /// </summary>
        public const string C_GYOM_SPO = KKHSystemConst.GyomKbn.Sports;
        /// <summary>
        /// エンタテイメント 
        /// </summary>
        public const string C_GYOM_ENTE = KKHSystemConst.GyomKbn.Entertainment;
        /// <summary>
        /// その他コンテンツ 
        /// </summary>
        public const string C_GYOM_SONOC = KKHSystemConst.GyomKbn.SonotaC;
        # endregion 業務区分 

        #region 種別コード 
        /// <summary>
        ///  種別コード：テレビ番組 
        /// </summary>
        public const string C_CD_TVBAN = KkhConstUni.ShubetsuCd.C_TV_BANGUMI;
        /// <summary>
        ///  種別コード：テレビ特番 
        /// </summary>
        public const string C_CD_TVTOK = KkhConstUni.ShubetsuCd.C_TV_TOKUBAN;
        /// <summary>
        ///  種別コード：テレビスポット 
        /// </summary>
        public const string C_CD_TVSPOT = KkhConstUni.ShubetsuCd.C_TV_SPOT;
        /// <summary>
        ///  種別コード：雑誌 
        /// </summary>
        public const string C_CD_ZASHI = KkhConstUni.ShubetsuCd.C_ZASHI;
        /// <summary>
        ///  種別コード：新聞 
        /// </summary>
        public const string C_CD_SHINBUN = KkhConstUni.ShubetsuCd.C_SHINBUN;
        /// <summary>
        ///  種別コード：その他 
        /// </summary>
        public const string C_CD_SONOTA = KkhConstUni.ShubetsuCd.C_SONOTA;
        /// <summary>
        ///  種別コード：制作 
        /// </summary>
        public const string C_CD_SEISAKU = KkhConstUni.ShubetsuCd.C_SEISAKU;
        #endregion 種別コード 

        #region 種別名 
        /// <summary>
        ///  種別名：テレビ番組 
        /// </summary>
        public const string C_MEI_TVBAN = KkhConstUni.ShubetsuMei.C_TV_BANGUMI;
        /// <summary>
        ///  種別名：テレビ特番 
        /// </summary>
        public const string C_MEI_TVTOK = KkhConstUni.ShubetsuMei.C_TV_TOKUBAN;
        /// <summary>
        ///  種別名：テレビスポット 
        /// </summary>
        public const string C_MEI_TVSPOT = KkhConstUni.ShubetsuMei.C_TV_SPOT;
        /// <summary>
        ///  種別名：雑誌 
        /// </summary>
        public const string C_MEI_ZASHI = KkhConstUni.ShubetsuMei.C_ZASHI;
        /// <summary>
        ///  種別名：新聞 
        /// </summary>
        public const string C_MEI_SHINBUN = KkhConstUni.ShubetsuMei.C_SHINBUN;
        /// <summary>
        /// 種別名：その他 
        /// </summary>
        public const string C_MEI_SONOTA = KkhConstUni.ShubetsuMei.C_SONOTA;
        ///  種別名：制作 
        /// </summary>
        public const string C_MEI_SEISAKU = KkhConstUni.ShubetsuMei.C_SEISAKU;
        # endregion 種別名 

        # region 請求区分 
        /// <summary>
        /// 新聞 
        /// </summary>
        public const string C_SEI_SHINBUN = KKHSystemConst.SeiKbn.NewsPaper;

        /// <summary>
        /// 雑誌 
        /// </summary>
        public const string C_SEI_ZASHI = KKHSystemConst.SeiKbn.Magazine;

        /// <summary>
        /// タイム 
        /// </summary>
        public const string C_SEI_TIME = KKHSystemConst.SeiKbn.Time;

        /// <summary>
        /// スポット 
        /// </summary>
        public const string C_SEI_SPOT = KKHSystemConst.SeiKbn.Spot;

        /// <summary>
        /// IC 
        /// </summary>
        public const string C_SEI_IC = KKHSystemConst.SeiKbn.IC;

        /// <summary>
        /// 交通広告 
        /// </summary>
        public const string C_SEI_KOTSU = KKHSystemConst.SeiKbn.Ooh;

        /// <summary>
        /// 諸作業 
        /// </summary>
        public const string C_SEI_SHOSAGYO = KKHSystemConst.SeiKbn.Works;

        /// <summary>
        /// 国際マス 
        /// </summary>
        public const string C_SEI_KOKUMAS = KKHSystemConst.SeiKbn.KMas;

        /// <summary>
        /// 国際(諸作業）  
        /// </summary>
        public const string C_SEI_KOKUSHOSA = KKHSystemConst.SeiKbn.KWorks;
        # endregion 請求区分 

        # endregion 定数 

        #region メンバ変数 
        private DetailInputUniNaviParameter _naviParam = new DetailInputUniNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIdx = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private string _mCurrentGyomuKbn = "";          //受注一覧の業務区分.
        private string shubetsuNm = string.Empty;    //種別名.
        private string busho = string.Empty;    //種別名.
        private string _mHosoNenGetsu = string.Empty;   //放送月.
        private bool dateChkFlg = true;                //日付妥当性フラグ 

        /// <summary>
        /// 種別変更前 
        /// </summary>
        private string beforeShubtsuNm = string.Empty;

        /// <summary>
        /// KkhDateTimePicker用 
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// KkhDateTimePicker用 
        /// </summary>
        private DataSet ds;

        #endregion メンバ変数 

        #region コンストラクタ 
        public DetailInputUni()
        {
            InitializeComponent();

            ds = new DataSet();
            dt = ds.Tables.Add("Table");
            dt.Columns.Add("DateTimeColumn", typeof(DateTime));
            dt.Columns[0].AllowDBNull = true;
            dt.Rows.Add(new object[] { DateTime.Now });
            dt.Rows.Add(new object[] { DBNull.Value });
            dtpFrom.DataBindings.Add("Value", ds, "Table.DateTimeColumn");
            dtpTo.DataBindings.Add("Value", ds, "Table.DateTimeColumn");

        }
        #endregion コンストラクタ 

        #region イベント 
        /// <summary>
        /// 画面遷移イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputUni_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailInputUniNaviParameter)
            {
                _naviParam = (DetailInputUniNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRowUni;
                _rowDetailIdx = _naviParam.RowDetailIndexUni;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetailUni_Sheet1;
                //_mHosoBi = _naviParam.DateUni;
            }
        }

        /// <summary>
        /// フォームLoadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputUi_Load(object sender , EventArgs e)
        {
            // 各コントロールの初期化 
            InitializeControl();

            // 各コントロールの編集 
            EditControl();

        }


        /// <summary>
        /// OKボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender , EventArgs e)
        {
            //入力桁チェック.
            bool rtn = ChkNyuRyokuKetaSu();

            if (rtn)
            {
                rtn = CheckSeikyuKinGaku();
            }

            //[種別]が[TV番組][TV特番]の場合 
            if (shubetsuNm == C_MEI_TVBAN 
                || shubetsuNm == C_MEI_TVTOK)
            {
                //日付妥当性フラグがfalseの場合 
                if (!dateChkFlg)
                {
                    //エラーメッセージ(放送月が日付として有効ではありせん。)を表示 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0150, null, "入力エラー", MessageBoxButtons.OK);
                    this.ActiveControl = null;
                    return;
                }
            }

            if (rtn)
            {
                if (_spdKkhDetail_Sheet1.RowCount == 0)
                {
                    // １行追加 
                    _spdKkhDetail_Sheet1.AddRows(_rowDetailIdx , 1);
                    _spdKkhDetail_Sheet1.AddSelection(_rowDetailIdx , -1 , 1 , -1);
                }

                // 明細スプレッドに入力内容を設定 
                SetSpread(shubetsuNm);

                //画面遷移.
                Navigator.Backward(this , _naviParam , null , true);
                this.Close();
            }
        }

        /// <summary>
        /// キャンセルボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender , EventArgs e)
        {
            Navigator.Backward(this , null , null , true);
            this.Close();
        }

        /// <summary>
        /// 番組名コンボボックスチェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBangumiMei_SelectedIndexChanged(object sender , EventArgs e)
        {
            string _tanka = "0";
            int result = 0;
            //単価 
            if (cmbBangumiMei.SelectedIndex != -1)
            {
                if (cmbBangumiMei.SelectedIndex != 0)
                {
                    string _value = this.cmbBangumiMei.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(_value))
                    {
                        _tanka = this.cmbBangumiMei.SelectedValue.ToString();

                    }
                }
            }

            //放送回数.
            string _kaisu = string.Empty;
            if (string.IsNullOrEmpty(txtKaisu2.Text))
            {
                //_kaisu = "1";
            }
            else
            {
                _kaisu = txtKaisu2.Text;
            }
            //string _kaisu = txtKaisu2.Text.ToString();
            if (int.TryParse(_kaisu , out result))
            {
                _kaisu = result.ToString();
            }
            //請求金額、消費税額を計算.
            CalcSeiKinShoZei(_tanka , _kaisu);
        }

        /// <summary>
        /// 種別変更チェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbShubetsuHenko_SelectedIndexChanged(object sender , EventArgs e)
        {

            //変更後の種別の取得する.
            shubetsuNm = cmbShubetsuHenko.Text;

            if (shubetsuNm != beforeShubtsuNm)
            {
                //変更前が空、かつ変更後がTV番組、TV特番の場合、処理しない 
                if (beforeShubtsuNm == "" && shubetsuNm == C_MEI_TVBAN
                    || beforeShubtsuNm == "" && shubetsuNm == C_MEI_TVTOK)
                {
                    return;   
                }

                //*********************************************.
                //種別ごとにコントロールの表示・非表示.
                //*********************************************.
                VisibleControl(shubetsuNm);

                //*********************************************.
                //種別ごとにコントロールに値をセット.
                //*********************************************.
                //SetMeisaiValue(shubetsuNm);

                //*********************************************.
                //値の初期化.
                //*********************************************.
                SetShubetsuSyokika(shubetsuNm);

                //変更前の種別を保持する  
                beforeShubtsuNm = shubetsuNm;
            }

        }

        /// <summary>
        /// txtKaisuをLeaveした場合 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKaisu_Leave(object sender , EventArgs e)
        {
            string _tanka = string.Empty;   //単価.
            string _kaisu = string.Empty;   //回数.
            //単価を取得する.
            if (!string.IsNullOrEmpty(txtTanka.Text))
            {
                _tanka = txtTanka.Text.ToString();
            }
            //回数数量を取得する.
            if (!string.IsNullOrEmpty(txtKaisu.Text))
            {
                _kaisu = txtKaisu.Text.ToString();
            }
            //請求金額、消費税額を算出する.
            CalcSeiKinShoZei(_tanka , _kaisu);
        }

        /// <summary>
        /// txtKaisu2をLeaveした場合 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKaisu2_Leave(object sender , EventArgs e)
        {
            string _tanka = string.Empty;   //単価.
            string _kaisu = string.Empty;   //回数.
            //単価を取得する.
            if (!string.IsNullOrEmpty(txtTanka2.Text))
            {
                _tanka = txtTanka2.Text.ToString();
            }
            //放送回数を取得する.
            if (!string.IsNullOrEmpty(txtKaisu2.Text))
            {
                _kaisu = txtKaisu2.Text.ToString();
            }
            //請求金額、消費税額を算出する.
            CalcSeiKinShoZei(_tanka , _kaisu);
        }

        /// <summary>
        /// 放送日選択ボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHosoBiSentaku_Click(object sender , EventArgs e)
        {
            // 明細入力画面表示.
            //KKHNaviParameter naviParam = new KKHNaviParameter();
            DetailHosoBiUniNaviParameter naviParam = new DetailHosoBiUniNaviParameter();
            naviParam.SpdKkhDetailUni_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.EsqId = _naviParam.EsqId;
            naviParam.Egcd = _naviParam.Egcd;
            naviParam.TksKgyCd = _naviParam.TksKgyCd;
            naviParam.TksBmnSeqNo = _naviParam.TksBmnSeqNo;
            naviParam.TksTntSeqNo = _naviParam.TksTntSeqNo;
            //放送月.
            //_mHosoNenGetsu = _dataRow.hb1Field8.ToString().Trim();

            //放送月.
            //放送月がnullか空白、または日付妥当性フラグがfalseの場合 
            if (string.IsNullOrEmpty(txtHosoTsuki.Text) 
                || !dateChkFlg)
            //if (txtHosoTsuki.Text == null || txtHosoTsuki.Text == string.Empty)
            {
                //受注データの放送月をセット.
                naviParam.DateUni = _dataRow.hb1Yymm.ToString().Trim();
            }
            else
            {
                //[放送月]をセット 
                naviParam.DateUni = KKHUtility.DateToStr(txtHosoTsuki.Text);
            }
            //放送日.
            naviParam.HosoBi = KkhUniStrConv.GetHosoBiArray(txtHosoBi.Text);

            //object result = Navigator.ShowModalFormByName(this , "DetailHosoBiUni" , naviParam);
            object result = Navigator.ShowModalForm(this, "toDetailHosoBiUni", naviParam);
            
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }

            //放送日をセット.
            txtHosoBi.Text = KkhUniStrConv.GetHosoBi(naviParam.HosoBi);
            this.ActiveControl = null;
        }

        /// <summary>
        /// txtHosoTsuki_Leaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosoTsuki_Leave(object sender , EventArgs e)
        {
            //yyyyMMにする 
            string hosoTsuki = Isid.KKH.Common.KKHUtility.KKHUtility.DateToStr(txtHosoTsuki.Text);
            //DateTime dateTime = new DateTime();

            //日付妥当性フラグを初期化 
            dateChkFlg = false;

            //6桁の場合 
            if (hosoTsuki.Length == 6)
            {
                dateChkFlg = KKHUtility.IsDate(hosoTsuki, "yyyyMM");
                txtHosoTsuki.Text = hosoTsuki.Insert(4, "/");
            }
            if (shubetsuNm.Equals(C_MEI_TVBAN) || shubetsuNm.Equals(C_MEI_TVTOK))
            {
                if (hosoTsuki.Trim() == "")
                {
                    dateChkFlg = true;
                }
            }
        }

        /// <summary>
        /// 年月のバリデーション 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosoTsuki_Validating(object sender , CancelEventArgs e)
        {
            string text = txtHosoTsuki.Text;
            DateTime dateTime = new DateTime();

            if (text.Equals(string.Empty))
            {
                //未入力時は何もしない 
                return;
            }

            //日付妥当性チェック 
            if (text.Length != 6
                || DateTime.TryParse(text.Insert(4, "/") + "/01", out dateTime) == false)
            {
                //エラーメッセージ(入力形式が正しくありません。)を表示 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0072, null, "入力エラー", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            //表示フォーマットを変更 
            txtHosoTsuki.Text = dateTime.ToString("yyyy/MM");
        }

        /// <summary>
        /// 年月のフォーカス_Enter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosoTsuki_Enter(object sender , EventArgs e)
        {
            txtHosoTsuki.Text = Isid.KKH.Common.KKHUtility.KKHUtility.DateToStr(txtHosoTsuki.Text);
        }

        /// <summary>
        /// 年月のKeyPressイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosoTsuki_KeyPress(object sender , KeyPressEventArgs e)
        {
            //入力禁止文字の判定 
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 請求原票番号のKeyPressイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSeiGenBango3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数値、バックスペースのみ入力可能
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 回数のKeyPressイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKaisu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数値、バックスペースのみ入力可能
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 放送回数のKeyPressイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKaisu2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数値、バックスペースのみ入力可能
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 半角変換ボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHanHenkan_Click(object sender , EventArgs e)
        {
            //件名.
            txtKenNm.Text = KKHStrConv.toNarrow(txtKenNm.Text.Trim());

            //費目名.
            txtHimokuMei.Text = KKHStrConv.toNarrow(txtHimokuMei.Text.Trim());

            //種別で分岐.
            //TVSPOT、その他.
            if (shubetsuNm.Equals(C_MEI_TVSPOT)
                || shubetsuNm.Equals(C_MEI_SONOTA))
            {
                //媒体名.
                txtBaitaiMei.Text = KKHStrConv.toNarrow(txtBaitaiMei.Text.Trim());
            }
            //雑誌、新聞.
            else if (shubetsuNm.Equals(C_MEI_ZASHI)
                || shubetsuNm.Equals(C_MEI_SHINBUN))
            {
                //媒体名.
                txtBaitaiMei.Text = KKHStrConv.toNarrow(txtBaitaiMei.Text.Trim());
                //スペース.
                txtSpace.Text = KKHStrConv.toNarrow(txtSpace.Text.Trim());
                //掲載号.
                txtKeisaiGo.Text = KKHStrConv.toNarrow(txtKeisaiGo.Text.Trim());
            }
            //制作.
            else if (shubetsuNm.Equals(C_MEI_SEISAKU))
            {
                //制作内容.
                txtSeisaku.Text = KKHStrConv.toNarrow(txtSeisaku.Text.Trim());
                //納品日.
                txtNohinBi.Text = KKHStrConv.toNarrow(txtNohinBi.Text.Trim());
            }

            this.ActiveControl = null;
        }

        /// <summary>
        /// 入力不可コントロールでキーボード操作時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNGNyuryoku_KeyPress(object sender , KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                //if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back || e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNGNyuryoku_KeyDown(object sender , KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 期間コントロールを押下したとき 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            DateTimePicker dp = (DateTimePicker)sender;
            if (e.KeyCode == Keys.Delete)
            {
                dtpFrom.Value = null;
                //dp.CustomFormat = "g";
            }
            else
            {
                dp.CustomFormat = "yyyy/MM/dd";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dp = (DateTimePicker)sender;
            dp.CustomFormat = "yyyy/MM/dd";
        }

        /// <summary>
        /// 件名_TextChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenNm_TextChanged(object sender, EventArgs e)
        {
            this.txtKenNm.TextChanged -= new System.EventHandler(this.txtKenNm_TextChanged);
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            //60byteを超過した場合 
            while (sjisEnc.GetByteCount(txtKenNm.Text) > 60)
            {
                //カーソルをテキストの最後から2番目の位置にセットする  
                int curPoint = txtKenNm.SelectionStart - 1;
                if (curPoint < 0)
                {
                    curPoint = 0;
                }
                //最後のテキストを削除する 
                txtKenNm.Text = txtKenNm.Text.Remove(curPoint, 1);
                //カーソルを最後の位置にセットする 
                txtKenNm.SelectionStart = curPoint;
            }

            this.txtKenNm.TextChanged += new System.EventHandler(this.txtKenNm_TextChanged);
        }

        #endregion イベント
        #region メソッド

        /// <summary>
        /// 各コントロールの初期表示処理 
        /// </summary>
        private void InitializeControl()
        {
            // テキストボックス↓ 
            txtKenNm.Text = string.Empty;
            txtHimokuMei.Text = string.Empty;
            txtBaitaiMei.Text = string.Empty;
            txtHosoTsuki.Text = string.Empty;
            txtHosoBi.Text = string.Empty;
            txtTanka.Text = string.Empty;
            txtKaisu.Text = string.Empty;
            txtSeikyuKinGaku.Text = string.Empty;
            txtShohiZeiGaku.Text = string.Empty;
            txtSeiGenBango1.Text = string.Empty;
            txtSeiGenBango2.Text = string.Empty;
            txtSeiGenBango3.Text = string.Empty;
            txtSotoBango.Text = string.Empty;
            txtKeisaiGo.Text = string.Empty;
            txtNohinBi.Text = string.Empty;
            txtSpace.Text = string.Empty;
            txtSeisaku.Text = string.Empty;
            txtTanka2.Text = string.Empty;
            txtKaisu2.Text = string.Empty;
            txtSeikyuKinGaku2.Text = string.Empty;
            txtShohiZeiGaku2.Text = string.Empty;

            dtpFrom.Value = null;
            dtpTo.Value = null;

            //***********************************.
            //種別名をコンボボックスにセットする.
            //***********************************.
            SetShubetsuCmb();

            //***********************************.
            //番組名をコンボボックスにセットする.
            //***********************************.
            SetBangumiMeiCmb();

            //***********************************.
            //部署名をコンボボックスにセットする.
            //***********************************.
            SetBushoCmb();
        }

        /// <summary>
        /// 各コントロールの編集処理. 
        /// </summary>
        private void EditControl()
        {
            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                string _seigen = string.Empty;  //請求原票番号.
                
                //業務区分より種別名を判別する.
                _mCurrentGyomuKbn = _dataRow.hb1GyomKbn.ToString().Trim();   // 業務区分
                switch (_mCurrentGyomuKbn)
                {
                    case C_GYOM_TVT:
                        shubetsuNm = C_MEI_TVBAN;
                        break;
                    case C_GYOM_TVS:
                        shubetsuNm = C_MEI_TVSPOT;
                        break;
                    case C_GYOM_ZASHI:
                        shubetsuNm = C_MEI_ZASHI;
                        break;
                    case C_GYOM_SHINBUN:
                        shubetsuNm = C_MEI_SHINBUN;
                        break;
                    case C_GYOM_CREAT:
                        shubetsuNm = C_MEI_SEISAKU;
                        break;
                    default:
                        shubetsuNm = C_MEI_SONOTA;
                        break;
                }

                //*********************************************.
                //種別ごとにコントロールの表示・非表示.
                //*********************************************.
                VisibleControl(shubetsuNm);

                //*********************************************.
                //コントロールに値をセット.
                //*********************************************.
                //種別共通↓
                //件名 
                txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                //費目名 
                txtHimokuMei.Text = _dataRow.hb1HimkNmKJ.ToString().Trim();

                //請求原票番号.
                _seigen = _dataRow.hb1GpyNo.ToString().Trim();
                if (!string.IsNullOrEmpty(_seigen))
                {
                    txtSeiGenBango1.Text = _seigen.Substring(0 , 6);
                    txtSeiGenBango2.Text = _seigen.Substring(6 , 4);
                }
                //ソート番号.
                txtSotoBango.Text = "0";
                //種別変更 
                cmbShubetsuHenko.Text = shubetsuNm;
                //部署変更
                cmbBusho.Text = busho;

                //*********************************************.
                //種別ごとに受注データをセット.
                //*********************************************.
                SetJuchuValue(shubetsuNm);
            }
            // 明細がある場合.
            else
            {
                string _seigen = string.Empty;  //請求原票番号.
                string _soto = string.Empty;    //ソート番号.
                int result = 0;                 //TryParse結果.
                
                //種別名 
                shubetsuNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SHUBETSU].Text.Trim();
                //部署
                busho = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BUSHO].Text.Trim();

                //*********************************************.
                //種別ごとにコントロールの表示・非表示.
                //*********************************************.
                VisibleControl(shubetsuNm);

                //*********************************************.
                //コントロールに値をセット.
                //*********************************************.
                //呼び元の明細Spreadより取得した値をセットする.
                //種別共通↓ 
                //件名 
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_KENMEI].Text;
                
                //費目名 
                txtHimokuMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HIMOKUMEI].Text;
                
                //請求原票番号.
                _seigen = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SEIKYUGENPYO].Text.Trim();
                if (!string.IsNullOrEmpty(_seigen))
                {
                    _seigen = _seigen.Replace("-", "");

                    if (_seigen.Length == 11)
                    {
                        txtSeiGenBango1.Text = _seigen.Substring(0, 6);
                        txtSeiGenBango2.Text = _seigen.Substring(6, 4);
                        txtSeiGenBango3.Text = _seigen.Substring(10, 1);
                    }
                    else if (_seigen.Length == 10)
                    {
                        txtSeiGenBango1.Text = _seigen.Substring(0, 6);
                        txtSeiGenBango2.Text = _seigen.Substring(6, 4);
                    }
                    else if (_seigen.Length == 1)
                    {
                        txtSeiGenBango3.Text = _seigen;
                    }
                }
                
                //ソート番号.
                _soto = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SOTOBANGO].Text.Trim();

                if (int.TryParse(_soto , out result))
                {
                    txtSotoBango.Text = result.ToString();
                }
                //種別変更
                cmbShubetsuHenko.Text = shubetsuNm;
                //部署変更
                cmbBusho.Text = busho;
                //*********************************************.
                //種別ごとに明細データをセット.
                //*********************************************.
                SetMeisaiValue(shubetsuNm);

            }
        }

        /// <summary>
        /// コントロールの表示・非表示制御.
        /// </summary>
        /// <param name="shubetsuMei"></param>
        private void VisibleControl(string shubetsuMei)
        {
            # region 表示制御
            switch (shubetsuMei)
            {
                # region TV番組
                case C_MEI_TVBAN:
                    //媒体名.
                    lblBaitaiMei.Visible = false;
                    txtBaitaiMei.Visible = false;

                    //スペース.
                    lblSpace.Visible = false;
                    txtSpace.Visible = false;

                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
 
                    //納品日.
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;

                    //掲載号.
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;

                    //掲載日.
                    lblKeisaiBi.Visible = false;
                    dtpFrom.Visible = false;
                    lblKara.Visible = false;
                    dtpTo.Visible = false;

                    //放送月.
                    lblHosoTsuki.Visible = true;
                    txtHosoTsuki.Visible = true;

                    //放送日選択.
                    btnHosoBiSentaku.Visible = true;

                    //放送日.
                    lblHosoBi.Visible = true;
                    txtHosoBi.Visible = true;
                    txtHosoBi.ReadOnly = true;

                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;

                    //回数数量.
                    lblKaisuSuryo.Visible = false;
                    txtKaisu.Visible = false;

                    //請求金額.
                    lblSeikyuKinGaku.Visible = false;
                    txtSeikyuKinGaku.Visible = false;

                    //消費税額.
                    lblShohiZeiGaku.Visible = false;
                    txtShohiZeiGaku.Visible = false;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = true;
                    grpKinGaku.Location = new Point(12 , 134);

                    //番組名.
                    lblBangumiMei.Visible = true;
                    cmbBangumiMei.Visible = true;

                    //単価.
                    lblTanka2.Visible = true;
                    txtTanka2.Visible = true;

                    //放送回数.
                    lblHosoKaisu.Visible = true;
                    txtKaisu2.Visible = true;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = true;
                    txtSeikyuKinGaku2.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = true;
                    txtShohiZeiGaku2.Visible = true;

                    //****************************************.
                    //番組名.
                    //****************************************.
                    //SetBangumiMeiCmb();

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;
                # endregion TV番組
                # region TV特番
                case C_MEI_TVTOK:
                    //媒体名.
                    lblBaitaiMei.Visible = false;
                    txtBaitaiMei.Visible = false;
                    //スペース.
                    lblSpace.Visible = false;
                    txtSpace.Visible = false;
                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
                    //納品日
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;
                    //掲載号
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;
                    //掲載日.
                    lblKeisaiBi.Visible = false;
                    dtpFrom.Visible = false;
                    lblKara.Visible = false;
                    dtpTo.Visible = false;
                    //放送月.
                    lblHosoTsuki.Visible = true;
                    txtHosoTsuki.Visible = true;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = true;
                    //放送日.
                    lblHosoBi.Visible = true;
                    txtHosoBi.Visible = true;
                    txtHosoBi.ReadOnly = true;
                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;
                    //回数数量.
                    lblKaisuSuryo.Visible = false;
                    txtKaisu.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku.Visible = false;
                    txtSeikyuKinGaku.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku.Visible = false;
                    txtShohiZeiGaku.Visible = false;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = true;
                    grpKinGaku.Location = new Point(12 , 134);
                    //番組名.
                    lblBangumiMei.Visible = true;
                    cmbBangumiMei.Visible = true;
                    //単価.
                    lblTanka2.Visible = true;
                    txtTanka2.Visible = true;
                    //放送回数.
                    lblHosoKaisu.Visible = true;
                    txtKaisu2.Visible = true;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = true;
                    txtSeikyuKinGaku2.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = true;
                    txtShohiZeiGaku2.Visible = true;
                    //****************************************.
                    //番組名.
                    //****************************************.
                    //SetBangumiMeiCmb();

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;
                # endregion TV特番

                # region TVスポット
                case C_MEI_TVSPOT:
                    //媒体名.
                    lblBaitaiMei.Visible = true;
                    txtBaitaiMei.Visible = true;
                    lblBaitaiMei.Text = "放送局名";
                    //スペース.
                    lblSpace.Visible = false;
                    txtSpace.Visible = false;
                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
                    //納品日
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;
                    //掲載号
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;
                    //掲載日.
                    lblKeisaiBi.Visible = true;
                    lblKeisaiBi.Text = "放送期間";
                    dtpFrom.Visible = true;
                    lblKara.Visible = true;
                    dtpTo.Visible = true;
                    //放送月.
                    lblHosoTsuki.Visible = false;
                    txtHosoTsuki.Visible = false;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = false;
                    //放送日.
                    lblHosoBi.Visible = false;
                    txtHosoBi.Visible = false;
                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;
                    //回数数量.
                    lblKaisuSuryo.Visible = true;
                    txtKaisu.Visible = true;
                    lblKaisuSuryo.Text = "局数";
                    //請求金額.
                    lblSeikyuKinGaku.Visible = true;
                    txtSeikyuKinGaku.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku.Visible = true;
                    txtShohiZeiGaku.Visible = true;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = false;
                    //番組名.
                    lblBangumiMei.Visible = false;
                    cmbBangumiMei.Visible = false;
                    //単価.
                    lblTanka2.Visible = false;
                    txtTanka2.Visible = false;
                    //放送回数.
                    lblHosoKaisu.Visible = false;
                    txtKaisu2.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = false;
                    txtSeikyuKinGaku2.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = false;
                    txtShohiZeiGaku2.Visible = false;

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;
                # endregion TVスポット
                # region 雑誌
                case C_MEI_ZASHI:

                    //媒体名.
                    lblBaitaiMei.Visible = true;
                    txtBaitaiMei.Visible = true;
                    lblBaitaiMei.Text = "媒体名";
                    //スペース.
                    lblSpace.Visible = true;
                    lblSpace.Location = new Point(12 , 94);
                    txtSpace.Visible = true;
                    txtSpace.Location = new Point(86 , 91);
                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
                    //納品日.
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;
                    //放送月.
                    lblHosoTsuki.Visible = false;
                    txtHosoTsuki.Visible = false;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = false;
                    //放送日.
                    lblHosoBi.Visible = false;
                    txtHosoBi.Visible = false;
                    //掲載号.
                    lblKeisaiGo.Visible = true;
                    lblKeisaiGo.Location = new Point(12 , 119);
                    txtKeisaiGo.Visible = true;
                    txtKeisaiGo.Location = new Point(86 , 116);
                    //掲載日.
                    lblKeisaiBi.Visible = true;
                    lblKeisaiBi.Text = "発売日";
                    dtpFrom.Visible = true;
                    lblKara.Visible = false;
                    dtpTo.Visible = false;
                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;
                    //回数数量.
                    lblKaisuSuryo.Visible = false;
                    txtKaisu.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku.Visible = true;
                    txtSeikyuKinGaku.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku.Visible = true;
                    txtShohiZeiGaku.Visible = true;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = false;
                    //番組名.
                    lblBangumiMei.Visible = false;
                    cmbBangumiMei.Visible = false;
                    //単価.
                    lblTanka2.Visible = false;
                    txtTanka2.Visible = false;
                    //放送回数.
                    lblHosoKaisu.Visible = false;
                    txtKaisu2.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = false;
                    txtSeikyuKinGaku2.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = false;
                    txtShohiZeiGaku2.Visible = false;

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;
                # endregion 雑誌
                # region 新聞
                case C_MEI_SHINBUN:

                    //媒体名.
                    lblBaitaiMei.Visible = true;
                    txtBaitaiMei.Visible = true;
                    lblBaitaiMei.Text = "媒体名";
                    //スペース.
                    lblSpace.Visible = true;
                    lblSpace.Location = new Point(12 , 94);
                    txtSpace.Visible = true;
                    txtSpace.Location = new Point(86 , 91);
                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
                    //納品日.
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;
                    //放送月.
                    lblHosoTsuki.Visible = false;
                    txtHosoTsuki.Visible = false;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = false;
                    //放送日.
                    lblHosoBi.Visible = false;
                    txtHosoBi.Visible = false;
                    //掲載号.
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;
                    //掲載日.
                    lblKeisaiBi.Visible = true;
                    lblKeisaiBi.Text = "掲載日";
                    dtpFrom.Visible = true;
                    lblKara.Visible = false;
                    dtpTo.Visible = false;
                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;
                    //回数数量.
                    lblKaisuSuryo.Visible = false;
                    txtKaisu.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku.Visible = true;
                    txtSeikyuKinGaku.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku.Visible = true;
                    txtShohiZeiGaku.Visible = true;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = false;
                    //番組名.
                    lblBangumiMei.Visible = false;
                    cmbBangumiMei.Visible = false;
                    //単価.
                    lblTanka2.Visible = false;
                    txtTanka2.Visible = false;
                    //放送回数.
                    lblHosoKaisu.Visible = false;
                    txtKaisu2.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = false;
                    txtSeikyuKinGaku2.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = false;
                    txtShohiZeiGaku2.Visible = false;

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;
                # endregion 新聞
                # region その他
                case C_MEI_SONOTA:
                    //媒体名.
                    lblBaitaiMei.Visible = true;
                    txtBaitaiMei.Visible = true;
                    lblBaitaiMei.Text = "媒体名";
                    //スペース.
                    lblSpace.Visible = false;
                    txtSpace.Visible = false;
                    //制作内容.
                    lblSeisaku.Visible = false;
                    txtSeisaku.Visible = false;
                    //納品日.
                    lblNohinBi.Visible = false;
                    txtNohinBi.Visible = false;
                    //掲載号.
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;
                    //掲載日.
                    lblKeisaiBi.Visible = true;
                    lblKeisaiBi.Text = "期間";
                    dtpFrom.Visible = true;
                    lblKara.Visible = true;
                    dtpTo.Visible = true;
                    //放送月.
                    lblHosoTsuki.Visible = false;
                    txtHosoTsuki.Visible = false;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = false;
                    //放送日.
                    lblHosoBi.Visible = false;
                    txtHosoBi.Visible = false;
                    //単価.
                    lblTanka.Visible = false;
                    txtTanka.Visible = false;
                    //回数数量.
                    lblKaisuSuryo.Visible = false;
                    txtKaisu.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku.Visible = true;
                    txtSeikyuKinGaku.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku.Visible = true;
                    txtShohiZeiGaku.Visible = true;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = false;
                    //番組名.
                    lblBangumiMei.Visible = false;
                    cmbBangumiMei.Visible = false;
                    //単価.
                    lblTanka2.Visible = false;
                    txtTanka2.Visible = false;
                    //放送回数.
                    lblHosoKaisu.Visible = false;
                    txtKaisu2.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = false;
                    txtSeikyuKinGaku2.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = false;
                    txtShohiZeiGaku2.Visible = false;

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;

                # endregion その他
                # region 制作
                case C_MEI_SEISAKU:
                    //媒体名.
                    lblBaitaiMei.Visible = false;
                    txtBaitaiMei.Visible = false;
                    //スペース.
                    lblSpace.Visible = false;
                    txtSpace.Visible = false;
                    //制作内容.
                    lblSeisaku.Visible = true;
                    lblSeisaku.Location = new Point(12 , 119);
                    txtSeisaku.Visible = true;
                    txtSeisaku.Location = new Point(86 , 116);
                    //納品日.
                    lblNohinBi.Visible = true;
                    lblNohinBi.Location = new Point(12 , 145);
                    txtNohinBi.Visible = true;
                    txtNohinBi.Location = new Point(86 , 141);
                    //掲載号.
                    lblKeisaiGo.Visible = false;
                    txtKeisaiGo.Visible = false;
                    //掲載日.
                    lblKeisaiBi.Visible = false;
                    dtpFrom.Visible = false;
                    lblKara.Visible = false;
                    dtpTo.Visible = false;
                    //放送月.
                    lblHosoTsuki.Visible = false;
                    txtHosoTsuki.Visible = false;
                    //放送日選択.
                    btnHosoBiSentaku.Visible = false;
                    //放送日.
                    lblHosoBi.Visible = false;
                    txtHosoBi.Visible = false;
                    //単価.
                    lblTanka.Visible = true;
                    txtTanka.Visible = true;
                    //回数数量.
                    lblKaisuSuryo.Visible = true;
                    txtKaisu.Visible = true;
                    lblKaisuSuryo.Text = "回数数量";
                    //請求金額.
                    lblSeikyuKinGaku.Visible = true;
                    txtSeikyuKinGaku.Visible = true;
                    //消費税額.
                    lblShohiZeiGaku.Visible = true;
                    txtShohiZeiGaku.Visible = true;

                    //****************************************.
                    //金額関連.
                    //****************************************.
                    grpKinGaku.Visible = false;
                    //番組名.
                    lblBangumiMei.Visible = false;
                    cmbBangumiMei.Visible = false;
                    //単価.
                    lblTanka2.Visible = false;
                    txtTanka2.Visible = false;
                    //放送回数.
                    lblHosoKaisu.Visible = false;
                    txtKaisu2.Visible = false;
                    //請求金額.
                    lblSeikyuKinGaku2.Visible = false;
                    txtSeikyuKinGaku2.Visible = false;
                    //消費税額.
                    lblShohiZeiGaku2.Visible = false;
                    txtShohiZeiGaku2.Visible = false;

                    //****************************************.
                    //部署選択.
                    //****************************************.
                    lblBusho.Visible = true;
                    lblBusho.Location = new Point(348, 134);
                    break;

                # endregion 制作
            }
            # endregion 表示制御
        }
        
        /// <summary>
        /// 種別変更後の初期化 
        /// </summary>
        /// <param name="shubetsuMei"></param>
        private void SetShubetsuSyokika(string shubetsuMei)
        {
            string _seigen = string.Empty;
            string _subHosoTsuki = string.Empty;
            string _keisai = string.Empty;
            string _kaisuSuryo = string.Empty;
            int result = 0;

            //種別共通↓
            //明細レコードが無い場合 
            # region 明細レコードが無い場合 
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //件名 
                txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                //費目名 
                txtHimokuMei.Text = _dataRow.hb1HimkNmKJ.ToString().Trim();
                //受注データをセットする 
                SetJuchuValue(shubetsuMei);
            }
            # endregion 明細レコードが無い場合 
            else
            {
                //件名 
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KENMEI].Text;
                
                //費目名 
                txtHimokuMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HIMOKUMEI].Text;

                //明細の種別と同じ場合 
                if (shubetsuMei == _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SHUBETSU].Text.Trim())
                {
                    //明細データをセットする 
                    SetMeisaiValue(shubetsuMei);
                }
                else
                {
                    //受注データをセットする 
                    SetJuchuValue(shubetsuMei);
                }
            }

        }

        /// <summary>
        /// 番組名をコンボボックスにセットする.
        /// </summary>
        private void SetBangumiMeiCmb()
        {
            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 番組名 
            cmbBangumiMei.Items.Clear();
            result = process.FindMasterByCond(_naviParam.EsqId ,
                                            _naviParam.Egcd ,
                                            _naviParam.TksKgyCd ,
                                            _naviParam.TksBmnSeqNo ,
                                            _naviParam.TksTntSeqNo ,
                                             DetailUni.C_MST_BANGUMIRYOKIN ,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtBanRyo =
                new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow = dtBanRyo.NewMasterDataVORow();
            dtBanRyo.AddMasterDataVORow(voRow);//空行を追加 
            if (result.MasterDataSet.MasterDataVO != null) 
            {
                dtBanRyo.Merge(result.MasterDataSet.MasterDataVO);
            }
          
            dtBanRyo.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる.
            this.cmbBangumiMei.DataSource = dtBanRyo;
            
            //表示される値はDataTableのColumn1列(番組名).
            this.cmbBangumiMei.DisplayMember = dtBanRyo.Column1Column.ColumnName;
            
            //値引後単価
            this.cmbBangumiMei.ValueMember = dtBanRyo.Column3Column.ColumnName;
        }

        /// <summary>
        /// 種別名をコンボボックスにセットする.
        /// </summary>
        private void SetShubetsuCmb()
        {
            //DataTableオブジェクトを生成.
            DataTable dtblShubetsu = new DataTable();

            //dtblShubetsuに列を追加.
            dtblShubetsu.Columns.Add("CODE" , typeof(string));
            dtblShubetsu.Columns.Add("NAME" , typeof(string));

            string[,] arr = 
            {
                {C_CD_TVBAN, C_MEI_TVBAN},      //TV番組 
                {C_CD_TVTOK, C_MEI_TVTOK},      //TV特番 
                {C_CD_TVSPOT, C_MEI_TVSPOT},    //TVスポット 
                {C_CD_ZASHI, C_MEI_ZASHI},      //雑誌 
                {C_CD_SHINBUN, C_MEI_SHINBUN},  //新聞 
                {C_CD_SEISAKU, C_MEI_SEISAKU},  //制作 
                {C_CD_SONOTA, C_MEI_SONOTA},    //その他 
            };

            for (int i = 0 ; i < arr.GetLength(0) ; i++)
            {

                //新しい行を作成 
                DataRow drRow = dtblShubetsu.NewRow();
                //各列に値をセット 
                drRow["CODE"] = arr[i , 0];
                drRow["NAME"] = arr[i , 1];
                //DataTableに行を追加 
                dtblShubetsu.Rows.Add(drRow);
            }

            //データセットの変更をコミットする.
            dtblShubetsu.AcceptChanges();
            
            // 初期化のために一時的にイベントをオフにする
            cmbShubetsuHenko.SelectedIndexChanged -= new System.EventHandler(this.cmbShubetsuHenko_SelectedIndexChanged);

            //コンボボックスのDataSourceにDataTableを割り当てる.
            cmbShubetsuHenko.DataSource = dtblShubetsu;
            
            //表示される値はDataTableのNAME列.
            cmbShubetsuHenko.DisplayMember = "NAME";
            
            //対応する値はDataTableのID列.
            cmbShubetsuHenko.ValueMember = "CODE";

            // 初期化のために一時的にイベントをオフにしたのを元に戻す 
            cmbShubetsuHenko.SelectedIndexChanged += new System.EventHandler(this.cmbShubetsuHenko_SelectedIndexChanged);
        }

        /// <summary>
        /// 部署名をコンボボックスにセットする.
        /// </summary>
        private void SetBushoCmb()
        {
            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 部署名 
            cmbBusho.Items.Clear();
            result = process.FindMasterByCond(_naviParam.EsqId,
                                            _naviParam.Egcd,
                                            _naviParam.TksKgyCd,
                                            _naviParam.TksBmnSeqNo,
                                            _naviParam.TksTntSeqNo,
                                             DetailUni.C_MST_BUSHO,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtBusho =
                new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtBusho.NewMasterDataVORow();
            dtBusho.AddMasterDataVORow(voRow2);//空行を追加 
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtBusho.Merge(result.MasterDataSet.MasterDataVO);
            }

            dtBusho.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる.
            this.cmbBusho.DataSource = dtBusho;

            //表示される値はDataTableのColumn1列(番組名).
            this.cmbBusho.DisplayMember = dtBusho.Column1Column.ColumnName;
        }

        /// <summary>
        /// 種別名ごとに明細の値をセットする.
        /// </summary>
        /// <param name="shubetsuCd"></param>
        private void SetJuchuValue(string shubetsuMei)
        {
            string _seigen = string.Empty;
            string _subHosoTsuki = string.Empty;
            string _keisai = string.Empty;
            string _kaisuSuryo = string.Empty;
            int result = 0;

            //請求原票番号 
            _seigen = _dataRow.hb1GpyNo.ToString().Trim();
            if (!string.IsNullOrEmpty(_seigen))
            {
                if (_seigen.Length >= 10)
                {
                    txtSeiGenBango1.Text = _seigen.Substring(0, 6);
                    txtSeiGenBango2.Text = _seigen.Substring(6, 4);
                }
            }

            //種別ごとの処理 
            switch (shubetsuMei)
            {
                #region TV番組 

                case C_MEI_TVBAN:

                    //変更前の種別が[TV特番]ではない場合 
                    if (beforeShubtsuNm != C_MEI_TVTOK)
                    {
                        //放送月 
                        txtHosoTsuki.Text = string.Empty;
                        //日付型の場合 
                        if (_dataRow.hb1Field8.Length >= 8)
                        {
                            if (KKHUtility.IsDate(_dataRow.hb1Field8.Substring(0, 8), "yyyyMMdd"))
                            {
                                txtHosoTsuki.Text = _dataRow.hb1Field8.Substring(0, 4) + "/" + _dataRow.hb1Field8.Substring(4, 2);
                            }
                        }
                        //放送日
                        //txtHosoBi.Text = string.Empty;
                        txtHosoBi.Text = KkhUniStrConv.GetHosoBi(_dataRow.hb1Field7);
                        //番組名
                        cmbBangumiMei.Text = "";

                        //放送回数 
                        //数値の場合 
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field6.Trim()))
                        {
                            if (KKHUtility.IntParse(_dataRow.hb1Field6.Trim()) > 0)
                            {
                                txtKaisu2.Text = KKHUtility.IntParse(_dataRow.hb1Field6.Trim()).ToString();
                            }
                            else
                            {
                                txtKaisu2.Text = "";
                            }

                        }
                        else
                        {
                            txtKaisu2.Text = "";
                        }

                    }
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                        break;

                #endregion TV番組 

                # region TV特番 

                case C_MEI_TVTOK:

                    //変更前の種別が[TV番組]ではない場合 
                    if (beforeShubtsuNm != C_MEI_TVBAN)
                    {
                        //放送月
                        txtHosoTsuki.Text = string.Empty;
                        if (_dataRow.hb1Field8.Length >= 8)
                        {
                            if (KKHUtility.IsDate(_dataRow.hb1Field8.Substring(0, 8), "yyyyMMdd"))
                            {
                                txtHosoTsuki.Text = _dataRow.hb1Field8.Substring(0, 4) + "/" + _dataRow.hb1Field8.Substring(4, 2);
                            }
                        }
                        //放送日
                        txtHosoBi.Text = KkhUniStrConv.GetHosoBi(_dataRow.hb1Field7);
                        //番組名
                        cmbBangumiMei.Text = "";

                        //回数
                        //数値の場合 
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field6.Trim()))
                        {
                            if (KKHUtility.IntParse(_dataRow.hb1Field6.Trim()) > 0)
                            {
                                txtKaisu2.Text = KKHUtility.IntParse(_dataRow.hb1Field6.Trim()).ToString();
                            }
                            else
                            {
                                txtKaisu2.Text = "";
                            }
                        }
                        else
                        {
                            txtKaisu2.Text = "";
                        }
                    }
                    break;

                #endregion TV特番

                # region TVスポット 

                case C_MEI_TVSPOT:

                    if (_dataRow.hb1GyomKbn.Equals(C_GYOM_TVS))
                    {
                        //媒体名.
                        txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                        //掲載日.
                        _keisai = _dataRow.hb1Field4.ToString().Trim();
                        if (!string.IsNullOrEmpty(_keisai))
                        {

                            if (_keisai.Length == 16)
                            {
                                dtpFrom.CustomFormat = "yyyy/MM/dd";
                                dtpTo.CustomFormat = "yyyy/MM/dd";
                                dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 8));
                                dtpTo.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(8, 8));
                            }
                            else if (_keisai.Length == 8)
                            {
                                dtpFrom.CustomFormat = "yyyy/MM/dd";
                                dtpTo.CustomFormat = "yyyy/MM/dd";
                                dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 8));
                                dtpTo.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 8));
                            }
                        }
                        //数値の場合 
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field3.Trim()))
                        {
                            txtKaisu.Text = KKHUtility.IntParse(_dataRow.hb1Field3).ToString().Trim();
                        }
                        else
                        {
                            txtKaisu.Text = "";
                        }

                    }
                    else
                    {
                        txtBaitaiMei.Text = string.Empty;
                        dtpFrom.Value = null;
                        dtpTo.Value = null;
                        txtKaisu.Text = string.Empty;
                    }
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                    break;

                #endregion TVスポット
                # region 雑誌 
                case C_MEI_ZASHI:

                    if (_dataRow.hb1GyomKbn.Equals(C_GYOM_ZASHI))
                    {
                        //媒体名.
                        txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                        //スペース.
                        txtSpace.Text = _dataRow.hb1Field9.ToString() + _dataRow.hb1Field8.ToString();
                        //掲載号.
                        txtKeisaiGo.Text = _dataRow.hb1Field4.ToString().Trim();
                        //掲載日.
                        if (!(String.IsNullOrEmpty(_dataRow.hb1Field3.ToString())))
                        {
                            string str = _dataRow.hb1Field3.Substring(0, 4) + "/" + _dataRow.hb1Field3.Substring(4, 2) + "/" + _dataRow.hb1Field3.Substring(6, 2);
                            DateTime dt = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(str);

                            if (dt != DateTime.MinValue)
                            {
                                dtpFrom.CustomFormat = "yyyy/MM/dd";
                                dtpFrom.Value = dt;
                            }
                            else
                            {
                                dtpFrom.Value = null;
                            }
                        }
                    }
                    else
                    {
                        //初期化 
                        txtBaitaiMei.Text = string.Empty;
                        txtSpace.Text = string.Empty;
                        txtKeisaiGo.Text = string.Empty;
                        dtpFrom.Value = null;
                    }
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                    break;

                #endregion 雑誌 

                # region 新聞 

                case C_MEI_SHINBUN:

                    if (_dataRow.hb1GyomKbn.Equals(C_GYOM_SHINBUN))
                    {
                        //媒体名.
                        txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                        //スペース.
                        txtSpace.Text = _dataRow.hb1Field11.ToString();
                        //掲載日.
                        if (!String.IsNullOrEmpty(_dataRow.hb1Field3.ToString()))
                        {
                            //dtpFrom.Text = ConvertToDatetimeParsableString(_dataRow.hb1Field3.ToString().Trim());
                            if (_dataRow.hb1Field3.Length == 8)
                            {
                                string str = _dataRow.hb1Field3.Substring(0, 4) + "/" + _dataRow.hb1Field3.Substring(4, 2) + "/" + _dataRow.hb1Field3.Substring(6, 2);
                                DateTime dt = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(str);

                                if (dt != DateTime.MinValue)
                                {
                                    dtpFrom.CustomFormat = "yyyy/MM/dd";
                                    dtpFrom.Value = dt;
                                }
                                else
                                {
                                    dtpFrom.Value = null;
                                }
                            
                            }
                        }
                    }
                    else
                    {
                        //初期化 
                        txtBaitaiMei.Text = string.Empty;
                        txtSpace.Text = string.Empty;
                        dtpFrom.Value = null;
                    }
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                    break;

                #endregion 新聞
                # region その他 

                case C_MEI_SONOTA:
                    //媒体名.
                    txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();

                    # region 請求区分 

                    //請求区分 
                    switch (_dataRow.hb1SeiKbn)
                    {
                        //新聞 
                        case C_SEI_SHINBUN:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field12.ToString().Trim();
                            break;
                        //雑誌 
                        case C_SEI_ZASHI:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field10;
                            break;
                        //タイム 
                        case C_SEI_TIME:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field8.ToString().Trim();
                            break;
                        //スポット 
                        case C_SEI_SPOT:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field4.ToString().Trim();
                            break;
                        //諸作業 
                        case C_SEI_SHOSAGYO:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field5.ToString().Trim();
                            break;
                        //交通 
                        case C_SEI_KOTSU:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field5.ToString().Trim();
                            break;
                        //IC
                        case C_SEI_IC:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field5.ToString().Trim();
                            break;
                        //国際マス 
                        case C_SEI_KOKUMAS:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field2.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field3.ToString().Trim();
                            break;
                        //国際(諸作業)
                        case C_SEI_KOKUSHOSA:
                            //媒体名.
                            txtBaitaiMei.Text = _dataRow.hb1Field3.ToString();
                            //掲載日(期間16).
                            _keisai = _dataRow.hb1Field4.ToString().Trim();
                            break;
                    }
                    # endregion 請求区分 

                    //掲載日(期間16).
                    if (!string.IsNullOrEmpty(_keisai))
                    {
                        if (_keisai.Length >= 16)
                        {
                            dtpFrom.CustomFormat = "yyyy/MM/dd";
                            dtpTo.CustomFormat = "yyyy/MM/dd";
                            dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 8));
                            dtpTo.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(8, 8));
                        }
                    }
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                    break;

                #endregion その他 

                # region 制作 

                case C_MEI_SEISAKU:
                    //制作内容.
                    txtSeisaku.Text = string.Empty;
                    //納品日.
                    if (_dataRow.hb1GyomKbn.Equals(C_GYOM_CREAT))
                    {
                        //国際区分:国内のとき 
                        if (_dataRow.hb1KokKbn == "0")
                        {
                            //費目補足があるときは費目補足を納品日にセット
                            if (_dataRow.hb1Field3.ToString() != "")
                            {
                                txtNohinBi.Text = _dataRow.hb1Field3.ToString();
                            }
                            //費目補足がないときは納品期間を納品日にセット
                            else
                            {
                                if (_dataRow.hb1Field5.Length == 16)
                                {
                                    String v1 = _dataRow.hb1Field5.ToString().Substring(0, 8);
                                    String v2 = _dataRow.hb1Field5.ToString().Substring(8, 8);

                                    if (String.Equals(v1, v2))
                                    {
                                        txtNohinBi.Text = KKHUtility.StringCnvDateTime(v1.ToString()).ToString("M/d");
                                    }
                                    else
                                    {
                                        txtNohinBi.Text = _dataRow.hb1Field5.ToString().Substring(0, 4);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(4, 2);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(6, 2);
                                        txtNohinBi.Text += "-";
                                        txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(8, 4);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(12, 2);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(14, 2);
                                    }
                                }
                                else if (_dataRow.hb1Field5.Length == 8)
                                {
                                    txtNohinBi.Text = _dataRow.hb1Field5.ToString().Substring(0, 4);
                                    txtNohinBi.Text += "/";
                                    txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(4, 2);
                                    txtNohinBi.Text += "/";
                                    txtNohinBi.Text += _dataRow.hb1Field5.ToString().Substring(6, 2);
                                }
                                else
                                {
                                    txtNohinBi.Text = _dataRow.hb1Field5.ToString();
                                }
                            }
                        }
                        //国際区分:国際のとき 
                        else
                        {
                            //費目補足があるときは費目補足を納品日にセット 
                            if (_dataRow.hb1Field1.ToString() != "")
                            {
                                txtNohinBi.Text = _dataRow.hb1Field1.ToString();
                            }
                            //費目補足がないときは納品期間を納品日にセット 
                            else
                            {
                                if (_dataRow.hb1Field4.Length == 16)
                                {
                                    String v1 = _dataRow.hb1Field4.ToString().Substring(0, 8);
                                    String v2 = _dataRow.hb1Field4.ToString().Substring(8, 8);

                                    if (String.Equals(v1, v2))
                                    {
                                        txtNohinBi.Text = KKHUtility.StringCnvDateTime(v1.ToString()).ToString("M/d");
                                    }
                                    else
                                    {
                                        txtNohinBi.Text = _dataRow.hb1Field4.ToString().Substring(0, 4);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(4, 2);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(6, 2);
                                        txtNohinBi.Text += "-";
                                        txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(8, 4);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(12, 2);
                                        txtNohinBi.Text += "/";
                                        txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(14, 2);
                                    }
                                }
                                else if (_dataRow.hb1Field4.Length == 8)
                                {
                                    txtNohinBi.Text = _dataRow.hb1Field4.ToString().Substring(0, 4);
                                    txtNohinBi.Text += "/";
                                    txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(4, 2);
                                    txtNohinBi.Text += "/";
                                    txtNohinBi.Text += _dataRow.hb1Field4.ToString().Substring(6, 2);
                                }
                                else
                                {
                                    txtNohinBi.Text = _dataRow.hb1Field4.ToString();
                                }
                            }
                        }

                        //単価.
                        if (KKHUtility.IsNumeric(_dataRow.hb1SeiTnka.ToString()))
                        {
                            txtTanka.Text = _dataRow.hb1SeiTnka.ToString("###,###,###,##0");
                        }
                        else
                        {
                            txtTanka.Text = "0";
                        }
                        //txtTanka.Text = _dataRow.hb1SeiTnka.ToString("###,###,###,##0");

                        //回数数量.
                        _kaisuSuryo = _dataRow.hb1Field6.ToString().Trim();
                        if (int.TryParse(_kaisuSuryo, out result))
                        {
                            txtKaisu.Text = result.ToString();
                        }
                    }
                    else
                    {
                        txtNohinBi.Text = string.Empty;
                        txtTanka.Text = string.Empty;
                        txtKaisu.Text = string.Empty;
                    }
                    txtNohinBi.Location = new Point(86, 141);
                    //請求金額、消費税額をセットする 
                    SetSeikinShohizei(_dataRow);

                    break;

                #endregion 制作 
            }

        }

        /// <summary>
        /// 種別名ごとに明細の値をセットする.
        /// </summary>
        /// <param name="shubetsuCd"></param>
        private void SetMeisaiValue(string shubetsuMei)
        {

            //string _mHosoNenGetsu = string.Empty;.
            string _subHosoTsuki = string.Empty;
            string _keisai = string.Empty;
            string _kaisuSuryo = string.Empty;
            int result = 0;       //TryParse結果.

            #region 種別名で分岐

            //種別名で分岐.
            switch (shubetsuMei)
            {
                # region TV番組、TV特番

                case C_MEI_TVBAN:
                case C_MEI_TVTOK:
                    //放送月.
                    txtHosoTsuki.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HOSOTSUKI].Text.Trim();
                    //放送日.
                    txtHosoBi.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text.Trim();
                    //番組名
                    cmbBangumiMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BANGUMIMEI].Text.Trim();
                    break;
                # endregion TV番組、TV特番

                # region TVスポット
                case C_MEI_TVSPOT:
                    //媒体名.
                    txtBaitaiMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BAITAIMEI].Text;
                    //掲載日.
                    _keisai = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HOSOKAISU].Text.Trim();
                    if (string.IsNullOrEmpty(_keisai.Replace("-", "")))
                    {
                        dtpFrom.Value = null;
                        dtpTo.Value = null;
                    }
                    else
                    {
                        dtpFrom.CustomFormat = "yyyy/MM/dd";
                        dtpTo.CustomFormat = "yyyy/MM/dd";
                        dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 10));
                        dtpTo.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(11, 10));
                    }
                    //局数(放送回数).
                    _kaisuSuryo = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text.Trim();
                    if (int.TryParse(_kaisuSuryo, out result))
                    {
                        txtKaisu.Text = result.ToString();
                    }
                    break;
                # endregion TVスポット

                # region 雑誌、新聞

                case C_MEI_ZASHI:
                case C_MEI_SHINBUN:
                    //媒体名.
                    txtBaitaiMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BAITAIMEI].Text;
                    //スペース.
                    txtSpace.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SUPESU].Text;
                    //掲載号.
                    txtKeisaiGo.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIGO].Text.Trim();
                    //掲載日、発売日.
                    _keisai = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text.Trim();
                    if (!string.IsNullOrEmpty(_keisai))
                    {
                        dtpFrom.CustomFormat = "yyyy/MM/dd";
                        dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai);
                    }
                    //dtpFrom.Text = ConvertToDatetimeParsableString(_spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text.Trim());
                    break;
                # endregion 雑誌、新聞
                # region その他
                case C_MEI_SONOTA:
                    //媒体名.
                    txtBaitaiMei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BAITAIMEI].Text;
                    //掲載日.
                    _keisai = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text.Trim();
                    if (string.IsNullOrEmpty(_keisai.Replace("-","")))
                    {
                        dtpFrom.Value = null;
                        dtpTo.Value = null;
                        //dtpFrom.CustomFormat = "g";
                        //dtpTo.CustomFormat = "g";
                    }
                    else
                    {
                        dtpFrom.CustomFormat = "yyyy/MM/dd";
                        dtpTo.CustomFormat = "yyyy/MM/dd";
                        dtpFrom.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(0, 10));
                        dtpTo.Value = KKHUtility.StringCnvDateTime(_keisai.Substring(11, 10));
                    }
                    //dtpFrom.Text = _keisai.Substring(0 , 4) + _keisai.Substring(5 , 2) + _keisai.Substring(8 , 2);
                    //dtpTo.Text = _keisai.Substring(11 , 4) + _keisai.Substring(16 , 2) + _keisai.Substring(19 , 2);
                    break;
                # endregion その他
                # region 制作
                case C_MEI_SEISAKU:
                    //制作内容.
                    txtSeisaku.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SEISAKUNAIYO].Text;
                    //納品日.
                    txtNohinBi.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Text;
                    //単価.
                    //string _seiTanka = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_TANKA].Text.Trim();
                    //txtTanka.Text = _seiTanka.ToString("###,###,###,##0");
                    txtTanka.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_TANKA].Text.Trim();
                    //回数数量.
                    _kaisuSuryo = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HOSOKAISU].Text.Trim();
                    if (int.TryParse(_kaisuSuryo, out result))
                    {
                        txtKaisu.Text = result.ToString();
                    }
                    break;
                # endregion 制作

            }
            #endregion 種別名で分岐

            //****************************************.
            //請求金額、消費税額をセット.
            //****************************************.
            //TV番組、TV特番.
            //if (shubetsuMei.Equals(C_MEI_TVBAN) 
            //    || shubetsuMei.Equals(C_MEI_TVTOK))
            //{
            //    if (!String.IsNullOrEmpty(cmbBangumiMei.Text))
            //    {
            //        //単価.
            //        string _tanka = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_TANKA].Text.Trim();
            //        //放送回数.
            //        string _hosoKaisu = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HOSOKAISU].Text.Trim();
            //        if (string.IsNullOrEmpty(_hosoKaisu))
            //        {
            //            _hosoKaisu = "1";
            //        }
            //        CalcSeiKinShoZei(_tanka, _hosoKaisu);
            //    }
            //    else
            //    {
            //        SetSeikinShohizei(_dataRow);

            //    }
            //}
            //else
            //{
            //    SetSeikinShohizei(_dataRow);
            //}

            //明細登録済の受注は明細からデータを取得出来るように修正(2013/01/22 JSE A.Naito) ////////////////////////////////
            if (shubetsuMei.Equals(C_MEI_TVBAN)
                || shubetsuMei.Equals(C_MEI_TVTOK))
            {
              
                //単価.
                txtTanka2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_TANKA].Text.Trim();
                //放送回数.
                txtKaisu2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_HOSOKAISU].Text.Trim();
                //請求金額.
                txtSeikyuKinGaku2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SEIKYUKINGAKU].Text.Trim();
                //消費税額.
                txtShohiZeiGaku2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SHOHIZEIGAKU].Text.Trim();
            }
            else
            {
                //請求金額.
                txtSeikyuKinGaku.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SEIKYUKINGAKU].Text.Trim();
                //消費税額.
                txtShohiZeiGaku.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SHOHIZEIGAKU].Text.Trim();
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }


        /// <summary>
        /// 請求金額、消費税額を計算.
        /// /// </summary>
        /// <param name="tanka"></param>
        /// <param name="kaisu"></param>
        private void CalcSeiKinShoZei(string tanka , string kaisu)
        {
            //****************************************.
            //請求金額、消費税額をセット.
            //****************************************.
            //単価.
            decimal _dTanka = 0;
            string _stanka = string.Empty;
            decimal result2 = 0;
            if (!string.IsNullOrEmpty(tanka))
            {
                //decimal型にセット.
                if (decimal.TryParse(tanka, out result2))
                {
                    _stanka = result2.ToString();
                }
                _dTanka = decimal.Parse(_stanka);

            }

            //放送回数.
            decimal _dKaisu = 0;
            string _sKaisu = string.Empty;
            decimal result = 0;
            if (!string.IsNullOrEmpty(kaisu))
            {
                if (decimal.TryParse(kaisu, out result))
                {
                    _sKaisu = result.ToString();
                    //txtHosoKaisu.Text = result.ToString();
                }
                //decimal型にセット.
                _dKaisu = decimal.Parse(_sKaisu);
            }
            //請求金額 = 単価 × 回数.
            decimal _seikyuGak = _dTanka * _dKaisu;
            //消費税率.
            decimal _shozeiRit = decimal.Parse(_dataRow.hb1SzeiRitu.ToString());
            //消費税額 = 請求金額 * 消費税率.
            decimal _shozeiGak = 0M;    //消費税額.
            if (_shozeiRit != 0)
            {
                _shozeiGak = _seikyuGak * _shozeiRit / 100;
            }
            //小数点以下切捨て
            _shozeiGak = Math.Floor(_shozeiGak);

            //単価
            txtTanka.Text = _dTanka.ToString("###,###,###,##0");
            txtTanka2.Text = _dTanka.ToString("###,###,###,##0");

            //回数
            txtKaisu.Text = kaisu;
            txtKaisu2.Text = kaisu;
            //請求金額.
            txtSeikyuKinGaku2.Text = _seikyuGak.ToString("###,###,###,##0");
            //消費税額.
            txtShohiZeiGaku2.Text = _shozeiGak.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 明細スプレッドに入力内容をセットする.
        /// </summary>
        /// <param name="shuMei"></param>
        private void SetSpread(string shuMei)
        {
            //共通↓.
            //請求原票番号.
            string _seigen = string.Empty;
            string _seigen1 = txtSeiGenBango1.Text.Trim();
            string _seigen2 = txtSeiGenBango2.Text.Trim();
            string _seigen3 = txtSeiGenBango3.Text.Trim();
            if (!string.IsNullOrEmpty(_seigen1))
            {
                _seigen = _seigen1;
            }
            if (!string.IsNullOrEmpty(_seigen2))
            {
                if (_seigen.Length > 0)
                {
                    _seigen += "-";
                }
                _seigen += _seigen2;
            }
            if (!string.IsNullOrEmpty(_seigen3))
            {
                if (_seigen.Length > 0)
                {
                    _seigen += "-";
                }
                _seigen += _seigen3;
            }
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_SEIKYUGENPYO].Value = _seigen;
            //種別名.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SHUBETSU].Value = shubetsuNm;
            //種別コード.
            //_spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SHUBETSU].Value = cmbShubetsuHenko.SelectedValue;
            //件名.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_KENMEI].Value = txtKenNm.Text;
            //費目名.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HIMOKUMEI].Value = txtHimokuMei.Text;
            //ソート番号.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SOTOBANGO].Value = txtSotoBango.Text;
            //部署.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_BUSHO].Value = cmbBusho.Text;
            //種別名が「TV番組」「TV特番」の場合.
            if (shubetsuNm == C_MEI_TVBAN 
                || shubetsuNm == C_MEI_TVTOK)
            {
                //単価.
                _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_TANKA].Value = txtTanka.Text;
                //請求金額.
                _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SEIKYUKINGAKU].Value = txtSeikyuKinGaku2.Text;
                //消費税額.
                _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SHOHIZEIGAKU].Value = txtShohiZeiGaku2.Text;
            }
            else
            {
                //請求金額.
                _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SEIKYUKINGAKU].Value = txtSeikyuKinGaku.Text;
                //消費税額.
                _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SHOHIZEIGAKU].Value = txtShohiZeiGaku.Text;
            }
            //共通↑.

            //種別名で分岐.
            switch (shubetsuNm)
            {
                # region TV番組、TV特番 
                case C_MEI_TVBAN:
                case C_MEI_TVTOK:
                    //放送月.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HOSOTSUKI].Value = txtHosoTsuki.Text.Trim();
                    //放送日.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_KEISAIBI].Value = txtHosoBi.Text.Trim();
                    //番組名.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_BANGUMIMEI].Value = cmbBangumiMei.Text.Trim();
                    //放送回数.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HOSOKAISU].Value = txtKaisu2.Text.Trim();
                    break;
                # endregion TV番組、TV特番  

                # region TVスポット 
                case C_MEI_TVSPOT:
                    //媒体名.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_BAITAIMEI].Value = txtBaitaiMei.Text;
                    
                    //掲載日.
                    string ksaiBi = "";
                    if (!string.IsNullOrEmpty(dtpFrom.Text) 
                        && !string.IsNullOrEmpty(dtpTo.Text))
                    {
                        ksaiBi = dtpFrom.Text + "-" + dtpTo.Text;
                        //ksaiBi += "-";
                        //ksaiBi += dtpTo.Text;
                    }
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Value = ksaiBi;

                    //局数(放送回数).
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HOSOKAISU].Value = txtKaisu.Text.Trim();
                    break;
                # endregion TVスポット 

                # region 雑誌、新聞 
                case C_MEI_ZASHI:
                case C_MEI_SHINBUN:
                    //媒体名.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_BAITAIMEI].Value = txtBaitaiMei.Text;
                    //スペース.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SUPESU].Value = txtSpace.Text;
                    //掲載日.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Value = dtpFrom.Text;
                    //掲載号.
                    if (shubetsuNm == C_MEI_ZASHI)
                    {
                        _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIGO].Value = txtKeisaiGo.Text;
                    }
                    break;
                # endregion 雑誌、新聞 

                # region その他 
                case C_MEI_SONOTA:
                    //媒体名.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_BAITAIMEI].Value = txtBaitaiMei.Text;
                    //掲載日.
                    ksaiBi = "";
                    if (!string.IsNullOrEmpty(dtpFrom.Text.Trim()) && !string.IsNullOrEmpty(dtpTo.Text.Trim()))
                    {
                        ksaiBi = dtpFrom.Text + "-" + dtpTo.Text;
                    }
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_KEISAIBI].Value = ksaiBi;
                    break;
                # endregion その他 

                # region 制作 
                case C_MEI_SEISAKU:
                    //制作内容.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_SEISAKUNAIYO].Value = txtSeisaku.Text;
                    //納品日.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_KEISAIBI].Value = txtNohinBi.Text;
                    //単価.
                    if (string.IsNullOrEmpty(txtTanka.Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_TANKA].Value = 0;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[_rowDetailIdx, DetailUni.COLIDX_MLIST_TANKA].Value = txtTanka.Text;
                    }
                    //回数数量.
                    _spdKkhDetail_Sheet1.Cells[_rowDetailIdx , DetailUni.COLIDX_MLIST_HOSOKAISU].Value = txtKaisu.Text;
                    break;
                # endregion 制作 

            }

        }


        /// <summary>
        /// 桁数チェック.
        /// ※現行通りにしたが、半角も全角も１桁と数えている。いる？.
        /// </summary>
        private bool ChkNyuRyokuKetaSu()
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            //件名桁数ﾁｪｯｸ(帳票表示桁).
            if (!string.IsNullOrEmpty(txtKenNm.Text))
            {
                if (sjisEnc.GetByteCount(txtKenNm.Text) > 19)
                {
                    if (MessageUtility.ShowMessageBox(MessageCode.HB_W0002
                        , new string[] { lblKenMei.Text }
                        , "明細登録"
                        , MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            //費目名桁数ﾁｪｯｸ(帳票表示桁).
            //_iHanCnt = 0;
            if (!string.IsNullOrEmpty(txtKenNm.Text))
            {
                if (sjisEnc.GetByteCount(txtHimokuMei.Text) > 16)
                {
                    if (MessageUtility.ShowMessageBox(MessageCode.HB_W0001
                        , new string[] { lblHimokuMei.Text }
                        , "明細登録"
                        , MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 請求金額チェック
        /// </summary>
        private bool CheckSeikyuKinGaku()
        {
            decimal hb1SeiGak = 0M;
            decimal seikyuKinGaku = 0M;

            hb1SeiGak = KKHUtility.DecParse( _dataRow.hb1SeiGak.ToString() );

            // TV番組・TV特番の場合 
            if (shubetsuNm.Equals(C_MEI_TVBAN) || shubetsuNm.Equals(C_MEI_TVTOK))
            {
                seikyuKinGaku = KKHUtility.DecParse( txtSeikyuKinGaku2.Text );
            }
            else
            {
                seikyuKinGaku = KKHUtility.DecParse( txtSeikyuKinGaku.Text );
            }

            // 受注金額＞請求金額の場合 
            if (hb1SeiGak > seikyuKinGaku)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0132, null, "明細登録", MessageBoxButtons.OK);

                return false;
            }

            // 受注と請求の差が1000円以上の場合 
            if (( ( hb1SeiGak - seikyuKinGaku ) <= -1000 ))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0133, null, "明細登録", MessageBoxButtons.OK);

                return false;
            }

            return true;
        }

        /// <summary>
        /// yyyymmdd形式の文字列をDatetime形式の文字列に変換する 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        String ConvertToDatetimeParsableString( String value )
        {
            return Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime( value ).ToString();
        }

        /// <summary>
        /// 請求金額、消費税額をセット.
        /// </summary>
        /// <param name="pDataRow"></param>
        private void SetSeikinShohizei(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow pDataRow)
        {
            //請求金額.
            txtSeikyuKinGaku2.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
            //消費税額.
            txtShohiZeiGaku2.Text = _dataRow.hb1SzeiGak.ToString("###,###,###,##0");
            //請求金額.
            txtSeikyuKinGaku.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
            //消費税額.
            txtShohiZeiGaku.Text = _dataRow.hb1SzeiGak.ToString("###,###,###,##0");

        }

        #endregion メソッド 

    }
}
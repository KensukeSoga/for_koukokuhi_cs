using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;

using Isid.KKH.Lion.Utility;
using Isid.KKH.Lion.View.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Lion.ProcessController.MastGet;

using Isid.KKH.Lion.ProcessController.Detail;

namespace Isid.KKH.Lion.View.Detail
{
    /// <summary>
    /// ライオン明細入力画面.
    /// </summary>
    public partial class DetailInputLion : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region メンバ変数.

        private DetailInputLionNaviParameter _naviParam = new DetailInputLionNaviParameter();   //DetailInputLionNaviParameter

        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;//明細登録からの受注用.
        private int _rowDetailIndex = -1;//明細登録INDEX
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;//明細登録からの明細シート用.
        private string _pKmkType;//項目パターン.
        private string _currentKenNm = "";//カレント件名.
        private string pCardNO = "";//カードNO(保持用)
        private string pBaitaiNO = "";//媒体NO(保持用)
        private string pBitaiName = "";//媒体名称(保持用)
        private string pMeiCardNo = "";//明細データ存在時のカードＮＯ(明細登録画面よりパラメータで渡される)
        private string pMeiBaitaiNo = "";//明細データ存在時の媒体区分(明細登録画面よりパラメータで渡される)
        private Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable prTvRmast;//テレビ料金マスタ用.
        private Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable prRdRmast;//ラジオ料金マスタ用.
        private FindLionMastByCondServiceResult prTvBmast;//テレビ番組マスタ用.
        private FindLionMastByCondServiceResult prRdBmast;//ラジオ番組マスタ用.
        private FindLionMastByCondServiceResult prTvKmast;//テレビ局マスタ用.
        private FindLionMastByCondServiceResult prRdKmast;//ラジオ局マスタ用.
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtTvHenMast;//テレビ変換マスタ.
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtRdHenMast;//ラジオ変換マスタ.
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtShinHenMast;//新聞変換マスタ.
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtZashiHenMast;//雑誌変換マスタ.

        KKHLionReadMastDB readMastDB = new KKHLionReadMastDB();//汎用マスタ検索クラス(一度検索したマスタのデータを保持する)

        //消費税の自動計算を行うかどうかのフラグ.
        private Boolean bConFlg = false;

        //カードNo切り替え時の番組コード保持用.
        private string pBangumiCd = "";

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputLion()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //明細のチェックのみなので0行の場合はスルー.
            if (dgvMain_Sheet1.RowCount > 0)
            {
                //必須チェック.
                if (CheckRequired() == false)
                {
                    this.ActiveControl = null;
                    return;
                }

                //マスタコードチェック.
                if (CheckMastCd() == false)
                {
                    this.ActiveControl = null;
                    return;
                }

                //任意チェック.
                if (CheckAny() == false)
                {
                    this.ActiveControl = null;
                    return;
                }
            }

            //明細変更.
            EditKkhDetail();

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

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

        /// <summary>
        /// 画面遷移イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailInputLionNaviParameter)
            {
                _naviParam = (DetailInputLionNaviParameter)arg.NaviParameter;

                //KKH共通パラメータ.
                _dataRow = _naviParam.DataRow;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
                //独自パラメータ.
                _pKmkType = _naviParam.pStrTypePtan;
                pBaitaiNO = _naviParam.pBaitaiCd;
                pMeiCardNo = _naviParam.pMeiCardNo;
                pMeiBaitaiNo = _naviParam.pBaitaiCd;
                //マスタデータ.
                //テレビ系.
                prTvBmast = _naviParam.prTvBmast;
                prTvKmast = _naviParam.prTvKmast;
                prTvRmast = _naviParam.prTvRmast;
                //ラジオ系.
                prRdBmast = _naviParam.prRdBmast;
                prRdKmast = _naviParam.prRdKmast;
                prRdRmast = _naviParam.prRdRmast;
                //汎用マスタ系.
                dtTvHenMast = _naviParam.DtTvHenMast;//テレビ局コード変換マスタ.
                dtRdHenMast = _naviParam.DtRdHenMast;//ラジオ局コード変換マスタ.
            }
            else if (arg.NaviParameter is FindLionCodeItrNaviParameter)
            {
                FindLionCodeItrNaviParameter findNaviParam = (FindLionCodeItrNaviParameter)arg.NaviParameter;
                if (findNaviParam.CdNo == "009")
                {
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_FUKENCD].Value = findNaviParam.Cd;
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_STR1].Value = findNaviParam.Name;
                }
                else if (findNaviParam.CdNo == "012")
                {
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_BAITAI].Value = findNaviParam.Cd;
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_STR1].Value = findNaviParam.Name;
                }
                else
                {
                    //局誌コード.
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = findNaviParam.Cd;
                    //局誌名称.
                    dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_STR1].Value = findNaviParam.Name;

                    //雑誌の場合.
                    if (findNaviParam.CdNo == "008")
                    {
                        //スペースコード.
                        dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_SPACE].Value = findNaviParam.SpCd;
                        //宣伝費.
                        dgvMain_Sheet1.Cells[findNaviParam.CurrentRow, KKHLionConst.COLIDX_MLIST_INT1].Value = findNaviParam.Ryokin;
                    }
                }
            }
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputLion_Load(object sender, EventArgs e)
        {
            //消費税入力フラグをオフ.
            bConFlg = false;

            //各コントロールの初期化.
            InitializeControl();

            //スプレッドを上書きモードにする.
            this.dgvMain.EditModeReplace = true;

            //各コントロールの編集.
            editControl();

            //コントロールを未選択状態にする.
            //this.ActiveControl = null;

            //初期フォーカスを削除ボタンに設定.
            this.btnDelete.Select();
        }

        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            //テキストボックス.
            txtKenNm.Text = "";
            txtSeiKyuG.Text = "";
        }

        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            #region カードNO・媒体区分判定.

            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //////////////////////////////////////////////////////////////
                //明細がない場合.
                //////////////////////////////////////////////////////////////

                string strbaitaikbn = "";//媒体区分.
                string GymForCardNo = "";//明細データが存在しない時用のカードNO設定用変数.

                //ラジオ.
                if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_RD))
                {
                    //GymForCardNo = KKHLionConst.COLSTR_CARDNO_RDLCL;//ラジオ(ローカル)を設定.
                    //タイムの場合.
                    if (_dataRow.hb1TmspKbn.Equals("1")
                        || _dataRow.hb1TmspKbn.Equals(""))
                    {
                        GymForCardNo = KKHLionConst.COLSTR_CARDNO_RDLCL;//ラジオタイム(ローカル)を設定.
                        //媒体区分セット.
                        strbaitaikbn = KKHLionConst.BAITAIKBN_RD;
                    }
                    //スポットの場合.
                    else
                    {
                        GymForCardNo = KKHLionConst.COLSTR_CARDNO_SPOT;//スポットを設定.
                        //媒体区分セット.
                        strbaitaikbn = KKHLionConst.BAITAIKBN_RD_SPOT;
                    }
                }
                //テレビタイム.
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_TV))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_TVLCL;//テレビ(ローカル)を設定.
                    //媒体区分セット.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_TV;
                }
                //BSCS
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_BSCS))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_BSCS;//テレビ(ローカル)を設定.

                    //媒体区分セット.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_BSCS;
                }
                //スポット(テレビ/ラジオ)
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_SPOT))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_SPOT;//スポット(テレビ/ラジオ)を設定.
                    //媒体区分セット.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_TV_SPOT;
                }
                //新聞.
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_SINBN))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_SINBN;//新聞.
                    //媒体区分.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_NP;
                }
                //雑誌.
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_ZASSI))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_ZASSI;//雑誌.
                    //媒体区分.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_MZ;
                }
                //交通.
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_KOTU))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_KOTU;//交通.
                    //媒体区分.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_OOH;
                }
                //制作.
                else if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_SEISAKU))
                {
                    GymForCardNo = KKHLionConst.COLSTR_CARDNO_SEISAKU;//制作.
                }
                else
                {
                    //業務区分で変更.
                    //インターネットの場合.
                    if (_dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_INTARACTIVE))
                    {
                        GymForCardNo = KKHLionConst.COLSTR_CARDNO_INTERNET;//インターネット.
                        //媒体区分セット.
                        strbaitaikbn = KKHLionConst.BAITAIKBN_INT;
                    }
                    else
                    {
                        GymForCardNo = KKHLionConst.COLSTR_CARDNO_SONOTA;//その他.
                        //媒体区分セット.
                        strbaitaikbn = KKHLionConst.BAITAIKBN_OTHER;
                    }
                }

                //カードNO保持.
                pCardNO = GymForCardNo;
                //媒体NO保持.
                pBaitaiNO = strbaitaikbn;
            }
            else
            {
                //////////////////////////////////////////////////////////////
                //明細がある場合.
                //////////////////////////////////////////////////////////////

                pCardNO = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_CARDNO].Value.ToString();
                pBaitaiNO = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BAITAI].Value.ToString();
            }

            #endregion カードNO・媒体区分判定.

            #region ヘッダ部の表示設定.

            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();

            //表示パターン取得.
            _pKmkType = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_CDPATARN, pCardNO, "");

            ////項目設定(上記で取得したパターンで設定する)
            //utl.kmkset(_pKmkType, pBaitaiNO, dgvMain_Sheet1);

            //コントロール編集.
            ControlChange(_pKmkType, pBaitaiNO);

            //ブランドマスタ読込.
            SetCmbBrand();

            //番組コンボ.
            if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL)
                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS)
                )
            {
                //テレビ番組マスタ.
                SetCmbTvB();

                //前回の番組をコンボボックスにセット.
                cmbBangumi.SelectedValue = pBangumiCd;

            }
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL)
                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                )
            {
                //ラジオ番組マスタ.
                SetCmbRdB();

                //前回の番組をコンボボックスにセット.
                cmbBangumi.SelectedValue = pBangumiCd;

            }

            //地区設定.
            SetCmdSeitiku();
            #endregion ヘッダ部の表示設定.

            #region 明細部の表示設定.

            //項目設定.
            //スプレッドシートの列、行数の値を取得し入力画面の明細に設定.
            dgvMain_Sheet1.ColumnCount = _spdKkhDetail_Sheet1.ColumnCount;
            dgvMain_Sheet1.FrozenColumnCount = KKHLionConst.COLIDX_MLIST_STR1 + 1;

            //foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
            for (int cnt = 0; cnt < dgvMain_Sheet1.Columns.Count; cnt++)
            {
                FarPoint.Win.Spread.Column col = dgvMain_Sheet1.Columns[cnt];

                //共通処理.
                dgvMain_Sheet1.Columns[cnt].Label = _spdKkhDetail_Sheet1.Columns[cnt].Label;
                dgvMain_Sheet1.Columns[cnt].Visible = _spdKkhDetail_Sheet1.Columns[cnt].Visible;
                dgvMain_Sheet1.Columns[cnt].Width = _spdKkhDetail_Sheet1.Columns[cnt].Width;

                //カードNO
                if (cnt == KKHLionConst.COLIDX_MLIST_CARDNO)
                {
                    //CellTypeをボタンに変更.
                    col.CellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    FarPoint.Win.Spread.CellType.ButtonCellType cellType = (FarPoint.Win.Spread.CellType.ButtonCellType)col.CellType;
                    cellType.Text = pCardNO;
                }
                //ブランドCDをコンボボックスとして表示.
                else if (cnt == KKHLionConst.COLIDX_MLIST_BRANDCD)
                {
                    //ブランドデータ抽出.
                    Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = null;

                    Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process =
                        Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
                    FindMasterMaintenanceByCondServiceResult result;

                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                      _naviParam.strEgcd,
                                                      _naviParam.strTksKgyCd,
                                                      _naviParam.strTksBmnSeqNo,
                                                      _naviParam.strTksTntSeqNo,
                                                      KKHLionConst.C_MAST_BRAND_CD,
                                                      null);

                    dt = result.MasterDataSet.MasterDataVO;

                    List<string> code = new List<string>();
                    List<string> name = new List<string>();
                    for (int i = 0; i < dt.Count; i++)
                    {
                        code.Add(dt[i].Column1);
                        name.Add(dt[i].Column1 + " " + dt[i].Column2);
                    }
                    code.Insert(0, "");
                    name.Insert(0, "");

                    //セルタイプをコンボボックスに＋データ紐づけ.
                    col.CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType cellType = (FarPoint.Win.Spread.CellType.ComboBoxCellType)col.CellType;
                    cellType.Items = name.ToArray();
                    cellType.ItemData = code.ToArray();
                    cellType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    col.CellType = cellType;

                    //okazaki
                    //ブランド列を非表示にする.
                    if (!(_pKmkType.Equals(KKHLionConst.COLSTR_KMKTYPE_6) ||
                        _pKmkType.Equals(KKHLionConst.COLSTR_KMKTYPE_8)))
                    {
                        col.Visible = false;
                    }
                    //okazaki

                }
                else if (cnt == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                {
                    col.Locked = true;
                    //明細登録画面のスプレッドと同様のタイプ.
                    col.CellType = _spdKkhDetail_Sheet1.Columns[cnt].CellType;
                }
                else if (cnt == KKHLionConst.COLIDX_MLIST_TIKUGO)
                {
                    col.Locked = true;
                    //明細登録画面のスプレッドと同様のタイプ.
                    col.CellType = _spdKkhDetail_Sheet1.Columns[cnt].CellType;
                }
                //上記以外の処理.
                else
                {
                    //明細登録画面のスプレッドと同様のタイプ.
                    col.CellType = _spdKkhDetail_Sheet1.Columns[cnt].CellType;
                }
            }

            #endregion 明細部の表示設定.

            #region 値設定.

            //////////////////////////////////////////////////////////////
            //明細がない場合.
            //////////////////////////////////////////////////////////////
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //スプレッドシートの行をクリア⇒１行追加.
                dgvMain_Sheet1.RowCount = 0;
                dgvMain_Sheet1.RowCount = 1;

                SetDownload_CardNo(0);//初期値編集(明細部の設定、ヘッダ部の合計項目等編集).

            }
            //////////////////////////////////////////////////////////////
            //明細がある場合.
            //////////////////////////////////////////////////////////////
            else
            {
                //*************************************
                //明細部の編集.
                //*************************************
                //スプレッドシートの列、行数の値を取得し入力画面の明細に設定.
                dgvMain_Sheet1.ColumnCount = _spdKkhDetail_Sheet1.ColumnCount;
                dgvMain_Sheet1.RowCount = _spdKkhDetail_Sheet1.RowCount;

                //スプレッドのレイアウト描画中止.
                dgvMain.SuspendLayout();

                //データ設定.
                for (int i = 0; i < dgvMain_Sheet1.RowCount; i++)
                {
                    for (int ii = 0; ii < dgvMain_Sheet1.ColumnCount; ii++)
                    {
                        //カードNO
                        switch (ii)
                        {
                            //カードNO処理(セルに値があるとボタンがアクティブになってしまうため、nullにする)
                            case KKHLionConst.COLIDX_MLIST_CARDNO:
                                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Value = null;
                                break;
                            //ブランド.
                            case KKHLionConst.COLIDX_MLIST_BRANDCD:
                                string brandCd = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value);
                                string[] value = brandCd.Split(' ');
                                if (value.Length > 0)
                                {
                                    dgvMain_Sheet1.Cells[i, ii].Value = value[0];
                                }
                                break;
                            //他.
                            default:
                                dgvMain_Sheet1.Cells[i, ii].Value = _spdKkhDetail_Sheet1.Cells[i, ii].Value;
                                break;
                        }
                    }
                }

                //レイアウトロジック再開.
                dgvMain.ResumeLayout(true);

                //*************************************
                //ヘッダ部の編集.
                //*************************************
                if (lblBrand.Visible == true)
                {
                    //ブランドコード取得.
                    string brandCd = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BRANDCD].Value);
                    string[] value = brandCd.Split(' ');

                    cmbBrand.SelectedValue = value[0];
                }

                if (lblBangumi.Visible == true)
                {
                    //番組コード取得.
                    string bangumiCd = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BANGCD].Value);

                    //SelectedIndexChangedイベント削除.
                    cmbBangumi.SelectedIndexChanged -= new EventHandler(cmbBangumi_SelectedIndexChanged);

                    //指定した番組名をコンボボックスにセット.
                    cmbBangumi.SelectedValue = bangumiCd;

                    //SelectedIndexChangedイベント復活.
                    cmbBangumi.SelectedIndexChanged += new EventHandler(cmbBangumi_SelectedIndexChanged);
                }


                //放送回数を設定.
                string hososu = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_HOSOSU].Value);

                if (KKHUtility.IsNumeric(hososu))
                {
                    txtHososu.Text = int.Parse(hososu).ToString();
                }
                //それ以外は1＋保持.
                else
                {
                    txtHososu.Text = "1";
                }

                //休止回数を設定.
                string kyusisu = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_KYUSISU].Value);

                if (KKHUtility.IsNumeric(kyusisu))
                {
                    txtKyusisu.Text = int.Parse(kyusisu).ToString();
                }
                //それ以外は0＋保持.
                else
                {
                    txtKyusisu.Text = "0";
                }

                //キャンペーン期間を設定.
                string kikan = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_KIKAN].Value);

                if (!String.IsNullOrEmpty(kikan.Trim()))
                {
                    /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD start */
                    if (kikan.Length == 23)
                    {
                        /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD end */
                        if (KKHUtility.IsDate(kikan.Substring(0, 10), "yyyy/MM/dd") &&
                            KKHUtility.IsDate(kikan.Substring(13, 10), "yyyy/MM/dd"))
                        {
                            //期間FROM
                            txtCanpFrom.Text = kikan.Substring(0, 10).Replace("/", string.Empty);
                            //期間TO
                            txtCanpTo.Text = kikan.Substring(13, 10).Replace("/", string.Empty);
                        }
                        else
                        {
                            txtCanpFrom.Text = " ";
                            txtCanpTo.Text = " ";
                        }
                        /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD start */
                    }
                    /* 2014/09/30 消費税端数調整対応 HLC fujimoto MOD end */
                }
                else
                {
                    txtCanpFrom.Text = " ";
                    txtCanpTo.Text = " ";
                }

                //秒数を設定.
                string byosu = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BYOSU].Value);

                if (KKHUtility.IsNumeric(byosu))
                {
                    txtByosu.Text = int.Parse(byosu).ToString();
                }
                //それ以外は0＋保持.
                else
                {
                    txtByosu.Text = "0";
                }

                //合計計算処理.
                CalcTotalCost();
            }

            //////////////////////////////////////////////////////////////
            //明細ありなし共通.
            //////////////////////////////////////////////////////////////
            _currentKenNm = _dataRow.hb1KKNameKJ.ToString().Trim();//件名変更チェック時に必要？.
            txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
            txtYymm.Text = _dataRow.hb1Yymm.Substring(0, 4) + "/" + _dataRow.hb1Yymm.Substring(4, 2);//年月.

            //okazaki
            dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_CARDNO].Visible = true;
            dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_BIKO].Visible = true;
            dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_URIMEI].Visible = true;
            //okazaki

            #endregion 値設定.
        }

        /// <summary>
        /// 各ヘッダ部コントロールの表示、非表示処理.
        /// </summary>
        private void ControlChange(string PtnType, string TvorRd)
        {
            //テレビスポットボタンを非表示にする.
            btnTvSpot.Visible = false;

            //パターン１(テレビタイム、ラジオタイム、BS、CS用)
            if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_1))
            {
                //電波料金.
                lblDenpaRyoG.Visible = true;
                txtDenpaRyoG.Visible = true;
                //ネット料金.
                lblNetRyoG.Visible = true;
                txtNetRyoG.Visible = true;
                //ブランド名コンボボックス.
                lblBrand.Visible = false;
                cmbBrand.Visible = false;
                //番組名コンボボックス.
                lblBangumi.Visible = true;
                cmbBangumi.Visible = true;
                //消費税１.
                lblSyohizei1.Visible = false;
                txtTax1.Visible = false;
                //消費税２.
                lblSyohizei2.Visible = false;
                txtTax2.Visible = false;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = true;
            }
            //パターン２(テレビスポット、ラジオスポット)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_2))
            {
                //電波料金.
                lblDenpaRyoG.Visible = true;
                txtDenpaRyoG.Visible = true;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = true;
                cmbBrand.Visible = true;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Visible = false;
                txtTax1.Visible = false;
                //消費税２.
                lblSyohizei2.Visible = false;
                txtTax2.Visible = false;
                //制地区コンボボックス.
                lblTiku.Visible = true;
                cmbSeitiku.Visible = true;
                //スポットグループ.
                grpSpot.Visible = true;
                //制作費グループ.
                grpHKkaisu.Visible = false;

                //テレビスポットの場合.
                if (pBaitaiNO.Equals(KKHLionConst.BAITAIKBN_TV_SPOT))
                {
                    btnTvSpot.Visible = true;
                }
            }
            //パターン３(新聞)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_3))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = true;
                cmbBrand.Visible = true;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Visible = false;
                txtTax1.Visible = false;
                //消費税２.
                lblSyohizei2.Visible = false;
                txtTax2.Visible = false;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
            //パターン４(雑誌)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_4))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = true;
                cmbBrand.Visible = true;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Visible = false;
                txtTax1.Visible = false;
                //消費税２.
                lblSyohizei2.Visible = false;
                txtTax2.Visible = false;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
            //パターン５(交通)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_5))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = true;
                cmbBrand.Visible = true;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Visible = false;
                txtTax1.Visible = false;
                //消費税２.
                lblSyohizei2.Visible = false;
                txtTax2.Visible = false;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
            //パターン６(その他、チラシ、サンプリング、事業費)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_6))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = false;
                cmbBrand.Visible = false;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Text = "媒体消費税(1)";
                lblSyohizei1.Visible = true;
                txtTax1.Visible = true;
                //消費税２.
                lblSyohizei2.Text = "媒体消費税(2)";
                lblSyohizei2.Visible = true;
                txtTax2.Visible = true;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
            //パターン７(制作)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_7))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = true;
                cmbBrand.Visible = true;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Text = "制作消費税(1)";
                lblSyohizei1.Visible = true;
                txtTax1.Visible = true;
                //消費税２.
                lblSyohizei2.Text = "制作消費税(2)";
                lblSyohizei2.Visible = true;
                txtTax2.Visible = true;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
            //パターン８(インターネット、モバイル)
            else if (PtnType.Equals(KKHLionConst.COLSTR_KMKTYPE_8))
            {
                //電波料金.
                lblDenpaRyoG.Visible = false;
                txtDenpaRyoG.Visible = false;
                //ネット料金.
                lblNetRyoG.Visible = false;
                txtNetRyoG.Visible = false;
                //ブランド名コンボボックス.
                lblBrand.Visible = false;
                cmbBrand.Visible = false;
                //番組名コンボボックス.
                lblBangumi.Visible = false;
                cmbBangumi.Visible = false;
                //消費税１.
                lblSyohizei1.Text = "媒体消費税(1)";
                lblSyohizei1.Visible = true;
                txtTax1.Visible = true;
                //消費税２.
                lblSyohizei2.Text = "媒体消費税(2)";
                lblSyohizei2.Visible = true;
                txtTax2.Visible = true;
                //制地区コンボボックス.
                lblTiku.Visible = false;
                cmbSeitiku.Visible = false;
                //スポットグループ.
                grpSpot.Visible = false;
                //制作費グループ.
                grpHKkaisu.Visible = false;
            }
        }

        /// <summary>
        /// 新聞マスタの読み込み.
        /// </summary>
        /// <returns></returns>
        private string loadMaster(string mastsybt, string srccd)
        {
            string retval = "";

            Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController controller =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result = null;

            result = controller.FindMasterByCond
            (
                _naviParam.strEsqId,
                _naviParam.strEgcd,
                _naviParam.strTksKgyCd,
                _naviParam.strTksBmnSeqNo,
                _naviParam.strTksTntSeqNo,
                mastsybt,
                srccd
            );

            //エラーの場合.
            if (result.HasError == true)
            {
                retval = "";
            }

            //取得件数が0件の場合.
            if (result.MasterDataSet.MasterDataVO.Rows.Count <= 0)
            {
                retval = "";
            }
            else
            {
                /* 2014/12/04 ライオン新聞対応 HLC fujimoto MOD start */
                string strWhere = "COLUMN1 = '" + srccd + "'";
                DataRow[] row = result.MasterDataSet.MasterDataVO.Select(strWhere);
                retval = row[0]["COLUMN2"].ToString();

                //retval = result.MasterDataSet.MasterDataVO[0].Column2;//名称取得.
                /* 2014/12/04 ライオン新聞対応 HLC fujimoto MOD end */
            }

            return retval;
        }

        /// <summary>
        /// 掲載日変換.
        /// </summary>
        /// <returns></returns>
        private string keisaihenkan(string keisaibi)
        {
            string retval = "";

            retval = keisaibi.Substring(0, 4) + "/" +
                            keisaibi.Substring(4, 2) + "/" +
                            keisaibi.Substring(6, 2) + " - " +
                            keisaibi.Substring(8, 4) + "/" +
                            keisaibi.Substring(12, 2) + "/" +
                            keisaibi.Substring(14, 2);

            return retval;
        }

        /// <summary>
        /// 1行追加(＋カードNOでの設定でデータadd)
        /// </summary>
        /// <returns></returns>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //最大行に１行追加.
            dgvMain_Sheet1.AddRows(dgvMain_Sheet1.RowCount, 1);

            //カードNOで追加行の初期値を設定する.
            SetDownload_CardNo(dgvMain_Sheet1.RowCount - 1);

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細ダブルクリック時処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //局誌、媒体CD列（２列目）クリック時にコード一覧画面を出す.
            if (
                //局誌CD＋テレビネット.
                   (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET))
                //局誌CD＋テレビローカル.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL))
                //局誌CD＋ラジオネット.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET))
                //局誌CD＋ラジオローカル.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL))
                //局誌CD＋スポット.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SPOT))
                //局誌CD＋新聞.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SINBN))
                //局誌CD＋雑誌.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_ZASSI))
                //府県CD＋交通.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_FUKENCD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_KOTU))
                //媒体CD＋制作.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_BAITAI
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU))
                //局誌CD＋BS/CS
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS))
                //局誌CD＋インターネット.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_INTERNET))
                //局誌CD＋モバイル.
                || (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_KYOKUSICD
                     && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_MOBIL))
                   )
            {

                //媒体に対するデータが存在するか確認.
                DetailLionProcessController.FindLionCodeItrParam param = new DetailLionProcessController.FindLionCodeItrParam();
                param.esqId = _naviParam.strEsqId;
                param.egCd = _naviParam.strEgcd;
                param.tksKgyCd = _naviParam.strTksKgyCd;
                param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParam.strTksTntSeqNo;

                DetailLionProcessController processController = DetailLionProcessController.GetInstance();
                FindLionCodeItrServiceResult coderesult = processController.FindLionCodeItrService(pCardNO, pBaitaiNO, param);
                if (coderesult.HasError)
                {
                    return;
                }
                if (coderesult.CILionDataSet.KkhCodeItr.Count == 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0143
                                                , null
                                                , "明細登録"
                                                , MessageBoxButtons.OK);
                    return;
                }

                //明細入力画面表示.
                FindLionCodeItrNaviParameter naviParam = new FindLionCodeItrNaviParameter();
                naviParam.strEsqId = _naviParam.strEsqId;
                naviParam.strEgcd = _naviParam.strEgcd;
                naviParam.strTksKgyCd = _naviParam.strTksKgyCd;
                naviParam.strTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                naviParam.strTksTntSeqNo = _naviParam.strTksTntSeqNo;
                naviParam.CdNo = pCardNO;
                naviParam.BtCd = pBaitaiNO;
                naviParam.CurrentRow = dgvMain_Sheet1.ActiveRowIndex;

                object result = Navigator.ShowModalForm(this, "toFindLionCodeItr", naviParam);
                if (result == null)
                {
                    return;
                }

                //セット.
                if (naviParam.CdNo.Equals(""))
                { }
                else
                {
                    //局誌にデータをセットするもの.
                    if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SPOT)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SINBN)
                        )
                    {
                        //局誌CD
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value
                            = naviParam.Cd;
                        //名称.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_STR1].Value
                            = naviParam.Name;
                    }
                    else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_ZASSI))
                    {
                        //局誌CD
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = naviParam.Cd;
                        //名称.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_STR1].Value = naviParam.Name;
                        //スペース.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_SPACE].Value = naviParam.SpCd;
                        //実施料.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_INT1].Value = naviParam.Ryokin;
                    }
                    //府県にデータをセットするもの.
                    //府県CD＋交通.
                    else if (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_FUKENCD
                             && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_KOTU))
                    {
                        //府県CD
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_FUKENCD].Value
                            = naviParam.Cd;
                        //名称.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_STR1].Value
                            = naviParam.Name;
                    }
                    //媒体CDにセットするもの.
                    else if (dgvMain_Sheet1.ActiveColumnIndex == KKHLionConst.COLIDX_MLIST_BAITAI
                            && pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU))
                    {
                        //媒体CD
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_BAITAI].Value
                            = naviParam.Cd;
                        //名称.
                        dgvMain_Sheet1.Cells[dgvMain_Sheet1.ActiveRowIndex, KKHLionConst.COLIDX_MLIST_STR1].Value
                            = naviParam.Name;
                    }
                }
            }
        }

        /// <summary>
        /// 行削除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //行が存在しない場合は何もしない.
            if (dgvMain_Sheet1.RowCount == 0)
            {
                return;
            }

            //１行削除.
            dgvMain_Sheet1.RemoveRows(dgvMain_Sheet1.ActiveRowIndex, 1);

            //金額計算.
            CalcClaimCost(dgvMain_Sheet1.ActiveRowIndex);

            //計算処理.
            CalcTotalCost();

            //消費税.
            CalcTaxCost(dgvMain_Sheet1.ActiveRowIndex);

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// スプレッド内容変更時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            int rowIndex = 0;
            //指定したRowIndexを取得.
            //rowIndex = dgvMain_Sheet1.ActiveRowIndex;
            rowIndex = e.Row;

            switch (e.Column)
            {
                case KKHLionConst.COLIDX_MLIST_INT1:         //実施料.
                case KKHLionConst.COLIDX_MLIST_JISIDENPA:    //電波料.
                case KKHLionConst.COLIDX_MLIST_NBKRITU:      //値引率.
                case KKHLionConst.COLIDX_MLIST_INT2:         //制作費・タイアップ制作費.
                case KKHLionConst.COLIDX_MLIST_NETRYO:       //ネット料.
                    //Null、空白の場合、0をセット.
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_INT1);
                    //値引額の計算.
                    CalcNebikiGaku(rowIndex);
                    //請求金額の計算.
                    CalcClaimCost(rowIndex);
                    //消費税の計算.
                    CalcTaxCost(rowIndex);
                    //合計項目の計算.
                    CalcTotalCost();
                    break;
                case KKHLionConst.COLIDX_MLIST_NBKDENPARYO:  //値引電波料.
                    //請求金額の計算.
                    CalcClaimCost(rowIndex);
                    //消費税の計算.
                    CalcTaxCost(rowIndex);
                    //合計項目の計算.
                    CalcTotalCost();
                    break;
                case KKHLionConst.COLIDX_MLIST_NBKGOKNGK:    //値引後金額.
                case KKHLionConst.COLIDX_MLIST_TAXRITU:      //消費税率.
                    //Null、空白の場合、0をセット.
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_TAXRITU);
                    CalcTaxCost(rowIndex);
                    //合計項目の計算.
                    CalcTotalCost();
                    break;
                case KKHLionConst.COLIDX_MLIST_TAX:          //消費税.
                    //Null、空白の場合、0をセット.
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_TAX);
                    //合計項目の計算.
                    CalcTotalCost();
                    break;
                case KKHLionConst.COLIDX_MLIST_HONSU:        //本数.
                case KKHLionConst.COLIDX_MLIST_BYOSU:        //秒数.
                    //Null、空白の場合、0をセット.
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_BYOSU);
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_HONSU);
                    //総秒数の計算.
                    CalcSoByosu(rowIndex);
                    break;
                case KKHLionConst.COLIDX_MLIST_SOBYOSU:     //総秒数.
                    //Null、空白の場合、0をセット.
                    SetZero(rowIndex, KKHLionConst.COLIDX_MLIST_SOBYOSU);
                    break;
                case KKHLionConst.COLIDX_MLIST_KIKAN:       //期間.
                    String kikan = KKHUtility.ToString(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_KIKAN].Value);
                    if (kikan.Length == 16)
                    {
                        dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_KIKAN].Value = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2)
                            + "/" + kikan.Substring(6, 2) + " - " + kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2);
                    }
                    break;
                case KKHLionConst.COLIDX_MLIST_BIKO:       //備考.
                    //60byteまで入力可.
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
                    TextCellType tCell = (TextCellType)dgvMain_Sheet1.GetCellType(e.Row, e.Column);
                    string s = dgvMain_Sheet1.GetValue(e.Row, e.Column).ToString();
                    if (enc.GetByteCount(s) > 60)
                    {
                        char[] chrs = enc.GetChars(enc.GetBytes(s), 0, 60);
                        s = enc.GetString(enc.GetBytes(chrs));
                        dgvMain_Sheet1.SetValue(e.Row, e.Column, s);
                    }
                    break;
                default:
                    break;
            }

            //消費税項目を直接入力した場合は消費税入力フラグをオン.
            if (e.Column == KKHLionConst.COLIDX_MLIST_TAX)
            {
                bConFlg = true;
            }

            //明細1行目の消費税率を直接編集した場合は消費税入力フラグをオフ.
            if ((e.Column == KKHLionConst.COLIDX_MLIST_TAXRITU) && (e.Row == 0))
            {
                bConFlg = false;
            }

            ////金額計算.
            //CalcClaimCost(rowIndex);
            ////計算処理.
            //CalcTotalCost();
            ////消費税.
            //CalcTaxCost(rowIndex);
        }

        /// <summary>
        /// スプレッドKeyDown時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_KeyDown(object sender, KeyEventArgs e)
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
                    //選択範囲終了行.
                    int rowEnd = (rn.Row + rn.RowCount - 1);
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        //行分ループ.
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(this.dgvMain.GetRootWorkbook(), clipVal, rowCnt, colCnt);

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

        /// <summary>
        /// 放送回数、休止回数からフォーカスが外れた時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosKysi_Leave(object sender, EventArgs e)
        {
            int keisan = 0;
            int housou = 0;
            int kyusisu = 0;

            if (KKHUtility.IsNumeric(txtHososu.Text))
            {
                housou = int.Parse(txtHososu.Text);
            }
            if (KKHUtility.IsNumeric(txtKyusisu.Text))
            {
                kyusisu = int.Parse(txtKyusisu.Text);
            }
            //本数 = 放送回数 - 休止回数.
            keisan = housou - kyusisu;

            //０以下の場合は０設定.
            if (keisan < 0)
            {
                keisan = 0;
            }

            //単価区分.
            string tnkbn = string.Empty;

            //単価区分取得.
            if (cmbBangumi.Text.Trim() != string.Empty)
            {
                //テレビ番組マスタ.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS)
                    )
                {
                    MastLion.TvBnLionRow[] tvLion;
                    tvLion = (MastLion.TvBnLionRow[])prTvBmast.mastLionDataSet.TvBnLion.Select("BANCD = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");
                    if (tvLion.Length > 0) tnkbn = tvLion[0].TANKA;
                }
                //ラジオ番組マスタ.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                    )
                {
                    MastLion.RdBnLionRow[] rdLion;
                    rdLion = (MastLion.RdBnLionRow[])prRdBmast.mastLionDataSet.RdBnLion.Select("BANCD = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");
                    if (rdLion.Length > 0) tnkbn = rdLion[0].TANKA;

                }
            }

            //全行に対して処理.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //放送回数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = housou.ToString();
                //休止回数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = kyusisu.ToString();
                //元の本数を記憶.
                //int honsu_org = int.Parse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HONSU].Text);
                int honsu_org = KKHUtility.IntParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HONSU].Text);
                //本数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HONSU].Value = keisan.ToString();
                //総秒数を反映.
                CalcSoByosu(row.Index);

                //単価の場合は×本数.
                if (tnkbn.Equals("1"))
                {
                    //電波料.
                    decimal denpa = Decimal.Parse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                    //ネット料.
                    decimal netryo = Decimal.Parse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NETRYO].Text);
                    //制作費.
                    decimal seisakuhi = Decimal.Parse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_INT2].Text);

                    if (denpa > 0 && honsu_org > 0)
                    {
                        //電波料.
                        dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value =
                            Math.Truncate(denpa / honsu_org * keisan);
                        //値引き電波料.
                        dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value =
                            Math.Truncate(Math.Truncate(denpa / honsu_org * keisan) * (_dataRow.hb1NeviRitu * 0.01M));
                    }

                    if (netryo > 0 && honsu_org > 0)
                    {
                        //ネット料.
                        dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NETRYO].Value =
                            Math.Truncate(netryo / honsu_org * keisan);
                    }

                    if (seisakuhi > 0 && honsu_org > 0)
                    {
                        //制作費.
                        dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_INT2].Value =
                            Math.Truncate(seisakuhi / honsu_org * keisan);
                    }

                    //値引額の計算.
                    CalcNebikiGaku(row.Index);
                    //請求金額の計算.
                    CalcClaimCost(row.Index);
                    //消費税の計算.
                    CalcTaxCost(row.Index);
                }
            }
            CalcTotalCost();
        }

        /// <summary>
        /// 放送回数、休止回数が編集されたときのイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHosKysi_TextChanged(object sender, EventArgs e)
        {
            int keisan = 0;
            int housou = 0;
            int kyusisu = 0;

            if (KKHUtility.IsNumeric(txtHososu.Text))
            {
                housou = int.Parse(txtHososu.Text);
            }
            if (KKHUtility.IsNumeric(txtKyusisu.Text))
            {
                kyusisu = int.Parse(txtKyusisu.Text);
            }
            //本数 = 放送回数 - 休止回数.
            keisan = housou - kyusisu;

            //０以下の場合は０設定.
            if (keisan < 0)
            {
                keisan = 0;
            }

            //全行に対して処理.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //放送回数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = housou.ToString();
                //休止回数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = kyusisu.ToString();
                //本数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HONSU].Value = keisan.ToString();
                //総秒数を反映.
                CalcSoByosu(row.Index);
            }
        }

        #endregion

        #region メソッド.

        /// <summary>
        /// カードNOで初期値設定処理.
        /// </summary>
        /// <returns></returns>
        private void SetDownload_CardNo(int lRows)
        {
            //合計額用.
            decimal seigakug = 0M;
            decimal jisidenpa = 0M;
            decimal netryo = 0M;

            //カウント用変数.
            //int cnt = 0;
            //各項目用.
            string strFdretu = " ";         //FD
            string strkyokusicd = "";       //局誌CD
            //string strkyokusicd = " ";    //局誌CD
            string strkyokusinm = " ";      //局誌名,
            string strspace = " ";          //スペース,
            string strkeisaietc = " ";      //掲載日・号・ほか.
            string strkikan = " ";          //期間.
            string strbaitaikbn = "";       //媒体区分.
            string strkyusikaisu = "";      //休止回数.
            string strhonsu = "";           //本数.
            string strbyosu = "";           //秒数.
            string strsobyosu = "";         //総秒数.
            int intsobyosu = 0;             //総秒数.
            string strhosokaisu = "";       //放送回数.
            string strhosokaisu_h = "";     //放送回数(本数)
            decimal nebikidenpa = 0M;       //値引き電波料.
            decimal int1 = 0M;              //制作費等.
            string GymForCardNo = "";       //明細データが存在しない時用のカードNO設定用変数.

            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();

            //請求額計の計算.
            seigakug = _dataRow.hb1SeiGak;

            //カードNOの設定(業務区分により変化)
            //ラジオタイム(ローカル、ネット)
            if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL))
            {
                GymForCardNo = pCardNO;     //ラジオ(ローカル)をセット.

                //ローカルかネットで分岐.
                //ネットの場合.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET))
                {
                    //FD列.
                    strFdretu = "04";
                }
                else
                {
                    strFdretu = "05";
                }

                //媒体区分セット.
                strbaitaikbn = KKHLionConst.BAITAIKBN_RD;
                //休止回数.
                strkyusikaisu = "0";

                //請求区分で分岐.
                //請求区分が[タイム]、かつg業務区分が[ラジオ]
                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm) &&
                    _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_RD))
                {
                    //局誌CD
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = _dataRow.hb1Field2;
                    //本数.
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhonsu = "1";
                    }
                    else
                    {
                        strhonsu = _dataRow.hb1Field6;
                    }
                    //秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                    {
                        strbyosu = _dataRow.hb1Field5;
                    }
                    else
                    {
                        strbyosu = "0";
                    }

                    //総秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                    {
                        intsobyosu = (int.Parse(_dataRow.hb1Field5) * int.Parse(_dataRow.hb1Field6));
                    }
                    else
                    {
                        intsobyosu = 0;
                    }
                    strsobyosu = intsobyosu.ToString();
                    //放送回数(本数)
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhosokaisu_h = "1";
                    }
                    else
                    {
                        strhosokaisu_h = _dataRow.hb1Field6;
                    }

                    //期間.
                    if ((_dataRow.hb1Field8 != "") && (_dataRow.hb1Field8.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field8);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field8;
                    }
                    //放送回数.
                    if (KKHUtility.IsNumeric(strhosokaisu_h))
                    {
                        strhosokaisu = int.Parse(strhosokaisu_h).ToString();
                    }
                    else
                    {
                        strhosokaisu = "1";//コンボボックス.
                    }
                }
                else
                {
                    //局誌CD
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //本数.
                    strhonsu = "1";
                    //秒数.
                    strbyosu = "0";
                    //総秒数.
                    strsobyosu = "0";
                    //放送回数(本数)
                    strhosokaisu_h = "1";
                    //期間.
                    strkikan = " ";
                    //放送回数.
                    strhosokaisu = "1"; //コンボボックス.
                    txtHososu.Text = strhosokaisu;
                }

                //費目コードで分岐 .
                //電波.
                if (_dataRow.hb1HimkCd.Equals(KKHLionConst.gcstrHimoku_Denpa))
                {
                    jisidenpa = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    nebikidenpa = _dataRow.hb1NeviGak;
                }
                //回線.
                else if (_dataRow.hb1HimkCd.Equals(KKHLionConst.gcstrHimoku_Kaisen))
                {
                    netryo = _dataRow.hb1NeviGak;

                }
                //その他.
                else
                {
                    int1 = _dataRow.hb1NeviGak;
                }
                //休止回数.
                txtKyusisu.Text = strkyusikaisu;
                //放送回数.
                txtHososu.Text = strhosokaisu;

                //番組コード.
                if (!String.IsNullOrEmpty(cmbBangumi.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BANGCD].Value = cmbBangumi.Text.ToString().Substring(0, 3);
                }
                //合計とか.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                //dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT2].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                //本数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = int.Parse(strhonsu);
                //秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = int.Parse(strbyosu);
                //総秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = int.Parse(strsobyosu);
                //放送回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);
                //休止回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = int.Parse(strkyusikaisu);
            }
            //テレビタイム(ネット、ローカル）の場合.
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET) || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL))
            {
                GymForCardNo = pCardNO;//テレビ(ローカル)を設定.

                //FD列.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET))
                {
                    strFdretu = "01";
                }
                else
                {
                    strFdretu = "02";
                }

                //媒体区分セット.
                strbaitaikbn = KKHLionConst.BAITAIKBN_TV;
                //休止回数.
                strkyusikaisu = "0";

                //請求区分で分岐.
                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm)
                    && _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_TV))
                {
                    //局誌CD(仮)
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = _dataRow.hb1Field2;
                    //本数.
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhonsu = "1";
                    }
                    else
                    {
                        strhonsu = _dataRow.hb1Field6;
                    }
                    //秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                    {
                        strbyosu = _dataRow.hb1Field5;
                    }
                    else
                    {
                        strbyosu = "0";
                    }

                    //総秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                    {
                        intsobyosu = (int.Parse(_dataRow.hb1Field5) * int.Parse(_dataRow.hb1Field6));
                    }
                    else
                    {
                        intsobyosu = 0;
                    }
                    strsobyosu = intsobyosu.ToString();
                    //放送回数(本数)
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhosokaisu_h = "1";
                    }
                    else
                    {
                        strhosokaisu_h = _dataRow.hb1Field6;
                    }

                    //期間.
                    if ((_dataRow.hb1Field8 != "") && (_dataRow.hb1Field8.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field8);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field8;
                    }
                    //放送回数.
                    if (KKHUtility.IsNumeric(strhosokaisu_h))
                    {
                        strhosokaisu = int.Parse(strhosokaisu_h).ToString();
                    }
                    else
                    {
                        strhosokaisu = "1";//コンボボックス.
                    }
                }
                else
                {
                    //局誌CD
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //本数.
                    strhonsu = "1";
                    //秒数.
                    strbyosu = "0";
                    //総秒数.
                    strsobyosu = "0";
                    //放送回数(本数)
                    strhosokaisu_h = "1";
                    //期間.
                    strkikan = " ";
                    //放送回数.
                    strhosokaisu = "1";//コンボボックス.
                }

                //費目コードで分岐.
                //電波.
                if (_dataRow.hb1HimkCd.Equals(KKHLionConst.gcstrHimoku_Denpa))
                {
                    jisidenpa = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    nebikidenpa = _dataRow.hb1NeviGak;
                }
                //回線.
                else if (_dataRow.hb1HimkCd.Equals(KKHLionConst.gcstrHimoku_Kaisen))
                {
                    netryo = _dataRow.hb1NeviGak;
                }
                //その他.
                else
                {
                    int1 = _dataRow.hb1NeviGak;
                }

                //休止回数.
                txtKyusisu.Text = strkyusikaisu;
                //放送回数.
                txtHososu.Text = strhosokaisu;

                //番組コード.
                if (!String.IsNullOrEmpty(cmbBangumi.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BANGCD].Value = cmbBangumi.Text.ToString().Substring(0, 3);
                }
                //合計とか.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                //dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT2].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                //本数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = int.Parse(strhonsu);
                //秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = int.Parse(strbyosu);
                //総秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = int.Parse(strsobyosu);
                //放送回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);
                //休止回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = int.Parse(strkyusikaisu);
            }
            //BSCS
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS))
            {
                GymForCardNo = KKHLionConst.COLSTR_CARDNO_BSCS;//テレビ(ローカル)を設定.

                //FD列.
                strFdretu = "16";
                //媒体区分セット.
                strbaitaikbn = KKHLionConst.BAITAIKBN_BSCS;
                //休止回数.
                strkyusikaisu = "0";

                //請求区分で分岐.
                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm)
                    && _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_TV))
                {
                    //局誌CD
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = _dataRow.hb1Field2;
                    //本数.
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhonsu = "1";
                    }
                    else
                    {
                        strhonsu = _dataRow.hb1Field6;
                    }
                    //秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                    {
                        strbyosu = _dataRow.hb1Field5;
                    }
                    else
                    {
                        strbyosu = "0";
                    }

                    //総秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                    {
                        intsobyosu = (int.Parse(_dataRow.hb1Field5) * int.Parse(_dataRow.hb1Field6));
                    }
                    else
                    {
                        intsobyosu = 0;
                    }
                    strsobyosu = intsobyosu.ToString();
                    //放送回数(本数)
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhosokaisu_h = "1";
                    }
                    else
                    {
                        strhosokaisu_h = _dataRow.hb1Field6;
                    }

                    //期間.
                    if ((_dataRow.hb1Field8 != "") && (_dataRow.hb1Field8.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field8);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field8;
                    }
                    //放送回数.
                    if (KKHUtility.IsNumeric(strhosokaisu_h))
                    {
                        strhosokaisu = int.Parse(strhosokaisu_h).ToString();
                    }
                    else
                    {
                        strhosokaisu = "1";//コンボボックス.
                    }
                }
                else
                {
                    //局誌CD
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //本数.
                    strhonsu = "1";
                    //秒数.
                    strbyosu = "0";
                    //総秒数.
                    strsobyosu = "0";
                    //放送回数(本数)
                    strhosokaisu_h = "1";
                    //期間.
                    strkikan = " ";
                    //放送回数.
                    strhosokaisu = "1";//コンボボックスへ.
                }

                jisidenpa = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                nebikidenpa = _dataRow.hb1NeviGak;

                //休止回数.
                txtKyusisu.Text = strkyusikaisu;
                //放送回数.
                txtHososu.Text = strhosokaisu;

                //番組コード.
                if (!String.IsNullOrEmpty(cmbBangumi.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BANGCD].Value = cmbBangumi.Text.ToString().Substring(0, 3);
                }
                //合計とか.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                //dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT2].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                //本数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = int.Parse(strhonsu);
                //秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = int.Parse(strbyosu);
                //総秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = int.Parse(strsobyosu);
                //放送回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);
                //休止回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = int.Parse(strkyusikaisu);

            }
            //スポット(テレビ/ラジオ)
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SPOT))
            {
                //テレビスポット.
                if (pBaitaiNO.Equals(KKHLionConst.BAITAIKBN_TV_SPOT))
                {
                    GymForCardNo = pCardNO;//スポット(テレビ/ラジオ)
                    //媒体区分セット.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_TV_SPOT;
                    //FD列.
                    strFdretu = "03";

                    //請求区分で分岐.
                    //if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Sp))
                    if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Sp) && _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_SPOT))
                    {
                        //局誌CD
                        strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                        //局誌名称.
                        strkyokusinm = _dataRow.hb1Field2;
                        //本数.
                        if (_dataRow.hb1Field6 == "")
                        {
                            strhonsu = "1";
                        }
                        else
                        {
                            strhonsu = _dataRow.hb1Field6;
                        }
                        //秒数.
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                        {
                            strbyosu = _dataRow.hb1Field5;
                        }
                        else
                        {
                            strbyosu = "0";
                        }

                        //総秒数.
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                        {
                            intsobyosu = (int.Parse(_dataRow.hb1Field5) * int.Parse(_dataRow.hb1Field6));
                        }
                        else
                        {
                            intsobyosu = 0;
                        }
                        strsobyosu = intsobyosu.ToString();
                        //放送回数(本数)
                        if (_dataRow.hb1Field6 == "")
                        {
                            strhosokaisu_h = "1";
                        }
                        else
                        {
                            strhosokaisu_h = _dataRow.hb1Field6;
                        }

                        //期間.
                        if ((_dataRow.hb1Field4 != "") && (_dataRow.hb1Field4.Length == 16))
                        {
                            strkikan = keisaihenkan(_dataRow.hb1Field4);
                        }
                        else
                        {
                            strkikan = _dataRow.hb1Field4;
                        }
                        //秒数.
                        txtByosu.Text = int.Parse(strbyosu).ToString();

                        if (_dataRow.hb1Field4.Length > 7)
                        {
                            //FROM
                            txtCanpFrom.Text = _dataRow.hb1Field4.Substring(0, 8);
                        }
                        if (_dataRow.hb1Field4.Length > 15)
                        {
                            //TO
                            txtCanpTo.Text = _dataRow.hb1Field4.Substring(8, 8);
                        }
                    }
                    else
                    {
                        //局誌CD.
                        strkyokusicd = "";
                        //局誌名称.
                        strkyokusinm = " ";
                        //本数.
                        strhonsu = "1";
                        //秒数.
                        strbyosu = "0";
                        //総秒数.
                        strsobyosu = "0";
                        //放送回数(本数)
                        strhosokaisu_h = "1";
                        //期間.
                        strkikan = " ";
                        //秒数.
                        txtByosu.Text = "0";
                        //FROM
                        txtCanpFrom.Text = " ";
                        //TO
                        txtCanpTo.Text = " ";
                    }

                    //ブランドコード･名称.
                    if (!String.IsNullOrEmpty(cmbBrand.Text))
                    {
                        dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                    }
                    //合計とか.
                    //dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_INT2].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TIKUGO].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    //本数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = int.Parse(strhonsu);
                    //秒数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = int.Parse(strbyosu);
                    //総秒数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = int.Parse(strsobyosu);
                    //放送回数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);
                }
                //ラジオスポット.
                else
                {
                    GymForCardNo = pCardNO;//ラジオ(ローカル)を設定.

                    //FD列.
                    strFdretu = "03";
                    //媒体区分セット.
                    strbaitaikbn = KKHLionConst.BAITAIKBN_RD_SPOT;
                    //休止回数.
                    strkyusikaisu = "0";

                    //請求区分、業務区分がラジオの場合.
                    //if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Sp))
                    if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Sp)
                        && _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_RD))
                    {
                        //局誌CD
                        strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                        //局誌名称.
                        strkyokusinm = _dataRow.hb1Field2;
                        //本数.
                        if (_dataRow.hb1Field6 == "")
                        {
                            strhonsu = "1";
                        }
                        else
                        {
                            strhonsu = _dataRow.hb1Field6;
                        }
                        //秒数.
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                        {
                            strbyosu = _dataRow.hb1Field5;
                        }
                        else
                        {
                            strbyosu = "0";
                        }

                        //総秒数.
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                        {
                            intsobyosu = (int.Parse(_dataRow.hb1Field5) * int.Parse(_dataRow.hb1Field6));
                        }
                        else
                        {
                            intsobyosu = 0;
                        }
                        strsobyosu = intsobyosu.ToString();
                        //放送回数(本数)
                        if (_dataRow.hb1Field6 == "")
                        {
                            strhosokaisu_h = "1";
                        }
                        else
                        {
                            strhosokaisu_h = _dataRow.hb1Field6;
                        }

                        //期間.
                        if ((_dataRow.hb1Field4 != "") && (_dataRow.hb1Field4.Length == 16))
                        {
                            strkikan = keisaihenkan(_dataRow.hb1Field4);
                        }
                        else
                        {
                            strkikan = _dataRow.hb1Field4;
                        }
                        //秒数.
                        txtByosu.Text = int.Parse(strbyosu).ToString();
                        if (_dataRow.hb1Field4.Length > 7)
                        {
                            //FROM
                            txtCanpFrom.Text = _dataRow.hb1Field4.Substring(0, 8);
                        }
                        if (_dataRow.hb1Field4.Length > 15)
                        {
                            //TO
                            txtCanpTo.Text = _dataRow.hb1Field4.Substring(8, 8);
                        }
                    }
                    else
                    {
                        //局誌CD
                        strkyokusicd = "";
                        //局誌名称.
                        strkyokusinm = " ";
                        //本数.
                        strhonsu = "1";
                        //秒数.
                        strbyosu = "0";
                        //総秒数.
                        strsobyosu = "0";
                        //放送回数(本数)
                        strhosokaisu_h = "1";
                        //期間.
                        strkikan = " ";
                        //秒数.
                        txtByosu.Text = "0";
                        //FROM
                        txtCanpFrom.Text = "";
                        //TO
                        txtCanpTo.Text = "";
                    }

                    //ブランドコード･名称.
                    if (!String.IsNullOrEmpty(cmbBrand.Text))
                    {
                        dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                    }

                    //合計とか///////
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                    //本数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = int.Parse(strhonsu);
                    //秒数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = int.Parse(strbyosu);
                    //総秒数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = int.Parse(strsobyosu);
                    //放送回数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);
                    //休止回数.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = int.Parse(strkyusikaisu);
                }
            }
            //新聞.
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SINBN))
            {
                GymForCardNo = KKHLionConst.COLSTR_CARDNO_SINBN;//新聞.

                //FD列.
                strFdretu = "07";
                //媒体区分.
                strbaitaikbn = KKHLionConst.BAITAIKBN_NP;
                //請求区分で分岐.
                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Np))
                {
                    //局誌CD
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);

                    //局誌名称.
                    //okazaki
                    //strkyokusinm = loadMaster(KKHLionConst.C_MAST_SHINBUN_CD, strkyokusicd);
                    //if (string.IsNullOrEmpty(strkyokusinm.Trim()))
                    //{
                    //    strkyokusicd = "";
                    //}
                    if (strkyokusicd.Trim().Equals(String.Empty))
                    {
                        strkyokusinm = " ";
                    }
                    else
                    {
                        strkyokusinm = loadMaster(KKHLionConst.C_MAST_SHINBUN_CD, strkyokusicd);
                        if (string.IsNullOrEmpty(strkyokusinm.Trim()))
                        {
                            strkyokusicd = "";
                        }
                    }
                    //okazaki

                    //スペース.
                    strspace = _dataRow.hb1Field11;
                    //掲載日･号･等.
                    strkeisaietc = _dataRow.hb1Field3;

                    //期間.
                    if ((_dataRow.hb1Field12 != "") && (_dataRow.hb1Field12.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field12);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field12;
                    }
                }
                else
                {
                    //局誌CD.
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //スペース.
                    strspace = " ";
                    //掲載日･号･等.
                    strkeisaietc = " ";
                    //期間.
                    strkikan = " ";
                }

                //ブランドコード･名称.
                if (!String.IsNullOrEmpty(cmbBrand.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                }

                //合計とか.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
            }
            //雑誌.
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_ZASSI))
            {
                GymForCardNo = KKHLionConst.COLSTR_CARDNO_ZASSI;//雑誌.

                //FD列.
                strFdretu = "08";
                //媒体区分.
                strbaitaikbn = KKHLionConst.BAITAIKBN_MZ;

                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Mz))
                {
                    //局誌CD.
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = _dataRow.hb1Field2;
                    //スペース.
                    strspace = _dataRow.hb1Field9;
                    //掲載日･号･等.
                    strkeisaietc = _dataRow.hb1Field4;

                    ////期間.
                    if ((_dataRow.hb1Field10 != "") && (_dataRow.hb1Field10.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field10);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field10;
                    }
                }
                else
                {
                    //局誌CD.
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //スペース.
                    strspace = " ";
                    //掲載日･号･等.
                    strkeisaietc = " ";
                    //期間.
                    strkikan = " ";
                }

                //ブランドコード･名称.
                if (!String.IsNullOrEmpty(cmbBrand.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                }

                //合計とか///////
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
            }
            //交通.
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_KOTU))
            {
                GymForCardNo = KKHLionConst.COLSTR_CARDNO_KOTU;//交通.

                //FD列.
                strFdretu = "09";

                //媒体区分.
                strbaitaikbn = KKHLionConst.BAITAIKBN_OOH;

                if (_dataRow.hb1GyomKbn.ToString().Equals(KKHLionConst.COLSTR_GYOM_KOTU))
                {
                    //期間.
                    if ((_dataRow.hb1Field5 != "") && (_dataRow.hb1Field5.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field5);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field5;
                    }
                }
                else
                {
                    strkikan = "";
                }

                //ブランドコード･名称.
                if (!String.IsNullOrEmpty(cmbBrand.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                }

                //合計とか///////
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
            }
            //制作.
            else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU))
            {
                GymForCardNo = KKHLionConst.COLSTR_CARDNO_SEISAKU;//制作.

                //FD列.
                strFdretu = "20";

                //媒体区分.
                strbaitaikbn = pBaitaiNO;
                strkyokusinm = pBitaiName;//_dataRow.hb1Field2;

                //実施料.
                //int1 = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;

                //ブランドコード･名称.
                if (!String.IsNullOrEmpty(cmbBrand.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                }

                //合計とか///////
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;


            }
            //他すべて.
            else
            {
                //カードNOセット.
                GymForCardNo = pCardNO;

                //FD列.
                switch (pCardNO)
                {
                    case KKHLionConst.COLSTR_CARDNO_SONOTA:     //その他.
                        strFdretu = "10";
                        break;
                    case KKHLionConst.COLSTR_CARDNO_CHIRASI:    //チラシ.
                        strFdretu = "14";
                        break;
                    case KKHLionConst.COLSTR_CARDNO_SAMPLING:   //サンプリング.
                        strFdretu = "15";
                        break;
                    case KKHLionConst.COLSTR_CARDNO_INTERNET:   //インターネット.
                        strFdretu = "17";
                        break;
                    case KKHLionConst.COLSTR_CARDNO_MOBIL:      //モバイル.
                        strFdretu = "18";
                        break;
                    case KKHLionConst.COLSTR_CARDNO_JIGYOHI:    //事業費.
                        strFdretu = "19";
                        break;
                    default:
                        strFdretu = "99";
                        break;
                }

                //媒体区分.
                strbaitaikbn = pBaitaiNO;
                strkyokusinm = pBitaiName;

                //局誌名称.
                strkyokusinm = _dataRow.hb1Field2;

                //実施料.
                int1 = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;

                //カードNoで変更.
                //インターネット、モバイルの場合.
                if (pCardNO == KKHLionConst.COLSTR_CARDNO_INTERNET
                    || pCardNO == KKHLionConst.COLSTR_CARDNO_MOBIL)
                {
                    //局誌CD
                    strkyokusicd = "";
                    //strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = "";
                    //strkyokusinm = _dataRow.hb1Field2;
                }


                //合計とか///////
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = (_dataRow.hb1SeiGak + _dataRow.hb1NeviGak) - _dataRow.hb1NeviGak;
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;

            }

            //明細(業務区分で分岐しない共通のもの)
            //データ日付.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_YYMM].Value = _dataRow.hb1Yymm;
            //代理店CD
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value = "1001";//固定.
            //費目CD
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;
            //ブランド名称(コンボブランドが表示状態のみ)
            if (cmbBrand.Visible == true)
            {
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = cmbBrand.Items[0];
            }
            //値引率.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKRITU].Value = _dataRow.hb1NeviRitu;
            //件名.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KENMEI].Value = _dataRow.hb1KKNameKJ;
            //消費税率.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAXRITU].Value = _dataRow.hb1SzeiRitu;
            //消費税額.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAX].Value = Math.Truncate(_dataRow.hb1SeiGak * ( _dataRow.hb1SzeiRitu * 0.01M ));
            //売上明細Ｎｏ.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_URIMEI].Value = _dataRow.hb1JyutNo + "-" + _dataRow.hb1JyMeiNo + "-" + _dataRow.hb1UrMeiNo;
            //費目CD
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;


            //業務区分によって変更.
            //FD用列.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = strFdretu;
            //局誌CD
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = strkyokusicd;
            //局誌名称.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_STR1].Value = strkyokusinm;
            //スペース.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SPACE].Value = strspace;
            //掲載日･号･等.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KEISAI].Value = strkeisaietc;
            //期間.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KIKAN].Value = strkikan;
            //媒体区分.
            dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BAITAI].Value = strbaitaikbn;

            //１行目以外の場合は初期値の一部を空白or0にする.
            if (lRows != 0)
            {
                //可変１.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = 0M;
                //実施電波.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = 0M;
                //値引電波.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = 0M;
                //ネット料.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NETRYO].Value = 0M;
                //可変２.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT2].Value = 0M;
                //消費税.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAX].Value = 0M;
                //局誌CD
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = "";
                //局誌名称.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_STR1].Value = "";
            }

            //カードNo変更時のみの設定.
            if (dgvMain_Sheet1.RowCount == 1)
            {
                //カードNo変更処理.
                foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                {
                    //カードNoはボタンに変更.
                    col.CellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    FarPoint.Win.Spread.CellType.ButtonCellType cellType
                        = (FarPoint.Win.Spread.CellType.ButtonCellType)col.CellType;
                    cellType.Text = GymForCardNo;
                    break;
                }

                //表示パターン取得.
                _pKmkType = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_CDPATARN, pCardNO, "");

                //項目設定(上記で取得したパターンで設定する)
                utl.kmkset(_pKmkType, pBaitaiNO, dgvMain_Sheet1);

                //ヘッダー項目設定.
                ControlChange(_pKmkType, pBaitaiNO);

                //テレビ番組マスタ.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS)
                    )
                {
                    SetCmbTvB();

                    //前回の番組をコンボボックスにセット.
                    cmbBangumi.SelectedValue = pBangumiCd;
                }
                else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                    )
                {
                    SetCmbRdB();

                    //前回の番組をコンボボックスにセット.
                    cmbBangumi.SelectedValue = pBangumiCd;
                }
                else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SPOT))
                {
                    SetCmdSeitiku();
                }
            }

            //okazaki
            //ブランド列を非表示にする.
            if (!(_pKmkType.Equals(KKHLionConst.COLSTR_KMKTYPE_6) ||
                _pKmkType.Equals(KKHLionConst.COLSTR_KMKTYPE_8)))
            {
                FarPoint.Win.Spread.Column col = dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_BRANDCD];
                col.Visible = false;
            }
            dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_CARDNO].Visible = true;
            //okazaki

            //計算処理.
            CalcTotalCost();
        }

        /// <summary>
        /// スプレッドのボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //消費税入力フラグをオフ.
            bConFlg = false;

            //番組コンボボックスが表示されている場合は番組コードを保持.
            if (cmbBangumi.Visible == true && !String.IsNullOrEmpty(cmbBangumi.Text))
            {
                pBangumiCd = cmbBangumi.Text.ToString().Substring(0, 3);
            }

            if (e.Column == KKHLionConst.COLIDX_MLIST_CARDNO)
            {
                //明細入力画面表示.
                //パラメータセット.
                FindLionCardNoItrNaviParameter naviParam = new FindLionCardNoItrNaviParameter();
                naviParam.strEsqId = _naviParam.strEsqId;
                naviParam.strEgcd = _naviParam.strEgcd;
                naviParam.strTksKgyCd = _naviParam.strTksKgyCd;
                naviParam.strTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                naviParam.strTksTntSeqNo = _naviParam.strTksTntSeqNo;

                //ダイアログでカードNO一覧画面を呼び出し.
                object result = Navigator.ShowModalForm(this, "toFindLionCardNoItr", naviParam);
                if (result == null)
                {
                    //データが存在しなかったら処理を抜ける.
                    return;
                }
                //戻り値に値が入っていたら処理を行う.
                if (naviParam.CdNoItrCd.Equals(""))
                { }
                else
                {
                    //スプレッド初期化.
                    dgvMain_Sheet1.RowCount = 0;
                    dgvMain_Sheet1.RowCount = 1;

                    //splitで戻り値を分ける.
                    string str = naviParam.CdNoItrCd;

                    //カンマ区切りで分割して配列に格納する.
                    string[] ary = str.Split(',');

                    //カードＮＯセット.
                    pCardNO = ary[0];
                    //媒体区分セット.
                    pBaitaiNO = ary[2];
                    //媒体名称セット.
                    pBitaiName = ary[3];

                    //●明細データのあり、なしで分岐(明細登録画面からのパラメータで変化)
                    if (_spdKkhDetail_Sheet1.RowCount == 0)
                    {
                        //カードNOによるデータセット処理(1行)
                        SetDownload_CardNo(0);
                    }
                    else
                    {
                        //設定したカードNOが存在する明細データのカードNOと同一だったら(スポット、制作の場合は媒体区分も比較)
                        if (pCardNO.Equals(pMeiCardNo) &&
                            !(pMeiCardNo.Equals(KKHLionConst.COLSTR_CARDNO_SPOT) && !pBaitaiNO.Equals(pMeiBaitaiNo)) &&
                            !(pMeiCardNo.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU) && !pBaitaiNO.Equals(pMeiBaitaiNo)))
                        {
                            //各コントロールの初期化.
                            InitializeControl();
                            //各コントロールの編集.
                            editControl();
                        }
                        //上記以外の場合.
                        else
                        {
                            //カードNOによるデータセット処理(1行)
                            SetDownload_CardNo(0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ブランドコンボボックスSelectedIndexChangedイベント,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //ブランドコード･名称をスプレッドに反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
            }
        }

        /// <summary>
        /// 明細金額、消費税の合計計算.
        /// </summary>
        private void CalcTotalCost()
        {
            decimal seiKyuG = 0M;           //請求額合計.
            decimal denpaRyoG = 0M;         //電波料合計.
            decimal netRyoG = 0M;           //ネット料合計.
            decimal tax = 0M;               //消費税.
            decimal tax1 = 0M;              //消費税(制作・媒体１).
            decimal tax2 = 0M;              //消費税(制作・媒体２).
            string baitai = string.Empty;   //媒体区分.

            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //請求額合計.
                seiKyuG += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text);

                //電波料合計.
                denpaRyoG += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);

                //ネット料合計.
                netRyoG += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NETRYO].Text);

                //消費税.
                tax = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_TAX].Text);

                //媒体区分取得.
                baitai = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_BAITAI].Value);

                //媒体区分により分岐.
                if (!baitai.Trim().Equals("31") && !baitai.Trim().Equals("51"))
                {
                    //消費税(制作・媒体１)
                    tax1 += tax;
                }
                else
                {
                    //消費税(制作・媒体２)
                    tax2 += tax;
                }

                //地区別の合計を計算し値をセットする.
                CalcTikuBetsu(row.Index, baitai);


            }

            //請求額合計.
            txtSeiKyuG.Text = seiKyuG.ToString("###,###,###,##0");
            //電波料合計.
            txtDenpaRyoG.Text = denpaRyoG.ToString("###,###,###,##0");
            //ネット料合計.
            txtNetRyoG.Text = netRyoG.ToString("###,###,###,##0");
            //消費税(制作・媒体１)
            txtTax1.Text = tax1.ToString("###,###,###,##0");
            //消費税(制作・媒体２)
            txtTax2.Text = tax2.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 地区別計算.
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="baitai">媒体区分</param>
        /// <returns>計算結果</returns>
        private void CalcTikuBetsu(int rowIndex, string baitai)
        {
            decimal ret = 0M;                   //地区合計.
            string tikuCd = string.Empty;       //地区コード.
            string tikuCdComp = string.Empty;   //地区コード(比較用)
            bool rowFlg = false;                //フラグ.
            int ttlRowIdx = 0;                  //地区別合計の設定行.
            decimal seiKyuG = 0M;               //請求額合計.

            //地区合計の再計算(ＴＶスポットのみ)
            if (KKHLionConst.BAITAIKBN_TV_SPOT.Equals(baitai))
            {
                if (dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_TIKUCD].Value == null)
                {
                    //地区コードがブランクの場合はその行だけで合計する.
                    dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_TIKUGO].Value = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text);
                    return;
                }

                //地区コード取得.
                tikuCd = KKHUtility.ToString(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_TIKUCD].Value);

                foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                {
                    //地区コード(比較用)取得.
                    tikuCdComp = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_TIKUCD].Value);

                    if (tikuCd.Equals(tikuCdComp))
                    {
                        //該当の先頭行を格納.
                        if (rowFlg == false)
                        {
                            rowFlg = true;
                            ttlRowIdx = row.Index;
                        }

                        //請求金額取得.
                        seiKyuG = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text);
                        ret += seiKyuG;
                    }
                }
                dgvMain_Sheet1.Cells[ttlRowIdx, KKHLionConst.COLIDX_MLIST_TIKUGO].Value = ret;
            }
        }

        private void CalcNebikiGaku(int rowIndex)
        {
            decimal kingaku = 0M;
            decimal nebikiRitu = 0M;
            decimal nebikiGaku = 0M;

            switch (pCardNO)
            {
                case KKHLionConst.COLSTR_CARDNO_ZASSI:      //雑誌.
                    kingaku = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT1].Text);
                    nebikiRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKRITU].Text);
                    break;
                case KKHLionConst.COLSTR_CARDNO_TVNET:      //テレビタイム.
                case KKHLionConst.COLSTR_CARDNO_TVLCL:      //テレビローカル.
                case KKHLionConst.COLSTR_CARDNO_RDNET:      //ラジオタイム.
                case KKHLionConst.COLSTR_CARDNO_RDLCL:      //ラジオローカル.
                case KKHLionConst.COLSTR_CARDNO_BSCS:       //BS/CS
                    kingaku = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                    nebikiRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKRITU].Text);
                    break;
                case KKHLionConst.COLSTR_CARDNO_SPOT:       //スポット.
                    kingaku = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                    nebikiRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKRITU].Text);
                    break;
                default:
                    return;
                //break;
            }

            nebikiGaku = Math.Truncate(kingaku * (nebikiRitu * 0.01M));
            dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = nebikiGaku;
        }

        /// <summary>
        /// 請求金額計算・設定.
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        private void CalcClaimCost(int rowIndex)
        {
            //存在しない行が指定されている場合は何もしない.
            if (dgvMain_Sheet1.RowCount <= rowIndex)
            {
                return;
            }

            decimal nDenpaRyo = 0M;     //値引電波料.
            decimal netRyo = 0M;        //ネット料.
            decimal seisakuhi = 0M;     //制作費.
            decimal denpaRyo = 0M;      //電波料.
            decimal jishiRyo = 0M;      //実施料.
            decimal tSeisakuhi = 0M;    //タイアップ制作費.
            decimal seiGak = 0M;        //請求金額.

            //カードNOにより処理を分岐.
            //switch (KKHUtility.ToString(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_CARDNO].Value))
            switch (pCardNO)
            {
                case KKHLionConst.COLSTR_CARDNO_SINBN:      //新聞.


                    //実施料の取得.
                    jishiRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT1].Text);
                    //値引額の取得.
                    nDenpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
                    //請求金額の計算.
                    seiGak = jishiRyo - nDenpaRyo;
                    break;

                case KKHLionConst.COLSTR_CARDNO_ZASSI:      //雑誌.
                    //実施料の取得.
                    jishiRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT1].Text);
                    //タイアップ制作費.
                    tSeisakuhi = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT2].Text);
                    //値引額の取得.
                    nDenpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
                    //請求金額の計算.
                    seiGak = jishiRyo - nDenpaRyo + tSeisakuhi;
                    break;

                case KKHLionConst.COLSTR_CARDNO_TVNET:      //テレビタイム.
                case KKHLionConst.COLSTR_CARDNO_TVLCL:      //テレビローカル.
                case KKHLionConst.COLSTR_CARDNO_RDNET:      //ラジオタイム.
                case KKHLionConst.COLSTR_CARDNO_RDLCL:      //ラジオローカル.
                case KKHLionConst.COLSTR_CARDNO_BSCS:       //BS/CS
                    //電波料の取得.
                    denpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                    //値引電波料の取得.
                    nDenpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
                    //ネット料の取得.
                    netRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NETRYO].Text);
                    //制作費の取得.
                    seisakuhi = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT2].Text);
                    //請求金額の計算.
                    seiGak = denpaRyo - nDenpaRyo + netRyo + seisakuhi;
                    break;

                case KKHLionConst.COLSTR_CARDNO_SPOT:       //スポット.
                    //電波料の取得.
                    denpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                    //値引電波料の取得.
                    nDenpaRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
                    //請求金額の計算.
                    seiGak = denpaRyo - nDenpaRyo;
                    break;

                case KKHLionConst.COLSTR_CARDNO_KOTU:       //交通.
                case KKHLionConst.COLSTR_CARDNO_SEISAKU:    //制作費.
                default:
                    //実施料の取得.
                    jishiRyo = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_INT1].Text);
                    //請求金額の計算.
                    seiGak = jishiRyo;
                    break;
            }

            //請求金額のセット.
            dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = seiGak;
        }

        /// <summary>
        /// 消費税計算・設定.
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        private void CalcTaxCost(int rowIndex)
        {
            //存在しない行が指定されている場合は何もしない.
            if (dgvMain_Sheet1.RowCount <= rowIndex)
            {
                return;
            }

            decimal nbkGokngk = 0M;     //請求額.
            decimal taxritu = 0M;       //消費税額.

            //請求額・税率の取得.
            nbkGokngk = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text);
            taxritu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_TAXRITU].Text);

            //消費税額のセット.
            dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_TAX].Value = Math.Floor(nbkGokngk * (taxritu * 0.01M));
        }

        /// <summary>
        /// 総秒数の計算・設定.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CalcSoByosu(int rowIndex)
        {
            //存在しない行が指定されている場合は何もしない.
            if (dgvMain_Sheet1.RowCount <= rowIndex)
            {
                return;
            }

            int byosu = 0;      //秒数.
            int honsu = 0;      //本数.
            int soByosu = 0;    //総秒数.

            //秒数、本数の取得.
            if (string.IsNullOrEmpty(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_BYOSU].Text))
            {
                byosu = 0;
            }
            else
            {
                byosu = int.Parse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_BYOSU].Text);
            }

            if (string.IsNullOrEmpty(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_HONSU].Text))
            {
                honsu = 1;
            }
            else
            {
                honsu = int.Parse(dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_HONSU].Text);
            }

            //総秒数の計算.
            soByosu = byosu * honsu;

            //総秒数のセット.
            dgvMain_Sheet1.Cells[rowIndex, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = soByosu;
        }

        /// <summary>
        /// Null、空白の場合、0をセットする.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        private void SetZero(int rowIndex, int colIndex)
        {
            if (String.IsNullOrEmpty(dgvMain_Sheet1.Cells[rowIndex, colIndex].Text))
            {
                dgvMain_Sheet1.Cells[rowIndex, colIndex].Text = "0";
            }
        }

        /// <summary>
        /// 端数調整.
        /// </summary>
        private void EditFraction()
        {
            decimal denpaRyo = 0M;      //電波料.
            decimal nDenpaRyo = 0M;     //値引電波料.
            decimal neviRitu = 0M;      //値引率.

            //値引額の算出.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //電波料.
                denpaRyo += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                //値引電波料.
                nDenpaRyo += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
            }
            //値引率の取得.
            neviRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_NBKRITU].Text);
            //電波料の合計から値引額を算出.
            denpaRyo = Math.Floor(denpaRyo * (neviRitu * 0.01M));

            //値引金額の差額算出.
            if (denpaRyo != nDenpaRyo && denpaRyo != 0)
            {
                //現在の値引額の取得.
                decimal buff = KKHUtility.DecParse(dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Text);
                //端数分を追加.
                dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = buff + denpaRyo - nDenpaRyo;
                //請求金額の再計算.
                this.CalcClaimCost(0);
                //消費税の再計算.
                this.CalcTaxCost(0);
            }

            decimal seiGak = 0M;        //請求金額.
            decimal tax = 0M;           //消費税.
            decimal taxRitu = 0M;       //消費税率.

            //消費税の算出.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //請求金額.
                seiGak += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text);
                //消費税額.
                tax += KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_TAX].Text);
            }
            //消費税率の取得.
            taxRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_TAXRITU].Text);
            //請求金額の合計から消費税を算出.
            seiGak = Math.Floor(seiGak * (taxRitu * 0.01M));

            //消費税額の差額算出.
            if (seiGak != tax && seiGak != 0 && bConFlg == false)
            {
                //現在の消費税額を取得.
                decimal buff = KKHUtility.DecParse(dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_TAX].Text);
                //端数分を追加.
                decimal taxh = Math.Floor(buff + seiGak - tax);
                dgvMain_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_TAX].Value = taxh;

                if (txtTax1.Visible == true)
                {
                    //制作･媒体消費税(1)
                    txtTax1.Text = taxh.ToString("###,###,###,##0");
                }
            }

        }

        /// <summary>
        /// ブランドコンボボックス設定.
        /// </summary>
        private void SetCmbBrand()
        {
            Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance.MasterDataVORow[] rows;
            List<LionComboBoxItem> items;

            result = process.FindMasterByCond(_naviParam.strEsqId,
                                              _naviParam.strEgcd,
                                              _naviParam.strTksKgyCd,
                                              _naviParam.strTksBmnSeqNo,
                                              _naviParam.strTksTntSeqNo,
                                              KKHLionConst.C_MAST_BRAND_CD,
                                              null);

            rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select();
            items = new List<LionComboBoxItem>();
            items.Add(new LionComboBoxItem(string.Empty, string.Empty));

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                items.Add(new LionComboBoxItem(row.Column1, row.Column1 + " " + row.Column2));
            }



            //cmbBrand.Items.Clear();
            cmbBrand.DisplayMember = "NAME";
            cmbBrand.ValueMember = "CODE";
            cmbBrand.DataSource = items;
        }

        /// <summary>
        /// テレビ番組コンボボックス設定.
        /// </summary>
        private void SetCmbTvB()
        {
            //コンボボックスに設定MasterMaintenance.MasterDataVORow
            MastLion.TvBnLionRow[] rows;
            List<LionComboBoxItem> items;
            rows = (MastLion.TvBnLionRow[])prTvBmast.mastLionDataSet.TvBnLion.Select();
            items = new List<LionComboBoxItem>();
            items.Add(new LionComboBoxItem(string.Empty, string.Empty));

            foreach (Isid.KKH.Lion.Schema.MastLion.TvBnLionRow row in rows)
            {
                items.Add(new LionComboBoxItem(row.BANCD, row.BANCD + " " + row.BANNAME));
            }

            //cmbBangumi.Items.Clear();
            cmbBangumi.DisplayMember = "NAME";
            cmbBangumi.ValueMember = "CODE";
            //cmbBangumi.Items = items;

            cmbBangumi.DataSource = items;
        }

        /// <summary>
        /// ラジオ番組コンボボックス設定.
        /// </summary>
        private void SetCmbRdB()
        {
            //コンボボックスに設定MasterMaintenance.MasterDataVORow
            MastLion.RdBnLionRow[] rows;
            List<LionComboBoxItem> items;
            rows = (MastLion.RdBnLionRow[])prRdBmast.mastLionDataSet.RdBnLion.Select();
            items = new List<LionComboBoxItem>();
            items.Add(new LionComboBoxItem(string.Empty, string.Empty));

            foreach (Isid.KKH.Lion.Schema.MastLion.RdBnLionRow row in rows)
            {
                items.Add(new LionComboBoxItem(row.BANCD, row.BANCD + " " + row.BANNAME));
            }

            //cmbBangumi.Items.Clear();
            cmbBangumi.DisplayMember = "NAME";
            cmbBangumi.ValueMember = "CODE";

            cmbBangumi.DataSource = items;
        }

        /// <summary>
        /// 制地区コンボボックス設定.
        /// </summary>
        private void SetCmdSeitiku()
        {
            Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process
                = Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;

            result = process.FindMasterByCond(_naviParam.strEsqId,
                                               _naviParam.strEgcd,
                                               _naviParam.strTksKgyCd,
                                               _naviParam.strTksBmnSeqNo,
                                               _naviParam.strTksTntSeqNo,
                                               KKHLionConst.C_MAST_SEITIKU_CD,
                                               null);

            if (result.HasError)
            {
                return;
            }

            //地区マスタデータセット.
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)result.MasterDataSet.MasterDataVO.Copy();


            //取得したデータにフィルタを設定(媒体区分).
            dt.DefaultView.RowFilter = dt.Column1Column.ColumnName + " = '" + pBaitaiNO + "'";
            //コードと名称で一意になるようにしてコンボボックスのデータソース用のDataTableを作成する.
            DataTable dsCmb = dt.DefaultView.ToTable(dt.TableName
                                                        , true
                                                        , dt.Column3Column.ColumnName
                                                        , dt.Column2Column.ColumnName);
            dsCmb.Rows.Add("", "");

            //コード順でソートを行う.
            DataTable dsCmbbox = new DataTable();

            dsCmbbox = dsCmb.Clone();
            DataView dv = new DataView(dsCmb);
            dv.Sort = dt.Column2Column.ColumnName;

            foreach (DataRowView drv in dv)
            {
                dsCmbbox.ImportRow(drv.Row);
            }

            cmbSeitiku.DataSource = dsCmbbox;
            cmbSeitiku.DisplayMember = dsCmbbox.Columns[0].ColumnName;
            cmbSeitiku.ValueMember = dsCmbbox.Columns[1].ColumnName;

            cmbSeitiku.SelectedIndex = -1;
        }


        /// <summary>
        /// 必須チェック.
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckRequired()
        {

            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //局誌CD入力チェック.
                string kyokusiCd = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value);
                //局誌CDが未入力で、.
                //カードNoが「009:交通」「010:その他」「012:制作費」「014:チラシ」.
                //「015:サンプリング」「017:インターネット」「018:モバイル」「019:事業費」以外の場合.
                if (string.IsNullOrEmpty(kyokusiCd.Trim()) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_KOTU) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SONOTA) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_CHIRASI) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SAMPLING) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_INTERNET) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_MOBIL) &&
                    !pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0122
                                                , new string[] { "局誌コード", "入力" }
                                                , "明細登録"
                                                , MessageBoxButtons.OK);
                    this.ActiveControl = null;
                    return false;
                }

                //府県CD入力チェック.
                string fukenCd = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_FUKENCD].Value);
                //府県CDが未入力で、カードNoが「009:交通」の場合.
                if (string.IsNullOrEmpty(fukenCd.Trim()) &&
                    pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_KOTU))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0122
                                                , new string[] { "府県コード", "入力" }
                                                , "明細登録"
                                                , MessageBoxButtons.OK);
                    return false;
                }

                //媒体区分選択チェック.
                string baitai = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_BAITAI].Value);
                //媒体区分が未選択の場合.
                if (string.IsNullOrEmpty(baitai.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0122
                                                , new string[] { "媒体区分", "指定" }
                                                , "明細登録"
                                                , MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 任意チェック.
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckAny()
        {
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //局誌CD入力チェック (確認メッセージ表示)
                //カードNoが「017:インターネット」「018:モバイル」の場合.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_INTERNET)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    string kyokusiCd = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value);

                    if (string.IsNullOrEmpty(kyokusiCd))
                    {
                        DialogResult dr = MessageUtility.ShowMessageBox(MessageCode.HB_C0014
                                                                      , new string[] { "局誌コード" }
                                                                      , "明細登録"
                                                                      , MessageBoxButtons.YesNo);
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

                //総秒数入力チェック (確認メッセージ表示)
                //カードNoが「005:スポット」の場合.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_SPOT))
                //if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_INTERNET))
                {
                    string sobyosu =
                        KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value);

                    //Null、空白、0の場合、ワーニング.
                    if (string.IsNullOrEmpty(sobyosu.Trim()) || sobyosu.Trim().Equals("0"))
                    //if (string.IsNullOrEmpty(sobyosu.Trim()))
                    {
                        DialogResult dr = MessageUtility.ShowMessageBox(MessageCode.HB_C0014
                                                                      , new string[] { "総秒数" }
                                                                      , "明細登録"
                                                                      , MessageBoxButtons.YesNo);
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

                //キャンペーン期間チェック.

            }

            //端数調整.
            this.EditFraction();

            //消費税額入力チェック (確認メッセージ表示)
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //消費税率.
                decimal taxRitu = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_TAXRITU].Text);
                //実施料.
                decimal int1 = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_INT1].Text);
                //電波料.
                decimal jisDenpa = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text);
                //消費税.
                decimal tax = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_TAX].Text);

                if (tax == 0 && (int1 + jisDenpa) != 0)
                {
                    DialogResult dr = MessageUtility.ShowMessageBox(MessageCode.HB_C0014
                                                                  , new string[] { "消費税額" }
                                                                  , "明細登録"
                                                                  , MessageBoxButtons.YesNo);
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

            return true;
        }

        /// <summary>
        /// マスターコードチェック.
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckMastCd()
        {
            Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process =
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result = null;                                     //マスタ情報.
            MasterMaintenance.MasterDataVODataTable vo = null;                                          //マスタ情報.
            FindCommonByCondServiceResult dtMastAddress = null;                                         //アドレス系システムマスタ.
            FindCommonByCondServiceResult dtMastFile = null;                                            //ファイル系システムマスタ.
            Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult tvkResult = null;   //テレビ局マスタ情報.
            Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult rdkResult = null;   //ラジオ局マスタ情報.
            Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable tvKLion = null;                              //テレビ局マスタ情報.
            Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable rdKLion = null;                              //ラジオ局マスタ情報.
            string msg = string.Empty;                                                                  //メッセージ保持用.
            string value = string.Empty;                                                                //コード保持用.
            string filter = string.Empty;                                                               //検索フィルタ 索フィルタ.

            //カードNOにより処理を分岐.
            switch (pCardNO)
            {
                case KKHLionConst.COLSTR_CARDNO_SINBN:      //「007:新聞」.
                    //新聞マスタ取得.
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                      _naviParam.strEgcd,
                                                      _naviParam.strTksKgyCd,
                                                      _naviParam.strTksBmnSeqNo,
                                                      _naviParam.strTksTntSeqNo,
                                                      KKHLionConst.C_MAST_SHINBUN_CD,
                                                      null);

                    vo = result.MasterDataSet.MasterDataVO;

                    //新聞変換マスタ取得.
                    dtShinHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                  _naviParam.strEgcd,
                                                  _naviParam.strTksKgyCd,
                                                  _naviParam.strTksBmnSeqNo,
                                                  _naviParam.strTksTntSeqNo,
                                                  KKHLionConst.C_MAST_SHINBUN_HEN_CD,
                                                  false);
                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        //局誌CD
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                        filter = vo.Column1Column.Caption + " = \'" + value + "\'";
                        if (vo.Select(filter).Length == 0)
                        {
                            msg = "新聞マスタ";
                            break;
                        }
                        //新聞変換マスタ.
                        filter = dtShinHenMast.Column3Column.Caption + " = \'" + value + "\'";
                        if (dtShinHenMast.Select(filter).Length == 0)
                        {
                            msg = "新聞変換マスタ";
                            break;
                        }
                    }

                    break;

                case KKHLionConst.COLSTR_CARDNO_ZASSI:      //「008:雑誌」.
                    //雑誌マスタ取得.
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                      _naviParam.strEgcd,
                                                      _naviParam.strTksKgyCd,
                                                      _naviParam.strTksBmnSeqNo,
                                                      _naviParam.strTksTntSeqNo,
                                                      KKHLionConst.C_MAST_ZASSI_CD,
                                                      null);

                    vo = result.MasterDataSet.MasterDataVO;

                    //雑誌変換マスタ取得.
                    dtZashiHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                  _naviParam.strEgcd,
                                                  _naviParam.strTksKgyCd,
                                                  _naviParam.strTksBmnSeqNo,
                                                  _naviParam.strTksTntSeqNo,
                                                  KKHLionConst.C_MAST_ZASHI_HEN_CD,
                                                  false);

                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        //局誌CD
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                        filter = vo.Column1Column.Caption + " = \'" + value + "\'";
                        if (vo.Select(filter).Length == 0)
                        {
                            msg = "雑誌マスタ";
                            break;
                        }
                        //雑誌変換マスタ.
                        filter = dtZashiHenMast.Column2Column.Caption + " = \'" + value + "\'";
                        if (dtZashiHenMast.Select(filter).Length == 0)
                        {
                            msg = "雑誌変換マスタ";
                            break;
                        }
                    }

                    break;

                case KKHLionConst.COLSTR_CARDNO_TVNET:      //「001:テレビタイム」.
                case KKHLionConst.COLSTR_CARDNO_TVLCL:      //「002:テレビローカル」.
                case KKHLionConst.COLSTR_CARDNO_BSCS:       //「016:BS/CS」.

                    dtMastAddress = this.GetSysMastInfoAddress();   //アドレス系システムマスタ.
                    dtMastFile = this.GetSysMastInfoFile();         //ファイル系システムマスタ.
                    //テレビ局マスタ情報取得.
                    tvkResult = this.GetTvKMastResult(dtMastAddress.CommonDataSet.SystemCommon[0].field4.ToString()
                                                    , dtMastAddress.CommonDataSet.SystemCommon[0].field10.ToString()
                                                    , dtMastAddress.CommonDataSet.SystemCommon[0].field2.ToString()
                                                    , dtMastFile.CommonDataSet.SystemCommon[0].field4.ToString());

                    tvKLion = tvkResult.mastLionDataSet.TvKLion;

                    //テレビ局変換マスタ取得.
                    dtTvHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                  _naviParam.strEgcd,
                                                  _naviParam.strTksKgyCd,
                                                  _naviParam.strTksBmnSeqNo,
                                                  _naviParam.strTksTntSeqNo,
                                                  KKHLionConst.C_MAST_TV_HEN_CD,
                                                  false);

                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        //局誌CD
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                        filter = tvKLion.KYOKUCDColumn.Caption + " = \'" + value + "\'";
                        if (tvKLion.Select(filter).Length == 0)
                        {
                            msg = "テレビ局マスタ";
                            break;
                        }
                        //テレビ局変換マスタ.
                        filter = dtTvHenMast.Column2Column.Caption + " = \'" + value + "\'";
                        if (dtTvHenMast.Select(filter).Length == 0)
                        {
                            msg = "テレビ局変換マスタ";
                            break;
                        }
                    }

                    break;

                case KKHLionConst.COLSTR_CARDNO_RDNET:      //「003:ラジオタイム」.
                case KKHLionConst.COLSTR_CARDNO_RDLCL:      //「004:ラジオローカル」.

                    dtMastAddress = this.GetSysMastInfoAddress();   //アドレス系システムマスタ.
                    dtMastFile = this.GetSysMastInfoFile();         //ファイル系システムマスタ.
                    //ラジオ局マスタ情報取得.
                    rdkResult = this.GetRdKMastResult(dtMastAddress.CommonDataSet.SystemCommon[0].field4.ToString()
                                                    , dtMastAddress.CommonDataSet.SystemCommon[0].field10.ToString()
                                                    , dtMastAddress.CommonDataSet.SystemCommon[0].field2.ToString()
                                                    , dtMastFile.CommonDataSet.SystemCommon[0].field5.ToString());

                    rdKLion = rdkResult.mastLionDataSet.RdKLion;

                    //ラジオ局変換マスタ取得.
                    dtRdHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                  _naviParam.strEgcd,
                                                  _naviParam.strTksKgyCd,
                                                  _naviParam.strTksBmnSeqNo,
                                                  _naviParam.strTksTntSeqNo,
                                                  KKHLionConst.C_MAST_RADIO_HEN_CD,
                                                  false);

                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        //局誌CD.
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                        filter = rdKLion.KYOKUCDColumn.Caption + " = \'" + value + "\'";
                        if (rdKLion.Select(filter).Length == 0)
                        {
                            msg = "ラジオ局マスタ";
                            break;
                        }
                        //ラジオ局変換マスタ.
                        filter = dtRdHenMast.Column2Column.Caption + " = \'" + value + "\'";
                        if (dtRdHenMast.Select(filter).Length == 0)
                        {
                            msg = "ラジオ局変換マスタ";
                            break;
                        }
                    }
                    break;

                case KKHLionConst.COLSTR_CARDNO_SPOT:       //「005]スポット」.

                    dtMastAddress = this.GetSysMastInfoAddress();   //アドレス系システムマスタ.
                    dtMastFile = this.GetSysMastInfoFile();         //ファイル系システムマスタ.

                    switch (pBaitaiNO)
                    {
                        case KKHLionConst.BAITAIKBN_TV_SPOT:
                            //テレビ局マスタ情報取得.
                            tvkResult = this.GetTvKMastResult(dtMastAddress.CommonDataSet.SystemCommon[0].field4.ToString()
                                                            , dtMastAddress.CommonDataSet.SystemCommon[0].field10.ToString()
                                                            , dtMastAddress.CommonDataSet.SystemCommon[0].field2.ToString()
                                                            , dtMastFile.CommonDataSet.SystemCommon[0].field4.ToString());

                            tvKLion = tvkResult.mastLionDataSet.TvKLion;

                            //テレビ局変換マスタ取得.
                            dtTvHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                          _naviParam.strEgcd,
                                                          _naviParam.strTksKgyCd,
                                                          _naviParam.strTksBmnSeqNo,
                                                          _naviParam.strTksTntSeqNo,
                                                          KKHLionConst.C_MAST_TV_HEN_CD,
                                                          false);

                            //存在チェック.
                            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                            {
                                //局誌CD
                                value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                                filter = tvKLion.KYOKUCDColumn.Caption + " = \'" + value + "\'";
                                if (tvKLion.Select(filter).Length == 0)
                                {
                                    msg = "テレビ局マスタ";
                                    break;
                                }

                                //テレビ局変換マスタ.
                                filter = dtTvHenMast.Column2Column.Caption + " = \'" + value + "\'";
                                if (dtTvHenMast.Select(filter).Length == 0)
                                {
                                    msg = "テレビ局変換マスタ";
                                    break;
                                }

                            }
                            break;

                        case KKHLionConst.BAITAIKBN_RD_SPOT:
                            //ラジオ局マスタ情報取得.
                            rdkResult = this.GetRdKMastResult(dtMastAddress.CommonDataSet.SystemCommon[0].field4.ToString()
                                                            , dtMastAddress.CommonDataSet.SystemCommon[0].field10.ToString()
                                                            , dtMastAddress.CommonDataSet.SystemCommon[0].field2.ToString()
                                                            , dtMastFile.CommonDataSet.SystemCommon[0].field5.ToString());

                            rdKLion = rdkResult.mastLionDataSet.RdKLion;

                            //ラジオ局変換マスタ取得.
                            dtRdHenMast = readMastDB.FindMasterData(_naviParam.strEsqId,
                                                          _naviParam.strEgcd,
                                                          _naviParam.strTksKgyCd,
                                                          _naviParam.strTksBmnSeqNo,
                                                          _naviParam.strTksTntSeqNo,
                                                          KKHLionConst.C_MAST_RADIO_HEN_CD,
                                                          false);

                            //存在チェック.
                            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                            {
                                //局誌CD.
                                value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Text.Trim();
                                filter = rdKLion.KYOKUCDColumn.Caption + " = \'" + value + "\'";
                                if (rdKLion.Select(filter).Length == 0)
                                {
                                    msg = "ラジオ局マスタ";
                                    break;
                                }
                                //ラジオ局変換マスタ.
                                filter = dtRdHenMast.Column2Column.Caption + " = \'" + value + "\'";
                                if (dtRdHenMast.Select(filter).Length == 0)
                                {
                                    msg = "ラジオ局変換マスタ";
                                    break;
                                }
                            }
                            break;
                    }
                    break;

                case KKHLionConst.COLSTR_CARDNO_KOTU:       //「009:交通」.
                    //県マスタ取得.
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                      _naviParam.strEgcd,
                                                      _naviParam.strTksKgyCd,
                                                      _naviParam.strTksBmnSeqNo,
                                                      _naviParam.strTksTntSeqNo,
                                                      KKHLionConst.C_MAST_KEN_CD,
                                                      null);

                    vo = result.MasterDataSet.MasterDataVO;

                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_FUKENCD].Text.Trim();
                        filter = vo.Column1Column.Caption + " = \'" + value + "\'";
                        if (vo.Select(filter).Length == 0)
                        {
                            msg = "県マスタ";
                            break;
                        }
                    }

                    break;

                case KKHLionConst.COLSTR_CARDNO_SEISAKU:    //「012:制作費」.
                    //媒体区分マスタ取得.
                    result = process.FindMasterByCond(_naviParam.strEsqId,
                                                      _naviParam.strEgcd,
                                                      _naviParam.strTksKgyCd,
                                                      _naviParam.strTksBmnSeqNo,
                                                      _naviParam.strTksTntSeqNo,
                                                      KKHLionConst.C_MAST_BAITAI_CD,
                                                      null);

                    vo = result.MasterDataSet.MasterDataVO;
                    //存在チェック.
                    foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
                    {
                        value = dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_BAITAI].Text.Trim();
                        filter = vo.Column1Column.Caption + " = \'" + value + "\'";
                        if (vo.Select(filter).Length == 0)
                        {
                            msg = "媒体区分マスタ";
                            break;
                        }
                    }
                    break;
            }

            if (string.IsNullOrEmpty(msg) == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0018
                                            , new string[] { value, msg }
                                            , "明細登録"
                                            , MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// アドレス系システムマスタ情報取得.
        /// </summary>
        /// <returns>アドレス系システムマスタ情報</returns>
        private FindCommonByCondServiceResult GetSysMastInfoAddress()
        {
            FindCommonByCondServiceResult plDtMast = null;      //アドレス系システムマスタ用.

            //取得（アドレス）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRFL_SYBT,
                                                                                            KKHLionConst.C_SMASTA_FLD1);
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast = comResult;
            }

            return plDtMast;
        }

        /// <summary>
        /// ファイル系システムマスタ用情報取得.
        /// </summary>
        /// <returns>ファイル系システムマスタ用情報</returns>
        private FindCommonByCondServiceResult GetSysMastInfoFile()
        {
            FindCommonByCondServiceResult plDtMast = null;    //ファイル系システムマスタ用.

            //取得（ファイル）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRKT_SYBT,
                                                                                            KKHLionConst.C_WRKTF_FLD1);
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast = comResult;
            }

            return plDtMast;
        }

        /// <summary>
        /// テレビ局マスタ情報取得.
        /// </summary>
        /// <param name="address">アドレス</param>
        /// <param name="pass">パスワード</param>
        /// <param name="tempAddress">テンプアドレス</param>
        /// <param name="filenm">ファイル名</param>
        /// <returns>取得結果</returns>
        private Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult GetTvKMastResult(string address
                                                                                                       , string pass
                                                                                                       , string tempAddress
                                                                                                       , string filenm)
        {
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            //●↓ここからワークテーブルリフレッシュタイム↓●.
            //システム管理者の場合はワークテーブルの更新を行わない.
            if (!_naviParam.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //テレビ局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(address, pass, tempAddress, filenm, KKHLionConst.C_WRFL_TVKMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ (テレビ局マスタ)
                    MastLion.TvKLionDataTable mstDataVo = new MastLion.TvKLionDataTable();

                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController =
                        Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();

                    mstDataVo = mstf.TvKSetCsvData(address + filenm, _naviParam);

                    masterMaintenanceProcessController.RegisterTvKMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstDataVo,
                                                                      dtNow);
                }
            }

            //テレビ局マスタ取得処理.
            //実行.
            MastLion mstData = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mst =
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();

            ArrayList aryMst = new ArrayList();

            //検索項目 (空白でもOK)
            aryMst.Add("");//放送局コード.
            aryMst.Add("");//記号.
            aryMst.Add("");//系列.
            aryMst.Add("");//地区.

            //実行.
            Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult result = mst.FindTvKMast(aryMst, _naviParam);

            //データが存在しなければ終了.
            if (result == null)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// ラジオ局マスタ情報取得.
        /// </summary>
        /// <param name="address">アドレス</param>
        /// <param name="pass">パスワード</param>
        /// <param name="tempAddress">テンプアドレス</param>
        /// <param name="filenm">ファイル名</param>
        /// <returns>取得結果</returns>
        private Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult GetRdKMastResult(string address
                                                                                                       , string pass
                                                                                                       , string tempAddress
                                                                                                       , string filenm)
        {
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            //●↓ここからワークテーブルリフレッシュタイム↓●.
            //システム管理者の場合はワークテーブルの更新を行わない.
            if (!_naviParam.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //ラジオ局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(address, pass, tempAddress, filenm, KKHLionConst.C_WRFL_RDKMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ (ラジオ局マスタ)
                    MastLion.RdKLionDataTable mstDataVo = new MastLion.RdKLionDataTable();

                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController =
                        Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstDataVo = mstf.RdKSetCsvData(address + filenm, _naviParam);

                    masterMaintenanceProcessController.RegisterRdKMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstDataVo,
                                                                      dtNow);
                }
            }

            //ラジオ局マスタ取得処理.
            //実行.
            MastLion mstData = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mst =
                Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList arrMst = new ArrayList();

            //検索項目 (空白でもOK)
            arrMst.Add("");//放送局コード.
            arrMst.Add("");//記号.
            arrMst.Add("");//系列.

            //実行.
            Isid.KKH.Lion.ProcessController.MastGet.FindLionMastByCondServiceResult result = mst.FindRdKMast(arrMst, _naviParam);

            //データが存在しなければ終了.
            if (result == null)
            {
                return null;
            }

            return result;
        }

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

            //キー=「列,行」値=「貼り付け値」.
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                //複数コピーでない場合.
                multiCopyFlg = false;
            }

            //コピー分のセル走査.
            foreach (string pastKey in pastDic.Keys)
            {
                //キー「列,行」を分割.
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
                    dgvMain_Change(this.dgvMain, changeEvent);
                }
                //セルタイプの違い等でのエラー回避用.
                catch
                {

                }
            }

            return multiCopyFlg;
        }

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
            if (actColumn.Locked)
            {
                //ロックされている場合.
                return false;
            }

            //非表示列へは貼り付け不可とする.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType ||
                actColumn.CellType is NumberCellType)
            {
                //セルタイプがテキストの場合.
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region テレビ,ラジオ番組展開処理.

        #region イベント.

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBangumi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データが存在する場合は処理を行わない　←必須.
            //if (pMeiCardNo != "") {
            //    return;
            //}

            //番組選択時に処理を行う.
            if (cmbBangumi.SelectedIndex != 0 && cmbBangumi.SelectedIndex != -1)
            {
                //↓マスタ設定//////////////////////////////////////////////////////////////////////////
                //番組用変数設定.
                string NetFc = "";//ネットFC
                string TnkKbn = "";//単価区分.
                string kyokucd = "";//局CD(電通CD)
                String netOrLcl = ""; //タイプ２がネットかローカル.

                //料金マスタ変数設定.
                //decimal Denparyo = 0M;//電波料.
                //decimal Netryo = 0M;//ネット料.
                //decimal Seisakuhi = 0M;//ネット料.
                //string housokyoku = "";//局CD(ライオンCD)
                //string keiretu = "";//局系列CD.
                List<PgKyokuRyokin> lstPgKyokuRyokin = new List<PgKyokuRyokin>();

                //テレビ番組マスタ.
                if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                    || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS)
                    )
                {

                    MastLion.TvBnLionRow[] rowsb;
                    rowsb = (MastLion.TvBnLionRow[])prTvBmast.mastLionDataSet.TvBnLion.Select("BANCD = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");

                    //番組マスタデータ取得.
                    foreach (Isid.KKH.Lion.Schema.MastLion.TvBnLionRow rowb in rowsb)
                    {
                        //ネット(1)かローカル(2)
                        netOrLcl = rowb.TYPE2;

                        //単価区分セット.
                        TnkKbn = rowb.TANKA;

                        //局コード.
                        kyokucd = rowb.HKYOKUCD;

                        //システム管理者の場合で料金マスタが空の場合、処理を抜ける.
                        if (_naviParam.strEsqId.Substring(0, 3).Equals("@@@") && prTvRmast == null)
                        {
                                return;
                        }

                        MastLion.TvKeiKinSetRow[] rowsk;
                        rowsk = (MastLion.TvKeiKinSetRow[])prTvRmast.Select(
                            "BanCd = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");

                        //料金マスタデータ取得.
                        foreach (Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetRow rowk in rowsk)
                        {
                            //局マスタデータ取得.
                            MastLion.TvKLionRow[] rows;
                            rows = (MastLion.TvKLionRow[])prTvKmast.mastLionDataSet.TvKLion.Select(
                                "KEIRETSU = '" + rowk.KeiretuCD
                                + "' AND KYOKUCD = '" + rowk.KyokuCd + "'");
                            if (rows.Length == 0)
                            {
                                //局マスタに紐づかないデータは無視.
                                continue;
                            }

                            PgKyokuRyokin pgKyokuRyokin = new PgKyokuRyokin();

                            //番組マスタのデータを使用************************************
                            //番組CD
                            pgKyokuRyokin.bangumiCd = rowb.BANCD;
                            //制作費セット.
                            //局変換マスタの存在チェックを行い、存在しなければ0をセットする.
                            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[] tvHenMastRows =
                                (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[])dtTvHenMast.Select(
                                dtTvHenMast.Column1Column.ColumnName + " = '" + rowb.HKYOKUCD
                                + "' AND " + dtTvHenMast.Column2Column.ColumnName + " = '" + rows[0].KYOKUCD + "'");
                            if (tvHenMastRows.Length == 0)
                            {
                                pgKyokuRyokin.seisakuHi = 0.0M;
                            }
                            else
                            {
                                pgKyokuRyokin.seisakuHi = decimal.Parse(rowb.SEISAKUHI);
                            }

                            //料金マスタのデータを使用************************************
                            //電波料セット.
                            pgKyokuRyokin.denpaRyo = rowk.DenpaRyo;
                            //ネット料セット.
                            pgKyokuRyokin.netRyo = rowk.NetRyo;

                            //局マスタのデータを使用************************************
                            //局CD.
                            pgKyokuRyokin.kyokuCd = rows[0].KYOKUCD;
                            //局名称.
                            pgKyokuRyokin.kyokuNm = rows[0].KYOKUNAME;

                            //ソートキー1(帳票表示順).
                            pgKyokuRyokin.sortKey1 = rows[0].THYOJIJYUN;

                            lstPgKyokuRyokin.Add(pgKyokuRyokin);
                        }

                        break;
                    }
                }
                //ラジオ番組マスタ.
                else if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDLCL)
                        || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_RDNET)
                        )
                {
                    MastLion.RdBnLionRow[] rowsb;
                    rowsb = (MastLion.RdBnLionRow[])prRdBmast.mastLionDataSet.RdBnLion.Select("BANCD = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");

                    //番組マスタデータ取得.
                    foreach (Isid.KKH.Lion.Schema.MastLion.RdBnLionRow rowb in rowsb)
                    {
                        //ネットかローカル.
                        netOrLcl = rowb.TYPE2;

                        //ネットFCセット.
                        //NetFc = rowb.TYPE2;
                        //単価区分セット.
                        TnkKbn = rowb.TANKA;
                        ////制作費セット.
                        //Seisakuhi = decimal.Parse(rowb.SEISAKUHI);

                        //システム管理者の場合で料金マスタが空の場合、処理を抜ける.
                        if (_naviParam.strEsqId.Substring(0, 3).Equals("@@@") && prRdRmast == null)
                        {
                            return;
                        }

                        MastLion.RdKeiKinSetRow[] rowsk;
                        rowsk = (MastLion.RdKeiKinSetRow[])prRdRmast.Select(
                            "BanCd = '" + cmbBangumi.Text.ToString().Substring(0, 3) + "'");

                        //料金マスタデータ取得.
                        foreach (Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetRow rowk in rowsk)
                        {
                            //局マスタデータ取得.
                            MastLion.RdKLionRow[] rows;
                            rows = (MastLion.RdKLionRow[])prRdKmast.mastLionDataSet.RdKLion.Select(
                                "KEIRETSU = '" + rowk.KeiretuCD + "' AND KYOKUCD = '" + rowk.KyokuCd + "'");
                            if (rows.Length == 0)
                            {
                                //局マスタに紐づかないデータは無視.
                                continue;
                            }

                            PgKyokuRyokin pgKyokuRyokin = new PgKyokuRyokin();

                            //番組マスタのデータを使用************************************
                            //番組CD
                            pgKyokuRyokin.bangumiCd = rowb.BANCD;
                            //制作費セット.
                            //局変換マスタの存在チェックを行い、存在しなければ0をセットする.
                            //番組マスタの[制作局]をキーに局マスタを検索する.
                            string filter = dtRdHenMast.Column1Column.ColumnName + " = '" + rowb.HKYOKUCD
                                + "' AND " + dtRdHenMast.Column2Column.ColumnName + " = '" + rows[0].KYOKUCD + "'";

                            MasterMaintenance.MasterDataVORow[] rdHenMastRows =
                                (MasterMaintenance.MasterDataVORow[])dtRdHenMast.Select(filter);
                            if (rdHenMastRows.Length == 0)
                            {
                                pgKyokuRyokin.seisakuHi = 0.0M;
                            }
                            else
                            {
                                pgKyokuRyokin.seisakuHi = decimal.Parse(rowb.SEISAKUHI);
                            }
                            //pgKyokuRyokin.seisakuHi = decimal.Parse(rowb.SEISAKUHI);

                            //料金マスタのデータを使用************************************
                            //電波料セット.
                            pgKyokuRyokin.denpaRyo = rowk.DenpaRyo;
                            //ネット料セット.
                            pgKyokuRyokin.netRyo = rowk.NetRyo;

                            //局マスタのデータを使用************************************
                            //局CD
                            pgKyokuRyokin.kyokuCd = rows[0].KYOKUCD;
                            //局名称.
                            pgKyokuRyokin.kyokuNm = rows[0].KYOKUNAME;

                            //ソートキー1 (帳票表示順)
                            int hyojiJyun = 0;
                            if (int.TryParse(rows[0].HYOJIJYUN, out hyojiJyun) == false)
                            {
                                pgKyokuRyokin.sortKey1 = null;
                            }
                            else
                            {
                                pgKyokuRyokin.sortKey1 = hyojiJyun.ToString(new string('0', int.MaxValue.ToString().Length));
                            }

                            lstPgKyokuRyokin.Add(pgKyokuRyokin);
                        }

                        break;
                    }
                }
                //↑マスタ設定//////////////////////////////////////////////////////////////////////////

                int cnt = 0;

                //スプレッド初期化.
                dgvMain_Sheet1.RowCount = 0;
                dgvMain_Sheet1.RowCount = lstPgKyokuRyokin.Count;

                //格納してあるデータをソートする.
                lstPgKyokuRyokin.Sort();

                ////局マスタ分ループ.
                //foreach (Isid.KKH.Lion.Schema.MastLion.TvKLionRow row in rows)
                foreach (PgKyokuRyokin pgKyokuRyokin in lstPgKyokuRyokin)
                {

                    //カードNoがBS/CSの場合.
                    if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_BSCS))
                    {
                        //カードNo
                        foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                        {
                            //カードNoはボタンに変更.
                            col.CellType = new ButtonCellType();
                            ButtonCellType cellType = (ButtonCellType)col.CellType;
                            cellType.Text = KKHLionConst.COLSTR_CARDNO_BSCS;
                            break;
                        }
                        //FD順序.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "16";
                        //媒体区分.
                        pBaitaiNO = KKHLionConst.BAITAIKBN_BSCS;
                        //シートに媒体区分をセット.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                    }
                    //それ以外.
                    else
                    {
                        //番組マスタのタイプ２がネットの場合 (1:ネット、2:ローカル)
                        if (netOrLcl.Equals("1"))
                        {
                            //テレビの場合.
                            if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL))
                            {
                                //カードNo
                                //★このやり方しかない？.
                                foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                                {
                                    //カードNoはボタンに変更.
                                    col.CellType = new ButtonCellType();
                                    ButtonCellType cellType = (ButtonCellType)col.CellType;
                                    cellType.Text = KKHLionConst.COLSTR_CARDNO_TVNET;

                                    break;
                                }

                                dgvMain_Sheet1.Cells[0, 0].Value = null;
                                //FD順序.
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "01";
                                //媒体区分.
                                pBaitaiNO = KKHLionConst.BAITAIKBN_TV;
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                            }
                            //ラジオの場合.
                            else
                            {
                                //カードNo
                                //★このやり方しかない？.
                                foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                                {
                                    //カードNoはボタンに変更.
                                    col.CellType = new ButtonCellType();
                                    ButtonCellType cellType = (ButtonCellType)col.CellType;
                                    cellType.Text = KKHLionConst.COLSTR_CARDNO_RDNET;
                                    break;
                                }
                                //FD順序.
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "04";
                                //媒体区分.
                                pBaitaiNO = KKHLionConst.BAITAIKBN_RD;
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                            }
                        }
                        //番組マスタのタイプ２がローカルの場合 (1:ネット、2:ローカル)
                        else
                        {
                            //テレビの場合.
                            if (pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVNET)
                                || pCardNO.Equals(KKHLionConst.COLSTR_CARDNO_TVLCL))
                            {
                                //カードNo
                                //★このやり方しかない？.
                                foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                                {
                                    //カードNoはボタンに変更.
                                    col.CellType = new ButtonCellType();
                                    ButtonCellType cellType = (ButtonCellType)col.CellType;
                                    cellType.Text = KKHLionConst.COLSTR_CARDNO_TVLCL;
                                    break;
                                }
                                //FD順序.
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "02";
                                //媒体区分.
                                pBaitaiNO = KKHLionConst.BAITAIKBN_TV;
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                            }
                            //ラジオの場合.
                            else
                            {
                                //カードNo
                                //★このやり方しかない？.
                                foreach (FarPoint.Win.Spread.Column col in dgvMain_Sheet1.Columns)
                                {
                                    //カードNoはボタンに変更.
                                    col.CellType = new ButtonCellType();
                                    ButtonCellType cellType = (ButtonCellType)col.CellType;
                                    cellType.Text = KKHLionConst.COLSTR_CARDNO_RDLCL;
                                    break;
                                }
                                //FD順序.
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "05";
                                //媒体区分.
                                pBaitaiNO = KKHLionConst.BAITAIKBN_RD;
                                dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                            }
                        }
                    }

                    //データ日付.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_YYMM].Value = _dataRow.hb1Yymm;
                    //代理店CD
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value = "1001";//固定.
                    //費目CD
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;
                    //ブランド名称 (コンボブランドが表示状態のみ)
                    if (cmbBrand.Visible == true)
                    {
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = cmbBrand.Items[0];
                    }
                    //値引率.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NBKRITU].Value = _dataRow.hb1NeviRitu;
                    //局誌コード.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = pgKyokuRyokin.kyokuCd;
                    //局誌名称.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_STR1].Value = pgKyokuRyokin.kyokuNm;
                    //ネットFCを表示.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NETFC].Value = NetFc;

                    decimal keisan001 = 0.01M;
                    //単価時の場合は電波・ネット料×本数.
                    if (TnkKbn.Equals("1"))
                    {
                        //請求区分がタイム　かつ　Field1(媒体コード)が未設定（受注新規で作成）ではない場合　単価×本数.
                        if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm) && _dataRow.hb1Field1 != "")
                        {
                            //電波料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = pgKyokuRyokin.denpaRyo * decimal.Parse(_dataRow.hb1Field6);
                            //値引き電波料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = Math.Truncate(pgKyokuRyokin.denpaRyo * Math.Truncate(decimal.Parse(_dataRow.hb1Field6)) * _dataRow.hb1NeviRitu * keisan001);
                            //ネット料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NETRYO].Value = pgKyokuRyokin.netRyo * decimal.Parse(_dataRow.hb1Field6);
                            //制作費を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_INT2].Value = pgKyokuRyokin.seisakuHi * decimal.Parse(_dataRow.hb1Field6);
                        }
                        //ダウンデータの請求区分がタイムでない場合は放送回数を1回として計算.
                        else
                        {
                            //電波料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = pgKyokuRyokin.denpaRyo * 1;
                            //値引き電波料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = Math.Truncate(pgKyokuRyokin.denpaRyo * 1 * _dataRow.hb1NeviRitu * keisan001);
                            //ネット料を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NETRYO].Value = pgKyokuRyokin.netRyo * 1;
                            //制作費を表示.
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_INT2].Value = pgKyokuRyokin.seisakuHi * 1;
                        }
                    }
                    else
                    {
                        //電波料を表示.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = pgKyokuRyokin.denpaRyo * 1;
                        //値引き電波料を表示.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = Math.Truncate(pgKyokuRyokin.denpaRyo * 1 * _dataRow.hb1NeviRitu * keisan001);
                        //ネット料を表示.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_NETRYO].Value = pgKyokuRyokin.netRyo * 1;
                        //制作費を表示.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_INT2].Value = pgKyokuRyokin.seisakuHi * 1;
                    }

                    //本数設定.
                    if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm))
                    {
                        //本数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HONSU].Value = _dataRow.hb1Field6;
                        //放送回数 (計算用)
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = _dataRow.hb1Field6;
                        //休止回数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = "0";
                        //秒数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BYOSU].Value = _dataRow.hb1Field5;
                        //総秒数.
                        if (KKHUtility.IsNumeric(_dataRow.hb1Field5) && KKHUtility.IsNumeric(_dataRow.hb1Field6))
                        {
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = decimal.Parse(_dataRow.hb1Field6) * decimal.Parse(_dataRow.hb1Field5);
                        }
                        else
                        {
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = "0";
                        }
                        //期間を表示.
                        if ((_dataRow.hb1Field8 != "") && (_dataRow.hb1Field8.Length == 16))
                        {
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KIKAN].Value = keisaihenkan(_dataRow.hb1Field8);
                        }
                        else
                        {
                            dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KIKAN].Value = _dataRow.hb1Field8;
                        }
                    }
                    else
                    {
                        //本数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HONSU].Value = "1";
                        //放送回数 (計算用).
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = "1";
                        //休止回数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = "0";
                        //秒数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BYOSU].Value = "0";
                        //総秒数.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = "0";
                        //期間を表示.
                        dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KIKAN].Value = "";
                    }

                    //消費税率を表示.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_TAXRITU].Value = _dataRow.hb1SzeiRitu;
                    //件名.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_KENMEI].Value = _dataRow.hb1KKNameKJ;
                    //売上明細No
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_URIMEI].Value = _dataRow.hb1JyutNo + "-" + _dataRow.hb1JyMeiNo + "-" + _dataRow.hb1UrMeiNo;
                    //番組コード.
                    dgvMain_Sheet1.Cells[cnt, KKHLionConst.COLIDX_MLIST_BANGCD].Value = cmbBangumi.Text.ToString().Substring(0, 3);

                    //請求金額の計算.
                    CalcClaimCost(cnt);
                    //消費税を表示.
                    CalcTaxCost(cnt);

                    //カウントアップ.
                    cnt++;
                }

                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Tm))
                {
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field6))
                    {
                        txtHososu.Text = int.Parse(_dataRow.hb1Field6).ToString();
                    }
                    else
                    {
                        txtHososu.Text = "1";
                    }
                }
                else
                {
                    txtHososu.Text = "1";
                }

                //計算処理.
                CalcTotalCost();
            }
        }

        /// <summary>
        /// テレビスポット検索画面遷移.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTvSpot_Click(object sender, EventArgs e)
        {
            //パラメータセット.
            FindLionTVSpotNaviParameter naviParam = new FindLionTVSpotNaviParameter();
            naviParam.strEsqId = _naviParam.strEsqId;
            naviParam.strEgcd = _naviParam.strEgcd;
            naviParam.strTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParam.strTksTntSeqNo;
            naviParam.StrYymm = _naviParam.StrYymm;
            naviParam.strName = _naviParam.strName;

            //請求年月の設定.
            naviParam.StrYM = txtYymm.Text.ToString();

            //ダイアログでカードNO一覧画面を呼び出し.
            object result = Navigator.ShowModalForm(this, "toFindLionTVSpot", naviParam);

            if (result == null)
            {
                //データが存在しなかったら処理を抜ける.
                return;
            }

            //各項目用.
            string strFdretu = " ";     //FD
            string strkyokusicd = " ";  //局誌CD
            string strkyokusinm = " ";  //局誌名.
            string strspace = " ";      //スペース.
            string strkeisaietc = " ";  //掲載日・号・ほか.
            string strkikan = " ";      //期間.
            string strbaitaikbn = "";   //媒体区分.
            string strbyosu = "";       //秒数.
            string strhosokaisu_h = ""; //放送回数(本数)

            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();

            //データの反映.
            //レイアウトロジック中止.
            dgvMain.SuspendLayout();

            dgvMain_Sheet1.RowCount = 0;

            DetailDSLion.KkhTVSpotDetailListViewRow[] resultRows = (DetailDSLion.KkhTVSpotDetailListViewRow[])((FindLionTVSpotNaviParameter)result).DetailListRow;

            foreach (DetailDSLion.KkhTVSpotDetailListViewRow resultRow in resultRows)
            {
                dgvMain_Sheet1.AddRows(dgvMain_Sheet1.RowCount, 1);

                int lRows = dgvMain_Sheet1.RowCount - 1;

                ////初期設定.
                //SetDownload_CardNo(lRows);

                //初期処理開始.
                //媒体区分セット.
                strbaitaikbn = KKHLionConst.BAITAIKBN_TV_SPOT;
                //FD列.
                strFdretu = "03";

                //請求区分で分岐.
                if (_dataRow.hb1SeiKbn.Equals(KKHLionConst.gcstrSeikbn_Sp) && _dataRow.hb1GyomKbn.Equals(KKHLionConst.COLSTR_GYOM_SPOT))
                {
                    //局誌CD
                    strkyokusicd = utl.GetLionCd(_dataRow, _naviParam);
                    //局誌名称.
                    strkyokusinm = _dataRow.hb1Field2;

                    //放送回数 (本数)
                    if (_dataRow.hb1Field6 == "")
                    {
                        strhosokaisu_h = "1";
                    }
                    else
                    {
                        strhosokaisu_h = _dataRow.hb1Field6;
                    }
                    //秒数.
                    if (KKHUtility.IsNumeric(_dataRow.hb1Field5))
                    {
                        strbyosu = _dataRow.hb1Field5;
                    }
                    else
                    {
                        strbyosu = "0";
                    }
                    //期間.
                    if ((_dataRow.hb1Field4 != "") && (_dataRow.hb1Field4.Length == 16))
                    {
                        strkikan = keisaihenkan(_dataRow.hb1Field4);
                    }
                    else
                    {
                        strkikan = _dataRow.hb1Field4;
                    }

                    //秒数.
                    txtByosu.Text = int.Parse(strbyosu).ToString();

                    if (_dataRow.hb1Field4.Length > 7)
                    {
                        //FROM
                        txtCanpFrom.Text = _dataRow.hb1Field4.Substring(0, 8);
                    }
                    if (_dataRow.hb1Field4.Length > 15)
                    {
                        //TO
                        txtCanpTo.Text = _dataRow.hb1Field4.Substring(8, 8);
                    }
                }
                else
                {
                    //局誌CD
                    strkyokusicd = "";
                    //局誌名称.
                    strkyokusinm = " ";
                    //秒数.
                    strbyosu = "0";
                    //放送回数 (本数)
                    strhosokaisu_h = "1";
                    //期間.
                    strkikan = " ";
                    //秒数.
                    txtByosu.Text = "0";
                    //FROM
                    txtCanpFrom.Text = " ";
                    //TO
                    txtCanpTo.Text = " ";
                }

                //ブランドコード･名称.
                if (!String.IsNullOrEmpty(cmbBrand.Text))
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                }

                //放送回数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = int.Parse(strhosokaisu_h);

                //データ日付.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_YYMM].Value = _dataRow.hb1Yymm;
                //代理店CD
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value = "1001";//固定.
                //費目CD
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;
                //ブランド名称 (コンボブランドが表示状態のみ)
                if (cmbBrand.Visible == true)
                {
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = cmbBrand.Items[0];
                }
                //値引率.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKRITU].Value = _dataRow.hb1NeviRitu;
                //件名.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KENMEI].Value = _dataRow.hb1KKNameKJ;
                //消費税率.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAXRITU].Value = _dataRow.hb1SzeiRitu;
                //売上明細No
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_URIMEI].Value = _dataRow.hb1JyutNo + "-" + _dataRow.hb1JyMeiNo + "-" + _dataRow.hb1UrMeiNo;
                //費目CD
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;

                //業務区分によって変更.
                //FD用列.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = strFdretu;
                //局誌CD
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = strkyokusicd;
                //局誌名称.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_STR1].Value = strkyokusinm;
                //スペース.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SPACE].Value = strspace;
                //掲載日･号･等.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KEISAI].Value = strkeisaietc;
                //期間.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KIKAN].Value = strkikan;
                //媒体区分.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BAITAI].Value = strbaitaikbn;

                //１行目以外の場合は初期値の一部を空白or0にする.
                if (lRows != 0)
                {
                    //可変１.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT1].Value = 0M;
                    //実施電波.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = 0M;
                    //値引電波.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = 0M;
                    //ネット料.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NETRYO].Value = 0M;
                    //可変２.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_INT2].Value = 0M;
                    //消費税.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAX].Value = 0M;
                    //局誌CD
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = "";
                    //局誌名称.
                    dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_STR1].Value = "";
                }

                //初期処理終了.

                //局誌コード.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = resultRow.KYOKUCD;
                //局誌名称.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_STR1].Value = resultRow.KYOKUNAME;
                //実施電波料.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = KKHUtility.DecParse(resultRow.K_HKGAK_HAT);
                //値引き電波料.
                //dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = KKHUtility.DecParse(resultRow.K_HKGAK_HAT) * (_dataRow.hb1NeviRitu / 100.0m);
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = Math.Truncate(KKHUtility.DecParse(resultRow.K_HKGAK_HAT) * (_dataRow.hb1NeviRitu * 0.01M));
                //本数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_HONSU].Value = KKHUtility.DecParse(resultRow.COUNT);
                //秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_BYOSU].Value = KKHUtility.DecParse(resultRow.CM_SEC);
                //総秒数.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = KKHUtility.DecParse(resultRow.TOTAL_CM_SEC);
                //地区コード.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TIKUCD].Value = resultRow.TIKU;

                //請求金額 = 実施電波料 - 値引き電波料.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value =
                    (KKHUtility.DecParse(dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value.ToString())
                        - KKHUtility.DecParse(dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value.ToString())).ToString();


                //消費税額 = 請求金額 × 消費税率.
                dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAX].Value =
                    (Math.Floor(KKHUtility.DecParse(dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value.ToString())
                        * (KKHUtility.DecParse(dgvMain_Sheet1.Cells[lRows, KKHLionConst.COLIDX_MLIST_TAXRITU].Value.ToString()) * 0.01M))).ToString();
            }
            //計算処理.
            CalcTotalCost();

            //レイアウトロジック再開.
            dgvMain.ResumeLayout();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 地区コンボボックスSelectedValue変更時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSeitiku_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cmbSeitiku.Visible == false)
            //{
            //    return;
            //}
            //cmbSeitiku_SelectedValueChanged();
        }

        /// <summary>
        /// 番組展開処理.
        /// </summary>
        private void cmbSeitiku_SelectedValueChanged()
        {
            if (this.dgvMain_Sheet1.RowCount > 1)
            {
                if (MessageBox.Show("分割データが存在します。展開する場合は、データが削除されます。" + Environment.NewLine + "展開してもよろしいですか？", "明細登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }

            if (cmbSeitiku.SelectedIndex < 0)
            {
                return;
            }

            int COLIDX_KYOKUCD = -1;
            int COLIDX_KYOKUNAME = -1;
            int COLIDX_TIKU = -1;

            string selValue = cmbSeitiku.SelectedValue.ToString();
            string filterEx = "";
            DataRow[] rows;

            //空が選択された場合は何もしない.

            if (selValue.Equals(string.Empty)) { return; }

            if (pBaitaiNO == KKHLionConst.BAITAIKBN_TV_SPOT && pCardNO == KKHLionConst.COLSTR_CARDNO_SPOT)
            {
                filterEx = filterEx + "";
                //テレビ局マスタ検索条件作成==================================================
                //制地区マスタ(仮)からデータを取得する.
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process
                    = Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result;

                result = process.FindMasterByCond(_naviParam.strEsqId,
                                                   _naviParam.strEgcd,
                                                   _naviParam.strTksKgyCd,
                                                   _naviParam.strTksBmnSeqNo,
                                                   _naviParam.strTksTntSeqNo,
                                                   KKHLionConst.C_MAST_SEITIKU_CD,
                                                   null);

                if (result.HasError)
                {
                    return;
                }

                //地区マスタデータセット.
                Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)result.MasterDataSet.MasterDataVO.Copy();




                Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[] tikuDataRow = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column.ColumnName + "='" + pBaitaiNO + "' AND " + dt.Column2Column.ColumnName + "='" + selValue + "'");

                filterEx = filterEx + " " + prTvKmast.mastLionDataSet.TvKLion.TIKUColumn.ColumnName + " <> '' ";
                for (int i = 0; i < tikuDataRow.Length; i++)
                {
                    if (i == 0)
                    {
                        filterEx = filterEx + " AND (";
                        filterEx = filterEx + String.Format("    {0} = '{1}' ", prTvKmast.mastLionDataSet.TvKLion.TIKUColumn.ColumnName, tikuDataRow[i].Column4);
                    }
                    else
                    {
                        filterEx = filterEx + String.Format(" OR {0} = '{1}' ", prTvKmast.mastLionDataSet.TvKLion.TIKUColumn.ColumnName, tikuDataRow[i].Column4);
                    }

                    if (i == tikuDataRow.Length - 1)
                    {
                        filterEx = filterEx + " )";
                    }
                }
                //============================================================================

                rows = prTvKmast.mastLionDataSet.TvKLion.Select(filterEx, prTvKmast.mastLionDataSet.TvKLion.THYOJIJYUNColumn.ColumnName);

                COLIDX_KYOKUCD = prTvKmast.mastLionDataSet.TvKLion.KYOKUCDColumn.Ordinal;
                COLIDX_KYOKUNAME = prTvKmast.mastLionDataSet.TvKLion.KYOKUNAMEColumn.Ordinal;
                COLIDX_TIKU = prTvKmast.mastLionDataSet.TvKLion.TIKUColumn.Ordinal;
            }
            else
            {
                filterEx = filterEx + "";
                //ラジオ局マスタ検索条件作成==================================================
                //制地区マスタ(仮)からデータを取得する.
                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController process
                    = Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result;

                result = process.FindMasterByCond(_naviParam.strEsqId,
                                                   _naviParam.strEgcd,
                                                   _naviParam.strTksKgyCd,
                                                   _naviParam.strTksBmnSeqNo,
                                                   _naviParam.strTksTntSeqNo,
                                                   KKHLionConst.C_MAST_SEITIKU_CD,
                                                   null);

                if (result.HasError)
                {
                    return;
                }

                //地区マスタデータセット.
                Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dt = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)result.MasterDataSet.MasterDataVO.Copy();
                Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[] tikuDataRow = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow[])dt.Select(dt.Column1Column.ColumnName + "='" + pBaitaiNO + "' AND " + dt.Column2Column.ColumnName + "='" + selValue + "'");
                for (int i = 0; i < tikuDataRow.Length; i++)
                {
                    if (i == 0)
                    {
                        filterEx = filterEx + " (";
                        filterEx = filterEx + String.Format("    {0} = '{1}' ", prRdKmast.mastLionDataSet.RdKLion.KYOKUCDColumn.ColumnName, tikuDataRow[i].Column4);
                    }
                    else
                    {
                        filterEx = filterEx + String.Format(" OR {0} = '{1}' ", prRdKmast.mastLionDataSet.RdKLion.KYOKUCDColumn.ColumnName, tikuDataRow[i].Column4);
                    }

                    if (i == tikuDataRow.Length - 1)
                    {
                        filterEx = filterEx + " )";
                    }
                }
                //============================================================================
                rows = prRdKmast.mastLionDataSet.RdKLion.Select(filterEx/*, prRdKmast.mastLionDataSet.RdKLion.THYOJIJYUNColumn.ColumnName*/);

                COLIDX_KYOKUCD = prTvKmast.mastLionDataSet.TvKLion.KYOKUCDColumn.Ordinal;
                COLIDX_KYOKUNAME = prTvKmast.mastLionDataSet.TvKLion.KYOKUNAMEColumn.Ordinal;
                //COLIDX_TIKU = prTvKmast.mastLionDataSet.TvKLion.TIKUColumn.Ordinal;
            }

            //スプレッド初期化.
            dgvMain_Sheet1.RowCount = 0;
            dgvMain_Sheet1.RowCount = rows.Length;

            //foreach (DataRow row in rows)
            for (int i = 0; i < rows.Length; i++)
            {
                if (i == 0)
                {
                    //最初の行に電波料(請求金額+値引額)・値引電波料・請求額を表示.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = _dataRow.hb1SeiGak + _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = _dataRow.hb1NeviGak;
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = _dataRow.hb1SeiGak;
                }
                //カードNO
                FarPoint.Win.Spread.CellType.ButtonCellType cellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                cellType.Text = pCardNO;
                dgvMain_Sheet1.Columns[KKHLionConst.COLIDX_MLIST_CARDNO].CellType = cellType;
                //データ日付.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_YYMM].Value = _dataRow.hb1Yymm;
                //代理店CD
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value = "1001";
                //費目CD
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = _dataRow.hb1HimkCd;
                //ブランド名称.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = cmbBrand.SelectedValue;
                //局誌CD
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = rows[i][COLIDX_KYOKUCD];
                //局誌名称.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_STR1].Value = rows[i][COLIDX_KYOKUNAME];
                //値引率.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKRITU].Value = _dataRow.hb1NeviRitu;
                if (pCardNO == KKHLionConst.COLSTR_CARDNO_SPOT && pBaitaiNO == KKHLionConst.BAITAIKBN_TV_SPOT)
                {
                    //テレビスポットの場合.
                    //媒体区分.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                    //FD用表示順序.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "03";
                    //地区順を格納.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TIKUCD].Value = rows[i][COLIDX_TIKU];
                }
                else
                {
                    //媒体区分.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BAITAI].Value = pBaitaiNO;
                    //FD用表示順序.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = "03";
                }

                if (_dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                {
                    //本数.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HONSU].Value = _dataRow.hb1Field6;
                }
                else
                {
                    //本数.
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HONSU].Value = "1";
                }

                //秒数.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BYOSU].Value = txtByosu.Text;

                //総秒数を再計算する.
                int honsu = KKHUtility.IntParse(dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HONSU].Text);
                int byousu = KKHUtility.IntParse(dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BYOSU].Text);
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = honsu * byousu;//本数・秒数が空や不正文字の場合は0

                //期間.
                //入力値が日付として評価できるかどうかチェック.
                if (KKHUtility.IsDate(txtCanpFrom.Text, "yyyyMMdd") && KKHUtility.IsDate(txtCanpTo.Text, "yyyyMMdd"))
                {
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KIKAN].Value = txtCanpFrom.Text.Insert(6, "/").Insert(4, "/") + " - " + txtCanpTo.Text.Insert(6, "/").Insert(4, "/");
                }
                else
                {
                    dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KIKAN].Value = "";
                }
                //件名.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KENMEI].Value = _dataRow.hb1KKNameKJ;
                //消費税率.
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TAXRITU].Value = _dataRow.hb1SzeiRitu;
                CalcTaxCost(i);
                //売上明細No
                dgvMain_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_URIMEI].Value = _dataRow.hb1JyutNo + "-" + _dataRow.hb1JyMeiNo + "-" + _dataRow.hb1UrMeiNo;

                if (pBaitaiNO == KKHLionConst.BAITAIKBN_TV_SPOT && pCardNO == KKHLionConst.COLSTR_CARDNO_SPOT)
                {
                    //地区別合計.
                    CalcTikuBetsu(i, pBaitaiNO);
                }
            }
        }

        /// <summary>
        /// 地区コンボボックスドロップダウンリスト選択確定時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSeitiku_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbSeitiku_SelectedValueChanged();
        }

        /// <summary>
        /// キャンペーン期間TO変更時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCanpTo_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// キャンペーン期間のKeyPressイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCanp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                //入力が「Backspace」の場合.
                e.Handled = false;
            }
            else if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //入力が「数字」以外の場合.
                e.Handled = true;
            }
        }

        /// <summary>
        /// キャンペーン期間からフォーカスが外れた時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCanp_Leave(object sender, EventArgs e)
        {
            string kikan = "";

            //入力値が日付として評価できるかどうかチェック.
            if (KKHUtility.IsDate(txtCanpFrom.Text, "yyyyMMdd") && KKHUtility.IsDate(txtCanpTo.Text, "yyyyMMdd"))
            {
                kikan = txtCanpFrom.Text.Insert(6, "/").Insert(4, "/") + " - " + txtCanpTo.Text.Insert(6, "/").Insert(4, "/");
            }
            else
            {
                kikan = "";
            }

            //全行に対して処理.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //放送数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_KIKAN].Value = kikan;
            }
        }

        /// <summary>
        /// 秒数からフォーカスが外れた時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtByosu_Leave(object sender, EventArgs e)
        {
            //全行に対して処理.
            foreach (FarPoint.Win.Spread.Row row in dgvMain_Sheet1.Rows)
            {
                //秒数を反映.
                dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_BYOSU].Value = txtByosu.Text;

                string honsu = KKHUtility.ToString(dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_HONSU].Value);

                //総秒数を反映.
                if (KKHUtility.IsNumeric(txtByosu.Text) && KKHUtility.IsNumeric(honsu))
                {
                    dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value =
                        long.Parse(txtByosu.Text) * long.Parse(honsu);
                }
                else
                {
                    dgvMain_Sheet1.Cells[row.Index, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = "0";
                }
            }
        }

        #endregion

        #region メソッド.

        /// <summary>
        /// 明細変更.
        /// </summary>
        private void EditKkhDetail()
        {
            _spdKkhDetail_Sheet1.RowCount = this.dgvMain_Sheet1.RowCount;
            for (int rowIdx = 0; rowIdx < this.dgvMain_Sheet1.RowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < this.dgvMain_Sheet1.ColumnCount; colIdx++)
                {
                    if (colIdx == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        FarPoint.Win.Spread.CellType.ButtonCellType cellType = (FarPoint.Win.Spread.CellType.ButtonCellType)this.dgvMain_Sheet1.Columns[colIdx].CellType;
                        _spdKkhDetail_Sheet1.Cells[rowIdx, colIdx].Text = cellType.Text;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[rowIdx, colIdx].Text = this.dgvMain_Sheet1.Cells[rowIdx, colIdx].Text;
                    }
                }
            }
        }

        #endregion

        #endregion

    }

    #region スキーマに追加を検討.

    /// <summary>
    /// 系列局展開情報構造体.
    /// </summary>
    internal struct PgKyokuRyokin : System.IComparable
    {
        //番組CD
        public string bangumiCd;
        //電波料.
        public decimal denpaRyo;
        //ネット料.
        public decimal netRyo;
        //制作費.
        public decimal seisakuHi;
        //局誌CD
        public string kyokuCd;
        //局誌名称.
        public string kyokuNm;
        //ソートキー1
        public string sortKey1;

        //データ型比較.
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException("別の型とは比較できません。", "obj");
            }

            //Null対応------------------------------------------------
            if (this.sortKey1 == ((PgKyokuRyokin)obj).sortKey1)
            {
                return 0;
            }
            else if (((PgKyokuRyokin)obj).sortKey1 == null)
            {
                return 1;
            }
            else if (this.sortKey1 == null)
            {
                return -1;
            }
            //--------------------------------------------------------
            return this.sortKey1.CompareTo(((PgKyokuRyokin)obj).sortKey1);
        }
    }

    #endregion
}
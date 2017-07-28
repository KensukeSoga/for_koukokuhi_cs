using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using System.Collections;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Kmn.Utility;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Kmn.View.Detail
{
    /// <summary>
    /// 公文 明細一括登録用クラス 
    /// </summary>
    public partial class DetailKmnBulkRegister : KKHDialogBase
    {
        #region 変数.
        /// <summary>
        /// ナビパラメータ.
        /// </summary>
        DetailKmnBulkRegisterNaviparameter _naviPara;

        /// <summary>
        /// 宛先テーブル 
        /// </summary>
        Hashtable _htAtesaki = new Hashtable();  //宛先マスタ_比較項目と部門略称をセットで保持
        #endregion

        #region 定数.
        #region スプレッド行番号 
        /// <summary>
        /// 品目1列番号 
        /// </summary>
        public const int SPDCOL_HINMOKU1 = 0;
        /// <summary>
        /// 品目2列番号 
        /// </summary>
        public const int SPDCOL_HINMOKU2 = 1;
        /// <summary>
        /// 品目3列番号 
        /// </summary>
        public const int SPDCOL_HINMOKU3 = 2;
        /// <summary>
        /// 費目列番号 
        /// </summary>
        public const int SPDCOL_HIMOKU = 3;
        /// <summary>
        /// 期間列番号 
        /// </summary>
        public const int SPDCOL_KIKAN = 4;
        /// <summary>
        /// 合計金額列番号 
        /// </summary>
        public const int SPDCOL_GOUKEI = 5;
        /// <summary>
        /// 消費税計列番号 
        /// </summary>
        public const int SPDCOL_SYOUHI = 6;
        #endregion
        
        #endregion 定数 

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailKmnBulkRegister()
        {
            _naviPara = null;
            InitializeComponent();
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロード時のイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailKmnBulkRegister_Load(object sender, EventArgs e)
        {   
            dispInit();
        }

        /// <summary>
        /// キャンセルボタン押下時のイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// 画面遷移時のイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailKmnBulkRegister_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailKmnBulkRegisterNaviparameter)
            {
                _naviPara = (DetailKmnBulkRegisterNaviparameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 明細登録ボタン押下時のイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiToroku_Click(object sender, EventArgs e)
        {
            //登録前に入力チェックを行う 
            if (!CheckBtnOK())
            {
                return;
            }

            //登録確認メッセージの表示 
            if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "明細登録", MessageBoxButtons.YesNo))
            {
                this.ActiveControl = null;
                return;
            }

            //登録用のデータを作成 
            DetailKmnBulkRegisterNaviparameter returnNavi = new DetailKmnBulkRegisterNaviparameter();
            returnNavi = CreateRegistData();
            //登録処理が終わったら 
            Navigator.Backward(this, returnNavi, null, true);
            this.Close();
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 初期表示 
        /// </summary>
        private void dispInit()
        {
            //部門コンボボックスの設定 
            SetSeikyusakiBumonCmb();
            CmbSeikyusakiBumon.Text = SetBumonValue();

            //年月コンボボックスを設定 
            txtSeikyuYyyymm.Value = SetYYmmValue();
            txtSeikyuYyyymm.cmbYM_SetDate();

            //スプレッドの表示設定 
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviPara.DataRowKmn)
            {
                KKHKmnDetailDisp detailDisp = new KKHKmnDetailDisp();
                
                //選択した行を編集して表示 
                //明細を作成する 
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRows = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] { };
                dataRows = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] { row };

                //品目をうけとり 
                string[] hinmokuList = detailDisp.SetJuchuValue_himoku(row.hb1GyomKbn, dataRows, row);
                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailRow rows = _dsDetailKmn.KkhDetail.NewKkhDetailRow();
                rows.Hinmoku1 = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuList[0]), 30);
                rows.Hinmoku2 = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuList[1]), 30);
                rows.Hinmoku3 = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuList[2]), 30);
                rows.Himoku = row.hb1HimkNmKJ;
                rows.Kikan = detailDisp.GetKikanFromTo(dataRows);
                rows.GokeiKingaku = row.hb1SeiGak.ToString("###,###,###,##0");
                rows.GokeiZeigaku = row.hb1SzeiGak.ToString("###,###,###,##0");

                //データテーブルに追加 
                _dsDetailKmn.KkhDetail.AddKkhDetailRow(rows);

            }
        }
        
        /// <summary>
        /// 請求先部門をコンボボックスにセットする 
        /// </summary>
        private void SetSeikyusakiBumonCmb()
        {
            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 請求先部門 
            //CmbSeikyusakiBumon.Items.Clear();
            result = process.FindMasterByCond(_naviPara.EsqId,
                                            _naviPara.Egcd,
                                            _naviPara.TksKgyCd,
                                            _naviPara.TksBmnSeqNo,
                                            _naviPara.TksTntSeqNo,
                                             DetailKmn.C_MST_ATESAKI,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtAtesaki =
                new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtAtesaki.NewMasterDataVORow();
            dtAtesaki.AddMasterDataVORow(voRow2);//空行を追加 
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtAtesaki.Merge(result.MasterDataSet.MasterDataVO);

                _htAtesaki = new Hashtable();
                // 比較項目と部門略称をセットで保持 
                foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO)
                {
                    _htAtesaki.Add(row.Column4, row.Column2);
                }
            }

            dtAtesaki.AcceptChanges();


            // 2013/04/23 部署名の重複表示排除対応 JSE M.Naito start 
            MasterMaintenance.MasterDataVODataTable dtAtesaki_new =
                new MasterMaintenance.MasterDataVODataTable();

            foreach (MasterMaintenance.MasterDataVORow row1 in result.MasterDataSet.MasterDataVO)
            {
                // 新規行作成 
                MasterMaintenance.MasterDataVORow newrow = (MasterMaintenance.MasterDataVORow)dtAtesaki_new.NewRow();
                // 
                if (dtAtesaki_new.Count > 0)
                {
                    // 部門略称と宛先が一致するデータをDataTableから取得 

                    DataRow[] dt = dtAtesaki_new.Select(dtAtesaki_new.Column2Column.ColumnName + "='" + row1.Column2 + "' AND "
                        + dtAtesaki_new.Column3Column.ColumnName + "='" + row1.Column3 + "'");

                    // DataTableに同じ部門略称が存在しない場合 

                    if (dt.Length == 0)
                    {
                        // 部門略称を取得 

                        newrow.Column2 = row1.Column2;
                        // コードを取得 

                        newrow.Column1 = row1.Column1;
                        // 宛先を取得 

                        newrow.Column3 = row1.Column3;

                        // DataTableに追加 
                        dtAtesaki_new.AddMasterDataVORow(newrow);
                    }
                }
                else
                {
                    // 部門略称を取得 

                    newrow.Column2 = row1.Column2;
                    // コードを取得 

                    newrow.Column1 = row1.Column1;
                    // 宛先を取得 

                    newrow.Column3 = row1.Column3;

                    // 空行を追加 
                    MasterMaintenance.MasterDataVORow voRow2_new = dtAtesaki_new.NewMasterDataVORow();
                    dtAtesaki_new.AddMasterDataVORow(voRow2_new);

                    // DataTableに追加 
                    dtAtesaki_new.AddMasterDataVORow(newrow);
                }
            }


            dtAtesaki_new.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる 
            this.CmbSeikyusakiBumon.DataSource = dtAtesaki_new;

            //表示される値はDataTableのColumn2列 
            this.CmbSeikyusakiBumon.DisplayMember = dtAtesaki_new.Column2Column.ColumnName;
            //表示と対応するコード値はDataTableのColumn1列 
            this.CmbSeikyusakiBumon.ValueMember = dtAtesaki_new.Column1Column.ColumnName;

        }

        /// <summary>
        /// OKボタンクリック時の入力チェック 
        /// </summary>
        /// <returns></returns>
        private bool CheckBtnOK()
        {
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                // チェック対象の値格納用変数 
                string chkVal = "";
                // エラーメッセージ文字列格納用変数 
                string errMsg = "期間：YYYY/MM/DD-YYYY/MM/DD形式で入力されていません。";

                if (CheckRequiredCheck(i) == false)
                {
                    return false;
                }

                //金額 
                if (spdDetailInput_Sheet1.Columns[SPDCOL_GOUKEI].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, SPDCOL_GOUKEI].Text.Replace(",", "");

                    if (chkVal != "" && (KKHUtility.GetByteCount(chkVal) > 13 || KKHUtility.IsNumeric(chkVal) == false))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0003, new string[] { "合計金額" }, "入力エラー", MessageBoxButtons.OK);
                        return false;
                    }
                }

                // 期間 
                if (spdDetailInput_Sheet1.Columns[SPDCOL_KIKAN].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, SPDCOL_KIKAN].Text;

                    // 空欄時はチェックしない 
                    if (!string.IsNullOrEmpty(chkVal))
                    {
                        // ハイフンの存在チェック 
                        if (chkVal.IndexOf("-") >= 0)
                        {
                            // 存在する 
                            // ハイフン前後の文字列を取得 

                            int hai = chkVal.IndexOf("-");
                            string maestr = chkVal.Substring(0, hai);
                            string atostr = chkVal.Substring(hai + 1);

                            // 両方の文字列が日付に変換できるかチェック 
                            if (!KKHUtility.IsDate(maestr, "yyyy/MM/dd") || !KKHUtility.IsDate(atostr, "yyyy/MM/dd"))
                            {
                                // 変換できない 

                                MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                        else
                        {
                            // 存在しない 

                            MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 必須が設定されているかをチェック 
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <returns></returns>
        private bool CheckRequiredCheck(int rowIdx)
        {
            // 請求年月(Spread関係無いのでおそと) 
            if (txtSeikyuYyyymm.Text.Trim().Equals(string.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "請求年月" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 品目１ 
            if (spdDetailInput_Sheet1.Cells[rowIdx, SPDCOL_HINMOKU1].Text.Trim().Equals(string.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "品目１" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 費目 
            if (spdDetailInput_Sheet1.Cells[rowIdx, SPDCOL_HIMOKU].Text.Trim().Equals(string.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "費目" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 合計金額 
            if (spdDetailInput_Sheet1.Cells[rowIdx, SPDCOL_GOUKEI].Text.Trim().Equals(string.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "合計金額" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 消費税合計 
            if (spdDetailInput_Sheet1.Cells[rowIdx, SPDCOL_SYOUHI].Text.Trim().Equals(string.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "消費税合計" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登録データの作成 
        /// </summary>
        private DetailKmnBulkRegisterNaviparameter CreateRegistData()
        {
            KKHKmnDetailDisp detailDisp = new KKHKmnDetailDisp();
            DetailKmnBulkRegisterNaviparameter retNavi = new DetailKmnBulkRegisterNaviparameter();
            List<Isid.KKH.Common.KKHSchema.Detail> returnList = new List<Isid.KKH.Common.KKHSchema.Detail>();

            //サービスパラメータ用変数 
            
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();
            int addCnt = 0;

            //*********************************************
            //THB1DOWNの登録データ編集 
            //*********************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviPara.DataRowKmn)
            {
                Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

                //thb1DownRow.hb1TimStmp = new DateTime(); 
                thb1DownRow.hb1UpdApl = "DtlKmn";//TODO 
                thb1DownRow.hb1UpdTnt = _naviPara.EsqId;
                thb1DownRow.hb1EgCd = _naviPara.Egcd;
                thb1DownRow.hb1TksKgyCd = _naviPara.TksKgyCd;
                thb1DownRow.hb1TksBmnSeqNo = _naviPara.TksBmnSeqNo;
                thb1DownRow.hb1TksTntSeqNo = _naviPara.TksTntSeqNo;
                thb1DownRow.hb1Yymm = row.hb1Yymm;
                thb1DownRow.hb1JyutNo = row.hb1JyutNo;
                thb1DownRow.hb1JyMeiNo = row.hb1JyMeiNo;
                thb1DownRow.hb1UrMeiNo = row.hb1UrMeiNo;
                thb1DownRow.hb1MSeiFlg = "0";
                thb1DownRow.hb1MeisaiFlg = "1";


                //***************************************
                //登録者、更新者の登録 
                //***************************************
                thb1DownRow.hb1TrkTnt = string.Empty;
                thb1DownRow.hb1TrkTntNm = string.Empty;
                thb1DownRow.hb1KsnTnt = string.Empty;
                thb1DownRow.hb1KsnTntNm = string.Empty;

                //登録担当者が空かつ更新者が空でない場合 
                if (string.IsNullOrEmpty(row.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(row.hb1KsnTntNm.Trim()))
                {
                    //登録者、更新者両方入れる 
                    //登録者 
                    thb1DownRow.hb1TrkTnt = _naviPara.EsqId.Trim();
                    //登録者名 
                    thb1DownRow.hb1TrkTntNm = _naviPara.Name.Trim();
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviPara.EsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviPara.Name.Trim();
                }
                //登録者が空の場合 
                else if (string.IsNullOrEmpty(row.hb1TrkTntNm.Trim()))
                {
                    //登録者のみを入れる 
                    //登録者 
                    thb1DownRow.hb1TrkTnt = _naviPara.EsqId.Trim();
                    //登録者名 
                    thb1DownRow.hb1TrkTntNm = _naviPara.Name.Trim();
                    //更新者のみを入れる 
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviPara.EsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviPara.Name.Trim();
                }
                else
                {
                    //更新者のみを入れる 
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviPara.EsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviPara.Name.Trim();
                }



                thb1DownRow.hb1TouFlg = row.hb1TouFlg;
                //thb1DownRow.hb1TouFlg = "0";
                dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

                dsDetail.THB1DOWN.Merge(dtThb1Down);


                //*********************************************
                //THB2KMEIの登録データ編集 
                //*********************************************
                //int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
                object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = "DtlKmn";//TODO
                addRow.hb2UpdTnt = _naviPara.EsqId;
                addRow.hb2EgCd = _naviPara.Egcd;
                addRow.hb2TksKgyCd = _naviPara.TksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviPara.TksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviPara.TksTntSeqNo;
                addRow.hb2Yymm = row.hb1Yymm;
                addRow.hb2JyutNo = row.hb1JyutNo;
                addRow.hb2JyMeiNo = row.hb1JyMeiNo;
                addRow.hb2UrMeiNo = row.hb1UrMeiNo;
                // TODO：費目コードは必要？ 
                addRow.hb2HimkCd = row.hb1HimkCd;

                addRow.hb2Renbn = (addCnt + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                //合計金額 
                addRow.hb2SeiGak = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_GOUKEI].Value.ToString());
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                addRow.hb2Date1 = " ";
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = " ";
                addRow.hb2Kbn2 = " ";
                addRow.hb2Kbn3 = " ";

                //部門コード 
                cellValue = CmbSeikyusakiBumon.SelectedValue;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }
                addRow.hb2Code2 = " ";
                addRow.hb2Code3 = " ";
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";

                //費目名 
                addRow.hb2Name1 = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_HIMOKU].Value.ToString();
                //期間 
                cellValue = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_KIKAN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name2 = " ";
                }
                //品名２ 
                cellValue = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_HINMOKU2].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name3 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name3 = " ";
                }
                //品名３ 
                cellValue = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_HINMOKU3].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name4 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name4 = " ";
                }
                //請求先部門 
                cellValue = CmbSeikyusakiBumon.Text;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name5 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name5 = " ";
                }
                //請求年月 

                cellValue = txtSeikyuYyyymm.Text.ToString().Replace("/", "");
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name6 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name6 = " ";
                }
                addRow.hb2Name7 = " ";
                //品名１ 
                addRow.hb2Name8 = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_HINMOKU1].Value.ToString();

                //費目名 
                addRow.hb2Name9 = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_HIMOKU].Value.ToString();
                //期間 
                cellValue = spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_KIKAN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name10 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name10 = " ";
                }

                string naiyo = detailDisp.SetJuchuValue_naiyo(row.hb1GyomKbn, row);
                if (naiyo.Length >= 50)
                {
                    //内容(1) 
                    addRow.hb2Name11 = naiyo.Substring(0, 50);
                    if (naiyo.Length >= 100)
                    {
                        //内容(2) 
                        addRow.hb2Name12 = naiyo.Substring(50, 50);
                        if (row.hb1HimkNmKJ.Length >= 150)
                        {
                            //内容(3) 
                            addRow.hb2Name13 = naiyo.Substring(100, 50);
                            //内容(4) 
                            addRow.hb2Name14 = naiyo.Substring(150);
                        }
                        else
                        {
                            //内容(3) 
                            addRow.hb2Name13 = naiyo.Substring(100);
                            //内容(4) 
                            addRow.hb2Name14 = " ";
                        }

                    }
                    else
                    {
                        //内容(2) 
                        addRow.hb2Name12 = naiyo.Substring(50);
                        //内容(3) 
                        addRow.hb2Name13 = " ";
                        //内容(4) 
                        addRow.hb2Name14 = " ";
                    }
                }
                else
                {
                    //内容(1) 
                    addRow.hb2Name11 = naiyo;
                    //内容(2) 
                    addRow.hb2Name12 = " ";
                    //内容(3) 
                    addRow.hb2Name13 = " ";
                    //内容(4) 
                    addRow.hb2Name14 = " ";
                }
                //備考 
                cellValue = " ";
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name15 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name15 = " ";
                }

                //金額(合計金額とイコール) 
                addRow.hb2Kngk1 = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_GOUKEI].Value.ToString());
                //消費税額(合計消費税額とイコール) 
                addRow.hb2Kngk2 = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_SYOUHI].Value.ToString());
                //合計消費税額 
                addRow.hb2Kngk3 = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[addCnt, SPDCOL_SYOUHI].Value.ToString());

                addRow.hb2Ritu1 = 0M;
                addRow.hb2Ritu2 = 0M;

                addRow.hb2Sonota1 = " ";
                addRow.hb2Sonota2 = " ";
                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";
                addRow.hb2BunFlg = " ";

                addRow.hb2MeihnFlg = " ";
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
                dsDetail.THB2KMEI.Merge(dtThb2Kmei);

                addCnt++;

                //更新日付最大値の判定 
                if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                {
                    maxUpdDate = row.hb1TimStmp;
                }

                dsDetail.AcceptChanges();
                returnList.Add(dsDetail);

            }

            retNavi.EsqId = _naviPara.EsqId;
            retNavi.DsDetailList = returnList;
            retNavi.LastUpdate = maxUpdDate;

            return retNavi;
        }

        /// <summary>
        /// デフォルトで表示する請求先部門を取得する 
        /// </summary>
        /// <returns></returns>
        private string SetBumonValue()
        {
            // 変数初期化 

            string result = string.Empty;
            string kenNm = string.Empty;

            //選択行数文確認を行う 
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviPara.DataRowKmn)
            {
                // 件名から【xxx】を抜き出すため存在チェック 
                if (row.hb1KKNameKJ.IndexOf('【') >= 0 && row.hb1KKNameKJ.IndexOf('】') >= 0)
                {
                    // それぞれの文字位置を取得 
                    int tmp_start = row.hb1KKNameKJ.IndexOf('【');
                    int tmp_end = row.hb1KKNameKJ.IndexOf('】');
                    if (tmp_start < tmp_end)
                    {
                        // 抜き出す文字数 
                        int moji = tmp_end - tmp_start;
                        // 抜き出す 
                        kenNm = row.hb1KKNameKJ.Substring(tmp_start, moji + 1);

                        // 宛先マスタの比較項目に一致するかチェック 
                        if (_htAtesaki.ContainsKey(kenNm))
                        {
                            //resultが空なら、resultに格納 
                            if (result.Equals(string.Empty))
                            {
                                // 一致した請求先部門を取得 
                                result = (string)_htAtesaki[kenNm];
                            }
                            //resultがあった場合、比較を実行 
                            //異なる場合はresultを空にして処理終了 
                            else if (!result.Equals((string)_htAtesaki[kenNm]))
                            {
                                result = string.Empty;
                                return result;
                            }
                        }
                        //見つからなかった場合は処理終了 
                        else
                        {
                            result = string.Empty;
                            return result;
                        }
                    }
                    //位置が変な時は処理終了 
                    else
                    {
                        result = string.Empty;
                        return result;
                    }
                }
                //見つからなかった場合は処理終了 
                else
                {
                    result = string.Empty;
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// デフォルトで表示する請求年月を取得する 
        /// </summary>
        /// <returns></returns>
        private string SetYYmmValue()
        {
            // 変数初期化 

            string result = string.Empty;
            string kenNm = string.Empty;

            //選択行数文確認を行う 
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviPara.DataRowKmn)
            {
                if(result.Equals(string.Empty))
                {
                    result = row.hb1Yymm;
                }
                else if (!result.Equals(row.hb1Yymm))
                {
                    result = string.Empty;
                    return result;
                }
            }
            return result;
        }
        #endregion        
    }
}

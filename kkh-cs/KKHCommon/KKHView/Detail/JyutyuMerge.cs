using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// 受注統合画面 
    /// </summary>
    public partial class JyutyuMerge : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region メンバ変数
        KKHNaviParameter _naviParameterIn = new KKHNaviParameter();
        KKHNaviParameter _naviParameterOut = new KKHNaviParameter();
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public JyutyuMerge()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント
        private void JyutyuMerge_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameterIn = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        private void JyutyuMerge_Shown(object sender, EventArgs e)
        {
            InitializeControl();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (OkClick() == false)
            //{
            //    return;
            //}
            _naviParameterOut.IntValue1 = int.Parse(KKHUtility.KKHUtility.ToString(cmbTouData.SelectedValue));
            Navigator.Backward(this, _naviParameterOut, null, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }
        #endregion イベント

        private void InitializeControl()
        {
            //統合先選択コンボボックス 
            Isid.KKH.Common.KKHSchema.Detail.ComboDataTable dtCombo = new Isid.KKH.Common.KKHSchema.Detail.ComboDataTable();
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviParameterIn.DsDetail.JyutyuData.Rows)
            {
                Isid.KKH.Common.KKHSchema.Detail.ComboRow addRow = dtCombo.NewComboRow();
                string kenmei = row.hb1KKNameKJ;
                string kingaku = row.hb1SeiGak.ToString("#,0");
                addRow.text = kenmei + kingaku.PadLeft(15 - kingaku.Length, ' ');
                addRow.value = row.rowNum;

                dtCombo.AddComboRow(addRow);
            }

            cmbTouData.DisplayMember = dtCombo.textColumn.ColumnName;
            cmbTouData.ValueMember = dtCombo.valueColumn.ColumnName;
            cmbTouData.DataSource = dtCombo;
        }

        /// <summary>
        /// OKボタンクリック時の処理 
        /// </summary>
        /// <returns></returns>
        protected virtual bool OkClick()
        {
            //サービスパラメータ(統合元データリスト) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouMoto = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouMoto = dsTougouMoto.THB1DOWN;
            //サービスパラメータ(統合先データ) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouSaki = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouSaki = dsTougouSaki.THB1DOWN;
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouSaki = dtTougouSaki.NewTHB1DOWNRow(true);
            //サービスパラメータ(更新日付最大値－排他チェック用) 
            DateTime maxUpdDate = new DateTime();

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in _naviParameterIn.DsDetail.JyutyuData.Rows)
            {
                //統合元データの編集 
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouMoto = dtTougouMoto.NewTHB1DOWNRow();
                rowTougouMoto.hb1UpdTnt = _naviParameterIn.strEsqId;
                rowTougouMoto.hb1UpdApl = _naviParameterIn.AplId;
                rowTougouMoto.hb1EgCd = row.hb1EgCd;
                rowTougouMoto.hb1TksKgyCd = row.hb1TksKgyCd;
                rowTougouMoto.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                rowTougouMoto.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                rowTougouMoto.hb1Yymm = row.hb1Yymm;
                rowTougouMoto.hb1JyutNo = row.hb1JyutNo;
                rowTougouMoto.hb1JyMeiNo = row.hb1JyMeiNo;
                rowTougouMoto.hb1UrMeiNo = row.hb1UrMeiNo;
                rowTougouMoto.hb1TouFlg = row.hb1TouFlg.PadRight(1, ' ');

                dtTougouMoto.AddTHB1DOWNRow(rowTougouMoto);

                //統合先データの編集 
                if (row.rowNum == int.Parse(KKHUtility.KKHUtility.ToString(cmbTouData.SelectedValue)))
                {

                    //row.hb1TimStmp = new DateTime();
                    //更新プログラム 
                    rowTougouSaki.hb1UpdApl = _naviParameterIn.AplId; 
                    //更新担当者 
                    rowTougouSaki.hb1UpdTnt = _naviParameterIn.strEsqId;
                    //営業所（扱）コード 
                    rowTougouSaki.hb1AtuEgCd = row.hb1EgCd;
                    //営業所（取）コード 
                    rowTougouSaki.hb1EgCd = row.hb1EgCd;
                    //得意先企業コード 
                    rowTougouSaki.hb1TksKgyCd = row.hb1TksKgyCd;
                    //得意先部門SEQNO 
                    rowTougouSaki.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                    //得意先担当SEQNO 
                    rowTougouSaki.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                    //受注No 
                    rowTougouSaki.hb1JyutNo = row.hb1JyutNo;
                    //受注明細No 
                    rowTougouSaki.hb1JyMeiNo = row.hb1JyMeiNo;
                    //売上明細No 
                    rowTougouSaki.hb1UrMeiNo = row.hb1UrMeiNo;
                    //請求原票No 
                    rowTougouSaki.hb1GpyNo = " ";
                    //ページNo 
                    rowTougouSaki.hb1GpyoPag = " ";
                    //請求No 
                    rowTougouSaki.hb1SeiNo = " ";
                    //費目コード 
                    rowTougouSaki.hb1HimkCd = row.hb1HimkCd;
                    //統合フラグ 
                    rowTougouSaki.hb1TouFlg = "1";
                    //年月 
                    rowTougouSaki.hb1Yymm = row.hb1Yymm;
                    //業務区分 
                    rowTougouSaki.hb1GyomKbn = row.hb1GyomKbn;
                    //マス正味区分 
                    rowTougouSaki.hb1MsKbn = row.hb1MsKbn;
                    //タイムスポット区分 
                    rowTougouSaki.hb1TmspKbn = row.hb1TmspKbn;
                    //国際区分 
                    rowTougouSaki.hb1KokKbn = row.hb1KokKbn;
                    //請求区分 
                    rowTougouSaki.hb1SeiKbn = row.hb1SeiKbn;
                    //商品No 
                    rowTougouSaki.hb1SyoNo = row.hb1SyoNo;
                    //件名(漢字) 
                    rowTougouSaki.hb1KKNameKJ = row.hb1KKNameKJ;
                    //営業画面タイプ 
                    rowTougouSaki.hb1EgGamenType = row.hb1EgGamenType;
                    //企画・製版区分
                    rowTougouSaki.hb1KkakShanKbn = row.hb1KkakShanKbn;
                    //取料金 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求単価 
                    rowTougouSaki.hb1SeiTnka = 0.0M;
                    //請求金額 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引率 
                    rowTougouSaki.hb1NeviRitu = row.hb1NeviRitu;
                    //値引額 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税区分 
                    rowTougouSaki.hb1SzeiKbn = row.hb1SzeiKbn;
                    //消費税率 
                    rowTougouSaki.hb1SzeiRitu = row.hb1SzeiRitu;
                    //消費税額 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                    //費目名(漢字) 
                    rowTougouSaki.hb1HimkNmKJ = row.hb1HimkNmKJ;
                    //費目名(カナ) 
                    rowTougouSaki.hb1HimkNmKN = " ";
                    //統合先受注No 
                    rowTougouSaki.hb1TJyutNo = " ";
                    //統合先受注明細No 
                    rowTougouSaki.hb1TJyMeiNo = " ";
                    //統合先売上明細No 
                    rowTougouSaki.hb1TUrMeiNo = " ";
                    //未請求フラグ 
                    rowTougouSaki.hb1MSeiFlg = " ";
                    //変更前年月 
                    rowTougouSaki.hb1YymmOld = " ";
                    //フィールド１ 
                    rowTougouSaki.hb1Field1 = row.hb1Field1;
                    //フィールド２ 
                    rowTougouSaki.hb1Field2 = row.hb1Field2;
                    //フィールド３ 
                    rowTougouSaki.hb1Field3 = row.hb1Field3;
                    //フィールド４ 
                    rowTougouSaki.hb1Field4 = row.hb1Field4;
                    //フィールド５ 
                    rowTougouSaki.hb1Field5 = row.hb1Field5;
                    //フィールド６ 
                    rowTougouSaki.hb1Field6 = row.hb1Field6;
                    //フィールド７ 
                    rowTougouSaki.hb1Field7 = row.hb1Field7;
                    //フィールド８ 
                    rowTougouSaki.hb1Field8 = row.hb1Field8;
                    //フィールド９ 
                    rowTougouSaki.hb1Field9 = row.hb1Field9;
                    //フィールド１０ 
                    rowTougouSaki.hb1Field10 = row.hb1Field10;
                    //フィールド１１ 
                    rowTougouSaki.hb1Field11 = row.hb1Field11;
                    //フィールド１２ 
                    rowTougouSaki.hb1Field12 = row.hb1Field12;

                }
                else
                {
                    //取料金 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求金額 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引額 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税額 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                }


                //更新日付最大値の判定 
                if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                {
                    maxUpdDate = row.hb1TimStmp;
                }
            }

            dtTougouSaki.AddTHB1DOWNRow(rowTougouSaki);
            dsTougouSaki.THB1DOWN.Merge(dtTougouSaki);

            dsTougouMoto.THB1DOWN.Merge(dtTougouMoto);

            DetailProcessController.MergeJyutyuDataParam param = new DetailProcessController.MergeJyutyuDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsTougouSaki = dsTougouSaki;
            param.dsTougouMoto = dsTougouMoto;
            param.maxUpdDate = maxUpdDate;

            DetailProcessController processController = DetailProcessController.GetInstance();
            MergeJyutyuDataServiceResult result = processController.MergeJyutyuData(param);
            if (result.HasError == true)
            {
                //MessageBox.Show("統合に失敗しました。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
    }
}


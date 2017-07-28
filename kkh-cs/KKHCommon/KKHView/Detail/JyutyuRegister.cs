using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// 新規登録ダイアログ(ベース) 
    /// </summary>
    public partial class JyutyuRegister : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region 定数
        /// <summary>
        /// 件名最大文字数
        /// </summary>
        protected const int SUBJECT_MAX_LENGTH = 60;
        #endregion 定数

        #region メンバ変数
        //Inパラメータ用NaviParameter 
        private KKHNaviParameter _naviParameterIn = new KKHNaviParameter();
        //Outパラメータ用NaviParameter 
        private KKHNaviParameter _naviParameterOut = new KKHNaviParameter();


        #endregion メンバ変数

  
        #region プロパティ

        /// <summary>
        /// Inパラメータ用NaviParameter を取得します。 
        /// </summary>
        public KKHNaviParameter NaviParameterIn
        {
            get { return _naviParameterIn; }
        }

        #endregion プロパティ

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public JyutyuRegister()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region イベント

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JyutyuRegister_Shown(object sender, EventArgs e)
        {
            if (DesignMode == true) { return; }

            InitializeControl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenmei_KeyPress(object sender, KeyPressEventArgs e)
        {
            //入力禁止文字の判定 
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGymKbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void JyutyuRegister_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameterIn = (KKHNaviParameter)arg.NaviParameter;
            }

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeRegisterJyutyu())
            {
                return;
            }

            if (RegisterJyutyuData() == false)
            {
                return;
            }

            //MessageBox.Show("処理が終了しました。", "新規登録", MessageBoxButtons.OK);//TODO
            //MessageUtility.ShowMessageBox(MessageCode.HB_I0007, null, "新規登録", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0015, null, "新規登録", MessageBoxButtons.OK);
            Navigator.Backward(this, _naviParameterOut, null, true);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoJpn_CheckedChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKenmei_TextChanged(object sender, EventArgs e)
        {
            // 件名のバイト数が60より大きい場合はエラー
            if (KKHUtility.KKHUtility.GetByteCount(txtKenmei.Text) > SUBJECT_MAX_LENGTH)
            {
                txtKenmei.Text = txtKenmei.Text.Substring(0, txtKenmei.Text.Length - 1);
                //MessageUtility.ShowMessageBox(MessageCode.HB_W0135, new String[] { SUBJECT_MAX_LENGTH.ToString() }, "新規登録", MessageBoxButtons.OK);
                //this.txtKenmei.Focus();
                txtKenmei.Select(txtKenmei.Text.Length, 0);
                return;
            }
        }

        #endregion イベント

        #region 得意先毎の実装

        /// <summary>
        /// 新規登録サービスパラメータを編集する 
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            DetailProcessController.RegisterJyutyuDataParam param = new DetailProcessController.RegisterJyutyuDataParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row = dtThb1Down.NewTHB1DOWNRow();

            //row.hb1TimStmp = new DateTime();
            //更新プログラム 
            row.hb1UpdApl = _naviParameterIn.AplId;
            //更新担当者 
            row.hb1UpdTnt = _naviParameterIn.strEsqId;
            //営業所（扱）コード 
            row.hb1AtuEgCd = _naviParameterIn.strEgcd;
            //営業所（取）コード 
            row.hb1EgCd = _naviParameterIn.strEgcd;
            //得意先企業コード 
            row.hb1TksKgyCd = _naviParameterIn.strTksKgyCd;
            //得意先部門SEQNO 
            row.hb1TksBmnSeqNo = _naviParameterIn.strTksBmnSeqNo;
            //得意先担当SEQNO 
            row.hb1TksTntSeqNo = _naviParameterIn.strTksTntSeqNo;
            //受注No 
            row.hb1JyutNo = "";//採番はJAVAで実装 
            //受注明細No 
            row.hb1JyMeiNo = "001";
            //売上明細No 
            row.hb1UrMeiNo = "001";
            //請求原票No 
            row.hb1GpyNo = " ";
            //ページNo 
            row.hb1GpyoPag = " ";
            //請求No 
            row.hb1SeiNo = " ";
            //費目コード 
            row.hb1HimkCd = " ";
            //統合フラグ 
            row.hb1TouFlg = " ";
            //年月 
            row.hb1Yymm = txtYymm.Text;
            //業務区分 
            string gymKbn = (string)cmbGymKbn.SelectedValue;
            row.hb1GyomKbn = gymKbn;
            //マス正味区分 
            row.hb1MsKbn = " ";
            //タイムスポット区分 
            string tsKbn = " ";
            if (gymKbn == KKHSystemConst.GyomKbn.TVTime)
            {
                tsKbn = "1";
            }
            else if (gymKbn == KKHSystemConst.GyomKbn.TVSpot)
            {
                tsKbn = "2";
            }
            else if (pnlTmSp.Visible == true)
            {
                if (rdoTime.Checked == true)
                {
                    tsKbn = "1";
                }
                else if (rdoSpot.Checked == true)
                {
                    tsKbn = "2";
                }
            }
            else
            {
                tsKbn = " ";
            }
            row.hb1TmspKbn = tsKbn;
            //国際区分 
            string koksaiKbn = " ";
            if (rdoJpn.Checked == true)
            {
                koksaiKbn = "0";
            }
            else if (rdoKgi.Checked == true)
            {
                koksaiKbn = "1";
            }
            row.hb1KokKbn = koksaiKbn;
            //請求区分 
            row.hb1SeiKbn = GetSeiKbn(gymKbn, tsKbn, koksaiKbn);
            //商品No 
            row.hb1SyoNo = " ";
            //件名(漢字) 
            row.hb1KKNameKJ = txtKenmei.Text;
            //営業画面タイプ 
            row.hb1EgGamenType = " ";
            //企画・製版区分
            row.hb1KkakShanKbn = " ";
            //取料金 
            row.hb1ToriGak = 0.0M;
            //請求単価 
            row.hb1SeiTnka = 0.0M;
            //請求金額 
            row.hb1SeiGak = 0.0M;
            //値引率 
            row.hb1NeviRitu = 0.0M;
            //値引額 
            row.hb1NeviGak = 0.0M;
            //消費税区分 
            row.hb1SzeiKbn = " ";
            //消費税率 
            row.hb1SzeiRitu = 0.0M;
            //消費税額 
            row.hb1SzeiGak = 0.0M;
            //費目名(漢字) 
            row.hb1HimkNmKJ = " ";
            //費目名(カナ) 
            row.hb1HimkNmKN = " ";
            //統合先受注No 
            row.hb1TJyutNo = " ";
            //統合先受注明細No 
            row.hb1TJyMeiNo = " ";
            //統合先売上明細No 
            row.hb1TUrMeiNo = " ";
            //未請求フラグ 
            row.hb1MSeiFlg = " ";
            //変更前年月 
            row.hb1YymmOld = " ";
            //フィールド１ 
            row.hb1Field1 = " ";
            //フィールド２ 
            row.hb1Field2 = " ";
            //フィールド３ 
            row.hb1Field3 = " ";
            //フィールド４ 
            row.hb1Field4 = " ";
            //フィールド５ 
            row.hb1Field5 = " ";
            //フィールド６ 
            row.hb1Field6 = " ";
            //フィールド７ 
            row.hb1Field7 = " ";
            //フィールド８ 
            row.hb1Field8 = " ";
            //フィールド９ 
            row.hb1Field9 = " ";
            //フィールド１０ 
            row.hb1Field10 = " ";
            //フィールド１１ 
            row.hb1Field11 = " ";
            //フィールド１２ 
            row.hb1Field12 = " ";

            dtThb1Down.AddTHB1DOWNRow(row);
            dsDetail.THB1DOWN.Merge(dtThb1Down);
            param.dsDetail = dsDetail;

            return param;
        }

        /// <summary>
        /// 受注新規登録前のチェック処理 
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        protected virtual bool CheckBeforeRegisterJyutyu()
        {
            //共通チェックを追加 
            if (KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0026, null, "新規登録", MessageBoxButtons.OK);
                cmbGymKbn.Focus();
                return false;
            }

            if (txtKenmei.Text == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0029, null,  "新規登録", MessageBoxButtons.OK);
                txtKenmei.Focus();
                return false;
            }
            return true;
        }

        #endregion 得意先毎の実装

        /// <summary>
        /// コントロールの初期表示 
        /// </summary>
        private void InitializeControl()
        {
            //*********************************
            //年月 
            //*********************************
            txtYymm.Text = _naviParameterIn.StrYymm;

            //*********************************
            //業務区分コンボボックス 
            //*********************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult result = processController.FindCommonCodeMasterByCond(KKHSecurityInfo.GetInstance().UserEsqId, "87", _naviParameterIn.strDate);

            KKHSchema.Common.RcmnMeu29CCDataTable dsGyomKbn = new KKHSchema.Common.RcmnMeu29CCDataTable();
            dsGyomKbn.Merge(result.CommonDataSet.RcmnMeu29CC);
            dsGyomKbn.AcceptChanges();

            cmbGymKbn.DisplayMember = dsGyomKbn.naiyJColumn.ColumnName;
            cmbGymKbn.ValueMember = dsGyomKbn.kyCdColumn.ColumnName;
            cmbGymKbn.DataSource = dsGyomKbn;

            cmbGymKbn.SelectedValue = _naviParameterIn.GyomKbn;

        }

        /// <summary>
        /// コントロールの表示／非表示変更 
        /// </summary>
        private void ChangeVisible()
        {
            if ((KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "11030" 
                || KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == "11050")
                && rdoJpn.Checked == true)
            {
                pnlTmSp.Visible = true;
            }
            else
            {
                pnlTmSp.Visible = false;
            }
        }

        /// <summary>
        /// 新規登録処理 
        /// </summary>
        /// <returns></returns>
        private bool RegisterJyutyuData()
        {
            //新規登録処理のパラメータ編集 
            DetailProcessController.RegisterJyutyuDataParam param = EditRegisterJyutyuDataParam();

            DetailProcessController processController = DetailProcessController.GetInstance();
            RegisterJyutyuDataServiceResult result = processController.RegisterJyutyuData(param);

            if (result.HasError == true)
            {
                if (result.MessageCode == "UNIQUE-E0002")//TODO
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0054, null, "新規登録", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "新規登録", MessageBoxButtons.OK);
                }
                return false;
            }

            //登録した受注ダウンロードデータを返却する 
            _naviParameterOut.DsDetail = result.DsDetail;
            return true;
        }

        /// <summary>
        /// 請求区分を決定する 
        /// </summary>
        /// <param name="gyomKbn">業務区分</param>
        /// <param name="tsKbn">タイム／スポット区分</param>
        /// <param name="koksaiKbn">国際区分</param>
        /// <returns></returns>
        public string GetSeiKbn(string gyomKbn, string tsKbn, string koksaiKbn)
        {
            string seiKbn = "";

            if (koksaiKbn == KKHSystemConst.KoksaiKbn.Kokusai)
            {
                if (gyomKbn == KKHSystemConst.GyomKbn.Shinbun
                    || gyomKbn == KKHSystemConst.GyomKbn.Zashi
                    || gyomKbn == KKHSystemConst.GyomKbn.Radio
                    || gyomKbn == KKHSystemConst.GyomKbn.TVTime
                    || gyomKbn == KKHSystemConst.GyomKbn.TVSpot
                    || gyomKbn == KKHSystemConst.GyomKbn.EiseiM
                    || gyomKbn == KKHSystemConst.GyomKbn.InteractiveM
                    )
                {
                    //国際マス 
                    seiKbn = KKHSystemConst.SeiKbn.KMas;
                }
                else
                {
                    //国際(諸作業) 
                    seiKbn = KKHSystemConst.SeiKbn.KWorks;
                }
            }
            else
            {
                if (gyomKbn == KKHSystemConst.GyomKbn.Shinbun)
                {
                    //新聞 
                    seiKbn = KKHSystemConst.SeiKbn.NewsPaper;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.Zashi)
                {
                    //雑誌 
                    seiKbn = KKHSystemConst.SeiKbn.Magazine;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.TVSpot
                    || (gyomKbn == KKHSystemConst.GyomKbn.Radio && tsKbn == KKHSystemConst.TimeSpotKbn.Spot)
                    || (gyomKbn == KKHSystemConst.GyomKbn.EiseiM && tsKbn == KKHSystemConst.TimeSpotKbn.Spot)
                )
                {
                    //スポット 
                    seiKbn = KKHSystemConst.SeiKbn.Spot;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.TVTime
                    || (gyomKbn == KKHSystemConst.GyomKbn.Radio && tsKbn == KKHSystemConst.TimeSpotKbn.Time)
                    || (gyomKbn == KKHSystemConst.GyomKbn.EiseiM && tsKbn == KKHSystemConst.TimeSpotKbn.Time)
                )
                {
                    //タイム 
                    seiKbn = KKHSystemConst.SeiKbn.Time;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.InteractiveM)
                {
                    //インタラクティブメディア 
                    seiKbn = KKHSystemConst.SeiKbn.IC;
                }
                else if (gyomKbn == KKHSystemConst.GyomKbn.OohM)
                {
                    //交通広告 
                    seiKbn = KKHSystemConst.SeiKbn.Ooh;
                }
                else
                {
                    //諸作業 
                    seiKbn = KKHSystemConst.SeiKbn.Works;
                }
            }

            return seiKbn;
        }
    }
}


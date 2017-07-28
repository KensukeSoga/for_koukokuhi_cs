using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
//using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.History;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox;

namespace Isid.KKH.Common.KKHView.History
{
    public partial class HisDownlodData : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region "メンバ変数"
        /// <summary>
        /// ナビパラメーター 
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 業務区分 
        /// </summary>
        KKHSchema.Common.RcmnMeu29CCDataTable GyoumKbn = new Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable();

        #endregion "メンバ変数"

        #region "コンストラクタ"

        /// <summary>
        /// 
        /// </summary>
        public HisDownlodData()
        {
            InitializeComponent();
        }
        #endregion "コンストラクタ"

        #region "イベント"


        /// <summary>
        /// 画面遷移時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void HisDownlodData_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HisDownlodData_Load(object sender, EventArgs e)
        {
            //初期データ編集 
            EditControl();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 表示ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {

            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 年月の取得 
            string yyyyMm = orgYyyyMm.Value;

            HistoryProcessController.findHisJyutDownparam param = new HistoryProcessController.findHisJyutDownparam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yyyyMm;
            HistoryProcessController processController = HistoryProcessController.GetInstance();
            FindHisByCondServiceResult result = processController.findHisJyutDown(param);

            //エラーの場合
            if (result.HasError)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();
                return;
            }
            //検索結果が0件の場合 
            if (result.dsDataSet.jyutyuDownLoad.Rows.Count == 0)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                // MessageBox.Show("この月の請求原票を取り込んでいません。");
                MessageUtility.ShowMessageBox(MessageCode.HB_W0096, null, "受注履歴", MessageBoxButtons.OK);
            }

            HisDs.jyutyuDownLoadRow[] resultRow = (HisDs.jyutyuDownLoadRow[])result.dsDataSet.jyutyuDownLoad.Select("", "");

            //データセット 
            //HisDs ds = new HisDs();

            String baseDate = "";    //処理対象 
            String wk = "";         //処理対象から抜き出した文字  
            String wk2 = "";        //処理済 
            String wk3 = "";     //処理結果 

            //初期化する 
            ds.Clear();

            foreach (HisDs.jyutyuDownLoadRow row in resultRow)
            {
                HisDs.jyutyuDownLoadRow addrow = ds.jyutyuDownLoad.NewjyutyuDownLoadRow();

                //出力区分 
                if (row.SyuKbn.Equals("1"))
                {
                    addrow.SyuKbn = "新規";
                }
                else if (row.SyuKbn.Equals("2"))
                {
                    addrow.SyuKbn = "再出力";
                }

                //原票出力日時 
                addrow.GpsyuTimStmp = YymmddSet(row.GpsyuTimStmp.Trim());
                //業務区分 
                addrow.GyomKbn = gyomkbn(row.GyomKbn.Trim());
                //請求年月 
                baseDate = row.Yymm.ToString().Trim();
                wk3 = "";

                for (int i = 0; i < baseDate.Length; i++) 
                {
                    //請求年月を１文字ずつ取得する 
                    wk = baseDate.Substring(i, 1);
                    //[処理対象]が","かつ""かつ" "かつ6文字ではない場合、その値を[処理済]にセット 
                    if (wk != "," && wk != "" && wk != " " && wk2.Length != 6)
                    {
                        wk2 += wk;
                    }
                    
                    //[処理済]が6文字の場合 
                    if (wk2.Length == 6)
                    {
                        //[処理結果]が空白の場合  
                        if (wk3 == "")
                        {
                            wk3 = wk2.Substring(0, 4) + "/" + wk2.Substring(4, 2);
                        }
                        else
                        {
                            wk3 += "," + wk2.Substring(0, 4) + "/" + wk2.Substring(4, 2);
                        }
                        //[処理済]を初期化 
                        wk2 = "";
                    }
                }

                //処理結果を請求年月にセット 
                addrow.Yymm = wk3;

                //担当者コード
                addrow.TntCd = row.TntCd;
                //担当者名
                addrow.TntNm = row.TntNm;

                ds.jyutyuDownLoad.AddjyutyuDownLoadRow(addrow);
            }

            //ローディング表示終了 
            base.CloseLoadingDialog();

            //データ表示
            //hisMain_Sheet1.DataSource = ds.jyutyuDownLoad;
            ds.jyutyuDownLoad.AcceptChanges();
            //請求年月までを固定列にする
            //hisMain_Sheet1.FrozenColumnCount = 3;

            //コントロールを未選択状態にする 
            this.ActiveControl = null;


        }

        /// <summary>
        /// 戻るボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRtn_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.HisDownLoad, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
        }
        #endregion "イベント"

        #region "メソッド"

        /// <summary>
        /// 営業日取得
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// 各コントロール編集
        /// </summary>
        private void EditControl()
        {
            //年月の取得
            string hostDt = getHostDate();
            
            string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;

                if (hostDt != "")
                {
                    hostDt = hostDt.Trim().Replace("/", "");
                    if (hostDt.Trim().Length >= 6)
                    {
                        orgYyyyMm.Value = hostDt.Substring(0, 6);
                    }
                    else
                    {
                        orgYyyyMm.Value = hostDt;
                    }
                    orgYyyyMm.cmbYM_SetDate();
                }

            tslName.Text = _naviParam.strName;
            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslDate.Text = _naviParam.strDate;

            //**************************
            //業務区分取得
            //**************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult result
                = processController.FindCommonCodeMasterByCond(KKHSecurityInfo.GetInstance().UserEsqId, "87", hostDt);

            if (result.HasError)
            {
                return;
            }
            
            GyoumKbn.Merge(result.CommonDataSet.RcmnMeu29CC);

        }

        /// <summary>
        /// 年月、時間のセット
        /// </summary>
        /// <param name="yymmdd"></param>
        /// <returns></returns>
        private string YymmddSet(string yymmdd)
        {
            if (yymmdd.Length != 14) { return string.Empty; }

            string afterYymmdd = yymmdd.Substring(0, 4) + "/" +
                                 yymmdd.Substring(4, 2) + "/" +
                                 yymmdd.Substring(6, 2) + " " +
                                 yymmdd.Substring(8, 2) + ":" +
                                 yymmdd.Substring(10, 2) + ":" +
                                 yymmdd.Substring(12, 2);

            return afterYymmdd;
        }

        /// <summary>
        /// 業務区分名称割り振り
        /// </summary>
        /// <param name="gycd"></param>
        /// <returns></returns>
        private string gyomkbn(string gycd)
        {
            //業務区分コード
            string[] gyomNm = gycd.Split(',');
            //業務区分名
            string gyCdName = string.Empty;

            for (int i = 0; i < gyomNm.Length; i++)
            {
                foreach (KKHSchema.Common.RcmnMeu29CCRow row in GyoumKbn)
                {
                    //業務区分コードが一致したら業務名を入れる。
                    if (gyomNm[i].Equals(row.kyCd.Trim()))
                    {
                        gyCdName = gyCdName + row.naiyJ ;
                        if (i != gyomNm.Length - 1)
                        {
                            gyCdName = gyCdName + ",";
                        }

                        break;
                    }
                }
            }
            return gyCdName;
        }

        #endregion "メソッド"
    }
}


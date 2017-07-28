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
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.History;
using Isid.KKH.Common.KKHSchema;
namespace Isid.KKH.Lion.View.History
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
        //private KKHSystemConst.GyomKbn gyomkbn = new KKHSystemConst.GyomKbn();

        #endregion "メンバ変数"

        #region "コンストラクタ"
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
        }

        /// <summary>
        /// 表示ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {

            string stry = txtYyyy.Value.ToString();
            string strm = "";
            if (txtMm.Value.ToString().Length == 1)
            {
                strm = "0" + txtMm.Value.ToString();
            }
            else
            {
                strm = txtMm.Value.ToString();
            }

            //年月のセット
            string yearmon = stry + strm;

            HistoryProcessController.findHisJyutDownparam param = new HistoryProcessController.findHisJyutDownparam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;
            HistoryProcessController processController = HistoryProcessController.GetInstance();
            FindHisByCondServiceResult result = processController.findHisJyutDown(param);

            //エラーの場合
            if (result.HasError)
            {

            }
            //検索結果が0件の場合
            if (result.dsDataSet.jyutyuDownLoad.Rows.Count == 0)
            {
                // MessageBox.Show("この月の請求原票を取り込んでいません。");
                MessageUtility.ShowMessageBox(MessageCode.HB_W0096, null, "受注履歴", MessageBoxButtons.OK);
            }

            HisDs.jyutyuDownLoadRow[] resultRow = (HisDs.jyutyuDownLoadRow[])result.dsDataSet.jyutyuDownLoad.Select("", "");

            //データセット
            HisDs ds = new HisDs();


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
                if (row.Yymm.Trim().Length == 6)
                {
                    addrow.Yymm = row.Yymm.Trim().Substring(0, 4) + "/" + row.Yymm.Trim().Substring(4, 2);
                }
                //担当者コード
                addrow.TntCd = row.TntCd;
                //担当者名
                addrow.TntNm = row.TntNm;


                ds.jyutyuDownLoad.AddjyutyuDownLoadRow(addrow);
            }

            //データ表示
            hisMain_Sheet1.DataSource = ds.jyutyuDownLoad;

        }

        /// <summary>
        /// 戻るボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void njButton2_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
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
            string strDate = getHostDate();
            //ステータスの設定
            txtYyyy.Text = strDate.Substring(0, 4);
            txtMm.Text = strDate.Substring(4, 2);
            tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslDate.Text = _naviParam.strDate;
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

            string[] gyomNm = gycd.Split(',');
            //媒体名
            string gyCdName = string.Empty;

            for (int i = 0; i < gyomNm.Length; i++)
            {
                switch (gyomNm[i])
                {
                    case KKHSystemConst.GyomKbn.Shinbun:
                        gyCdName = gyCdName + "新聞";
                        break;
                    case KKHSystemConst.GyomKbn.Zashi:
                        gyCdName = gyCdName + "雑誌";
                        break;
                    case KKHSystemConst.GyomKbn.Radio:
                        gyCdName = gyCdName + "ラジオ";
                        break;
                    case KKHSystemConst.GyomKbn.TVTime:
                        gyCdName = gyCdName + "テレビタイム";
                        break;
                    case KKHSystemConst.GyomKbn.TVSpot:
                        gyCdName = gyCdName + "テレビスポット";
                        break;
                    case KKHSystemConst.GyomKbn.EiseiM:
                        gyCdName = gyCdName + "衛星メディア";
                        break;
                    case KKHSystemConst.GyomKbn.InteractiveM:
                        gyCdName = gyCdName + "インタラクティブメディア";
                        break;
                    case KKHSystemConst.GyomKbn.OohM:
                        gyCdName = gyCdName + "OOHメディア ";
                        break;
                    case KKHSystemConst.GyomKbn.SonotaM:
                        gyCdName = gyCdName + "その他メディア";
                        break;
                    case KKHSystemConst.GyomKbn.MPlan:
                        gyCdName = gyCdName + "メディアプランニング";
                        break;
                    case KKHSystemConst.GyomKbn.Creative:
                        gyCdName = gyCdName + "クリエーティブ";
                        break;
                    case KKHSystemConst.GyomKbn.MarkePromo:
                        gyCdName = gyCdName + "マーケティング/プロモーション";
                        break;
                    case KKHSystemConst.GyomKbn.Sports:
                        gyCdName = gyCdName + "スポーツ";
                        break;
                    case KKHSystemConst.GyomKbn.Entertainment:
                        gyCdName = gyCdName + "エンタテイメント";
                        break;
                    case KKHSystemConst.GyomKbn.SonotaC:
                        gyCdName = gyCdName + "その他コンテンツ";
                        break;
                }
                if (i != gyomNm.Length - 1)
                {
                    gyCdName = gyCdName + ",";
                }
            }

            return gyCdName;
        }

        #endregion "メソッド"

    }
}


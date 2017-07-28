using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using System.Collections;
using System.Windows.Forms;
using System.IO;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// CSVマスタデータ読み込み処理.
    /// </summary>
    /// <remarks>
    ///  修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/2/6</description>
    ///       <description>Fourm K.T</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class KKHLionReadMastFile
    {

        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "WkUpLion";

        #endregion 定数.

        #region メンバ変数.

        //保存用データセット.
        private FindCommonByCondServiceResult _dtAddrMst;     //アドレス系システムマスタ用.
        private FindCommonByCondServiceResult _dtFileMst;    //ファイル系システムマスタ用.
        private MastLion.TvCmLionDataTable _dtTvByoMst;     //TV秒数マスタ用.
        private MastLion.RdCmLionDataTable _dtRdByoMst;     //RD秒数マスタ用.

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public KKHLionReadMastFile()
        {
            _dtAddrMst = new FindCommonByCondServiceResult();
            _dtFileMst = new FindCommonByCondServiceResult();
            _dtTvByoMst = new MastLion.TvCmLionDataTable();
            _dtRdByoMst = new MastLion.RdCmLionDataTable();
        }

        #endregion コンストラクタ.

        /// <summary>
        /// テレビ秒数データCSVファイルのデータセット読込.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.TvCmLionDataTable findTvBDataCSVRead(string fp,string ym)
        {
            //スキーマ読込.
            Isid.KKH.Lion.Schema.MastLion.TvCmLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvCmLionDataTable();
            //カウント用変数宣言、初期化.
            int i = 0;
            //読み込みデータsplit用変数.
            String str;
            StreamReader sr = null;
            //ファイルが存在すれば読み込み.
            if (File.Exists(fp))
            {
                //Shift JIS　でストリームから一行ごとに最後まで読み込む.
                sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));
            }
            else
            {
                //nullを返す.
                return null;
            }

            while (null != (str = sr.ReadLine()))
            {
                //データvoを生成.
                mstdatavo.AddTvCmLionRow(mstdatavo.NewTvCmLionRow());

                //CSVの内容をsplit(タブ)
                String[] ar = str.Split(',');

                ////年月チェック.
                //if (ar[1].Equals(ym))
                //{} else
                //{
                //    mstdatavo.Clear();
                //    return mstdatavo;
                //}

                //ここからＣＳＶの内容read
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_CARDKBN] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_YEARMONTH] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_DAIRITENCD] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_BAITAIKBN] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_BANGUMICD] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_BRANDCD] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_BRANNAME] = ar[6];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_KYOKUSICD] = ar[7];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_KYOKUSINAME] = ar[8];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_NETFC] = ar[9];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_FUKENCD] = ar[10];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL1] = ar[11];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL2] = ar[12];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL3] = ar[13];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL4] = ar[14];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_GOKEI] = ar[15];
                    //総秒数.
                    if ((ar[16].Trim()).Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVCM_SOBYOSU] = 0;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVCM_SOBYOSU] = ar[16];
                    }
                    //秒数.
                    if ((ar[17].Trim()).Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVCM_BYOSU] = 0;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVCM_BYOSU] = ar[17];
                    }
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL5] = ar[18];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_VAL6] = ar[19];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_ONAIRKAISU] = ar[20];
                    mstdatavo.Rows[i][KKHLionConst.C_TVCM_DATASYORICD] = ar[21];
                }
                catch (Exception e)
                {
                    //閉じる.
                    sr.Close();
//                  //メッセージ表示.
//                  MessageUtility.ShowMessageBox(MessageCode.HB_E0019, null, "テレビ秒数", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }
            //閉じる.
            sr.Close();

            //vo戻す.
            return mstdatavo;
        }

        /// <summary>
        /// ラジオ秒数データCSVファイルのデータセット読込.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.RdCmLionDataTable findRdBDataCSVRead(string fp, string ym)
        {
            //スキーマ読込.
            Isid.KKH.Lion.Schema.MastLion.RdCmLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdCmLionDataTable();
            //カウント用変数宣言、初期化.
            int i = 0;
            //読み込みデータsplit用変数.
            String str;
            StreamReader sr = null;
            //ファイルが存在すれば読み込み.
            if (File.Exists(fp))
            {
                //Shift JIS　でストリームから一行ごとに最後まで読み込む.
                sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));
            }
            else
            {
                //nullを返す.
                return null;
            }

            while (null != (str = sr.ReadLine()))
            {
                //データvoを生成.
                mstdatavo.AddRdCmLionRow(mstdatavo.NewRdCmLionRow());

                //CSVの内容をsplit
                String[] ar = str.Split(',');

                ////年月チェック.
                //if (ar[1].Equals(ym))
                //{ }
                //else
                //{
                //    mstdatavo.Clear();
                //    return mstdatavo;
                //}

                //ここからＣＳＶの内容read
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_CARDKBN] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_YEARMONTH] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_DAIRITENCD] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_BAITAIKBN] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_BANGUMICD] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_BRANDCD] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_BRANNAME] = ar[6];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_KYOKUSICD] = ar[7];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_KYOKUSINAME] = ar[8];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_NETFC] = ar[9];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_FUKENCD] = ar[10];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL1] = ar[11];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL2] = ar[12];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL3] = ar[13];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL4] = ar[14];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_GOKEI] = ar[15];
                    //総秒数.
                    if ((ar[16].Trim()).Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDCM_SOBYOSU] = 0;
                    }
                    else {
                        mstdatavo.Rows[i][KKHLionConst.C_RDCM_SOBYOSU] = ar[16];
                    }
                    //秒数.
                    if ((ar[17].Trim()).Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDCM_BYOSU] = 0;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDCM_BYOSU] = ar[17];
                    }
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL5] = ar[18];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_VAL6] = ar[19];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_ONAIRKAISU] = ar[20];
                    mstdatavo.Rows[i][KKHLionConst.C_RDCM_DATASYORICD] = ar[21];
                }
                catch
                {
                    //閉じる.
                    sr.Close();
//                  //メッセージ表示.
//                  MessageUtility.ShowMessageBox(MessageCode.HB_E0019, null, "ラジオ秒数", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            //閉じる.
            sr.Close();

            //vo戻す.
            return mstdatavo;
        }

        /// <summary>
        /// テレビ系列局金額設定マスタCSVファイルのデータセット読込.
        /// </summary>
        /// <param name="fp">string fp//ファイルadres</param>
        /// <param name="_naviParam"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable findTvRDataCSVRead(string fp, KKHNaviParameter _naviParam)
        {
            if (!File.Exists(fp))
            {
                if (_naviParam.strEsqId.Substring(0, 3).Equals("@@@")) { return null; }
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "テレビ系列局金額設定マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //スキーマ読込.
            Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable();
            //カウント用変数宣言、初期化.
            int i = 0;
            //読み込みデータsplit用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            while (null != (str = sr.ReadLine()))
            {
                //データvoを生成.
                mstdatavo.AddTvKeiKinSetRow(mstdatavo.NewTvKeiKinSetRow());

                //CSVの内容をsplit.
                String[] ar = str.Split('\t');

                //ここからＣＳＶの内容read.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_TVRY_BANCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_TVRY_KYOKUCD] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_TVRY_KEIRETUCD] = ar[2];
                    if (ar[3].Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVRY_DENPARYO] = 0M;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVRY_DENPARYO] = ar[3];
                    }
                    if (ar[4].Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVRY_NETRYO] = 0M;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_TVRY_NETRYO] = ar[4];;
                    }
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "テレビ系列局金額設定マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            //閉じる.
            sr.Close();

            //vo戻す.
            return mstdatavo;
        }

        /// <summary>
        /// ラジオ系列局金額設定マスタCSVファイルのデータセット読込.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="_naviParam"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable findRdRDataCSVRead(string fp, KKHNaviParameter _naviParam)
        {
            if (!File.Exists(fp))
            {
                if (_naviParam.strEsqId.Substring(0, 3).Equals("@@@")) { return null; }

                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "ラジオ系列局金額設定マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //スキーマ読込.
            Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable();
            //カウント用変数宣言、初期化.
            int i = 0;
            //読み込みデータsplit用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            while (null != (str = sr.ReadLine()))
            {
                //データvoを生成.
                mstdatavo.AddRdKeiKinSetRow(mstdatavo.NewRdKeiKinSetRow());

                //CSVの内容をsplit.
                String[] ar = str.Split('\t');

                //ここからＣＳＶの内容read.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_RDRY_BANCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_RDRY_KYOKUCD] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_RDRY_KEIRETUCD] = ar[2];
                    if (ar[3].Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDRY_DENPARYO] = 0M;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDRY_DENPARYO] = ar[3];
                    }
                    if (ar[4].Equals(""))
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDRY_NETRYO] = 0M;
                    }
                    else
                    {
                        mstdatavo.Rows[i][KKHLionConst.C_RDRY_NETRYO] = ar[4];
                    }
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "ラジオ系列局金額設定マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            //閉じる.
            sr.Close();

            //vo戻す.
            return mstdatavo;
        }

        /// <summary>
        /// TV番組マスタワークテーブルリフレッシュ用VOセット.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable TvBnSetCsvData(string fp, KKHNaviParameter naviParameter)
        {
            if (!File.Exists(fp))
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "テレビ番組マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //インスタンス生成.
            Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable();
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //カウント用変数セット.
            int i = 0;
            //split用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            //ファイルの行数分ループ.
            while (null != (str = sr.ReadLine()))
            {
                //データセットにINS
                mstdatavo.AddTvBnLionRow(mstdatavo.NewTvBnLionRow());

                //カンマで分ける.
                String[] ar = str.Split('\t');

                //画面のパラメータ情報セット.
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TRKTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TRKPL] = KKHLionConst.C_TRKPL;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TRKTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_UPDTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_UPDAPL] = KKHLionConst.C_TRKPL; ;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_UPDTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_EGCD] = naviParameter.strEgcd;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TKSKGYCD] = naviParameter.strTksKgyCd;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TKSBMNSEQNO] = naviParameter.strTksBmnSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_TVBN_TKSTNTSEQNO] = naviParameter.strTksTntSeqNo;

                //ここからＣＳＶの内容.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_BANCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_BANNAME] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_HKYOKUCD] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_SEISAKUHI] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_HYOJIJYUN] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_TANKA] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_TVBN_TYPE2] = ar[6];
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "テレビ番組マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            sr.Close();
            return mstdatavo;
        }

        /// <summary>
        /// ラジオ番組マスタワークテーブルリフレッシュ用VOセット.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable RdBnSetCsvData(string fp, KKHNaviParameter naviParameter)
        {
            if (!File.Exists(fp))
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "ラジオ番組マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //インスタンス生成.
            Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable();
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //カウント用変数セット.
            int i = 0;
            //split用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            //ファイルの行数分ループ.
            while (null != (str = sr.ReadLine()))
            {
                //データセットにINS
                mstdatavo.AddRdBnLionRow(mstdatavo.NewRdBnLionRow());

                //カンマで分ける.
                String[] ar = str.Split('\t');

                //画面のパラメータ情報セット.
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TRKTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TRKPL] = KKHLionConst.C_TRKPL;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TRKTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_UPDTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_UPDAPL] = KKHLionConst.C_TRKPL; ;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_UPDTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_EGCD] = naviParameter.strEgcd;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TKSKGYCD] = naviParameter.strTksKgyCd;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TKSBMNSEQNO] = naviParameter.strTksBmnSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_RDBN_TKSTNTSEQNO] = naviParameter.strTksTntSeqNo;

                //ここからＣＳＶの内容.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_BANCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_BANNAME] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_HKYOKUCD] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_SEISAKUHI] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_HYOJIJYUN] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_TANKA] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_RDBN_TYPE2] = ar[6];
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "ラジオ番組マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            sr.Close();
            return mstdatavo;
        }

        /// <summary>
        /// TV局マスタワークテーブルリフレッシュ用VOセット.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable TvKSetCsvData(string fp, KKHNaviParameter naviParameter)
        {
            if (!File.Exists(fp))
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "テレビ局マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //インスタンス生成.
            Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable();
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //カウント用変数セット.
            int i = 0;
            //split用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            //ファイルの行数分ループ.
            while (null != (str = sr.ReadLine()))
            {
                //データセットにINS
                mstdatavo.AddTvKLionRow(mstdatavo.NewTvKLionRow());

                //カンマで分ける.
                String[] ar = str.Split('\t');

                //画面のパラメータ情報セット.
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TRKTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TRKPL] = KKHLionConst.C_TRKPL;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TRKTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_UPDTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_UPDAPL] = KKHLionConst.C_TRKPL; ;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_UPDTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_EGCD] = naviParameter.strEgcd;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TKSKGYCD] = naviParameter.strTksKgyCd;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TKSBMNSEQNO] = naviParameter.strTksBmnSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_TVK_TKSTNTSEQNO] = naviParameter.strTksTntSeqNo;

                //ここからＣＳＶの内容.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_KYOKUCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_KYOKUNAME] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_KIGOU] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_KEIRETSU] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_TIKU] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_THYOJIJYUN] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_TVK_HYOJIJYUN] = ar[6];
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "テレビ局マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            sr.Close();
            return mstdatavo;
        }

        /// <summary>
        /// ラジオ局マスタワークテーブルリフレッシュ用VOセット.
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable RdKSetCsvData(string fp, KKHNaviParameter naviParameter)
        {
            if (!File.Exists(fp))
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "ラジオ局マスタ", MessageBoxButtons.OK);
                //nullを返す.
                return null;
            }

            //インスタンス生成.
            Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable();
            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;
            //カウント用変数セット.
            int i = 0;
            //split用変数.
            String str;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む.
            StreamReader sr = new StreamReader(fp, System.Text.Encoding.GetEncoding(932));

            //ファイルの行数分ループ.
            while (null != (str = sr.ReadLine()))
            {
                //データセットにINS
                mstdatavo.AddRdKLionRow(mstdatavo.NewRdKLionRow());

                //カンマで分ける.
                String[] ar = str.Split('\t');

                //画面のパラメータ情報セット.
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TRKTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TRKPL] = KKHLionConst.C_TRKPL;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TRKTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_UPDTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_UPDAPL] = KKHLionConst.C_TRKPL; ;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_UPDTNT] = naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_EGCD] = naviParameter.strEgcd;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TKSKGYCD] = naviParameter.strTksKgyCd;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TKSBMNSEQNO] = naviParameter.strTksBmnSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_RDK_TKSTNTSEQNO] = naviParameter.strTksTntSeqNo;

                //ここからＣＳＶの内容.
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_RDK_KYOKUCD] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_RDK_KYOKUNAME] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_RDK_KIGOU] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_RDK_KEIRETSU] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_RDK_HYOJIJYUN] = ar[4];
                }
                catch
                {
                    //閉じる.
                    sr.Close();
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0002, null, "ラジオ局マスタ", MessageBoxButtons.OK);
                    //nullを返す.
                    return null;
                }

                i++;
            }

            sr.Close();
            return mstdatavo;
        }

        /// <summary>
        /// マスタファイルコピー.
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="Pass"></param>
        /// <param name="TempAddress"></param>
        /// <param name="filenm"></param>
        /// <returns></returns>
        private Boolean MastCopy(string Address, string Pass, string TempAddress, string filenm)
        {
            try
            {
                //ファイルを強制コピー（上書き）する。.
                System.IO.File.Copy(Address + filenm, TempAddress + filenm);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ライオンマスタ取得.
        /// </summary>
        /// <param name="_naviParam"></param>
        /// <returns></returns>
        public MastLion GetLionMast(KKHNaviParameter _naviParam)
        {
            MastLion MastLionDs = new MastLion();

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
                _dtAddrMst = comResult;
            }

            //取得（ファイル）.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRKT_SYBT,
                                                                                            KKHLionConst.C_WRKTF_FLD1);

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                _dtFileMst = comResult2;
            }

            //マスタ取得処理/////////////////////////////////////////////////////////////////////////////////////////
            //変数.
            string Address = "";//アドレス(秒数系)
            string AddressMst = "";//アドレス(そのほかマスタ系）.

            string Pass = "";//パスワード.

            string TempAddress = "";//テンプアドレス.
            string TvbFname = "";//テレビ秒数用ファイルネーム.
            string RdbFname = "";//テレビ秒数用ファイルネーム.
            string TvRFname = "";//テレビ系列局金額設定マスタファイル用ファイルネーム.
            string RdRFname = "";//ラジオ系列局金額設定マスタファイル用ネーム.
            string TvBnFname = "";//テレビ番組マスタ用ファイルネーム.
            string RdBnFname = "";//ラジオ番組マスタ用ファイルネーム.
            string TvKFname = "";//テレビ局マスタ用ファイルネーム.
            string RdKFname = "";//ラジオ局マスタ用ファイルネーム.

            //アドレス、パス、添付アドレスを取得設定.
            Address = _dtAddrMst.CommonDataSet.SystemCommon[0].field3.ToString();
            AddressMst = _dtAddrMst.CommonDataSet.SystemCommon[0].field4.ToString();
            Pass = _dtAddrMst.CommonDataSet.SystemCommon[0].field10.ToString();
            TempAddress = _dtAddrMst.CommonDataSet.SystemCommon[0].field2.ToString();
            //ファイル名を取得設定.
            TvbFname = _dtFileMst.CommonDataSet.SystemCommon[0].field8.ToString();
            RdbFname = _dtFileMst.CommonDataSet.SystemCommon[0].field9.ToString();
            TvBnFname = _dtFileMst.CommonDataSet.SystemCommon[0].field2.ToString();
            RdBnFname = _dtFileMst.CommonDataSet.SystemCommon[0].field3.ToString();
            TvKFname = _dtFileMst.CommonDataSet.SystemCommon[0].field4.ToString();
            RdKFname = _dtFileMst.CommonDataSet.SystemCommon[0].field5.ToString();
            TvRFname = _dtFileMst.CommonDataSet.SystemCommon[0].field6.ToString();
            RdRFname = _dtFileMst.CommonDataSet.SystemCommon[0].field7.ToString();

            //システム管理者の場合はマスタファイルの存在確認不要.
            if (!_naviParam.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //マスタファイル存在確認.
                if (!(File.Exists(AddressMst + TvBnFname) &&
                    File.Exists(AddressMst + RdBnFname) &&
                    File.Exists(AddressMst + TvKFname) &&
                    File.Exists(AddressMst + RdKFname) &&
                    File.Exists(AddressMst + TvRFname) &&
                    File.Exists(AddressMst + RdRFname))
                    )
                {
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "エラー", MessageBoxButtons.OK);
                    MastLionDs.Clear();
                    return MastLionDs;
                }
            }

            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;

            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            #region テレビ.

            //CM秒数TVデータ取得テスト.
            //ファイル取得、比較.
            //if (tims.findMastGet(Address, Pass, TempAddress, TvbFname, KKHLionConst.C_WRFL_TVCMST, _naviParam))
            //{
            //    //データテーブルVOにデータ読込開始.
            //    //prTvBmast = mstf.findTvBDataCSVRead(Address + TvbFname, "201202");
            //    _dtTvByoMst = mstf.findTvBDataCSVRead(Address + TvbFname, yymm);

            //    if (_dtTvByoMst.Rows.Count == 0)
            //    {
            //        //エラー.
            //        MastLionDs.Clear();
            //        return MastLionDs;
            //    }
            //    //結果を入れる.
            //    MastLionDs.TvCmLion.Merge(_dtTvByoMst);
            //}

            //●↓ここからワークテーブルリフレッシュタイム↓●.
            //TV番組マスタデータワークテーブルリフレッシュ処理.
            //システム管理者の場合はワークテーブルの更新を行わない.

            if (!_naviParam.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //ファイル取得、比較.
                //Boolean blok = false;
                if (tims.findMastGet(AddressMst, Pass, TempAddress, TvBnFname, KKHLionConst.C_WRFL_TVBMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ（TV番組マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.TvBnSetCsvData(AddressMst + TvBnFname, _naviParam);

                    masterMaintenanceProcessController.RegisterMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstdatavo,
                                                                      dtNow);

                    // オペレーションログの出力.
                    KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKTVB, KKHLogUtilityLion.DESC_OPERATION_LOG_WKTVB);

                }

                //TV局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, TvKFname, KKHLionConst.C_WRFL_TVKMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ（TV局マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.TvKSetCsvData(AddressMst + TvKFname, _naviParam);

                    masterMaintenanceProcessController.RegisterTvKMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstdatavo,
                                                                      dtNow);

                    // オペレーションログの出力.
                    KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKTVK, KKHLogUtilityLion.DESC_OPERATION_LOG_WKTVK);

                }
            }

            //TV番組マスタ取得処理.
            //実行.
            MastLion Tvmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mast = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList arytvmast = new ArrayList();

            //検索項目（空白でもOK)
            arytvmast.Add("");//番組CD
            arytvmast.Add("");//番組NM
            arytvmast.Add("");//局誌CD
            arytvmast.Add("");//単価区分.
            arytvmast.Add("");//TYPE2

            //実行.
            FindLionMastByCondServiceResult result = mast.FindTvMast(arytvmast, _naviParam);

            //エラー.
            if (result.HasError)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //データが存在しなければ終了.
            if (result.mastLionDataSet.TvBnLion.Rows.Count == 0)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果を入れる。.
            MastLionDs.TvBnLion.Merge(result.mastLionDataSet.TvBnLion);

            //テレビ局マスタ取得処理.
            //実行.
            MastLion TvKmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masttvk = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList arytvkmast = new ArrayList();

            //検索項目（空白でもOK)
            arytvkmast.Add("");//放送局コード.
            arytvkmast.Add("");//記号.
            arytvkmast.Add("");//系列.
            arytvkmast.Add("");//地区.

            //実行.
            FindLionMastByCondServiceResult tvkresult = masttvk.FindTvKMast(arytvkmast, _naviParam);

            //エラー.
            if (tvkresult.HasError)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }


            //データが存在しなければ終了.
            if (tvkresult.mastLionDataSet.TvKLion.Rows.Count == 0)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果を入れる.
            MastLionDs.TvKLion.Merge(tvkresult.mastLionDataSet.TvKLion);

            #endregion テレビ.

            #region ラジオ.

            //CM秒数ラジオデータ取得テスト.
            //ファイル取得、比較.
            //if (tims.findMastGet(Address, Pass, TempAddress, RdbFname, KKHLionConst.C_WRFL_RDCMST, _naviParam))
            //{
            //    //データテーブルVOにデータ読込開始.
            //   _dtRdByoMst = mstf.findRdBDataCSVRead(Address + RdbFname, yymm);

            //    if (_dtRdByoMst.Rows.Count == 0)
            //    {
            //        MastLionDs.Clear();
            //        return MastLionDs;
            //    }

            //    //結果を入れる。.
            //    MastLionDs.RdCmLion.Merge(_dtRdByoMst);
            //}

            //ラジオ番組マスタデータワークテーブルリフレッシュ処理.
            //システム管理者の場合はワークテーブルの更新を行わない.
            if (!_naviParam.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, RdBnFname, KKHLionConst.C_WRFL_RDBMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ（ラジオ番組マスタ)
                    MastLion.RdBnLionDataTable mstdatavo = new MastLion.RdBnLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.RdBnSetCsvData(AddressMst + RdBnFname, _naviParam);

                    masterMaintenanceProcessController.RegisterRdMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstdatavo,
                                                                      dtNow);

                    // オペレーションログの出力.
                    KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKRDB, KKHLogUtilityLion.DESC_OPERATION_LOG_WKRDB);

                }

                //ラジオ局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, RdKFname, KKHLionConst.C_WRFL_RDKMST, _naviParam))
                {
                    //ワークテーブルリフレッシュ（ラジオ局マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.RdKSetCsvData(AddressMst + RdKFname, _naviParam);

                    masterMaintenanceProcessController.RegisterRdKMasterResult(
                                                                      _naviParam.strEsqId,
                                                                      KKHLionConst.C_TRKPL,
                                                                      _naviParam.strEgcd,
                                                                      _naviParam.strTksKgyCd,
                                                                      _naviParam.strTksBmnSeqNo,
                                                                      _naviParam.strTksTntSeqNo,
                                                                      "",
                                                                      "",
                                                                      mstdatavo,
                                                                      dtNow);

                    // オペレーションログの出力.
                    KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKRDK, KKHLogUtilityLion.DESC_OPERATION_LOG_WKRDK);

                }
            }

            //ラジオ番組マスタ取得処理.
            //実行.
            MastLion Rdmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mastrd = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList aryrdmast = new ArrayList();

            //検索項目（空白でもOK)
            aryrdmast.Add("");//番組CD
            aryrdmast.Add("");//番組NM
            aryrdmast.Add("");//局誌CD
            aryrdmast.Add("");//単価区分.
            aryrdmast.Add("");//TYPE2

            //実行.
            FindLionMastByCondServiceResult rdresult = mastrd.FindRdMast(aryrdmast, _naviParam);

            //エラー.
            if (rdresult.HasError)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //検索結果0件.
            if (rdresult.mastLionDataSet.RdBnLion.Rows.Count == 0)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果を入れる.
            MastLionDs.RdBnLion.Merge(rdresult.mastLionDataSet.RdBnLion);

            //ラジオ局マスタ取得処理.
            //実行.
            MastLion RdKmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mastrdk = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList aryrdkmast = new ArrayList();

            //検索項目（空白でもOK)
            aryrdkmast.Add("");//放送局コード.
            aryrdkmast.Add("");//記号.
            aryrdkmast.Add("");//系列.

            //実行.
            FindLionMastByCondServiceResult rdkresult = mastrdk.FindRdKMast(aryrdkmast, _naviParam);

            //エラー.
            if (rdkresult.HasError)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //検索結果0件.
            if (rdkresult.mastLionDataSet.RdKLion.Rows.Count == 0)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果を入れる.
            MastLionDs.RdKLion.Merge(rdkresult.mastLionDataSet.RdKLion);

            #endregion ラジオ.

            //*******************************
            //ブランドコードの取得.
            //*******************************
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.FindBrandDataParam param = new Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.FindBrandDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.masterkey = "0005";

            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController brandprocess = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            FindLionMastByCondServiceResult brandresult = brandprocess.FindBrandData(param);

            //エラー.
            if (brandresult.HasError)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0017, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果が0件のとき.
            if (brandresult.mastLionDataSet.BrandLion.Rows.Count == 0)
            {
                //メッセージ表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "エラー", MessageBoxButtons.OK);
                MastLionDs.Clear();
                return MastLionDs;
            }

            //結果を入れる。.
            MastLionDs.BrandLion.Merge(brandresult.mastLionDataSet.BrandLion);


            return MastLionDs;
        }

        /// <summary>
        /// テレビ、ラジオCm取得.
        /// </summary>
        /// <param name="_naviParam"></param>
        /// <param name="yymm"></param>
        /// <returns></returns>
        public MastLion GetLionTvRdCm(KKHNaviParameter _naviParam, string yymm)
        {
            MastLion MastLionDs = new MastLion();

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
                _dtAddrMst = comResult;
            }

            //取得（ファイル）.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRKT_SYBT,
                                                                                            KKHLionConst.C_WRKTF_FLD1);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                _dtFileMst = comResult2;
            }

            //マスタ取得処理/////////////////////////////////////////////////////////////////////////////////////////
            //変数.
            string Address = "";//アドレス(秒数系).
            string AddressMst = "";//アドレス(そのほかマスタ系）.
            string Pass = "";//パスワード.
            string TempAddress = "";//テンプアドレス.
            string TvbFname = "";//テレビ秒数用ファイルネーム.
            string RdbFname = "";//テレビ秒数用ファイルネーム.
            string TvRFname = "";//テレビ系列局金額設定マスタファイル用ファイルネーム.
            string RdRFname = "";//ラジオ系列局金額設定マスタファイル用ネーム.
            string TvBnFname = "";//テレビ番組マスタ用ファイルネーム.
            string RdBnFname = "";//ラジオ番組マスタ用ファイルネーム.
            string TvKFname = "";//テレビ局マスタ用ファイルネーム.
            string RdKFname = "";//ラジオ局マスタ用ファイルネーム.

            //アドレス、パス、添付アドレスを取得設定.
            Address = _dtAddrMst.CommonDataSet.SystemCommon[0].field3.ToString();
            AddressMst = _dtAddrMst.CommonDataSet.SystemCommon[0].field4.ToString();
            Pass = _dtAddrMst.CommonDataSet.SystemCommon[0].field10.ToString();
            TempAddress = _dtAddrMst.CommonDataSet.SystemCommon[0].field2.ToString();
            //ファイル名を取得設定.
            TvbFname = _dtFileMst.CommonDataSet.SystemCommon[0].field8.ToString();
            RdbFname = _dtFileMst.CommonDataSet.SystemCommon[0].field9.ToString();
            TvBnFname = _dtFileMst.CommonDataSet.SystemCommon[0].field2.ToString();
            RdBnFname = _dtFileMst.CommonDataSet.SystemCommon[0].field3.ToString();
            TvKFname = _dtFileMst.CommonDataSet.SystemCommon[0].field4.ToString();
            RdKFname = _dtFileMst.CommonDataSet.SystemCommon[0].field5.ToString();
            TvRFname = _dtFileMst.CommonDataSet.SystemCommon[0].field6.ToString();
            RdRFname = _dtFileMst.CommonDataSet.SystemCommon[0].field7.ToString();

            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;

            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            //CM秒数TVデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(Address, Pass, TempAddress, TvbFname, KKHLionConst.C_WRFL_TVCMST, _naviParam))
            {
                //データテーブルVOにデータ読込開始.
                _dtTvByoMst = mstf.findTvBDataCSVRead(Address + TvbFname, yymm);

                if (_dtTvByoMst != null)
                {
                    if (_dtTvByoMst.Rows.Count == 0)
                    {
                        //エラー.
                        MastLionDs.Clear();
                        //return MastLionDs;
                    }

                    //結果を入れる.
                    MastLionDs.TvCmLion.Merge(_dtTvByoMst);
                }
            }

            //CM秒数ラジオデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(Address, Pass, TempAddress, RdbFname, KKHLionConst.C_WRFL_RDCMST, _naviParam))
            {
                //データテーブルVOにデータ読込開始.
                _dtRdByoMst = mstf.findRdBDataCSVRead(Address + RdbFname, yymm);

                if (_dtRdByoMst != null)
                {
                    if (_dtRdByoMst.Rows.Count == 0 && ( ( _dtTvByoMst != null ) || _dtTvByoMst.Rows.Count == 0 ))
                    {
                        MastLionDs.Clear();
                        return MastLionDs;
                    }

                    //結果を入れる。.
                    MastLionDs.RdCmLion.Merge(_dtRdByoMst);
                }
            }

            return MastLionDs;
        }
    }

}

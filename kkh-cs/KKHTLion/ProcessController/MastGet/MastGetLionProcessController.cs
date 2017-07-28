using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.ProcessController.History.Parser;
using System.Collections;

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
namespace Isid.KKH.Lion.ProcessController.MastGet
{
    /// <summary>
    /// マスタ取得（Lion）プロセスコントローラ
    /// </summary>
    /// <remarks>
    ///   修正管理
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/2/6/description>
    ///       <description>Fourm K.T</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class MastGetLionProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {

        #region "構造体"

        #endregion "構造体"

        #region "インスタンス変数"
        public static MastGetLionProcessController _processController;
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        public static MastGetLionProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new MastGetLionProcessController();
            }
            return _processController;
        }

        #endregion "インスタンス変数"

        #region "コンストラクタ"

        #endregion "コンストラクタ"

        #region "メソッド"


        /// <summary>
        /// マスタ比較
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Boolean findMastGet(string Address, string Pass, string TempAddress, ArrayList files, KKHNaviParameter naviParameter)
        {
            DateTime dtFilesv = new DateTime();
            DateTime dtFilelcl = new DateTime();

            _naviParameter = naviParameter;
            DateTime dtNow = DateTime.Now;
            Boolean newflag = false;

            //件数分処理
            for (int i = 0; i < files.Count; i++ )
            {
                //ローカルにファイルが無かったら強制ＤＬ
                if (System.IO.File.Exists(TempAddress + files[i]))
                {
                    //ファイル強制ワークテーブル挿入OFF
                    newflag = false;
                    dtFilesv = System.IO.File.GetLastWriteTime(Address + files[i]);
                    dtFilelcl = System.IO.File.GetLastWriteTime(TempAddress + files[i]);
                }
                else
                {
                    //ファイル強制ワークテーブル挿入ON
                    newflag = true;
                    //ファイルＤＬ処理（コピー）
                }

                //ローカル、サーバを比較し一致しなかったら
                //CSVマスタDLし、ワークテーブルリフレッシュ処理を実行する。
                if (dtFilesv != dtFilelcl || newflag == true)
                {
                    //ファイルＤＬ処理（コピー）
                    findMastGet(Address, Pass, TempAddress, files, i);

                    //ワークテーブルリフレッシュ
                    //TV系列局金額設定マスタ
                    if (files[i].ToString().Equals("TV系列局金額設定マスタ.csv"))
                    {
                        Isid.KKH.Lion.Schema.MasterMaintenance.MasterDataVODataTable mstdatavo = new Isid.KKH.Lion.Schema.MasterMaintenance.MasterDataVODataTable();
                        MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();

                        mstdatavo = ReadCsv(TempAddress + files[i]);

                        //Isid.KKH.Lion.ProcessController.MastGet.RegisterMasterServiceResult result = masterMaintenanceProcessController.RegisterMasterResult(
                        //                                                  _naviParameter.strEsqId,
                        //                                                  KKHLionConst.C_TRKPL,
                        //                                                  _naviParameter.strEgcd,
                        //                                                  _naviParameter.strTksKgyCd,
                        //                                                  _naviParameter.strTksBmnSeqNo,
                        //                                                  _naviParameter.strTksTntSeqNo,
                        //                                                  "",
                        //                                                  _naviParameter.strFilterValue,
                        //                                                  mstdatavo,
                        //                                                  dtNow);

                    } else
                    //TV番組マスタ
                    if (files[i].ToString().Equals("TV番組マスタ.csv"))
                    {

                    } else
                    //TV放送局マスタ
                    if (files[i].ToString().Equals("TV放送局マスタ.csv"))
                    {

                    }
                }
                

            }
            return true;
        }

        /// <summary>
        /// マスタファイルゲット
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Boolean findMastGet(string Address, string Pass, string TempAddress, ArrayList files,int cnt)
        {
            try
            {
                //ファイルを強制コピー（上書き）する。
                System.IO.File.Copy(Address + files[cnt], TempAddress + files[cnt]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// マスタファイルゲット
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Isid.KKH.Lion.Schema.MasterMaintenance.MasterDataVODataTable ReadCsv(string fp)
        {
            Isid.KKH.Lion.Schema.MasterMaintenance.MasterDataVODataTable mstdatavo = new Isid.KKH.Lion.Schema.MasterMaintenance.MasterDataVODataTable();
            DateTime dtNow = DateTime.Now;
            int i = 0;
            //Shift JIS　でストリームから一行ごとに最後まで読み込む
            System.IO.StreamReader sr = new System.IO.StreamReader(fp, System.Text.Encoding.GetEncoding(932));
            String str;
            while (null != (str = sr.ReadLine()))
            {
                mstdatavo.AddMasterDataVORow(mstdatavo.NewMasterDataVORow());

                String[] ar = str.Split(',');

                mstdatavo.Rows[i][KKHLionConst.C_TRKTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_TRKPL] = KKHLionConst.C_TRKPL;
                mstdatavo.Rows[i][KKHLionConst.C_TRKTNT] = _naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_UPDTIMSTMP] = dtNow;
                mstdatavo.Rows[i][KKHLionConst.C_UPDAPL] = KKHLionConst.C_TRKPL; ;
                mstdatavo.Rows[i][KKHLionConst.C_UPDTNT] = _naviParameter.strEsqId;
                mstdatavo.Rows[i][KKHLionConst.C_TKSKGYCD] = _naviParameter.strTksKgyCd;
                mstdatavo.Rows[i][KKHLionConst.C_TKSBMNSEQNO] = _naviParameter.strTksBmnSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_TKSTNTSEQNO] = _naviParameter.strTksTntSeqNo;
                mstdatavo.Rows[i][KKHLionConst.C_SYBT] = "001";

                //ここからＣＳＶの内容
                try
                {
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN1] = ar[0];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN2] = ar[1];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN3] = ar[2];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN4] = ar[3];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN5] = ar[4];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN6] = ar[5];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN7] = ar[6];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN8] = ar[7];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN9] = ar[8];
                    mstdatavo.Rows[i][KKHLionConst.C_COLUMN10] = ar[9];
                }
                catch 
                { }

                i++;
            }
            sr.Close();

            return mstdatavo;
        }

        #endregion "メソッド"

    }
}

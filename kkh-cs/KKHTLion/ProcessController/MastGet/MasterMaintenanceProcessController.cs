using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.KKH.Lion.ProcessController.MastGet.Parser;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Lion.ProcessController.MastGet.Converter;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
 using System.Collections;


namespace Isid.KKH.Lion.ProcessController.MastGet
{
    /// <summary>
    /// ライオンマスタプロセスコントローラ 
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
    ///       <description>2011/02/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class MasterMaintenanceProcessController:Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static MasterMaintenanceProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private masterLionServiceAdapter _adapter;

        /// <summary>
        /// commonマスタアダプター
        /// </summary>
        private masterServiceAdapter _mstadapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Lion.Schema.MastLion _dsMaster;

        #endregion インスタンス変数

        #region データ構造体
        /// <summary>
        /// 
        /// </summary>
        public struct FindBrandDataParam
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// アプリID
            /// </summary>
            public String AplId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 種別
            /// </summary>
            public String Sybt;
            /// <summary>
            /// フィルターバリュー
            /// </summary>
            public String filterValue;
            /// <summary>
            /// マスターキー
            /// </summary>
            public String masterkey;
        }

        /// <summary>
        /// 雑誌スペース料金マスタパラメータ構造体 
        /// </summary>
        public struct MastLionZashiRyoSpcParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
        }


        #endregion データ構造体
        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private MasterMaintenanceProcessController()
        {
            _adapter = CreateAdapter<masterLionServiceAdapter>();
            _mstadapter = CreateAdapter<masterServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static MasterMaintenanceProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new MasterMaintenanceProcessController();
            }
            return _processController;
        }


        /// <summary>
        /// テレビ番組マスタワークデータリフレッシュ 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public Boolean RegisterMasterResult(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo, 
            String TksTntSeqNo, String MasterKey, String FilterValue, 
            Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable DataVO, 
            DateTime maxupdate)
        {
            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            lionTvMastRegisterVO register = new lionTvMastRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.lionData = MasterDataSetConverter.ConvertForMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            _adapter.registerLionTvMast(register);

            return true;
            
        }

        /// <summary>
        /// ラジオ番組マスタワークデータリフレッシュ 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public Boolean RegisterRdMasterResult(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo,
            String TksTntSeqNo, String MasterKey, String FilterValue,
            Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable DataVO,
            DateTime maxupdate)
        {
            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            lionRdMastRegisterVO register = new lionRdMastRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.lionData = MasterDataSetConverter.ConvertForRdMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            _adapter.registerLionRdMast(register);


            return true;

        }

        /// <summary>
        /// テレビ局マスタワークデータリフレッシュ 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public Boolean RegisterTvKMasterResult(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo,
            String TksTntSeqNo, String MasterKey, String FilterValue,
            Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable DataVO,
            DateTime maxupdate)
        {
            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            lionTvKMastRegisterVO register = new lionTvKMastRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.lionData = MasterDataSetConverter.ConvertForTvKMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            _adapter.registerLionTvKMast(register);


            return true;

        }

        /// <summary>
        /// ラジオ局マスタワークデータリフレッシュ 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public Boolean RegisterRdKMasterResult(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo,
            String TksTntSeqNo, String MasterKey, String FilterValue,
            Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable DataVO,
            DateTime maxupdate)
        {
            //サービス結果 
            RegisterMasterServiceResult serviceResult = new RegisterMasterServiceResult();

            lionRdKMastRegisterVO register = new lionRdKMastRegisterVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.lionData = MasterDataSetConverter.ConvertForRdKMasterInsert(DataVO);
            register._maxupdate = maxupdate;


            //サービスの呼び出し 
            _adapter.registerLionRdKMast(register);


            return true;

        }

        /// <summary>
        /// 各マスタ用タイムスタンプ更新処理 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public Boolean UpdateTimeStampData(ArrayList param, KKHNaviParameter naviParameter)
        {
            UpdateTimeStampDataServiceResult serviceResult = new UpdateTimeStampDataServiceResult();
            updateTimeStampVO udvo = new updateTimeStampVO();

            udvo._egCd = naviParameter.strEgcd;
            udvo._tksKgyCd = naviParameter.strTksKgyCd;
            udvo._tksBmnSeqNo = naviParameter.strTksBmnSeqNo;
            udvo._TksTntSeqNo = naviParameter.strTksTntSeqNo;
            udvo._syBt = param[0].ToString();
            udvo._field1 = param[1].ToString();
            udvo._mstkbn = param[2].ToString();
            udvo.timeStamp = param[3].ToString();
            _adapter.updateTimeStampData(udvo);

            return true;
        }

        /// <summary>
        /// TV番組マスタ検索処理 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public FindLionMastByCondServiceResult FindTvMast(ArrayList param, KKHNaviParameter naviParameter)
        {
            FindLionMastByCondServiceResult serviceResult = new FindLionMastByCondServiceResult();
            findTvMastCondition cond = new findTvMastCondition();

            cond.egCd = naviParameter.strEgcd;
            cond.tksKgyCd = naviParameter.strTksKgyCd;
            cond.tksBmnSeqNo = naviParameter.strTksBmnSeqNo;
            cond.tksTntSeqNo = naviParameter.strTksTntSeqNo;
            cond.bancd = param[0].ToString();
            cond.banname = param[1].ToString();
            cond.hkyokucd = param[2].ToString();
            cond.tanka = param[3].ToString();
            cond.type2 = param[4].ToString();
            //サービスの呼び出し 
            findTvMastResult result = _adapter.findTvMastByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }



            // パース 
            FindLionMastParseResult parseResult = FindLionMastParser.ParseForFindReportMacByCond(result);
            _dsMaster = parseResult.MastLionDataSet;

            // サービス結果の生成 
            serviceResult.mastLionDataSet = parseResult.MastLionDataSet;

            return serviceResult;


        }

        /// <summary>
        /// ラジオ番組マスタ検索処理 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public FindLionMastByCondServiceResult FindRdMast(ArrayList param, KKHNaviParameter naviParameter)
        {
            FindLionMastByCondServiceResult serviceResult = new FindLionMastByCondServiceResult();
            findRdMastCondition cond = new findRdMastCondition();

            cond.egCd = naviParameter.strEgcd;
            cond.tksKgyCd = naviParameter.strTksKgyCd;
            cond.tksBmnSeqNo = naviParameter.strTksBmnSeqNo;
            cond.tksTntSeqNo = naviParameter.strTksTntSeqNo;
            cond.bancd = param[0].ToString();
            cond.banname = param[1].ToString();
            cond.hkyokucd = param[2].ToString();
            cond.tanka = param[3].ToString();
            cond.type2 = param[4].ToString();
            //サービスの呼び出し 
            findRdMastResult result = _adapter.findRdMastByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }



            // パース 
            FindLionMastParseResult parseResult = FindLionMastParser.ParseForFindReportRdMacByCond(result);
            _dsMaster = parseResult.MastLionDataSet;

            // サービス結果の生成 
            serviceResult.mastLionDataSet = parseResult.MastLionDataSet;

            return serviceResult;


        }

        /// <summary>
        /// TV局マスタ検索処理 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public FindLionMastByCondServiceResult FindTvKMast(ArrayList param, KKHNaviParameter naviParameter)
        {
            FindLionMastByCondServiceResult serviceResult = new FindLionMastByCondServiceResult();
            findTvKMastCondition cond = new findTvKMastCondition();

            cond.egCd = naviParameter.strEgcd;
            cond.tksKgyCd = naviParameter.strTksKgyCd;
            cond.tksBmnSeqNo = naviParameter.strTksBmnSeqNo;
            cond.tksTntSeqNo = naviParameter.strTksTntSeqNo;
            cond.kyokucd = param[0].ToString();
            cond.kigou = param[1].ToString();
            cond.keiretsu = param[2].ToString();
            cond.tiku = param[3].ToString();
            //サービスの呼び出し  
            findTvKMastResult result = _adapter.findTvKMastByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }



            // パース
            FindLionMastParseResult parseResult = FindLionMastParser.ParseForFindReportTvKMacByCond(result);
            _dsMaster = parseResult.MastLionDataSet;

            // サービス結果の生成
            serviceResult.mastLionDataSet = parseResult.MastLionDataSet;

            return serviceResult;


        }

        /// <summary>
        /// ラジオ局マスタ検索処理 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="naviParameter"></param>
        /// <returns></returns>
        public FindLionMastByCondServiceResult FindRdKMast(ArrayList param, KKHNaviParameter naviParameter)
        {
            FindLionMastByCondServiceResult serviceResult = new FindLionMastByCondServiceResult();
            findRdKMastCondition cond = new findRdKMastCondition();

            cond.egCd = naviParameter.strEgcd;
            cond.tksKgyCd = naviParameter.strTksKgyCd;
            cond.tksBmnSeqNo = naviParameter.strTksBmnSeqNo;
            cond.tksTntSeqNo = naviParameter.strTksTntSeqNo;
            cond.kyokucd = param[0].ToString();
            cond.kigou = param[1].ToString();
            cond.keiretsu = param[2].ToString();
            //サービスの呼び出し 
            findRdKMastResult result = _adapter.findRdKMastByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }



            // パース
            FindLionMastParseResult parseResult = FindLionMastParser.ParseForFindReportRdKMacByCond(result);
            _dsMaster = parseResult.MastLionDataSet;

            // サービス結果の生成
            serviceResult.mastLionDataSet = parseResult.MastLionDataSet;

            return serviceResult;


        }

        /// <summary>
        /// ブランド取得 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindLionMastByCondServiceResult FindBrandData(FindBrandDataParam param)
        {
            FindLionMastByCondServiceResult serviceResult = new FindLionMastByCondServiceResult();

            masterCondition cond = new masterCondition();
            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.masterKey = param.masterkey;
            cond.filterValue = param.filterValue;
            //cond.= param.masterkey;
            
            //サービスの呼び出し 
            masterResult result = _mstadapter.findMasterByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            FindLionMastParseResult parseresult = FindLionMastParser.ParseForFindMasterByCond(result);
            _dsMaster = parseresult.MastLionDataSet;

            // サービス結果の生成 
            serviceResult.mastLionDataSet = parseresult.MastLionDataSet;

            return serviceResult;

        }

        /// <summary>
        /// 雑誌スペース料金マスタ検索処理 
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public MastLionZashiRyoSpcServiceResult MastLionZashiRyoSpcService(String cd, String name, MastLionZashiRyoSpcParam param)
        {
            MastLionZashiRyoSpcServiceResult serviceResult = new MastLionZashiRyoSpcServiceResult();
            lionZashiRyoSpcMastCondition cond = new lionZashiRyoSpcMastCondition();

            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.cd = cd.ToString();
            cond.name = name.ToString();
            //サービスの呼び出し 
            lionZashiRyoSpcMastResult result = _adapter.lionZashiRyoSpcMastByCond(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }

            // パース
            MastLionZashiRyoSpcServiceResult parseResult = MastLionZashiRyoSpcParser.ParseForMastLionZashiRyoSpc(result);

            // サービス結果の生成
            serviceResult.MZLionDataSet = parseResult.MZLionDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 雑誌スペース料金マスタ更新処理 
        /// </summary>
        /// <param name="EsqId"></param>
        /// <param name="AplId"></param>
        /// <param name="Egcd"></param>
        /// <param name="TksKgyCd"></param>
        /// <param name="TksBmnSeqNo"></param>
        /// <param name="TksTntSeqNo"></param>
        /// <param name="Sybt"></param>
        /// <param name="ZashiCd"></param>
        /// <param name="MasterKey"></param>
        /// <param name="FilterValue"></param>
        /// <param name="DataVO"></param>
        /// <param name="maxupdate"></param>
        /// <returns></returns>
        public MastLionZashiRyoSpcServiceResult InsertMastLionZashiRyoSpcService(String EsqId, String AplId, String Egcd, String TksKgyCd, String TksBmnSeqNo, String TksTntSeqNo,
            String Sybt, String ZashiCd, String MasterKey, String FilterValue, Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DataVO, DateTime maxupdate)
        {
            MastLionZashiRyoSpcServiceResult serviceResult = new MastLionZashiRyoSpcServiceResult();

            insertLionZashiRyoSpcMastVO register = new insertLionZashiRyoSpcMastVO();
            register.esqId = EsqId;
            register.aplId = AplId;
            register.egCd = Egcd;
            register.tksKgyCd = TksKgyCd;
            register.tksBmnSeqNo = TksBmnSeqNo;
            register.tksTntSeqNo = TksTntSeqNo;
            register._sybt = Sybt;
            register._zashiCd = ZashiCd;
            register.masterKey = MasterKey;
            register.filterValue = FilterValue;
            register.masterData = MasterDataSetConverter.ConvertForMasterInsert(DataVO);
            register._maxupdate = maxupdate;
            //サービスの呼び出し 
            insertLionZashiRyoSpcMastResult result = _adapter.insertLionZashiRyoSpcMast(register);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            return serviceResult;
        }

        #endregion メソッド
    }
}
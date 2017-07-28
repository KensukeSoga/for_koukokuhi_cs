using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.ProcessController.Detail.Parser;

namespace Isid.KKH.Acom.ProcessController.Detail
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ(アコム) 
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
    ///       <description></description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailAcomProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 広告費明細データ検索パラメータ構造体 
        /// </summary>
        public struct FindDetailDataByCondParam
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
            /// <summary>
            /// 年月 
            /// </summary>
            public String yymm;
            /// <summary>
            /// 受注No 
            /// </summary>
            public String jyutNo;
            /// <summary>
            /// 受注明細No 
            /// </summary>
            public String jyMeiNo;
            /// <summary>
            /// 売上明細No 
            /// </summary>
            public String urMeiNo;
            /// <summary>
            /// 商品区分 
            /// </summary>
            public String SyouhinKbn;
            /// <summary>
            /// 依頼番号 
            /// </summary>
            public String IrBan;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// 広告費明細入力プロセスコントローラ 
        /// </summary>
        private static DetailAcomProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター 
        /// </summary>
        private detailAcomServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Acom.Schema.DetailDSAcom _dsAcom;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private DetailAcomProcessController()
        {
            _adapter = CreateAdapter<detailAcomServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        public static DetailAcomProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailAcomProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 発注行番号の取得 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="aplId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="tksBmnSeqNo"></param>
        /// <param name="tksTntSeqNo"></param>
        /// <param name="irban"></param>
        /// <param name="irrowban"></param>
        /// <returns></returns>
        public FindHatyuNumServiceResult FindHatyuNum(String esqId, String aplId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo, String irban, String irrowban)
        {
            FindHatyuNumServiceResult serviceResult = new FindHatyuNumServiceResult();
            findHatyuNumByCondVO vo = new findHatyuNumByCondVO();
            vo._esqId = esqId;
            vo._tksKgyCd = tksKgyCd;
            vo._tksBmnSeqNo = tksBmnSeqNo;
            vo._tksTntSeqNo = tksTntSeqNo;
            vo._Irban = irban;
            vo._Irrowban = irrowban;

            findHatyuNumBycondResult result = _adapter.findHatyuNumget(vo);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            FindHatyuNumServiceResult parseResult = DetailParser.ParseForFindHatyuNum(result);

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;
            return serviceResult;
        }

        /// <summary>
        /// 発注データ取得 
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public FindHatyuDataServiceResult findhatyudata(thb5HikVO vo)
        {
            FindHatyuDataServiceResult serviceResult = new FindHatyuDataServiceResult();
            findThb5HikResult result = _adapter.findHatyuget(vo);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataByCondParseResult parseResult = DetailParser.ParseForFindHatyuDataByCond(result);
            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindDetailDataByCondServiceResult FindMeisaiDataByCond(FindDetailDataByCondParam param)
        {
            //サービス結果 
            FindDetailDataByCondServiceResult serviceResult = new FindDetailDataByCondServiceResult();

            findMeisaiDataCondition condition = new findMeisaiDataCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.jyutNo = param.jyutNo;
            condition.jyMeiNo = param.jyMeiNo;
            condition.urMeiNo = param.urMeiNo;

            //サービスの呼び出し 
            findMeisaiDataResult result = _adapter.findMeisaiDataByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataByCondParseResult parseResult = DetailParser.ParseForFindDetailDataByCond(result);

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 商品名称取得 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string SyouhinName(FindDetailDataByCondParam param)
        {
            findSyohinNameGetCond cond = new findSyohinNameGetCond();
            cond._esqId = param.esqId;
            cond._tksKgyCd = param.tksKgyCd;
            cond._tksBmnSeqNo = param.tksBmnSeqNo;
            cond._tksTntSeqNo = param.tksTntSeqNo;
            cond._syohinKbn = param.SyouhinKbn;

            string result = _adapter.findsyouhinName(cond);

            return result;
        }

        /// <summary>
        /// 発注番号確認 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindDetailDataByCondServiceResult FindHatyuConfirm(FindDetailDataByCondParam param)
        {
            //サービス結果 
            FindDetailDataByCondServiceResult serviceResult = new FindDetailDataByCondServiceResult();

            findHatyuNumByCondVO cond = new findHatyuNumByCondVO();
            cond._esqId = param.esqId;
            cond._tksKgyCd = param.tksKgyCd;
            cond._tksBmnSeqNo = param.tksBmnSeqNo;
            cond._tksTntSeqNo = param.tksTntSeqNo;
            cond._Irban = param.IrBan;

            //サービスの呼び出し 
            findHatyuConfirmResult result = _adapter.findHatyuConfirm(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataByCondParseResult parseResult = DetailParser.ParseForFindHatyuConfirm(result);
            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }
        #endregion メソッド 
    }
}

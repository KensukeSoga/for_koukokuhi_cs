using System;
using System.Collections.Generic;
using System.Text;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHProcessController.Detail.Parser;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Ash.ProcessController.Detail.Parser;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Ash.ProcessController.Detail
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2011/11/14</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class DetailAshProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義.

        /// <summary>
        /// 広告費明細データ検索パラメータ構造体.
        /// </summary>
        public struct FindDetailDataAshByCondParam
        {
            /// <summary>
            /// ログイン担当者ESQID.
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 受注No.
            /// </summary>
            public String jyutNo;
            /// <summary>
            /// 受注明細No.
            /// </summary>
            public String jyMeiNo;
            /// <summary>
            /// 売上明細No.
            /// </summary>
            public String urMeiNo;
            /// <summary>
            /// 業務区分.
            /// </summary>
            public String gyomKbn;
            /// <summary>
            /// タイムスポット区分.
            /// </summary>
            public String tmSpKbn;
            /// <summary>
            /// 国際区分.
            /// </summary>
            public String kokKbn;
            /// <summary>
            /// 請求区分.
            /// </summary>
            public String seiKbn;
        }

        /// <summary>
        /// FD SEQ取得パラメータ構造体.
        /// </summary>
        public struct GetFDSeqParam
        {
            /// <summary>
            /// ログイン担当者ESQID.
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月.
            /// </summary>
            public String yymm;
            /// <summary>
            /// 売上明細No.
            /// </summary>
            public String urMeiNo;
        }

        /// <summary>
        /// 統合パラメータ構造体.
        /// </summary>
        public struct MergeDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID.
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(統合先).
            /// </summary>
            public Isid.KKH.Common.KKHSchema.Detail dsTougouSaki;
            /// <summary>
            /// 広告費明細データセット(統合元).
            /// </summary>
            public Isid.KKH.Common.KKHSchema.Detail dsTougouMoto;
            /// <summary>
            /// 最大更新日付(排他チェック用).
            /// </summary>
            public DateTime maxUpdDate;
            /// <summary>
            /// 媒体コード(統合先).
            /// </summary>
            public string baitaiCd ;
        }

        // 張(JANG)     ADD START   2014/08/15
        /// <summary>
        /// キー局の番組コード.
        /// </summary>
        public struct KeyKyokuBangumiCdParam
        {
            /// <summary>
            /// 営業所（取）コード.
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード.
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO.
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO.
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 媒体コード(統合先)
            /// </summary>
            public string baitaiCd;
        }
        // 張(JANG)     ADD END   2014/08/15
        #endregion パラメータ構造体定義.

        #region インスタンス変数.

        /// <summary>
        /// 広告費明細入力プロセスコントローラ.
        /// </summary>
        private static DetailAshProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター.
        /// </summary>
        private detailAshServiceAdapter _adapter;

        ///// <summary>
        ///// データセット.
        ///// </summary>
        //private static Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        #endregion インスタンス変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタです。.
        /// </summary>
        private DetailAshProcessController()
        {
            _adapter = CreateAdapter<detailAshServiceAdapter>();
        }

        #endregion コンストラクタ.

        #region メソッド.

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。.
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        public static DetailAshProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailAshProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 広告費明細データ検索.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindDetailDataAshByCondServiceResult FindDetailDataAshByCond(FindDetailDataAshByCondParam param)
        {
            //サービス結果.
            FindDetailDataAshByCondServiceResult serviceResult = new FindDetailDataAshByCondServiceResult();

            detailDataAshCondition condition = new detailDataAshCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.jyutNo = param.jyutNo;
            condition.jyMeiNo = param.jyMeiNo;
            condition.urMeiNo = param.urMeiNo;
            condition.gyoumuKbn = param.gyomKbn;
            condition.tmSpKbn = param.tmSpKbn;
            condition.kokKbn = param.kokKbn;
            condition.seiKbn = param.seiKbn;

            //サービスの呼び出し.
            detailDataAshResult result = _adapter.findDetailDataAshByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース.
            FindDetailDataAshByCondParseResult parseResult = DetailAshParser.ParseForFindDetailDataAshByCond(result);
            // サービス結果の生成.
            serviceResult.DetailAshDataSet = parseResult.DetailAshDataSet;
            serviceResult.TargetBaitaiCd = result.targetBaitaiCd;

            return serviceResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetFDSeq(GetFDSeqParam param)
        {
            getFDSeqCondition condition = new getFDSeqCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.urMeiNo = param.urMeiNo;

            //サービスの呼び出し.
            getFDSeqResult result = _adapter.getFDSeq(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return "";
            }

            return result.fdSeq;

        }

        /// <summary>
        /// 受注統合(明細統合).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MergeDataServiceResult MergeData(MergeDataParam param)
        {
            //サービス結果.
            MergeDataServiceResult serviceResult = new MergeDataServiceResult();

            detailDataAshMergeVO condition = new detailDataAshMergeVO();
            condition.esqId = param.esqId;
            condition.tougouSaki = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsTougouSaki)[0];
            condition.tougouMotoList = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsTougouMoto);
            condition.maxUpdDate = param.maxUpdDate;
            condition.baitaiCd = param.baitaiCd;

            detailDataAshMergeResult result = _adapter.mergeData(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            return serviceResult;
        }

        // 張(Jang) ADD START 2014/08/15

        /// <summary>
        /// キー局の番組コード.

        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindKeyKyokuBangumiCdServiceResult FindKeyKyokuBangumiCd(KeyKyokuBangumiCdParam param)
        {
            FindKeyKyokuBangumiCdServiceResult serviceResult = new FindKeyKyokuBangumiCdServiceResult();
            findKeyKyokuBangumiCdResult result = new findKeyKyokuBangumiCdResult();

            findKeyKyokuBangumiCdCondition condition = new findKeyKyokuBangumiCdCondition();
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.sybt = param.baitaiCd;

            result = _adapter.findKeyKyokuBangumiCd(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー.
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            //serviceResult.DetailAshDataSet = result.bangumiCdList;

            //// パース.
            FindKeyKyokuBangumiCdParseResult parseResult = DetailAshParser.ParseForFindKeyKyokuBangumiCd(result);
            //// サービス結果の生成.
            serviceResult.DetailAshDataSet = parseResult.DetailAshDataSet;

            return serviceResult;
        }
        // 張(Jang) ADD END 2014/08/15

        #endregion メソッド.
    }
}
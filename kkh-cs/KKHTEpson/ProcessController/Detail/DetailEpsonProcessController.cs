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
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Epson.ProcessController.Detail.Parser;

namespace Isid.KKH.Epson.ProcessController.Detail
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ
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
    ///       <description>2012/03/02</description>
    ///       <description>IP Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    /// 　　<item>
    ///       <description>2012/04/25</description>
    ///       <description>JSE Tamura</description>
    ///       <description>請求回収機能実装</description>
    ///     </item>
    ///   </list>
    /// </remarks>

    public class DetailEpsonProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 広告費明細データ検索パラメータ構造体 
        /// </summary>
        public struct FindDetailDataEpsonByCondParam
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
            /// 区分
            /// </summary>
            public String kbn;
            ///// <summary>
            ///// 受注No 
            ///// </summary>
            //public String jyutNo;
            ///// <summary>
            ///// 受注明細No 
            ///// </summary>
            //public String jyMeiNo;
            ///// <summary>
            ///// 売上明細No 
            ///// </summary>
            //public String urMeiNo;
            ///// <summary>
            ///// 業務区分 
            ///// </summary>
            //public String gyomKbn;
            ///// <summary>
            ///// タイムスポット区分 
            ///// </summary>
            //public String tmSpKbn;
            ///// <summary>
            ///// 国際区分 
            ///// </summary>
            //public String kokKbn;
            ///// <summary>
            ///// 請求区分 
            ///// </summary>
            //public String seiKbn;
        }

        /// <summary>
        /// 明細登録(一括)パラメータ構造体 
        /// </summary>
        public struct BulkUpdateDetailDataEpsonParam
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
            /// 広告費明細データセット(登録データ) 
            /// </summary>
            public List<Isid.KKH.Common.KKHSchema.Detail> dsDetailList;

            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
            /// <summary>
            /// 入力フラグ 
            /// </summary>
            public String inputFlg;

            /// <summary>
            /// 登録者、更新者用 
            /// </summary>
            public Isid.KKH.Common.KKHSchema.Detail TourokuList;
        }

        /// <summary>
        /// 一括統合パラメータ構造体 
        /// </summary>
        public struct MergeBulkJyutyuDataEpsonParam
        {
            /// <summary>
            /// 広告費明細データセット(登録データ) 
            /// </summary>
            public List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList;
        }

        /// <summary>
        /// 請求回収データ検索パラメータ構造体 
        /// </summary>
        public struct FindSeikyuKaisyuDataByCondParam
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

            /*
            /// <summary>
            /// 受注No 
            /// </summary>
            public String kokKbn;
            /// <summary>
            /// タイム／スポット 
            /// </summary>
            public String tmspKbn;
            /// <summary>
            /// 業務区分 
            /// </summary>
            public String gyomKbn;
            /// <summary>
            /// 受注No 
            /// </summary>
            public String jyutNo;
            /// <summary>
            /// ソート順(媒体順／件名順) 
            /// </summary>
            public String orderKbn;
            */

            /// <summary>
            /// 変更チェックフラグ
            /// </summary>
            public bool updateCheckFlag;
        }


        #endregion パラメータ構造体定義

        #region インスタンス変数

        /// <summary>
        /// 広告費明細入力プロセスコントローラ
        /// </summary>
        private static DetailEpsonProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター
        /// </summary>
        private detailEpsonServiceAdapter _adapter;

        ///// <summary>
        ///// データセット
        ///// </summary>
        //private static Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private DetailEpsonProcessController()
        {
            _adapter = CreateAdapter<detailEpsonServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        public static DetailEpsonProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailEpsonProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 広告費明細データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindDetailDataEpsonByCondServiceResult FindDetailDataEpsonByCond(FindDetailDataEpsonByCondParam param)
        {
            //サービス結果 
            FindDetailDataEpsonByCondServiceResult serviceResult = new FindDetailDataEpsonByCondServiceResult();

            detailDataEpsonCondition condition = new detailDataEpsonCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.kbn = param.kbn;
            //condition.jyutNo = param.jyutNo;
            //condition.jyMeiNo = param.jyMeiNo;
            //condition.urMeiNo = param.urMeiNo;
            //condition.gyoumuKbn = param.gyomKbn;
            //condition.tmSpKbn = param.tmSpKbn;
            //condition.kokKbn = param.kokKbn;
            //condition.seiKbn = param.seiKbn;

            //サービスの呼び出し 
            detailDataEpsonResult result = _adapter.findDetailDataEpsonByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataEpsonByCondParseResult parseResult = DetailEpsonParser.ParseForFindDetailDataEpsonByCond(result);
            // サービス結果の生成 
            serviceResult.DetailEpsonDataSet = parseResult.DetailEpsonDataSet;

            return serviceResult;
        }


        /// <summary>
        /// 明細登録(複数一括) 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public BulkUpdateDetailDataEpsonServiceResult BulkUpdateDetailDataEpson(BulkUpdateDetailDataEpsonParam param)
        {
            //サービス結果 
            BulkUpdateDetailDataEpsonServiceResult serviceResult = new BulkUpdateDetailDataEpsonServiceResult();

            detailDataEpsonBulkUpdateVO condition = new detailDataEpsonBulkUpdateVO();
            condition.egCd = param.egCd;
            condition.esqId = param.esqId;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.inputFlg = param.inputFlg;
            condition.touIkkatsuThb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(param.TourokuList);
            List<detailDataEpsonVO> detailDataVoList = new List<detailDataEpsonVO>();

            foreach (Isid.KKH.Common.KKHSchema.Detail dsDetail in param.dsDetailList)
            {
                String kbn = ((Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[])dsDetail.THB2KMEI.Select("",""))[0].hb2Name21;

                if (String.Equals(kbn, "1"))
                {
                    detailDataEpsonVO detailDataVo = new detailDataEpsonVO();
                    detailDataVo.kbn = "1";
                    detailDataVo.thb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(dsDetail)[0];
                    detailDataVo.thb2Kmei = DetailDataSetConverter.ConvertForTHB2KMEI(dsDetail);
                    detailDataVoList.Add(detailDataVo);
                }
                else if (String.Equals(kbn, "2"))
                {
                    detailDataEpsonVO detailDataVo = new detailDataEpsonVO();
                    detailDataVo.kbn = "2";
                    detailDataVo.thb2Kmei = DetailDataSetConverter.ConvertForTHB2KMEI(dsDetail);
                    detailDataVoList.Add(detailDataVo);
                }
            }

            condition.detailDataEpsonVOList = detailDataVoList.ToArray();
            condition.maxUpdDate = param.maxUpdDate;

            detailDataEpsonBulkUpdateResult result = _adapter.bulkUpdateDetailDataEpson(condition);

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

        /// <summary>
        /// 一括統合 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MergeBulkJyutyuDataEpsonServiceResult MergeBulkJyutyuDataEpson(MergeBulkJyutyuDataEpsonParam param)
        {
            //サービス結果
            MergeBulkJyutyuDataEpsonServiceResult serviceResult = new MergeBulkJyutyuDataEpsonServiceResult();

            bulkJyutyuDataEpsonMergeVO vo = new bulkJyutyuDataEpsonMergeVO();
            List<jyutyuDataMergeVO> jyutyuDataMergeVOList = new List<jyutyuDataMergeVO>();

            List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList
                = param.mergeJyutyuDataParamList;
            foreach (Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam mergeJyutyuDataParam in mergeJyutyuDataParamList)
            {
                jyutyuDataMergeVO jyutyuDataMergeVO = new jyutyuDataMergeVO();
                jyutyuDataMergeVO.esqId = mergeJyutyuDataParam.esqId;
                jyutyuDataMergeVO.tougouSaki = DetailDataSetConverter.ConvertForTHB1DOWN(mergeJyutyuDataParam.dsTougouSaki)[0];
                jyutyuDataMergeVO.tougouMotoList = DetailDataSetConverter.ConvertForTHB1DOWN(mergeJyutyuDataParam.dsTougouMoto);
                jyutyuDataMergeVO.maxUpdDate = mergeJyutyuDataParam.maxUpdDate;
                jyutyuDataMergeVOList.Add(jyutyuDataMergeVO);
            }

            vo.jyutyuDataMergeVOList = jyutyuDataMergeVOList.ToArray();

            bulkJyutyuDataEpsonMergeResult result = _adapter.mergeBulkJyutyuDataEpson(vo);

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

        /// <summary>
        /// 請求回収データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindSeikyuDataEpsonByCondServiceResult FindSeikyuKaisyuDataByCond(FindSeikyuKaisyuDataByCondParam param)
        {
            //サービス結果 
            FindSeikyuDataEpsonByCondServiceResult serviceResult = new FindSeikyuDataEpsonByCondServiceResult();

            seikyuDataCondition condition = new seikyuDataCondition();
            
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.bmncd = param.tksBmnSeqNo;
            condition.tntcd = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            
            //サービスの呼び出し 
            seikyuDataEpsonResult result = _adapter.findSeikyuDataEpsonByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindSeikyuDataEpsonByCondParseResult parseResult = DetailEpsonParser.ParseForFindSeikyuDataEpsonByCond(result);
            
            // サービス結果の生成 
            serviceResult.SeikyuEpsonDataSet = parseResult.SeikyuEpsonDataSet;

            return serviceResult;
        }

        #endregion メソッド
    }
}
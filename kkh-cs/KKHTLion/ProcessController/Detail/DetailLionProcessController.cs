using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.ProcessController.Detail.Parser;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Detail
{   /// <summary>
    /// 件名変更プロセスコントローラ(ライオン) 
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
    ///       <description>2012/02/09</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailLionProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 広告費明細データ検索パラメータ構造体 
        /// </summary>
        public struct FindDetailDataLionByCondParam
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
            /// 媒体区分 
            /// </summary>
            public String code1;
            /// <summary>
            /// カードNO
            /// </summary>
            public String code6;
        }

        /// <summary>
        /// カードNO一覧パラメータ構造体 
        /// </summary>
        public struct FindLionCardNoItrParam
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

        /// <summary>
        /// コード一覧パラメータ構造体 
        /// </summary>
        public struct FindLionCodeItrParam
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

        /// <summary>
        /// カードNO取得パラメータ構造体 
        /// </summary>
        public struct FindLionCardNoGetParam
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

        }
        #endregion パラメータ構造体定義
        #region "インスタンス変数"

        /// <summary>
        /// LIONプロセスコントローラー
        /// </summary>
        public static DetailLionProcessController _processController;

        /// <summary>
        /// LIONサービスアダプター
        /// </summary>
        public lionDetailServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Lion.Schema.DetailDSLion _dsLion;

        #endregion "インスタンス変数"

        #region "コンストラクタ"

        public DetailLionProcessController()
        {
            _adapter = CreateAdapter<lionDetailServiceAdapter>();
        }

        #endregion "コンストラクタ"

        #region "メソッド"

        /// <summary>
        /// Lionプロセスコントローラーのインスタンスを返します 
        /// </summary>
        /// <returns></returns>
        public static DetailLionProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailLionProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        internal UpdateSubjectDataServiceResult UpdateSubjectData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRow)
         {
             UpdateSubjectDataServiceResult serviceResult = new UpdateSubjectDataServiceResult();
             updateSubjectVO udvo = new updateSubjectVO();

             for (int i = 0; i < dataRow.Length ; i++)
             {
                 udvo._egCd = dataRow[i].hb1EgCd;
                 udvo._kkNameKJ = dataRow[i].hb1KKNameKJ;
                 udvo._tksKgyCd = dataRow[i].hb1TksKgyCd;
                 udvo._tksBmnSeqNo = dataRow[i].hb1TksBmnSeqNo;
                 udvo._TksTntSeqNo = dataRow[i].hb1TksTntSeqNo;
                 udvo._YYMM = dataRow[i].hb1Yymm;
//               udvo._jyutNo = dataRow[i].hb2JyutNo;
                 udvo._jyutNo = dataRow[i].hb1JyutNo;
                 udvo._jyMeiNo = dataRow[i].hb1JyMeiNo;
                 udvo._lUrmeino = dataRow[i].hb1UrMeiNo;
                 updateSubjectResult result = _adapter.updateSubjectData(udvo);
                 serviceResult.DetailDataSet = result._thb1DownList;
             }
             return serviceResult;
         }

        /// <summary>
        /// カードNOの取得 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindLionByCondServiceResult FindLionCardNoGet(FindLionCardNoGetParam param)
        {
            FindLionByCondServiceResult serviceResult = new FindLionByCondServiceResult();
            findLionCardNoGetCondition condition = new findLionCardNoGetCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.jyutno = param.jyutNo;
            condition.jymeino = param.jyMeiNo;
            condition.urmeino = param.urMeiNo;

            //サービスの呼び出し 
            findLionCardNoGetResult result = _adapter.findLionCardNoGetByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataLionByCondParseResult parseResult = FindLionCardNoGetParser.ParseForFindLionCardNoGetByCond(result);
            // サービス結果の生成 
            serviceResult.DetailLionDataSet = parseResult.DetailLionDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 広告費明細データの検索・表示 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindLionByCondServiceResult FindLionDetail(FindDetailDataLionByCondParam param)
        {
            FindLionByCondServiceResult serviceResult = new FindLionByCondServiceResult();
            findLionDetailCondition condition = new findLionDetailCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.bmncd = param.tksBmnSeqNo;
            condition.tntcd = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.jyutno = param.jyutNo;
            condition.jymeino = param.jyMeiNo;
            condition.urmeino = param.urMeiNo;
            condition.code1 = param.code1;
            condition.code6 = param.code6;

            //サービスの呼び出し 
            findLionDetailResult result = _adapter.findLionDetailByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindDetailDataLionByCondParseResult parseResult = FindDetailLionParser.ParseForFindDetailLionNoGetByCond(result);
            // サービス結果の生成 
            serviceResult.DetailLionDataSet = parseResult.DetailLionDataSet;

            return serviceResult;

        }

        /// <summary>
        /// カードNOから媒体区分の検索
        /// </summary>
        /// <param name="cdno"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindLionCardNoItrServiceResult FindLionCardNoItrService(String cdno, FindLionCardNoItrParam param)
        {
            FindLionCardNoItrServiceResult serviceResult = new FindLionCardNoItrServiceResult();
            findLionCardNoItrCondition cond = new findLionCardNoItrCondition();

            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.code = cdno.ToString();
            //サービスの呼び出し 
            findLionCardNoItrResult result = _adapter.cardNoItrData(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }

            // パース
            FindLionCardNoItrServiceResult parseResult = FindLionCardNoItrParser.ParseForFindLionCardNoItr(result);

            // サービス結果の生成
            serviceResult.CNILionDataSet = parseResult.CNILionDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 媒体種別から媒体CD,名称の検索
        /// </summary>
        /// <param name="cdno"></param>
        /// <param name="btCD"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindLionCodeItrServiceResult FindLionCodeItrService(String cdno, String btCD, FindLionCodeItrParam param)
        {
            FindLionCodeItrServiceResult serviceResult = new FindLionCodeItrServiceResult();
            findLionCodeItrCondition cond = new findLionCodeItrCondition();

            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond.tksBmnSeqNo = param.tksBmnSeqNo;
            cond.tksTntSeqNo = param.tksTntSeqNo;
            cond.cdNo = cdno.ToString();
            if(btCD != null)
            {
                cond.btCd = btCD.ToString();
            }
            
            //サービスの呼び出し 
            findLionCodeItrResult result = _adapter.codeItrData(cond);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                return null;
            }

            // パース
            FindLionCodeItrServiceResult parseResult = FindLionCodeItrParser.ParseForFindLionCodeItr(result);

            // サービス結果の生成
            serviceResult.CILionDataSet = parseResult.CILionDataSet;

            return serviceResult;
        }

        /// <summary>
        /// TVSpotデータを検索する
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="egCd"></param>
        /// <param name="tksKgyCd"></param>
        /// <param name="bmn"></param>
        /// <param name="tnt"></param>
        /// <param name="jobNo"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        public FindLionTVSpotServiceResult FindLionTVSpotService(String esqId, 
            String egCd, 
            String tksKgyCd,
            String bmn, 
            String tnt, 
            String jobNo,
            String ym)
        {
            // サービス結果
            FindLionTVSpotServiceResult serviceResult = new FindLionTVSpotServiceResult();

            findLionTVSpotCondition condition = new findLionTVSpotCondition();

            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.bmncd = bmn;
            condition.tntcd = tnt;
            condition.jobNo = jobNo;
            condition.YM = ym;

            // サービスの呼び出し
            findLionTVSpotResult result = _adapter.findLionTVSpotByCond(condition);

            errorInfo info = result.errorInfo;

            if (( info != null ) && ( info.error ))
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;

                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindLionTVSpotServiceResult parseResult = FindLionTVSpotParser.ParseForFindLionTVSpot(result);

            _dsLion = parseResult.dsDetailLion;

            // サービス結果の生成
            serviceResult.dsDetailLion = parseResult.dsDetailLion;

            return serviceResult;
        }

        #endregion "メソッド"
    }
}

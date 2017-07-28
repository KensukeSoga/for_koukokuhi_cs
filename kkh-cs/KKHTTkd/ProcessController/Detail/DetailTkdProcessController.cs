using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Tkd.ProcessController.Detail.Parser;

namespace Isid.KKH.Tkd.ProcessController.Detail
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ(武田薬品) 
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
    ///       <description>2012/01/05</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailTkdProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 実施No最大値検索パラメータ構造体 
        /// </summary>
        internal struct FindMaxJissiNoByCondParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            internal string esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            internal string egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            internal string tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            internal string tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            internal string tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            internal string yymm;
        }

        /// <summary>
        /// 使用済実施Noの件数検索パラメータ構造体 
        /// </summary>
        internal struct FindJissiNoCntByCondParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            internal string esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            internal string egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            internal string tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            internal string tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            internal string tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            internal string yymm;
            /// <summary>
            /// 受注No 
            /// </summary>
            internal string jyutNo;
            /// <summary>
            /// 受注明細No 
            /// </summary>
            internal string jyMeiNo;
            /// <summary>
            /// 売上明細No 
            /// </summary>
            internal string urMeiNo;
            /// <summary>
            /// 実施No 
            /// </summary>
            internal string jissiNo;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// 広告費明細入力プロセスコントローラ 
        /// </summary>
        private static DetailTkdProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター 
        /// </summary>
        private detailTakedaServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private DetailTkdProcessController()
        {
            _adapter = CreateAdapter<detailTakedaServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        internal static DetailTkdProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailTkdProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 実施NO関係 
        /// </summary>
        /// <param name="esqId">esqId</param>
        /// <param name="aplId">aplId</param>
        /// <param name="egCd">営業所（取）コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="tksBmnSeqNo">得意先部門SEQNO</param>
        /// <param name="tksTntSeqNo">得意先担当SEQNO</param>
        /// <param name="yymm">年月</param>
        /// <param name="jyutNo">受注No</param>
        /// <param name="jyMeiNo">受注明細No</param>
        /// <param name="urMeiNo">売上明細No</param>
        /// <param name="haibun">配分率</param>
        /// <param name="renban">連番</param>
        /// <param name="fuyoOrUpdown">判断値</param>
        /// <param name="baitaiCd">媒体コード</param>
        /// <param name="jissiNo">実施No</param>
        /// <returns></returns>
        internal UpdateJissiNoFuyoServiceResult UpdateJissiNo(String esqId, String aplId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo, String yymm, String[] jyutNo, String[] jyMeiNo, String[] urMeiNo, String[] haibun, String[] renban, String fuyoOrUpdown, String[] baitaiCd, String[] jissiNo)
        {
            //サービス結果 
            UpdateJissiNoFuyoServiceResult serviceResult = new UpdateJissiNoFuyoServiceResult();
            autoJissiBycondVO atjvo = new autoJissiBycondVO();
            atjvo._esqId = esqId;
            atjvo._aplId = aplId;
            atjvo._egCd = egCd;
            atjvo._tksKgyCd = tksKgyCd;
            atjvo._tksBmnSeqNo = tksBmnSeqNo;
            atjvo._tksTntSeqNo = tksTntSeqNo;
            atjvo._YYMM = yymm;
            atjvo._jyutNo = jyutNo;
            atjvo._jyMeiNo = jyMeiNo;
            atjvo._urMeiNo = urMeiNo;
            atjvo._haibun = haibun;
            atjvo._Renban = renban;
            atjvo.fuyoOrUpdown = fuyoOrUpdown;
            atjvo._BaitaiCd = baitaiCd;
            atjvo._JissiNo = jissiNo;

            autoJissiBycondResult result = _adapter.autoNoBycond(atjvo);

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
        /// THB2KMEIのSELECT
        /// </summary>
        /// <param name="esqId">esqId</param>
        /// <param name="aplId">aplId</param>
        /// <param name="egCd">営業所（取）コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="tksBmnSeqNo">得意先部門SEQNO</param>
        /// <param name="tksTntSeqNo">得意先担当SEQNO</param>
        /// <param name="yymm">年月</param>      
        /// <param name="creativeFlg">クリエイティブフラグ</param>      
        /// <returns></returns>
        internal FindJyutyuDataByCondServiceResult FindThb2Kmei(
            String esqId, 
            String aplId, 
            String egCd, 
            String tksKgyCd, 
            String tksBmnSeqNo, 
            String tksTntSeqNo, 
            String yymm,
            String creativeFlg)
        {
            FindJyutyuDataByCondServiceResult serviceResult = new FindJyutyuDataByCondServiceResult();
            findThb2KmeiBycondVO vo = new findThb2KmeiBycondVO();
            vo._esqId = esqId;
            vo._aplId = aplId;
            vo._egCd = egCd;
            vo._tksKgyCd = tksKgyCd;
            vo._tksBmnSeqNo = tksBmnSeqNo;
            vo._tksTntSeqNo = tksTntSeqNo;
            vo._YYMM = yymm;
            vo.creativeFlg = creativeFlg;

            findThb2KmeiBycondResult result = _adapter.jissiNo(vo);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            FindJyutyuDataByCondServiceResult parseResult = DetailParser.ParseForFindThb2KmeiDataByCond(result);
            _dsDetail = parseResult.DetailDataSet;

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;
            return serviceResult;
        }

        /// <summary>
        /// 実施Noの最大値検索 
        /// </summary>
        /// <param name="param">実施No最大値検索パラメータ</param>
        /// <param name="messageCode"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        internal decimal FindMaxJissiNoByCond(FindMaxJissiNoByCondParam param
                                          , out string messageCode
                                          , out string[] note)
        {
            findMaxJissiNoCondition condition = new findMaxJissiNoCondition();

            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;

            // サービスの呼び出し 
            findMaxJissiNoByCondResult result = _adapter.findMaxJissiNoByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                messageCode = info.errorCode;
                note = info.note;
                return 0;
            }

            messageCode = null;
            note = null;
            return result.jissiNo;
        }

        /// <summary>
        /// 使用済実施Noの件数検索 
        /// </summary>
        /// <param name="param">使用済実施Noの件数検索パラメータ</param>
        /// <param name="messageCode"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        internal decimal FindJissiNoCntByCond(FindJissiNoCntByCondParam param
                                          , out string messageCode
                                          , out string[] note)
        {
            findJissiNoCntCondition condition = new findJissiNoCntCondition();

            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.jyutNo = param.jyutNo;
            condition.jyMeiNo = param.jyMeiNo;
            condition.urMeiNo = param.urMeiNo;
            condition.jissiNo = param.jissiNo;

            // サービスの呼び出し 
            findJissiNoCntByCondResult result = _adapter.findJissiNoCntByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                messageCode = info.errorCode;
                note = info.note;
                return 0;
            }

            messageCode = null;
            note = null;
            return result.jissiNoCnt;
        }

        #endregion メソッド 
    }
}

using System;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.ProcessController.Claim.Parser;

namespace Isid.KKH.Acom.ProcessController.Claim
{
    /// <summary>
    /// 請求データプロセスコントローラ(アコム) 
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
    ///       <description>2012/2/09</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ClaimAcomProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 請求データ検索パラメータ構造体 
        /// </summary>
        internal struct FindClaimByCondParam
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
            /// 種別 
            /// </summary>
            internal string sybt;
        }

        /// <summary>
        /// 送信フラグ更新パラメータ構造体 
        /// </summary>
        internal struct UpdateOutFlgParam
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
            /// 受注No 
            /// </summary>
            internal string[] jyutNo;
            /// <summary>
            /// 受注明細No 
            /// </summary>
            internal string[] jyMeiNo;
            /// <summary>
            /// 売上明細No 
            /// </summary>
            internal string[] urMeiNo;
            /// <summary>
            /// 連番 
            /// </summary>
            internal string[] renban;
            /// <summary>
            /// 請求書No 
            /// </summary>
            internal string[] seiNo;
            /// <summary>
            /// 請求書行No 
            /// </summary>
            internal string[] seiGyoNo;
            /// <summary>
            /// 請求年月日 
            /// </summary>
            internal string[] seiYymm;
            /// <summary>
            /// 送信フラグ 
            /// </summary>
            internal string outFlg;
            /// <summary>
            /// 出力日時 
            /// </summary>
            internal string outDate;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// プロセスコントローラ 
        /// </summary>
        private static ClaimAcomProcessController _processController;

        /// <summary>
        /// サービスアダプター 
        /// </summary>
        private claimAcomServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Acom.Schema.ClaimDSAcom _ds;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private ClaimAcomProcessController()
        {
            _adapter = CreateAdapter<claimAcomServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        ///プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>プロセスコントローラのインスタンス</returns>
        internal static ClaimAcomProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ClaimAcomProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 請求データ検索 
        /// </summary>
        /// <param name="param">請求データ検索パラメータ構造体</param>
        /// <returns>請求データ検索サービス結果</returns>
        internal FindClaimAcomByCondServiceResult FindClaimByCond(FindClaimByCondParam param)
        {
            // 請求データ検索サービス結果 
            FindClaimAcomByCondServiceResult serviceResult = new FindClaimAcomByCondServiceResult();

            findClaimCondition condition = new findClaimCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.sybt = param.sybt;

            // サービスの呼び出し 
            findClaimByCondResult result = _adapter.findClaimByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindClaimAcomByCondParseResult parseResult = ClaimAcomParser.ParseForFindClaimAcomByCond(result);
            _ds = parseResult.ClaimAcomDataSet;

            // サービス結果の生成 
            serviceResult.ClaimDataSet = parseResult.ClaimAcomDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 送信フラグ更新 
        /// </summary>
        /// <param name="param">送信フラグ更新パラメータ構造体</param>
        /// <returns>送信フラグ更新サービス結果</returns>
        internal UpdateOutFlgServiceResult UpdateOutFlg(UpdateOutFlgParam param)
        {
            // 送信フラグ更新サービス結果 
            UpdateOutFlgServiceResult serviceResult = new UpdateOutFlgServiceResult();

            updateOutFlgVO vo = new updateOutFlgVO();
            vo.esqId = param.esqId;
            vo.egCd = param.egCd;
            vo.tksKgyCd = param.tksKgyCd;
            vo.tksBmnSeqNo = param.tksBmnSeqNo;
            vo.tksTntSeqNo = param.tksTntSeqNo;
            vo.jyutNo = param.jyutNo;
            vo.jyMeiNo = param.jyMeiNo;
            vo.urMeiNo = param.urMeiNo;
            vo.renban = param.renban;
            vo.outDate = param.outDate;
            vo.outFlg = param.outFlg;
            vo.seiNo = param.seiNo;
            vo.seiGyoNo = param.seiGyoNo;
            vo.seiYymm = param.seiYymm;

            // サービスの呼び出し 
            updateOutFlgResult result = _adapter.updateOutFlg(vo);

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

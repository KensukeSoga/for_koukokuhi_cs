using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Skyp.ProcessController.Detail.Parser;

namespace Isid.KKH.Skyp.ProcessController.Detail
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ(スカパー) 
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
    ///       <description>2011/12/21</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailSkypProcessController : KKHProcessController
    {
        #region パラメータ構造体定義 

        /// <summary>
        /// 並び順情報検索パラメータ構造体 
        /// </summary>
        internal struct FindOrderDataByCondParam
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
            /// 媒体区分名 
            /// </summary>
            internal string baitaikbn;
        }

        /// <summary>
        /// 並び順データ更新パラメータ構造体 
        /// </summary>
        internal struct UpdateOrderDataParam
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
            /// 並び順 
            /// </summary>
            internal string[] order;
            /// <summary>
            /// 媒体名称 
            /// </summary>
            internal string[] baitaiNm;
            /// <summary>
            /// 媒体区分 
            /// </summary>
            internal string[] baitaiKbn;
        }

        #endregion パラメータ構造体定義 

        #region インスタンス変数 

        /// <summary>
        /// 広告費明細入力プロセスコントローラ(スカパー) 
        /// </summary>
        private static DetailSkypProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター(スカパー) 
        /// </summary>
        private detailSkypServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static Isid.KKH.Skyp.Schema.DetailDSSkyp _dsSkyp;

        #endregion インスタンス変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private DetailSkypProcessController()
        {
            _adapter = CreateAdapter<detailSkypServiceAdapter>();
        }

        #endregion コンストラクタ 

        #region メソッド 

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        internal static DetailSkypProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailSkypProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 並び順データ検索 
        /// </summary>
        /// <param name="param">並び順情報検索パラメータ構造体</param>
        /// <returns>並び順データ検索サービス結果</returns>
        internal FindOrderByCondServiceResult FindOrderDataByCond(FindOrderDataByCondParam param)
        {
            // 並び順データ検索サービス結果 
            FindOrderByCondServiceResult serviceResult = new FindOrderByCondServiceResult();

            findOrderCondition condition = new findOrderCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.ym = param.yymm;
            condition.baitaikbn = param.baitaikbn;
            // サービスの呼び出し 
            findOrderByCondResult result = _adapter.findOrderByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindOrderByCondParseResult parseResult = DetailParser.ParseForFindOrderDataByCond(result);
            _dsSkyp = parseResult.DetailDataSet;

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 並び順データ更新 
        /// </summary>
        /// <param name="param">並び順データ検索パラメータ構造体</param>
        /// <returns>並び順データ更新サービス結果</returns>
        internal UpdateOrderServiceResult UpdateOrderData(UpdateOrderDataParam param)
        {
            // 並び順データ更新サービス結果 
            UpdateOrderServiceResult serviceResult = new UpdateOrderServiceResult();

            updateOrderVO vo = new updateOrderVO();            
            vo.esqId = param.esqId;
            vo.egCd = param.egCd;
            vo.tksKgyCd = param.tksKgyCd;
            vo.tksBmnSeqNo = param.tksBmnSeqNo;
            vo.tksTntSeqNo = param.tksTntSeqNo;
            vo.yymm = param.yymm;
            vo.order = param.order;
            vo.baitaiNm = param.baitaiNm;
            vo.baitaiKbn = param.baitaiKbn;

            // サービスの呼び出し 
            updateOrderResult result = _adapter.updateOrderData(vo);

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

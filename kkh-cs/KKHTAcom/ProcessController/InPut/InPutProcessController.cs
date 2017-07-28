using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Acom.ProcessController.InPut;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.ProcessController.InPut.Parser;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.ProcessController.InPut.Converter;

namespace Isid.KKH.Acom.ProcessController.InPut
{
    /// <summary>
    /// 取込情報プロセスコントローラ
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
    ///       <description>2011/11/10</description>
    ///       <description>HLC K.Fujisaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class InPutProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ 
        /// </summary>
        private static InPutProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター 
        /// </summary>
        private inputServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static InPutHik _dsHik;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private InPutProcessController()
        {
            _adapter = CreateAdapter<inputServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static InPutProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new InPutProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// アコム発注取込情報検索 
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindHikByCondServiceResult FindHikByCond(String tkskgycd, String tksbmnseqno, String tkstntseqno, String sybt, String year)
        {
            // サービス結果 
            FindHikByCondServiceResult serviceResult = new FindHikByCondServiceResult();

            hikCommonCondition condition = new hikCommonCondition();
            condition.tkskgycd = tkskgycd;
            condition.tksbmnseqno = tksbmnseqno;
            condition.tkstntseqno = tkstntseqno;
            condition.syubetsu = sybt;
            condition.year = year;

            // サービスの呼び出し 
            hikSearchResult result = _adapter.findHikByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindHikByCondParseResult parseResult = InPutParser.ParseForFindHikByCond(result);
            _dsHik = parseResult.HikDataSet;

            // サービス結果の生成 
            serviceResult.HikDataSet = parseResult.HikDataSet;

            return serviceResult;
        }


        /// <summary>
        /// アコム発注取込情報(日付)検索 
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindHikDateCntByCondServiceResult FindHikDateCntByCond(InPutHik dsInPutHik)
        {
            // サービス結果 
            FindHikDateCntByCondServiceResult serviceResult = new FindHikDateCntByCondServiceResult();
            hikCommonCondition condition = new hikCommonCondition();


            // サービスの呼び出し 
            hikSearchResult result = _adapter.findHikDateCntByCond(HikFileConverter.ConvertForHikDateCntSelect(dsInPutHik));

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindHikByCondParseResult parseResult = InPutParser.ParseForFindHikDateCntByCond(result);
            _dsHik = parseResult.HikDataSet;

            // サービス結果の生成 
            serviceResult.HikDataSet = parseResult.HikDataSet;

            return serviceResult;
        }


        /// <summary>
        /// アコム発注取込比較情報検索 
        /// </summary>
        /// <returns>検索サービス結果</returns>
        public FindHikCheckDataByCondServiceResult FindHikCheckDataByCond(InPutHik dsInPutHik)
        {
            FindHikCheckDataByCondServiceResult serviceResult = new FindHikCheckDataByCondServiceResult();

            //サービス呼び出し(手順① 登録前比較用発注データ取得)
            hikSearchResult result = _adapter.findHikCheckDataByCond(HikFileConverter.ConvertForHikFileInsert(dsInPutHik));

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            // パース 
            FindHikByCondParseResult parseResult = InPutParser.ParseForFindHikCheckDataByCond(result);
            _dsHik = parseResult.HikDataSet;

            // サービス結果の生成 
            serviceResult.HikDataSet = parseResult.HikDataSet;

            return serviceResult;
        }

        /// <summary>
        /// アコム発注取込ファイル登録 
        /// </summary>
        /// <param name="dsInPutHik">保存対象データセット</param>
        /// <returns>実行結果</returns>
        public HikFileInsertServiceResult RegistHikInsert(InPutHik dsInPutHik)
        {
            HikFileInsertServiceResult serviceResult = new HikFileInsertServiceResult();
          
            //サービスの呼び出し(手順③ 発注データ登録)
            hikRegistResult result = _adapter.registHikByCond(HikFileConverter.ConvertForHikFileInsert(dsInPutHik));

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


        #endregion
    }
}

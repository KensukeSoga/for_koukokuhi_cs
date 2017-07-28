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

namespace Isid.KKH.Common.KKHProcessController.Detail
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
    ///       <description>2011/11/14</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class DetailProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 受注登録内容データ検索パラメータ構造体 
        /// </summary>
        public struct FindJyutyuDataByCondParam
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
            /// 終了年月 
            /// </summary>
            public String yymmto;
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
            /// <summary>
            /// 変更チェックフラグ
            /// </summary>
            public bool updateCheckFlag;
            /// <summary>
            /// 件名
            /// </summary>
            public String kkNameKj;
        }

        /// <summary>
        /// 表示データ登録(明細登録)パラメータ構造体 
        /// </summary>
        public struct UpdateDisplayDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;

            /// <summary>
            /// 広告費明細データセット(登録データ) 
            /// </summary>
            public KKHSchema.Detail dsDetail;

            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;

            /// <summary>
            /// 登録者更新者対応Update用
            /// </summary>
            public KKHSchema.Detail TouKoudsDetail;
        }

        /// <summary>
        /// 明細登録(一括)パラメータ構造体 
        /// </summary>
        public struct BulkUpdateDetailDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;

            /// <summary>
            /// 広告費明細データセット(登録データ) 
            /// </summary>
            public List<KKHSchema.Detail> dsDetailList;

            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
        }

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
        }

        /// <summary>
        /// 受注削除パラメータ構造体 
        /// </summary>
        public struct DeleteJyutyuDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(削除対象データ) 
            /// </summary>
            public KKHSchema.Detail dsDetail;
            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
        }

        /// <summary>
        /// 年月変更パラメータ構造体 
        /// </summary>
        public struct ChangeSeikyuYymmParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(更新対象データ) 
            /// </summary>
            public KKHSchema.Detail dsDetail;
            /// <summary>
            /// 更新後請求年月 
            /// </summary>
            public string yymmNew;
            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
        }

        /// <summary>
        /// 新規登録パラメータ構造体 
        /// </summary>
        public struct RegisterJyutyuDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(更新対象データ) 
            /// </summary>
            public KKHSchema.Detail dsDetail;
        }

        /// <summary>
        /// 受注統合パラメータ構造体 
        /// </summary>
        public struct MergeJyutyuDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(統合先) 
            /// </summary>
            public KKHSchema.Detail dsTougouSaki;
            /// <summary>
            /// 広告費明細データセット(統合元) 
            /// </summary>
            public KKHSchema.Detail dsTougouMoto;
            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
        }

        /// <summary>
        /// 受注解除パラメータ構造体 
        /// </summary>
        public struct MergeCancelJyutyuDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 広告費明細データセット(統合先) 
            /// </summary>
            public KKHSchema.Detail dsTougouSaki;
            /// <summary>
            /// 最大更新日付(排他チェック用) 
            /// </summary>
            public DateTime maxUpdDate;
        }

        /// <summary>
        /// 受注No統合Insertパラメータ構造体 
        /// </summary>
        public struct InTjyutnoDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// アプリID
            /// </summary>
            public String aplId;
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
            /// 費目コード 
            /// </summary>
            public String himkCd;
            /// <summary>
            /// 業務区分 
            /// </summary>
            public String gyomKbn;
            /// <summary>
            /// 国際マス正味区分 
            /// </summary>
            public String msKbn;
            /// <summary>
            /// タイムスポット区分 
            /// </summary>
            public String tmsKbn;
            /// <summary>
            /// 国際区分 
            /// </summary>
            public String kokKbn;
            /// <summary>
            /// 請求区分 
            /// </summary>
            public String seiKbn;
            /// <summary>
            /// 商品No
            /// </summary>
            public String syoNo;
            /// <summary>
            /// 件名 
            /// </summary>
            public String kknameKj;
            /// <summary>
            /// 営業画面タイプ 
            /// </summary>
            public String egGamenType;
            /// <summary>
            /// 企画・製版区分 
            /// </summary>
            public String kkakShanKbn;
            /// <summary>
            /// 取り料金 
            /// </summary>
            public String toriRyouKin;
            /// <summary>
            /// 請求金額 
            /// </summary>
            public String seikyuKin;
            /// <summary>
            /// 値引率
            /// </summary>
            public String nebikiRitu;
            /// <summary>
            /// 値引額 
            /// </summary>
            public String nebikiGaku;
            /// <summary>
            /// 消費税区分 
            /// </summary>
            public String szeiKbn;
            /// <summary>
            /// 消費税率 
            /// </summary>
            public String szeiRitu;
            /// <summary>
            /// 消費税額 
            /// </summary>
            public String szeiGaku;
            /// <summary>
            /// 費目名 
            /// </summary>
            public String himkNmkj;
            /// <summary>
            /// フィールド1
            /// </summary>
            public String Filed1;
            /// <summary>
            /// フィールド2
            /// </summary>
            public String Filed2;
            /// <summary>
            /// フィールド3
            /// </summary>
            public String Filed3;
            /// <summary>
            /// フィールド4
            /// </summary>
            public String Filed4;
            /// <summary>
            /// フィールド5
            /// </summary>
            public String Filed5;
            /// <summary>
            /// フィールド6
            /// </summary>
            public String Filed6;
            /// <summary>
            /// フィールド7
            /// </summary>
            public String Filed7;
            /// <summary>
            /// フィールド8
            /// </summary>
            public String Filed8;
            /// <summary>
            /// フィールド9
            /// </summary>
            public String Filed9;
            /// <summary>
            /// フィールド10
            /// </summary>
            public String Filed10;
            /// <summary>
            /// フィールド11
            /// </summary>
            public String Filed11;
            /// <summary>
            /// フィールド12
            /// </summary>
            public String Filed12;
        }

        /// <summary>
        /// 
        /// </summary>
        public struct UpTjyutnoDataParam
        {
            /// <summary>
            /// ログイン担当者ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// アプリID
            /// </summary>
            public String aplId;
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
            /// 業務区分 
            /// </summary>
            public String GyoumKbn;
            /// <summary>
            /// タイムスポット区分 
            /// </summary>
            public String Tmspkbn;
        }


        /// <summary>
        /// 受注ダウンロード履歴データ検索パラメータ構造体 
        /// </summary>
        public struct FindJyutyuRirekiDataByCondParam
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
            /// 統合フラグ 
            /// </summary>
            public String touFlg;
            /// <summary>
            /// ファイルタイムスタンプ 
            /// </summary>
            public String fileTimStmp;
        }

        #endregion パラメータ構造体定義

        #region インスタンス変数

        /// <summary>
        /// 広告費明細入力プロセスコントローラ
        /// </summary>
        private static DetailProcessController _processController;

        /// <summary>
        /// 広告費明細入力サービスアダプター
        /// </summary>
        private detailServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private DetailProcessController()
        {
            _adapter = CreateAdapter<detailServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// 広告費明細入力プロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>広告費明細入力プロセスコントローラのインスタンス</returns>
        public static DetailProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new DetailProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 受注登録内容データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindJyutyuDataByCondServiceResult FindJyutyuDataByCond(FindJyutyuDataByCondParam param)
        {
            //サービス結果 
            FindJyutyuDataByCondServiceResult serviceResult = new FindJyutyuDataByCondServiceResult();

            jyutyuDataCondition condition = new jyutyuDataCondition();
            // TODO APLIDは仮的に設定 
            condition.aplId = "APLID";
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.yymmTo = param.yymmto;
            condition.kokKbn = param.kokKbn;
            condition.tmspKbn = param.tmspKbn;
            condition.gyomKbn = param.gyomKbn;
            condition.jyutNo = param.jyutNo;
            condition.orderKbn = param.orderKbn;
            condition.updateCheckFlag = param.updateCheckFlag;
            condition.kkNameKj = param.kkNameKj;

            //サービスの呼び出し 
            jyutyuDataCondResult result = _adapter.findJyutyuDataByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindJyutyuDataByCondParseResult parseResult = DetailParser.ParseForFindJutyuDataByCond(result);
            _dsDetail = parseResult.DetailDataSet;

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 表示データ(明細登録)登録 
        /// </summary>
        /// <param name="esqId"></param>
        /// <param name="dsDetail"></param>
        /// <param name="maxUpdDate"></param>
        /// <returns></returns>
        public UpdateDisplayDataServiceResult UpdateDisplayData(String esqId, KKHSchema.Detail dsDetail, DateTime maxUpdDate)
        {
            UpdateDisplayDataParam param = new UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            return UpdateDisplayData(param);
        }

        /// <summary>
        /// 表示データ登録 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateDisplayDataServiceResult UpdateDisplayData(UpdateDisplayDataParam param){
            //サービス結果 
            UpdateDisplayDataServiceResult serviceResult = new UpdateDisplayDataServiceResult();

            detailUpdateDataVO condition = new detailUpdateDataVO();
            condition.esqId = param.esqId;
            condition.thb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsDetail)[0];
            condition.thb2Kmei = DetailDataSetConverter.ConvertForTHB2KMEI(param.dsDetail);
            condition.maxUpdDate = param.maxUpdDate;
            //統合されている場合は統合元となった受注に登録者、更新者を書き込む
            if (param.TouKoudsDetail != null)
            {
                if (param.TouKoudsDetail.THB1DOWN.Count > 0)
                {
                    condition.touKouThb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsDetail)[0];
                }
            }
            detailUpdateDataResult result = _adapter.updateDisplayData(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            if (result.thb1Down != null)
            {
                serviceResult.DsDetail.THB1DOWN.Merge(DetailParser.ParseForTHB1DOWN(new thb1DownVO[] { result.thb1Down }));
            }
            if (result.thb2Kmei != null)
            {
                serviceResult.DsDetail.THB2KMEI.Merge(DetailParser.ParseForTHB2KMEI(result.thb2Kmei));
            }

            return serviceResult;
        }

        /// <summary>
        /// 広告費明細データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindDetailDataByCondServiceResult FindDetailDataByCond(FindDetailDataByCondParam param)
        {
            //サービス結果 
            FindDetailDataByCondServiceResult serviceResult = new FindDetailDataByCondServiceResult();

            detailDataCondition condition = new detailDataCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.jyutNo = param.jyutNo;
            condition.jyMeiNo = param.jyMeiNo;
            condition.urMeiNo = param.urMeiNo;

            //サービスの呼び出し 
            detailDataResult result = _adapter.findDetailDataByCond(condition);
            
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
            _dsDetail = parseResult.DetailDataSet;

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 一括登録 
        /// </summary>
        /// <param name="esqId">ログイン担当者ESQID</param>
        /// <param name="aplId">アプリID</param>
        /// <param name="egCd">営業所（取）コード</param>
        /// <param name="tksKgyCd">得意先企業コード</param>
        /// <param name="tksBmnSeqNo">得意先部門SEQNO</param>
        /// <param name="tksTntSeqNo">得意先担当SEQNO</param>
        /// <param name="dsDetail">広告費明細入力データセット(THB1DOWN)</param>
        /// <returns></returns>
        public RegisterBulkDataServiceResult RegisterBulkData(String esqId, String aplId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo, KKHSchema.Detail dsDetail,KKHSchema.Detail TouKouDetail)
        {
            //サービス結果 
            RegisterBulkDataServiceResult serviceResult = new RegisterBulkDataServiceResult();

            bulkDataRegisterVO bulkDataRegisterVO1 = new bulkDataRegisterVO();
            bulkDataRegisterVO1.esqId = esqId;
            bulkDataRegisterVO1.aplId = aplId;
            bulkDataRegisterVO1.egCd = egCd;
            bulkDataRegisterVO1.tksKgyCd = tksKgyCd;
            bulkDataRegisterVO1.tksBmnSeqNo = tksBmnSeqNo;
            bulkDataRegisterVO1.tksTntSeqNo = tksTntSeqNo;
            bulkDataRegisterVO1.thb1DownList = DetailDataSetConverter.ConvertForTHB1DOWN(dsDetail);
            bulkDataRegisterVO1.touIkkatsuThb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(TouKouDetail);
            bulkDataRegisterResult result = _adapter.registerBulkData(bulkDataRegisterVO1);

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
        /// 受注削除 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteJyutyuDataServiceResult DeleteJyutyuData(DeleteJyutyuDataParam param)
        {
            //サービス結果 
            DeleteJyutyuDataServiceResult serviceResult = new DeleteJyutyuDataServiceResult();

            jyutyuDataDeleteVO condition = new jyutyuDataDeleteVO();
            condition.esqId = param.esqId;
            condition.thb1DownList = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsDetail);
            condition.maxUpdDate = param.maxUpdDate;

            jyutyuDataDeleteResult result = _adapter.deleteJyutyuData(condition);

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
        /// 年月変更 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeSeikyuYymmServiceResult ChangeSeikyuYymm(ChangeSeikyuYymmParam param)
        {
            //サービス結果 
            ChangeSeikyuYymmServiceResult serviceResult = new ChangeSeikyuYymmServiceResult();

            seikyuYymmChangeVO condition = new seikyuYymmChangeVO();
            condition.esqId = param.esqId;
            condition.thb1DownList = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsDetail);
            condition.yymmNew = param.yymmNew;
            condition.maxUpdDate = param.maxUpdDate;

            seikyuYymmChangeResult result = _adapter.changeSeikyuYymm(condition);

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
        /// 受注No統合Update
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JyutNoTouUpdateServiceResult UpdateJyutNoTou(UpTjyutnoDataParam param)
        {
            JyutNoTouUpdateServiceResult serviceResult = new JyutNoTouUpdateServiceResult();
            jyutNoTouUpdateVO vo = new jyutNoTouUpdateVO();
            vo._esqId = param.esqId;
            vo._aplId = param.aplId;
            vo._egCd = param.egCd;
            vo._tksKgyCd = param.tksKgyCd;
            vo._tksBmnSeqNo = param.tksBmnSeqNo;
            vo._tksTntSeqNo = param.tksTntSeqNo;
            vo._YYMM = param.yymm;
            vo._keyJyutno = param.jyutNo;
            vo._keyJyMeiNo = param.jyMeiNo;
            vo._keyUriMeiNo = param.urMeiNo;
            vo._Gyomkbn = param.GyoumKbn;
            vo._Tmspkbn = param.Tmspkbn;
            jyutNoTouUpdateResult result = _adapter.JyutNoTouGou(vo);
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
        /// 受注No統合登録 
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public JyutNoTouInsServiceResult InsjyutNoTou(jyutNoTouInsVO vo)
        {
            JyutNoTouInsServiceResult serviceResult = new JyutNoTouInsServiceResult();
            jyutNoTouInsResult result = _adapter.JyutNoTouGouIns(vo);
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
        /// 新規登録 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RegisterJyutyuDataServiceResult RegisterJyutyuData(RegisterJyutyuDataParam param)
        {
            //サービス結果 
            RegisterJyutyuDataServiceResult serviceResult = new RegisterJyutyuDataServiceResult();

            jyutyuDataRegisterVO condition = new jyutyuDataRegisterVO();
            condition.esqId = param.esqId;
            condition.thb1DownList = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsDetail);

            jyutyuDataRegisterResult result = _adapter.registerJyutyuData(condition);

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
        /// 受注統合 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MergeJyutyuDataServiceResult MergeJyutyuData(MergeJyutyuDataParam param)
        {
            //サービス結果 
            MergeJyutyuDataServiceResult serviceResult = new MergeJyutyuDataServiceResult();

            jyutyuDataMergeVO condition = new jyutyuDataMergeVO();
            condition.esqId = param.esqId;
            condition.tougouSaki = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsTougouSaki)[0];
            condition.tougouMotoList = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsTougouMoto);
            condition.maxUpdDate = param.maxUpdDate;

            jyutyuDataMergeResult result = _adapter.mergeJyutyuData(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }
            //if (result.thb1DownList != null)
            //{
            //    serviceResult.DsDetail.THB1DOWN.Merge(DetailParser.ParseForTHB1DOWN(result.thb1DownList));
            //}

            return serviceResult;
        }

        /// <summary>
        /// 統合取消 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MergeCancelJyutyuDataServiceResult MergeCancelJyutyuData(MergeCancelJyutyuDataParam param)
        {
            //サービス結果 
            MergeCancelJyutyuDataServiceResult serviceResult = new MergeCancelJyutyuDataServiceResult();

            jyutyuDataMergeCancelVO condition = new jyutyuDataMergeCancelVO();
            condition.esqId = param.esqId;
            condition.tougouSaki = DetailDataSetConverter.ConvertForTHB1DOWN(param.dsTougouSaki)[0];
            condition.maxUpdDate = param.maxUpdDate;

            jyutyuDataMergeCancelResult result = _adapter.mergeCancelJyutyuData(condition);

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
        /// 受注ダウンロード履歴データ検索 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindJyutyuRirekiDataByCondServiceResult FindJyutyuRirekiDataByCond(FindJyutyuRirekiDataByCondParam param)
        {
            //サービス結果 
            FindJyutyuRirekiDataByCondServiceResult serviceResult = new FindJyutyuRirekiDataByCondServiceResult();

            thb8DownRCondition condition = new thb8DownRCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;
            condition.yymm = param.yymm;
            condition.jyutNo = param.jyutNo;
            condition.jyMeiNo = param.jyMeiNo;
            condition.urMeiNo = param.urMeiNo;
            condition.touFlg = param.touFlg;
            condition.fileTimStmp = param.fileTimStmp;

            //サービスの呼び出し 
            thb8DownRResult result = _adapter.findJyutyuRirekiDataByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindJyutyuRirekiDataByCondParseResult parseResult = DetailParser.ParseForFindJutyuRirekiDataByCond(result);
            _dsDetail = parseResult.DetailDataSet;

            // サービス結果の生成 
            serviceResult.DetailDataSet = parseResult.DetailDataSet;

            return serviceResult;
        }


        /// <summary>
        /// 明細登録(複数一括) 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public BulkUpdateDetailDataServiceResult BulkUpdateDetailData(BulkUpdateDetailDataParam param)
        {
            //サービス結果 
            BulkUpdateDetailDataServiceResult serviceResult = new BulkUpdateDetailDataServiceResult();

            detailDataBulkUpdateVO condition = new detailDataBulkUpdateVO();
            condition.esqId = param.esqId;
            List<detailDataVO> detailDataVoList = new List<detailDataVO>();
            foreach (KKHSchema.Detail dsDetail in param.dsDetailList)
            {
                detailDataVO detailDataVo = new detailDataVO();
                detailDataVo.thb1Down = DetailDataSetConverter.ConvertForTHB1DOWN(dsDetail)[0];
                detailDataVo.thb2Kmei = DetailDataSetConverter.ConvertForTHB2KMEI(dsDetail);
                detailDataVoList.Add(detailDataVo);
            }
            condition.detailDataVOList = detailDataVoList.ToArray();
            condition.maxUpdDate = param.maxUpdDate;

            detailDataBulkUpdateResult result = _adapter.bulkUpdateDetailData(condition);

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
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
using Isid.KKH.Ash.ProcessController.Detail.Parser;
using Isid.KKH.Main.ProcessController.Login.Parser;

namespace Isid.KKH.Main.ProcessController.Login
{
    /// <summary>
    /// ログインプロセスコントローラ
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
    ///       <description>2012/02/24</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class LoginProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region パラメータ構造体定義

        /// <summary>
        /// 業務会計セキュリティロール取得パラメータ構造体
        /// </summary>
        public struct GetAccountSecurityRoleParam
        {
            /// <summary>
            /// アプリID
            /// </summary>
            public String aplId;
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// パスワード
            /// </summary>
            public String password;
            /// <summary>
            /// セキュリティ情報 
            /// </summary>
            public byte[] securityInfo;
        }
        /// <summary>
        /// ログイン初期情報取得検索パラメータ構造体
        /// </summary>
        public struct GetLoginInitInfoParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 運用No. 
            /// </summary>
            public String operationNo;
        }
        /// <summary>
        /// 得意先情報取得検索パラメータ構造体
        /// </summary>
        public struct GetCustomerInfoParam
        {
            /// <summary>
            /// ログイン担当者ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// 得意先コード 
            /// </summary>
            public String customerCode;
        }
        /// <summary>
        /// ログインパラメータ構造体
        /// </summary>
        public struct LoginParam
        {
            /// <summary>
            /// ログイン担当者ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 運用No.
            /// </summary>
            public String operationNo;
            /// <summary>
            /// ユーザーID
            /// </summary>
            public String userId;
            /// <summary>
            /// パスワード
            /// </summary>
            public String password;
            /// <summary>
            /// 得意先コード
            /// </summary>
            public String customerCode;
            /// <summary>
            /// 通常ユーザーフラグ
            /// </summary>
            public String normalUserFlag;
            /// <summary>
            /// 相対権限
            /// </summary>
            public String relativeAuthority;
            /// <summary>
            /// 担当者所属組織コード
            /// </summary>
            public String organizationCode;
            /// <summary>
            /// ホスト営業日
            /// </summary>
            public String eigyoBi;
        }
        /// <summary>
        /// 開放得意先取得検索パラメータ構造体
        /// </summary>
        public struct GetOpenCustomerInfoParam
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

        #endregion パラメータ構造体定義

        #region インスタンス変数

        /// <summary>
        /// ログインプロセスコントローラ
        /// </summary>
        private static LoginProcessController _processController;

        /// <summary>
        /// ログインサービスアダプター
        /// </summary>
        private loginServiceAdapter _adapter;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private LoginProcessController()
        {
            _adapter = CreateAdapter<loginServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// ログインプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>ログインプロセスコントローラのインスタンス</returns>
        public static LoginProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new LoginProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 業務会計セキュリティロール取得
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public accountSecurityRoleResult GetAccountSecurityRole(GetAccountSecurityRoleParam param)
        {
            accountSecurityRoleCondition condition = new accountSecurityRoleCondition();
            condition.aplId = param.aplId;
            condition.esqId = param.esqId;
            condition.password = param.password;
            condition.securityInfo = param.securityInfo;

            //サービスの呼び出し 
            return _adapter.getAccountSecurityRole(condition);
        }

        /// <summary>
        /// ログイン初期情報取得
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public loginInitInfoResult GetLoginInitInfo(GetLoginInitInfoParam param)
        {
            loginInitInfoCondition condition = new loginInitInfoCondition();
            condition.esqId = param.esqId;
            condition.operationNo = param.operationNo;

            //サービスの呼び出し 
            return _adapter.getLoginInitInfo(condition);
        }

        /// <summary>
        /// 得意先情報取得
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public customerInfoResult GetCustomerInfo(GetCustomerInfoParam param)
        {
            customerInfoCondition condition = new customerInfoCondition();
            condition.esqId = param.esqId;
            condition.customerCode = param.customerCode;

            //サービスの呼び出し 
            return _adapter.getCustomerInfo(condition);
        }

        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public LoginServiceResult Login(LoginParam param)
        {
            //サービス結果 
            LoginServiceResult serviceResult = new LoginServiceResult();

            loginCondition condition = new loginCondition();
            condition.esqId = param.esqId;
            condition.operationNo = param.operationNo;
            condition.userId = param.userId;
            condition.password = param.password;
            condition.customerCode = param.customerCode;
            condition.normalUserFlag = param.normalUserFlag;
            condition.relativeAuthority = param.relativeAuthority;
            condition.organizationCode = param.organizationCode;
            condition.eigyoBi = param.eigyoBi;

            //サービスの呼び出し 
            ; loginResult result = _adapter.login(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;
                return serviceResult;
            }

            // パース 
            LoginParseResult parseResult = LoginParser.ParseForLogin(result);
            // サービス結果の生成 
            serviceResult.EgCd = result.egCd;
            serviceResult.UserName = result.userName;
            serviceResult.LoginCustomerDataSet = parseResult.LoginCustomerDataSet;
            serviceResult.SystemAdministerFlg = result._SystemAdministerFlg;



            return serviceResult;
        }

        /// <summary>
        /// 開放得意先情報取得
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public openCustomerInfoResult GetOpenCustomerInfo(GetOpenCustomerInfoParam param)
        {
            openCustomerInfoCondition condition = new openCustomerInfoCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;

            //サービスの呼び出し 
            return _adapter.getOpenCustomerInfo(condition);
        }

       #endregion メソッド
    }
}
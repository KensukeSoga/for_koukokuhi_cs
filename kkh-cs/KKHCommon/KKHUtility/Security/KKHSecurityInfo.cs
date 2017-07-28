using System;
using System.Collections.Generic;
using System.Text;

using Isid.NJSecurity.Core;
using Isid.NJSecurity.Sso;

namespace Isid.KKH.Common.KKHUtility.Security
{
    /// <summary>
    /// セキュリティ情報保持クラス
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
    ///       <description>2011/11/01</description>
    ///       <description>HLC sonobe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class KKHSecurityInfo
    {
        #region メンバ変数

        /** セキュリティ情報 */
        private ISecurityInfo _securityInfo;
        /** 相対権限 */
        private string _relativeAuthority;
        /** セキュリティロール取得対象外フラグ */
        private bool _notSecurityRoleFlag;
        /** 自身のインスタンス(singleton)*/
        private static KKHSecurityInfo _instance = new KKHSecurityInfo();

        #endregion メンバ変数


        #region プロパティ

        /// <summary>
        /// セキュリティ情報 
        /// </summary>
        public ISecurityInfo SecurityInfo
        {
            set { _securityInfo = value; }
            get { return _securityInfo; }
        }

        /// <summary>
        /// 相対権限 
        /// </summary>
        public string RelativeAuthority
        {
            set { _relativeAuthority = value; }
            get { return _relativeAuthority; }
        }

        /// <summary>
        /// セキュリティロール取得対象外フラグ 
        /// </summary>
        public bool NotSecurityRoleFlag
        {
            set { _notSecurityRoleFlag = value; }
            get { return _notSecurityRoleFlag; }
        }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get
            {
                if (_securityInfo != null)
                {
                    return _securityInfo.GetUserInfo().Name;
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// UserEsqId
        /// </summary>
        public string UserEsqId
        {
            get
            {
                if (_securityInfo != null)
                {
                    return _securityInfo.GetUserInfo().ID;
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion プロパティ


        #region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        private KKHSecurityInfo()
        {
        }

        #endregion コンストラクタ


        #region メソッド

        /// <summary>
        /// インスタンスを返します 
        /// </summary>
        /// <returns></returns>
        public static KKHSecurityInfo GetInstance()
        {
            return _instance;
        }

        #endregion メソッド
    }
}

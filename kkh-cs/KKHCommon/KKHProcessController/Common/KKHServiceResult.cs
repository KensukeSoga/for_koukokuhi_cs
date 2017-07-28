using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Common
{

    /// <summary>
    /// サービス結果基底クラス
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
    ///       <description>2011/10/01</description>
    ///       <description>HLC sonobe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// エラー可否フラグ 
        /// </summary>
        private bool _hasError;

        /// <summary>
        /// エラー可否フラグを取得します。 
        /// </summary>
        public bool HasError
        {
            get { return _hasError; }
        }

        /// <summary>
        /// メッセージコード 
        /// </summary>
        private string _messageCode;

        /// <summary>
        /// メッセージコードを取得または設定します。 
        /// </summary>
        public string MessageCode
        {
            get { return _messageCode; }
            set
            {
                if (value != null)
                {
                    _hasError = true;
                }
                _messageCode = value;
            }
        }

        /// <summary>
        /// メッセージ情報 
        /// </summary>
        private string[] _note;

        /// <summary>
        /// メッセージ情報を取得または設定します。 
        /// </summary>
        public string[] Note
        {
            get { return _note; }
            set { _note = value; }
        }

        #endregion プロパティ
    }
}

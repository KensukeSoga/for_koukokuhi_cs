using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Common
{
    /// <summary>
    ///  チェック処理の結果を表す 
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
    ///       <description>2011/01/21</description>
    ///       <description>ISID-IT T.Kamidai</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class CheckResult
    {
        /// <summary>
        /// メッセージIDが設定されているかを表す 
        /// </summary>
        private bool _hasWarning = false;

        /// <summary>
        /// メッセージIDが設定されているかを表す 
        /// </summary>
        public bool HasWarning
        {
            get {return _hasWarning; }
        }

        /// <summary>
        /// メッセージID
        /// </summary>
        private string _messageCode;

        /// <summary>
        /// メッセージID
        /// </summary>
        public string MessageCode
        {
            get { return _messageCode; }
            set {
                //メッセージIDがセットされたらHasWarningをTrueにする 
                if (value != null)
                {
                    _hasWarning = true;
                }

                _messageCode = value; 
            }
        }

        /// <summary>
        /// メッセージ情報 
        /// </summary>
        private object[] _note;

        /// <summary>
        /// メッセージ情報 
        /// </summary>
        public object[] Note
        {
            get { return _note; }
            set { _note = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.NJ.Util.Message;

namespace Isid.KKH.Common.KKHView.Common
{

    /// <summary>
    /// メッセージユーティリティ
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
    ///       <description>2012/02/01</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class MessageUtility
    {

        #region インスタンス変数

        /// <summary>
        /// システムコード
        /// </summary>
        private const string SYSTEM_CODE = "HB000000";

        /// <summary>
        /// エラーレベル：情報
        /// </summary>
        private const string ERR_LEVEL_INFORMASION = "I";

        /// <summary>
        /// エラーレベル：確認
        /// </summary>
        private const string ERR_LEVEL_CONFIRM = "C";

        /// <summary>
        /// エラーレベル：警告
        /// </summary>
        private const string ERR_LEVEL_WARNING = "W";

        /// <summary>
        /// エラーレベル：エラー
        /// </summary>
        private const string ERR_LEVEL_ERROR = "E";

        /// <summary>
        /// 変換前改行コード
        /// </summary>
        private const string CONVERT_FROM_CARRIAGE_RETURN = "\\r";

        /// <summary>
        /// 変換後改行コード
        /// </summary>
        private const string CONVERT_TO_CARRIAGE_RETURN = "\r";

        /// <summary>
        /// 変換前復帰コード
        /// </summary>
        private const string CONVERT_FROM_LINE_FEED = "\\n";

        /// <summary>
        /// 変換後復帰コード
        /// </summary>
        private const string CONVERT_TO_LINE_FEED = "\n";


        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// privateコンストラクタです。
        /// </summary>
        private MessageUtility()
        {
        }

        #endregion コンストラクタ

        #region パブリックメソッド

        /// <summary>
        /// メッセージボックスを表示します。（初期選択ボタン指定あり）
        /// </summary>
        /// <param name="messageCode">メッセージコード</param>
        /// <param name="messageParam">メッセージパラメータ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="buttonType">ボタン種類</param>
        /// <param name="defaultButton">初期選択ボタン</param>
        /// <returns>ダイアログボックスの戻り値を示す識別子</returns>
        public static DialogResult ShowMessageBox(string messageCode, string[] messageParam, string caption, MessageBoxButtons buttonType,
            MessageBoxDefaultButton defaultButton)
        {
            MessageCatalog messageCatalog = MessageCatalogLoader.GetErrorMessage(messageCode, SYSTEM_CODE, messageParam);
            string message = messageCatalog.GetMessage();
            message = ConvertEndOfLine(message);
            MessageBoxIcon icon = SelectIcon(messageCatalog.GetMsgType());
            return MessageBox.Show(message, caption, buttonType, icon, defaultButton);
        }

        /// <summary>
        /// メッセージボックスを表示します。（初期選択ボタン指定なし）
        /// </summary>
        /// <param name="messageCode">メッセージコード</param>
        /// <param name="messageParam">メッセージパラメータ</param>
        /// <param name="caption">キャプション</param>
        /// <param name="buttonType">ボタン種類</param>
        /// <returns>ダイアログボックスの戻り値を示す識別子</returns>
        public static DialogResult ShowMessageBox(string messageCode, string[] messageParam, string caption, MessageBoxButtons buttonType)
        {
            return ShowMessageBox(messageCode, messageParam, caption, buttonType, MessageBoxDefaultButton.Button1);
        }

        #endregion パブリックメソッド

        #region プライベートメソッド

        /// <summary>
        /// アイコン選択
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <returns>アイコン</returns>
        private static MessageBoxIcon SelectIcon(string errLevel)
        {
            if (ERR_LEVEL_INFORMASION.Equals(errLevel))
            {
                return MessageBoxIcon.Information;
            }
            else if (ERR_LEVEL_CONFIRM.Equals(errLevel))
            {
                return MessageBoxIcon.Question;
            }
            else if (ERR_LEVEL_WARNING.Equals(errLevel))
            {
                return MessageBoxIcon.Warning;
            }
            else
            {
                return MessageBoxIcon.Error;
            }
        }

        /// <summary>
        /// 行終端文字変換
        /// </summary>
        /// <param name="message">変換前文字列</param>
        /// <returns>変換後文字列</returns>
        private static String ConvertEndOfLine(string message)
        {
            // 水平タブ等にも対応するのであれば、メソッド名をConvertEscapeSequence等に変更して下さい。

            // 改行コードの変換
            message = message.Replace(CONVERT_FROM_CARRIAGE_RETURN, CONVERT_TO_CARRIAGE_RETURN);

            // 復帰コードの変換
            message = message.Replace(CONVERT_FROM_LINE_FEED, CONVERT_TO_LINE_FEED);

            return message;
        }

        #endregion プライベートメソッド
    }
}

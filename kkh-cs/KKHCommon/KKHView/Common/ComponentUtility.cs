using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common
{
    /// <summary>
    /// Componentユーティリティ 
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
    ///       <description>2011/01/27</description>
    ///       <description>ISID-IT T.Kamidai</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal static class ComponentUtility
    {
        /// <summary>
        /// DoEventsを行います。 
        /// DoEventsを呼び出すと、ボタン連打などでイベントがキューに溜まってしまい、 
        /// 予期せぬ挙動を起こすことが有ります。 
        /// そこで、DoEventsの前にコントロールを無効化してからDoEventsを行い、その後 
        /// コントロールを元に戻します。 
        /// </summary>
        /// <param name="target"></param>
        internal static void RgDoEvents(System.Windows.Forms.Form target)
        {
            //DoEventsを行う前に引数のコントロールに貼り付けられているコントロールをDisableにします。 
            Boolean[] enabledStatus = DisableTopLevelControls(target);
            //画面右上の×ボタンも一時的に非表示にします。 
            Boolean blnControlBoxVisible = target.ControlBox;
            target.ControlBox = false;

            Application.DoEvents();

            //画面右上の×ボタンを表示します。 
            target.ControlBox = blnControlBoxVisible;
            //DoEventsの後でDisable制御したものを元に戻します。 
            ResetEnabledTopLevelControls(target, enabledStatus);
        }

        /// <summary>
        /// 引数のコントロールに貼られているコントロールをDisableにします。 
        /// 戻り値はDisable化する前のコントロールのEnable状態を配列にしたものです。 
        /// </summary>
        /// <param name="target">対象コントロール</param>
        /// <returns>Disable化する前のコントロールのEnable状態配列</returns>
        private static Boolean[] DisableTopLevelControls(System.Windows.Forms.Form target)
        {
            Boolean[] enabledStatus = new Boolean[target.Controls.Count];

            int index = 0;
            foreach (System.Windows.Forms.Control control in target.Controls)
            {
                enabledStatus[index] = control.Enabled;
                control.Enabled = false;
                index++;
            }

            return enabledStatus;
        }

        /// <summary>
        /// 引数のコントロールに貼られているコントロールのEnable制御を行います。  
        /// </summary>
        /// <param name="target">対象コントロール</param>
        /// <param name="enabledStatus">コントロールのEnable状態配列</param>
        private static void ResetEnabledTopLevelControls(System.Windows.Forms.Form target, Boolean[] enabledStatus)
        {
            int index = 0;
            foreach (System.Windows.Forms.Control control in target.Controls)
            {
                control.Enabled = enabledStatus[index];
                index++;
            }
        }
    }
}

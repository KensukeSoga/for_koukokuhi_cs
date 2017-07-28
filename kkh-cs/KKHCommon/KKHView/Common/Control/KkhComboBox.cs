using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJ.View.Widget;

namespace Isid.KKH.Common.KKHView.Common.Control
{
    /// <summary>
    /// イベント拡張コンボボックス
    /// ※コンボリストを開いているときにフォーカス移動した際、 
    /// OnSelectionChangeCommittedイベントが発生するように拡張しています。 
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
    ///       <description>2011/02/03</description>
    ///       <description>ISID-IT T.Kamidai</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class KkhComboBox : NJComboBox
    {
        /// <summary> コンボで選択しているインデックス </summary>
        int index;

        /// <summary>
        /// コンボリストが開いたときのイベント 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);

            // インデックスを保持する 
            index = this.SelectedIndex;
        }

        /// <summary>
        /// 選択変更確定時のイベント 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            // OnDropDownClosedイベントが途中で発生するため、インデックスを保持する 
            index = this.SelectedIndex;

            base.OnSelectionChangeCommitted(e);
        }

        /// <summary>
        /// コンボリストが閉じるときのイベント 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);

            // インデックスが変更されたときのみイベントを実行させる 
            if (index != this.SelectedIndex)
            {
                this.OnSelectionChangeCommitted(e);
            }

        }

    }
}

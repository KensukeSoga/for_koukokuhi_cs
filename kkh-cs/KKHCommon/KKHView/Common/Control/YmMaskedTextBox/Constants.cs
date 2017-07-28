namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    /// <summary>
    /// マスクに使用する形式を定義します。 
    /// </summary>
    internal enum MaskText : int
    {
        /// <summary>
        /// マスク未使用 
        /// </summary>
        NO_MASK = 0,
        /// <summary>
        /// YYYY/MMを設定します 
        /// </summary>
        SLASH = 1
    }

    /// <summary>
    /// 年月入力コントロール関係で使用する定数を管理するクラス 
    /// </summary>
    internal class YmControlConst
    {
        /// <summary>
        /// YmMaskedTextBoxの入力可能最大値 
        /// </summary>
        internal const string INPUT_MAXVALUE = "204912";
        /// <summary>
        /// YmMaskedTextBoxの入力可能最小値 
        /// </summary>
        internal const string INPUT_MINVALUE = "195001";
    }

    /// <summary>
    /// 表示するモード
    /// </summary>
    public enum DisplayMode : int
    {
        /// <summary>
        /// テキストボックス＋ボタン 
        /// </summary>
        TEXT_BUTTON = 0,
        /// <summary>
        /// コンボボックス 
        /// </summary>
        COMBO = 1
    }
}
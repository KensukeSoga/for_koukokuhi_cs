namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    /// <summary>
    /// �}�X�N�Ɏg�p����`�����`���܂��B 
    /// </summary>
    internal enum MaskText : int
    {
        /// <summary>
        /// �}�X�N���g�p 
        /// </summary>
        NO_MASK = 0,
        /// <summary>
        /// YYYY/MM��ݒ肵�܂� 
        /// </summary>
        SLASH = 1
    }

    /// <summary>
    /// �N�����̓R���g���[���֌W�Ŏg�p����萔���Ǘ�����N���X 
    /// </summary>
    internal class YmControlConst
    {
        /// <summary>
        /// YmMaskedTextBox�̓��͉\�ő�l 
        /// </summary>
        internal const string INPUT_MAXVALUE = "204912";
        /// <summary>
        /// YmMaskedTextBox�̓��͉\�ŏ��l 
        /// </summary>
        internal const string INPUT_MINVALUE = "195001";
    }

    /// <summary>
    /// �\�����郂�[�h
    /// </summary>
    public enum DisplayMode : int
    {
        /// <summary>
        /// �e�L�X�g�{�b�N�X�{�{�^�� 
        /// </summary>
        TEXT_BUTTON = 0,
        /// <summary>
        /// �R���{�{�b�N�X 
        /// </summary>
        COMBO = 1
    }
}
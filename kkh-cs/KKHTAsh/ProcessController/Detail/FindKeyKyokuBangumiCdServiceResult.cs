using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Ash.ProcessController.Detail
{
    /// <summary>
    /// �����T�[�r�X����.
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ�.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2014/08/15</description>
    ///       <description>HLC ��(Jang)</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindKeyKyokuBangumiCdServiceResult : KKHServiceResult
    {
        #region �v���p�e�B

        /// <summary>
        /// �ėp�f�[�^�Z�b�g�ł��B.
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh _dsDetailAsh;

        /// <summary>
        /// �ėp�f�[�^�Z�b�g���擾�܂��͐ݒ肵�܂��B.
        /// </summary>
        public Isid.KKH.Ash.Schema.DetailDSAsh DetailAshDataSet
        {
            get { return _dsDetailAsh; }
            set { _dsDetailAsh = value; }
        }
        #endregion �v���p�e�B
    }
}

